# onboard.py — Interactive new-practice deployment

Interactive Python script that walks through the entire procedure in
[`docs/ONBOARD-NEW-PRACTICE.md`](../../docs/ONBOARD-NEW-PRACTICE.md) and
executes every step that doesn't require a human click.

```
$ python onboard.py
```

## What it does

| Step | Mode |
|---|---|
| 1. Pre-flight validation (DNS, SQL, Coolify API, SSH, free ports) | Automatic |
| 2. Create operational DB; ensure schema patches; seed three Practice rows + admin user | Automatic |
| 3. SSH to reverse-proxy; write 2 Traefik dynamic-config YAML files | Automatic |
| 4. Coolify API: find/create Project, create both Applications, set env vars, trigger deploy | Automatic |
| 5. Smoke-test public endpoints + login | Automatic |
| 6. Print summary with all the URLs and IDs you'll need | Automatic |

What's NOT automated (these still need a human):

- **DNS A records** — must exist before you run the script. Pre-flight validates via `dig` and refuses to proceed otherwise.
- **Coolify API token** — generate once in Coolify UI → Keys & Tokens.
- **Coolify server registration** — the deployment server (e.g. `10.3.104.49`) must already be registered in Coolify.
- **SQL schema** — if creating a brand-new operational DB, apply the schema first (clone from a reference DB or run `AppSetting.sql` + `ConfigSetting.sql`). The script creates the database itself but assumes the `Practice` table exists. It will warn you and stop if it doesn't.
- **Browser sign-in test** — verify the admin user can sign in after the script finishes.

## Setup

```bash
cd scripts/onboard
pip install -r requirements.txt
```

System requirements:

- Python ≥ 3.9
- Docker (the script uses the `mcr.microsoft.com/mssql-tools` image for SQL — no Python SQL driver needed)
- Network access from your machine to:
  - The SQL Server (TCP 1433)
  - The reverse-proxy host (SSH)
  - The app server's port range 8090–8200 (for free-port detection)
  - The Coolify base URL

## Run

```bash
python onboard.py
```

You'll be asked for the inputs from
[`docs/ONBOARD-NEW-PRACTICE.md §1`](../../docs/ONBOARD-NEW-PRACTICE.md#1-the-seven-inputs-you-need-collect-these-first):

1. Practice friendly name
2. UI subdomain prefix
3. API subdomain prefix
4. Practice short code (CLM)
5. Operational DB name
6. SQL Server host + credentials
7. Initial admin username + password

Plus operational inputs:

- Coolify base URL + API token
- Coolify deployment server IP
- Reverse-proxy SSH host + credentials

The script confirms the inputs back to you and asks for go-ahead before
making any changes.

## Idempotency

You can re-run the script. Each step checks current state and skips
work already done:

- Database creation: `IF NOT EXISTS`
- ALTER TABLE: only adds columns that don't exist
- Practice rows: only inserted if `PracticeCode` doesn't already exist
- User creation: skipped if username already exists
- Traefik configs: overwritten (it's the same content for a given practice)
- Coolify Applications: reused if name matches; new env vars layered on top

If any step fails partway, fix the underlying issue and re-run — the
script picks up where it left off.

## Configuration constants

A few values are hardcoded near the top of `onboard.py` because they
don't vary per practice. Edit if your environment differs:

| Constant | Default | Meaning |
|---|---|---|
| `API_REPO_URL` | `https://github.com/AtcEmr/Practizing-api-TALBOT_CLINIC` | API repo URL |
| `UI_REPO_URL` | `https://github.com/AtcEmr/Practizing-ui-TALBOT_CLINIC` | UI repo URL |
| `DEFAULT_BRANCH` | `coolify` | Branch deployed by Coolify |
| `APEX_DOMAIN` | `dsigworkflow.com` | Top-level domain practices live under |
| `PORT_RANGE_START` | `8090` | Lowest host port to assign |
| `PORT_RANGE_END` | `8200` | Highest host port to assign |
| `MSSQL_TOOLS_IMAGE` | `mcr.microsoft.com/mssql-tools` | Docker image used for SQL operations |
| `TRAEFIK_DYNAMIC_DIR` | `/etc/traefik/dynamic` | Where Traefik watches for dynamic-config files |

## Troubleshooting

If the script fails at a specific step, the error message tells you
which one and why. The fixes mostly map to entries in
[`docs/TROUBLESHOOTING.md`](../../docs/TROUBLESHOOTING.md) and
[`docs/ONBOARD-NEW-PRACTICE.md §9`](../../docs/ONBOARD-NEW-PRACTICE.md#9-troubleshooting-decision-tree).

Most common surprises:

- **`docker: command not found`** — install Docker Desktop or change `_sqlcmd` to use a local `sqlcmd`.
- **DNS lookup fails** — A records aren't propagated yet; wait or check your DNS provider.
- **Coolify API 401** — token expired or wrong scope. Regenerate.
- **Coolify API 422 on Application creation** — Coolify version mismatch. Endpoint payload shape changed; update `Coolify.create_compose_app` accordingly.
- **`Cannot insert NULL into column 'X'`** during DB seed — your operational DB's `Practice` schema differs slightly from what the script assumes. Inspect with `SELECT TOP 1 * FROM Practice` and patch the INSERT.

If anything crashes, the script raises the underlying exception so you
get a full traceback. Fix and re-run — idempotent.

## Security notes

- The script asks for credentials interactively and never writes them to disk.
- DB connection strings (which include the SQL password) DO get written into:
  - Coolify env vars (Coolify stores them encrypted; mark as Secret in the UI)
  - The `dbo.Practice.DBConnectionString` column (per the existing schema design — this is a system limitation)
- **Rotate the SQL password** after onboarding completes. The connection string with the password is now in: env vars, Practice rows, and the script's process memory.
- The Coolify API token is held only for the duration of the run.
- The reverse-proxy SSH password is used for SFTP + sudo writes, then discarded.

## Limitations / known gaps

- Doesn't apply schema to a brand-new DB — assumes `Practice` table exists. Easy to add: pipe `AppSetting.sql` through `_sqlcmd`. Skipped to avoid the script silently overwriting an existing DB.
- Doesn't manage DNS records. Add a provider client (Cloudflare, Route 53, etc.) if you want full automation.
- Coolify API surface is conservative — uses generic v4 endpoints. If your Coolify is much newer or older, `Coolify.set_env` and `create_compose_app` may need tweaks.
- Doesn't poll Coolify build status. After triggering deploy, it sleeps 30s then tests endpoints. First builds take 15–25 min so smoke-test results may be flaky on first run; re-run smoke section if needed.
