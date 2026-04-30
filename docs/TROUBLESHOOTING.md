# Troubleshooting & Known Issues

This is the most important file in this folder. It captures every gotcha,
pre-existing bug, and operational pitfall surfaced during deployment
preparation. Read it before you start changing code.

Severity legend: 🔴 critical / 🟡 high / 🟢 medium / ⚪ informational

---

## Build issues

### 🔴 BUILD: `error : System.Runtime.CompilerServices.Unsafe doesn't support netcoreapp2.1`

**Cause**: NuGet's transitive resolver picks `System.Runtime.CompilerServices.Unsafe@6.0.0`, whose `targets` file actively errors on netcoreapp2.1.

**Fix** (already applied): `Directory.Build.props` at repo root pins the package to `4.5.3`.

```xml
<Project>
  <ItemGroup>
    <PackageReference Include="System.Runtime.CompilerServices.Unsafe" Version="4.5.3" />
  </ItemGroup>
</Project>
```

**If you see this error again**: a newly-added NuGet package transitively requires `Unsafe >= 5.0` or higher. Either upgrade the project to .NET 6/8 (proper fix), or pin `Unsafe` higher and risk a different conflict.

### 🔴 BUILD: `NU1605: Detected package downgrade: System.Runtime.CompilerServices.Unsafe from 6.0.0 to 4.5.3`

**Cause**: Some package in the dep graph has a hard floor on `Unsafe >= 6.0.0`, conflicting with the `Directory.Build.props` pin.

**The known offender**: MimeKit 4.x. Fixed by pinning MimeKit to `2.15.1` in `Common/PractiZing.BusinessLogic.Common.csproj`.

**If you see this with a different package**: identify the package via the error message, then either:

1. Pin the package to its last-netcoreapp2.1-compatible version
2. Move netcoreapp2.1 → 6/8 LTS (the real fix)

### 🔴 BUILD: `error MSB3245: Could not resolve "EdiFabric.Core"`

**Cause**: A `<HintPath>` points at `EDIFabric/Packages/`, which is gitignored by the root `.gitignore` rule `**/packages/*`. The folder doesn't exist on clean clones.

**Fix** (already applied to `HostService.Api.csproj` and `ClaimCreator.Prof.csproj`): redirect HintPaths to `lib/EdiFabric.Framework/DLLs/net45/`, where the same DLLs are already committed.

```xml
<Reference Include="EdiFabric.Core">
  <HintPath>..\..\lib\EdiFabric.Framework\DLLs\net45\EdiFabric.Core.dll</HintPath>
</Reference>
```

**If you see this in a new csproj**: same fix. Always reference DLLs from `lib/`, never `EDIFabric/Packages/`.

### 🟡 BUILD (UI): `npm rebuild` re-triggers broken nested `node-sass@4.10.0`

**Cause**: The lockfile pins node-sass to 4.10.0. There's no Node 14 prebuilt; download URLs 404 today; gcc 10 doesn't compile it from source.

**Fix** (already applied in UI `Dockerfile`):

```dockerfile
RUN npm ci --ignore-scripts ... \
 && rm -rf node_modules/@angular-devkit/build-angular/node_modules/node-sass \
 && npm install node-sass@4.14.1 --no-save ...
```

The `--ignore-scripts` skips the failing postinstall during `ci`. The nested broken copy is deleted so module resolution falls through to a top-level 4.14.1 (which DOES have a Node 14 prebuilt).

### 🟡 BUILD (UI): `error TS2307: Cannot find module 'pi-lib'`

**Cause**: `tsconfig.json` paths map `pi-lib` → `dist/pi-lib`. The library must be built first.

**Fix** (already applied): UI `Dockerfile` runs `ng build pi-lib` before the app build.

```dockerfile
RUN ng build pi-lib                        # <-- this first
RUN ng build --configuration=production
```

### ⚪ BUILD: filename casing

The Windows-developed code has typo'd folder/namespace names that are
load-bearing:

- `MasterServcie` (typo for `Service`) — used as a namespace
- `BussinessLogic` (typo for `Business`) — folder name for ERAService
- `EdiFrabric.Custom` (typo for `Fabric`) — folder name for `EDIFabric/`

**Don't rename them** without a sweeping refactor — every reference will
break.

---

## Runtime issues

### 🔴 RUNTIME: JWT secret hardcoded

**Where**: `HostService/HostService.Api/Startup.cs:53`

```csharp
private readonly static string secretKey = "JWT!Secret#As#perMYChoiCE!123";
```

