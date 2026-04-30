namespace EdiFabric.Rules.HIPAA_004010X097A1_837
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X097A1", "837")]
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
    [Group(typeof(HL_BillingPaytoProviderHierarchicalLevel_2000A))]
    public class Loop_2000A
    {
        
        [Required]
        [Pos(1)]
        public HL_BillingPaytoProviderHierarchicalLevel_2000A HL_BillingPaytoProviderHierarchicalLevel_2000A { get; set; }
        [Pos(2)]
        public PRV_BillingPaytoProviderSpecialtyInformation_2000A PRV_BillingPaytoProviderSpecialtyInformation_2000A { get; set; }
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
    public class X12_ID_735_HL_BillingPaytoProviderHierarchicalLevel_2000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",BI,PT,")]
    public class X12_ID_1221_PRV_BillingPaytoProviderSpecialtyInformation_2000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_BillingPaytoProviderSpecialtyInformation_2000A
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
    [EdiCodes(",01,19,20,22,29,41,53,76,")]
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
        [Pos(2)]
        public All_DTP_2300 All_DTP_2300 { get; set; }
        [Pos(3)]
        public DN1_OrthodonticTotalMonthsOfTreatment_2300 DN1_OrthodonticTotalMonthsOfTreatment_2300 { get; set; }
        [ListCount(35)]
        [Pos(4)]
        public List<DN2_ToothStatus_2300> DN2_ToothStatus_2300 { get; set; }
        [ListCount(10)]
        [Pos(5)]
        public List<PWK_ClaimSupplementalInformation_2300> PWK_ClaimSupplementalInformation_2300 { get; set; }
        [Pos(6)]
        public All_AMT_2300 All_AMT_2300 { get; set; }
        [Pos(7)]
        public All_REF_2300 All_REF_2300 { get; set; }
        [ListCount(20)]
        [Pos(8)]
        public List<NTE_ClaimNote_2300> NTE_ClaimNote_2300 { get; set; }
        [Pos(9)]
        public All_2310 All_2310 { get; set; }
        [ListCount(10)]
        [Pos(10)]
        public List<Loop_2320> Loop_2320 { get; set; }
        [Required]
        [ListCount(50)]
        [Pos(11)]
        public List<Loop_2400> Loop_2400 { get; set; }
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    [EdiCodes(",E,I,M,")]
    public class X12_ID_1368_DN2_ToothStatus_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",B4,DA,DG,EB,OB,OZ,P6,RB,RR,")]
    public class X12_ID_755_PWK_ClaimSupplementalInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",AA,BM,EL,EM,FX,")]
    public class X12_ID_756_PWK_ClaimSupplementalInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",ADD,")]
    public class X12_ID_363_NTE_ClaimNote_2300
    {
    }
    
    [Serializable()]
    [Group(typeof(LX_LineCounter_2400))]
    public class Loop_2400
    {
        
        [Required]
        [ListCount(50)]
        [Pos(1)]
        public List<LX_LineCounter_2400> LX_LineCounter_2400 { get; set; }
        [Required]
        [Pos(2)]
        public SV3_DentalService_2400 SV3_DentalService_2400 { get; set; }
        [ListCount(32)]
        [Pos(3)]
        public List<TOO_ToothInformation_2400> TOO_ToothInformation_2400 { get; set; }
        [Pos(4)]
        public All_DTP_2400 All_DTP_2400 { get; set; }
        [ListCount(5)]
        [Pos(5)]
        public List<QTY_AnesthesiaQuantity_2400> QTY_AnesthesiaQuantity_2400 { get; set; }
        [Pos(6)]
        public All_REF_2400 All_REF_2400 { get; set; }
        [Pos(7)]
        public All_AMT_2400 All_AMT_2400 { get; set; }
        [ListCount(10)]
        [Pos(8)]
        public List<NTE_LineNote_2400> NTE_LineNote_2400 { get; set; }
        [Pos(9)]
        public All_2420 All_2420 { get; set; }
        [ListCount(25)]
        [Pos(10)]
        public List<Loop_2430> Loop_2430 { get; set; }
    }
    
    [Serializable()]
    public class X12_N0
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,")]
    public class X12_ID_235_C003_769673990
    {
    }
    
    [Serializable()]
    [EdiCodes(",JP,")]
    public class X12_ID_1270_TOO_ToothInformation_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,EM,HM,HO,HP,P3,P4,P5,SG,")]
    public class X12_ID_673_QTY_AnesthesiaQuantity_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",ADD,")]
    public class X12_ID_363_NTE_LineNote_2400
    {
    }
    
    [Serializable()]
    [Group(typeof(SVD_LineAdjudicationInformation_2430))]
    public class Loop_2430
    {
        
        [Required]
        [Pos(1)]
        public SVD_LineAdjudicationInformation_2430 SVD_LineAdjudicationInformation_2430 { get; set; }
        [ListCount(99)]
        [Pos(2)]
        public List<CAS_ServiceAdjustment_2430> CAS_ServiceAdjustment_2430 { get; set; }
        [Required]
        [Pos(3)]
        public DTP_LineAdjudicationDate_2430 DTP_LineAdjudicationDate_2430 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",CO,CR,OA,PI,PR,")]
    public class X12_ID_1033_CAS_ServiceAdjustment_2430
    {
    }
    
    [Serializable()]
    [EdiCodes(",573,")]
    public class X12_ID_374_DTP_LineAdjudicationDate_2430
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_LineAdjudicationDate_2430
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_LineAdjudicationDate_2430), typeof(X12_ID_1250_DTP_LineAdjudicationDate_2430))]
    public class DTP_LineAdjudicationDate_2430
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_LineAdjudicationDate_2430))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_LineAdjudicationDate_2430))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AdjudicationOrPaymentDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("CAS", typeof(X12_ID_1033_CAS_ServiceAdjustment_2430))]
    public class CAS_ServiceAdjustment_2430
    {
        
        [Required]
        [DataElement("1033", typeof(X12_ID_1033_CAS_ServiceAdjustment_2430))]
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
    public class SVD_LineAdjudicationInformation_2430
    {
        
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string OtherPayerPrimaryIdentifier_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ServiceLinePaidAmount_02 { get; set; }
        [Required]
        [Pos(3)]
        public C003_790621493 C003_790621493 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string SVD_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string PaidServiceUnitCount_05 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(6)]
        public string BundledOrUnbundledLineNumber_06 { get; set; }
    }
    
    [Serializable()]
    [Composite("C003_790621493")]
    public class C003_790621493
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_790621493))]
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
    [EdiCodes(",AD,ZZ,")]
    public class X12_ID_235_C003_790621493
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
    [Group(typeof(NM1_AssistantSurgeonName_2420C))]
    public class Loop_2420C
    {
        
        [Required]
        [Pos(1)]
        public NM1_AssistantSurgeonName_2420C NM1_AssistantSurgeonName_2420C { get; set; }
        [Pos(2)]
        public PRV_AssistantSurgeonSpecialtyInformation_2420C PRV_AssistantSurgeonSpecialtyInformation_2420C { get; set; }
        [Pos(3)]
        public REF_AssistantSurgeonSecondaryIdentification_2420C REF_AssistantSurgeonSecondaryIdentification_2420C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DD,")]
    public class X12_ID_98_NM1_AssistantSurgeonName_2420C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_AssistantSurgeonName_2420C
    {
    }
    
    [Serializable()]
    [EdiCodes(",AS,")]
    public class X12_ID_1221_PRV_AssistantSurgeonSpecialtyInformation_2420C
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_AssistantSurgeonSpecialtyInformation_2420C
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,G2,LU,TJ,X4,X5,")]
    public class X12_ID_128_REF_AssistantSurgeonSecondaryIdentification_2420C
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_AssistantSurgeonSecondaryIdentification_2420C))]
    public class REF_AssistantSurgeonSecondaryIdentification_2420C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_AssistantSurgeonSecondaryIdentification_2420C))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string AssistantSurgeonSecondaryIdentifier_02 { get; set; }
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
    [Segment("PRV", typeof(X12_ID_1221_PRV_AssistantSurgeonSpecialtyInformation_2420C), typeof(X12_ID_128_PRV_AssistantSurgeonSpecialtyInformation_2420C))]
    public class PRV_AssistantSurgeonSpecialtyInformation_2420C
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_AssistantSurgeonSpecialtyInformation_2420C))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_AssistantSurgeonSpecialtyInformation_2420C))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_AssistantSurgeonName_2420C), typeof(X12_ID_1065_NM1_AssistantSurgeonName_2420C))]
    public class NM1_AssistantSurgeonName_2420C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_AssistantSurgeonName_2420C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_AssistantSurgeonName_2420C))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AssistantSurgeonLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string AssistantSurgeonFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string AssistantSurgeonMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string AssistantSurgeonNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_AssistantSurgeonName_2420C))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string AssistantSurgeonIdentifier_09 { get; set; }
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
    public class X12_ID_66_NM1_AssistantSurgeonName_2420C
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_OtherPayerReferralNumber_2420B))]
    public class Loop_2420B
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerReferralNumber_2420B NM1_OtherPayerReferralNumber_2420B { get; set; }
        [ListCount(2)]
        [Pos(2)]
        public List<REF_OtherPayerPriorAuthorizationOrReferralNumber_2420B> REF_OtherPayerPriorAuthorizationOrReferralNumber_2420B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_NM1_OtherPayerReferralNumber_2420B
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_OtherPayerReferralNumber_2420B
    {
    }
    
    [Serializable()]
    [EdiCodes(",9F,G1,")]
    public class X12_ID_128_REF_OtherPayerPriorAuthorizationOrReferralNumber_2420B
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerPriorAuthorizationOrReferralNumber_2420B))]
    public class REF_OtherPayerPriorAuthorizationOrReferralNumber_2420B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerPriorAuthorizationOrReferralNumber_2420B))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerReferralNumber_2420B), typeof(X12_ID_1065_NM1_OtherPayerReferralNumber_2420B))]
    public class NM1_OtherPayerReferralNumber_2420B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerReferralNumber_2420B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerReferralNumber_2420B))]
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
        [DataElement("66", typeof(X12_ID_66_NM1_OtherPayerReferralNumber_2420B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string OtherPayerReferralNumber_09 { get; set; }
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
    public class X12_ID_66_NM1_OtherPayerReferralNumber_2420B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_RenderingProviderName_2420A))]
    public class Loop_2420A
    {
        
        [Required]
        [Pos(1)]
        public NM1_RenderingProviderName_2420A NM1_RenderingProviderName_2420A { get; set; }
        [Pos(2)]
        public PRV_RenderingProviderSpecialtyInformation_2420A PRV_RenderingProviderSpecialtyInformation_2420A { get; set; }
        [ListCount(5)]
        [Pos(3)]
        public List<REF_RenderingProviderSecondaryIdentification_2420A> REF_RenderingProviderSecondaryIdentification_2420A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",82,")]
    public class X12_ID_98_NM1_RenderingProviderName_2420A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_RenderingProviderName_2420A
    {
    }
    
    [Serializable()]
    [EdiCodes(",PE,")]
    public class X12_ID_1221_PRV_RenderingProviderSpecialtyInformation_2420A
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_RenderingProviderSpecialtyInformation_2420A
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,EI,G2,G5,LU,SY,TJ,")]
    public class X12_ID_128_REF_RenderingProviderSecondaryIdentification_2420A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_RenderingProviderSecondaryIdentification_2420A))]
    public class REF_RenderingProviderSecondaryIdentification_2420A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_RenderingProviderSecondaryIdentification_2420A))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string RenderingProviderSecondaryIdentifier_02 { get; set; }
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
    [Segment("PRV", typeof(X12_ID_1221_PRV_RenderingProviderSpecialtyInformation_2420A), typeof(X12_ID_128_PRV_RenderingProviderSpecialtyInformation_2420A))]
    public class PRV_RenderingProviderSpecialtyInformation_2420A
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_RenderingProviderSpecialtyInformation_2420A))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_RenderingProviderSpecialtyInformation_2420A))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_RenderingProviderName_2420A), typeof(X12_ID_1065_NM1_RenderingProviderName_2420A))]
    public class NM1_RenderingProviderName_2420A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_RenderingProviderName_2420A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_RenderingProviderName_2420A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string RenderingProviderLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string RenderingProviderFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string RenderingProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string RenderingProviderNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_RenderingProviderName_2420A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string RenderingProviderIdentifier_09 { get; set; }
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
    public class X12_ID_66_NM1_RenderingProviderName_2420A
    {
    }
    
    [Serializable()]
    [Segment("NTE", typeof(X12_ID_363_NTE_LineNote_2400))]
    public class NTE_LineNote_2400
    {
        
        [Required]
        [DataElement("363", typeof(X12_ID_363_NTE_LineNote_2400))]
        [Pos(1)]
        public string NoteReferenceCode_01 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ClaimNoteText_02 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_AMT_2400
    {
        
        [Pos(1)]
        public AMT_ApprovedAmount_2400 AMT_ApprovedAmount_2400 { get; set; }
        [Pos(2)]
        public AMT_SalesTaxAmount_2400 AMT_SalesTaxAmount_2400 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AAE,")]
    public class X12_ID_522_AMT_ApprovedAmount_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",T,")]
    public class X12_ID_522_AMT_SalesTaxAmount_2400
    {
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_SalesTaxAmount_2400))]
    public class AMT_SalesTaxAmount_2400
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_SalesTaxAmount_2400))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string SalesTaxAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_ApprovedAmount_2400))]
    public class AMT_ApprovedAmount_2400
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_ApprovedAmount_2400))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ApprovedAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2400
    {
        
        [Pos(1)]
        public REF_ServicePredeterminationIdentification_2400 REF_ServicePredeterminationIdentification_2400 { get; set; }
        [ListCount(2)]
        [Pos(2)]
        public List<REF_PriorAuthorizationOrReferralNumber_2400> REF_PriorAuthorizationOrReferralNumber_2400 { get; set; }
        [Pos(3)]
        public REF_LineItemControlNumber_2400 REF_LineItemControlNumber_2400 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",G3,")]
    public class X12_ID_128_REF_ServicePredeterminationIdentification_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",9F,G1,")]
    public class X12_ID_128_REF_PriorAuthorizationOrReferralNumber_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",6R,")]
    public class X12_ID_128_REF_LineItemControlNumber_2400
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_LineItemControlNumber_2400))]
    public class REF_LineItemControlNumber_2400
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_LineItemControlNumber_2400))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string LineItemControlNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_PriorAuthorizationOrReferralNumber_2400))]
    public class REF_PriorAuthorizationOrReferralNumber_2400
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PriorAuthorizationOrReferralNumber_2400))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ReferralNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_ServicePredeterminationIdentification_2400))]
    public class REF_ServicePredeterminationIdentification_2400
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ServicePredeterminationIdentification_2400))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PredeterminationOfBenefitsIdentifier_02 { get; set; }
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
    [Segment("QTY", typeof(X12_ID_673_QTY_AnesthesiaQuantity_2400))]
    public class QTY_AnesthesiaQuantity_2400
    {
        
        [Required]
        [DataElement("673", typeof(X12_ID_673_QTY_AnesthesiaQuantity_2400))]
        [Pos(1)]
        public string QuantityQualifier_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string AnesthesiaUnitCount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string QTY_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string QTY_04 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_DTP_2400
    {
        
        [Pos(1)]
        public DTP_DateService_2400 DTP_DateService_2400 { get; set; }
        [Pos(2)]
        public DTP_DatePriorPlacement_2400 DTP_DatePriorPlacement_2400 { get; set; }
        [Pos(3)]
        public DTP_DateAppliancePlacement_2400 DTP_DateAppliancePlacement_2400 { get; set; }
        [Pos(4)]
        public DTP_DateReplacement_2400 DTP_DateReplacement_2400 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",472,")]
    public class X12_ID_374_DTP_DateService_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DateService_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",441,")]
    public class X12_ID_374_DTP_DatePriorPlacement_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DatePriorPlacement_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",452,")]
    public class X12_ID_374_DTP_DateAppliancePlacement_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DateAppliancePlacement_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",446,")]
    public class X12_ID_374_DTP_DateReplacement_2400
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DateReplacement_2400
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateReplacement_2400), typeof(X12_ID_1250_DTP_DateReplacement_2400))]
    public class DTP_DateReplacement_2400
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateReplacement_2400))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateReplacement_2400))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ReplacementDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateAppliancePlacement_2400), typeof(X12_ID_1250_DTP_DateAppliancePlacement_2400))]
    public class DTP_DateAppliancePlacement_2400
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateAppliancePlacement_2400))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateAppliancePlacement_2400))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OrthodonticBandingDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DatePriorPlacement_2400), typeof(X12_ID_1250_DTP_DatePriorPlacement_2400))]
    public class DTP_DatePriorPlacement_2400
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DatePriorPlacement_2400))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DatePriorPlacement_2400))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PriorPlacementDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateService_2400), typeof(X12_ID_1250_DTP_DateService_2400))]
    public class DTP_DateService_2400
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateService_2400))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateService_2400))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ServiceDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("TOO", typeof(X12_ID_1270_TOO_ToothInformation_2400))]
    public class TOO_ToothInformation_2400
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_TOO_ToothInformation_2400))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ToothCode_02 { get; set; }
        [Pos(3)]
        public C005_1144116843 C005_1144116843 { get; set; }
    }
    
    [Serializable()]
    [Composite("C005_1144116843")]
    public class C005_1144116843
    {
        
        [Required]
        [DataElement("1369", typeof(X12_ID_1369_C005_1144116843))]
        [Pos(1)]
        public string ToothSurfaceCode_01 { get; set; }
        [DataElement("1369", typeof(X12_ID_1369_C005_1144116843))]
        [Pos(2)]
        public string ToothSurfaceCode_02 { get; set; }
        [DataElement("1369", typeof(X12_ID_1369_C005_1144116843))]
        [Pos(3)]
        public string ToothSurfaceCode_03 { get; set; }
        [DataElement("1369", typeof(X12_ID_1369_C005_1144116843))]
        [Pos(4)]
        public string ToothSurfaceCode_04 { get; set; }
        [DataElement("1369", typeof(X12_ID_1369_C005_1144116843))]
        [Pos(5)]
        public string ToothSurfaceCode_05 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",B,D,F,I,L,M,O,")]
    public class X12_ID_1369_C005_1144116843
    {
    }
    
    [Serializable()]
    [Segment("SV3", typeof(X12_ID_235_C003_769673990))]
    public class SV3_DentalService_2400
    {
        
        [Required]
        [Pos(1)]
        public C003_769673990 C003_769673990 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string LineItemChargeAmount_02 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string FacilityTypeCode_03 { get; set; }
        [Pos(4)]
        public C006_1953420907 C006_1953420907 { get; set; }
        [DataElement("1358", typeof(X12_ID_1358_SV3_DentalService_2400))]
        [Pos(5)]
        public string ProsthesisCrownOrInlayCode_05 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProcedureCount_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string SV3_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string SV3_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string SV3_09 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string SV3_10 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string SV3_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",I,R,")]
    public class X12_ID_1358_SV3_DentalService_2400
    {
    }
    
    [Serializable()]
    [Composite("C006_1953420907")]
    public class C006_1953420907
    {
        
        [Required]
        [DataElement("1361", typeof(X12_ID_1361_C006_1953420907))]
        [Pos(1)]
        public string OralCavityDesignationCode_01 { get; set; }
        [DataElement("1361", typeof(X12_ID_1361_C006_1953420907))]
        [Pos(2)]
        public string OralCavityDesignationCode_02 { get; set; }
        [DataElement("1361", typeof(X12_ID_1361_C006_1953420907))]
        [Pos(3)]
        public string OralCavityDesignationCode_03 { get; set; }
        [DataElement("1361", typeof(X12_ID_1361_C006_1953420907))]
        [Pos(4)]
        public string OralCavityDesignationCode_04 { get; set; }
        [DataElement("1361", typeof(X12_ID_1361_C006_1953420907))]
        [Pos(5)]
        public string OralCavityDesignationCode_05 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",00,01,02,09,10,20,30,40,L,R,")]
    public class X12_ID_1361_C006_1953420907
    {
    }
    
    [Serializable()]
    [Composite("C003_769673990")]
    public class C003_769673990
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_769673990))]
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
        public string SV3_07 { get; set; }
    }
    
    [Serializable()]
    [Segment("LX")]
    public class LX_LineCounter_2400
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
        public List<CAS_ClaimAdjustment_2320> CAS_ClaimAdjustment_2320 { get; set; }
        [Pos(3)]
        public All_AMT_2320 All_AMT_2320 { get; set; }
        [Pos(4)]
        public DMG_OtherInsuredDemographicInformation_2320 DMG_OtherInsuredDemographicInformation_2320 { get; set; }
        [Required]
        [Pos(5)]
        public OI_OtherInsuranceCoverageInformation_2320 OI_OtherInsuranceCoverageInformation_2320 { get; set; }
        [Required]
        [Pos(6)]
        public All_2330 All_2330 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",P,S,T,")]
    public class X12_ID_1138_SBR_OtherSubscriberInformation_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,18,19,20,21,22,29,76,")]
    public class X12_ID_1069_SBR_OtherSubscriberInformation_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",CO,CR,OA,PI,PR,")]
    public class X12_ID_1033_CAS_ClaimAdjustment_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_OtherInsuredDemographicInformation_2320
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
    }
    
    [Serializable()]
    [Group(typeof(NM1_OtherPayerRenderingProvider_2330E))]
    public class Loop_2330E
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerRenderingProvider_2330E NM1_OtherPayerRenderingProvider_2330E { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<REF_OtherPayerRenderingProviderIdentification_2330E> REF_OtherPayerRenderingProviderIdentification_2330E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",82,")]
    public class X12_ID_98_NM1_OtherPayerRenderingProvider_2330E
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_OtherPayerRenderingProvider_2330E
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,EI,G2,G5,LU,SY,TJ,")]
    public class X12_ID_128_REF_OtherPayerRenderingProviderIdentification_2330E
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerRenderingProviderIdentification_2330E))]
    public class REF_OtherPayerRenderingProviderIdentification_2330E
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerRenderingProviderIdentification_2330E))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerRenderingProviderIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerRenderingProvider_2330E), typeof(X12_ID_1065_NM1_OtherPayerRenderingProvider_2330E))]
    public class NM1_OtherPayerRenderingProvider_2330E
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerRenderingProvider_2330E))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerRenderingProvider_2330E))]
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
    [Group(typeof(NM1_OtherPayerReferringProvider_2330D))]
    public class Loop_2330D
    {
        
        [Required]
        [Pos(1)]
        public NM1_OtherPayerReferringProvider_2330D NM1_OtherPayerReferringProvider_2330D { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<REF_OtherPayerReferringProviderIdentification_2330D> REF_OtherPayerReferringProviderIdentification_2330D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DN,P3,")]
    public class X12_ID_98_NM1_OtherPayerReferringProvider_2330D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_OtherPayerReferringProvider_2330D
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,EI,G2,G5,LU,SY,TJ,")]
    public class X12_ID_128_REF_OtherPayerReferringProviderIdentification_2330D
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerReferringProviderIdentification_2330D))]
    public class REF_OtherPayerReferringProviderIdentification_2330D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerReferringProviderIdentification_2330D))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerReferringProviderIdentifier_02 { get; set; }
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
    [Segment("NM1", typeof(X12_ID_98_NM1_OtherPayerReferringProvider_2330D), typeof(X12_ID_1065_NM1_OtherPayerReferringProvider_2330D))]
    public class NM1_OtherPayerReferringProvider_2330D
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_OtherPayerReferringProvider_2330D))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_OtherPayerReferringProvider_2330D))]
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
        public List<REF_OtherPayerPatientIdentification_2330C> REF_OtherPayerPatientIdentification_2330C { get; set; }
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
    [EdiCodes(",1W,23,IG,SY,")]
    public class X12_ID_128_REF_OtherPayerPatientIdentification_2330C
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerPatientIdentification_2330C))]
    public class REF_OtherPayerPatientIdentification_2330C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerPatientIdentification_2330C))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerPatientPrimaryIdentifier_02 { get; set; }
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
    [EdiCodes(",MI,")]
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
        [ListCount(2)]
        [Pos(2)]
        public List<PER_OtherPayerContactInformation_2330B> PER_OtherPayerContactInformation_2330B { get; set; }
        [Pos(3)]
        public DTP_ClaimPaidDate_2330B DTP_ClaimPaidDate_2330B { get; set; }
        [Pos(4)]
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
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_OtherPayerContactInformation_2330B
    {
    }
    
    [Serializable()]
    [EdiCodes(",573,")]
    public class X12_ID_374_DTP_ClaimPaidDate_2330B
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_ClaimPaidDate_2330B
    {
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2330B
    {
        
        [ListCount(3)]
        [Pos(1)]
        public List<REF_OtherPayerSecondaryIdentifier_2330B> REF_OtherPayerSecondaryIdentifier_2330B { get; set; }
        [ListCount(2)]
        [Pos(2)]
        public List<REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B> REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B { get; set; }
        [Pos(3)]
        public REF_OtherPayerClaimAdjustmentIndicator_2330B REF_OtherPayerClaimAdjustmentIndicator_2330B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",2U,D8,F8,FY,NF,TJ,")]
    public class X12_ID_128_REF_OtherPayerSecondaryIdentifier_2330B
    {
    }
    
    [Serializable()]
    [EdiCodes(",9F,G1,")]
    public class X12_ID_128_REF_OtherPayerPriorAuthorizationOrReferralNumber_2330B
    {
    }
    
    [Serializable()]
    [EdiCodes(",T4,")]
    public class X12_ID_128_REF_OtherPayerClaimAdjustmentIndicator_2330B
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerClaimAdjustmentIndicator_2330B))]
    public class REF_OtherPayerClaimAdjustmentIndicator_2330B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerClaimAdjustmentIndicator_2330B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerClaimAdjustmentIndicator_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_OtherPayerSecondaryIdentifier_2330B))]
    public class REF_OtherPayerSecondaryIdentifier_2330B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherPayerSecondaryIdentifier_2330B))]
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
    [Segment("DTP", typeof(X12_ID_374_DTP_ClaimPaidDate_2330B), typeof(X12_ID_1250_DTP_ClaimPaidDate_2330B))]
    public class DTP_ClaimPaidDate_2330B
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ClaimPaidDate_2330B))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ClaimPaidDate_2330B))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DateClaimPaid_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_OtherPayerContactInformation_2330B))]
    public class PER_OtherPayerContactInformation_2330B
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_OtherPayerContactInformation_2330B))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [Required]
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherPayerContactName_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_OtherPayerContactInformation_2330B))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_OtherPayerContactInformation_2330B))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_OtherPayerContactInformation_2330B))]
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
    public class X12_ID_365_PER_OtherPayerContactInformation_2330B
    {
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
        public N4_OtherSubscriberCityStateZipCode_2330A N4_OtherSubscriberCityStateZipCode_2330A { get; set; }
        [ListCount(3)]
        [Pos(4)]
        public List<REF_OtherSubscriberSecondaryIdentification_2330A> REF_OtherSubscriberSecondaryIdentification_2330A { get; set; }
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
    public class X12_ID_128_REF_OtherSubscriberSecondaryIdentification_2330A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_OtherSubscriberSecondaryIdentification_2330A))]
    public class REF_OtherSubscriberSecondaryIdentification_2330A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherSubscriberSecondaryIdentification_2330A))]
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
    public class N4_OtherSubscriberCityStateZipCode_2330A
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
        [Required]
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
    [EdiCodes(",24,MI,ZZ,")]
    public class X12_ID_66_NM1_OtherSubscriberName_2330A
    {
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
    [EdiCodes(",N,Y,")]
    public class X12_ID_1363_OI_OtherInsuranceCoverageInformation_2320
    {
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_OtherInsuredDemographicInformation_2320))]
    public class DMG_OtherInsuredDemographicInformation_2320
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_OtherInsuredDemographicInformation_2320))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherInsuredBirthDate_02 { get; set; }
        [Required]
        [DataElement("1068", typeof(X12_ID_1068_DMG_OtherInsuredDemographicInformation_2320))]
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
    public class X12_ID_1068_DMG_OtherInsuredDemographicInformation_2320
    {
    }
    
    [Serializable()]
    [All()]
    public class All_AMT_2320
    {
        
        [Pos(1)]
        public AMT_CoordinationOfBenefitsCOBPayerPaidAmount_2320 AMT_CoordinationOfBenefitsCOBPayerPaidAmount_2320 { get; set; }
        [Pos(2)]
        public AMT_CoordinationOfBenefitsCOBApprovedAmount_2320 AMT_CoordinationOfBenefitsCOBApprovedAmount_2320 { get; set; }
        [Pos(3)]
        public AMT_CoordinationOfBenefitsCOBAllowedAmount_2320 AMT_CoordinationOfBenefitsCOBAllowedAmount_2320 { get; set; }
        [Pos(4)]
        public AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_2320 AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_2320 { get; set; }
        [Pos(5)]
        public AMT_CoordinationOfBenefitsCOBCoveredAmount_2320 AMT_CoordinationOfBenefitsCOBCoveredAmount_2320 { get; set; }
        [Pos(6)]
        public AMT_CoordinationOfBenefitsCOBDiscountAmount_2320 AMT_CoordinationOfBenefitsCOBDiscountAmount_2320 { get; set; }
        [Pos(7)]
        public AMT_CoordinationOfBenefitsCOBPatientPaidAmount_2320 AMT_CoordinationOfBenefitsCOBPatientPaidAmount_2320 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",D,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBPayerPaidAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",AAE,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBApprovedAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",B6,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBAllowedAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",F2,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",AU,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBCoveredAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBDiscountAmount_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",F5,")]
    public class X12_ID_522_AMT_CoordinationOfBenefitsCOBPatientPaidAmount_2320
    {
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBPatientPaidAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBPatientPaidAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBPatientPaidAmount_2320))]
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
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBDiscountAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBDiscountAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBDiscountAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string OtherPayerDiscountAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBCoveredAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBCoveredAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBCoveredAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string CoveredAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_2320))]
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
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBAllowedAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBAllowedAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBAllowedAmount_2320))]
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
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBApprovedAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBApprovedAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBApprovedAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ApprovedAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBPayerPaidAmount_2320))]
    public class AMT_CoordinationOfBenefitsCOBPayerPaidAmount_2320
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_CoordinationOfBenefitsCOBPayerPaidAmount_2320))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string PayerPaidAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("CAS", typeof(X12_ID_1033_CAS_ClaimAdjustment_2320))]
    public class CAS_ClaimAdjustment_2320
    {
        
        [Required]
        [DataElement("1033", typeof(X12_ID_1033_CAS_ClaimAdjustment_2320))]
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
        public string PolicyName_04 { get; set; }
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
    [EdiCodes(",09,11,12,13,14,15,16,17,BL,CH,CI,DS,FI,HM,LM,MB,MC,MH,OF,SA,VA,WC,ZZ,")]
    public class X12_ID_1032_SBR_OtherSubscriberInformation_2320
    {
    }
    
    [Serializable()]
    [All()]
    public class All_2310
    {
        
        [ListCount(2)]
        [Pos(1)]
        public List<Loop_2310A> Loop_2310A { get; set; }
        [Pos(2)]
        public Loop_2310B Loop_2310B { get; set; }
        [Pos(3)]
        public Loop_2310C Loop_2310C { get; set; }
        [Pos(4)]
        public Loop_2310D Loop_2310D { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_AssistantSurgeonName_2310D))]
    public class Loop_2310D
    {
        
        [Required]
        [Pos(1)]
        public NM1_AssistantSurgeonName_2310D NM1_AssistantSurgeonName_2310D { get; set; }
        [Pos(2)]
        public PRV_AssistantSurgeonSpecialtyInformation_2310D PRV_AssistantSurgeonSpecialtyInformation_2310D { get; set; }
        [Pos(3)]
        public REF_AssistantSurgeonSecondaryIdentification_2310D REF_AssistantSurgeonSecondaryIdentification_2310D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DD,")]
    public class X12_ID_98_NM1_AssistantSurgeonName_2310D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_AssistantSurgeonName_2310D
    {
    }
    
    [Serializable()]
    [EdiCodes(",AS,")]
    public class X12_ID_1221_PRV_AssistantSurgeonSpecialtyInformation_2310D
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_AssistantSurgeonSpecialtyInformation_2310D
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,G2,LU,TJ,X4,X5,")]
    public class X12_ID_128_REF_AssistantSurgeonSecondaryIdentification_2310D
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_AssistantSurgeonSecondaryIdentification_2310D))]
    public class REF_AssistantSurgeonSecondaryIdentification_2310D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_AssistantSurgeonSecondaryIdentification_2310D))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string AssistantSurgeonSecondaryIdentifier_02 { get; set; }
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
    [Segment("PRV", typeof(X12_ID_1221_PRV_AssistantSurgeonSpecialtyInformation_2310D), typeof(X12_ID_128_PRV_AssistantSurgeonSpecialtyInformation_2310D))]
    public class PRV_AssistantSurgeonSpecialtyInformation_2310D
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_AssistantSurgeonSpecialtyInformation_2310D))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_AssistantSurgeonSpecialtyInformation_2310D))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_AssistantSurgeonName_2310D), typeof(X12_ID_1065_NM1_AssistantSurgeonName_2310D))]
    public class NM1_AssistantSurgeonName_2310D
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_AssistantSurgeonName_2310D))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_AssistantSurgeonName_2310D))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AssistantSurgeonLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string AssistantSurgeonFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string AssistantSurgeonMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string AssistantSurgeonNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_AssistantSurgeonName_2310D))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string AssistantSurgeonIdentifier_09 { get; set; }
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
    public class X12_ID_66_NM1_AssistantSurgeonName_2310D
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_ServiceFacilityLocation_2310C))]
    public class Loop_2310C
    {
        
        [Required]
        [Pos(1)]
        public NM1_ServiceFacilityLocation_2310C NM1_ServiceFacilityLocation_2310C { get; set; }
        [ListCount(5)]
        [Pos(2)]
        public List<REF_ServiceFacilityLocationSecondaryIdentification_2310C> REF_ServiceFacilityLocationSecondaryIdentification_2310C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",FA,")]
    public class X12_ID_98_NM1_ServiceFacilityLocation_2310C
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_ServiceFacilityLocation_2310C
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1G,1H,G2,LU,TJ,X4,X5,")]
    public class X12_ID_128_REF_ServiceFacilityLocationSecondaryIdentification_2310C
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_ServiceFacilityLocationSecondaryIdentification_2310C))]
    public class REF_ServiceFacilityLocationSecondaryIdentification_2310C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ServiceFacilityLocationSecondaryIdentification_2310C))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_ServiceFacilityLocation_2310C), typeof(X12_ID_1065_NM1_ServiceFacilityLocation_2310C))]
    public class NM1_ServiceFacilityLocation_2310C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ServiceFacilityLocation_2310C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ServiceFacilityLocation_2310C))]
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
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_ServiceFacilityLocation_2310C))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
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
    public class X12_ID_66_NM1_ServiceFacilityLocation_2310C
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_RenderingProviderName_2310B))]
    public class Loop_2310B
    {
        
        [Required]
        [Pos(1)]
        public NM1_RenderingProviderName_2310B NM1_RenderingProviderName_2310B { get; set; }
        [Pos(2)]
        public PRV_RenderingProviderSpecialtyInformation_2310B PRV_RenderingProviderSpecialtyInformation_2310B { get; set; }
        [ListCount(5)]
        [Pos(3)]
        public List<REF_RenderingProviderSecondaryIdentification_2310B> REF_RenderingProviderSecondaryIdentification_2310B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",82,")]
    public class X12_ID_98_NM1_RenderingProviderName_2310B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_RenderingProviderName_2310B
    {
    }
    
    [Serializable()]
    [EdiCodes(",PE,")]
    public class X12_ID_1221_PRV_RenderingProviderSpecialtyInformation_2310B
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_RenderingProviderSpecialtyInformation_2310B
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,EI,G2,G5,LU,SY,TJ,")]
    public class X12_ID_128_REF_RenderingProviderSecondaryIdentification_2310B
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_RenderingProviderSecondaryIdentification_2310B))]
    public class REF_RenderingProviderSecondaryIdentification_2310B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_RenderingProviderSecondaryIdentification_2310B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string RenderingProviderSecondaryIdentifier_02 { get; set; }
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
    [Segment("PRV", typeof(X12_ID_1221_PRV_RenderingProviderSpecialtyInformation_2310B), typeof(X12_ID_128_PRV_RenderingProviderSpecialtyInformation_2310B))]
    public class PRV_RenderingProviderSpecialtyInformation_2310B
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_RenderingProviderSpecialtyInformation_2310B))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_RenderingProviderSpecialtyInformation_2310B))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_RenderingProviderName_2310B), typeof(X12_ID_1065_NM1_RenderingProviderName_2310B))]
    public class NM1_RenderingProviderName_2310B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_RenderingProviderName_2310B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_RenderingProviderName_2310B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string RenderingProviderLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string RenderingProviderFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string RenderingProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string RenderingProviderNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_RenderingProviderName_2310B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string RenderingProviderIdentifier_09 { get; set; }
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
    public class X12_ID_66_NM1_RenderingProviderName_2310B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_ReferringProviderName_2310A))]
    public class Loop_2310A
    {
        
        [Required]
        [Pos(1)]
        public NM1_ReferringProviderName_2310A NM1_ReferringProviderName_2310A { get; set; }
        [Pos(2)]
        public PRV_ReferringProviderSpecialtyInformation_2310A PRV_ReferringProviderSpecialtyInformation_2310A { get; set; }
        [ListCount(5)]
        [Pos(3)]
        public List<REF_ReferringProviderSecondaryIdentification_2310A> REF_ReferringProviderSecondaryIdentification_2310A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DN,P3,")]
    public class X12_ID_98_NM1_ReferringProviderName_2310A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_ReferringProviderName_2310A
    {
    }
    
    [Serializable()]
    [EdiCodes(",RF,")]
    public class X12_ID_1221_PRV_ReferringProviderSpecialtyInformation_2310A
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_ReferringProviderSpecialtyInformation_2310A
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,EI,G2,G5,LU,SY,TJ,")]
    public class X12_ID_128_REF_ReferringProviderSecondaryIdentification_2310A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_ReferringProviderSecondaryIdentification_2310A))]
    public class REF_ReferringProviderSecondaryIdentification_2310A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ReferringProviderSecondaryIdentification_2310A))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ReferringProviderSecondaryIdentifier_02 { get; set; }
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
    [Segment("PRV", typeof(X12_ID_1221_PRV_ReferringProviderSpecialtyInformation_2310A), typeof(X12_ID_128_PRV_ReferringProviderSpecialtyInformation_2310A))]
    public class PRV_ReferringProviderSpecialtyInformation_2310A
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_ReferringProviderSpecialtyInformation_2310A))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_ReferringProviderSpecialtyInformation_2310A))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_ReferringProviderName_2310A), typeof(X12_ID_1065_NM1_ReferringProviderName_2310A))]
    public class NM1_ReferringProviderName_2310A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ReferringProviderName_2310A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ReferringProviderName_2310A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ReferringProviderLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ReferringProviderFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ReferringProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ReferringProviderNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_ReferringProviderName_2310A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ReferringProviderIdentifier_09 { get; set; }
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
    public class X12_ID_66_NM1_ReferringProviderName_2310A
    {
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
    [All()]
    public class All_REF_2300
    {
        
        [ListCount(5)]
        [Pos(1)]
        public List<REF_PredeterminationIdentification_2300> REF_PredeterminationIdentification_2300 { get; set; }
        [Pos(2)]
        public REF_ServiceAuthorizationExceptionCode_2300 REF_ServiceAuthorizationExceptionCode_2300 { get; set; }
        [Pos(3)]
        public REF_OriginalReferenceNumberICNDCN_2300 REF_OriginalReferenceNumberICNDCN_2300 { get; set; }
        [ListCount(2)]
        [Pos(4)]
        public List<REF_PriorAuthorizationOrReferralNumber_2300> REF_PriorAuthorizationOrReferralNumber_2300 { get; set; }
        [Pos(5)]
        public REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300 REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",G3,")]
    public class X12_ID_128_REF_PredeterminationIdentification_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",4N,")]
    public class X12_ID_128_REF_ServiceAuthorizationExceptionCode_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",F8,")]
    public class X12_ID_128_REF_OriginalReferenceNumberICNDCN_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",9F,G1,")]
    public class X12_ID_128_REF_PriorAuthorizationOrReferralNumber_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D9,")]
    public class X12_ID_128_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_2300
    {
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
        public string ReferralNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_PredeterminationIdentification_2300))]
    public class REF_PredeterminationIdentification_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PredeterminationIdentification_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PredeterminationOfBenefitsIdentifier_02 { get; set; }
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
        public AMT_PatientAmountPaid_2300 AMT_PatientAmountPaid_2300 { get; set; }
        [Pos(2)]
        public AMT_CreditDebitCardMaximumAmount_2300 AMT_CreditDebitCardMaximumAmount_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",F5,")]
    public class X12_ID_522_AMT_PatientAmountPaid_2300
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
    [Segment("AMT", typeof(X12_ID_522_AMT_PatientAmountPaid_2300))]
    public class AMT_PatientAmountPaid_2300
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_PatientAmountPaid_2300))]
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
    public class X12_ID_66_PWK_ClaimSupplementalInformation_2300
    {
    }
    
    [Serializable()]
    [Segment("DN2")]
    public class DN2_ToothStatus_2300
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ToothNumber_01 { get; set; }
        [Required]
        [DataElement("1368", typeof(X12_ID_1368_DN2_ToothStatus_2300))]
        [Pos(2)]
        public string ToothStatusCode_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string DN2_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string DN2_04 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string DN2_05 { get; set; }
    }
    
    [Serializable()]
    [Segment("DN1")]
    public class DN1_OrthodonticTotalMonthsOfTreatment_2300
    {
        
        [DataElement("", typeof(X12_R))]
        [Pos(1)]
        public string OrthodonticTreatmentMonthsCount_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string OrthodonticTreatmentMonthsRemainingCount_02 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_DN1_OrthodonticTotalMonthsOfTreatment_2300))]
        [Pos(3)]
        public string QuestionResponse_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DN1_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",Y,")]
    public class X12_ID_1073_DN1_OrthodonticTotalMonthsOfTreatment_2300
    {
    }
    
    [Serializable()]
    [All()]
    public class All_DTP_2300
    {
        
        [Pos(1)]
        public DTP_DateAdmission_2300 DTP_DateAdmission_2300 { get; set; }
        [Pos(2)]
        public DTP_DateDischarge_2300 DTP_DateDischarge_2300 { get; set; }
        [Pos(3)]
        public DTP_DateReferral_2300 DTP_DateReferral_2300 { get; set; }
        [Pos(4)]
        public DTP_DateAccident_2300 DTP_DateAccident_2300 { get; set; }
        [ListCount(5)]
        [Pos(5)]
        public List<DTP_DateAppliancePlacement_2300> DTP_DateAppliancePlacement_2300 { get; set; }
        [Pos(6)]
        public DTP_DateService_2300 DTP_DateService_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",435,")]
    public class X12_ID_374_DTP_DateAdmission_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DateAdmission_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",096,")]
    public class X12_ID_374_DTP_DateDischarge_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DateDischarge_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",330,")]
    public class X12_ID_374_DTP_DateReferral_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DateReferral_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",439,")]
    public class X12_ID_374_DTP_DateAccident_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DateAccident_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",452,")]
    public class X12_ID_374_DTP_DateAppliancePlacement_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DateAppliancePlacement_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",472,")]
    public class X12_ID_374_DTP_DateService_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_DateService_2300
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateService_2300), typeof(X12_ID_1250_DTP_DateService_2300))]
    public class DTP_DateService_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateService_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateService_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ServiceDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateAppliancePlacement_2300), typeof(X12_ID_1250_DTP_DateAppliancePlacement_2300))]
    public class DTP_DateAppliancePlacement_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateAppliancePlacement_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateAppliancePlacement_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OrthodonticBandingDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateAccident_2300), typeof(X12_ID_1250_DTP_DateAccident_2300))]
    public class DTP_DateAccident_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateAccident_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateAccident_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string AccidentDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateReferral_2300), typeof(X12_ID_1250_DTP_DateReferral_2300))]
    public class DTP_DateReferral_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateReferral_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateReferral_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ReferralDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateDischarge_2300), typeof(X12_ID_1250_DTP_DateDischarge_2300))]
    public class DTP_DateDischarge_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateDischarge_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateDischarge_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DischargeOrEndOfCareDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DateAdmission_2300), typeof(X12_ID_1250_DTP_DateAdmission_2300))]
    public class DTP_DateAdmission_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DateAdmission_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DateAdmission_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string RelatedHospitalizationAdmissionDate_03 { get; set; }
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
        public C023_748726487 C023_748726487 { get; set; }
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
        [Pos(11)]
        public C024_1545295657 C024_1545295657 { get; set; }
        [DataElement("1366", typeof(X12_ID_1366_CLM_ClaimInformation_2300))]
        [Pos(12)]
        public string SpecialProgramIndicator_12 { get; set; }
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
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(18)]
        public string CLM_18 { get; set; }
        [DataElement("1383", typeof(X12_ID_1383_CLM_ClaimInformation_2300))]
        [Pos(19)]
        public string ClaimSubmissionReasonCode_19 { get; set; }
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
    [EdiCodes(",A,C,P,")]
    public class X12_ID_1359_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1363_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,02,03,05,")]
    public class X12_ID_1366_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",PB,")]
    public class X12_ID_1383_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,9,10,11,")]
    public class X12_ID_1514_CLM_ClaimInformation_2300
    {
    }
    
    [Serializable()]
    [Composite("C024_1545295657")]
    public class C024_1545295657
    {
        
        [Required]
        [DataElement("1362", typeof(X12_ID_1362_C024_1545295657))]
        [Pos(1)]
        public string RelatedCausesCode_01 { get; set; }
        [DataElement("1362", typeof(X12_ID_1362_C024_1545295657))]
        [Pos(2)]
        public string RelatedCausesCode_02 { get; set; }
        [DataElement("1362", typeof(X12_ID_1362_C024_1545295657))]
        [Pos(3)]
        public string RelatedCausesCode_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string AutoAccidentStateOrProvinceCode_04 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string CountryCode_05 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AA,EM,OA,")]
    public class X12_ID_1362_C024_1545295657
    {
    }
    
    [Serializable()]
    [Composite("C023_748726487")]
    public class C023_748726487
    {
        
        [Required]
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string FacilityTypeCode_01 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string CLM_02 { get; set; }
        [Required]
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ClaimSubmissionReasonCode_03 { get; set; }
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
        public List<REF_PatientSecondaryIdentification_2010CA> REF_PatientSecondaryIdentification_2010CA { get; set; }
        [Pos(2)]
        public REF_PropertyAndCasualtyClaimNumber_2010CA REF_PropertyAndCasualtyClaimNumber_2010CA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1W,23,IG,SY,")]
    public class X12_ID_128_REF_PatientSecondaryIdentification_2010CA
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
    [Segment("REF", typeof(X12_ID_128_REF_PatientSecondaryIdentification_2010CA))]
    public class REF_PatientSecondaryIdentification_2010CA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PatientSecondaryIdentification_2010CA))]
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
        [DataElement("1220", typeof(X12_ID_1220_PAT_PatientInformation_2000C))]
        [Pos(4)]
        public string StudentStatusCode_04 { get; set; }
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
    [EdiCodes(",F,N,P,")]
    public class X12_ID_1220_PAT_PatientInformation_2000C
    {
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
        [Required]
        [Pos(2)]
        public Loop_2010BB Loop_2010BB { get; set; }
        [Pos(3)]
        public Loop_2010BC Loop_2010BC { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_CreditDebitCardHolderName_2010BC))]
    public class Loop_2010BC
    {
        
        [Required]
        [Pos(1)]
        public NM1_CreditDebitCardHolderName_2010BC NM1_CreditDebitCardHolderName_2010BC { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<REF_CreditDebitCardInformation_2010BC> REF_CreditDebitCardInformation_2010BC { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AO,")]
    public class X12_ID_98_NM1_CreditDebitCardHolderName_2010BC
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_CreditDebitCardHolderName_2010BC
    {
    }
    
    [Serializable()]
    [EdiCodes(",BB,")]
    public class X12_ID_128_REF_CreditDebitCardInformation_2010BC
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_CreditDebitCardInformation_2010BC))]
    public class REF_CreditDebitCardInformation_2010BC
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_CreditDebitCardInformation_2010BC))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_CreditDebitCardHolderName_2010BC), typeof(X12_ID_1065_NM1_CreditDebitCardHolderName_2010BC))]
    public class NM1_CreditDebitCardHolderName_2010BC
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_CreditDebitCardHolderName_2010BC))]
        [Pos(1)]
        public string LocationQualifier_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_CreditDebitCardHolderName_2010BC))]
        [Pos(2)]
        public string LoopIdentifierCode_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CreditOrDebitCardHolderLastOrOrganizationalName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string EntityTypeQualifier_04 { get; set; }
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
        [DataElement("66", typeof(X12_ID_66_NM1_CreditDebitCardHolderName_2010BC))]
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
    public class X12_ID_66_NM1_CreditDebitCardHolderName_2010BC
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_PayerName_2010BB))]
    public class Loop_2010BB
    {
        
        [Required]
        [Pos(1)]
        public NM1_PayerName_2010BB NM1_PayerName_2010BB { get; set; }
        [Pos(2)]
        public N3_PayerAddress_2010BB N3_PayerAddress_2010BB { get; set; }
        [Pos(3)]
        public N4_PayerCityStateZIPCode_2010BB N4_PayerCityStateZIPCode_2010BB { get; set; }
        [ListCount(3)]
        [Pos(4)]
        public List<REF_PayerSecondaryIdentificationNumber_2010BB> REF_PayerSecondaryIdentificationNumber_2010BB { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_NM1_PayerName_2010BB
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_PayerName_2010BB
    {
    }
    
    [Serializable()]
    [EdiCodes(",2U,FY,NF,TJ,")]
    public class X12_ID_128_REF_PayerSecondaryIdentificationNumber_2010BB
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PayerSecondaryIdentificationNumber_2010BB))]
    public class REF_PayerSecondaryIdentificationNumber_2010BB
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PayerSecondaryIdentificationNumber_2010BB))]
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
    public class N4_PayerCityStateZIPCode_2010BB
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
        public string PayerPostalZoneOrZIPCode_04 { get; set; }
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
    public class N3_PayerAddress_2010BB
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
    [Segment("NM1", typeof(X12_ID_98_NM1_PayerName_2010BB), typeof(X12_ID_1065_NM1_PayerName_2010BB))]
    public class NM1_PayerName_2010BB
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_PayerName_2010BB))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_PayerName_2010BB))]
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
        [DataElement("66", typeof(X12_ID_66_NM1_PayerName_2010BB))]
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
    public class X12_ID_66_NM1_PayerName_2010BB
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
        [Required]
        [DataElement("1143", typeof(X12_ID_1143_SBR_SubscriberInformation_2000B))]
        [Pos(6)]
        public string CoordinationOfBenefitsCode_06 { get; set; }
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
    [EdiCodes(",1,6,")]
    public class X12_ID_1143_SBR_SubscriberInformation_2000B
    {
    }
    
    [Serializable()]
    [EdiCodes(",09,11,12,13,14,15,16,17,BL,CH,CI,DS,FI,HM,LM,MB,MC,MH,OF,SA,VA,WC,ZZ,")]
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
    [Group(typeof(NM1_PaytoProvidersName_2010AB))]
    public class Loop_2010AB
    {
        
        [Required]
        [Pos(1)]
        public NM1_PaytoProvidersName_2010AB NM1_PaytoProvidersName_2010AB { get; set; }
        [Required]
        [Pos(2)]
        public N3_PaytoProvidersAddress_2010AB N3_PaytoProvidersAddress_2010AB { get; set; }
        [Required]
        [Pos(3)]
        public N4_PaytoProviderCityStateZip_2010AB N4_PaytoProviderCityStateZip_2010AB { get; set; }
        [ListCount(5)]
        [Pos(4)]
        public List<REF_PaytoProviderSecondaryIdentificationNumber_2010AB> REF_PaytoProviderSecondaryIdentificationNumber_2010AB { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",87,")]
    public class X12_ID_98_NM1_PaytoProvidersName_2010AB
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_PaytoProvidersName_2010AB
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,EI,G2,G5,LU,SY,TJ,")]
    public class X12_ID_128_REF_PaytoProviderSecondaryIdentificationNumber_2010AB
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PaytoProviderSecondaryIdentificationNumber_2010AB))]
    public class REF_PaytoProviderSecondaryIdentificationNumber_2010AB
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PaytoProviderSecondaryIdentificationNumber_2010AB))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PaytoProviderIdentifier_02 { get; set; }
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
    public class N4_PaytoProviderCityStateZip_2010AB
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
    public class N3_PaytoProvidersAddress_2010AB
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
    [Segment("NM1", typeof(X12_ID_98_NM1_PaytoProvidersName_2010AB), typeof(X12_ID_1065_NM1_PaytoProvidersName_2010AB))]
    public class NM1_PaytoProvidersName_2010AB
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_PaytoProvidersName_2010AB))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_PaytoProvidersName_2010AB))]
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
        public string PaytoProviderFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string PaytoProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string PaytoProviderNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_PaytoProvidersName_2010AB))]
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
    public class X12_ID_66_NM1_PaytoProvidersName_2010AB
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
    }
    
    [Serializable()]
    [EdiCodes(",85,")]
    public class X12_ID_98_NM1_BillingProviderName_2010AA
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_BillingProviderName_2010AA
    {
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2010AA
    {
        
        [ListCount(5)]
        [Pos(1)]
        public List<REF_BillingProviderSecondaryIdentificationNumber_2010AA> REF_BillingProviderSecondaryIdentificationNumber_2010AA { get; set; }
        [ListCount(8)]
        [Pos(2)]
        public List<REF_ClaimSubmitterCreditDebitCardInformation_2010AA> REF_ClaimSubmitterCreditDebitCardInformation_2010AA { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1H,EI,G2,G5,LU,SY,TJ,")]
    public class X12_ID_128_REF_BillingProviderSecondaryIdentificationNumber_2010AA
    {
    }
    
    [Serializable()]
    [EdiCodes(",06,8U,EM,IJ,RB,ST,TT,")]
    public class X12_ID_128_REF_ClaimSubmitterCreditDebitCardInformation_2010AA
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_ClaimSubmitterCreditDebitCardInformation_2010AA))]
    public class REF_ClaimSubmitterCreditDebitCardInformation_2010AA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ClaimSubmitterCreditDebitCardInformation_2010AA))]
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
    [Segment("REF", typeof(X12_ID_128_REF_BillingProviderSecondaryIdentificationNumber_2010AA))]
    public class REF_BillingProviderSecondaryIdentificationNumber_2010AA
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_BillingProviderSecondaryIdentificationNumber_2010AA))]
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
        public string BillingProviderFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string BillingProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string BillingProviderNameSuffix_07 { get; set; }
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
    public class X12_DT
    {
    }
    
    [Serializable()]
    public class X12_TM
    {
    }
    
    [Serializable()]
    [Segment("PRV", typeof(X12_ID_1221_PRV_BillingPaytoProviderSpecialtyInformation_2000A), typeof(X12_ID_128_PRV_BillingPaytoProviderSpecialtyInformation_2000A))]
    public class PRV_BillingPaytoProviderSpecialtyInformation_2000A
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_BillingPaytoProviderSpecialtyInformation_2000A))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_BillingPaytoProviderSpecialtyInformation_2000A))]
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
    [Segment("HL", typeof(X12_ID_735_HL_BillingPaytoProviderHierarchicalLevel_2000A))]
    public class HL_BillingPaytoProviderHierarchicalLevel_2000A
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
        [DataElement("735", typeof(X12_ID_735_HL_BillingPaytoProviderHierarchicalLevel_2000A))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_BillingPaytoProviderHierarchicalLevel_2000A))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_BillingPaytoProviderHierarchicalLevel_2000A
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
        public string IdentificationCodeQualifier_08 { get; set; }
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
        public List<PER_SubmitterContactInformation_1000A> PER_SubmitterContactInformation_1000A { get; set; }
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
    public class X12_ID_366_PER_SubmitterContactInformation_1000A
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_SubmitterContactInformation_1000A))]
    public class PER_SubmitterContactInformation_1000A
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_SubmitterContactInformation_1000A))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [Required]
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubmitterContactName_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_SubmitterContactInformation_1000A))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_SubmitterContactInformation_1000A))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_SubmitterContactInformation_1000A))]
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
    public class X12_ID_365_PER_SubmitterContactInformation_1000A
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
