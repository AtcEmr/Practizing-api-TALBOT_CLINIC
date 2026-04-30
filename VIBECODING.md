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
| [STORED_PROCEDURES.md](STORED_PROCEDURES.md) | Every active SP, its caller, and the dispatch tables. |
| [docs/database/](docs/database/) | DB schema (maintained by Codex). |

---

## Layer 2 — Subagents

Specialist agents that investigate without editing. Use them via slash commands or by name.

| Agent | Use when |
|---|---|
| `feature-tracer` ([.claude/agents/feature-tracer.md](.claude/agents/feature-tracer.md)) | You need to know how a feature works end-to-end before touching it. |
| `sp-impact-analyzer` ([.claude/agents/sp-impact-analyzer.md](.claude/agents/sp-impact-analyzer.md)) | You're about to rename, drop, or change the signature of a stored procedure. |
| `safety-reviewer` ([.claude/agents/safety-reviewer.md](.claude/agents/safety-reviewer.md)) | You're about to merge a non-trivial change. |
| `db-introspector` ([.claude/agents/db-introspector.md](.claude/agents/db-introspector.md)) | You need actual DB state — table columns, SP body, dependency lookup. Read-only. |

For agents other than Claude (Codex, Gemini): the subagent files are plain Markdown with YAML frontmatter. The frontmatter `description` and the body's "Method" + "Output shape" sections are the contract. You can adapt them to your own runner format.

---

## Layer 3 — Skills (workflows)

Step-by-step playbooks with built-in guardrails. Each skill names the convention to copy from existing code, lists the order of operations, and flags the project-specific gotchas to avoid.

| Skill | When to invoke |
|---|---|
| [`add-api-endpoint`](.claude/skills/add-api-endpoint/SKILL.md) | Add a new CRUD endpoint to one of the 9 API services. |
| [`add-report`](.claude/skills/add-report/SKILL.md) | Add a report to the Reports menu. Usually no C# changes — just a `PZ_Report` row. |
| [`add-scrub`](.claude/skills/add-scrub/SKILL.md) | Add a claim-scrub rule (SP-based or C#-validator-based). |
| [`add-admin-screen`](.claude/skills/add-admin-screen/SKILL.md) | Add a master-data list+detail screen in the root admin Angular app. |

Skills are deliberately opinionated. They reflect this codebase's conventions, not generic .NET / Angular advice. If your task doesn't match a skill, follow the closest [recipe in RECIPES.md](docs/conventions/RECIPES.md).

---

## Layer 4 — Slash commands

User-typed shortcuts that dispatch to subagents. Open the file under `.claude/commands/` to see what each does.

| Command | What it does |
|---|---|
| `/trace-feature <name>` | Walks UI → API → DB for the named feature; returns file:line citations. |
| `/sp-impact <sp_name>` | Shows the blast radius of changing the named SP across code, `PZ_Report`, `Scrub`, dependencies, and SQL Agent. |
| `/safety-review [staged]` | Runs the pre-merge checklist against the current diff. |
| `/db-query <question>` | Read-only query against the live DB. |

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
