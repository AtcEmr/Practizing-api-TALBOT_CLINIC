# Architecture

## TL;DR

- **8 ASP.NET Core 2.1 services** in one Git repo, one solution file.
- One **3-layer pattern** repeated in every service: `Api` → `BusinessLogic` → `DataAccess`.
- One **HostService** that references every other service's Api project and acts as the production aggregator (issues JWTs, loads practice connection strings, exposes Swagger).
- Two **SQL Server** databases: a per-practice DB (default tenant), and a `PracticeCentral` DB that lists every practice and its connection string.
- Inter-service calls happen mostly through **shared project references** (compile-time linking) rather than HTTP, so most "microservices" share their controllers' assemblies via `HostService`.
- External integrations: **AWS DynamoDB** (payment history), **Plaid** (bank linking for patient payments), **Stripe** (also payment processing — see `Base/PractiZing.Base/`), **EdiFabric** (EDI parsing for 837/835), **SFTP** to Catalyst (charge export), **HL7** message ingestion.

## Repository layout

```
Practizing-api-TALBOT_CLINIC/
├── Base/PractiZing.Base/                        # Domain entities, enums, interfaces — referenced by every service
├── Common/
│   ├── PractiZing.Api.Common/                   # Shared controllers (BaseRepositoryController, SecuredRepositoryController), interceptors, identity types, middlewares
│   ├── PractiZing.BusinessLogic.Common/         # Shared business logic (ParseParameter, ObjectConvertor, helpers, MimeKit-based mailer)
│   ├── PractiZing.DataAccess.Common/            # DataBaseContext, ModuleBaseRepository<T>, transaction provider
│   ├── PractiZing.Sftp/                         # SFTP helper (Catalyst export)
│   └── PractiZing.UnitTest.Common/              # Test base classes (almost no real tests use this)
├── ChargePaymentService/                        # By far the largest service
│   ├── PractiZing.Api.ChargePaymentService/     # Controllers, Startup
│   ├── PractiZing.BusinessLogic.ChargePaymentService/  # Repositories — ChargesRepository alone is ~3,600 lines
│   └── PractiZing.DataAccess.ChargePaymentService/      # Tables (one .cs per SQL table), Objects (DTOs), Views, ValidationErrorCodes
├── ClaimService/                                # NOT an API. Three libraries:
│   ├── PractiZing.ClaimCreator.Base/            # Shared 837 building blocks
│   ├── PractiZing.ClaimCreator.Form/            # 837I (institutional)
│   └── PractiZing.ClaimCreator.Prof/            # 837P (professional)
├── DenialManagementService/                     # Api / BusinessLogic / DataAccess + a UnitTest project
├── ERAService/                                  # Api / BusinessLogic (note typo: "BussinessLogic") / DataAccess
├── HostService/HostService.Api/                 # The aggregator — pulls every other Api csproj as ProjectReference
├── MasterService/                               # Reference data (CPT, ICD, providers, facilities, configs)
├── PatientService/                              # Patient demographics, cases, policies
├── ReportService/                               # Report definitions; library only (no controllers)
├── SecurityService/                             # Auth: login, users, roles, permissions
├── EDIFabric/                                   # EdiFabric source (rules, templates, custom)
├── lib/                                         # Pre-built proprietary DLLs (EdiFabric.Framework prebuilt, X12EDI.dll, Xfinium.Pcl)
├── PractiZing.sln                               # Solution that includes every project above
├── Dockerfile                                   # Parameterized — builds any service via SERVICE_PROJECT build-arg
├── Directory.Build.props                        # Repo-wide MSBuild prop pinning System.Runtime.CompilerServices.Unsafe to 4.5.3 for netcoreapp2.1 compat
├── docker-compose.yaml                          # 8 services + shared `coolify` external network
├── coolify/README.md                            # Coolify deploy instructions
└── docs/                                        # ← you are here
```

## The three-layer pattern

Each service repeats this structure:

```
ServiceName/
├── PractiZing.Api.<ServiceName>/                ← controllers + Startup
│   ├── Controllers/
│   │   └── XxxController.cs                     ← inherits SecuredRepositoryController<IXxxRepository>
│   ├── Program.cs                               ← reads ApplicationUrl from config
│   └── Startup.cs                               ← AddCommonService, AddXxxRepositories, AddXxxServices
├── PractiZing.BusinessLogic.<ServiceName>/      ← repositories + service classes
│   ├── Repositories/
│   │   └── XxxRepository.cs                     ← inherits ModuleBaseRepository<TEntity>
│   ├── Services/                                ← higher-level orchestrators (sometimes)
│   └── PractiZing<ServiceName>RepositoryCollectionExtension.cs   ← DI registrations
└── PractiZing.DataAccess.<ServiceName>/         ← tables, DTOs, views, validation codes
    ├── Tables/                                  ← one .cs per SQL table — POCO with [Alias("...")] attributes
    ├── Objects/                                 ← request/response DTOs
    ├── View/                                    ← SQL view representations
    └── ValidationErrorCodes.cs                  ← validation code dictionary
```

### How a request flows

```
Browser (UI)
  │
  │   HTTP /api/Charges?...
  ▼
Coolify Traefik (terminates TLS)
  │
  ▼
nginx (UI container) — reverse-proxies /api/* to ${API_URL}
  │
  ▼
HostService (or chargepayment service container)
  │
  │   Authentication middleware validates Bearer JWT
  │   Routing finds ChargesController
  ▼
ChargesController (PractiZing.Api.ChargePaymentService)
  │
  │   await this.Repository.GetAll(filter)
  │     [Repository = IChargesRepository, injected]
  ▼
ChargesRepository (PractiZing.BusinessLogic.ChargePaymentService)
  │
  │   _dbContext.Connection.Select<Charges>(...)
  │     [via ServiceStack OrmLite, sometimes Dapper, sometimes raw SqlCommand]
  ▼
SQL Server (per-practice DB resolved via DataBaseContext)
  │
  ▼
Result objects → controller → JSON response
```

The repository class is doing a *lot* of the work that would be in a
service layer in a cleaner design. See [`TROUBLESHOOTING.md`](TROUBLESHOOTING.md)
for "the repositories are de-facto service classes" — `ChargesRepository`
is 3,600 lines and orchestrates 17 dependencies.

## Multi-tenancy: how practices map to databases

```
ASPNETCORE config has DefaultConnection (per-practice DB) and PracticeCentralDBContext (lookup DB).

At HostService startup:
  HostService/Startup.cs:104 → service.GetAllPractices().Result    ← synchronous DB call at boot
    Reads every row of PracticeCentralPractice from PracticeCentral DB
    Each row has DBConnectionString
    Each is registered with OrmLiteConnectionFactory under PracticeCode

At request time:
  PractiZingIdentity (set by JWT validation) carries the practice code
  Repository code does dbFactory.OpenAsync(practiceCode) to pick the right DB
```

If `PracticeCentral` is unreachable at container start, HostService crashes
and Coolify will keep restarting it. There is no boot-time retry.

## How the services connect to each other

- **At compile time**: every service's `Api` csproj references its
  matching `BusinessLogic` and `DataAccess` csprojs. Some services'
  `BusinessLogic` ALSO references other services' `BusinessLogic` or
  `DataAccess` (for example, `ChargePaymentService.BusinessLogic`
  references `ClaimCreator.Prof` and Patient/Master DataAccess).
- **At runtime**: in production with `HostService` as the binary, every
  service's controllers + repositories live in a single process. They
  call each other via direct DI, not HTTP.
- **HostService.Api.csproj** project-references all 7 other Api csprojs.
  ASP.NET Core 2.x discovers their controllers via `ApplicationParts`
  default scanning — it picks up controllers from referenced assemblies
  that contain MVC types.

This is **not** truly distributed microservices. It's a modular monolith
with the option of running services individually for development.

## What `HostService` does that the others don't

`HostService/HostService.Api/Startup.cs` — open it and you'll see:

- JWT authentication (`AddJwtAuthentication`) — issues bearer tokens at `/token` and `/tokenAzure`
- The hardcoded HMAC `secretKey = "JWT!Secret#As#perMYChoiCE!123"` (🔴 see TROUBLESHOOTING.md)
- `_practices` startup loader (the boot-time DB call mentioned above)
- Response compression, CORS (`AllowAnyOrigin` — 🟡), file-attachment static-file middleware
- Custom request-localization middleware
- Memory cache + `userAuthRepository.SetAllInCache(_practices)` at startup (preloads all logged-in users)
- ServiceStack OrmLite license registration (🟢 expired 2019 but still functional)
- Calls `ConfigureRepositoriesAndService` which registers DI for every service (`AddChargePaymentServiceRepositories`, `AddPatientServiceRepositories`, …)

The other services have minimal `Startup.cs` and rely on `AddCommonService(Configuration)` (in `Common/PractiZing.BusinessLogic.Common`) for shared infrastructure. They do **not** register JWT auth themselves — meaning if you hit a service directly without going through HostService, `[Authorize]` decorators reject everything.

## External integrations

| Integration | Used by | How configured | Status |
|---|---|---|---|
| AWS DynamoDB | `ChargePaymentService/Repositories/HistoryPaymentRepository.cs` | Hardcoded keys in source (🔴 needs `IConfiguration` rewrite) | Broken — keys have `"Test"` appended |
| Plaid | `ChargePaymentService/Repositories/PlaidPaymentRepository.cs` | Configuration keys | Functional |
| Stripe | `Base/PractiZing.Base/` (Stripe.NET package) | Configuration keys | Functional |
| EdiFabric | `ClaimService/PractiZing.ClaimCreator.Prof/`, `ChargePaymentService/.../ClaimFileProcessService.cs` | DLL refs in `lib/` (proprietary, not on NuGet) | Functional |
| HL7 | `ChargePaymentService/.../ChargesController` (`AddCPTDesc` endpoint) | Inbound only — UI POSTs HL7-derived data | Functional |
| SFTP (Catalyst) | `ChargePaymentService/.../ChargesController` (`ExportExcelToCatalyst`) + `Common/PractiZing.Sftp/` | Configuration keys (host, user, key) | Functional |
| HCFA / 1500 form rendering | `ChargePaymentService/.../HcfaFormFieldRepository`, `lib/Xfinium.Pcl.6.7.0.00` | DLL ref | Functional |
| TrizettoReference | `ChargePaymentService/Connected Services/TrizettoReference/` (excluded from build) | WSDL-generated client | Disabled (csproj excludes the folder) |

## Data persistence and tooling

- **ServiceStack OrmLite** is the primary ORM. Most repositories use it for CRUD via `db.Select<T>(filter)`, `db.Insert(...)`, etc.
- **Dapper** is also referenced (via `ServiceStack.OrmLite.Dapper`) for some hand-tuned queries.
- **Raw `SqlCommand`** is used in a few reporting paths (e.g. `ChargesRepository.GetExcelForPatientDetailInsuranceAging`) to call stored procedures or run dynamically-built SQL. **One of these paths has a SQL injection (🔴 see TROUBLESHOOTING.md).**
- **`*DataSet.xsd`** files (e.g. `PI_ACCESSDataSet.xsd`) are .NET typed datasets; they're a legacy carry-over and barely used.
- **No EF Core / migrations** in the repo. Schema lives in `AppSetting.sql` and `ConfigSetting.sql` at the repo root and is presumed already deployed.

## Why "8 services" if HostService runs them all

Three reasons that surface when reading the code:

1. **Compile-time domain isolation**: each service's csproj only depends on what it needs. You can't accidentally have ChargePayment code call into Master internals — it has to go through Master's repository interface in `Base/`.
2. **Deployability optionality**: each Api project has its own `Program.cs` and `Startup.cs` with `Main`, so you *could* deploy them separately. The compose stack does this — 8 containers — but in practice HostService alone serves all routes.
3. **Reflection of org structure**: the "service" boundaries broadly match how features are organized (charges/payments, denials, ERA, master data). Useful for onboarding even if runtime is monolithic.

The build cost is real: each Docker image includes the entire
build context. 8 images means 8x the layer storage. If you decide
HostService is the only one you ship, you can comment out the other
seven services in `docker-compose.yaml`.
