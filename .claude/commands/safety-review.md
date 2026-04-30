---
description: Run the pre-merge safety review on staged or branch changes. Walks the SECURITY_AND_RISKS checklist against the diff.
argument-hint: [optional: "staged" to review only staged changes]
---

Use the `safety-reviewer` subagent to run the pre-merge safety review on the current changes.

If $ARGUMENTS is "staged", review only `git diff --staged`. Otherwise review all changes between the current branch and main (`git diff main...HEAD`).

The subagent walks the checklist in `docs/architecture/SECURITY_AND_RISKS.md` (last section) and reports each item as PASS / FAIL / N/A with file:line evidence.

If FAIL items exist, the overall verdict is FAIL. Do not auto-fix — return the report and let the human decide.
