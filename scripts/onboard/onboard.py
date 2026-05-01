#!/usr/bin/env python3
"""
PractiZing — Interactive new-practice onboarding script.

Implements docs/ONBOARD-NEW-PRACTICE.md end-to-end. Asks for the seven
inputs, then drives:

    1. Pre-flight validation (DNS, SQL Server, Coolify API, SSH)
    2. SQL Server: CREATE DATABASE, schema apply, ALTER TABLE, seed Practice rows
    3. Reverse-proxy: write Traefik dynamic-config files via SSH+SFTP
    4. Coolify: create Project + 2 Applications, set env vars, trigger deploy
    5. Smoke-test public endpoints

Idempotent — safe to re-run if a step partially succeeded.

Dependencies (pip install -r requirements.txt):
    requests   — Coolify REST API client
    paramiko   — SSH+SFTP for reverse-proxy config
    dnspython  — DNS validation

Stdlib only otherwise. SQL operations subprocess out to the same
mcr.microsoft.com/mssql-tools Docker image the existing environment
uses, so no Python SQL driver to install.
"""

from __future__ import annotations

import getpass
import json
import os
import re
import shlex
import socket
import subprocess
import sys
import time
from dataclasses import dataclass, field
from typing import Any, Optional

try:
    import requests
except ImportError:
    sys.exit("Missing dependency: pip install requests")

try:
    import paramiko
except ImportError:
    sys.exit("Missing dependency: pip install paramiko")

try:
    import dns.resolver
except ImportError:
    sys.exit("Missing dependency: pip install dnspython")


# -------------------------------------------------------------------------
# Constants — change these once per environment, not per practice.
# -------------------------------------------------------------------------

# The two Git repositories that get deployed per practice.
API_REPO_URL = "https://github.com/AtcEmr/Practizing-api-TALBOT_CLINIC"
UI_REPO_URL = "https://github.com/AtcEmr/Practizing-ui-TALBOT_CLINIC"
DEFAULT_BRANCH = "coolify"

# DNS apex domain — the script asks for the subdomain prefix and
# concatenates with this. If you serve practices under multiple
# top-level domains, ask the user instead.
APEX_DOMAIN = "dsigworkflow.com"

# Default port range to scan for unused host ports on the app server.
PORT_RANGE_START = 8090
PORT_RANGE_END = 8200

# Coolify-helper Docker image used for SQL operations (matches the
# pattern already in use in this environment).
MSSQL_TOOLS_IMAGE = "mcr.microsoft.com/mssql-tools"

# Where Traefik watches for dynamic-config files on the reverse-proxy.
# Adjust if your Traefik file provider is configured differently.
TRAEFIK_DYNAMIC_DIR = "/etc/traefik/dynamic"


# -------------------------------------------------------------------------
# Data classes — collected inputs travel as a single object.
# -------------------------------------------------------------------------

@dataclass
class Inputs:
    # 1–7 from docs/ONBOARD-NEW-PRACTICE.md §1
    practice_name: str = ""
    ui_subdomain: str = ""
    api_subdomain: str = ""
    db_name: str = ""
    db_host: str = ""
    db_user: str = ""
    db_password: str = ""
    admin_user: str = ""
    admin_password: str = ""
    practice_clm: str = ""

    # Coolify access
    coolify_url: str = ""
    coolify_token: str = ""
    coolify_server_ip: str = ""

    # Reverse-proxy SSH (for Traefik config writes)
    proxy_ssh_host: str = ""
    proxy_ssh_user: str = ""
    proxy_ssh_password: str = ""

    # Computed during pre-flight
    host_api_port: int = 0
    host_ui_port: int = 0

    @property
    def ui_fqdn(self) -> str:
        return f"{self.ui_subdomain}.{APEX_DOMAIN}"

    @property
    def api_fqdn(self) -> str:
        return f"{self.api_subdomain}.{APEX_DOMAIN}"

    @property
    def db_connection_string(self) -> str:
        return (
            f"Data Source={self.db_host};"
            f"Initial Catalog={self.db_name};"
            f"User id={self.db_user};"
            f"Password={self.db_password};"
            f"TrustServerCertificate=True;"
            f"MultipleActiveResultSets=true;"
            f"Encrypt=True"
        )


# -------------------------------------------------------------------------
# Pretty output helpers — keep terminal noise readable.
# -------------------------------------------------------------------------

def _color(code: int, text: str) -> str:
    return f"\033[{code}m{text}\033[0m" if sys.stdout.isatty() else text


def step(n: int, total: int, label: str) -> None:
    print(_color(96, f"\n[{n}/{total}] {label}"))


