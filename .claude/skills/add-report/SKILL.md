---
name: add-report
description: Adds a new report to the Practizing Reports menu. Use when the user asks to "add a report", "create a new RDLC report", or "add a report option". Most reports are DB-dispatched via PZ_Report — this skill avoids unnecessary C# changes and keeps the SP catalog in sync.
---

# Skill: Add a report

Reports in Practizing are dispatched from the `PZ_Report` table. The Reports menu in the UI calls `GET /api/ReportData` which lists every active row, then `POST /api/Report` with a `reportId` and parameter values. The API substitutes the parameter values into `PZ_Report.Command` (a literal `exec rpt_X {p1}` string) and runs it.

**You usually do not need to write any C#.** The work is: write an SP, insert a row, optionally add a UI parameter component.

## When you should run this skill

- User says "add a report", "I need a new aging report", "add this report to the Reports menu".
- The report is a SELECT-style read; one or more SQL result sets feed an RDLC layout.

## When you should NOT run this skill

- The user wants a **dashboard** (live metrics, charts) — that's a controller endpoint, not a PZ_Report row. Use `add-api-endpoint`.
- The user wants a **scrub rule** that runs on claim submission — use `add-scrub`.
- The "report" is actually a one-off Excel export with custom formatting that doesn't fit the RDLC pipeline — discuss with the user; existing examples are `Charges/GetExcelForPatientDetailInsuranceAgingReport`-style hardcoded controller actions.

## Inputs to gather first

1. **Report name** — what shows in the Reports menu (e.g. "Aging by Provider").
2. **Parameters** — date range? provider? facility? insurance? ID list? Each parameter needs a key name (e.g. `fromDate`, `toDate`, `providerID`).
3. **Result shape** — column list. Drives both the SP and the RDLC dataset.
4. **Naming**: SP must start with `rpt_` for a report (codebase convention). PascalCase or snake_case is OK — match neighbors.

## Migration-safe mode

> Read this before authoring a new stored procedure.

The team is moving toward retiring SQL Server stored procedures (see [docs/database/sql-server-to-postgres-migration-plan.md](../../../docs/database/sql-server-to-postgres-migration-plan.md)). Adding a new `rpt_*` SP works in the current architecture but adds to the migration backlog.

