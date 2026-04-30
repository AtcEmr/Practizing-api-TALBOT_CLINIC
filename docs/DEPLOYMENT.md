# Deployment Runbook

## TL;DR

The full prod deploy story:

1. SQL Server is provisioned (Coolify-managed or external) with both DBs populated.
2. Coolify pulls this repo's `coolify` branch, builds the 8 Docker images via `docker-compose.yaml`, and runs them on its host.
3. Coolify's Traefik proxy fronts the containers and terminates TLS.
4. The UI repo's stack is deployed similarly, with `API_URL` pointing at HostService.
5. Both stacks share Coolify's `coolify` Docker network, so the UI's nginx can reach the API by container name.

## Files in the repo that drive deployment

| File | Purpose |
|---|---|
| `Dockerfile` | Parameterized — builds any service via `SERVICE_PROJECT` and `SERVICE_DLL` build-args. Multi-stage: SDK → ASP.NET runtime, runs as non-root user `app`. |
| `docker-compose.yaml` | One stack, eight services. YAML anchor `&api-common` shares env vars and volumes. |
| `.dockerignore` | Strips `bin/`, `obj/`, `.vs/`, dev appsettings, secrets. |
| `.env.example` | Template for every env var Coolify needs to set. |
| `.gitattributes` | Forces LF on Dockerfile / .sh / compose / nginx files so Windows clones don't break the Alpine shebang. |
| `Directory.Build.props` | Repo-wide MSBuild prop pinning `System.Runtime.CompilerServices.Unsafe` to 4.5.3 (necessary for netcoreapp2.1 builds; see [`TROUBLESHOOTING.md`](TROUBLESHOOTING.md)). |
| `coolify/README.md` | Original Coolify-specific deploy steps; this file is the maintainer's runbook for ongoing operations. |

## First-time Coolify setup

1. **Provision SQL Server**. Two databases:
   - `PracticeCentral` (the lookup DB; has the `PracticeCentralPractice` table)
   - At least one per-practice DB (e.g. `PI2_TEMP` or `PI2_TalbotClinic`) populated with the schema in `AppSetting.sql`
2. **Coolify project + Application**:
   - Create a new Application of type "Docker Compose"
   - Source: this Git repo, branch `coolify`
   - Build pack: Compose
3. **Environment Variables tab**: paste values from `.env.example`, replacing every `CHANGE_ME`
4. **Domains tab**: assign a hostname per compose service. Recommended:
   - `host` → `api.your-domain.example`
   - others → either dedicate subdomains or skip (HostService aggregates routes)
5. **Persistent storage**: the `attachments` volume in compose is auto-managed by Coolify. Add `/attachments` to the backup policy.
6. **Network**: Coolify creates a `coolify` Docker network on its host automatically. The compose `external: true` clause hooks into it.
7. **Click Deploy**. First build takes 15–25 minutes (SDK pull + 8 service builds).

## Smoke-testing a fresh deploy

After deploy, in this order:

```bash
# 1. Containers running?
docker ps --filter name=practizing

# 2. HostService boot completed (loaded practices, registered token provider)?
docker logs practizing-host 2>&1 | tail -50
# Look for: "Now listening on: http://[::]:8080" and absence of stack traces

# 3. Token endpoint responsive?
curl -i -X POST https://api.your-domain.example/token \
  -H "Content-Type: application/json" \
  -d '{"username":"<dev-user>","password":"<dev-pass>"}'
# Expected: 200 OK with { "AccessToken": "..." }

# 4. Authenticated endpoint?
TOKEN=...
curl -i https://api.your-domain.example/api/Charges \
  -H "Authorization: bearer $TOKEN"
# Expected: 200 OK with JSON
```

If step 2 shows `Cannot open server "..."` errors, your DB connection
strings are wrong or the server is unreachable from the container.

If step 3 returns `401`, your JWT secret in HostService doesn't match what
the token validator uses (currently both come from the same hardcoded
constant 🔴).

## Updating production

Since Coolify auto-deploys the `coolify` branch:

```bash
# from your dev branch
git checkout coolify
git merge dev-branch
git push origin coolify
# Coolify webhook fires, rebuilds, replaces containers
```

You can also manually deploy by clicking "Deploy" in Coolify.

> **Coolify replaces containers one at a time, but during the swap there's
> a brief moment where both old and new are running.** With shared
> volumes (the `attachments` volume) and shared DBs, both can write —
> rare but possible. Plan migration scripts to be idempotent.

## Rolling back

Coolify keeps the previous image set. In the Application UI:

- "Deployments" tab lists every deploy
- Click "Redeploy" on the previous successful one

Or do it via Git:

```bash
git checkout coolify
git revert <bad-commit>          # creates a forward fix commit
git push origin coolify
```

Avoid `git push --force` to `coolify` — Coolify history is the audit
trail.

## Logs

```bash
# Last 200 lines, follow
docker logs -f --tail=200 practizing-host

# All services in compose
docker compose -p practizing-api-talbot_clinic logs -f --tail=50

# In Coolify: Application → Logs tab. Streamed live.
```

HostService also writes to `/app/Logs/<DateTime>.txt` inside the
container. **These are NOT on a volume**, so they're lost when the
container restarts. If you need persistent logs, either:

- Mount a `logs` volume in compose for the `host` service (not currently configured), or
- Plug into Coolify's external log shipping (Loki/Datadog/etc.)

## Restarting a single service

```bash
docker compose -p practizing-api-talbot_clinic restart host
```