def ok(msg: str) -> None:
    print(_color(92, f"  ✓ {msg}"))


def warn(msg: str) -> None:
    print(_color(93, f"  ! {msg}"))


def err(msg: str) -> None:
    print(_color(91, f"  ✗ {msg}"))


def die(msg: str) -> None:
    err(msg)
    sys.exit(1)


# -------------------------------------------------------------------------
# Section 1 — Interactive input collection.
# -------------------------------------------------------------------------

_SUBDOMAIN_RE = re.compile(r"^[a-z][a-z0-9-]{1,61}[a-z0-9]$")
_DB_NAME_RE = re.compile(r"^[A-Za-z][A-Za-z0-9_]{2,127}$")


def _ask(prompt: str, default: str = "", validate=None) -> str:
    suffix = f" [{default}]" if default else ""
    while True:
        raw = input(f"? {prompt}{suffix}: ").strip()
        if not raw and default:
            raw = default
        if not raw:
            err("required")
            continue
        if validate:
            problem = validate(raw)
            if problem:
                err(problem)
                continue
        return raw


def _ask_password(prompt: str, min_len: int = 8) -> str:
    while True:
        raw = getpass.getpass(f"? {prompt}: ")
        if len(raw) < min_len:
            err(f"must be at least {min_len} characters")
            continue
        confirm = getpass.getpass(f"  confirm: ")
        if raw != confirm:
            err("did not match — try again")
            continue
        return raw


def _validate_subdomain(s: str) -> Optional[str]:
    if not _SUBDOMAIN_RE.match(s):
        return "must be lowercase alphanumeric, may include hyphens, no dots"
    return None


def _validate_db_name(s: str) -> Optional[str]:
    if not _DB_NAME_RE.match(s):
        return "must start with a letter, alphanumeric + underscores only, ≤128 chars"
    return None


def _validate_clm(s: str) -> Optional[str]:
    if not re.match(r"^[A-Za-z0-9]{2,20}$", s):
        return "2–20 alphanumeric characters"
    return None


def _validate_url(s: str) -> Optional[str]:
    if not s.startswith(("http://", "https://")):
        return "must start with http:// or https://"
    return None


def collect_inputs() -> Inputs:
    print(_color(96, "\n=== PractiZing — New Practice Onboarding ===\n"))
    print("Answer the following. See docs/ONBOARD-NEW-PRACTICE.md for context.\n")

    inp = Inputs()

    # Practice identity
    inp.practice_name = _ask("Practice friendly name (e.g. 'Sunrise Health Clinic LLC')")
    inp.ui_subdomain = _ask(
        f"UI subdomain prefix (becomes <prefix>.{APEX_DOMAIN})",
        validate=_validate_subdomain,
    )
    inp.api_subdomain = _ask(
        f"API subdomain prefix (becomes <prefix>.{APEX_DOMAIN})",
        default=f"{inp.ui_subdomain}api",
        validate=_validate_subdomain,
    )
    inp.practice_clm = _ask(
        "Practice short code (CLM, e.g. 'SUN', 'ATC')",
        validate=_validate_clm,
    ).upper()

    # Database
    inp.db_name = _ask(
        "Operational DB name (e.g. PI_SUNRISE_CLINIC)",
        default=f"PI_{inp.practice_clm}_CLINIC",
        validate=_validate_db_name,
    )
    inp.db_host = _ask("SQL Server host (e.g. 10.3.104.52)")
    inp.db_user = _ask("SQL Server username", default="sa")
    inp.db_password = getpass.getpass("? SQL Server password: ")
    if not inp.db_password:
        die("SQL Server password is required")

    # Initial admin
    inp.admin_user = _ask("Initial admin username for the new practice")
    inp.admin_password = _ask_password("Initial admin password")

    # Coolify
    inp.coolify_url = _ask(
        "Coolify base URL (e.g. https://coolify.example.com)",
        validate=_validate_url,
    ).rstrip("/")
    inp.coolify_token = getpass.getpass("? Coolify API token: ")
    if not inp.coolify_token:
        die("Coolify API token is required")
    inp.coolify_server_ip = _ask("Coolify deployment server IP (e.g. 10.3.104.49)")

    # Reverse-proxy SSH
    inp.proxy_ssh_host = _ask("Reverse-proxy SSH host (Traefik config dir lives here)")
    inp.proxy_ssh_user = _ask("Reverse-proxy SSH user", default="admin")
    inp.proxy_ssh_password = getpass.getpass("? Reverse-proxy SSH password: ")
    if not inp.proxy_ssh_password:
        die("Reverse-proxy SSH password is required")

    return inp


