# Database Reference

## Overview

The system uses **two SQL Server databases** per deployment:

1. **`PracticeCentral`** — the lookup database. One per Coolify deployment.
2. **A per-practice DB** (e.g. `PI2_TalbotClinic`) — the operational database for one tenant practice. There can be many of these in production.

The system is **multi-tenant by practice**. A "practice" is the billing
organization (e.g. Talbot Clinic). Each practice has its own operational DB.

## How tenancy works

```
┌──────────────────────────────────────────────────┐
│   PracticeCentral DB                             │
│   ┌──────────────────────────────────────────┐   │
│   │  PracticeCentralPractice                 │   │
│   │  ─────────────────────────────────────   │   │
│   │  Id, PracticeCode, PracticeName,         │   │
│   │  DBConnectionString, IsActive, ...       │   │
│   │                                          │   │
│   │  Row 1: TalbotClinic    → conn-str-1     │   │
│   │  Row 2: SomeOtherPractice → conn-str-2   │   │
│   └──────────────────────────────────────────┘   │
└──────────────────────────────────────────────────┘
                    │
       HostService startup reads every row,
       registers each conn-str under PracticeCode
       in OrmLiteConnectionFactory.
                    │
                    ▼
┌──────────────────┐  ┌──────────────────┐
│ PI2_TalbotClinic │  │ PI2_OtherPractice│
│ (operational DB) │  │ (operational DB) │
│  - Patient       │  │  - Patient       │
│  - Charges       │  │  - Charges       │
│  - Claim         │  │  - Claim         │
│  - ...           │  │  - ...           │
└──────────────────┘  └──────────────────┘
```

At request time, the JWT carries the user's PracticeCode. Repository code
calls `dbFactory.OpenAsync(practiceCode)` to open a connection to the
right tenant DB.

For local dev with one practice, both DBs can be on the same SQL Server
instance.

## Configuration

`appsettings.json` for HostService (and other services that need it):

```json
{
  "ConnectionStrings": {
    "DefaultConnection":            "Server=...;Database=PI2_TalbotClinic;...",
    "PracticeCentralDBContext":     "Server=...;Database=PracticeCentral;..."
  }
}
```

In Coolify env vars (the form ASP.NET Core reads):

- `ConnectionStrings__DefaultConnection`
- `ConnectionStrings__PracticeCentralDBContext`

## Schema layout

There is **no migration tooling** (no EF Core migrations, no Flyway, no
Liquibase). Schema is in two SQL files at the repo root:

- `AppSetting.sql` — the per-practice DB schema (Patient, Charges, Claim, etc.)
- `ConfigSetting.sql` — schema for the master config tables (CPTCode, ICDCode, providers, facilities, settings)

These files are run **manually** against fresh databases. Any schema
change in production requires:

1. Edit the relevant `.sql` file
2. Generate a manual diff against your environments
3. Apply the diff outside the deploy pipeline
4. Then deploy code that depends on the new schema

> 🟡 This is a real operational risk. A code-and-DB-out-of-sync deploy is
> painful. Consider introducing migrations as a follow-up modernization.

## Tables — per service

Every Api service has a matching DataAccess project with `Tables/` POCOs.
Each `.cs` file maps to one SQL table via ServiceStack OrmLite's
`[Alias("dbo.TableName")]` attribute.

### ChargePaymentService (operational, ~50 tables)

The biggest cluster. Lives in `ChargePaymentService/PractiZing.DataAccess.ChargePaymentService/Tables/`.

