# PostgreSQL Migration Artifacts

This folder is the destination for all PostgreSQL migration artifacts produced by the SQL Server → PG project. **It is intentionally mostly-empty today.** Artifacts will be generated as the migration plan's phases close out.

## Why nothing is here yet

The migration plan has three Phase 0 decisions still open ([sql-server-to-postgres-migration-plan.md §Stack Decisions](../sql-server-to-postgres-migration-plan.md)):

1. **Naming strategy** — PascalCase quoted identifiers vs. lower_snake_case. Determines every column name in every `CREATE TABLE`.
2. **Multi-tenant model** — schema-per-practice vs. database-per-practice vs. shared tables. Determines `CREATE SCHEMA` vs. `CREATE DATABASE` and identity-sequence scoping.
3. **Case-insensitive columns** — `citext` columns vs. functional indexes on `lower(...)`. Determines column types on ~20 tables (CPT, ICD, NDC, usernames, payer codes).

Generating DDL before these decisions land produces artifacts that have to be regenerated. Worse, agents may copy partially-correct DDL forward as if it were the source of truth.

The conversion **worksheet** at [../postgres-schema-conversion.md](../postgres-schema-conversion.md) tracks what's pending.

## Target layout (when artifacts exist)

```
docs/database/postgres/
├── README.md                              ← this file
├── draft/                                 ← pgloader output (Phase 3)
│   ├── 00_create_database.sql
│   ├── 01_create_schemas.sql
│   ├── 02_tables/                         ← one .sql per table or one consolidated file
│   ├── 03_constraints.sql                 ← FKs, checks, defaults
│   ├── 04_indexes.sql
│   ├── 05_sequences.sql
│   └── pgloader-run.log
├── curated/                               ← human-edited final DDL (Phase 3 → 4)
│   ├── 00_…                               ← same shape as draft/, after fixes
│   └── deviations.md                      ← every place curated/ differs from draft/
├── functions/                             ← SP equivalents that survived as PG functions
│   ├── reports/
│   │   ├── rpt_aging_summary_by_insurance.sql
│   │   └── …
│   ├── scrubs/                            ← TVP-replacement functions, if any
│   └── README.md                          ← classification: ported / retired-in-app / dropped
├── triggers/
│   ├── audit_generic.sql                  ← target: 1 generic function replacing 221 SQL Server triggers
│   └── README.md                          ← per-trigger disposition
├── validation/                            ← Phase 4 + Phase 9 scripts
│   ├── row_counts.sql
│   ├── money_totals.sql
│   ├── fk_orphans.sql
│   ├── case_collision_check.sql
│   └── computed_column_parity.sql
└── runbooks/
    ├── pgloader-run.md                    ← how to run the proof
    ├── cutover.md                         ← Phase 10 runbook
    └── rollback.md                        ← Phase 10 rollback procedure
```

## What lives where

- **`draft/`** — generated output (pgloader, scripts). Never hand-edit; regenerate if the source schema changes. **Every `draft/` regeneration MUST include a `manifest.json`** (see required fields below) so a future review can confirm what was generated against what.

#### `draft/manifest.json` required fields

Every pgloader run that produces output in `draft/` is paired with a `manifest.json` capturing the inputs and tool versions that produced it. Without the manifest, "we ran pgloader" is not auditable.

