# PostgreSQL Schema Conversion Worksheet

This is a **worksheet**, not a generator output. It lists every conversion rule, every Phase 0 decision that gates each rule, and both per-table-class and per-table status columns. The team fills it in as decisions are ratified and artifacts are produced under [postgres/](./postgres/).

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

Per-routine status lives in **[postgres-sp-conversion.md](./postgres-sp-conversion.md)** — the parallel worksheet that tracks each of the 131 user SPs (138 minus 7 system `sp_*diagram*` SPs). [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md) remains the source of truth for *current callers*; the SP worksheet is the source of truth for *migration disposition*.

The SP worksheet contains a per-SP row with category, dispatch (PZ_Report / Scrub / C# direct), risk signals (NOLOCK / TEMP / DYNSQL / TVP / WRITE / etc.), recommended disposition, and migration status. As of the initial generation, every row's status is `pending Phase 0`.

Disposition distribution (preliminary, before Phase 5 review):

| Disposition | Count |
|---|---:|
| Retire to C# (active reports + denial + integrations + statements + ChargeStat) | ~25 |
| Port to PG function (large reports as temporary bridge) | ~12 |
| Move to scheduled job (ETL / warehouse / snapshots) | ~16 |
| Move to integration service (Catalyst / Plaid / MethaSoft / Chase) | ~8 |
| Drop (inactive reports + orphans + cleanup utilities + dated copies) | ~70 |
| BROKEN (3 phantom references — not in this count) | 3 |

These are starting estimates. Phase 5 classification refines each row.

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

The detailed table below is the starting per-table worksheet. It should move from `pending Phase 0` to `draft generated / curated / validated / approved` as artifacts land.

### Per-table progress (generated from current SQL Server snapshot)

This table is generated from `PI_ATC_CLINIC_schema.json` and intentionally starts every table at `pending Phase 0`. It is still not DDL. The first status transition should happen only after Phase 0 decisions are approved and pgloader (or the selected equivalent) produces draft output.

Columns:
- `Text cols` counts `varchar`, `nvarchar`, `char`, `text`, and `sysname` columns that may need D4 case/collation review.
- `Legacy/binary` counts `text` and `image` columns needing explicit conversion review.
- `UDT alias` counts `PatientBillingID` columns needing a domain-vs-plain-varchar decision.

| Table | Columns | Identity | Computed | Money cols | Text cols | Legacy/binary | UDT alias | Status | Notes |
|---|---:|---:|---:|---:|---:|---:|---:|---|---|
| `dbo.ActionCategory` | 15 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.ActionNote` | 21 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.AdjustmentReasonCode` | 14 | 1 | 1 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.AppSetting` | 10 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ARGroup` | 8 | 0 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.ARGroupReasonCode` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ARSCategoryReasonCode` | 5 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ATC_DATA` | 23 | 1 | 0 | 0 | 18 | 0 | 0 | pending Phase 0 | |
| `dbo.AttFile` | 12 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.AttFileTable` | 3 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.BankReconciliation` | 30 | 1 | 0 | 6 | 8 | 0 | 0 | pending Phase 0 | |
| `dbo.BatchStatement` | 12 | 1 | 0 | 1 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.BillingUnitConversionChart` | 4 | 1 | 0 | 0 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.CallHistory` | 12 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.CatalystChargeNotes` | 7 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.Charge` | 64 | 1 | 0 | 6 | 22 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargeBatch` | 12 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargeInWriteOff` | 10 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargeNote` | 8 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargeOld` | 68 | 0 | 1 | 12 | 19 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargeScrub` | 3 | 1 | 0 | 0 | 1 | 1 | 0 | pending Phase 0 | |
| `dbo.ChargesForCatalystExcel` | 68 | 0 | 0 | 5 | 48 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargesReportData` | 156 | 1 | 0 | 9 | 104 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargesReportData_Consolidate` | 135 | 1 | 0 | 9 | 90 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargesReportDataSnapShots` | 15 | 1 | 0 | 7 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargesReportDataSnapShots_All` | 16 | 1 | 0 | 7 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargesReportDataSnapShotsChild` | 14 | 1 | 0 | 7 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargesReportDataSnapShotsChild_All` | 15 | 1 | 0 | 7 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargeStat` | 10 | 0 | 0 | 4 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ChargeStatementCount` | 7 | 1 | 0 | 1 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.ChasePaymentChild` | 5 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ChasePayments` | 15 | 1 | 0 | 2 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.Claim` | 239 | 1 | 0 | 0 | 168 | 0 | 0 | pending Phase 0 | |
| `dbo.ClaimBatch` | 21 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ClaimCharge` | 9 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.ClaimConfig` | 10 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ClaimStatusInquiry` | 4 | 1 | 0 | 0 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.ClaimStatusInquiryChild` | 14 | 1 | 0 | 1 | 11 | 0 | 0 | pending Phase 0 | |
| `dbo.ClaimTotal` | 16 | 1 | 0 | 3 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.Clearinghouse` | 48 | 1 | 0 | 0 | 34 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigAdjustmentReasonCode` | 11 | 1 | 2 | 0 | 8 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigBillType` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigCaseType` | 5 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigCDGroup` | 3 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigClaimTypeCodes` | 3 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigDrugClass` | 5 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigERARemarkCodes` | 5 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigFacilitySubType` | 5 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigFacilityType` | 4 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigFollowUpPeriod` | 5 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigIdType` | 4 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigInsuranceCompanyType` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigInsuranceFormType` | 6 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigInsuranceMedicareSecondary` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigMaritalStatus` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigMessageCode` | 10 | 0 | 0 | 0 | 8 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigNDCUOM` | 4 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigPatientRace` | 6 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigPlaid` | 6 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigPOS` | 4 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigPosition` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigPractitionerService` | 10 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigProviderPosition` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigProviderSpecialty` | 4 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigReferralSource` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigRelationship` | 6 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigScrubsCCIEdit` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigServiceCircumstance` | 3 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigServiceType` | 4 | 0 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigSetting` | 11 | 0 | 0 | 0 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigSettingGroup` | 4 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigSupervisionType` | 2 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigSystemCD` | 4 | 0 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigTOS` | 3 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ConfigTrizettoPatientEligibility` | 23 | 1 | 0 | 0 | 17 | 0 | 0 | pending Phase 0 | |
| `dbo.CPT_To_ICD10` | 5 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.CPT_To_Modifier` | 5 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.CPTCategory` | 11 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.CPTCode` | 33 | 1 | 0 | 1 | 11 | 0 | 0 | pending Phase 0 | |
| `dbo.CPTModifier` | 6 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.DailyQueue` | 9 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.DefaultReasonCode` | 9 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.DenialQueue` | 15 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.DepositType` | 7 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.Destination` | 4 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.DrugCharge` | 63 | 1 | 0 | 6 | 22 | 0 | 0 | pending Phase 0 | |
| `dbo.DrugClass` | 8 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.dsig_test` | 1 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.DynmoPayments` | 29 | 1 | 0 | 0 | 19 | 0 | 0 | pending Phase 0 | |
| `dbo.EDI824` | 13 | 1 | 0 | 0 | 8 | 0 | 0 | pending Phase 0 | |
| `dbo.EDIEligibilityLog` | 9 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.EdiErrorCodes` | 3 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.emricdcode` | 3 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.EncounterRules` | 11 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.EncounterRulesAllowedCPT` | 4 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.EncounterRulesAllowedPOS` | 4 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.EncounterTypes` | 8 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ERAClaim` | 19 | 1 | 0 | 1 | 9 | 0 | 0 | pending Phase 0 | |
| `dbo.ERAClaimChargeAdjustment` | 7 | 1 | 0 | 1 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ERAClaimChargePayment` | 11 | 1 | 0 | 2 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.ERAClaimChargeRemark` | 4 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ERARoot` | 25 | 1 | 0 | 1 | 21 | 0 | 0 | pending Phase 0 | |
| `dbo.Facility` | 32 | 1 | 0 | 0 | 19 | 0 | 0 | pending Phase 0 | |
| `dbo.FacilityIdentity` | 9 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.FeeSchedule` | 12 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.FSCharge` | 17 | 1 | 0 | 3 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.FSDiscount` | 13 | 1 | 0 | 2 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.FSLocalityCarrier` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ActionCategory` | 18 | 1 | 0 | 0 | 8 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ActionNote` | 22 | 1 | 0 | 0 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.H_AppSetting` | 13 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ARGroup` | 11 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ARGroupReasonCode` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ARSCategoryReasonCode` | 8 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_AttFile` | 14 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.H_AttFileTable` | 6 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Charge` | 60 | 1 | 0 | 6 | 24 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ChargeBatch` | 15 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Claim` | 158 | 1 | 0 | 0 | 105 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ClaimBatch` | 21 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ClaimCharge` | 7 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ClaimConfig` | 13 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ClaimTotal` | 19 | 1 | 0 | 0 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Clearinghouse` | 44 | 1 | 0 | 0 | 33 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigBillType` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigCaseType` | 8 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigCDGroup` | 6 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigDrugClass` | 7 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigFacilitySubType` | 8 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigFacilityType` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigFollowUpPeriod` | 8 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigIdType` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigInsuranceCompanyType` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigInsuranceFormType` | 9 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigInsuranceMedicareSecondary` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigNDCUOM` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigPOS` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigPosition` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigProviderPosition` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigProviderSpecialty` | 7 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigReferralSource` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigRelationship` | 9 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigSetting` | 14 | 1 | 0 | 0 | 9 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigSettingGroup` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigSystemCD` | 7 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ConfigTOS` | 6 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_CPTCategory` | 14 | 1 | 0 | 0 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.H_CPTCode` | 30 | 1 | 0 | 1 | 11 | 0 | 0 | pending Phase 0 | |
| `dbo.H_CPTModifier` | 8 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_DefaultReasonCode` | 11 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_DenialQueue` | 17 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.H_DepositType` | 10 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Destination` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_DrugCharge` | 55 | 1 | 0 | 3 | 21 | 0 | 0 | pending Phase 0 | |
| `dbo.H_DrugClass` | 11 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.H_DynmoPayments` | 32 | 1 | 0 | 0 | 21 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ERAClaim` | 14 | 1 | 0 | 1 | 9 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ERAClaimChargeAdjustment` | 8 | 1 | 0 | 1 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ERAClaimChargePayment` | 12 | 1 | 0 | 2 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ERAClaimChargeRemark` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ERARoot` | 27 | 1 | 0 | 1 | 22 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Facility` | 29 | 1 | 0 | 0 | 19 | 0 | 0 | pending Phase 0 | |
| `dbo.H_FacilityIdentity` | 12 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_FeeSchedule` | 15 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_FSCharge` | 20 | 1 | 0 | 3 | 9 | 0 | 0 | pending Phase 0 | |
| `dbo.H_FSDiscount` | 15 | 1 | 0 | 2 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_FSLocalityCarrier` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_HL7Status` | 18 | 1 | 0 | 0 | 10 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ICDCode` | 21 | 1 | 0 | 0 | 10 | 0 | 0 | pending Phase 0 | |
| `dbo.H_InsuranceCompany` | 35 | 1 | 0 | 0 | 18 | 0 | 0 | pending Phase 0 | |
| `dbo.H_InsuranceGuarantor` | 32 | 1 | 0 | 0 | 28 | 0 | 0 | pending Phase 0 | |
| `dbo.H_InsurancePolicy` | 36 | 1 | 0 | 0 | 15 | 0 | 0 | pending Phase 0 | |
| `dbo.H_InsurancePolicyHolder` | 32 | 1 | 0 | 0 | 24 | 0 | 0 | pending Phase 0 | |
| `dbo.H_InvDiagnosis` | 8 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Invoice` | 57 | 1 | 0 | 1 | 12 | 0 | 0 | pending Phase 0 | |
| `dbo.H_NDC` | 16 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Patient` | 118 | 1 | 0 | 0 | 69 | 1 | 1 | pending Phase 0 | |
| `dbo.H_PatientAuthorizationNumber` | 13 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_PatientCase` | 15 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_PatientStatement` | 11 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Payment` | 22 | 1 | 0 | 3 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.H_PaymentAdjustment` | 14 | 1 | 0 | 1 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_PaymentBatch` | 15 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_PaymentCharge` | 10 | 1 | 0 | 1 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.H_PaymentRemarkCode` | 8 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_PortalPayment` | 26 | 1 | 0 | 2 | 12 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Practice` | 12 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Provider` | 27 | 1 | 0 | 0 | 12 | 1 | 0 | pending Phase 0 | |
| `dbo.H_ProviderIdentity` | 12 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.H_PUser` | 20 | 1 | 0 | 0 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ReferringDoctor` | 30 | 1 | 0 | 0 | 20 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Scrub` | 13 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ScrubAssignment` | 11 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.H_Voucher` | 25 | 1 | 0 | 1 | 9 | 0 | 0 | pending Phase 0 | |
| `dbo.H_ZipCodeLookup` | 10 | 1 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.HL7RuleScripts` | 5 | 1 | 0 | 0 | 1 | 1 | 0 | pending Phase 0 | |
| `dbo.HL7Status` | 15 | 1 | 0 | 0 | 8 | 0 | 0 | pending Phase 0 | |
| `dbo.ICDCode` | 20 | 1 | 0 | 0 | 8 | 0 | 0 | pending Phase 0 | |
| `dbo.icdtemp` | 2 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.InsuranceCompany` | 42 | 1 | 0 | 0 | 19 | 0 | 0 | pending Phase 0 | |
| `dbo.InsuranceGuarantor` | 29 | 1 | 0 | 0 | 26 | 0 | 0 | pending Phase 0 | |
| `dbo.InsuranceOnlinePayment` | 16 | 1 | 0 | 1 | 10 | 0 | 0 | pending Phase 0 | |
| `dbo.InsurancePolicy` | 37 | 1 | 0 | 0 | 14 | 0 | 0 | pending Phase 0 | |
| `dbo.InsurancePolicy_ERAUpdate` | 5 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.InsurancePolicyException` | 4 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.InsurancePolicyHolder` | 29 | 1 | 0 | 0 | 22 | 0 | 0 | pending Phase 0 | |
| `dbo.InvDiagnosis` | 5 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.InvDxOld` | 12 | 0 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.Invoice` | 60 | 1 | 0 | 1 | 12 | 0 | 0 | pending Phase 0 | |
| `dbo.InvoiceOld` | 73 | 1 | 0 | 1 | 16 | 3 | 0 | pending Phase 0 | |
| `dbo.LabSalesRep` | 8 | 0 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.LISA_Charges` | 4 | 1 | 0 | 0 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.LlmSettings` | 9 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |
| `dbo.MasterCPT` | 2 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.MasterICD10` | 2 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.MethaSoftInvoice` | 20 | 1 | 0 | 0 | 13 | 0 | 0 | pending Phase 0 | |
| `dbo.MonthEndClose` | 7 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.NDC` | 14 | 0 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.Patient` | 119 | 1 | 0 | 0 | 70 | 1 | 1 | pending Phase 0 | |
| `dbo.PatientAlert` | 9 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PatientAuthorizationNumber` | 10 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PatientCase` | 12 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PatientEligibility` | 14 | 1 | 0 | 0 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.PatientEligibilityDetail` | 29 | 1 | 0 | 0 | 26 | 0 | 0 | pending Phase 0 | |
| `dbo.PatientNote` | 9 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PatientPolicyAuthorization` | 24 | 1 | 0 | 0 | 18 | 0 | 0 | pending Phase 0 | |
| `dbo.PatientState` | 11 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PatientStatement` | 13 | 1 | 0 | 1 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.Payment` | 21 | 1 | 0 | 3 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.PaymentAdjustment` | 12 | 1 | 0 | 1 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PaymentAdjustmentNotes` | 9 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PaymentBatch` | 12 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PaymentCharge` | 7 | 1 | 0 | 1 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.PaymentRemarkCode` | 6 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.PaymentReportData` | 35 | 1 | 0 | 4 | 17 | 0 | 0 | pending Phase 0 | |
| `dbo.PaymentReportData__Consolidate` | 37 | 1 | 0 | 4 | 18 | 0 | 0 | pending Phase 0 | |
| `dbo.PlaidPayment` | 41 | 1 | 0 | 0 | 36 | 0 | 0 | pending Phase 0 | |
| `dbo.PortalPayment` | 28 | 1 | 0 | 3 | 12 | 0 | 0 | pending Phase 0 | |
| `dbo.PortalPaymentChild` | 3 | 1 | 0 | 0 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.Practice` | 40 | 0 | 0 | 0 | 30 | 0 | 0 | pending Phase 0 | |
| `dbo.Provider` | 38 | 1 | 0 | 0 | 15 | 1 | 0 | pending Phase 0 | |
| `dbo.ProviderFacilityValidtion` | 3 | 1 | 0 | 0 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.ProviderIdentity` | 9 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.Provieder_temp` | 12 | 1 | 0 | 0 | 11 | 0 | 0 | pending Phase 0 | |
| `dbo.PZ_Module` | 3 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.PZ_ModulePermission` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.PZ_Report` | 11 | 1 | 0 | 0 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.PZ_Role` | 2 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.PZ_RoleModule` | 3 | 1 | 0 | 0 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.PZ_User` | 21 | 1 | 0 | 0 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.PZ_UserAuthentication` | 7 | 1 | 0 | 0 | 3 | 2 | 0 | pending Phase 0 | |
| `dbo.PZ_UserPermission` | 8 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.PZ_UserRole` | 8 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ReferringDoctor` | 31 | 1 | 0 | 0 | 20 | 0 | 0 | pending Phase 0 | |
| `dbo.RemarkCodeSolution` | 4 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ReportARChargesMonthWise` | 19 | 1 | 0 | 15 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.ReportCollectionPercentage` | 17 | 1 | 0 | 11 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ReportCollectionPercentageChild` | 18 | 1 | 0 | 11 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ReportFormulaField` | 5 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.Scrub` | 11 | 1 | 0 | 0 | 3 | 0 | 0 | pending Phase 0 | |
| `dbo.ScrubAssignment` | 8 | 1 | 0 | 0 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.ScrubCoding` | 8 | 1 | 0 | 0 | 2 | 1 | 0 | pending Phase 0 | |
| `dbo.ScrubConfig` | 4 | 1 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ScrubError` | 10 | 1 | 0 | 0 | 2 | 1 | 0 | pending Phase 0 | |
| `dbo.sysdiagrams` | 5 | 1 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.temp_adjustmentCodes` | 2 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.temp_patient` | 27 | 1 | 0 | 0 | 26 | 0 | 0 | pending Phase 0 | |
| `dbo.Temp_Policy` | 7 | 0 | 0 | 0 | 6 | 0 | 0 | pending Phase 0 | |
| `dbo.tmpPatient` | 111 | 1 | 0 | 0 | 66 | 1 | 1 | pending Phase 0 | |
| `dbo.Voucher` | 23 | 1 | 0 | 1 | 7 | 0 | 0 | pending Phase 0 | |
| `dbo.WriteOffTHCode` | 4 | 1 | 0 | 0 | 0 | 0 | 0 | pending Phase 0 | |
| `dbo.XXXFeeCharge` | 14 | 0 | 0 | 2 | 5 | 0 | 0 | pending Phase 0 | |
| `dbo.XXXFEELocalityCarrierNumber` | 3 | 0 | 0 | 0 | 1 | 0 | 0 | pending Phase 0 | |
| `dbo.XXXXPM_RELATIONSHIPS` | 5 | 0 | 0 | 0 | 2 | 0 | 0 | pending Phase 0 | |
| `dbo.ZipCodeLookup` | 7 | 1 | 0 | 0 | 4 | 0 | 0 | pending Phase 0 | |

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