| Table | Purpose |
|---|---|
| `Charges` | The atomic billable line item — one CPT code per charge |
| `Invoice` | Grouping of charges for billing |
| `Claim` | An 837 EDI claim sent to a payer |
| `ClaimBatch` | Batch of claims sent together |
| `ClaimCharge` | Link table: claim ↔ charge |
| `ClaimTotal` | Calculated totals per claim |
| `ClaimStatusInquiry` / `ClaimStatusInquiryChild` | 276 inquiry tracking |
| `Claim824Status` | 824 rejection responses from clearinghouse |
| `Voucher` | Source of payment (one check or EFT) |
| `Payment` | Application of a voucher's money to charges |
| `PaymentBatch` | Workflow grouping for payment posting |
| `PaymentCharge` | Link: payment ↔ charge with amounts |
| `PaymentAdjustment` / `PaymentAdjustmentNotes` | Non-payment reductions |
| `PaymentRemarkCode` | Per-payment remark codes |
| `HistoryPayment` | DynamoDB-backed payment history (separate from SQL) |
| `BankReconciliation` | Matching deposits to vouchers |
| `ChasePayments` / `ChasePaymentChild` | Unmatched / hard-to-reconcile payments |
| `ChargeBatch` | Batch grouping for charge posting workflows |
| `ChargesReportData` / `ChargesReportDataConsolidate` | Cached/denormalized data for AR aging reports |
| `ChargeScrub` / `ScrubError` | Pre-submission validation results |
| `ChargeInWriteOff` | Charges moved to write-off |
| `WriteOffTHCode` | Write-off threshold/category codes |
| `ChargeStatementCount` | Track how many statements have been sent for a charge |
| `FeeSchedule` / `FSCharge` / `FSDiscount` / `FSLocalityCarrier` | Contracted rates and discounts |
| `CPTModifier` | CPT modifiers used in charging |
| `DrugCharge` | Drug-specific charge metadata |
| `InvDiagnosis` | Diagnosis codes attached to invoices |
| `ConfigHCFAFormField` | Per-payer HCFA-1500 box overrides |
| `ConfigMessageCode` | Message codes used in claim narratives |
| `MethaSoftInvoice` | Methadone-specific invoicing (specialized billing path) |
| `PortalPayment` / `PlaidPayment` | Patient self-payment via portal / Plaid |

### PatientService (operational, ~16 tables)

`PatientService/PractiZing.DataAccess.PatientService/Tables/`.

| Table | Purpose |
|---|---|
| `Patient` | Demographics, MRN, billing ID |
| `PatientCase` | Episode of care; insurance assignment |
| `InsurancePolicy` | Insurance coverage attached to a patient |
| `InsurancePolicyHolder` | The policy holder if not the patient |
| `InsuranceGuarantor` | Financially responsible party |
| `InsuancePolicyException` | (typo: "Insuance") Insurance policy exceptions/overrides |
| `PatientAlert` | Display alerts when a patient is opened in the UI |
| `PatientNote` | Free-text notes on the patient |
| `PatientAuthorizationNumber` | Pre-auth tracking |
| `PatientStatement` | Statements sent to this patient |
| `BatchStatement` | Bulk-statement tracking |
| `CallHistory` | Calls made/received about a patient |
| `DailyQueue` | Today's worklist |
| `HL7Status` | Status of inbound HL7 messages |
| `EDIEligibilityLog` | 270/271 eligibility check log |
| `LabVendorInsuranceCodes` | Lab-vendor-specific insurance code mappings |
| `ClaimBillType` | Bill type codes (institutional billing) |

### MasterService (reference / configuration, ~70 tables)

`MasterService/PractiZing.DataAccess.MasterService/Tables/`.

These are the lookup tables — CPT codes, ICD-10, providers, facilities,
and a *lot* of `Config*` tables for various dropdown values.

| Group | Examples |
|---|---|
| Codes | `CPTCode`, `MasterCPTCode`, `MasterICD10`, `ICDCode`, `NDC`, `CPTCategory` |
| Providers / Facilities | `Provider`, `ProviderIdentity`, `Facility`, `FacilityIdentity` |
| Insurance | `InsuranceCompany`, `ClearingHouse` |
| Adjustments / Remarks | `AdjustmentReasonCode`, `ConfigAdjustmentReasonCode`, `ConfigERARemarkCodes`, `ARSCategoryReasonCode` |
| Place / Type / Position codes | `ConfigPOS`, `ConfigTOS`, `ConfigBillType`, `ConfigCaseType`, `ConfigPosition`, `ConfigSupervisionType` |
| Patient demographics codes | `ConfigMaritalStatus`, `ConfigPatientRace`, `ConfigRelationship` |
| Workflow / system | `ConfigSetting`, `ConfigSettingGroup`, `ConfigSystemCD`, `MonthEndClose`, `AppSetting` |
| Misc | `BillingUnitConversionChart`, `ZipCodeLookUp`, `RemarkCodeSolution`, `LabSalesRep` |

### SecurityService (auth, ~11 tables)

`SecurityService/PractiZing.DataAccess.SecurityService/Tables/`.

