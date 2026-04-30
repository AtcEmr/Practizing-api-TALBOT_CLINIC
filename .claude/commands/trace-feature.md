---
description: Trace a Practizing feature end-to-end (UI → API → DB) and report the call path with file:line citations.
argument-hint: <feature name or screen, e.g. "Denial Dashboard">
---

Use the `feature-tracer` subagent to trace the feature: **$ARGUMENTS**

The subagent should:
1. Find the UI component / screen
2. Walk down through the Angular service to the API endpoint
3. Identify the controller action and repository method
4. Name every table or stored procedure touched
5. Cross-reference `STORED_PROCEDURES.md` for known SPs
6. Flag any risk noted in `docs/architecture/SECURITY_AND_RISKS.md`

Return a tight, file:line-cited report. Do not propose changes — this is a read-only trace to inform the next decision.
