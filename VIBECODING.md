# VibeCoding Framework — Practizing

A framework for safe AI-assisted development on the Practizing medical-billing platform. Designed to be tool-agnostic — works with Claude Code, Codex, Gemini, or any agent that reads project files.

If you are an AI agent: read this file once, then keep [CLAUDE.md](CLAUDE.md) and [docs/architecture/SECURITY_AND_RISKS.md](docs/architecture/SECURITY_AND_RISKS.md) loaded as context for the rest of the session.

---

## Why this exists

Two things make this codebase hostile to surface-level edits:

1. **Stored procedures are dispatched from DB tables.** `PZ_Report.Command` and `Scrub.StoredProcedure` hold SP names that no `grep` will find. Renaming an SP based on a code search alone silently breaks production.
2. **Several safety rails are off.** The role/permission filter is commented out, the JWT secret is hardcoded, dev DB credentials are checked in, the default SP runner is SQL-injectable. New code must not pile on; old code is being fixed gradually.

The framework gives any AI agent the docs, subagents, skills, and commands needed to understand the system before changing it, and to verify changes before merging.

---

## The four layers

```
┌─────────────────────────────────────────────────────────────┐
│  Layer 1 — DOCS  (what is true)                             │
│  docs/architecture/ + docs/conventions/ + STORED_PROCEDURES │
│  + docs/database/ (Codex-maintained schema)                 │
└─────────────────────────────────────────────────────────────┘
┌─────────────────────────────────────────────────────────────┐
│  Layer 2 — SUBAGENTS  (read-only experts)                   │
│  .claude/agents/  — focused investigation, no editing       │
└─────────────────────────────────────────────────────────────┘
┌─────────────────────────────────────────────────────────────┐
│  Layer 3 — SKILLS  (how to add things safely)               │
│  .claude/skills/  — repeatable workflows with guardrails    │
└─────────────────────────────────────────────────────────────┘
┌─────────────────────────────────────────────────────────────┐
│  Layer 4 — COMMANDS  (one-line shortcuts)                   │
│  .claude/commands/  — user-typed entry points to the above  │
└─────────────────────────────────────────────────────────────┘
```

The flow for a typical task:
1. Read **docs** for orientation.
2. Run a **command** that delegates to a **subagent** to gather facts (where is X? what would Y break?).
3. Apply a **skill** to make the change in the canonical pattern.
4. Run `/safety-review` before merging.

---

## Layer 1 — Documentation

Read in order on first contact with this codebase:

| Doc | Purpose |
|---|---|
| [CLAUDE.md](CLAUDE.md) | Top-of-the-funnel orientation. The "must-know-before-editing" list. |
| [docs/architecture/SYSTEM_OVERVIEW.md](docs/architecture/SYSTEM_OVERVIEW.md) | Five perspectives on the same code. Glossary. |
| [docs/architecture/API_ARCHITECTURE.md](docs/architecture/API_ARCHITECTURE.md) | The 9 service projects, DI, conventions, anti-patterns. |
| [docs/architecture/UI_ARCHITECTURE.md](docs/architecture/UI_ARCHITECTURE.md) | Angular workspace, routing, state, interceptors, smells. |
| [docs/architecture/DATA_FLOW.md](docs/architecture/DATA_FLOW.md) | UI → API → DB request path, worked examples, multi-tenant rules. |
| [docs/architecture/SECURITY_AND_RISKS.md](docs/architecture/SECURITY_AND_RISKS.md) | The "do not break" list. Read before any non-trivial change. |
| [docs/conventions/RECIPES.md](docs/conventions/RECIPES.md) | Canonical "how to add X" patterns. |
| [STORED_PROCEDURES.md](STORED_PROCEDURES.md) | Every active SP, its caller, the dispatch tables, and known-broken references. |
| [docs/database/](docs/database/) | DB schema (maintained by Codex). |
| [docs/database/sql-server-to-postgres-migration-plan.md](docs/database/sql-server-to-postgres-migration-plan.md) | The PostgreSQL migration plan. Read before authoring any new stored procedure. Defines "migration-safe mode." |
| [docs/database/postgres-schema-conversion.md](docs/database/postgres-schema-conversion.md) | Table-side conversion worksheet — per-decision and per-rule status, per-table progress. Update as Phase 0 closes. |
| [docs/database/postgres-sp-conversion.md](docs/database/postgres-sp-conversion.md) | SP-side conversion worksheet — per-procedure migration tracker for all 131 user SPs. Parallel to the table worksheet. |
| [docs/database/postgres/](docs/database/postgres/) | Destination folder for actual PostgreSQL DDL artifacts. Empty until Phase 0 ratifies. |

## Migration-safe mode

The team is moving from SQL Server to PostgreSQL on a multi-quarter timeline. While that's underway, every code change should respect a small set of **migration-safe** rules that keep the backlog from growing.

### Rule 0 — Characterization-first TDD (overrides all others)

