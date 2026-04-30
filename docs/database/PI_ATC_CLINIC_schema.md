# PI_ATC_CLINIC SQL Server Schema

Generated from SQL Server metadata for code review and AI-agent context. This export intentionally contains schema and object definitions only; it does not contain table data or connection credentials.

## Files

- `PI_ATC_CLINIC_schema.sql`: DDL-style schema export plus view/function/procedure/trigger definitions from `sys.sql_modules`.
- `PI_ATC_CLINIC_schema.json`: structured metadata for tables, keys, indexes, routines, report commands, scrub configuration, and API routine references.

## Database Summary

- Database: `PI_ATC_CLINIC`
- Generated: `2026-04-30T18:38:16-04:00`
- User tables: `275`
- Views: `16`
- Stored procedures: `138`
- Functions: `23`
- Triggers: `221`
- User-defined table types: `1`

## Important API Coupling

- Reports are partly database-driven: `dbo.PZ_Report.Command` stores SQL/procedure command text that `ReportRepository` executes.
- Claim scrubbing is database-driven: `dbo.Scrub.StoredProcedure` stores procedure names, and the API can also receive a procedure name in the scrub request.
- The API depends on SQL Server-specific behavior: stored procedures, T-SQL functions, table-valued parameters, `System.Data.SqlClient`, and raw `EXEC` command strings.

## Routine Quality Signals

- Modules scanned: `398`
- Uses `NOLOCK`: `113`
- Uses `SELECT *`: `40`
- Uses dynamic SQL markers: `0`
- Uses cursors: `73`
- Uses temp tables: `22`
- Has TRY/CATCH markers: `5`

## API Routine Reference Check

The following routine-like names were found in API code but not found as database modules:

- `usp_PaymentChargeByPaymentId` first seen at `.\ChargePaymentService\PractiZing.BusinessLogic.ChargePaymentService\Repositories\PaymentChargeRepository.cs:540`
- `usp_GetDynmoPaymentsForCatalystRCM` first seen at `.\ChargePaymentService\PractiZing.BusinessLogic.ChargePaymentService\Repositories\DynmoPaymentsRepository.cs:484`

## Runtime Routine Validation Notes

- `dbo.PZ_Report.Command` currently references 36 executable report routines; all 36 were found in the database metadata.
- `dbo.Scrub.StoredProcedure` currently has 8 active configured names. Six are SQL stored procedures. `CPTToICDValidator` and `CPTToModifierValidator` were not found as database modules, so scrub requests using those names will fail if the API executes them through `SqlCommand.CommandType = StoredProcedure`.
- `sys.sql_expression_dependencies` reports many unresolved rows for trigger pseudo-tables and unqualified references. After excluding triggers and references that do exist by object name, the remaining missing referenced entities are `dtproperties`, `ARSCategoryReasonCodes`, `BL_PaymentsAdjustmentWithPayorLevel`, `ChargeBalanceAR90`, `CPAReportMonthYearWise`, and `CPAReportMonthYearWiseChild`.

## Dynamic Report Commands

| ID | Active | Report | Command |
|---:|:---:|---|---|
| 1 | True | `Charge Detail By DOS` | `exec rpt_ChargesDOSReport {fromDate},{toDate},{providerID},{FacilityID},{AuxillaryProviderId},{RefferingProviderId}` |
| 3 | True | `Deposit Summary` | `exec rpt_PaymentDepositsReport {fromDate},{toDate},{InsuranceCompanyId}` |
| 4 | True | `Aging By Insurance` | `exec rpt_Aging_Summary_By_Insurance {toDate}` |
| 6 | True | `Aging By Patient` | `exec rpt_Aging_Summary_By_Patient {toDate}` |
| 11 | True | `Aging Patient Detail By Insurance Company` | `exec rpt_Aging_Patient_Detail_By_InsuranceCompany {toDate}, {InsuranceCompanyId}` |
| 13 | True | `AR Associated` | `exec rpt_GetAssociatedARReport {fromDate}, {toDate}` |
| 17 | True | `CPA By Provider Details` | `exec rpt_CPA_By_Provider_Report {fromDate}, {toDate}` |
| 18 | True | `CPA By Provider Revenue Center` | `exec rpt_CPAByRevenueCenterReport {fromDate}, {toDate}` |
| 25 | True | `Patient Balance` | `exec rpt_GetPatientBalanceReport {toDate}` |
| 27 | True | `Patient StatementFinal` | `exec rpt_PatientChargeStatement {patientId},{FromDate},{toDate},{Message},{IsBulkStatement},{IsAllCharges}` |
| 31 | True | `Payment By Accession` | `exec usp_PaymentByAccession {fromDate},{toDate}` |
| 35 | True | `CPA By Provider Details By Dos` | `exec rpt_CPA_By_Provider_Report_ByDOSDate_LOOP {fromDate}, {toDate},{ProviderID},{AuxillaryProviderId},{RefferingProviderId},{FacilityId}` |
| 37 | True | `CPA By Provider Details Post Date` | `exec rpt_CPA_By_Provider_By_PostDate_Report {fromDate}, {toDate},{ProviderID},{AuxillaryProviderId},{RefferingProviderId},{FacilityId}` |
| 39 | True | `CPA by Auxillary Provider Details Post Date` | `exec rpt_CPA_By_AuxillaryProvider_By_PostDate_Report {fromDate}, {toDate}` |
| 40 | True | `CPA By Facility Details By Post Date` | `exec rpt_CPA_By_Facility_By_PostDate_Report {fromDate}, {toDate},{facilityId}` |
| 41 | True | `Payment Posting` | `exec rpt_PostingPaymentByDate {FromDate},{ToDate},{ProviderId},{FacilityId},{InsuranceCompanyId},{AuxillaryProviderId},{RefferingProviderId}` |
| 42 | True | `CPA By Facility Details By Dos` | `exec rpt_CPA_By_Facility_Report_ByDOSDate_LOOP {fromDate}, {toDate},{facilityId}` |
| 43 | True | `Payment Posting By CPT Codes` | `exec rpt_PostingPaymentByCptCodeByPostDate {FromDate},{ToDate},{ProviderId},{FacilityId},{InsuranceCompanyId},{AuxillaryProviderId},{RefferingProviderId}` |
| 2 | False | `CPA By Provider` | `exec rpt_CPAByProvider {fromDate},{toDate},{providerID}` |
| 5 | False | `Aging By Insurance Type` | `exec rpt_Aging_Summary_By_InsuranceCompanyType {toDate}` |
| 12 | False | `Adjustment Patient Detail By DOS` | `exec rpt_AdjustmentPatientDetailByDOS {fromDate}, {toDate}` |
| 14 | False | `Charge Details By DOS By RevCenter` | `exec rpt_ChargeDetailsByDOSByCategory {fromDate}, {toDate}` |
| 15 | False | `Charge Detail By POS` | `exec rpt_ChargeDetailsByPostDate {fromDate}, {toDate}` |
| 16 | False | `Charges With PrimaryIns Applied` | `exec rpt_pm_PrimaryPaymentsApplied {fromDate}, {toDate}` |
| 19 | False | `CPA Details By DOS And CPT` | `exec rpt_CPADetailsByDOSByCPT {fromDate},{toDate},{cptcodes}` |
| 20 | False | `CPTCode Reimbursement` | `exec rpt_CPTCodeReimbursementReport {fromDate}, {toDate},{cptcodes}` |
| 21 | False | `Denial Details` | `exec rpt_GetDenialDetails {fromDate}, {toDate},{reasoncodes}` |
| 22 | False | `Insurance Balance` | `exec rpt_GetInsuranceBalanceReport {toDate}` |
| 23 | False | `Lab Activity By Ordering Provider` | `exec rpt_LabActivityByOrderingProviderReport {fromDate}, {toDate}` |
| 24 | False | `Lab Activity By Payer` | `exec rpt_LabActivityByPayerReport {fromDate}, {toDate}` |
| 26 | False | `Patient DOS CPAO Detail` | `exec rpt_PatientDOSCPAODetailReport {fromDate}, {toDate},{cptcodes}` |
| 28 | False | `Aging Account Balances` | `` |
| 29 | False | `AR Status Info` | `exec rpt_PatientAndInsARStatusReport {fromDate}, {toDate}` |
| 30 | False | `Payment Details` | `exec rpt_GetPaymentDetails {fromDate}, {toDate}` |
| 36 | False | `CCPA By Provider Details` | `exec rpt_CCPA_By_Provider_Report {fromDate}, {toDate}` |
| 38 | False | `CCPA By Provider Details` | `exec rpt_CCPA_By_Provider_Report {fromDate}, {toDate}` |
| 44 | False | `Payment Breakdown Month-wise` | `exec usp_GetInsurancewisePaymentReport {fromDate}, {toDate}` |

