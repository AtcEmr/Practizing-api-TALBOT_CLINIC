# Configuration Reference

Every config key the API reads, where it's read, and what happens if it's
missing or wrong. ASP.NET Core 2.x's configuration provider stack reads:

1. `appsettings.json` (file, optional)
2. `appsettings.<Environment>.json` (file, optional)
3. Environment variables (override anything above)
4. Command-line args

Environment variables use **double underscore** (`__`) for nested JSON
paths. So `ConnectionStrings__DefaultConnection` overrides
`appsettings.json["ConnectionStrings"]["DefaultConnection"]`.

## Required configuration

These MUST be set in production. If absent, the named symptom occurs.

| Key | Type | Read by | If missing |
|---|---|---|---|
| `ConnectionStrings:DefaultConnection` | string | All services via `Common/.../DataBaseContext.cs`. Also HostService at startup. | All DB-touching endpoints throw `InvalidOperationException` with no readable error. |
| `ConnectionStrings:PracticeCentralDBContext` | string | HostService startup (`Startup.cs:104` reads practices) | HostService fails to start; container loops. |
| `ApplicationUrl` | string | `Common/PractiZing.Api.Common/UrlConfiguration.cs` | Service binds to default Kestrel URL (`http://localhost:5000` if not in container; `ASPNETCORE_URLS` env var also overrides) |
| `ASPNETCORE_URLS` | string env var | Kestrel itself | Falls back to `ApplicationUrl` config or default |
| `ASPNETCORE_ENVIRONMENT` | env var | ASP.NET Core | Defaults to `Production`. Set to `Development` for verbose errors. |
| `ValidIssuer` | string | HostService JWT validation, token endpoint | JWT validation rejects every token; logins succeed but every subsequent call 401s. |
| `ValidAudience` | string | HostService JWT validation, token endpoint | Same as above. |

## Optional configuration

| Key | Default | Read by | Effect |
|---|---|---|---|
| `UseSwagger` | `false` | `HostService/Startup.cs` | When `true`, exposes `/swagger`. **Never turn on in prod** — it leaks endpoint shapes. |
| `UIUrl` | (none) | (declared in `.env.example`, not actually consumed; CORS uses `AllowAnyOrigin()`) 🟡 | Currently no effect. Wire to `WithOrigins(Configuration["UIUrl"])` if you fix CORS. |
| `AttachmentFolder` | `attachments` | HostService static-files middleware | Combined with `AppDomain.CurrentDomain.BaseDirectory` via `Path.Combine`. Note: a leading `/` makes the result absolute (matches the Docker volume mount at `/attachments`); without leading `/`, it becomes `<app dir>/attachments`. The Docker `.env.example` sets `AttachmentFolder=/attachments` deliberately. |
| `tempLabReportFolder` | `C:\Projects\Attachments\` (Windows path 🟡) | Lab-report temp file logic | Linux containers will fail Windows paths. Override to `/tmp/labreports/` or similar in Linux env. |
| `SiteLocale` | `en-GB` | Request-localization middleware in HostService | Affects date/number formatting in some response paths. |
| `Logging:LogLevel:Default` | `Information` | Standard ASP.NET Core logging | |
| `Logging:LogLevel:Microsoft` | `Information` | Standard ASP.NET Core logging | Bumps Microsoft.* loggers down. |
| `Logging:IncludeScopes` | `false` | ASP.NET Core | |

## Configuration that's currently broken / hardcoded

These are env vars in `.env.example` that **don't actually flow to code**.
Setting them does nothing today. Each one is a code-change issue, not a
config issue.

| Env var | Where the hardcoded value lives | What to do |
|---|---|---|
| `JWT_SECRET` | `HostService/HostService.Api/Startup.cs:53` `secretKey = "JWT!Secret#As#perMYChoiCE!123"` 🔴 | Replace with `Configuration["Jwt:Secret"]` and read from env. Until then, secret is the same for every instance. |
| `AWS_ACCESS_KEY_ID`, `AWS_SECRET_ACCESS_KEY` | `ChargePaymentService/.../HistoryPaymentRepository.cs:32` constructor argument 🔴 | Constructor should inject `IConfiguration` and read keys. Today the keys have `"Test"` appended in source so DynamoDB calls fail. |
| `AWS_REGION` | Same constructor as above (hardcoded `Amazon.RegionEndpoint.USEast1`) | Same fix. |
| `JWT_ISSUER` | Set via `ValidIssuer` config — this part DOES work. The env var maps via .env.example into `ValidIssuer`. | Already wired. |
| `JWT_AUDIENCE` | Set via `ValidAudience` — also wired. | Already wired. |

## Per-service config matrix

Most services share the same baseline (logging, connection strings,
ApplicationUrl, ValidIssuer/Audience). What differs:

### HostService

Reads everything. The aggregator. Must have:
- Both `ConnectionStrings`
- `ValidIssuer`, `ValidAudience`
- `UseSwagger` (boolean)
- `AttachmentFolder`

### ChargePaymentService

In addition to the baseline:
- AWS DynamoDB credentials (currently hardcoded — see above)
- Stripe credentials (read from config in `Base/PractiZing.Base/`)
- Plaid credentials (read from config in `Repositories/PlaidPaymentRepository.cs`)
- SFTP credentials for Catalyst export (read in `Common/PractiZing.Sftp/`)
- HCFA form rendering settings

### PatientService

Baseline plus:
- HL7 ingestion endpoint settings (if used)
- Statement printing config

### Other services

Baseline only.

## Where to set values in production (Coolify)

In Coolify's web UI, the Application has an **Environment Variables**
tab. For each entry:

- Name: the env var name (e.g. `ConnectionStrings__DefaultConnection`)
- Value: the string
- **Mark as Secret** for credentials. Coolify masks secrets in logs.

Use the patterns in `.env.example` as your starting list.

For DB connections specifically, Coolify lets you create a "Database
Resource" alongside the Application. The resource has its own connection
string; copy it into `ConnectionStrings__DefaultConnection` in the
Application's env vars.

## Reading config from code

The standard ASP.NET Core 2.x pattern. All services do something like:

```csharp
public class MyRepository
{
    private readonly IConfiguration _configuration;

    public MyRepository(IConfiguration configuration) { _configuration = configuration; }

    public void DoThing()
    {
        var sftpHost = _configuration["Sftp:Host"];                // simple key
        var poolSize = _configuration.GetValue<int>("Pool:Size");  // typed
        var connStr  = _configuration.GetConnectionString("Foo");  // ConnectionStrings:Foo
    }
}
```

Inject `IConfiguration` if you need it. Don't read environment variables
directly via `Environment.GetEnvironmentVariable` — go through
`IConfiguration` so file-based config keeps working too.

## Inspecting effective config in a running container

```bash
# print the entire config (development environment)
docker exec practizing-host env | grep -E "ConnectionStrings|JWT|UI|AWS"

# or hit a debug controller you add temporarily
GET /api/Diagnostics/Config
```

Don't ship a `/Diagnostics/Config` endpoint to production unless it filters
secrets.
