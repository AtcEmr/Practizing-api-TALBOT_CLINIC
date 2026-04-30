# Security, Risks & Gotchas

This is the "do not break" list. Treat it as required reading before any non-trivial change.

Severity:
- 🔴 **Critical** — actively exploitable or causes data corruption. Do not introduce more of these. Plan to fix when in scope.
- 🟠 **High** — wrong behavior likely; security or correctness impact.
- 🟡 **Medium** — fragile; future bugs likely.
- ⚪ **Low** — code-quality smell.

## 🔴 Critical

### 1. `BaseRepository.ExecuteStoredProcedureAsync` is SQL-injectable
[Common/PractiZing.BusinessLogic.Common/BaseRepository.cs:132](../../Common/PractiZing.BusinessLogic.Common/BaseRepository.cs#L132).

Builds the SQL by string concatenation: `$"exec {functionName} {p1},{p2},…"`. `CreateFunctionParameter` wraps strings in single quotes but does **not** escape embedded quotes. Any caller that passes user-supplied input is exploitable.

**Rule for new code:** if the input is anything other than a hardcoded constant or a typed primitive that you control, use Pattern B from [STORED_PROCEDURES.md §2.2](../../STORED_PROCEDURES.md#22-pattern-b--raw-sqlcommand-with-commandtypestoredprocedure) (raw `SqlCommand` + `Parameters.AddWithValue` or `SqlParameter`).

### 2. Permission filter is disabled
`Common/.../SecuredFilterAttribute.cs` — `OnActionExecutionAsync` has the entire role/permission check commented out and unconditionally calls `await next()`. Every authenticated user can invoke every `[Authorize]` endpoint, regardless of role.

**Rule:** do not write code that *assumes* the controller will reject the user based on permissions. If a particular action must be limited to a role, check `LoggedUser` claims explicitly inside the repository or service method.

### 3. JWT signing secret is hardcoded in source
`Common/.../ConfigureAuthServices.cs` contains the secret as a string literal. Anyone with the compiled DLL can forge tokens.

**Rule:** the secret should come from `Configuration["JwtSecret"]` (env var). When you next touch auth setup, fix it. Do not commit any code that adds a second hardcoded secret.

### 4. Database credentials in `appsettings.Development.json`
Server IP, user, and password are checked into git. The file ends up in dev images.

**Rule:** never commit changes to `appsettings.Development.json` that update prod-like credentials. Production must come from Coolify env vars (`ConnectionStrings__DefaultConnection`). When rotating credentials, rotate the env var, not this file.

### 5. EMR credentials embedded in JWT claims
`Common/.../IdentityUser.cs` decodes EMR URL, username, and password from claims. The UI sees them.

**Rule:** never log claim contents. Never echo `LoggedUser` to a response. If you need to call the EMR, do it server-side and don't surface those values to the client.

### 6. DB-dispatched SP names
`PZ_Report.Command` and `Scrub.StoredProcedure` are read by the API and executed. Today these tables are seeded by DBAs, but if you ever add an endpoint that lets a user write to them, an attacker can pick any SP (or arbitrary SQL).

**Rule:** treat those columns as code, not data. Do not add user-facing CRUD endpoints for them without strong validation (whitelist of known SP names, parameter signature check).

## 🟠 High

### 7. `Exception.Message` returned to clients
Every controller has `catch (Exception ex) { return StatusCode(500, ex.Message); }`. Stack traces and DB error text leak to the browser.

**Rule:** in new controllers, log the full exception via `ILogger`, return a generic string. When fixing this generally, do it in the base controller so it cascades.

### 8. `DateTime.Now` everywhere
Audit columns (`CreatedDate`, `ModifiedDate`) and cache expirations use local time. The server is one TZ; reports and clients may be different. Daylight Saving Time will cause one-hour gaps and overlaps.

**Rule:** in new code, use `DateTime.UtcNow`. Never compare `Now` with `UtcNow`. When you touch a method that uses `Now`, prefer to fix it; if not in scope, leave a `// TODO(utc): …` and move on.

### 9. `PracticeId` defaults to 1 if JWT claim missing
[BaseRepository.cs:48](../../Common/PractiZing.BusinessLogic.Common/BaseRepository.cs#L48). A malformed token silently writes rows under practice 1.

**Rule:** if you write a new repository method that filters or stamps by practice, throw if `LoggedUser.PracticeId == 0` rather than tolerating the default. Better: fix the default in BaseRepository to throw.

### 10. `.GetAwaiter().GetResult()` in async paths
`ERAService/.../ERARequestService.cs:30` synchronously blocks an HTTP call. Under load this deadlocks the threadpool.

**Rule:** never use `.GetAwaiter().GetResult()` or `.Result` on a `Task<T>` in a request handler. Use `await`.

### 11. Excel exports / batch scrubs run in the request thread
There is no background queue. Long requests block; a timeout looks like an error.

**Rule:** for any new long-running operation, set a clear cap on row count, document the expected runtime, and consider returning a "started" response with a poll endpoint if you can.

### 12. UI subscribes without unsubscribing
~164 `.subscribe()` vs ~14 `unsubscribe`/`takeUntil`/`async`. With the tab-recreate pattern, this leaks.

**Rule:** in new Angular components, use `takeUntil(this.destroy$)` or the `async` pipe. Set up `destroy$ = new Subject<void>()` and `complete()` it in `ngOnDestroy`.

### 13. UI `_rid` interceptor bug
`api.interceptor.ts:57,83` uses `=` instead of `===`. The condition is always truthy. Works by coincidence today.

**Rule:** if you fix this, regression-test the spinner-hide path carefully. Don't copy this idiom.

## 🟡 Medium

### 14. No correlation ID propagation
The UI sends `_rid` but the API does not read it. No request id makes it into logs, so multi-service traces are impossible.

**Rule:** if you add new outbound calls, log the upstream call site and a self-generated id. When the team fixes this for real, plumb a single id end-to-end.

### 15. `Console.WriteLine` instead of `ILogger`
~20 call sites, output goes to STDOUT. Filtering by level, scoping by request, or shipping elsewhere is impossible.

**Rule:** in new code use `ILogger<T>`. When you touch a file with `Console.WriteLine`, replace those calls if it's safe.

### 16. Static `_practiceCodes` list in `DataBaseContext`
Grows unboundedly as new tenants are onboarded; never cleared. Connection-pool pressure if it grows large.

**Rule:** don't write new code that adds entries here — let the existing logic manage it. If a fix is in scope, replace with a `ConcurrentDictionary` of known practice codes seeded at startup.

### 17. Permission UI directive does not exist
The UI shows every button to every user. Server enforcement is not consistent (see #2).

**Rule:** if you add an action that must be restricted, restrict it server-side AND hide it client-side once a permission directive lands. Until then, name the endpoint and document the restriction.

### 18. `useHash: true` SPA routing
URLs don't reflect tab state. Users can't bookmark anything past `#/billing`.

**Rule:** don't change this without a backend nginx update; the `/api/*` proxy depends on the host's path layout.

### 19. Two parallel implementations of "the same thing"
`bulk-statement/` + `bulk-statement11/`. `payment/` + `old_payment_screen/`. Both compiled in.

**Rule:** when editing in this area, **first** find which file the running app actually renders (open the tab in the running UI, then trace from `app.module.ts`). Do not assume the newer-named one wins.

### 20. JWT "small token" stored in MemoryCache
If the API restarts (Coolify rolls a container), all logged-in users 401 mid-session and lose their work because of #5/#7. Cache lifespan is the JWT's own expiry.

**Rule:** plan deploys for off-hours, or send users to login before deploys. Don't extend the JWT lifetime to mask this — just plan around it.

## ⚪ Low

### 21. Heavy commented code in production files
- `BaseRepository.cs:111–122` — alternate Update implementation
- `SecuredFilterAttribute.cs:58–75` — the disabled permission filter
- `provider.component.ts`, `billing-info.component.ts` — large blocks

**Rule:** don't add to these. If you touch a file with commented blocks that have no `// TODO`/`// HACK` rationale, deletion is fine in a small follow-up.

### 22. Loose typing in UI services
`Observable<any>` everywhere. Type errors only surface at runtime.

**Rule:** in new services, use the actual model interface as the generic parameter. Don't migrate the old code unless it's in your task scope.

### 23. No tests
The API has one (mostly empty) test project; the UI has 34 stub `.spec.ts` files. There is no safety net.

**Rule:** when fixing a non-trivial bug, write a regression test as part of the fix. New features should ship with at least an integration-level test if reasonable.

### 24. Old framework versions
.NET Core 2.1 (out of support), Angular 7 (multiple majors behind), node-sass 4.x, Bootstrap 3. Upgrades are out of scope of normal feature work but track the cumulative debt.

**Rule:** don't introduce any new dependency that requires .NET Core 3+ or Angular 8+. When you do propose an upgrade, plan the LTS jump (.NET 8, Angular 17+) rather than a one-step bump.

## Checklist before merging a non-trivial change

- [ ] No new call to `ExecuteStoredProcedureAsync` with user-supplied input.
- [ ] No new use of `DateTime.Now` for audit/timestamp fields.
- [ ] If the change adds a query, it filters by `LoggedUser.PracticeId` where the table is per-practice.
- [ ] If the change adds a controller action, it does not return `ex.Message` to the client.
- [ ] If the change adds an Angular component, every `subscribe` is paired with cleanup.
- [ ] If the change touches an SP name, both `PZ_Report.Command` and `Scrub.StoredProcedure` were grepped.
- [ ] If the change touches auth, the JWT secret is sourced from configuration, not a literal.
- [ ] If the change touches `appsettings.Development.json`, no production credentials were added.
- [ ] If the change touches `pi-lib`, the library was rebuilt before the apps were tested.
- [ ] If two parallel implementations exist (`payment/` vs `old_payment_screen/`, etc.), the live one was edited.
