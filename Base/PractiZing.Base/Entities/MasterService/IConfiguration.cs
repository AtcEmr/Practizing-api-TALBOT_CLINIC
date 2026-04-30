using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.Master
{
    public interface IConfiguration : IActive
    {
         string ExportDirectory { get; set; }
         bool? ExportBilling { get; set; }
         int? PatientHXVersion { get; set; }
         int? MaxPatientHXVersion { get; set; }
         int? MaxPt { get; set; }
         int ReminderAdjustAmt { get; set; }
         int ReminderAdjustMax { get; set; }
         bool? BillingIDMatch { get; set; }
         bool? PMSInterface { get; set; }
         int PendingListDelay { get; set; }
         int MaxPendingListDelay { get; set; }
         int? DefaultProviderID { get; set; }
         string TestLabDirectory { get; set; }
         bool? HistoryOfDrugAbuseAlert { get; set; }
         string ExtendLength { get; set; }
         int? FollowupLeadTime { get; set; }
         bool? SocketConnect { get; set; }
         string SocketIP { get; set; }
         int? SocketPort { get; set; }
         char PrescriptionType { get; set; }
         string ServerPath { get; set; }
         bool? MultiplePatientCharts { get; set; }
         bool? AutoReviewDICOM { get; set; }
         bool WindowsLogon { get; set; }
         string ICSResolution { get; set; }
         int? ICSColor { get; set; }
         char? CPTModifierSeparator { get; set; }
         int? CPSPProvider { get; set; }
         bool? HL7SendLocation { get; set; }
         string LabInfoForm { get; set; }
         bool PrintBarcode { get; set; }
         string PrescriptionComment { get; set; }
         char? AlwaysSetGender { get; set; }
         bool? ShowInsuranceVerification { get; set; }
         bool? ShowPenicillinAllergic { get; set; }
         bool? ShowBillingUserID { get; set; }
         bool? ShowFooterSpaceForLabels { get; set; }
         bool? ShowLabCorpHeader { get; set; }
         bool? ShowGenericSignatureSection { get; set; }
         bool? ShowLabCorpSignatureSection { get; set; }
         string HL7SendingApp { get; set; }
         string HL7ReceivingApp { get; set; }
         string HL7MSHversion { get; set; }
         string HL7FileExtension { get; set; }
         bool? HL7IncludeUB2 { get; set; }
         bool? HL7IncludeInsurance { get; set; }
         char? HL7DXSeparator { get; set; }
         bool? HL7IncludePV1 { get; set; }
         bool TransferOfCare { get; set; }
         string PMSGroupNumber { get; set; }
         string HL7InterfaceName { get; set; }
         bool PatientTrackingProviderALT { get; set; }//////////TransferOfCareImage image    
         bool? D1FaxEnable { get; set; }
         string D1FaxHost { get; set; }
         int? D1FaxPort { get; set; }
         bool HL7_ApptFac_UseAlt { get; set; }
         bool SpecialConsultDefaults { get; set; }
         string Import { get; set; }
         string CCRExport { get; set; }
         string PQRIExport { get; set; }
         bool? InsLvl22 { get; set; }
         int? DefaultLabCompany { get; set; }
         string DollarSignLabel { get; set; }
         int MeaningfulUseThresholdStage { get; set; }
         bool? CombineTests { get; set; }
         string TelevoxExportPath { get; set; }
         bool OrderLabsResponsibleProvider { get; set; }
         bool PTShowNextStageColumn { get; set; }
         string TimeZone { get; set; }
         string ServerSocketIPPort { get; set; }
         string BulkPath { get; set; }
         string AC_OID_Client { get; set; }
         string LegalAuthenticator { get; set; }
         int MaxPatientID { get; set; }
         bool? NursingHomeAlert { get; set; }
         bool SendRXtoHXMed { get; set; }
         string TempBillingID { get; set; }
         bool CombinedAssessmentPlans { get; set; }
         bool PrescriptionPrintSuffix { get; set; }
         string PatientEducationDirectory { get; set; }
         string DatabaseName { get; set; }
         string ClinicCode { get; set; }
         bool? IsBillingOnlySystem { get; set; }
         bool? IsLabCompany { get; set; }
         string IN1UniqueID { get; set; }
         string ClinicName { get; set; }
         int? ClaimType { get; set; }
         bool? IsPaymentCentral { get; set; }
         bool? IsChargeCentral { get; set; }
         int? DefaultLocationID { get; set; }
         bool? AutoUpdateCheck { get; set; }
         string PIUpdateDownloadUrl { get; set; }
         string PIAPIFolderPath { get; set; }
         int? LabCompanyAndBillingOnlySystem { get; set; }
         string ClaimBillingType { get; set; }
         string HL7ServiceFolderPath { get; set; }
         string ERAProcessServiceFolderPath { get; set; }
         string ERAFileImportFolderPath { get; set; }
         string InstamedPaymentServiceFolderPath { get; set; }
         string PaymentCentralServiceFolderPath { get; set; }
         string ChargeCentralServiceFolderPath { get; set; }
         bool? IsPatientPortal { get; set; }
         bool? IsInstamed { get; set; }
         DateTime? GCodeLogicStartDate { get; set; }
         bool? IsFeeChargeAdjusmentApplicable { get; set; }
         bool? IsBillingLabOnly { get; set; }
         bool? IsCustomHL7ServiceActive { get; set; }
    }
}
