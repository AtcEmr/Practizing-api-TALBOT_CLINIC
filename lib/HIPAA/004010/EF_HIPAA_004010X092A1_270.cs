namespace EdiFabric.Rules.HIPAA_004010X092A1_270
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X092A1", "270")]
    public class TS270 : EdiMessage
    {
        
        [Pos(1)]
        public ST ST { get; set; }
        [Pos(2)]
        public WPC_IProcEvnt WPC_IProcEvnt { get; set; }
        [Required]
        [Pos(3)]
        public BHT_BeginningOfHierarchicalTransaction BHT_BeginningOfHierarchicalTransaction { get; set; }
        [Required]
        [Pos(4)]
        public List<Loop_2000A> Loop_2000A { get; set; }
        [Pos(5)]
        public SE SE { get; set; }
    }
    
    [Serializable()]
    public class @string
    {
    }
    
    [Serializable()]
    [EdiCodes(",0022,")]
    public class X12_ID_1005_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,13,36,")]
    public class X12_ID_353_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_InformationSourceLevel_2000A))]
    public class Loop_2000A
    {
        
        [Required]
        [Pos(1)]
        public HL_InformationSourceLevel_2000A HL_InformationSourceLevel_2000A { get; set; }
        [Required]
        [Pos(2)]
        public Loop_2100A Loop_2100A { get; set; }
        [Required]
        [Pos(3)]
        public List<Loop_2000B> Loop_2000B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",20,")]
    public class X12_ID_735_HL_InformationSourceLevel_2000A
    {
    }
    
    [Serializable()]
    public class X12_AN
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_InformationReceiverLevel_2000B))]
    public class Loop_2000B
    {
        
        [Required]
        [Pos(1)]
        public HL_InformationReceiverLevel_2000B HL_InformationReceiverLevel_2000B { get; set; }
        [Required]
        [Pos(2)]
        public Loop_2100B Loop_2100B { get; set; }
        [Required]
        [Pos(3)]
        public List<Loop_2000C> Loop_2000C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",21,")]
    public class X12_ID_735_HL_InformationReceiverLevel_2000B
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_SubscriberLevel_2000C))]
    public class Loop_2000C
    {
        
        [Required]
        [Pos(1)]
        public HL_SubscriberLevel_2000C HL_SubscriberLevel_2000C { get; set; }
        [ListCount(2)]
        [Pos(2)]
        public List<TRN_SubscriberTraceNumber_2000C> TRN_SubscriberTraceNumber_2000C { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2100C Loop_2100C { get; set; }
        [Pos(4)]
        public List<Loop_2000D> Loop_2000D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",22,")]
    public class X12_ID_735_HL_SubscriberLevel_2000C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_481_TRN_SubscriberTraceNumber_2000C
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_DependentLevel_2000D))]
    public class Loop_2000D
    {
        
        [Required]
        [Pos(1)]
        public HL_DependentLevel_2000D HL_DependentLevel_2000D { get; set; }
        [ListCount(2)]
        [Pos(2)]
        public List<TRN_DependentTraceNumber_2000D> TRN_DependentTraceNumber_2000D { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2100D Loop_2100D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",23,")]
    public class X12_ID_735_HL_DependentLevel_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_481_TRN_DependentTraceNumber_2000D
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_DependentName_2100D))]
    public class Loop_2100D
    {
        
        [Required]
        [Pos(1)]
        public NM1_DependentName_2100D NM1_DependentName_2100D { get; set; }
        [ListCount(9)]
        [Pos(2)]
        public List<REF_DependentAdditionalIdentification_2100D> REF_DependentAdditionalIdentification_2100D { get; set; }
        [Pos(3)]
        public N3_DependentAddress_2100D N3_DependentAddress_2100D { get; set; }
        [Pos(4)]
        public N4_DependentCityStateZIPCode_2100D N4_DependentCityStateZIPCode_2100D { get; set; }
        [Pos(5)]
        public PRV_ProviderInformation_2100D PRV_ProviderInformation_2100D { get; set; }
        [Pos(6)]
        public DMG_DependentDemographicInformation_2100D DMG_DependentDemographicInformation_2100D { get; set; }
        [Pos(7)]
        public INS_DependentRelationship_2100D INS_DependentRelationship_2100D { get; set; }
        [ListCount(2)]
        [Pos(8)]
        public List<DTP_DependentDate_2100D> DTP_DependentDate_2100D { get; set; }
        [ListCount(99)]
        [Pos(9)]
        public List<Loop_2110D> Loop_2110D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",03,")]
    public class X12_ID_98_NM1_DependentName_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_DependentName_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",18,1L,6P,A6,CT,EA,EJ,F6,GH,HJ,IF,IG,N6,SY,")]
    public class X12_ID_128_REF_DependentAdditionalIdentification_2100D
    {
    }
    
    [Serializable()]
    public class X12_ID
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,AT,BI,CO,CV,H,LA,OT,P1,P2,PC,PE,R,SB,SK,SU,HH,RF,")]
    public class X12_ID_1221_PRV_ProviderInformation_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",9K,D3,EI,HPI,SY,TJ,ZZ,")]
    public class X12_ID_128_PRV_ProviderInformation_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_DependentDemographicInformation_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,")]
    public class X12_ID_1073_INS_DependentRelationship_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,19,34,")]
    public class X12_ID_1069_INS_DependentRelationship_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",102,307,435,472,")]
    public class X12_ID_374_DTP_DependentDate_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_DependentDate_2100D
    {
    }
    
    [Serializable()]
    [Group(typeof(EQ_DependentEligibilityOrBenefitInquiryInformation_2110D))]
    public class Loop_2110D
    {
        
        [Pos(1)]
        public EQ_DependentEligibilityOrBenefitInquiryInformation_2110D EQ_DependentEligibilityOrBenefitInquiryInformation_2110D { get; set; }
        [ListCount(10)]
        [Pos(2)]
        public List<III_DependentEligibilityOrBenefitAdditionalInquiryInformation_2110D> III_DependentEligibilityOrBenefitAdditionalInquiryInformation_2110D { get; set; }
        [Pos(3)]
        public REF_DependentAdditionalInformation_2110D REF_DependentAdditionalInformation_2110D { get; set; }
        [Pos(4)]
        public DTP_DependentEligibilityBenefitDate_2110D DTP_DependentEligibilityBenefitDate_2110D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,30,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,A0,A1,A2,A3,A4,A5,A6,A7,A8,A9,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AQ,AR,BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BP,BQ,BR,BS,")]
    public class X12_ID_1365_EQ_DependentEligibilityOrBenefitInquiryInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,CJ,HC,ID,IV,N4,ZZ,")]
    public class X12_ID_235_C003_843860081
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,BK,ZZ,")]
    public class X12_ID_1270_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",9F,G1,")]
    public class X12_ID_128_REF_DependentAdditionalInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",307,435,472,")]
    public class X12_ID_374_DTP_DependentEligibilityBenefitDate_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_DependentEligibilityBenefitDate_2110D
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DependentEligibilityBenefitDate_2110D), typeof(X12_ID_1250_DTP_DependentEligibilityBenefitDate_2110D))]
    public class DTP_DependentEligibilityBenefitDate_2110D
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DependentEligibilityBenefitDate_2110D))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DependentEligibilityBenefitDate_2110D))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DateTimePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_DependentAdditionalInformation_2110D))]
    public class REF_DependentAdditionalInformation_2110D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_DependentAdditionalInformation_2110D))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PriorAuthorizationOrReferralNumber_02 { get; set; }
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
    [Segment("III", typeof(X12_ID_1270_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_2110D))]
    public class III_DependentEligibilityOrBenefitAdditionalInquiryInformation_2110D
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_2110D))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string III_03 { get; set; }
        [StringLength(1, 264)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string III_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string III_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string III_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string III_07 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string III_08 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string III_09 { get; set; }
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    [Segment("EQ", typeof(X12_ID_1365_EQ_DependentEligibilityOrBenefitInquiryInformation_2110D), typeof(X12_ID_235_C003_843860081))]
    public class EQ_DependentEligibilityOrBenefitInquiryInformation_2110D
    {
        
        [DataElement("1365", typeof(X12_ID_1365_EQ_DependentEligibilityOrBenefitInquiryInformation_2110D))]
        [Pos(1)]
        public string ServiceTypeCode_01 { get; set; }
        [Pos(2)]
        public C003_843860081 C003_843860081 { get; set; }
        [DataElement("1207", typeof(X12_ID_1207_EQ_DependentEligibilityOrBenefitInquiryInformation_2110D))]
        [Pos(3)]
        public string BenefitCoverageLevelCode_03 { get; set; }
        [DataElement("1336", typeof(X12_ID_1336_EQ_DependentEligibilityOrBenefitInquiryInformation_2110D))]
        [Pos(4)]
        public string InsuranceTypeCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",CHD,DEP,ECH,EMP,ESP,FAM,IND,SPC,SPO,")]
    public class X12_ID_1207_EQ_DependentEligibilityOrBenefitInquiryInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",AP,C1,CO,GP,HM,IP,OT,PR,PS,SP,WC,")]
    public class X12_ID_1336_EQ_DependentEligibilityOrBenefitInquiryInformation_2110D
    {
    }
    
    [Serializable()]
    [Composite("C003_843860081")]
    public class C003_843860081
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_843860081))]
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
        public string EQ_07 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DependentDate_2100D), typeof(X12_ID_1250_DTP_DependentDate_2100D))]
    public class DTP_DependentDate_2100D
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DependentDate_2100D))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DependentDate_2100D))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DateTimePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("INS", typeof(X12_ID_1073_INS_DependentRelationship_2100D), typeof(X12_ID_1069_INS_DependentRelationship_2100D))]
    public class INS_DependentRelationship_2100D
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_INS_DependentRelationship_2100D))]
        [Pos(1)]
        public string InsuredIndicator_01 { get; set; }
        [Required]
        [DataElement("1069", typeof(X12_ID_1069_INS_DependentRelationship_2100D))]
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
    public class X12_N0
    {
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_DependentDemographicInformation_2100D))]
    public class DMG_DependentDemographicInformation_2100D
    {
        
        [DataElement("1250", typeof(X12_ID_1250_DMG_DependentDemographicInformation_2100D))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DependentBirthDate_02 { get; set; }
        [DataElement("1068", typeof(X12_ID_1068_DMG_DependentDemographicInformation_2100D))]
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
    [EdiCodes(",F,M,")]
    public class X12_ID_1068_DMG_DependentDemographicInformation_2100D
    {
    }
    
    [Serializable()]
    [Segment("PRV", typeof(X12_ID_1221_PRV_ProviderInformation_2100D), typeof(X12_ID_128_PRV_ProviderInformation_2100D))]
    public class PRV_ProviderInformation_2100D
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_ProviderInformation_2100D))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_ProviderInformation_2100D))]
        [Pos(2)]
        public string ReferenceIdentificationQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProviderIdentifier_03 { get; set; }
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
    [Segment("N4")]
    public class N4_DependentCityStateZIPCode_2100D
    {
        
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string DependentCityName_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string DependentStateCode_02 { get; set; }
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string DependentPostalZoneOrZIPCode_03 { get; set; }
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
    public class N3_DependentAddress_2100D
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string DependentAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DependentAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_DependentAdditionalIdentification_2100D))]
    public class REF_DependentAdditionalIdentification_2100D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_DependentAdditionalIdentification_2100D))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_DependentName_2100D), typeof(X12_ID_1065_NM1_DependentName_2100D))]
    public class NM1_DependentName_2100D
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_DependentName_2100D))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_DependentName_2100D))]
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
    [Segment("TRN", typeof(X12_ID_481_TRN_DependentTraceNumber_2000D))]
    public class TRN_DependentTraceNumber_2000D
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_DependentTraceNumber_2000D))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TraceNumber_02 { get; set; }
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
    [EdiCodes(",0,")]
    public class X12_ID_736_HL_DependentLevel_2000D
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_SubscriberName_2100C))]
    public class Loop_2100C
    {
        
        [Required]
        [Pos(1)]
        public NM1_SubscriberName_2100C NM1_SubscriberName_2100C { get; set; }
        [ListCount(9)]
        [Pos(2)]
        public List<REF_SubscriberAdditionalIdentification_2100C> REF_SubscriberAdditionalIdentification_2100C { get; set; }
        [Pos(3)]
        public N3_SubscriberAddress_2100C N3_SubscriberAddress_2100C { get; set; }
        [Pos(4)]
        public N4_SubscriberCityStateZIPCode_2100C N4_SubscriberCityStateZIPCode_2100C { get; set; }
        [Pos(5)]
        public PRV_ProviderInformation_2100C PRV_ProviderInformation_2100C { get; set; }
        [Pos(6)]
        public DMG_SubscriberDemographicInformation_2100C DMG_SubscriberDemographicInformation_2100C { get; set; }
        [Pos(7)]
        public INS_SubscriberRelationship_2100C INS_SubscriberRelationship_2100C { get; set; }
        [ListCount(2)]
        [Pos(8)]
        public List<DTP_SubscriberDate_2100C> DTP_SubscriberDate_2100C { get; set; }
        [ListCount(99)]
        [Pos(9)]
        public List<Loop_2110C> Loop_2110C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",IL,")]
    public class X12_ID_98_NM1_SubscriberName_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_SubscriberName_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",18,1L,1W,49,6P,A6,CT,EA,EJ,F6,GH,HJ,IG,N6,NQ,SY,")]
    public class X12_ID_128_REF_SubscriberAdditionalIdentification_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,AT,BI,CO,CV,H,LA,OT,P1,P2,PC,PE,R,SB,SK,SU,HH,RF,")]
    public class X12_ID_1221_PRV_ProviderInformation_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",9K,D3,EI,HPI,SY,TJ,ZZ,")]
    public class X12_ID_128_PRV_ProviderInformation_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_SubscriberDemographicInformation_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",Y,")]
    public class X12_ID_1073_INS_SubscriberRelationship_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",18,")]
    public class X12_ID_1069_INS_SubscriberRelationship_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",102,307,435,472,")]
    public class X12_ID_374_DTP_SubscriberDate_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_SubscriberDate_2100C
    {
    }
    
    [Serializable()]
    [Group(typeof(EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C))]
    public class Loop_2110C
    {
        
        [Pos(1)]
        public EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C { get; set; }
        [Pos(2)]
        public AMT_SubscriberSpendDownAmount_2110C AMT_SubscriberSpendDownAmount_2110C { get; set; }
        [ListCount(10)]
        [Pos(3)]
        public List<III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_2110C> III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_2110C { get; set; }
        [Pos(4)]
        public REF_SubscriberAdditionalInformation_2110C REF_SubscriberAdditionalInformation_2110C { get; set; }
        [Pos(5)]
        public DTP_SubscriberEligibilityBenefitDate_2110C DTP_SubscriberEligibilityBenefitDate_2110C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,30,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,A0,A1,A2,A3,A4,A5,A6,A7,A8,A9,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AQ,AR,BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BP,BQ,BR,BS,")]
    public class X12_ID_1365_EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,CJ,HC,ID,IV,N4,ZZ,")]
    public class X12_ID_235_C003_842352757
    {
    }
    
    [Serializable()]
    [EdiCodes(",R,")]
    public class X12_ID_522_AMT_SubscriberSpendDownAmount_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",BF,BK,ZZ,")]
    public class X12_ID_1270_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",9F,G1,")]
    public class X12_ID_128_REF_SubscriberAdditionalInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",307,435,472,")]
    public class X12_ID_374_DTP_SubscriberEligibilityBenefitDate_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_SubscriberEligibilityBenefitDate_2110C
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_SubscriberEligibilityBenefitDate_2110C), typeof(X12_ID_1250_DTP_SubscriberEligibilityBenefitDate_2110C))]
    public class DTP_SubscriberEligibilityBenefitDate_2110C
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_SubscriberEligibilityBenefitDate_2110C))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_SubscriberEligibilityBenefitDate_2110C))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DateTimePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_SubscriberAdditionalInformation_2110C))]
    public class REF_SubscriberAdditionalInformation_2110C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_SubscriberAdditionalInformation_2110C))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PriorAuthorizationOrReferralNumber_02 { get; set; }
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
    [Segment("III", typeof(X12_ID_1270_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_2110C))]
    public class III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_2110C
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_2110C))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string III_03 { get; set; }
        [StringLength(1, 264)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string III_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string III_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string III_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string III_07 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string III_08 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string III_09 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_SubscriberSpendDownAmount_2110C))]
    public class AMT_SubscriberSpendDownAmount_2110C
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_SubscriberSpendDownAmount_2110C))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string SpendDownAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("EQ", typeof(X12_ID_1365_EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C), typeof(X12_ID_235_C003_842352757))]
    public class EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C
    {
        
        [DataElement("1365", typeof(X12_ID_1365_EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C))]
        [Pos(1)]
        public string ServiceTypeCode_01 { get; set; }
        [Pos(2)]
        public C003_842352757 C003_842352757 { get; set; }
        [DataElement("1207", typeof(X12_ID_1207_EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C))]
        [Pos(3)]
        public string BenefitCoverageLevelCode_03 { get; set; }
        [DataElement("1336", typeof(X12_ID_1336_EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C))]
        [Pos(4)]
        public string InsuranceTypeCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",CHD,DEP,ECH,EMP,ESP,FAM,IND,SPC,SPO,")]
    public class X12_ID_1207_EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",AP,C1,CO,GP,HM,HN,IP,MA,MB,MC,PR,PS,SP,WC,")]
    public class X12_ID_1336_EQ_SubscriberEligibilityOrBenefitInquiryInformation_2110C
    {
    }
    
    [Serializable()]
    [Composite("C003_842352757")]
    public class C003_842352757
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_842352757))]
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
        public string EQ_07 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_SubscriberDate_2100C), typeof(X12_ID_1250_DTP_SubscriberDate_2100C))]
    public class DTP_SubscriberDate_2100C
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_SubscriberDate_2100C))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_SubscriberDate_2100C))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DateTimePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("INS", typeof(X12_ID_1073_INS_SubscriberRelationship_2100C), typeof(X12_ID_1069_INS_SubscriberRelationship_2100C))]
    public class INS_SubscriberRelationship_2100C
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_INS_SubscriberRelationship_2100C))]
        [Pos(1)]
        public string InsuredIndicator_01 { get; set; }
        [Required]
        [DataElement("1069", typeof(X12_ID_1069_INS_SubscriberRelationship_2100C))]
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
        [Required]
        [DataElement("", typeof(X12_N0))]
        [Pos(17)]
        public string BirthSequenceNumber_17 { get; set; }
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_SubscriberDemographicInformation_2100C))]
    public class DMG_SubscriberDemographicInformation_2100C
    {
        
        [DataElement("1250", typeof(X12_ID_1250_DMG_SubscriberDemographicInformation_2100C))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberBirthDate_02 { get; set; }
        [DataElement("1068", typeof(X12_ID_1068_DMG_SubscriberDemographicInformation_2100C))]
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
    [EdiCodes(",F,M,")]
    public class X12_ID_1068_DMG_SubscriberDemographicInformation_2100C
    {
    }
    
    [Serializable()]
    [Segment("PRV", typeof(X12_ID_1221_PRV_ProviderInformation_2100C), typeof(X12_ID_128_PRV_ProviderInformation_2100C))]
    public class PRV_ProviderInformation_2100C
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_ProviderInformation_2100C))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_ProviderInformation_2100C))]
        [Pos(2)]
        public string ReferenceIdentificationQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProviderIdentifier_03 { get; set; }
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
    [Segment("N4")]
    public class N4_SubscriberCityStateZIPCode_2100C
    {
        
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string SubscriberCityName_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string SubscriberStateCode_02 { get; set; }
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
    public class N3_SubscriberAddress_2100C
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
    [Segment("REF", typeof(X12_ID_128_REF_SubscriberAdditionalIdentification_2100C))]
    public class REF_SubscriberAdditionalIdentification_2100C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_SubscriberAdditionalIdentification_2100C))]
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
    [Segment("NM1", typeof(X12_ID_98_NM1_SubscriberName_2100C), typeof(X12_ID_1065_NM1_SubscriberName_2100C))]
    public class NM1_SubscriberName_2100C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_SubscriberName_2100C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_SubscriberName_2100C))]
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
        [DataElement("66", typeof(X12_ID_66_NM1_SubscriberName_2100C))]
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
    public class X12_ID_66_NM1_SubscriberName_2100C
    {
    }
    
    [Serializable()]
    [Segment("TRN", typeof(X12_ID_481_TRN_SubscriberTraceNumber_2000C))]
    public class TRN_SubscriberTraceNumber_2000C
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_SubscriberTraceNumber_2000C))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TraceNumber_02 { get; set; }
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
    [EdiCodes(",0,1,")]
    public class X12_ID_736_HL_SubscriberLevel_2000C
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_InformationReceiverName_2100B))]
    public class Loop_2100B
    {
        
        [Required]
        [Pos(1)]
        public NM1_InformationReceiverName_2100B NM1_InformationReceiverName_2100B { get; set; }
        [ListCount(9)]
        [Pos(2)]
        public List<REF_InformationReceiverAdditionalIdentification_2100B> REF_InformationReceiverAdditionalIdentification_2100B { get; set; }
        [Pos(3)]
        public N3_InformationReceiverAddress_2100B N3_InformationReceiverAddress_2100B { get; set; }
        [Pos(4)]
        public N4_InformationReceiverCityStateZIPCode_2100B N4_InformationReceiverCityStateZIPCode_2100B { get; set; }
        [ListCount(3)]
        [Pos(5)]
        public List<PER_InformationReceiverContactInformation_2100B> PER_InformationReceiverContactInformation_2100B { get; set; }
        [Pos(6)]
        public PRV_InformationReceiverProviderInformation_2100B PRV_InformationReceiverProviderInformation_2100B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1P,2B,36,80,FA,GP,P5,PR,")]
    public class X12_ID_98_NM1_InformationReceiverName_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_InformationReceiverName_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1C,1D,1J,4A,CT,EL,EO,HPI,JD,N5,N7,Q4,SY,TJ,")]
    public class X12_ID_128_REF_InformationReceiverAdditionalIdentification_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_InformationReceiverContactInformation_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,AT,BI,CO,CV,H,HH,LA,OT,P1,P2,PC,PE,R,RF,SB,SK,SU,")]
    public class X12_ID_1221_PRV_InformationReceiverProviderInformation_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",ZZ,")]
    public class X12_ID_128_PRV_InformationReceiverProviderInformation_2100B
    {
    }
    
    [Serializable()]
    [Segment("PRV", typeof(X12_ID_1221_PRV_InformationReceiverProviderInformation_2100B), typeof(X12_ID_128_PRV_InformationReceiverProviderInformation_2100B))]
    public class PRV_InformationReceiverProviderInformation_2100B
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_InformationReceiverProviderInformation_2100B))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_InformationReceiverProviderInformation_2100B))]
        [Pos(2)]
        public string ReferenceIdentificationQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ReceiverProviderSpecialtyCode_03 { get; set; }
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
    [Segment("PER", typeof(X12_ID_366_PER_InformationReceiverContactInformation_2100B))]
    public class PER_InformationReceiverContactInformation_2100B
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_InformationReceiverContactInformation_2100B))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InformationReceiverContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_InformationReceiverContactInformation_2100B))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string InformationReceiverCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_InformationReceiverContactInformation_2100B))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string InformationReceiverCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_InformationReceiverContactInformation_2100B))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string InformationReceiverCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ED,EM,FX,TE,")]
    public class X12_ID_365_PER_InformationReceiverContactInformation_2100B
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_InformationReceiverCityStateZIPCode_2100B
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string InformationReceiverCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string InformationReceiverStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string InformationReceiverPostalZoneOrZIPCode_03 { get; set; }
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
    public class N3_InformationReceiverAddress_2100B
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string InformationReceiverAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InformationReceiverAdditionalAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_InformationReceiverAdditionalIdentification_2100B))]
    public class REF_InformationReceiverAdditionalIdentification_2100B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_InformationReceiverAdditionalIdentification_2100B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InformationReceiverAdditionalIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string LicenseNumberStateCode_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_InformationReceiverName_2100B), typeof(X12_ID_1065_NM1_InformationReceiverName_2100B))]
    public class NM1_InformationReceiverName_2100B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_InformationReceiverName_2100B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_InformationReceiverName_2100B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string InformationReceiverLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string InformationReceiverFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string InformationReceiverMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string InformationReceiverNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_InformationReceiverName_2100B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string InformationReceiverIdentificationNumber_09 { get; set; }
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
    [EdiCodes(",24,34,FI,PI,PP,SV,XV,XX,")]
    public class X12_ID_66_NM1_InformationReceiverName_2100B
    {
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_InformationReceiverLevel_2000B))]
    public class HL_InformationReceiverLevel_2000B
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
        [DataElement("735", typeof(X12_ID_735_HL_InformationReceiverLevel_2000B))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_InformationReceiverLevel_2000B))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_InformationReceiverLevel_2000B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_InformationSourceName_2100A))]
    public class Loop_2100A
    {
        
        [Required]
        [Pos(1)]
        public NM1_InformationSourceName_2100A NM1_InformationSourceName_2100A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",2B,36,GP,P5,PR,")]
    public class X12_ID_98_NM1_InformationSourceName_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_InformationSourceName_2100A
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_InformationSourceName_2100A), typeof(X12_ID_1065_NM1_InformationSourceName_2100A))]
    public class NM1_InformationSourceName_2100A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_InformationSourceName_2100A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_InformationSourceName_2100A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string InformationSourceLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string InformationSourceFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string InformationSourceMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string InformationSourceNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_InformationSourceName_2100A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string InformationSourcePrimaryIdentifier_09 { get; set; }
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
    [EdiCodes(",24,46,FI,NI,PI,XV,XX,")]
    public class X12_ID_66_NM1_InformationSourceName_2100A
    {
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_InformationSourceLevel_2000A))]
    public class HL_InformationSourceLevel_2000A
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
        [DataElement("735", typeof(X12_ID_735_HL_InformationSourceLevel_2000A))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_InformationSourceLevel_2000A))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_InformationSourceLevel_2000A
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
    public class X12_DT
    {
    }
    
    [Serializable()]
    public class X12_TM
    {
    }
    
    [Serializable()]
    [EdiCodes(",RT,RU,")]
    public class X12_ID_640_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [Segment("WPC")]
    public class WPC_IProcEvnt
    {
        
        [DataElement("", typeof(string))]
        [Pos(1)]
        public string s_01 { get; set; }
        [DataElement("", typeof(string))]
        [Pos(2)]
        public string ty_02 { get; set; }
        [DataElement("", typeof(string))]
        [Pos(3)]
        public string _03 { get; set; }
        [DataElement("", typeof(string))]
        [Pos(4)]
        public string h_04 { get; set; }
    }
}