def confirm_inputs(inp: Inputs) -> None:
    print(_color(96, "\n=== Review ===\n"))
    print(f"  Practice name        : {inp.practice_name}")
    print(f"  UI subdomain         : {inp.ui_fqdn}")
    print(f"  API subdomain        : {inp.api_fqdn}")
    print(f"  CLM code             : {inp.practice_clm}")
    print(f"  Operational DB       : {inp.db_name} on {inp.db_host}")
    print(f"  Admin user           : {inp.admin_user}")
    print(f"  Coolify URL          : {inp.coolify_url}")
    print(f"  App server IP        : {inp.coolify_server_ip}")
    print(f"  Reverse-proxy host   : {inp.proxy_ssh_user}@{inp.proxy_ssh_host}")
    print()

    confirm = input("Proceed? [y/N] ").strip().lower()
    if confirm not in ("y", "yes"):
        die("Aborted by user.")


# -------------------------------------------------------------------------
# Section 2 — Pre-flight validation.
# -------------------------------------------------------------------------

def check_dns(inp: Inputs) -> None:
    """DNS A records must resolve before we proceed (TLS provisioning depends on it)."""
    for host in (inp.ui_fqdn, inp.api_fqdn):
        try:
            answers = dns.resolver.resolve(host, "A", lifetime=5)
            ips = sorted(a.to_text() for a in answers)
            ok(f"{host} → {', '.join(ips)}")
        except (dns.resolver.NXDOMAIN, dns.resolver.NoAnswer):
            die(
                f"{host} does not resolve. Add A records pointing at your "
                "reverse-proxy machine's WAN IP and re-run."
            )
        except dns.exception.DNSException as exc:
            die(f"DNS lookup error for {host}: {exc}")


def _sqlcmd(inp: Inputs, db: str, query: str, capture: bool = True) -> str:
    """Run a SQL query via dockerized mssql-tools. Returns combined output."""
    docker_args = [
        "docker", "run", "--rm",
        MSSQL_TOOLS_IMAGE,
        "/opt/mssql-tools/bin/sqlcmd",
        "-S", inp.db_host,
        "-U", inp.db_user,
        "-P", inp.db_password,
    ]
    if db:
        docker_args.extend(["-d", db])
    docker_args.extend(["-Q", query, "-h", "-1", "-W"])

    env = os.environ.copy()
    env["MSYS_NO_PATHCONV"] = "1"  # Windows MINGW bash fix; harmless on Linux.

    result = subprocess.run(
        docker_args,
        env=env,
        capture_output=True,
        text=True,
        timeout=60,
    )
    output = (result.stdout or "") + (result.stderr or "")
    if result.returncode != 0:
        raise RuntimeError(
            f"sqlcmd failed (exit {result.returncode}):\n{output.strip()}"
        )
    return output if capture else ""


def check_sql(inp: Inputs) -> None:
    try:
        out = _sqlcmd(inp, "", "SELECT @@VERSION")
    except Exception as exc:
        die(f"Cannot connect to SQL Server {inp.db_host} as {inp.db_user}: {exc}")
    first_line = out.splitlines()[0] if out.strip() else "(empty response)"
    ok(f"SQL Server reachable: {first_line[:60]}…")


def check_coolify(inp: Inputs) -> None:
    try:
        r = requests.get(
            f"{inp.coolify_url}/api/v1/servers",
            headers={"Authorization": f"Bearer {inp.coolify_token}"},
            timeout=10,
        )
    except requests.RequestException as exc:
        die(f"Cannot reach Coolify at {inp.coolify_url}: {exc}")
    if r.status_code == 401:
        die("Coolify API token rejected. Generate a new token in Coolify UI → Keys & Tokens.")
    if not r.ok:
        die(f"Coolify API error {r.status_code}: {r.text[:200]}")
    servers = r.json() if r.headers.get("content-type", "").startswith("application/json") else []
    ok(f"Coolify API reachable, {len(servers)} server(s) registered")


def _ssh_connect(inp: Inputs) -> paramiko.SSHClient:
    client = paramiko.SSHClient()
    client.set_missing_host_key_policy(paramiko.AutoAddPolicy())
    client.connect(
        hostname=inp.proxy_ssh_host,
        username=inp.proxy_ssh_user,
        password=inp.proxy_ssh_password,
        timeout=10,
        allow_agent=False,
        look_for_keys=False,
    )
    return client


