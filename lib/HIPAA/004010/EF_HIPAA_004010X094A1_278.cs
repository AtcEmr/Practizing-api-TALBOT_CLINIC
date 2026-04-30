namespace EdiFabric.Rules.HIPAA_004010X094A1_278
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X094A1", "278")]
    public class TS278 : EdiMessage
    {
        
        [Pos(1)]
        public ST ST { get; set; }
        [Pos(2)]
        public Loop_BHT_A1 Loop_BHT_A1 { get; set; }
        [Pos(3)]
        public Loop_BHT_A3 Loop_BHT_A3 { get; set; }
        [Pos(4)]
        public SE SE { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(BHT_BeginningOfHierarchicalTransaction))]
    public class Loop_BHT_A3
    {
        
        [Pos(1)]
        public BHT_BeginningOfHierarchicalTransaction BHT_BeginningOfHierarchicalTransaction { get; set; }
        [Pos(2)]
        public Loop_2000A Loop_2000A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0078,")]
    public class X12_ID_1005_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [EdiCodes(",11,")]
    public class X12_ID_353_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_UtilizationManagementOrganizationUMOLevel_2000A))]
    public class Loop_2000A
    {
        
        [Required]
        [Pos(1)]
        public HL_UtilizationManagementOrganizationUMOLevel_2000A HL_UtilizationManagementOrganizationUMOLevel_2000A { get; set; }
        [ListCount(9)]
        [Pos(2)]
        public List<AAA_RequestValidation_2000A> AAA_RequestValidation_2000A { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2010A Loop_2010A { get; set; }
        [Required]
        [Pos(4)]
        public Loop_2000B Loop_2000B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",20,")]
    public class X12_ID_735_HL_UtilizationManagementOrganizationUMOLevel_2000A
    {
    }
    
    [Serializable()]
    public class X12_AN
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_RequestValidation_2000A
    {
    }
    
    [Serializable()]
    public class X12_ID
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_RequesterLevel_2000B))]
    public class Loop_2000B
    {
        
        [Required]
        [Pos(1)]
        public HL_RequesterLevel_2000B HL_RequesterLevel_2000B { get; set; }
        [Required]
        [Pos(2)]
        public Loop_2010B Loop_2010B { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2000C Loop_2000C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",21,")]
    public class X12_ID_735_HL_RequesterLevel_2000B
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_SubscriberLevel_2000C))]
    public class Loop_2000C
    {
        
        [Required]
        [Pos(1)]
        public HL_SubscriberLevel_2000C HL_SubscriberLevel_2000C { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<TRN_PatientEventTrackingNumber_2000C> TRN_PatientEventTrackingNumber_2000C { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<AAA_SubscriberRequestValidation_2000C> AAA_SubscriberRequestValidation_2000C { get; set; }
        [Pos(4)]
        public All_DTP_2000C All_DTP_2000C { get; set; }
        [Pos(5)]
        public HI_SubscriberDiagnosis_2000C HI_SubscriberDiagnosis_2000C { get; set; }
        [ListCount(10)]
        [Pos(6)]
        public List<PWK_AdditionalPatientInformation_2000C> PWK_AdditionalPatientInformation_2000C { get; set; }
        [Required]
        [Pos(7)]
        public All_2010C All_2010C { get; set; }
        [Pos(8)]
        public Loop_2000D Loop_2000D { get; set; }
        [Pos(9)]
        public List<Loop_2000E> Loop_2000E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",22,")]
    public class X12_ID_735_HL_SubscriberLevel_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_481_TRN_PatientEventTrackingNumber_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_SubscriberRequestValidation_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,BJ,BK,LOI,")]
    public class X12_ID_1270_C022_1220716762
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,BJ,LOI,")]
    public class X12_ID_1270_C022_1576947122
    {
    }
    
    [Serializable()]
    [EdiCodes(",03,04,05,06,07,08,09,10,11,13,15,21,48,55,59,77,A3,A4,AM,AS,AT,B2,B3,BR,BS,BT,CB" +
        ",CK,D2,DA,DB,DG,DJ,DS,FM,HC,HR,I5,IR,LA,M1,NN,OB,OC,OD,OE,OX,P4,P5,P6,P7,PE,PN,P" +
        "O,PQ,PY,PZ,QC,QR,RB,RR,RT,RX,SG,V5,XP,")]
    public class X12_ID_755_PWK_AdditionalPatientInformation_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",BM,EL,EM,FX,VO,")]
    public class X12_ID_756_PWK_AdditionalPatientInformation_2000C
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_ServiceProviderLevel_2000E))]
    public class Loop_2000E
    {
        
        [Required]
        [Pos(1)]
        public HL_ServiceProviderLevel_2000E HL_ServiceProviderLevel_2000E { get; set; }
        [Pos(2)]
        public MSG_MessageText_2000E MSG_MessageText_2000E { get; set; }
        [Required]
        [ListCount(3)]
        [Pos(3)]
        public List<Loop_2010E> Loop_2010E { get; set; }
        [Required]
        [Pos(4)]
        public List<Loop_2000F> Loop_2000F { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",19,")]
    public class X12_ID_735_HL_ServiceProviderLevel_2000E
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_ServiceLevel_2000F))]
    public class Loop_2000F
    {
        
        [Required]
        [Pos(1)]
        public HL_ServiceLevel_2000F HL_ServiceLevel_2000F { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<TRN_ServiceTraceNumber_2000F> TRN_ServiceTraceNumber_2000F { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<AAA_ServiceRequestValidation_2000F> AAA_ServiceRequestValidation_2000F { get; set; }
        [Required]
        [Pos(4)]
        public UM_HealthCareServicesReviewInformation_2000F UM_HealthCareServicesReviewInformation_2000F { get; set; }
        [Pos(5)]
        public HCR_HealthCareServicesReview_2000F HCR_HealthCareServicesReview_2000F { get; set; }
        [Pos(6)]
        public REF_PreviousCertificationIdentification_2000F REF_PreviousCertificationIdentification_2000F { get; set; }
        [Pos(7)]
        public All_DTP_2000F All_DTP_2000F { get; set; }
        [Pos(8)]
        public HI_Procedures_2000F HI_Procedures_2000F { get; set; }
        [Pos(9)]
        public HSD_HealthCareServicesDelivery_2000F HSD_HealthCareServicesDelivery_2000F { get; set; }
        [Pos(10)]
        public CL1_InstitutionalClaimCode_2000F CL1_InstitutionalClaimCode_2000F { get; set; }
        [Pos(11)]
        public CR1_AmbulanceTransportInformation_2000F CR1_AmbulanceTransportInformation_2000F { get; set; }
        [Pos(12)]
        public CR2_SpinalManipulationServiceInformation_2000F CR2_SpinalManipulationServiceInformation_2000F { get; set; }
        [Pos(13)]
        public CR5_HomeOxygenTherapyInformation_2000F CR5_HomeOxygenTherapyInformation_2000F { get; set; }
        [Pos(14)]
        public CR6_HomeHealthCareInformation_2000F CR6_HomeHealthCareInformation_2000F { get; set; }
        [ListCount(10)]
        [Pos(15)]
        public List<PWK_AdditionalServiceInformation_2000F> PWK_AdditionalServiceInformation_2000F { get; set; }
        [Pos(16)]
        public MSG_MessageText_2000F MSG_MessageText_2000F { get; set; }
        [Pos(17)]
        public Loop_2010F Loop_2010F { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",SS,")]
    public class X12_ID_735_HL_ServiceLevel_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_481_TRN_ServiceTraceNumber_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_ServiceRequestValidation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",AR,HS,SC,")]
    public class X12_ID_1525_UM_HealthCareServicesReviewInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,I,R,S,")]
    public class X12_ID_1322_UM_HealthCareServicesReviewInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",A1,A3,A4,A6,CT,NA,")]
    public class X12_ID_306_HCR_HealthCareServicesReview_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",BB,")]
    public class X12_ID_128_REF_PreviousCertificationIdentification_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_57917350
    {
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_1220782300
    {
    }
    
    [Serializable()]
    [EdiCodes(",DY,FL,HS,MN,VS,")]
    public class X12_ID_673_HSD_HealthCareServicesDelivery_2000F
    {
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    public class X12_N0
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,")]
    public class X12_ID_923_CR6_HomeHealthCareInformation_2000F
    {
    }
    
    [Serializable()]
    public class X12_DT
    {
    }
    
    [Serializable()]
    [EdiCodes(",03,04,05,06,07,08,09,10,11,13,15,21,48,55,59,77,A3,A4,AM,AS,AT,B2,B3,BR,BS,BT,CB" +
        ",CK,D2,DA,DB,DG,DJ,DS,FM,HC,HR,I5,IR,LA,M1,NN,OB,OC,OD,OE,OX,P4,P5,P6,P7,PE,PN,P" +
        "O,PQ,PY,PZ,QC,QR,RB,RR,RT,RX,SG,V5,XP,")]
    public class X12_ID_755_PWK_AdditionalServiceInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",BM,EL,EM,FX,VO,")]
    public class X12_ID_756_PWK_AdditionalServiceInformation_2000F
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_AdditionalServiceInformationContactName_2010F))]
    public class Loop_2010F
    {
        
        [Required]
        [Pos(1)]
        public NM1_AdditionalServiceInformationContactName_2010F NM1_AdditionalServiceInformationContactName_2010F { get; set; }
        [Pos(2)]
        public N3_AdditionalServiceInformationContactAddress_2010F N3_AdditionalServiceInformationContactAddress_2010F { get; set; }
        [Pos(3)]
        public N4_AdditionalServiceInformationContactCityStateZipCode_2010F N4_AdditionalServiceInformationContactCityStateZipCode_2010F { get; set; }
        [Pos(4)]
        public PER_AdditionalServiceInformationContactInformation_2010F PER_AdditionalServiceInformationContactInformation_2010F { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1P,2B,ABG,FA,PR,X3,")]
    public class X12_ID_98_NM1_AdditionalServiceInformationContactName_2010F
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_AdditionalServiceInformationContactName_2010F
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_AdditionalServiceInformationContactInformation_2010F
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_AdditionalServiceInformationContactInformation_2010F))]
    public class PER_AdditionalServiceInformationContactInformation_2010F
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_AdditionalServiceInformationContactInformation_2010F))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ResponseContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalServiceInformationContactInformation_2010F))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ResponseContactCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalServiceInformationContactInformation_2010F))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ResponseContactCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalServiceInformationContactInformation_2010F))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string ResponseContactCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EM,FX,TE,")]
    public class X12_ID_365_PER_AdditionalServiceInformationContactInformation_2010F
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_AdditionalServiceInformationContactCityStateZipCode_2010F
    {
        
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ResponseContactCityName_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string ResponseContactStateOrProvinceCode_02 { get; set; }
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ResponseContactPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string ResponseContactCountryCode_04 { get; set; }
        [DataElement("309", typeof(X12_ID_309_N4_AdditionalServiceInformationContactCityStateZipCode_2010F))]
        [Pos(5)]
        public string LocationQualifier_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ResponseContactSpecificLocation_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",B1,DP,")]
    public class X12_ID_309_N4_AdditionalServiceInformationContactCityStateZipCode_2010F
    {
    }
    
    [Serializable()]
    [Segment("N3")]
    public class N3_AdditionalServiceInformationContactAddress_2010F
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ResponseContactAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ResponseContactAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_AdditionalServiceInformationContactName_2010F), typeof(X12_ID_1065_NM1_AdditionalServiceInformationContactName_2010F))]
    public class NM1_AdditionalServiceInformationContactName_2010F
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_AdditionalServiceInformationContactName_2010F))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_AdditionalServiceInformationContactName_2010F))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ResponseContactLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ResponseContactFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ResponseContactMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ResponseContactNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_AdditionalServiceInformationContactName_2010F))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ResponseContactIdentifier_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string NM1_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",24,34,46,PI,XV,XX,")]
    public class X12_ID_66_NM1_AdditionalServiceInformationContactName_2010F
    {
    }
    
    [Serializable()]
    [Segment("MSG")]
    public class MSG_MessageText_2000F
    {
        
        [Required]
        [StringLength(1, 264)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string FreeFormMessageText_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string MSG_02 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(3)]
        public string MSG_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("PWK", typeof(X12_ID_755_PWK_AdditionalServiceInformation_2000F), typeof(X12_ID_756_PWK_AdditionalServiceInformation_2000F))]
    public class PWK_AdditionalServiceInformation_2000F
    {
        
        [Required]
        [DataElement("755", typeof(X12_ID_755_PWK_AdditionalServiceInformation_2000F))]
        [Pos(1)]
        public string AttachmentReportTypeCode_01 { get; set; }
        [Required]
        [DataElement("756", typeof(X12_ID_756_PWK_AdditionalServiceInformation_2000F))]
        [Pos(2)]
        public string AttachmentTransmissionCode_02 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(3)]
        public string PWK_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string PWK_04 { get; set; }
        [DataElement("66", typeof(X12_ID_66_PWK_AdditionalServiceInformation_2000F))]
        [Pos(5)]
        public string IdentificationCodeQualifier_05 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string AttachmentControlNumber_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string AttachmentDescription_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string PWK_08 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string PWK_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AC,")]
    public class X12_ID_66_PWK_AdditionalServiceInformation_2000F
    {
    }
    
    [Serializable()]
    [Segment("CR6", typeof(X12_ID_923_CR6_HomeHealthCareInformation_2000F))]
    public class CR6_HomeHealthCareInformation_2000F
    {
        
        [Required]
        [DataElement("923", typeof(X12_ID_923_CR6_HomeHealthCareInformation_2000F))]
        [Pos(1)]
        public string PrognosisCode_01 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string ServiceFromDate_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_CR6_HomeHealthCareInformation_2000F))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HomeHealthCertificationPeriod_04 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(5)]
        public string CR6_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string CR6_06 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CR6_HomeHealthCareInformation_2000F))]
        [Pos(7)]
        public string MedicareCoverageIndicator_07 { get; set; }
        [Required]
        [DataElement("1322", typeof(X12_ID_1322_CR6_HomeHealthCareInformation_2000F))]
        [Pos(8)]
        public string CertificationTypeCode_08 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(9)]
        public string CR6_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string CR6_10 { get; set; }
        [StringLength(1, 15)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string CR6_11 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(12)]
        public string CR6_12 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(13)]
        public string CR6_13 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(14)]
        public string CR6_14 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(15)]
        public string CR6_15 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(16)]
        public string CR6_16 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(17)]
        public string CR6_17 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(18)]
        public string CR6_18 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(19)]
        public string CR6_19 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(20)]
        public string CR6_20 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(21)]
        public string CR6_21 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_CR6_HomeHealthCareInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,U,Y,")]
    public class X12_ID_1073_CR6_HomeHealthCareInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,I,R,S,")]
    public class X12_ID_1322_CR6_HomeHealthCareInformation_2000F
    {
    }
    
    [Serializable()]
    [Segment("CR5")]
    public class CR5_HomeOxygenTherapyInformation_2000F
    {
        
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(1)]
        public string CR5_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string CR5_02 { get; set; }
        [DataElement("1348", typeof(X12_ID_1348_CR5_HomeOxygenTherapyInformation_2000F))]
        [Pos(3)]
        public string OxygenEquipmentTypeCode_03 { get; set; }
        [DataElement("1348", typeof(X12_ID_1348_CR5_HomeOxygenTherapyInformation_2000F))]
        [Pos(4)]
        public string OxygenEquipmentTypeCode_04 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string EquipmentReasonDescription_05 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string OxygenFlowRate_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string DailyOxygenUseCount_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string OxygenUsePeriodHourCount_08 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string RespiratoryTherapistOrderText_09 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string CR5_10 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(11)]
        public string CR5_11 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(12)]
        public string CR5_12 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(13)]
        public string CR5_13 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(14)]
        public string CR5_14 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(15)]
        public string CR5_15 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(16)]
        public string PortableOxygenSystemFlowRate_16 { get; set; }
        [Required]
        [DataElement("1382", typeof(X12_ID_1382_CR5_HomeOxygenTherapyInformation_2000F))]
        [Pos(17)]
        public string OxygenDeliverySystemCode_17 { get; set; }
        [DataElement("1348", typeof(X12_ID_1348_CR5_HomeOxygenTherapyInformation_2000F))]
        [Pos(18)]
        public string OxygenEquipmentTypeCode_18 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",A,B,C,D,E,O,")]
    public class X12_ID_1348_CR5_HomeOxygenTherapyInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,B,C,D,E,")]
    public class X12_ID_1382_CR5_HomeOxygenTherapyInformation_2000F
    {
    }
    
    [Serializable()]
    [Segment("CR2")]
    public class CR2_SpinalManipulationServiceInformation_2000F
    {
        
        [DataElement("", typeof(X12_N0))]
        [Pos(1)]
        public string TreatmentSeriesNumber_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string TreatmentCount_02 { get; set; }
        [DataElement("1367", typeof(X12_ID_1367_CR2_SpinalManipulationServiceInformation_2000F))]
        [Pos(3)]
        public string SubluxationLevelCode_03 { get; set; }
        [DataElement("1367", typeof(X12_ID_1367_CR2_SpinalManipulationServiceInformation_2000F))]
        [Pos(4)]
        public string SubluxationLevelCode_04 { get; set; }
        [DataElement("355", typeof(X12_ID_355_CR2_SpinalManipulationServiceInformation_2000F))]
        [Pos(5)]
        public string UnitOrBasisForMeasurementCode_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string TreatmentPeriodCount_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string MonthlyTreatmentCount_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string CR2_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string CR2_09 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string CR2_10 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string CR2_11 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(12)]
        public string CR2_12 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",C1,C2,C3,C4,C5,C6,C7,CO,IL,L1,L2,L3,L4,L5,OC,SA,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T" +
        "11,T12,")]
    public class X12_ID_1367_CR2_SpinalManipulationServiceInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",DA,MO,WK,YR,")]
    public class X12_ID_355_CR2_SpinalManipulationServiceInformation_2000F
    {
    }
    
    [Serializable()]
    [Segment("CR1")]
    public class CR1_AmbulanceTransportInformation_2000F
    {
        
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(1)]
        public string CR1_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string CR1_02 { get; set; }
        [Required]
        [DataElement("1316", typeof(X12_ID_1316_CR1_AmbulanceTransportInformation_2000F))]
        [Pos(3)]
        public string AmbulanceTransportCode_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CR1_04 { get; set; }
        [DataElement("355", typeof(X12_ID_355_CR1_AmbulanceTransportInformation_2000F))]
        [Pos(5)]
        public string UnitOrBasisForMeasurementCode_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string TransportDistance_06 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string AmbulanceTripOriginAddress_07 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string AmbulanceTripDestinationAddress_08 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string CR1_09 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string CR1_10 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",I,R,T,X,")]
    public class X12_ID_1316_CR1_AmbulanceTransportInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",DH,DK,")]
    public class X12_ID_355_CR1_AmbulanceTransportInformation_2000F
    {
    }
    
    [Serializable()]
    [Segment("CL1")]
    public class CL1_InstitutionalClaimCode_2000F
    {
        
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(1)]
        public string AdmissionTypeCode_01 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AdmissionSourceCode_02 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string PatientStatusCode_03 { get; set; }
        [DataElement("1345", typeof(X12_ID_1345_CL1_InstitutionalClaimCode_2000F))]
        [Pos(4)]
        public string NursingHomeResidentialStatusCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,9,")]
    public class X12_ID_1345_CL1_InstitutionalClaimCode_2000F
    {
    }
    
    [Serializable()]
    [Segment("HSD", typeof(X12_ID_673_HSD_HealthCareServicesDelivery_2000F))]
    public class HSD_HealthCareServicesDelivery_2000F
    {
        
        [DataElement("673", typeof(X12_ID_673_HSD_HealthCareServicesDelivery_2000F))]
        [Pos(1)]
        public string QuantityQualifier_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ServiceUnitCount_02 { get; set; }
        [DataElement("355", typeof(X12_ID_355_HSD_HealthCareServicesDelivery_2000F))]
        [Pos(3)]
        public string UnitOrBasisForMeasurementCode_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string SampleSelectionModulus_04 { get; set; }
        [DataElement("615", typeof(X12_ID_615_HSD_HealthCareServicesDelivery_2000F))]
        [Pos(5)]
        public string TimePeriodQualifier_05 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(6)]
        public string PeriodCount_06 { get; set; }
        [DataElement("678", typeof(X12_ID_678_HSD_HealthCareServicesDelivery_2000F))]
        [Pos(7)]
        public string ShipDeliveryOrCalendarPatternCode_07 { get; set; }
        [DataElement("679", typeof(X12_ID_679_HSD_HealthCareServicesDelivery_2000F))]
        [Pos(8)]
        public string DeliveryPatternTimeCode_08 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DA,MO,WK,")]
    public class X12_ID_355_HSD_HealthCareServicesDelivery_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",6,7,21,26,27,34,35,")]
    public class X12_ID_615_HSD_HealthCareServicesDelivery_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,SA,SB,SC,SD,SG" +
        ",SL,SP,SX,SY,SZ,")]
    public class X12_ID_678_HSD_HealthCareServicesDelivery_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,B,C,D,E,F,G,Y,")]
    public class X12_ID_679_HSD_HealthCareServicesDelivery_2000F
    {
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_57917350), typeof(X12_ID_1270_C022_1220782300))]
    public class HI_Procedures_2000F
    {
        
        [Required]
        [Pos(1)]
        public C022_57917350 C022_57917350 { get; set; }
        [Pos(2)]
        public C022_1220782300 C022_1220782300 { get; set; }
        [Pos(3)]
        public C022_1577012660 C022_1577012660 { get; set; }
        [Pos(4)]
        public C022_2026368314 C022_2026368314 { get; set; }
        [Pos(5)]
        public C022_1105734032 C022_1105734032 { get; set; }
        [Pos(6)]
        public C022_57524135 C022_57524135 { get; set; }
        [Pos(7)]
        public C022_1220389085 C022_1220389085 { get; set; }
        [Pos(8)]
        public C022_1576619445 C022_1576619445 { get; set; }
        [Pos(9)]
        public C022_2027023675 C022_2027023675 { get; set; }
        [Pos(10)]
        public C022_1105078671 C022_1105078671 { get; set; }
        [Pos(11)]
        public C022_57786279 C022_57786279 { get; set; }
        [Pos(12)]
        public C022_1220651229 C022_1220651229 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_1220651229")]
    public class C022_1220651229
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1220651229))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1220651229))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_1220651229
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_1220651229
    {
    }
    
    [Serializable()]
    [Composite("C022_57786279")]
    public class C022_57786279
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_57786279))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_57786279))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_57786279
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_57786279
    {
    }
    
    [Serializable()]
    [Composite("C022_1105078671")]
    public class C022_1105078671
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1105078671))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1105078671))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_1105078671
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_1105078671
    {
    }
    
    [Serializable()]
    [Composite("C022_2027023675")]
    public class C022_2027023675
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_2027023675))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_2027023675))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_2027023675
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_2027023675
    {
    }
    
    [Serializable()]
    [Composite("C022_1576619445")]
    public class C022_1576619445
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1576619445))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1576619445))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_1576619445
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_1576619445
    {
    }
    
    [Serializable()]
    [Composite("C022_1220389085")]
    public class C022_1220389085
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1220389085))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1220389085))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_1220389085
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_1220389085
    {
    }
    
    [Serializable()]
    [Composite("C022_57524135")]
    public class C022_57524135
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_57524135))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_57524135))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_57524135
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_57524135
    {
    }
    
    [Serializable()]
    [Composite("C022_1105734032")]
    public class C022_1105734032
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1105734032))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1105734032))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_1105734032
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_1105734032
    {
    }
    
    [Serializable()]
    [Composite("C022_2026368314")]
    public class C022_2026368314
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_2026368314))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_2026368314))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_2026368314
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_2026368314
    {
    }
    
    [Serializable()]
    [Composite("C022_1577012660")]
    public class C022_1577012660
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1577012660))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1577012660))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ABR,BO,BQ,JP,LOI,NDC,ZZ,")]
    public class X12_ID_1270_C022_1577012660
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_1577012660
    {
    }
    
    [Serializable()]
    [Composite("C022_1220782300")]
    public class C022_1220782300
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1220782300))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1220782300))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_1220782300
    {
    }
    
    [Serializable()]
    [Composite("C022_57917350")]
    public class C022_57917350
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_57917350))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_57917350))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ProcedureMonetaryAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureQuantity_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string VersionReleaseOrIndustryIdentifier_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_C022_57917350
    {
    }
    
    [Serializable()]
    [All()]
    public class All_DTP_2000F
    {
        
        [Pos(1)]
        public DTP_ServiceDate_2000F DTP_ServiceDate_2000F { get; set; }
        [Pos(2)]
        public DTP_AdmissionDate_2000F DTP_AdmissionDate_2000F { get; set; }
        [Pos(3)]
        public DTP_DischargeDate_2000F DTP_DischargeDate_2000F { get; set; }
        [Pos(4)]
        public DTP_SurgeryDate_2000F DTP_SurgeryDate_2000F { get; set; }
        [Pos(5)]
        public DTP_CertificationIssueDate_2000F DTP_CertificationIssueDate_2000F { get; set; }
        [Pos(6)]
        public DTP_CertificationExpirationDate_2000F DTP_CertificationExpirationDate_2000F { get; set; }
        [Pos(7)]
        public DTP_CertificationEffectiveDate_2000F DTP_CertificationEffectiveDate_2000F { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",472,")]
    public class X12_ID_374_DTP_ServiceDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_ServiceDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",435,")]
    public class X12_ID_374_DTP_AdmissionDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_AdmissionDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",096,")]
    public class X12_ID_374_DTP_DischargeDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DischargeDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",456,")]
    public class X12_ID_374_DTP_SurgeryDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_SurgeryDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",102,")]
    public class X12_ID_374_DTP_CertificationIssueDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_CertificationIssueDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",036,")]
    public class X12_ID_374_DTP_CertificationExpirationDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_CertificationExpirationDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",007,")]
    public class X12_ID_374_DTP_CertificationEffectiveDate_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_CertificationEffectiveDate_2000F
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_CertificationEffectiveDate_2000F), typeof(X12_ID_1250_DTP_CertificationEffectiveDate_2000F))]
    public class DTP_CertificationEffectiveDate_2000F
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_CertificationEffectiveDate_2000F))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_CertificationEffectiveDate_2000F))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CertificationEffectiveDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_CertificationExpirationDate_2000F), typeof(X12_ID_1250_DTP_CertificationExpirationDate_2000F))]
    public class DTP_CertificationExpirationDate_2000F
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_CertificationExpirationDate_2000F))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_CertificationExpirationDate_2000F))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CertificationExpirationDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_CertificationIssueDate_2000F), typeof(X12_ID_1250_DTP_CertificationIssueDate_2000F))]
    public class DTP_CertificationIssueDate_2000F
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_CertificationIssueDate_2000F))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_CertificationIssueDate_2000F))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CertificationIssueDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_SurgeryDate_2000F), typeof(X12_ID_1250_DTP_SurgeryDate_2000F))]
    public class DTP_SurgeryDate_2000F
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_SurgeryDate_2000F))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_SurgeryDate_2000F))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProposedOrActualSurgeryDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DischargeDate_2000F), typeof(X12_ID_1250_DTP_DischargeDate_2000F))]
    public class DTP_DischargeDate_2000F
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DischargeDate_2000F))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DischargeDate_2000F))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProposedOrActualDischargeDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_AdmissionDate_2000F), typeof(X12_ID_1250_DTP_AdmissionDate_2000F))]
    public class DTP_AdmissionDate_2000F
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_AdmissionDate_2000F))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_AdmissionDate_2000F))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProposedOrActualAdmissionDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_ServiceDate_2000F), typeof(X12_ID_1250_DTP_ServiceDate_2000F))]
    public class DTP_ServiceDate_2000F
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ServiceDate_2000F))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ServiceDate_2000F))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProposedOrActualServiceDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PreviousCertificationIdentification_2000F))]
    public class REF_PreviousCertificationIdentification_2000F
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PreviousCertificationIdentification_2000F))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PreviousCertificationIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string REF_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("HCR", typeof(X12_ID_306_HCR_HealthCareServicesReview_2000F))]
    public class HCR_HealthCareServicesReview_2000F
    {
        
        [Required]
        [DataElement("306", typeof(X12_ID_306_HCR_HealthCareServicesReview_2000F))]
        [Pos(1)]
        public string ActionCode_01 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string CertificationNumber_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_HCR_HealthCareServicesReview_2000F))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_HCR_HealthCareServicesReview_2000F))]
        [Pos(4)]
        public string SecondSurgicalOpinionIndicator_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",35,36,37,41,53,69,70,82,83,84,85,86,87,88,89,90,91,92,96,98,E8,")]
    public class X12_ID_901_HCR_HealthCareServicesReview_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_HCR_HealthCareServicesReview_2000F
    {
    }
    
    [Serializable()]
    [Segment("UM", typeof(X12_ID_1525_UM_HealthCareServicesReviewInformation_2000F), typeof(X12_ID_1322_UM_HealthCareServicesReviewInformation_2000F))]
    public class UM_HealthCareServicesReviewInformation_2000F
    {
        
        [Required]
        [DataElement("1525", typeof(X12_ID_1525_UM_HealthCareServicesReviewInformation_2000F))]
        [Pos(1)]
        public string RequestCategoryCode_01 { get; set; }
        [Required]
        [DataElement("1322", typeof(X12_ID_1322_UM_HealthCareServicesReviewInformation_2000F))]
        [Pos(2)]
        public string CertificationTypeCode_02 { get; set; }
        [DataElement("1365", typeof(X12_ID_1365_UM_HealthCareServicesReviewInformation_2000F))]
        [Pos(3)]
        public string ServiceTypeCode_03 { get; set; }
        [Pos(4)]
        public C023_2027220282 C023_2027220282 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string UM_05 { get; set; }
        [DataElement("1338", typeof(X12_ID_1338_UM_HealthCareServicesReviewInformation_2000F))]
        [Pos(6)]
        public string LevelOfServiceCode_06 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string UM_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string UM_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string UM_09 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string UM_10 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",1,2,3,4,5,6,7,8,12,14,15,16,17,18,20,21,23,24,25,26,27,28,33,34,35,36,37,38,39,40,42,44,45,46,48,50,51,52,53,54,56,57,58,59,61,62,63,64,65,67,68,69,70,71,72,73,74,75,76,77,78,79,80,82,83,84,85,86,93,94,95,98,99,A0,A1,A2,A3,A4,A6,A7,A8,A9,AB,AC,AD,AE,AF,AG,AI,AJ,AK,AL,AR,BB,BC,BD,BE,BF,BG,BS,")]
    public class X12_ID_1365_UM_HealthCareServicesReviewInformation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",03,U,")]
    public class X12_ID_1338_UM_HealthCareServicesReviewInformation_2000F
    {
    }
    
    [Serializable()]
    [Composite("C023_2027220282")]
    public class C023_2027220282
    {
        
        [Required]
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string FacilityTypeCode_01 { get; set; }
        [Required]
        [DataElement("1332", typeof(X12_ID_1332_C023_2027220282))]
        [Pos(2)]
        public string FacilityCodeQualifier_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string UM_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",A,B,")]
    public class X12_ID_1332_C023_2027220282
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_ServiceRequestValidation_2000F))]
    public class AAA_ServiceRequestValidation_2000F
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_ServiceRequestValidation_2000F))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_AAA_ServiceRequestValidation_2000F))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("889", typeof(X12_ID_889_AAA_ServiceRequestValidation_2000F))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,33,52,57,60,61,62,T5,")]
    public class X12_ID_901_AAA_ServiceRequestValidation_2000F
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,")]
    public class X12_ID_889_AAA_ServiceRequestValidation_2000F
    {
    }
    
    [Serializable()]
    [Segment("TRN", typeof(X12_ID_481_TRN_ServiceTraceNumber_2000F))]
    public class TRN_ServiceTraceNumber_2000F
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_ServiceTraceNumber_2000F))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ServiceTraceNumber_02 { get; set; }
        [Required]
        [StringLength(10, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string TraceAssigningEntityIdentifier_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string TraceAssigningEntityAdditionalIdentifier_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_ServiceLevel_2000F))]
    public class HL_ServiceLevel_2000F
    {
        
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HierarchicalIDNumber_01 { get; set; }
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HierarchicalParentIDNumber_02 { get; set; }
        [Required]
        [DataElement("735", typeof(X12_ID_735_HL_ServiceLevel_2000F))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_ServiceLevel_2000F))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0,")]
    public class X12_ID_736_HL_ServiceLevel_2000F
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_ServiceProviderName_2010E))]
    public class Loop_2010E
    {
        
        [Required]
        [Pos(1)]
        public NM1_ServiceProviderName_2010E NM1_ServiceProviderName_2010E { get; set; }
        [ListCount(7)]
        [Pos(2)]
        public List<REF_ServiceProviderSupplementalIdentification_2010E> REF_ServiceProviderSupplementalIdentification_2010E { get; set; }
        [Pos(3)]
        public N3_ServiceProviderAddress_2010E N3_ServiceProviderAddress_2010E { get; set; }
        [Pos(4)]
        public N4_ServiceProviderCityStateZIPCode_2010E N4_ServiceProviderCityStateZIPCode_2010E { get; set; }
        [Pos(5)]
        public PER_ServiceProviderContactInformation_2010E PER_ServiceProviderContactInformation_2010E { get; set; }
        [ListCount(9)]
        [Pos(6)]
        public List<AAA_ServiceProviderRequestValidation_2010E> AAA_ServiceProviderRequestValidation_2010E { get; set; }
        [Pos(7)]
        public PRV_ServiceProviderInformation_2010E PRV_ServiceProviderInformation_2010E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1T,FA,SJ,")]
    public class X12_ID_98_NM1_ServiceProviderName_2010E
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_ServiceProviderName_2010E
    {
    }
    
    [Serializable()]
    [EdiCodes(",1G,1J,EI,N5,N7,SY,ZH,")]
    public class X12_ID_128_REF_ServiceProviderSupplementalIdentification_2010E
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_ServiceProviderContactInformation_2010E
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_ServiceProviderRequestValidation_2010E
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,AS,AT,CO,CV,OP,OR,OT,PC,PE,")]
    public class X12_ID_1221_PRV_ServiceProviderInformation_2010E
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_ServiceProviderInformation_2010E
    {
    }
    
    [Serializable()]
    [Segment("PRV", typeof(X12_ID_1221_PRV_ServiceProviderInformation_2010E), typeof(X12_ID_128_PRV_ServiceProviderInformation_2010E))]
    public class PRV_ServiceProviderInformation_2010E
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_ServiceProviderInformation_2010E))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_ServiceProviderInformation_2010E))]
        [Pos(2)]
        public string ReferenceIdentificationQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProviderTaxonomyCode_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string PRV_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string PRV_05 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string PRV_06 { get; set; }
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_ServiceProviderRequestValidation_2010E))]
    public class AAA_ServiceProviderRequestValidation_2010E
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_ServiceProviderRequestValidation_2010E))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_AAA_ServiceProviderRequestValidation_2010E))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("889", typeof(X12_ID_889_AAA_ServiceProviderRequestValidation_2010E))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,33,35,41,43,44,45,46,47,49,51,52,79,97,")]
    public class X12_ID_901_AAA_ServiceProviderRequestValidation_2010E
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,")]
    public class X12_ID_889_AAA_ServiceProviderRequestValidation_2010E
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_ServiceProviderContactInformation_2010E))]
    public class PER_ServiceProviderContactInformation_2010E
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_ServiceProviderContactInformation_2010E))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ServiceProviderContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ServiceProviderContactInformation_2010E))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ServiceProviderContactCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ServiceProviderContactInformation_2010E))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ServiceProviderContactCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ServiceProviderContactInformation_2010E))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string ServiceProviderContactCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EM,FX,TE,")]
    public class X12_ID_365_PER_ServiceProviderContactInformation_2010E
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_ServiceProviderCityStateZIPCode_2010E
    {
        
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ServiceProviderCityName_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string ServiceProviderStateOrProvinceCode_02 { get; set; }
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ServiceProviderPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string ServiceProviderCountryCode_04 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string N4_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string N4_06 { get; set; }
    }
    
    [Serializable()]
    [Segment("N3")]
    public class N3_ServiceProviderAddress_2010E
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ServiceProviderAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ServiceProviderAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_ServiceProviderSupplementalIdentification_2010E))]
    public class REF_ServiceProviderSupplementalIdentification_2010E
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ServiceProviderSupplementalIdentification_2010E))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ServiceProviderSupplementalIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string REF_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_ServiceProviderName_2010E), typeof(X12_ID_1065_NM1_ServiceProviderName_2010E))]
    public class NM1_ServiceProviderName_2010E
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ServiceProviderName_2010E))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ServiceProviderName_2010E))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ServiceProviderLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ServiceProviderFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ServiceProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ServiceProviderNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_ServiceProviderName_2010E))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ServiceProviderIdentifier_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string NM1_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",24,34,46,XX,")]
    public class X12_ID_66_NM1_ServiceProviderName_2010E
    {
    }
    
    [Serializable()]
    [Segment("MSG")]
    public class MSG_MessageText_2000E
    {
        
        [Required]
        [StringLength(1, 264)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string FreeFormMessageText_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string MSG_02 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(3)]
        public string MSG_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_ServiceProviderLevel_2000E))]
    public class HL_ServiceProviderLevel_2000E
    {
        
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HierarchicalIDNumber_01 { get; set; }
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HierarchicalParentIDNumber_02 { get; set; }
        [Required]
        [DataElement("735", typeof(X12_ID_735_HL_ServiceProviderLevel_2000E))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_ServiceProviderLevel_2000E))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_ServiceProviderLevel_2000E
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_DependentLevel_2000D))]
    public class Loop_2000D
    {
        
        [Required]
        [Pos(1)]
        public HL_DependentLevel_2000D HL_DependentLevel_2000D { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<TRN_PatientEventTrackingNumber_2000D> TRN_PatientEventTrackingNumber_2000D { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<AAA_DependentRequestValidation_2000D> AAA_DependentRequestValidation_2000D { get; set; }
        [Pos(4)]
        public All_DTP_2000D All_DTP_2000D { get; set; }
        [Pos(5)]
        public HI_DependentDiagnosis_2000D HI_DependentDiagnosis_2000D { get; set; }
        [ListCount(10)]
        [Pos(6)]
        public List<PWK_AdditionalPatientInformation_2000D> PWK_AdditionalPatientInformation_2000D { get; set; }
        [Required]
        [Pos(7)]
        public All_2010D All_2010D { get; set; }
        [Required]
        [Pos(8)]
        public List<Loop_2000E> Loop_2000E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",23,")]
    public class X12_ID_735_HL_DependentLevel_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_481_TRN_PatientEventTrackingNumber_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_DependentRequestValidation_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,BJ,BK,LOI,")]
    public class X12_ID_1270_C022_701663074
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,BJ,LOI,")]
    public class X12_ID_1270_C022_461201876
    {
    }
    
    [Serializable()]
    [EdiCodes(",03,04,05,06,07,08,09,10,11,13,15,21,48,55,59,77,A3,A4,AM,AS,AT,B2,B3,BR,BS,BT,CB" +
        ",CK,D2,DA,DB,DG,DJ,DS,FM,HC,HR,I5,IR,LA,M1,NN,OB,OC,OD,OE,OX,P4,P5,P6,P7,PE,PN,P" +
        "O,PQ,PY,PZ,QC,QR,RB,RR,RT,RX,SG,V5,XP,")]
    public class X12_ID_755_PWK_AdditionalPatientInformation_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",BM,EL,EM,FX,VO,")]
    public class X12_ID_756_PWK_AdditionalPatientInformation_2000D
    {
    }
    
    [Serializable()]
    [All()]
    public class All_2010D
    {
        
        [Required]
        [Pos(1)]
        public Loop_2010DA Loop_2010DA { get; set; }
        [Pos(2)]
        public Loop_2010DB Loop_2010DB { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_AdditionalPatientInformationContactName_2010DB))]
    public class Loop_2010DB
    {
        
        [Required]
        [Pos(1)]
        public NM1_AdditionalPatientInformationContactName_2010DB NM1_AdditionalPatientInformationContactName_2010DB { get; set; }
        [Pos(2)]
        public N3_AdditionalPatientInformationContactAddress_2010DB N3_AdditionalPatientInformationContactAddress_2010DB { get; set; }
        [Pos(3)]
        public N4_AdditionalPatientInformationContactCityStateZipCode_2010DB N4_AdditionalPatientInformationContactCityStateZipCode_2010DB { get; set; }
        [Pos(4)]
        public PER_AdditionalPatientInformationContactInformation_2010DB PER_AdditionalPatientInformationContactInformation_2010DB { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1P,2B,ABG,FA,PR,X3,")]
    public class X12_ID_98_NM1_AdditionalPatientInformationContactName_2010DB
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_AdditionalPatientInformationContactName_2010DB
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_AdditionalPatientInformationContactInformation_2010DB
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_AdditionalPatientInformationContactInformation_2010DB))]
    public class PER_AdditionalPatientInformationContactInformation_2010DB
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_AdditionalPatientInformationContactInformation_2010DB))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ResponseContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalPatientInformationContactInformation_2010DB))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ResponseContactCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalPatientInformationContactInformation_2010DB))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ResponseContactCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalPatientInformationContactInformation_2010DB))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string ResponseContactCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EM,FX,TE,")]
    public class X12_ID_365_PER_AdditionalPatientInformationContactInformation_2010DB
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_AdditionalPatientInformationContactCityStateZipCode_2010DB
    {
        
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ResponseContactCityName_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string ResponseContactStateOrProvinceCode_02 { get; set; }
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ResponseContactPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string ResponseContactCountryCode_04 { get; set; }
        [DataElement("309", typeof(X12_ID_309_N4_AdditionalPatientInformationContactCityStateZipCode_2010DB))]
        [Pos(5)]
        public string LocationQualifier_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ResponseContactSpecificLocation_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",B1,DP,")]
    public class X12_ID_309_N4_AdditionalPatientInformationContactCityStateZipCode_2010DB
    {
    }
    
    [Serializable()]
    [Segment("N3")]
    public class N3_AdditionalPatientInformationContactAddress_2010DB
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ResponseContactAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ResponseContactAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_AdditionalPatientInformationContactName_2010DB), typeof(X12_ID_1065_NM1_AdditionalPatientInformationContactName_2010DB))]
    public class NM1_AdditionalPatientInformationContactName_2010DB
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_AdditionalPatientInformationContactName_2010DB))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_AdditionalPatientInformationContactName_2010DB))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ResponseContactLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ResponseContactFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ResponseContactMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ResponseContactNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_AdditionalPatientInformationContactName_2010DB))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ResponseContactIdentifier_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string NM1_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",24,34,46,PI,XV,XX,")]
    public class X12_ID_66_NM1_AdditionalPatientInformationContactName_2010DB
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_DependentName_2010DA))]
    public class Loop_2010DA
    {
        
        [Required]
        [Pos(1)]
        public NM1_DependentName_2010DA NM1_DependentName_2010DA { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<REF_DependentSupplementalIdentification_2010DA> REF_DependentSupplementalIdentification_2010DA { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<AAA_DependentRequestValidation_2010DA> AAA_DependentRequestValidation_2010DA { get; set; }
        [Pos(4)]
        public DMG_DependentDemographicInformation_2010DA DMG_DependentDemographicInformation_2010DA { get; set; }
        [Pos(5)]
        public INS_DependentRelationship_2010DA INS_DependentRelationship_2010DA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",QC,")]
    public class X12_ID_98_NM1_DependentName_2010DA
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_DependentName_2010DA
    {
    }
    
    [Serializable()]
    [EdiCodes(",A6,EJ,SY,")]
    public class X12_ID_128_REF_DependentSupplementalIdentification_2010DA
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_DependentRequestValidation_2010DA
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_DependentDemographicInformation_2010DA
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,")]
    public class X12_ID_1073_INS_DependentRelationship_2010DA
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,04,05,07,09,10,15,17,19,20,21,22,23,24,29,32,33,34,39,40,41,43,53,G8,")]
    public class X12_ID_1069_INS_DependentRelationship_2010DA
    {
    }
    
    [Serializable()]
    [Segment("INS", typeof(X12_ID_1073_INS_DependentRelationship_2010DA), typeof(X12_ID_1069_INS_DependentRelationship_2010DA))]
    public class INS_DependentRelationship_2010DA
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_INS_DependentRelationship_2010DA))]
        [Pos(1)]
        public string InsuredIndicator_01 { get; set; }
        [Required]
        [DataElement("1069", typeof(X12_ID_1069_INS_DependentRelationship_2010DA))]
        [Pos(2)]
        public string IndividualRelationshipCode_02 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string INS_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string INS_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string INS_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string INS_06 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string INS_07 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string INS_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string INS_09 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string INS_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string INS_11 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string INS_12 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(13)]
        public string INS_13 { get; set; }
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(14)]
        public string INS_14 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(15)]
        public string INS_15 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(16)]
        public string INS_16 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(17)]
        public string BirthSequenceNumber_17 { get; set; }
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_DependentDemographicInformation_2010DA))]
    public class DMG_DependentDemographicInformation_2010DA
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_DependentDemographicInformation_2010DA))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DependentBirthDate_02 { get; set; }
        [DataElement("1068", typeof(X12_ID_1068_DMG_DependentDemographicInformation_2010DA))]
        [Pos(3)]
        public string DependentGenderCode_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string DMG_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string DMG_05 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string DMG_06 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string DMG_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string DMG_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string DMG_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",F,M,U,")]
    public class X12_ID_1068_DMG_DependentDemographicInformation_2010DA
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_DependentRequestValidation_2010DA))]
    public class AAA_DependentRequestValidation_2010DA
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_DependentRequestValidation_2010DA))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_AAA_DependentRequestValidation_2010DA))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("889", typeof(X12_ID_889_AAA_DependentRequestValidation_2010DA))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,33,58,64,65,66,67,68,71,77,95,")]
    public class X12_ID_901_AAA_DependentRequestValidation_2010DA
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,")]
    public class X12_ID_889_AAA_DependentRequestValidation_2010DA
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_DependentSupplementalIdentification_2010DA))]
    public class REF_DependentSupplementalIdentification_2010DA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_DependentSupplementalIdentification_2010DA))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DependentSupplementalIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string REF_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_DependentName_2010DA), typeof(X12_ID_1065_NM1_DependentName_2010DA))]
    public class NM1_DependentName_2010DA
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_DependentName_2010DA))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_DependentName_2010DA))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DependentLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DependentFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string DependentMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string DependentNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_DependentName_2010DA))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string DependentPrimaryIdentifier_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string NM1_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",MI,ZZ,")]
    public class X12_ID_66_NM1_DependentName_2010DA
    {
    }
    
    [Serializable()]
    [Segment("PWK", typeof(X12_ID_755_PWK_AdditionalPatientInformation_2000D), typeof(X12_ID_756_PWK_AdditionalPatientInformation_2000D))]
    public class PWK_AdditionalPatientInformation_2000D
    {
        
        [Required]
        [DataElement("755", typeof(X12_ID_755_PWK_AdditionalPatientInformation_2000D))]
        [Pos(1)]
        public string AttachmentReportTypeCode_01 { get; set; }
        [Required]
        [DataElement("756", typeof(X12_ID_756_PWK_AdditionalPatientInformation_2000D))]
        [Pos(2)]
        public string AttachmentTransmissionCode_02 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(3)]
        public string PWK_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string PWK_04 { get; set; }
        [DataElement("66", typeof(X12_ID_66_PWK_AdditionalPatientInformation_2000D))]
        [Pos(5)]
        public string IdentificationCodeQualifier_05 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string AttachmentControlNumber_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string AttachmentDescription_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string PWK_08 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string PWK_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AC,")]
    public class X12_ID_66_PWK_AdditionalPatientInformation_2000D
    {
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_701663074), typeof(X12_ID_1270_C022_461201876))]
    public class HI_DependentDiagnosis_2000D
    {
        
        [Required]
        [Pos(1)]
        public C022_701663074 C022_701663074 { get; set; }
        [Pos(2)]
        public C022_461201876 C022_461201876 { get; set; }
        [Pos(3)]
        public C022_1624066826 C022_1624066826 { get; set; }
        [Pos(4)]
        public C022_1509084096 C022_1509084096 { get; set; }
        [Pos(5)]
        public C022_1152853736 C022_1152853736 { get; set; }
        [Pos(6)]
        public C022_702449506 C022_702449506 { get; set; }
        [Pos(7)]
        public C022_460808661 C022_460808661 { get; set; }
        [Pos(8)]
        public C022_1623673611 C022_1623673611 { get; set; }
        [Pos(9)]
        public C022_1508428735 C022_1508428735 { get; set; }
        [Pos(10)]
        public C022_1152198375 C022_1152198375 { get; set; }
        [Pos(11)]
        public C022_701794145 C022_701794145 { get; set; }
        [Pos(12)]
        public C022_461070805 C022_461070805 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_461070805")]
    public class C022_461070805
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_461070805))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_461070805))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_461070805
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_461070805
    {
    }
    
    [Serializable()]
    [Composite("C022_701794145")]
    public class C022_701794145
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_701794145))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_701794145))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_701794145
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_701794145
    {
    }
    
    [Serializable()]
    [Composite("C022_1152198375")]
    public class C022_1152198375
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1152198375))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1152198375))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1152198375
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1152198375
    {
    }
    
    [Serializable()]
    [Composite("C022_1508428735")]
    public class C022_1508428735
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1508428735))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1508428735))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1508428735
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1508428735
    {
    }
    
    [Serializable()]
    [Composite("C022_1623673611")]
    public class C022_1623673611
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1623673611))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1623673611))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1623673611
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1623673611
    {
    }
    
    [Serializable()]
    [Composite("C022_460808661")]
    public class C022_460808661
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_460808661))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_460808661))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_460808661
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_460808661
    {
    }
    
    [Serializable()]
    [Composite("C022_702449506")]
    public class C022_702449506
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_702449506))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_702449506))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_702449506
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_702449506
    {
    }
    
    [Serializable()]
    [Composite("C022_1152853736")]
    public class C022_1152853736
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1152853736))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1152853736))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1152853736
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1152853736
    {
    }
    
    [Serializable()]
    [Composite("C022_1509084096")]
    public class C022_1509084096
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1509084096))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1509084096))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1509084096
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1509084096
    {
    }
    
    [Serializable()]
    [Composite("C022_1624066826")]
    public class C022_1624066826
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1624066826))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1624066826))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1624066826
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1624066826
    {
    }
    
    [Serializable()]
    [Composite("C022_461201876")]
    public class C022_461201876
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_461201876))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_461201876))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_461201876
    {
    }
    
    [Serializable()]
    [Composite("C022_701663074")]
    public class C022_701663074
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_701663074))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_701663074))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_701663074
    {
    }
    
    [Serializable()]
    [All()]
    public class All_DTP_2000D
    {
        
        [Pos(1)]
        public DTP_AccidentDate_2000D DTP_AccidentDate_2000D { get; set; }
        [Pos(2)]
        public DTP_LastMenstrualPeriodDate_2000D DTP_LastMenstrualPeriodDate_2000D { get; set; }
        [Pos(3)]
        public DTP_EstimatedDateOfBirth_2000D DTP_EstimatedDateOfBirth_2000D { get; set; }
        [Pos(4)]
        public DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",439,")]
    public class X12_ID_374_DTP_AccidentDate_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_AccidentDate_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",484,")]
    public class X12_ID_374_DTP_LastMenstrualPeriodDate_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_LastMenstrualPeriodDate_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",ABC,")]
    public class X12_ID_374_DTP_EstimatedDateOfBirth_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_EstimatedDateOfBirth_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",431,")]
    public class X12_ID_374_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D), typeof(X12_ID_1250_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D))]
    public class DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000D))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OnsetDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_EstimatedDateOfBirth_2000D), typeof(X12_ID_1250_DTP_EstimatedDateOfBirth_2000D))]
    public class DTP_EstimatedDateOfBirth_2000D
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_EstimatedDateOfBirth_2000D))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_EstimatedDateOfBirth_2000D))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string EstimatedBirthDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_LastMenstrualPeriodDate_2000D), typeof(X12_ID_1250_DTP_LastMenstrualPeriodDate_2000D))]
    public class DTP_LastMenstrualPeriodDate_2000D
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_LastMenstrualPeriodDate_2000D))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_LastMenstrualPeriodDate_2000D))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string LastMenstrualPeriodDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_AccidentDate_2000D), typeof(X12_ID_1250_DTP_AccidentDate_2000D))]
    public class DTP_AccidentDate_2000D
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_AccidentDate_2000D))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_AccidentDate_2000D))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AccidentDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_DependentRequestValidation_2000D))]
    public class AAA_DependentRequestValidation_2000D
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_DependentRequestValidation_2000D))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_AAA_DependentRequestValidation_2000D))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("889", typeof(X12_ID_889_AAA_DependentRequestValidation_2000D))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,33,56,")]
    public class X12_ID_901_AAA_DependentRequestValidation_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,")]
    public class X12_ID_889_AAA_DependentRequestValidation_2000D
    {
    }
    
    [Serializable()]
    [Segment("TRN", typeof(X12_ID_481_TRN_PatientEventTrackingNumber_2000D))]
    public class TRN_PatientEventTrackingNumber_2000D
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_PatientEventTrackingNumber_2000D))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PatientEventTrackingNumber_02 { get; set; }
        [Required]
        [StringLength(10, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string TraceAssigningEntityIdentifier_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string TraceAssigningEntityAdditionalIdentifier_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_DependentLevel_2000D))]
    public class HL_DependentLevel_2000D
    {
        
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HierarchicalIDNumber_01 { get; set; }
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HierarchicalParentIDNumber_02 { get; set; }
        [Required]
        [DataElement("735", typeof(X12_ID_735_HL_DependentLevel_2000D))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_DependentLevel_2000D))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_DependentLevel_2000D
    {
    }
    
    [Serializable()]
    [All()]
    public class All_2010C
    {
        
        [Required]
        [Pos(1)]
        public Loop_2010CA Loop_2010CA { get; set; }
        [Pos(2)]
        public Loop_2010CB Loop_2010CB { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_AdditionalPatientInformationContactName_2010CB))]
    public class Loop_2010CB
    {
        
        [Required]
        [Pos(1)]
        public NM1_AdditionalPatientInformationContactName_2010CB NM1_AdditionalPatientInformationContactName_2010CB { get; set; }
        [Pos(2)]
        public N3_AdditionalPatientInformationContactAddress_2010CB N3_AdditionalPatientInformationContactAddress_2010CB { get; set; }
        [Pos(3)]
        public N4_AdditionalPatientInformationContactCityStateZipCode_2010CB N4_AdditionalPatientInformationContactCityStateZipCode_2010CB { get; set; }
        [Pos(4)]
        public PER_AdditionalPatientInformationContactInformation_2010CB PER_AdditionalPatientInformationContactInformation_2010CB { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1P,2B,ABG,FA,PR,X3,")]
    public class X12_ID_98_NM1_AdditionalPatientInformationContactName_2010CB
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_AdditionalPatientInformationContactName_2010CB
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_AdditionalPatientInformationContactInformation_2010CB
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_AdditionalPatientInformationContactInformation_2010CB))]
    public class PER_AdditionalPatientInformationContactInformation_2010CB
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_AdditionalPatientInformationContactInformation_2010CB))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ResponseContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalPatientInformationContactInformation_2010CB))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ResponseContactCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalPatientInformationContactInformation_2010CB))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ResponseContactCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_AdditionalPatientInformationContactInformation_2010CB))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string ResponseContactCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EM,FX,TE,")]
    public class X12_ID_365_PER_AdditionalPatientInformationContactInformation_2010CB
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_AdditionalPatientInformationContactCityStateZipCode_2010CB
    {
        
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ResponseContactCityName_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string ResponseContactStateOrProvinceCode_02 { get; set; }
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ResponseContactPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string ResponseContactCountryCode_04 { get; set; }
        [DataElement("309", typeof(X12_ID_309_N4_AdditionalPatientInformationContactCityStateZipCode_2010CB))]
        [Pos(5)]
        public string LocationQualifier_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ResponseContactSpecificLocation_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",B1,DP,")]
    public class X12_ID_309_N4_AdditionalPatientInformationContactCityStateZipCode_2010CB
    {
    }
    
    [Serializable()]
    [Segment("N3")]
    public class N3_AdditionalPatientInformationContactAddress_2010CB
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ResponseContactAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ResponseContactAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_AdditionalPatientInformationContactName_2010CB), typeof(X12_ID_1065_NM1_AdditionalPatientInformationContactName_2010CB))]
    public class NM1_AdditionalPatientInformationContactName_2010CB
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_AdditionalPatientInformationContactName_2010CB))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_AdditionalPatientInformationContactName_2010CB))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ResponseContactLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ResponseContactFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ResponseContactMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ResponseContactNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_AdditionalPatientInformationContactName_2010CB))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ResponseContactIdentifier_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string NM1_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",24,34,46,PI,XV,XX,")]
    public class X12_ID_66_NM1_AdditionalPatientInformationContactName_2010CB
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_SubscriberName_2010CA))]
    public class Loop_2010CA
    {
        
        [Required]
        [Pos(1)]
        public NM1_SubscriberName_2010CA NM1_SubscriberName_2010CA { get; set; }
        [ListCount(9)]
        [Pos(2)]
        public List<REF_SubscriberSupplementalIdentification_2010CA> REF_SubscriberSupplementalIdentification_2010CA { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<AAA_SubscriberRequestValidation_2010CA> AAA_SubscriberRequestValidation_2010CA { get; set; }
        [Pos(4)]
        public DMG_SubscriberDemographicInformation_2010CA DMG_SubscriberDemographicInformation_2010CA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",IL,")]
    public class X12_ID_98_NM1_SubscriberName_2010CA
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_SubscriberName_2010CA
    {
    }
    
    [Serializable()]
    [EdiCodes(",1L,1W,6P,A6,EJ,F6,HJ,IG,N6,NQ,SY,")]
    public class X12_ID_128_REF_SubscriberSupplementalIdentification_2010CA
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_SubscriberRequestValidation_2010CA
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_SubscriberDemographicInformation_2010CA
    {
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_SubscriberDemographicInformation_2010CA))]
    public class DMG_SubscriberDemographicInformation_2010CA
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_SubscriberDemographicInformation_2010CA))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberBirthDate_02 { get; set; }
        [DataElement("1068", typeof(X12_ID_1068_DMG_SubscriberDemographicInformation_2010CA))]
        [Pos(3)]
        public string SubscriberGenderCode_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string DMG_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string DMG_05 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string DMG_06 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string DMG_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string DMG_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string DMG_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",F,M,U,")]
    public class X12_ID_1068_DMG_SubscriberDemographicInformation_2010CA
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_SubscriberRequestValidation_2010CA))]
    public class AAA_SubscriberRequestValidation_2010CA
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_SubscriberRequestValidation_2010CA))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_AAA_SubscriberRequestValidation_2010CA))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("889", typeof(X12_ID_889_AAA_SubscriberRequestValidation_2010CA))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,58,64,65,66,67,68,71,72,73,74,75,76,77,78,79,95,")]
    public class X12_ID_901_AAA_SubscriberRequestValidation_2010CA
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,")]
    public class X12_ID_889_AAA_SubscriberRequestValidation_2010CA
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_SubscriberSupplementalIdentification_2010CA))]
    public class REF_SubscriberSupplementalIdentification_2010CA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_SubscriberSupplementalIdentification_2010CA))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberSupplementalIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string REF_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_SubscriberName_2010CA), typeof(X12_ID_1065_NM1_SubscriberName_2010CA))]
    public class NM1_SubscriberName_2010CA
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_SubscriberName_2010CA))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_SubscriberName_2010CA))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string SubscriberLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string SubscriberFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string SubscriberMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string SubscriberNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_SubscriberName_2010CA))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string SubscriberPrimaryIdentifier_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string NM1_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",MI,ZZ,")]
    public class X12_ID_66_NM1_SubscriberName_2010CA
    {
    }
    
    [Serializable()]
    [Segment("PWK", typeof(X12_ID_755_PWK_AdditionalPatientInformation_2000C), typeof(X12_ID_756_PWK_AdditionalPatientInformation_2000C))]
    public class PWK_AdditionalPatientInformation_2000C
    {
        
        [Required]
        [DataElement("755", typeof(X12_ID_755_PWK_AdditionalPatientInformation_2000C))]
        [Pos(1)]
        public string AttachmentReportTypeCode_01 { get; set; }
        [Required]
        [DataElement("756", typeof(X12_ID_756_PWK_AdditionalPatientInformation_2000C))]
        [Pos(2)]
        public string AttachmentTransmissionCode_02 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(3)]
        public string PWK_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string PWK_04 { get; set; }
        [DataElement("66", typeof(X12_ID_66_PWK_AdditionalPatientInformation_2000C))]
        [Pos(5)]
        public string IdentificationCodeQualifier_05 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string AttachmentControlNumber_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string AttachmentDescription_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string PWK_08 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string PWK_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AC,")]
    public class X12_ID_66_PWK_AdditionalPatientInformation_2000C
    {
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_1220716762), typeof(X12_ID_1270_C022_1576947122))]
    public class HI_SubscriberDiagnosis_2000C
    {
        
        [Required]
        [Pos(1)]
        public C022_1220716762 C022_1220716762 { get; set; }
        [Pos(2)]
        public C022_1576947122 C022_1576947122 { get; set; }
        [Pos(3)]
        public C022_2027351352 C022_2027351352 { get; set; }
        [Pos(4)]
        public C022_1105799570 C022_1105799570 { get; set; }
        [Pos(5)]
        public C022_57065380 C022_57065380 { get; set; }
        [Pos(6)]
        public C022_1220323547 C022_1220323547 { get; set; }
        [Pos(7)]
        public C022_1576553907 C022_1576553907 { get; set; }
        [Pos(8)]
        public C022_2026958137 C022_2026958137 { get; set; }
        [Pos(9)]
        public C022_1105144209 C022_1105144209 { get; set; }
        [Pos(10)]
        public C022_57720741 C022_57720741 { get; set; }
        [Pos(11)]
        public C022_1220585691 C022_1220585691 { get; set; }
        [Pos(12)]
        public C022_1576816051 C022_1576816051 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_1576816051")]
    public class C022_1576816051
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1576816051))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1576816051))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1576816051
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1576816051
    {
    }
    
    [Serializable()]
    [Composite("C022_1220585691")]
    public class C022_1220585691
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1220585691))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1220585691))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1220585691
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1220585691
    {
    }
    
    [Serializable()]
    [Composite("C022_57720741")]
    public class C022_57720741
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_57720741))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_57720741))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_57720741
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_57720741
    {
    }
    
    [Serializable()]
    [Composite("C022_1105144209")]
    public class C022_1105144209
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1105144209))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1105144209))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1105144209
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1105144209
    {
    }
    
    [Serializable()]
    [Composite("C022_2026958137")]
    public class C022_2026958137
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_2026958137))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_2026958137))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_2026958137
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_2026958137
    {
    }
    
    [Serializable()]
    [Composite("C022_1576553907")]
    public class C022_1576553907
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1576553907))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1576553907))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1576553907
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1576553907
    {
    }
    
    [Serializable()]
    [Composite("C022_1220323547")]
    public class C022_1220323547
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1220323547))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1220323547))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1220323547
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1220323547
    {
    }
    
    [Serializable()]
    [Composite("C022_57065380")]
    public class C022_57065380
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_57065380))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_57065380))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_57065380
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_57065380
    {
    }
    
    [Serializable()]
    [Composite("C022_1105799570")]
    public class C022_1105799570
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1105799570))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1105799570))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_1105799570
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1105799570
    {
    }
    
    [Serializable()]
    [Composite("C022_2027351352")]
    public class C022_2027351352
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_2027351352))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_2027351352))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,LOI,")]
    public class X12_ID_1270_C022_2027351352
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_2027351352
    {
    }
    
    [Serializable()]
    [Composite("C022_1576947122")]
    public class C022_1576947122
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1576947122))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1576947122))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1576947122
    {
    }
    
    [Serializable()]
    [Composite("C022_1220716762")]
    public class C022_1220716762
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1220716762))]
        [Pos(1)]
        public string DiagnosisTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1220716762))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DiagnosisDate_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1220716762
    {
    }
    
    [Serializable()]
    [All()]
    public class All_DTP_2000C
    {
        
        [Pos(1)]
        public DTP_AccidentDate_2000C DTP_AccidentDate_2000C { get; set; }
        [Pos(2)]
        public DTP_LastMenstrualPeriodDate_2000C DTP_LastMenstrualPeriodDate_2000C { get; set; }
        [Pos(3)]
        public DTP_EstimatedDateOfBirth_2000C DTP_EstimatedDateOfBirth_2000C { get; set; }
        [Pos(4)]
        public DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",439,")]
    public class X12_ID_374_DTP_AccidentDate_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_AccidentDate_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",484,")]
    public class X12_ID_374_DTP_LastMenstrualPeriodDate_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_LastMenstrualPeriodDate_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",ABC,")]
    public class X12_ID_374_DTP_EstimatedDateOfBirth_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_EstimatedDateOfBirth_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",431,")]
    public class X12_ID_374_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C), typeof(X12_ID_1250_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C))]
    public class DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_OnsetOfCurrentSymptomsOrIllnessDate_2000C))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OnsetDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_EstimatedDateOfBirth_2000C), typeof(X12_ID_1250_DTP_EstimatedDateOfBirth_2000C))]
    public class DTP_EstimatedDateOfBirth_2000C
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_EstimatedDateOfBirth_2000C))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_EstimatedDateOfBirth_2000C))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string EstimatedBirthDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_LastMenstrualPeriodDate_2000C), typeof(X12_ID_1250_DTP_LastMenstrualPeriodDate_2000C))]
    public class DTP_LastMenstrualPeriodDate_2000C
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_LastMenstrualPeriodDate_2000C))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_LastMenstrualPeriodDate_2000C))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string LastMenstrualPeriodDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_AccidentDate_2000C), typeof(X12_ID_1250_DTP_AccidentDate_2000C))]
    public class DTP_AccidentDate_2000C
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_AccidentDate_2000C))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_AccidentDate_2000C))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AccidentDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_SubscriberRequestValidation_2000C))]
    public class AAA_SubscriberRequestValidation_2000C
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_SubscriberRequestValidation_2000C))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_AAA_SubscriberRequestValidation_2000C))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("889", typeof(X12_ID_889_AAA_SubscriberRequestValidation_2000C))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,33,56,")]
    public class X12_ID_901_AAA_SubscriberRequestValidation_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,")]
    public class X12_ID_889_AAA_SubscriberRequestValidation_2000C
    {
    }
    
    [Serializable()]
    [Segment("TRN", typeof(X12_ID_481_TRN_PatientEventTrackingNumber_2000C))]
    public class TRN_PatientEventTrackingNumber_2000C
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_PatientEventTrackingNumber_2000C))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PatientEventTrackingNumber_02 { get; set; }
        [Required]
        [StringLength(10, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string TraceAssigningEntityIdentifier_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string TraceAssigningEntityAdditionalIdentifier_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_SubscriberLevel_2000C))]
    public class HL_SubscriberLevel_2000C
    {
        
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HierarchicalIDNumber_01 { get; set; }
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HierarchicalParentIDNumber_02 { get; set; }
        [Required]
        [DataElement("735", typeof(X12_ID_735_HL_SubscriberLevel_2000C))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_SubscriberLevel_2000C))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_SubscriberLevel_2000C
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_RequesterName_2010B))]
    public class Loop_2010B
    {
        
        [Required]
        [Pos(1)]
        public NM1_RequesterName_2010B NM1_RequesterName_2010B { get; set; }
        [ListCount(8)]
        [Pos(2)]
        public List<REF_RequesterSupplementalIdentification_2010B> REF_RequesterSupplementalIdentification_2010B { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<AAA_RequesterRequestValidation_2010B> AAA_RequesterRequestValidation_2010B { get; set; }
        [Pos(4)]
        public PRV_RequesterProviderInformation_2010B PRV_RequesterProviderInformation_2010B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1P,FA,")]
    public class X12_ID_98_NM1_RequesterName_2010B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_RequesterName_2010B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1G,1J,CT,EI,N5,N7,SY,ZH,")]
    public class X12_ID_128_REF_RequesterSupplementalIdentification_2010B
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_RequesterRequestValidation_2010B
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,AS,AT,CO,CV,OP,OR,OT,PC,PE,RF,")]
    public class X12_ID_1221_PRV_RequesterProviderInformation_2010B
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_RequesterProviderInformation_2010B
    {
    }
    
    [Serializable()]
    [Segment("PRV", typeof(X12_ID_1221_PRV_RequesterProviderInformation_2010B), typeof(X12_ID_128_PRV_RequesterProviderInformation_2010B))]
    public class PRV_RequesterProviderInformation_2010B
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_RequesterProviderInformation_2010B))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_RequesterProviderInformation_2010B))]
        [Pos(2)]
        public string ReferenceIdentificationQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProviderTaxonomyCode_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string PRV_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string PRV_05 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string PRV_06 { get; set; }
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_RequesterRequestValidation_2010B))]
    public class AAA_RequesterRequestValidation_2010B
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_RequesterRequestValidation_2010B))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_AAA_RequesterRequestValidation_2010B))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("889", typeof(X12_ID_889_AAA_RequesterRequestValidation_2010B))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",35,41,43,44,45,46,47,49,50,51,79,97,")]
    public class X12_ID_901_AAA_RequesterRequestValidation_2010B
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,R,")]
    public class X12_ID_889_AAA_RequesterRequestValidation_2010B
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_RequesterSupplementalIdentification_2010B))]
    public class REF_RequesterSupplementalIdentification_2010B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_RequesterSupplementalIdentification_2010B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string RequesterSupplementalIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string REF_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_RequesterName_2010B), typeof(X12_ID_1065_NM1_RequesterName_2010B))]
    public class NM1_RequesterName_2010B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_RequesterName_2010B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_RequesterName_2010B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string RequesterLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string RequesterFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string RequesterMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string RequesterNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_RequesterName_2010B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string RequesterIdentifier_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string NM1_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",24,34,46,XX,")]
    public class X12_ID_66_NM1_RequesterName_2010B
    {
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_RequesterLevel_2000B))]
    public class HL_RequesterLevel_2000B
    {
        
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HierarchicalIDNumber_01 { get; set; }
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HierarchicalParentIDNumber_02 { get; set; }
        [Required]
        [DataElement("735", typeof(X12_ID_735_HL_RequesterLevel_2000B))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_RequesterLevel_2000B))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_RequesterLevel_2000B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_UtilizationManagementOrganizationUMOName_2010A))]
    public class Loop_2010A
    {
        
        [Required]
        [Pos(1)]
        public NM1_UtilizationManagementOrganizationUMOName_2010A NM1_UtilizationManagementOrganizationUMOName_2010A { get; set; }
        [Pos(2)]
        public PER_UtilizationManagementOrganizationUMOContactInformation_2010A PER_UtilizationManagementOrganizationUMOContactInformation_2010A { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<AAA_UtilizationManagementOrganizationUMORequestValidation_2010A> AAA_UtilizationManagementOrganizationUMORequestValidation_2010A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",X3,")]
    public class X12_ID_98_NM1_UtilizationManagementOrganizationUMOName_2010A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_UtilizationManagementOrganizationUMOName_2010A
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_UtilizationManagementOrganizationUMOContactInformation_2010A
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_UtilizationManagementOrganizationUMORequestValidation_2010A
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_UtilizationManagementOrganizationUMORequestValidation_2010A))]
    public class AAA_UtilizationManagementOrganizationUMORequestValidation_2010A
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_UtilizationManagementOrganizationUMORequestValidation_2010A))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [DataElement("901", typeof(X12_ID_901_AAA_UtilizationManagementOrganizationUMORequestValidation_2010A))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [DataElement("889", typeof(X12_ID_889_AAA_UtilizationManagementOrganizationUMORequestValidation_2010A))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",04,41,42,79,80,T4,")]
    public class X12_ID_901_AAA_UtilizationManagementOrganizationUMORequestValidation_2010A
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,P,Y,")]
    public class X12_ID_889_AAA_UtilizationManagementOrganizationUMORequestValidation_2010A
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_UtilizationManagementOrganizationUMOContactInformation_2010A))]
    public class PER_UtilizationManagementOrganizationUMOContactInformation_2010A
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_UtilizationManagementOrganizationUMOContactInformation_2010A))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string UtilizationManagementOrganizationUMOContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_UtilizationManagementOrganizationUMOContactInformation_2010A))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string UtilizationManagementOrganizationUMOContactCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_UtilizationManagementOrganizationUMOContactInformation_2010A))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string UtilizationManagementOrganizationUMOContactCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_UtilizationManagementOrganizationUMOContactInformation_2010A))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string UtilizationManagementOrganizationUMOContactCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EM,FX,TE,")]
    public class X12_ID_365_PER_UtilizationManagementOrganizationUMOContactInformation_2010A
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_UtilizationManagementOrganizationUMOName_2010A), typeof(X12_ID_1065_NM1_UtilizationManagementOrganizationUMOName_2010A))]
    public class NM1_UtilizationManagementOrganizationUMOName_2010A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_UtilizationManagementOrganizationUMOName_2010A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_UtilizationManagementOrganizationUMOName_2010A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string UtilizationManagementOrganizationUMOLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string UtilizationManagementOrganizationUMOFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string UtilizationManagementOrganizationUMOMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string UtilizationManagementOrganizationUMONameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_UtilizationManagementOrganizationUMOName_2010A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string UtilizationManagementOrganizationUMOIdentifier_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string NM1_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",24,34,46,PI,XV,XX,")]
    public class X12_ID_66_NM1_UtilizationManagementOrganizationUMOName_2010A
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_RequestValidation_2000A))]
    public class AAA_RequestValidation_2000A
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_RequestValidation_2000A))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [Required]
        [DataElement("901", typeof(X12_ID_901_AAA_RequestValidation_2000A))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [Required]
        [DataElement("889", typeof(X12_ID_889_AAA_RequestValidation_2000A))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",04,41,42,79,")]
    public class X12_ID_901_AAA_RequestValidation_2000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,P,Y,")]
    public class X12_ID_889_AAA_RequestValidation_2000A
    {
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_UtilizationManagementOrganizationUMOLevel_2000A))]
    public class HL_UtilizationManagementOrganizationUMOLevel_2000A
    {
        
        [Required]
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HierarchicalIDNumber_01 { get; set; }
        [StringLength(1, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HL_02 { get; set; }
        [Required]
        [DataElement("735", typeof(X12_ID_735_HL_UtilizationManagementOrganizationUMOLevel_2000A))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_UtilizationManagementOrganizationUMOLevel_2000A))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_UtilizationManagementOrganizationUMOLevel_2000A
    {
    }
    
    [Serializable()]
    [Segment("BHT", typeof(X12_ID_1005_BHT_BeginningOfHierarchicalTransaction), typeof(X12_ID_353_BHT_BeginningOfHierarchicalTransaction))]
    public class BHT_BeginningOfHierarchicalTransaction
    {
        
        [Required]
        [DataElement("1005", typeof(X12_ID_1005_BHT_BeginningOfHierarchicalTransaction))]
        [Pos(1)]
        public string HierarchicalStructureCode_01 { get; set; }
        [Required]
        [DataElement("353", typeof(X12_ID_353_BHT_BeginningOfHierarchicalTransaction))]
        [Pos(2)]
        public string TransactionSetPurposeCode_02 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string SubmitterTransactionIdentifier_03 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(4)]
        public string TransactionSetCreationDate_04 { get; set; }
        [Required]
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(5)]
        public string TransactionSetCreationTime_05 { get; set; }
        [DataElement("640", typeof(X12_ID_640_BHT_BeginningOfHierarchicalTransaction))]
        [Pos(6)]
        public string TransactionTypeCode_06 { get; set; }
    }
    
    [Serializable()]
    public class X12_TM
    {
    }
    
    [Serializable()]
    [EdiCodes(",18,19,AT,")]
    public class X12_ID_640_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [Group(typeof(BHT_BeginningOfHierarchicalTransaction))]
    public class Loop_BHT_A1
    {
        
        [Pos(1)]
        public BHT_BeginningOfHierarchicalTransaction BHT_BeginningOfHierarchicalTransaction { get; set; }
        [Pos(2)]
        public Loop_2000A Loop_2000A { get; set; }
    }
}
