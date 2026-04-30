# MasterService

**Folder**: `MasterService/`
**Container name in compose**: `practizing-master`

## Purpose

Reference / master data. Almost every dropdown, lookup, or "configure
this" screen in the UI is backed by a controller here.

## Key controllers

70+ controllers — the most of any service by count. Grouped:

### Codes (clinical)

| Controller | Notes |
|---|---|
| `CPTCodeController`, `MasterCPTController` | CPT codes |
| `ICDCodeController`, `MasterICD10Controller` | Diagnosis codes (note: `ICD` and `ICD10` represent different generations / data sources) |
| `NDCController` | National Drug Codes |
| `CPTCategoryController` | Category groupings |
| `DrugClassController` | Drug class lookup |

### Providers / facilities

| Controller | Notes |
|---|---|
| `ProviderController`, `ProviderIdentityController` | Provider master + per-payer billing IDs |
| `FacilityController`, `FacilityIdentityController` | Facility master + per-payer IDs |
| `ReferringDoctorController` | External referring physicians |

### Insurance / clearinghouse

| Controller | Notes |
|---|---|
| `InsuranceCompanyController` | Insurance company master |
| `ClearingHouseController` | Clearinghouse routing config |
| `ConfigInsuranceCompanyTypeController` | Lookup |
| `ConfigInsuranceFormTypeController` | Lookup |
| `ConfigInsuranceMedicareSecondaryController` | Medicare-secondary lookup |
| `ConfigERARemarkCodesController` | Remark code config |

### Adjustment / remark

| Controller | Notes |
|---|---|
| `AdjustmentReasonCodeController` | Reason codes |
| `ConfigAdjustmentReasonCodeController` | Configuration of reason codes |
| `ARSCategoryReasonCodeController` | AR category linkage |
| `RemarkCodeSolutionController` | Documented solutions per remark code |
| `DenialCategoryController` | Denial category lookup |

### Place / Type / Position / Specialty

| Controller | Notes |
|---|---|
| `ConfigPOSController` | Place of Service |
| `ConfigTOSController` | Type of Service |
| `ConfigBillTypeController` | Bill type (institutional billing) |
| `ConfigCaseTypeController` | Case type lookup |
| `ConfigPositionController`, `ConfigProviderPositionController` | Provider position roles |
| `ConfigProviderSpecialtyController` | Specialties |
| `ConfigSupervisionTypeController` | Supervision types |
| `ConfigPractitionerServiceController` | Service-line config |
| `ConfigServiceCircumstanceController` | Circumstance modifiers |
| `ConfigServiceTypeController` | Service-type config |
| `ConfigReferralSourceController` | Referral source codes |
| `ConfigFacilityTypeController` | Facility type lookup |
| `ConfigFacilitySubTypeController` | Subtype |
| `ConfigIdTypeController` | Identifier type |
| `ConfigFollowUpPeriodController` | Follow-up period codes |
| `ConfigSystemCDController` | System code lookup |

### Patient demographics codes

| Controller | Notes |
|---|---|
| `ConfigMaritalStatusController` | Marital status |
| `ConfigPatientRaceController` | Race code lookup |
| `ConfigRelationshipController` | Relationship to insured |

### Drug / NDC / units

| Controller | Notes |
|---|---|
| `ConfigNDCUOMController` | NDC unit of measure |
| `BillingUnitConversionChartController` | Unit-conversion table |

### System / settings / misc

| Controller | Notes |
|---|---|
| `ConfigSettingController`, `ConfigSettingGroupController` | Application settings groups |
| `AppSettingController` | App-level settings |
| `ClaimConfigController` | Claim-related defaults |
| `MonthEndCloseController` | Lock/unlock fiscal periods |
| `DepositTypeController` | Payment deposit types |
| `NotesCategoryController`, `DemographicNoteController` | Notes categorization |
| `AttFileController` | Attachment file metadata |
| `LabSalesRepController` | Lab sales rep contact |
| `ZipCodeLookUpController` | ZIP → city/state lookup |
| `ReportController` | Report definition CRUD (consumed by ReportService) |

## Key tables

See [`../DATABASE.md`](../DATABASE.md) MasterService section. ~70 tables; mostly thin lookups (Id + Code + Description).

## Dependencies

`MasterService.BusinessLogic` references:

- `Common/*`
- (No cross-service deps)

## Notable repository patterns

Most repositories here are thin: standard CRUD with optional soft-delete
flag. The exceptions:

- `MonthEndCloseRepository` — enforces date-locking; closing a period prevents new charges/payments from being posted to it
- `ProviderRepository`, `FacilityRepository` — track per-payer billing IDs in linked `*Identity` tables; CRUD has cascade implications
- `InsuranceCompanyRepository` — used by every other service for insurance lookups; expensive `GetAll` is cached

## Known gotchas

- 🟢 The `MasterServcie` typo (in namespace `PractiZing.DataAccess.MasterServcie.Objects`) — load-bearing; renaming requires sweeping refactor
- 🟡 Hot lookup endpoints (`GetAll` for InsuranceCompany, CPTCode, ICDCode, NDC) hit the DB on every call. UI hits them on every page load. Consider caching with TTL — see `PracticeConfigurationService` in the UI (which already caches `isLabCompany` config locally).
- 🟢 The `Reports` endpoint here lists report definitions; the actual execution is in ChargePayment / Report services.
- ⚪ `PatientStateController` *should* probably be in MasterService but lives in PatientService; not worth moving without a refactor.
