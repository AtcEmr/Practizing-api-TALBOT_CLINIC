---
description: Show the blast radius of changing or removing a stored procedure — C# callers, PZ_Report, Scrub, view/SP dependencies, SQL Agent jobs.
argument-hint: <stored procedure name, e.g. usp_GetDenialManagementAgingCountByRange>
---

Use the `sp-impact-analyzer` subagent to analyze the impact of changing or removing the stored procedure: **$ARGUMENTS**

The subagent must check **all five layers**:
1. Hardcoded C# call sites in this repo and the UI repo
2. `PZ_Report.Command` rows in the live DB
3. `Scrub.StoredProcedure` rows in the live DB
4. SQL `sys.sql_expression_dependencies` (other SPs / views that reference it)
5. SQL Agent jobs in `msdb.dbo.sysjobsteps`

Return a verdict (SAFE / BREAKING / NEEDS COORDINATION / UNKNOWN) plus the structured dependency list. Do not propose code changes.

Run this **before** renaming, dropping, or changing the signature of any SP. Grep alone is insufficient — this codebase dispatches SPs by row in `PZ_Report` and `Scrub`, which grep cannot see.
