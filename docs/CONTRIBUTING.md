# Contributing / Developer Setup

This is a working guide for someone setting up a dev environment from
scratch and making their first change.

## Prerequisites

| Tool | Version | Why |
|---|---|---|
| .NET Core SDK | **2.1** (latest patch, `2.1.819` works) | Target framework. .NET 6/8 SDKs CAN restore + build, but use 2.1 to match prod |
| Visual Studio 2019 (Windows) or Rider | any recent | IDE with `.sln` support; VS Code works for editing but debugging multi-project is awkward |
| SQL Server | 2016+ | Local instance, Express edition is fine |
| Git | any | |
| Docker Desktop | optional | Needed only if you want to run via compose |

> ⚠️ **.NET Core 2.1 is out of support** since Aug 2021. SDK still installable from Microsoft's archive: https://dotnet.microsoft.com/en-us/download/dotnet/2.1
>
> Once the project is upgraded to .NET 6 or 8 LTS this section can change.

## Get the code

```bash
git clone https://github.com/AtcEmr/Practizing-api-TALBOT_CLINIC.git
cd Practizing-api-TALBOT_CLINIC
```

The repo is large (>500 MB checkout) because of the proprietary DLLs in
`lib/` and the EdiFabric source/templates.

## Build everything

From the repo root:

```bash
dotnet restore PractiZing.sln
dotnet build PractiZing.sln --configuration Debug
```

Common first-time build failures and their fixes are in
[`TROUBLESHOOTING.md`](TROUBLESHOOTING.md). The most likely ones for a
fresh clone:

- `error : System.Runtime.CompilerServices.Unsafe doesn't support netcoreapp2.1` — fixed by `Directory.Build.props` at repo root, but if you delete that file you'll see this.
- `error NU1605: Detected package downgrade: ...Unsafe from 6.0.0 to 4.5.3` — caused by another package pulling v6 transitively; pin it the same way MimeKit was pinned in `Common/PractiZing.BusinessLogic.Common.csproj`.
- `error MSB3245: Could not resolve "EdiFabric.Core"` — would only happen if `HostService.Api.csproj` or `ClaimCreator.Prof.csproj` lost their `lib/` HintPath redirect. See [`TROUBLESHOOTING.md`](TROUBLESHOOTING.md).

## Configure local settings

Each Api project has an `appsettings.Development.json`. **These files are
currently committed with real-ish credentials** (🔴 see [`TROUBLESHOOTING.md`](TROUBLESHOOTING.md))
— treat them as templates and fill with your own local SQL Server
connection string before running. They look like:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=...;Initial Catalog=PI2_TEMP;User id=...;Password=...;",
    "PracticeCentralDBContext": "Data Source=...;Initial Catalog=PracticeCentral;..."
  },
  "ApplicationUrl": "http://localhost:5000",
  "tempLabReportFolder": "C:\\Projects\\Attachments\\",
  "UIUrl": "http://localhost:4200/",
  "AttachmentFolder": "attachments"
}
```

You'll need a local SQL Server with two databases populated:

- `PracticeCentral` — has the `PracticeCentralPractice` table listing every tenant practice and its DB connection string. Schema is in `ConfigSetting.sql` at the repo root.
- A per-practice DB (often called `PI2_TEMP` in dev). Schema is in `AppSetting.sql`.

Note `PI2_TEMP` is a common dev/QA database name; production uses
practice-specific names. The migration approach in this repo is "run
the SQL files manually" — there is no EF migration story.

## Run a single service

You can run any service standalone for a focused dev loop:

```bash
cd ChargePaymentService/PractiZing.Api.ChargePaymentService
dotnet run
```

It listens on the URL from `ApplicationUrl` in `appsettings.Development.json`
(default `http://localhost:5000`). Swagger at `/swagger`.

But running a service alone has caveats:

- **No JWT auth wired**. `[Authorize]` decorators on its controllers will return 401 because no auth scheme is registered. To bypass for dev, add `[AllowAnonymous]` to specific endpoints, or run HostService instead.
- **No practice loading**. The multi-tenant lookup happens in HostService's startup. The repository code expects `_practices` to be populated. Single-service runs will work for endpoints that use only `DefaultConnection`.

## Run the full stack via HostService

```bash
cd HostService/HostService.Api
dotnet run
```