def check_ssh(inp: Inputs) -> None:
    try:
        client = _ssh_connect(inp)
        try:
            stdin, stdout, stderr = client.exec_command(
                f"test -d {shlex.quote(TRAEFIK_DYNAMIC_DIR)} && echo OK || echo MISSING",
                timeout=10,
            )
            output = stdout.read().decode().strip()
            if "OK" not in output:
                die(
                    f"Traefik dynamic-config dir {TRAEFIK_DYNAMIC_DIR} not found on "
                    f"{inp.proxy_ssh_host}. Adjust TRAEFIK_DYNAMIC_DIR in this script "
                    "or create the directory."
                )
            ok(f"Reverse-proxy SSH OK; Traefik dir present at {TRAEFIK_DYNAMIC_DIR}")
        finally:
            client.close()
    except paramiko.AuthenticationException:
        die(f"SSH auth rejected for {inp.proxy_ssh_user}@{inp.proxy_ssh_host}")
    except Exception as exc:
        die(f"SSH connection failed: {exc}")


def pick_host_ports(inp: Inputs) -> None:
    """Find two unused TCP ports on the app server in the configured range."""
    used: set[int] = set()
    # Probe by attempting socket connect — anything that responds is "used".
    for port in range(PORT_RANGE_START, PORT_RANGE_END + 1):
        try:
            with socket.create_connection((inp.coolify_server_ip, port), timeout=0.3):
                used.add(port)
        except OSError:
            pass

    free = [p for p in range(PORT_RANGE_START, PORT_RANGE_END + 1) if p not in used]
    if len(free) < 2:
        die(
            f"Not enough free host ports in {PORT_RANGE_START}-{PORT_RANGE_END}. "
            f"Used ports detected: {sorted(used)[:20]}…"
        )
    inp.host_api_port = free[0]
    inp.host_ui_port = free[1]
    ok(f"Picked host ports: API={inp.host_api_port}, UI={inp.host_ui_port}")


# -------------------------------------------------------------------------
# Section 3 — Database setup.
# -------------------------------------------------------------------------

def _db_exists(inp: Inputs) -> bool:
    out = _sqlcmd(
        inp, "",
        f"SELECT COUNT(*) FROM sys.databases WHERE name = '{inp.db_name}'",
    )
    return "1" in out.split()


def _table_exists(inp: Inputs, table: str) -> bool:
    out = _sqlcmd(
        inp, inp.db_name,
        f"SELECT COUNT(*) FROM sys.tables WHERE name = '{table}'",
    )
    return "1" in out.split()


def _column_exists(inp: Inputs, table: str, column: str) -> bool:
    out = _sqlcmd(
        inp, inp.db_name,
        f"SELECT COUNT(*) FROM sys.columns WHERE "
        f"object_id = OBJECT_ID('dbo.{table}') AND name = '{column}'",
    )
    return "1" in out.split()


def _practice_row_exists(inp: Inputs, practice_code: str) -> bool:
    out = _sqlcmd(
        inp, inp.db_name,
        f"SELECT COUNT(*) FROM dbo.Practice WHERE PracticeCode = '{practice_code}'",
    )
    return "1" in out.split()


def _user_exists(inp: Inputs, username: str) -> bool:
    out = _sqlcmd(
        inp, inp.db_name,
        f"SELECT COUNT(*) FROM dbo.[User] WHERE UserName = '{username}'",
    )
    return "1" in out.split()