```jsonc
{
  "captured_at": "2026-04-30T14:32:01Z",          // UTC ISO 8601
  "captured_by": "alice@example.com",
  "source": {
    "host": "10.3.104.52",
    "database": "PI_ATC_CLINIC",
    "sql_server_version": "Microsoft SQL Server 2019 (RTM-CU18) ...",
    "schema_hash": "sha256:abc123...",            // hash of `sys.objects` + `sys.columns` snapshot
    "object_counts": {
      "tables":    275,
      "columns":   4775,
      "indexes":   259,
      "fks":       140,
      "views":     16,
      "procedures":138,
      "functions": 23,
      "triggers":  221
    }
  },
  "row_count_snapshot": {
    "Charge":   1234567,
    "Payment":   234567,
    "Patient":    45678
    // … all tables; this is the snapshot to reconcile against post-load
  },
  "pgloader": {
    "version": "3.6.7",
    "config_file_hash": "sha256:def456...",
    "command": "pgloader --with \"data only\" mssql.cfg pg.cfg"
  },
  "excluded_objects": [
    { "name": "dbo.Provieder_temp", "reason": "obvious typo / dead table" }
  ],
  "errors": {
    "count": 0,
    "log_file": "pgloader-run.log"
  },
  "generated_ddl": {
    "file": "01_create_schemas.sql",
    "hash": "sha256:ghi789..."
  },
  "previous_manifest_hash": "sha256:..."           // links to the prior run; null on first run
}
```

The manifest is committed to `draft/manifest-YYYYMMDD-HHMMSS.json` (one per run, keep all). When `curated/` differs from `draft/`, the deviations log references the specific manifest hash that produced the draft.
- **`curated/`** — what production will actually run. Hand-edited as needed; every deviation from `draft/` is logged in `deviations.md` so the next pgloader run can be diffed against current intent.
- **`functions/`** — only SPs that the migration plan's Phase 6 classification kept (reports too complex to retire, performance-critical aggregates). The README in `functions/` lists every original SP and where it ended up: ported, retired into application code, or dropped.
- **`triggers/`** — at most one generic audit trigger function. Per-table cascading-state triggers are **not** ported here — those move to application services.
- **`validation/`** — SQL that validates parity. Run during Phase 4 (initial load) and during Phase 9 (dual-run). Money totals and FK integrity are the gate; row counts alone are insufficient.
- **`runbooks/`** — operational docs for Phase 10 cutover.

## Rules for contributors

1. **Do not commit DDL to `draft/` or `curated/` until Phase 0 decisions are formally approved.** Use the worksheet at [../postgres-schema-conversion.md](../postgres-schema-conversion.md) to track readiness.
2. **Do not hand-write a complete `CREATE TABLE` from scratch.** Run pgloader; commit its output to `draft/`; edit in `curated/` only. This keeps the conversion reproducible.
3. **Every file in `curated/` that diverges from `draft/` must have an entry in `curated/deviations.md`** explaining why. The diff is itself a review artifact.
4. **No production credentials in any SQL file.** Connection strings come from env at runtime, never from DDL.
5. **Naming strategy is enforced.** When the team chooses (PascalCase quoted vs. lower_snake_case), that choice is locked. Mixing them inside this folder is a CI fail.
6. **Computed columns** become PostgreSQL generated columns or views — choose per-table and document in `curated/deviations.md`. The 4 SQL Server computed columns are inventoried in the migration plan's §"SQL Server Defaults and Computed Columns".
7. **`numeric(19,4)` for money.** Never PostgreSQL `money`. The validation/money_totals.sql script enforces this.

## Status

| Artifact | Status | Phase | Owner |
|---|---|---|---|
| `draft/` (pgloader output) | not started | 3 | — |
| `curated/` (production DDL) | not started | 3 → 4 | — |
| `functions/` | not started | 6 | — |
| `triggers/audit_generic.sql` | not started | 6e | — |
| `validation/` scripts | not started | 4 | — |
| `runbooks/pgloader-run.md` | not started | 3 | — |
| `runbooks/cutover.md` | not started | 10 | — |
| `runbooks/rollback.md` | not started | 10 | — |

When an artifact lands, update this status table in the same PR.

## Cross-references

- [../sql-server-to-postgres-migration-plan.md](../sql-server-to-postgres-migration-plan.md) — the plan that drives this folder.
- [../postgres-schema-conversion.md](../postgres-schema-conversion.md) — per-table conversion worksheet.
- [../PI_ATC_CLINIC_schema.md](../PI_ATC_CLINIC_schema.md) — current SQL Server schema, the source of all conversions.
- [../../../STORED_PROCEDURES.md](../../../STORED_PROCEDURES.md) — SP catalog driving the `functions/` classification.
