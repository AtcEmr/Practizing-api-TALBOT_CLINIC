# PostgreSQL Stored-Procedure Conversion Worksheet

Parallel to [postgres-schema-conversion.md](./postgres-schema-conversion.md) — that one tracks the 275 tables; this one tracks the 138 stored procedures (131 user-authored + 7 built-in `sp_*diagram*` excluded). Each row is a per-procedure migration tracker. Update as Phase 5 classification closes and Phase 6 retirement progresses.

Source artifacts:
- Live DB metadata: `sys.procedures`, `sys.parameters`, body indicators captured 2026-04-30 from `PI_ATC_CLINIC` on `10.3.104.52`.
- Dispatch tables: `PZ_Report` (active + inactive), `Scrub`.
- C# call-site map: [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md).
- Migration plan: [sql-server-to-postgres-migration-plan.md](./sql-server-to-postgres-migration-plan.md).

## Status legend

| Status | Meaning |
|---|---|
| `pending Phase 0` | Cannot pick a final disposition until Phase 0 decisions land. |
| `classified` | Phase 5 caller analysis done; disposition recorded. |
| `replacement implemented` | Disposition target exists in code/PG; not yet validated. |
| `dual-run validated` | Outputs match SQL Server within agreed tolerance. |
| `cutover` | New path live; SP scheduled for drop. |
| `dropped` | SP removed from PG schema; row kept here for audit trail. |
| `BROKEN` | SP referenced but missing/non-functional in current SQL Server. Triage as a bug, not a migration item. |

## Disposition legend

| Disposition | What it means |
|---|---|
| **Retire to C#** | Logic moves into application service / query handler. The SP is dropped after dual-run. Default for read paths called from C#. |
| **Port to PG function** | Stays in DB as a PG function (parameterized SELECT or set-returning function) — the migration plan's "temporary bridge" pattern. Default for large multi-join reports during the pilot window. |
| **Move to scheduled job** | ETL/snapshot work that should be a Hangfire/cron job calling repositories, not a DB-side procedure. |
| **Move to integration service** | Catalyst/Plaid/MethaSoft/Chase calls that span DB + external partner; belong in a dedicated service. |
| **Drop** | Orphaned, dated/owner-named copy, test variant, or one-time cleanup with no live callers. |

## Phase 0 gates