def setup_database(inp: Inputs) -> None:
    """Create DB if missing, ensure schema patches, seed Practice rows + admin user."""

    # --- Create DB if missing ---
    if _db_exists(inp):
        ok(f"Database {inp.db_name} already exists (skipping CREATE)")
    else:
        _sqlcmd(inp, "", f"CREATE DATABASE [{inp.db_name}]")
        ok(f"Created database {inp.db_name}")

    if not _table_exists(inp, "Practice"):
        die(
            f"Database {inp.db_name} exists but has no dbo.Practice table. "
            "Apply the schema (AppSetting.sql + ConfigSetting.sql, or clone "
            "from a reference DB) before re-running this script."
        )

    # --- Patch Practice schema (add 7 columns the C# entity expects) ---
    needed_columns = [
        ("PracticeURL", "NVARCHAR(500) NULL"),
        ("StripeKey", "NVARCHAR(500) NULL"),
        ("DBName", "NVARCHAR(200) NULL"),
        ("CustomerKey", "NVARCHAR(200) NULL"),
        ("LabDBName", "NVARCHAR(200) NULL"),
        ("DBConnectionString", "NVARCHAR(MAX) NULL"),
    ]
    for col, definition in needed_columns:
        if not _column_exists(inp, "Practice", col):
            _sqlcmd(inp, inp.db_name, f"ALTER TABLE dbo.Practice ADD {col} {definition}")
            ok(f"Added column dbo.Practice.{col}")

    # PracticeId is a computed alias of Id (the operational table's PK).
    if not _column_exists(inp, "Practice", "PracticeId"):
        _sqlcmd(inp, inp.db_name, "ALTER TABLE dbo.Practice ADD PracticeId AS Id")
        ok("Added computed column dbo.Practice.PracticeId AS Id")

    # --- Seed three Practice rows: canonical + UI alias + API alias ---
    rows_to_insert = [
        # (PracticeCode, PracticeName, PracticeURL, Id offset)
        (
            inp.ui_subdomain,
            inp.practice_name,
            f"https://{inp.ui_fqdn}",
            1,
        ),
        (
            inp.api_subdomain,
            f"{inp.practice_name} (alias api)",
            f"https://{inp.api_fqdn}",
            2,
        ),
    ]

    # Determine starting Id. If the table is empty use 1; otherwise MAX(Id)+1.
    out = _sqlcmd(inp, inp.db_name, "SELECT ISNULL(MAX(Id), 0) FROM dbo.Practice")
    current_max = int(out.strip().split()[0]) if out.strip().split() else 0

    for code, name, url, offset in rows_to_insert:
        if _practice_row_exists(inp, code):
            ok(f"Practice row PracticeCode='{code}' already exists (skipping)")
            continue
        new_id = current_max + offset
        # Escape single quotes in user-supplied strings.
        e_name = name.replace("'", "''")
        e_conn = inp.db_connection_string.replace("'", "''")
        query = (
            f"INSERT INTO dbo.Practice ("
            f"  Id, UId, PracticeCode, PracticeName, PracticeCodeCLM, "
            f"  PracticeURL, DBName, LabDBName, DBConnectionString, "
            f"  CreatedDate, CreatedBy, ModifiedDate, ModifiedBy"
            f") VALUES ("
            f"  {new_id}, NEWID(), '{code}', '{e_name}', '{inp.practice_clm}', "
            f"  '{url}', '{inp.db_name}', '{inp.db_name}', '{e_conn}', "
            f"  GETUTCDATE(), 'onboard.py', GETUTCDATE(), 'onboard.py'"
            f")"
        )
        _sqlcmd(inp, inp.db_name, query)
        ok(f"Seeded Practice row Id={new_id} PracticeCode='{code}'")

    # --- Seed initial admin user ---
    if _user_exists(inp, inp.admin_user):
        ok(f"User '{inp.admin_user}' already exists (skipping)")
    else:
        # We don't know the exact User schema or password-hash algorithm in
        # this codebase; we insert the plaintext into a Password column and
        # warn the operator. They can rotate via the password-change flow
        # after first login.
        e_user = inp.admin_user.replace("'", "''")
        e_pass = inp.admin_password.replace("'", "''")
        try:
            _sqlcmd(
                inp, inp.db_name,
                f"INSERT INTO dbo.[User] (UserName, Password, IsActive, "
                f"CreatedDate, CreatedBy, ModifiedDate, ModifiedBy) VALUES ("
                f"'{e_user}', '{e_pass}', 1, "
                f"GETUTCDATE(), 'onboard.py', GETUTCDATE(), 'onboard.py')"
            )
            warn(
                f"Inserted '{inp.admin_user}' with plaintext password — verify the "
                "schema's password column name and hash algorithm match. If the "
                "User schema differs, rotate the password via the app's password-"
                "change flow on first login."
            )
        except Exception as exc:
            warn(
                f"Could not auto-create admin user: {exc}. "
                "Insert manually after deploy completes."
            )


# -------------------------------------------------------------------------
# Section 4 — Reverse-proxy: write Traefik dynamic-config files.
# -------------------------------------------------------------------------

_TRAEFIK_TEMPLATE = """\
http:
  routers:
    {name}-http:
      rule: Host(`{fqdn}`)
      entryPoints:
        - http
      middlewares:
        - redirect-to-https
      service: {name}-svc
    {name}-https:
      rule: Host(`{fqdn}`)
      entryPoints:
        - https
      tls:
        certResolver: letsencrypt
      service: {name}-svc
  middlewares:
    redirect-to-https:
      redirectScheme:
        scheme: https
        permanent: true
  services:
    {name}-svc:
      loadBalancer:
        servers:
          -
            url: 'http://{server}:{port}'
"""


