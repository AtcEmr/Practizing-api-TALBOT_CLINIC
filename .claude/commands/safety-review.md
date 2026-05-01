---
description: Run the pre-merge safety review on the current change set. Walks the SECURITY_AND_RISKS checklist against the diff. Default covers committed + staged + unstaged + untracked.
argument-hint: [optional: "staged" | "committed" | (default = all)]
---

Use the `safety-reviewer` subagent to run the pre-merge safety review on the current changes.

Scope based on $ARGUMENTS:
- **(no arg, default)** — review the union of: `git diff main...HEAD` (committed branch changes), `git diff --staged` (staged changes), `git diff` (unstaged tracked changes), and `git ls-files --others --exclude-standard` (untracked files). This is the broadest scope because risks like committed secrets, credentials in `appsettings`, and stray dev files hide most often in untracked or unstaged state.
- **staged** — review only `git diff --staged`.
- **committed** — review only `git diff main...HEAD`.

The subagent walks the checklist in `docs/architecture/SECURITY_AND_RISKS.md` (last section) and reports each item as PASS / FAIL / N/A with file:line evidence.

If FAIL items exist, the overall verdict is FAIL. Do not auto-fix — return the report and let the human decide.