**SQL Server is the contract. Capture tests against SQL Server before changing anything; PostgreSQL must pass the same tests unchanged.** No PG slice ships without its SQL Server fixture in the same PR (or already on `main`).

This is a first-class migration principle, not a guideline. See the [Characterization-First TDD Migration Gate](docs/database/sql-server-to-postgres-migration-plan.md) section in the migration plan for the full statement, the required golden-master fixture list (reports, scrubs, SPs, EDI 837/835, payments, denials, aging, statements, multi-tenant boundary), and the per-phase impact.

When in doubt: the SQL Server output is correct, including the bugs, until the migration decision log says otherwise. Coverage is secondary; **business parity is the release gate**.

### Other migration-safe rules

When migration-safe mode is **active** (ask the user; or check whether the migration plan has been formally adopted):

1. **No new SQL Server stored procedures** unless explicitly approved. Prefer typed C# query handlers / services. If you must add one, mark it `[migration-debt]` in [STORED_PROCEDURES.md](STORED_PROCEDURES.md) so the retirement project can budget for it.
2. **No new uses of `BaseRepository.ExecuteStoredProcedureAsync`.** Route SP calls through the planned `IRoutineExecutor` boundary if it exists, or keep them confined to the legacy paths that are already there.
3. **No new T-SQL features** that don't translate cleanly: `NEWID()`, `GETDATE()`, `TOP`, `ISNULL`, `WITH (NOLOCK)`, `MERGE`, `OUTPUT INTO`, `SCOPE_IDENTITY()`. Use portable equivalents (`COALESCE`, parameter for the date, etc.).
4. **No new triggers.** The 221 existing triggers are already a migration burden; do not add to them. Use application-level audit writes.
5. **No new `dbo.PZ_Report.Command` strings of executable SQL.** When adding a report, prefer a code-side handler and a `ReportKey`. If the legacy column is the only way today, mark the row.
6. **No new `Scrub.StoredProcedure` rows that depend on a C# validator branch** — that branch isn't implemented. See the [add-scrub skill](.claude/skills/add-scrub/SKILL.md).
7. **All raw SQL must use explicit `SqlParameter` typing** (not `AddWithValue`) so the same code can move to Npgsql with minimal changes.

When migration-safe mode is **not** active (early development, or the team has not yet committed): follow current conventions, but every new SP/trigger you add will have to be retired later. Tag them anyway.

The skills in `.claude/skills/` each have a "Migration-safe mode" section that maps to these rules.

---

## Layer 2 — Subagents

Specialist agents that investigate without editing. Use them via slash commands or by name.

| Agent | Use when |
|---|---|
| `feature-tracer` ([.claude/agents/feature-tracer.md](.claude/agents/feature-tracer.md)) | You need to know how a feature works end-to-end before touching it. |
| `sp-impact-analyzer` ([.claude/agents/sp-impact-analyzer.md](.claude/agents/sp-impact-analyzer.md)) | You're about to rename, drop, or change the signature of a stored procedure. |
| `safety-reviewer` ([.claude/agents/safety-reviewer.md](.claude/agents/safety-reviewer.md)) | You're about to merge a non-trivial change. Default scope covers committed + staged + unstaged + untracked. |
| `db-introspector` ([.claude/agents/db-introspector.md](.claude/agents/db-introspector.md)) | You need actual DB state — table columns, SP body, dependency lookup. Read-only. |
| `test-coverage-planner` ([.claude/agents/test-coverage-planner.md](.claude/agents/test-coverage-planner.md)) | You're about to merge code without tests, or want to plan what to test for a feature. |
| `catalog-sync-validator` ([.claude/agents/catalog-sync-validator.md](.claude/agents/catalog-sync-validator.md)) | Detects drift between catalog docs (`STORED_PROCEDURES.md`, postgres-sp-conversion, postgres-schema-conversion) and the live DB. Run monthly during steady state, weekly during migration phases. |

For agents other than Claude (Codex, Gemini): the subagent files are plain Markdown with YAML frontmatter. The frontmatter `description` and the body's "Method" + "Output shape" sections are the contract. You can adapt them to your own runner format.

---

## Layer 3 — Skills (workflows)

Step-by-step playbooks with built-in guardrails. Each skill names the convention to copy from existing code, lists the order of operations, and flags the project-specific gotchas to avoid.

