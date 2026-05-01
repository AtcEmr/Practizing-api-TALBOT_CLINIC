# PractiZing API — Maintainer Documentation

Welcome. This folder is the entry point if you've inherited (or are about
to maintain) the PractiZing medical-billing API. **Read [`ARCHITECTURE.md`](ARCHITECTURE.md)
first** — it explains how the pieces fit together. Then dip into the rest
as needed.

## What this repository is

A medical-billing back-end for the Talbot Clinic deployment of PractiZing
("Practice Insight"). Handles everything between charges and payment
posting: claim creation, EDI transmission to clearinghouses, ERA (835)
import, denial management, fee schedules, statements, and reporting.

It is a **multi-project ASP.NET Core 2.1 solution** organized as eight
service folders plus shared libraries. Each service is independently
deployable and also wired together through `HostService`, which is the
production aggregator.

## Document index

| Doc | What it answers |
|---|---|
| [`ARCHITECTURE.md`](ARCHITECTURE.md) | Why microservices, how they fit, the 3-layer pattern (Api → BusinessLogic → DataAccess), how `HostService` aggregates, the data flow from a UI request to the database |
| [`CONTRIBUTING.md`](CONTRIBUTING.md) | Local dev setup, how to build/run/debug, how to add a controller / repository / migration, conventions to follow |
| [`CONFIGURATION.md`](CONFIGURATION.md) | Every environment variable, every `appsettings.json` key, who reads it, what happens if it's missing |
| [`DEPLOYMENT.md`](DEPLOYMENT.md) | Operational runbook: container layout, networking, secrets, logs, restart procedures, scaling, common failures |
| **[`ONBOARD-NEW-PRACTICE.md`](ONBOARD-NEW-PRACTICE.md)** | **End-to-end runbook for adding a new practice / tenant. Encodes every gotcha hit during the first deploy. Start here when adding a new client.** Pairs with [`scripts/onboard/onboard.py`](../scripts/onboard/) — an interactive Python script that drives the whole runbook automatically. |
| [`TROUBLESHOOTING.md`](TROUBLESHOOTING.md) | Every gotcha we know about — the build issues, the runtime issues, the historical bugs and pre-existing tech debt |
| [`GLOSSARY.md`](GLOSSARY.md) | Domain terms (Charge vs Invoice vs Claim vs Voucher vs Payment vs ERA — these recur with subtly different meanings) |
| [`DATABASE.md`](DATABASE.md) | The two SQL Server databases, what tables live where, how the practice-multi-tenancy works |
| [`services/README.md`](services/README.md) | Index of the eight services. Each service has its own page describing what it owns. |

## Document index — per service

| Service | What it owns |
|---|---|
| [HostService](services/HostService.md) | The aggregator — JWT issuance, the `/token` endpoint, practice-DB connection-string loading at boot, request compression, CORS |
| [ChargePaymentService](services/ChargePaymentService.md) | The biggest service. Charges, invoices, claims (837 EDI), payments, ERAs (835), vouchers, payment batches, fee schedules, scrub, Plaid integration |
| [PatientService](services/PatientService.md) | Patient demographics, cases, insurance policies, statements, alerts, action notes, HL7 status |
| [SecurityService](services/SecurityService.md) | Login/logout endpoints, user/role/permission management |
| [MasterService](services/MasterService.md) | Reference / master data — CPT codes, ICD-10, providers, facilities, insurance companies, all the config look-ups |
| [DenialManagementService](services/DenialManagementService.md) | Denial queues, action notes, AR groups, denial categorization |
| [ERAService](services/ERAService.md) | Electronic Remittance Advice (835) parsing and storage |
| [ReportService](services/ReportService.md) | Report definitions and execution — note: it has no controllers, it's a library used by ChargePayment + others |
| [ClaimService](services/ClaimService.md) | Not an API service — three claim-creator libraries (Base/Form/Prof) used by ChargePaymentService for 837P/837I formatting |

## Other useful documents in this folder

In addition to the maintainer-onboarding docs above, prior work has
produced these reference materials worth keeping:

- [`architecture/`](architecture/) — alternate / deeper architecture writeups (SYSTEM_OVERVIEW, API_ARCHITECTURE, UI_ARCHITECTURE, DATA_FLOW, SECURITY_AND_RISKS). Some overlap with `ARCHITECTURE.md` above; both are useful.
- [`conventions/RECIPES.md`](conventions/RECIPES.md) — copy-paste-ready patterns for adding endpoints, repositories, controllers without breaking the project's conventions.
- [`database/`](database/) — actual SQL Server schema dump (`.sql`, `.json`, `.md`) generated from `PI_ATC_CLINIC`. This is the source-of-truth schema reference; my [`DATABASE.md`](DATABASE.md) above is a higher-level overview.
- [`database/sql-server-to-postgres-migration-plan.md`](database/sql-server-to-postgres-migration-plan.md) — if/when you migrate off SQL Server, this is the planning document.

## Conventions used in this documentation

- **File:line refs** like `HostService/Startup.cs:53` are clickable links if you're reading on GitHub.
- 🔴 / 🟡 / 🟢 mark severity of any flagged issues.
- "Pre-existing" means the issue was in the code when this doc was written; not introduced by deploy packaging.
