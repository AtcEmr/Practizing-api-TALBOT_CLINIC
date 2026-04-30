# API Architecture — Practizing .NET Backend

This is a deep reference. For orientation, start at [SYSTEM_OVERVIEW.md](./SYSTEM_OVERVIEW.md). For "how do I add X", go to [RECIPES.md](../conventions/RECIPES.md). For risks, [SECURITY_AND_RISKS.md](./SECURITY_AND_RISKS.md).

## 1. Solution layout

`PractiZing.sln` contains 9 service projects + shared layers. **Each service has the same 3-tier shape:**

```
ServiceName/
├── PractiZing.Api.{ServiceName}/             # Controllers, Startup, appsettings
├── PractiZing.BusinessLogic.{ServiceName}/   # Repositories, Services, DI extensions
└── PractiZing.DataAccess.{ServiceName}/      # Tables (entities), DTOs, Views, ValidationErrorCodes
```

Cross-cutting:
- `Base/PractiZing.Base/` — interface contracts (`I{Entity}`, `I{Entity}Repository`, `IStamp`, `IPracticeDTO`, `IUniqueIdentifier`)
- `Common/PractiZing.Api.Common/` — Startup helpers (`ConfigureCommonService`, `ConfigureAuthServices`, `AddSwaggerService`)
- `Common/PractiZing.BusinessLogic.Common/` — `BaseRepository<T>`, `ModuleBaseRepository`, transaction provider
- `Common/PractiZing.DataAccess.Common/` — `DataBaseContext`, identity model, stamp/practice mixins
- `EDIFabric/`, `lib/` — vendored EdiFabric SDK + custom HIPAA templates
- `Sftp/PractiZing.Sftp/` — SFTP wrapper for clearinghouse upload/download

**Hard rule: services do not reference each other's DataAccess or BusinessLogic projects.** Cross-service interaction is HTTP or DB. If you find yourself adding a project reference between two services, stop and rethink.

## 2. The 9 services

| Service | Purpose | Notable repos / files |
|---|---|---|
| `SecurityService` | Login, JWT, users, roles, permissions | `LoginController`, `PractiZingJwtTokenHandler`, `IdentityUser` |
| `MasterService` | All master/reference data | `CptCodesRepository`, `ProviderRepository`, `InsuranceCompanyRepository`, `FeeScheduleRepository`, `ConfigSettingRepository` |
| `PatientService` | Patient demographics & cases | `PatientRepository`, `PatientCaseRepository`, `InsurancePolicyRepository` |
| `ChargePaymentService` | Charge/payment/voucher/batch + scrubs + bank reconciliation + integrations | `ChargesRepository` (3000+ lines), `PaymentRepository`, `VoucherRepository`, `ClaimBatchRepository`, `BankReconciliationRepository`, `PlaidPaymentRepository`, `MethaSoftInvoiceRepository`, `DynmoPaymentsRepository`, `ChasePaymentsRepository` |
| `ClaimService` | Claim CRUD, ClaimView, 837 generation | `ClaimRepository`, `ClaimViewRepository`, `ScrubErrorRepository` |
| `ERAService` | 835 parsing, ERA root, payment-from-ERA posting | `ERARootRepository`, `ERARequestService` (calls external ERA fulfillment URL) |
| `DenialManagementService` | Denial queue, dashboard, follow-up assignment | `DenialQueueRepository` |
| `ReportService` | RDLC dispatch, statements, charge-stat | `ReportRepository`, `ChargeStatRepository`, `StatementFileService` |
| `HostService` | Cross-cutting utilities (ZIP lookup etc.) | `ZipCodeLookupRepository` |

## 3. Bootstrap & DI

