using PractiZing.Base.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Models
{
    public class Configuration : IConfiguration
    {
        public string ExportDirectory { get; set; }
        public bool? ExportBilling { get; set; }
        public int? PatientHXVersion { get; set; }
        public int? MaxPatientHXVersion { get; set; }
        public int? MaxPt { get; set; }
        public int ReminderAdjustAmt { get; set; }
        public int ReminderAdjustMax { get; set; }
        public bool? BillingIDMatch { get; set; }
        public bool? PMSInterface { get; set; }
        public int PendingListDelay { get; set; }
        public int MaxPendingListDelay { get; set; }
        public int? DefaultProviderID { get; set; }
        public string TestLabDirectory { get; set; }
        public bool? HistoryOfDrugAbuseAlert { get; set; }
        public string ExtendLength { get; set; }
        public int? FollowupLeadTime { get; set; }
        public bool? SocketConnect { get; set; }
        public string SocketIP { get; set; }
        public int? SocketPort { get; set; }
        public char PrescriptionType { get; set; }
        public string ServerPath { get; set; }
        public bool? MultiplePatientCharts { get; set; }
        public bool? AutoReviewDICOM { get; set; }
        public bool WindowsLogon { get; set; }
        public string ICSResolution { get; set; }
        public int? ICSColor { get; set; }
        public char? CPTModifierSeparator { get; set; }
        public int? CPSPProvider { get; set; }
        public bool? HL7SendLocation { get; set; }
        public string LabInfoForm { get; set; }
        public bool PrintBarcode { get; set; }
        public string PrescriptionComment { get; set; }
        public char? AlwaysSetGender { get; set; }
        public bool? ShowInsuranceVerification { get; set; }
        public bool? ShowPenicillinAllergic { get; set; }
        public bool? ShowBillingUserID { get; set; }
        public bool? ShowFooterSpaceForLabels { get; set; }
        public bool? ShowLabCorpHeader { get; set; }
        public bool? ShowGenericSignatureSection { get; set; }
        public bool? ShowLabCorpSignatureSection { get; set; }
        public string HL7SendingApp { get; set; }
        public string HL7ReceivingApp { get; set; }
        public string HL7MSHversion { get; set; }
        public string HL7FileExtension { get; set; }
        public bool? HL7IncludeUB2 { get; set; }
        public bool? HL7IncludeInsurance { get; set; }
        public char? HL7DXSeparator { get; set; }
        public bool? HL7IncludePV1 { get; set; }
        public bool TransferOfCare { get; set; }
        public string PMSGroupNumber { get; set; }
        public string HL7InterfaceName { get; set; }
        public bool PatientTrackingProviderALT { get; set; }//////////
        public byte?[] TransferOfCareImage { get; set; }
        public bool? D1FaxEnable { get; set; }
        public string D1FaxHost { get; set; }
        public int? D1FaxPort { get; set; }
        public bool HL7_ApptFac_UseAlt { get; set; }
        public bool SpecialConsultDefaults { get; set; }
        public string Import { get; set; }
        public string CCRExport { get; set; }
        public string PQRIExport { get; set; }
        public bool? InsLvl22 { get; set; }
        public int? DefaultLabCompany { get; set; }
        public string DollarSignLabel { get; set; }
        public int MeaningfulUseThresholdStage { get; set; }
        public bool? CombineTests { get; set; }
        public string TelevoxExportPath { get; set; }
        public bool OrderLabsResponsibleProvider { get; set; }
        public bool PTShowNextStageColumn { get; set; }
        public string TimeZone { get; set; }
        public string ServerSocketIPPort { get; set; }
        public string BulkPath { get; set; }
        public string AC_OID_Client { get; set; }
        public string LegalAuthenticator { get; set; }
        public int MaxPatientID { get; set; }
        public bool? NursingHomeAlert { get; set; }
        public bool SendRXtoHXMed { get; set; }
        public string TempBillingID { get; set; }
        public bool CombinedAssessmentPlans { get; set; }
        public bool PrescriptionPrintSuffix { get; set; }
        public string PatientEducationDirectory { get; set; }
        public string DatabaseName { get; set; }
        public string ClinicCode { get; set; }
        public bool? IsBillingOnlySystem { get; set; }
        public bool? IsLabCompany { get; set; }
        public string IN1UniqueID { get; set; }
        public string ClinicName { get; set; }
        public int? ClaimType { get; set; }
        public bool? IsPaymentCentral { get; set; }
        public bool? IsChargeCentral { get; set; }
        public int? DefaultLocationID { get; set; }
        public bool? AutoUpdateCheck { get; set; }
        public string PIUpdateDownloadUrl { get; set; }
        public string PIAPIFolderPath { get; set; }
        public int? LabCompanyAndBillingOnlySystem { get; set; }
        public string ClaimBillingType { get; set; }
        public string HL7ServiceFolderPath { get; set; }
        public string ERAProcessServiceFolderPath { get; set; }
        public string ERAFileImportFolderPath { get; set; }
        public string InstamedPaymentServiceFolderPath { get; set; }
        public string PaymentCentralServiceFolderPath { get; set; }
        public string ChargeCentralServiceFolderPath { get; set; }
        public bool? IsPatientPortal { get; set; }
        public bool? IsInstamed { get; set; }
        public DateTime? GCodeLogicStartDate { get; set; }
        public bool? IsFeeChargeAdjusmentApplicable { get; set; }
        public bool? IsBillingLabOnly { get; set; }
        public bool? IsCustomHL7ServiceActive { get; set; }

       public bool IsActive { get; set; }
    }
}
