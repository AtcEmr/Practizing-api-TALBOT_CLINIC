# SQL Server to PostgreSQL Migration Plan

This document is a migration review plan for moving the PractiZing API database layer from SQL Server to PostgreSQL and, specifically, for moving away from SQL Server stored procedures over time.

It is based on:

- API source code in this repository.
- Generated SQL Server schema artifacts in `docs/database/PI_ATC_CLINIC_schema.*`.
- Live metadata inspection of `PI_ATC_CLINIC`.

No application code changes were made for this review.

## Executive Summary

This project cannot be moved from SQL Server to PostgreSQL by only changing connection strings. The API, schema, and stored procedure model are tightly coupled to SQL Server.

The safest practical path is a staged migration:

1. Stabilize the current build and test baseline.
2. Create a database portability layer in the API so SQL Server and PostgreSQL behavior can be isolated behind common interfaces.
3. Convert the SQL Server schema and data into a PostgreSQL-compatible model.
4. Treat stored procedures as a migration workstream, not as an afterthought.
5. Port only the procedures required for an initial PostgreSQL cutover.
6. Gradually retire stored procedures by moving business rules, report queries, and scrub rules into tested application services.
7. Use dual-run validation against SQL Server until billing, claims, payments, denials, statements, and reports match.

Recommended end-state:

- PostgreSQL owns durable data, constraints, indexes, and simple views.
- The API owns billing workflow, scrub rules, report orchestration, and integration logic.
- Remaining database functions are limited to simple read-model helpers where database execution is clearly beneficial.
- Stored procedure names should no longer be stored as executable configuration in business tables.

## Stack Decisions (Phase 0 prerequisites)

The original plan correctly says "stabilize first" but leaves several foundational decisions open. Each one cascades into a half-dozen downstream choices and rules out specific tooling paths. They must be made before any phase work begins; deferring them stalls the project.

### .NET runtime target

**Target: .NET 8 LTS.**

Reasoning:
- .NET Core 2.1 has been out of support since August 2021. No security patches; many modern packages no longer publish 2.1-compatible builds.
- .NET 8 is the current LTS through November 2026. Skip .NET 6 (EOL November 2024 — forces a second migration sooner) and .NET 9 (STS, only 18 months of support).
- This decision must happen before the PostgreSQL provider work because the Npgsql / OrmLite versions you can use are gated on the runtime.

What this forces:
- ServiceStack OrmLite must move from `5.0.2` to a current version supporting .NET 8. License/version check required.
- JWT handling moves from the legacy stack to current `Microsoft.AspNetCore.Authentication.JwtBearer`. The custom `PractiZingJwtTokenHandler` has to be revalidated against the current handler.
- `EdiFabric` license + version must be revalidated against modern .NET. EdiFabric publishes a `.NET 6+` SDK; verify the team's license covers it.
- Replace `System.Data.SqlClient` with `Microsoft.Data.SqlClient` even before introducing Npgsql — the former is on life support.
- Defer `Newtonsoft.Json` → `System.Text.Json` to a post-migration project. The surface change is too wide to ride along.

When this happens: **Phase 1 (baseline)**. The PostgreSQL work cannot start in earnest until the build is green on .NET 8.

### Data-access library

**Recommendation: keep ServiceStack OrmLite. Change the dialect from `SqlServerDialect.Provider` to `PostgreSqlDialect.Provider`. Do not switch to EF Core or pure Dapper as part of this migration.**

Why not EF Core:
- 275 tables × 4775 columns × `[Alias]`-decorated entities × multi-tenant per-connection routing in `DataBaseContext` is not a 6-month rebuild — it is a 12-18 month rewrite. Combining that with the database engine change is two migrations at once. Don't.

Why not Dapper-only:
- The repositories rely on OrmLite's typed `Connection.SelectAsync<T>(predicate)` ergonomics. Replacing those with hand-written SQL erases the type safety and amplifies the SQL-injection surface that was just hardened.

What the OrmLite path forces:
- Verify the current ServiceStack license bundle includes `ServiceStack.OrmLite.PostgreSQL`.
- OrmLite supports running multiple dialects from one `OrmLiteConnectionFactory` — that's how the dual-run pilot will keep some tenants on SQL Server while one tenant moves to PG. Confirm before committing.
- Audit every use of SQL-Server-only OrmLite features: `OrmLiteConfig.SqlExpressionSelectFilter`, dialect-specific `Sql.Custom`, raw `WITH (NOLOCK)` hints in `Connection.ExecAsync`. Each must move behind `IDatabaseDialect` (see "Concrete Boundary Interfaces" below).

### Multi-tenant model

**Recommendation: schema-per-practice within a single PostgreSQL cluster.**

Decision matrix:

| Model | Pros | Cons | Verdict |
|---|---|---|---|
| **Database-per-practice** (current SQL Server pattern) | Maximum isolation; per-tenant PITR; simple permission model | High operational cost (every tenant onboarding = create DB, run migrations, register connection); cross-practice analytics needs federation; PG is more memory-bound per DB than SQL Server | **NO**. Doesn't scale ops. |
| **Schema-per-practice** | One cluster, one connection pool; cross-practice analytics with `UNION ALL`; cheaper backups; trivial dual-run (just skip schemas not yet migrated) | Migrations applied per-schema (tooling needed); permission model needs care; isolation depends on app correctness | **YES**. Best fit: `DataBaseContext` already routes per practice — change "open the right DB" to "set `search_path TO practice_<code>, public`". |
| **Shared tables, tenant column** | Simplest schema; easiest cross-tenant queries | Largest blast radius for app bugs (a missing `WHERE PracticeId = ?` leaks data across practices); per-tenant PITR is hard; row-level security is real work to set up and audit | **NO**. The current code already misses PracticeId filters in places (`BaseRepository.cs:48` defaults to 1). Shared-table model amplifies that bug class — unacceptable for medical billing data. |

What schema-per-practice forces:
- `DataBaseContext` simplifies — one connection factory; `search_path` set per request from the host header.
- Migration tooling: a per-schema runner. Recommend Flyway (battle-tested for multi-schema), or Liquibase. Avoid hand-rolled.
- Backup strategy: full-cluster PITR + selective `pg_dump` per schema for tenant-level recovery.
- Coolify deployment: one PG service, not 30. Simpler operationally.
- New-tenant onboarding becomes "create schema, run migrations, no app config change" — better than today.

### Naming strategy

**Recommendation: preserve PascalCase using quoted identifiers in PostgreSQL. Defer the lower_snake_case rename to a separate post-migration project.**

Why preserve:
- 275 OrmLite `[Alias("Charge")]`-style decorations + raw SQL strings + 138 SP bodies all encode PascalCase column references. Renaming during the migration multiplies risk for no current value.
- PostgreSQL handles quoted identifiers correctly; performance is identical.
- The rename can be done idiomatically *after* PostgreSQL is in production, table-by-table, with the test coverage that's been built up during dual-run.

Cost of this choice:
- Every raw SQL string must use `"PascalCase"` quoting. Add a CI lint rule or grep check.
- Some PG tooling (psql tab-completion, some IDE integrations) assumes lower-case. Document in the runbook.

If the team chooses lower_snake_case anyway: budget +3 months and add a Phase 5.5 "Rename apply" step. Do NOT mix the two strategies inside one migration.

### Data-migration tooling

**Recommendation: `pgloader` for bulk transfer + custom C# validators for finance, FK integrity, and case-sensitivity.**

Why not AWS DMS / Azure DMS:
- The source DB is on-prem (`10.3.104.52`). Routing data to a cloud-managed service for transformation adds compliance burden (PHI in transit through a third-party service) and bandwidth cost. Only consider if the destination PG is also in that cloud.

Why not SSIS:
- Heavy investment for a one-shot migration; harder to rerun cleanly during testing iterations.

Why not pure custom C#:
- pgloader handles 80% of the schema-to-schema mechanics for free: type mapping, GUID→uuid, bit→boolean, COPY-based bulk loading, sequence resync. Reinventing that costs weeks.

What pgloader handles automatically:
- Type mapping per the table in §"Current Data Type Usage".
- Identity column → sequence with the correct start value.
- Bulk COPY for performance (orders of magnitude faster than INSERT).
- Most default-constraint translation.

What you must validate in custom C# (cannot rely on pgloader):
1. **Money totals per table** — sum SQL Server, sum PostgreSQL, fail if delta > $0.01. Tables to validate: `Charge`, `Payment`, `PaymentAdjustment`, `Voucher`, `Invoice`, `ChargeBatch`, `PaymentBatch`. This is the financial-correctness gate.
2. **FK orphan checks** across the 140 declared foreign keys. SQL Server may have rows that violate FKs (if the FK was added with `WITH NOCHECK`); PG will reject them.
3. **Case-insensitive uniqueness collisions.** SQL Server's CI collation may have allowed `'Smith'` and `'SMITH'` as distinct rows that PG sees as duplicate. Affected columns: usernames, practice codes, CPT, ICD, modifiers, payer names, NDC.
4. **Computed-column reproduction** — the 4 computed columns. Confirm PG generated columns or views produce identical values for sample rows.
5. **Row counts per table** — necessary but not sufficient.
6. **Trigger-fired audit row reconciliation** — see "Trigger Migration Strategy" below.

### Phase 0 security cleanup (mandatory before any migration work)

The current codebase has secrets that will be carried into migration artifacts unless cleaned up first. This is not optional and not deferrable.

| Secret | Location | Action | Owner |
|---|---|---|---|
| JWT signing secret | `Common/.../ConfigureAuthServices.cs` (string literal) | Move to `Configuration["Jwt:Secret"]` env var. **Rotate the value** — assume the literal has leaked. | Security/backend |
| Dev DB password | `appsettings.Development.json` (per service) | Remove from git history (`git filter-repo`). Replace with placeholder. Document local-dev override via env. | Backend lead |
| Dev DB IP `10.3.104.52` | `appsettings.Development.json` | Remove. Default `localhost` for new dev setups. Current value only resolves on team VPN anyway. | Backend lead |
| EMR credentials in JWT claims | `Common/.../IdentityUser.cs` (claims sent to UI) | Stop putting them in claims (preferred — call EMR server-side), or at minimum encrypt with a key not visible to the client. | Security |
| ServiceStack license key | If checked in, audit. | Move to env var. Rotate if appropriate. | Backend lead |
| Permission filter disabled | `Common/.../SecuredFilterAttribute.cs` (commented out) | Either re-enable with role/permission lookup wired up, OR remove `[Authorize]` from endpoints that intentionally accept any authenticated user, so the contract is honest. Today's behavior is "every authenticated user can hit every endpoint." | Security |

**Do not start writing PostgreSQL adapter code with the JWT secret still committed.** You will copy it into the migration artifacts and re-leak it. The same applies to dev DB credentials — pgloader configs and DBA scripts that reference them will end up in the migration repo.

### Pilot tenant selection rubric