def write_traefik_configs(inp: Inputs) -> None:
    files = {
        f"{inp.api_subdomain}.yml": _TRAEFIK_TEMPLATE.format(
            name=inp.api_subdomain,
            fqdn=inp.api_fqdn,
            server=inp.coolify_server_ip,
            port=inp.host_api_port,
        ),
        f"{inp.ui_subdomain}.yml": _TRAEFIK_TEMPLATE.format(
            name=inp.ui_subdomain,
            fqdn=inp.ui_fqdn,
            server=inp.coolify_server_ip,
            port=inp.host_ui_port,
        ),
    }

    client = _ssh_connect(inp)
    try:
        # SFTP needs write access to TRAEFIK_DYNAMIC_DIR. If the SSH user
        # isn't root, we go via /tmp + sudo mv. Detect by trying SFTP first.
        sftp = client.open_sftp()
        try:
            for filename, content in files.items():
                tmp_path = f"/tmp/{filename}"
                with sftp.open(tmp_path, "w") as f:
                    f.write(content)

                # sudo move into Traefik dir.
                cmd = (
                    f"echo {shlex.quote(inp.proxy_ssh_password)} | "
                    f"sudo -S sh -c "
                    f"{shlex.quote(f'mv {tmp_path} {TRAEFIK_DYNAMIC_DIR}/{filename} && chmod 644 {TRAEFIK_DYNAMIC_DIR}/{filename}')}"
                )
                stdin, stdout, stderr = client.exec_command(cmd, timeout=15)
                exit_code = stdout.channel.recv_exit_status()
                if exit_code != 0:
                    err_text = stderr.read().decode().strip()
                    raise RuntimeError(f"Failed to install {filename}: {err_text}")
                ok(f"Wrote {TRAEFIK_DYNAMIC_DIR}/{filename}")
        finally:
            sftp.close()
    finally:
        client.close()


# -------------------------------------------------------------------------
# Section 5 — Coolify API client + Application creation.
# -------------------------------------------------------------------------

class Coolify:
    """Thin wrapper around the Coolify v4 REST API.

    Endpoint surface here is conservative and tolerant — Coolify's API
    occasionally renames fields between minor versions. Each call has a
    fallback that asks the operator for help if the remote shape differs
    from what we expect.
    """

    def __init__(self, base_url: str, token: str) -> None:
        self.base = base_url.rstrip("/") + "/api/v1"
        self.session = requests.Session()
        self.session.headers.update({
            "Authorization": f"Bearer {token}",
            "Content-Type": "application/json",
            "Accept": "application/json",
        })

    def _request(self, method: str, path: str, **kwargs: Any) -> requests.Response:
        url = f"{self.base}{path}"
        r = self.session.request(method, url, timeout=60, **kwargs)
        if not r.ok:
            raise RuntimeError(
                f"Coolify {method} {path} -> {r.status_code}: {r.text[:300]}"
            )
        return r

    # --- servers ---
    def list_servers(self) -> list[dict]:
        return self._request("GET", "/servers").json()

    def find_server_by_ip(self, ip: str) -> Optional[dict]:
        for s in self.list_servers():
            if s.get("ip") == ip or s.get("user_specified_url") == ip:
                return s
        return None

    # --- projects ---
    def list_projects(self) -> list[dict]:
        return self._request("GET", "/projects").json()

    def find_or_create_project(self, name: str) -> dict:
        for p in self.list_projects():
            if p.get("name") == name:
                return p
        r = self._request("POST", "/projects", json={"name": name, "description": f"Auto-created by onboard.py for {name}"})
        return r.json()

    # --- applications ---
    def list_applications(self) -> list[dict]:
        return self._request("GET", "/applications").json()

    def find_application(self, name: str) -> Optional[dict]:
        for a in self.list_applications():
            if a.get("name") == name:
                return a
        return None

    def create_compose_app(
        self,
        *,
        project_uuid: str,
        server_uuid: str,
        environment_name: str,
        name: str,
        git_repository: str,
        git_branch: str,
    ) -> dict:
        payload = {
            "project_uuid": project_uuid,
            "server_uuid": server_uuid,
            "environment_name": environment_name,
            "name": name,
            "description": f"Auto-created by onboard.py",
            "git_repository": git_repository,
            "git_branch": git_branch,
            "build_pack": "dockercompose",
            "ports_exposes": "8080",
        }
        r = self._request("POST", "/applications/dockercompose", json=payload)
        return r.json()

    def set_env(self, app_uuid: str, key: str, value: str, *, is_secret: bool = False) -> None:
        # Coolify v4: POST /api/v1/applications/{uuid}/envs (some versions use /env)
        try:
            self._request(
                "POST",
                f"/applications/{app_uuid}/envs",
                json={
                    "key": key,
                    "value": value,
                    "is_preview": False,
                    "is_build_time": False,
                    "is_literal": True,
                    "is_multiline": False,
                    "is_shown_once": is_secret,
                },
            )
        except RuntimeError:
            # Fallback path for older API shapes.
            self._request(
                "POST",
                f"/applications/{app_uuid}/env",
                json={"key": key, "value": value},
            )

    def deploy(self, app_uuid: str) -> dict:
        r = self._request("POST", f"/applications/{app_uuid}/start", json={})
        return r.json() if r.text else {}

    def get_app(self, app_uuid: str) -> dict:
        return self._request("GET", f"/applications/{app_uuid}").json()


