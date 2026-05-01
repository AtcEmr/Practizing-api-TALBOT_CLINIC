---
description: Plan tests for the current change set, a feature, or a stored procedure. Returns a prioritized list of tests with file paths and what each proves.
argument-hint: [optional: feature name or SP name; default = current uncommitted+committed diff]
---

Use the `test-coverage-planner` subagent to plan tests for: **$ARGUMENTS**

If $ARGUMENTS is empty, plan tests for the current change set (committed + staged + unstaged), the same scope as `/safety-review`.

The subagent walks the change layer-by-layer (unit / repository contract / API integration / golden-master / UI) and applies the project's risk-driven test patterns (multi-tenant filtering, datetime audit, SP injection, etc.) from `docs/architecture/SECURITY_AND_RISKS.md`.

**Migration work is planned in characterization-first mode.** If the change touches `docs/database/postgres-*`, an `IRoutineExecutor`/`IDatabaseDialect` boundary, an SP retirement, or PG provider code, the planner switches modes: the P0 test list captures **SQL Server's current behavior** as fixtures and asserts that PG produces the same output. Coverage is secondary; business parity is the gate. See the [migration plan's Characterization-First TDD Migration Gate](../../docs/database/sql-server-to-postgres-migration-plan.md).

Output is a prioritized list (P0 / P1 / P2) with concrete test names, target files, and a one-line "what it proves" for each. Read-only — the subagent does not write tests, only plans them.

Use this before merging non-trivial changes. The team's coverage goal is 80%; this command exists to ratchet the project toward that goal one PR at a time.