The plan correctly says "one low-risk practice moves first" but doesn't say how to choose. Use this rubric. The pilot must exercise enough surface to be a real test, but not so much that a regression takes down a major customer.

A good pilot tenant has:
1. **Moderate billing volume.** ≥1000 charges/month so the data-warehouse SPs see real load, but not the largest-revenue practice. (Don't pilot on the customer who'll notice an outage first.)
2. **Active claim submission.** Outbound 837 traffic and inbound 835 ERAs running through the pipeline weekly, so EDI and ERA-payment-posting workflows are exercised.
3. **At least one denial-management user.** The denial dashboard SPs are a common failure point; pilot must hit them in real workflows.
4. **At least 2 of: Plaid, MethaSoft, Catalyst, Chase integrations enabled.** External-integration SPs are a risk surface that internal-only pilots wouldn't catch.
5. **Standard insurance mix** — Medicare + Medicaid + 2-3 commercial. Not a lab-only or single-payer practice, since those exercise narrower SPs.
6. **Clean reconciliation history.** No open billing disputes that would conflate "real bug" with "migration noise."
7. **Cooperative practice manager** willing to do golden-master comparisons (week 1 reports run on both DBs, manager signs off on parity).
8. **Geographically simple** — single time-zone, no overlap-hours concerns during cutover.