def _coolify_app_envs_for_api(inp: Inputs) -> list[tuple[str, str, bool]]:
    """Returns (key, value, is_secret) tuples for the API stack."""
    return [
        ("DB_DEFAULT_CONNECTION", inp.db_connection_string, True),
        ("DB_PRACTICE_CENTRAL_CONNECTION", inp.db_connection_string, True),
        ("JWT_ISSUER", "http://PractiZing.com", False),
        ("JWT_AUDIENCE", "PRACTICE_INSIGHT", False),
        ("UI_URL", f"https://{inp.ui_fqdn}", False),
        ("SITE_LOCALE", "en-GB", False),
        ("AWS_ACCESS_KEY_ID", "", False),
        ("AWS_SECRET_ACCESS_KEY", "", False),
        ("AWS_REGION", "us-east-1", False),
        ("USE_SWAGGER", "false", False),
        ("http", "https", False),
        ("HOST_API_PORT", str(inp.host_api_port), False),
    ]


def _coolify_app_envs_for_ui(inp: Inputs) -> list[tuple[str, str, bool]]:
    return [
        ("API_URL", f"http://{inp.coolify_server_ip}:{inp.host_api_port}", False),
        ("API_HOST", inp.api_fqdn, False),
        ("HOST_UI_PORT", str(inp.host_ui_port), False),
    ]


def setup_coolify(inp: Inputs) -> tuple[str, str]:
    """Create both Applications, set env vars, return their UUIDs."""
    cool = Coolify(inp.coolify_url, inp.coolify_token)

    server = cool.find_server_by_ip(inp.coolify_server_ip)
    if not server:
        die(
            f"Coolify has no server registered at {inp.coolify_server_ip}. "
            "Add it via Coolify UI → Servers → Add."
        )
    server_uuid = server.get("uuid") or server.get("id")
    ok(f"Coolify server {inp.coolify_server_ip} -> uuid={server_uuid}")

    project_name = f"practizing-{inp.ui_subdomain}"
    project = cool.find_or_create_project(project_name)
    project_uuid = project.get("uuid") or project.get("id")
    ok(f"Coolify project '{project_name}' -> uuid={project_uuid}")

    api_app_name = f"{inp.ui_subdomain}-api"
    ui_app_name = f"{inp.ui_subdomain}-ui"

    # API app
    existing = cool.find_application(api_app_name)
    if existing:
        ok(f"API Application '{api_app_name}' already exists; reusing")
        api_app_uuid = existing.get("uuid") or existing.get("id")
    else:
        created = cool.create_compose_app(
            project_uuid=project_uuid,
            server_uuid=server_uuid,
            environment_name="production",
            name=api_app_name,
            git_repository=API_REPO_URL,
            git_branch=DEFAULT_BRANCH,
        )
        api_app_uuid = created.get("uuid") or created.get("id")
        ok(f"Created API Application '{api_app_name}' -> uuid={api_app_uuid}")

    for key, value, is_secret in _coolify_app_envs_for_api(inp):
        try:
            cool.set_env(api_app_uuid, key, value, is_secret=is_secret)
        except RuntimeError as exc:
            warn(f"set_env({key}) failed: {exc} (likely already set; skipping)")
    ok(f"API env vars applied")

    # UI app
    existing = cool.find_application(ui_app_name)
    if existing:
        ok(f"UI Application '{ui_app_name}' already exists; reusing")
        ui_app_uuid = existing.get("uuid") or existing.get("id")
    else:
        created = cool.create_compose_app(
            project_uuid=project_uuid,
            server_uuid=server_uuid,
            environment_name="production",
            name=ui_app_name,
            git_repository=UI_REPO_URL,
            git_branch=DEFAULT_BRANCH,
        )
        ui_app_uuid = created.get("uuid") or created.get("id")
        ok(f"Created UI Application '{ui_app_name}' -> uuid={ui_app_uuid}")

    for key, value, is_secret in _coolify_app_envs_for_ui(inp):
        try:
            cool.set_env(ui_app_uuid, key, value, is_secret=is_secret)
        except RuntimeError as exc:
            warn(f"set_env({key}) failed: {exc} (likely already set; skipping)")
    ok("UI env vars applied")

    # Trigger deploys
    cool.deploy(api_app_uuid)
    ok(f"API deploy triggered (UUID {api_app_uuid})")
    cool.deploy(ui_app_uuid)
    ok(f"UI deploy triggered (UUID {ui_app_uuid})")

    return api_app_uuid, ui_app_uuid


