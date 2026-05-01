# Stored Procedures Reference — Practizing (Talbot Clinic)

> **Audience:** AI agents and engineers working on either repo of the Practizing medical-billing platform. This document maps every stored procedure in the `PI_ATC_CLINIC` database to its callers in the .NET API and, where traceable, the Angular UI screens that trigger it.
>
> **Sources of truth used to compile this:**
> - C# code in `Practizing-api-TALBOT_CLINIC` (this repo)
> - Angular code in `Practizing-ui-TALBOT_CLINIC`
> - Live SQL Server `PI_ATC_CLINIC` on `10.3.104.52` (138 user SPs as of 2026-04-30)
> - Two DB-driven dispatch tables: `PZ_Report` (reports) and `Scrub` (claim-scrub rules)

---

## 1. Architecture Overview

### 1.1 Repos

| Repo | Path | Stack | Role |
|---|---|---|---|
| Practizing API | `Practizing-api-TALBOT_CLINIC` | .NET / ServiceStack OrmLite + Dapper-style raw SQL | Multi-project solution, one Web API per business area |
| Practizing UI | `Practizing-ui-TALBOT_CLINIC` | Angular (multi-project workspace: `pibilling`, `pipatient`, root admin app) | Calls API endpoints via `ApiHttpInterceptor` that prefixes `environment.apiUrl` |

### 1.2 API service projects

The API solution (`PractiZing.sln`) is split into business-domain services. Each has its own `*.Api.*` (controllers) and `*.BusinessLogic.*` (repositories/services) project:

| Service project | Domain | SPs invoked from this project |
|---|---|---|
| `ChargePaymentService` | Charges, payments, vouchers, claim batches, scrubbing, bank reconciliation, Catalyst exports, Plaid matching, MethaSoft | 14 |
| `DenialManagementService` | Denial queue, denial dashboard, aging metrics | 9 |
| `ReportService` | RDLC report dispatch, patient statements, charge-stat refresh, aging-balance batch statements | 5 |
| `PatientService` | Patient CRUD, data-warehouse refresh per-patient | 2 |
| `ClaimService`, `ERAService`, `MasterService`, `SecurityService`, `HostService` | Claims, ERA processing, master data, auth, host utilities | 0 direct SP calls — these use OrmLite ORM exclusively |

**Common base:** All repos inherit `Common/PractiZing.BusinessLogic.Common/BaseRepository.cs`, which exposes the helper used for most SP calls (see §3).

---

## 2. SP Invocation Patterns in the API

There are **three distinct ways** SPs are invoked. When adding a new caller, match the existing pattern in the surrounding file rather than introducing a fourth.

### 2.1 Pattern A — `BaseRepository.ExecuteStoredProcedureAsync<T>` (most common)