**Impact**:
- Anyone with repo read access can forge any user's JWT.
- The `JWT_SECRET` env var I documented in `.env.example` is **not actually consumed by code** today.
- Rotating the secret requires a code change.

**Fix**: refactor to read `Configuration["Jwt:Secret"]` and bind from env. Wire into both the token issuer and the token validator. After fixing, set a strong secret in Coolify env.

### 🔴 RUNTIME: AWS keys hardcoded with `"Test"` appended

**Where**: `ChargePaymentService/PractiZing.BusinessLogic.ChargePaymentService/Repositories/HistoryPaymentRepository.cs:32`

```csharp
_client = new AmazonDynamoDBClient(
    "AKIA3JXRCLK5EZFUZGECTest",
    "2u+CgIqTpVY0n3Fdhcbi5uY96JOd2jnLQcVliQJQTest",
    Amazon.RegionEndpoint.USEast1);
```

**Impact**:
- The original key (without `"Test"`) is in git history. Treat as compromised — rotate.
- The current `"Test"`-suffixed key fails authentication. Any code path that calls history-payment endpoints will throw `AmazonDynamoDBException: The security token included in the request is invalid.`

**Fix**:
1. Rotate the original key in IAM. (Critical — it was at one point committed; assume captured.)
2. Inject `IConfiguration` into the constructor; read `AWS:AccessKeyId`, `AWS:SecretAccessKey`, `AWS:Region` from config.
3. Remove the hardcoded constructor literals.
4. Set the env vars in Coolify.

### 🔴 RUNTIME: SQL injection in report parameter parser

**Where**: `Common/PractiZing.BusinessLogic.Common/ParseParameter.cs:33-34`

```csharp
finalBody = finalBody.Replace("{" + foundToken + "}", "'" + tokenValue + "'");
```

**Used by**:
- `ChargesRepository.GetExcelForPostingPayments` (line ~2715) — reads template SQL from `Report` table, substitutes user-supplied values, runs as raw SQL via `SqlCommand.CommandText` with no parameterization.
- Several other report-generating endpoints.

**Impact**: any user input that flows through `ParseReport` and contains a single quote breaks out and injects SQL.

**Fix**: rewrite `ParseReport` to map `{name}` → `@name` and bind values via `SqlParameter`. Then change every call site to use parameterized commands.

### 🟡 RUNTIME: HostService crashes if DB unreachable at boot

**Where**: `HostService/HostService.Api/Startup.cs:104`

```csharp
_practices = service.GetAllPractices().Result;
```

**Impact**: synchronous DB call. If `PracticeCentral` is unreachable, this throws. Coolify will keep restarting the container indefinitely with no clear error in the health UI.

**Workaround**: ensure DB is up before pushing a deploy.

**Fix**: wrap in retry-on-startup, or move practice loading to first-request lazy load with caching.

### 🟡 RUNTIME: Stack traces leaked to API clients

**Where**: every controller has the pattern:

```csharp
catch (Exception ex)
{
    return StatusCode(500, ex.Message);
}
```

**Impact**: the response body to a 500 contains the exception message, which often includes table names, stored proc names, and file paths. Useful debug info; bad PHI/security exposure.

**Fix**: add a global exception filter (`app.UseExceptionHandler(...)`); log the exception with a correlation ID, return a generic message + the ID to the client.

### 🟡 RUNTIME: CORS allows any origin

**Where**: every `Startup.cs`

```csharp
app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
```

**Impact**: any website can have a logged-in user's browser call your API.

**Fix**: replace with `WithOrigins(Configuration["UIUrl"])`.

### 🟡 RUNTIME: `[AllowAnonymous]` on some controllers

**Sites**:

- `ChargePaymentService/.../ChargesController.cs:70` — commented out (`//[AllowAnonymous]`)
- `ChargePaymentService/.../ClaimBatchController.cs:92` — active

**Impact**: anonymous endpoints in a PHI service. Each one needs justification.

**Fix**: review each, document why anonymous is needed, or restrict.

### 🟡 RUNTIME: MimeKit 2.15.1 vs 4.7.1 API differences

**Where**: `Common/PractiZing.BusinessLogic.Common/PractiZing.BusinessLogic.Common.csproj`

**Background**: MimeKit was downgraded from 4.7.1 → 2.15.1 to be compatible with netcoreapp2.1. If any code calls APIs that exist only in 3.x or 4.x, runtime exceptions occur.

**To investigate**:
```bash
grep -rn "using MimeKit\|MimeKit\." Common/PractiZing.BusinessLogic.Common/ --include="*.cs"
```

**Fix**: either rewrite to 2.15.1 API, or upgrade .NET to 6/8 and re-pin MimeKit to 4.x.