| Skill | When to invoke |
|---|---|
| [`add-api-endpoint`](.claude/skills/add-api-endpoint/SKILL.md) | Add a new CRUD endpoint to one of the 9 API services. |
| [`add-report`](.claude/skills/add-report/SKILL.md) | Add a report to the Reports menu. Usually no C# changes — just a `PZ_Report` row. |
| [`add-scrub`](.claude/skills/add-scrub/SKILL.md) | Add a claim-scrub rule. Today every scrub row runs as a SQL Server stored procedure (the C# validator path is documented but unimplemented in current code). |
| [`add-admin-screen`](.claude/skills/add-admin-screen/SKILL.md) | Add a master-data list+detail screen in the root admin Angular app. |
| [`write-tests`](.claude/skills/write-tests/SKILL.md) | Author tests after `/coverage-plan` produces a P0 list. Picks the right layer (unit / repository contract / API integration / golden-master / UI) and follows the codebase's existing patterns. |
| [`remove-endpoint`](.claude/skills/remove-endpoint/SKILL.md) | Retire an existing API endpoint cleanly across every dispatch surface. Refuses if UI callers still depend on it. |
| [`deprecate-feature`](.claude/skills/deprecate-feature/SKILL.md) | Mark a feature/endpoint/report/scrub for removal with a planned cutover date. Adds the deprecation banner, registers the date in `MIGRATION_DECISIONS.md`, and primes `remove-endpoint` for the cutover day. |

Skills are deliberately opinionated. They reflect this codebase's conventions, not generic .NET / Angular advice. If your task doesn't match a skill, follow the closest [recipe in RECIPES.md](docs/conventions/RECIPES.md).

---

## Layer 4 — Slash commands

User-typed shortcuts that dispatch to subagents. Open the file under `.claude/commands/` to see what each does.

| Command | What it does |
|---|---|
| `/trace-feature <name>` | Walks UI → API → DB for the named feature; returns file:line citations. |
| `/sp-impact <sp_name>` | Shows the blast radius of changing the named SP across code, `PZ_Report`, `Scrub`, dependencies, and SQL Agent. |
| `/safety-review [staged\|committed]` | Runs the pre-merge checklist. Default covers committed + staged + unstaged + untracked. |
| `/db-query <question>` | Read-only query against the live DB. |
| `/coverage-plan [feature]` | Plans tests for the current change set or a named feature. Returns prioritized P0/P1/P2 list. |
| `/validate-catalog [sps\|tables\|dispatch]` | Detects drift between catalog docs and live DB. Read-only. |

---

## Workflow examples

### Example 1: "Add a report for charges by referring provider"

1. Read [add-report skill](.claude/skills/add-report/SKILL.md).
2. Author `rpt_ChargesByReferringProvider` in the DB.
3. `INSERT INTO PZ_Report (...)` with the dispatch row.
4. Append the row to [STORED_PROCEDURES.md §3.5](STORED_PROCEDURES.md#35-reports-dispatched-dynamically-via-pz_reportcommand-pattern-24).
5. `/safety-review` — confirm no `DateTime.Now`, no `ex.Message` leak, etc.

### Example 2: "Why does Denial Dashboard load slowly?"

1. `/trace-feature Denial Dashboard` — get the call path.
2. Note that 5 SPs run in sequence in `DenialQueueRepository.GetAgingCount`.
3. `/db-query show me the execution plan for usp_GetDenialManagementAgingCountByRange` — find the slow one.
4. Optimize the SP or parallelize the C# calls.

### Example 3: "Rename `usp_GetInsurancewisePaymentReport` to `usp_GetPayerPaymentReport`"

1. `/sp-impact usp_GetInsurancewisePaymentReport` — find every caller, including `PZ_Report` rows.
2. Update C#, the `PZ_Report` row, and `STORED_PROCEDURES.md` atomically.
3. `/safety-review` — confirm `PZ_Report.Command` was updated alongside the SP.

---

## Working without Claude Code

The framework is plain files. Other agents can use it as follows:

- **Codex / Cursor**: read `CLAUDE.md` + `docs/architecture/SECURITY_AND_RISKS.md` at session start. Treat the skill `SKILL.md` files as recipes; the `.claude/agents/*.md` files are subagent contracts you can dispatch to a sub-task.
- **Gemini Code Assist**: ingest `docs/architecture/` as context; treat `STORED_PROCEDURES.md` as the SP catalog.
- **Generic LLM**: paste `CLAUDE.md` + `SECURITY_AND_RISKS.md` + the relevant skill into context before asking for code.

The rule that matters: **always check the dispatch tables (`PZ_Report`, `Scrub`) before assuming a stored procedure is unused or safe to rename.** That's the single most common way to break this system.

---

## Maintaining the framework

If you change something and the framework's claims drift, fix the doc:

| You changed | Update |
|---|---|
| Added/renamed/dropped a stored procedure | [STORED_PROCEDURES.md](STORED_PROCEDURES.md) |
| Added a new pattern to follow | [docs/conventions/RECIPES.md](docs/conventions/RECIPES.md) and consider adding a skill |
| Discovered a new risk | [docs/architecture/SECURITY_AND_RISKS.md](docs/architecture/SECURITY_AND_RISKS.md) and add to the merge checklist |
| Re-architected a service | The relevant `docs/architecture/*.md` |
| Schema change | `docs/database/` (Codex's domain) |

Stale framework docs are worse than missing ones — they convince agents that wrong things are true. Be willing to delete an entry that no longer holds.