HostService listens on whatever URL its config has set (no `ApplicationUrl`
key by default; falls back to `http://localhost:5000`). Hit
`http://localhost:5000/swagger` for the aggregated Swagger UI (set
`UseSwagger: true` in config).

You can also run via Docker Compose for a closer-to-prod environment:

```bash
docker network create coolify       # one-time, on a fresh machine
cp .env.example .env                 # then edit .env
docker compose build                 # ~15 min cold
docker compose up -d
docker compose logs -f host
```

## Adding a new feature

The naming and folder layout is rigid. Match it.

### Add a new controller endpoint

In `<ServiceName>/PractiZing.Api.<ServiceName>/Controllers/<NewController>.cs`:

```csharp
[Route("api/[controller]")]
public class WidgetController : SecuredRepositoryController<IWidgetRepository>
{
    public WidgetController(IWidgetRepository repo) : base(repo) { }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }
        catch (EntityException ex) { return StatusCode(400, ex.ValidationCodeResult); }
        catch (Exception ex)       { return StatusCode(500, ex.Message); }
    }
}
```

> **Don't keep copying the try/catch boilerplate forever.** A global
> exception filter would clean this up — see "Modernization candidates"
> in [`TROUBLESHOOTING.md`](TROUBLESHOOTING.md). For now, match the
> existing pattern so nothing surprises in code review.

### Add a new repository

1. Create the entity in `<ServiceName>/PractiZing.DataAccess.<ServiceName>/Tables/Widget.cs` (POCO with `[Alias("dbo.Widget")]`).
2. Create the interface in `Base/PractiZing.Base/Repositories/<ServiceName>/IWidgetRepository.cs`.
3. Implement in `<ServiceName>/PractiZing.BusinessLogic.<ServiceName>/Repositories/WidgetRepository.cs` extending `ModuleBaseRepository<Widget>`.
4. Register DI in `<ServiceName>/PractiZing.BusinessLogic.<ServiceName>/PractiZing<ServiceName>RepositoryCollectionExtension.cs` — there's an `AddXxxServiceRepositories(this IServiceCollection)` extension method per service.

### Add or change a SQL table

There's no migration tooling. Edit `AppSetting.sql` or `ConfigSetting.sql`
at the repo root, then run the diff manually against your dev DB. For
production, that SQL needs to be run as part of the deploy process —
which is currently a manual step. Plan accordingly.

## Conventions

- **Controllers** keep one `try`/`catch (EntityException)`/`catch (Exception)` block per action. Don't add new patterns; we'll consolidate later.
- **Repositories** inherit `ModuleBaseRepository<T>`. They get `Connection`, `LoggedUser`, and `ValidationErrorCodes` from the base.
- **Routes** are `[Route("api/[controller]")]`. The controller class name minus "Controller" becomes the route segment.
- **DTOs** vs **Entities**: `Tables/` are DB-bound POCOs. `Objects/` are request/response DTOs. Don't expose `Tables/` types directly to controllers if you can help it.
- **Filenames** mostly follow PascalCase. There are typo-bound exceptions (`MasterServcie` namespace, `BussinessLogic` folder for ERAService, `EdiFrabric.Custom` folder). They're load-bearing in references — don't rename without a sweeping refactor.

## Testing

There are 9 `*Tests*.cs` files across the repo. There is no real test
coverage. Don't pretend `dotnet test` is a quality gate — it isn't for
this codebase yet. If you add tests, target `xUnit` and put them in a
new `<ServiceName>.UnitTests` project.

## Logging

`ILogger` is wired but barely used. HostService writes to
`Logs/<DateTime>.txt` files via `loggerFactory.AddFile(...)` (custom
file-logging extension). All other logging is `Console.WriteLine` or
`logger.LogInformation`. Coolify captures stdout and stderr.

## Pre-commit

There are no git hooks, no pre-commit linters, no CI configured in this
repo as of this doc. If you add CI:

- Pin .NET SDK version (`global.json` in repo root would help — it's not currently there)
- `dotnet build` is enough for compile validation
- The Docker build (`docker compose build`) is the only "does it really build" smoke test today

## When you're done

- Match commit message style of recent commits
- Push to a feature branch
- Open a PR. There's no review automation; ask a teammate.
- The `coolify` branch is what Coolify auto-deploys. If you merge to `main`, it does NOT auto-deploy. (Move that branch only when you're confident.)
