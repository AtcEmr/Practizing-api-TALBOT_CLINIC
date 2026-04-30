# Domain Glossary

These terms recur across the codebase and the UI. They're not always
intuitive even if you've worked in healthcare billing — and several
("Charge", "Invoice", "Claim") look like they overlap when they don't.

Read this once before reading the per-service docs.

---

## Patient & encounter terms

**Patient**: the person receiving care. Has demographics, addresses, identifiers (MRN, billing ID). Stored in `PatientService.Patient` table.

**PatientCase** (or just "Case"): a billing-relevant grouping of an episode of care for a patient — e.g. "the broken-arm case" vs. "the routine physical case". Each case has its own diagnosis, insurance assignment, primary/secondary/tertiary insurance order. Stored in `PatientService.PatientCase` table. A patient can have many cases over time.

**Accession Number / Billing ID / Patient Account Number**: depending on the table, these all refer to the same external system's reference for a charge or specimen. The lab / EMR generates them; the billing system tags everything with them so reconciliation is possible. Naming inconsistency is *real* in this codebase.

**Provider**: the doctor / practitioner billing for the service. Has NPI, specialties, identities (per-payer billing IDs).

**Facility**: the location where the service was rendered (clinic, hospital, lab). Has its own NPI/identifiers.

**Practice**: the billing tenant (the parent organization). The system is multi-tenant by practice — each practice has its own database. The `PracticeCentral` DB lists every practice and its connection string.

---

## Money / billing terms

**Charge**: the line-item billed for a single CPT code on a specific date for a specific patient/case. The atomic unit. Has `Amount`, `CPTCode`, `Modifiers`, `DOS` (date of service), `Provider`, `Facility`. Stored in `ChargePaymentService.Charges` table.

**Invoice**: a grouping of charges sent together for billing. One claim usually = one invoice. Has totals (`totalCharges`, `totalPaid`, `totalAdjustment`, `totalDue`). Stored in `ChargePaymentService.Invoice`. **Don't confuse with paper invoices to patients — those are "Statements".**

**Claim**: an X12 837 EDI message sent to an insurance company asking them to pay for one or more charges. A claim references invoice(s) → charges. Once sent, has a `claimId`, `sentDate`, eventually a status. Stored in `ChargePaymentService.Claim` table. **The 837 generation is in `ClaimService/PractiZing.ClaimCreator.Prof/` (837P, professional) and `ClaimCreator.Form/` (837I, institutional).**

**Statement**: a bill sent to the patient (PDF or paper) for amounts they owe. Distinct from a Claim (sent to insurance) and an Invoice (internal grouping). Stored in `PatientService.BatchStatement` and `PatientService.PatientStatement`.

**Voucher**: a record of payment received — typically corresponds to one check (paper) or one ACH/EFT (electronic) from an insurance company. Has check number, amount, deposit date. Stored in `ChargePaymentService.Voucher` table. A voucher links to one or many `Payments`.

**Payment**: the application of money to charges. Where the voucher is the *source*, the payment is the *application*. Stored in `ChargePaymentService.Payment` table. **`PaymentBatch` groups payments for posting workflows.**

**PaymentCharge**: the link table between a payment and the charges it pays. Records how the payment dollar was distributed.

**Adjustment**: a non-payment reduction of a charge — write-offs, contractual adjustments (the difference between billed and allowed), bad debt. Stored alongside payments because workflow-wise they're entered at the same time. `PaymentAdjustment` and `PaymentAdjustmentNotes` tables.

**WriteOff** vs **Adjustment**: a write-off is one *kind* of adjustment (the practice gives up trying to collect). The difference matters for AR aging reports. `WriteOffTHCode` is the table of write-off threshold codes used to classify them.

---

## EDI / claim-cycle terms

**837**: the X12 standard for submitting a claim. There are two flavors:
- **837P**: Professional (most ambulatory care, this is what `ClaimCreator.Prof` builds)
- **837I**: Institutional (hospital inpatient, what `ClaimCreator.Form` builds)

**835**: the X12 standard for receiving payment from a payer (Electronic Remittance Advice / ERA). The `ERAService` parses these. An ERA contains the payment voucher AND the per-charge breakdown of what was paid, what was adjusted, and reason codes for any denials.

**276/277**: claim status inquiry/response. `ClaimStatusInquiry` table tracks 276 we send; 277 responses come back with status.

**824**: application advice (rejection at the EDI clearinghouse level, before the payer ever sees it). `Claim824Status` table.

