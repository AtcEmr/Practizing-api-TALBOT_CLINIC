# System Overview — Practizing (Talbot Clinic)

> Read this first. Everything else is detail.

## What this system is

A multi-tenant SaaS medical-billing platform for clinics. Built around the lifecycle of a charge: a clinician creates a charge → it becomes a claim → it goes out as an X12 837 EDI file → an 835 ERA comes back → payments and adjustments post → unpaid balances become denials → patients get statements → the practice reconciles deposits with the bank.

Every screen, every endpoint, every stored procedure exists to support one of those lifecycle steps.

## Two repos, one product

| Repo | Tech | Role |
|---|---|---|
| `Practizing-api-TALBOT_CLINIC` (this repo) | .NET Core 2.1, ServiceStack OrmLite, EdiFabric, JWT | 9 service-bounded API projects + shared base/common, single SQL Server DB, 138 SPs |
| `Practizing-ui-TALBOT_CLINIC` | Angular 7, PrimeNG, ag-grid, RxJS 6 | 3-project Angular workspace (root admin + `pibilling` + `pipatient`) plus a `pi-lib` ng-packagr library |

Deployed via Coolify-orchestrated Docker; one container per API service, one for the SPA, an external SQL Server.

## Five perspectives on the same code

You will need more than one mental model to work in this codebase. Use the perspective that matches the question you are answering.

### Perspective 1: Layered (UI → API → DB)
Component → Angular service → HTTP → API controller → repository → OrmLite/SP → table/view.
Use this when **debugging a single user action**. Walk it top-down.
See [DATA_FLOW.md](./DATA_FLOW.md).

### Perspective 2: Domain-bounded (per service)
Each `*Service` project owns a subset of tables and a slice of the lifecycle:
| Service | Owns | UI surface |
|---|---|---|
| `SecurityService` | Login, JWT issuance, users/roles/permissions (PZ_*) | Sign-in, Admin → Users |
| `MasterService` | CPT, ICD, NDC, Insurance, Facility, Provider, Config*, fee schedules | Admin → master data |
| `PatientService` | Patient, PatientCase, demographics, insurance policies | `pipatient` sub-app |
| `ChargePaymentService` | Charges, claims, payments, vouchers, batches, scrubs, bank-reconciliation, Plaid, MethaSoft | `pibilling` charge/payment/claim screens |
| `ClaimService` | Claim CRUD, ClaimView, ClaimBatch, 837 generation | Claim review screens |
| `ERAService` | ERARoot, 835 parsing, payment posting from ERAs | Admin → ERA Details |
| `DenialManagementService` | Denial queue, denial dashboard, follow-up assignment | Denial Dashboard / Management |
| `ReportService` | RDLC reports, statements, charge-stat refresh, aging-balance batches | Reports tab, Statements |
| `HostService` | ZIP lookup, common cross-cutting utilities | Used everywhere |

Use this when **adding a feature** — pick the right service, follow its conventions.
See [API_ARCHITECTURE.md](./API_ARCHITECTURE.md).

### Perspective 3: Cross-cutting concerns
- **Multi-tenancy**: practice code resolves from HTTP `Host` header → `DataBaseContext` opens the matching connection string. PracticeId is stamped from JWT into every repository.
- **Auth**: SecurityService issues a "small token" JWT; full claims live in MemoryCache, swapped at validation time by `PractiZingJwtTokenHandler`. `[Authorize]` is set on a base controller.
- **Audit**: `BaseRepository.SetUserStamp` writes Created*/Modified* fields automatically — uses `DateTime.Now` (local), not UTC.
- **Logging**: ILogger + Serilog package present, but most code uses `Console.WriteLine` to STDOUT.
- **EDI**: `EdiFabric` library, `PractiZing.EdiFabric.Custom`, `PractiZing.Sftp` handle 837 out / 835 in.

Use this when **a change touches more than one service**.

### Perspective 4: Operational
- **Build**: per-service Dockerfile build args choose which API project to compile into one image; UI is a separate two-stage build (Node 14 → nginx).
- **Deploy**: `docker-compose.yaml` lists one container per API service plus the SPA. Coolify wraps it. Connection strings, JWT secret, API base URL come from env vars (with `appsettings.Development.json` containing checked-in dev defaults — see Risks).
- **Data**: one SQL Server `PI_ATC_CLINIC` DB at `10.3.104.52`. SPs are documented in [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md). Schema docs live under [docs/database/](../database/) (Codex-maintained).
- **Background jobs**: there are NO in-process schedulers (no Hangfire/Quartz/IHostedService). Long-running work runs synchronously in the request, OR is done by SQL Agent jobs on the DB host.

Use this when **shipping or troubleshooting prod**.

### Perspective 5: Risk surface
The codebase has live security, correctness, and maintainability risks that should shape every change. The full list is in [SECURITY_AND_RISKS.md](./SECURITY_AND_RISKS.md). The three you must keep in mind during any edit:

1. **Permission-check filter is commented out** — every authenticated user can hit every `[Authorize]` endpoint. Don't write code that *assumes* the role check happens at the controller.
2. **`BaseRepository.ExecuteStoredProcedureAsync` builds SQL via string concatenation** — never pass user input directly. Use raw `SqlCommand` + parameters when input could be untrusted.
3. **Reports and scrubs are DB-dispatched** — SP names live in `PZ_Report.Command` and `Scrub.StoredProcedure`. Adding/removing reports usually means a DB row change, not a code change. Renaming an SP without checking those tables silently breaks production.

## Where to look for what

| If you need to … | Read |
|---|---|
| understand the API service split | [API_ARCHITECTURE.md](./API_ARCHITECTURE.md) |
| understand the UI app split, routing, state | [UI_ARCHITECTURE.md](./UI_ARCHITECTURE.md) |
| trace a screen → endpoint → SP path | [DATA_FLOW.md](./DATA_FLOW.md) |
| see all stored procedures and their callers | [STORED_PROCEDURES.md](../../STORED_PROCEDURES.md) (root) |
| not break security or multi-tenancy | [SECURITY_AND_RISKS.md](./SECURITY_AND_RISKS.md) |
| add a new endpoint, report, scrub, or admin screen | [docs/conventions/RECIPES.md](../conventions/RECIPES.md) |
| schema and tables | [docs/database/](../database/) |

## Glossary

- **Practice / PracticeCode / PracticeId** — a tenant. Each clinic is one practice. Practice code resolves from HTTP host; practice id flows in JWT claims.
- **Voucher** — a deposit-side record bundling one or more payments.
- **Charge** — a single billable line item (one CPT for one DOS).
- **Invoice** — a grouping of charges (one per encounter, typically).
- **Claim** — a billed-to-payer record; can include 1+ charges from 1+ invoices.
- **Claim batch** — a set of claims submitted together (one EDI file).
- **Scrub** — a pre-submission validation rule. Each row in the `Scrub` table is one rule (an SP or a C# validator).
- **ERA / 835** — Electronic Remittance Advice from a payer; X12 file.
- **EDI 837** — outbound claim file; X12.
- **CCN** — payer Claim Control Number.
- **PZ_Report** — DB table that maps a UI report name to an SP `Command` string.
- **Catalyst / Plaid / MethaSoft / Chase** — third-party integrations (RCM partner, bank-feed, lab system, Chase deposits).
