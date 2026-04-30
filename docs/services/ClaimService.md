# ClaimService

**Folder**: `ClaimService/`
**NOT a HTTP service** — three library projects. Has NO controllers, NO Api project, NO container.

## Purpose

Builds **X12 837 EDI claim files**. There are two flavors of 837:

- **837P (Professional)** — for ambulatory / office-based care. Most charges in this system.
- **837I (Institutional)** — for hospital inpatient / specialized facility billing.

Each is a complex data structure (CMS guides are hundreds of pages). The
projects here translate internal C# claim objects into the X12 format
that clearinghouses and payers expect.

## The three projects

| Project | Purpose |
|---|---|
| `PractiZing.ClaimCreator.Base` | Shared building blocks: subscriber/patient/provider segments, common loops |
| `PractiZing.ClaimCreator.Form` | 837I (institutional / "form 837") |
| `PractiZing.ClaimCreator.Prof` | 837P (professional). 🔴 Had broken HintPath until coolify-branch fix |

## How it's used

- `ChargePaymentService.BusinessLogic` references `ClaimCreator.Prof` (and Base/Form transitively)
- Specifically `ClaimRepository` and/or a `ClaimFileProcessService` orchestrate building the 837 string
- Output is a flat-text file conforming to X12 — passed to a clearinghouse via SFTP or HTTP

## Dependencies

- `lib/EdiFabric.Framework/DLLs/net45/EdiFabric.Core.dll` (and `Framework.dll`)
- `EDIFabric/EdiFabric.Templates.Hipaa` (project ref)
- `EDIFabric/PractiZing.EdiFrabric.Custom` (project ref)

## Known gotchas

- 🔴 `ClaimCreator.Prof.csproj` originally had `<HintPath>..\..\EDIFabric\Packages\...</HintPath>` — gitignored, missing on clean clones. Already fixed in coolify branch (`docs/TROUBLESHOOTING.md` "🔴 BUILD: error MSB3245").
- 🟡 The translation from internal claim objects to 837 X12 is implicit in the code; there's no documentation of which fields map to which X12 segments. If you need to fix a payer rejection, you'll be cross-referencing the X12 837 implementation guide and the source manually.
- 🟢 The 837I path (`ClaimCreator.Form`) is rarely exercised; if your practice doesn't bill institutional claims, this is dead code.
