namespace EdiFabric.Rules.HIPAA_004010X061A1_820
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X061A1", "820")]
    public class TS820 : EdiMessage
    {
        
        [Pos(1)]
        public ST ST { get; set; }
        [Required]
        [Pos(2)]
        public BPR_FinancialInformation BPR_FinancialInformation { get; set; }
        [Required]
        [Pos(3)]
        public TRN_ReassociationKey TRN_ReassociationKey { get; set; }
        [Pos(4)]
        public CUR_NonUSDollarsCurrency CUR_NonUSDollarsCurrency { get; set; }
        [Pos(5)]
        public List<REF_PremiumReceiversIdentificationKey> REF_PremiumReceiversIdentificationKey { get; set; }
        [Pos(6)]
        public All_DTM All_DTM { get; set; }
        [Required]
        [Pos(7)]
        public Loop_1000A Loop_1000A { get; set; }
        [Required]
        [Pos(8)]
        public Loop_1000B Loop_1000B { get; set; }
        [Pos(9)]
        public Loop_2000A Loop_2000A { get; set; }
        [Pos(10)]
        public List<Loop_2000B> Loop_2000B { get; set; }
        [Pos(11)]
        public SE SE { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",C,D,I,P,U,X,")]
    public class X12_ID_305_BPR_FinancialInformation
    {
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,3,")]
    public class X12_ID_481_TRN_ReassociationKey
    {
    }
    
    [Serializable()]
    public class X12_AN
    {
    }
    
    [Serializable()]
    [EdiCodes(",2B,PR,")]
    public class X12_ID_98_CUR_NonUSDollarsCurrency
    {
    }
    
    [Serializable()]
    public class X12_ID
    {
    }
    
    [Serializable()]
    [EdiCodes(",14,18,2F,38,72,")]
    public class X12_ID_128_REF_PremiumReceiversIdentificationKey
    {
    }
    
    [Serializable()]
    [Group(typeof(ENT_IndividualRemittance_2000B))]
    public class Loop_2000B
    {
        
        [Required]
        [Pos(1)]
        public ENT_IndividualRemittance_2000B ENT_IndividualRemittance_2000B { get; set; }
        [Pos(2)]
        public List<Loop_2100B> Loop_2100B { get; set; }
        [Pos(3)]
        public List<Loop_2300B> Loop_2300B { get; set; }
    }
    
    [Serializable()]
    public class X12_N0
    {
    }
    
    [Serializable()]
    [EdiCodes(",2J,")]
    public class X12_ID_98_ENT_IndividualRemittance_2000B
    {
    }
    
    [Serializable()]
    [Group(typeof(RMR_IndividualPremiumRemittanceDetail_2300B))]
    public class Loop_2300B
    {
        
        [Required]
        [Pos(1)]
        public RMR_IndividualPremiumRemittanceDetail_2300B RMR_IndividualPremiumRemittanceDetail_2300B { get; set; }
        [Pos(2)]
        public DTM_IndividualCoveragePeriod_2300B DTM_IndividualCoveragePeriod_2300B { get; set; }
        [Pos(3)]
        public List<Loop_2320B> Loop_2320B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",11,9J,AZ,B7,CT,ID,IG,IK,KW,")]
    public class X12_ID_128_RMR_IndividualPremiumRemittanceDetail_2300B
    {
    }
    
    [Serializable()]
    [EdiCodes(",582,")]
    public class X12_ID_374_DTM_IndividualCoveragePeriod_2300B
    {
    }
    
    [Serializable()]
    public class X12_DT
    {
    }
    
    [Serializable()]
    [Group(typeof(ADX_IndividualPremiumAdjustment_2320B))]
    public class Loop_2320B
    {
        
        [Required]
        [Pos(1)]
        public ADX_IndividualPremiumAdjustment_2320B ADX_IndividualPremiumAdjustment_2320B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",20,52,53,AA,AX,H1,H6,IA,J3,")]
    public class X12_ID_426_ADX_IndividualPremiumAdjustment_2320B
    {
    }
    
    [Serializable()]
    [Segment("ADX")]
    public class ADX_IndividualPremiumAdjustment_2320B
    {
        
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(1)]
        public string AdjustmentAmount_01 { get; set; }
        [Required]
        [DataElement("426", typeof(X12_ID_426_ADX_IndividualPremiumAdjustment_2320B))]
        [Pos(2)]
        public string AdjustmentReasonCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ADX_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ADX_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTM", typeof(X12_ID_374_DTM_IndividualCoveragePeriod_2300B))]
    public class DTM_IndividualCoveragePeriod_2300B
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTM_IndividualCoveragePeriod_2300B))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string DTM_02 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(3)]
        public string DTM_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string DTM_04 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTM_IndividualCoveragePeriod_2300B))]
        [Pos(5)]
        public string DateTimePeriodFormatQualifier_05 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CoveragePeriod_06 { get; set; }
    }
    
    [Serializable()]
    public class X12_TM
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_DTM_IndividualCoveragePeriod_2300B
    {
    }
    
    [Serializable()]
    [Segment("RMR", typeof(X12_ID_128_RMR_IndividualPremiumRemittanceDetail_2300B))]
    public class RMR_IndividualPremiumRemittanceDetail_2300B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_RMR_IndividualPremiumRemittanceDetail_2300B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InsuranceRemittanceReferenceNumber_02 { get; set; }
        [DataElement("482", typeof(X12_ID_482_RMR_IndividualPremiumRemittanceDetail_2300B))]
        [Pos(3)]
        public string PaymentActionCode_03 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string DetailPremiumPaymentAmount_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string BilledPremiumAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string RMR_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string RMR_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string RMR_08 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PI,PP,")]
    public class X12_ID_482_RMR_IndividualPremiumRemittanceDetail_2300B
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_IndividualName_2100B))]
    public class Loop_2100B
    {
        
        [Required]
        [Pos(1)]
        public NM1_IndividualName_2100B NM1_IndividualName_2100B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EY,QE,")]
    public class X12_ID_98_NM1_IndividualName_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_IndividualName_2100B
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_IndividualName_2100B), typeof(X12_ID_1065_NM1_IndividualName_2100B))]
    public class NM1_IndividualName_2100B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_IndividualName_2100B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_IndividualName_2100B))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string IndividualLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string IndividualFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string IndividualMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string IndividualNamePrefix_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string IndividualNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_IndividualName_2100B))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string IndividualIdentifier_09 { get; set; }
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
    [EdiCodes(",34,EI,N,")]
    public class X12_ID_66_NM1_IndividualName_2100B
    {
    }
    
    [Serializable()]
    [Segment("ENT")]
    public class ENT_IndividualRemittance_2000B
    {
        
        [Required]
        [DataElement("", typeof(X12_N0))]
        [Pos(1)]
        public string AssignedNumber_01 { get; set; }
        [Required]
        [DataElement("98", typeof(X12_ID_98_ENT_IndividualRemittance_2000B))]
        [Pos(2)]
        public string EntityIdentifierCode_02 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_ENT_IndividualRemittance_2000B))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ReceiversIndividualIdentifier_04 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string ENT_05 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string ENT_06 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ENT_07 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string ENT_08 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ENT_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",34,EI,ZZ,")]
    public class X12_ID_66_ENT_IndividualRemittance_2000B
    {
    }
    
    [Serializable()]
    [Group(typeof(ENT_OrganizationSummaryRemittance_2000A))]
    public class Loop_2000A
    {
        
        [Required]
        [Pos(1)]
        public ENT_OrganizationSummaryRemittance_2000A ENT_OrganizationSummaryRemittance_2000A { get; set; }
        [Required]
        [Pos(2)]
        public List<Loop_2300A> Loop_2300A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",2L,")]
    public class X12_ID_98_ENT_OrganizationSummaryRemittance_2000A
    {
    }
    
    [Serializable()]
    [Group(typeof(RMR_OrganizationSummaryRemittanceDetail_2300A))]
    public class Loop_2300A
    {
        
        [Required]
        [Pos(1)]
        public RMR_OrganizationSummaryRemittanceDetail_2300A RMR_OrganizationSummaryRemittanceDetail_2300A { get; set; }
        [Pos(2)]
        public Loop_2310A Loop_2310A { get; set; }
        [Pos(3)]
        public List<Loop_2320A> Loop_2320A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",11,1L,CT,IK,")]
    public class X12_ID_128_RMR_OrganizationSummaryRemittanceDetail_2300A
    {
    }
    
    [Serializable()]
    [Group(typeof(ADX_OrganizationSummaryRemittanceLevelAdjustment_2320A))]
    public class Loop_2320A
    {
        
        [Required]
        [Pos(1)]
        public ADX_OrganizationSummaryRemittanceLevelAdjustment_2320A ADX_OrganizationSummaryRemittanceLevelAdjustment_2320A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",20,52,53,AA,H1,H6,IA,J3,")]
    public class X12_ID_426_ADX_OrganizationSummaryRemittanceLevelAdjustment_2320A
    {
    }
    
    [Serializable()]
    [Segment("ADX")]
    public class ADX_OrganizationSummaryRemittanceLevelAdjustment_2320A
    {
        
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(1)]
        public string AdjustmentAmount_01 { get; set; }
        [Required]
        [DataElement("426", typeof(X12_ID_426_ADX_OrganizationSummaryRemittanceLevelAdjustment_2320A))]
        [Pos(2)]
        public string AdjustmentReasonCode_02 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string ADX_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ADX_04 { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(IT1_SummaryLineItem_2310A))]
    public class Loop_2310A
    {
        
        [Required]
        [Pos(1)]
        public IT1_SummaryLineItem_2310A IT1_SummaryLineItem_2310A { get; set; }
        [Pos(2)]
        public List<Loop_2315A> Loop_2315A { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(SLN_MemberCount_2315A))]
    public class Loop_2315A
    {
        
        [Required]
        [Pos(1)]
        public SLN_MemberCount_2315A SLN_MemberCount_2315A { get; set; }
    }
    
    [Serializable()]
    [Segment("SLN")]
    public class SLN_MemberCount_2315A
    {
        
        [Required]
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string LineItemControlNumber_01 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SLN_02 { get; set; }
        [Required]
        [DataElement("662", typeof(X12_ID_662_SLN_MemberCount_2315A))]
        [Pos(3)]
        public string InformationOnlyIndicator_03 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string HeadCount_04 { get; set; }
        [Required]
        [Pos(5)]
        public C001_1152001766 C001_1152001766 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string SLN_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string SLN_07 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string SLN_08 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string SLN_09 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string SLN_10 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string SLN_11 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string SLN_12 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(13)]
        public string SLN_13 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(14)]
        public string SLN_14 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(15)]
        public string SLN_15 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(16)]
        public string SLN_16 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(17)]
        public string SLN_17 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(18)]
        public string SLN_18 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(19)]
        public string SLN_19 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(20)]
        public string SLN_20 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(21)]
        public string SLN_21 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(22)]
        public string SLN_22 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(23)]
        public string SLN_23 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(24)]
        public string SLN_24 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(25)]
        public string SLN_25 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(26)]
        public string SLN_26 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(27)]
        public string SLN_27 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(28)]
        public string SLN_28 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",O,")]
    public class X12_ID_662_SLN_MemberCount_2315A
    {
    }
    
    [Serializable()]
    [Composite("C001_1152001766")]
    public class C001_1152001766
    {
        
        [Required]
        [DataElement("355", typeof(X12_ID_355_C001_1152001766))]
        [Pos(1)]
        public string UnitOrBasisForMeasurementCode_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string SLN_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string SLN_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string SLN_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string SLN_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string SLN_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string SLN_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string SLN_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string SLN_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string SLN_10 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(11)]
        public string SLN_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string SLN_12 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(13)]
        public string SLN_13 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(14)]
        public string SLN_14 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string SLN_15 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",10,IE,PR,")]
    public class X12_ID_355_C001_1152001766
    {
    }
    
    [Serializable()]
    [Segment("IT1")]
    public class IT1_SummaryLineItem_2310A
    {
        
        [Required]
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string LineItemControlNumber_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string IT1_02 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string IT1_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string IT1_04 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string IT1_05 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string IT1_06 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string IT1_07 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string IT1_08 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string IT1_09 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string IT1_10 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string IT1_11 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(12)]
        public string IT1_12 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(13)]
        public string IT1_13 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(14)]
        public string IT1_14 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(15)]
        public string IT1_15 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(16)]
        public string IT1_16 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(17)]
        public string IT1_17 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(18)]
        public string IT1_18 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(19)]
        public string IT1_19 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(20)]
        public string IT1_20 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(21)]
        public string IT1_21 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(22)]
        public string IT1_22 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(23)]
        public string IT1_23 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(24)]
        public string IT1_24 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(25)]
        public string IT1_25 { get; set; }
    }
    
    [Serializable()]
    [Segment("RMR", typeof(X12_ID_128_RMR_OrganizationSummaryRemittanceDetail_2300A))]
    public class RMR_OrganizationSummaryRemittanceDetail_2300A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_RMR_OrganizationSummaryRemittanceDetail_2300A))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ContractInvoiceAccountGroupOrPolicyNumber_02 { get; set; }
        [DataElement("482", typeof(X12_ID_482_RMR_OrganizationSummaryRemittanceDetail_2300A))]
        [Pos(3)]
        public string PaymentActionCode_03 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string DetailPremiumPaymentAmount_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string BilledPremiumAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string RMR_06 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string RMR_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string RMR_08 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PA,PI,PO,PP,")]
    public class X12_ID_482_RMR_OrganizationSummaryRemittanceDetail_2300A
    {
    }
    
    [Serializable()]
    [Segment("ENT")]
    public class ENT_OrganizationSummaryRemittance_2000A
    {
        
        [Required]
        [DataElement("", typeof(X12_N0))]
        [Pos(1)]
        public string AssignedNumber_01 { get; set; }
        [Required]
        [DataElement("98", typeof(X12_ID_98_ENT_OrganizationSummaryRemittance_2000A))]
        [Pos(2)]
        public string EntityIdentifierCode_02 { get; set; }
        [DataElement("66", typeof(X12_ID_66_ENT_OrganizationSummaryRemittance_2000A))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OrganizationIdentificationCode_04 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string ENT_05 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(6)]
        public string ENT_06 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string ENT_07 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(8)]
        public string ENT_08 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ENT_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,9,FI,")]
    public class X12_ID_66_ENT_OrganizationSummaryRemittance_2000A
    {
    }
    
    [Serializable()]
    [Group(typeof(N1_PremiumPayersName_1000B))]
    public class Loop_1000B
    {
        
        [Required]
        [Pos(1)]
        public N1_PremiumPayersName_1000B N1_PremiumPayersName_1000B { get; set; }
        [Pos(2)]
        public N2_PremiumPayerAdditionalName_1000B N2_PremiumPayerAdditionalName_1000B { get; set; }
        [Pos(3)]
        public N3_PremiumPayersAddress_1000B N3_PremiumPayersAddress_1000B { get; set; }
        [Pos(4)]
        public N4_PremiumPayersCityStateZip_1000B N4_PremiumPayersCityStateZip_1000B { get; set; }
        [Pos(5)]
        public List<PER_PremiumPayersAdministrativeContact_1000B> PER_PremiumPayersAdministrativeContact_1000B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_N1_PremiumPayersName_1000B
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_PremiumPayersAdministrativeContact_1000B
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_PremiumPayersAdministrativeContact_1000B))]
    public class PER_PremiumPayersAdministrativeContact_1000B
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_PremiumPayersAdministrativeContact_1000B))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [Required]
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PremiumPayerContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_PremiumPayersAdministrativeContact_1000B))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_PremiumPayersAdministrativeContact_1000B))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_PremiumPayersAdministrativeContact_1000B))]
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
    public class X12_ID_365_PER_PremiumPayersAdministrativeContact_1000B
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_PremiumPayersCityStateZip_1000B
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PremiumPayerCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string PremiumPayerStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string PremiumPayerPostalZoneOrZIPCode_03 { get; set; }
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
    public class N3_PremiumPayersAddress_1000B
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PremiumPayerAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PremiumPayerAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("N2")]
    public class N2_PremiumPayerAdditionalName_1000B
    {
        
        [Required]
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PremiumPayerAdditionalName_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string N2_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("N1", typeof(X12_ID_98_N1_PremiumPayersName_1000B))]
    public class N1_PremiumPayersName_1000B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_N1_PremiumPayersName_1000B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PremiumPayerName_02 { get; set; }
        [DataElement("66", typeof(X12_ID_66_N1_PremiumPayersName_1000B))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string PremiumPayerIdentifier_04 { get; set; }
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
    [EdiCodes(",1,9,24,75,EQ,FI,PI,")]
    public class X12_ID_66_N1_PremiumPayersName_1000B
    {
    }
    
    [Serializable()]
    [Group(typeof(N1_PremiumReceiversName_1000A))]
    public class Loop_1000A
    {
        
        [Required]
        [Pos(1)]
        public N1_PremiumReceiversName_1000A N1_PremiumReceiversName_1000A { get; set; }
        [Pos(2)]
        public N2_PremiumReceiverAdditionalName_1000A N2_PremiumReceiverAdditionalName_1000A { get; set; }
        [Pos(3)]
        public N3_PremiumReceiversAddress_1000A N3_PremiumReceiversAddress_1000A { get; set; }
        [Pos(4)]
        public N4_PremiumReceiversCityStateZip_1000A N4_PremiumReceiversCityStateZip_1000A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PE,")]
    public class X12_ID_98_N1_PremiumReceiversName_1000A
    {
    }
    
    [Serializable()]
    [Segment("N4")]
    public class N4_PremiumReceiversCityStateZip_1000A
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
    public class N3_PremiumReceiversAddress_1000A
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ReceiverAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ReceiverAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("N2")]
    public class N2_PremiumReceiverAdditionalName_1000A
    {
        
        [Required]
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ReceiverAdditionalName_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string N2_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("N1", typeof(X12_ID_98_N1_PremiumReceiversName_1000A))]
    public class N1_PremiumReceiversName_1000A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_N1_PremiumReceiversName_1000A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string InformationReceiverLastOrOrganizationName_02 { get; set; }
        [DataElement("66", typeof(X12_ID_66_N1_PremiumReceiversName_1000A))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ReceiverIdentifier_04 { get; set; }
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
    [EdiCodes(",1,9,EQ,FI,XV,")]
    public class X12_ID_66_N1_PremiumReceiversName_1000A
    {
    }
    
    [Serializable()]
    [All()]
    public class All_DTM
    {
        
        [Pos(1)]
        public DTM_ProcessDate DTM_ProcessDate { get; set; }
        [Pos(2)]
        public DTM_DeliveryDate DTM_DeliveryDate { get; set; }
        [Pos(3)]
        public DTM_CoveragePeriod DTM_CoveragePeriod { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",009,")]
    public class X12_ID_374_DTM_ProcessDate
    {
    }
    
    [Serializable()]
    [EdiCodes(",035,")]
    public class X12_ID_374_DTM_DeliveryDate
    {
    }
    
    [Serializable()]
    [EdiCodes(",582,")]
    public class X12_ID_374_DTM_CoveragePeriod
    {
    }
    
    [Serializable()]
    [Segment("DTM", typeof(X12_ID_374_DTM_CoveragePeriod))]
    public class DTM_CoveragePeriod
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTM_CoveragePeriod))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string DTM_02 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(3)]
        public string DTM_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string DTM_04 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTM_CoveragePeriod))]
        [Pos(5)]
        public string DateTimePeriodFormatQualifier_05 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CoveragePeriod_06 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_DTM_CoveragePeriod
    {
    }
    
    [Serializable()]
    [Segment("DTM", typeof(X12_ID_374_DTM_DeliveryDate))]
    public class DTM_DeliveryDate
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTM_DeliveryDate))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string PremiumDeliveryDate_02 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(3)]
        public string DTM_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string DTM_04 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string DTM_05 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string DTM_06 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTM", typeof(X12_ID_374_DTM_ProcessDate))]
    public class DTM_ProcessDate
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTM_ProcessDate))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string PayerProcessDate_02 { get; set; }
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(3)]
        public string DTM_03 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string DTM_04 { get; set; }
        [StringLength(2, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(5)]
        public string DTM_05 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string DTM_06 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PremiumReceiversIdentificationKey))]
    public class REF_PremiumReceiversIdentificationKey
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PremiumReceiversIdentificationKey))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PremiumReceiverReferenceIdentifier_02 { get; set; }
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
    [Segment("CUR", typeof(X12_ID_98_CUR_NonUSDollarsCurrency))]
    public class CUR_NonUSDollarsCurrency
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_CUR_NonUSDollarsCurrency))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string CurrencyCode_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string ExchangeRate_03 { get; set; }
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
    [Segment("TRN", typeof(X12_ID_481_TRN_ReassociationKey))]
    public class TRN_ReassociationKey
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_ReassociationKey))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string CheckOrEFTTraceNumber_02 { get; set; }
        [StringLength(10, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string OriginatingCompanyIdentifier_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string OriginatingCompanySupplementalCode_04 { get; set; }
    }
    
    [Serializable()]
    [Segment("BPR", typeof(X12_ID_305_BPR_FinancialInformation))]
    public class BPR_FinancialInformation
    {
        
        [Required]
        [DataElement("305", typeof(X12_ID_305_BPR_FinancialInformation))]
        [Pos(1)]
        public string TransactionHandlingCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string TotalPremiumPaymentAmount_02 { get; set; }
        [Required]
        [DataElement("478", typeof(X12_ID_478_BPR_FinancialInformation))]
        [Pos(3)]
        public string CreditOrDebitFlagCode_03 { get; set; }
        [Required]
        [DataElement("591", typeof(X12_ID_591_BPR_FinancialInformation))]
        [Pos(4)]
        public string PaymentMethodCode_04 { get; set; }
        [DataElement("812", typeof(X12_ID_812_BPR_FinancialInformation))]
        [Pos(5)]
        public string PaymentFormatCode_05 { get; set; }
        [DataElement("506", typeof(X12_ID_506_BPR_FinancialInformation))]
        [Pos(6)]
        public string DepositoryFinancialInstitutionDFIIdentificationNumberQualifier_06 { get; set; }
        [StringLength(3, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string OriginatingDepositoryFinancialInstitutionDFIIdentifier_07 { get; set; }
        [DataElement("569", typeof(X12_ID_569_BPR_FinancialInformation))]
        [Pos(8)]
        public string AccountNumberQualifier_08 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string SenderBankAccountNumber_09 { get; set; }
        [StringLength(10, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(10)]
        public string OriginatingCompanyIdentifier_10 { get; set; }
        [StringLength(9, 9)]
        [DataElement("", typeof(X12_AN))]
        [Pos(11)]
        public string OriginatingCompanySupplementalCode_11 { get; set; }
        [DataElement("506", typeof(X12_ID_506_BPR_FinancialInformation))]
        [Pos(12)]
        public string DepositoryFinancialInstitutionDFIIdentificationNumberQualifier_12 { get; set; }
        [StringLength(3, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(13)]
        public string ReceivingDepositoryFinancialInstitutionDFIIdentifier_13 { get; set; }
        [DataElement("569", typeof(X12_ID_569_BPR_FinancialInformation))]
        [Pos(14)]
        public string AccountNumberQualifier_14 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(15)]
        public string ReceiverBankAccountNumber_15 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(16)]
        public string CheckIssueOrEFTEffectiveDate_16 { get; set; }
        [StringLength(1, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(17)]
        public string BPR_17 { get; set; }
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(18)]
        public string BPR_18 { get; set; }
        [StringLength(3, 12)]
        [DataElement("", typeof(X12_AN))]
        [Pos(19)]
        public string BPR_19 { get; set; }
        [StringLength(1, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(20)]
        public string BPR_20 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(21)]
        public string BPR_21 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",C,D,")]
    public class X12_ID_478_BPR_FinancialInformation
    {
    }
    
    [Serializable()]
    [EdiCodes(",ACH,BOP,CHK,FWT,SWT,")]
    public class X12_ID_591_BPR_FinancialInformation
    {
    }
    
    [Serializable()]
    [EdiCodes(",CCP,CTX,")]
    public class X12_ID_812_BPR_FinancialInformation
    {
    }
    
    [Serializable()]
    [EdiCodes(",01,04,")]
    public class X12_ID_506_BPR_FinancialInformation
    {
    }
    
    [Serializable()]
    [EdiCodes(",ALC,DA,")]
    public class X12_ID_569_BPR_FinancialInformation
    {
    }
}
