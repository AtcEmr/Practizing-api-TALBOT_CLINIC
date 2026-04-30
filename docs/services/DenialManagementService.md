# DenialManagementService

**Folder**: `DenialManagementService/`
**Container name in compose**: `practizing-denial`

## Purpose

The denial-followup workflow. When a payer denies a claim or part of a
claim, billers need to investigate, fix the underlying issue, and
re-submit (or write off). This service provides the queue, the action
notes (free-text + categorization with follow-up dates), and the AR
grouping logic.

## Key controllers

5 controllers; small but central:

| Controller | What |
|---|---|
| `DenialQueueController` | The biller's worklist of denied claims to chase |
| `ActionCategoryController` | Lookup of categorization buckets ("Authorization Required", "COB", etc.) |
| `ActionNoteController` | Free-text notes per charge/claim, with category and follow-up date |
| `ARGroupController` | AR reporting buckets (groupings used in aging reports) |
| `ARGroupReasonCodeController` | Reason-code mappings into AR groups |

## Key tables

| Table | Purpose |
|---|---|
| `DenialQueue` | Worklist (one row per work item) |
| `ActionCategory` | Category lookup |
| `ActionNote` | The notes themselves; FK to charge/claim and category |
| `ARGroup` | AR reporting buckets |
| `ARGroupReasonCode` | Reason-code → AR group mapping |

There's also a `PracticeInsight.UnitTest.DenialService` test project (one
of the few) — limited coverage but useful as a reference for testing
patterns.

## Dependencies

`DenialService.BusinessLogic` references:

- `Common/*`
- `MasterService` (to read `DenialCategory`, `RemarkCodeSolution`)
- `ChargePaymentService.DataAccess` (to read claim/charge for context on a denial)

## Notable repository patterns

- `ActionNoteRepository` — heavy use; the note creation path validates
  category and FK references, sets follow-up date. UI hits this from
  the denial-detail page on every save.
- `DenialQueueRepository` — paginated queries; UI displays in ag-grid with sort/filter

## Known gotchas

- 🟢 `RemoveAllExpiredTokenFromCache` is referenced from HostService but lives in SecurityService; nothing here.
- 🟡 Action-note follow-up dates aren't proactively notified (no email/alert on past-due). The UI surfaces them, but if a biller doesn't open the queue, they're invisible. Consider adding a daily report.
- 🟡 No archival of completed denials. The `DenialQueue` grows unbounded.
