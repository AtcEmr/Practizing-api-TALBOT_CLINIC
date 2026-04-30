# Deploying the PractiZing API stack to Coolify

This repository ships a single `docker-compose.yaml` at the root that builds
all eight ASP.NET Core services from one parameterized `Dockerfile`. Coolify
treats the whole stack as one Application resource.

## Pre-deploy checklist (do these BEFORE the first push)

1. **Rotate compromised credentials.** The repo has historically committed
   plaintext secrets:
   - SQL Server passwords in `*/appsettings.Development.json` (six files).
   - An AWS access key in
     `ChargePaymentService/PractiZing.BusinessLogic.ChargePaymentService/Repositories/HistoryPaymentRepository.cs:32`.
   - A JWT HMAC key in `HostService/HostService.Api/Startup.cs:53`.
   - A ServiceStack license literal (expired 2019) in every `Startup.cs`.
   Rotate all of them in the upstream services first. Git history retains
   the originals; if the repo is or has been public, treat the originals as
   public.

2. **Stop tracking dev appsettings.** Once you've rotated, untrack them:
   ```bash
   git rm --cached \
     ChargePaymentService/PractiZing.Api.ChargePaymentService/appsettings.Development.json \
     DenialManagementService/PractiZing.Api.DenialService/appsettings.Development.json \
     ERAService/PractiZing.Api.ERAService/appsettings.Development.json \
     MasterService/PractiZing.Api.MasterService/appsettings.Development.json \
     PatientService/PractiZing.Api.PatientService/appsettings.Development.json \
     SecurityService/PractiZing.Api.SecurityService/appsettings.Development.json
   ```
   Add `**/appsettings.Development.json` to `.gitignore` if you want to keep
   local copies, or commit a sanitized template alongside.

3. **Provision SQL Server.** The image is stateless. Use Coolify's managed
   "Resource → Database → SQL Server", AWS RDS, or any reachable instance.
   Note both connection strings the app needs:
   - `ConnectionStrings:DefaultConnection`
   - `ConnectionStrings:PracticeCentralDBContext`

## One-time setup in Coolify

1. **Create a new Application** → "Docker Compose" build pack.
2. Point it at this repository, branch `main`, base directory `/`.
3. Coolify will detect `docker-compose.yaml` automatically.
4. Under **Environment Variables**, paste the contents of `.env.example`
   and replace every `CHANGE_ME` value. Important:
   - .NET reads `Foo__Bar` env vars as `Foo:Bar` config keys, so
     `ConnectionStrings__DefaultConnection` overrides
     `appsettings.json["ConnectionStrings"]["DefaultConnection"]`.
   - Mark `DB_*`, `JWT_SECRET`, and `AWS_*` as **Secret** so Coolify masks
     them in logs and the UI.
5. Under **Domains / Proxy**, give each service a hostname:
   - `host` → `api.your-domain.example`            (recommended primary)
   - `chargepayment` → `chargepayment.api.your-domain.example`
   - `denial`        → `denial.api.your-domain.example`
   - `era`           → `era.api.your-domain.example`
   - `master`        → `master.api.your-domain.example`
   - `patient`       → `patient.api.your-domain.example`
   - `report`        → `report.api.your-domain.example`
   - `security`      → `security.api.your-domain.example`
   Each service's container port is `8080`; Coolify's Traefik instance
   terminates TLS in front of it.
6. **Persistent storage**: the compose file declares an `attachments`
   volume mounted at `/attachments` in every container. Coolify will
   create it on first deploy. Add this path to your backup policy.
7. Click **Deploy**. The first build pulls the .NET Core 2.1 SDK image
   (~1.7 GB) and rebuilds eight services; expect 15–25 minutes. Subsequent
   deploys reuse the layer cache and finish in 3–5 minutes.

## Local sanity-check before pushing

```bash
cp .env.example .env
# edit .env and fill real values pointing at a non-prod database
docker compose build
docker compose up -d
docker compose ps         # all eight services should report healthy
docker compose logs -f host
```

The HostService aggregates routes from every other Api project, so for a
quick smoke test:

```bash
curl -i http://localhost:8081/   # host 8081 -> container 8080 (per override below)
```

(Each compose service uses `expose: 8080` — not `ports:` — so locally
you'll need to add a `ports:` mapping in a `docker-compose.override.yaml`
or let Coolify handle the proxying.)

## Networking

The compose stack joins two networks:

- **`coolify`** — declared `external: true`. Coolify creates this network
  on its host and runs Traefik on it. Every service that Coolify should
  publicly route must be on it. The UI stack also joins this network so
  its nginx layer can reach API services by container name without going
  through the public internet.
- **`practizing`** — a private bridge created by this stack. Used for
  inter-service traffic (e.g. if Service A ever needs to call Service B
  internally).

If you're running compose outside Coolify (e.g. on a developer machine),
the `coolify` network won't exist yet. Create it once:

```bash
docker network create coolify
```

### Local host-port binding (debugging)

The compose file uses `expose:` only, so no host ports are bound by
default. To poke a service from your host without going through Traefik,
drop a `docker-compose.override.yaml` next to the main compose file
(it's `.gitignored`):

```yaml
# host_port:container_port — containers always listen on 8080,
# host side uses 8081+ to avoid clashing with anything on the
# conventional 8080.
services:
  host:
    ports:
      - "8081:8080"     # http://localhost:8081/
  chargepayment:
    ports:
      - "8082:8080"
  denial:
    ports:
      - "8083:8080"
  # ... continue 8084, 8085, ... per service
```

`docker compose up -d` picks the override up automatically.

### How the UI reaches the API

Two patterns work:

1. **Public URL** (default in Coolify): the UI's `API_URL` is the
   public host of the API stack's `host` service, e.g.
   `https://api.your-domain.example`. The browser → Coolify Traefik
   → `host` container.
2. **Internal DNS**: set the UI's `API_URL` to
   `http://practizing-host:8080`. Both stacks must be on the `coolify`
   network (they are, with this config). Faster, no public hop, and the
   API never needs a public hostname. CORS becomes a non-issue.

## Operational notes

- **Health checks**: none of the services expose a `/health` endpoint
  today. Add `app.UseHealthChecks("/health")` in each `Startup.Configure`,
  then add a `healthcheck:` block in the compose file. Until that's done,
  Coolify falls back to TCP-port checks.
- **CORS**: every `Startup.cs` currently calls
  `AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()`. Tighten to
  `WithOrigins(Configuration["UIUrl"])` and the `UIUrl` env var becomes
  the single source of truth.
- **Swagger**: only `HostService` honors the `UseSwagger` flag. Leave it
  `false` in prod. The other services unconditionally call
  `app.UseSwaggerUI(...)` in their `Startup.cs` — patch them to read the
  same flag before going to a public domain.
- **TLS**: the apps listen on plain HTTP inside the container. Coolify's
  reverse proxy terminates TLS. Do not expose container port `8080`
  directly to the internet.
- **Logs**: services use `loggerFactory.AddConsole` only. Coolify
  captures stdout/stderr by default; for retention longer than the
  container lifetime, plug into Coolify's log shipping or add Serilog +
  a sink.

## Why a single Dockerfile?

Every Api csproj follows the same pattern: it references sibling
`BusinessLogic.*` and `DataAccess.*` projects in the same repo, plus
`Common/*` and `Base/*`. `dotnet publish <Api.csproj>` resolves all of
those automatically when the build context is the repo root, so one
parameterized Dockerfile produces eight different images by passing
`SERVICE_PROJECT` and `SERVICE_DLL` build args. Less duplication, one
place to bump runtime versions when you upgrade off .NET Core 2.1.