Anti-patterns (do NOT pilot on):
- The largest-revenue practice (blast radius).
- The most complex setup (too many variables).
- A new practice (no historical data to compare against).
- A practice with active billing-correctness audits (you'd contaminate the audit).

Pilot duration: 4 weeks of dual-run before considering cutover. Two month-end closes within the pilot, since month-end exposes batch jobs and aging reports that don't run daily.

## Current SQL Server Coupling

### Application Coupling

| Area | Current finding | Migration implication |
|---|---|---|
| Runtime | API targets old .NET Core 2.1 projects. | Modern PostgreSQL provider support will be easier after upgrading the runtime. Do not start the database migration until the solution can build reliably. |
| ORM/provider | `Common/PractiZing.DataAccess.Common/PractiZing.DataAccess.Common.csproj` references `ServiceStack.OrmLite.SqlServer` version `5.0.2`. | Replace or abstract the provider. PostgreSQL requires a PostgreSQL OrmLite provider or a different data access layer. |
| Connection registration | `HostService/HostService.Api/Startup.cs` creates `OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider)` and registers each practice using `SqlServerDialect.Provider`. | A PostgreSQL migration must redesign provider registration for `PracticeCentral` and every practice database. |
| Multi-tenant routing | `Common/PractiZing.DataAccess.Common/DataBaseContext.cs` derives practice code from request origin and opens a named OrmLite connection. | Decide whether each practice becomes a separate PostgreSQL database, a separate schema, or a tenant key inside shared tables. |
| Direct SQL Server ADO.NET | 15 C# files use `System.Data.SqlClient`, `SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `SqlParameter`, or `SqlDbType`. | These calls must move to provider-neutral abstractions or to Npgsql-specific implementations. |
| Generic procedure helper | `Common/PractiZing.BusinessLogic.Common/BaseRepository.cs` builds `exec {functionName} {params}` strings. | This is SQL Server-specific and unsafe. PostgreSQL needs parameterized `select * from function(...)`, `call`, or application-side query handlers. |
| Stored procedure calls | 23 `ExecuteStoredProcedureAsync` call sites were found in code. | Each call needs a migration disposition: retire, port, or replace with query service. |
| Direct `CommandType.StoredProcedure` | 7 direct `CommandType.StoredProcedure` usages were found. | PostgreSQL functions/procedures do not behave like SQL Server stored procedures. Result handling must be redesigned. |
| Report execution | `ReportRepository` executes command text from `dbo.PZ_Report.Command` via `SqlCommand.CommandText`. | Reports are data-driven SQL. These commands must be converted to parameterized report definitions or report query services. |
| Scrub execution | `ClaimBatchRepository.RunAutoScrub` accepts a procedure name and passes a SQL Server table-valued parameter to a stored procedure. | This is one of the highest-risk migration areas. It should become a scrub rule engine or a PostgreSQL-specific rule executor. |
| Raw SQL strings | At least 191 raw SQL indicators were found. Some are comments or false positives, but there are real examples using `SELECT`, `TOP`, `exec`, string concatenation, and SQL Server table names. | Raw SQL must be inventoried, parameterized, and converted to PostgreSQL syntax. |

### Database Inventory

| Object type | Count |
|---|---:|
| User tables | 275 |
| Columns | 4,775 |
| Identity columns | 231 |
| Computed columns | 4 |
| Default constraints | 272 |
| Foreign keys | 140 |
| Indexes | 259 |
| Check constraints | 1 |
| Views | 16 |
| Stored procedures | 138 |
| Functions | 23 |
| Triggers | 221 |
| User-defined table types | 1 |

Current SQL Server collation:

- `SQL_Latin1_General_CP1_CI_AS`
- 2,355 text columns use this collation.

This matters because SQL Server is currently case-insensitive. PostgreSQL is case-sensitive by default unless you design for case-insensitive behavior using `citext`, nondeterministic ICU collations, normalized lower-case columns, or functional indexes such as `lower(column)`.

### Current Data Type Usage

| SQL Server type | Count | PostgreSQL target recommendation |
|---|---:|---|
| `varchar` | 2,065 | `varchar(n)` or `text`. Preserve length where validation depends on it. |
| `int` | 709 | `integer` |
| `bit` | 490 | `boolean` |
| `datetime` | 415 | `timestamp without time zone`, unless the column represents an absolute instant. |
| `smallint` | 297 | `smallint` |
| `nvarchar` | 238 | `varchar(n)` or `text`. PostgreSQL text is UTF-8. |
| `money` | 193 | `numeric(19,4)` or domain type over `numeric(19,4)`. Avoid PostgreSQL `money`. |
| `uniqueidentifier` | 104 | `uuid` |
| `date` | 101 | `date` |
| `bigint` | 59 | `bigint` |
| `char` | 39 | `char(n)` or `varchar(n)` depending on semantics. |
| `decimal` | 19 | `numeric(p,s)` |
| `tinyint` | 13 | `smallint` with check constraint `0 <= value <= 255`, if needed. |
| `text` | 9 | `text` |
| `float` | 7 | `double precision` |
| `image` | 5 | `bytea` |
| `varbinary` | 3 | `bytea` |
| `PatientBillingID` | 3 | User-defined alias over `varchar(20)`. Convert to a PostgreSQL domain or plain `varchar(20)`. |
| `datetime2` | 3 | `timestamp` with appropriate precision. |
| `real` | 2 | `real` |
| `sysname` | 1 | `varchar(128)` or `text` |

### SQL Server Defaults and Computed Columns

Common defaults:

- `((0))`: 98 uses.
- `((1))`: 55 uses.
- `(newid())`: 39 uses. PostgreSQL equivalent should be `gen_random_uuid()` from `pgcrypto`, or `uuid_generate_v4()` from `uuid-ossp`.
- `(getdate())`: 32 uses. PostgreSQL equivalent is usually `now()` or `CURRENT_TIMESTAMP`.
- `(sysutcdatetime())`: 1 use. PostgreSQL equivalent is usually `timezone('utc', now())` or a `timestamptz` design.

Computed columns:

- `dbo.AdjustmentReasonCode.ReasonCode`: `GroupCode + '-' + Code`
- `dbo.ChargeOld.RealPostDate`: `dateadd(second, PostTime, PostDate)`
- `dbo.ConfigAdjustmentReasonCode.ReasonCode`: `GroupCode + '-' + Code`
- `dbo.ConfigAdjustmentReasonCode.Description`: `Category`

PostgreSQL options:

- Convert simple computed columns to generated columns.
- Convert complex or compatibility-sensitive computed columns to views.
- If the API writes to the table and never reads the computed column directly, consider moving the computed value into the application or reports.

## Stored Procedure Dependency Inventory

Stored procedures are a major dependency in this application. There are three separate dependency sources:

1. Hardcoded procedure names in C#.
2. Procedure commands stored in database configuration tables.
3. Procedures called by other procedures/functions/triggers inside SQL Server.

### Hardcoded API Routine References

The API contains references to these routine-like names:

- `rpt_aging_patient_detail_by_insurancecompany`
- `rpt_patientchargestatementxml`
- `usp_denialmanagementforclaimdetail`
- `usp_denialmanagementforcompanytype`
- `usp_denialmanagementforcompanytypecharges`
- `usp_denialmanagementforinsurancecompany`
- `usp_denialmanagementforinsurancecompanycharges`
- `usp_denialmanagementfortotaladjustment`
- `usp_denialmanagementfortotaladjustmentcharges`
- `usp_getactionnotesforcatalyst`
- `usp_getallpracticesvouchers`
- `usp_getdenialmanagementagingcountbyrange`
- `usp_getdenialmanagementagingcountbyrangefilter`
- `usp_getdynmopaymentsforcatalystrcm`
- `usp_getinsurancewisepaymentreport`
- `usp_getpatientagingbalances`
- `usp_getpatientagingbalances_batchstatement`
- `usp_getpatientforautostatment`
- `usp_getpaymentwarehousereportdata`
- `usp_getvouchersforplaidpayments`
- `usp_importchargesindatawarehousetable_patientwise`
- `usp_insertorupdatechargestat`
- `usp_methasoft_createaccession`
- `usp_paymentchargebypaymentid`
- `usp_reportdataforcatalystallcharges`
- `usp_syncdepositswithchasepayments`
- `usp_updatepayercontrolnumbertoclaims`
- `usp_updateplaidpayment_voucher`

The following referenced names were not found as database modules:

- `usp_GetDynmoPaymentsForCatalystRCM`
- `usp_PaymentChargeByPaymentId`, currently seen in commented code.

### Report Procedure Dependencies

`dbo.PZ_Report.Command` currently references 36 executable report routines. All 36 were found in the database metadata.

Examples:

- `rpt_ChargesDOSReport`
- `rpt_PaymentDepositsReport`
- `rpt_Aging_Summary_By_Insurance`
- `rpt_Aging_Summary_By_Patient`
- `rpt_Aging_Patient_Detail_By_InsuranceCompany`
- `rpt_CPA_By_Provider_Report`
- `rpt_PatientChargeStatement`
- `rpt_PostingPaymentByDate`
- `rpt_PostingPaymentByCptCodeByPostDate`
- `usp_GetInsurancewisePaymentReport`

Migration implication:

- These report commands cannot remain as SQL Server `exec ...` strings.
- The report catalog should store stable report keys, not executable SQL.
- The API should map each report key to a parameterized query handler, a PostgreSQL function, or a report service.

### Scrub Procedure Dependencies

`dbo.Scrub.StoredProcedure` currently contains 8 active configured names:

| Configured name | Found in DB? | Current role |
|---|---:|---|
| `usp_RunScrub81EM` | Yes | Stored procedure using `ChargeType` table-valued parameter. |
| `usp_RunScrub82EM` | Yes | Stored procedure using `ChargeType` table-valued parameter. |
| `usp_RunScrub83EM` | Yes | Stored procedure using `ChargeType` table-valued parameter. |
| `usp_RunScrub84EM` | Yes | Stored procedure using `ChargeType` table-valued parameter. |
| `usp_RunScrub86EM` | Yes | Stored procedure using `ChargeType` table-valued parameter. |
| `usp_RunScrub124` | Yes | Stored procedure using `ChargeType` table-valued parameter. |
| `CPTToICDValidator` | No | Configured but not found as a database module. |
| `CPTToModifierValidator` | No | Configured but not found as a database module. |

The SQL Server user-defined table type is `dbo.ChargeType`, with 52 columns. It is used by:

- `dbo.usp_RunScrub124`
- `dbo.usp_RunScrub81EM`
- `dbo.usp_RunScrub82EM`
- `dbo.usp_RunScrub83EM`
- `dbo.usp_RunScrub84EM`
- `dbo.usp_RunScrub86EM`

PostgreSQL has no SQL Server-style table-valued parameters. Options:

1. Pass JSONB to a PostgreSQL function and unpack with `jsonb_to_recordset`.
2. Bulk insert the charges into a temporary table and run scrub SQL against it.
3. Pass arrays/composite types.
4. Move scrub rules into application code and keep the database as the source of reference data.

Recommended path:

- For long-term maintainability, move scrub rules into application services.
- Use database reference tables for CPT, ICD, modifiers, payer rules, and configuration.
- Keep `dbo.Scrub` equivalent as a rule catalog, but replace `StoredProcedure` with a stable rule key such as `scrub_81_em_needs_mod_25`.
- Dual-run old SQL Server scrub procedures and new application rules until results match on golden test batches.

### EDI Pipeline (837/835) — Separate Workstream

The original plan covers stored-procedure scrubs and reports but does not name EDI processing as its own migration risk. It is. The 837 generator and 835 importer are tightly coupled to SQL Server data access and to the same `ChargeType` TVP / `DataTable` patterns as scrubs.

**Outbound 837 (claim submission):**
- `ClaimService` reads claim+charge+patient+insurance data via OrmLite, builds X12 837 via EdiFabric, writes the file via `PractiZing.Sftp` to the clearinghouse.
- Risks: (a) any raw SQL or SP-backed reads behind `BuildClaimEnvelope`-style methods will need PostgreSQL conversion; (b) EdiFabric license validity on the new runtime; (c) clearinghouse contract dictates exact field formatting — round-trip the same charge through SQL Server-built and PostgreSQL-built 837 and diff byte-for-byte before cutover; (d) if `usp_RunScrub*` ran as a pre-flight on the same charges, the scrub-rule retirement (Phase 6) must complete or be bridged before claims can submit cleanly.

**Inbound 835 (ERA / payment posting):**
- `ERAService` pulls 835 files via SFTP, parses with EdiFabric, calls `ERARootRepository.PostPayments` and friends to write Payment / PaymentAdjustment / PaymentCharge rows.
- Risks: (a) `usp_UpdateChargesforerapaymentforchargesnotfound` is referenced from this pipeline (per `STORED_PROCEDURES.md` §5.3) and needs migration disposition; (b) ERA payment matching uses case-insensitive lookups on payer IDs and patient identifiers — these will fail on PostgreSQL unless the case-sensitivity strategy is applied; (c) money rounding: 835 amounts are decimal cents — verify `numeric(19,4)` round-trips identically; (d) ERAs that fail to post create an ErrorClaim row; the error path must be exercised on PG before cutover.

**SFTP and clearinghouse contracts:**
- These do not change with the database migration — same inbound/outbound SFTP credentials, same clearinghouse destinations.
- BUT: the cutover plan must coordinate with the clearinghouse if the 837 generation moves to a new server IP that the clearinghouse whitelists.

**Recommended approach:**
1. Add EDI to the procedure catalog as a category alongside Reports, Scrubs, ETL, Audit. Catalog every code path that reads/writes for 837 generation and 835 posting.
2. Build golden-master tests: take 50 representative claims and 50 representative ERAs from the production stream (de-identified). Run them through SQL Server, capture every byte of the 837 and every row written from the 835.
3. Re-run the same 100 cases on PostgreSQL after migration; diff bytes (837) and rows (835).
4. Treat any non-zero diff as a blocker. Even a whitespace difference in 837 can break clearinghouse validation.
5. Cutover for EDI is part of the tenant pilot — do not flip 837 generation to PG until the pilot has produced a full week of clean claim files.

**EDI is a higher-risk workstream than reports** because there is an external partner (the clearinghouse) who will not tolerate malformed files. Reports are internal; an off-by-one row count is a bug we can fix. A malformed 837 is a rejected claim batch and revenue impact.

### Trigger Migration Strategy

The original plan dedicates one paragraph to the 221 triggers. They deserve more attention because they are the largest source of unexpected dual-run diffs.

**What we know:**
- 221 triggers exist (per inventory).
- They likely fall into three categories: (a) audit/history (mirroring rows to `_History` tables); (b) cascading state updates (e.g., updating `Charge.Balance` when a `Payment` row is inserted); (c) leftover dead triggers from earlier features.
- Without a per-trigger classification, we cannot estimate the migration cost.

**Why this is a dual-run hazard:**
- During the dual-run, both SQL Server and PostgreSQL receive writes (or PG receives replicated writes). Triggers fire on both. If the trigger logic is *reproduced* on PG, timing differences alone will produce diffs in audit timestamps that look like data corruption. If the trigger is *not* reproduced, audit rows simply won't appear on PG — also a diff.
- The Phase 9 validation comparison must distinguish "trigger fired with different timing" from "data is wrong." Without explicit handling, dual-run output will be all noise.

**Strategy:**
1. **Inventory.** Classify all 221 triggers in week 1 of Phase 5: which are audit/history, which are cascading state, which are dead. Use `sys.triggers` joined to trigger source.
2. **Audit/history triggers:** Do NOT port mechanically. Instead, decide on a single audit pattern for PG (recommend: one audit table + one generic trigger function in PL/pgSQL that captures `OLD`/`NEW` as JSONB). Replace 221 SQL Server triggers with 1 PG trigger function attached to N tables.
3. **Cascading state triggers:** These often hide business logic (e.g., recomputing balances). DO move them to application code. Document each one in a trigger-retirement log; show the equivalent service method.
4. **Dead triggers:** Drop in PG schema. Don't migrate dead code.
5. **Compliance:** before retiring any audit trigger, confirm with compliance/legal whether the history rows it produces are required for HIPAA audit retention. If yes, the application replacement must produce equivalent rows in the new audit table.

**Dual-run validation handling:**
- Comparison logic must exclude audit-timestamp columns from the diff (they will always differ).
- For cascading state triggers being retired, run a backfill verification: pick a sample of N rows that the trigger touched in SQL Server, recompute the state via the application replacement on PG, diff.
- Expect dual-run noise from triggers in week 1 of pilot. Reserve a week of triage to characterize and dismiss known-good differences.

**Risk:** if the trigger inventory reveals that core business logic is hidden in triggers (likely, given 221 of them), Phase 6 effort grows by 2-4 weeks. Hold a checkpoint after the inventory before committing the broader timeline.

### Stored Procedure Quality Signals

Across 138 stored procedures:

| Signal | Count |
|---|---:|
| Uses `NOLOCK` | 89 |
| Uses `SELECT *` | 37 |
| Uses `TOP` | 15 |
| Uses `ISNULL` | 69 |
| Uses `GETDATE` | 48 |
| Uses `DATEADD` | 25 |
| Uses `DATEDIFF` | 27 |
| Uses `CONVERT` | 43 |
| Uses `CAST` | 92 |
| Uses temp table marker `#` | 22 |
| Uses T-SQL variables | 89 |
| Uses `MERGE` | 2 |
| Has TRY/CATCH markers | 5 |
| Uses identity retrieval | 9 |

This confirms that procedure migration is not mechanical. Most procedures require semantic review.

The longest and highest-risk procedures include:

- `dbo.usp_ImportChargesInDataWareHouseTable_PatientWise`
- `dbo.usp_ImportChargesInDataWareHouseTable`
- `dbo.usp_ImportChargesInDataWareHouseTable_RefreshPatient`
- `dbo.rpt_Aging_Patient_Detail_By_InsuranceCompany`
- `dbo.USP_ReportDataForCatalystAllCharges`
- `dbo.rpt_Aging_Summary_By_Insurance`
- `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable`
- `dbo.usp_ChargesByRevenueReport`
- `dbo.rpt_PatientChargeStatement`
- `dbo.rpt_PatientChargeStatement_Rohit`

These should not be blindly translated to PL/pgSQL. They should be classified by business purpose and tested against known billing outputs.

## Why a Simple PostgreSQL Port Will Fail

### Provider and Dialect

The current code initializes SQL Server-specific OrmLite dialect providers. PostgreSQL needs a different provider. Even if OrmLite supports both, SQL generation, identifier quoting, parameter binding, pagination, date functions, and schema behavior differ.

### Direct `SqlClient`

Any code using:

- `SqlConnection`
- `SqlCommand`
- `SqlDataAdapter`
- `SqlParameter`
- `SqlDbType`
- `CommandType.StoredProcedure`

must be replaced by provider-neutral ADO.NET or Npgsql-specific code.

The better design is to centralize database execution through small abstractions:

- `IQueryExecutor`
- `IRoutineExecutor`
- `IReportQueryExecutor`
- `IScrubRuleExecutor`
- `IDatabaseDialect`

Do not let direct Npgsql calls spread through the codebase the way direct `SqlClient` calls exist today.

### Stored Procedure Semantics

SQL Server stored procedures can easily return result sets, accept table-valued parameters, use temp tables, and be called with `exec proc @param`.

PostgreSQL has:

- Functions: `select * from function(args)`.
- Procedures: `call procedure(args)`, generally not used for returning table result sets.
- Set-returning functions.
- Composite types.
- JSONB record expansion.
- Temporary tables.
- Refcursors, if absolutely required.

For this app, PostgreSQL functions are usually a better temporary bridge than PostgreSQL procedures. For the final state, most business procedures should be retired into application services.

### Table-Valued Parameters

The current scrub implementation sends a .NET `DataTable` to SQL Server as `@Charges`. PostgreSQL does not support SQL Server TVPs. This affects the scrub workflow directly.

Recommended replacement order:

1. Define a C# scrub input contract independent of `DataTable`.
2. Build application scrub rules for each `usp_RunScrub...` procedure.
3. Use database reference data through normal repositories.
4. Compare old procedure results and new rule results on the same charge batches.
5. Remove procedure-name execution from the request path.

Temporary PostgreSQL bridge:

- Send charge rows as JSONB.
- Use a PostgreSQL function with `jsonb_to_recordset`.
- Return a typed set of scrub errors.

### Case Sensitivity and Identifier Naming

SQL Server current collation is case-insensitive. PostgreSQL is case-sensitive for string comparison by default and folds unquoted identifiers to lower case.

You must choose a naming strategy:

Option 1: Preserve existing PascalCase identifiers with quoted PostgreSQL names.

- Pros: closer to current C# class/table names.
- Cons: every raw SQL query must quote identifiers exactly. Easy to break. Not idiomatic PostgreSQL.

Option 2: Convert to lower_snake_case.

- Pros: idiomatic PostgreSQL, easier long-term maintenance.
- Cons: requires explicit ORM mappings and raw SQL rewrites.

Recommendation:

- Do not mix naming strategies.
- For a long-term PostgreSQL system, prefer lower_snake_case.
- Because this repository has many raw SQL strings and table names derived from C# type names, expect raw SQL and mapping changes either way.

### Collation and Case-Insensitive Lookups

The application likely assumes case-insensitive comparisons for values such as:

- User names.
- Practice codes.
- CPT and ICD codes.
- Insurance names.
- Report names.
- Payer identifiers.
- Modifier codes.

PostgreSQL design options:

- Use `citext` for columns that must be case-insensitive.
- Use functional indexes on `lower(column)`.
- Normalize selected code columns to uppercase at write time.
- Use ICU nondeterministic collations if the target PostgreSQL version and operations model supports them.

Recommendation:

- Normalize medical code columns such as CPT, ICD, modifiers, and payer codes to uppercase.
- Use `citext` or `lower(...)` indexes for usernames and user-entered names where case-insensitive lookup matters.
- Create tests for login, practice selection, code lookup, insurance search, patient search, report filters, and denial filters.

### T-SQL Syntax

Common SQL Server syntax in procedures and raw SQL must be rewritten.

| SQL Server | PostgreSQL direction |
|---|---|
| `TOP 200` | `LIMIT 200` |
| `ISNULL(a,b)` | `COALESCE(a,b)` |
| `GETDATE()` | `now()` or `CURRENT_TIMESTAMP` |
| `SYSDATETIME()` | `CURRENT_TIMESTAMP` |
| `SYSUTCDATETIME()` | `timezone('utc', now())` or `timestamptz` design |
| `NEWID()` | `gen_random_uuid()` or `uuid_generate_v4()` |
| `DATEADD(...)` | interval arithmetic |
| `DATEDIFF(...)` | date subtraction or `extract(...)` |
| `CONVERT(type, value, style)` | `value::type`, `to_char`, `to_date`, or `to_timestamp` |
| `SELECT INTO #temp` | `CREATE TEMP TABLE ... AS SELECT ...` |
| `#temp` tables | PostgreSQL temporary tables or CTEs |
| `@variable` | PL/pgSQL variables or SQL function parameters |
| `SCOPE_IDENTITY()` | `RETURNING id` |
| `MERGE` | PostgreSQL `INSERT ... ON CONFLICT`, `MERGE` if target version supports it, or explicit upsert logic |
| `NOLOCK` | Remove. PostgreSQL MVCC already provides non-blocking reads without dirty reads. |
| `dbo.TableName` | PostgreSQL schema-qualified names, typically `public.table_name` or tenant schema. |
| `[ColumnName]` | Double quotes only if preserving case, otherwise lower-case identifiers. |

### Transactions and Isolation

`DataBaseContext.BeginCommittedTransaction` uses `ReadUncommitted`. PostgreSQL treats `READ UNCOMMITTED` effectively like `READ COMMITTED`; dirty reads are not supported.

Expected behavior differences:

- Reports may return more consistent data than SQL Server `NOLOCK` reports.
- Some workflows that relied on dirty reads may show different timing.
- Blocking behavior is different because PostgreSQL uses MVCC.
- Long-running reports can create vacuum pressure if not managed.

Migration plan must include:

- Transaction isolation review for billing workflows.
- Long-running report performance tests.
- Index tuning after migration.
- Removal of `NOLOCK` assumptions.

## Migration Strategy Options

### Option A: Port Procedures to PostgreSQL First

This means translating SQL Server procedures/functions/triggers into PostgreSQL functions/procedures and changing the API to call them.

Pros:

- Lower immediate application rewrite.
- Can preserve some database-centered workflows.
- Good temporary bridge for high-risk reports.

Cons:

- Still leaves business logic in the database.
- PL/pgSQL translation is time-consuming.
- SQL Server TVPs, result sets, temp tables, and date functions need redesign.
- Existing procedure quality issues remain.
- Tests are still required for every procedure.

Use this for:

- Critical read-only reports needed for first cutover.
- Procedures too risky to rewrite before the initial migration.
- Temporary compatibility only.

Do not use this as the final architecture for all 138 procedures.

### Option B: Retire Procedures Through Application Services

This means creating application-level query handlers, rule engines, and background jobs that replace stored procedure behavior.

Pros:

- Business logic becomes testable in C#.
- Easier code review and coverage.
- Less database lock-in.
- Better long-term maintainability.
- Easier observability and logging.

Cons:

- Larger application refactor.
- Requires strong test coverage and golden datasets.
- May require query tuning and read models.

Recommended for:

- Scrub rules.
- Denial dashboard logic.
- Billing workflow side effects.
- Payment reconciliation.
- Catalyst/warehouse sync.
- Report orchestration and parameter handling.

### Option C: Hybrid Staged Migration

Recommended approach.

1. Port only the procedures needed for the first PostgreSQL cutover.
2. Put all procedure execution behind interfaces.
3. Build application replacements module by module.
4. Dual-run old and new implementations.
5. Retire procedures once outputs match.

This avoids a risky big-bang rewrite while still moving toward a cleaner architecture.

## Recommended Target Architecture

### Database

PostgreSQL should own:

- Tables.
- Primary keys.
- Foreign keys.
- Check constraints.
- Unique constraints.
- Indexes.
- Simple views where useful.
- Optional materialized views for reporting.
- Audit tables if required.

PostgreSQL should not own, long-term:

- Billing workflow branching.
- Medical billing scrub rules.
- Claim lifecycle state machines.
- Report parameter parsing.
- Executable report SQL stored in business tables.
- Integration workflows.

### Application

The API should own:

- Billing service logic.
- Scrub rule evaluation.
- Claim generation orchestration.
- Payment and adjustment business rules.
- Denial management workflow.
- Report command orchestration.
- External integration workflows.
- Provider-specific database execution details hidden behind small interfaces.

### Concrete Boundary Interfaces

The original plan listed interface names. Below are the concrete signatures so the boundary is tangible and reviewable. Each interface has an SQL Server implementation (current behavior wrapped) and a PostgreSQL implementation (new). The DI container picks one per request based on the practice's migration status.

#### `IDatabaseDialect`
The abstraction that hides T-SQL vs PG-SQL syntax differences. Used by repositories that build dynamic SQL.

```csharp
public interface IDatabaseDialect
{
    string Now { get; }                                     // GETDATE() | now()
    string UtcNow { get; }                                  // SYSUTCDATETIME() | timezone('utc', now())
    string NewGuid { get; }                                 // NEWID() | gen_random_uuid()
    string Quote(string identifier);                        // [Foo] | "Foo"
    string PageClause(int offset, int limit);               // OFFSET ... ROWS FETCH NEXT | LIMIT/OFFSET
    string TopOrLimit(int n);                               // TOP n in SELECT | LIMIT n
    string CoalesceFunction { get; }                        // ISNULL | COALESCE   (prefer COALESCE in new code)
    string IdentityRetrieval { get; }                       // SCOPE_IDENTITY() | RETURNING id (handled differently)
    bool SupportsNoLockHint { get; }                        // true on SqlServer, false on PG
    string FormatDateLiteral(DateTime value);               // 'YYYY-MM-DD HH:MM:SS' formatting
}

// Implementations:
// - SqlServerDialect : IDatabaseDialect      (preserves current behavior 1:1)
// - PostgreSqlDialect : IDatabaseDialect
```

#### `IQueryExecutor`
Replaces direct `SqlConnection`/`SqlCommand` usage with a provider-neutral query path. Forces parameterization.

```csharp
public interface IQueryExecutor
{
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null, CancellationToken ct = default);
    Task<T> QuerySingleAsync<T>(string sql, object parameters = null, CancellationToken ct = default);
    Task<int> ExecuteAsync(string sql, object parameters = null, CancellationToken ct = default);
    Task<DataTable> QueryDataTableAsync(string sql, object parameters = null, CancellationToken ct = default);  // for legacy Excel exports
}

// Implementations dispatch via the current OrmLite Connection but enforce parameterization
// and route through the dialect for any provider-sensitive syntax.
```

**No code outside this interface may call `new SqlConnection(...)` or `new NpgsqlConnection(...)`.** A grep-based CI rule enforces this. There are 15 SqlClient files today; after Phase 1.5 (consolidation) there should be zero direct uses outside this implementation.

#### `IRoutineExecutor`
Replaces `BaseRepository.ExecuteStoredProcedureAsync`. Routes calls to the right dialect's procedure-call mechanism.

```csharp
public interface IRoutineExecutor
{
    Task<IEnumerable<T>> ExecuteRoutineAsync<T>(string routineKey, object parameters = null, CancellationToken ct = default);
    Task<T> ExecuteScalarRoutineAsync<T>(string routineKey, object parameters = null, CancellationToken ct = default);
    Task<int> ExecuteVoidRoutineAsync(string routineKey, object parameters = null, CancellationToken ct = default);
}

// "routineKey" is a stable application-level identifier — NOT a database name.
// Implementations look up the dialect-specific routine name from a registry:
//   - SqlServer impl: "denial.aging_count_by_range" → exec usp_GetDenialManagementAgingCountByRange
//   - Postgres impl:  "denial.aging_count_by_range" → select * from denial_aging_count_by_range()
//
// This ends the practice of hardcoding usp_ names in C# and makes future renames safe.
```

The registry lives in code (not in `PZ_Report.Command`). It's a `Dictionary<string, RoutineMapping>` populated at startup. Adding a new routine adds a key in two places: SQL Server registry and PG registry. Renames are localized to the registry.

#### `IReportQueryExecutor`
Replaces `ReportRepository.GenerateReportData` and the `PZ_Report.Command` executable-SQL pattern.

```csharp
public interface IReportQueryExecutor
{
    Task<ReportResult> RunReportAsync(string reportKey, IDictionary<string, object> parameters, CancellationToken ct = default);
}

public record ReportResult(string DatasetName, IReadOnlyList<IReadOnlyList<IDictionary<string, object>>> ResultSets);
```

`PZ_Report` table schema changes:
- Drop the `Command` column (no more executable SQL in business tables).
- Add `ReportKey` column (stable identifier like `"aging.summary_by_insurance"`).
- Keep `ReportName`, `Parameters`, `DataSetName`, `IsActive`, `ComponentName`.
- Add `ParameterSchema` (JSON) describing the parameter types and validation rules.

The implementation maps `reportKey` → typed query handler. SQL Server impl wraps the legacy `exec rpt_...` for the migration window; PG impl runs a parameterized SQL or PG function. Both share the parameter validation against `ParameterSchema`.

#### `IScrubRuleExecutor`
Replaces `ClaimBatchRepository.RunAutoScrub`'s "user passes spName" pattern.

```csharp
public interface IScrubRuleExecutor
{
    Task<IReadOnlyList<ScrubError>> RunScrubAsync(
        string ruleKey,
        IReadOnlyList<ScrubInputCharge> charges,
        ScrubContext context,
        CancellationToken ct = default);
}

public record ScrubInputCharge(/* the 52 fields of the current ChargeType TVP, strongly typed */);
public record ScrubError(int ChargeId, string RuleKey, string Message, ScrubSeverity Severity);
public record ScrubContext(string PracticeCode, int ScrubId);
```

The dispatcher reads `Scrub.RuleKey` (replacing `Scrub.StoredProcedure`). Implementations:
- SqlServer impl: still calls the legacy `usp_RunScrub*` with the TVP, for the migration window.
- Postgres impl: calls a C# rule class OR (temporary bridge) a PG function with `jsonb_to_recordset`.
- Pure-app impl (target end state): calls a C# `IScrubRule` implementation, no DB function involved.

The `spName` parameter on the request is dropped — no client-supplied procedure names ever reach the database layer. This closes the SP-injection vulnerability called out in the API safety review.

#### `IDatabaseConnectionFactory`
Routes a request to the right database connection based on practice + migration status.

```csharp
public interface IDatabaseConnectionFactory
{
    IDbConnection OpenConnection(string practiceCode);
    DatabaseProvider GetProviderFor(string practiceCode);    // SqlServer or Postgres
}

public enum DatabaseProvider { SqlServer, Postgres }
```

During pilot, this returns `Postgres` for one practice and `SqlServer` for everyone else. Lookup is from configuration, not from code, so flipping a tenant requires a config change, not a deploy.

#### `IAuditWriter`
Replaces the 221 SQL Server triggers' audit emissions with one centralized writer.

```csharp
public interface IAuditWriter
{
    Task WriteAuditAsync(string tableName, AuditAction action, object before, object after, string actor, CancellationToken ct = default);
}

public enum AuditAction { Insert, Update, Delete }
```

Used by repositories that want to record audit events without depending on triggers. Behind the interface, the SQL Server impl can stay no-op (triggers still firing); the PG impl writes to a single audit table with JSONB before/after.

#### Refactored example: `DenialQueueRepository.GetAgingCount`

Before (current code, simplified):
```csharp
public async Task<DenialManagementDTO> GetAgingCount() {
    var dto = new DenialManagementDTO();
    dto.DenialManagements = await ExecuteStoredProcedureAsync<DenialManagementDTO>(
        "usp_GetDenialManagementAgingCountByRange");
    dto.DenialManagementsByCompanyType = (await ExecuteStoredProcedureAsync<DenialManagementInsuranceTypeDTO>(
        "usp_DenialManagementForCompanyType")).Take(5);
    // … 3 more SP calls
    return dto;
}
```

After (Phase 2 boundary applied):
```csharp
public async Task<DenialManagementDTO> GetAgingCount(CancellationToken ct = default) {
    var dto = new DenialManagementDTO();
    dto.DenialManagements = await _routineExecutor.ExecuteRoutineAsync<DenialManagementDTO>(
        "denial.aging_count_by_range", ct: ct);
    dto.DenialManagementsByCompanyType = (await _routineExecutor.ExecuteRoutineAsync<DenialManagementInsuranceTypeDTO>(
        "denial.by_company_type", ct: ct)).Take(5);
    // … 3 more
    return dto;
}
```

The C# now references stable keys, not SQL Server names. The registry maps:

```csharp
// SqlServerRoutineRegistry.cs
{ "denial.aging_count_by_range",   ("usp_GetDenialManagementAgingCountByRange", RoutineKind.StoredProcedure) },
{ "denial.by_company_type",        ("usp_DenialManagementForCompanyType",        RoutineKind.StoredProcedure) },

// PostgresRoutineRegistry.cs
{ "denial.aging_count_by_range",   ("denial_aging_count_by_range",                RoutineKind.Function) },
{ "denial.by_company_type",        ("denial_by_company_type",                     RoutineKind.Function) },
```

**This refactor is the highest-leverage move in Phase 2.** Every other workstream (reports, scrubs, dashboard, ETL) reuses the same pattern. Get this interface right and reviewable before scaling out.

### Acceptance criteria for Phase 2 (boundary work)

- Zero direct `SqlConnection` / `SqlCommand` / `SqlDataAdapter` references outside `Microsoft.Data.SqlClient`-implementing files for `IQueryExecutor` / `IRoutineExecutor`.
- Zero `ExecuteStoredProcedureAsync(..., string)` calls in repositories — all routed through `IRoutineExecutor` with stable keys.
- Zero `cmd.CommandText = "exec ...";` in repositories — same reason.
- `PZ_Report.Command` no longer used at runtime (still in DB during migration; new column `ReportKey` drives behavior).
- `Scrub.StoredProcedure` no longer used at runtime; `RuleKey` drives behavior.
- A grep CI rule enforces "no new direct SqlClient/Npgsql usage outside the executor implementations."
- Application still runs on SQL Server. No PostgreSQL code is exercised yet.
- All existing API integration tests pass against the boundary-wrapped SQL Server path.

## Detailed Execution Plan

### Phase 0: Migration Governance and Freeze Points

Deliverables:

- Define migration owner and module owners.
- Define production cutover owner.
- Define rollback authority.
- Define which tenant/practice will be the pilot.
- Define what data is in scope for the first cutover.
- Define acceptable downtime or choose a CDC/dual-sync approach.
- Create a migration decision log.

Rules:

- Do not start code migration until current SQL Server behavior is captured with tests.
- Do not start production data migration until schema conversion is repeatable.
- Do not retire a stored procedure until its replacement has golden-master output tests.

### Phase 1: Stabilize Build and Test Baseline

Current blocker:

- The API does not currently build cleanly in the tested environment because the stack is old and dependencies are missing.

Required work:

1. Make the solution build consistently.
2. Decide whether to upgrade from .NET Core 2.1 before the database migration.
3. Restore or replace missing third-party dependencies.
4. Remove hardcoded development database credentials from tests and appsettings.
5. Build a repeatable local/dev test database environment.
6. Create an integration test harness that can run against SQL Server first.

Recommended test baseline:

- Unit tests for pure business logic.
- Repository contract tests.
- SQL Server integration tests for current behavior.
- API endpoint tests for critical workflows.
- Golden-master tests for reports and stored procedures.

Critical medical billing workflows to baseline:

- Login and practice routing.
- Patient search and patient demographic update.
- Insurance policy add/update.
- Charge entry.
- Claim creation.
- Claim batching.
- Scrub execution.
- 837 generation.
- ERA/835 import.
- Payment posting.
- Payment adjustments and reversals.
- Denial queue and denial dashboard.
- Patient statements.
- Aging reports.
- Payment posting reports.
- Catalyst/warehouse export or sync workflows.

### Phase 1.5: SqlClient Consolidation Audit

Inserted between Phase 1 (baseline) and Phase 2 (compatibility boundary). The original plan implies these two can happen in parallel; they cannot. Phase 2 introduces new abstractions, but if the existing SqlClient sprawl is not first inventoried and consolidated, the abstractions will be applied unevenly and PostgreSQL will leak through the cracks.

**Goal:** every direct SqlClient call in the codebase is either deleted (if dead) or converted to use the existing OrmLite `Connection`. Result is a known, bounded surface for Phase 2 to wrap.

**Required work:**
1. Inventory: produce a list of all 15 SqlClient files plus the 7 `CommandType.StoredProcedure` direct-usage sites. For each, record:
   - File:line
   - Why it bypassed OrmLite (often: needed `DataTable` for Excel export, or needed TVP for scrubs)
   - Whether the use case is still valid
2. Replace direct `SqlClient` usage with OrmLite raw-SQL where possible (`Connection.SqlListAsync<T>(...)`).
3. For Excel export `DataTable` cases: keep the `DataTable` shape but route through a new helper that can be re-implemented in Phase 2.
4. For scrub TVP cases: leave as-is — they will be replaced wholesale in Phase 6.
5. Switch `System.Data.SqlClient` references to `Microsoft.Data.SqlClient` (separate Nuget; same API, current support).
6. Delete commented-out SqlClient code (per the API safety review, multiple files have these).

**Acceptance criteria:**
- Direct SqlClient usage is reduced to no more than the 6 known scrub TVP call sites.
- All Excel export paths route through one helper (call it `IExcelDataSource`) — Phase 2 will provide its PG implementation.
- `System.Data.SqlClient` references replaced with `Microsoft.Data.SqlClient` everywhere.
- Build still green; no behavior change.

**Why this is its own phase:**
- Doing it inside Phase 2 means partially-wrapped code. That's the worst-of-both state — neither the old SqlClient nor the new abstraction has consistent semantics.
- It surfaces edge cases that the Phase 2 interfaces must support (e.g., the Excel `DataTable` use case is easy to miss in interface design).
- It ends with a measurable, grep-able invariant (no new SqlClient outside the known list) that a CI rule can enforce.

**Estimated effort:** 2 weeks for one engineer if SqlClient sites are mechanical; 4 weeks if scrub TVP boundaries reveal redesign work.

### Phase 2: Create a Database Compatibility Boundary

Goal:

- Make the database provider a replaceable implementation detail.

Required work:

1. Wrap direct `SqlClient` usage.
2. Replace `BaseRepository.ExecuteStoredProcedureAsync` string concatenation with a provider-aware routine executor.
3. Replace raw report command execution with `IReportQueryExecutor`.
4. Replace scrub stored procedure execution with `IScrubRuleExecutor`.
5. Replace ad hoc `DataSet` and `DataTable` expectations with typed result contracts where possible.
6. Convert raw string SQL to parameterized SQL.
7. Centralize identifier quoting and naming strategy.
8. Add logging around query names, duration, row count, and failures without logging PHI.

Acceptance criteria:

- No new code should directly reference `SqlConnection`, `SqlCommand`, or `SqlDataAdapter`.
- All stored procedure calls go through one routine abstraction.
- All report execution goes through one report abstraction.
- All scrub execution goes through one scrub abstraction.
- The application still runs against SQL Server before PostgreSQL work starts.

### Phase 3: Build the PostgreSQL Schema Prototype

Goal:

- Produce a repeatable PostgreSQL schema migration from the SQL Server schema.

Required work:

1. Decide naming strategy.
2. Convert data types.
3. Convert identity columns to generated identity or sequences.
4. Convert defaults.
5. Convert computed columns.
6. Convert indexes and unique constraints.
7. Convert foreign keys.
8. Convert check constraints.
9. Decide what to do with audit/history triggers.
10. Create a repeatable migration script set.

Recommended PostgreSQL extensions:

- `pgcrypto` for `gen_random_uuid()`.
- `citext` if case-insensitive columns are modeled with `citext`.

Schema acceptance criteria:

- PostgreSQL schema can be dropped and recreated from scripts.
- Every SQL Server table has a mapped PostgreSQL table or a documented reason it was excluded.
- Every primary key is preserved.
- Every required foreign key is preserved or intentionally deferred with a documented reason.
- Sequences are initialized above max imported IDs.
- UUID defaults are functional.
- Money columns use `numeric`, not PostgreSQL `money`.
- Deprecated `text` and `image` columns are converted.

### Phase 4: Data Migration Prototype

Goal:

- Move a full copy of SQL Server data into PostgreSQL and prove parity.

Possible tools:

- `pgloader` or equivalent conversion tooling.
- AWS DMS, Azure Database Migration Service, or a similar CDC-capable tool if cloud infrastructure is available.
- SSIS/custom ETL if the organization already uses it.
- Custom C# migration jobs for edge cases.

Data migration steps:

1. Export or connect to SQL Server source.
2. Create PostgreSQL schema.
3. Disable or defer constraints where needed for initial bulk load.
4. Load parent/reference tables first.
5. Load transactional tables.
6. Load binary columns into `bytea`.
7. Convert GUIDs to `uuid`.
8. Convert money to `numeric(19,4)`.
9. Convert dates/timestamps.
10. Re-enable constraints.
11. Rebuild indexes if they were disabled.
12. Set sequence values.
13. Run validation.

Validation queries:

- Row count per table.
- Primary key count per table.
- Null count for required columns.
- Foreign key orphan checks.
- Financial totals by charge/payment/adjustment tables.
- Claim count by status.
- Payment batch totals.
- Aging totals.
- Patient statement totals.
- Report output comparisons.

Do not use table row counts alone as proof. Financial totals and workflow outputs matter more.

### Phase 5: Stored Procedure Classification

Create a procedure catalog for all 138 stored procedures and 23 functions.

Each row should include:

- Routine name.
- Source category: C# hardcoded, `PZ_Report`, `Scrub`, internal-only, unknown.
- Caller file or database caller.
- Endpoint or workflow.
- Input parameters.
- Output shape.
- Tables read.
- Tables written.
- Side effects.
- Uses temp tables.
- Uses `NOLOCK`.
- Uses date functions.
- Uses identity retrieval.
- Uses dynamic SQL, if any.
- Expected data volume.
- Business owner.
- Migration decision: retire, port temporarily, keep as PostgreSQL function, or delete.
- Test owner.
- Golden dataset available: yes/no.
- PostgreSQL status.
- Application replacement status.

Prioritization:

1. Procedures required by active API endpoints.
2. Procedures configured in `PZ_Report` and `Scrub`.
3. Procedures that write billing, claim, payment, or denial data.
4. Procedures that generate reports used for financial reconciliation.
5. Internal-only, unused, or historical procedures.

### Phase 6: Stored Procedure Retirement Strategy

The goal is not to recreate all SQL Server stored procedures in PostgreSQL. The goal is to remove hidden business logic from the database where that improves safety, testability, and portability.

#### Reports

Current state:

- `PZ_Report.Command` stores executable SQL like `exec rpt_...`.
- `ReportRepository` parses parameters and executes the command text.

Recommended end-state:

- `PZ_Report` stores report metadata only: key, name, active flag, parameter schema, output schema, display options.
- The API maps report key to a typed report query handler.
- Query handlers use parameterized SQL or ORM queries.
- High-volume reports may use PostgreSQL materialized views refreshed by background jobs.

Migration steps:

1. Create a report inventory from `PZ_Report`.
2. For each active report, capture SQL Server output for golden input parameters.
3. Build a typed report output contract.
4. Implement PostgreSQL query handler or temporary PostgreSQL function.
5. Compare row counts, column names, data types, and financial totals.
6. Replace stored SQL command with a report key.
7. Remove executable SQL from report configuration.

#### Scrub Rules

Current state:

- `Scrub.StoredProcedure` stores procedure names.
- API receives or uses a procedure name.
- `ClaimBatchRepository` sends a `DataTable` as `@Charges`.

Recommended end-state:

- `Scrub` stores rule metadata and rule key.
- `IScrubRule` implementations evaluate charge batches.
- Rules can use reference data repositories.
- Results are typed `ScrubError` objects.

Migration steps:

1. Define a typed `ScrubInputCharge` matching the current `ChargeType`.
2. Define typed `ScrubError` output.
3. For each `usp_RunScrub...` procedure, build a golden dataset.
4. Implement one rule at a time in C#.
5. Dual-run old procedure and new rule in non-production.
6. Diff output by charge ID, scrub ID, message, CPT, ICD, modifier, and severity.
7. Cut over rule by rule.
8. Replace `StoredProcedure` with `RuleKey`.
9. Remove `spName` from request paths so clients cannot steer executable database logic.

Temporary PostgreSQL bridge:

- If a scrub rule cannot be retired before cutover, implement a PostgreSQL function that accepts JSONB charge rows.
- Keep that bridge behind `IScrubRuleExecutor`.
- Mark it temporary in the procedure catalog.

#### Denial Management and Aging

Current state:

- Denial dashboard repositories call procedures such as `usp_GetDenialManagementAgingCountByRange`, `usp_DenialManagementForCompanyType`, and related charge filters.

Recommended end-state:

- Application query handlers own dashboard query definitions.
- PostgreSQL indexes or materialized views support performance.

Migration steps:

1. Capture current dashboard outputs by date range and filter.
2. Identify exact source tables and joins.
3. Create read model queries in application code.
4. Add indexes based on actual filters.
5. Compare SQL Server procedure output and PostgreSQL output.

#### Warehouse, Catalyst, and External Sync

Procedures such as these look like ETL or integration routines:

- `usp_ImportChargesInDataWareHouseTable_PatientWise`
- `USP_ReportDataForCatalystAllCharges`
- `USP_ImportCatalystAllChargeIntoWareHouseTable`
- `usp_SyncDepositsWithChasePayments`

Recommended end-state:

- Background jobs or integration services own ETL and sync orchestration.
- Database may expose views/read models, but workflow control should live in the application/job layer.

Migration steps:

1. Identify schedule, trigger, and owner for each routine.
2. Determine whether it is still actively used.
3. Capture source and destination tables.
4. Create idempotent job logic.
5. Add job run logs and retry behavior.
6. Compare old and new output tables.

#### Audit and History Triggers

Current state:

- 221 triggers were found.
- They appear likely to populate history tables.
- Trigger signals show 221 likely history triggers.

Options:

1. Port triggers to PostgreSQL trigger functions.
2. Replace with application-level audit logging.
3. Use logical decoding or CDC for audit/history downstream.

Recommendation:

- For initial migration, port only audit triggers required for compliance or product behavior.
- Long-term, use a consistent audit strategy rather than hundreds of table-specific trigger bodies.

Audit requirements to confirm:

- Is the history data required for HIPAA audit?
- Which tables require before/after images?
- How long must history be retained?
- Is user ID captured consistently?
- Are sensitive fields, such as passwords or clearinghouse credentials, currently written to history?

### Phase 7: PostgreSQL Application Implementation

Main application workstreams:

1. Runtime and package upgrade.
2. PostgreSQL provider registration.
3. Connection string and secret management.
4. Multi-tenant routing.
5. Repository query compatibility.
6. Stored procedure/routine abstraction.
7. Report execution abstraction.
8. Scrub execution abstraction.
9. Transaction behavior.
10. Performance tuning.

Important package decision:

- Because the current projects target .NET Core 2.1 and OrmLite SQL Server 5.0.2, confirm compatible versions before choosing Npgsql and OrmLite PostgreSQL.
- The cleaner path is to upgrade the API to a supported .NET runtime first, then migrate providers.

Provider acceptance criteria:

- Application can start with PostgreSQL connection strings.
- `PracticeCentral` routing works.
- Practice-specific connections work.
- No direct SQL Server connection string syntax remains in runtime config.
- No `System.Data.SqlClient` dependency is required for PostgreSQL mode.
- SQL Server mode can still run during migration until cutover is complete.

### Phase 8: PostgreSQL Performance and Index Tuning

Performance cannot be assumed from SQL Server indexes.

Required checks:

- Explain plans for high-traffic endpoints.
- Explain plans for reports.
- Explain plans for scrub rule queries.
- Explain plans for patient search.
- Explain plans for claim and payment workflows.
- Long-running report impact on vacuum.
- Index bloat after bulk loads.
- Autovacuum settings.
- Connection pool sizing.
- Query timeout strategy.

PostgreSQL index opportunities:

- Functional indexes on `lower(...)` for case-insensitive search.
- Partial indexes for active/non-deleted rows.
- Composite indexes matching report filters.
- Covering indexes with `INCLUDE` where useful.
- Materialized views for stable report aggregates.

### Phase 9: Dual-Run Validation

**Trigger-noise warning (read first):** the 221 audit/cascading triggers (see "Trigger Migration Strategy" earlier) will produce diffs in audit timestamps and possibly in cascaded state columns even when the underlying business data is correct. Phase 9 validation logic must classify each diff:

- **Acceptable diff** — audit-timestamp-only, known cascading-state column the team has documented.
- **Suspicious diff** — anything else; investigate.

If you do not pre-classify, Phase 9 generates thousands of "differences" that the team will start ignoring out of fatigue. That is the failure mode that ends pilots quietly.

**Recommended diff tooling:**
- A row-by-row comparison job that hashes selected columns (excluding audit timestamps) per table.
- Aggregations comparing sums of monetary columns (the financial-correctness gate from Phase 4 §"Data-migration tooling").
- A daily report sent to the migration owner: row count parity, financial parity, exception list.

Before production cutover, run SQL Server and PostgreSQL side by side.

Validation modes:

1. Read-only compare:
   - Same inputs go to SQL Server and PostgreSQL.
   - Compare results.

2. Shadow write:
   - Production writes continue to SQL Server.
   - PostgreSQL receives replicated or replayed writes.
   - Compare state and outputs.

3. Pilot tenant:
   - One low-risk practice moves first.
   - Monitor workflows and reports.

4. Full cutover:
   - Freeze writes or use CDC.
   - Apply final delta.
   - Switch API connection routing.

Golden-master comparisons:

- Report columns and row counts.
- Charge totals.
- Payment totals.
- Adjustment totals.
- Claim counts by status.
- Denial counts by aging bucket.
- Patient statement totals.
- Scrub error counts and messages.
- EDI file generation inputs.

### Phase 10: Production Cutover

Cutover plan must be written and rehearsed.

Minimum cutover checklist:

1. Confirm backups.
2. Confirm rollback plan.
3. Confirm application build/version.
4. Confirm PostgreSQL schema version.
5. Confirm data migration validation.
6. Stop writes or start final CDC catch-up.
7. Run final data sync.
8. Validate row counts and financial totals.
9. Set sequences.
10. Enable application PostgreSQL mode.
11. Run smoke tests.
12. Run critical reports.
13. Monitor logs, slow queries, errors, and connection pool.
14. Keep SQL Server read-only until rollback window closes.

Rollback rule:

- If any writes occur in PostgreSQL after cutover, rollback to SQL Server requires either reverse replication or discarding PostgreSQL writes. Decide this before cutover.

## Stored Procedure Conversion Playbook

Use this playbook per procedure.

### Step 1: Classify

Questions:

- Is it called by C#?
- Is it called through `PZ_Report`?
- Is it called through `Scrub`?
- Is it only called by another procedure?
- Does it write data?
- Does it return one result set, multiple result sets, scalar values, or no rows?
- Does it rely on temp tables?
- Does it rely on identity values?
- Does it use `NOLOCK`?
- Does it perform billing, claim, payment, or denial state changes?

Decision:

- Retire into application service.
- Port temporarily to PostgreSQL function.
- Keep as permanent PostgreSQL function.
- Delete as unused.

### Step 2: Capture Current Behavior

For each procedure:

- Save input parameter examples.
- Save result schemas.
- Save output rows for known test data.
- Save side-effect before/after row counts.
- Save financial totals affected.
- Save error behavior.

Do this before changing anything.

### Step 3: Choose Replacement Pattern

| Procedure type | Recommended replacement |
|---|---|
| Read-only report | Application report query handler or PostgreSQL function returning table. |
| Dashboard aggregate | Application query handler plus indexes/materialized view. |
| Scrub rule | Application `IScrubRule` implementation. |
| ETL/import/export | Background job or integration service. |
| Simple lookup | ORM/repository query. |
| Audit trigger helper | Central audit strategy. |
| Complex transactional workflow | Application service with explicit transaction and tests. |

### Step 4: Implement Behind an Interface

Even temporary PostgreSQL functions should be called through interfaces.

Bad target:

- Controllers/repositories directly call `select * from usp_name(...)`.

Better target:

- Controller calls service.
- Service calls repository/query handler.
- Query handler uses provider-specific implementation behind an interface.

### Step 5: Dual-Run

For non-production:

- Execute old SQL Server procedure and new implementation with same input.
- Normalize ordering.
- Normalize decimal precision.
- Normalize date/time precision.
- Compare rows and totals.
- Log differences.

Cut over only when differences are understood and approved.

## Procedure Retirement Order

Recommended order:

1. Unused or broken procedure references.
   - Resolve `usp_GetDynmoPaymentsForCatalystRCM`.
   - Confirm whether commented `usp_PaymentChargeByPaymentId` should be deleted or restored.
   - Resolve missing scrub entries `CPTToICDValidator` and `CPTToModifierValidator`.

2. Scrub procedures.
   - High value because they use TVPs and are SQL Server-specific.
   - Move to application rules.

3. Report procedures used by active reports.
   - Start with low-risk read-only reports.
   - Keep complex financial reports behind temporary PostgreSQL functions until verified.

4. Denial dashboard procedures.
   - Replace with application query handlers and read models.

5. Payment/Plaid/Chase/Dynmo routines.
   - Move integration logic to services.

6. Warehouse/Catalyst routines.
   - Move to jobs or data pipeline.

7. Audit/history triggers.
   - Replace with a consistent PostgreSQL audit strategy after compliance requirements are confirmed.

## Testing Plan

### Minimum Test Layers

1. Unit tests:
   - Scrub rules.
   - Billing calculations.
   - Claim state transitions.
   - Payment allocation.
   - Date and aging calculations.

2. Repository contract tests:
   - Same contract runs against SQL Server and PostgreSQL during migration.
   - Confirms CRUD behavior, queries, null handling, case sensitivity, date precision, and decimal precision.

3. Stored procedure replacement tests:
   - Old SQL Server procedure output versus new implementation output.

4. API integration tests:
   - Critical billing workflows.
   - Report generation.
   - Claim and payment workflows.

5. Data migration tests:
   - Row counts.
   - Financial totals.
   - FK integrity.
   - Sequence values.
   - Case-insensitive lookups.

6. Performance tests:
   - Reports.
   - Patient search.
   - Claim batch generation.
   - Scrub execution.
   - Payment posting.

### Golden Dataset Requirements

Build de-identified datasets for:

- A patient with primary and secondary insurance.
- A patient with no insurance.
- Charge with multiple CPT/modifier/ICD combinations.
- Claims that pass scrub.
- Claims that fail each scrub rule.
- ERA payment with adjustments.
- Manual payment.
- Reversal/refund scenario.
- Denial queue scenario.
- Aging across buckets.
- Patient statement generation.
- Reports with expected totals.

### Test Acceptance

Before PostgreSQL cutover:

- Build passes.
- Unit tests pass.
- SQL Server baseline integration tests pass.
- PostgreSQL integration tests pass.
- Stored procedure replacement tests pass for all cutover-critical routines.
- Report golden-master outputs match or approved differences are documented.
- Scrub outputs match or approved differences are documented.
- Data migration validation passes.

## Security and Compliance Requirements

This is medical billing software. Treat the migration as high-risk for PHI and financial correctness.

Required controls:

- Do not commit database passwords or connection strings.
- Use secret storage for SQL Server and PostgreSQL credentials.
- Use encrypted connections.
- Restrict migration database users to required privileges.
- Use de-identified data for developer testing.
- Log migration operations without logging PHI.
- Ensure audit requirements are preserved.
- Verify history/audit table behavior before retiring triggers.
- Review database backups and retention.
- Review access controls for generated schema documents if they include object definitions that reveal sensitive table names.

## PostgreSQL Deployment Considerations

Decisions needed:

- PostgreSQL version.
- Managed service versus self-hosted.
- Database-per-practice versus schema-per-practice versus shared tenant column.
- Backup and point-in-time recovery.
- Read replicas for reporting.
- Connection pooling strategy.
- Migration maintenance window.
- Monitoring stack.
- Slow query logging.
- Extension policy.
- Disaster recovery RPO/RTO.

Recommended baseline:

- Use a supported PostgreSQL version.
- Use managed PostgreSQL if operational expertise is limited.
- Enable PITR backups.
- Use least-privilege database roles.
- Use connection pooling.
- Add slow query logging before load testing.
- Separate reporting load if reports are heavy.

## Cutover Readiness Checklist

The project is not ready to cut over until all of these are true:

- Current API builds reliably.
- PostgreSQL schema is generated from reviewed migrations, not ad hoc manual changes.
- Data migration is repeatable.
- Data migration validation is automated.
- All active stored procedure dependencies have a migration decision.
- Cutover-critical stored procedures are ported or retired.
- Scrub rules are migrated or bridged.
- Active reports are migrated or bridged.
- Direct `SqlClient` usage is removed or isolated from PostgreSQL mode.
- SQL Server `exec` string construction is removed or isolated from PostgreSQL mode.
- Practice routing works in PostgreSQL mode.
- Collation/case-insensitive behavior is tested.
- Financial totals are validated.
- Rollback plan is rehearsed.

## What NOT to Rewrite

The plan recommends retiring stored procedures into application services. That recommendation is correct in aggregate but wrong if applied to every SP. Some SPs are fine where they are; rewriting them adds risk without value.

**Keep as PostgreSQL functions or views (do not rewrite into C#):**

1. **Pure read-model aggregations that the database does well.** Aging-bucket math, charge-stat snapshots, simple report aggregations. These are SET operations the database optimizer handles better than application code paginating through rows.

2. **Reports that involve >5 joins and date-range partitioning.** Rewriting these into LINQ/OrmLite produces less-performant queries and obscures the SQL the DBA needs to tune.

3. **Idempotent ETL that runs on a schedule.** `usp_ChargeSnapShotsMonthWise` and similar consolidators. They write to read-only snapshot tables. Moving them to a C# background service buys nothing and adds operational surface (a service that must be running, monitored, and scaled).

4. **Computed-column-replacement views.** The 4 computed columns map cleanly to PG views; do not move them to application code.

**Quality signals from the original plan that are NOT rewrite triggers:**

- **`NOLOCK` usage (89 procs).** PostgreSQL MVCC makes NOLOCK irrelevant — *removing the hint is the migration*. The proc body itself is usually unchanged. Don't conflate "remove NOLOCK" with "rewrite the SP."
- **`SELECT *` (37 procs).** A code-quality smell, but not a migration blocker. Reports that consume the result set will still work. Address `SELECT *` in a separate cleanup project, not in the migration.
- **`ISNULL` (69 procs).** Mechanical replacement with `COALESCE`. Not a rewrite trigger — a syntax pass.
- **`CAST` / `CONVERT` (135 procs total).** Most translate cleanly. Only the `CONVERT(value, type, style)` form needs case-by-case attention.

**Triggers for actual rewriting (move to application code):**

- The SP performs **scrub or claim-validation business logic**. This belongs in C# where it is unit-testable.
- The SP **mutates state across many tables in one transaction** based on application input. Application services with explicit transaction scopes are clearer and testable.
- The SP **calls external services** (rare in T-SQL, but check). Application code is the right place.
- The SP **uses TVP inputs** (the 6 scrub procs). Already flagged as rewrite candidates.
- The SP **embeds business rules that change frequently** (per business owner). Application code lets product reason about changes.

**Apply the rewrite trigger list during Phase 5 classification.** Procedures matching only the "quality signals" without a real rewrite trigger should be marked "translate, don't rewrite."

## Effort Estimation

The original plan has no sizing. Without it, leadership cannot fund the project and engineering cannot commit timelines. Below are T-shirt sizes for one team of 4-5 engineers (1 backend lead, 2 backend, 1 DBA, 1 QA) plus a part-time product owner. Sizes assume the team is dedicated; halve them if the team is half-time.

| Phase | Size | Calendar weeks | Notes |
|---|---|---|---|
| **0**  | Stack decisions | M | 2 | Ratify with leadership; no code. |
| **0**  | Security cleanup | M | 2 | JWT secret, dev creds, permission filter. Mostly mechanical, blocks everything else. |
| **1**  | Build + test baseline + .NET 8 upgrade | XL | 8 | Largest pure-engineering item before migration starts. Risk: vendor library incompat (EdiFabric, OrmLite, ServiceStack license). |
| **1.5** | SqlClient consolidation | M | 3 | 15 files, mechanical for most. |
| **2**  | Compatibility boundary (interfaces + wrappers) | XL | 8 | Most leveraged work. Refactor every repository's SP/raw-SQL call to go through the executor. |
| **3**  | PG schema prototype | L | 6 | pgloader output + handwritten amendments + repeatable migration scripts. Includes naming-strategy enforcement. |
| **4**  | Data migration prototype + validators | L | 6 | Includes the financial-totals validator suite. |
| **5**  | SP classification (138 procs + 23 functions + 221 triggers) | M | 4 | Per-routine review; produces the catalog that drives Phase 6 sizing. |
| **6a** | SP retirement: scrubs (6 procs + 2 validators) | L | 6 | High-risk: TVP redesign, golden-master per rule. |
| **6b** | SP retirement: reports (~36 routines) | XL | 10 | Big surface. Many can be PG-functions for the migration; a subset retired into application code. |
| **6c** | SP retirement: denial dashboard (~10 procs) | L | 6 | App query handlers + indexes. |
| **6d** | SP retirement: ETL/Catalyst/Plaid/Chase (~15 procs) | L | 6 | Background jobs or services. |
| **6e** | SP retirement: audit triggers (221 → ~1 PG generic) | M | 4 | Mostly schema work plus one PL/pgSQL function. |
| **7**  | PG application implementation (provider, multi-tenant routing, perf) | L | 6 | The piece that turns on PG at runtime. |
| **8**  | PG performance and index tuning | M | 4 | Iterative; pilot exposes hot queries. |
| **9**  | Dual-run validation | L | 6 | Includes the trigger-noise classification window and pilot tenant onboarding. |
| **EDI** | 837/835 workstream (parallel) | L | 6 | Runs in parallel with 6a-d; gates pilot cutover. |
| **10** | Production cutover | M | 2 | If 9 is clean. Includes rollback rehearsal. |

**Sum (with parallelism):** ~13–18 calendar months from Phase 0 to last-tenant cutover for a moderately-sized customer base. Pilot tenant cutover is achievable inside 9–12 months.

**Risk factors that grow these numbers:**
- Vendor incompatibility on .NET 8 (EdiFabric or OrmLite license issues): +2–4 months on Phase 1.
- Trigger inventory reveals heavy business logic: +2–4 weeks on Phase 6e and adds work to 6a-d.
- Pilot tenant uncovers regression in EDI byte-parity: +2–6 weeks.
- Compliance audit demands stricter audit-row preservation: +2 weeks Phase 6e.
- Team availability < 4 FTE: linearly extend.

**Risk factors that shrink them:**
- Aggressive deletion of unused SPs in Phase 5 classification (the inventory in `STORED_PROCEDURES.md` §5 already names ~108 candidates): -1–2 months on Phase 6.
- Deciding NOT to retire reports — keep them as PG functions for v1 — saves 4-6 weeks on Phase 6b.
- Existing test coverage (today: very low). Each unit of pre-existing test coverage saves ~1 week of golden-master work.

**Estimate confidence:** ±30% at this stage. Re-estimate after Phase 0 (decisions made, scope frozen) and again after Phase 5 (procedure inventory complete).

## Coolify and Deployment Considerations

The original plan does not address that this codebase is Coolify-orchestrated. The migration touches deployment in three ways:

1. **Two databases during dual-run.** Each API service container needs both `ConnectionStrings__SqlServer` and `ConnectionStrings__Postgres` env vars during the pilot. The `IDatabaseConnectionFactory` selects per-tenant. Add new Coolify secrets; do not put PG credentials in `appsettings.*.json`.

2. **One PG service, not many.** Recommendation is schema-per-practice (one cluster); add one PostgreSQL container or managed PG external to Coolify. Avoid running PG inside Coolify for production — use a managed service for backups, replicas, monitoring.

3. **Rollback plan.** Coolify rollback is "redeploy previous container image." That works for application code, but if PG has received writes during the pilot, redeploying the old image (which only knows SQL Server) loses those writes. Pre-cutover decision: do you reverse-replicate during pilot, or do you accept that rolling back means data loss for the pilot tenant only? Document and rehearse.

**Deployment workstream items:**
- Add a per-tenant routing config map; flip a tenant by changing one entry.
- Add health checks that exercise both DB connections (existing health check probably only checks SQL Server).
- Update the Coolify docker-compose to include the PG connection string env var path.
- Update `coolify/README.md` with the dual-run runbook: how to flip a tenant, how to roll back, how to monitor diff jobs.

## Recommended First 30 Days

Week 1:

- Make the API build cleanly.
- Create a migration procedure catalog.
- Remove or isolate hardcoded database credentials from dev/test config.
- Choose target PostgreSQL naming strategy.
- Choose tenant layout.

Week 2:

- Build SQL Server golden-master tests for reports, scrubs, payment posting, denials, and claims.
- Create first PostgreSQL schema conversion prototype.
- Create first full data load prototype.

Week 3:

- Introduce database execution abstractions in design.
- Prototype PostgreSQL provider startup with one simple repository.
- Prototype one read-only report in PostgreSQL.
- Prototype one scrub rule replacement in C#.

Week 4:

- Compare SQL Server and PostgreSQL outputs.
- Estimate remaining procedure work by category.
- Decide which procedures will be ported temporarily and which will be retired before cutover.
- Produce a cutover timeline with pilot tenant selection.

## Final Recommendation

Use a hybrid migration.

Do not attempt a big-bang rewrite of all 138 SQL Server procedures into PostgreSQL. Also do not attempt to keep the current model where procedure names are executable configuration values in report and scrub tables.

The practical path is:

1. Stabilize and test the SQL Server baseline.
2. Build a PostgreSQL schema and data migration prototype.
3. Put all database-specific execution behind interfaces.
4. Port only the minimum critical stored procedures needed for the first PostgreSQL pilot.
5. Retire stored procedures module by module into tested C# services and query handlers.
6. Use dual-run comparisons until the PostgreSQL implementation proves equivalent for billing-critical workflows.

This is a significant migration. For this codebase, the stored procedure work is probably the largest part of the database migration, and scrub/report workflows should be treated as separate subprojects with their own tests and acceptance criteria.

## Outstanding Decisions / Open Questions

These are decisions or unknowns the plan cannot resolve unilaterally. Each should have a named owner and a deadline before Phase 1 starts. Closed decisions should be appended to the migration decision log; open ones drive risk.

### Decisions needed from leadership
1. **Approve .NET 8 LTS as runtime target?** (Default: yes. Owner: backend lead. Deadline: end of Phase 0.)
2. **Approve schema-per-practice multi-tenancy?** Decision changes deployment cost and migration parallelism. (Owner: architecture lead. Deadline: end of Phase 0.)
3. **Approve preserving PascalCase quoted identifiers?** Alternative is +3 months for lower_snake_case rename. (Owner: backend lead. Deadline: end of Phase 0.)
4. **Approve managed PostgreSQL service (vs self-hosted)?** Operational expertise question. (Owner: ops lead. Deadline: before Phase 4.)
5. **Approve EdiFabric license upgrade for .NET 8?** Cost question. (Owner: vendor management. Deadline: end of Phase 0.)
6. **Approve hybrid migration (Option C) over full retirement (Option B)?** Codex recommends hybrid; this v2 review concurs. (Owner: architecture lead. Deadline: end of Phase 0.)
7. **Approve pilot tenant selection?** Use the rubric in §"Pilot tenant selection rubric". (Owner: product + ops. Deadline: before Phase 9.)
8. **Approve cutover model: hard cutover with maintenance window, or CDC-based zero-downtime?** Affects Phase 10 design. (Owner: architecture + ops. Deadline: before Phase 8.)

### Decisions needed from compliance / legal
1. **HIPAA audit retention requirements** for the 221 triggers. Which audit rows must survive the migration as bit-perfect copies vs. acceptable to reproduce in a new schema? (Owner: compliance. Deadline: before Phase 6e.)
2. **PHI handling during dual-run.** May the diff-validation job include patient names/DOBs in its diff output for triage, or must outputs be de-identified? (Owner: compliance. Deadline: before Phase 9.)
3. **Cross-border data residency** if managed PG is in a different region than the existing on-prem SQL Server. (Owner: compliance. Deadline: before Phase 4.)
4. **Backup retention policy for the new cluster.** PITR window, monthly archive retention, deletion policy. (Owner: ops + compliance. Deadline: before Phase 4.)

### Decisions needed from clearinghouse / external partners
1. **Clearinghouse acceptance** of 837 files generated from the new server (if the IP changes). (Owner: integrations lead. Deadline: before Phase 9 EDI cutover.)
2. **Plaid, MethaSoft, Catalyst, Chase** API contracts — verify none assume database-side state that would diverge during dual-run. (Owner: integrations lead. Deadline: before Phase 6d.)
3. **External report consumers** (if any practices export reports to external systems) — verify column-name and number-format parity. (Owner: account management. Deadline: before pilot.)

### Open technical questions
1. **Is `usp_GetDynmoPaymentsForCatalystRCM` actually missing from the DB** (per the plan's note) or just lower-cased in metadata? Resolve via DB introspection. (Owner: backend lead. Deadline: end of Phase 5.)
2. **Are the 8 commented-out / "Inactive" categories in `STORED_PROCEDURES.md` §5** truly orphaned, or are some of them called by SQL Agent jobs? Run the SP-impact-analyzer on each before deciding to drop. (Owner: DBA. Deadline: end of Phase 5.)
3. **Does the ServiceStack license bundle include OrmLite PostgreSQL provider?** (Owner: backend lead. Deadline: end of Phase 0.)
4. **Will the team accept a brief read-only window during cutover** (e.g., 30 minutes) or must it be zero-downtime? Decides whether logical replication is needed. (Owner: ops. Deadline: before Phase 8.)
5. **What is the test data plan?** The current dev DB has live PHI. We cannot use it for unit/integration testing. Need a de-identified synthetic dataset that exercises the major workflows. (Owner: QA lead. Deadline: end of Phase 1.)
6. **Are there SQL Agent jobs we don't know about?** Per the plan, "scheduled work runs as SQL Agent jobs on the DB host." Inventory required. (Owner: DBA. Deadline: end of Phase 5.)
7. **What is the rollback authority chain?** Who can call "abort cutover" at hour 6 of a 12-hour window, and what's the criteria? (Owner: project sponsor. Deadline: before Phase 10.)

### Items the original plan flagged that this review confirms
1. The `usp_PaymentChargeByPaymentId` reference in commented-out code is dead — confirmed via the SP catalog. Drop it cleanly during Phase 5.
2. The two missing scrub validators (`CPTToICDValidator`, `CPTToModifierValidator`) are C# classes, not DB SPs, and are dispatched by the same `Scrub.StoredProcedure` column. Confirmed in the API safety review. Documented in the new `add-scrub` skill.
3. `BaseRepository.ExecuteStoredProcedureAsync` is SQL-injection-vulnerable. Confirmed. Phase 2's `IRoutineExecutor` boundary closes this surface.

## Cross-references

This plan complements other migration-supporting docs in the repo:

- [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md) — current SP catalog (138 SPs, callers, dispatch tables).
- [docs/architecture/SECURITY_AND_RISKS.md](../architecture/SECURITY_AND_RISKS.md) — known risks; the migration must not regress any of these.
- [docs/architecture/API_ARCHITECTURE.md](../architecture/API_ARCHITECTURE.md) — current architecture; informs the boundary design in Phase 2.
- [docs/database/PI_ATC_CLINIC_schema.md](./PI_ATC_CLINIC_schema.md) — current schema dump.
- [VIBECODING.md](../../VIBECODING.md) — the framework's `sp-impact-analyzer` subagent should be used during Phase 5 to verify each SP's blast radius before deciding its disposition.