| Table | Purpose |
|---|---|
| `User` | The user account record |
| `Role` | Named roles (e.g. "Biller", "Admin") |
| `UserRole` | Link: user ↔ role |
| `PZModule` | Application modules ("Charges", "Claims", "Reports", ...) |
| `RoleModule` | Per-role module access |
| `UserPermission` | User-specific permission overrides |
| `UserPermissionConfig` | Configuration for permission types |
| `ModulePermission` | Permission types per module |
| `LoggedInUser` | Tracking who's currently logged in (also cached in memory at HostService startup) |
| `UserAuthentication` | Login attempts / session records |
| `PracticeCentralPractice` | **Lives in PracticeCentral DB**, not the per-practice DB |

### DenialManagementService (~5 tables)

| Table | Purpose |
|---|---|
| `ARGroup` / `ARGroupReasonCode` | Reporting buckets for accounts receivable |
| `ActionCategory` / `ActionNote` | Free-text notes with categorization for denial follow-up |
| `DenialQueue` | The worklist for billing reps |

### ERAService (~5 tables)

| Table | Purpose |
|---|---|
| `ERARoot` | Top-level 835 record (one per file) |
| `ERAClaim` | Per-claim entries within an ERA |
| `ERAClaimChargePayment` | Per-charge payment from an ERA |
| `ERAClaimChargeAdjustment` | Per-charge adjustment from an ERA |
| `ERAClaimChargeRemark` | Per-charge remark codes from an ERA |

### ReportService (~7 tables)

| Table | Purpose |
|---|---|
| `Report` | Report definitions (template SQL with `{token}` placeholders for parameters) |
| `ReportFormulaField` | Calculated fields used in reports |
| `ReportARChargesMonthWise` | Cached AR aging report data |
| `CPAReportMonthYearWise` / `CPAReportMonthYearWiseChild` | CPA-specific reporting |
| `ChargeBalanceAR90` | Cached 90-day AR balance |
| `ChargeStat` | Cached charge statistics |

> **The `Report.Command` column contains template SQL with `{token}`
> placeholders that's substituted at runtime by `ParseParameter.ParseReport`.**
> 🔴 This is the SQL injection sink described in `TROUBLESHOOTING.md`.

## Inter-database references

Most code paths only touch the per-practice DB. A few things touch
PracticeCentral:

- HostService at startup (read all practices)
- Login flow (resolve user → practice)
- Some cross-practice reporting (rare)

There are NO foreign keys across the two databases. Code does the join
in C#.

## Connection management

`Common/PractiZing.DataAccess.Common/DataBaseContext.cs` is the central
type. Repositories receive an injected `DataBaseContext` and access the
underlying `IDbConnection` via `this.Connection` on `ModuleBaseRepository<T>`.

The actual factory registration happens in HostService:

```csharp
var sqlPracticeCentralDbFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);
sqlPracticeCentralDbFactory.RegisterConnection("PracticeCentral", connectionString, SqlServerDialect.Provider);
foreach (var practice in _practices) {
    sqlPracticeCentralDbFactory.RegisterConnection(practice.PracticeCode, practice.DBConnectionString, SqlServerDialect.Provider);
}
```

So you can `OpenDbConnection()` (default tenant) or `OpenDbConnection("PracticeCode")` (specific tenant or `PracticeCentral`).

## Where queries actually run

Code uses **three** DB-access styles in the same repo. When you're tracing
a query, look for one of these patterns:

1. **ServiceStack OrmLite** — most common:
   ```csharp
   var charges = await db.SelectAsync<Charges>(c => c.PatientUId == patientId);
   ```
2. **Dapper** (via `ServiceStack.OrmLite.Dapper`):
   ```csharp
   var rows = await db.QueryAsync<ChargeRow>("SELECT ... WHERE Id = @id", new { id });
   ```
3. **Raw `SqlCommand`** for stored procs and dynamic SQL:
   ```csharp
   var cmd = new SqlCommand { CommandText = "rpt_Aging_Patient_Detail_By_InsuranceCompany", CommandType = CommandType.StoredProcedure, ... };
   ```

## Performance / index notes

There's no schema-level documentation of indexes (they're in `AppSetting.sql`
as part of `CREATE TABLE` statements). When investigating slow queries,
check the generated SQL via SQL Server Profiler / Extended Events.

Hot reports (`GetExcelForPatientDetailInsuranceAging`, etc.) hit cached
denormalized tables (`ChargesReportData`, `ChargesReportDataConsolidate`)
populated by jobs not described in this codebase. If those caches are
stale, reports look stale even if operational data is fresh.

## Backup / disaster recovery

See [`DEPLOYMENT.md`](DEPLOYMENT.md) "Backup / restore". The DBs are the
only stateful assets.