Every `Startup.cs` follows the same shape:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddCommonService(Configuration);          // shared DI (DB, JWT, ILoginUser, MemoryCache)
    services.Add{Service}Repositories();               // service-local repository registrations
    services.Add{Service}();                           // service-local services
    services.AddSwaggerService();
}
```

`AddCommonService` (Common/PractiZing.Api.Common/ConfigureCommonService.cs) wires:
- `DataBaseContext` — **scoped per request**, opens connection from the practice code on the host header
- `ILoginUser` (`IdentityUser`) — **transient**, reads claims out of `HttpContext.User`
- `ITransactionProvider` — scoped
- `MemoryCache` — scoped
- JWT auth via `AddJwtAuthentication()` (custom token validator that swaps "small token" for cached full claims)

The repository registration pattern: each service has a `*RepositoryCollectionExtension.cs` that calls `services.AddScoped<I{Entity}Repository, {Entity}Repository>()` for every repo. **There is no assembly scan.** A new repository must be added to the extension method explicitly or it won't resolve.

## 4. Data access conventions

### 4.1 The base class
Almost every repo inherits `BaseRepository<T>` (`Common/PractiZing.BusinessLogic.Common/BaseRepository.cs`). It exposes:
- `Connection` — OrmLite connection from `DataBaseContext`
- `LoggedUser` — current `ILoginUser`
- CRUD: `GetById`, `AddNewAsync`, `Update`, `UpdateAsync`, `DeleteByIdAsync`
- `SetUserStamp(entity, isUpdate)` — automatically populates audit columns when an entity implements `ICreatedStamp` / `IModifiedStamp`. **Uses `DateTime.Now` (local), not UTC.**
- `ExecuteStoredProcedureAsync<T1>(spName, params object[] args)` — string-concat SP runner. **Vulnerable to injection if any arg is untrusted.** Documented in [STORED_PROCEDURES.md §2.1](../../STORED_PROCEDURES.md#21-pattern-a--baserepositoryexecutestoredprocedureasync-most-common).

### 4.2 Multi-tenancy
- The HTTP `Host` header determines the practice code → `DataBaseContext` chooses connection string.
- `ILoginUser.PracticeId` (from JWT) is the in-app filter id. Some repos filter by it; some don't. **When you add a query, explicitly filter by `LoggedUser.PracticeId` if the table is per-practice.** Do not assume a default of 1 (the system default if missing — a bug, not a feature).

### 4.3 Tables
- OrmLite `[Alias("table_name")]` decoration on every entity class.
- `PZ_*` is the prefix for system/security tables (PZ_User, PZ_Role, PZ_Module, PZ_ModulePermission, PZ_UserPermission, PZ_UserRole, PZ_UserAuthentication, PZ_Report).
- Views use `vw_` prefix.
- `Scrub` is the dispatch table for claim-scrub rules.
- `IsActive` exists on most config tables for soft-delete semantics; not consistent across all entities.

### 4.4 Three SP invocation patterns
See [STORED_PROCEDURES.md §2](../../STORED_PROCEDURES.md#2-sp-invocation-patterns-in-the-api). Short form:
- **Pattern A** — `ExecuteStoredProcedureAsync` (default; risky for untrusted input)
- **Pattern B** — Raw `SqlCommand` + `CommandType.StoredProcedure` + `Parameters.AddWithValue` (use this when input is untrusted, when you need a `DataTable`, or when a TVP/scrub-style parameter is involved)
- **Pattern C** — Inline `EXEC` SQL string (legacy; use Pattern B instead in new code)

### 4.5 DB-dispatched SP names
Two tables hold SP names that the C# code looks up at runtime:
- `PZ_Report.Command` — every entry in the Reports menu
- `Scrub.StoredProcedure` — every claim-scrub rule

When you rename or drop a stored procedure, **grep BOTH the C# code AND those tables**. See [STORED_PROCEDURES.md §3.5–3.6](../../STORED_PROCEDURES.md#35-reports-dispatched-dynamically-via-pz_reportcommand-pattern-24).

## 5. Controller conventions

- Routing: `[Route("api/[controller]")]`. Controller class names are the route segment minus `Controller`.
- Auth: every controller inherits `SecuredRepositoryController<TRepository>` which carries `[Authorize]`. **The permission filter (`SecuredFilterAttribute`) is currently commented out**, so authentication passes ⇒ access is granted; role/permission checks DO NOT run at the controller. Don't write code that depends on them.
- Error handling: try/catch around each action. `EntityException` → `StatusCode(400, ex.ValidationCodeResult)`. Anything else → `StatusCode(500, ex.Message)`. **`ex.Message` is exposed to the client** — do not put internal data in exception messages.
- Action method shape:
  ```csharp
  [HttpGet("by/{id}")]
  public async Task<IActionResult> GetById(long id)
  {
      try {
          var result = await Repository.GetById(id);
          return Ok(result);
      }
      catch (EntityException ex) { return StatusCode(400, ex.ValidationCodeResult); }
      catch (Exception ex)       { return StatusCode(500, ex.Message); }
  }
  ```

## 6. Auth flow

1. UI POSTs `/api/Login` with `{ username, password }`.
2. `LoginController` forwards to a configured external auth endpoint (Catalyst/EMR).
3. On success, the API builds a JWT with claims (Id, FirstName, UserName, PracticeId, RoleIds, EMR creds, etc.).
4. The full JWT is **cached in MemoryCache** under a "small token" key.
5. The small token is returned to the UI.
6. UI sends the small token in `Authorization: bearer <smallToken>`.
7. `PractiZingJwtTokenHandler.GetToken()` swaps small → full at validation time.

**Security caveats** ([SECURITY_AND_RISKS.md](./SECURITY_AND_RISKS.md)):
- JWT signing key is hardcoded in `ConfigureAuthServices.cs`.
- EMR credentials live in JWT claims; UI sees them.
- Permission filter is disabled.

## 7. Background work

There is none in code. No `IHostedService`, no Hangfire, no Quartz. Long-running endpoints (Excel exports, batch scrubs, charge-stat refresh) **block the HTTP request thread**. Scheduled work runs as SQL Agent jobs on the DB host. If you add a "every 5 minutes" feature, your only in-app option today is to add `IHostedService` — there is no precedent in this codebase, so think before introducing one.

## 8. EDI / X12

- **Outbound 837**: `ClaimService` builds the file using `EdiFabric.Templates.Hipaa` + `PractiZing.EdiFabric.Custom`. Triggered from ClaimBatch endpoints.
- **Inbound 835**: `ERAService.ERARootRepository` parses ERAs, then matches payments → charges, posts to DB.
- Files move via SFTP (`PractiZing.Sftp`) to/from the clearinghouse.

When you touch EDI, watch for:
- HIPAA spec versions (5010 vs 4010) in the templates project.
- The custom validators in `PractiZing.EdiFabric.Custom` — claim type mapping is project-specific.

## 9. Logging & observability

- `ILogger<T>` is injected in some controllers but rarely used.
- `Console.WriteLine` is the de facto logger in many places — output goes to Docker STDOUT and shows up in Coolify.
- No correlation-ID middleware, despite the UI sending `_rid` on every request. The header reaches the API but no code reads it.
- Serilog is in package references but not wired up to a sink.

If you add a new feature, prefer `ILogger<T>` over `Console.WriteLine`. If you add an outbound HTTP call, log the upstream status code and response time.

## 10. Build & deploy

- Target: **.NET Core 2.1 (out of support since Aug 2021)**.
- Single `Dockerfile` parameterized by `SERVICE_PROJECT` and `SERVICE_DLL` build args. One image per API service.
- `docker-compose.yaml` runs all 8 service containers + a shared Coolify proxy network.
- Container port: `8080`. Host bindings start at 8081 (see `coolify/`).
- Connection strings, JWT secret (when overridden), API base URL come from environment variables. `appsettings.Development.json` is a dev-only fallback that contains a checked-in plaintext DB password — do not let production use it.

## 11. Naming & file conventions

| What | Pattern | Where |
|---|---|---|
| Entity interface | `I{Entity}` | `Base/PractiZing.Base/Entities/{Service}/I{Entity}.cs` |
| Entity class | `{Entity}` with `[Alias("table")]` | `{Service}/PractiZing.DataAccess.{Service}/Tables/{Entity}.cs` |
| Repository interface | `I{Entity}Repository` | `Base/PractiZing.Base/Repositories/{Service}/I{Entity}Repository.cs` |
| Repository implementation | `{Entity}Repository : BaseRepository<{Entity}>, I{Entity}Repository` | `{Service}/PractiZing.BusinessLogic.{Service}/Repositories/{Entity}Repository.cs` |
| Service class (non-CRUD logic) | `{Entity}Service : I{Entity}Service` | `{Service}/PractiZing.BusinessLogic.{Service}/Services/{Entity}Service.cs` |
| Controller | `{Entity}Controller : SecuredRepositoryController<I{Entity}Repository>` | `{Service}/PractiZing.Api.{Service}/Controllers/{Entity}Controller.cs` |
| DI extension | `Add{Service}Repositories`, `Add{Service}Services` | `{Service}/PractiZing.BusinessLogic.{Service}/{Service}RepositoryCollectionExtension.cs` |

To add a new endpoint end-to-end, follow the recipe in [RECIPES.md → Add an API endpoint](../conventions/RECIPES.md#add-an-api-endpoint).

## 12. Anti-patterns to avoid in new code

1. Calling `ExecuteStoredProcedureAsync` with any user-supplied string. Use Pattern B (raw `SqlCommand` + parameters).
2. Returning `ex.Message` to the client. Log server-side; return a generic error.
3. Using `DateTime.Now` for new audit/timestamp columns. Use `DateTime.UtcNow`.
4. Adding a project reference between two `*.BusinessLogic.{Service}` projects. Cross-service should be HTTP or DB.
5. Assuming the user can't reach an endpoint because of `[Authorize]` permissions. They can — the permission filter is disabled.
6. Forgetting to register a new repository in the DI extension method. There is no assembly scan; missing registrations only fail at runtime.
7. Forgetting to filter by `LoggedUser.PracticeId` on tables that are per-practice. `DataBaseContext` picks the right DB, but in-DB row scoping is repository code's job.
8. Using `.GetAwaiter().GetResult()` to "convert" async to sync. Use `await` end-to-end.
