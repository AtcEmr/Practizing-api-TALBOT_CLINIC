# PostgreSQL Schema Conversion Worksheet

This is a **worksheet**, not a generator output. It lists every conversion rule, every Phase 0 decision that gates each rule, and a per-table-class status column. The team fills it in as decisions are ratified and artifacts are produced under [postgres/](./postgres/).

When this worksheet is fully green, [postgres/curated/](./postgres/) is ready for the dual-run pilot.

---

## Phase 0 decisions (gate everything below)

Until each of these is **APPROVED** and dated in the [migration plan's Review Iteration Log](./sql-server-to-postgres-migration-plan.md), no DDL should be committed.

| # | Decision | Status | Owner | Approved date | Notes |
|---|---|---|---|---|---|
| D1 | **Runtime target** — .NET 10 LTS (with optional .NET 8 stepping stone) | pending | backend lead | — | Required before Npgsql / OrmLite versions can be picked. |
| D2 | **Multi-tenant model** — schema-per-practice (recommended) vs. DB-per-practice vs. shared tables | pending | architecture | — | Determines `CREATE SCHEMA` vs. `CREATE DATABASE` plus identity-sequence scoping. |
| D3 | **Naming strategy** — PascalCase quoted (recommended) vs. lower_snake_case | pending | backend lead | — | Determines every column name in every CREATE TABLE. Mixing inside the migration is a CI fail. |
| D4 | **Case-insensitive columns** — `citext` vs. functional indexes on `lower(...)` vs. write-time normalize | pending | backend lead | — | Affects ~20 columns: CPT, ICD, NDC, usernames, payer codes, modifier codes, practice codes. |
| D5 | **Money type** — `numeric(19,4)` confirmed (never PG `money`) | pending | architecture | — | Default-yes; ratify in writing. |
| D6 | **Identity strategy** — sequence per table (recommended) vs. global sequences | pending | DBA | — | Per-table matches SQL Server `IDENTITY` semantics. |
| D7 | **Audit-history strategy** — single PG generic trigger function (recommended) vs. port 221 individual triggers | pending | architecture + compliance | — | Compliance must confirm HIPAA retention rules first. |
| D8 | **Computed-column strategy** — PG generated columns vs. views vs. application-side | pending | backend lead | — | Per-column choice; default to generated columns for the simple cases. |
| D9 | **Pilot tenant** — practice code, expected month-end dates | pending | product + ops | — | Selection rubric in the migration plan. |
| D10 | **Cutover model** — maintenance window vs. CDC-based zero-downtime | pending | ops | — | Affects Phase 8 design. |

---

## Conversion rules (each gated on a decision above)

### Identifiers

| Rule | Gated on | Status | Note |
|---|---|---|---|
| All table/column names quoted exactly as in SQL Server | D3 | pending | If lower_snake_case is chosen instead, replace with a separate transform pass and add 3 months. |
| Reserved-word collisions checked (`User`, `Order`, etc.) | D3 | pending | SQL Server table `PZ_User` quotes fine in PG. |
| Schema names — one per practice | D2 | pending | Naming convention `practice_<code>` (lowercase always for schema names; safest). |
| Cross-schema references in views/SPs use schema-qualified names | D2 | pending | |

### Data types

The full mapping table is in [sql-server-to-postgres-migration-plan.md §"Current Data Type Usage"](./sql-server-to-postgres-migration-plan.md#current-data-type-usage). Per-rule status:

| Source | Target | Gated on | Status | Note |
|---|---|---|---|---|
| `varchar(n)` | `varchar(n)` (preserve length) | — | pending | Most common (2065 columns). |
| `nvarchar(n)` | `varchar(n)` | — | pending | PG text is UTF-8; `nvarchar` distinction is moot. |
| `int` → `integer`, `bigint` → `bigint`, `smallint` → `smallint`, `tinyint` → `smallint + check` | — | pending | Mechanical. |
| `bit` | `boolean` | — | pending | Default values must be `true`/`false`, not `1`/`0`. |
| `datetime` | `timestamp without time zone` | — | pending | Unless column represents an absolute instant; then `timestamptz`. Per-column review needed. |
| `date` | `date` | — | pending | Mechanical. |
| `datetime2` | `timestamp` | — | pending | 3 columns; preserve precision. |
| `money` | `numeric(19,4)` | D5 | pending | Never `money`. 193 columns. |
| `decimal(p,s)` | `numeric(p,s)` | — | pending | Mechanical. |
| `uniqueidentifier` | `uuid` | — | pending | Default `gen_random_uuid()` from `pgcrypto`. 104 columns. |
| `image`, `varbinary` | `bytea` | — | pending | 8 columns total. |
| `text` | `text` | — | pending | 9 columns; deprecated in SQL Server, fine in PG. |
| `float` | `double precision`, `real` | — | pending | 9 columns. |
| `PatientBillingID` (user-defined alias) | `varchar(20)` or PG domain | — | pending | 3 columns. |
| `sysname` | `varchar(128)` | — | pending | 1 column. |
| Case-insensitive code columns | `citext` OR `lower()` index | D4 | pending | Affects CPT, ICD, NDC, modifier, payer, username, practice-code, insurance-name columns. |

### Defaults

| Source | Target | Status |
|---|---|---|
| `((0))`, `((1))`, `(())` literal numerics | Same literal | pending |
| `(getdate())` | `now()` or `CURRENT_TIMESTAMP` | pending |
| `(sysutcdatetime())` | `timezone('utc', now())` if column is `timestamp`; otherwise pick `timestamptz` design | pending |
| `(newid())` | `gen_random_uuid()` (requires `pgcrypto`) | pending |
| Custom function defaults | Per-column review | pending |

### Identity columns (231 total)

| Rule | Gated on | Status |
|---|---|---|
| Each `IDENTITY(s, i)` becomes `GENERATED BY DEFAULT AS IDENTITY` (or `SERIAL`/`BIGSERIAL` per type) | D6 | pending |
| Sequence start values seeded above max imported ID (`setval(...)`) | D6 | pending |
| Per-schema sequences when D2 = schema-per-practice | D2, D6 | pending |

### Computed columns (4 total)

| Source column | Expression | Target plan | Status |
|---|---|---|---|
| `dbo.AdjustmentReasonCode.ReasonCode` | `GroupCode + '-' + Code` | PG generated column `(group_code \|\| '-' \|\| code)` | pending |
| `dbo.ChargeOld.RealPostDate` | `dateadd(second, PostTime, PostDate)` | PG generated column using `interval` arithmetic | pending |
| `dbo.ConfigAdjustmentReasonCode.ReasonCode` | `GroupCode + '-' + Code` | PG generated column | pending |
| `dbo.ConfigAdjustmentReasonCode.Description` | `Category` | PG generated column or rename column | pending |

### Constraints (412 total: 272 defaults + 140 FKs + 1 check, plus 259 indexes)

| Rule | Status | Note |
|---|---|---|
| FKs preserved as-is | pending | But: SQL Server may have FKs added with `WITH NOCHECK` that have orphan rows. Validation script must catch these before PG rejects them. |
| Cascading rules (`ON DELETE CASCADE` etc.) preserved | pending | Per-FK review for behavior parity. |
| Unique constraints preserved | pending | Watch for case-insensitive collisions where SQL Server CI collation hid duplicates. |
| Indexes — straight conversion | pending | Add functional `lower()` indexes per D4. |
| Indexes — `INCLUDE` columns | pending | PG supports `INCLUDE` since v11. |
| Filtered indexes (SQL Server `WHERE` clause) | pending | Become PG partial indexes; syntax differs. |
| Check constraints | pending | Only 1 in source. |

### Views (16 total)

| Rule | Status | Note |
|---|---|---|
| Views ported one-to-one | pending | Replace SQL-Server-only syntax (e.g. `TOP`, `ISNULL`) per the migration plan's T-SQL syntax table. |
| Views that reference deprecated SP behavior | pending | Per-view review. |
| Materialized-view candidates flagged | pending | Reporting views may benefit from `MATERIALIZED VIEW` + scheduled refresh. |

### Triggers (221 total)

| Rule | Gated on | Status |
|---|---|---|
| Inventory: classify each trigger as audit-history / cascading-state / dead | D7 | pending |
| Audit-history triggers replaced with **one** generic PG function attached to N tables | D7 | pending |
| Cascading-state triggers retired into application services | D7 | pending |
| Dead triggers dropped | — | pending |
| HIPAA retention requirements confirmed before any audit trigger is dropped | D7 | pending |

### Stored procedures (138 total) and functions (23 total)

Per-routine status lives in [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md). Phase 5 of the migration plan extends that catalog with a "migration disposition" column. Until Phase 5 closes, the conversion target for each routine is `unknown`.

| Disposition | Count (estimated) | Where it ends up |
|---|---|---|
| Retired into application code | ~70 | `IRoutineExecutor` registry maps the key to a C# query handler. |
| Ported as PG function (temporary bridge) | ~30 | `postgres/functions/` |
| Permanent PG function (read-model helper) | ~10 | `postgres/functions/` |
| Deleted (orphaned/dead) | ~28 | not migrated |

### TVPs / Table-Valued Parameters

| Source | Target | Gated on | Status |
|---|---|---|---|
| `dbo.ChargeType` (52 columns, used by 6 scrub SPs) | JSONB input to PG function with `jsonb_to_recordset`, OR retire scrubs to C# entirely | D7 + Phase 6a | pending |

---

## Per-table-class progress (placeholder)

Group of 275 tables for tracking. **All rows start at "pending Phase 0".** Update as Phase 3 closes.

| Table class | Example tables | Decisions affecting | Status |
|---|---|---|---|
| Identity / users / permissions | `PZ_User`, `PZ_Role`, `PZ_UserPermission`, `PZ_ModulePermission` | D2, D3, D4 (usernames) | pending Phase 0 |
| Patient / demographics | `Patient`, `PatientCase`, `Address`, `InsurancePolicy` | D2, D3, D4 (names) | pending Phase 0 |
| Charge / payment / invoice | `Charge`, `Payment`, `PaymentAdjustment`, `Invoice`, `Voucher`, `ChargeBatch`, `PaymentBatch` | D2, D3, D5 (money) | pending Phase 0 |
| Claim / EDI / scrub | `Claim`, `ClaimView`, `ClaimBatch`, `Scrub`, `ScrubError`, `ScrubAssignment` | D2, D3 | pending Phase 0 |
| ERA / 835 | `ERARoot`, `ERAClaim`, `ERAPayment` | D2, D3, D5 | pending Phase 0 |
| Master / config | `CPTCode`, `ICDCode`, `NDC`, `InsuranceCompany`, `Provider`, `Facility`, `ConfigSetting`, `PZ_Report`, `Scrub` | D2, D3, D4 (codes) | pending Phase 0 |
| Reporting read-model / warehouse | `ChargeStat`, `ChargesReportData`, `ChargesReportDataSnapShots`, `ChargesReportData_Consolidate`, `Aging*` | D2, D5 | pending Phase 0 |
| Audit / history (`*_H`, `H_*`) | `H_Charge`, `H_Payment`, `H_Scrub`, ... | D7 | pending Phase 0 |
| Bank reconciliation / Plaid / MethaSoft | `BankReconciliation`, `PlaidPayment`, `ChasePayment`, `MethaSoftInvoice` | D2, D3, D5 | pending Phase 0 |
| Lookups / utility | `ZipCodeLookUp`, `ConfigSystemCD`, `ConfigPOS`, ... | D2 | pending Phase 0 |

When pgloader output exists, this becomes a per-table table: 275 rows, each "draft generated / curated / validated / approved."

---

## Validation gate (Phase 4 → Phase 9)

This worksheet is not "done" until every item below passes:

- [ ] All Phase 0 decisions APPROVED with date in the migration plan's Review Iteration Log.
- [ ] `postgres/draft/` populated by pgloader against the full schema.
- [ ] `postgres/curated/` reflects every deviation needed; `deviations.md` explains each.
- [ ] All 275 tables have a row in this worksheet's per-table table with status `validated`.
- [ ] All 4 computed columns reproduced and verified in `validation/computed_column_parity.sql`.
- [ ] All 140 FKs apply cleanly (no orphan rows blocking).
- [ ] Money totals from `validation/money_totals.sql` match SQL Server within $0.01 across `Charge`, `Payment`, `PaymentAdjustment`, `Voucher`, `Invoice`, `ChargeBatch`, `PaymentBatch`.
- [ ] Case-collision check from `validation/case_collision_check.sql` returns zero rows for every D4-affected column.
- [ ] All 138 SPs have a Phase 5 disposition recorded in [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md).
- [ ] All 221 triggers classified per D7; audit generic function in `postgres/triggers/audit_generic.sql`.
- [ ] Pilot tenant (D9) selected and signed off.
- [ ] EDI 837 byte-parity confirmed for the test claim corpus (Phase 9 EDI gate).
- [ ] 835 ERA posting parity confirmed for the test ERA corpus.

---

## Open issues that affect this worksheet

These are tracked here so they don't get lost:

1. **`usp_GetDynmoPaymentsForCatalystRCM`** — referenced from `DynmoPaymentsRepository.cs:484` but not present in the SQL Server schema. Either restore the SP, remove the C# code path, or migrate the integration. Owner: backend lead. Deadline: end of Phase 5. ([STORED_PROCEDURES.md §8](../../STORED_PROCEDURES.md))
2. **Scrub rows 7 & 8** (`CPTToICDValidator`, `CPTToModifierValidator`) — configured in `Scrub.StoredProcedure` but no SQL Server SP exists. Either implement, refactor `RunAutoScrub`, or deactivate. Owner: backend lead. Deadline: before scrub workstream starts.
3. **EdiFabric net45 DLLs** — current `lib/EdiFabric.Framework/DLLs/net45/*` will not load on .NET 10. Vendor upgrade or replacement is a Phase 1 prerequisite. Owner: backend lead. Deadline: end of Phase 1.
4. **PHI in dev DB** — `appsettings.Development.json` points at a DB that contains real billing data. The test infrastructure (write-tests skill) needs a de-identified synthetic dataset before any integration test can be authored without PHI exposure. Owner: QA lead. Deadline: end of Phase 1.

---

## How to update this worksheet

1. When a Phase 0 decision is approved, change its row to `APPROVED`, fill in date, and update the gated rules' status from `pending` to `ready`.
2. When pgloader produces output, populate the per-table progress table with one row per actual table.
3. When a deviation from pgloader output is needed in `postgres/curated/`, add an entry in `postgres/curated/deviations.md` AND mark the relevant rule here.
4. When all items in the validation gate pass, mark this worksheet **DONE** and move on to Phase 9 dual-run.

This worksheet is itself a deliverable. Stale rows are worse than missing ones.

## Cross-references

- [sql-server-to-postgres-migration-plan.md](./sql-server-to-postgres-migration-plan.md) — the plan that drives this worksheet.
- [postgres/README.md](./postgres/README.md) — destination folder for artifacts.
- [PI_ATC_CLINIC_schema.md](./PI_ATC_CLINIC_schema.md) — current SQL Server schema, the source.
- [../../STORED_PROCEDURES.md](../../STORED_PROCEDURES.md) — SP catalog driving the routine-disposition tracking.
