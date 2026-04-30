# Services Index

Eight projects under the umbrella of the API solution. Seven of them are
HTTP services with their own Api/BusinessLogic/DataAccess triplets;
**ClaimService** is a library only.

In production, **`HostService` runs as the single binary** that hosts
controllers from every other Api project (via project references and ASP.NET
Core MVC's automatic `ApplicationParts` discovery). The other 7 services
exist primarily for compile-time isolation and the option of standalone
deployment.

| Service | Purpose | Folder | Read first |
|---|---|---|---|
| [HostService](HostService.md) | Aggregator: JWT, multi-tenant DB loading, hosts every controller | `HostService/` | If you need to understand auth, request entry, or startup |
| [ChargePaymentService](ChargePaymentService.md) | The biggest service. Charges, claims, payments, ERA, vouchers, fee schedules | `ChargePaymentService/` | If 80% of issues are billing-related, start here |
| [PatientService](PatientService.md) | Patient demographics, cases, insurance, statements | `PatientService/` | Patient-data issues |
| [SecurityService](SecurityService.md) | Login, users, roles, permissions | `SecurityService/` | Auth issues beyond JWT itself |
| [MasterService](MasterService.md) | Reference data: codes, providers, facilities, configs | `MasterService/` | Anything dropdown-related |
| [DenialManagementService](DenialManagementService.md) | Denial workflow: queues, action notes, AR groups | `DenialManagementService/` | Denial-management UI issues |
| [ERAService](ERAService.md) | Electronic Remittance Advice (835) parsing | `ERAService/` | When ERA imports break |
| [ReportService](ReportService.md) | Report definitions and execution. Library only — no controllers | `ReportService/` | Reports & dashboards |
| [ClaimService](ClaimService.md) | Library only. 837 EDI claim builders (Prof and Form) | `ClaimService/` | Claim-file format issues |

## Common patterns across all services

Every Api service has:

```
ServiceName/
├── PractiZing.Api.<ServiceName>/                ← controllers + Startup.cs
├── PractiZing.BusinessLogic.<ServiceName>/      ← repositories + service classes + DI extension
└── PractiZing.DataAccess.<ServiceName>/         ← Tables/, Objects/, Views/, ValidationErrorCodes
```

And every service's `Startup.cs` typically calls:

```csharp
services.AddCommonService(Configuration);                   // shared infrastructure
services.AddXxxServiceRepositories();                       // service-specific DI
services.AddXxxServices();                                  // service-specific DI
```

`AddCommonService` is the catch-all in `Common/PractiZing.BusinessLogic.Common/`. It registers `IDataBaseContext`, `ITransactionProvider`, AutoMapper, etc.

## Common file conventions

- **Controllers** end in `Controller.cs` and inherit `SecuredRepositoryController<TRepo>` from `Common/PractiZing.Api.Common/Controllers/`. The base provides the `Repository` property and the `[Authorize]` attribute.
- **Repositories** inherit `ModuleBaseRepository<TEntity>` from `Common/PractiZing.BusinessLogic.Common/`. The base provides `Connection`, `LoggedUser`, `ValidationErrorCodes`, common CRUD helpers.
- **Tables** (in `DataAccess/Tables/`) are POCOs decorated with ServiceStack OrmLite attributes (`[Alias("dbo.TableName")]`, `[PrimaryKey]`, `[AutoIncrement]`, `[References(typeof(...))]`).
- **Objects** (in `DataAccess/Objects/`) are request/response DTOs without DB attributes.

## How to read a service's docs

Each service page below has the same sections:

- **Purpose** — one paragraph
- **Key controllers** — what each controller covers
- **Key tables** — the data model
- **Notable repository methods** — cross-cutting / non-obvious ones
- **Dependencies** — what it pulls in from sibling services
- **Known gotchas** — service-specific quirks
