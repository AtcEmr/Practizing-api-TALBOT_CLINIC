---
description: Run the catalog-sync-validator against the live DB. Detects drift between STORED_PROCEDURES.md / postgres-sp-conversion.md / postgres-schema-conversion.md and PI_ATC_CLINIC. Read-only.
argument-hint: [optional: "sps" | "tables" | "dispatch" | (default = all)]
---

Use the `catalog-sync-validator` subagent to detect drift between the framework's catalog documents and the live `PI_ATC_CLINIC` database.

Scope (based on $ARGUMENTS):
- **(no arg, default)** — full check: SPs, tables, `PZ_Report` dispatch, `Scrub` dispatch, plus C# call-site citations.
- **sps** — only the SP catalog and the per-SP migration worksheet.
- **tables** — only the per-table schema worksheet.
- **dispatch** — only `PZ_Report.Command` and `Scrub.StoredProcedure` references (the broken-reference class).

Returns a structured drift report with P0 (broken refs), P1 (catalog stale), and P2 (cosmetic) categories. Read-only — the subagent does not modify the catalogs or the DB.

Run this monthly during steady-state, weekly during active migration phases. Run it immediately if a developer suspects an SP is missing from a catalog.

The subagent will ask for DB credentials if they're not already in the conversation.
