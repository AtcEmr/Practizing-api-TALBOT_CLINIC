namespace EdiFabric.Rules.HIPAA_004010X095A1_834
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X095A1", "834")]
    public class TS834 : EdiMessage
    {
        
        [Pos(1)]
        public ST ST { get; set; }
        [Required]
        [Pos(2)]
        public BGN_BeginningSegment BGN_BeginningSegment { get; set; }
        [Pos(3)]
        public REF_TransactionSetPolicyNumber REF_TransactionSetPolicyNumber { get; set; }
        [Pos(4)]
        public List<DTP_FileEffectiveDate> DTP_FileEffectiveDate { get; set; }
        [Required]
        [Pos(5)]
        public Loop_1000A Loop_1000A { get; set; }
        [Required]
        [Pos(6)]
        public Loop_1000B Loop_1000B { get; set; }
        [ListCount(2)]
        [Pos(7)]
        public List<Loop_1000C> Loop_1000C { get; set; }
        [Required]
        [Pos(8)]
        public List<Loop_2000> Loop_2000 { get; set; }
        [Pos(9)]
        public SE SE { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",00,15,22,")]
    public class X12_ID_353_BGN_BeginningSegment
    {
    }
    
    [Serializable()]
    public class X12_AN
    {
    }
    
    [Serializable()]
    [EdiCodes(",38,")]
    public class X12_ID_128_REF_TransactionSetPolicyNumber
    {
    }
    
    [Serializable()]
    [EdiCodes(",007,303,382,388,")]
    public class X12_ID_374_DTP_FileEffectiveDate
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_FileEffectiveDate
    {
    }
    
    [Serializable()]
    [Group(typeof(INS_MemberLevelDetail_2000))]
    public class Loop_2000
    {
        
        [Required]
        [Pos(1)]
        public INS_MemberLevelDetail_2000 INS_MemberLevelDetail_2000 { get; set; }
        [Required]
        [Pos(2)]
        public All_REF_2000 All_REF_2000 { get; set; }
        [ListCount(20)]
        [Pos(3)]
        public List<DTP_MemberLevelDates_2000> DTP_MemberLevelDates_2000 { get; set; }
        [Required]
        [Pos(4)]
        public Loop_2100A Loop_2100A { get; set; }
        [Pos(5)]
        public Loop_2100B Loop_2100B { get; set; }
        [Pos(6)]
        public Loop_2100C Loop_2100C { get; set; }
        [ListCount(3)]
        [Pos(7)]
        public List<Loop_2100D> Loop_2100D { get; set; }
        [ListCount(3)]
        [Pos(8)]
        public List<Loop_2100E> Loop_2100E { get; set; }
        [Pos(9)]
        public Loop_2100F Loop_2100F { get; set; }
        [Pos(10)]
        public Loop_2100G Loop_2100G { get; set; }
        [Pos(11)]
        public Loop_2200 Loop_2200 { get; set; }
        [ListCount(99)]
        [Pos(12)]
        public List<Loop_2300> Loop_2300 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",N,Y,")]
    public class X12_ID_1073_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,03,04,05,06,07,08,09,10,11,12,13,14,15,17,18,19,23,24,25,26,31,32,33,38,48,49" +
        ",53,")]
    public class X12_ID_1069_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",286,296,297,300,301,303,336,337,338,339,340,341,350,351,356,357,383,393,394,473," +
        "474,")]
    public class X12_ID_374_DTP_MemberLevelDates_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_MemberLevelDates_2000
    {
    }
    
    [Serializable()]
    [Group(typeof(HD_HealthCoverage_2300))]
    public class Loop_2300
    {
        
        [Required]
        [Pos(1)]
        public HD_HealthCoverage_2300 HD_HealthCoverage_2300 { get; set; }
        [Required]
        [ListCount(4)]
        [Pos(2)]
        public List<DTP_HealthCoverageDates_2300> DTP_HealthCoverageDates_2300 { get; set; }
        [ListCount(4)]
        [Pos(3)]
        public List<AMT_HealthCoveragePolicy_2300> AMT_HealthCoveragePolicy_2300 { get; set; }
        [ListCount(2)]
        [Pos(4)]
        public List<REF_HealthCoveragePolicyNumber_2300> REF_HealthCoveragePolicyNumber_2300 { get; set; }
        [ListCount(10)]
        [Pos(5)]
        public List<IDC_IdentificationCard_2300> IDC_IdentificationCard_2300 { get; set; }
        [ListCount(30)]
        [Pos(6)]
        public List<Loop_2310> Loop_2310 { get; set; }
        [ListCount(5)]
        [Pos(7)]
        public List<Loop_2320> Loop_2320 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",001,002,021,024,025,026,030,032,")]
    public class X12_ID_875_HD_HealthCoverage_2300
    {
    }
    
    [Serializable()]
    public class X12_ID
    {
    }
    
    [Serializable()]
    [EdiCodes(",303,348,349,543,")]
    public class X12_ID_374_DTP_HealthCoverageDates_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_HealthCoverageDates_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",B9,C1,D2,P3,")]
    public class X12_ID_522_AMT_HealthCoveragePolicy_2300
    {
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    [EdiCodes(",17,1L,ZZ,")]
    public class X12_ID_128_REF_HealthCoveragePolicyNumber_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",D,H,P,")]
    public class X12_ID_1215_IDC_IdentificationCard_2300
    {
    }
    
    [Serializable()]
    [Group(typeof(COB_CoordinationOfBenefits_2320))]
    public class Loop_2320
    {
        
        [Required]
        [Pos(1)]
        public COB_CoordinationOfBenefits_2320 COB_CoordinationOfBenefits_2320 { get; set; }
        [ListCount(5)]
        [Pos(2)]
        public List<REF_AdditionalCoordinationOfBenefitsIdentifiers_2320> REF_AdditionalCoordinationOfBenefitsIdentifiers_2320 { get; set; }
        [Pos(3)]
        public N1_OtherInsuranceCompanyName_2320 N1_OtherInsuranceCompanyName_2320 { get; set; }
        [ListCount(2)]
        [Pos(4)]
        public List<DTP_CoordinationOfBenefitsEligibilityDates_2320> DTP_CoordinationOfBenefitsEligibilityDates_2320 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",P,S,T,U,")]
    public class X12_ID_1138_COB_CoordinationOfBenefits_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",60,6P,A6,SY,ZZ,")]
    public class X12_ID_128_REF_AdditionalCoordinationOfBenefitsIdentifiers_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",IN,")]
    public class X12_ID_98_N1_OtherInsuranceCompanyName_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",344,345,")]
    public class X12_ID_374_DTP_CoordinationOfBenefitsEligibilityDates_2320
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_CoordinationOfBenefitsEligibilityDates_2320
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_CoordinationOfBenefitsEligibilityDates_2320), typeof(X12_ID_1250_DTP_CoordinationOfBenefitsEligibilityDates_2320))]
    public class DTP_CoordinationOfBenefitsEligibilityDates_2320
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_CoordinationOfBenefitsEligibilityDates_2320))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_CoordinationOfBenefitsEligibilityDates_2320))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CoordinationOfBenefitsDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("N1", typeof(X12_ID_98_N1_OtherInsuranceCompanyName_2320))]
    public class N1_OtherInsuranceCompanyName_2320
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_N1_OtherInsuranceCompanyName_2320))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InsurerName_02 { get; set; }
        [DataElement("66", typeof(X12_ID_66_N1_OtherInsuranceCompanyName_2320))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string InsuredGroupOrPolicyNumber_04 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string N1_05 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string N1_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",FI,NI,XV,")]
    public class X12_ID_66_N1_OtherInsuranceCompanyName_2320
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_AdditionalCoordinationOfBenefitsIdentifiers_2320))]
    public class REF_AdditionalCoordinationOfBenefitsIdentifiers_2320
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_AdditionalCoordinationOfBenefitsIdentifiers_2320))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InsuredGroupOrPolicyNumber_02 { get; set; }
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
    [Segment("COB", typeof(X12_ID_1138_COB_CoordinationOfBenefits_2320))]
    public class COB_CoordinationOfBenefits_2320
    {
        
        [Required]
        [DataElement("1138", typeof(X12_ID_1138_COB_CoordinationOfBenefits_2320))]
        [Pos(1)]
        public string PayerResponsibilitySequenceNumberCode_01 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InsuredGroupOrPolicyNumber_02 { get; set; }
        [Required]
        [DataElement("1143", typeof(X12_ID_1143_COB_CoordinationOfBenefits_2320))]
        [Pos(3)]
        public string CoordinationOfBenefitsCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,5,6,")]
    public class X12_ID_1143_COB_CoordinationOfBenefits_2320
    {
    }
    
    [Serializable()]
    [Group(typeof(LX_ProviderInformation_2310))]
    public class Loop_2310
    {
        
        [Required]
        [Pos(1)]
        public LX_ProviderInformation_2310 LX_ProviderInformation_2310 { get; set; }
        [Required]
        [Pos(2)]
        public NM1_ProviderName_2310 NM1_ProviderName_2310 { get; set; }
        [Pos(3)]
        public N4_ProviderCityStateZIPCode_2310 N4_ProviderCityStateZIPCode_2310 { get; set; }
        [ListCount(2)]
        [Pos(4)]
        public List<PER_ProviderCommunicationsNumbers_2310> PER_ProviderCommunicationsNumbers_2310 { get; set; }
        [Pos(5)]
        public PLA_PCPChangeReason_2310 PLA_PCPChangeReason_2310 { get; set; }
    }
    
    [Serializable()]
    public class X12_N0
    {
    }
    
    [Serializable()]
    [EdiCodes(",3D,OD,P3,QA,QN,Y2,")]
    public class X12_ID_98_NM1_ProviderName_2310
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_ProviderName_2310
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_ProviderCommunicationsNumbers_2310
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_306_PLA_PCPChangeReason_2310
    {
    }
    
    [Serializable()]
    [EdiCodes(",1P,")]
    public class X12_ID_98_PLA_PCPChangeReason_2310
    {
    }
    
    [Serializable()]
    [Segment("PLA", typeof(X12_ID_306_PLA_PCPChangeReason_2310), typeof(X12_ID_98_PLA_PCPChangeReason_2310))]
    public class PLA_PCPChangeReason_2310
    {
        
        [Required]
        [DataElement("306", typeof(X12_ID_306_PLA_PCPChangeReason_2310))]
        [Pos(1)]
        public string ActionCode_01 { get; set; }
        [Required]
        [DataElement("98", typeof(X12_ID_98_PLA_PCPChangeReason_2310))]
        [Pos(2)]
        public string EntityIdentifierCode_02 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(3)]
        public string ProviderEffectiveDate_03 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(4)]
        public string PLA_04 { get; set; }
        [Required]
        [DataElement("1203", typeof(X12_ID_1203_PLA_PCPChangeReason_2310))]
        [Pos(5)]
        public string MaintenanceReasonCode_05 { get; set; }
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
    [EdiCodes(",14,22,46,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,")]
    public class X12_ID_1203_PLA_PCPChangeReason_2310
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_ProviderCommunicationsNumbers_2310))]
    public class PER_ProviderCommunicationsNumbers_2310
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_ProviderCommunicationsNumbers_2310))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PER_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_ProviderCommunicationsNumbers_2310))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ProviderCommunicationsNumbers_2310))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ProviderCommunicationsNumbers_2310))]
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
    [EdiCodes(",EM,EX,FX,HP,TE,WP,")]
    public class X12_ID_365_PER_ProviderCommunicationsNumbers_2310
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_ProviderCityStateZIPCode_2310
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string MemberCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string MemberStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string MemberPostalZoneOrZipCode_03 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
        [DataElement("309", typeof(X12_ID_309_N4_ProviderCityStateZIPCode_2310))]
        [Pos(5)]
        public string LocationQualifier_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string LocationIdentificationCode_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",60,CY,RJ,")]
    public class X12_ID_309_N4_ProviderCityStateZIPCode_2310
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_ProviderName_2310), typeof(X12_ID_1065_NM1_ProviderName_2310))]
    public class NM1_ProviderName_2310
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ProviderName_2310))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ProviderName_2310))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProviderLastOrOrganizationName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProviderFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ProviderMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ProviderNamePrefix_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ProviderNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_ProviderName_2310))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ProviderIdentifier_09 { get; set; }
        [Required]
        [DataElement("706", typeof(X12_ID_706_NM1_ProviderName_2310))]
        [Pos(10)]
        public string EntityRelationshipCode_10 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string NM1_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",34,FI,SV,XX,")]
    public class X12_ID_66_NM1_ProviderName_2310
    {
    }
    
    [Serializable()]
    [EdiCodes(",25,26,72,")]
    public class X12_ID_706_NM1_ProviderName_2310
    {
    }
    
    [Serializable()]
    [Segment("LX")]
    public class LX_ProviderInformation_2310
    {
        
        [Required]
        [DataElement("", typeof(X12_N0))]
        [Pos(1)]
        public string AssignedNumber_01 { get; set; }
    }
    
    [Serializable()]
    [Segment("IDC")]
    public class IDC_IdentificationCard_2300
    {
        
        [Required]
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PlanCoverageDescription_01 { get; set; }
        [Required]
        [DataElement("1215", typeof(X12_ID_1215_IDC_IdentificationCard_2300))]
        [Pos(2)]
        public string IdentificationCardTypeCode_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string IdentificationCardCount_03 { get; set; }
        [DataElement("306", typeof(X12_ID_306_IDC_IdentificationCard_2300))]
        [Pos(4)]
        public string ActionCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,2,RX,")]
    public class X12_ID_306_IDC_IdentificationCard_2300
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_HealthCoveragePolicyNumber_2300))]
    public class REF_HealthCoveragePolicyNumber_2300
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_HealthCoveragePolicyNumber_2300))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InsuredGroupOrPolicyNumber_02 { get; set; }
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
    [Segment("AMT", typeof(X12_ID_522_AMT_HealthCoveragePolicy_2300))]
    public class AMT_HealthCoveragePolicy_2300
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_HealthCoveragePolicy_2300))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ContractAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_HealthCoverageDates_2300), typeof(X12_ID_1250_DTP_HealthCoverageDates_2300))]
    public class DTP_HealthCoverageDates_2300
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_HealthCoverageDates_2300))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_HealthCoverageDates_2300))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CoveragePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("HD", typeof(X12_ID_875_HD_HealthCoverage_2300))]
    public class HD_HealthCoverage_2300
    {
        
        [Required]
        [DataElement("875", typeof(X12_ID_875_HD_HealthCoverage_2300))]
        [Pos(1)]
        public string MaintenanceTypeCode_01 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string HD_02 { get; set; }
        [Required]
        [DataElement("1205", typeof(X12_ID_1205_HD_HealthCoverage_2300))]
        [Pos(3)]
        public string InsuranceLineCode_03 { get; set; }
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string PlanCoverageDescription_04 { get; set; }
        [DataElement("1207", typeof(X12_ID_1207_HD_HealthCoverage_2300))]
        [Pos(5)]
        public string CoverageLevelCode_05 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(6)]
        public string HD_06 { get; set; }
        [DataElement("", typeof(X12_N0))]
        [Pos(7)]
        public string HD_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string HD_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string HD_09 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string HD_10 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string HD_11 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AG,AH,AJ,AK,DCP,DEN,EPO,FAC,HE,HLT,HMO,LTC,LTD,MM,MOD,PDG,POS,PPO,PRA,STD,UR,VIS" +
        ",")]
    public class X12_ID_1205_HD_HealthCoverage_2300
    {
    }
    
    [Serializable()]
    [EdiCodes(",CHD,DEP,E1D,E2D,E3D,E5D,E6D,E7D,E8D,E9D,ECH,EMP,ESP,FAM,IND,SPC,SPO,TWO,")]
    public class X12_ID_1207_HD_HealthCoverage_2300
    {
    }
    
    [Serializable()]
    [Group(typeof(DSB_DisabilityInformation_2200))]
    public class Loop_2200
    {
        
        [Required]
        [Pos(1)]
        public DSB_DisabilityInformation_2200 DSB_DisabilityInformation_2200 { get; set; }
        [ListCount(2)]
        [Pos(2)]
        public List<DTP_DisabilityEligibilityDates_2200> DTP_DisabilityEligibilityDates_2200 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,")]
    public class X12_ID_1146_DSB_DisabilityInformation_2200
    {
    }
    
    [Serializable()]
    [EdiCodes(",360,361,")]
    public class X12_ID_374_DTP_DisabilityEligibilityDates_2200
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DTP_DisabilityEligibilityDates_2200
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_DisabilityEligibilityDates_2200), typeof(X12_ID_1250_DTP_DisabilityEligibilityDates_2200))]
    public class DTP_DisabilityEligibilityDates_2200
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_DisabilityEligibilityDates_2200))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_DisabilityEligibilityDates_2200))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DisabilityEligibilityDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("DSB", typeof(X12_ID_1146_DSB_DisabilityInformation_2200))]
    public class DSB_DisabilityInformation_2200
    {
        
        [Required]
        [DataElement("1146", typeof(X12_ID_1146_DSB_DisabilityInformation_2200))]
        [Pos(1)]
        public string DisabilityTypeCode_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string DSB_02 { get; set; }
        [StringLength(4, 6)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string DSB_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string DSB_04 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string DSB_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string DSB_06 { get; set; }
        [DataElement("235", typeof(X12_ID_235_DSB_DisabilityInformation_2200))]
        [Pos(7)]
        public string ProductOrServiceIDQualifier_07 { get; set; }
        [StringLength(1, 15)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string DiagnosisCode_08 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",DX,")]
    public class X12_ID_235_DSB_DisabilityInformation_2200
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_ResponsiblePerson_2100G))]
    public class Loop_2100G
    {
        
        [Required]
        [Pos(1)]
        public NM1_ResponsiblePerson_2100G NM1_ResponsiblePerson_2100G { get; set; }
        [Pos(2)]
        public PER_ResponsiblePersonCommunicationsNumbers_2100G PER_ResponsiblePersonCommunicationsNumbers_2100G { get; set; }
        [Pos(3)]
        public N3_ResponsiblePersonStreetAddress_2100G N3_ResponsiblePersonStreetAddress_2100G { get; set; }
        [Pos(4)]
        public N4_ResponsiblePersonCityStateZip_2100G N4_ResponsiblePersonCityStateZip_2100G { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",E1,EI,EXS,GD,J6,QD,")]
    public class X12_ID_98_NM1_ResponsiblePerson_2100G
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_ResponsiblePerson_2100G
    {
    }
    
    [Serializable()]
    [EdiCodes(",RP,")]
    public class X12_ID_366_PER_ResponsiblePersonCommunicationsNumbers_2100G
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_ResponsiblePersonCityStateZip_2100G
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
    public class N3_ResponsiblePersonStreetAddress_2100G
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
    [Segment("PER", typeof(X12_ID_366_PER_ResponsiblePersonCommunicationsNumbers_2100G))]
    public class PER_ResponsiblePersonCommunicationsNumbers_2100G
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_ResponsiblePersonCommunicationsNumbers_2100G))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PER_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_ResponsiblePersonCommunicationsNumbers_2100G))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ResponsiblePersonCommunicationsNumbers_2100G))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ResponsiblePersonCommunicationsNumbers_2100G))]
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
    [EdiCodes(",EM,EX,FX,HP,TE,WP,")]
    public class X12_ID_365_PER_ResponsiblePersonCommunicationsNumbers_2100G
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_ResponsiblePerson_2100G), typeof(X12_ID_1065_NM1_ResponsiblePerson_2100G))]
    public class NM1_ResponsiblePerson_2100G
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ResponsiblePerson_2100G))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ResponsiblePerson_2100G))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ResponsiblePartyLastOrOrganizationName_03 { get; set; }
        [Required]
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
        public string ResponsiblePartyNamePrefix_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ResponsiblePartySuffixName_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_ResponsiblePerson_2100G))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ResponsiblePartyIdentifier_09 { get; set; }
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
    [EdiCodes(",34,ZZ,")]
    public class X12_ID_66_NM1_ResponsiblePerson_2100G
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_CustodialParent_2100F))]
    public class Loop_2100F
    {
        
        [Required]
        [Pos(1)]
        public NM1_CustodialParent_2100F NM1_CustodialParent_2100F { get; set; }
        [Pos(2)]
        public PER_CustodialParentCommunicationsNumbers_2100F PER_CustodialParentCommunicationsNumbers_2100F { get; set; }
        [Pos(3)]
        public N3_CustodialParentStreetAddress_2100F N3_CustodialParentStreetAddress_2100F { get; set; }
        [Pos(4)]
        public N4_CustodialParentCityStateZip_2100F N4_CustodialParentCityStateZip_2100F { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",S3,")]
    public class X12_ID_98_NM1_CustodialParent_2100F
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_CustodialParent_2100F
    {
    }
    
    [Serializable()]
    [EdiCodes(",PQ,")]
    public class X12_ID_366_PER_CustodialParentCommunicationsNumbers_2100F
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_CustodialParentCityStateZip_2100F
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string CustodialParentCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string CustodialParentStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string CustodialParentPostalZoneOrZIPCode_03 { get; set; }
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
    public class N3_CustodialParentStreetAddress_2100F
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string CustodialParentAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string CustodialParentAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_CustodialParentCommunicationsNumbers_2100F))]
    public class PER_CustodialParentCommunicationsNumbers_2100F
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_CustodialParentCommunicationsNumbers_2100F))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PER_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_CustodialParentCommunicationsNumbers_2100F))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_CustodialParentCommunicationsNumbers_2100F))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_CustodialParentCommunicationsNumbers_2100F))]
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
    [EdiCodes(",EM,EX,FX,HP,TE,WP,")]
    public class X12_ID_365_PER_CustodialParentCommunicationsNumbers_2100F
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_CustodialParent_2100F), typeof(X12_ID_1065_NM1_CustodialParent_2100F))]
    public class NM1_CustodialParent_2100F
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_CustodialParent_2100F))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_CustodialParent_2100F))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CustodialParentLastName_03 { get; set; }
        [Required]
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CustodialParentFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string CustodialParentMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CustodialParentNamePrefix_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string CustodialParentNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_CustodialParent_2100F))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string CustodialParentIdentifier_09 { get; set; }
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
    [EdiCodes(",34,ZZ,")]
    public class X12_ID_66_NM1_CustodialParent_2100F
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_MemberSchool_2100E))]
    public class Loop_2100E
    {
        
        [Required]
        [Pos(1)]
        public NM1_MemberSchool_2100E NM1_MemberSchool_2100E { get; set; }
        [Pos(2)]
        public PER_MemberSchoolCommmunicationsNumbers_2100E PER_MemberSchoolCommmunicationsNumbers_2100E { get; set; }
        [Pos(3)]
        public N3_MemberSchoolStreetAddress_2100E N3_MemberSchoolStreetAddress_2100E { get; set; }
        [Pos(4)]
        public N4_MemberSchoolCityStateZip_2100E N4_MemberSchoolCityStateZip_2100E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",M8,")]
    public class X12_ID_98_NM1_MemberSchool_2100E
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_MemberSchool_2100E
    {
    }
    
    [Serializable()]
    [EdiCodes(",SK,")]
    public class X12_ID_366_PER_MemberSchoolCommmunicationsNumbers_2100E
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_MemberSchoolCityStateZip_2100E
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string SchoolCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string SchoolStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string SchoolPostalZoneOrZIPCode_03 { get; set; }
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
    public class N3_MemberSchoolStreetAddress_2100E
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string SchoolAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SchoolAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_MemberSchoolCommmunicationsNumbers_2100E))]
    public class PER_MemberSchoolCommmunicationsNumbers_2100E
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_MemberSchoolCommmunicationsNumbers_2100E))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PER_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_MemberSchoolCommmunicationsNumbers_2100E))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_MemberSchoolCommmunicationsNumbers_2100E))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_MemberSchoolCommmunicationsNumbers_2100E))]
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
    [EdiCodes(",EM,EX,FX,TE,")]
    public class X12_ID_365_PER_MemberSchoolCommmunicationsNumbers_2100E
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_MemberSchool_2100E), typeof(X12_ID_1065_NM1_MemberSchool_2100E))]
    public class NM1_MemberSchool_2100E
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_MemberSchool_2100E))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_MemberSchool_2100E))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string SchoolName_03 { get; set; }
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
    [Group(typeof(NM1_MemberEmployer_2100D))]
    public class Loop_2100D
    {
        
        [Required]
        [Pos(1)]
        public NM1_MemberEmployer_2100D NM1_MemberEmployer_2100D { get; set; }
        [Pos(2)]
        public PER_MemberEmployerCommunicationsNumbers_2100D PER_MemberEmployerCommunicationsNumbers_2100D { get; set; }
        [Pos(3)]
        public N3_MemberEmployerStreetAddress_2100D N3_MemberEmployerStreetAddress_2100D { get; set; }
        [Pos(4)]
        public N4_MemberEmployerCityStateZip_2100D N4_MemberEmployerCityStateZip_2100D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ES,")]
    public class X12_ID_98_NM1_MemberEmployer_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_MemberEmployer_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",EP,")]
    public class X12_ID_366_PER_MemberEmployerCommunicationsNumbers_2100D
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_MemberEmployerCityStateZip_2100D
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string InsuredEmployerCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string InsuredEmployerStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string InsuredEmployerPostalZoneOrZIPCode_03 { get; set; }
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
    public class N3_MemberEmployerStreetAddress_2100D
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string InsuredEmployerAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InsuredEmployerAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_MemberEmployerCommunicationsNumbers_2100D))]
    public class PER_MemberEmployerCommunicationsNumbers_2100D
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_MemberEmployerCommunicationsNumbers_2100D))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PER_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_MemberEmployerCommunicationsNumbers_2100D))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_MemberEmployerCommunicationsNumbers_2100D))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_MemberEmployerCommunicationsNumbers_2100D))]
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
    [EdiCodes(",EM,EX,FX,TE,")]
    public class X12_ID_365_PER_MemberEmployerCommunicationsNumbers_2100D
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_MemberEmployer_2100D), typeof(X12_ID_1065_NM1_MemberEmployer_2100D))]
    public class NM1_MemberEmployer_2100D
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_MemberEmployer_2100D))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_MemberEmployer_2100D))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string InsuredEmployerName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string InsuredEmployerFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string InsuredEmployerMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string InsuredEmployerNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_MemberEmployer_2100D))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string InsuredEmployerIdentifier_09 { get; set; }
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
    [EdiCodes(",ZZ,")]
    public class X12_ID_66_NM1_MemberEmployer_2100D
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_MemberMailingAddress_2100C))]
    public class Loop_2100C
    {
        
        [Required]
        [Pos(1)]
        public NM1_MemberMailingAddress_2100C NM1_MemberMailingAddress_2100C { get; set; }
        [Pos(2)]
        public N3_MemberMailStreetAddress_2100C N3_MemberMailStreetAddress_2100C { get; set; }
        [Pos(3)]
        public N4_MemberMailCityStateZip_2100C N4_MemberMailCityStateZip_2100C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",31,")]
    public class X12_ID_98_NM1_MemberMailingAddress_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_MemberMailingAddress_2100C
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_MemberMailCityStateZip_2100C
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
    public class N3_MemberMailStreetAddress_2100C
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
    [Segment("NM1", typeof(X12_ID_98_NM1_MemberMailingAddress_2100C), typeof(X12_ID_1065_NM1_MemberMailingAddress_2100C))]
    public class NM1_MemberMailingAddress_2100C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_MemberMailingAddress_2100C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_MemberMailingAddress_2100C))]
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
    [Group(typeof(NM1_IncorrectMemberName_2100B))]
    public class Loop_2100B
    {
        
        [Required]
        [Pos(1)]
        public NM1_IncorrectMemberName_2100B NM1_IncorrectMemberName_2100B { get; set; }
        [Pos(2)]
        public DMG_IncorrectMemberDemographics_2100B DMG_IncorrectMemberDemographics_2100B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",70,")]
    public class X12_ID_98_NM1_IncorrectMemberName_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_IncorrectMemberName_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_IncorrectMemberDemographics_2100B
    {
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_IncorrectMemberDemographics_2100B))]
    public class DMG_IncorrectMemberDemographics_2100B
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_IncorrectMemberDemographics_2100B))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PriorIncorrectInsuredBirthDate_02 { get; set; }
        [Required]
        [DataElement("1068", typeof(X12_ID_1068_DMG_IncorrectMemberDemographics_2100B))]
        [Pos(3)]
        public string PriorIncorrectInsuredGenderCode_03 { get; set; }
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
    public class X12_ID_1068_DMG_IncorrectMemberDemographics_2100B
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_IncorrectMemberName_2100B), typeof(X12_ID_1065_NM1_IncorrectMemberName_2100B))]
    public class NM1_IncorrectMemberName_2100B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_IncorrectMemberName_2100B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_IncorrectMemberName_2100B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PriorIncorrectInsuredLastName_03 { get; set; }
        [Required]
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string PriorIncorrectInsuredFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string PriorIncorrectInsuredMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string PriorIncorrectInsuredNamePrefix_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string PriorIncorrectInsuredNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_IncorrectMemberName_2100B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PriorIncorrectInsuredIdentifier_09 { get; set; }
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
    [EdiCodes(",34,ZZ,")]
    public class X12_ID_66_NM1_IncorrectMemberName_2100B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_MemberName_2100A))]
    public class Loop_2100A
    {
        
        [Required]
        [Pos(1)]
        public NM1_MemberName_2100A NM1_MemberName_2100A { get; set; }
        [Pos(2)]
        public PER_MemberCommunicationsNumbers_2100A PER_MemberCommunicationsNumbers_2100A { get; set; }
        [Pos(3)]
        public N3_MemberResidenceStreetAddress_2100A N3_MemberResidenceStreetAddress_2100A { get; set; }
        [Pos(4)]
        public N4_MemberResidenceCityStateZIPCode_2100A N4_MemberResidenceCityStateZIPCode_2100A { get; set; }
        [Pos(5)]
        public DMG_MemberDemographics_2100A DMG_MemberDemographics_2100A { get; set; }
        [Pos(6)]
        public ICM_MemberIncome_2100A ICM_MemberIncome_2100A { get; set; }
        [ListCount(4)]
        [Pos(7)]
        public List<AMT_MemberPolicyAmounts_2100A> AMT_MemberPolicyAmounts_2100A { get; set; }
        [Pos(8)]
        public HLH_MemberHealthInformation_2100A HLH_MemberHealthInformation_2100A { get; set; }
        [ListCount(5)]
        [Pos(9)]
        public List<LUI_MemberLanguage_2100A> LUI_MemberLanguage_2100A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",74,IL,")]
    public class X12_ID_98_NM1_MemberName_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_MemberName_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",IP,")]
    public class X12_ID_366_PER_MemberCommunicationsNumbers_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_MemberDemographics_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,6,7,8,9,B,C,H,Q,S,U,")]
    public class X12_ID_594_ICM_MemberIncome_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",B9,C1,D2,P3,")]
    public class X12_ID_522_AMT_MemberPolicyAmounts_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",N,S,T,U,X,")]
    public class X12_ID_1212_HLH_MemberHealthInformation_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",LD,LE,")]
    public class X12_ID_66_LUI_MemberLanguage_2100A
    {
    }
    
    [Serializable()]
    [Segment("LUI", typeof(X12_ID_66_LUI_MemberLanguage_2100A))]
    public class LUI_MemberLanguage_2100A
    {
        
        [DataElement("66", typeof(X12_ID_66_LUI_MemberLanguage_2100A))]
        [Pos(1)]
        public string IdentificationCodeQualifier_01 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string LanguageCode_02 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string LanguageDescription_03 { get; set; }
        [DataElement("1303", typeof(X12_ID_1303_LUI_MemberLanguage_2100A))]
        [Pos(4)]
        public string LanguageUseIndicator_04 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string LUI_05 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",5,7,8,")]
    public class X12_ID_1303_LUI_MemberLanguage_2100A
    {
    }
    
    [Serializable()]
    [Segment("HLH", typeof(X12_ID_1212_HLH_MemberHealthInformation_2100A))]
    public class HLH_MemberHealthInformation_2100A
    {
        
        [DataElement("1212", typeof(X12_ID_1212_HLH_MemberHealthInformation_2100A))]
        [Pos(1)]
        public string HealthRelatedCode_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string MemberHeight_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string MemberWeight_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string HLH_04 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string HLH_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string HLH_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string HLH_07 { get; set; }
    }
    
    [Serializable()]
    [Segment("AMT", typeof(X12_ID_522_AMT_MemberPolicyAmounts_2100A))]
    public class AMT_MemberPolicyAmounts_2100A
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_MemberPolicyAmounts_2100A))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ContractAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("ICM", typeof(X12_ID_594_ICM_MemberIncome_2100A))]
    public class ICM_MemberIncome_2100A
    {
        
        [Required]
        [DataElement("594", typeof(X12_ID_594_ICM_MemberIncome_2100A))]
        [Pos(1)]
        public string FrequencyCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string WageAmount_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string WorkHoursCount_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string LocationIdentificationCode_04 { get; set; }
        [StringLength(1, 5)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string SalaryGradeCode_05 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string ICM_06 { get; set; }
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_MemberDemographics_2100A))]
    public class DMG_MemberDemographics_2100A
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_MemberDemographics_2100A))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string MemberBirthDate_02 { get; set; }
        [Required]
        [DataElement("1068", typeof(X12_ID_1068_DMG_MemberDemographics_2100A))]
        [Pos(3)]
        public string GenderCode_03 { get; set; }
        [DataElement("1067", typeof(X12_ID_1067_DMG_MemberDemographics_2100A))]
        [Pos(4)]
        public string MaritalStatusCode_04 { get; set; }
        [DataElement("1109", typeof(X12_ID_1109_DMG_MemberDemographics_2100A))]
        [Pos(5)]
        public string RaceOrEthnicityCode_05 { get; set; }
        [DataElement("1066", typeof(X12_ID_1066_DMG_MemberDemographics_2100A))]
        [Pos(6)]
        public string CitizenshipStatusCode_06 { get; set; }
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
    public class X12_ID_1068_DMG_MemberDemographics_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",B,D,I,M,R,S,U,W,X,")]
    public class X12_ID_1067_DMG_MemberDemographics_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",7,8,A,B,C,D,E,F,G,H,I,J,N,O,P,Z,")]
    public class X12_ID_1109_DMG_MemberDemographics_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,")]
    public class X12_ID_1066_DMG_MemberDemographics_2100A
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_MemberResidenceCityStateZIPCode_2100A
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
        [DataElement("309", typeof(X12_ID_309_N4_MemberResidenceCityStateZIPCode_2100A))]
        [Pos(5)]
        public string LocationQualifier_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string LocationIdentificationCode_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",60,CY,")]
    public class X12_ID_309_N4_MemberResidenceCityStateZIPCode_2100A
    {
    }
    
    [Serializable()]
    [Segment("N3")]
    public class N3_MemberResidenceStreetAddress_2100A
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
    [Segment("PER", typeof(X12_ID_366_PER_MemberCommunicationsNumbers_2100A))]
    public class PER_MemberCommunicationsNumbers_2100A
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_MemberCommunicationsNumbers_2100A))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PER_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_MemberCommunicationsNumbers_2100A))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_MemberCommunicationsNumbers_2100A))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_MemberCommunicationsNumbers_2100A))]
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
    [EdiCodes(",EM,EX,FX,HP,TE,WP,")]
    public class X12_ID_365_PER_MemberCommunicationsNumbers_2100A
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_MemberName_2100A), typeof(X12_ID_1065_NM1_MemberName_2100A))]
    public class NM1_MemberName_2100A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_MemberName_2100A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_MemberName_2100A))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string SubscriberLastName_03 { get; set; }
        [Required]
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
        [DataElement("66", typeof(X12_ID_66_NM1_MemberName_2100A))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string SubscriberIdentifier_09 { get; set; }
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
    [EdiCodes(",34,ZZ,")]
    public class X12_ID_66_NM1_MemberName_2100A
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_MemberLevelDates_2000), typeof(X12_ID_1250_DTP_MemberLevelDates_2000))]
    public class DTP_MemberLevelDates_2000
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_MemberLevelDates_2000))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_MemberLevelDates_2000))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string StatusInformationEffectiveDate_03 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2000
    {
        
        [Required]
        [Pos(1)]
        public REF_SubscriberNumber_2000 REF_SubscriberNumber_2000 { get; set; }
        [Pos(2)]
        public REF_MemberPolicyNumber_2000 REF_MemberPolicyNumber_2000 { get; set; }
        [ListCount(5)]
        [Pos(3)]
        public List<REF_MemberIdentificationNumber_2000> REF_MemberIdentificationNumber_2000 { get; set; }
        [Pos(4)]
        public REF_PriorCoverageMonths_2000 REF_PriorCoverageMonths_2000 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0F,")]
    public class X12_ID_128_REF_SubscriberNumber_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",1L,")]
    public class X12_ID_128_REF_MemberPolicyNumber_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",17,23,3H,6O,DX,F6,Q4,ZZ,")]
    public class X12_ID_128_REF_MemberIdentificationNumber_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",QQ,")]
    public class X12_ID_128_REF_PriorCoverageMonths_2000
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PriorCoverageMonths_2000))]
    public class REF_PriorCoverageMonths_2000
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PriorCoverageMonths_2000))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PriorCoverageMonthCount_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_MemberIdentificationNumber_2000))]
    public class REF_MemberIdentificationNumber_2000
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_MemberIdentificationNumber_2000))]
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
    [Segment("REF", typeof(X12_ID_128_REF_MemberPolicyNumber_2000))]
    public class REF_MemberPolicyNumber_2000
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_MemberPolicyNumber_2000))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InsuredGroupOrPolicyNumber_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_SubscriberNumber_2000))]
    public class REF_SubscriberNumber_2000
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_SubscriberNumber_2000))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberIdentifier_02 { get; set; }
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
    [Segment("INS", typeof(X12_ID_1073_INS_MemberLevelDetail_2000), typeof(X12_ID_1069_INS_MemberLevelDetail_2000))]
    public class INS_MemberLevelDetail_2000
    {
        
        [Required]
        [DataElement("1073", typeof(X12_ID_1073_INS_MemberLevelDetail_2000))]
        [Pos(1)]
        public string InsuredIndicator_01 { get; set; }
        [Required]
        [DataElement("1069", typeof(X12_ID_1069_INS_MemberLevelDetail_2000))]
        [Pos(2)]
        public string IndividualRelationshipCode_02 { get; set; }
        [Required]
        [DataElement("875", typeof(X12_ID_875_INS_MemberLevelDetail_2000))]
        [Pos(3)]
        public string MaintenanceTypeCode_03 { get; set; }
        [DataElement("1203", typeof(X12_ID_1203_INS_MemberLevelDetail_2000))]
        [Pos(4)]
        public string MaintenanceReasonCode_04 { get; set; }
        [Required]
        [DataElement("1216", typeof(X12_ID_1216_INS_MemberLevelDetail_2000))]
        [Pos(5)]
        public string BenefitStatusCode_05 { get; set; }
        [DataElement("1218", typeof(X12_ID_1218_INS_MemberLevelDetail_2000))]
        [Pos(6)]
        public string MedicarePlanCode_06 { get; set; }
        [DataElement("1219", typeof(X12_ID_1219_INS_MemberLevelDetail_2000))]
        [Pos(7)]
        public string ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode_07 { get; set; }
        [DataElement("584", typeof(X12_ID_584_INS_MemberLevelDetail_2000))]
        [Pos(8)]
        public string EmploymentStatusCode_08 { get; set; }
        [DataElement("1220", typeof(X12_ID_1220_INS_MemberLevelDetail_2000))]
        [Pos(9)]
        public string StudentStatusCode_09 { get; set; }
        [DataElement("1073", typeof(X12_ID_1073_INS_MemberLevelDetail_2000))]
        [Pos(10)]
        public string HandicapIndicator_10 { get; set; }
        [DataElement("1250", typeof(X12_ID_1250_INS_MemberLevelDetail_2000))]
        [Pos(11)]
        public string DateTimePeriodFormatQualifier_11 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string InsuredIndividualDeathDate_12 { get; set; }
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
    [EdiCodes(",001,021,024,025,030,")]
    public class X12_ID_875_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,02,03,04,05,06,07,08,09,10,11,14,15,16,17,18,20,21,22,25,26,27,28,29,31,32,33" +
        ",37,38,39,40,41,43,AI,XN,XT,")]
    public class X12_ID_1203_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,C,S,T,")]
    public class X12_ID_1216_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",A,B,C,D,E,")]
    public class X12_ID_1218_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,6,7,8,")]
    public class X12_ID_1219_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",AO,AU,FT,L1,PT,RT,TE,")]
    public class X12_ID_584_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",F,N,P,")]
    public class X12_ID_1220_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_INS_MemberLevelDetail_2000
    {
    }
    
    [Serializable()]
    [Group(typeof(N1_TPABrokerName_1000C))]
    public class Loop_1000C
    {
        
        [Required]
        [Pos(1)]
        public N1_TPABrokerName_1000C N1_TPABrokerName_1000C { get; set; }
        [Pos(2)]
        public Loop_1100C Loop_1100C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",BO,TV,")]
    public class X12_ID_98_N1_TPABrokerName_1000C
    {
    }
    
    [Serializable()]
    [Group(typeof(ACT_TPABrokerAccountInformation_1100C))]
    public class Loop_1100C
    {
        
        [Required]
        [Pos(1)]
        public ACT_TPABrokerAccountInformation_1100C ACT_TPABrokerAccountInformation_1100C { get; set; }
    }
    
    [Serializable()]
    [Segment("ACT")]
    public class ACT_TPABrokerAccountInformation_1100C
    {
        
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string TPAOrBrokerAccountNumber_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ACT_02 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ACT_03 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ACT_04 { get; set; }
        [StringLength(1, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string ACT_05 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string TPAOrBrokerAccountNumber_06 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ACT_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string ACT_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string ACT_09 { get; set; }
    }
    
    [Serializable()]
    [Segment("N1", typeof(X12_ID_98_N1_TPABrokerName_1000C))]
    public class N1_TPABrokerName_1000C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_N1_TPABrokerName_1000C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TPAOrBrokerName_02 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_N1_TPABrokerName_1000C))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string TPAOrBrokerIdentificationCode_04 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string N1_05 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string N1_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",94,FI,XV,")]
    public class X12_ID_66_N1_TPABrokerName_1000C
    {
    }
    
    [Serializable()]
    [Group(typeof(N1_Payer_1000B))]
    public class Loop_1000B
    {
        
        [Required]
        [Pos(1)]
        public N1_Payer_1000B N1_Payer_1000B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",IN,")]
    public class X12_ID_98_N1_Payer_1000B
    {
    }
    
    [Serializable()]
    [Segment("N1", typeof(X12_ID_98_N1_Payer_1000B))]
    public class N1_Payer_1000B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_N1_Payer_1000B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InsurerName_02 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_N1_Payer_1000B))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string InsurerIdentificationCode_04 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string N1_05 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string N1_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",FI,XV,")]
    public class X12_ID_66_N1_Payer_1000B
    {
    }
    
    [Serializable()]
    [Group(typeof(N1_SponsorName_1000A))]
    public class Loop_1000A
    {
        
        [Required]
        [Pos(1)]
        public N1_SponsorName_1000A N1_SponsorName_1000A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",P5,")]
    public class X12_ID_98_N1_SponsorName_1000A
    {
    }
    
    [Serializable()]
    [Segment("N1", typeof(X12_ID_98_N1_SponsorName_1000A))]
    public class N1_SponsorName_1000A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_N1_SponsorName_1000A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PlanSponsorName_02 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_N1_SponsorName_1000A))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string SponsorIdentifier_04 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string N1_05 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string N1_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",FI,ZZ,")]
    public class X12_ID_66_N1_SponsorName_1000A
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_FileEffectiveDate), typeof(X12_ID_1250_DTP_FileEffectiveDate))]
    public class DTP_FileEffectiveDate
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_FileEffectiveDate))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_FileEffectiveDate))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string DateTimePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_TransactionSetPolicyNumber))]
    public class REF_TransactionSetPolicyNumber
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_TransactionSetPolicyNumber))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string MasterPolicyNumber_02 { get; set; }
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
    [Segment("BGN", typeof(X12_ID_353_BGN_BeginningSegment))]
    public class BGN_BeginningSegment
    {
        
        [Required]
        [DataElement("353", typeof(X12_ID_353_BGN_BeginningSegment))]
        [Pos(1)]
        public string TransactionSetPurposeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TransactionSetIdentifierCode_02 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(3)]
        public string TransactionSetCreationDate_03 { get; set; }
        [Required]
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(4)]
        public string TransactionSetCreationTime_04 { get; set; }
        [DataElement("623", typeof(X12_ID_623_BGN_BeginningSegment))]
        [Pos(5)]
        public string TimeZoneCode_05 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string TransactionSetIdentifierCode_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string BGN_07 { get; set; }
        [Required]
        [DataElement("306", typeof(X12_ID_306_BGN_BeginningSegment))]
        [Pos(8)]
        public string ActionCode_08 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string BGN_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,AD,AS,AT" +
        ",CD,CS,CT,ED,ES,ET,GM,HD,HS,HT,LT,MD,MS,MT,ND,NS,NT,PD,PS,PT,TD,TS,TT,UT,")]
    public class X12_ID_623_BGN_BeginningSegment
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,4,")]
    public class X12_ID_306_BGN_BeginningSegment
    {
    }
}
