# ChargePaymentService

**Folder**: `ChargePaymentService/`
**Container name in compose**: `practizing-chargepayment`
**Other modules in this folder**:
- `PractiZing.Api.ChargePaymentService/`
- `PractiZing.BusinessLogic.ChargePaymentService/` (3,600+ line `ChargesRepository`)
- `PractiZing.DataAccess.ChargePaymentService/` (~50 tables, multiple typed datasets)

## Purpose

The biggest service. Owns the entire charge-to-payment lifecycle:

- Charge entry, validation (scrub), and posting
- Invoice grouping
- Claim generation (837 EDI via `ClaimService.ClaimCreator.Prof`)
- Claim batch submission
- Voucher / payment posting
- ERA payment application
- Fee schedules and contracted rates
- Bank reconciliation
- Plaid- and Stripe-backed patient self-payment
- Catalyst SFTP export
- AR aging and reporting (cached denormalized data)

If something is "billing-related," it likely lives here.

## Key controllers

35 controllers — the most of any service. Loose grouping:

### Charge / invoice management

| Controller | Endpoints |
|---|---|
| `ChargesController` | Get, Update, Delete charges. The 414-line workhorse. Includes `/CPTDesc` (HL7 enrichment), `/getStatements`, `/downloadInvoices`, AI-related `/getforai`, `/updatefromai`. |
| `ChargeBatchController` | Create/list charge batches |
| `ChargeScrubController` | Pre-submission validation results |
| `InvoiceController` | Invoice CRUD |
| `InvDiagnosisController` | Diagnoses attached to invoices |
| `DrugChargeController` | Drug-specific charges (NDC, units, etc.) |
| `MethaSoftInvoiceController` | Methadone-specific invoicing path |
| `ChargesReportDataController` | AR-aging cached data |
| `WriteOffTHCodeController` | Write-off threshold codes |
| `CPTModifierController` | CPT modifier CRUD |

### Claim management

| Controller | Endpoints |
|---|---|
| `ClaimController` | Claim CRUD; trigger 837 generation |
| `ClaimBatchController` | Batch submission to clearinghouses |
| `ClaimViewController` | Read-only claim views (denormalized for UI) |
| `ClaimTotalController` | Calculated claim totals |
| `ClaimStatusInquiryController` | 276 inquiries |
| `ScrubErrorController` | Per-error scrub log |
| `ConfigHCFAFormFieldController` | Per-payer 1500-form box overrides |
| `ConfigMessageCodeController` | Narrative message codes |

### Payment / voucher

| Controller | Endpoints |
|---|---|
| `PaymentController` | Payment CRUD |
| `PaymentBatchController` | Payment posting batches |
| `PaymentChargeController` | Per-charge payment application |
| `PaymentAdjustmentController` | Adjustment entry |
| `PaymentAdjustmentNotesController` | Notes attached to adjustments |
| `PaymentRemarkCodeController` | Remark codes |
| `PaymentReportDataController` | Cached payment-report data |
| `VoucherController` | Voucher CRUD |
| `BankReconciliationController` | Bank-to-voucher reconciliation |
| `ChasePaymentsController` / `ChasePaymentChildController` | Unmatched payment workflow |
| `HistoryPaymentController` | DynamoDB-backed payment history (🔴 broken AWS keys, see TROUBLESHOOTING) |
| `PortalPaymentController` | Patient portal payments |
| `PlaidPaymentController` | Plaid bank-account payments |

### Fee schedule

| Controller | Endpoints |
|---|---|
| `FeeScheduleController` | Fee schedule CRUD |
| `FSChargeController` | Per-CPT fees |
| `FSDiscountController` | Per-discount fees |
| `FSLocalityCarrierController` | Locality + carrier rates |

## Key tables

See [`../DATABASE.md`](../DATABASE.md) for the full list. The hot ones:

- `Charges` (atomic billable line)
- `Invoice` (grouping)
- `Claim` (the 837)
- `Voucher`, `Payment`, `PaymentCharge`, `PaymentAdjustment`
- `FeeSchedule`, `FSCharge`, `FSDiscount`, `FSLocalityCarrier`

## Notable repository methods

- `ChargesRepository.GetAll(filter)` — the dashboard query
- `ChargesRepository.GetExcelForPatientDetailInsuranceAging` — uses raw `SqlCommand` to call a stored proc
- `ChargesRepository.GetExcelForPostingPayments` — uses `ParseParameter.ParseReport` (🔴 SQL injection sink)
- `ChargesRepository.UploadExcelForReportDataForCatalystAllChargesToSFTP` — invokes the SFTP helper to push CSV to Catalyst
- `ChargesRepository.UpdateFromAI` — accepts updated charge data from an AI process; no documented input validation
- `ClaimRepository.GenerateClaimFile` — calls into `ClaimService.ClaimCreator.Prof` to build 837P
- `ClaimFileProcessService.ClaimFileProcessService.ProcessClaimFile` — top-level orchestration of claim generation
- `HistoryPaymentRepository` — uses AWS DynamoDB; constructor 🔴 has hardcoded AWS keys with `"Test"` suffix

## Dependencies

`ChargePaymentService.BusinessLogic` references:

- `Base/PractiZing.Base`
- `Common/PractiZing.BusinessLogic.Common` (and others)
- `ClaimService/PractiZing.ClaimCreator.Base`
- `ClaimService/PractiZing.ClaimCreator.Form`
- `ClaimService/PractiZing.ClaimCreator.Prof` (🔴 was broken HintPath until coolify-branch fix)
- `ERAService/PractiZing.DataAccess.ERAService`
- `MasterService/PractiZing.BusinessLogic.MasterService` (and DataAccess)
- `PatientService/PractiZing.DataAccess.PatientService`
- `Common/PractiZing.Sftp`
- NuGet: `RestSharp 106.10.1`, `PdfSharpCore 1.1.21`, `System.Data.DataSetExtensions`, `MimeKit` (transitively via Common)

External integrations:
- AWS DynamoDB (HistoryPayment)
- Plaid (PlaidPayment)
- Stripe (Base/)
- Catalyst SFTP

## Known gotchas

- 🔴 `HistoryPaymentRepository` has hardcoded AWS keys (with `"Test"` appended); endpoints will fail.
- 🔴 `ParseParameter.ParseReport` is the SQL injection sink — don't add new callers.
- 🟡 `ChargesRepository` is 3,614 lines with 17 dependencies. New cross-cutting code should go in `Services/` (the underused folder), not the repository.
- 🟡 Exception handling in controllers is copy-paste boilerplate; new controllers should follow it for now (consistency), but a global exception filter is the right long-term answer.
- 🟡 `[AllowAnonymous]` appears (commented at `ChargesController:70`, active at `ClaimBatchController:92`); audit each on prod review.
- 🟢 `Connected Services/TrizettoReference/` is excluded from build (`<Compile Remove="...">`); dead code.
- 🟢 `*.bak` files (`ClaimFileProcessService.cs.bak`, `.csproj.bak`) are committed — leftover scratch.
