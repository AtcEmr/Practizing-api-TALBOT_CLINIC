# PatientService

**Folder**: `PatientService/`
**Container name in compose**: `practizing-patient`

## Purpose

Owns patient-side data: demographics, cases, insurance policies,
authorization tracking, alerts, statements, the daily worklist, HL7
ingestion status.

This is the second-largest service after ChargePayment.

## Key controllers

16 controllers. Functional groupings:

| Controller | What |
|---|---|
| `PatientController` | Patient demographics CRUD |
| `PatientCaseController` | Episode of care; insurance assignment |
| `InsurancePolicyController` | Policies attached to a patient |
| `insurancePolicyHolderController` (note casing) | Policy holders if not the patient |
| `InsuranceGuarantorController` | Financially responsible party |
| `PatientAlertController` | Alerts that pop up on patient open |
| `PatientNoteController` | Free-text notes |
| `PatientAuthorizationNumberController` | Pre-auth tracking |
| `PatientStatementController` | Per-patient statement records |
| `BatchStatementController` | Bulk statement runs |
| `CallHistoryController` | Inbound/outbound call tracking |
| `DailyQueueController` | Today's worklist |
| `DashBoardQuickController` | Cards on the patient-dashboard top |
| `DataIntegrationController` | EMR/lab integration entry points |
| `HL7StatusController` | Status of inbound HL7 messages |
| `PatientStateController` | US state lookup (probably should be in Master 🟢) |

## Key tables

| Table | Purpose |
|---|---|
| `Patient` | Demographics |
| `PatientCase` | Episode + insurance assignment |
| `InsurancePolicy`, `InsurancePolicyHolder`, `InsuranceGuarantor` | Coverage data |
| `InsuancePolicyException` (typo: "Insuance") | Per-policy overrides |
| `PatientAlert`, `PatientNote` | Free-text + alerts |
| `PatientAuthorizationNumber` | Pre-auth |
| `PatientStatement`, `BatchStatement` | Statement workflow |
| `CallHistory`, `DailyQueue` | Workflow tables |
| `HL7Status` | HL7 ingest tracking |
| `EDIEligibilityLog` | 270/271 eligibility check log |
| `LabVendorInsuranceCodes` | Lab-vendor → insurance code mappings |
| `ClaimBillType` | Bill-type lookup (institutional billing) |

## Dependencies

`PatientService.BusinessLogic` references:

- `Common/*`
- `MasterService/PractiZing.DataAccess.MasterService` (insurance company lookups, ZIP validation, etc.)
- `ChargePaymentService/PractiZing.DataAccess.ChargePaymentService` (claims/payments visible on patient page)

## Notable repositories

- `PatientRepository` — the dashboard query, search, demographics CRUD
- `PatientCaseRepository` — case workflow, primary/secondary insurance shuffling
- `InsurancePolicyRepository` — policy CRUD + duplicate detection
- `BatchStatementRepository` — bulk statement generation
- `DashboardQuickStartService` (in `Services/`, not `Repositories/`) — orchestrates dashboard cards. **Note: this file's first line `using Amazon.DynamoDBv2;` suggests it touches DynamoDB too — verify before changing.**

## Known gotchas

- 🟢 `insurancePolicyHolderController` filename starts lowercase — match the existing casing.
- 🟢 `Insuance` typo in `InsuancePolicyException` — load-bearing in references.
- 🟢 `PatientStateController` is in PatientService but conceptually a master-data lookup. Don't move it without checking who calls it.
- 🟡 Patient demographic write paths don't have audit logging — every change overwrites silently. PHI compliance review may flag this.
- 🟡 `BatchStatement` runs are synchronous — large batches can timeout the request. Move to background jobs if scale matters.