Or in Coolify UI: Application → Containers → Restart on the service.

## Scaling

The compose file has no `deploy.replicas` configured. To run multiple
copies of HostService:

```yaml
services:
  host:
    deploy:
      replicas: 3
```

But: HostService has in-process state (`_practices` cache,
`SetAllInCache(_practices)` for tokens). Multiple replicas means each has
its own cache. Token validation still works (it's stateless HMAC), but
the user-cache per-instance means a logout in one instance doesn't
revoke in another. Plan a Redis-backed cache before scaling out.

## Network architecture

```
                    Internet
                       │
                       │ TLS 80/443
                       ▼
              ┌──────────────────┐
              │  Coolify Traefik │   (on the `coolify` Docker network)
              └──────┬─────┬─────┘
                     │     │
                     │     │ http :8080 internal
        ┌────────────▼┐   ┌▼─────────────┐
        │ practizing- │   │ practizing-  │
        │ ui          │   │ host         │
        │ (nginx)     │   │ (HostService)│
        └────┬────────┘   └──────────────┘
             │ /api/* proxy
             │  http://practizing-host:8080
             ▼
        ┌──────────────────────────────┐
        │ The other 7 API containers   │
        │ on `practizing` private net  │
        │ (chargepayment, denial, era, │
        │  master, patient, report,    │
        │  security)                   │
        └──────────────────────────────┘
                     │
                     │ TCP 1433
                     ▼
              ┌────────────────┐
              │ SQL Server     │   (Coolify Resource or external)
              │  - PI2_*       │
              │  - Practice-   │
              │    Central     │
              └────────────────┘
```

- Containers expose port `8080` internally only (no host-port binding in prod)
- Local debug binds host port 8081 (or 8081/8082/8083... per service for the API stack) → container 8080 via `docker-compose.override.yaml`
- The UI's nginx contains `proxy_pass ${API_URL}/api/` — set `API_URL` to `http://practizing-host:8080` for in-cluster routing

## Common operational issues

| Symptom | Likely cause | Fix |
|---|---|---|
| `host` container restart-loops at boot | Unable to read `PracticeCentral` DB | Check `ConnectionStrings__PracticeCentralDBContext`; verify SQL Server reachable from container (`docker exec practizing-host nc -zv <db-host> 1433`) |
| Login (`/token`) returns 200 but every other API call returns 401 | JWT secret mismatch (this is hardcoded; if you've added a config-based override only for issuance OR validation, they won't match) | Verify the secret used at `HostService/Startup.cs:53` matches what the validator uses |
| Some endpoints return 500 with `MissingMethodException` mentioning MimeKit | Code path uses MimeKit 4.x API; we downgraded MimeKit to 2.15.1 for build compat | Identify the call site via stack trace; either work around with 2.15.1 API, or upgrade .NET to 6/8 and re-pin MimeKit to 4.x |
| Reports endpoint 500s with SQL syntax error | Likely the `ParseParameter.ParseReport` SQL injection / quoting issue (🔴 see `TROUBLESHOOTING.md`) | The fix is non-trivial: rewrite to use `SqlParameter` properly. As a workaround, sanitize report parameters before they hit the parser |
| `cannot resolve "EdiFabric.Core"` during `dotnet restore` in Docker | A new csproj added a HintPath into the gitignored `EDIFabric/Packages/` | Redirect to `lib/EdiFabric.Framework/DLLs/net45/` like the other fixed csprojs |
| UI shows blank page; browser DevTools shows 404 on `/api/...` | nginx upstream wrong | Check `API_URL` env var on the UI; restart UI container so the entrypoint re-renders nginx config |
| File uploads (lab reports, CAQH) fail at 100MB | nginx `client_max_body_size` cap | Already set to `100M` in nginx.conf.template; for >100MB, edit the template |

## Backup / restore

The data lives in:

1. **SQL Server databases** — back up with whatever your DB-resource provider supports. For Coolify-managed DBs, that's the resource's "Backup" tab.
2. **Attachments volume** — the `attachments` named volume in compose. `docker run --rm -v <vol>:/backup ubuntu tar czf - /backup > attachments.tgz`. Schedule this via Coolify's volume backup feature or cron on the host.
3. **Logs** — currently ephemeral; not backed up. If you wire structured logging, also wire log retention.

There's nothing else stateful in the stack. The containers are
disposable — losing them means re-deploying.

## Going to production checklist

Before pointing real PHI traffic at this:

- [ ] Rotate the SQL Server passwords; remove from `appsettings.Development.json`; commit a sanitized template
- [ ] Rotate the AWS access key (the one in `HistoryPaymentRepository.cs`) — it's in git history
- [ ] Refactor `HistoryPaymentRepository.cs:32` to read AWS creds from `IConfiguration`
- [ ] Refactor `HostService/Startup.cs:53` to read JWT secret from `IConfiguration`
- [ ] Tighten CORS — replace `AllowAnyOrigin()` with `WithOrigins(Configuration["UIUrl"])`
- [ ] Suppress Swagger in production (`UseSwagger=false` is already default; keep it that way)
- [ ] Add a global exception filter — controllers leak stack traces today
- [ ] Set up DB backup schedule
- [ ] Set up alerting on container restarts
- [ ] Document the runbook recipients (who do you call when this breaks at 2am?)

This is the same list as the "Pre-deploy checklist" in
`coolify/README.md`. None of it has been done by the deployment
packaging — it's all source/operational work.
