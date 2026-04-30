# HostService

**Folder**: `HostService/HostService.Api/`
**csproj**: `HostService.Api.csproj`
**Container name in compose**: `practizing-host`

## Purpose

The aggregator and the de facto production binary. HostService:

- Issues JWT bearer tokens (`/token` and `/tokenAzure` endpoints)
- Loads every practice's DB connection string at startup from `PracticeCentral`
- Configures CORS, response compression, request localization
- Serves attachment files via static-files middleware
- Hosts the controllers from every other Api service via project references

In production, you typically run **only HostService**; the other 7 service
containers are redundant when HostService is up. They're in compose for
local-dev flexibility and to give you the option of horizontally
splitting later.

## What it owns

HostService has **no controllers of its own**. The `Controllers/` folder
in the project is empty; ASP.NET Core MVC discovers controllers from the
referenced Api projects' assemblies via the default `ApplicationParts`
provider.

## Key parts of `Startup.cs`

Read top-to-bottom. Highlights:

| Line(ish) | What | Notes |
|---|---|---|
| 53 | `secretKey = "JWT!Secret#As#perMYChoiCE!123"` | 🔴 Hardcoded JWT HMAC key. Used for both token issuance and validation. See [`../TROUBLESHOOTING.md`](../TROUBLESHOOTING.md). |
| 80–85 | `var connectionString = Configuration.GetConnectionString("DefaultConnection")` | The root connection (the *first* practice's DB). |
| 86–87 | `var sqlPracticeCentralDbFactory = new OrmLiteConnectionFactory(...)` | OrmLite's per-tenant connection factory. |
| 100–106 | Practice loader: `_practices = service.GetAllPractices().Result` and `RegisterConnection(practice.PracticeCode, ...)` | 🟡 **Synchronous DB call at boot**; container fails to start if PracticeCentral is unreachable. |
| 110+ | `services.AddResponseCompression(...)` | gzip on responses. |
| 125 | `services.AddMvc(...).SetCompatibilityVersion(2.1)` | The version pin matters; don't bump without code review. |
| 132+ | `ConfigureRepositoriesAndService(services)` | DI registrations: `AddChargePaymentServiceRepositories`, `AddPatientServiceRepositories`, etc. — calls every other service's DI extension. |
| 167+ | `ConfigureErrorCodes(services)` | Every service's `ValidationErrorCodes` is registered as a singleton. |
| 182 | `loggerFactory.AddFile($"Logs/{date}.txt")` | 🟡 Custom file logger; logs are NOT on a Docker volume; lost on restart. |
| 192–196 | `app.UseCors(b => b.AllowAnyOrigin()...)` | 🟡 Wide-open CORS. |
| 198 | ServiceStack license registration | 🟢 Expired 2019. |
| 207–217 | `DefaultFilesOptions` + `UseStaticFiles` for attachments | The path math here matters; see [`../CONFIGURATION.md`](../CONFIGURATION.md) "Path.Combine subtlety". |
| 234–244 | `userAuthRepository.SetAllInCache(_practices)` | Preloads logged-in user cache. |
| 250–278 | `app.UseSimpleTokenProvider(new TokenProviderOptions { Path = "/token", ... })` | Token endpoints. Two of them: `/token` (basic auth) and `/tokenAzure` (Azure AD auth — username, password ignored). 30-day expiry. |

## Endpoints

HostService exposes:

- `POST /token` — username + password → JWT
- `POST /tokenAzure` — Azure AD token exchange (incomplete; SSO flow not finished)
- Everything else served by HostService is from referenced services' controllers — see those services' docs.

## Dependencies

`HostService.Api.csproj` references:

```
Base/PractiZing.Base
Common/PractiZing.Api.Common
Common/PractiZing.BusinessLogic.Common
Common/PractiZing.DataAccess.Common
ChargePaymentService/PractiZing.Api.ChargePaymentService
ChargePaymentService/PractiZing.BusinessLogic.ChargePaymentService
DenialManagementService/PractiZing.Api.DenialService
ERAService/PractiZing.Api.ERAService
MasterService/PractiZing.Api.MasterService
PatientService/PractiZing.Api.PatientService
ReportService/PractiZing.Api.ReportService
ReportService/PractiZing.BusinessLogic.ReportService
SecurityService/PractiZing.Api.SecurityService
SecurityService/PractiZing.BusinessLogic.SecurityService
ClaimService/PractiZing.ClaimCreator.Prof
EDIFabric/EdiFabric.Templates.Hipaa (transitively)
```

External DLLs referenced (`HintPath`):
- `lib/EdiFabric.Framework/DLLs/net45/EdiFabric.Core.dll`
- `lib/EdiFabric.Framework/DLLs/net45/EdiFabric.Framework.dll`

## Known gotchas

- **JWT secret is hardcoded** — see [`../TROUBLESHOOTING.md`](../TROUBLESHOOTING.md) 🔴
- **Boot crashes if `PracticeCentral` unreachable** — see "Synchronous DB call at boot" above
- **No `/health` endpoint** — Coolify falls back to TCP port checks
- **The original `EDIFabric/Packages/` HintPath was broken** (gitignored folder); already fixed in `coolify` branch by redirecting to `lib/`
- **In compose, this is `practizing-host`**; the other services use `practizing-<servicename>` — match this when adding a new service to compose