**HCFA / CMS-1500**: the paper claim form. The ChargePaymentService can generate filled-in 1500 PDFs (used when EDI submission isn't an option). `ConfigHCFAFormField` table maps CPT/payer settings to specific boxes on the form.

**HL7**: a different healthcare standard, used here for inbound integration with EMR/lab systems. Some endpoints (`/api/Charges/CPTDesc`) accept HL7-derived data to enrich charges.

**Clearinghouse**: a third-party that receives 837s from us and forwards them to the right payer (Trizetto, Change Healthcare, etc.). `ClearingHouse` table in MasterService.

---

## Codes & lookups

**CPT Code**: Current Procedural Terminology — what was done. `CPTCode` in MasterService. Five-digit numeric or 5-char alphanumeric.

**ICD-10**: International Classification of Diseases — diagnosis codes. `MasterICD10` in MasterService. Alphanumeric.

**Modifier**: two-character suffix attached to a CPT code that further describes the service (e.g. modifier 25 = "significant separately identifiable E/M service"). `CPTModifier` table.

**NDC**: National Drug Code — for billed drugs. `NDC` table.

**POS**: Place of Service code — where the service was rendered (11 = office, 21 = inpatient hospital, etc.). `ConfigPOS` table.

**TOS**: Type of Service. `ConfigTOS` table.

**Adjustment Reason Code**: from the X12 standard, codes like `CO-45` (contractual obligation, charge exceeds fee schedule). `AdjustmentReasonCode` and `ConfigAdjustmentReasonCode` tables.

**Remark Code**: more detailed explanation that accompanies an adjustment. `PaymentRemarkCode`, `ConfigERARemarkCodes` tables.

**Denial Category**: a practice-defined grouping of denials (e.g. "Coordination of Benefits", "Authorization Required"). `DenialCategory` table.

---

## Workflow terms

**Scrub**: pre-submission validation of a claim against payer-specific rules. Catches errors before submission so they can be fixed without bouncing through the clearinghouse. `ChargeScrub`, `ScrubError` tables.

**Fee Schedule**: the contracted rates between a practice and a payer for each CPT code. `FeeSchedule`, `FSCharge`, `FSDiscount`, `FSLocalityCarrier` tables.

**Action Note**: a free-text note added to a charge/claim by a billing rep, with a category and follow-up date. The denial-management workflow lives here. `ActionNote`, `ActionCategory` tables.

**Denial Queue**: the worklist of denied claims grouped for a billing rep. `DenialQueue` table.

**AR Group / AR Aging**: accounts receivable. AR groups are reporting buckets (e.g. by payer, by age). `ARGroup`, `ARGroupReasonCode` tables.

**Take-back / Recoupment**: when a payer reverses a previously-paid amount. UI has a `take-back-payments` module.

**Chase Payment**: a payment that was posted but couldn't be fully reconciled — money from a payer that doesn't match any expected payment. `ChasePayments`, `ChasePaymentChild` tables.

**Bank Reconciliation**: matching deposits in the practice's bank account to recorded vouchers. `BankReconciliation` table.

**Bulk Statement**: generating patient statements en masse (monthly/weekly). UI has a `bulk-statement` module.

**Bulk Adjustment**: applying the same adjustment to many charges (e.g. write off all charges over 90 days for payer X). UI has a `bulk-adjustment` module.

**Month-End Close**: locking the previous month's data so reports are stable. `MonthEndClose` table in MasterService. Once closed, you can't retroactively post charges/payments to that month.

---

## System / infrastructure terms (project-specific)

**HostService**: the API aggregator. Issues JWTs, loads practice connection strings at startup, hosts every other service's controllers via project references.

**PracticeCentral DB**: the lookup database. Contains the `PracticeCentralPractice` table — every tenant practice and its DB connection string. HostService reads this on boot.

**`DBConnectionString` per practice**: each row in `PracticeCentralPractice` has its own connection string. Repository code resolves the right DB per request based on the user's practice (carried in the JWT).

**`pi-lib`**: the Angular library project in the UI workspace. Despite the name, it's mostly a "shared base classes" dump (67 empty `BaseXxx extends DD` classes), not a true reusable library. See UI `docs/ARCHITECTURE.md`.

**`piworkspace`**: the default Angular project (the root shell). Contains auth, header, navigation, and statically imports `pibilling` and `pipatient`.

**EdiFabric**: the third-party library used for parsing/building EDI X12. Its source is under `EDIFabric/` and prebuilt DLLs under `lib/EdiFabric.Framework/`.

**Catalyst**: a third-party reporting/analytics service. The `ExportExcelToCatalyst` endpoint in ChargesController pushes charge data via SFTP to Catalyst's intake.

**Plaid**: bank-account connector. `PlaidPaymentRepository` integrates Plaid for collecting patient payments.

**ag-grid**: the data-grid library used pervasively in the UI. Three different majors are installed simultaneously (🟡 see UI architecture docs).

---

## Acronyms

| Acronym | Expansion |
|---|---|
| AR | Accounts Receivable |
| CAQH | Council for Affordable Quality Healthcare (provider credentialing) |
| CMS | Centers for Medicare & Medicaid Services |
| CPT | Current Procedural Terminology |
| DOB | Date of Birth |
| DOS | Date of Service |
| EDI | Electronic Data Interchange (the umbrella for 837/835 etc.) |
| EFT | Electronic Funds Transfer |
| EMR | Electronic Medical Record |
| ERA | Electronic Remittance Advice (835) |
| HCFA | Health Care Financing Administration (the old name for CMS; "HCFA form" = the CMS-1500 paper claim form) |
| HCPCS | Healthcare Common Procedure Coding System (superset of CPT) |
| HL7 | Health Level Seven (clinical messaging standard) |
| ICD | International Classification of Diseases |
| MRN | Medical Record Number |
| NDC | National Drug Code |
| NPI | National Provider Identifier |
| PHI | Protected Health Information |
| PI | Practice Insight (the product name; appears as `PractiZing` namespace prefix) |
| POS | Place of Service |
| TOS | Type of Service |
