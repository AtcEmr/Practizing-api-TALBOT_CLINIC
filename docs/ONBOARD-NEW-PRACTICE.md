# Onboard a New Practice — End-to-End Runbook

> **Audience.** This document is written so that:
> - A non-technical operator can follow the click-by-click steps and ship a new practice in ~30 minutes.
> - An AI agent (Claude Code, Codex, etc.) can read it, gather the seven inputs in [§1](#1-the-seven-inputs-you-need-collect-these-first), and execute the SQL/SSH/Coolify steps end-to-end with no human troubleshooting.
>
> **It is opinionated.** Every quirk we hit deploying the first practice (Autumn Treatment Center / `billing.dsigworkflow.com`) is encoded as a specific step. Don't skip steps "for now" — the system has multiple coupling points (DNS subdomain ↔ practice code, Coolify per-app networks, hardcoded LoginController self-call, etc.) that fail silently when one piece is missing.

---

## 0. Architecture in 60 seconds (read once)

```
        Public DNS
   <subdomain>.<your-domain>
            │
            ▼
   ┌──────────────────────┐
   │  Reverse-proxy       │   <- your control-plane machine
   │  (Traefik, file-     │   <- has dynamic config files like
   │   based dynamic      │   <- /etc/traefik/dynamic/*.yml
   │   config)            │
   │  TLS termination     │   <- Let's Encrypt cert per domain
   └─────────┬────────────┘
             │  HTTP, internal LAN
             ▼
   ┌──────────────────────────────────────────┐
   │  App server (Coolify "Server" target)    │
   │  IP: 10.3.104.49                          │
   │  ┌────────────────────────────────────┐  │
   │  │ docker-compose stacks deployed     │  │
   │  │ here by Coolify:                   │  │
   │  │  - API stack (8 services)          │  │
   │  │  - UI stack (1 service)            │  │
   │  │ Each Coolify App = its own         │  │
   │  │  per-project Docker network        │  │
   │  └────────────────────────────────────┘  │
   └──────────────────┬───────────────────────┘
                      │  TCP 1433 (LAN)
                      ▼
              ┌───────────────────┐
              │  SQL Server       │
              │  10.3.104.52      │
              │  - PI_<PRACTICE>  │  <- one DB per practice
              │  - PracticeCentral│  <- (optional) lookup DB
              └───────────────────┘
```

### Key fact most likely to trip you up

When the API authenticates a request, it looks at the **request's URL** and uses the **first DNS label** as the practice code:

```csharp
// Common/PractiZing.DataAccess.Common/DataBaseContext.cs:40
practiceCode = header.Split(".").FirstOrDefault();
```

Then it opens a SQL connection registered under that name. If the registration doesn't exist, `400 Bad Request: "No factory registered is named <subdomain>"`.

That means **every public subdomain you give a practice MUST exist as a row in `dbo.Practice` with `PracticeCode = <subdomain prefix>`**. For Autumn Treatment Center we deploy on `billing.dsigworkflow.com` and `billingapi.dsigworkflow.com`, so we have THREE rows: `clinicbilling` (legacy), `billing` (UI subdomain), `billingapi` (API subdomain). All three point at the same operational DB.

This is the load-bearing rule the rest of this document flows from.

---

## 1. The seven inputs you need (collect these first)

Tell the AI agent / operator these values up front. Without all seven, the deploy will stall.

| # | Input | Example | Notes |
|---|---|---|---|
| 1 | Practice friendly name | `Sunrise Health Clinic LLC` | Free text; appears in JWTs and UI title |
| 2 | UI subdomain | `sunrise` → `sunrise.dsigworkflow.com` | Pick something stable; this becomes a PracticeCode |
| 3 | API subdomain | `sunriseapi` → `sunriseapi.dsigworkflow.com` | Convention: `<ui>api`; also becomes a PracticeCode |
| 4 | Operational DB name | `PI_SUNRISE_CLINIC` | One DB per practice; never share with another practice |
| 5 | DB server + creds | host `10.3.104.52`, user `sa`, password `<secret>` | Same SQL Server can host many practice DBs |
| 6 | Initial admin user | `sunriseadmin` / `<password>` | Created in the practice DB's `User` table (step 7) |
| 7 | Practice short code (CLM) | `SUN` | 3-letter code used in claim file naming. Often the same as practice initials |

**Two host ports** are also implied — pick from the available range on the app server:

| Resource | Port (host:container) | Notes |
|---|---|---|
| API host service | `<APIPORT>:8080` | Pick an unused port, e.g. `8092` |
| UI nginx | `<UIPORT>:8080` | Pick an unused port, e.g. `8093` |

To find what's already used, on the app server: `ss -tln | awk '{print $4}' | grep -oE ':[0-9]+$' | sort -u`.

---

## 2. DNS records (do this first; propagation is slow)

Add A records pointing both subdomains at the **reverse-proxy** machine's WAN IP (the machine that runs your Traefik, NOT the app server).

For Autumn Treatment Center we used (your actual WAN IP will differ):

```
billing.dsigworkflow.com.       A  74.142.163.218
billingapi.dsigworkflow.com.    A  74.142.163.218
```

For a new practice, do the equivalent two records. Verify with:

```bash
dig +short <ui-subdomain>.dsigworkflow.com
dig +short <api-subdomain>.dsigworkflow.com
```

Both should return your reverse-proxy WAN IP.

> **AI agent note**: if you don't have DNS access, hand the records to the operator and continue — DNS can propagate while the rest of the steps run.

---

## 3. Database setup

You have two paths depending on whether the new practice gets its own DB or shares an existing one. Most deployments give each practice its own DB.

### 3a. Create the operational DB (if new)

Connect to the SQL Server. The pattern for the existing deploy:

```bash
MSYS_NO_PATHCONV=1 docker run --rm mcr.microsoft.com/mssql-tools \
  /opt/mssql-tools/bin/sqlcmd -S 10.3.104.52 -U sa -P '<password>' \
  -Q "CREATE DATABASE PI_<PRACTICE>_CLINIC"
```

(Replace `<PRACTICE>` with a short identifier matching input #4.)

### 3b. Apply schema

Copy the schema from a reference practice (typically your "template" practice or an existing one). Two options:

**Option A — clone schema from existing DB** (fastest, recommended):

```bash
# On the SQL Server host or any machine with sqlcmd:
# Generate schema-only dump
mssql-scripter -S 10.3.104.52 -U sa -P '<password>' -d PI_ATC_CLINIC \
  --schema-and-data --exclude-data --file-per-object \
  --target-server-version 2019 -f /tmp/schema/

# Apply to new DB
sqlcmd -S 10.3.104.52 -U sa -P '<password>' -d PI_<PRACTICE>_CLINIC -i /tmp/schema/all.sql
```

**Option B — apply the SQL files committed to this repo**:

```bash
sqlcmd -S 10.3.104.52 -U sa -P '<password>' -d PI_<PRACTICE>_CLINIC -i AppSetting.sql
sqlcmd -S 10.3.104.52 -U sa -P '<password>' -d PI_<PRACTICE>_CLINIC -i ConfigSetting.sql
```

> See [`DATABASE.md`](DATABASE.md) for what's in each file and the relationship between them.

### 3c. Patch the `Practice` table to match the C# entity

The `dbo.Practice` table in operational DBs ships with 40 columns of practice-specific settings (SMTP, EMR URLs, logo, etc.) but is **missing 7 columns the C# `PracticeCentralPractice` entity expects**. Without these, HostService crashes at startup with `Invalid column name '...'`.

Run this **once per new operational DB**:

```sql
USE PI_<PRACTICE>_CLINIC;
GO

-- Computed alias so the entity's PracticeId column maps to the existing Id PK.
-- Then add the 6 columns the entity needs that the operational table never had.
ALTER TABLE dbo.Practice ADD
    PracticeId         AS Id,
    PracticeURL        NVARCHAR(500) NULL,
    StripeKey          NVARCHAR(500) NULL,
    DBName             NVARCHAR(200) NULL,
    CustomerKey        NVARCHAR(200) NULL,
    LabDBName          NVARCHAR(200) NULL,
    DBConnectionString NVARCHAR(MAX) NULL;
GO
```

### 3d. Insert THREE practice rows (the load-bearing step)

This is where most deploys go wrong. You need:

1. The **canonical** row for the practice (with whatever main `PracticeCode` you want — e.g., `<practice-id>` or just the UI subdomain).
2. An alias row whose `PracticeCode` matches the **UI subdomain** (e.g., `sunrise` for `sunrise.dsigworkflow.com`).
3. An alias row whose `PracticeCode` matches the **API subdomain** (e.g., `sunriseapi` for `sunriseapi.dsigworkflow.com`).

Why three: the API derives the practice code from `Origin`/`Referer`/`Host` header and splits on `.` taking the first label. UI requests carry `Origin: https://<ui-subdomain>...`, the LoginController self-call carries `Host: <api-subdomain>...`. Both must resolve to a registered connection.

For the existing Autumn Treatment Center deploy we have:

```sql
SELECT Id, PracticeCode, PracticeName FROM dbo.Practice ORDER BY Id;
-- 1  clinicbilling  Autumn Treatment Center LLC
-- 2  billing        ATC alias billing
-- 3  billingapi     ATC alias billingapi
```

For a new practice, run this template (fill in the `<>` placeholders):

```sql
USE PI_<PRACTICE>_CLINIC;
GO

DECLARE @PracticeName       NVARCHAR(400) = '<Sunrise Health Clinic LLC>';
DECLARE @PracticeCodeCLM    NVARCHAR(20)  = '<SUN>';
DECLARE @UISubdomain        NVARCHAR(50)  = '<sunrise>';        -- e.g. sunrise
DECLARE @APISubdomain       NVARCHAR(50)  = '<sunriseapi>';     -- e.g. sunriseapi
DECLARE @PublicUIURL        NVARCHAR(500) = 'https://<sunrise>.dsigworkflow.com';
DECLARE @PublicAPIURL       NVARCHAR(500) = 'https://<sunriseapi>.dsigworkflow.com';
DECLARE @DBName             NVARCHAR(200) = 'PI_<PRACTICE>_CLINIC';
DECLARE @DBConnString       NVARCHAR(MAX) = 'Data Source=10.3.104.52;Initial Catalog=PI_<PRACTICE>_CLINIC;User id=sa;Password=<password>;TrustServerCertificate=True;MultipleActiveResultSets=true;Encrypt=True';

-- 1) Canonical row (PracticeId = 1 for a fresh DB).
--    Many operational lookups assume Id=1 = the host practice; keep that convention.
--    Pick whatever PracticeCode you want for "system identifier" use; we'll add aliases below.
INSERT INTO dbo.Practice (
    Id, UId, PracticeCode, PracticeName, PracticeCodeCLM,
    PracticeURL, DBName, LabDBName, DBConnectionString,
    CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
) VALUES (
    1, NEWID(), @UISubdomain, @PracticeName, @PracticeCodeCLM,
    @PublicUIURL, @DBName, @DBName, @DBConnString,
    GETUTCDATE(), 'system', GETUTCDATE(), 'system'
);

-- 2) Alias row matching the UI subdomain (already done above if @UISubdomain == canonical PracticeCode).
--    Skip if step 1 already used the UI subdomain.

-- 3) Alias row matching the API subdomain.
INSERT INTO dbo.Practice (
    Id, UId, PracticeCode, PracticeName, PracticeCodeCLM,
    PracticeURL, DBName, LabDBName, DBConnectionString,
    CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
) VALUES (
    2, NEWID(), @APISubdomain, @PracticeName + ' (alias api)', @PracticeCodeCLM,
    @PublicAPIURL, @DBName, @DBName, @DBConnString,
    GETUTCDATE(), 'system', GETUTCDATE(), 'system'
);

GO

-- Verify
SELECT Id, PracticeCode, PracticeName, PracticeURL FROM dbo.Practice ORDER BY Id;
```

> **NOT NULL columns to remember**: `Id`, `UId`, `CreatedDate`, `CreatedBy`, `ModifiedDate`, `ModifiedBy`. The INSERT will fail with a misleading "cannot insert NULL" until all six are supplied.

### 3e. Create the initial admin user

Each practice needs at least one user record so login can succeed.

```sql
USE PI_<PRACTICE>_CLINIC;
GO

DECLARE @UserName     NVARCHAR(100) = '<sunriseadmin>';
DECLARE @PasswordHash NVARCHAR(500) = '<hashed-password>';   -- match whatever hash algorithm the existing User rows use
DECLARE @PracticeId   INT           = 1;                     -- the Id from step 3d row 1

-- Inspect an existing User row first to see the schema:
--   SELECT TOP 1 * FROM dbo.[User];
-- Then INSERT mirroring required columns. Most installs use SHA-something or bcrypt;
-- check existing values to figure out the algorithm.

INSERT INTO dbo.[User] (
    UserName, /* PasswordColumn, depends on schema */
    PracticeId, IsActive, /* ... */
    CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
) VALUES (
    @UserName, @PasswordHash,
    @PracticeId, 1,
    GETUTCDATE(), 'system', GETUTCDATE(), 'system'
);
```

> If you don't know the password-hash algorithm, the cleanest path is to copy an existing user row and `UPDATE` the username and password fields after using the API's password-change flow on first login. Or: temporarily expose a password-set endpoint, set the password, then disable.

---

## 4. Reverse-proxy: add Traefik dynamic config files

On your **reverse-proxy machine** (the one running Traefik with file-based dynamic config), drop two new YAML files into the dynamic config directory (the same place where existing site files like `bhsscribe.yml` live).

Replace the placeholders with your input values.

### 4a. `<api-subdomain>.yml`

```yaml
http:
  routers:
    <api-subdomain>-http:
      rule: Host(`<api-subdomain>.dsigworkflow.com`)
      entryPoints:
        - http
      middlewares:
        - redirect-to-https
      service: <api-subdomain>-svc
    <api-subdomain>-https:
      rule: Host(`<api-subdomain>.dsigworkflow.com`)
      entryPoints:
        - https
      tls:
        certResolver: letsencrypt
      service: <api-subdomain>-svc
  middlewares:
    redirect-to-https:
      redirectScheme:
        scheme: https
        permanent: true
  services:
    <api-subdomain>-svc:
      loadBalancer:
        servers:
          -
            url: 'http://10.3.104.49:<APIPORT>'
```

### 4b. `<ui-subdomain>.yml`

```yaml
http:
  routers:
    <ui-subdomain>-http:
      rule: Host(`<ui-subdomain>.dsigworkflow.com`)
      entryPoints:
        - http
      middlewares:
        - redirect-to-https
      service: <ui-subdomain>-svc
    <ui-subdomain>-https:
      rule: Host(`<ui-subdomain>.dsigworkflow.com`)
      entryPoints:
        - https
      tls:
        certResolver: letsencrypt
      service: <ui-subdomain>-svc
  middlewares:
    redirect-to-https:
      redirectScheme:
        scheme: https
        permanent: true
  services:
    <ui-subdomain>-svc:
      loadBalancer:
        servers:
          -
            url: 'http://10.3.104.49:<UIPORT>'
```

Traefik watches the directory; **no restart needed**. You'll see the router pick up in Traefik logs within a few seconds.

---

## 5. Coolify: create the API Application

> If you ever decide to share a single API Application across many practices, skip this section and reuse the existing one. The current architecture (one API stack per practice) is simpler, but more resource-heavy.

### 5a. Create the Application

1. Coolify UI → **+ New** → **Application**
2. Source: **Public Repository** (or whatever matches how Coolify accesses your repos)
3. Repository: `https://github.com/AtcEmr/Practizing-api-TALBOT_CLINIC`
4. Branch: `coolify`
5. Build pack: **Docker Compose** (Coolify auto-detects `docker-compose.yaml`)
6. Server: choose the deployment server (the one with IP `10.3.104.49` and 12+ GB free disk; see [`DEPLOYMENT.md`](DEPLOYMENT.md) for resource requirements)

### 5b. Override the host port

Before the first deploy, edit the compose `ports` mapping for the `host` service so this practice's API binds to the unique host port you picked. This requires either:

- **Per-Application Coolify "Compose override"** (Coolify v4.0.0-beta.339+ supports this in the UI), or
- A **separate branch per practice** in the repo with the port modification baked in. Cleanest is to use a branch named `coolify-<practice>` and set Coolify's branch field to that.

For now, the simplest path is option B. Cherry-pick a one-line change to a new branch:

```bash
git checkout coolify
git checkout -b coolify-<practice>
# edit docker-compose.yaml: change "8090:8080" to "<APIPORT>:8080" on the `host` service
git commit -am "host port for <practice>"
git push origin coolify-<practice>
```

Then in Coolify set the branch to `coolify-<practice>`.

### 5c. Set the Domains field

**Leave all Domain fields blank** in Coolify's UI. Routing is handled by your reverse-proxy Traefik via the dynamic config files in step 4. Coolify's auto-Traefik would conflict if you also set Domains here.

### 5d. Set environment variables

Paste these into Coolify's Environment Variables tab. Replace `<>` placeholders.

```
DB_DEFAULT_CONNECTION=Data Source=10.3.104.52;Initial Catalog=PI_<PRACTICE>_CLINIC;User id=sa;Password=<password>;TrustServerCertificate=True;MultipleActiveResultSets=true;Encrypt=True
DB_PRACTICE_CENTRAL_CONNECTION=Data Source=10.3.104.52;Initial Catalog=PI_<PRACTICE>_CLINIC;User id=sa;Password=<password>;TrustServerCertificate=True;MultipleActiveResultSets=true;Encrypt=True
JWT_ISSUER=http://PractiZing.com
JWT_AUDIENCE=PRACTICE_INSIGHT
UI_URL=https://<ui-subdomain>.dsigworkflow.com
SITE_LOCALE=en-GB
AWS_ACCESS_KEY_ID=
AWS_SECRET_ACCESS_KEY=
AWS_REGION=us-east-1
USE_SWAGGER=false
http=https
```

**Mark `DB_DEFAULT_CONNECTION` and `DB_PRACTICE_CENTRAL_CONNECTION` as Secret.**

#### Critical entries explained

| Key | Why this exact value |
|---|---|
| `DB_DEFAULT_CONNECTION` | Operational DB. The C# code is hardcoded to query the `Practice` table on this connection during startup. Wrong DB = `Invalid column name 'PracticeId'` errors. |
| `DB_PRACTICE_CENTRAL_CONNECTION` | Used in some legacy code paths. **Currently a duplicate of DefaultConnection** because the `PracticeCentralPracticeRepository.GetAllPractices()` ignores its own `PracticeCentralDBContext` and reads from `DefaultConnection` (this is a code bug — fix tracked in TROUBLESHOOTING). For now: same value as DefaultConnection. |
| `http` | Used by `LoginController` to build a self-call URL to `/token`. If unset, NullReferenceException → 500 with empty body. **Always `https`** in production (the controller's HttpClient call goes out the public WAN to your Traefik and back). |
| `UI_URL` | Currently not consumed by code (CORS uses `AllowAnyOrigin()`), but set it anyway for when CORS is fixed. |

### 5e. Deploy

Click **Deploy**. First build pulls the .NET Core 2.1 SDK image (~1.7 GB) and rebuilds 8 services; expect 15–25 minutes. Watch the build log; the failure modes you might hit are documented in [`TROUBLESHOOTING.md`](TROUBLESHOOTING.md).

### 5f. Smoke-test the API

From your reverse-proxy machine:

```bash
# Direct host-port reachability
curl -i http://10.3.104.49:<APIPORT>/api/Login -X POST \
  -H 'Content-Type: application/json' \
  -d '{"userName":"<adminuser>","password":"<password>"}'
# Expected: 200 OK with {"AccessToken":"...","ExpiresIn":...}

# Via the public Traefik route
curl -sk -X POST 'https://<api-subdomain>.dsigworkflow.com/api/Login' \
  -H 'Content-Type: application/json' \
  -d '{"userName":"<adminuser>","password":"<password>"}'
# Expected: identical response
```

---

## 6. Coolify: create the UI Application

### 6a. Create the Application

1. Coolify UI → **+ New** → **Application**
2. Repository: `https://github.com/AtcEmr/Practizing-ui-TALBOT_CLINIC`
3. Branch: `coolify` (or `coolify-<practice>` if you forked for the host-port change as in step 5b)
4. Build pack: **Docker Compose**
5. Server: same as the API (10.3.104.49)

### 6b. Override host port (same pattern as 5b)

The UI compose has `ports: "8091:8080"`. Change `8091` to your `<UIPORT>` for this practice. Same branch pattern as the API.

### 6c. Domains: leave empty

Same reason as 5c.

### 6d. Set environment variables

```
API_URL=http://10.3.104.49:<APIPORT>
API_HOST=<api-subdomain>.dsigworkflow.com
```

#### Critical entries explained

| Key | Why this exact value |
|---|---|
| `API_URL` | Where the UI's nginx proxies `/api/*`. **Use the LAN host:port**, not the public URL. Public-URL routes the traffic out the WAN and back through Traefik for no benefit. The container reaches `10.3.104.49:<APIPORT>` directly over the Docker network → host network. |
| `API_HOST` | The `Host` header nginx sends upstream. Must be the API's **public hostname**, not the UI's. The legacy `LoginController` reads `Host` to build a self-call URL to `/token`; if it sees the UI's hostname, the call gets routed to the UI's nginx (which 404s on `/token`) and login fails with HTTP 500. |

### 6e. Deploy

Click **Deploy**. Faster than the API build — ~5–10 minutes.

### 6f. Smoke-test the UI

From your reverse-proxy machine:

```bash
# Direct host-port reachability
curl -i http://10.3.104.49:<UIPORT>/healthz
# Expected: 200 ok

# Via the public Traefik route
curl -sk https://<ui-subdomain>.dsigworkflow.com/healthz
# Expected: 200 ok

# Login through the full chain (browser → UI nginx → API host service)
curl -sk -X POST 'https://<ui-subdomain>.dsigworkflow.com/api/Login' \
  -H 'Content-Type: application/json' \
  -d '{"userName":"<adminuser>","password":"<password>"}'
# Expected: 200 OK with AccessToken
```

---

## 7. Final verification (browser test)

1. Open `https://<ui-subdomain>.dsigworkflow.com/` in a browser
2. Log in with the admin credentials
3. You should land on the dashboard

If anything fails, [§9](#9-troubleshooting-decision-tree) below has the failure-mode triage.

---

## 8. Post-deploy hardening (do these the same day)

These are the gotchas we hit on the first deploy. Each is a known security or operational risk that ships in the default configuration.

| # | Action | Severity |
|---|---|---|
| 1 | **Rotate the SQL Server `sa` password** if it was used in any earlier env var or commit. Connection strings now contain it both in env vars and inside the `Practice.DBConnectionString` column. | 🔴 |
| 2 | **Confirm the practice's admin user** can only see this practice's data. Cross-tenant leak risk if the `Practice` rows weren't set up correctly. | 🔴 |
| 3 | **Set up a SQL Server backup schedule** for `PI_<PRACTICE>_CLINIC`. There's no schema-managed backup. | 🟡 |
| 4 | **Test logout** — there's a known issue where logout doesn't clear cross-tab state (see UI `docs/STATE-AND-AUTH.md`). | 🟡 |
| 5 | **Confirm `/var/log/docker-cleanup.log` is being written** the morning after the first cron run (03:00 server time). | 🟢 |

---

## 9. Troubleshooting decision tree

If the deploy fails or login doesn't work, walk this tree top-to-bottom.

### Browser can't reach the UI URL at all

- `dig +short <ui-subdomain>.dsigworkflow.com` returns nothing → DNS not propagated, wait or fix DNS.
- DNS resolves but browser shows TLS error → Traefik hasn't issued a Let's Encrypt cert. Check Traefik logs on your reverse-proxy machine for `acme` errors. Common cause: HTTP-01 challenge can't reach Traefik (firewall blocking port 80). Fix the firewall, retry.
- DNS + TLS OK, browser shows 502 Bad Gateway → see "502 from Traefik" below.

### 502 from Traefik on either subdomain

The container behind it isn't running or isn't on the expected host port.

```bash
ssh admin@10.3.104.49 "sudo docker ps --format '{{.Names}}\t{{.Ports}}' | grep -E 'host-|ui-'"
```

- No matching container running → redeploy the Coolify Application.
- Container running but mapped to wrong port → check the host port override in `docker-compose.yaml` matches your Traefik dynamic config.
- Container running on right port but Traefik still 502s → from the reverse-proxy machine: `curl -i http://10.3.104.49:<port>/`. If that fails too, network/firewall between Traefik machine and `10.3.104.49`.

### `Login failed for user '<USER>'` in API logs

Coolify env var still has the literal `<USER>` placeholder. Edit it, replace with real DB credentials, redeploy.

### `Invalid column name 'PracticeId'` (or `PracticeURL`, `DBName`, etc.) in API logs

The operational DB's `Practice` table is missing the columns the C# entity expects. Run the `ALTER TABLE` statements from [§3c](#3c-patch-the-practice-table-to-match-the-c-entity).

### `No factory registered is named '<subdomain>'` in API response (HTTP 400)

The DB's `Practice` table doesn't have a row with `PracticeCode = '<subdomain>'`. Add it (see [§3d](#3d-insert-three-practice-rows-the-load-bearing-step)). After adding, **restart the API host container** so it reloads `_practices`:

```bash
ssh admin@10.3.104.49 "sudo docker restart \$(sudo docker ps --format '{{.Names}}' | grep '^host-')"
```

### `/api/Login` returns HTTP 500 with empty body

The `http=` env var on the API isn't set. Add `http=https` to Coolify env vars, redeploy. (Cause: `LoginController.cs:68` does `headerOrigin.Contains(_configuration["http"])` and crashes if config returns null.)

### UI proxy returns 502 with 14-second timeout

Either:
- `API_URL` is wrong (UI nginx can't reach the address) — fix in Coolify env, redeploy UI.
- `API_HOST` is missing or wrong — same fix.

If you set `API_URL` to a public URL (`https://...`) instead of the LAN host:port, you're routing UI→API traffic out the public internet for no reason. Use `http://10.3.104.49:<APIPORT>` instead.

### "No space left on device" during build

Run the cleanup manually:

```bash
ssh admin@10.3.104.49 "sudo docker builder prune -af && sudo docker image prune -af"
```

The nightly cron (3am) keeps this in check, but a heavy-rebuild day can blow through it.

### Container restart-loops with `'/app/attachments/' does not exist`

The Dockerfile fix is in `coolify` branch (`fdf6220` and later). If you forked from an older commit, rebase onto the latest `coolify` branch.

---

## 10. Rollback / decommission

If the deploy goes sideways and you need to roll back:

1. Coolify Applications → **Deployments tab** → click "Redeploy" on the previous successful build.
2. To **completely remove** a practice:
   - Coolify: delete both Applications.
   - Reverse-proxy: `rm /etc/traefik/dynamic/<api-subdomain>.yml /etc/traefik/dynamic/<ui-subdomain>.yml`.
   - DNS: remove A records.
   - SQL: `DROP DATABASE PI_<PRACTICE>_CLINIC` (irreversible — back up first).

The `Practice` rows in other practices' DBs aren't affected (each practice's `Practice` table is in its own DB).

---

## 11. AI-agent execution prompt

If you're handing this to an AI agent (Claude Code, Codex, etc.), copy-paste the prompt below. The agent should ask for the seven inputs from [§1](#1-the-seven-inputs-you-need-collect-these-first), execute every step, and stop only at the gates that genuinely need a human (DNS records, Coolify "Deploy" button click, browser smoke-test).

````
You are onboarding a new practice to the PractiZing medical-billing platform.
The full runbook is in `docs/ONBOARD-NEW-PRACTICE.md` in this repo. Read it
before doing anything.

Required inputs from the user (ask once, all seven, before starting):
  1. Practice friendly name
  2. UI subdomain prefix (e.g. "sunrise" → sunrise.dsigworkflow.com)
  3. API subdomain prefix (e.g. "sunriseapi" → sunriseapi.dsigworkflow.com)
  4. Operational DB name (e.g. PI_SUNRISE_CLINIC)
  5. SQL Server credentials (host, user, password)
  6. Initial admin user (username + plaintext password — you'll hash it
     using whatever algorithm matches existing User rows in the DB)
  7. Practice short code (e.g. "SUN" — used in PracticeCodeCLM)

Then also derive (don't ask the user, just figure out):
  8. Two unused host ports on the app server (10.3.104.49) for API and UI

Execute in this order. STOP and ask the user to act at the marked
"Human gate" steps. Don't proceed past a gate until they confirm.

Step A — DB setup (you can do this end-to-end via mssql-tools):
  - CREATE DATABASE PI_<PRACTICE>_CLINIC if not exists
  - Apply schema (copy from existing PI_ATC_CLINIC if available, or apply
    the .sql files at the repo root)
  - Run the ALTER TABLE statements from §3c
  - Insert three practice rows per §3d (canonical + UI alias + API alias)
  - Insert one admin user per §3e (figure out the password hash format
    by inspecting existing User rows first)
  - VERIFY: SELECT * FROM Practice should show all three rows; SELECT *
    FROM [User] WHERE UserName=<admin> should show one row

Step B — DNS [Human gate]:
  - Print the two A records that need to exist
  - Wait for user to confirm DNS is set
  - Verify with `dig +short` from your machine

Step C — Reverse-proxy Traefik config (you have SSH access; write the
files via plink/ssh):
  - Generate the two YAML files from §4 templates with placeholders filled in
  - SCP them to /etc/traefik/dynamic/ on the reverse-proxy machine
  - Verify Traefik picked them up by curl-ing the endpoints

Step D — Coolify Apps [Human gate for first-time setup]:
  - The user creates two Coolify Applications via the UI (you can guide
    them step-by-step but you can't click for them). Provide:
      * Repository URLs for both API and UI
      * Branch name (coolify-<practice> if you forked for port override)
      * Server selection
      * Full env-var list per §5d (API) and §6d (UI)
  - Wait for both Applications to deploy successfully

Step E — Smoke test (you can do this autonomously):
  - Run the curl tests from §5f and §6f
  - If all green: declare success and document the new practice in
    `docs/practices/<practice-name>.md` (1-pager: name, subdomains, DB,
    deploy date, who created it)
  - If anything red: walk the troubleshooting tree in §9, fix, retry

Refuse to proceed if:
  - The user can't supply real credentials
  - DNS isn't set up after a reasonable wait
  - The schema clone source DB isn't specified

Document every step you take in a fresh PR description so the human
operator has an audit trail.
````

---

## 12. Reference: What the Autumn Treatment Center deploy looks like (worked example)

Use this as the canonical "what right looks like" if you're unsure whether a step succeeded.

| Field | Value |
|---|---|
| Practice friendly name | Autumn Treatment Center LLC |
| UI subdomain | `billing` (`billing.dsigworkflow.com`) |
| API subdomain | `billingapi` (`billingapi.dsigworkflow.com`) |
| Operational DB | `PI_ATC_CLINIC` |
| DB server | `10.3.104.52` |
| App server | `10.3.104.49` |
| API host port | `8090` |
| UI host port | `8091` |
| `Practice` rows | `clinicbilling` (Id=1), `billing` (Id=2), `billingapi` (Id=3) |
| PracticeCodeCLM | `ATC` |

Smoke-test commands that should all return `200 OK`:

```bash
curl -sk -X POST 'https://billingapi.dsigworkflow.com/api/Login' \
  -H 'Content-Type: application/json' \
  -d '{"userName":"talbothealth","password":"T@lbot4321$"}' -w "\n%{http_code}\n"

curl -sk -X POST 'https://billing.dsigworkflow.com/api/Login' \
  -H 'Content-Type: application/json' \
  -d '{"userName":"talbothealth","password":"T@lbot4321$"}' -w "\n%{http_code}\n"

curl -sk 'https://billing.dsigworkflow.com/healthz' -w "\n%{http_code}\n"
```

If any of these regress, troubleshoot using [§9](#9-troubleshooting-decision-tree).