## Scrub Stored Procedure Configuration

| ID | Active | Name | Stored Procedure |
|---:|:---:|---|---|
| 1 | True | `Scrub 81 EM Needs Mod 25` | `usp_RunScrub81EM` |
| 2 | True | `Scrub 82 EM needs Mod 24` | `usp_RunScrub82EM` |
| 3 | True | `Scrub 83 EM needs Mod 57` | `usp_RunScrub83EM` |
| 4 | True | `Scrub 84 Surg needs mod 58, 59, 78, 79` | `usp_RunScrub84EM` |
| 5 | True | `Scrub 86 CCI Edits` | `usp_RunScrub86EM` |
| 6 | True | `Scrub 124 J Code Without NDC Message Code` | `usp_RunScrub124` |
| 7 | True | `CPTToICDValidator` | `CPTToICDValidator` |
| 8 | True | `CPTToModifierValidator` | `CPTToModifierValidator` |

## Possible Broken SQL Dependencies

| Referencing object | Referenced schema | Referenced entity |
|---|---|---|
| `dbo.rpt_Aging_Patient_Detail_By_InsuranceCompany` | `` | `rpt_InsuranceAgaingPatientReport` |
| `dbo.rpt_Aging_Summary_By_Insurance` | `` | `rpt_InsuranceAgaingReport` |
| `dbo.rpt_Aging_Summary_By_Patient` | `` | `rpt_PatientAgaingReport` |
| `dbo.rpt_CPA_By_Facility_Report_ByDOSDate_LOOP` | `` | `rpt_CPA_By_Facility_Report_ByDOSDate` |
| `dbo.rpt_CPA_By_Provider_Report_ByDOSDate_LOOP` | `` | `rpt_CPA_By_Provider_Report_ByDOSDate` |
| `dbo.rpt_CPAByProvider` | `` | `rpt_PaymentsToDoctors` |
| `dbo.rpt_CPADetailsByDOSByCPT` | `` | `usp_dos` |
| `dbo.rpt_CPTCodeReimbursementReport` | `` | `usp_PostDetail` |
| `dbo.rpt_GetAssociatedARReport` | `` | `rpt_Aging_Summary_By_Revenue_Center` |
| `dbo.rpt_GetPaymentDetails` | `` | `usp_GetPaymentsToCompany` |
| `dbo.rpt_GetPaymentDetails` | `` | `usp_GetPaymentsToDoctors` |
| `dbo.rpt_PatientAndInsARStatusReport` | `` | `rpt_PatientAndInsTotalARStatusReport` |
| `dbo.rpt_PatientChargeStatement` | `` | `usp_ImportChargesInDataWareHouseTable_PatientWise` |
| `dbo.rpt_PatientChargeStatement_Rohit` | `` | `usp_ImportChargesInDataWareHouseTable_PatientWise` |
| `dbo.rpt_PatientDOSCPAODetailReport` | `` | `usp_dos` |
| `dbo.sp_upgraddiagrams` | `dbo` | `dtproperties` |
| `dbo.trg_ActionCategory_Delete` | `` | `deleted` |
| `dbo.trg_ActionCategory_Insert` | `` | `inserted` |
| `dbo.trg_ActionCategory_Update` | `` | `deleted` |
| `dbo.trg_ActionCategory_Update` | `` | `inserted` |
| `dbo.trg_ActionNote_Delete` | `` | `deleted` |
| `dbo.trg_ActionNote_Insert` | `` | `inserted` |
| `dbo.trg_ActionNote_Update` | `` | `deleted` |
| `dbo.trg_ActionNote_Update` | `` | `inserted` |
| `dbo.trg_AppSetting_Delete` | `` | `deleted` |
| `dbo.trg_AppSetting_Insert` | `` | `inserted` |
| `dbo.trg_AppSetting_Update` | `` | `deleted` |
| `dbo.trg_AppSetting_Update` | `` | `inserted` |
| `dbo.trg_ARGroup_Delete` | `` | `deleted` |
| `dbo.trg_ARGroup_Insert` | `` | `inserted` |
| `dbo.trg_ARGroup_Update` | `` | `deleted` |
| `dbo.trg_ARGroup_Update` | `` | `inserted` |
| `dbo.trg_ARGroupReasonCode_Delete` | `` | `deleted` |
| `dbo.trg_ARGroupReasonCode_Insert` | `` | `inserted` |
| `dbo.trg_ARGroupReasonCode_Update` | `` | `deleted` |
| `dbo.trg_ARGroupReasonCode_Update` | `` | `inserted` |
| `dbo.trg_ARSCategoryReasonCode_Delete` | `` | `deleted` |
| `dbo.trg_ARSCategoryReasonCode_Insert` | `` | `inserted` |
| `dbo.trg_ARSCategoryReasonCode_Update` | `` | `deleted` |
| `dbo.trg_ARSCategoryReasonCode_Update` | `` | `inserted` |
| `dbo.trg_AttFile_Delete` | `` | `deleted` |
| `dbo.trg_AttFile_Insert` | `` | `inserted` |
| `dbo.trg_AttFile_Update` | `` | `deleted` |
| `dbo.trg_AttFile_Update` | `` | `inserted` |
| `dbo.trg_AttFileTable_Delete` | `` | `deleted` |
| `dbo.trg_AttFileTable_Insert` | `` | `inserted` |
| `dbo.trg_AttFileTable_Update` | `` | `deleted` |
| `dbo.trg_AttFileTable_Update` | `` | `inserted` |
| `dbo.trg_Charge_Delete` | `` | `deleted` |
| `dbo.trg_Charge_Insert` | `` | `inserted` |
| `dbo.trg_Charge_Update` | `` | `deleted` |
| `dbo.trg_Charge_Update` | `` | `inserted` |
| `dbo.trg_ChargeBatch_Delete` | `` | `deleted` |
| `dbo.trg_ChargeBatch_Insert` | `` | `inserted` |
| `dbo.trg_ChargeBatch_Update` | `` | `deleted` |
| `dbo.trg_ChargeBatch_Update` | `` | `inserted` |
| `dbo.trg_Claim_Delete` | `` | `deleted` |
| `dbo.trg_Claim_Insert` | `` | `inserted` |
| `dbo.trg_Claim_Update` | `` | `deleted` |
| `dbo.trg_Claim_Update` | `` | `inserted` |
| `dbo.trg_ClaimBatch_Delete` | `` | `deleted` |
| `dbo.trg_ClaimBatch_Insert` | `` | `inserted` |
| `dbo.trg_ClaimBatch_Update` | `` | `deleted` |
| `dbo.trg_ClaimBatch_Update` | `` | `inserted` |
| `dbo.trg_ClaimCharge_Delete` | `` | `deleted` |
| `dbo.trg_ClaimCharge_Insert` | `` | `inserted` |
| `dbo.trg_ClaimCharge_Update` | `` | `deleted` |
| `dbo.trg_ClaimCharge_Update` | `` | `inserted` |
| `dbo.trg_ClaimConfig_Delete` | `` | `deleted` |
| `dbo.trg_ClaimConfig_Insert` | `` | `inserted` |
| `dbo.trg_ClaimConfig_Update` | `` | `deleted` |
| `dbo.trg_ClaimConfig_Update` | `` | `inserted` |
| `dbo.trg_ClaimTotal_Delete` | `` | `deleted` |
| `dbo.trg_ClaimTotal_Insert` | `` | `inserted` |
| `dbo.trg_ClaimTotal_Update` | `` | `deleted` |
| `dbo.trg_ClaimTotal_Update` | `` | `inserted` |
| `dbo.trg_Clearinghouse_Delete` | `` | `deleted` |
| `dbo.trg_Clearinghouse_Insert` | `` | `inserted` |
| `dbo.trg_Clearinghouse_Update` | `` | `deleted` |
| `dbo.trg_Clearinghouse_Update` | `` | `inserted` |
| `dbo.trg_ConfigBillType_Delete` | `` | `deleted` |
| `dbo.trg_ConfigBillType_Insert` | `` | `inserted` |
| `dbo.trg_ConfigBillType_Update` | `` | `deleted` |
| `dbo.trg_ConfigBillType_Update` | `` | `inserted` |
| `dbo.trg_ConfigCaseType_Delete` | `` | `deleted` |
| `dbo.trg_ConfigCaseType_Insert` | `` | `inserted` |
| `dbo.trg_ConfigCaseType_Update` | `` | `deleted` |
| `dbo.trg_ConfigCaseType_Update` | `` | `inserted` |
| `dbo.trg_ConfigDrugClass_Delete` | `` | `deleted` |
| `dbo.trg_ConfigDrugClass_Insert` | `` | `inserted` |
| `dbo.trg_ConfigDrugClass_Update` | `` | `deleted` |
| `dbo.trg_ConfigDrugClass_Update` | `` | `inserted` |
| `dbo.trg_ConfigFacilitySubType_Delete` | `` | `deleted` |
| `dbo.trg_ConfigFacilitySubType_Insert` | `` | `inserted` |
| `dbo.trg_ConfigFacilitySubType_Update` | `` | `deleted` |
| `dbo.trg_ConfigFacilitySubType_Update` | `` | `inserted` |
| `dbo.trg_ConfigFacilityType_Delete` | `` | `deleted` |
| `dbo.trg_ConfigFacilityType_Insert` | `` | `inserted` |
| `dbo.trg_ConfigFacilityType_Update` | `` | `deleted` |
| `dbo.trg_ConfigFacilityType_Update` | `` | `inserted` |
| `dbo.trg_ConfigFollowUpPeriod_Delete` | `` | `deleted` |
| `dbo.trg_ConfigFollowUpPeriod_Insert` | `` | `inserted` |
| `dbo.trg_ConfigFollowUpPeriod_Update` | `` | `deleted` |
| `dbo.trg_ConfigFollowUpPeriod_Update` | `` | `inserted` |
| `dbo.trg_ConfigIdType_Delete` | `` | `deleted` |
| `dbo.trg_ConfigIdType_Insert` | `` | `inserted` |
| `dbo.trg_ConfigIdType_Update` | `` | `deleted` |
| `dbo.trg_ConfigIdType_Update` | `` | `inserted` |
| `dbo.trg_ConfigInsuranceCompanyType_Delete` | `` | `deleted` |
| `dbo.trg_ConfigInsuranceCompanyType_Insert` | `` | `inserted` |
| `dbo.trg_ConfigInsuranceCompanyType_Update` | `` | `deleted` |
| `dbo.trg_ConfigInsuranceCompanyType_Update` | `` | `inserted` |
| `dbo.trg_ConfigInsuranceFormType_Delete` | `` | `deleted` |
| `dbo.trg_ConfigInsuranceFormType_Insert` | `` | `inserted` |
| `dbo.trg_ConfigInsuranceFormType_Update` | `` | `deleted` |
| `dbo.trg_ConfigInsuranceFormType_Update` | `` | `inserted` |
| `dbo.trg_ConfigInsuranceMedicareSecondary_Delete` | `` | `deleted` |
| `dbo.trg_ConfigInsuranceMedicareSecondary_Insert` | `` | `inserted` |
| `dbo.trg_ConfigInsuranceMedicareSecondary_Update` | `` | `deleted` |
| `dbo.trg_ConfigInsuranceMedicareSecondary_Update` | `` | `inserted` |
| `dbo.trg_ConfigPOS_Delete` | `` | `deleted` |
| `dbo.trg_ConfigPOS_Insert` | `` | `inserted` |
| `dbo.trg_ConfigPOS_Update` | `` | `deleted` |
| `dbo.trg_ConfigPOS_Update` | `` | `inserted` |
| `dbo.trg_ConfigPosition_Delete` | `` | `deleted` |
| `dbo.trg_ConfigPosition_Insert` | `` | `inserted` |
| `dbo.trg_ConfigPosition_Update` | `` | `deleted` |
| `dbo.trg_ConfigPosition_Update` | `` | `inserted` |
| `dbo.trg_ConfigProviderPosition_Delete` | `` | `deleted` |
| `dbo.trg_ConfigProviderPosition_Insert` | `` | `inserted` |
| `dbo.trg_ConfigProviderPosition_Update` | `` | `deleted` |
| `dbo.trg_ConfigProviderPosition_Update` | `` | `inserted` |
| `dbo.trg_ConfigProviderSpecialty_Delete` | `` | `deleted` |
| `dbo.trg_ConfigProviderSpecialty_Insert` | `` | `inserted` |
| `dbo.trg_ConfigProviderSpecialty_Update` | `` | `deleted` |
| `dbo.trg_ConfigProviderSpecialty_Update` | `` | `inserted` |
| `dbo.trg_ConfigReferralSource_Delete` | `` | `deleted` |
| `dbo.trg_ConfigReferralSource_Insert` | `` | `inserted` |
| `dbo.trg_ConfigReferralSource_Update` | `` | `deleted` |
| `dbo.trg_ConfigReferralSource_Update` | `` | `inserted` |
| `dbo.trg_ConfigRelationship_Delete` | `` | `deleted` |
| `dbo.trg_ConfigRelationship_Insert` | `` | `inserted` |
| `dbo.trg_ConfigRelationship_Update` | `` | `deleted` |
| `dbo.trg_ConfigRelationship_Update` | `` | `inserted` |
| `dbo.trg_ConfigSetting_Delete` | `` | `deleted` |
| `dbo.trg_ConfigSetting_Insert` | `` | `inserted` |
| `dbo.trg_ConfigSetting_Update` | `` | `deleted` |
| `dbo.trg_ConfigSetting_Update` | `` | `inserted` |
| `dbo.trg_ConfigSettingGroup_Delete` | `` | `deleted` |
| `dbo.trg_ConfigSettingGroup_Insert` | `` | `inserted` |
| `dbo.trg_ConfigSettingGroup_Update` | `` | `deleted` |
| `dbo.trg_ConfigSettingGroup_Update` | `` | `inserted` |
| `dbo.trg_ConfigSystemCD_Delete` | `` | `deleted` |
| `dbo.trg_ConfigSystemCD_Insert` | `` | `inserted` |
| `dbo.trg_ConfigSystemCD_Update` | `` | `deleted` |
| `dbo.trg_ConfigSystemCD_Update` | `` | `inserted` |
| `dbo.trg_ConfigTOS_Delete` | `` | `deleted` |
| `dbo.trg_ConfigTOS_Insert` | `` | `inserted` |
| `dbo.trg_ConfigTOS_Update` | `` | `deleted` |
| `dbo.trg_ConfigTOS_Update` | `` | `inserted` |
| `dbo.trg_CPTCategory_Delete` | `` | `deleted` |
| `dbo.trg_CPTCategory_Insert` | `` | `inserted` |
| `dbo.trg_CPTCategory_Update` | `` | `deleted` |
| `dbo.trg_CPTCategory_Update` | `` | `inserted` |
| `dbo.trg_CPTCode_Delete` | `` | `deleted` |
| `dbo.trg_CPTCode_Insert` | `` | `inserted` |
| `dbo.trg_CPTCode_Update` | `` | `deleted` |
| `dbo.trg_CPTCode_Update` | `` | `inserted` |
| `dbo.trg_CPTModifier_Delete` | `` | `deleted` |
| `dbo.trg_CPTModifier_Insert` | `` | `inserted` |
| `dbo.trg_CPTModifier_Update` | `` | `deleted` |
| `dbo.trg_CPTModifier_Update` | `` | `inserted` |
| `dbo.trg_DefaultReasonCode_Delete` | `` | `deleted` |
| `dbo.trg_DefaultReasonCode_Insert` | `` | `inserted` |
| `dbo.trg_DefaultReasonCode_Update` | `` | `deleted` |
| `dbo.trg_DefaultReasonCode_Update` | `` | `inserted` |
| `dbo.trg_DenialQueue_Delete` | `` | `deleted` |
| `dbo.trg_DenialQueue_Insert` | `` | `inserted` |
| `dbo.trg_DenialQueue_Update` | `` | `deleted` |
| `dbo.trg_DenialQueue_Update` | `` | `inserted` |
| `dbo.trg_DepositType_Delete` | `` | `deleted` |
| `dbo.trg_DepositType_Insert` | `` | `inserted` |
| `dbo.trg_DepositType_Update` | `` | `deleted` |
| `dbo.trg_DepositType_Update` | `` | `inserted` |
| `dbo.trg_Destination_Delete` | `` | `deleted` |
| `dbo.trg_Destination_Insert` | `` | `inserted` |
| `dbo.trg_Destination_Update` | `` | `deleted` |
| `dbo.trg_Destination_Update` | `` | `inserted` |
| `dbo.trg_DrugClass_Delete` | `` | `deleted` |
| `dbo.trg_DrugClass_Insert` | `` | `inserted` |
| `dbo.trg_DrugClass_Update` | `` | `deleted` |
| `dbo.trg_DrugClass_Update` | `` | `inserted` |
| `dbo.trg_DynmoPayments_Delete` | `` | `deleted` |
| `dbo.trg_DynmoPayments_Insert` | `` | `inserted` |
| `dbo.trg_DynmoPayments_Update` | `` | `deleted` |
| `dbo.trg_DynmoPayments_Update` | `` | `inserted` |
| `dbo.trg_ERAClaim_Delete` | `` | `deleted` |
| `dbo.trg_ERAClaim_Insert` | `` | `inserted` |
| `dbo.trg_ERAClaim_Update` | `` | `deleted` |
| `dbo.trg_ERAClaim_Update` | `` | `inserted` |
| `dbo.trg_ERAClaimChargeAdjustment_Delete` | `` | `deleted` |
| `dbo.trg_ERAClaimChargeAdjustment_Insert` | `` | `inserted` |
| `dbo.trg_ERAClaimChargeAdjustment_Update` | `` | `deleted` |
| `dbo.trg_ERAClaimChargeAdjustment_Update` | `` | `inserted` |
| `dbo.trg_ERAClaimChargePayment_Delete` | `` | `deleted` |
| `dbo.trg_ERAClaimChargePayment_Insert` | `` | `inserted` |
| `dbo.trg_ERAClaimChargePayment_Update` | `` | `deleted` |
| `dbo.trg_ERAClaimChargePayment_Update` | `` | `inserted` |
| `dbo.trg_ERAClaimChargeRemark_Delete` | `` | `deleted` |
| `dbo.trg_ERAClaimChargeRemark_Insert` | `` | `inserted` |
| `dbo.trg_ERAClaimChargeRemark_Update` | `` | `deleted` |
| `dbo.trg_ERAClaimChargeRemark_Update` | `` | `inserted` |
| `dbo.trg_ERARoot_Delete` | `` | `deleted` |
| `dbo.trg_ERARoot_Insert` | `` | `inserted` |
| `dbo.trg_ERARoot_Update` | `` | `deleted` |
| `dbo.trg_ERARoot_Update` | `` | `inserted` |
| `dbo.trg_Facility_Delete` | `` | `deleted` |
| `dbo.trg_Facility_Insert` | `` | `inserted` |
| `dbo.trg_Facility_Update` | `` | `deleted` |
| `dbo.trg_Facility_Update` | `` | `inserted` |
| `dbo.trg_FacilityIdentity_Delete` | `` | `deleted` |
| `dbo.trg_FacilityIdentity_Insert` | `` | `inserted` |
| `dbo.trg_FacilityIdentity_Update` | `` | `deleted` |
| `dbo.trg_FacilityIdentity_Update` | `` | `inserted` |
| `dbo.trg_FeeSchedule_Delete` | `` | `deleted` |
| `dbo.trg_FeeSchedule_Insert` | `` | `inserted` |
| `dbo.trg_FeeSchedule_Update` | `` | `deleted` |
| `dbo.trg_FeeSchedule_Update` | `` | `inserted` |
| `dbo.trg_FSCharge_Update` | `` | `deleted` |
| `dbo.trg_FSCharge_Update` | `` | `inserted` |
| `dbo.trg_ICDCode_Delete` | `` | `deleted` |
| `dbo.trg_ICDCode_Insert` | `` | `inserted` |
| `dbo.trg_ICDCode_Update` | `` | `deleted` |
| `dbo.trg_ICDCode_Update` | `` | `inserted` |
| `dbo.trg_InsuranceCompany_Delete` | `` | `deleted` |
| `dbo.trg_InsuranceCompany_Insert` | `` | `inserted` |
| `dbo.trg_InsuranceCompany_Update` | `` | `deleted` |
| `dbo.trg_InsuranceCompany_Update` | `` | `inserted` |
| `dbo.trg_InsuranceGuarantor_Delete` | `` | `deleted` |
| `dbo.trg_InsuranceGuarantor_Insert` | `` | `inserted` |
| `dbo.trg_InsuranceGuarantor_Update` | `` | `deleted` |
| `dbo.trg_InsuranceGuarantor_Update` | `` | `inserted` |
| `dbo.trg_InsurancePolicy_Delete` | `` | `deleted` |
| `dbo.trg_InsurancePolicy_Insert` | `` | `inserted` |
| `dbo.trg_InsurancePolicy_Update` | `` | `deleted` |
| `dbo.trg_InsurancePolicy_Update` | `` | `inserted` |
| `dbo.trg_InsurancePolicyHolder_Insert` | `` | `inserted` |
| `dbo.trg_InsurancePolicyHolder_Update` | `` | `deleted` |
| `dbo.trg_InsurancePolicyHolder_Update` | `` | `inserted` |
| `dbo.trg_InsurancePolicyHolderHolder_Delete` | `` | `deleted` |
| `dbo.trg_InvDiagnosis_Delete` | `` | `deleted` |
| `dbo.trg_InvDiagnosis_Insert` | `` | `inserted` |
| `dbo.trg_InvDiagnosis_Update` | `` | `deleted` |
| `dbo.trg_InvDiagnosis_Update` | `` | `inserted` |
| `dbo.trg_Invoice_Delete` | `` | `deleted` |
| `dbo.trg_Invoice_Insert` | `` | `inserted` |
| `dbo.trg_Invoice_Update` | `` | `deleted` |
| `dbo.trg_Invoice_Update` | `` | `inserted` |
| `dbo.trg_NDC_Delete` | `` | `deleted` |
| `dbo.trg_NDC_Insert` | `` | `inserted` |
| `dbo.trg_NDC_Update` | `` | `deleted` |
| `dbo.trg_NDC_Update` | `` | `inserted` |
| `dbo.trg_Patient_Delete` | `` | `deleted` |
| `dbo.trg_Patient_Insert` | `` | `inserted` |
| `dbo.trg_Patient_Update` | `` | `deleted` |
| `dbo.trg_Patient_Update` | `` | `inserted` |
| `dbo.trg_PatientAuthorizationNumber_Insert` | `` | `inserted` |
| `dbo.trg_PatientAuthorizationNumber_Update` | `` | `deleted` |
| `dbo.trg_PatientAuthorizationNumber_Update` | `` | `inserted` |
| `dbo.trg_PatientCase_Delete` | `` | `deleted` |
| `dbo.trg_PatientCase_Insert` | `` | `inserted` |
| `dbo.trg_PatientCase_Update` | `` | `deleted` |
| `dbo.trg_PatientCase_Update` | `` | `inserted` |
| `dbo.trg_Payment_Delete` | `` | `deleted` |
| `dbo.trg_Payment_Insert` | `` | `inserted` |
| `dbo.trg_Payment_Update` | `` | `deleted` |
| `dbo.trg_Payment_Update` | `` | `inserted` |
| `dbo.trg_PaymentAdjustment_Delete` | `` | `deleted` |
| `dbo.trg_PaymentAdjustment_Insert` | `` | `inserted` |
| `dbo.trg_PaymentAdjustment_Update` | `` | `deleted` |
| `dbo.trg_PaymentAdjustment_Update` | `` | `inserted` |
| `dbo.trg_PaymentBatch_Delete` | `` | `deleted` |
| `dbo.trg_PaymentBatch_Insert` | `` | `inserted` |
| `dbo.trg_PaymentBatch_Update` | `` | `deleted` |
| `dbo.trg_PaymentBatch_Update` | `` | `inserted` |
| `dbo.trg_PaymentCharge_Delete` | `` | `deleted` |
| `dbo.trg_PaymentCharge_Insert` | `` | `inserted` |
| `dbo.trg_PaymentCharge_Update` | `` | `deleted` |
| `dbo.trg_PaymentCharge_Update` | `` | `inserted` |
| `dbo.trg_PaymentRemarkCode_Delete` | `` | `deleted` |
| `dbo.trg_PaymentRemarkCode_Insert` | `` | `inserted` |
| `dbo.trg_PaymentRemarkCode_Update` | `` | `deleted` |
| `dbo.trg_PaymentRemarkCode_Update` | `` | `inserted` |
| `dbo.trg_PortalPayment_Delete` | `` | `deleted` |
| `dbo.trg_PortalPayment_Insert` | `` | `inserted` |
| `dbo.trg_Provider_Delete` | `` | `deleted` |
| `dbo.trg_Provider_Insert` | `` | `inserted` |
| `dbo.trg_Provider_Update` | `` | `deleted` |
| `dbo.trg_Provider_Update` | `` | `inserted` |
| `dbo.trg_PUser_Delete` | `` | `deleted` |
| `dbo.trg_PUser_Insert` | `` | `inserted` |
| `dbo.trg_PUser_Update` | `` | `deleted` |
| `dbo.trg_PUser_Update` | `` | `inserted` |
| `dbo.trg_ReferringDoctor_Delete` | `` | `deleted` |
| `dbo.trg_ReferringDoctor_Insert` | `` | `inserted` |
| `dbo.trg_ReferringDoctor_Update` | `` | `deleted` |
| `dbo.trg_ReferringDoctor_Update` | `` | `inserted` |
| `dbo.trg_Voucher_Delete` | `` | `inserted` |
| `dbo.trg_Voucher_Insert` | `` | `inserted` |
| `dbo.trg_Voucher_Update` | `` | `inserted` |
| `dbo.ufn_GetPaymentReasonsCodeByChargeNumber_Denial` | `` | `ARSCategoryReasonCodes` |
| `dbo.ufn_GetPaymentReasonsCodeByChargeNumber_Denial` | `` | `BL_PaymentsAdjustmentWithPayorLevel` |
| `dbo.usp_90DaysBalanceFinal` | `` | `ChargeBalanceAR90` |
| `dbo.usp_90DaysBalanceFinal` | `` | `CPAReportMonthYearWise` |
| `dbo.usp_90DaysBalanceFinal` | `` | `CPAReportMonthYearWiseChild` |
| `dbo.usp_ChargeSnapShotsMonthWise_Consolidated` | `dbo` | `ChargesReportDataSnapShots` |
| `dbo.usp_ChargeSnapShotsMonthWise_Consolidated` | `dbo` | `ChargesReportDataSnapShotsChild` |
| `dbo.usp_ChargeSnapShotsMonthWise_RUNALL` | `dbo` | `usp_ChargeSnapShotsMonthWise` |
| `dbo.usp_ChargeSnapShotsMonthWise_RUNALL` | `dbo` | `usp_ChargeSnapShotsMonthWise` |
| `dbo.usp_ChargeSnapShotsMonthWise_RUNALL` | `dbo` | `usp_ChargeSnapShotsMonthWise` |
| `dbo.usp_ChargeSnapShotsMonthWise_RUNALL` | `dbo` | `usp_ChargeSnapShotsMonthWise` |
| `dbo.usp_ConsolidateAllDbsChargeData` | `dbo` | `ChargesReportData` |
| `dbo.usp_ConsolidateAllDbsPaymentData` | `dbo` | `PaymentReportData` |
| `dbo.usp_CPAReportYearMonthWise` | `` | `CPAReportMonthYearWise` |
| `dbo.usp_CPAReportYearMonthWise` | `` | `CPAReportMonthYearWiseChild` |
| `dbo.usp_DOSDetailReport` | `` | `usp_dos` |
| `dbo.usp_GetActionNotesForCatalyst` | `dbo` | `ActionCategory` |
| `dbo.usp_GetActionNotesForCatalyst` | `dbo` | `ActionNote` |
| `dbo.usp_GetAllPracticesVouchers` | `dbo` | `Charge` |
| `dbo.usp_GetAllPracticesVouchers` | `dbo` | `DepositType` |
| `dbo.usp_GetAllPracticesVouchers` | `dbo` | `InsuranceCompany` |
| `dbo.usp_GetAllPracticesVouchers` | `dbo` | `Payment` |
| `dbo.usp_GetAllPracticesVouchers` | `dbo` | `PaymentAdjustment` |
| `dbo.usp_GetAllPracticesVouchers` | `dbo` | `PaymentCharge` |
| `dbo.usp_GetAllPracticesVouchers` | `dbo` | `Voucher` |
| `dbo.usp_GetARAging90DaysData` | `` | `ChargeBalanceAR90` |
| `dbo.usp_GetDenialManagementAgingCountByRange` | `` | `usp_DenialManagementAgingCount` |
| `dbo.usp_GetDenialManagementAgingCountByRangeAfterFilter` | `` | `usp_DenialManagementAgingCountAfterFilter` |
| `dbo.usp_GetDenialManagementAgingCountByRangeFilter` | `` | `usp_DenialManagementAgingCountCharges` |
| `dbo.usp_GetVouchersForPlaidPayments` | `dbo` | `Voucher` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `ActionCategory` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `ActionNote` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `Claim` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `ConfigInsuranceCompanyType` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `ConfigRelationship` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `CptCode` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `Facility` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `FacilityIdentity` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `InsuranceCompany` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `Invoice` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `Patient` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `Payment` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `PaymentAdjustment` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `PaymentCharge` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `ReferringDoctor` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `ufn_ActiveInsuranceForCaseNo_PolicyNumber` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `Voucher` |
| `dbo.USP_ImportCatalystAllChargeIntoWareHouseTable` | `dbo` | `vw_GetChargeForPendingPayment_Dashboard` |
| `dbo.usp_InsertDataInCollectionPercentageTable` | `` | `usp_InsertDataInCollectionPercentageTableChild` |
| `dbo.usp_PatientIntegrationWPA` | `` | `usp_AddInsurancePolicyByPatientId` |
| `dbo.usp_ReportARChargesMonthWiseNew` | `` | `usp_GetTableForMonthReport` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `ActionCategory` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `ActionNote` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `Claim` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `ConfigInsuranceCompanyType` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `ConfigRelationship` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `CptCode` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `Facility` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `FacilityIdentity` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `InsuranceCompany` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `Patient` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `Payment` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `PaymentAdjustment` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `PaymentCharge` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `Provider` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `ProviderIdentity` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `ufn_ActiveInsuranceForCaseNo_PolicyNumber` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `Voucher` |
| `dbo.USP_ReportDataForCatalystAllCharges` | `dbo` | `vw_GetChargeForPendingPayment_Dashboard` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `ActionNote` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `Claim` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `ConfigInsuranceCompanyType` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `ConfigRelationship` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `CptCode` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `Facility` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `FacilityIdentity` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `InsuranceCompany` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `Patient` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `Payment` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `PaymentAdjustment` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `PaymentCharge` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `Provider` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `ProviderIdentity` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `ufn_ActiveInsuranceForCaseNo_PolicyNumber` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `Voucher` |
| `dbo.USP_ReportDataForCatalystAllCharges_Test` | `dbo` | `vw_GetChargeForPendingPayment_Dashboard` |
| `dbo.usp_RunDenialDashboard` | `` | `usp_insertorupdatechargestat` |
| `dbo.usp_UpdatePlaidPayment_Voucher` | `dbo` | `Voucher` |
| `dbo.usp_WeeklyChargeInfoReport` | `` | `usp_PostDetail` |

