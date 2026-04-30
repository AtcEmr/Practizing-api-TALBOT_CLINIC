namespace EdiFabric.Rules.HIPAA_004010X092A1_271
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X092A1", "271")]
    public class TS271 : EdiMessage
    {
        
        [Pos(1)]
        public ST ST { get; set; }
        [Required]
        [Pos(2)]
        public BHT_BeginningOfHierarchicalTransaction BHT_BeginningOfHierarchicalTransaction { get; set; }
        [Required]
        [Pos(3)]
        public List<Loop_2000A> Loop_2000A { get; set; }
        [Pos(4)]
        public SE SE { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0022,")]
    public class X12_ID_1005_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [EdiCodes(",11,")]
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
        [ListCount(9)]
        [Pos(2)]
        public List<AAA_RequestValidation_2000A> AAA_RequestValidation_2000A { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2100A Loop_2100A { get; set; }
        [Pos(4)]
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
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_RequestValidation_2000A
    {
    }
    
    [Serializable()]
    public class X12_ID
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
        [ListCount(3)]
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
    [EdiCodes(",1,2,")]
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
        [ListCount(3)]
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
    [EdiCodes(",1,2,")]
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
        [ListCount(3)]
        [Pos(5)]
        public List<PER_DependentContactInformation_2100D> PER_DependentContactInformation_2100D { get; set; }
        [ListCount(9)]
        [Pos(6)]
        public List<AAA_DependentRequestValidation_2100D> AAA_DependentRequestValidation_2100D { get; set; }
        [Pos(7)]
        public DMG_DependentDemographicInformation_2100D DMG_DependentDemographicInformation_2100D { get; set; }
        [Pos(8)]
        public INS_DependentRelationship_2100D INS_DependentRelationship_2100D { get; set; }
        [ListCount(9)]
        [Pos(9)]
        public List<DTP_DependentDate_2100D> DTP_DependentDate_2100D { get; set; }
        [Pos(10)]
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
    [EdiCodes(",18,1L,1W,49,6P,A6,CT,EA,EJ,F6,GH,HJ,IF,IG,M7,N6,NQ,Q4,SY,")]
    public class X12_ID_128_REF_DependentAdditionalIdentification_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_DependentContactInformation_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_DependentRequestValidation_2100D
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
    [EdiCodes(",01,19,21,34,")]
    public class X12_ID_1069_INS_DependentRelationship_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",102,152,291,307,318,340,341,342,343,346,347,382,435,442,458,472,539,540,636,")]
    public class X12_ID_374_DTP_DependentDate_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_DependentDate_2100D
    {
    }
    
    [Serializable()]
    [Group(typeof(EB_DependentEligibilityOrBenefitInformation_2110D))]
    public class Loop_2110D
    {
        
        [Required]
        [Pos(1)]
        public EB_DependentEligibilityOrBenefitInformation_2110D EB_DependentEligibilityOrBenefitInformation_2110D { get; set; }
        [ListCount(9)]
        [Pos(2)]
        public List<HSD_HealthCareServicesDelivery_2110D> HSD_HealthCareServicesDelivery_2110D { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<REF_DependentAdditionalIdentification_2110D> REF_DependentAdditionalIdentification_2110D { get; set; }
        [ListCount(20)]
        [Pos(4)]
        public List<DTP_DependentEligibilityBenefitDate_2110D> DTP_DependentEligibilityBenefitDate_2110D { get; set; }
        [ListCount(9)]
        [Pos(5)]
        public List<AAA_DependentRequestValidation_2110D> AAA_DependentRequestValidation_2110D { get; set; }
        [ListCount(10)]
        [Pos(6)]
        public List<MSG_MessageText_2110D> MSG_MessageText_2110D { get; set; }
        [ListCount(10)]
        [Pos(7)]
        public List<Loop_2115D> Loop_2115D { get; set; }
        [Pos(8)]
        public LSLoop LSLoop { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,CB,MC,")]
    public class X12_ID_1390_EB_DependentEligibilityOrBenefitInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",CHD,DEP,ECH,ESP,FAM,IND,SPC,SPO,")]
    public class X12_ID_1207_EB_DependentEligibilityOrBenefitInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",DY,FL,HS,MN,VS,")]
    public class X12_ID_673_HSD_HealthCareServicesDelivery_2110D
    {
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    [EdiCodes(",18,1L,1W,49,6P,9F,A6,F6,G1,IG,N6,NQ,")]
    public class X12_ID_128_REF_DependentAdditionalIdentification_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",193,194,198,290,292,295,304,307,318,348,349,356,357,435,472,636,771,")]
    public class X12_ID_374_DTP_DependentEligibilityBenefitDate_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_DependentEligibilityBenefitDate_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_DependentRequestValidation_2110D
    {
    }
    
    [Serializable()]
    [Group(typeof(LS_DependentEligibilityOrBenefitInformation_2110D))]
    public class LSLoop
    {
        
        [Required]
        [Pos(1)]
        public LS_DependentEligibilityOrBenefitInformation_2110D LS_DependentEligibilityOrBenefitInformation_2110D { get; set; }
        [Pos(2)]
        public Loop_2120D Loop_2120D { get; set; }
        [Required]
        [Pos(3)]
        public LE_Trailer_2110D LE_Trailer_2110D { get; set; }
    }
    
    [Serializable()]
    [Segment("LE")]
    public class LE_Trailer_2110D
    {
        
        [Required]
        [StringLength(1, 6)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string LoopIdentifierCode_01 { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_DependentBenefitRelatedEntityName_2120D))]
    public class Loop_2120D
    {
        
        [Required]
        [Pos(1)]
        public NM1_DependentBenefitRelatedEntityName_2120D NM1_DependentBenefitRelatedEntityName_2120D { get; set; }
        [Pos(2)]
        public N3_DependentBenefitRelatedEntityAddress_2120D N3_DependentBenefitRelatedEntityAddress_2120D { get; set; }
        [Pos(3)]
        public N4_DependentBenefitRelatedEntityCityStateZIPCode_2120D N4_DependentBenefitRelatedEntityCityStateZIPCode_2120D { get; set; }
        [ListCount(3)]
        [Pos(4)]
        public List<PER_DependentBenefitRelatedEntityContactInformation_2120D> PER_DependentBenefitRelatedEntityContactInformation_2120D { get; set; }
        [Pos(5)]
        public PRV_DependentBenefitRelatedProviderInformation_2120D PRV_DependentBenefitRelatedProviderInformation_2120D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",13,1P,2B,36,73,FA,GP,IL,LR,P3,P4,P5,PR,SEP,TTP,VN,X3,PRP,")]
    public class X12_ID_98_NM1_DependentBenefitRelatedEntityName_2120D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_DependentBenefitRelatedEntityName_2120D
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_DependentBenefitRelatedEntityContactInformation_2120D
    {
    }
    
    [Serializable()]
    [EdiCodes(",AD,AT,BI,CO,CV,H,LA,OT,P1,P2,PC,PE,R,SB,SK,SU,HH,RF,")]
    public class X12_ID_1221_PRV_DependentBenefitRelatedProviderInformation_2120D
    {
    }
    
    [Serializable()]
    [EdiCodes(",9K,D3,EI,HPI,SY,TJ,ZZ,")]
    public class X12_ID_128_PRV_DependentBenefitRelatedProviderInformation_2120D
    {
    }
    
    [Serializable()]
    [Segment("PRV", typeof(X12_ID_1221_PRV_DependentBenefitRelatedProviderInformation_2120D), typeof(X12_ID_128_PRV_DependentBenefitRelatedProviderInformation_2120D))]
    public class PRV_DependentBenefitRelatedProviderInformation_2120D
    {
        
        [Required]
        [DataElement("1221", typeof(X12_ID_1221_PRV_DependentBenefitRelatedProviderInformation_2120D))]
        [Pos(1)]
        public string ProviderCode_01 { get; set; }
        [Required]
        [DataElement("128", typeof(X12_ID_128_PRV_DependentBenefitRelatedProviderInformation_2120D))]
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
    [Segment("PER", typeof(X12_ID_366_PER_DependentBenefitRelatedEntityContactInformation_2120D))]
    public class PER_DependentBenefitRelatedEntityContactInformation_2120D
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_DependentBenefitRelatedEntityContactInformation_2120D))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BenefitRelatedEntityContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_DependentBenefitRelatedEntityContactInformation_2120D))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string BenefitRelatedEntityCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_DependentBenefitRelatedEntityContactInformation_2120D))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string BenefitRelatedEntityCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_DependentBenefitRelatedEntityContactInformation_2120D))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string BenefitRelatedEntityCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ED,EM,FX,TE,WP,")]
    public class X12_ID_365_PER_DependentBenefitRelatedEntityContactInformation_2120D
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_DependentBenefitRelatedEntityCityStateZIPCode_2120D
    {
        
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string BenefitRelatedEntityCityName_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string BenefitRelatedEntityStateCode_02 { get; set; }
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string BenefitRelatedEntityPostalZoneOrZIPCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
        [DataElement("309", typeof(X12_ID_309_N4_DependentBenefitRelatedEntityCityStateZIPCode_2120D))]
        [Pos(5)]
        public string LocationQualifier_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string DepartmentOfDefenseHealthServiceRegionCode_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",RJ,")]
    public class X12_ID_309_N4_DependentBenefitRelatedEntityCityStateZIPCode_2120D
    {
    }
    
    [Serializable()]
    [Segment("N3")]
    public class N3_DependentBenefitRelatedEntityAddress_2120D
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string BenefitRelatedEntityAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BenefitRelatedEntityAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_DependentBenefitRelatedEntityName_2120D), typeof(X12_ID_1065_NM1_DependentBenefitRelatedEntityName_2120D))]
    public class NM1_DependentBenefitRelatedEntityName_2120D
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_DependentBenefitRelatedEntityName_2120D))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_DependentBenefitRelatedEntityName_2120D))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string BenefitRelatedEntityLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string BenefitRelatedEntityFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string BenefitRelatedEntityMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string BenefitRelatedEntityNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_DependentBenefitRelatedEntityName_2120D))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string BenefitRelatedEntityIdentifier_09 { get; set; }
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
    [EdiCodes(",24,34,46,FA,FI,MI,NI,PI,PP,SV,XV,XX,ZZ,")]
    public class X12_ID_66_NM1_DependentBenefitRelatedEntityName_2120D
    {
    }
    
    [Serializable()]
    [Segment("LS")]
    public class LS_DependentEligibilityOrBenefitInformation_2110D
    {
        
        [Required]
        [StringLength(1, 6)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string LoopIdentifierCode_01 { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(III_DependentEligibilityOrBenefitAdditionalInformation_2115D))]
    public class Loop_2115D
    {
        
        [Required]
        [Pos(1)]
        public III_DependentEligibilityOrBenefitAdditionalInformation_2115D III_DependentEligibilityOrBenefitAdditionalInformation_2115D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,BK,ZZ,")]
    public class X12_ID_1270_III_DependentEligibilityOrBenefitAdditionalInformation_2115D
    {
    }
    
    [Serializable()]
    [Segment("III", typeof(X12_ID_1270_III_DependentEligibilityOrBenefitAdditionalInformation_2115D))]
    public class III_DependentEligibilityOrBenefitAdditionalInformation_2115D
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_III_DependentEligibilityOrBenefitAdditionalInformation_2115D))]
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
    [Segment("MSG")]
    public class MSG_MessageText_2110D
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
    public class X12_N0
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_DependentRequestValidation_2110D))]
    public class AAA_DependentRequestValidation_2110D
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_DependentRequestValidation_2110D))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [Required]
        [DataElement("901", typeof(X12_ID_901_AAA_DependentRequestValidation_2110D))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [Required]
        [DataElement("889", typeof(X12_ID_889_AAA_DependentRequestValidation_2110D))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,52,53,54,55,56,57,60,61,62,63,69,70,")]
    public class X12_ID_901_AAA_DependentRequestValidation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,R,W,X,Y,")]
    public class X12_ID_889_AAA_DependentRequestValidation_2110D
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
        public string EligibilityOrBenefitDateTimePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_DependentAdditionalIdentification_2110D))]
    public class REF_DependentAdditionalIdentification_2110D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_DependentAdditionalIdentification_2110D))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DependentEligibilityOrBenefitIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PlanSponsorName_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("HSD", typeof(X12_ID_673_HSD_HealthCareServicesDelivery_2110D))]
    public class HSD_HealthCareServicesDelivery_2110D
    {
        
        [DataElement("673", typeof(X12_ID_673_HSD_HealthCareServicesDelivery_2110D))]
        [Pos(1)]
        public string QuantityQualifier_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string BenefitQuantity_02 { get; set; }
        [DataElement("355", typeof(X12_ID_355_HSD_HealthCareServicesDelivery_2110D))]
        [Pos(3)]
        public string UnitOrBasisForMeasurementCode_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string SampleSelectionModulus_04 { get; set; }
        [DataElement("615", typeof(X12_ID_615_HSD_HealthCareServicesDelivery_2110D))]
        [Pos(5)]
        public string TimePeriodQualifier_05 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(6)]
        public string PeriodCount_06 { get; set; }
        [DataElement("678", typeof(X12_ID_678_HSD_HealthCareServicesDelivery_2110D))]
        [Pos(7)]
        public string DeliveryFrequencyCode_07 { get; set; }
        [DataElement("679", typeof(X12_ID_679_HSD_HealthCareServicesDelivery_2110D))]
        [Pos(8)]
        public string DeliveryPatternTimeCode_08 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DA,MO,VS,WK,YR,")]
    public class X12_ID_355_HSD_HealthCareServicesDelivery_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",6,7,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,")]
    public class X12_ID_615_HSD_HealthCareServicesDelivery_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,SG,SL,SP,SX,SY" +
        ",SZ,")]
    public class X12_ID_678_HSD_HealthCareServicesDelivery_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,B,C,D,E,F,G,Y,")]
    public class X12_ID_679_HSD_HealthCareServicesDelivery_2110D
    {
    }
    
    [Serializable()]
    [Segment("EB", typeof(X12_ID_1390_EB_DependentEligibilityOrBenefitInformation_2110D), typeof(X12_ID_1207_EB_DependentEligibilityOrBenefitInformation_2110D))]
    public class EB_DependentEligibilityOrBenefitInformation_2110D
    {
        
        [Required]
        [DataElement("1390", typeof(X12_ID_1390_EB_DependentEligibilityOrBenefitInformation_2110D))]
        [Pos(1)]
        public string EligibilityOrBenefitInformation_01 { get; set; }
        [DataElement("1207", typeof(X12_ID_1207_EB_DependentEligibilityOrBenefitInformation_2110D))]
        [Pos(2)]
        public string BenefitCoverageLevelCode_02 { get; set; }
        [DataElement("1365", typeof(X12_ID_1365_EB_DependentEligibilityOrBenefitInformation_2110D))]
        [Pos(3)]
        public string ServiceTypeCode_03 { get; set; }
        [DataElement("1336", typeof(X12_ID_1336_EB_DependentEligibilityOrBenefitInformation_2110D))]
        [Pos(4)]
        public string InsuranceTypeCode_04 { get; set; }
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string PlanCoverageDescription_05 { get; set; }
        [DataElement("615", typeof(X12_ID_615_EB_DependentEligibilityOrBenefitInformation_2110D))]
        [Pos(6)]
        public string TimePeriodQualifier_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string BenefitAmount_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string BenefitPercent_08 { get; set; }
        [DataElement("673", typeof(X12_ID_673_EB_DependentEligibilityOrBenefitInformation_2110D))]
        [Pos(9)]
        public string QuantityQualifier_09 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string BenefitQuantity_10 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_EB_DependentEligibilityOrBenefitInformation_2110D))]
        [Pos(11)]
        public string AuthorizationOrCertificationIndicator_11 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_EB_DependentEligibilityOrBenefitInformation_2110D))]
        [Pos(12)]
        public string InPlanNetworkIndicator_12 { get; set; }
        [Pos(13)]
        public C003_843532404 C003_843532404 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,30,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,A0,A1,A2,A3,A4,A5,A6,A7,A8,A9,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AQ,AR,BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BP,BQ,BR,BS,")]
    public class X12_ID_1365_EB_DependentEligibilityOrBenefitInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",12,13,14,15,16,41,42,43,47,AP,C1,CO,CP,D,EP,FF,GP,HM,HN,HS,IN,IP,LC,LD,LI,LT,MA," +
        "MB,MC,MH,MI,MP,OT,PE,PL,PP,PR,PS,QM,RP,SP,TF,WC,WU,DB,")]
    public class X12_ID_1336_EB_DependentEligibilityOrBenefitInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",6,7,13,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,")]
    public class X12_ID_615_EB_DependentEligibilityOrBenefitInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",99,CA,CE,DB,DY,HS,LA,LE,MN,P6,QA,S7,S8,VS,YY,")]
    public class X12_ID_673_EB_DependentEligibilityOrBenefitInformation_2110D
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,U,Y,")]
    public class X12_ID_1073_EB_DependentEligibilityOrBenefitInformation_2110D
    {
    }
    
    [Serializable()]
    [Composite("C003_843532404")]
    public class C003_843532404
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_843532404))]
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
        public string EB_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AD,CJ,HC,ID,IV,N4,ZZ,")]
    public class X12_ID_235_C003_843532404
    {
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
        [DataElement("875", typeof(X12_ID_875_INS_DependentRelationship_2100D))]
        [Pos(3)]
        public string MaintenanceTypeCode_03 { get; set; }
        [DataElement("1203", typeof(X12_ID_1203_INS_DependentRelationship_2100D))]
        [Pos(4)]
        public string MaintenanceReasonCode_04 { get; set; }
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
        [DataElement("1220", typeof(X12_ID_1220_INS_DependentRelationship_2100D))]
        [Pos(9)]
        public string StudentStatusCode_09 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_INS_DependentRelationship_2100D))]
        [Pos(10)]
        public string HandicapIndicator_10 { get; set; }
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
    [EdiCodes(",001,")]
    public class X12_ID_875_INS_DependentRelationship_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",25,")]
    public class X12_ID_1203_INS_DependentRelationship_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",F,N,P,")]
    public class X12_ID_1220_INS_DependentRelationship_2100D
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
    [EdiCodes(",F,M,U,")]
    public class X12_ID_1068_DMG_DependentDemographicInformation_2100D
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_DependentRequestValidation_2100D))]
    public class AAA_DependentRequestValidation_2100D
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_DependentRequestValidation_2100D))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [Required]
        [DataElement("901", typeof(X12_ID_901_AAA_DependentRequestValidation_2100D))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [Required]
        [DataElement("889", typeof(X12_ID_889_AAA_DependentRequestValidation_2100D))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,42,43,45,47,48,49,51,52,56,57,58,60,61,62,63,64,65,66,67,68,71,")]
    public class X12_ID_901_AAA_DependentRequestValidation_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,R,S,W,X,Y,")]
    public class X12_ID_889_AAA_DependentRequestValidation_2100D
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_DependentContactInformation_2100D))]
    public class PER_DependentContactInformation_2100D
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_DependentContactInformation_2100D))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string DependentContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_DependentContactInformation_2100D))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string DependentContactNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_DependentContactInformation_2100D))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string DependentContactNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_DependentContactInformation_2100D))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string DependentContactNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",HP,TE,WP,")]
    public class X12_ID_365_PER_DependentContactInformation_2100D
    {
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
        public string PlanSponsorName_03 { get; set; }
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
        [DataElement("66", typeof(X12_ID_66_NM1_DependentName_2100D))]
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
    public class X12_ID_66_NM1_DependentName_2100D
    {
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
        [ListCount(3)]
        [Pos(5)]
        public List<PER_SubscriberContactInformation_2100C> PER_SubscriberContactInformation_2100C { get; set; }
        [ListCount(9)]
        [Pos(6)]
        public List<AAA_SubscriberRequestValidation_2100C> AAA_SubscriberRequestValidation_2100C { get; set; }
        [Pos(7)]
        public DMG_SubscriberDemographicInformation_2100C DMG_SubscriberDemographicInformation_2100C { get; set; }
        [Pos(8)]
        public INS_SubscriberRelationship_2100C INS_SubscriberRelationship_2100C { get; set; }
        [ListCount(9)]
        [Pos(9)]
        public List<DTP_SubscriberDate_2100C> DTP_SubscriberDate_2100C { get; set; }
        [Pos(10)]
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
    [EdiCodes(",18,1L,1W,3H,49,6P,A6,CT,EA,EJ,F6,GH,HJ,IF,IG,ML,N6,NQ,Q4,SY,")]
    public class X12_ID_128_REF_SubscriberAdditionalIdentification_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_SubscriberContactInformation_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_SubscriberRequestValidation_2100C
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
    [EdiCodes(",102,152,291,307,318,340,341,342,343,346,347,356,357,382,435,442,458,472,539,540," +
        "636,771,")]
    public class X12_ID_374_DTP_SubscriberDate_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_SubscriberDate_2100C
    {
    }
    
    [Serializable()]
    [Group(typeof(EB_SubscriberEligibilityOrBenefitInformation_2110C))]
    public class Loop_2110C
    {
        
        [Required]
        [Pos(1)]
        public EB_SubscriberEligibilityOrBenefitInformation_2110C EB_SubscriberEligibilityOrBenefitInformation_2110C { get; set; }
        [ListCount(9)]
        [Pos(2)]
        public List<HSD_HealthCareServicesDelivery_2110C> HSD_HealthCareServicesDelivery_2110C { get; set; }
        [ListCount(9)]
        [Pos(3)]
        public List<REF_SubscriberAdditionalIdentification_2110C> REF_SubscriberAdditionalIdentification_2110C { get; set; }
        [ListCount(20)]
        [Pos(4)]
        public List<DTP_SubscriberEligibilityBenefitDate_2110C> DTP_SubscriberEligibilityBenefitDate_2110C { get; set; }
        [ListCount(9)]
        [Pos(5)]
        public List<AAA_SubscriberRequestValidation_2110C> AAA_SubscriberRequestValidation_2110C { get; set; }
        [ListCount(10)]
        [Pos(6)]
        public List<MSG_MessageText_2110C> MSG_MessageText_2110C { get; set; }
        [ListCount(10)]
        [Pos(7)]
        public List<Loop_2115C> Loop_2115C { get; set; }
        [Pos(8)]
        public LSLoop LSLoop { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,MC,CB,")]
    public class X12_ID_1390_EB_SubscriberEligibilityOrBenefitInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",CHD,DEP,ECH,EMP,ESP,FAM,IND,SPC,SPO,")]
    public class X12_ID_1207_EB_SubscriberEligibilityOrBenefitInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",DY,FL,HS,MN,VS,")]
    public class X12_ID_673_HSD_HealthCareServicesDelivery_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",18,1L,1W,49,6P,9F,A6,F6,G1,IG,N6,NQ,")]
    public class X12_ID_128_REF_SubscriberAdditionalIdentification_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",193,194,198,290,292,295,304,307,318,348,349,356,357,435,472,636,")]
    public class X12_ID_374_DTP_SubscriberEligibilityBenefitDate_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,RD8,")]
    public class X12_ID_1250_DTP_SubscriberEligibilityBenefitDate_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_SubscriberRequestValidation_2110C
    {
    }
    
    [Serializable()]
    [Group(typeof(III_SubscriberEligibilityOrBenefitAdditionalInformation_2115C))]
    public class Loop_2115C
    {
        
        [Required]
        [Pos(1)]
        public III_SubscriberEligibilityOrBenefitAdditionalInformation_2115C III_SubscriberEligibilityOrBenefitAdditionalInformation_2115C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BF,BK,ZZ,")]
    public class X12_ID_1270_III_SubscriberEligibilityOrBenefitAdditionalInformation_2115C
    {
    }
    
    [Serializable()]
    [Segment("III", typeof(X12_ID_1270_III_SubscriberEligibilityOrBenefitAdditionalInformation_2115C))]
    public class III_SubscriberEligibilityOrBenefitAdditionalInformation_2115C
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_III_SubscriberEligibilityOrBenefitAdditionalInformation_2115C))]
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
    [Segment("MSG")]
    public class MSG_MessageText_2110C
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
    [Segment("AAA", typeof(X12_ID_1073_AAA_SubscriberRequestValidation_2110C))]
    public class AAA_SubscriberRequestValidation_2110C
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_SubscriberRequestValidation_2110C))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [Required]
        [DataElement("901", typeof(X12_ID_901_AAA_SubscriberRequestValidation_2110C))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [Required]
        [DataElement("889", typeof(X12_ID_889_AAA_SubscriberRequestValidation_2110C))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,52,53,54,55,56,57,60,61,62,63,69,70,")]
    public class X12_ID_901_AAA_SubscriberRequestValidation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,R,W,X,Y,")]
    public class X12_ID_889_AAA_SubscriberRequestValidation_2110C
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
        public string EligibilityOrBenefitDateTimePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_SubscriberAdditionalIdentification_2110C))]
    public class REF_SubscriberAdditionalIdentification_2110C
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_SubscriberAdditionalIdentification_2110C))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberEligibilityOrBenefitIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PlanSponsorName_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("HSD", typeof(X12_ID_673_HSD_HealthCareServicesDelivery_2110C))]
    public class HSD_HealthCareServicesDelivery_2110C
    {
        
        [DataElement("673", typeof(X12_ID_673_HSD_HealthCareServicesDelivery_2110C))]
        [Pos(1)]
        public string QuantityQualifier_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string BenefitQuantity_02 { get; set; }
        [DataElement("355", typeof(X12_ID_355_HSD_HealthCareServicesDelivery_2110C))]
        [Pos(3)]
        public string UnitOrBasisForMeasurementCode_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string SampleSelectionModulus_04 { get; set; }
        [DataElement("615", typeof(X12_ID_615_HSD_HealthCareServicesDelivery_2110C))]
        [Pos(5)]
        public string TimePeriodQualifier_05 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(6)]
        public string PeriodCount_06 { get; set; }
        [DataElement("678", typeof(X12_ID_678_HSD_HealthCareServicesDelivery_2110C))]
        [Pos(7)]
        public string DeliveryFrequencyCode_07 { get; set; }
        [DataElement("679", typeof(X12_ID_679_HSD_HealthCareServicesDelivery_2110C))]
        [Pos(8)]
        public string DeliveryPatternTimeCode_08 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DA,MO,VS,WK,YR,")]
    public class X12_ID_355_HSD_HealthCareServicesDelivery_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",6,7,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,")]
    public class X12_ID_615_HSD_HealthCareServicesDelivery_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,SG,SL,SP,SX,SY" +
        ",SZ,")]
    public class X12_ID_678_HSD_HealthCareServicesDelivery_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,B,C,D,E,F,G,Y,")]
    public class X12_ID_679_HSD_HealthCareServicesDelivery_2110C
    {
    }
    
    [Serializable()]
    [Segment("EB", typeof(X12_ID_1390_EB_SubscriberEligibilityOrBenefitInformation_2110C), typeof(X12_ID_1207_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
    public class EB_SubscriberEligibilityOrBenefitInformation_2110C
    {
        
        [Required]
        [DataElement("1390", typeof(X12_ID_1390_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
        [Pos(1)]
        public string EligibilityOrBenefitInformation_01 { get; set; }
        [DataElement("1207", typeof(X12_ID_1207_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
        [Pos(2)]
        public string BenefitCoverageLevelCode_02 { get; set; }
        [DataElement("1365", typeof(X12_ID_1365_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
        [Pos(3)]
        public string ServiceTypeCode_03 { get; set; }
        [DataElement("1336", typeof(X12_ID_1336_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
        [Pos(4)]
        public string InsuranceTypeCode_04 { get; set; }
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string PlanCoverageDescription_05 { get; set; }
        [DataElement("615", typeof(X12_ID_615_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
        [Pos(6)]
        public string TimePeriodQualifier_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string BenefitAmount_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string BenefitPercent_08 { get; set; }
        [DataElement("673", typeof(X12_ID_673_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
        [Pos(9)]
        public string QuantityQualifier_09 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string BenefitQuantity_10 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
        [Pos(11)]
        public string AuthorizationOrCertificationIndicator_11 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_EB_SubscriberEligibilityOrBenefitInformation_2110C))]
        [Pos(12)]
        public string InPlanNetworkIndicator_12 { get; set; }
        [Pos(13)]
        public C003_843401331 C003_843401331 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,30,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,A0,A1,A2,A3,A4,A5,A6,A7,A8,A9,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AQ,AR,BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BP,BQ,BR,BS,")]
    public class X12_ID_1365_EB_SubscriberEligibilityOrBenefitInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",12,13,14,15,16,41,42,43,47,AP,C1,CO,CP,D,EP,FF,GP,HM,HN,HS,IN,IP,LC,LD,LI,LT,MA," +
        "MB,MC,MH,MI,MP,OT,PE,PL,PP,PR,PS,QM,RP,SP,TF,WC,WU,DB,")]
    public class X12_ID_1336_EB_SubscriberEligibilityOrBenefitInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",6,7,13,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,")]
    public class X12_ID_615_EB_SubscriberEligibilityOrBenefitInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",99,CA,CE,DB,DY,HS,LA,LE,MN,P6,QA,S7,S8,VS,YY,")]
    public class X12_ID_673_EB_SubscriberEligibilityOrBenefitInformation_2110C
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,U,Y,")]
    public class X12_ID_1073_EB_SubscriberEligibilityOrBenefitInformation_2110C
    {
    }
    
    [Serializable()]
    [Composite("C003_843401331")]
    public class C003_843401331
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_843401331))]
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
        public string EB_07 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AD,CJ,HC,ID,IV,N4,ZZ,")]
    public class X12_ID_235_C003_843401331
    {
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
        [DataElement("875", typeof(X12_ID_875_INS_SubscriberRelationship_2100C))]
        [Pos(3)]
        public string MaintenanceTypeCode_03 { get; set; }
        [DataElement("1203", typeof(X12_ID_1203_INS_SubscriberRelationship_2100C))]
        [Pos(4)]
        public string MaintenanceReasonCode_04 { get; set; }
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
        [DataElement("1220", typeof(X12_ID_1220_INS_SubscriberRelationship_2100C))]
        [Pos(9)]
        public string StudentStatusCode_09 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_INS_SubscriberRelationship_2100C))]
        [Pos(10)]
        public string HandicapIndicator_10 { get; set; }
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
    [EdiCodes(",001,")]
    public class X12_ID_875_INS_SubscriberRelationship_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",25,")]
    public class X12_ID_1203_INS_SubscriberRelationship_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",F,N,P,")]
    public class X12_ID_1220_INS_SubscriberRelationship_2100C
    {
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
    [EdiCodes(",F,M,U,")]
    public class X12_ID_1068_DMG_SubscriberDemographicInformation_2100C
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_SubscriberRequestValidation_2100C))]
    public class AAA_SubscriberRequestValidation_2100C
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_SubscriberRequestValidation_2100C))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [Required]
        [DataElement("901", typeof(X12_ID_901_AAA_SubscriberRequestValidation_2100C))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [Required]
        [DataElement("889", typeof(X12_ID_889_AAA_SubscriberRequestValidation_2100C))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,42,43,45,47,48,49,51,52,56,57,58,60,61,62,63,64,65,66,67,68,71,72,73,74,75,76" +
        ",77,78,")]
    public class X12_ID_901_AAA_SubscriberRequestValidation_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,R,S,W,X,Y,")]
    public class X12_ID_889_AAA_SubscriberRequestValidation_2100C
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_SubscriberContactInformation_2100C))]
    public class PER_SubscriberContactInformation_2100C
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_SubscriberContactInformation_2100C))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_SubscriberContactInformation_2100C))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string SubscriberContactNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_SubscriberContactInformation_2100C))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string SubscriberContactNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_SubscriberContactInformation_2100C))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string SubscriberContactNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",HP,TE,WP,")]
    public class X12_ID_365_PER_SubscriberContactInformation_2100C
    {
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
        [DataElement("309", typeof(X12_ID_309_N4_SubscriberCityStateZIPCode_2100C))]
        [Pos(5)]
        public string LocationQualifier_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string LocationIdentificationCode_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",CY,FI,")]
    public class X12_ID_309_N4_SubscriberCityStateZIPCode_2100C
    {
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
        public string PlanSponsorName_03 { get; set; }
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
        public string SubscriberNamePrefix_06 { get; set; }
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
        [ListCount(9)]
        [Pos(3)]
        public List<AAA_InformationReceiverRequestValidation_2100B> AAA_InformationReceiverRequestValidation_2100B { get; set; }
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
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_InformationReceiverRequestValidation_2100B
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_InformationReceiverRequestValidation_2100B))]
    public class AAA_InformationReceiverRequestValidation_2100B
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_InformationReceiverRequestValidation_2100B))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [Required]
        [DataElement("901", typeof(X12_ID_901_AAA_InformationReceiverRequestValidation_2100B))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [Required]
        [DataElement("889", typeof(X12_ID_889_AAA_InformationReceiverRequestValidation_2100B))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",15,41,43,44,45,46,47,48,50,51,79,97,T4,")]
    public class X12_ID_901_AAA_InformationReceiverRequestValidation_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,R,S,W,X,Y,")]
    public class X12_ID_889_AAA_InformationReceiverRequestValidation_2100B
    {
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
    [EdiCodes(",0,1,")]
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
        [ListCount(9)]
        [Pos(2)]
        public List<REF_InformationSourceAdditionalIdentification_2100A> REF_InformationSourceAdditionalIdentification_2100A { get; set; }
        [ListCount(3)]
        [Pos(3)]
        public List<PER_InformationSourceContactInformation_2100A> PER_InformationSourceContactInformation_2100A { get; set; }
        [ListCount(9)]
        [Pos(4)]
        public List<AAA_RequestValidation_2100A> AAA_RequestValidation_2100A { get; set; }
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
    [EdiCodes(",18,55,")]
    public class X12_ID_128_REF_InformationSourceAdditionalIdentification_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_InformationSourceContactInformation_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_AAA_RequestValidation_2100A
    {
    }
    
    [Serializable()]
    [Segment("AAA", typeof(X12_ID_1073_AAA_RequestValidation_2100A))]
    public class AAA_RequestValidation_2100A
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_AAA_RequestValidation_2100A))]
        [Pos(1)]
        public string ValidRequestIndicator_01 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string AAA_02 { get; set; }
        [Required]
        [DataElement("901", typeof(X12_ID_901_AAA_RequestValidation_2100A))]
        [Pos(3)]
        public string RejectReasonCode_03 { get; set; }
        [Required]
        [DataElement("889", typeof(X12_ID_889_AAA_RequestValidation_2100A))]
        [Pos(4)]
        public string FollowupActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",04,41,42,79,80,T4,")]
    public class X12_ID_901_AAA_RequestValidation_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",C,N,P,R,S,W,X,Y,")]
    public class X12_ID_889_AAA_RequestValidation_2100A
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_InformationSourceContactInformation_2100A))]
    public class PER_InformationSourceContactInformation_2100A
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_InformationSourceContactInformation_2100A))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InformationSourceContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_InformationSourceContactInformation_2100A))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string InformationSourceCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_InformationSourceContactInformation_2100A))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string InformationSourceCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_InformationSourceContactInformation_2100A))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string InformationSourceCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ED,EM,FX,TE,")]
    public class X12_ID_365_PER_InformationSourceContactInformation_2100A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_InformationSourceAdditionalIdentification_2100A))]
    public class REF_InformationSourceAdditionalIdentification_2100A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_InformationSourceAdditionalIdentification_2100A))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InformationSourceAdditionalPlanIdentifier_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PlanName_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string REF_04 { get; set; }
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
    [EdiCodes(",C,N,P,R,S,Y,")]
    public class X12_ID_889_AAA_RequestValidation_2000A
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
    [EdiCodes(",0,1,")]
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
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string BHT_06 { get; set; }
    }
    
    [Serializable()]
    public class X12_DT
    {
    }
    
    [Serializable()]
    public class X12_TM
    {
    }
}
