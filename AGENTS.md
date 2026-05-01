# AGENTS.md

Tool-agnostic agent instructions for the Practizing repo. Codex (and any other agent that respects this convention) reads this file at session start. Claude Code reads its own [CLAUDE.md](./CLAUDE.md), which references the same framework.

## Read these in order

This file is the **tool-agnostic** entry point. Claude Code uses [`CLAUDE.md`](./CLAUDE.md) instead, which has the same content from a Claude-runner's perspective. **Do not read both top-to-bottom — pick the one that matches your runner.** This file's reading order is canonical for non-Claude agents:

1. **This file (`AGENTS.md`)** — orientation + the three "must know before editing" rules below.
2. [`VIBECODING.md`](./VIBECODING.md) — framework index: subagents, skills, slash commands, migration-safe rules.
3. [`docs/architecture/SECURITY_AND_RISKS.md`](./docs/architecture/SECURITY_AND_RISKS.md) — the "do not break" list and the merge checklist.
4. [`STORED_PROCEDURES.md`](./STORED_PROCEDURES.md) — every active stored procedure, its caller, the dispatch tables, and known-broken references. Read before touching any SP.

For migration work, additionally:
5. [`docs/database/sql-server-to-postgres-migration-plan.md`](./docs/database/sql-server-to-postgres-migration-plan.md) — read the **Characterization-First TDD Migration Gate** section (near the top) before any SQL/PG/SP/EDI work.

## The three rules every agent must respect

1. **Permission filter is disabled.** Every authenticated user can hit every `[Authorize]` endpoint. Don't write code that *assumes* the controller will reject the user.
2. **`BaseRepository.ExecuteStoredProcedureAsync` is SQL-injectable.** Never pass user input to it. Use raw `SqlCommand` with explicitly-typed `SqlParameter` (not `AddWithValue`).
3. **Reports and scrubs are DB-dispatched.** SP names live in `PZ_Report.Command` and `Scrub.StoredProcedure` columns. Renaming an SP without updating those tables breaks production silently.

## Where the framework lives

Claude Code stores its agent definitions, skills, and slash commands under `.claude/`. Other agents can read those files as plain Markdown:

| Resource | Location | Format |
|---|---|---|
| Specialized agents (read-only investigators) | [.claude/agents/](./.claude/agents/) | Markdown with YAML frontmatter (`name`, `description`, `tools`) |
| Skills (workflow playbooks) | [.claude/skills/](./.claude/skills/) | One folder per skill containing `SKILL.md` |
| Slash commands (user-typed shortcuts) | [.claude/commands/](./.claude/commands/) | Markdown with frontmatter |
| Settings (Claude-specific) | `.claude/settings.json` (gitignored) | JSON |

If your agent runner doesn't natively support these formats, treat each file as a **prompt template**: read its body and follow its method.

### Agents available

| Agent | Purpose |
|---|---|
| `feature-tracer` | Walks UI → API → DB call graph for a named feature. |
| `sp-impact-analyzer` | Five-layer blast-radius check before renaming/dropping a stored procedure. |
| `safety-reviewer` | Pre-merge checklist enforcement. Default scope covers committed + staged + unstaged + untracked. |
| `db-introspector` | Read-only queries against the live `PI_ATC_CLINIC` SQL Server. |
| `test-coverage-planner` | Plans tests for a change, with characterization-first mode for migration PRs. |
| `catalog-sync-validator` | Detects drift between catalog docs and live DB. |

### Skills available

| Skill | Use when |
|---|---|
| `add-api-endpoint` | New CRUD endpoint in one of the 9 API services |
| `add-report` | New report row in `PZ_Report` (or, in migration-safe mode, a C# query handler) |
| `add-scrub` | New claim scrub rule (SP-only today; C# validator path is unimplemented) |
| `add-admin-screen` | New master-data list+detail screen in the root admin Angular app |
| `write-tests` | Author tests, with characterization-first mode for migration work |
| `remove-endpoint` | Retire an existing endpoint cleanly across all dispatch surfaces |
| `deprecate-feature` | Mark a feature for removal with a planned cutover date |

### Slash commands available

| Command | Effect |
|---|---|
| `/trace-feature <name>` | Invoke `feature-tracer` |
| `/sp-impact <sp_name>` | Invoke `sp-impact-analyzer` |
| `/safety-review [staged\|committed]` | Invoke `safety-reviewer` |
| `/db-query <question>` | Invoke `db-introspector` (read-only DB) |
| `/coverage-plan [feature]` | Invoke `test-coverage-planner` |
| `/validate-catalog` | Invoke `catalog-sync-validator` |

If you're not Claude Code, you can dispatch these manually by reading the corresponding `.claude/commands/<name>.md` and following its instructions.

## Migration-safe mode (active during the SQL → PG migration)

Read [VIBECODING.md §"Migration-safe mode"](./VIBECODING.md) for the full set of seven rules plus Rule 0 (characterization-first). The summary:

- **Rule 0:** SQL Server is the contract. Capture tests against SQL Server before any PG code; PG must pass the same tests unchanged. Coverage is secondary; **business parity is the release gate**.
- No new SQL Server stored procedures unless explicitly approved (mark `[migration-debt]` in `STORED_PROCEDURES.md`).
- No new triggers (the 221 existing ones are already a burden).
- No new T-SQL features that don't translate cleanly (`NEWID()`, `GETDATE()`, `TOP`, `ISNULL`, `WITH (NOLOCK)`, `MERGE`, `OUTPUT INTO`, `SCOPE_IDENTITY()`).
- No new `Parameters.AddWithValue`. Use explicit `SqlParameter` typing. For TVPs, set `SqlDbType.Structured` + `TypeName`.
- No new `dbo.PZ_Report.Command` strings of executable SQL. Use a `ReportKey` and a code-side handler.
- No new `Scrub.StoredProcedure` rows that depend on a C# validator branch — that branch isn't implemented.

## Live DB access

`PI_ATC_CLINIC` on `10.3.104.52`, SQL auth. Credentials are conversation-supplied — do not hardcode them. On Windows + Git Bash, prefix `docker run` with `MSYS_NO_PATHCONV=1` to stop path mangling.

Use the `db-introspector` agent (or `/db-query`) for read-only DB questions. The agent refuses mutations.

## Before merging non-trivial changes

1. Run `/safety-review` (or its equivalent in your runner). Default scope catches issues in committed + staged + unstaged + untracked changes.
2. For migration PRs: `/coverage-plan` switches to characterization-first mode automatically. The P0 test list captures SQL Server output, not author intent.
3. If you renamed/dropped an SP, run `/sp-impact` to confirm `PZ_Report.Command`, `Scrub.StoredProcedure`, and SQL Agent jobs all match.
4. The merge checklist is in [docs/architecture/SECURITY_AND_RISKS.md](./docs/architecture/SECURITY_AND_RISKS.md). The CI workflow in `.github/workflows/safety-review.yml` enforces the mechanically-checkable subset; humans still own the rest.

## What to do when this file is wrong

This file ages with the codebase. If you find a discrepancy, fix the doc in the same PR as your code change. Stale framework docs are worse than missing ones.
