# SQL Agent Jobs Inventory and Disposition

The Practizing application states that scheduled work runs as SQL Agent jobs on the DB host (per [CLAUDE.md](../../CLAUDE.md) and [SYSTEM_OVERVIEW.md](../architecture/SYSTEM_OVERVIEW.md)). Until this inventory exists, every "background job" disposition in the SP worksheet is fiction.

This worksheet is **populated in Phase 1, frozen at end of Phase 5**, and drives Phase 6d (ETL/integration retirement) and Phase 10 (cutover scheduling).

## Status

| Field | Value |
|---|---|
| Inventory captured | **NOT YET — Phase 1 deliverable** |
| Captured by | — |
| Capture date | — |
| Source | `msdb` on `10.3.104.52` |
| Frozen on | — |

Once captured, replace this status block with the actual values.

## How to capture

Run this against `msdb` on the production DB host (or a representative environment that has the same job schedule):

```sql
SELECT
    j.job_id,
    j.name                                AS job_name,
    j.enabled                             AS job_enabled,
    j.description,
    s.step_id,
    s.step_name,
    s.subsystem,
    s.command,
    sch.name                              AS schedule_name,
    sch.freq_type,
    sch.freq_interval,
    sch.active_start_time,
    (
        SELECT TOP 1 run_date * 1000000 + run_time
        FROM msdb.dbo.sysjobhistory h
        WHERE h.job_id = j.job_id AND h.run_status = 1
        ORDER BY h.run_date DESC, h.run_time DESC
    )                                     AS last_successful_run,
    j.date_created
FROM msdb.dbo.sysjobs j
LEFT JOIN msdb.dbo.sysjobsteps s        ON s.job_id = j.job_id
LEFT JOIN msdb.dbo.sysjobschedules js   ON js.job_id = j.job_id
LEFT JOIN msdb.dbo.sysschedules sch     ON sch.schedule_id = js.schedule_id
ORDER BY j.name, s.step_id;
```

Required permissions on `msdb`: `SQLAgentReaderRole` minimum, `SQLAgentOperatorRole` to read history. If the DBA cannot grant these to the migration team, the DBA captures and exports the result; the team reviews the export.

Save the raw export to `postgres/validation/sql-agent-export-YYYYMMDD.csv`. Use it to populate the table below.

## Inventory worksheet (one row per job-step)

Every row starts at `pending Phase 0` and is updated by Phase 5 review.

### Status legend

| Status | Meaning |
|---|---|
| `pending Phase 0` | Captured but not yet classified |
| `port to {framework}` | Will run as a background-job in the chosen framework (Hangfire/Quartz/cron/etc., per Decision D12) |
| `port to PG function + scheduled call` | Logic stays in DB as a PG function; the scheduler (chosen framework) calls it on the same cadence |
| `one-shot at cutover` | Run once during Phase 10, then dropped |
| `keep on SQL Server until decommission` | Continues to run on legacy SQL Server until the practice fully cuts over |
| `drop` | Confirmed unused or superseded |
| `dual-run validated` | Re-implementation runs in parallel; output matches |
| `cutover` | Re-implementation is the source of truth; old job disabled |

### Worksheet table

| Job name | Enabled | Schedule | Last successful run | Step subsystem | Step command (truncated) | Referenced SPs | Owner | Disposition | Status | Evidence |
|---|---|---|---|---|---|---|---|---|---|---|
| _populate from msdb export_ | — | — | — | — | — | — | — | — | pending Phase 0 | — |

## Required disposition columns (V3.2 evidence-tracking)

For each job, the team must record:

- **Owner** — one human (not a team) responsible for the migration of this job.
- **Disposition** — one of the status values above; default `pending Phase 0`.
- **Replacement evidence** — commit hash or PR number where the replacement lands.
- **Validation evidence** — link to the parity-test run output that proves the new path matches the old.
- **Cutover date** — when the SQL Server job is disabled.

A row cannot move past `pending Phase 0` without an owner. A row cannot move to `dual-run validated` without validation evidence. A row cannot move to `cutover` without an explicit disable-the-SQL-Agent-job step in the cutover runbook.

## Common job categories (expected — confirm during capture)

Predicting based on the SP catalog and schema, the team is likely to find:

- **Charge data warehouse loaders** — `usp_ImportChargesInDataWareHouseTable` and variants. Expected nightly. Disposition: port to background-job framework.
- **Snapshot generators** — `usp_ChargeSnapShotsMonthWise*`, `usp_CPAReportYearMonthWise`, `usp_90DaysBalanceFinal`. Expected monthly, end-of-month. Disposition: port to scheduled job.
- **Statement generation pipeline** — possibly drives `usp_GetPatientForAutoStatment`. Expected weekly. Disposition: port to application service.
- **Cleanup / maintenance** — `usp_UpdateDueByWhereBlank`, `usp_MovePPOChargesToLISAClark`. Disposition: drop or one-shot at cutover.
- **Catalyst / Dynmo / Plaid sync** — runs that pull external data. Disposition: port to integration service.
- **Index maintenance / statistics** — generic SQL Server jobs. Disposition: replace with PG-native autovacuum tuning + scheduled REINDEX.
- **Backup verification** — generic SQL Server jobs. Disposition: replace with PG-native PITR verification.

If the actual capture reveals categories not on this list, that is itself a finding worth flagging.

## Rules for contributors

1. Do not edit the worksheet rows without a corresponding entry in [MIGRATION_DECISIONS.md](./MIGRATION_DECISIONS.md).
2. Do not disable a SQL Agent job until its row reads `cutover` AND the cutover runbook has been executed for the relevant tenant.
3. If a job is "currently failing" (last run ≠ success), file a bug BEFORE classifying — the migration cannot inherit broken jobs without explicit acknowledgment.
4. SQL Agent jobs that themselves call SPs marked `Drop` in [postgres-sp-conversion.md](./postgres-sp-conversion.md) are by transitivity also `drop`. The job inventory and SP worksheet must agree.

## Cross-references

- [postgres-sp-conversion.md](./postgres-sp-conversion.md) — every SP referenced from a SQL Agent job step should also have a row there.
- [sql-server-to-postgres-migration-plan.md](./sql-server-to-postgres-migration-plan.md) — Phase 0 §"SQL Agent job inventory" pins this worksheet as a hard gate.
- [MIGRATION_DECISIONS.md](./MIGRATION_DECISIONS.md) — D12 (background-job framework decision) determines what "port to {framework}" actually means.
