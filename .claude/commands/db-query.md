---
description: Run a read-only query against the live PI_ATC_CLINIC database — schema lookups, SP source, row counts, dependency lookups.
argument-hint: <plain-English question about the DB, e.g. "show me the columns of the Charge table">
---

Use the `db-introspector` subagent to answer this DB question: **$ARGUMENTS**

The subagent runs read-only queries (SELECT, sp_helptext, sys catalog views) against `PI_ATC_CLINIC` on `10.3.104.52` and returns the answer in a clean format.

It will refuse to run any mutation (INSERT/UPDATE/DELETE/DDL) — those need to go through SSMS or a DBA. PHI is redacted in output unless explicitly requested.

If credentials are not in the conversation, the subagent will ask before connecting.
