# CLAUDE.md — Practizing API (Talbot Clinic)

Orientation for Claude / Codex / Gemini / any AI agent working in this repo. Read this once before touching code.

## What this repo is

.NET medical-billing API for the Practizing platform. Multi-project solution (`PractiZing.sln`) split into 9 service-bounded projects: `ChargePaymentService`, `ClaimService`, `DenialManagementService`, `ERAService`, `HostService`, `MasterService`, `PatientService`, `ReportService`, `SecurityService`. Each domain has its own `*.Api.*` (controllers), `*.BusinessLogic.*` (repositories/services), and `*.DataAccess.*` (entities/DTOs) sub-projects, all sharing `Common/` and `Base/`.

The Angular frontend is a sibling repo: `Practizing-ui-TALBOT_CLINIC` at `c:\Users\MadhukarNarahari\Documents\GitHub\Practizing-ui-TALBOT_CLINIC` — multi-project workspace (root admin + `pibilling` + `pipatient`) plus a `pi-lib` ng-packagr library.

## ⚠ Three things you must know before editing

1. **Permission filter is disabled.** Every authenticated user can hit every `[Authorize]` endpoint regardless of role. Don't write code that *assumes* the controller will reject the user — enforce role checks in the repository if needed.
2. **`BaseRepository.ExecuteStoredProcedureAsync` is SQL-injectable.** It builds SQL by string concat. Never pass user input to it; use raw `SqlCommand` with **explicit `SqlParameter` types** (avoid `AddWithValue` — its inferred types cause index scans and silent mis-promotion). For TVPs set `SqlDbType.Structured` + `TypeName` explicitly.
3. **Reports and scrubs are DB-dispatched.** SP names live in `PZ_Report.Command` and `Scrub.StoredProcedure` columns. Adding/removing reports usually means a DB row, not a code change. Renaming an SP without checking those tables silently breaks production.

The full risk list is in [docs/architecture/SECURITY_AND_RISKS.md](docs/architecture/SECURITY_AND_RISKS.md).

## VibeCoding Framework — the entry point

This repo ships a framework for safe AI-assisted development. **Use the entries in [VIBECODING.md](VIBECODING.md) before opening unfamiliar code.**

Quick map:
- **Architecture docs** → [docs/architecture/](docs/architecture/) — start at [SYSTEM_OVERVIEW.md](docs/architecture/SYSTEM_OVERVIEW.md)
- **How to add things** → [docs/conventions/RECIPES.md](docs/conventions/RECIPES.md)
- **Subagents** → [.claude/agents/](.claude/agents/) — `feature-tracer`, `sp-impact-analyzer`, `safety-reviewer`, `db-introspector`
- **Skills (workflows)** → [.claude/skills/](.claude/skills/) — `add-api-endpoint`, `add-report`, `add-scrub`, `add-admin-screen`
- **Slash commands** → [.claude/commands/](.claude/commands/) — `/trace-feature`, `/sp-impact`, `/safety-review`, `/db-query`

## Where documentation lives

**`docs/` is the canonical location for project documentation.** When you need context, look here first.

- **`docs/architecture/`** — system overview, API deep dive, UI deep dive, data flow, security & risks. Read [SYSTEM_OVERVIEW.md](docs/architecture/SYSTEM_OVERVIEW.md) first.
- **`docs/conventions/RECIPES.md`** — canonical patterns for adding endpoints, reports, scrubs, admin screens.
- **`docs/database/`** — DB schema and ER diagrams. Maintained by Codex. Source of truth for table-level questions.
- **`docs/database/sql-server-to-postgres-migration-plan.md`** — PostgreSQL migration plan. Defines "migration-safe mode" — read before adding any new stored procedure, trigger, or T-SQL feature.
- **`STORED_PROCEDURES.md`** (root) — every active stored procedure, its caller in C#, API endpoint, UI screen, inactive/orphaned SPs, and known-broken references. Read before adding any SP call or touching report/scrub dispatch.

When you create new docs, put them under `docs/` (e.g. `docs/runbooks/`, `docs/integrations/`). Root-level exceptions: `CLAUDE.md`, `VIBECODING.md`, `STORED_PROCEDURES.md`, `README.md` — those stay at root for discoverability.

## Live DB access

`PI_ATC_CLINIC` on `10.3.104.52`, SQL auth. Credentials are conversation-supplied — do not commit them. The `STORED_PROCEDURES.md` reference was generated against this DB; queries run via the `mcr.microsoft.com/mssql-tools` Docker image. On Git Bash on Windows, prefix `docker run` with `MSYS_NO_PATHCONV=1` to stop path mangling of `/opt/...` arguments. Use the `db-introspector` subagent or `/db-query` for read-only DB questions.

## Patterns worth knowing before you edit

- **ORM:** ServiceStack OrmLite via `BaseRepository<T>` in `Common/PractiZing.BusinessLogic.Common/`. Most CRUD goes through `Connection.Select/Insert/Update/Delete`. Audit columns are auto-stamped by `SetUserStamp`.
- **Multi-tenancy:** practice code resolves from HTTP `Host` header → `DataBaseContext` opens the matching connection string. PracticeId is stamped from JWT into every repository. Both should agree — they're not actively cross-checked.
- **Cross-service calls:** services do NOT reference each other's projects. They share the DB and (rarely) call HTTP. No queues, no SignalR.
- **Background jobs:** there are none in process. Long-running endpoints block the request thread; scheduled work is SQL Agent on the DB host.
- **Coolify/Docker:** one image per service via build-arg-parameterized `Dockerfile`. Container port `8080`; host bindings start at `8081`. See `coolify/README.md`.

## Working with the sibling UI repo

When tracing a bug from a UI screen back to a SP (or vice versa), the path is:
Angular component → Angular service (`*.service.ts`) → API controller → repository method → SP/table.
For every major feature, the cross-repo flow map is in [STORED_PROCEDURES.md §4](STORED_PROCEDURES.md). For an arbitrary feature, run `/trace-feature <name>`.

UI conventions and gotchas (Angular 7, RxJS 6, no NgRx, tab-based pseudo-routing, subscription leak risk) are in [docs/architecture/UI_ARCHITECTURE.md](docs/architecture/UI_ARCHITECTURE.md).

## Before merging non-trivial changes

Run `/safety-review`. It walks the project's risk checklist against the diff and reports PASS/FAIL per item. The full checklist is in [docs/architecture/SECURITY_AND_RISKS.md](docs/architecture/SECURITY_AND_RISKS.md#checklist-before-merging-a-non-trivial-change).
