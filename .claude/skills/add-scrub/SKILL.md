---
name: add-scrub
description: Adds a new claim-scrub rule to the Practizing system. Use when the user asks to "add a scrub rule", "block claims that …", "validate claims for …". Scrubs are dispatched from the Scrub table — every row currently runs as a stored procedure (the C# validator code path is not implemented). This skill enforces that constraint and keeps the catalog in sync.
---

# Skill: Add a claim scrub

> **Read this first.** The data model and the runtime do not match. The DB `Scrub` table exposes columns named `IsProcedure`, `IsAutoScrub`, `IsPracticeCentral`, but the C# entity at [`ChargePaymentService/.../Tables/Scrub.cs:22-25`](../../../ChargePaymentService/PractiZing.DataAccess.ChargePaymentService/Tables/Scrub.cs) has all three commented out. The runtime [`ClaimBatchRepository.RunAutoScrub`](../../../ChargePaymentService/PractiZing.BusinessLogic.ChargePaymentService/Repositories/ClaimBatchRepository.cs#L506-L536) **unconditionally executes the value of `Scrub.StoredProcedure` as a SQL Server stored procedure** with `CommandType.StoredProcedure`. There is **no branch** that calls a C# validator class.
>
> **Two existing rows therefore do not work:** `CPTToICDValidator` and `CPTToModifierValidator` are configured in the `Scrub` table but a SQL Server stored procedure does not exist with those names. Calling them raises a runtime SQL error.
>
> **Implication for this skill:** every new scrub rule must be implemented as a stored procedure with the exact signature below. The "C# validator path" is planned but unimplemented; do not configure scrub rows that depend on it.

## When you should run this skill

- User says "add a scrub", "validate claim before submission", "block claims missing modifier X", "add a CCI edit".
- The validation must run against a batch of charges before they go out as 837.

## When you should NOT run this skill

- The validation is a per-field UI check at data entry — that's a directive in the post-charge form, not a scrub.
- The validation is a post-submission claim status check — that belongs in the ERA processing pipeline.
- The validation is a billing analytics or reporting concern — that's a report.
- The user wants a C# validator instead of a stored procedure. The dispatch path doesn't exist; either implement it (a 1-2 day refactor of `RunAutoScrub`) or steer the user to the SP path.

## Inputs to gather first

1. **Rule name** — short label (e.g. "Scrub 87 — Mod 25 with EM only").
2. **What it validates** — the failure condition in plain English, then SQL.
3. **Auto-run** — should it run on every batch automatically (`Active = 1`)?
4. **Existing precedent** — find the closest existing scrub (`usp_RunScrub81EM` through `usp_RunScrub86EM`, `usp_RunScrub124`) and copy its skeleton.

## Steps

### 1. Author the SP

Required signature (matches the existing `usp_RunScrub*` procedures):

```sql
CREATE PROCEDURE usp_RunScrub87
    @Charges ChargeType READONLY,         -- TVP — see existing scrubs for the type def
    @ScrubId int,
    @PracticeCode nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Return rows shaped like a ScrubError DataTable.
    -- The dispatcher reads result-set [0] via SqlDataAdapter and converts to ScrubError.
    -- Look at an existing usp_RunScrub82EM body to confirm the column shape your version
    -- of the dispatcher expects; the converter in ClaimBatchRepository.ConvertDataTableToList
    -- currently only reads ActionDate but the older versions read more columns.
    -- Until the dispatcher is hardened, return all the columns the existing scrubs return.

    SELECT
        c.ChargeId,
        c.ClaimId,
        c.FacilityId,
        ...                                  -- match an existing usp_RunScrub*EM exactly
    FROM @Charges c
    LEFT JOIN CPTCode cpt ON cpt.Code = c.CPTCode
    WHERE c.Modifiers LIKE '%25%'
      AND (cpt.IsEM = 0 OR cpt.IsEM IS NULL);
END
```

**Required guarantees:**
- Signature is exactly `(@Charges ChargeType READONLY, @ScrubId int, @PracticeCode nvarchar(50))`. The dispatcher passes positional parameters via `AddWithValue`; mismatched order or types fail at runtime.
- Return a result set whose columns match what the existing scrubs return. Do **not** insert into `ScrubError` from inside the SP — the dispatcher reads the result set and the caller writes errors.
- `@PracticeCode` is for tagging; do not assume it filters automatically. Apply your own practice filter if needed.

### 2. Insert the Scrub row

```sql
INSERT INTO Scrub (Name, Description, DestinationId, Active, Priority, [Order], StoredProcedure)
VALUES (
  'Scrub 87 — Mod 25 with EM only',
  'Flags modifier 25 applied to non-E/M CPTs.',
  1,                  -- DestinationId — copy from a similar row
  1,                  -- Active
  1,                  -- Priority
  9,                  -- Order — pick next free
  'usp_RunScrub87'
);
```

Note: the live `Scrub` table may have additional columns (`IsAutoScrub`, `IsProcedure`, `IsPracticeCentral`) that exist in the schema. They are not read by the running C# code (the entity has them commented out). Set them to safe defaults if they have NOT NULL constraints, but expect them to be ignored at runtime until the entity is updated.

### 3. Update the catalog

Append a row to [STORED_PROCEDURES.md §3.6](../../../STORED_PROCEDURES.md#36-claim-scrubs-dispatched-dynamically-via-scrubstoredprocedure-pattern-24).

## Verify

1. From the running UI, open a claim batch and click "Run Scrub" — your rule should fire alongside the existing ones.
2. Plant a charge that violates the rule; verify the dispatcher reports an error (current converter is lossy — see step 1's note).
3. Plant a passing charge; verify no error.
4. Toggle `Active = 0` and re-run; confirm the rule is skipped.

## What this skill does NOT do

- It does not write the `ChargeType` TVP — it already exists with 52 columns; reuse it.
- It does not affect EDI generation — failed scrubs only block submission via UI workflow.
- It does not implement the C# validator path. That is a separate refactor of `RunAutoScrub`. If the user needs C# rules urgently, scope it as its own task.

## Critical security context

The endpoint `POST /api/ClaimBatch/scrub` is `[AllowAnonymous]` and accepts the `spName` parameter from the query string. Combined with `RunAutoScrub` executing `spName` directly as `CommandType.StoredProcedure`, **any unauthenticated caller can invoke any stored procedure in the database with three string parameters.** This is documented in [SECURITY_AND_RISKS.md](../../../docs/architecture/SECURITY_AND_RISKS.md) under the Critical section.

**Do not add any new scrub work until that endpoint is hardened.** Adding a new SP gives the unauthenticated caller one more procedure they can invoke. The fix is two lines:
1. Remove `[AllowAnonymous]` from `ClaimBatchController.Scrub`.
2. Replace the `spName` query parameter with a server-side lookup of `Scrub.StoredProcedure` by `Scrub.Id`, so the client cannot specify an arbitrary SP name.

If you cannot do that fix in scope, raise it explicitly to the user before proceeding.

## Migration-safe mode

This skill currently writes new SQL Server stored procedures and `Scrub` rows. That conflicts with the long-term direction in [docs/database/sql-server-to-postgres-migration-plan.md](../../../docs/database/sql-server-to-postgres-migration-plan.md), which retires SPs in favor of application services with stable rule keys.

If the team has switched to migration-safe mode (asked the user explicitly):
- **Do not add new stored procedures.** Add a C# `IScrubRule` implementation under `ChargePaymentService/PractiZing.BusinessLogic.ChargePaymentService/ScrubRules/`.
- **You must first add the dispatch path.** `RunAutoScrub` does not currently call C# validators. Either ship a small `IScrubRuleExecutor` interface and route to it, or do not enable the rule until the dispatcher exists.
- Add the rule to a code-side registry; add a `Scrub` row with `RuleKey` (after the schema migration adds that column) instead of `StoredProcedure`.

If migration-safe mode is **not** active, follow the SP path above but keep this section in mind for the next time the team reviews scrub strategy.

## Common mistakes

- Wrong SP signature (missing one of the three params, or wrong order). The dispatcher fails silently — `AddWithValue` doesn't validate parameter shape against the SP.
- Forgetting `Active = 1` → rule never runs.
- Adding a row with `StoredProcedure = 'MyValidator'` thinking it dispatches to a C# class. It does not. The runtime will look for a SQL stored procedure with that exact name and error out.
- Returning rows in a different shape than the existing scrubs → `ConvertDataTableToList` silently drops fields.
- Using `AddWithValue` for the TVP in any new dispatcher code. TVPs require `SqlDbType.Structured` with a `TypeName`. The current dispatcher does this correctly for `@Charges` because SqlClient infers it from a `DataTable`, but new code should set the type explicitly.

## Cross-references

- [STORED_PROCEDURES.md §3.6](../../../STORED_PROCEDURES.md#36-claim-scrubs-dispatched-dynamically-via-scrubstoredprocedure-pattern-24)
- [docs/architecture/API_ARCHITECTURE.md §4.5](../../../docs/architecture/API_ARCHITECTURE.md#45-db-dispatched-sp-names)
- [docs/architecture/SECURITY_AND_RISKS.md](../../../docs/architecture/SECURITY_AND_RISKS.md) — see anonymous-scrub Critical entry
- Existing scrub SPs to copy from: `usp_RunScrub81EM` through `usp_RunScrub86EM`, `usp_RunScrub124`
- The two configured-but-broken rows: `CPTToICDValidator`, `CPTToModifierValidator` (these will throw at runtime if invoked)