Until these decisions are APPROVED in the [migration plan's Review Iteration Log](./sql-server-to-postgres-migration-plan.md), no SP-side disposition can be locked in:

| Decision | DDL/SP impact | Tracked in |
|---|---|---|
| Runtime target (.NET 10 LTS) | Determines OrmLite + Npgsql versions; affects whether retired SPs can use modern C# patterns. | postgres-schema-conversion §Phase 0 D1 |
| Multi-tenant model (schema-per-practice) | Determines whether ported SPs become PG functions per schema or shared. | postgres-schema-conversion §Phase 0 D2 |
| Naming strategy | Determines casing for any ported PG functions; affects rename/refactor cost. | postgres-schema-conversion §Phase 0 D3 |
| Audit-history strategy (D7) | Determines how many of the 221 triggers retire alongside their related SPs. | postgres-schema-conversion §Phase 0 D7 |
| **SP-specific: anonymous scrub endpoint hardening** | `[AllowAnonymous]` + caller-supplied `spName` on `POST /api/ClaimBatch/scrub` must be fixed before scrub-SP retirement starts. | [SECURITY_AND_RISKS.md §6](../architecture/SECURITY_AND_RISKS.md) |

## Summary by category

| Category | Count |
|---|---:|
| Report | 18 |
| Report (inactive) | 16 |
| ETL / Warehouse / Snapshot | 16 |
| Report (orphan) | 12 |
| Other (orphan?) | 11 |
| Denial Management (orphan) | 11 |
| Denial Management | 9 |
| Scrub | 6 |
| Cleanup utility | 4 |
| Statement | 3 |
| Patient Utility | 3 |
| Catalyst Integration (orphan) | 3 |
| Statement (legacy) | 2 |
| Catalyst Integration | 2 |
| Bank Reconciliation | 2 |
| Other (C# direct) | 2 |
| Patient Warehouse Refresh | 2 |
| Plaid Integration | 2 |
| Legacy / test variant | 1 |
| Scrub Utility (orphan) | 1 |
| Patient Aging | 1 |
| ChargeStat | 1 |
| MethaSoft Integration | 1 |
| Claim Utility | 1 |
| ERA Utility | 1 |
| **Total (live SPs)** | **131** |
| BROKEN references (live in code, missing in DB) | 3 |

## Risk-signal legend

Compact tags in the per-SP table below:

- `NOLOCK` — uses `WITH (NOLOCK)` hints. Strip on PG (MVCC handles it).
- `TEMP` — uses `#temp` tables or `SELECT INTO #...`. PG temp tables differ; review per-SP.
- `DYNSQL` — uses `EXEC()` or `sp_executesql`. SQL injection surface; review carefully.
- `IDENT` — uses `SCOPE_IDENTITY()` or `@@IDENTITY`. PG uses `RETURNING`.
- `MERGE` — uses `MERGE`. PG `INSERT ... ON CONFLICT` is the usual replacement.
- `TVP` — accepts a table-valued parameter (`READONLY`). No PG equivalent; use JSONB or temp tables.
- `WRITE` — issues `INSERT`/`UPDATE`/`DELETE`. Side-effecting; needs golden-master tests, not just output diff.
- `TRY` — has `TRY...CATCH`. PG uses `EXCEPTION` blocks; behavior differs.

## Per-SP worksheet

| SP | Modified | Lines | Category | Active dispatch | Risks | Recommended disposition | Status |
|---|---|---:|---|---|---|---|---|
| `DeletePaymentsByCheckNumber` | 2019-09-20 | 40 | Cleanup utility | — | WRITE | Drop or move to one-time SQL script during cutover. | pending Phase 0 |
| `rpt_AdjustmentPatientDetailByDOS` | 2019-08-21 | 33 | Report (inactive) | PZ_Report id=12 | — | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_Aging_Patient_Detail_By_InsuranceCompany` | 2021-05-19 | 286 | Report | PZ_Report id=11 + C# `ChargesRepository.GetExcelForReportDataForCatalystAgeingData` | NOLOCK WRITE | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_Aging_Summary_By_Insurance` | 2021-05-19 | 281 | Report | PZ_Report id=4 | NOLOCK WRITE | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_Aging_Summary_By_InsuranceCompanyType` | 2019-08-07 | 248 | Report (inactive) | PZ_Report id=5 | NOLOCK WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_Aging_Summary_By_Patient` | 2021-05-19 | 216 | Report | PZ_Report id=6 | NOLOCK WRITE | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_Aging_Summary_By_Revenue_Center` | 2019-08-07 | 209 | Report (orphan) | — | NOLOCK WRITE | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_CCPA_By_Provider_Report` | 2021-02-12 | 250 | Report (inactive) | PZ_Report id=36 | NOLOCK | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_ChargeDetailsByDOSByCategory` | 2019-08-07 | 27 | Report (inactive) | PZ_Report id=14 | — | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_ChargeDetailsByPostDate` | 2019-08-07 | 47 | Report (inactive) | PZ_Report id=15 | — | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_ChargesDOSReport` | 2022-10-26 | 97 | Report | PZ_Report id=1 | NOLOCK | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `rpt_CPA_By_AuxillaryProvider_By_PostDate_Report` | 2021-07-08 | 110 | Report | PZ_Report id=39 | NOLOCK | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_CPA_By_Facility_By_PostDate_Report` | 2021-08-12 | 133 | Report | PZ_Report id=40 | NOLOCK WRITE | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_CPA_By_Facility_Report_ByDOSDate` | 2021-07-13 | 14 | Report (orphan) | — | NOLOCK | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_CPA_By_Facility_Report_ByDOSDate_LOOP` | 2021-08-27 | 74 | Report | PZ_Report id=42 | WRITE | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `rpt_CPA_By_Provider_By_PostDate_Report` | 2021-08-18 | 126 | Report | PZ_Report id=37 | NOLOCK | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_CPA_By_Provider_Report` | 2020-09-11 | 111 | Report | PZ_Report id=17 | NOLOCK | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_CPA_By_Provider_Report_ByDOSDate` | 2022-02-25 | 120 | Report (orphan) | — | NOLOCK | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_CPA_By_Provider_Report_ByDOSDate_LOOP` | 2021-08-27 | 65 | Report | PZ_Report id=35 | WRITE | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `rpt_CPA_By_Provider_Report_ByDOSDateTest` | 2020-03-30 | 106 | Legacy / test variant | — | NOLOCK | Drop — superseded copy. | pending Phase 0 |
| `rpt_CPAByProvider` | 2019-08-28 | 108 | Report (inactive) | PZ_Report id=2 | NOLOCK WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_CPAByRevenueCenter` | 2019-08-07 | 101 | Report (orphan) | — | WRITE | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_CPAByRevenueCenterReport` | 2019-08-07 | 92 | Report | PZ_Report id=18 | NOLOCK WRITE | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `rpt_CPADetailsByDOSByCPT` | 2019-08-21 | 86 | Report (inactive) | PZ_Report id=19 | NOLOCK WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_CPT_DX_Trending` | 2019-08-07 | 32 | Report (orphan) | — | NOLOCK | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_CPT_DX_Trending_By_Revenue_Center` | 2019-08-07 | 30 | Report (orphan) | — | NOLOCK | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_CPTCodeReimbursementReport` | 2019-08-22 | 59 | Report (inactive) | PZ_Report id=20 | WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_GetAssociatedARReport` | 2019-08-21 | 159 | Report | PZ_Report id=13 | NOLOCK WRITE | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_GetDenialDetails` | 2019-08-21 | 25 | Report (inactive) | PZ_Report id=21 | NOLOCK WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_GetInsuranceBalanceReport` | 2019-08-07 | 117 | Report (inactive) | PZ_Report id=22 | NOLOCK WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_GetPatientBalanceReport` | 2022-10-20 | 139 | Report | PZ_Report id=25 | NOLOCK WRITE | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_GetPaymentDetails` | 2019-08-21 | 12 | Report (inactive) | PZ_Report id=30 | WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_InsuranceAgaingPatientReport` | 2022-03-28 | 101 | Report (orphan) | — | NOLOCK WRITE | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_InsuranceAgaingReport` | 2021-05-19 | 94 | Report (orphan) | — | NOLOCK WRITE | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_LabActivityByOrderingProviderReport` | 2019-08-07 | 154 | Report (inactive) | PZ_Report id=23 | NOLOCK | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_LabActivityByPayerReport` | 2019-08-07 | 147 | Report (inactive) | PZ_Report id=24 | NOLOCK | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_PatientAgaingReport` | 2022-10-20 | 49 | Report (orphan) | — | NOLOCK WRITE | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_PatientAndInsARStatusReport` | 2019-08-07 | 189 | Report (inactive) | PZ_Report id=29 | NOLOCK WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_PatientAndInsTotalARStatusReport` | 2019-08-07 | 182 | Report (orphan) | — | NOLOCK WRITE | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_PatientChargeStatement` | 2025-11-11 | 265 | Report | PZ_Report id=27 | NOLOCK WRITE | Port temporarily as PG function during pilot; retire to C# query handler in v1.1. | pending Phase 0 |
| `rpt_PatientChargeStatement_05162024` | 2024-05-16 | 221 | Statement (legacy) | — | NOLOCK WRITE | Drop — dated/owner-named copy of `rpt_PatientChargeStatement`. | pending Phase 0 |
| `rpt_PatientChargeStatement_Rohit` | 2025-11-10 | 264 | Statement (legacy) | — | NOLOCK WRITE | Drop — dated/owner-named copy of `rpt_PatientChargeStatement`. | pending Phase 0 |
| `rpt_PatientChargeStatementXML` | 2021-08-05 | 235 | Statement | C# `ReportRepository (statement XML)` | NOLOCK WRITE | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `rpt_PatientDOSCPAODetailReport` | 2019-08-21 | 77 | Report (inactive) | PZ_Report id=26 | NOLOCK WRITE | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_PaymentDeposits` | 2019-08-07 | 40 | Report (orphan) | — | — | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_PaymentDepositsReport` | 2022-05-25 | 17 | Report | PZ_Report id=3 | NOLOCK | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `rpt_PaymentsToDoctors` | 2019-08-28 | 26 | Report (orphan) | — | — | Drop unless DBA confirms SQL Agent or external caller. | pending Phase 0 |
| `rpt_pm_PrimaryPaymentsApplied` | 2019-08-07 | 22 | Report (inactive) | PZ_Report id=16 | — | Drop unless product confirms it is needed; if needed, follow active-report path. | pending Phase 0 |
| `rpt_PostingPaymentByCptCodeByPostDate` | 2021-08-17 | 49 | Report | PZ_Report id=43 | NOLOCK WRITE | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `rpt_PostingPaymentByDate` | 2022-09-02 | 80 | Report | PZ_Report id=41 | NOLOCK | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `usp_90DaysBalanceFinal` | 2023-01-04 | 149 | ETL / Warehouse / Snapshot | — | WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_AddInsurancePolicyByPatientId` | 2021-05-10 | 23 | Patient Utility | — | IDENT WRITE | Verify caller with sp-impact-analyzer before deciding. Likely retire to application service or drop. | pending Phase 0 |
| `usp_ChargesByRevenueReport` | 2019-08-07 | 403 | Other (orphan?) | — | NOLOCK WRITE | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_ChargeSnapShotsMonthWise` | 2022-10-04 | 121 | ETL / Warehouse / Snapshot | — | NOLOCK IDENT WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_ChargeSnapShotsMonthWise_Consolidated` | 2022-09-21 | 57 | ETL / Warehouse / Snapshot | — | NOLOCK IDENT WRITE TRY | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_ChargeSnapShotsMonthWise_RUNALL` | 2022-09-02 | 8 | ETL / Warehouse / Snapshot | — | — | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_CollectionPercentageReport` | 2019-08-07 | 79 | ETL / Warehouse / Snapshot | — | NOLOCK WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_ConsolidateAllDbsChargeData` | 2025-07-15 | 73 | ETL / Warehouse / Snapshot | — | WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_ConsolidateAllDbsPaymentData` | 2023-12-15 | 29 | ETL / Warehouse / Snapshot | — | NOLOCK WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_CPAReportYearMonthWise` | 2023-01-04 | 168 | ETL / Warehouse / Snapshot | — | NOLOCK IDENT WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_DenialManagementAgingCount` | 2019-08-07 | 80 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementAgingCountAfterFilter` | 2019-08-07 | 85 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementAgingCountCharges` | 2019-08-07 | 85 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementAgingCountForCompanyType` | 2019-08-07 | 68 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementAgingCountForCompanyTypeAfterFilter` | 2019-08-07 | 70 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementAgingCountForDenailAdjustment` | 2019-08-07 | 55 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementAgingCountForDenailAdjustmentAfterFilter` | 2019-08-07 | 61 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementAgingCountForInsuranceCompany` | 2019-08-07 | 57 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementAgingCountForInsuranceCompanyAfterFilter` | 2019-08-07 | 57 | Denial Management (orphan) | — | NOLOCK | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_DenialManagementForClaimDetail` | 2019-08-07 | 48 | Denial Management | C# `DenialQueueRepository.GetAgingCount` | NOLOCK | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_DenialManagementForCompanyType` | 2019-08-07 | 53 | Denial Management | C# `DenialQueueRepository.GetAgingCount` | NOLOCK | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_DenialManagementForCompanyTypeCharges` | 2019-08-07 | 56 | Denial Management | C# `DenialQueueRepository.GetCharges` | NOLOCK | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_DenialManagementForInsuranceCompany` | 2019-08-07 | 49 | Denial Management | C# `DenialQueueRepository.GetAgingCount` | NOLOCK | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_DenialManagementForInsuranceCompanyCharges` | 2019-08-07 | 50 | Denial Management | C# `DenialQueueRepository.GetCharges` | NOLOCK | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_DenialManagementForTotalAdjustment` | 2019-08-07 | 53 | Denial Management | C# `DenialQueueRepository.GetAgingCount` | NOLOCK | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_DenialManagementForTotalAdjustmentCharges` | 2019-08-07 | 42 | Denial Management | C# `DenialQueueRepository.GetCharges` | NOLOCK | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_dos` | 2019-08-07 | 153 | Other (orphan?) | — | NOLOCK TEMP WRITE | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_DOSDetailReport` | 2019-08-07 | 79 | Other (orphan?) | — | NOLOCK WRITE | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_FindScrubDataForPatientAndCharges` | 2019-08-07 | 82 | Scrub Utility (orphan) | — | TEMP | Drop unless caller found. | pending Phase 0 |
| `usp_GetActionNotesForCatalyst` | 2022-12-16 | 18 | Catalyst Integration | C# `ChargesRepository.GetExcelForReportDataForCatalystAllNotes` | NOLOCK | Retire to integration service. Coordinate with Catalyst owner. | pending Phase 0 |
| `usp_GetAllPracticesVouchers` | 2024-09-09 | 132 | Bank Reconciliation | C# `BankReconciliationRepository.SyncData` | NOLOCK WRITE | Retire to application service. | pending Phase 0 |
| `usp_GetARAging90DaysData` | 2023-01-02 | 31 | Other (orphan?) | — | — | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_GetDenialManagementAgingCountByRange` | 2019-08-07 | 51 | Denial Management | C# `DenialQueueRepository.GetAgingCount` | WRITE | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_GetDenialManagementAgingCountByRangeAfterFilter` | 2019-08-07 | 53 | Denial Management (orphan) | — | WRITE | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_GetDenialManagementAgingCountByRangeFilter` | 2019-08-07 | 53 | Denial Management | C# `DenialQueueRepository.GetCharges` | WRITE | Retire to C# query handler. Index/materialized view supports performance. | pending Phase 0 |
| `usp_GetInnetwork` | 2019-08-07 | 24 | Other (orphan?) | — | — | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_GetInsurancewisePaymentReport` | 2022-05-05 | 28 | Other (C# direct) | C# `PaymentRepository.GetInsurancewisePaymentReport` | NOLOCK | Retire to application service or query handler. | pending Phase 0 |
| `usp_GetPatientAgingBalances` | 2024-10-17 | 96 | Patient Aging | C# `PatientRepository.Get` | NOLOCK WRITE | Retire to C# query handler. | pending Phase 0 |
| `usp_GetPatientAgingBalances_BatchStatement` | 2021-05-21 | 84 | Statement | C# `ReportRepository.usp_GetPatientAgingBalances_BatchStatement` | NOLOCK WRITE | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `usp_GetPatientForAutoStatment` | 2021-07-13 | 50 | Statement | C# `ReportRepository.GetPatientsForAutoStatement` | NOLOCK WRITE | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `usp_GetPaymentsToCompany` | 2019-08-14 | 5 | Other (orphan?) | — | — | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_GetPaymentsToDoctors` | 2019-08-14 | 5 | Other (orphan?) | — | — | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_GetPaymentWareHouseReportData` | 2022-05-13 | 13 | Patient Warehouse Refresh | C# `PaymentReportDataRepository.Get` | NOLOCK | Retire to background job; trigger from a service rather than from a request. | pending Phase 0 |
| `usp_GetTableForMonthReport` | 2023-01-06 | 77 | ETL / Warehouse / Snapshot | — | WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_GetVouchersForPlaidPayments` | 2022-05-26 | 7 | Plaid Integration | C# `VoucherRepository.GetVouchersForBankMatched` | NOLOCK | Retire to integration service. Coordinate with Plaid owner. | pending Phase 0 |
| `USP_ImportCatalystAllChargeIntoWareHouseTable` | 2023-04-28 | 228 | Catalyst Integration (orphan) | — | NOLOCK WRITE | Drop unless integration owner confirms usage; flag in §"Open Questions". | pending Phase 0 |
| `usp_ImportChargesInDataWareHouseTable` | 2025-11-06 | 422 | ETL / Warehouse / Snapshot | — | NOLOCK WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_ImportChargesInDataWareHouseTable_PatientWise` | 2025-07-16 | 402 | Patient Warehouse Refresh | C# `PatientRepository.RefreshPatientChargesReport_WareHouse` | NOLOCK WRITE TRY | Retire to background job; trigger from a service rather than from a request. | pending Phase 0 |
| `usp_ImportChargesInDataWareHouseTable_RefreshPatient` | 2024-10-15 | 362 | ETL / Warehouse / Snapshot | — | NOLOCK WRITE TRY | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_ImportExcelData` | 2023-02-28 | 114 | Cleanup utility | — | NOLOCK IDENT WRITE | Drop or move to one-time SQL script during cutover. | pending Phase 0 |
| `usp_ImportPaymentsInDataWareHouseTable` | 2024-10-09 | 66 | ETL / Warehouse / Snapshot | — | NOLOCK WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_InsertDataInCollectionPercentageTable` | 2022-11-29 | 49 | ETL / Warehouse / Snapshot | — | NOLOCK WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_InsertDataInCollectionPercentageTableChild` | 2022-11-29 | 46 | ETL / Warehouse / Snapshot | — | NOLOCK WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_insertorupdatechargestat` | 2024-11-01 | 103 | ChargeStat | C# `ChargeStatRepository.RefreshDenialDashboard` | NOLOCK MERGE WRITE | Retire to scheduled background job in application service. | pending Phase 0 |
| `usp_MethaSoft_CreateAccession` | 2024-05-01 | 47 | MethaSoft Integration | C# `MethaSoftInvoiceRepository.CreateAccessionWiseCptCodes` | MERGE WRITE | Retire to integration service. Coordinate with MethaSoft owner. | pending Phase 0 |
| `usp_MovePPOChargesToLISAClark` | 2024-01-17 | 59 | Cleanup utility | — | WRITE | Drop or move to one-time SQL script during cutover. | pending Phase 0 |
| `usp_PatientConsolidation` | 2025-11-04 | 42 | Patient Utility | — | WRITE | Verify caller with sp-impact-analyzer before deciding. Likely retire to application service or drop. | pending Phase 0 |
| `usp_PatientIntegrationWPA` | 2021-05-10 | 95 | Patient Utility | — | NOLOCK IDENT WRITE | Verify caller with sp-impact-analyzer before deciding. Likely retire to application service or drop. | pending Phase 0 |
| `usp_PaymentByAccession` | 2019-11-13 | 52 | Report | PZ_Report id=31 + C# `PaymentByAccessionTableAdapter (typed DataSet)` | NOLOCK WRITE | Retire to C# query handler with parameterized query. | pending Phase 0 |
| `usp_PaymentDeposits` | 2019-08-07 | 39 | Other (orphan?) | — | — | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_PostDetail` | 2019-08-28 | 153 | Other (orphan?) | — | NOLOCK TEMP WRITE | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_PracticeAnalysisReport` | 2019-08-07 | 36 | Other (orphan?) | — | NOLOCK | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |
| `usp_ReportARChargesMonthWiseNew` | 2023-08-30 | 95 | ETL / Warehouse / Snapshot | — | IDENT WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `USP_ReportDataForCatalystAllCharges` | 2023-04-28 | 243 | Catalyst Integration | C# `ChargesRepository.GetExcelForReportDataForCatalystAllCharges` | NOLOCK WRITE | Retire to integration service. Coordinate with Catalyst owner. | pending Phase 0 |
| `USP_ReportDataForCatalystAllCharges_Test` | 2022-12-21 | 183 | Catalyst Integration (orphan) | — | NOLOCK WRITE | Drop unless integration owner confirms usage; flag in §"Open Questions". | pending Phase 0 |
| `USP_ReportDataForCatalystByAccession` | 2022-02-14 | 30 | Catalyst Integration (orphan) | — | NOLOCK | Drop unless integration owner confirms usage; flag in §"Open Questions". | pending Phase 0 |
| `usp_RunDenialDashboard` | 2019-12-06 | 12 | Denial Management (orphan) | — | WRITE | Variant not called from current C#; drop unless DBA confirms SQL Agent usage. | pending Phase 0 |
| `usp_RunScrub124` | 2019-08-07 | 43 | Scrub | Scrub id=6 active | TVP | Retire to C# `IScrubRule`. Source-of-truth gold tests required before cutover. | pending Phase 0 |
| `usp_RunScrub81EM` | 2019-08-07 | 228 | Scrub | Scrub id=1 active | TVP | Retire to C# `IScrubRule`. Source-of-truth gold tests required before cutover. | pending Phase 0 |
| `usp_RunScrub82EM` | 2019-08-07 | 61 | Scrub | Scrub id=2 active | TVP | Retire to C# `IScrubRule`. Source-of-truth gold tests required before cutover. | pending Phase 0 |
| `usp_RunScrub83EM` | 2019-08-07 | 61 | Scrub | Scrub id=3 active | TVP | Retire to C# `IScrubRule`. Source-of-truth gold tests required before cutover. | pending Phase 0 |
| `usp_RunScrub84EM` | 2019-08-07 | 75 | Scrub | Scrub id=4 active | TVP | Retire to C# `IScrubRule`. Source-of-truth gold tests required before cutover. | pending Phase 0 |
| `usp_RunScrub86EM` | 2019-08-07 | 71 | Scrub | Scrub id=5 active | TVP | Retire to C# `IScrubRule`. Source-of-truth gold tests required before cutover. | pending Phase 0 |
| `usp_SaveClaimStatusInquiry` | 2023-10-25 | 16 | Claim Utility | — | IDENT WRITE | Verify caller; retire to application service if active. | pending Phase 0 |
| `USP_SyncDepositsWithChasePayments` | 2023-12-20 | 14 | Bank Reconciliation | C# `BankReconciliationRepository.SyncDepositsWithChasePayments` | NOLOCK WRITE | Retire to application service. | pending Phase 0 |
| `usp_UpdateChargesforerapaymentforchargesnotfound` | 2021-08-24 | 49 | ERA Utility | — | WRITE | Retire to ERAService once verified caller. | pending Phase 0 |
| `usp_UpdateDueByWhereBlank` | 2024-04-24 | 6 | Cleanup utility | — | WRITE | Drop or move to one-time SQL script during cutover. | pending Phase 0 |
| `usp_UpdatePayerControlNumberToClaims` | 2025-01-22 | 40 | Other (C# direct) | C# `ChargeBatchRepository.UpdateCCNClaims` | NOLOCK TEMP WRITE TRY | Retire to application service or query handler. | pending Phase 0 |
| `usp_UpdatePlaidPayment_Voucher` | 2022-05-26 | 56 | Plaid Integration | C# `VoucherRepository.UpdatePlaidMatched` | WRITE TRY | Retire to integration service. Coordinate with Plaid owner. | pending Phase 0 |
| `usp_VoucherPosting` | 2023-02-28 | 37 | ETL / Warehouse / Snapshot | — | NOLOCK WRITE | Move to scheduled job (Hangfire/cron). Verify SQL Agent usage during Phase 5; drop if no callers. | pending Phase 0 |
| `usp_WeeklyChargeInfoReport` | 2019-08-07 | 56 | Other (orphan?) | — | WRITE | Run sp-impact-analyzer in Phase 5 before deciding. | pending Phase 0 |

## Broken / phantom references (triage as bugs)

These names are referenced by code or by configuration tables, but the SP is missing from the live DB. Resolve before treating as migration items.

| Reference | Source | Issue | Action |
|---|---|---|---|
| `usp_GetDynmoPaymentsForCatalystRCM` | C# `DynmoPaymentsRepository.cs:484` | Active call site; SP not present in `sys.procedures`. Calling it raises a SQL error at runtime. | Restore the SP, remove the C# code path, or reroute to the Catalyst owner. (Migration plan §"Open technical questions" #1.) |
| `CPTToICDValidator` | `Scrub` row id=7 (`Active=1`) | `RunAutoScrub` always executes the value as a SQL Server SP; no SP exists with this name. | Either implement the SP, refactor the dispatcher to call C# validators, or set `Active=0` on the row. |
| `CPTToModifierValidator` | `Scrub` row id=8 (`Active=1`) | Same situation. | Same options. |

Resolution path: each row gets fixed once and never enters the migration backlog. Track in [STORED_PROCEDURES.md §8](../../STORED_PROCEDURES.md).

## Validation gate (Phase 6 → Phase 9)

This worksheet is "DONE" only when all of the following are true:

- [ ] Every row's `Status` is `cutover` or `dropped`.
- [ ] No `BROKEN` rows remain.
- [ ] All 6 active scrub SPs have C# `IScrubRule` replacements with golden-master tests passing.
- [ ] All Catalyst/Plaid/MethaSoft/Chase integration SPs have application-service replacements with the partner-owner sign-off.
- [ ] Every active report SP has either (a) been retired into a C# query handler, or (b) been ported as a PG function under [postgres/functions/](./postgres/) with parity tests.
- [ ] Anonymous `POST /api/ClaimBatch/scrub` endpoint is hardened (no `AllowAnonymous`; `scrubId` lookup instead of `spName`).
- [ ] `usp_GetDynmoPaymentsForCatalystRCM` resolved (restored, removed, or migrated).
- [ ] Two broken `Scrub` rows (rows 7, 8) resolved.
- [ ] No new SP added during the migration window without the `[migration-debt]` tag in [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md).

## Agent rules

- Do not change a row's `Status` to `replacement implemented` without a referenced commit hash that introduces the C# replacement or PG function.
- Do not change a row's `Status` to `dual-run validated` without a parity-test run logged under `postgres/validation/`.
- Do not drop an SP from the DB until its row reads `cutover` for at least one full month-end close on the pilot tenant.
- Do not "port" a scrub SP into PL/pgSQL as the long-term plan; scrubs retire to C# `IScrubRule`. PG functions are only acceptable as temporary bridges.
- Do not re-categorize a row from `Drop` to `Retire to C#` without confirming the SP is actually used (SP-impact-analyzer subagent + DBA review).
- When this worksheet conflicts with [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md), STORED_PROCEDURES.md is the source of truth for current callers; this file is the source of truth for migration disposition.
