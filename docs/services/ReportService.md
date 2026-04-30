# ReportService

**Folder**: `ReportService/`
**Container name in compose**: `practizing-report`

## Purpose

Stores report definitions and the cached aggregated tables that some
reports query. **Note: this service has NO controllers**. It's a library
project. Other services (mostly ChargePayment) inject its repositories
to fetch report definitions and write to the cached tables.

The `Api` project exists, has a `Startup.cs`, and can be built/deployed
as a container — but with no controllers, it serves nothing. The
container in compose is functionally idle. You can remove it from compose
without losing anything if you want fewer containers.

## Key tables

| Table | Purpose |
|---|---|
| `Report` | Report definitions. Has `Command` column (template SQL with `{token}` placeholders), `ReportType`, `ParameterMetaData` (JSON describing parameters). |
| `ReportFormulaField` | Calculated fields used in report rendering |
| `ReportARChargesMonthWise` | Cached AR aging by month |
| `CPAReportMonthYearWise` / `CPAReportMonthYearWiseChild` | CPA-specific aggregations |
| `ChargeBalanceAR90` | Cached 90-day AR balance |
| `ChargeStat` | Cached charge statistics |

## How reports run

1. UI (Reports module) fetches a `Report` row from the DB → gets the template SQL
2. UI calls a ChargePayment endpoint (e.g. `POST /api/Charges/GetExcelForPostingPatments`) with the parameters
3. ChargePayment's repository calls `ParseParameter.ParseReport(template, parametersAsRow)`:
   - Replaces `{ParamName}` in the template with `'value'` (string concatenation)
   - 🔴 No parameterization — SQL injection sink. See [`../TROUBLESHOOTING.md`](../TROUBLESHOOTING.md).
4. The resulting SQL is run via `SqlCommand.CommandText`
5. Output is converted to Excel via `Common/.../ExcelExportHelper.cs`

The cached tables (`ReportARChargesMonthWise`, `ChargeStat`, etc.) are
populated by jobs **not** in this repo — they're SQL Agent jobs or
external scripts. If they're stale, reports look stale.

## Dependencies

- `Common/*`
- (No cross-service deps in BusinessLogic; HostService references this for DI)

## Notable repository patterns

- `ReportRepository.GetById(int)` — fetch a definition for the UI
- The actual report execution is in ChargePayment, not here.

## Known gotchas

- 🔴 The `Report.Command` column contains template SQL with literal `{token}` placeholders. It's executed via `ParseParameter.ParseReport` which does string substitution. **Anyone with edit rights to the `Report` table can effectively inject SQL.** Don't expose Report-edit endpoints to non-admins.
- 🟢 The compose service `practizing-report` exposes nothing useful since there are no controllers. Consider removing it from compose to save ~450MB.
- 🟢 Cached aggregation tables are populated externally — document the cadence with whoever maintains the SQL Agent jobs.
- 🟡 Report definitions don't have versioning; editing a `Report` row in production immediately changes the report behavior for everyone. Add a change log if compliance requires audit.
