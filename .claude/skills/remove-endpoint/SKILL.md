---
name: remove-endpoint
description: Removes an existing CRUD API endpoint cleanly across every dispatch surface. Use when the user asks to "delete an endpoint", "retire a controller action", "remove an unused entity API". Walks the inverse of add-api-endpoint and updates every catalog the endpoint touched. Refuses to remove endpoints that still have UI callers without explicit acknowledgment.
---

# Skill: Remove an API endpoint

Removing an endpoint is harder than adding one because the codebase has at least four "shadow registries" that can hold a reference: the controller routing, the DI container, the Angular UI's HTTP calls, and the catalog docs. Miss any of these and you leave dead code or, worse, a runtime crash.

## When you should run this skill

- User asks to retire/delete a controller action or full controller.
- User asks to drop an entity that's no longer used.
- A migration plan deprecation reaches its cutover date and the old endpoint is being removed.

## When you should NOT run this skill

- The endpoint still has Angular UI callers and the user hasn't acknowledged that. Ask first; do not remove silently.
- The endpoint is being *replaced* by a new one. That's a refactor, not a removal — and the safest pattern is "deploy the new one, switch UI, then run this skill."
- The endpoint is part of an SP retirement during the SQL → PG migration. Use the `deprecate-feature` skill first to mark a cutover date; only run remove-endpoint on the cutover day.

## Inputs to gather first

1. **Endpoint name** — controller class + action method + HTTP verb (e.g. `ProviderController.GetByUId`, `GET /api/Provider/getByUId/{uid}`).
2. **Why it's being removed** — used in the PR description; matters for the `MIGRATION_DECISIONS.md` row.
3. **Confirmation that no UI caller still depends on it** — the user must say so explicitly.

## Pre-flight checks (run before editing)

### 1. Grep the API repo for the controller action
- Confirm no other C# code calls it internally (e.g. one controller calling another's repository directly is rare here, but happens).

### 2. Grep the UI repo
- The UI repo is at `c:\Users\MadhukarNarahari\Documents\GitHub\Practizing-ui-TALBOT_CLINIC`.
- Search for the endpoint URL fragment (`Provider/getByUId/`) across `*.ts` files.
- Any hit means the UI still calls this. Stop. Either retire the UI caller first, or coordinate the change.

### 3. Run `/sp-impact` if the endpoint touches an SP
- If the controller action ends up running `usp_X`, the SP may have other callers. Confirm.

### 4. Check `PZ_Report.Command` and `Scrub.StoredProcedure`
- If the SP is referenced from a dispatch table, removing the endpoint without updating the table leaves a dangling reference.

### 5. Check the catalog docs
- [STORED_PROCEDURES.md](../../../STORED_PROCEDURES.md) — does it list this SP/endpoint?
- [postgres-sp-conversion.md](../../../docs/database/postgres-sp-conversion.md) — what's the SP's row status?

If any of these checks reveals a reference, **stop and report**. Don't proceed with removal until the references are resolved.

## Steps (for a clean removal)

### 1. Remove the controller action
File: `{Service}/PractiZing.Api.{Service}/Controllers/{Entity}Controller.cs`

If the action is the *last* one in the controller, delete the whole file. If others remain, delete just the action method.

### 2. Remove the repository method
File: `{Service}/PractiZing.BusinessLogic.{Service}/Repositories/{Entity}Repository.cs` and its interface in `Base/PractiZing.Base/Repositories/{Service}/I{Entity}Repository.cs`.

If the repository is now empty (no methods), delete the file and its interface.

### 3. Remove the DI registration
File: `{Service}/PractiZing.BusinessLogic.{Service}/{Service}RepositoryCollectionExtension.cs`

Delete the line `services.AddScoped<I{Entity}Repository, {Entity}Repository>();`.

### 4. Remove the entity if no longer used elsewhere
- File: `{Service}/PractiZing.DataAccess.{Service}/Tables/{Entity}.cs` and `Base/PractiZing.Base/Entities/{Service}/I{Entity}.cs`.
- Only delete if no other repository/service references the type.
- Note: do NOT drop the database table here. Schema deletion is a separate operation that goes through the DBA and a migration script.

### 5. Update catalogs
- Remove the SP row from [STORED_PROCEDURES.md](../../../STORED_PROCEDURES.md) §3 and add it to §8 ("Known Broken / Stale References") if its dispatch table references stay.
- Update [postgres-sp-conversion.md](../../../docs/database/postgres-sp-conversion.md): change the row's `Status` to `cutover` or `dropped` per the actual state.
- If the endpoint was in `PZ_Report` or referenced by a `Scrub` row, **DBA must remove those rows separately** in a DB migration; the C# delete alone is insufficient.

### 6. Add a row to MIGRATION_DECISIONS.md (or the equivalent decision log)
- For migration-related removals, add a row in [MIGRATION_DECISIONS.md](../../../docs/database/MIGRATION_DECISIONS.md) under "SP Retirement Decisions" with the SP name, disposition (`Drop`), date, owner, approver, and the commit hash of this PR.

### 7. Build and run safety-review
- `dotnet build` — confirm nothing else broke.
- `/safety-review` — confirm no orphaned references.

## What this skill does NOT do

- It does not drop the SQL Server stored procedure. That's a separate DBA action and should happen only after dual-run validation if migration is in progress.
- It does not remove the corresponding database table. That requires a migration script reviewed by the DBA.
- It does not delete UI components. If the UI repo still has the screen that called this endpoint, that's a separate cleanup PR.
- It does not retroactively fix UI callers — those need the user to confirm they're already gone before removal.

## Common mistakes

- Removing the endpoint while the UI is still calling it. Result: 404s in production, support tickets.
- Removing the SP from C# but leaving a `PZ_Report.Command` row that still tries to `exec` it. Result: report fails silently or with a SQL error.
- Forgetting the DI registration. Result: build passes but the controller doesn't resolve at startup. May cascade into other unrelated DI failures.
- Treating "no grep hits in the API repo" as enough. Always check the UI repo too.
- Dropping the database table the same day. Treat schema and code as separate change windows.

## Cross-references

- [add-api-endpoint](../add-api-endpoint/SKILL.md) — the inverse pattern.
- [deprecate-feature](../deprecate-feature/SKILL.md) — use this first if removal is not immediate.
- [docs/architecture/SECURITY_AND_RISKS.md](../../../docs/architecture/SECURITY_AND_RISKS.md) — the safety-review checklist that runs against this PR.
- [docs/database/MIGRATION_DECISIONS.md](../../../docs/database/MIGRATION_DECISIONS.md) — append a row here for migration-related removals.
