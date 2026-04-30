# Data Flow — UI → API → DB

How a user action becomes a database row. Use this when debugging a single feature.

## The canonical request path

```
[Component]                        Angular component (e.g. DenialDashboardComponent)
    │ method call
    ▼
[Service]                          *.service.ts — uses HttpClient with relative URL
    │ HTTP
    ▼
[TokenInterceptor]                 Adds Authorization (bearer smallToken) + _rid header
    │
    ▼
[ApiHttpInterceptor]               Prepends environment.apiUrl, shows spinner, handles errors
    │
    ▼
nginx (prod) /api/* → ${API_URL}   In dev: direct to http://localhost:5001
    │
    ▼
[ASP.NET pipeline]                 JWT validation: PractiZingJwtTokenHandler swaps small→full
    │
    ▼
[Controller action]                {Entity}Controller : SecuredRepositoryController<I…>
    │
    ▼
[Repository]                       {Entity}Repository inherits BaseRepository<T>
    │
    ▼
[DataBaseContext]                  Picks SQL connection by practice code (HTTP Host header)
    │
    ▼
[SQL Server]                       OrmLite query OR exec stored procedure
                                       │
                                       ▼ (for reports/scrubs)
                                   PZ_Report.Command / Scrub.StoredProcedure → SP
```

Two side channels off this path matter:

- **MemoryCache** holds the full JWT for each "small token" that's in flight. If the cache evicts, the user gets 401 even though their cookie/header is still valid.
- **`_rid` header/query** is added by the UI and… ignored by the API. The API does not read it. (It exists as future correlation infra.)

## Worked examples

The cross-repo flow map for every major feature is in [STORED_PROCEDURES.md §4](../../STORED_PROCEDURES.md#4-ui--api--sp-path-cross-repo-flow-map). Below are three illustrative ones.

### Example 1 — Denial Dashboard (read path, multiple parallel SPs)

1. User opens "Denial Dashboard" tab.
2. `DenialDashboardComponent` (`projects/pibilling/src/app/denial-dashboard/`) calls `denialDashboardService.getAgingCount()`.
3. `denial-dashboard.service.ts` does `httpClient.get('DenialQueue/GetAgingCount')`.
4. Interceptors prepend base URL, attach token.
5. `DenialQueueController.GetAgingCount` calls `DenialQueueRepository.GetAgingCount`.
6. The repository fires **5 SPs in sequence** (see [STORED_PROCEDURES.md §3.1](../../STORED_PROCEDURES.md#31-denial-management-denialmanagementservice)) via `ExecuteStoredProcedureAsync`. All five are parameterless — they read context from session-scoped temp tables internally.
7. Results assembled into `DenialManagementDTO` and returned.
8. UI renders charts.

**What can go wrong:** any of the 5 SPs can throw; one failure aborts the whole call. The user sees a generic 500 toast.

### Example 2 — Run a report (DB-dispatched SP)

1. User opens "Reports" tab → picks "Aging By Insurance" → clicks Run.
2. UI does `httpClient.post('Report', { reportId: 4, parameters: { toDate: '...' } })`.
3. `ReportController.Run` → `ReportRepository.GenerateReportData(4, params)`.
4. Repository looks up `PZ_Report` row for `id=4` → reads `Command` = `exec rpt_Aging_Summary_By_Insurance {toDate}`.
5. `{toDate}` placeholder is substituted from `params`.
6. Final SQL `exec rpt_Aging_Summary_By_Insurance '2026-04-30'` executes via OrmLite.
7. Result serialized as JSON for the RDLC viewer.

**What can go wrong:** if `Command` is malformed (placeholder name doesn't match a key in `params`), the substitution silently leaves the literal `{toDate}` in the SQL, and SQL Server errors out. Always inspect the `Command` string when a report fails.

### Example 3 — Save a charge (write path with multi-tenancy)

1. User submits Post Charge form.
2. UI calls `chargesService.save(model)` → `httpClient.post('Charge', model)`.
3. `ChargesController.Post` → `ChargesRepository.AddNewAsync`.
4. `BaseRepository.SetUserStamp(entity, isUpdate=false)` populates `CreatedBy = LoggedUser.Id`, `CreatedDate = DateTime.Now`, `PracticeId = LoggedUser.PracticeId`.
5. `Connection.InsertAsync(entity)` — OrmLite generates `INSERT INTO Charge (...)`.
6. The connection itself is the practice-specific one (resolved from HTTP Host).

**What can go wrong:**
- If the user's JWT is missing `PracticeId`, `LoggedUser.PracticeId` defaults to **1** in `BaseRepository`. The row gets stamped to practice 1 by mistake. Fix the JWT or harden the default.
- The DB-level connection chosen by host header could be different from the in-row PracticeId (host says practice "talbot", JWT says PracticeId=5). Today nothing reconciles those.

## Multi-tenant resolution rules

Two independent things determine "what tenant am I in":
1. **The connection string** — chosen from `appsettings` by the practice code in the HTTP `Host` header (e.g. `talbot.app.com` → connection key `talbot`).
2. **The PracticeId on rows** — from the JWT claim, stamped by `BaseRepository`.

These should always agree. **They are not actively cross-checked.** When debugging a "wrong-practice" bug, verify both.

## Background flows

Most of the system runs in-request. The exceptions:
- **SQL Agent jobs** on the DB host run nightly snapshots, charge-stat refreshes, data-warehouse imports. Names live in [STORED_PROCEDURES.md §5.1](../../STORED_PROCEDURES.md#51-likely-sql-agent--scheduled-jobs-data-warehouse-loaders-snapshots).
- **External integrations** (Catalyst, Plaid, MethaSoft, Chase) are pulled by API endpoints when the user clicks a button — there's no event-driven scheduler.
- **EDI** (837 out / 835 in) is uploaded/downloaded over SFTP when triggered by claim-batch or ERA endpoints.

If you need a true scheduled job, your options are:
1. Add an SQL Agent job (preferred for DB-only work).
2. Add an `IHostedService` to one of the API services (no precedent here — proceed cautiously).
3. Run a `cron` on the host that hits an API endpoint.

## Logging, tracing, troubleshooting

When a single user action goes wrong:
1. Browser console and network tab for the HTTP details (the toastr message often loses fidelity).
2. Coolify logs of the relevant API service container — most useful messages are `Console.WriteLine`s, not structured.
3. Run the same SP manually against the DB to isolate UI vs API vs SQL.
4. Check the `_rid` from the request URL — it's not used by the API today, but it's visible in nginx access logs and helps line up entries when multiple tabs are open.

## When two services need to talk

Cross-service in-process calls are not allowed (see [API_ARCHITECTURE.md §1](./API_ARCHITECTURE.md#1-solution-layout)). Patterns in use:
- **Service A reads service B's tables directly** (because they share a DB) — most common.
- **HTTP** — only `ERAService → external ERA fulfillment URL` does this.
- **No queues, no events, no SignalR.**

Adding a queue would be a significant architectural change. Don't add one for a single feature.
