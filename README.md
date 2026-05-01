# PractiZing API — Talbot Clinic

The medical-billing API for the Talbot Clinic deployment of PractiZing
(a.k.a. "Practice Insight"). Multi-project ASP.NET Core 2.1 solution
covering the entire lifecycle from charge entry to payment posting:
claim creation (837 EDI), ERA (835) parsing, denial management, fee
schedules, statements, reporting.

## Quick links

🚀 **Adding a new practice / tenant?** See [`docs/ONBOARD-NEW-PRACTICE.md`](docs/ONBOARD-NEW-PRACTICE.md), or run the automation:

```bash
# Python 3.9+, Docker, and network access required
git clone https://github.com/AtcEmr/Practizing-api-TALBOT_CLINIC -b coolify
cd Practizing-api-TALBOT_CLINIC/scripts/onboard
pip install -r requirements.txt
python onboard.py
```

📚 **[`docs/`](docs/)** — comprehensive maintainer documentation. **Start with [`docs/README.md`](docs/README.md)**.

The docs cover:

- [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) — how the 8 services fit together
- [`docs/CONTRIBUTING.md`](docs/CONTRIBUTING.md) — local dev setup
- [`docs/CONFIGURATION.md`](docs/CONFIGURATION.md) — every env var and appsetting
- [`docs/DEPLOYMENT.md`](docs/DEPLOYMENT.md) — operational runbook
- [`docs/TROUBLESHOOTING.md`](docs/TROUBLESHOOTING.md) — every gotcha we know about
- [`docs/GLOSSARY.md`](docs/GLOSSARY.md) — domain terms (Charge vs Invoice vs Claim vs Voucher)
- [`docs/DATABASE.md`](docs/DATABASE.md) — schema overview
- [`docs/services/`](docs/services/) — per-service overview pages

🚢 **[`coolify/README.md`](coolify/README.md)** — Coolify-specific deploy steps for the `coolify` branch.

## Stack at a glance

- ASP.NET Core 2.1 (out of support since Aug 2021 — upgrade is a known follow-up)
- ServiceStack OrmLite (primary ORM) + Dapper + raw `SqlCommand` (yes, three styles)
- SQL Server 2016+ (two databases: a per-practice operational DB and a `PracticeCentral` lookup DB)
- AWS DynamoDB for payment history
- AWS SDK, Plaid, Stripe, MimeKit (downgraded to 2.15.1 for netcoreapp2.1 compat)
- EdiFabric for X12 837/835 parsing
- Docker for production via the `coolify` branch

## Repo layout (top level)

```
Base/                    Domain types (entities, enums, interfaces) referenced by every service
Common/                  Shared infrastructure (controllers, repositories, helpers, SFTP)
ChargePaymentService/    The biggest service — charges, claims, payments
ClaimService/            Library only — 837 EDI claim builders (Prof and Form)
DenialManagementService/ Denial workflow
ERAService/              Electronic Remittance Advice (835) parsing
HostService/             The aggregator — production binary
MasterService/           Reference / master data
PatientService/          Patient demographics, cases, statements
ReportService/           Report definitions (library only — no controllers)
SecurityService/         Auth (login, users, roles)
EDIFabric/               EdiFabric source files (rules, templates, custom)
lib/                     Pre-built proprietary DLLs (EdiFabric.Framework, X12EDI.dll, Xfinium)
PractiZing.sln           Solution including every project
docs/                    ← maintainer documentation
coolify/                 Coolify deploy guide
```

## License

Proprietary; all rights reserved.