Defined at [Common/PractiZing.BusinessLogic.Common/BaseRepository.cs:132](Common/PractiZing.BusinessLogic.Common/BaseRepository.cs#L132).

```csharp
public async Task<IEnumerable<T1>> ExecuteStoredProcedureAsync<T1>(
    string functionName, params object[] parameters)
{
    // builds:  exec {functionName} {p1},{p2},...
    // runs via ServiceStack OrmLite Connection.QueryAsync<T1>(query)
}
```

**⚠ Security note for any future agent:** This helper builds the SQL by string concatenation (`CreateFunctionParameter` wraps strings in single quotes but does not escape embedded quotes). Inputs from request bodies should be validated upstream, or the helper should be replaced with parameterized `SqlCommand` for any user-supplied values. Today the helper is mostly used with internally-controlled values (counts, IDs) so risk is low, but treat new callers with caution.

**Example call site:** [DenialManagementService/.../DenialQueueRepository.cs:247](DenialManagementService/PractiZing.BusinessLogic.DenialService/Repositories/DenialQueueRepository.cs#L247)

### 2.2 Pattern B — Raw `SqlCommand` with `CommandType.StoredProcedure`

Used when the SP returns a `DataTable` for Excel export, or takes a TVP / DataTable input (e.g. scrubs). The repo opens its own `SqlConnection` from `Connection.ConnectionString`.

**Example call site:** [ChargePaymentService/.../ChargesRepository.cs:2643](ChargePaymentService/PractiZing.BusinessLogic.ChargePaymentService/Repositories/ChargesRepository.cs#L2643)

```csharp
cmd.CommandText = "rpt_Aging_Patient_Detail_By_InsuranceCompany";
cmd.CommandType = CommandType.StoredProcedure;

// Prefer explicit SqlParameter types over AddWithValue.
// AddWithValue infers SqlDbType from the runtime value, which can mis-promote
// (e.g. ASCII strings → nvarchar, causing index scans, or longer-than-needed
// nvarchar(MAX) when the column is nvarchar(50)). For TVPs it works only by
// luck of DataTable inference; new TVP code must set Structured + TypeName.
cmd.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime) { Value = toDate });
cmd.Parameters.Add(new SqlParameter("@InsuranceCompanyId", SqlDbType.Int) { Value = insuranceCompanyId });
```

### 2.3 Pattern C — Inline `EXEC` text via OrmLite

Less common; used in `ReportService` when the SP name + params come from a DB-configured Command string.

**Example call site:** [ReportService/.../ReportRepository.cs:328](ReportService/PractiZing.BusinessLogic.ReportService/Repositories/ReportRepository.cs#L328)

```csharp
cmd.CommandText = "EXEC usp_GetPatientForAutoStatment " + days;
```

### 2.4 DB-driven SP dispatch (no SP name in C# code)

Two tables in the DB act as **dispatch maps** — the C# code does not contain the SP name; it reads the name from a row and runs whatever string it finds:

| Table | Column with SP name | Dispatched by |
|---|---|---|
| `PZ_Report` | `Command` (e.g. `exec rpt_Aging_Summary_By_Insurance {toDate}`) | [ReportRepository.GenerateReportData](ReportService/PractiZing.BusinessLogic.ReportService/Repositories/ReportRepository.cs#L74) — UI hits `POST /api/Report` with a `reportId` |
| `Scrub` | `StoredProcedure` (e.g. `usp_RunScrub81EM`) | [ClaimBatchRepository.RunAutoScrub](ChargePaymentService/PractiZing.BusinessLogic.ChargePaymentService/Repositories/ClaimBatchRepository.cs#L506) — caller passes `spName` from the `Scrub` row |

**Implication:** to discover all SPs that production actually runs, you cannot rely on `grep` over the API repo alone. You must also read `PZ_Report` and `Scrub`. Both are reproduced in §5.

---

## 3. Stored Procedures — Active Catalog

This is the union of: SPs hardcoded in C# + SPs referenced by `PZ_Report` + SPs referenced by `Scrub`. Parameters are taken from `sys.parameters` on the live DB.

### 3.1 Denial Management (`DenialManagementService`)

All called from [DenialQueueRepository.cs](DenialManagementService/PractiZing.BusinessLogic.DenialService/Repositories/DenialQueueRepository.cs) via `ExecuteStoredProcedureAsync` (Pattern A). All parameter-less — they read filter context from session/temp tables internally.

UI entry point: `DenialDashboardComponent` and `DenialManagementComponent` in `projects/pibilling/src/app/denial-dashboard/` and `denial-management/`. They call `GET /api/denialqueue/GetAgingCount` and `GET /api/denialqueue/GetCharges`.

| SP | Caller (file:line — method) | API endpoint | Purpose |
|---|---|---|---|
| `usp_GetDenialManagementAgingCountByRange` | DenialQueueRepository.cs:247 — `GetAgingCount` | `GET api/denialqueue/GetAgingCount` | Aging buckets (0-30, 31-60, 61-90, 91+) for denial dashboard |
| `usp_DenialManagementForCompanyType` | DenialQueueRepository.cs:248 — `GetAgingCount` | `GET api/denialqueue/GetAgingCount` | Top-5 denials by insurance-company-type (Medicare/Medicaid/Commercial/...) |
| `usp_DenialManagementForInsuranceCompany` | DenialQueueRepository.cs:249 — `GetAgingCount` | `GET api/denialqueue/GetAgingCount` | Top-5 denials by individual insurance company |
| `usp_DenialManagementForTotalAdjustment` | DenialQueueRepository.cs:250 — `GetAgingCount` | `GET api/denialqueue/GetAgingCount` | Top-5 denial adjustment-reason aggregates |
| `usp_DenialManagementForClaimDetail` | DenialQueueRepository.cs:251 — `GetAgingCount` | `GET api/denialqueue/GetAgingCount` | Claim-level denial detail (single row) |
| `usp_GetDenialManagementAgingCountByRangeFilter` | DenialQueueRepository.cs:313 — `GetCharges` (filter case 1) | `GET api/denialqueue/GetCharges` | Charges in a selected aging-bucket bar |
| `usp_DenialManagementForTotalAdjustmentCharges` | DenialQueueRepository.cs:324, 336 — `GetCharges` (cases 2,3) | `GET api/denialqueue/GetCharges` | Charges behind a selected adjustment-reason bar |
| `usp_DenialManagementForInsuranceCompanyCharges` | DenialQueueRepository.cs:345 — `GetCharges` (case 4) | `GET api/denialqueue/GetCharges` | Charges behind a selected insurance-company bar |
| `usp_DenialManagementForCompanyTypeCharges` | DenialQueueRepository.cs:354 — `GetCharges` (case 5) | `GET api/denialqueue/GetCharges` | Charges behind a selected company-type bar |

### 3.2 Charge / Payment / Voucher (`ChargePaymentService`)

| SP | Caller (file:line — method) | API endpoint | UI screen | Purpose |
|---|---|---|---|---|
| `rpt_Aging_Patient_Detail_By_InsuranceCompany` (`@ToDate datetime, @InsuranceCompanyId int`) | ChargesRepository.cs:2643 — `GetExcelForReportDataForCatalystAgeingData` | `POST api/Charges/GetExcelForPatientDetailInsuranceAgingReport` | Reports → Aging Patient Detail (Excel) | Excel export of aged patient AR by insurance |
| `USP_ReportDataForCatalystAllCharges` | ChargesRepository.cs:3068 — `GetExcelForReportDataForCatalystAllCharges` | Catalyst export endpoint on `ChargesController` | Catalyst integration job | Bulk charges export for the Catalyst RCM partner |
| `usp_GetActionNotesForCatalyst` | ChargesRepository.cs:3093 — `GetExcelForReportDataForCatalystAllNotes` | Catalyst export endpoint on `ChargesController` | Catalyst integration job | Action-notes feed for Catalyst |
| `usp_GetInsurancewisePaymentReport` (`@FromDate datetime, @ToDate datetime`) | PaymentRepository.cs:963 — `GetInsurancewisePaymentReport` | `POST api/Payment/GetExcelForInsuranceWisePaymentReport` | Reports → Insurance-wise Payments (Excel) | Payment totals grouped by payer for a date range |
| `usp_GetDynmoPaymentsForCatalystRCM` ⚠ **BROKEN — see note below** | DynmoPaymentsRepository.cs:484 — `GetDynmoPaymentsForCatalystRCM` | `DynmoPaymentsController` | Catalyst integration job | Payments feed for the "Dynmo" Catalyst pipeline |
| `usp_UpdatePayerControlNumberToClaims` | ChargeBatchRepository.cs:279 — `UpdateCCNClaims` | `GET api/chargebatch/UpdateCCNClaims` | Admin / batch utility (no obvious UI button) | Backfills payer control numbers across claims |
| `usp_GetAllPracticesVouchers` (`@MonthId int, @YearId int`) | BankReconciliationRepository.cs:284 — `SyncData` | `POST api/bankreconciliation/sync/{monthId}/{yearId}` | Bank Reconciliation page → "Sync" | Pulls vouchers across all practices for a month/year |
| `USP_SyncDepositsWithChasePayments` (`@MonthId int, @YearId int`) | BankReconciliationRepository.cs:373 — `SyncDepositsWithChasePayments` | `POST api/bankreconciliation/SyncDepositsWithChasePayments/{monthId}/{yearId}` | Bank Reconciliation page → "Sync with Chase" | Matches deposit records to Chase bank-feed payments |
| `usp_GetVouchersForPlaidPayments` | VoucherRepository.cs:868 — `GetVouchersForBankMatched` | Voucher endpoints in `VoucherController` | Plaid matching screen | Returns vouchers eligible for Plaid auto-match |
| `usp_UpdatePlaidPayment_Voucher` (`@XmlData nvarchar, @IsMatchedWithBank bit, @Practice varchar`) | VoucherRepository.cs:882 — `UpdatePlaidMatched` | Voucher endpoints in `VoucherController` | Plaid matching screen → "Match" | Persists Plaid match results back to vouchers |
| `usp_GetPaymentWareHouseReportData` (`@FromDate date, @ToDate date`) | PaymentReportDataRepository.cs:58 — `Get` | `GET api/PaymentReportData` | Payment Analytics dashboard | Hits the data-warehouse copy of payments |
| `usp_MethaSoft_CreateAccession` | MethaSoftInvoiceRepository.cs:170 — `CreateAccessionWiseCptCodes` (private) | `MethaSoftInvoiceController` | MethaSoft integration | Creates accession-wise CPT records for the MethaSoft lab |
| `usp_PaymentByAccession` (`@FromDate date, @ToDate date`) | Auto-generated `PaymentByAccessionTableAdapter` (typed-DataSet) **and** dispatched from `PZ_Report` row 31 ("Payment By Accession") | Used inside Excel export + via `POST api/Report` (reportId=31) | Reports → Payment By Accession | Payment posting grouped by accession number |
| `usp_PaymentChargeByPaymentId` | PaymentChargeRepository.cs:540 — **commented out** | — | — | **Dead code** as of this audit; do not depend on it |

### 3.3 Reports (`ReportService`)

| SP | Caller (file:line — method) | API endpoint | UI screen | Purpose |
|---|---|---|---|---|
| `usp_GetPatientForAutoStatment` (`@Days int`) | ReportRepository.cs:328 — `GetPatientsForAutoStatement` | `POST api/Report/GeneratePatientForAutoStatement` | Statements → Generate Auto-Statement | Picks patients eligible for an automated statement run, by N days since last activity |
| `usp_GetPatientAgingBalances_BatchStatement` (`@BatchStatementUId varchar`) | ReportRepository.cs:552 — `usp_GetPatientAgingBalances_BatchStatement` | `GET api/Report/GetPatientAgingBalancesBatchStatement?uid=` | Batch Statement preview | Aging balances for one batch-statement bundle |
| `rpt_PatientChargeStatementXML` (`@PatientId nvarchar, @ToDate datetime, @Message nvarchar`) | Dispatched via `PZ_Report` row (statement RDL) by `ReportRepository.GenerateReportData` | `POST api/Report` (statement reportId) and `GET api/Report/GetPatientStatementXML` | Patient Statement print | XML payload for the patient-statement RDLC |
| `usp_insertorupdatechargestat` | ChargeStatRepository.cs:681 — `RefreshDenialDashboard` (called twice in a loop) | `GET api/chargestat/refreshDenialDashboard` | Denial dashboard refresh button / scheduled refresh | Rebuilds the `ChargeStat` snapshot table that the denial dashboard reads from |
| `rpt_PatientChargeStatement` (`@PatientId, @FromDate, @ToDate, @Message, @IsBulkStatement, @IsAllCharges`) | Dispatched via `PZ_Report` row 27 ("Patient StatementFinal", `ReportTypeId=2`) | `POST api/Report` (reportId=27) | Patient Statement print | Multi-patient statement RDLC data source |

### 3.4 Patient (`PatientService`)

| SP | Caller (file:line — method) | API endpoint | UI screen | Purpose |
|---|---|---|---|---|
| `usp_GetPatientAgingBalances` | PatientRepository.cs:857 — `Get` | Used inside batch-statement generation | Batch Statement screens | Aging balance per patient (no params — full-population scan) |
| `usp_ImportChargesInDataWareHouseTable_PatientWise` (`@PatientId int`) | PatientRepository.cs:878 — `RefreshPatientChargesReport_WareHouse` | `POST api/patient/refreshChargesReportData/{UId}` | Billing Info → "Refresh Charges Report Data" | Replays one patient's charges into the data-warehouse table for reporting |

### 3.5 Reports dispatched dynamically via `PZ_Report.Command` (Pattern 2.4)

These are NOT named in C# — the row in `PZ_Report` is the contract. UI hits `POST /api/Report` with the `reportId`; `ReportRepository.GenerateReportData` substitutes `{paramName}` placeholders into the `Command` and executes it. To add or rename a report, update the `PZ_Report` row, not C# code.

| Report Id | Report Name | UI menu (Reports tab) | Command (SP) |
|---:|---|---|---|
| 1 | Charge Detail By DOS | Reports | `exec rpt_ChargesDOSReport {fromDate},{toDate},{providerID},{FacilityID},{AuxillaryProviderId},{RefferingProviderId}` |
| 3 | Deposit Summary | Reports | `exec rpt_PaymentDepositsReport {fromDate},{toDate},{InsuranceCompanyId}` |
| 4 | Aging By Insurance | Reports | `exec rpt_Aging_Summary_By_Insurance {toDate}` |
| 6 | Aging By Patient | Reports | `exec rpt_Aging_Summary_By_Patient {toDate}` |
| 11 | Aging Patient Detail By Insurance Company | Reports | `exec rpt_Aging_Patient_Detail_By_InsuranceCompany {toDate},{InsuranceCompanyId}` |
| 13 | AR Associated | Reports | `exec rpt_GetAssociatedARReport {fromDate},{toDate}` |
| 17 | CPA By Provider Details | Reports | `exec rpt_CPA_By_Provider_Report {fromDate},{toDate}` |
| 18 | CPA By Provider Revenue Center | Reports | `exec rpt_CPAByRevenueCenterReport {fromDate},{toDate}` |
| 25 | Patient Balance | Reports | `exec rpt_GetPatientBalanceReport {toDate}` |
| 27 | Patient StatementFinal | Statements | `exec rpt_PatientChargeStatement {patientId},{FromDate},{toDate},{Message},{IsBulkStatement},{IsAllCharges}` |
| 31 | Payment By Accession | Reports | `exec usp_PaymentByAccession {fromDate},{toDate}` |
| 35 | CPA By Provider Details By Dos | Reports | `exec rpt_CPA_By_Provider_Report_ByDOSDate_LOOP {fromDate},{toDate},{ProviderID},{AuxillaryProviderId},{RefferingProviderId},{FacilityId}` |
| 37 | CPA By Provider Details Post Date | Reports | `exec rpt_CPA_By_Provider_By_PostDate_Report {fromDate},{toDate},{ProviderID},{AuxillaryProviderId},{RefferingProviderId},{FacilityId}` |
| 39 | CPA by Auxillary Provider Details Post Date | Reports | `exec rpt_CPA_By_AuxillaryProvider_By_PostDate_Report {fromDate},{toDate}` |
| 40 | CPA By Facility Details By Post Date | Reports | `exec rpt_CPA_By_Facility_By_PostDate_Report {fromDate},{toDate},{facilityId}` |
| 41 | Payment Posting | Reports | `exec rpt_PostingPaymentByDate {FromDate},{ToDate},{ProviderId},{FacilityId},{InsuranceCompanyId},{AuxillaryProviderId},{RefferingProviderId}` |
| 42 | CPA By Facility Details By Dos | Reports | `exec rpt_CPA_By_Facility_Report_ByDOSDate_LOOP {fromDate},{toDate},{facilityId}` |
| 43 | Payment Posting By CPT Codes | Reports | `exec rpt_PostingPaymentByCptCodeByPostDate {FromDate},{ToDate},{ProviderId},{FacilityId},{InsuranceCompanyId},{AuxillaryProviderId},{RefferingProviderId}` |

`ReportTypeId` legend: `1 = RDLCReport`, `2 = PatientStatement`. The Angular UI uses `ReportData` (`GET api/ReportData`) to list available reports for the menu, then `POST api/Report` with the reportId and a `ReportOptionModel` containing the parameter values.

### 3.6 Claim scrubs dispatched dynamically via `Scrub.StoredProcedure` (Pattern 2.4)

UI: ClaimBatchComponent → "Run Scrub" button → `POST /api/ClaimBatch/scrub?spName=...&scrubId=...&practiceCode=...`. The endpoint is `[AllowAnonymous]` (see [SECURITY_AND_RISKS.md §6](docs/architecture/SECURITY_AND_RISKS.md)) and reads `spName` from the query string. The UI populates `spName` from a `Scrub` table row; the API does **not** validate it against the `Scrub` table.

**Dispatch reality (current code):** [`ClaimBatchRepository.RunAutoScrub`](ChargePaymentService/PractiZing.BusinessLogic.ChargePaymentService/Repositories/ClaimBatchRepository.cs) **always** executes `spName` as a SQL Server stored procedure with `CommandType.StoredProcedure`. The `Scrub.IsProcedure` and `Scrub.IsAutoScrub` columns shown in earlier drafts of this catalog **are commented out** in the C# entity ([`Scrub.cs:22-25`](ChargePaymentService/PractiZing.DataAccess.ChargePaymentService/Tables/Scrub.cs)) and therefore have no runtime effect. There is no C# validator branch.

All scrub SPs share the same TVP signature: `(@Charges ChargeType /*table-valued*/, @ScrubId int, @PracticeCode nvarchar)`.

| Scrub Id | Name | StoredProcedure | Status |
|---:|---|---|---|
| 1 | Scrub 81 EM Needs Mod 25 | `usp_RunScrub81EM` | OK |
| 2 | Scrub 82 EM needs Mod 24 | `usp_RunScrub82EM` | OK |
| 3 | Scrub 83 EM needs Mod 57 | `usp_RunScrub83EM` | OK |
| 4 | Scrub 84 Surg needs mod 58, 59, 78, 79 | `usp_RunScrub84EM` | OK |
| 5 | Scrub 86 CCI Edits | `usp_RunScrub86EM` | OK |
| 6 | Scrub 124 J Code Without NDC Message Code | `usp_RunScrub124` | OK |
| 7 | CPTToICDValidator | `CPTToICDValidator` | ⚠ **BROKEN** — no SQL Server SP exists with this name; the dispatcher will error if invoked |
| 8 | CPTToModifierValidator | `CPTToModifierValidator` | ⚠ **BROKEN** — same reason |

**Rows 7 and 8 are configured-but-broken.** Earlier framework drafts described them as "C# validators dispatched by name" — that is aspirational, not implemented. If invoked today, `RunAutoScrub` opens a `SqlConnection`, sets `cmd.CommandText = "CPTToICDValidator"`, and executes — SQL Server returns *Could not find stored procedure 'CPTToICDValidator'*. To make these work the team must either (a) create stored procedures with those names, or (b) refactor `RunAutoScrub` to branch to a C# validator dispatcher (a 1-2 day refactor; see the [add-scrub skill](.claude/skills/add-scrub/SKILL.md)).

---

## 4. UI → API → SP Path (cross-repo flow map)

For each major UI feature in `Practizing-ui-TALBOT_CLINIC`, this is the chain that ends at a stored procedure.

### Denial Dashboard
`projects/pibilling/src/app/denial-dashboard/denial-dashboard.component.ts` → `denial-dashboard.service.ts` → `GET api/denialqueue/GetAgingCount` → `DenialQueueController.GetAgingCount` → `DenialQueueRepository.GetAgingCount` → **5 SPs in §3.1** in parallel.

### Denial Management Grid
`projects/pibilling/src/app/denial-management/` → `denial-management.service.ts` → `GET api/denialqueue/GetCharges?filter=...` → `DenialQueueRepository.GetCharges` → 1 of 5 charge SPs (filter switch in §3.1).

### Reports menu (Aging, CPA, Payment Posting, etc.)
`projects/pibilling/src/app/reports/` → `report.service.ts` → `GET api/ReportData` (menu) then `POST api/Report` (run) → `ReportRepository.GenerateReportData` → reads `PZ_Report.Command` → executes the `rpt_*` SP listed in §3.5.

### Patient Statement
Statements UI → `GET api/Report/GetPatientStatement` and `POST api/Report` for statement reportId → `ReportRepository.GeneratePatientStatement` → `rpt_PatientChargeStatement` (multi) or `rpt_PatientChargeStatementXML` (single, XML).

Auto-statement generation: Statements UI → `POST api/Report/GeneratePatientForAutoStatement` → `ReportRepository.GetPatientsForAutoStatement` → `usp_GetPatientForAutoStatment @Days`.

### Bank Reconciliation
`bank-reconciliation.service.ts` → `POST api/bankreconciliation/sync/{m}/{y}` and `.../SyncDepositsWithChasePayments/{m}/{y}` → `usp_GetAllPracticesVouchers` and `USP_SyncDepositsWithChasePayments`.

### Claim Scrub
`charge-payments.service.ts` and ClaimBatch UI → `POST api/ClaimBatch/Scrub?spName=...` → `ClaimBatchRepository.RunAutoScrub` → SP from `Scrub.StoredProcedure` (see §3.6). The "Run Scrub" button on a single batch goes through `POST api/ClaimBatch/runScrub?claimBatchUId=` which triggers all auto-scrub rows in sequence.

### Catalyst RCM exports
No direct UI. Triggered by scheduled jobs / admin endpoints on `ChargesController` and `DynmoPaymentsController` → `USP_ReportDataForCatalystAllCharges`, `usp_GetActionNotesForCatalyst`, `usp_GetDynmoPaymentsForCatalystRCM`.

### MethaSoft / Plaid
MethaSoft: lab integration controller → `usp_MethaSoft_CreateAccession`. Plaid: payment-matching UI → `usp_GetVouchersForPlaidPayments`, `usp_UpdatePlaidPayment_Voucher`.

### Refresh Patient Charges (warehouse)
Billing Info → "Refresh" → `POST api/patient/refreshChargesReportData/{uid}` → `usp_ImportChargesInDataWareHouseTable_PatientWise @PatientId`.

### Charge-stat refresh (denial dashboard data prep)
Admin / scheduled → `GET api/chargestat/refreshDenialDashboard` → `usp_insertorupdatechargestat` (run in a loop over practices).

---

## 5. Inactive / Orphaned SPs in `PI_ATC_CLINIC`

The DB has 138 user SPs; only ~30 are referenced by current code or dispatch tables. The rest fall into these buckets — **do not assume any of them are safe to drop without checking SQL Agent jobs first**, but they are not invoked by the API or UI.

### 5.1 Likely SQL Agent / scheduled jobs (data-warehouse loaders, snapshots)
- `usp_ChargeSnapShotsMonthWise`, `_Consolidated`, `_RUNALL`
- `usp_ImportChargesInDataWareHouseTable`, `usp_ImportChargesInDataWareHouseTable_RefreshPatient`
- `usp_ImportPaymentsInDataWareHouseTable`
- `USP_ImportCatalystAllChargeIntoWareHouseTable`
- `usp_ConsolidateAllDbsChargeData`, `usp_ConsolidateAllDbsPaymentData`
- `usp_InsertDataInCollectionPercentageTable`, `_Child`
- `usp_RunDenialDashboard`
- `usp_VoucherPosting`
- `usp_GetTableForMonthReport`
- `usp_90DaysBalanceFinal`, `usp_GetARAging90DaysData`, `usp_CPAReportYearMonthWise`
- `usp_ReportARChargesMonthWiseNew`

### 5.2 Reporting SPs that exist but are NOT in `PZ_Report` (legacy/superseded)
- `rpt_AdjustmentPatientDetailByDOS`, `rpt_Aging_Summary_By_InsuranceCompanyType`, `rpt_Aging_Summary_By_Revenue_Center`
- `rpt_CCPA_By_Provider_Report`, `rpt_ChargeDetailsByDOSByCategory`, `rpt_ChargeDetailsByPostDate`
- `rpt_CPA_By_Facility_Report_ByDOSDate`, `rpt_CPA_By_Provider_Report_ByDOSDate`, `rpt_CPA_By_Provider_Report_ByDOSDateTest`
- `rpt_CPAByProvider`, `rpt_CPAByRevenueCenter`, `rpt_CPADetailsByDOSByCPT`
- `rpt_CPT_DX_Trending`, `rpt_CPT_DX_Trending_By_Revenue_Center`, `rpt_CPTCodeReimbursementReport`
- `rpt_GetDenialDetails`, `rpt_GetInsuranceBalanceReport`, `rpt_GetPaymentDetails`
- `rpt_InsuranceAgaingPatientReport`, `rpt_InsuranceAgaingReport`
- `rpt_LabActivityByOrderingProviderReport`, `rpt_LabActivityByPayerReport`
- `rpt_PatientAgaingReport`, `rpt_PatientAndInsARStatusReport`, `rpt_PatientAndInsTotalARStatusReport`
- `rpt_PatientChargeStatement_05162024`, `rpt_PatientChargeStatement_Rohit` *(dated/owner-named — clear staging copies)*
- `rpt_PatientDOSCPAODetailReport`, `rpt_PaymentDeposits`, `rpt_PaymentsToDoctors`
- `rpt_pm_PrimaryPaymentsApplied`

### 5.3 Standalone utilities (probably ad-hoc / DBA-run)
- `usp_PatientConsolidation`, `usp_PatientIntegrationWPA`, `usp_PaymentDeposits`
- `usp_AddInsurancePolicyByPatientId`, `usp_dos`, `usp_DOSDetailReport`
- `usp_FindScrubDataForPatientAndCharges`, `usp_GetInnetwork`
- `usp_GetPaymentsToCompany`, `usp_GetPaymentsToDoctors`
- `usp_PostDetail`, `usp_PracticeAnalysisReport`, `usp_WeeklyChargeInfoReport`
- `usp_CollectionPercentageReport`, `usp_ChargesByRevenueReport`, `usp_PaymentByAccession` *(also in PZ_Report)*
- `usp_SaveClaimStatusInquiry`
- `usp_DenialManagementAgingCount*` (multiple `*AfterFilter` variants — not the ones the API actually calls)
- `usp_UpdateChargesforerapaymentforchargesnotfound`, `usp_UpdateDueByWhereBlank`
- `usp_MovePPOChargesToLISAClark`, `usp_ImportExcelData`
- `USP_ReportDataForCatalystAllCharges_Test`, `USP_ReportDataForCatalystByAccession`
- `DeletePaymentsByCheckNumber`

### 5.4 SQL Server system / Database Diagrams (don't touch)
`sp_alterdiagram`, `sp_creatediagram`, `sp_dropdiagram`, `sp_helpdiagramdefinition`, `sp_helpdiagrams`, `sp_renamediagram`, `sp_upgraddiagrams`.

---

## 6. Quick Reference: SP signatures (live DB)

Pulled from `sys.parameters` on `PI_ATC_CLINIC@10.3.104.52` on 2026-04-30. `(none)` means no formal parameters — most "none" SPs read context from temp tables, session-scoped tables, or hard-coded WHERE clauses inside the body.

| SP | Parameters |
|---|---|
| `rpt_Aging_Patient_Detail_By_InsuranceCompany` | `@ToDate datetime, @InsuranceCompanyId int` |
| `rpt_Aging_Summary_By_Insurance` | `@ToDate datetime` |
| `rpt_Aging_Summary_By_Patient` | `@ToDate datetime` |
| `rpt_ChargesDOSReport` | `@FromDate, @ToDate datetime, @ProviderID, @FacilityID, @AuxillaryProviderId, @RefferingProviderId int, @IsExcel int` |
| `rpt_CPA_By_AuxillaryProvider_By_PostDate_Report` | `@FromDate, @ToDate datetime, @ProviderID int` |
| `rpt_CPA_By_Facility_By_PostDate_Report` | `@FromDate, @ToDate datetime, @FacilityId int, @IsExcel bit` |
| `rpt_CPA_By_Facility_Report_ByDOSDate_LOOP` | `@StartDate, @EndDate date, @FacilityId int, @IsExcel bit` |
| `rpt_CPA_By_Provider_By_PostDate_Report` | `@FromDate, @ToDate datetime, @ProviderID, @AuxillaryProviderId, @RefferingProviderId, @FacilityId int, @IsExcel bit` |
| `rpt_CPA_By_Provider_Report` | `@FromDate, @ToDate datetime, @ProviderID int` |
| `rpt_CPA_By_Provider_Report_ByDOSDate_LOOP` | `@StartDate, @EndDate date, @ProviderID, @AuxillaryProviderId, @RefferingProviderId, @FacilityId int` |
| `rpt_CPAByRevenueCenterReport` | `@FromDate, @ToDate datetime, @ProviderID int` |
| `rpt_GetAssociatedARReport` | `@FromDate, @ToDate date` |
| `rpt_GetPatientBalanceReport` | `@ToDate datetime` |
| `rpt_PatientChargeStatement` | `@PatientId nvarchar, @FromDate, @ToDate datetime, @Message nvarchar, @IsBulkStatement varchar, @IsAllCharges int` |
| `rpt_PatientChargeStatementXML` | `@PatientId nvarchar, @ToDate datetime, @Message nvarchar` |
| `rpt_PaymentDepositsReport` | `@FromDate, @ToDate date, @InsuranceCompanyId int, @IsExcel bit` |
| `rpt_PostingPaymentByCptCodeByPostDate` | `@FromDate, @ToDate date, @ProviderId, @FacilityId, @InsuranceCompanyId, @AuxillaryProviderId, @RefferingProviderId int, @IsExcel bit` |
| `rpt_PostingPaymentByDate` | `@FromDate, @ToDate date, @ProviderId, @FacilityId, @InsuranceCompanyId, @AuxillaryProviderId, @RefferingProviderId int, @IsExcel bit` |
| `usp_DenialManagement*` (all 9 active) | `(none)` |
| `usp_GetActionNotesForCatalyst` | `(none)` |
| `usp_GetAllPracticesVouchers` | `@MonthId int, @YearId int` |
| `usp_GetInsurancewisePaymentReport` | `@FromDate, @ToDate datetime` |
| `usp_GetPatientAgingBalances` | `(none)` |
| `usp_GetPatientAgingBalances_BatchStatement` | `@BatchStatementUId varchar` |
| `usp_GetPatientForAutoStatment` | `@Days int` |
| `usp_GetPaymentWareHouseReportData` | `@FromDate, @ToDate date` |
| `usp_GetVouchersForPlaidPayments` | `(none)` |
| `usp_ImportChargesInDataWareHouseTable_PatientWise` | `@PatientId int` |
| `usp_insertorupdatechargestat` | `(none)` |
| `usp_MethaSoft_CreateAccession` | `(none)` |
| `usp_PaymentByAccession` | `@FromDate, @ToDate date` |
| `usp_RunScrub81EM` ... `usp_RunScrub86EM`, `usp_RunScrub124` | `@Charges ChargeType /*TVP*/, @ScrubId int, @PracticeCode nvarchar` |
| `USP_ReportDataForCatalystAllCharges` | `(none)` |
| `USP_SyncDepositsWithChasePayments` | `@MonthId int, @YearId int` |
| `usp_UpdatePayerControlNumberToClaims` | `(none)` |
| `usp_UpdatePlaidPayment_Voucher` | `@XmlData nvarchar, @IsMatchedWithBank bit, @Practice varchar` |

---

## 7. Conventions for Future Changes

1. **Adding a new report** — insert a row into `PZ_Report` with the `Command` string and the parameter placeholders. Do NOT hardcode SP names in `ReportRepository`. UI auto-discovers via `GET api/ReportData`.
2. **Adding a new scrub** — insert a row into `Scrub`. If the rule needs a TVP, set `IsProcedure = 1` and follow the `usp_RunScrub*EM` signature. If it's a C# validator, the row's `StoredProcedure` value is the validator class name.
3. **Adding a hardcoded SP call** — prefer `BaseRepository.ExecuteStoredProcedureAsync<DTO>(name, params)` for `SELECT`-style SPs returning rows. Use raw `SqlCommand` with `CommandType.StoredProcedure` only when you need (a) DataTable output for Excel export, or (b) a TVP / DataTable input.
4. **Renaming or dropping an SP** — search all of: this repo (`grep -r "usp_Name" --include='*.cs'`), the UI repo (rare but check), `PZ_Report.Command`, `Scrub.StoredProcedure`, and SQL Agent jobs on the server.
5. **The `ExecuteStoredProcedureAsync` helper concatenates parameters into the SQL string.** If you call it with any user-supplied string, sanitize first. Better, refactor that path to use `SqlCommand.Parameters` — see [BaseRepository.cs:132-148](Common/PractiZing.BusinessLogic.Common/BaseRepository.cs#L132).
6. **Modify-date hint:** `sys.procedures.modify_date` is the cheapest way to spot recently-touched SPs when debugging a regression. The most-recently-modified SPs as of this audit are `rpt_PatientChargeStatement` (2025-11-11) and `usp_ImportChargesInDataWareHouseTable_PatientWise` (2025-07-16).

---

## 8. Known Broken / Stale References

These dependencies are referenced by the running code but the database object is missing or never existed. Treat them as bugs to triage, not "active SPs."

| Reference | From | Status | Action |
|---|---|---|---|
| `usp_GetDynmoPaymentsForCatalystRCM` | `DynmoPaymentsRepository.cs:484` (active call site) — `cmd.CommandText = "usp_GetDynmoPaymentsForCatalystRCM"` | **Missing from live DB.** Live DB query: only `usp_GetActionNotesForCatalyst`, `USP_ImportCatalystAllChargeIntoWareHouseTable`, `USP_ReportDataForCatalystAllCharges`, `USP_ReportDataForCatalystAllCharges_Test`, `USP_ReportDataForCatalystByAccession` exist. No `Dynmo*` SPs at all. | Calling this endpoint raises a SQL error at runtime. Either (a) restore/create the SP, or (b) remove the C# endpoint if the integration is dead. Confirm with whoever owns the Catalyst Dynmo integration. |
| `CPTToICDValidator` | `Scrub` table row 7 (active) | **Missing from live DB.** Dispatched by `RunAutoScrub` as a SQL Server SP; no such SP exists. | See §3.6. Either implement the SP, refactor the dispatcher to call C# validators, or deactivate the row (`Active = 0`). |
| `CPTToModifierValidator` | `Scrub` table row 8 (active) | **Missing from live DB.** Same situation. | Same options as row 7. |
| `usp_PaymentChargeByPaymentId` | `PaymentChargeRepository.cs:540` (**commented out**) | Missing from live DB. Code-side reference is the only trace. | Remove the commented code in a small cleanup PR; the SP itself is already gone. |

## 9. Open questions / follow-ups

- **Catalyst integration triggering** is not visible in any cron/Hangfire config in the repo. If it runs in production, it is likely fired by an external scheduler hitting the `ChargesController` endpoints. Verify before assuming the Catalyst SPs are dead.
- **30 of 138 SPs** are actively wired up. The remaining **~108** are either SQL-Agent jobs, dead reporting code, or DBA utilities. A separate audit of SQL Agent jobs on `10.3.104.52` would close the loop.
- **The framework's `sp-impact-analyzer` subagent** should be run against every SP before any rename/drop; the [migration plan](docs/database/sql-server-to-postgres-migration-plan.md) Phase 5 catalog leans on this.