If the migration is in flight (ask the user or check the migration plan's status):
- **Prefer adding a typed query handler in C# over a new stored procedure.** The handler lives in `ReportService` next to `ReportRepository`, exposes the same parameter shape, and produces the same dataset for the RDLC layout. The migration plan's `IReportQueryExecutor` boundary makes this trivial once it exists.
- **If you must add an SP** (genuine performance need that the optimizer handles better than the application): mark the new SP in [STORED_PROCEDURES.md](../../../STORED_PROCEDURES.md) with `[migration-debt]` so the retirement project sees it and budgets for the conversion.

If migration mode is **not** active, follow the SP path below.

## Steps (current SP-based path)

### 1. Author the SP in the DB

Convention: name starts with `rpt_`, parameters are `@PascalCase`.

```sql
CREATE PROCEDURE rpt_AgingByProvider
    @FromDate    datetime,
    @ToDate      datetime,
    @ProviderID  int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.ChargeId,
        p.LastName + ', ' + p.FirstName    AS PatientName,
        c.DOS,
        c.Total,
        c.Balance,
        DATEDIFF(day, c.DOS, GETDATE())    AS AgeDays
    FROM Charge c
    INNER JOIN Patient p ON p.Id = c.PatientId
    WHERE c.DOS BETWEEN @FromDate AND @ToDate
      AND (@ProviderID = 0 OR c.ProviderId = @ProviderID);
END
```

**Required guarantees:**
- **Practice scoping is implicit.** `DataBaseContext` opens the practice-specific connection by HTTP host header before the SP runs, so a plain `WHERE` on per-practice tables (`Charge`, `Payment`, etc.) is already scoped to the right practice. **Do not** add `WHERE PracticeId = (subquery)` — earlier drafts of this skill suggested `WHERE PracticeId = (SELECT TOP 1 PracticeId FROM PZ_User WHERE Id = @@PROCID)` which is wrong: `@@PROCID` is the current procedure's `object_id`, not a user id, so the subquery either matches nothing or matches an unrelated row by coincidence. **Delete that pattern wherever you see it.** If you genuinely need an explicit practice filter (cross-practice query, dynamic SQL, etc.), pass `@PracticeId int` as a parameter from the caller.
- **Parameter names match the placeholders** you'll put in `PZ_Report.Command`.
- **Dataset shape stays stable** — RDLC bindings are named to columns; renaming a column breaks the layout.

### 2. Insert the dispatch row in `PZ_Report`

```sql
INSERT INTO PZ_Report (ReportName, [Command], Menu, Parameters, DataSetName, ReportTypeId, IsActive, ComponentName)
VALUES (
  'Aging by Provider',                                                       -- shows in menu
  'exec rpt_AgingByProvider {fromDate}, {toDate}, {providerID}',             -- placeholders match SP params
  1,                                                                         -- 1 = under "Reports" menu group
  '...',                                                                     -- parameter metadata JSON (copy from a similar report)
  'AgingByProviderDataSet',                                                  -- name used inside the RDLC
  1,                                                                         -- 1 = RDLCReport, 2 = PatientStatement
  1,                                                                         -- IsActive
  'AgingByProviderOption'                                                    -- Angular RDLC option component selector
);
```

**Critical**: the `{placeholder}` names must match the keys the UI sends in the parameter payload. A typo silently leaves the literal `{toDate}` in the executed SQL and SQL Server errors out at runtime.

### 3. Add the parameter component in the UI (only if existing options don't cover it)

Most reports reuse one of the existing option components in `projects/pibilling/src/app/reports/`. Copy the closest one:
- date-range only → `report-fromto-option/`
- date-range + provider → `report-provider-option/`
- date-range + facility → `report-facility-option/`
- patient-specific → `report-patient-option/`

If yours fits an existing component, just reuse it — no UI change needed.

If you need a new combination, add a new `*-option.component.ts` whose template emits a parameter object whose keys match the `{placeholder}` names in step 2.

### 4. Build the RDLC layout (if hosting the report locally)

If the report renders inside the app (RDLC viewer) rather than as an Excel/PDF download, the layout file lives outside this repo (with the report-server assets). Coordinate with whoever owns the RDLC files.

### 5. Update the catalog

Append to [STORED_PROCEDURES.md §3.5](../../../STORED_PROCEDURES.md#35-reports-dispatched-dynamically-via-pz_reportcommand-pattern-24):

```
| <new ID> | Aging by Provider | Reports | `exec rpt_AgingByProvider {fromDate},{toDate},{providerID}` |
```

This is how future agents know your report exists.

### 6. Verify
- Restart no service is needed — `PZ_Report` is read on every report-list call.
- Open the Reports menu in the running UI; new entry should be there.
- Run the report with sample parameters; confirm the result set shape matches the RDLC dataset.

## What this skill does NOT do

- It does not modify `ReportRepository.cs` — the dispatcher is generic.
- It does not change `STORED_PROCEDURES.md` automatically (do step 5 yourself).
- It does not deploy the RDLC file (that's a report-server task).

## Common mistakes

- Using `usp_` prefix for a report. Use `rpt_` to match codebase convention.
- Mismatched placeholder names → silent runtime SQL error.
- Forgetting `IsActive = 1` → report won't appear in the menu.
- Returning more than one result set → RDLC may bind only the first.
- Putting parameter values directly in the SP body via dynamic SQL → reintroduces injection risk; pass them as `@params`.

## Cross-references

- [STORED_PROCEDURES.md §3.5](../../../STORED_PROCEDURES.md#35-reports-dispatched-dynamically-via-pz_reportcommand-pattern-24) — current report list
- [docs/architecture/API_ARCHITECTURE.md §4.5](../../../docs/architecture/API_ARCHITECTURE.md#45-db-dispatched-sp-names) — dispatch pattern