## Tables

- `dbo.ActionCategory` (15 columns)
- `dbo.ActionNote` (21 columns)
- `dbo.AdjustmentReasonCode` (14 columns)
- `dbo.AppSetting` (10 columns)
- `dbo.ARGroup` (8 columns)
- `dbo.ARGroupReasonCode` (3 columns)
- `dbo.ARSCategoryReasonCode` (5 columns)
- `dbo.ATC_DATA` (23 columns)
- `dbo.AttFile` (12 columns)
- `dbo.AttFileTable` (3 columns)
- `dbo.BankReconciliation` (30 columns)
- `dbo.BatchStatement` (12 columns)
- `dbo.BillingUnitConversionChart` (4 columns)
- `dbo.CallHistory` (12 columns)
- `dbo.CatalystChargeNotes` (7 columns)
- `dbo.Charge` (64 columns)
- `dbo.ChargeBatch` (12 columns)
- `dbo.ChargeInWriteOff` (10 columns)
- `dbo.ChargeNote` (8 columns)
- `dbo.ChargeOld` (68 columns)
- `dbo.ChargeScrub` (3 columns)
- `dbo.ChargesForCatalystExcel` (68 columns)
- `dbo.ChargesReportData` (156 columns)
- `dbo.ChargesReportData_Consolidate` (135 columns)
- `dbo.ChargesReportDataSnapShots` (15 columns)
- `dbo.ChargesReportDataSnapShots_All` (16 columns)
- `dbo.ChargesReportDataSnapShotsChild` (14 columns)
- `dbo.ChargesReportDataSnapShotsChild_All` (15 columns)
- `dbo.ChargeStat` (10 columns)
- `dbo.ChargeStatementCount` (7 columns)
- `dbo.ChasePaymentChild` (5 columns)
- `dbo.ChasePayments` (15 columns)
- `dbo.Claim` (239 columns)
- `dbo.ClaimBatch` (21 columns)
- `dbo.ClaimCharge` (9 columns)
- `dbo.ClaimConfig` (10 columns)
- `dbo.ClaimStatusInquiry` (4 columns)
- `dbo.ClaimStatusInquiryChild` (14 columns)
- `dbo.ClaimTotal` (16 columns)
- `dbo.Clearinghouse` (48 columns)
- `dbo.ConfigAdjustmentReasonCode` (11 columns)
- `dbo.ConfigBillType` (3 columns)
- `dbo.ConfigCaseType` (5 columns)
- `dbo.ConfigCDGroup` (3 columns)
- `dbo.ConfigClaimTypeCodes` (3 columns)
- `dbo.ConfigDrugClass` (5 columns)
- `dbo.ConfigERARemarkCodes` (5 columns)
- `dbo.ConfigFacilitySubType` (5 columns)
- `dbo.ConfigFacilityType` (4 columns)
- `dbo.ConfigFollowUpPeriod` (5 columns)
- `dbo.ConfigIdType` (4 columns)
- `dbo.ConfigInsuranceCompanyType` (3 columns)
- `dbo.ConfigInsuranceFormType` (6 columns)
- `dbo.ConfigInsuranceMedicareSecondary` (3 columns)
- `dbo.ConfigMaritalStatus` (3 columns)
- `dbo.ConfigMessageCode` (10 columns)
- `dbo.ConfigNDCUOM` (4 columns)
- `dbo.ConfigPatientRace` (6 columns)
- `dbo.ConfigPlaid` (6 columns)
- `dbo.ConfigPOS` (4 columns)
- `dbo.ConfigPosition` (3 columns)
- `dbo.ConfigPractitionerService` (10 columns)
- `dbo.ConfigProviderPosition` (3 columns)
- `dbo.ConfigProviderSpecialty` (4 columns)
- `dbo.ConfigReferralSource` (3 columns)
- `dbo.ConfigRelationship` (6 columns)
- `dbo.ConfigScrubsCCIEdit` (7 columns)
- `dbo.ConfigServiceCircumstance` (3 columns)
- `dbo.ConfigServiceType` (4 columns)
- `dbo.ConfigSetting` (11 columns)
- `dbo.ConfigSettingGroup` (4 columns)
- `dbo.ConfigSupervisionType` (2 columns)
- `dbo.ConfigSystemCD` (4 columns)
- `dbo.ConfigTOS` (3 columns)
- `dbo.ConfigTrizettoPatientEligibility` (23 columns)
- `dbo.CPT_To_ICD10` (5 columns)
- `dbo.CPT_To_Modifier` (5 columns)
- `dbo.CPTCategory` (11 columns)
- `dbo.CPTCode` (33 columns)
- `dbo.CPTModifier` (6 columns)
- `dbo.DailyQueue` (9 columns)
- `dbo.DefaultReasonCode` (9 columns)
- `dbo.DenialQueue` (15 columns)
- `dbo.DepositType` (7 columns)
- `dbo.Destination` (4 columns)
- `dbo.DrugCharge` (63 columns)
- `dbo.DrugClass` (8 columns)
- `dbo.dsig_test` (1 columns)
- `dbo.DynmoPayments` (29 columns)
- `dbo.EDI824` (13 columns)
- `dbo.EDIEligibilityLog` (9 columns)
- `dbo.EdiErrorCodes` (3 columns)
- `dbo.emricdcode` (3 columns)
- `dbo.EncounterRules` (11 columns)
- `dbo.EncounterRulesAllowedCPT` (4 columns)
- `dbo.EncounterRulesAllowedPOS` (4 columns)
- `dbo.EncounterTypes` (8 columns)
- `dbo.ERAClaim` (19 columns)
- `dbo.ERAClaimChargeAdjustment` (7 columns)
- `dbo.ERAClaimChargePayment` (11 columns)
- `dbo.ERAClaimChargeRemark` (4 columns)
- `dbo.ERARoot` (25 columns)
- `dbo.Facility` (32 columns)
- `dbo.FacilityIdentity` (9 columns)
- `dbo.FeeSchedule` (12 columns)
- `dbo.FSCharge` (17 columns)
- `dbo.FSDiscount` (13 columns)
- `dbo.FSLocalityCarrier` (3 columns)
- `dbo.H_ActionCategory` (18 columns)
- `dbo.H_ActionNote` (22 columns)
- `dbo.H_AppSetting` (13 columns)
- `dbo.H_ARGroup` (11 columns)
- `dbo.H_ARGroupReasonCode` (6 columns)
- `dbo.H_ARSCategoryReasonCode` (8 columns)
- `dbo.H_AttFile` (14 columns)
- `dbo.H_AttFileTable` (6 columns)
- `dbo.H_Charge` (60 columns)
- `dbo.H_ChargeBatch` (15 columns)
- `dbo.H_Claim` (158 columns)
- `dbo.H_ClaimBatch` (21 columns)
- `dbo.H_ClaimCharge` (7 columns)
- `dbo.H_ClaimConfig` (13 columns)
- `dbo.H_ClaimTotal` (19 columns)
- `dbo.H_Clearinghouse` (44 columns)
- `dbo.H_ConfigBillType` (6 columns)
- `dbo.H_ConfigCaseType` (8 columns)
- `dbo.H_ConfigCDGroup` (6 columns)
- `dbo.H_ConfigDrugClass` (7 columns)
- `dbo.H_ConfigFacilitySubType` (8 columns)
- `dbo.H_ConfigFacilityType` (7 columns)
- `dbo.H_ConfigFollowUpPeriod` (8 columns)
- `dbo.H_ConfigIdType` (7 columns)
- `dbo.H_ConfigInsuranceCompanyType` (6 columns)
- `dbo.H_ConfigInsuranceFormType` (9 columns)
- `dbo.H_ConfigInsuranceMedicareSecondary` (6 columns)
- `dbo.H_ConfigNDCUOM` (7 columns)
- `dbo.H_ConfigPOS` (7 columns)
- `dbo.H_ConfigPosition` (6 columns)
- `dbo.H_ConfigProviderPosition` (6 columns)
- `dbo.H_ConfigProviderSpecialty` (7 columns)
- `dbo.H_ConfigReferralSource` (6 columns)
- `dbo.H_ConfigRelationship` (9 columns)
- `dbo.H_ConfigSetting` (14 columns)
- `dbo.H_ConfigSettingGroup` (7 columns)
- `dbo.H_ConfigSystemCD` (7 columns)
- `dbo.H_ConfigTOS` (6 columns)
- `dbo.H_CPTCategory` (14 columns)
- `dbo.H_CPTCode` (30 columns)
- `dbo.H_CPTModifier` (8 columns)
- `dbo.H_DefaultReasonCode` (11 columns)
- `dbo.H_DenialQueue` (17 columns)
- `dbo.H_DepositType` (10 columns)
- `dbo.H_Destination` (7 columns)
- `dbo.H_DrugCharge` (55 columns)
- `dbo.H_DrugClass` (11 columns)
- `dbo.H_DynmoPayments` (32 columns)
- `dbo.H_ERAClaim` (14 columns)
- `dbo.H_ERAClaimChargeAdjustment` (8 columns)
- `dbo.H_ERAClaimChargePayment` (12 columns)
- `dbo.H_ERAClaimChargeRemark` (7 columns)
- `dbo.H_ERARoot` (27 columns)
- `dbo.H_Facility` (29 columns)
- `dbo.H_FacilityIdentity` (12 columns)
- `dbo.H_FeeSchedule` (15 columns)
- `dbo.H_FSCharge` (20 columns)
- `dbo.H_FSDiscount` (15 columns)
- `dbo.H_FSLocalityCarrier` (6 columns)
- `dbo.H_HL7Status` (18 columns)
- `dbo.H_ICDCode` (21 columns)
- `dbo.H_InsuranceCompany` (35 columns)
- `dbo.H_InsuranceGuarantor` (32 columns)
- `dbo.H_InsurancePolicy` (36 columns)
- `dbo.H_InsurancePolicyHolder` (32 columns)
- `dbo.H_InvDiagnosis` (8 columns)
- `dbo.H_Invoice` (57 columns)
- `dbo.H_NDC` (16 columns)
- `dbo.H_Patient` (118 columns)
- `dbo.H_PatientAuthorizationNumber` (13 columns)
- `dbo.H_PatientCase` (15 columns)
- `dbo.H_PatientStatement` (11 columns)
- `dbo.H_Payment` (22 columns)
- `dbo.H_PaymentAdjustment` (14 columns)
- `dbo.H_PaymentBatch` (15 columns)
- `dbo.H_PaymentCharge` (10 columns)
- `dbo.H_PaymentRemarkCode` (8 columns)
- `dbo.H_PortalPayment` (26 columns)
- `dbo.H_Practice` (12 columns)
- `dbo.H_Provider` (27 columns)
- `dbo.H_ProviderIdentity` (12 columns)
- `dbo.H_PUser` (20 columns)
- `dbo.H_ReferringDoctor` (30 columns)
- `dbo.H_Scrub` (13 columns)
- `dbo.H_ScrubAssignment` (11 columns)
- `dbo.H_Voucher` (25 columns)
- `dbo.H_ZipCodeLookup` (10 columns)
- `dbo.HL7RuleScripts` (5 columns)
- `dbo.HL7Status` (15 columns)
- `dbo.ICDCode` (20 columns)
- `dbo.icdtemp` (2 columns)
- `dbo.InsuranceCompany` (42 columns)
- `dbo.InsuranceGuarantor` (29 columns)
- `dbo.InsuranceOnlinePayment` (16 columns)
- `dbo.InsurancePolicy` (37 columns)
- `dbo.InsurancePolicy_ERAUpdate` (5 columns)
- `dbo.InsurancePolicyException` (4 columns)
- `dbo.InsurancePolicyHolder` (29 columns)
- `dbo.InvDiagnosis` (5 columns)
- `dbo.InvDxOld` (12 columns)
- `dbo.Invoice` (60 columns)
- `dbo.InvoiceOld` (73 columns)
- `dbo.LabSalesRep` (8 columns)
- `dbo.LISA_Charges` (4 columns)
- `dbo.LlmSettings` (9 columns)
- `dbo.MasterCPT` (2 columns)
- `dbo.MasterICD10` (2 columns)
- `dbo.MethaSoftInvoice` (20 columns)
- `dbo.MonthEndClose` (7 columns)
- `dbo.NDC` (14 columns)
- `dbo.Patient` (119 columns)
- `dbo.PatientAlert` (9 columns)
- `dbo.PatientAuthorizationNumber` (10 columns)
- `dbo.PatientCase` (12 columns)
- `dbo.PatientEligibility` (14 columns)
- `dbo.PatientEligibilityDetail` (29 columns)
- `dbo.PatientNote` (9 columns)
- `dbo.PatientPolicyAuthorization` (24 columns)
- `dbo.PatientState` (11 columns)
- `dbo.PatientStatement` (13 columns)
- `dbo.Payment` (21 columns)
- `dbo.PaymentAdjustment` (12 columns)
- `dbo.PaymentAdjustmentNotes` (9 columns)
- `dbo.PaymentBatch` (12 columns)
- `dbo.PaymentCharge` (7 columns)
- `dbo.PaymentRemarkCode` (6 columns)
- `dbo.PaymentReportData` (35 columns)
- `dbo.PaymentReportData__Consolidate` (37 columns)
- `dbo.PlaidPayment` (41 columns)
- `dbo.PortalPayment` (28 columns)
- `dbo.PortalPaymentChild` (3 columns)
- `dbo.Practice` (40 columns)
- `dbo.Provider` (38 columns)
- `dbo.ProviderFacilityValidtion` (3 columns)
- `dbo.ProviderIdentity` (9 columns)
- `dbo.Provieder_temp` (12 columns)
- `dbo.PZ_Module` (3 columns)
- `dbo.PZ_ModulePermission` (3 columns)
- `dbo.PZ_Report` (11 columns)
- `dbo.PZ_Role` (2 columns)
- `dbo.PZ_RoleModule` (3 columns)
- `dbo.PZ_User` (21 columns)
- `dbo.PZ_UserAuthentication` (7 columns)
- `dbo.PZ_UserPermission` (8 columns)
- `dbo.PZ_UserRole` (8 columns)
- `dbo.ReferringDoctor` (31 columns)
- `dbo.RemarkCodeSolution` (4 columns)
- `dbo.ReportARChargesMonthWise` (19 columns)
- `dbo.ReportCollectionPercentage` (17 columns)
- `dbo.ReportCollectionPercentageChild` (18 columns)
- `dbo.ReportFormulaField` (5 columns)
- `dbo.Scrub` (11 columns)
- `dbo.ScrubAssignment` (8 columns)
- `dbo.ScrubCoding` (8 columns)
- `dbo.ScrubConfig` (4 columns)
- `dbo.ScrubError` (10 columns)
- `dbo.sysdiagrams` (5 columns)
- `dbo.temp_adjustmentCodes` (2 columns)
- `dbo.temp_patient` (27 columns)
- `dbo.Temp_Policy` (7 columns)
- `dbo.tmpPatient` (111 columns)
- `dbo.Voucher` (23 columns)
- `dbo.WriteOffTHCode` (4 columns)
- `dbo.XXXFeeCharge` (14 columns)
- `dbo.XXXFEELocalityCarrierNumber` (3 columns)
- `dbo.XXXXPM_RELATIONSHIPS` (5 columns)
- `dbo.ZipCodeLookup` (7 columns)
