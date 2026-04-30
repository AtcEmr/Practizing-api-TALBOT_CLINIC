namespace EdiFabric.Rules.HIPAA_004010X096A1_837
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X096A1", "837")]
    public class TS837 : EdiMessage
    {
        
        [Pos(1)]
        public ST ST { get; set; }
        [Required]
        [Pos(2)]
        public BHT_BeginningOfHierarchicalTransaction BHT_BeginningOfHierarchicalTransaction { get; set; }
        [Required]
        [Pos(3)]
        public REF_TransmissionTypeIdentification REF_TransmissionTypeIdentification { get; set; }
        [Required]
        [Pos(4)]
        public Loop_1000A Loop_1000A { get; set; }
        [Required]
        [Pos(5)]
        public Loop_1000B Loop_1000B { get; set; }
        [Required]
        [Pos(6)]
        public List<Loop_2000A> Loop_2000A { get; set; }
        [Pos(7)]
        public SE SE { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0019,")]
    public class X12_ID_1005_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [EdiCodes(",00,18,")]
    public class X12_ID_353_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [EdiCodes(",87,")]
    public class X12_ID_128_REF_TransmissionTypeIdentification
    {
    }
    
    [Serializable()]
    public class X12_AN
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_BillingPayToProviderHierarchicalLevel_2000A))]
    public class Loop_2000A
    {
        
        [Required]
        [Pos(1)]
        public HL_BillingPayToProviderHierarchicalLevel_2000A HL_BillingPayToProviderHierarchicalLevel_2000A { get; set; }
        [Pos(2)]
        public PRV_BillingPayToProviderSpecialtyInformation_2000A PRV_BillingPayToProviderSpecialtyInformation_2000A { get; set; }
        [Pos(3)]
        public CUR_ForeignCurrencyInformation_2000A CUR_ForeignCurrencyInformation_2000A { get; set; }
        [Required]
        [Pos(4)]
        public All_2010A All_2010A { get; set; }
        [Required]
        [Pos(5)]
        public List<Loop_2000B> Loop_2000B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",20,")]
    public class X12_ID_735_HL_BillingPayToProviderHierarchicalLevel_2000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",BI,PT,")]
    public class X12_ID_1221_PRV_BillingPayToProviderSpecialtyInformation_2000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_BillingPayToProviderSpecialtyInformation_2000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",85,")]
    public class X12_ID_98_CUR_ForeignCurrencyInformation_2000A
    {
    }
    
    [Serializable()]
    public class X12_ID
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_SubscriberHierarchicalLevel_2000B))]
    public class Loop_2000B
    {
        
        [Required]
        [Pos(1)]
        public HL_SubscriberHierarchicalLevel_2000B HL_SubscriberHierarchicalLevel_2000B { get; set; }
        [Required]
        [Pos(2)]
        public SBR_SubscriberInformation_2000B SBR_SubscriberInformation_2000B { get; set; }
        [Required]
        [Pos(3)]
        public All_2010B All_2010B { get; set; }
        [ListCount(100)]
        [Pos(4)]
        public List<Loop_2300> Loop_2300 { get; set; }
        [Pos(5)]
        public List<Loop_2000C> Loop_2000C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",22,")]
    public class X12_ID_735_HL_SubscriberHierarchicalLevel_2000B
    {
    }
    
    [Serializable()]
    [EdiCodes(",P,S,T,")]
    public class X12_ID_1138_SBR_SubscriberInformation_2000B
    {
    }
    
    [Serializable()]
    [EdiCodes(",18,")]
    public class X12_ID_1069_SBR_SubscriberInformation_2000B
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_PatientHierarchicalLevel_2000C))]
    public class Loop_2000C
    {
        
        [Required]
        [Pos(1)]
        public HL_PatientHierarchicalLevel_2000C HL_PatientHierarchicalLevel_2000C { get; set; }
        [Required]
        [Pos(2)]
        public PAT_PatientInformation_2000C PAT_PatientInformation_2000C { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2010CA Loop_2010CA { get; set; }
        [Required]
        [ListCount(100)]
        [Pos(4)]
        public List<Loop_2300> Loop_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",23,")]
    public class X12_ID_735_HL_PatientHierarchicalLevel_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,04,05,07,10,15,17,19,20,21,22,23,24,29,32,33,36,39,40,41,43,53,G8,")]
    public class X12_ID_1069_PAT_PatientInformation_2000C
    {
    }
    
    [Serializable()]
    [Group(typeof(CLM_ClaimInformation_2300))]
    public class Loop_2300
    {
        
        [Required]
        [Pos(1)]
        public CLM_ClaimInformation_2300 CLM_ClaimInformation_2300 { get; set; }
        [Required]
        [Pos(2)]
        public All_DTP_2300 All_DTP_2300 { get; set; }
        [Pos(3)]
        public CL1_InstitutionalClaimCode_2300 CL1_InstitutionalClaimCode_2300 { get; set; }
        [ListCount(10)]
        [Pos(4)]
        public List<PWK_ClaimSupplementalInformation_2300> PWK_ClaimSupplementalInformation_2300 { get; set; }
        [Pos(5)]
        public CN1_ContractInformation_2300 CN1_ContractInformation_2300 { get; set; }
        [Pos(6)]
        public All_AMT_2300 All_AMT_2300 { get; set; }
        [Pos(7)]
        public All_REF_2300 All_REF_2300 { get; set; }
        [ListCount(10)]
        [Pos(8)]
        public List<K3_FileInformation_2300> K3_FileInformation_2300 { get; set; }
        [Pos(9)]
        public All_NTE_2300 All_NTE_2300 { get; set; }
        [Pos(10)]
        public CR6_HomeHealthCareInformation_2300 CR6_HomeHealthCareInformation_2300 { get; set; }
        [Pos(11)]
        public All_CRC_2300 All_CRC_2300 { get; set; }
        [Pos(12)]
        public All_HI_2300 All_HI_2300 { get; set; }
        [ListCount(4)]
        [Pos(13)]
        public List<QTY_ClaimQuantity_2300> QTY_ClaimQuantity_2300 { get; set; }
        [Pos(14)]
        public HCP_ClaimPricingRepricingInformation_2300 HCP_ClaimPricingRepricingInformation_2300 { get; set; }
        [ListCount(6)]
        [Pos(15)]
        public List<Loop_2305> Loop_2305 { get; set; }
        [Pos(16)]
        public All_2310 All_2310 { get; set; }
        [ListCount(10)]
        [Pos(17)]
        public List<Loop_2320> Loop_2320 { get; set; }
        [Required]
        [ListCount(999)]
        [Pos(18)]
        public List<Loop_2400> Loop_2400 { get; set; }
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    [EdiCodes(",AS,B2,B3,B4,CT,DA,DG,DS,EB,MT,NN,OB,OZ,PN,PO,PZ,RB,RR,RT,")]
    public class X12_ID_755_PWK_ClaimSupplementalInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",AA,BM,EL,EM,FX,")]
    public class X12_ID_756_PWK_ClaimSupplementalInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,02,03,04,05,06,09,")]
    public class X12_ID_1166_CN1_ContractInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,")]
    public class X12_ID_923_CR6_HomeHealthCareInformation_2300
    {
    }
    
    [Serializable()]
    public class X12_DT
    {
    }
    
    [Serializable()]
    [EdiCodes(",CA,CD,LA,NA,")]
    public class X12_ID_673_QTY_ClaimQuantity_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",00,01,02,03,04,05,06,07,08,09,10,11,12,13,14,")]
    public class X12_ID_1473_HCP_ClaimPricingRepricingInformation_2300
    {
    }
    
    [Serializable()]
    [Group(typeof(LX_ServiceLineNumber_2400))]
    public class Loop_2400
    {
        
        [Required]
        [Pos(1)]
        public LX_ServiceLineNumber_2400 LX_ServiceLineNumber_2400 { get; set; }
        [Required]
        [Pos(2)]
        public SV2_InstitutionalServiceLine_2400 SV2_InstitutionalServiceLine_2400 { get; set; }
        [ListCount(5)]
        [Pos(3)]
        public List<PWK_LineSupplementalInformation_2400> PWK_LineSupplementalInformation_2400 { get; set; }
        [Pos(4)]
        public All_DTP_2400 All_DTP_2400 { get; set; }
        [Pos(5)]
        public All_AMT_2400 All_AMT_2400 { get; set; }
        [Pos(6)]
        public HCP_LinePricingRepricingInformation_2400 HCP_LinePricingRepricingInformation_2400 { get; set; }
        [ListCount(25)]
        [Pos(7)]
        public List<Loop_2410> Loop_2410 { get; set; }
        [Pos(8)]
        public All_2420 All_2420 { get; set; }
        [ListCount(25)]
        [Pos(9)]
        public List<Loop_2430> Loop_2430 { get; set; }
    }
    
    [Serializable()]
    public class X12_N0
    {
    }
    
    [Serializable()]
    [EdiCodes(",HC,IV,ZZ,")]
    public class X12_ID_235_C003_339758511
    {
    }
    
    [Serializable()]
    [EdiCodes(",AS,B2,B3,B4,CT,DA,DG,DS,EB,MT,NN,OB,OZ,PN,PO,PZ,RB,RR,RT,")]
    public class X12_ID_755_PWK_LineSupplementalInformation_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",AA,AB,AD,AF,AG,BM,EL,EM,FX,")]
    public class X12_ID_756_PWK_LineSupplementalInformation_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",00,01,02,03,04,05,06,07,08,09,10,11,12,13,14,")]
    public class X12_ID_1473_HCP_LinePricingRepricingInformation_2400
    {
    }
    
    [Serializable()]
    [Group(typeof(SVD_ServiceLineAdjudicationInformation_2430))]
    public class Loop_2430
    {
        
        [Required]
        [Pos(1)]
        public SVD_ServiceLineAdjudicationInformation_2430 SVD_ServiceLineAdjudicationInformation_2430 { get; set; }
        [ListCount(99)]
        [Pos(2)]
        public List<CAS_ServiceLineAdjustment_2430> CAS_ServiceLineAdjustment_2430 { get; set; }
        [Pos(3)]
        public DTP_ServiceAdjudicationDate_2430 DTP_ServiceAdjudicationDate_2430 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",CO,CR,OA,PI,PR,")]
    public class X12_ID_1033_CAS_ServiceLineAdjustment_2430
    {
    }
    
    [Serializable()]
    [EdiCodes(",573,")]
    public class X12_ID_374_DTP_ServiceAdjudicationDate_2430
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_ServiceAdjudicationDate_2430
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_ServiceAdjudicationDate_2430), typeof(X12_ID_1250_DTP_ServiceAdjudicationDate_2430))]
    public class DTP_ServiceAdjudicationDate_2430
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ServiceAdjudicationDate_2430))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ServiceAdjudicationDate_2430))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ServiceAdjudicationOrPaymentDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("CAS", typeof(X12_ID_1033_CAS_ServiceLineAdjustment_2430))]
    public class CAS_ServiceLineAdjustment_2430
    {
        
        [Required]
        [DataElement("1033", typeof(X12_ID_1033_CAS_ServiceLineAdjustment_2430))]
        [Pos(1)]
        public string ClaimAdjustmentGroupCode_01 { get; set; }
        [Required]
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AdjustmentReasonCode_02 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string AdjustmentAmount_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string AdjustmentQuantity_04 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string AdjustmentReasonCode_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string AdjustmentAmount_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string AdjustmentQuantity_07 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string AdjustmentReasonCode_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string AdjustmentAmount_09 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string AdjustmentQuantity_10 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string AdjustmentReasonCode_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string AdjustmentAmount_12 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(13)]
        public string AdjustmentQuantity_13 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(14)]
        public string AdjustmentReasonCode_14 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string AdjustmentAmount_15 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(16)]
        public string AdjustmentQuantity_16 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(17)]
        public string AdjustmentReasonCode_17 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(18)]
        public string AdjustmentAmount_18 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(19)]
        public string AdjustmentQuantity_19 { get; set; }
    }
    
    [Serializable()]
    [Segment("SVD")]
    public class SVD_ServiceLineAdjudicationInformation_2430
    {
        
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PayerIdentifier_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ServiceLinePaidAmount_02 { get; set; }
        [Pos(3)]
        public C003_376494356 C003_376494356 { get; set; }
        [Required]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ServiceLineRevenueCode_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string AdjustmentQuantity_05 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(6)]
        public string BundledOrUnbundledLineNumber_06 { get; set; }
    }
    
    [Serializable()]
    [Composite("C003_376494356")]
    public class C003_376494356
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_376494356))]
        [Pos(1)]
        public string ProductOrServiceIDQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ProcedureCodeDescription_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",HC,IV,ZZ,")]
    public class X12_ID_235_C003_376494356
    {
    }
    
    [Serializable()]
    [All()]
    public class All_2420
    {
        
        [Pos(1)]
        public Loop_2420A Loop_2420A { get; set; }
        [Pos(2)]
        public Loop_2420B Loop_2420B { get; set; }
        [Pos(3)]
        public Loop_2420C Loop_2420C { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_OtherProviderName_2420C))]
    public class Loop_2420C
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherProviderName_2420C NM1_OtherProviderName_2420C { get; set; }
        [Pos(2)]
        public REF_OtherProviderSecondaryIdentification_2420C REF_OtherProviderSecondaryIdentification_2420C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",73,")]
    public class X12_ID_98_NM1_OtherProviderName_2420C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_OtherProviderName_2420C
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,SY,X5,")]
    public class X12_ID_128_REF_OtherProviderSecondaryIdentification_2420C
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherProviderSecondaryIdentification_2420C))]
    public class REF_OtherProviderSecondaryIdentification_2420C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherProviderSecondaryIdentification_2420C))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherProviderSecondaryIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherProviderName_2420C), typeof(X12_ID_1065_NM1_OtherProviderName_2420C))]
    public class NM1_OtherProviderName_2420C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherProviderName_2420C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherProviderName_2420C))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OtherPhysicianLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OtherPhysicianFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string OtherProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string OtherProviderNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_OtherProviderName_2420C))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string OtherProviderIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_OtherProviderName_2420C
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_OperatingPhysicianName_2420B))]
    public class Loop_2420B
    {
        
        [Required]
        [Pos(1)]
        public NM1_OperatingPhysicianName_2420B NM1_OperatingPhysicianName_2420B { get; set; }
        [Pos(2)]
        public REF_OperatingPhysicianSecondaryIdentification_2420B REF_OperatingPhysicianSecondaryIdentification_2420B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",72,")]
    public class X12_ID_98_NM1_OperatingPhysicianName_2420B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_OperatingPhysicianName_2420B
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,SY,X5,")]
    public class X12_ID_128_REF_OperatingPhysicianSecondaryIdentification_2420B
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OperatingPhysicianSecondaryIdentification_2420B))]
    public class REF_OperatingPhysicianSecondaryIdentification_2420B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OperatingPhysicianSecondaryIdentification_2420B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OperatingPhysicianSecondaryIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OperatingPhysicianName_2420B), typeof(X12_ID_1065_NM1_OperatingPhysicianName_2420B))]
    public class NM1_OperatingPhysicianName_2420B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OperatingPhysicianName_2420B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OperatingPhysicianName_2420B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OperatingPhysicianLastName_03 { get; set; }
        [Required]
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OperatingPhysicianFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string OperatingPhysicanMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string OperatingPhysicianNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_OperatingPhysicianName_2420B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string OperatingPhysicianPrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_OperatingPhysicianName_2420B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_AttendingPhysicianName_2420A))]
    public class Loop_2420A
    {
        
        [Required]
        [Pos(1)]
        public NM1_AttendingPhysicianName_2420A NM1_AttendingPhysicianName_2420A { get; set; }
        [Pos(2)]
        public REF_AttendingPhysicianSecondaryIdentification_2420A REF_AttendingPhysicianSecondaryIdentification_2420A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",71,")]
    public class X12_ID_98_NM1_AttendingPhysicianName_2420A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_AttendingPhysicianName_2420A
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,SY,X5,")]
    public class X12_ID_128_REF_AttendingPhysicianSecondaryIdentification_2420A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_AttendingPhysicianSecondaryIdentification_2420A))]
    public class REF_AttendingPhysicianSecondaryIdentification_2420A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_AttendingPhysicianSecondaryIdentification_2420A))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string AttendingPhysicianSecondaryIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_AttendingPhysicianName_2420A), typeof(X12_ID_1065_NM1_AttendingPhysicianName_2420A))]
    public class NM1_AttendingPhysicianName_2420A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_AttendingPhysicianName_2420A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_AttendingPhysicianName_2420A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AttendingPhysicianLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string AttendingPhysicianFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string AttendingPhysicianMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string AttendingPhysicianNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_AttendingPhysicianName_2420A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string AttendingPhysicianPrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_AttendingPhysicianName_2420A
    {
    }
    
    [Serializable()]
    [Group(typeof(LIN_DrugIdentification_2410))]
    public class Loop_2410
    {
        
        [Required]
        [Pos(1)]
        public LIN_DrugIdentification_2410 LIN_DrugIdentification_2410 { get; set; }
        [Pos(2)]
        public CTP_DrugPricing_2410 CTP_DrugPricing_2410 { get; set; }
        [Pos(3)]
        public REF_PrescriptionNumber_2410 REF_PrescriptionNumber_2410 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",N4,")]
    public class X12_ID_235_LIN_DrugIdentification_2410
    {
    }
    
    [Serializable()]
    [EdiCodes(",XZ,")]
    public class X12_ID_128_REF_PrescriptionNumber_2410
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PrescriptionNumber_2410))]
    public class REF_PrescriptionNumber_2410
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PrescriptionNumber_2410))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PrescriptionNumber_02 { get; set; }
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
    [Segment("CTP")]
    public class CTP_DrugPricing_2410
    {
        
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(1)]
        public string CTP_01 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string CTP_02 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string DrugUnitPrice_03 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string NationalDrugUnitCount_04 { get; set; }
        [Required]
        [Pos(5)]
        public C001_1932014657 C001_1932014657 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string CTP_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string CTP_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string CTP_08 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string CTP_09 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string CTP_10 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(11)]
        public string CTP_11 { get; set; }
    }
    
    [Serializable()]
    [Composite("C001_1932014657")]
    public class C001_1932014657
    {
        
        [Required]
        [DataElement("355", typeof(X12_ID_355_C001_1932014657))]
        [Pos(1)]
        public string UnitOrBasisForMeasurementCode_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string CTP_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string CTP_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CTP_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string CTP_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string CTP_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string CTP_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string CTP_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string CTP_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string CTP_10 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(11)]
        public string CTP_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string CTP_12 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(13)]
        public string CTP_13 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(14)]
        public string CTP_14 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string CTP_15 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",F2,GR,ML,UN,")]
    public class X12_ID_355_C001_1932014657
    {
    }
    
    [Serializable()]
    [Segment("LIN")]
    public class LIN_DrugIdentification_2410
    {
        
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string LIN_01 { get; set; }
        [Required]
        [DataElement("235", typeof(X12_ID_235_LIN_DrugIdentification_2410))]
        [Pos(2)]
        public string ProductOrServiceIDQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProductOrServiceID_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string LIN_04 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string LIN_05 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string LIN_06 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string LIN_07 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string LIN_08 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string LIN_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string LIN_10 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string LIN_11 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(12)]
        public string LIN_12 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(13)]
        public string LIN_13 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(14)]
        public string LIN_14 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(15)]
        public string LIN_15 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(16)]
        public string LIN_16 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(17)]
        public string LIN_17 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(18)]
        public string LIN_18 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(19)]
        public string LIN_19 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(20)]
        public string LIN_20 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(21)]
        public string LIN_21 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(22)]
        public string LIN_22 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(23)]
        public string LIN_23 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(24)]
        public string LIN_24 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(25)]
        public string LIN_25 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(26)]
        public string LIN_26 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(27)]
        public string LIN_27 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(28)]
        public string LIN_28 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(29)]
        public string LIN_29 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(30)]
        public string LIN_30 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(31)]
        public string LIN_31 { get; set; }
    }
    
    [Serializable()]
    [Segment("HCP", typeof(X12_ID_1473_HCP_LinePricingRepricingInformation_2400))]
    public class HCP_LinePricingRepricingInformation_2400
    {
        
        [Required]
        [DataElement("1473", typeof(X12_ID_1473_HCP_LinePricingRepricingInformation_2400))]
        [Pos(1)]
        public string PricingMethodology_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string RepricedAllowedAmount_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string RepricedSavingAmount_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string RepricedOrganizationalIdentifier_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string RepricingPerDiemOrFlatRateAmount_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string RepricedApprovedAmbulatoryPatientGroupCode_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string RepricedApprovedAmbulatoryPatientGroupAmount_07 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string RepricedApprovedRevenueCode_08 { get; set; }
        [DataElement("235", typeof(X12_ID_235_HCP_LinePricingRepricingInformation_2400))]
        [Pos(9)]
        public string ProductOrServiceIDQualifier_09 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string ProcedureCode_10 { get; set; }
        [DataElement("355", typeof(X12_ID_355_HCP_LinePricingRepricingInformation_2400))]
        [Pos(11)]
        public string UnitOrBasisForMeasurementCode_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string RepricedApprovedServiceUnitCount_12 { get; set; }
        [DataElement("901", typeof(X12_ID_901_HCP_LinePricingRepricingInformation_2400))]
        [Pos(13)]
        public string RejectReasonCode_13 { get; set; }
        [DataElement("1526", typeof(X12_ID_1526_HCP_LinePricingRepricingInformation_2400))]
        [Pos(14)]
        public string PolicyComplianceCode_14 { get; set; }
        [DataElement("1527", typeof(X12_ID_1527_HCP_LinePricingRepricingInformation_2400))]
        [Pos(15)]
        public string ExceptionCode_15 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",HC,")]
    public class X12_ID_235_HCP_LinePricingRepricingInformation_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",DA,UN,")]
    public class X12_ID_355_HCP_LinePricingRepricingInformation_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",T1,T2,T3,T4,T5,T6,")]
    public class X12_ID_901_HCP_LinePricingRepricingInformation_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,")]
    public class X12_ID_1526_HCP_LinePricingRepricingInformation_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,")]
    public class X12_ID_1527_HCP_LinePricingRepricingInformation_2400
    {
    }
    
    [Serializable()]
    [All()]
    public class All_AMT_2400
    {
        
        [Pos(1)]
        public AMT_ServiceTaxAmount_2400 AMT_ServiceTaxAmount_2400 { get; set; }
        [Pos(2)]
        public AMT_FacilityTaxAmount_2400 AMT_FacilityTaxAmount_2400 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",GT,")]
    public class X12_ID_522_AMT_ServiceTaxAmount_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",N8,")]
    public class X12_ID_522_AMT_FacilityTaxAmount_2400
    {
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_FacilityTaxAmount_2400))]
    public class AMT_FacilityTaxAmount_2400
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_FacilityTaxAmount_2400))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string FacilityTaxAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_ServiceTaxAmount_2400))]
    public class AMT_ServiceTaxAmount_2400
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_ServiceTaxAmount_2400))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ServiceTaxAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_DTP_2400
    {
        
        [Pos(1)]
        public DTP_ServiceLineDate_2400 DTP_ServiceLineDate_2400 { get; set; }
        [Pos(2)]
        public DTP_AssessmentDate_2400 DTP_AssessmentDate_2400 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",472,")]
    public class X12_ID_374_DTP_ServiceLineDate_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_ServiceLineDate_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",866,")]
    public class X12_ID_374_DTP_AssessmentDate_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_AssessmentDate_2400
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_AssessmentDate_2400), typeof(X12_ID_1250_DTP_AssessmentDate_2400))]
    public class DTP_AssessmentDate_2400
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_AssessmentDate_2400))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_AssessmentDate_2400))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AssessmentDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_ServiceLineDate_2400), typeof(X12_ID_1250_DTP_ServiceLineDate_2400))]
    public class DTP_ServiceLineDate_2400
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ServiceLineDate_2400))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ServiceLineDate_2400))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ServiceDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("PWK", typeof(X12_ID_755_PWK_LineSupplementalInformation_2400), typeof(X12_ID_756_PWK_LineSupplementalInformation_2400))]
    public class PWK_LineSupplementalInformation_2400
    {
        
        [Required]
        [DataElement("755", typeof(X12_ID_755_PWK_LineSupplementalInformation_2400))]
        [Pos(1)]
        public string AttachmentReportTypeCode_01 { get; set; }
        [Required]
        [DataElement("756", typeof(X12_ID_756_PWK_LineSupplementalInformation_2400))]
        [Pos(2)]
        public string AttachmentTransmissionCode_02 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(3)]
        public string PWK_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string PWK_04 { get; set; }
        [DataElement("66", typeof(X12_ID_66_PWK_LineSupplementalInformation_2400))]
        [Pos(5)]
        public string IdentificationCodeQualifier_05 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string AttachmentControlNumber_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string PWK_07 { get; set; }
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
    public class X12_ID_66_PWK_LineSupplementalInformation_2400
    {
    }
    
    [Serializable()]
    [Segment("SV2")]
    public class SV2_InstitutionalServiceLine_2400
    {
        
        [Required]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ServiceLineRevenueCode_01 { get; set; }
        [Pos(2)]
        public C003_339758511 C003_339758511 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string LineItemChargeAmount_03 { get; set; }
        [Required]
        [DataElement("355", typeof(X12_ID_355_SV2_InstitutionalServiceLine_2400))]
        [Pos(4)]
        public string UnitOrBasisForMeasurementCode_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ServiceUnitCount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ServiceLineRate_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string LineItemDeniedChargeOrNonCoveredChargeAmount_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string SV2_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string SV2_09 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string SV2_10 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DA,F2,UN,")]
    public class X12_ID_355_SV2_InstitutionalServiceLine_2400
    {
    }
    
    [Serializable()]
    [Composite("C003_339758511")]
    public class C003_339758511
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_339758511))]
        [Pos(1)]
        public string ProductOrServiceIDQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string SV2_07 { get; set; }
    }
    
    [Serializable()]
    [Segment("LX")]
    public class LX_ServiceLineNumber_2400
    {
        
        [Required]
        [DataElement("", typeof(X12_N0))]
        [Pos(1)]
        public string AssignedNumber_01 { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(SBR_OtherSubscriberInformation_2320))]
    public class Loop_2320
    {
        
        [Required]
        [Pos(1)]
        public SBR_OtherSubscriberInformation_2320 SBR_OtherSubscriberInformation_2320 { get; set; }
        [ListCount(5)]
        [Pos(2)]
        public List<CAS_ClaimLevelAdjustment_2320> CAS_ClaimLevelAdjustment_2320 { get; set; }
        [Pos(3)]
        public All_AMT_2320 All_AMT_2320 { get; set; }
        [Pos(4)]
        public DMG_OtherSubscriberDemographicInformation_2320 DMG_OtherSubscriberDemographicInformation_2320 { get; set; }
        [Required]
        [Pos(5)]
        public OI_OtherInsuranceCoverageInformation_2320 OI_OtherInsuranceCoverageInformation_2320 { get; set; }
        [Pos(6)]
        public MIA_MedicareInpatientAdjudicationInformation_2320 MIA_MedicareInpatientAdjudicationInformation_2320 { get; set; }
        [Pos(7)]
        public MOA_MedicareOutpatientAdjudicationInformation_2320 MOA_MedicareOutpatientAdjudicationInformation_2320 { get; set; }
        [Required]
        [Pos(8)]
        public All_2330 All_2330 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",P,S,T,")]
    public class X12_ID_1138_SBR_OtherSubscriberInformation_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,04,05,07,10,15,17,18,19,20,21,22,23,24,29,32,33,36,39,40,41,43,53,G8,")]
    public class X12_ID_1069_SBR_OtherSubscriberInformation_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",CO,CR,OA,PI,PR,")]
    public class X12_ID_1033_CAS_ClaimLevelAdjustment_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_OtherSubscriberDemographicInformation_2320
    {
    }
    
    [Serializable()]
    [All()]
    public class All_2330
    {
        
        [Required]
        [Pos(1)]
        public Loop_2330A Loop_2330A { get; set; }
        [Required]
        [Pos(2)]
        public Loop_2330B Loop_2330B { get; set; }
        [Pos(3)]
        public Loop_2330C Loop_2330C { get; set; }
        [Pos(4)]
        public Loop_2330D Loop_2330D { get; set; }
        [Pos(5)]
        public Loop_2330E Loop_2330E { get; set; }
        [Pos(6)]
        public Loop_2330F Loop_2330F { get; set; }
        [Pos(7)]
        public Loop_2330H Loop_2330H { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_OtherPayerServiceFacilityProvider_2330H))]
    public class Loop_2330H
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerServiceFacilityProvider_2330H NM1_OtherPayerServiceFacilityProvider_2330H { get; set; }
        [Required]
        [ListCount(3)]
        [Pos(2)]
        public List<REF_OtherPayerServiceFacilityProviderIdentification_2330H> REF_OtherPayerServiceFacilityProviderIdentification_2330H { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",FA,")]
    public class X12_ID_98_NM1_OtherPayerServiceFacilityProvider_2330H
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_OtherPayerServiceFacilityProvider_2330H
    {
    }
    
    [Serializable()]
    [EdiCodes(",1B,1C,1D,EI,G2,LU,N5,")]
    public class X12_ID_128_REF_OtherPayerServiceFacilityProviderIdentification_2330H
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerServiceFacilityProviderIdentification_2330H))]
    public class REF_OtherPayerServiceFacilityProviderIdentification_2330H
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerServiceFacilityProviderIdentification_2330H))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerServiceFacilityProviderIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerServiceFacilityProvider_2330H), typeof(X12_ID_1065_NM1_OtherPayerServiceFacilityProvider_2330H))]
    public class NM1_OtherPayerServiceFacilityProvider_2330H
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerServiceFacilityProvider_2330H))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerServiceFacilityProvider_2330H))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string NM1_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string NM1_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string NM1_09 { get; set; }
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
    [Group(typeof(NM1_OtherPayerOtherProvider_2330F))]
    public class Loop_2330F
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerOtherProvider_2330F NM1_OtherPayerOtherProvider_2330F { get; set; }
        [Required]
        [ListCount(3)]
        [Pos(2)]
        public List<REF_OtherPayerOtherProviderIdentification_2330F> REF_OtherPayerOtherProviderIdentification_2330F { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",73,")]
    public class X12_ID_98_NM1_OtherPayerOtherProvider_2330F
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_OtherPayerOtherProvider_2330F
    {
    }
    
    [Serializable()]
    [EdiCodes(",1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,SY,")]
    public class X12_ID_128_REF_OtherPayerOtherProviderIdentification_2330F
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerOtherProviderIdentification_2330F))]
    public class REF_OtherPayerOtherProviderIdentification_2330F
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerOtherProviderIdentification_2330F))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerOtherProviderIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerOtherProvider_2330F), typeof(X12_ID_1065_NM1_OtherPayerOtherProvider_2330F))]
    public class NM1_OtherPayerOtherProvider_2330F
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerOtherProvider_2330F))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerOtherProvider_2330F))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string NM1_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string NM1_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string NM1_09 { get; set; }
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
    [Group(typeof(NM1_OtherPayerOperatingProvider_2330E))]
    public class Loop_2330E
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerOperatingProvider_2330E NM1_OtherPayerOperatingProvider_2330E { get; set; }
        [Required]
        [ListCount(3)]
        [Pos(2)]
        public List<REF_OtherPayerOperatingProviderIdentification_2330E> REF_OtherPayerOperatingProviderIdentification_2330E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",72,")]
    public class X12_ID_98_NM1_OtherPayerOperatingProvider_2330E
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_OtherPayerOperatingProvider_2330E
    {
    }
    
    [Serializable()]
    [EdiCodes(",1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,")]
    public class X12_ID_128_REF_OtherPayerOperatingProviderIdentification_2330E
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerOperatingProviderIdentification_2330E))]
    public class REF_OtherPayerOperatingProviderIdentification_2330E
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerOperatingProviderIdentification_2330E))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerOperatingProviderIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerOperatingProvider_2330E), typeof(X12_ID_1065_NM1_OtherPayerOperatingProvider_2330E))]
    public class NM1_OtherPayerOperatingProvider_2330E
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerOperatingProvider_2330E))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerOperatingProvider_2330E))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string NM1_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string NM1_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string NM1_09 { get; set; }
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
    [Group(typeof(NM1_OtherPayerAttendingProvider_2330D))]
    public class Loop_2330D
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerAttendingProvider_2330D NM1_OtherPayerAttendingProvider_2330D { get; set; }
        [Required]
        [ListCount(3)]
        [Pos(2)]
        public List<REF_OtherPayerAttendingProviderIdentification_2330D> REF_OtherPayerAttendingProviderIdentification_2330D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",71,")]
    public class X12_ID_98_NM1_OtherPayerAttendingProvider_2330D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_OtherPayerAttendingProvider_2330D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,")]
    public class X12_ID_128_REF_OtherPayerAttendingProviderIdentification_2330D
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerAttendingProviderIdentification_2330D))]
    public class REF_OtherPayerAttendingProviderIdentification_2330D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerAttendingProviderIdentification_2330D))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerAttendingProviderIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerAttendingProvider_2330D), typeof(X12_ID_1065_NM1_OtherPayerAttendingProvider_2330D))]
    public class NM1_OtherPayerAttendingProvider_2330D
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerAttendingProvider_2330D))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerAttendingProvider_2330D))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string NM1_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string NM1_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string NM1_09 { get; set; }
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
    [Group(typeof(NM1_OtherPayerPatientInformation_2330C))]
    public class Loop_2330C
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerPatientInformation_2330C NM1_OtherPayerPatientInformation_2330C { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<REF_OtherPayerPatientIdentificationNumber_2330C> REF_OtherPayerPatientIdentificationNumber_2330C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",QC,")]
    public class X12_ID_98_NM1_OtherPayerPatientInformation_2330C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_OtherPayerPatientInformation_2330C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1W,IG,SY,")]
    public class X12_ID_128_REF_OtherPayerPatientIdentificationNumber_2330C
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerPatientIdentificationNumber_2330C))]
    public class REF_OtherPayerPatientIdentificationNumber_2330C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerPatientIdentificationNumber_2330C))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerPatientSecondaryIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerPatientInformation_2330C), typeof(X12_ID_1065_NM1_OtherPayerPatientInformation_2330C))]
    public class NM1_OtherPayerPatientInformation_2330C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerPatientInformation_2330C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerPatientInformation_2330C))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string NM1_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_OtherPayerPatientInformation_2330C))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string OtherPayerPatientPrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",EI,MI,")]
    public class X12_ID_66_NM1_OtherPayerPatientInformation_2330C
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_OtherPayerName_2330B))]
    public class Loop_2330B
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerName_2330B NM1_OtherPayerName_2330B { get; set; }
        [Pos(2)]
        public N3_OtherPayerAddress_2330B N3_OtherPayerAddress_2330B { get; set; }
        [Pos(3)]
        public N4_OtherPayerCityStateZIPCode_2330B N4_OtherPayerCityStateZIPCode_2330B { get; set; }
        [Pos(4)]
        public DTP_ClaimAdjudicationDate_2330B DTP_ClaimAdjudicationDate_2330B { get; set; }
        [Pos(5)]
        public All_REF_2330B All_REF_2330B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_NM1_OtherPayerName_2330B
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_OtherPayerName_2330B
    {
    }
    
    [Serializable()]
    [EdiCodes(",573,")]
    public class X12_ID_374_DTP_ClaimAdjudicationDate_2330B
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_ClaimAdjudicationDate_2330B
    {
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2330B
    {
        
        [ListCount(2)]
        [Pos(1)]
        public List<REF_OtherPayerSecondaryIdentificationAndReferenceNumber_2330B> REF_OtherPayerSecondaryIdentificationAndReferenceNumber_2330B { get; set; }
        [Pos(2)]
        public REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",2U,F8,FY,NF,TJ,")]
    public class X12_ID_128_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_2330B
    {
    }
    
    [Serializable()]
    [EdiCodes(",9F,G1,")]
    public class X12_ID_128_REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B))]
    public class REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerPriorAuthorizationOrReferralNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_2330B))]
    public class REF_OtherPayerSecondaryIdentificationAndReferenceNumber_2330B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_2330B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerSecondaryIdentifier_02 { get; set; }
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
    [Segment("DTP", typeof(X12_ID_374_DTP_ClaimAdjudicationDate_2330B), typeof(X12_ID_1250_DTP_ClaimAdjudicationDate_2330B))]
    public class DTP_ClaimAdjudicationDate_2330B
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ClaimAdjudicationDate_2330B))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ClaimAdjudicationDate_2330B))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AdjudicationOrPaymentDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_OtherPayerCityStateZIPCode_2330B
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string OtherPayerCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string OtherPayerStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string OtherPayerPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_OtherPayerAddress_2330B
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string OtherPayerAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerName_2330B), typeof(X12_ID_1065_NM1_OtherPayerName_2330B))]
    public class NM1_OtherPayerName_2330B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerName_2330B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerName_2330B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OtherPayerLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_OtherPayerName_2330B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string OtherPayerPrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",PI,XV,")]
    public class X12_ID_66_NM1_OtherPayerName_2330B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_OtherSubscriberName_2330A))]
    public class Loop_2330A
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherSubscriberName_2330A NM1_OtherSubscriberName_2330A { get; set; }
        [Pos(2)]
        public N3_OtherSubscriberAddress_2330A N3_OtherSubscriberAddress_2330A { get; set; }
        [Pos(3)]
        public N4_OtherSubscriberCityStateZIPCode_2330A N4_OtherSubscriberCityStateZIPCode_2330A { get; set; }
        [ListCount(3)]
        [Pos(4)]
        public List<REF_OtherSubscriberSecondaryInformation_2330A> REF_OtherSubscriberSecondaryInformation_2330A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",IL,")]
    public class X12_ID_98_NM1_OtherSubscriberName_2330A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_OtherSubscriberName_2330A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1W,23,IG,SY,")]
    public class X12_ID_128_REF_OtherSubscriberSecondaryInformation_2330A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherSubscriberSecondaryInformation_2330A))]
    public class REF_OtherSubscriberSecondaryInformation_2330A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherSubscriberSecondaryInformation_2330A))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherInsuredAdditionalIdentifier_02 { get; set; }
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
    [Segment("N4")]
    public class N4_OtherSubscriberCityStateZIPCode_2330A
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string OtherInsuredCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string OtherInsuredStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string OtherInsuredPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_OtherSubscriberAddress_2330A
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string OtherInsuredAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherInsuredAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherSubscriberName_2330A), typeof(X12_ID_1065_NM1_OtherSubscriberName_2330A))]
    public class NM1_OtherSubscriberName_2330A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherSubscriberName_2330A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherSubscriberName_2330A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OtherInsuredLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OtherInsuredFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string OtherInsuredMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string OtherInsuredNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_OtherSubscriberName_2330A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string OtherInsuredIdentifier_09 { get; set; }
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
    public class X12_ID_66_NM1_OtherSubscriberName_2330A
    {
    }
    
    [Serializable()]
    [Segment("MOA")]
    public class MOA_MedicareOutpatientAdjudicationInformation_2320
    {
        
        [DataElement("", typeof(X12_R))]
        [Pos(1)]
        public string ReimbursementRate_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ClaimHCPCSPayableAmount_02 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string RemarkCode_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string RemarkCode_04 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string RemarkCode_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string RemarkCode_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string RemarkCode_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string ClaimESRDPaymentAmount_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string NonpayableProfessionalComponentAmount_09 { get; set; }
    }
    
    [Serializable()]
    [Segment("MIA")]
    public class MIA_MedicareInpatientAdjudicationInformation_2320
    {
        
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(1)]
        public string CoveredDaysOrVisitsCount_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string LifetimeReserveDaysCount_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string LifetimePsychiatricDaysCount_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string ClaimDRGAmount_04 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string RemarkCode_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ClaimDisproportionateShareAmount_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string ClaimMSPPassthroughAmount_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string ClaimPPSCapitalAmount_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string PPSCapitalFSPDRGAmount_09 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string PPSCapitalHSPDRGAmount_10 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(11)]
        public string PPSCapitalDSHDRGAmount_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string OldCapitalAmount_12 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(13)]
        public string PPSCapitalIMEAmount_13 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(14)]
        public string PPSOperatingHospitalSpecificDRGAmount_14 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string CostReportDayCount_15 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(16)]
        public string PPSOperatingFederalSpecificDRGAmount_16 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(17)]
        public string ClaimPPSCapitalOutlierAmount_17 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(18)]
        public string ClaimIndirectTeachingAmount_18 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(19)]
        public string NonpayableProfessionalComponentAmount_19 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(20)]
        public string RemarkCode_20 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(21)]
        public string RemarkCode_21 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(22)]
        public string RemarkCode_22 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(23)]
        public string RemarkCode_23 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(24)]
        public string PPSCapitalExceptionAmount_24 { get; set; }
    }
    
    [Serializable()]
    [Segment("OI")]
    public class OI_OtherInsuranceCoverageInformation_2320
    {
        
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(1)]
        public string OI_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string OI_02 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_OI_OtherInsuranceCoverageInformation_2320))]
        [Pos(3)]
        public string BenefitsAssignmentCertificationIndicator_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string OI_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string OI_05 { get; set; }
        [Required]
        [DataElement("1363", typeof(X12_ID_1363_OI_OtherInsuranceCoverageInformation_2320))]
        [Pos(6)]
        public string ReleaseOfInformationCode_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_OI_OtherInsuranceCoverageInformation_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,I,M,N,O,Y,")]
    public class X12_ID_1363_OI_OtherInsuranceCoverageInformation_2320
    {
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_OtherSubscriberDemographicInformation_2320))]
    public class DMG_OtherSubscriberDemographicInformation_2320
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_OtherSubscriberDemographicInformation_2320))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherInsuredBirthDate_02 { get; set; }
        [Required]
        [DataElement("1068", typeof(X12_ID_1068_DMG_OtherSubscriberDemographicInformation_2320))]
        [Pos(3)]
        public string OtherInsuredGenderCode_03 { get; set; }
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
    public class X12_ID_1068_DMG_OtherSubscriberDemographicInformation_2320
    {
    }
    
    [Serializable()]
    [All()]
    public class All_AMT_2320
    {
        
        [Pos(1)]
        public AMT_PayerPriorPayment_2320 AMT_PayerPriorPayment_2320 { get; set; }
        [Pos(2)]
        public AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_2320 AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_2320 { get; set; }
        [Pos(3)]
        public AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_2320 AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_2320 { get; set; }
        [Pos(4)]
        public AMT_DiagnosticRelatedGroupDRGOutlierAmount_2320 AMT_DiagnosticRelatedGroupDRGOutlierAmount_2320 { get; set; }
        [Pos(5)]
        public AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_2320 AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_2320 { get; set; }
        [Pos(6)]
        public AMT_MedicarePaidAmount100_2320 AMT_MedicarePaidAmount100_2320 { get; set; }
        [Pos(7)]
        public AMT_MedicarePaidAmount80_2320 AMT_MedicarePaidAmount80_2320 { get; set; }
        [Pos(8)]
        public AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_2320 AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_2320 { get; set; }
        [Pos(9)]
        public AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_2320 AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_2320 { get; set; }
        [Pos(10)]
        public AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_2320 AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_2320 { get; set; }
        [Pos(11)]
        public AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_2320 AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_2320 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",C4,")]
    public class X12_ID_522_AMT_PayerPriorPayment_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",B6,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",T3,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_522_AMT_DiagnosticRelatedGroupDRGOutlierAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",N1,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",KF,")]
    public class X12_ID_522_AMT_MedicarePaidAmount100_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",PG,")]
    public class X12_ID_522_AMT_MedicarePaidAmount80_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",AA,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",B1,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",A8,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",YT,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_2320
    {
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ClaimTotalDeniedChargeAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string NonCoveredChargeAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string PaidFromPartBMedicareTrustFundAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string PaidFromPartAMedicareTrustFundAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_MedicarePaidAmount80_2320))]
    public class AMT_MedicarePaidAmount80_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_MedicarePaidAmount80_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string MedicarePaidAt80Amount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_MedicarePaidAmount100_2320))]
    public class AMT_MedicarePaidAmount100_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_MedicarePaidAmount100_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string MedicarePaidAt100Amount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string TotalMedicarePaidAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_DiagnosticRelatedGroupDRGOutlierAmount_2320))]
    public class AMT_DiagnosticRelatedGroupDRGOutlierAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_DiagnosticRelatedGroupDRGOutlierAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ClaimDRGOutlierAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_2320))]
    public class AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string CoordinationOfBenefitsTotalSubmittedChargeAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string AllowedAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_PayerPriorPayment_2320))]
    public class AMT_PayerPriorPayment_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_PayerPriorPayment_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string OtherPayerPatientPaidAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("CAS", typeof(X12_ID_1033_CAS_ClaimLevelAdjustment_2320))]
    public class CAS_ClaimLevelAdjustment_2320
    {
        
        [Required]
        [DataElement("1033", typeof(X12_ID_1033_CAS_ClaimLevelAdjustment_2320))]
        [Pos(1)]
        public string ClaimAdjustmentGroupCode_01 { get; set; }
        [Required]
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AdjustmentReasonCode_02 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string AdjustmentAmount_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string AdjustmentQuantity_04 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string AdjustmentReasonCode_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string AdjustmentAmount_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string AdjustmentQuantity_07 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string AdjustmentReasonCode_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string AdjustmentAmount_09 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string AdjustmentQuantity_10 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string AdjustmentReasonCode_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string AdjustmentAmount_12 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(13)]
        public string AdjustmentQuantity_13 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(14)]
        public string AdjustmentReasonCode_14 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string AdjustmentAmount_15 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(16)]
        public string AdjustmentQuantity_16 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_ID))]
        [Pos(17)]
        public string AdjustmentReasonCode_17 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(18)]
        public string AdjustmentAmount_18 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(19)]
        public string AdjustmentQuantity_19 { get; set; }
    }
    
    [Serializable()]
    [Segment("SBR", typeof(X12_ID_1138_SBR_OtherSubscriberInformation_2320), typeof(X12_ID_1069_SBR_OtherSubscriberInformation_2320))]
    public class SBR_OtherSubscriberInformation_2320
    {
        
        [Required]
        [DataElement("1138", typeof(X12_ID_1138_SBR_OtherSubscriberInformation_2320))]
        [Pos(1)]
        public string PayerResponsibilitySequenceNumberCode_01 { get; set; }
        [Required]
        [DataElement("1069", typeof(X12_ID_1069_SBR_OtherSubscriberInformation_2320))]
        [Pos(2)]
        public string IndividualRelationshipCode_02 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string InsuredGroupOrPolicyNumber_03 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OtherInsuredGroupName_04 { get; set; }
        [StringLength(1, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string SBR_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string SBR_06 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string SBR_07 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string SBR_08 { get; set; }
        [DataElement("1032", typeof(X12_ID_1032_SBR_OtherSubscriberInformation_2320))]
        [Pos(9)]
        public string ClaimFilingIndicatorCode_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",09,10,11,12,13,14,15,16,AM,BL,CH,CI,DS,HM,LI,LM,MA,MB,MC,OF,TV,VA,WC,ZZ,")]
    public class X12_ID_1032_SBR_OtherSubscriberInformation_2320
    {
    }
    
    [Serializable()]
    [All()]
    public class All_2310
    {
        
        [Pos(1)]
        public Loop_2310A Loop_2310A { get; set; }
        [Pos(2)]
        public Loop_2310B Loop_2310B { get; set; }
        [Pos(3)]
        public Loop_2310C Loop_2310C { get; set; }
        [Pos(4)]
        public Loop_2310E Loop_2310E { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_ServiceFacilityName_2310E))]
    public class Loop_2310E
    {
        
        [Required]
        [Pos(1)]
        public NM1_ServiceFacilityName_2310E NM1_ServiceFacilityName_2310E { get; set; }
        [Required]
        [Pos(2)]
        public N3_ServiceFacilityAddress_2310E N3_ServiceFacilityAddress_2310E { get; set; }
        [Required]
        [Pos(3)]
        public N4_ServiceFacilityCityStateZipCode_2310E N4_ServiceFacilityCityStateZipCode_2310E { get; set; }
        [ListCount(5)]
        [Pos(4)]
        public List<REF_ServiceFacilitySecondaryIdentification_2310E> REF_ServiceFacilitySecondaryIdentification_2310E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",FA,")]
    public class X12_ID_98_NM1_ServiceFacilityName_2310E
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_ServiceFacilityName_2310E
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,1J,EI,FH,G2,G5,LU,N5,X5,")]
    public class X12_ID_128_REF_ServiceFacilitySecondaryIdentification_2310E
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_ServiceFacilitySecondaryIdentification_2310E))]
    public class REF_ServiceFacilitySecondaryIdentification_2310E
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ServiceFacilitySecondaryIdentification_2310E))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string LaboratoryOrFacilitySecondaryIdentifier_02 { get; set; }
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
    [Segment("N4")]
    public class N4_ServiceFacilityCityStateZipCode_2310E
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string LaboratoryOrFacilityCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string LaboratoryOrFacilityStateOrProvinceCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string LaboratoryOrFacilityPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_ServiceFacilityAddress_2310E
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string LaboratoryOrFacilityAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string LaboratoryOrFacilityAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_ServiceFacilityName_2310E), typeof(X12_ID_1065_NM1_ServiceFacilityName_2310E))]
    public class NM1_ServiceFacilityName_2310E
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ServiceFacilityName_2310E))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ServiceFacilityName_2310E))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string LaboratoryOrFacilityName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_ServiceFacilityName_2310E))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string LaboratoryOrFacilityPrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_ServiceFacilityName_2310E
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_OtherProviderName_2310C))]
    public class Loop_2310C
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherProviderName_2310C NM1_OtherProviderName_2310C { get; set; }
        [ListCount(5)]
        [Pos(2)]
        public List<REF_OtherProviderSecondaryIdentification_2310C> REF_OtherProviderSecondaryIdentification_2310C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",73,")]
    public class X12_ID_98_NM1_OtherProviderName_2310C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_OtherProviderName_2310C
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,SY,X5,")]
    public class X12_ID_128_REF_OtherProviderSecondaryIdentification_2310C
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherProviderSecondaryIdentification_2310C))]
    public class REF_OtherProviderSecondaryIdentification_2310C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherProviderSecondaryIdentification_2310C))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherProviderSecondaryIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherProviderName_2310C), typeof(X12_ID_1065_NM1_OtherProviderName_2310C))]
    public class NM1_OtherProviderName_2310C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherProviderName_2310C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherProviderName_2310C))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OtherPhysicianLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OtherPhysicianFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string OtherProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string OtherProviderNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_OtherProviderName_2310C))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string OtherPhysicianIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_OtherProviderName_2310C
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_OperatingPhysicianName_2310B))]
    public class Loop_2310B
    {
        
        [Required]
        [Pos(1)]
        public NM1_OperatingPhysicianName_2310B NM1_OperatingPhysicianName_2310B { get; set; }
        [ListCount(5)]
        [Pos(2)]
        public List<REF_OperatingPhysicianSecondaryIdentification_2310B> REF_OperatingPhysicianSecondaryIdentification_2310B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",72,")]
    public class X12_ID_98_NM1_OperatingPhysicianName_2310B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_OperatingPhysicianName_2310B
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,SY,X5,")]
    public class X12_ID_128_REF_OperatingPhysicianSecondaryIdentification_2310B
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OperatingPhysicianSecondaryIdentification_2310B))]
    public class REF_OperatingPhysicianSecondaryIdentification_2310B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OperatingPhysicianSecondaryIdentification_2310B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OperatingPhysicianSecondaryIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OperatingPhysicianName_2310B), typeof(X12_ID_1065_NM1_OperatingPhysicianName_2310B))]
    public class NM1_OperatingPhysicianName_2310B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OperatingPhysicianName_2310B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OperatingPhysicianName_2310B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OperatingPhysicianLastName_03 { get; set; }
        [Required]
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OperatingPhysicianFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string OperatingPhysicanMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string OperatingPhysicianNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_OperatingPhysicianName_2310B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string OperatingPhysicianPrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_OperatingPhysicianName_2310B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_AttendingPhysicianName_2310A))]
    public class Loop_2310A
    {
        
        [Required]
        [Pos(1)]
        public NM1_AttendingPhysicianName_2310A NM1_AttendingPhysicianName_2310A { get; set; }
        [Pos(2)]
        public PRV_AttendingPhysicianSpecialtyInformation_2310A PRV_AttendingPhysicianSpecialtyInformation_2310A { get; set; }
        [ListCount(5)]
        [Pos(3)]
        public List<REF_AttendingPhysicianSecondaryIdentification_2310A> REF_AttendingPhysicianSecondaryIdentification_2310A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",71,")]
    public class X12_ID_98_NM1_AttendingPhysicianName_2310A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_AttendingPhysicianName_2310A
    {
    }
    
    [Serializable()]
    [EdiCodes(",AT,SU,")]
    public class X12_ID_1221_PRV_AttendingPhysicianSpecialtyInformation_2310A
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_AttendingPhysicianSpecialtyInformation_2310A
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,EI,G2,LU,N5,SY,X5,")]
    public class X12_ID_128_REF_AttendingPhysicianSecondaryIdentification_2310A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_AttendingPhysicianSecondaryIdentification_2310A))]
    public class REF_AttendingPhysicianSecondaryIdentification_2310A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_AttendingPhysicianSecondaryIdentification_2310A))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string AttendingPhysicianSecondaryIdentifier_02 { get; set; }
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
    [Segment("PRV", typeof(X12_ID_1221_PRV_AttendingPhysicianSpecialtyInformation_2310A), typeof(X12_ID_128_PRV_AttendingPhysicianSpecialtyInformation_2310A))]
    public class PRV_AttendingPhysicianSpecialtyInformation_2310A
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_AttendingPhysicianSpecialtyInformation_2310A))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_AttendingPhysicianSpecialtyInformation_2310A))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_AttendingPhysicianName_2310A), typeof(X12_ID_1065_NM1_AttendingPhysicianName_2310A))]
    public class NM1_AttendingPhysicianName_2310A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_AttendingPhysicianName_2310A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_AttendingPhysicianName_2310A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AttendingPhysicianLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string AttendingPhysicianFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string AttendingPhysicianMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string AttendingPhysicianNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_AttendingPhysicianName_2310A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string AttendingPhysicianPrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_AttendingPhysicianName_2310A
    {
    }
    
    [Serializable()]
    [Group(typeof(CR7_HomeHealthCarePlanInformation_2305))]
    public class Loop_2305
    {
        
        [Required]
        [Pos(1)]
        public CR7_HomeHealthCarePlanInformation_2305 CR7_HomeHealthCarePlanInformation_2305 { get; set; }
        [ListCount(12)]
        [Pos(2)]
        public List<HSD_HealthCareServicesDelivery_2305> HSD_HealthCareServicesDelivery_2305 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AI,MS,OT,PT,SN,ST,")]
    public class X12_ID_921_CR7_HomeHealthCarePlanInformation_2305
    {
    }
    
    [Serializable()]
    [EdiCodes(",VS,")]
    public class X12_ID_673_HSD_HealthCareServicesDelivery_2305
    {
    }
    
    [Serializable()]
    [Segment("HSD", typeof(X12_ID_673_HSD_HealthCareServicesDelivery_2305))]
    public class HSD_HealthCareServicesDelivery_2305
    {
        
        [DataElement("673", typeof(X12_ID_673_HSD_HealthCareServicesDelivery_2305))]
        [Pos(1)]
        public string Visits_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string NumberOfVisits_02 { get; set; }
        [DataElement("355", typeof(X12_ID_355_HSD_HealthCareServicesDelivery_2305))]
        [Pos(3)]
        public string FrequencyPeriod_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string FrequencyCount_04 { get; set; }
        [DataElement("615", typeof(X12_ID_615_HSD_HealthCareServicesDelivery_2305))]
        [Pos(5)]
        public string DurationOfVisitsUnits_05 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(6)]
        public string DurationOfVisitsNumberOfUnits_06 { get; set; }
        [DataElement("678", typeof(X12_ID_678_HSD_HealthCareServicesDelivery_2305))]
        [Pos(7)]
        public string ShipDeliveryOrCalendarPatternCode_07 { get; set; }
        [DataElement("679", typeof(X12_ID_679_HSD_HealthCareServicesDelivery_2305))]
        [Pos(8)]
        public string DeliveryPatternTimeCode_08 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DA,MO,Q1,WK,")]
    public class X12_ID_355_HSD_HealthCareServicesDelivery_2305
    {
    }
    
    [Serializable()]
    [EdiCodes(",7,35,")]
    public class X12_ID_615_HSD_HealthCareServicesDelivery_2305
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,N,O,S,W,")]
    public class X12_ID_678_HSD_HealthCareServicesDelivery_2305
    {
    }
    
    [Serializable()]
    [EdiCodes(",D,E,F,")]
    public class X12_ID_679_HSD_HealthCareServicesDelivery_2305
    {
    }
    
    [Serializable()]
    [Segment("CR7", typeof(X12_ID_921_CR7_HomeHealthCarePlanInformation_2305))]
    public class CR7_HomeHealthCarePlanInformation_2305
    {
        
        [Required]
        [DataElement("921", typeof(X12_ID_921_CR7_HomeHealthCarePlanInformation_2305))]
        [Pos(1)]
        public string DisciplineTypeCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_N0))]
        [Pos(2)]
        public string VisitsPriorToRecertificationDateCount_02 { get; set; }
        [Required]
        [DataElement("", typeof(X12_N0))]
        [Pos(3)]
        public string TotalVisitsProjectedThisCertificationCount_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("HCP", typeof(X12_ID_1473_HCP_ClaimPricingRepricingInformation_2300))]
    public class HCP_ClaimPricingRepricingInformation_2300
    {
        
        [Required]
        [DataElement("1473", typeof(X12_ID_1473_HCP_ClaimPricingRepricingInformation_2300))]
        [Pos(1)]
        public string PricingMethodology_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string RepricedAllowedAmount_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string RepricedSavingAmount_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string RepricingOrganizationIdentifier_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string RepricingPerDiemOrFlatRateAmount_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string RepricedApprovedDRGCode_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string RepricedApprovedAmount_07 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string RepricedApprovedRevenueCode_08 { get; set; }
        [DataElement("235", typeof(X12_ID_235_HCP_ClaimPricingRepricingInformation_2300))]
        [Pos(9)]
        public string ProductOrServiceIDQualifier_09 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string RepricedApprovedHCPCSCode_10 { get; set; }
        [DataElement("355", typeof(X12_ID_355_HCP_ClaimPricingRepricingInformation_2300))]
        [Pos(11)]
        public string UnitOrBasisForMeasurementCode_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string RepricedApprovedServiceUnitCount_12 { get; set; }
        [DataElement("901", typeof(X12_ID_901_HCP_ClaimPricingRepricingInformation_2300))]
        [Pos(13)]
        public string RejectReasonCode_13 { get; set; }
        [DataElement("1526", typeof(X12_ID_1526_HCP_ClaimPricingRepricingInformation_2300))]
        [Pos(14)]
        public string PolicyComplianceCode_14 { get; set; }
        [DataElement("1527", typeof(X12_ID_1527_HCP_ClaimPricingRepricingInformation_2300))]
        [Pos(15)]
        public string ExceptionCode_15 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",HC,")]
    public class X12_ID_235_HCP_ClaimPricingRepricingInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",DA,UN,")]
    public class X12_ID_355_HCP_ClaimPricingRepricingInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",T1,T2,T3,T4,T5,T6,")]
    public class X12_ID_901_HCP_ClaimPricingRepricingInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,")]
    public class X12_ID_1526_HCP_ClaimPricingRepricingInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,")]
    public class X12_ID_1527_HCP_ClaimPricingRepricingInformation_2300
    {
    }
    
    [Serializable()]
    [Segment("QTY", typeof(X12_ID_673_QTY_ClaimQuantity_2300))]
    public class QTY_ClaimQuantity_2300
    {
        
        [Required]
        [DataElement("673", typeof(X12_ID_673_QTY_ClaimQuantity_2300))]
        [Pos(1)]
        public string QuantityQualifier_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ClaimDaysCount_02 { get; set; }
        [Required]
        [Pos(3)]
        public C001_761255531 C001_761255531 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string QTY_04 { get; set; }
    }
    
    [Serializable()]
    [Composite("C001_761255531")]
    public class C001_761255531
    {
        
        [Required]
        [DataElement("355", typeof(X12_ID_355_C001_761255531))]
        [Pos(1)]
        public string UnitOrBasisForMeasurementCode_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string QTY_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string QTY_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string QTY_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string QTY_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string QTY_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string QTY_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string QTY_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string QTY_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string QTY_10 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(11)]
        public string QTY_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string QTY_12 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(13)]
        public string QTY_13 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(14)]
        public string QTY_14 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string QTY_15 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DA,")]
    public class X12_ID_355_C001_761255531
    {
    }
    
    [Serializable()]
    [All()]
    public class All_HI_2300
    {
        
        [Pos(1)]
        public HI_PrincipalAdmittingECodeAndPatientReasonForVisitDiagnosisInformation_2300 HI_PrincipalAdmittingECodeAndPatientReasonForVisitDiagnosisInformation_2300 { get; set; }
        [Pos(2)]
        public HI_DiagnosisRelatedGroupDRGInformation_2300 HI_DiagnosisRelatedGroupDRGInformation_2300 { get; set; }
        [ListCount(2)]
        [Pos(3)]
        public List<HI_OtherDiagnosisInformation_2300> HI_OtherDiagnosisInformation_2300 { get; set; }
        [Pos(4)]
        public HI_PrincipalProcedureInformation_2300 HI_PrincipalProcedureInformation_2300 { get; set; }
        [ListCount(2)]
        [Pos(5)]
        public List<HI_OtherProcedureInformation_2300> HI_OtherProcedureInformation_2300 { get; set; }
        [ListCount(2)]
        [Pos(6)]
        public List<HI_OccurrenceSpanInformation_2300> HI_OccurrenceSpanInformation_2300 { get; set; }
        [ListCount(2)]
        [Pos(7)]
        public List<HI_OccurrenceInformation_2300> HI_OccurrenceInformation_2300 { get; set; }
        [ListCount(2)]
        [Pos(8)]
        public List<HI_ValueInformation_2300> HI_ValueInformation_2300 { get; set; }
        [ListCount(2)]
        [Pos(9)]
        public List<HI_ConditionInformation_2300> HI_ConditionInformation_2300 { get; set; }
        [ListCount(2)]
        [Pos(10)]
        public List<HI_TreatmentCodeInformation_2300> HI_TreatmentCodeInformation_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BK,")]
    public class X12_ID_1270_C022_366454999
    {
    }
    
    [Serializable()]
    [EdiCodes(",BJ,ZZ,")]
    public class X12_ID_1270_C022_1550201916
    {
    }
    
    [Serializable()]
    [EdiCodes(",DR,")]
    public class X12_ID_1270_C022_804238586
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_10722864
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_1173024053
    {
    }
    
    [Serializable()]
    [EdiCodes(",BP,BR,")]
    public class X12_ID_1270_C022_775331376
    {
    }
    
    [Serializable()]
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_1600056629
    {
    }
    
    [Serializable()]
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_1547532442
    {
    }
    
    [Serializable()]
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_400822987
    {
    }
    
    [Serializable()]
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_782923930
    {
    }
    
    [Serializable()]
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_1165431499
    {
    }
    
    [Serializable()]
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_1600187701
    {
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_1584438832
    {
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_400691915
    {
    }
    
    [Serializable()]
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_1945919952
    {
    }
    
    [Serializable()]
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_1165300427
    {
    }
    
    [Serializable()]
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_1531783573
    {
    }
    
    [Serializable()]
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_1584307760
    {
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_1531783573), typeof(X12_ID_1270_C022_1584307760))]
    public class HI_TreatmentCodeInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_1531783573 C022_1531783573 { get; set; }
        [Pos(2)]
        public C022_1584307760 C022_1584307760 { get; set; }
        [Pos(3)]
        public C022_400560843 C022_400560843 { get; set; }
        [Pos(4)]
        public C022_783186074 C022_783186074 { get; set; }
        [Pos(5)]
        public C022_1615573585 C022_1615573585 { get; set; }
        [Pos(6)]
        public C022_1150045615 C022_1150045615 { get; set; }
        [Pos(7)]
        public C022_1097521428 C022_1097521428 { get; set; }
        [Pos(8)]
        public C022_1208112937 C022_1208112937 { get; set; }
        [Pos(9)]
        public C022_24366020 C022_24366020 { get; set; }
        [Pos(10)]
        public C022_1159380897 C022_1159380897 { get; set; }
        [Pos(11)]
        public C022_369967199 C022_369967199 { get; set; }
        [Pos(12)]
        public C022_422491386 C022_422491386 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_422491386")]
    public class C022_422491386
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_422491386))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_422491386
    {
    }
    
    [Serializable()]
    [Composite("C022_369967199")]
    public class C022_369967199
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_369967199))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_369967199
    {
    }
    
    [Serializable()]
    [Composite("C022_1159380897")]
    public class C022_1159380897
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1159380897))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_1159380897
    {
    }
    
    [Serializable()]
    [Composite("C022_24366020")]
    public class C022_24366020
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_24366020))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_24366020
    {
    }
    
    [Serializable()]
    [Composite("C022_1208112937")]
    public class C022_1208112937
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1208112937))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_1208112937
    {
    }
    
    [Serializable()]
    [Composite("C022_1097521428")]
    public class C022_1097521428
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1097521428))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_1097521428
    {
    }
    
    [Serializable()]
    [Composite("C022_1150045615")]
    public class C022_1150045615
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1150045615))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_1150045615
    {
    }
    
    [Serializable()]
    [Composite("C022_1615573585")]
    public class C022_1615573585
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1615573585))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_1615573585
    {
    }
    
    [Serializable()]
    [Composite("C022_783186074")]
    public class C022_783186074
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_783186074))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_783186074
    {
    }
    
    [Serializable()]
    [Composite("C022_400560843")]
    public class C022_400560843
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_400560843))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",TC,")]
    public class X12_ID_1270_C022_400560843
    {
    }
    
    [Serializable()]
    [Composite("C022_1584307760")]
    public class C022_1584307760
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1584307760))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [Composite("C022_1531783573")]
    public class C022_1531783573
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1531783573))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TreatmentCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [Segment("HI", typeof(X12_ID_1270_C022_1945919952), typeof(X12_ID_1270_C022_1165300427))]
    public class HI_ConditionInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_1945919952 C022_1945919952 { get; set; }
        [Pos(2)]
        public C022_1165300427 C022_1165300427 { get; set; }
        [Pos(3)]
        public C022_1600318773 C022_1600318773 { get; set; }
        [Pos(4)]
        public C022_1547794586 C022_1547794586 { get; set; }
        [Pos(5)]
        public C022_850965073 C022_850965073 { get; set; }
        [Pos(6)]
        public C022_332781844 C022_332781844 { get; set; }
        [Pos(7)]
        public C022_1971803945 C022_1971803945 { get; set; }
        [Pos(8)]
        public C022_793815255 C022_793815255 { get; set; }
        [Pos(9)]
        public C022_741291068 C022_741291068 { get; set; }
        [Pos(10)]
        public C022_1925037985 C022_1925037985 { get; set; }
        [Pos(11)]
        public C022_1186182394 C022_1186182394 { get; set; }
        [Pos(12)]
        public C022_2435477 C022_2435477 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_2435477")]
    public class C022_2435477
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_2435477))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_2435477
    {
    }
    
    [Serializable()]
    [Composite("C022_1186182394")]
    public class C022_1186182394
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1186182394))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_1186182394
    {
    }
    
    [Serializable()]
    [Composite("C022_1925037985")]
    public class C022_1925037985
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1925037985))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_1925037985
    {
    }
    
    [Serializable()]
    [Composite("C022_741291068")]
    public class C022_741291068
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_741291068))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_741291068
    {
    }
    
    [Serializable()]
    [Composite("C022_793815255")]
    public class C022_793815255
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_793815255))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_793815255
    {
    }
    
    [Serializable()]
    [Composite("C022_1971803945")]
    public class C022_1971803945
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1971803945))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_1971803945
    {
    }
    
    [Serializable()]
    [Composite("C022_332781844")]
    public class C022_332781844
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_332781844))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_332781844
    {
    }
    
    [Serializable()]
    [Composite("C022_850965073")]
    public class C022_850965073
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_850965073))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_850965073
    {
    }
    
    [Serializable()]
    [Composite("C022_1547794586")]
    public class C022_1547794586
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1547794586))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_1547794586
    {
    }
    
    [Serializable()]
    [Composite("C022_1600318773")]
    public class C022_1600318773
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1600318773))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BG,")]
    public class X12_ID_1270_C022_1600318773
    {
    }
    
    [Serializable()]
    [Composite("C022_1165300427")]
    public class C022_1165300427
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1165300427))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [Composite("C022_1945919952")]
    public class C022_1945919952
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1945919952))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ConditionCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [Segment("HI", typeof(X12_ID_1270_C022_1584438832), typeof(X12_ID_1270_C022_400691915))]
    public class HI_ValueInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_1584438832 C022_1584438832 { get; set; }
        [Pos(2)]
        public C022_400691915 C022_400691915 { get; set; }
        [Pos(3)]
        public C022_783055002 C022_783055002 { get; set; }
        [Pos(4)]
        public C022_1615704657 C022_1615704657 { get; set; }
        [Pos(5)]
        public C022_1149914543 C022_1149914543 { get; set; }
        [Pos(6)]
        public C022_1097390356 C022_1097390356 { get; set; }
        [Pos(7)]
        public C022_1207195433 C022_1207195433 { get; set; }
        [Pos(8)]
        public C022_23448516 C022_23448516 { get; set; }
        [Pos(9)]
        public C022_1160298401 C022_1160298401 { get; set; }
        [Pos(10)]
        public C022_369049695 C022_369049695 { get; set; }
        [Pos(11)]
        public C022_421573882 C022_421573882 { get; set; }
        [Pos(12)]
        public C022_762173035 C022_762173035 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_762173035")]
    public class C022_762173035
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_762173035))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_762173035
    {
    }
    
    [Serializable()]
    [Composite("C022_421573882")]
    public class C022_421573882
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_421573882))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_421573882
    {
    }
    
    [Serializable()]
    [Composite("C022_369049695")]
    public class C022_369049695
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_369049695))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_369049695
    {
    }
    
    [Serializable()]
    [Composite("C022_1160298401")]
    public class C022_1160298401
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1160298401))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_1160298401
    {
    }
    
    [Serializable()]
    [Composite("C022_23448516")]
    public class C022_23448516
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_23448516))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_23448516
    {
    }
    
    [Serializable()]
    [Composite("C022_1207195433")]
    public class C022_1207195433
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1207195433))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_1207195433
    {
    }
    
    [Serializable()]
    [Composite("C022_1097390356")]
    public class C022_1097390356
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1097390356))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_1097390356
    {
    }
    
    [Serializable()]
    [Composite("C022_1149914543")]
    public class C022_1149914543
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1149914543))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_1149914543
    {
    }
    
    [Serializable()]
    [Composite("C022_1615704657")]
    public class C022_1615704657
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1615704657))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_1615704657
    {
    }
    
    [Serializable()]
    [Composite("C022_783055002")]
    public class C022_783055002
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_783055002))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BE,")]
    public class X12_ID_1270_C022_783055002
    {
    }
    
    [Serializable()]
    [Composite("C022_400691915")]
    public class C022_400691915
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_400691915))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_1584438832")]
    public class C022_1584438832
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1584438832))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ValueCodeAssociatedAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_1165431499), typeof(X12_ID_1270_C022_1600187701))]
    public class HI_OccurrenceInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_1165431499 C022_1165431499 { get; set; }
        [Pos(2)]
        public C022_1600187701 C022_1600187701 { get; set; }
        [Pos(3)]
        public C022_1547663514 C022_1547663514 { get; set; }
        [Pos(4)]
        public C022_851096145 C022_851096145 { get; set; }
        [Pos(5)]
        public C022_332650772 C022_332650772 { get; set; }
        [Pos(6)]
        public C022_1971935017 C022_1971935017 { get; set; }
        [Pos(7)]
        public C022_793684183 C022_793684183 { get; set; }
        [Pos(8)]
        public C022_741159996 C022_741159996 { get; set; }
        [Pos(9)]
        public C022_1924906913 C022_1924906913 { get; set; }
        [Pos(10)]
        public C022_1186313466 C022_1186313466 { get; set; }
        [Pos(11)]
        public C022_2566549 C022_2566549 { get; set; }
        [Pos(12)]
        public C022_1531914645 C022_1531914645 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_1531914645")]
    public class C022_1531914645
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1531914645))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1531914645))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_1531914645
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1531914645
    {
    }
    
    [Serializable()]
    [Composite("C022_2566549")]
    public class C022_2566549
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_2566549))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_2566549))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_2566549
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_2566549
    {
    }
    
    [Serializable()]
    [Composite("C022_1186313466")]
    public class C022_1186313466
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1186313466))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1186313466))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_1186313466
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1186313466
    {
    }
    
    [Serializable()]
    [Composite("C022_1924906913")]
    public class C022_1924906913
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1924906913))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1924906913))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_1924906913
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1924906913
    {
    }
    
    [Serializable()]
    [Composite("C022_741159996")]
    public class C022_741159996
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_741159996))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_741159996))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_741159996
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_741159996
    {
    }
    
    [Serializable()]
    [Composite("C022_793684183")]
    public class C022_793684183
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_793684183))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_793684183))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_793684183
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_793684183
    {
    }
    
    [Serializable()]
    [Composite("C022_1971935017")]
    public class C022_1971935017
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1971935017))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1971935017))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_1971935017
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1971935017
    {
    }
    
    [Serializable()]
    [Composite("C022_332650772")]
    public class C022_332650772
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_332650772))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_332650772))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_332650772
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_332650772
    {
    }
    
    [Serializable()]
    [Composite("C022_851096145")]
    public class C022_851096145
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_851096145))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_851096145))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_851096145
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_851096145
    {
    }
    
    [Serializable()]
    [Composite("C022_1547663514")]
    public class C022_1547663514
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1547663514))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1547663514))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BH,")]
    public class X12_ID_1270_C022_1547663514
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1547663514
    {
    }
    
    [Serializable()]
    [Composite("C022_1600187701")]
    public class C022_1600187701
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1600187701))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1600187701))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    public class X12_ID_1250_C022_1600187701
    {
    }
    
    [Serializable()]
    [Composite("C022_1165431499")]
    public class C022_1165431499
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1165431499))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1165431499))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    public class X12_ID_1250_C022_1165431499
    {
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_400822987), typeof(X12_ID_1270_C022_782923930))]
    public class HI_OccurrenceSpanInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_400822987 C022_400822987 { get; set; }
        [Pos(2)]
        public C022_782923930 C022_782923930 { get; set; }
        [Pos(3)]
        public C022_1615835729 C022_1615835729 { get; set; }
        [Pos(4)]
        public C022_1149783471 C022_1149783471 { get; set; }
        [Pos(5)]
        public C022_1097259284 C022_1097259284 { get; set; }
        [Pos(6)]
        public C022_1207326505 C022_1207326505 { get; set; }
        [Pos(7)]
        public C022_23579588 C022_23579588 { get; set; }
        [Pos(8)]
        public C022_1160167329 C022_1160167329 { get; set; }
        [Pos(9)]
        public C022_369180767 C022_369180767 { get; set; }
        [Pos(10)]
        public C022_421704954 C022_421704954 { get; set; }
        [Pos(11)]
        public C022_762041963 C022_762041963 { get; set; }
        [Pos(12)]
        public C022_1945788880 C022_1945788880 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_1945788880")]
    public class C022_1945788880
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1945788880))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1945788880))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_1945788880
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_1945788880
    {
    }
    
    [Serializable()]
    [Composite("C022_762041963")]
    public class C022_762041963
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_762041963))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_762041963))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_762041963
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_762041963
    {
    }
    
    [Serializable()]
    [Composite("C022_421704954")]
    public class C022_421704954
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_421704954))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_421704954))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_421704954
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_421704954
    {
    }
    
    [Serializable()]
    [Composite("C022_369180767")]
    public class C022_369180767
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_369180767))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_369180767))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_369180767
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_369180767
    {
    }
    
    [Serializable()]
    [Composite("C022_1160167329")]
    public class C022_1160167329
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1160167329))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1160167329))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_1160167329
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_1160167329
    {
    }
    
    [Serializable()]
    [Composite("C022_23579588")]
    public class C022_23579588
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_23579588))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_23579588))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_23579588
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_23579588
    {
    }
    
    [Serializable()]
    [Composite("C022_1207326505")]
    public class C022_1207326505
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1207326505))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1207326505))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_1207326505
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_1207326505
    {
    }
    
    [Serializable()]
    [Composite("C022_1097259284")]
    public class C022_1097259284
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1097259284))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1097259284))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_1097259284
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_1097259284
    {
    }
    
    [Serializable()]
    [Composite("C022_1149783471")]
    public class C022_1149783471
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1149783471))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1149783471))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_1149783471
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_1149783471
    {
    }
    
    [Serializable()]
    [Composite("C022_1615835729")]
    public class C022_1615835729
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1615835729))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_1615835729))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",BI,")]
    public class X12_ID_1270_C022_1615835729
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_1615835729
    {
    }
    
    [Serializable()]
    [Composite("C022_782923930")]
    public class C022_782923930
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_782923930))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_782923930))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_782923930
    {
    }
    
    [Serializable()]
    [Composite("C022_400822987")]
    public class C022_400822987
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_400822987))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OccurrenceSpanCode_02 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_C022_400822987))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OccurrenceOrOccurrenceSpanCodeAssociatedDate_04 { get; set; }
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
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_C022_400822987
    {
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_1600056629), typeof(X12_ID_1270_C022_1547532442))]
    public class HI_OtherProcedureInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_1600056629 C022_1600056629 { get; set; }
        [Pos(2)]
        public C022_1547532442 C022_1547532442 { get; set; }
        [Pos(3)]
        public C022_851227217 C022_851227217 { get; set; }
        [Pos(4)]
        public C022_332519700 C022_332519700 { get; set; }
        [Pos(5)]
        public C022_1972066089 C022_1972066089 { get; set; }
        [Pos(6)]
        public C022_793553111 C022_793553111 { get; set; }
        [Pos(7)]
        public C022_741028924 C022_741028924 { get; set; }
        [Pos(8)]
        public C022_1924775841 C022_1924775841 { get; set; }
        [Pos(9)]
        public C022_1186444538 C022_1186444538 { get; set; }
        [Pos(10)]
        public C022_2697621 C022_2697621 { get; set; }
        [Pos(11)]
        public C022_1532045717 C022_1532045717 { get; set; }
        [Pos(12)]
        public C022_1584569904 C022_1584569904 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_1584569904")]
    public class C022_1584569904
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1584569904))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1584569904))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_1584569904
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1584569904
    {
    }
    
    [Serializable()]
    [Composite("C022_1532045717")]
    public class C022_1532045717
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1532045717))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1532045717))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_1532045717
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1532045717
    {
    }
    
    [Serializable()]
    [Composite("C022_2697621")]
    public class C022_2697621
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_2697621))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_2697621))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_2697621
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_2697621
    {
    }
    
    [Serializable()]
    [Composite("C022_1186444538")]
    public class C022_1186444538
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1186444538))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1186444538))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_1186444538
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1186444538
    {
    }
    
    [Serializable()]
    [Composite("C022_1924775841")]
    public class C022_1924775841
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1924775841))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1924775841))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_1924775841
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1924775841
    {
    }
    
    [Serializable()]
    [Composite("C022_741028924")]
    public class C022_741028924
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_741028924))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_741028924))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_741028924
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_741028924
    {
    }
    
    [Serializable()]
    [Composite("C022_793553111")]
    public class C022_793553111
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_793553111))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_793553111))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_793553111
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_793553111
    {
    }
    
    [Serializable()]
    [Composite("C022_1972066089")]
    public class C022_1972066089
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1972066089))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1972066089))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_1972066089
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_1972066089
    {
    }
    
    [Serializable()]
    [Composite("C022_332519700")]
    public class C022_332519700
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_332519700))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_332519700))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_332519700
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_332519700
    {
    }
    
    [Serializable()]
    [Composite("C022_851227217")]
    public class C022_851227217
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_851227217))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_851227217))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    [EdiCodes(",BO,BQ,")]
    public class X12_ID_1270_C022_851227217
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_C022_851227217
    {
    }
    
    [Serializable()]
    [Composite("C022_1547532442")]
    public class C022_1547532442
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1547532442))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1547532442))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    public class X12_ID_1250_C022_1547532442
    {
    }
    
    [Serializable()]
    [Composite("C022_1600056629")]
    public class C022_1600056629
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1600056629))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_1600056629))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureDate_04 { get; set; }
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
    public class X12_ID_1250_C022_1600056629
    {
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_775331376))]
    public class HI_PrincipalProcedureInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_775331376 C022_775331376 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HI_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string HI_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string HI_09 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string HI_10 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string HI_11 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string HI_12 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_775331376")]
    public class C022_775331376
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_775331376))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PrincipalProcedureCode_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_C022_775331376))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
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
    public class X12_ID_1250_C022_775331376
    {
    }
    
    [Serializable()]
    [Segment("HI", typeof(X12_ID_1270_C022_10722864), typeof(X12_ID_1270_C022_1173024053))]
    public class HI_OtherDiagnosisInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_10722864 C022_10722864 { get; set; }
        [Pos(2)]
        public C022_1173024053 C022_1173024053 { get; set; }
        [Pos(3)]
        public C022_1938196326 C022_1938196326 { get; set; }
        [Pos(4)]
        public C022_827422874 C022_827422874 { get; set; }
        [Pos(5)]
        public C022_1487359407 C022_1487359407 { get; set; }
        [Pos(6)]
        public C022_1623860972 C022_1623860972 { get; set; }
        [Pos(7)]
        public C022_366520535 C022_366520535 { get; set; }
        [Pos(8)]
        public C022_1550267452 C022_1550267452 { get; set; }
        [Pos(9)]
        public C022_20919356 C022_20919356 { get; set; }
        [Pos(10)]
        public C022_31604831 C022_31604831 { get; set; }
        [Pos(11)]
        public C022_1152142086 C022_1152142086 { get; set; }
        [Pos(12)]
        public C022_1959078293 C022_1959078293 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_1959078293")]
    public class C022_1959078293
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1959078293))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_1959078293
    {
    }
    
    [Serializable()]
    [Composite("C022_1152142086")]
    public class C022_1152142086
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1152142086))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_1152142086
    {
    }
    
    [Serializable()]
    [Composite("C022_31604831")]
    public class C022_31604831
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_31604831))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_31604831
    {
    }
    
    [Serializable()]
    [Composite("C022_20919356")]
    public class C022_20919356
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_20919356))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_20919356
    {
    }
    
    [Serializable()]
    [Composite("C022_1550267452")]
    public class C022_1550267452
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1550267452))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_1550267452
    {
    }
    
    [Serializable()]
    [Composite("C022_366520535")]
    public class C022_366520535
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_366520535))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_366520535
    {
    }
    
    [Serializable()]
    [Composite("C022_1623860972")]
    public class C022_1623860972
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1623860972))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_1623860972
    {
    }
    
    [Serializable()]
    [Composite("C022_1487359407")]
    public class C022_1487359407
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1487359407))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_1487359407
    {
    }
    
    [Serializable()]
    [Composite("C022_827422874")]
    public class C022_827422874
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_827422874))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_827422874
    {
    }
    
    [Serializable()]
    [Composite("C022_1938196326")]
    public class C022_1938196326
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1938196326))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BF,")]
    public class X12_ID_1270_C022_1938196326
    {
    }
    
    [Serializable()]
    [Composite("C022_1173024053")]
    public class C022_1173024053
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1173024053))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [Composite("C022_10722864")]
    public class C022_10722864
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_10722864))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherDiagnosis_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [Segment("HI", typeof(X12_ID_1270_C022_804238586))]
    public class HI_DiagnosisRelatedGroupDRGInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_804238586 C022_804238586 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HI_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string HI_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string HI_09 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string HI_10 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string HI_11 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string HI_12 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_804238586")]
    public class C022_804238586
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_804238586))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DiagnosisRelatedGroupDRGCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [Segment("HI", typeof(X12_ID_1270_C022_366454999), typeof(X12_ID_1270_C022_1550201916))]
    public class HI_PrincipalAdmittingECodeAndPatientReasonForVisitDiagnosisInformation_2300
    {
        
        [Required]
        [Pos(1)]
        public C022_366454999 C022_366454999 { get; set; }
        [Pos(2)]
        public C022_1550201916 C022_1550201916 { get; set; }
        [Pos(3)]
        public C022_20853820 C022_20853820 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string HI_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string HI_06 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HI_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string HI_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string HI_09 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string HI_10 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string HI_11 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string HI_12 { get; set; }
    }
    
    [Serializable()]
    [Composite("C022_20853820")]
    public class C022_20853820
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_20853820))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [EdiCodes(",BN,")]
    public class X12_ID_1270_C022_20853820
    {
    }
    
    [Serializable()]
    [Composite("C022_1550201916")]
    public class C022_1550201916
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_1550201916))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [Composite("C022_366454999")]
    public class C022_366454999
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_C022_366454999))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string HI_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HI_04 { get; set; }
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
    [All()]
    public class All_CRC_2300
    {
        
        [ListCount(3)]
        [Pos(1)]
        public List<CRC_HomeHealthFunctionalLimitations_2300> CRC_HomeHealthFunctionalLimitations_2300 { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<CRC_HomeHealthActivitiesPermitted_2300> CRC_HomeHealthActivitiesPermitted_2300 { get; set; }
        [ListCount(2)]
        [Pos(3)]
        public List<CRC_HomeHealthMentalStatus_2300> CRC_HomeHealthMentalStatus_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",75,")]
    public class X12_ID_1136_CRC_HomeHealthFunctionalLimitations_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_CRC_HomeHealthFunctionalLimitations_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",76,")]
    public class X12_ID_1136_CRC_HomeHealthActivitiesPermitted_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_CRC_HomeHealthActivitiesPermitted_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",77,")]
    public class X12_ID_1136_CRC_HomeHealthMentalStatus_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_CRC_HomeHealthMentalStatus_2300
    {
    }
    
    [Serializable()]
    [Segment("CRC", typeof(X12_ID_1136_CRC_HomeHealthMentalStatus_2300), typeof(X12_ID_1073_CRC_HomeHealthMentalStatus_2300))]
    public class CRC_HomeHealthMentalStatus_2300
    {
        
        [Required]
        [DataElement("1136", typeof(X12_ID_1136_CRC_HomeHealthMentalStatus_2300))]
        [Pos(1)]
        public string CertificationConditionIndicator_01 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CRC_HomeHealthMentalStatus_2300))]
        [Pos(2)]
        public string FunctionalLimitationCode_02 { get; set; }
        [Required]
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthMentalStatus_2300))]
        [Pos(3)]
        public string MentalStatusCode_03 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthMentalStatus_2300))]
        [Pos(4)]
        public string MentalStatusCode_04 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthMentalStatus_2300))]
        [Pos(5)]
        public string MentalStatusCode_05 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthMentalStatus_2300))]
        [Pos(6)]
        public string MentalStatusCode_06 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthMentalStatus_2300))]
        [Pos(7)]
        public string MentalStatusCode_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AG,CM,DI,DP,FO,LE,MC,OT,")]
    public class X12_ID_1321_CRC_HomeHealthMentalStatus_2300
    {
    }
    
    [Serializable()]
    [Segment("CRC", typeof(X12_ID_1136_CRC_HomeHealthActivitiesPermitted_2300), typeof(X12_ID_1073_CRC_HomeHealthActivitiesPermitted_2300))]
    public class CRC_HomeHealthActivitiesPermitted_2300
    {
        
        [Required]
        [DataElement("1136", typeof(X12_ID_1136_CRC_HomeHealthActivitiesPermitted_2300))]
        [Pos(1)]
        public string CertificationConditionIndicator_01 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CRC_HomeHealthActivitiesPermitted_2300))]
        [Pos(2)]
        public string FunctionalLimitationCode_02 { get; set; }
        [Required]
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthActivitiesPermitted_2300))]
        [Pos(3)]
        public string ActivitiesPermittedCode_03 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthActivitiesPermitted_2300))]
        [Pos(4)]
        public string ActivitiesPermittedCode_04 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthActivitiesPermitted_2300))]
        [Pos(5)]
        public string ActivitiesPermittedCode_05 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthActivitiesPermitted_2300))]
        [Pos(6)]
        public string ActivitiesPermittedCode_06 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthActivitiesPermitted_2300))]
        [Pos(7)]
        public string ActivitiesPermittedCode_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BR,CA,CB,CR,EP,IH,NR,PW,TR,UT,WA,WR,")]
    public class X12_ID_1321_CRC_HomeHealthActivitiesPermitted_2300
    {
    }
    
    [Serializable()]
    [Segment("CRC", typeof(X12_ID_1136_CRC_HomeHealthFunctionalLimitations_2300), typeof(X12_ID_1073_CRC_HomeHealthFunctionalLimitations_2300))]
    public class CRC_HomeHealthFunctionalLimitations_2300
    {
        
        [Required]
        [DataElement("1136", typeof(X12_ID_1136_CRC_HomeHealthFunctionalLimitations_2300))]
        [Pos(1)]
        public string CodeCategory_01 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CRC_HomeHealthFunctionalLimitations_2300))]
        [Pos(2)]
        public string CertificationConditionIndicator_02 { get; set; }
        [Required]
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthFunctionalLimitations_2300))]
        [Pos(3)]
        public string FunctionalLimitationCode_03 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthFunctionalLimitations_2300))]
        [Pos(4)]
        public string FunctionalLimitationCode_04 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthFunctionalLimitations_2300))]
        [Pos(5)]
        public string FunctionalLimitationCode_05 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthFunctionalLimitations_2300))]
        [Pos(6)]
        public string FunctionalLimitationCode_06 { get; set; }
        [DataElement("1321", typeof(X12_ID_1321_CRC_HomeHealthFunctionalLimitations_2300))]
        [Pos(7)]
        public string FunctionalLimitationCode_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AA,AL,BL,CO,DY,EL,HL,LB,OL,PA,SL,")]
    public class X12_ID_1321_CRC_HomeHealthFunctionalLimitations_2300
    {
    }
    
    [Serializable()]
    [Segment("CR6", typeof(X12_ID_923_CR6_HomeHealthCareInformation_2300))]
    public class CR6_HomeHealthCareInformation_2300
    {
        
        [Required]
        [DataElement("923", typeof(X12_ID_923_CR6_HomeHealthCareInformation_2300))]
        [Pos(1)]
        public string PrognosisCode_01 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string ServiceFromDate_02 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_CR6_HomeHealthCareInformation_2300))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string HomeHealthCertificationPeriod_04 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(5)]
        public string DiagnosisDate_05 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CR6_HomeHealthCareInformation_2300))]
        [Pos(6)]
        public string SkilledNursingFacilityIndicator_06 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CR6_HomeHealthCareInformation_2300))]
        [Pos(7)]
        public string MedicareCoverageIndicator_07 { get; set; }
        [Required]
        [DataElement("1322", typeof(X12_ID_1322_CR6_HomeHealthCareInformation_2300))]
        [Pos(8)]
        public string CertificationTypeCode_08 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(9)]
        public string SurgeryDate_09 { get; set; }
        [DataElement("235", typeof(X12_ID_235_CR6_HomeHealthCareInformation_2300))]
        [Pos(10)]
        public string ProductOrServiceIDQualifier_10 { get; set; }
        [StringLength(1, 15)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string SurgicalProcedureCode_11 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(12)]
        public string PhysicianOrderDate_12 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(13)]
        public string LastVisitDate_13 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(14)]
        public string PhysicianContactDate_14 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_CR6_HomeHealthCareInformation_2300))]
        [Pos(15)]
        public string DateTimePeriodFormatQualifier_15 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(16)]
        public string LastAdmissionPeriod_16 { get; set; }
        [Required]
        [DataElement("1384", typeof(X12_ID_1384_CR6_HomeHealthCareInformation_2300))]
        [Pos(17)]
        public string PatientDischargeFacilityTypeCode_17 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(18)]
        public string DiagnosisDate_18 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(19)]
        public string DiagnosisDate_19 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(20)]
        public string DiagnosisDate_20 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(21)]
        public string DiagnosisDate_21 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_CR6_HomeHealthCareInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,U,Y,")]
    public class X12_ID_1073_CR6_HomeHealthCareInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",I,R,S,")]
    public class X12_ID_1322_CR6_HomeHealthCareInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",HC,ID,")]
    public class X12_ID_235_CR6_HomeHealthCareInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,B,C,D,E,F,G,H,L,M,O,R,S,T,")]
    public class X12_ID_1384_CR6_HomeHealthCareInformation_2300
    {
    }
    
    [Serializable()]
    [All()]
    public class All_NTE_2300
    {
        
        [ListCount(10)]
        [Pos(1)]
        public List<NTE_ClaimNote_2300> NTE_ClaimNote_2300 { get; set; }
        [Pos(2)]
        public NTE_BillingNote_2300 NTE_BillingNote_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ALG,DCP,DGN,DME,MED,NTR,ODT,RHB,RLH,RNH,SET,SFM,SPT,UPI,")]
    public class X12_ID_363_NTE_ClaimNote_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",ADD,")]
    public class X12_ID_363_NTE_BillingNote_2300
    {
    }
    
    [Serializable()]
    [Segment("NTE", typeof(X12_ID_363_NTE_BillingNote_2300))]
    public class NTE_BillingNote_2300
    {
        
        [Required]
        [DataElement("363", typeof(X12_ID_363_NTE_BillingNote_2300))]
        [Pos(1)]
        public string NoteReferenceCode_01 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BillingNoteText_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NTE", typeof(X12_ID_363_NTE_ClaimNote_2300))]
    public class NTE_ClaimNote_2300
    {
        
        [Required]
        [DataElement("363", typeof(X12_ID_363_NTE_ClaimNote_2300))]
        [Pos(1)]
        public string NoteReferenceCode_01 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ClaimNoteText_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("K3")]
    public class K3_FileInformation_2300
    {
        
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string FixedFormatInformation_01 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string K3_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string K3_03 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2300
    {
        
        [Pos(1)]
        public REF_AdjustedRepricedClaimNumber_2300 REF_AdjustedRepricedClaimNumber_2300 { get; set; }
        [Pos(2)]
        public REF_RepricedClaimNumber_2300 REF_RepricedClaimNumber_2300 { get; set; }
        [Pos(3)]
        public REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300 REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300 { get; set; }
        [ListCount(2)]
        [Pos(4)]
        public List<REF_DocumentIdentificationCode_2300> REF_DocumentIdentificationCode_2300 { get; set; }
        [Pos(5)]
        public REF_OriginalReferenceNumberICNDCN_2300 REF_OriginalReferenceNumberICNDCN_2300 { get; set; }
        [Pos(6)]
        public REF_InvestigationalDeviceExemptionNumber_2300 REF_InvestigationalDeviceExemptionNumber_2300 { get; set; }
        [Pos(7)]
        public REF_ServiceAuthorizationExceptionCode_2300 REF_ServiceAuthorizationExceptionCode_2300 { get; set; }
        [Pos(8)]
        public REF_PeerReviewOrganizationPROApprovalNumber_2300 REF_PeerReviewOrganizationPROApprovalNumber_2300 { get; set; }
        [ListCount(2)]
        [Pos(9)]
        public List<REF_PriorAuthorizationOrReferralNumber_2300> REF_PriorAuthorizationOrReferralNumber_2300 { get; set; }
        [Pos(10)]
        public REF_MedicalRecordNumber_2300 REF_MedicalRecordNumber_2300 { get; set; }
        [Pos(11)]
        public REF_DemonstrationProjectIdentifier_2300 REF_DemonstrationProjectIdentifier_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",9C,")]
    public class X12_ID_128_REF_AdjustedRepricedClaimNumber_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",9A,")]
    public class X12_ID_128_REF_RepricedClaimNumber_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D9,")]
    public class X12_ID_128_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",DD,")]
    public class X12_ID_128_REF_DocumentIdentificationCode_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",F8,")]
    public class X12_ID_128_REF_OriginalReferenceNumberICNDCN_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",LX,")]
    public class X12_ID_128_REF_InvestigationalDeviceExemptionNumber_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",4N,")]
    public class X12_ID_128_REF_ServiceAuthorizationExceptionCode_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",G4,")]
    public class X12_ID_128_REF_PeerReviewOrganizationPROApprovalNumber_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",9F,G1,")]
    public class X12_ID_128_REF_PriorAuthorizationOrReferralNumber_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",EA,")]
    public class X12_ID_128_REF_MedicalRecordNumber_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",P4,")]
    public class X12_ID_128_REF_DemonstrationProjectIdentifier_2300
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_DemonstrationProjectIdentifier_2300))]
    public class REF_DemonstrationProjectIdentifier_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_DemonstrationProjectIdentifier_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DemonstrationProjectIdentifier_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_MedicalRecordNumber_2300))]
    public class REF_MedicalRecordNumber_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_MedicalRecordNumber_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string MedicalRecordNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_PriorAuthorizationOrReferralNumber_2300))]
    public class REF_PriorAuthorizationOrReferralNumber_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PriorAuthorizationOrReferralNumber_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PriorAuthorizationNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_PeerReviewOrganizationPROApprovalNumber_2300))]
    public class REF_PeerReviewOrganizationPROApprovalNumber_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PeerReviewOrganizationPROApprovalNumber_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PeerReviewAuthorizationNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_ServiceAuthorizationExceptionCode_2300))]
    public class REF_ServiceAuthorizationExceptionCode_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ServiceAuthorizationExceptionCode_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ServiceAuthorizationExceptionCode_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_InvestigationalDeviceExemptionNumber_2300))]
    public class REF_InvestigationalDeviceExemptionNumber_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_InvestigationalDeviceExemptionNumber_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InvestigationalDeviceExemptionIdentifier_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_OriginalReferenceNumberICNDCN_2300))]
    public class REF_OriginalReferenceNumberICNDCN_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OriginalReferenceNumberICNDCN_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ClaimOriginalReferenceNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_DocumentIdentificationCode_2300))]
    public class REF_DocumentIdentificationCode_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_DocumentIdentificationCode_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DocumentControlIdentifier_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300))]
    public class REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ValueAddedNetworkTraceNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_RepricedClaimNumber_2300))]
    public class REF_RepricedClaimNumber_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_RepricedClaimNumber_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string RepricedClaimReferenceNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_AdjustedRepricedClaimNumber_2300))]
    public class REF_AdjustedRepricedClaimNumber_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_AdjustedRepricedClaimNumber_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string AdjustedRepricedClaimReferenceNumber_02 { get; set; }
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
    [All()]
    public class All_AMT_2300
    {
        
        [Pos(1)]
        public AMT_PayerEstimatedAmountDue_2300 AMT_PayerEstimatedAmountDue_2300 { get; set; }
        [Pos(2)]
        public AMT_PatientEstimatedAmountDue_2300 AMT_PatientEstimatedAmountDue_2300 { get; set; }
        [Pos(3)]
        public AMT_PatientPaidAmount_2300 AMT_PatientPaidAmount_2300 { get; set; }
        [Pos(4)]
        public AMT_CreditDebitCardMaximumAmount_2300 AMT_CreditDebitCardMaximumAmount_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",C5,")]
    public class X12_ID_522_AMT_PayerEstimatedAmountDue_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",F3,")]
    public class X12_ID_522_AMT_PatientEstimatedAmountDue_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",F5,")]
    public class X12_ID_522_AMT_PatientPaidAmount_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",MA,")]
    public class X12_ID_522_AMT_CreditDebitCardMaximumAmount_2300
    {
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CreditDebitCardMaximumAmount_2300))]
    public class AMT_CreditDebitCardMaximumAmount_2300
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CreditDebitCardMaximumAmount_2300))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string CreditOrDebitCardMaximumAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_PatientPaidAmount_2300))]
    public class AMT_PatientPaidAmount_2300
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_PatientPaidAmount_2300))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string PatientAmountPaid_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_PatientEstimatedAmountDue_2300))]
    public class AMT_PatientEstimatedAmountDue_2300
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_PatientEstimatedAmountDue_2300))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string PatientResponsibilityAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_PayerEstimatedAmountDue_2300))]
    public class AMT_PayerEstimatedAmountDue_2300
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_PayerEstimatedAmountDue_2300))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string EstimatedClaimDueAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("CN1", typeof(X12_ID_1166_CN1_ContractInformation_2300))]
    public class CN1_ContractInformation_2300
    {
        
        [Required]
        [DataElement("1166", typeof(X12_ID_1166_CN1_ContractInformation_2300))]
        [Pos(1)]
        public string ContractTypeCode_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ContractAmount_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string ContractPercentage_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ContractCode_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string TermsDiscountPercentage_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ContractVersionIdentifier_06 { get; set; }
    }
    
    [Serializable()]
    [Segment("PWK", typeof(X12_ID_755_PWK_ClaimSupplementalInformation_2300), typeof(X12_ID_756_PWK_ClaimSupplementalInformation_2300))]
    public class PWK_ClaimSupplementalInformation_2300
    {
        
        [Required]
        [DataElement("755", typeof(X12_ID_755_PWK_ClaimSupplementalInformation_2300))]
        [Pos(1)]
        public string AttachmentReportTypeCode_01 { get; set; }
        [Required]
        [DataElement("756", typeof(X12_ID_756_PWK_ClaimSupplementalInformation_2300))]
        [Pos(2)]
        public string AttachmentTransmissionCode_02 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(3)]
        public string PWK_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string PWK_04 { get; set; }
        [DataElement("66", typeof(X12_ID_66_PWK_ClaimSupplementalInformation_2300))]
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
    public class X12_ID_66_PWK_ClaimSupplementalInformation_2300
    {
    }
    
    [Serializable()]
    [Segment("CL1")]
    public class CL1_InstitutionalClaimCode_2300
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
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CL1_04 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_DTP_2300
    {
        
        [Pos(1)]
        public DTP_DischargeHour_2300 DTP_DischargeHour_2300 { get; set; }
        [Required]
        [Pos(2)]
        public DTP_StatementDates_2300 DTP_StatementDates_2300 { get; set; }
        [Pos(3)]
        public DTP_AdmissionDateHour_2300 DTP_AdmissionDateHour_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",096,")]
    public class X12_ID_374_DTP_DischargeHour_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",TM,")]
    public class X12_ID_1250_DTP_DischargeHour_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",434,")]
    public class X12_ID_374_DTP_StatementDates_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_StatementDates_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",435,")]
    public class X12_ID_374_DTP_AdmissionDateHour_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",DT,")]
    public class X12_ID_1250_DTP_AdmissionDateHour_2300
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_AdmissionDateHour_2300), typeof(X12_ID_1250_DTP_AdmissionDateHour_2300))]
    public class DTP_AdmissionDateHour_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_AdmissionDateHour_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_AdmissionDateHour_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AdmissionDateAndHour_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_StatementDates_2300), typeof(X12_ID_1250_DTP_StatementDates_2300))]
    public class DTP_StatementDates_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_StatementDates_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_StatementDates_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string StatementFromOrToDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DischargeHour_2300), typeof(X12_ID_1250_DTP_DischargeHour_2300))]
    public class DTP_DischargeHour_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DischargeHour_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DischargeHour_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DischargeHour_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("CLM")]
    public class CLM_ClaimInformation_2300
    {
        
        [Required]
        [StringLength(1, 38)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PatientAccountNumber_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string TotalClaimChargeAmount_02 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string CLM_03 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CLM_04 { get; set; }
        [Required]
        [Pos(5)]
        public C023_1128957798 C023_1128957798 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CLM_ClaimInformation_2300))]
        [Pos(6)]
        public string ProviderOrSupplierSignatureIndicator_06 { get; set; }
        [DataElement("1359", typeof(X12_ID_1359_CLM_ClaimInformation_2300))]
        [Pos(7)]
        public string MedicareAssignmentCode_07 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CLM_ClaimInformation_2300))]
        [Pos(8)]
        public string BenefitsAssignmentCertificationIndicator_08 { get; set; }
        [Required]
        [DataElement("1363", typeof(X12_ID_1363_CLM_ClaimInformation_2300))]
        [Pos(9)]
        public string ReleaseOfInformationCode_09 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string CLM_10 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string CLM_11 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(12)]
        public string CLM_12 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(13)]
        public string CLM_13 { get; set; }
        [StringLength(1, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(14)]
        public string CLM_14 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(15)]
        public string CLM_15 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(16)]
        public string CLM_16 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(17)]
        public string CLM_17 { get; set; }
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_CLM_ClaimInformation_2300))]
        [Pos(18)]
        public string ExplanationOfBenefitsIndicator_18 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(19)]
        public string CLM_19 { get; set; }
        [DataElement("1514", typeof(X12_ID_1514_CLM_ClaimInformation_2300))]
        [Pos(20)]
        public string DelayReasonCode_20 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,C,")]
    public class X12_ID_1359_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,I,M,N,O,Y,")]
    public class X12_ID_1363_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,9,10,11,")]
    public class X12_ID_1514_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [Composite("C023_1128957798")]
    public class C023_1128957798
    {
        
        [Required]
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string FacilityTypeCode_01 { get; set; }
        [Required]
        [DataElement("1332", typeof(X12_ID_1332_C023_1128957798))]
        [Pos(2)]
        public string FacilityCodeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ClaimFrequencyCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",A,")]
    public class X12_ID_1332_C023_1128957798
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_PatientName_2010CA))]
    public class Loop_2010CA
    {
        
        [Required]
        [Pos(1)]
        public NM1_PatientName_2010CA NM1_PatientName_2010CA { get; set; }
        [Required]
        [Pos(2)]
        public N3_PatientAddress_2010CA N3_PatientAddress_2010CA { get; set; }
        [Required]
        [Pos(3)]
        public N4_PatientCityStateZIPCode_2010CA N4_PatientCityStateZIPCode_2010CA { get; set; }
        [Required]
        [Pos(4)]
        public DMG_PatientDemographicInformation_2010CA DMG_PatientDemographicInformation_2010CA { get; set; }
        [Pos(5)]
        public All_REF_2010CA All_REF_2010CA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",QC,")]
    public class X12_ID_98_NM1_PatientName_2010CA
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_PatientName_2010CA
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_PatientDemographicInformation_2010CA
    {
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2010CA
    {
        
        [ListCount(5)]
        [Pos(1)]
        public List<REF_PatientSecondaryIdentificationNumber_2010CA> REF_PatientSecondaryIdentificationNumber_2010CA { get; set; }
        [Pos(2)]
        public REF_PropertyAndCasualtyClaimNumber_2010CA REF_PropertyAndCasualtyClaimNumber_2010CA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1W,23,IG,SY,")]
    public class X12_ID_128_REF_PatientSecondaryIdentificationNumber_2010CA
    {
    }
    
    [Serializable()]
    [EdiCodes(",Y4,")]
    public class X12_ID_128_REF_PropertyAndCasualtyClaimNumber_2010CA
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PropertyAndCasualtyClaimNumber_2010CA))]
    public class REF_PropertyAndCasualtyClaimNumber_2010CA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PropertyAndCasualtyClaimNumber_2010CA))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PropertyCasualtyClaimNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_PatientSecondaryIdentificationNumber_2010CA))]
    public class REF_PatientSecondaryIdentificationNumber_2010CA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PatientSecondaryIdentificationNumber_2010CA))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PatientSecondaryIdentifier_02 { get; set; }
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
    [Segment("DMG", typeof(X12_ID_1250_DMG_PatientDemographicInformation_2010CA))]
    public class DMG_PatientDemographicInformation_2010CA
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_PatientDemographicInformation_2010CA))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PatientBirthDate_02 { get; set; }
        [Required]
        [DataElement("1068", typeof(X12_ID_1068_DMG_PatientDemographicInformation_2010CA))]
        [Pos(3)]
        public string PatientGenderCode_03 { get; set; }
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
    public class X12_ID_1068_DMG_PatientDemographicInformation_2010CA
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_PatientCityStateZIPCode_2010CA
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PatientCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string PatientStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string PatientPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_PatientAddress_2010CA
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PatientAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PatientAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_PatientName_2010CA), typeof(X12_ID_1065_NM1_PatientName_2010CA))]
    public class NM1_PatientName_2010CA
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_PatientName_2010CA))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_PatientName_2010CA))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PatientLastName_03 { get; set; }
        [Required]
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string PatientFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string PatientMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string PatientNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_PatientName_2010CA))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PatientPrimaryIdentifier_09 { get; set; }
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
    public class X12_ID_66_NM1_PatientName_2010CA
    {
    }
    
    [Serializable()]
    [Segment("PAT", typeof(X12_ID_1069_PAT_PatientInformation_2000C))]
    public class PAT_PatientInformation_2000C
    {
        
        [Required]
        [DataElement("1069", typeof(X12_ID_1069_PAT_PatientInformation_2000C))]
        [Pos(1)]
        public string IndividualRelationshipCode_01 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string PAT_02 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string PAT_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string PAT_04 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string PAT_05 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string PAT_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string PAT_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string PAT_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string PAT_09 { get; set; }
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_PatientHierarchicalLevel_2000C))]
    public class HL_PatientHierarchicalLevel_2000C
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
        [DataElement("735", typeof(X12_ID_735_HL_PatientHierarchicalLevel_2000C))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_PatientHierarchicalLevel_2000C))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0,")]
    public class X12_ID_736_HL_PatientHierarchicalLevel_2000C
    {
    }
    
    [Serializable()]
    [All()]
    public class All_2010B
    {
        
        [Required]
        [Pos(1)]
        public Loop_2010BA Loop_2010BA { get; set; }
        [Pos(2)]
        public Loop_2010BB Loop_2010BB { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2010BC Loop_2010BC { get; set; }
        [Pos(4)]
        public Loop_2010BD Loop_2010BD { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_ResponsiblePartyName_2010BD))]
    public class Loop_2010BD
    {
        
        [Required]
        [Pos(1)]
        public NM1_ResponsiblePartyName_2010BD NM1_ResponsiblePartyName_2010BD { get; set; }
        [Required]
        [Pos(2)]
        public N3_ResponsiblePartyAddress_2010BD N3_ResponsiblePartyAddress_2010BD { get; set; }
        [Required]
        [Pos(3)]
        public N4_ResponsiblePartyCityStateZIPCode_2010BD N4_ResponsiblePartyCityStateZIPCode_2010BD { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",QD,")]
    public class X12_ID_98_NM1_ResponsiblePartyName_2010BD
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_ResponsiblePartyName_2010BD
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_ResponsiblePartyCityStateZIPCode_2010BD
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ResponsiblePartyCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string ResponsiblePartyStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ResponsiblePartyPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_ResponsiblePartyAddress_2010BD
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ResponsiblePartyAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ResponsiblePartyAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_ResponsiblePartyName_2010BD), typeof(X12_ID_1065_NM1_ResponsiblePartyName_2010BD))]
    public class NM1_ResponsiblePartyName_2010BD
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ResponsiblePartyName_2010BD))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ResponsiblePartyName_2010BD))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ResponsiblePartyLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ResponsiblePartyFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ResponsiblePartyMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ResponsiblePartySuffixName_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string NM1_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string NM1_09 { get; set; }
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
    [Group(typeof(NM1_PayerName_2010BC))]
    public class Loop_2010BC
    {
        
        [Required]
        [Pos(1)]
        public NM1_PayerName_2010BC NM1_PayerName_2010BC { get; set; }
        [Pos(2)]
        public N3_PayerAddress_2010BC N3_PayerAddress_2010BC { get; set; }
        [Pos(3)]
        public N4_PayerCityStateZIPCode_2010BC N4_PayerCityStateZIPCode_2010BC { get; set; }
        [ListCount(3)]
        [Pos(4)]
        public List<REF_PayerSecondaryIdentification_2010BC> REF_PayerSecondaryIdentification_2010BC { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_NM1_PayerName_2010BC
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_PayerName_2010BC
    {
    }
    
    [Serializable()]
    [EdiCodes(",2U,FY,NF,TJ,")]
    public class X12_ID_128_REF_PayerSecondaryIdentification_2010BC
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PayerSecondaryIdentification_2010BC))]
    public class REF_PayerSecondaryIdentification_2010BC
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PayerSecondaryIdentification_2010BC))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayerAdditionalIdentifier_02 { get; set; }
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
    [Segment("N4")]
    public class N4_PayerCityStateZIPCode_2010BC
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PayerCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string PayerStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string PayerPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_PayerAddress_2010BC
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PayerAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayerAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_PayerName_2010BC), typeof(X12_ID_1065_NM1_PayerName_2010BC))]
    public class NM1_PayerName_2010BC
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_PayerName_2010BC))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_PayerName_2010BC))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PayerName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_PayerName_2010BC))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PayerIdentifier_09 { get; set; }
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
    [EdiCodes(",PI,XV,")]
    public class X12_ID_66_NM1_PayerName_2010BC
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_CreditDebitCardAccountHolderName_2010BB))]
    public class Loop_2010BB
    {
        
        [Required]
        [Pos(1)]
        public NM1_CreditDebitCardAccountHolderName_2010BB NM1_CreditDebitCardAccountHolderName_2010BB { get; set; }
        [ListCount(2)]
        [Pos(2)]
        public List<REF_CreditDebitCardInformation_2010BB> REF_CreditDebitCardInformation_2010BB { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AO,")]
    public class X12_ID_98_NM1_CreditDebitCardAccountHolderName_2010BB
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_CreditDebitCardAccountHolderName_2010BB
    {
    }
    
    [Serializable()]
    [EdiCodes(",AB,BB,")]
    public class X12_ID_128_REF_CreditDebitCardInformation_2010BB
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_CreditDebitCardInformation_2010BB))]
    public class REF_CreditDebitCardInformation_2010BB
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_CreditDebitCardInformation_2010BB))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string CreditOrDebitCardAuthorizationNumber_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_CreditDebitCardAccountHolderName_2010BB), typeof(X12_ID_1065_NM1_CreditDebitCardAccountHolderName_2010BB))]
    public class NM1_CreditDebitCardAccountHolderName_2010BB
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_CreditDebitCardAccountHolderName_2010BB))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_CreditDebitCardAccountHolderName_2010BB))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CreditOrDebitCardHolderLastOrOrganizationalName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CreditOrDebitCardHolderFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string CreditOrDebitCardHolderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string CreditOrDebitCardHolderNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_CreditDebitCardAccountHolderName_2010BB))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string CreditOrDebitCardNumber_09 { get; set; }
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
    [EdiCodes(",MI,")]
    public class X12_ID_66_NM1_CreditDebitCardAccountHolderName_2010BB
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_SubscriberName_2010BA))]
    public class Loop_2010BA
    {
        
        [Required]
        [Pos(1)]
        public NM1_SubscriberName_2010BA NM1_SubscriberName_2010BA { get; set; }
        [Pos(2)]
        public N3_SubscriberAddress_2010BA N3_SubscriberAddress_2010BA { get; set; }
        [Pos(3)]
        public N4_SubscriberCityStateZIPCode_2010BA N4_SubscriberCityStateZIPCode_2010BA { get; set; }
        [Pos(4)]
        public DMG_SubscriberDemographicInformation_2010BA DMG_SubscriberDemographicInformation_2010BA { get; set; }
        [Pos(5)]
        public All_REF_2010BA All_REF_2010BA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",IL,")]
    public class X12_ID_98_NM1_SubscriberName_2010BA
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_SubscriberName_2010BA
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_SubscriberDemographicInformation_2010BA
    {
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2010BA
    {
        
        [ListCount(4)]
        [Pos(1)]
        public List<REF_SubscriberSecondaryIdentification_2010BA> REF_SubscriberSecondaryIdentification_2010BA { get; set; }
        [Pos(2)]
        public REF_PropertyAndCasualtyClaimNumber_2010BA REF_PropertyAndCasualtyClaimNumber_2010BA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1W,23,IG,SY,")]
    public class X12_ID_128_REF_SubscriberSecondaryIdentification_2010BA
    {
    }
    
    [Serializable()]
    [EdiCodes(",Y4,")]
    public class X12_ID_128_REF_PropertyAndCasualtyClaimNumber_2010BA
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PropertyAndCasualtyClaimNumber_2010BA))]
    public class REF_PropertyAndCasualtyClaimNumber_2010BA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PropertyAndCasualtyClaimNumber_2010BA))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PropertyCasualtyClaimNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_SubscriberSecondaryIdentification_2010BA))]
    public class REF_SubscriberSecondaryIdentification_2010BA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_SubscriberSecondaryIdentification_2010BA))]
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
    [Segment("DMG", typeof(X12_ID_1250_DMG_SubscriberDemographicInformation_2010BA))]
    public class DMG_SubscriberDemographicInformation_2010BA
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_SubscriberDemographicInformation_2010BA))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberBirthDate_02 { get; set; }
        [Required]
        [DataElement("1068", typeof(X12_ID_1068_DMG_SubscriberDemographicInformation_2010BA))]
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
    public class X12_ID_1068_DMG_SubscriberDemographicInformation_2010BA
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_SubscriberCityStateZIPCode_2010BA
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string SubscriberCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string SubscriberStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string SubscriberPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_SubscriberAddress_2010BA
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string SubscriberAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_SubscriberName_2010BA), typeof(X12_ID_1065_NM1_SubscriberName_2010BA))]
    public class NM1_SubscriberName_2010BA
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_SubscriberName_2010BA))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_SubscriberName_2010BA))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
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
        [DataElement("66", typeof(X12_ID_66_NM1_SubscriberName_2010BA))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
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
    public class X12_ID_66_NM1_SubscriberName_2010BA
    {
    }
    
    [Serializable()]
    [Segment("SBR", typeof(X12_ID_1138_SBR_SubscriberInformation_2000B), typeof(X12_ID_1069_SBR_SubscriberInformation_2000B))]
    public class SBR_SubscriberInformation_2000B
    {
        
        [Required]
        [DataElement("1138", typeof(X12_ID_1138_SBR_SubscriberInformation_2000B))]
        [Pos(1)]
        public string PayerResponsibilitySequenceNumberCode_01 { get; set; }
        [DataElement("1069", typeof(X12_ID_1069_SBR_SubscriberInformation_2000B))]
        [Pos(2)]
        public string IndividualRelationshipCode_02 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string InsuredGroupOrPolicyNumber_03 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string InsuredGroupName_04 { get; set; }
        [StringLength(1, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string SBR_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string SBR_06 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string SBR_07 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string SBR_08 { get; set; }
        [DataElement("1032", typeof(X12_ID_1032_SBR_SubscriberInformation_2000B))]
        [Pos(9)]
        public string ClaimFilingIndicatorCode_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",09,10,11,12,13,14,15,16,AM,BL,CH,CI,DS,HM,LI,LM,MA,MB,MC,OF,TV,VA,WC,ZZ,")]
    public class X12_ID_1032_SBR_SubscriberInformation_2000B
    {
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_SubscriberHierarchicalLevel_2000B))]
    public class HL_SubscriberHierarchicalLevel_2000B
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
        [DataElement("735", typeof(X12_ID_735_HL_SubscriberHierarchicalLevel_2000B))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_SubscriberHierarchicalLevel_2000B))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0,1,")]
    public class X12_ID_736_HL_SubscriberHierarchicalLevel_2000B
    {
    }
    
    [Serializable()]
    [All()]
    public class All_2010A
    {
        
        [Required]
        [Pos(1)]
        public Loop_2010AA Loop_2010AA { get; set; }
        [Pos(2)]
        public Loop_2010AB Loop_2010AB { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_PayToProviderName_2010AB))]
    public class Loop_2010AB
    {
        
        [Required]
        [Pos(1)]
        public NM1_PayToProviderName_2010AB NM1_PayToProviderName_2010AB { get; set; }
        [Required]
        [Pos(2)]
        public N3_PayToProviderAddress_2010AB N3_PayToProviderAddress_2010AB { get; set; }
        [Required]
        [Pos(3)]
        public N4_PayToProviderCityStateZIPCode_2010AB N4_PayToProviderCityStateZIPCode_2010AB { get; set; }
        [ListCount(5)]
        [Pos(4)]
        public List<REF_PayToProviderSecondaryIdentification_2010AB> REF_PayToProviderSecondaryIdentification_2010AB { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",87,")]
    public class X12_ID_98_NM1_PayToProviderName_2010AB
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_PayToProviderName_2010AB
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,1J,B3,BQ,EI,FH,G2,G5,LU,SY,X5,")]
    public class X12_ID_128_REF_PayToProviderSecondaryIdentification_2010AB
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PayToProviderSecondaryIdentification_2010AB))]
    public class REF_PayToProviderSecondaryIdentification_2010AB
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PayToProviderSecondaryIdentification_2010AB))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PaytoProviderAdditionalIdentifier_02 { get; set; }
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
    [Segment("N4")]
    public class N4_PayToProviderCityStateZIPCode_2010AB
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PaytoProviderCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string PaytoProviderStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string PaytoProviderPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_PayToProviderAddress_2010AB
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PaytoProviderAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PaytoProviderAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_PayToProviderName_2010AB), typeof(X12_ID_1065_NM1_PayToProviderName_2010AB))]
    public class NM1_PayToProviderName_2010AB
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_PayToProviderName_2010AB))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_PayToProviderName_2010AB))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PaytoProviderLastOrOrganizationalName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_PayToProviderName_2010AB))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PaytoProviderIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_PayToProviderName_2010AB
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_BillingProviderName_2010AA))]
    public class Loop_2010AA
    {
        
        [Required]
        [Pos(1)]
        public NM1_BillingProviderName_2010AA NM1_BillingProviderName_2010AA { get; set; }
        [Required]
        [Pos(2)]
        public N3_BillingProviderAddress_2010AA N3_BillingProviderAddress_2010AA { get; set; }
        [Required]
        [Pos(3)]
        public N4_BillingProviderCityStateZIPCode_2010AA N4_BillingProviderCityStateZIPCode_2010AA { get; set; }
        [Pos(4)]
        public All_REF_2010AA All_REF_2010AA { get; set; }
        [ListCount(2)]
        [Pos(5)]
        public List<PER_BillingProviderContactInformation_2010AA> PER_BillingProviderContactInformation_2010AA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",85,")]
    public class X12_ID_98_NM1_BillingProviderName_2010AA
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_BillingProviderName_2010AA
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_BillingProviderContactInformation_2010AA
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_BillingProviderContactInformation_2010AA))]
    public class PER_BillingProviderContactInformation_2010AA
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_BillingProviderContactInformation_2010AA))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [Required]
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BillingProviderContactName_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_BillingProviderContactInformation_2010AA))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_BillingProviderContactInformation_2010AA))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_BillingProviderContactInformation_2010AA))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string CommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EM,FX,TE,")]
    public class X12_ID_365_PER_BillingProviderContactInformation_2010AA
    {
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2010AA
    {
        
        [ListCount(8)]
        [Pos(1)]
        public List<REF_BillingProviderSecondaryIdentification_2010AA> REF_BillingProviderSecondaryIdentification_2010AA { get; set; }
        [ListCount(8)]
        [Pos(2)]
        public List<REF_CreditDebitCardBillingInformation_2010AA> REF_CreditDebitCardBillingInformation_2010AA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,1J,B3,BQ,EI,FH,G2,G5,LU,SY,X5,")]
    public class X12_ID_128_REF_BillingProviderSecondaryIdentification_2010AA
    {
    }
    
    [Serializable()]
    [EdiCodes(",06,8U,EM,IJ,RB,ST,TT,")]
    public class X12_ID_128_REF_CreditDebitCardBillingInformation_2010AA
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_CreditDebitCardBillingInformation_2010AA))]
    public class REF_CreditDebitCardBillingInformation_2010AA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_CreditDebitCardBillingInformation_2010AA))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BillingProviderCreditCardIdentifier_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_BillingProviderSecondaryIdentification_2010AA))]
    public class REF_BillingProviderSecondaryIdentification_2010AA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_BillingProviderSecondaryIdentification_2010AA))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BillingProviderAdditionalIdentifier_02 { get; set; }
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
    [Segment("N4")]
    public class N4_BillingProviderCityStateZIPCode_2010AA
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string BillingProviderCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string BillingProviderStateOrProvinceCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string BillingProviderPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
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
    public class N3_BillingProviderAddress_2010AA
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string BillingProviderAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BillingProviderAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_BillingProviderName_2010AA), typeof(X12_ID_1065_NM1_BillingProviderName_2010AA))]
    public class NM1_BillingProviderName_2010AA
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_BillingProviderName_2010AA))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_BillingProviderName_2010AA))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string BillingProviderLastOrOrganizationalName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_BillingProviderName_2010AA))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string BillingProviderIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,XX,")]
    public class X12_ID_66_NM1_BillingProviderName_2010AA
    {
    }
    
    [Serializable()]
    [Segment("CUR", typeof(X12_ID_98_CUR_ForeignCurrencyInformation_2000A))]
    public class CUR_ForeignCurrencyInformation_2000A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_CUR_ForeignCurrencyInformation_2000A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string CurrencyCode_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string CUR_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CUR_04 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string CUR_05 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string CUR_06 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string CUR_07 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(8)]
        public string CUR_08 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(9)]
        public string CUR_09 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string CUR_10 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(11)]
        public string CUR_11 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(12)]
        public string CUR_12 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(13)]
        public string CUR_13 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(14)]
        public string CUR_14 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(15)]
        public string CUR_15 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(16)]
        public string CUR_16 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(17)]
        public string CUR_17 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(18)]
        public string CUR_18 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(19)]
        public string CUR_19 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(20)]
        public string CUR_20 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(21)]
        public string CUR_21 { get; set; }
    }
    
    [Serializable()]
    public class X12_TM
    {
    }
    
    [Serializable()]
    [Segment("PRV", typeof(X12_ID_1221_PRV_BillingPayToProviderSpecialtyInformation_2000A), typeof(X12_ID_128_PRV_BillingPayToProviderSpecialtyInformation_2000A))]
    public class PRV_BillingPayToProviderSpecialtyInformation_2000A
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_BillingPayToProviderSpecialtyInformation_2000A))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_BillingPayToProviderSpecialtyInformation_2000A))]
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
    [Segment("HL", typeof(X12_ID_735_HL_BillingPayToProviderHierarchicalLevel_2000A))]
    public class HL_BillingPayToProviderHierarchicalLevel_2000A
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
        [DataElement("735", typeof(X12_ID_735_HL_BillingPayToProviderHierarchicalLevel_2000A))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_BillingPayToProviderHierarchicalLevel_2000A))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_BillingPayToProviderHierarchicalLevel_2000A
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_ReceiverName_1000B))]
    public class Loop_1000B
    {
        
        [Required]
        [Pos(1)]
        public NM1_ReceiverName_1000B NM1_ReceiverName_1000B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",40,")]
    public class X12_ID_98_NM1_ReceiverName_1000B
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_ReceiverName_1000B
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_ReceiverName_1000B), typeof(X12_ID_1065_NM1_ReceiverName_1000B))]
    public class NM1_ReceiverName_1000B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ReceiverName_1000B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ReceiverName_1000B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ReceiverName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NM1_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string NM1_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_ReceiverName_1000B))]
        [Pos(8)]
        public string InformationReceiverIdentificationNumber_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ReceiverPrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",46,")]
    public class X12_ID_66_NM1_ReceiverName_1000B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_SubmitterName_1000A))]
    public class Loop_1000A
    {
        
        [Required]
        [Pos(1)]
        public NM1_SubmitterName_1000A NM1_SubmitterName_1000A { get; set; }
        [Required]
        [ListCount(2)]
        [Pos(2)]
        public List<PER_SubmitterEDIContactInformation_1000A> PER_SubmitterEDIContactInformation_1000A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",41,")]
    public class X12_ID_98_NM1_SubmitterName_1000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_SubmitterName_1000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_SubmitterEDIContactInformation_1000A
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_SubmitterEDIContactInformation_1000A))]
    public class PER_SubmitterEDIContactInformation_1000A
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_SubmitterEDIContactInformation_1000A))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [Required]
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubmitterContactName_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_SubmitterEDIContactInformation_1000A))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_SubmitterEDIContactInformation_1000A))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_SubmitterEDIContactInformation_1000A))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string CommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ED,EM,FX,TE,")]
    public class X12_ID_365_PER_SubmitterEDIContactInformation_1000A
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_SubmitterName_1000A), typeof(X12_ID_1065_NM1_SubmitterName_1000A))]
    public class NM1_SubmitterName_1000A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_SubmitterName_1000A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_SubmitterName_1000A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string SubmitterLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string SubmitterFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string SubmitterMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string NM1_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_SubmitterName_1000A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string SubmitterIdentifier_09 { get; set; }
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
    [EdiCodes(",46,")]
    public class X12_ID_66_NM1_SubmitterName_1000A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_TransmissionTypeIdentification))]
    public class REF_TransmissionTypeIdentification
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_TransmissionTypeIdentification))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TransmissionTypeCode_02 { get; set; }
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
        public string OriginatorApplicationTransactionIdentifier_03 { get; set; }
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
        [Required]
        [DataElement("640", typeof(X12_ID_640_BHT_BeginningOfHierarchicalTransaction))]
        [Pos(6)]
        public string ClaimOrEncounterIdentifier_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",CH,RP,")]
    public class X12_ID_640_BHT_BeginningOfHierarchicalTransaction
    {
    }
}