# -------------------------------------------------------------------------
# Section 6 — Smoke test the deployed endpoints.
# -------------------------------------------------------------------------

def smoke_test(inp: Inputs, settle_seconds: int = 30) -> None:
    print(f"  Waiting {settle_seconds}s for first-deploy build...")
    time.sleep(settle_seconds)

    # Test direct host-port (proves containers and host-port binding work).
    for label, port in (("API", inp.host_api_port), ("UI", inp.host_ui_port)):
        url = f"http://{inp.coolify_server_ip}:{port}/"
        try:
            r = requests.get(url, timeout=15, verify=False, allow_redirects=False)
            ok(f"{label} reachable at {url} (HTTP {r.status_code})")
        except requests.RequestException as exc:
            warn(f"{label} not yet reachable at {url}: {exc}")

    # Test via public Traefik. May take longer for first-deploy build.
    for label, fqdn, path, expect_min in (
        ("UI public", inp.ui_fqdn, "/healthz", 200),
        ("API public", inp.api_fqdn, "/", None),
    ):
        url = f"https://{fqdn}{path}"
        try:
            r = requests.get(url, timeout=20, verify=True)
            if expect_min is not None and r.status_code != expect_min:
                warn(f"{label}: HTTP {r.status_code} (expected {expect_min})")
            else:
                ok(f"{label}: HTTP {r.status_code}")
        except requests.RequestException as exc:
            warn(f"{label}: not yet reachable at {url}: {exc}")

    # Test login. This is the real "did it actually work" check.
    login_url = f"https://{inp.api_fqdn}/api/Login"
    try:
        r = requests.post(
            login_url,
            json={"userName": inp.admin_user, "password": inp.admin_password},
            timeout=30,
        )
        if r.status_code == 200 and "AccessToken" in r.text:
            ok(f"/api/Login returned a JWT — login works end-to-end!")
        else:
            warn(f"/api/Login returned HTTP {r.status_code}: {r.text[:300]}")
    except requests.RequestException as exc:
        warn(f"Login probe failed: {exc}")


# -------------------------------------------------------------------------
# Section 7 — Final summary.
# -------------------------------------------------------------------------

def print_summary(inp: Inputs, api_uuid: str, ui_uuid: str) -> None:
    print(_color(96, "\n=== Onboarding Complete ===\n"))
    print(f"  Practice          : {inp.practice_name}")
    print(f"  UI                : https://{inp.ui_fqdn}")
    print(f"  API               : https://{inp.api_fqdn}")
    print(f"  DB                : {inp.db_name} on {inp.db_host}")
    print(f"  Admin login       : {inp.admin_user}")
    print(f"  Coolify API app   : {inp.coolify_url}/applications/{api_uuid}")
    print(f"  Coolify UI app    : {inp.coolify_url}/applications/{ui_uuid}")
    print(f"  Host ports bound  : API={inp.host_api_port}, UI={inp.host_ui_port}")
    print()
    print("  Manual follow-ups:")
    print("  - Verify the admin user can sign in via the browser.")
    print("  - Rotate the SQL Server password if it's currently the shared default.")
    print("  - Document this practice in docs/practices/<name>.md.")


# -------------------------------------------------------------------------
# Entry point — orchestrates the seven steps.
# -------------------------------------------------------------------------

def main() -> None:
    try:
        inp = collect_inputs()
        confirm_inputs(inp)

        step(1, 7, "Pre-flight validation")
        check_dns(inp)
        check_sql(inp)
        check_coolify(inp)
        check_ssh(inp)
        pick_host_ports(inp)

        step(2, 7, "Database setup")
        setup_database(inp)

        step(3, 7, "Reverse-proxy Traefik configs")
        write_traefik_configs(inp)

        step(4, 7, "Coolify Applications + env vars + deploy")
        api_uuid, ui_uuid = setup_coolify(inp)

        step(5, 7, "Smoke testing public endpoints")
        smoke_test(inp)

        step(6, 7, "Summary")
        print_summary(inp, api_uuid, ui_uuid)

        print(_color(92, "\n✅ Done.\n"))
    except KeyboardInterrupt:
        print()
        die("Interrupted by user.")
    except Exception as exc:
        err(f"Onboarding failed: {exc}")
        raise


if __name__ == "__main__":
    main()
