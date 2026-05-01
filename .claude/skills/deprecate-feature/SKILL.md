---
name: deprecate-feature
description: Marks a feature, endpoint, report, or scrub for removal with a planned cutover date — without removing it today. Use when the user wants to "deprecate", "schedule for removal", "phase out", or "wind down" something. Adds the deprecation banner, registers the cutover date in the migration decision log, and primes the framework to run remove-endpoint on the cutover day.
---

# Skill: Deprecate a feature with a planned cutover date

Most feature removals fail because the team removes too quickly (UI callers haven't migrated) or too slowly (the dead code accrues for years). A deprecation pattern with a fixed cutover date solves both: announce the date, give callers time to migrate, then run [remove-endpoint](../remove-endpoint/SKILL.md) on the date.

## When you should run this skill

- A feature is being replaced by a newer one (e.g. `payment/` is the replacement for `old_payment_screen/`).
- A migration phase will retire an SP, but the C# endpoint behind it is still in use until the new path proves out.
- Product decides a low-usage feature will sunset on a specific date.

## When you should NOT run this skill

- The feature has zero callers and can just be removed today. Use [remove-endpoint](../remove-endpoint/SKILL.md) directly.
- The feature is being kept indefinitely with no replacement. Don't pretend to deprecate.
- The "feature" is actually a security issue. Fix the security issue, don't deprecate around it.

## Inputs to gather first

1. **What's being deprecated** — endpoint, report, scrub, UI screen, integration.
2. **Cutover date** — a specific calendar date, not "soon" or "Q3."
3. **What replaces it** (if anything) — for cross-reference.
4. **Who's affected** — the UI team, a partner integration, an internal tool.
5. **Owner of the cutover** — one named human, not a team.

## Steps

### 1. Add a deprecation marker in the source

For an API endpoint:

```csharp
[HttpGet("legacy-thing")]
[Obsolete("Deprecated 2026-04-30; cutover 2026-08-31. Use /api/NewThing/get instead. Tracked in MIGRATION_DECISIONS.md.")]
public async Task<IActionResult> GetLegacyThing(...) { ... }
```

For a UI component, add a `console.warn` in the constructor or a banner in the template:

```typescript
constructor(...) {
  console.warn('[DEPRECATED] LegacyComponent is deprecated. Cutover 2026-08-31. Use NewComponent.');
}
```

For an SP, add a comment block at the top of the SP body:

```sql
ALTER PROCEDURE rpt_LegacyThing ...
AS
BEGIN
  -- DEPRECATED 2026-04-30; cutover 2026-08-31.
  -- Replacement: rpt_NewThing (PZ_Report id 99).
  -- Owner: jdoe.
  -- Tracked in docs/database/MIGRATION_DECISIONS.md.
  ...
```

### 2. Add a row to MIGRATION_DECISIONS.md

Under "SP Retirement Decisions" (for SPs) or as a new top-level "Deprecations" section if there isn't one yet:

```
| 2026-04-30 | rpt_LegacyThing | Deprecated; cutover 2026-08-31 | jdoe | architecture lead | Replacement: rpt_NewThing | <commit hash of this PR> |
```

### 3. Update catalogs

- [STORED_PROCEDURES.md](../../../STORED_PROCEDURES.md): add a `[deprecated 2026-08-31]` tag to the SP's row in §3.
- [postgres-sp-conversion.md](../../../docs/database/postgres-sp-conversion.md): keep the row in `pending Phase 0` or move to `classified` with a note in the disposition column.

### 4. If the UI calls this, update the UI service to log the deprecation

The Angular service that calls the deprecated endpoint should log a deprecation warning to make UI usage discoverable:

```typescript
// LegacyService.getThing() — DEPRECATED 2026-04-30; cutover 2026-08-31.
// Replace callers with NewService.getThing.
getThing(): Observable<Thing[]> {
  console.warn('[DEPRECATED] LegacyService.getThing — use NewService.getThing instead.');
  return this.http.get<Thing[]>('Legacy/getThing');
}
```

### 5. Schedule the cutover

If the team uses a scheduling tool (Linear, Jira, GitHub milestones), create a milestone for the cutover date pointing to:
- The PR that ran `remove-endpoint` (to be opened on the cutover day).
- The owner.
- The list of dependencies that must finish before then (e.g., "UI team migrates 3 screens off this endpoint").

### 6. Tell anyone who's affected

If a partner integration uses the deprecated thing, the integrations lead emails the partner with the cutover date. If the UI team is affected, message the UI lead.

### 7. Build and run safety-review

- `dotnet build` confirms the `[Obsolete]` attribute is well-formed (it should produce a compile warning, not error).
- `/safety-review` confirms no other safety issues introduced.

## What happens on the cutover date

On the date in the deprecation, the same owner (or a successor) opens a new PR that runs the [remove-endpoint](../remove-endpoint/SKILL.md) skill. Pre-flight checks should now show zero callers; if they don't, the deprecation date slips and a new date is set.

## Common mistakes

- Setting a date that's too soon. Deprecations need time. 90+ days is reasonable for internal stuff; 6 months for partner integrations.
- Setting a date that's too far. "Some day" is not a deprecation, it's procrastination.
- Forgetting to email the partner. They learn at cutover and the integration breaks.
- Marking deprecated but not actually removing on the date. The `[Obsolete]` attribute starts being ignored after a year.
- Forgetting to update the catalog. The SP shows up in `STORED_PROCEDURES.md` as active long after the C# endpoint is gone.

## Cross-references

- [remove-endpoint](../remove-endpoint/SKILL.md) — runs on the cutover date.
- [docs/database/MIGRATION_DECISIONS.md](../../../docs/database/MIGRATION_DECISIONS.md) — the decision log that records the deprecation.
- [docs/architecture/SECURITY_AND_RISKS.md](../../../docs/architecture/SECURITY_AND_RISKS.md) — risk #20 is "two parallel implementations" — deprecation is the cure for that.
- [docs/database/sql-server-to-postgres-migration-plan.md](../../../docs/database/sql-server-to-postgres-migration-plan.md) — many SP retirements during the migration follow a deprecation → cutover pattern.