### 🟡 RUNTIME: `Logs/` directory not on a volume

**Where**: HostService writes to `Logs/<DateTime>.txt` via custom file-logger extension.

**Impact**: every container restart loses logs.

**Fix**: add a `logs` named volume in `docker-compose.yaml` for the `host` service mounted at `/app/Logs`.

### 🟡 RUNTIME: `tempLabReportFolder` is a Windows path in committed config

**Where**: `appsettings.Development.json` (multiple services):

```json
"tempLabReportFolder": "C:\\Projects\\Attachments\\"
```

**Impact**: in a Linux container this path doesn't exist. Lab report file logic will throw.

**Fix**: override via env var to `/tmp/labreports/` or similar in production. Add to Coolify env.

### 🟢 RUNTIME: ServiceStack license expired

**Where**: every `Startup.cs`:

```csharp
ServiceStack.Licensing.RegisterLicense(@"6058-...,Expiry:2019-04-25...");
```

**Impact**: ServiceStack OrmLite still functions in newer versions but logs warnings. May affect throughput/scale limits in some versions.

**Fix**: renew license, move to `Configuration["ServiceStack:License"]`, set in env.

### 🟢 RUNTIME: `Path.Combine` with leading slash subtlety

**Where**: `HostService/HostService.Api/Startup.cs:201`

```csharp
string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
```

If `relativePath = "/attachments"` (absolute), result = `/attachments` (the second arg wins).
If `relativePath = "attachments"`, result = `<app dir>/attachments`.

The Docker setup deliberately sets `AttachmentFolder=/attachments` (with leading slash) so it lands on the volume mount. **If someone "fixes" this by removing the slash, attachments break.**

### 🟢 RUNTIME: Static file middleware double-slash

**Where**: same place, line ~215:

```csharp
RequestPath = new PathString($"/{relativePath}")
```

If `relativePath = "/attachments"`, RequestPath = `"//attachments"` — double slash. PathString normalizes, but URLs with double slashes can confuse downstream proxies.

**Fix**: trim leading slash before interpolating.

### ⚪ RUNTIME: `_rid` request-correlation hack

**Where**: UI `api.interceptor.ts` adds `?_rid=<5-char-random>` to every URL; the API doesn't read it but it's logged.

**Impact**: cache-busting (defeats CDN caching of GET requests). Harmless but noisy in logs.

---

## Architecture-level concerns

### 🟡 "Repositories" are de-facto service classes

`ChargesRepository` is 3,614 lines with 17 injected dependencies. Other repositories follow suit (1,000+ lines is normal). They orchestrate cross-aggregate operations that should be in services.

**Implication**: when you add a feature, the temptation is to drop it into the repository because that's where similar logic lives. Resist. New cross-cutting logic should go in `Services/` (the underused folder right next to `Repositories/`).

### 🟡 Three different DB access styles in one repo

ServiceStack OrmLite + Dapper + raw `SqlCommand` are all in active use. Pick one when adding new code:

- **OrmLite** for entity CRUD (`db.Select<T>`, `db.Insert(...)`)
- **Dapper** for joins / read-only / reporting queries
- **Raw SqlCommand** is acceptable only for stored-proc calls; always parameterize

### 🟡 Inconsistent error handling

Each controller has `try / catch (EntityException) / catch (Exception)` boilerplate. New controllers should use this pattern for now (consistency > principle), but at the architecture level we should consolidate into a global filter.

### 🟢 `Connected Services/TrizettoReference/` is excluded from build

The csproj has:

```xml
<Compile Remove="Connected Services\TrizettoReference\**" />
```

This was a WSDL-generated client that was never finished. If you re-enable it, you'll need the WSDL and an HTTP client at runtime. Currently dead code.

### 🟢 Multiple `*DataSet.xsd` files

`PI_ACCESSDataSet.xsd`, `PI_ACCESSDataSet1.xsd` in `BusinessLogic.ChargePaymentService` are typed-DataSet leftovers from .NET Framework. They're hardly used. Removing them is a cleanup task; they don't actively harm but do bloat the build.

---

## How to use this doc when something goes wrong

1. Search for the error message text in this file first.
2. If not found, check the per-service docs ([`services/`](services/)) for service-specific quirks.
3. If still stuck, the deploy logs (`docker compose logs -f host`) usually contain a stack trace pointing to a file. Cross-reference with `ARCHITECTURE.md` to understand what layer that file is in.
4. Add anything new you discover to this file. **Don't let tribal knowledge drift back into people's heads** — that's how this codebase got the way it is.
