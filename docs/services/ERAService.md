# ERAService

**Folder**: `ERAService/`
**Container name in compose**: `practizing-era`

## Purpose

Parses incoming **835 (Electronic Remittance Advice)** files and stores
them as queryable rows. An 835 is what a payer sends to tell the practice
"here's what we paid, here's what we adjusted, here's the reason for any
denials." Once parsed, the data flows into payment posting (via
ChargePaymentService) and denial workflow (via DenialManagementService).

This service is small. Two controllers, five data tables.

## Note about folder typo

The BusinessLogic folder is **`PractiZing.BussinessLogic.ERAService`**
(double 's' in "Bussiness"). Load-bearing in references — don't fix the
spelling without a sweeping refactor.

## Key controllers

| Controller | What |
|---|---|
| `ERARootController` | Top-level 835 file metadata (one record per file imported). CRUD + reprocess. |
| `ERAClaimController` | Per-claim entries within an ERA, with their per-charge breakdown |

## Key tables

| Table | Purpose |
|---|---|
| `ERARoot` | One row per 835 file ingested. Has source, payer, date, total payment amount. |
| `ERAClaim` | One row per claim within an ERA. Has the payer's reference, what was paid for the whole claim. |
| `ERAClaimChargePayment` | Per-charge payment within a claim |
| `ERAClaimChargeAdjustment` | Per-charge adjustment within a claim |
| `ERAClaimChargeRemark` | Per-charge remark codes (denial reasons, etc.) |

## How an 835 is processed

1. File arrives (typically via SFTP from clearinghouse, or manual upload via UI)
2. Parsed by `EdiFabric` (`lib/EdiFabric.Framework/`) — converts X12 segments into objects
3. Stored as the four-table hierarchy above
4. Eventually triggers payment posting in ChargePaymentService

The actual import job that runs `EdiFabric` lives in the `BusinessLogic`
layer and is triggered either via the controller or scheduled (the
scheduler is not in this repo — it's external).

## Dependencies

- `Common/*`
- `EDIFabric/EdiFabric.Templates.Hipaa` (project ref)
- `EDIFabric/PractiZing.EdiFrabric.Custom` (project ref; another "Frabric" typo — intentional folder name)
- `lib/EdiFabric.Framework/` DLLs
- `ChargePaymentService.DataAccess` (to write payment records)

## Notable repository patterns

- `ERARootRepository.ImportFile(stream)` — top-level ingest
- `ERAClaimRepository.MatchToClaim` — matches a 835 claim to a 837 we sent

## Known gotchas

- 🟢 `BussinessLogic` typo in folder name; don't fix.
- 🟡 If a payer sends a 835 referring to a claim we don't have on record, the matching fails silently (or with a generic exception). Consider a 'parked' table for unmatched claim-level entries.
- 🟡 No deduplication of 835 imports — re-importing the same file would create duplicate rows. Add `(payerId, traceNumber, paymentDate)` uniqueness.
- 🟢 `Startup.cs` for ERAService is the most barebones of any service (just `AddMvc`); doesn't even register `AddCommonService`. If you run ERAService standalone, it likely doesn't have working DI for repositories. Always run via HostService.
