namespace EdiFabric.Rules.HIPAA_004010X091A1_835
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X091A1", "835")]
    public class TS835 : EdiMessage
    {
        
        [Pos(1)]
        public ST ST { get; set; }
        [Required]
        [Pos(2)]
        public BPR_FinancialInformation BPR_FinancialInformation { get; set; }
        [Required]
        [Pos(3)]
        public TRN_ReassociationTraceNumber TRN_ReassociationTraceNumber { get; set; }
        [Pos(4)]
        public CUR_ForeignCurrencyInformation CUR_ForeignCurrencyInformation { get; set; }
        [Pos(5)]
        public All_REF All_REF { get; set; }
        [Pos(6)]
        public DTM_ProductionDate DTM_ProductionDate { get; set; }
        [Required]
        [Pos(7)]
        public Loop_1000A Loop_1000A { get; set; }
        [Required]
        [Pos(8)]
        public Loop_1000B Loop_1000B { get; set; }
        [Pos(9)]
        public List<Loop_2000> Loop_2000 { get; set; }
        [Pos(10)]
        public List<PLB_ProviderAdjustment> PLB_ProviderAdjustment { get; set; }
        [Pos(11)]
        public SE SE { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",C,D,H,I,P,U,X,")]
    public class X12_ID_305_BPR_FinancialInformation
    {
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_481_TRN_ReassociationTraceNumber
    {
    }
    
    [Serializable()]
    public class X12_AN
    {
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_CUR_ForeignCurrencyInformation
    {
    }
    
    [Serializable()]
    public class X12_ID
    {
    }
    
    [Serializable()]
    [EdiCodes(",405,")]
    public class X12_ID_374_DTM_ProductionDate
    {
    }
    
    [Serializable()]
    public class X12_DT
    {
    }
    
    [Serializable()]
    [Segment("PLB")]
    public class PLB_ProviderAdjustment
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ProviderIdentifier_01 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string FiscalPeriodDate_02 { get; set; }
        [Required]
        [Pos(3)]
        public C042_1576553894 C042_1576553894 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string ProviderAdjustmentAmount_04 { get; set; }
        [Pos(5)]
        public C042_1508494285 C042_1508494285 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string ProviderAdjustmentAmount_06 { get; set; }
        [Pos(7)]
        public C042_1105209758 C042_1105209758 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string ProviderAdjustmentAmount_08 { get; set; }
        [Pos(9)]
        public C042_701925231 C042_701925231 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string ProviderAdjustmentAmount_10 { get; set; }
        [Pos(11)]
        public C042_1220454606 C042_1220454606 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string ProviderAdjustmentAmount_12 { get; set; }
        [Pos(13)]
        public C042_1623739133 C042_1623739133 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(14)]
        public string ProviderAdjustmentAmount_14 { get; set; }
    }
    
    [Serializable()]
    [Composite("C042_1623739133")]
    public class C042_1623739133
    {
        
        [Required]
        [DataElement("426", typeof(X12_ID_426_C042_1623739133))]
        [Pos(1)]
        public string AdjustmentReasonCode_01 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProviderAdjustmentIdentifier_02 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",50,51,72,90,AH,AM,AP,B2,B3,BD,BN,C5,CR,CS,CT,CV,CW,DM,E3,FB,FC,GO,IP,IR,IS,J1,L3" +
        ",L6,LE,LS,OA,OB,PI,PL,RA,RE,SL,TL,WO,WU,ZZ,")]
    public class X12_ID_426_C042_1623739133
    {
    }
    
    [Serializable()]
    [Composite("C042_1220454606")]
    public class C042_1220454606
    {
        
        [Required]
        [DataElement("426", typeof(X12_ID_426_C042_1220454606))]
        [Pos(1)]
        public string AdjustmentReasonCode_01 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProviderAdjustmentIdentifier_02 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",50,51,72,90,AH,AM,AP,B2,B3,BD,BN,C5,CR,CS,CT,CV,CW,DM,E3,FB,FC,GO,IP,IR,IS,J1,L3" +
        ",L6,LE,LS,OA,OB,PI,PL,RA,RE,SL,TL,WO,WU,ZZ,")]
    public class X12_ID_426_C042_1220454606
    {
    }
    
    [Serializable()]
    [Composite("C042_701925231")]
    public class C042_701925231
    {
        
        [Required]
        [DataElement("426", typeof(X12_ID_426_C042_701925231))]
        [Pos(1)]
        public string AdjustmentReasonCode_01 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProviderAdjustmentIdentifier_02 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",50,51,72,90,AH,AM,AP,B2,B3,BD,BN,C5,CR,CS,CT,CV,CW,DM,E3,FB,FC,GO,IP,IR,IS,J1,L3" +
        ",L6,LE,LS,OA,OB,PI,PL,RA,RE,SL,TL,WO,WU,ZZ,")]
    public class X12_ID_426_C042_701925231
    {
    }
    
    [Serializable()]
    [Composite("C042_1105209758")]
    public class C042_1105209758
    {
        
        [Required]
        [DataElement("426", typeof(X12_ID_426_C042_1105209758))]
        [Pos(1)]
        public string AdjustmentReasonCode_01 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProviderAdjustmentIdentifier_02 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",50,51,72,90,AH,AM,AP,B2,B3,BD,BN,C5,CR,CS,CT,CV,CW,DM,E3,FB,FC,GO,IP,IR,IS,J1,L3" +
        ",L6,LE,LS,OA,OB,PI,PL,RA,RE,SL,TL,WO,WU,ZZ,")]
    public class X12_ID_426_C042_1105209758
    {
    }
    
    [Serializable()]
    [Composite("C042_1508494285")]
    public class C042_1508494285
    {
        
        [Required]
        [DataElement("426", typeof(X12_ID_426_C042_1508494285))]
        [Pos(1)]
        public string AdjustmentReasonCode_01 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProviderAdjustmentIdentifier_02 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",50,51,72,90,AH,AM,AP,B2,B3,BD,BN,C5,CR,CS,CT,CV,CW,DM,E3,FB,FC,GO,IP,IR,IS,J1,L3" +
        ",L6,LE,LS,OA,OB,PI,PL,RA,RE,SL,TL,WO,WU,ZZ,")]
    public class X12_ID_426_C042_1508494285
    {
    }
    
    [Serializable()]
    [Composite("C042_1576553894")]
    public class C042_1576553894
    {
        
        [Required]
        [DataElement("426", typeof(X12_ID_426_C042_1576553894))]
        [Pos(1)]
        public string AdjustmentReasonCode_01 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProviderAdjustmentIdentifier_02 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",50,51,72,90,AH,AM,AP,B2,B3,BD,BN,C5,CR,CS,CT,CV,CW,DM,E3,FB,FC,GO,IP,IR,IS,J1,L3" +
        ",L6,LE,LS,OA,OB,PI,PL,RA,RE,SL,TL,WO,WU,ZZ,")]
    public class X12_ID_426_C042_1576553894
    {
    }
    
    [Serializable()]
    [Group(typeof(LX_HeaderNumber_2000))]
    public class Loop_2000
    {
        
        [Required]
        [Pos(1)]
        public LX_HeaderNumber_2000 LX_HeaderNumber_2000 { get; set; }
        [Pos(2)]
        public TS3_ProviderSummaryInformation_2000 TS3_ProviderSummaryInformation_2000 { get; set; }
        [Pos(3)]
        public TS2_ProviderSupplementalSummaryInformation_2000 TS2_ProviderSupplementalSummaryInformation_2000 { get; set; }
        [Required]
        [Pos(4)]
        public List<Loop_2100> Loop_2100 { get; set; }
    }
    
    [Serializable()]
    public class X12_N0
    {
    }
    
    [Serializable()]
    [Group(typeof(CLP_ClaimPaymentInformation_2100))]
    public class Loop_2100
    {
        
        [Required]
        [Pos(1)]
        public CLP_ClaimPaymentInformation_2100 CLP_ClaimPaymentInformation_2100 { get; set; }
        [ListCount(99)]
        [Pos(2)]
        public List<CAS_ClaimAdjustment_2100> CAS_ClaimAdjustment_2100 { get; set; }
        [Required]
        [Pos(3)]
        public All_NM1_2100 All_NM1_2100 { get; set; }
        [Pos(4)]
        public MIA_InpatientAdjudicationInformation_2100 MIA_InpatientAdjudicationInformation_2100 { get; set; }
        [Pos(5)]
        public MOA_OutpatientAdjudicationInformation_2100 MOA_OutpatientAdjudicationInformation_2100 { get; set; }
        [Pos(6)]
        public All_REF_2100 All_REF_2100 { get; set; }
        [ListCount(4)]
        [Pos(7)]
        public List<DTM_ClaimDate_2100> DTM_ClaimDate_2100 { get; set; }
        [ListCount(3)]
        [Pos(8)]
        public List<PER_ClaimContactInformation_2100> PER_ClaimContactInformation_2100 { get; set; }
        [ListCount(14)]
        [Pos(9)]
        public List<AMT_ClaimSupplementalInformation_2100> AMT_ClaimSupplementalInformation_2100 { get; set; }
        [ListCount(15)]
        [Pos(10)]
        public List<QTY_ClaimSupplementalInformationQuantity_2100> QTY_ClaimSupplementalInformationQuantity_2100 { get; set; }
        [ListCount(999)]
        [Pos(11)]
        public List<Loop_2110> Loop_2110 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,2,3,4,5,10,13,15,16,17,19,20,21,22,23,25,27,")]
    public class X12_ID_1029_CLP_ClaimPaymentInformation_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",CO,CR,OA,PI,PR,")]
    public class X12_ID_1033_CAS_ClaimAdjustment_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",036,050,232,233,")]
    public class X12_ID_374_DTM_ClaimDate_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",CX,")]
    public class X12_ID_366_PER_ClaimContactInformation_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",AU,D8,DY,F5,I,NL,T,ZK,ZL,ZM,ZN,ZO,ZZ,T2,")]
    public class X12_ID_522_AMT_ClaimSupplementalInformation_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",CA,CD,LA,LE,NA,NE,NR,OU,PS,VS,ZK,ZL,ZM,ZN,ZO,")]
    public class X12_ID_673_QTY_ClaimSupplementalInformationQuantity_2100
    {
    }
    
    [Serializable()]
    [Group(typeof(SVC_ServicePaymentInformation_2110))]
    public class Loop_2110
    {
        
        [Required]
        [Pos(1)]
        public SVC_ServicePaymentInformation_2110 SVC_ServicePaymentInformation_2110 { get; set; }
        [ListCount(3)]
        [Pos(2)]
        public List<DTM_ServiceDate_2110> DTM_ServiceDate_2110 { get; set; }
        [ListCount(99)]
        [Pos(3)]
        public List<CAS_ServiceAdjustment_2110> CAS_ServiceAdjustment_2110 { get; set; }
        [Pos(4)]
        public All_REF_2110 All_REF_2110 { get; set; }
        [ListCount(12)]
        [Pos(5)]
        public List<AMT_ServiceSupplementalAmount_2110> AMT_ServiceSupplementalAmount_2110 { get; set; }
        [ListCount(6)]
        [Pos(6)]
        public List<QTY_ServiceSupplementalQuantity_2110> QTY_ServiceSupplementalQuantity_2110 { get; set; }
        [ListCount(99)]
        [Pos(7)]
        public List<LQ_HealthCareRemarkCodes_2110> LQ_HealthCareRemarkCodes_2110 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AD,ER,HC,ID,IV,N4,NU,RB,ZZ,")]
    public class X12_ID_235_C003_1152853734
    {
    }
    
    [Serializable()]
    [EdiCodes(",150,151,472,")]
    public class X12_ID_374_DTM_ServiceDate_2110
    {
    }
    
    [Serializable()]
    [EdiCodes(",CO,CR,OA,PI,PR,")]
    public class X12_ID_1033_CAS_ServiceAdjustment_2110
    {
    }
    
    [Serializable()]
    [EdiCodes(",B6,DY,KH,NE,T,ZK,ZL,ZM,ZN,ZO,T2,")]
    public class X12_ID_522_AMT_ServiceSupplementalAmount_2110
    {
    }
    
    [Serializable()]
    [EdiCodes(",NE,ZK,ZL,ZM,ZN,ZO,")]
    public class X12_ID_673_QTY_ServiceSupplementalQuantity_2110
    {
    }
    
    [Serializable()]
    [EdiCodes(",HE,RX,")]
    public class X12_ID_1270_LQ_HealthCareRemarkCodes_2110
    {
    }
    
    [Serializable()]
    [Segment("LQ", typeof(X12_ID_1270_LQ_HealthCareRemarkCodes_2110))]
    public class LQ_HealthCareRemarkCodes_2110
    {
        
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_LQ_HealthCareRemarkCodes_2110))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string RemarkCode_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("QTY", typeof(X12_ID_673_QTY_ServiceSupplementalQuantity_2110))]
    public class QTY_ServiceSupplementalQuantity_2110
    {
        
        [Required]
        [DataElement("673", typeof(X12_ID_673_QTY_ServiceSupplementalQuantity_2110))]
        [Pos(1)]
        public string QuantityQualifier_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ServiceSupplementalQuantityCount_02 { get; set; }
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
    [Segment("AMT", typeof(X12_ID_522_AMT_ServiceSupplementalAmount_2110))]
    public class AMT_ServiceSupplementalAmount_2110
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_ServiceSupplementalAmount_2110))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ServiceSupplementalAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2110
    {
        
        [ListCount(7)]
        [Pos(1)]
        public List<REF_ServiceIdentification_2110> REF_ServiceIdentification_2110 { get; set; }
        [ListCount(10)]
        [Pos(2)]
        public List<REF_RenderingProviderInformation_2110> REF_RenderingProviderInformation_2110 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1S,6R,BB,E9,G1,G3,LU,RB,")]
    public class X12_ID_128_REF_ServiceIdentification_2110
    {
    }
    
    [Serializable()]
    [EdiCodes(",1A,1B,1C,1D,1G,1H,1J,HPI,SY,TJ,")]
    public class X12_ID_128_REF_RenderingProviderInformation_2110
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_RenderingProviderInformation_2110))]
    public class REF_RenderingProviderInformation_2110
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_RenderingProviderInformation_2110))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string RenderingProviderIdentifier_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_ServiceIdentification_2110))]
    public class REF_ServiceIdentification_2110
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ServiceIdentification_2110))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProviderIdentifier_02 { get; set; }
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
    [Segment("CAS", typeof(X12_ID_1033_CAS_ServiceAdjustment_2110))]
    public class CAS_ServiceAdjustment_2110
    {
        
        [Required]
        [DataElement("1033", typeof(X12_ID_1033_CAS_ServiceAdjustment_2110))]
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
    [Segment("DTM", typeof(X12_ID_374_DTM_ServiceDate_2110))]
    public class DTM_ServiceDate_2110
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTM_ServiceDate_2110))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string ServiceDate_02 { get; set; }
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
    public class X12_TM
    {
    }
    
    [Serializable()]
    [Segment("SVC", typeof(X12_ID_235_C003_1152853734))]
    public class SVC_ServicePaymentInformation_2110
    {
        
        [Required]
        [Pos(1)]
        public C003_1152853734 C003_1152853734 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string LineItemChargeAmount_02 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string LineItemProviderPaymentAmount_03 { get; set; }
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string NationalUniformBillingCommitteeRevenueCode_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string UnitsOfServicePaidCount_05 { get; set; }
        [Pos(6)]
        public C003_702449504 C003_702449504 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string OriginalUnitsOfServiceCount_07 { get; set; }
    }
    
    [Serializable()]
    [Composite("C003_702449504")]
    public class C003_702449504
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_702449504))]
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
    [EdiCodes(",AD,ER,HC,ID,IV,N4,NU,RB,ZZ,")]
    public class X12_ID_235_C003_702449504
    {
    }
    
    [Serializable()]
    [Composite("C003_1152853734")]
    public class C003_1152853734
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_1152853734))]
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
    [Segment("QTY", typeof(X12_ID_673_QTY_ClaimSupplementalInformationQuantity_2100))]
    public class QTY_ClaimSupplementalInformationQuantity_2100
    {
        
        [Required]
        [DataElement("673", typeof(X12_ID_673_QTY_ClaimSupplementalInformationQuantity_2100))]
        [Pos(1)]
        public string QuantityQualifier_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ClaimSupplementalInformationQuantity_02 { get; set; }
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
    [Segment("AMT", typeof(X12_ID_522_AMT_ClaimSupplementalInformation_2100))]
    public class AMT_ClaimSupplementalInformation_2100
    {
        
        [Required]
        [DataElement("522", typeof(X12_ID_522_AMT_ClaimSupplementalInformation_2100))]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string ClaimSupplementalInformationAmount_02 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string AMT_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_ClaimContactInformation_2100))]
    public class PER_ClaimContactInformation_2100
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_ClaimContactInformation_2100))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ClaimContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ClaimContactInformation_2100))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ClaimContactCommunicationsNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ClaimContactInformation_2100))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ClaimContactCommunicationsNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_ClaimContactInformation_2100))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string CommunicationNumberExtension_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EM,FX,TE,")]
    public class X12_ID_365_PER_ClaimContactInformation_2100
    {
    }
    
    [Serializable()]
    [Segment("DTM", typeof(X12_ID_374_DTM_ClaimDate_2100))]
    public class DTM_ClaimDate_2100
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTM_ClaimDate_2100))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string ClaimDate_02 { get; set; }
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
    [All()]
    public class All_REF_2100
    {
        
        [ListCount(5)]
        [Pos(1)]
        public List<REF_OtherClaimRelatedIdentification_2100> REF_OtherClaimRelatedIdentification_2100 { get; set; }
        [ListCount(10)]
        [Pos(2)]
        public List<REF_RenderingProviderIdentification_2100> REF_RenderingProviderIdentification_2100 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1L,1W,9A,9C,A6,BB,CE,EA,F8,G1,G3,IG,SY,")]
    public class X12_ID_128_REF_OtherClaimRelatedIdentification_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",1A,1B,1C,1D,1G,1H,D3,G2,")]
    public class X12_ID_128_REF_RenderingProviderIdentification_2100
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_RenderingProviderIdentification_2100))]
    public class REF_RenderingProviderIdentification_2100
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_RenderingProviderIdentification_2100))]
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
    [Segment("REF", typeof(X12_ID_128_REF_OtherClaimRelatedIdentification_2100))]
    public class REF_OtherClaimRelatedIdentification_2100
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_OtherClaimRelatedIdentification_2100))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string OtherClaimRelatedIdentifier_02 { get; set; }
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
    [Segment("MOA")]
    public class MOA_OutpatientAdjudicationInformation_2100
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
    public class MIA_InpatientAdjudicationInformation_2100
    {
        
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(1)]
        public string CoveredDaysOrVisitsCount_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string PPSOperatingOutlierAmount_02 { get; set; }
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
    [All()]
    public class All_NM1_2100
    {
        
        [Required]
        [Pos(1)]
        public NM1_PatientName_2100 NM1_PatientName_2100 { get; set; }
        [Pos(2)]
        public NM1_InsuredName_2100 NM1_InsuredName_2100 { get; set; }
        [Pos(3)]
        public NM1_CorrectedPatientInsuredName_2100 NM1_CorrectedPatientInsuredName_2100 { get; set; }
        [Pos(4)]
        public NM1_ServiceProviderName_2100 NM1_ServiceProviderName_2100 { get; set; }
        [Pos(5)]
        public NM1_CrossoverCarrierName_2100 NM1_CrossoverCarrierName_2100 { get; set; }
        [ListCount(2)]
        [Pos(6)]
        public List<NM1_CorrectedPriorityPayerName_2100> NM1_CorrectedPriorityPayerName_2100 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",QC,")]
    public class X12_ID_98_NM1_PatientName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_PatientName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",IL,")]
    public class X12_ID_98_NM1_InsuredName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_InsuredName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",74,")]
    public class X12_ID_98_NM1_CorrectedPatientInsuredName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_CorrectedPatientInsuredName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",82,")]
    public class X12_ID_98_NM1_ServiceProviderName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_ServiceProviderName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",TT,")]
    public class X12_ID_98_NM1_CrossoverCarrierName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_CrossoverCarrierName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_NM1_CorrectedPriorityPayerName_2100
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_CorrectedPriorityPayerName_2100
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_CorrectedPriorityPayerName_2100), typeof(X12_ID_1065_NM1_CorrectedPriorityPayerName_2100))]
    public class NM1_CorrectedPriorityPayerName_2100
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_CorrectedPriorityPayerName_2100))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_CorrectedPriorityPayerName_2100))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CorrectedPriorityPayerName_03 { get; set; }
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
        [DataElement("66", typeof(X12_ID_66_NM1_CorrectedPriorityPayerName_2100))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string CorrectedPriorityPayerIdentificationNumber_09 { get; set; }
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
    [EdiCodes(",AD,FI,NI,PI,PP,XV,")]
    public class X12_ID_66_NM1_CorrectedPriorityPayerName_2100
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_CrossoverCarrierName_2100), typeof(X12_ID_1065_NM1_CrossoverCarrierName_2100))]
    public class NM1_CrossoverCarrierName_2100
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_CrossoverCarrierName_2100))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_CrossoverCarrierName_2100))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CoordinationOfBenefitsCarrierName_03 { get; set; }
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
        [DataElement("66", typeof(X12_ID_66_NM1_CrossoverCarrierName_2100))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string CoordinationOfBenefitsCarrierIdentifier_09 { get; set; }
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
    [EdiCodes(",AD,FI,NI,PI,PP,XV,")]
    public class X12_ID_66_NM1_CrossoverCarrierName_2100
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_ServiceProviderName_2100), typeof(X12_ID_1065_NM1_ServiceProviderName_2100))]
    public class NM1_ServiceProviderName_2100
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ServiceProviderName_2100))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ServiceProviderName_2100))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
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
        [DataElement("66", typeof(X12_ID_66_NM1_ServiceProviderName_2100))]
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
    [EdiCodes(",BD,BS,FI,MC,PC,SL,UP,XX,")]
    public class X12_ID_66_NM1_ServiceProviderName_2100
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_CorrectedPatientInsuredName_2100), typeof(X12_ID_1065_NM1_CorrectedPatientInsuredName_2100))]
    public class NM1_CorrectedPatientInsuredName_2100
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_CorrectedPatientInsuredName_2100))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_CorrectedPatientInsuredName_2100))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string CorrectedPatientOrInsuredLastName_03 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CorrectedPatientOrInsuredFirstName_04 { get; set; }
        [StringLength(1, 25)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string CorrectedPatientOrInsuredMiddleName_05 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string NM1_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string CorrectedPatientOrInsuredNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_CorrectedPatientInsuredName_2100))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string CorrectedInsuredIdentificationIndicator_09 { get; set; }
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
    [EdiCodes(",C,")]
    public class X12_ID_66_NM1_CorrectedPatientInsuredName_2100
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_InsuredName_2100), typeof(X12_ID_1065_NM1_InsuredName_2100))]
    public class NM1_InsuredName_2100
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_InsuredName_2100))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_InsuredName_2100))]
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
        [DataElement("66", typeof(X12_ID_66_NM1_InsuredName_2100))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
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
    [EdiCodes(",34,HN,MI,")]
    public class X12_ID_66_NM1_InsuredName_2100
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_PatientName_2100), typeof(X12_ID_1065_NM1_PatientName_2100))]
    public class NM1_PatientName_2100
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_PatientName_2100))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_PatientName_2100))]
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
        [DataElement("66", typeof(X12_ID_66_NM1_PatientName_2100))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PatientIdentifier_09 { get; set; }
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
    [EdiCodes(",34,HN,MI,MR,")]
    public class X12_ID_66_NM1_PatientName_2100
    {
    }
    
    [Serializable()]
    [Segment("CAS", typeof(X12_ID_1033_CAS_ClaimAdjustment_2100))]
    public class CAS_ClaimAdjustment_2100
    {
        
        [Required]
        [DataElement("1033", typeof(X12_ID_1033_CAS_ClaimAdjustment_2100))]
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
    [Segment("CLP")]
    public class CLP_ClaimPaymentInformation_2100
    {
        
        [Required]
        [StringLength(1, 38)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PatientControlNumber_01 { get; set; }
        [Required]
        [DataElement("1029", typeof(X12_ID_1029_CLP_ClaimPaymentInformation_2100))]
        [Pos(2)]
        public string ClaimStatusCode_02 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string TotalClaimChargeAmount_03 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string ClaimPaymentAmount_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string PatientResponsibilityAmount_05 { get; set; }
        [Required]
        [DataElement("1032", typeof(X12_ID_1032_CLP_ClaimPaymentInformation_2100))]
        [Pos(6)]
        public string ClaimFilingIndicatorCode_06 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string PayerClaimControlNumber_07 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string FacilityTypeCode_08 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(9)]
        public string ClaimFrequencyCode_09 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(10)]
        public string CLP_10 { get; set; }
        [StringLength(1, 4)]
        [DataElement("", typeof(X12_ID))]
        [Pos(11)]
        public string DiagnosisRelatedGroupDRGCode_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string DiagnosisRelatedGroupDRGWeight_12 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(13)]
        public string DischargeFraction_13 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",12,13,14,15,16,AM,CH,DS,HM,LM,MA,MB,MC,OF,TV,VA,WC,")]
    public class X12_ID_1032_CLP_ClaimPaymentInformation_2100
    {
    }
    
    [Serializable()]
    [Segment("TS2")]
    public class TS2_ProviderSupplementalSummaryInformation_2000
    {
        
        [DataElement("", typeof(X12_R))]
        [Pos(1)]
        public string TotalDRGAmount_01 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string TotalFederalSpecificAmount_02 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string TotalHospitalSpecificAmount_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string TotalDisproportionateShareAmount_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string TotalCapitalAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string TotalIndirectMedicalEducationAmount_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string TotalOutlierDayCount_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string TotalDayOutlierAmount_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string TotalCostOutlierAmount_09 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string AverageDRGLengthOfStay_10 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(11)]
        public string TotalDischargeCount_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string TotalCostReportDayCount_12 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(13)]
        public string TotalCoveredDayCount_13 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(14)]
        public string TotalNoncoveredDayCount_14 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string TotalMSPPassThroughAmount_15 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(16)]
        public string AverageDRGWeight_16 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(17)]
        public string TotalPPSCapitalFSPDRGAmount_17 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(18)]
        public string TotalPPSCapitalHSPDRGAmount_18 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(19)]
        public string TotalPPSDSHDRGAmount_19 { get; set; }
    }
    
    [Serializable()]
    [Segment("TS3")]
    public class TS3_ProviderSummaryInformation_2000
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string ProviderIdentifier_01 { get; set; }
        [Required]
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string FacilityTypeCode_02 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(3)]
        public string FiscalPeriodDate_03 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string TotalClaimCount_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string TotalClaimChargeAmount_05 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string TotalCoveredChargeAmount_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string TotalNoncoveredChargeAmount_07 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string TotalDeniedChargeAmount_08 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string TotalProviderPaymentAmount_09 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(10)]
        public string TotalInterestAmount_10 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(11)]
        public string TotalContractualAdjustmentAmount_11 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string TotalGrammRudmanReductionAmount_12 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(13)]
        public string TotalMSPPayerAmount_13 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(14)]
        public string TotalBloodDeductibleAmount_14 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string TotalNonLabChargeAmount_15 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(16)]
        public string TotalCoinsuranceAmount_16 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(17)]
        public string TotalHCPCSReportedChargeAmount_17 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(18)]
        public string TotalHCPCSPayableAmount_18 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(19)]
        public string TotalDeductibleAmount_19 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(20)]
        public string TotalProfessionalComponentAmount_20 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(21)]
        public string TotalMSPPatientLiabilityMetAmount_21 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(22)]
        public string TotalPatientReimbursementAmount_22 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(23)]
        public string TotalPIPClaimCount_23 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(24)]
        public string TotalPIPAdjustmentAmount_24 { get; set; }
    }
    
    [Serializable()]
    [Segment("LX")]
    public class LX_HeaderNumber_2000
    {
        
        [Required]
        [DataElement("", typeof(X12_N0))]
        [Pos(1)]
        public string AssignedNumber_01 { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(N1_PayeeIdentification_1000B))]
    public class Loop_1000B
    {
        
        [Required]
        [Pos(1)]
        public N1_PayeeIdentification_1000B N1_PayeeIdentification_1000B { get; set; }
        [Pos(2)]
        public N3_PayeeAddress_1000B N3_PayeeAddress_1000B { get; set; }
        [Pos(3)]
        public N4_PayeeCityStateZIPCode_1000B N4_PayeeCityStateZIPCode_1000B { get; set; }
        [Pos(4)]
        public List<REF_PayeeAdditionalIdentification_1000B> REF_PayeeAdditionalIdentification_1000B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PE,")]
    public class X12_ID_98_N1_PayeeIdentification_1000B
    {
    }
    
    [Serializable()]
    [EdiCodes(",0B,1A,1B,1C,1D,1E,1F,1G,1H,D3,G2,N5,PQ,TJ,")]
    public class X12_ID_128_REF_PayeeAdditionalIdentification_1000B
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_PayeeAdditionalIdentification_1000B))]
    public class REF_PayeeAdditionalIdentification_1000B
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PayeeAdditionalIdentification_1000B))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string AdditionalPayeeIdentifier_02 { get; set; }
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
    public class N4_PayeeCityStateZIPCode_1000B
    {
        
        [Required]
        [StringLength(2, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PayeeCityName_01 { get; set; }
        [Required]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(2)]
        public string PayeeStateCode_02 { get; set; }
        [Required]
        [StringLength(3, 15)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string PayeePostalZoneOrZIPCode_03 { get; set; }
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
    public class N3_PayeeAddress_1000B
    {
        
        [Required]
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string PayeeAddressLine_01 { get; set; }
        [StringLength(1, 55)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayeeAddressLine_02 { get; set; }
    }
    
    [Serializable()]
    [Segment("N1", typeof(X12_ID_98_N1_PayeeIdentification_1000B))]
    public class N1_PayeeIdentification_1000B
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_N1_PayeeIdentification_1000B))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayeeName_02 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_N1_PayeeIdentification_1000B))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string PayeeIdentificationCode_04 { get; set; }
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
    [EdiCodes(",FI,XX,")]
    public class X12_ID_66_N1_PayeeIdentification_1000B
    {
    }
    
    [Serializable()]
    [Group(typeof(N1_PayerIdentification_1000A))]
    public class Loop_1000A
    {
        
        [Required]
        [Pos(1)]
        public N1_PayerIdentification_1000A N1_PayerIdentification_1000A { get; set; }
        [Required]
        [Pos(2)]
        public N3_PayerAddress_1000A N3_PayerAddress_1000A { get; set; }
        [Required]
        [Pos(3)]
        public N4_PayerCityStateZIPCode_1000A N4_PayerCityStateZIPCode_1000A { get; set; }
        [ListCount(4)]
        [Pos(4)]
        public List<REF_AdditionalPayerIdentification_1000A> REF_AdditionalPayerIdentification_1000A { get; set; }
        [Pos(5)]
        public PER_PayerContactInformation_1000A PER_PayerContactInformation_1000A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_N1_PayerIdentification_1000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",2U,EO,HI,NF,")]
    public class X12_ID_128_REF_AdditionalPayerIdentification_1000A
    {
    }
    
    [Serializable()]
    [EdiCodes(",CX,")]
    public class X12_ID_366_PER_PayerContactInformation_1000A
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_PayerContactInformation_1000A))]
    public class PER_PayerContactInformation_1000A
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_PayerContactInformation_1000A))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayerContactName_02 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_PayerContactInformation_1000A))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string PayerContactCommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_PayerContactInformation_1000A))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string PayerContactCommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_PayerContactInformation_1000A))]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string PayerContactCommunicationNumber_08 { get; set; }
        [StringLength(1, 20)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string PER_09 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EM,FX,TE,")]
    public class X12_ID_365_PER_PayerContactInformation_1000A
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_AdditionalPayerIdentification_1000A))]
    public class REF_AdditionalPayerIdentification_1000A
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_AdditionalPayerIdentification_1000A))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string AdditionalPayerIdentifier_02 { get; set; }
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
    public class N4_PayerCityStateZIPCode_1000A
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
        public string N4_04 { get; set; }
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
    public class N3_PayerAddress_1000A
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
    [Segment("N1", typeof(X12_ID_98_N1_PayerIdentification_1000A))]
    public class N1_PayerIdentification_1000A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_N1_PayerIdentification_1000A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayerName_02 { get; set; }
        [DataElement("66", typeof(X12_ID_66_N1_PayerIdentification_1000A))]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string PayerIdentifier_04 { get; set; }
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
    [EdiCodes(",XV,")]
    public class X12_ID_66_N1_PayerIdentification_1000A
    {
    }
    
    [Serializable()]
    [Segment("DTM", typeof(X12_ID_374_DTM_ProductionDate))]
    public class DTM_ProductionDate
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTM_ProductionDate))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string ProductionDate_02 { get; set; }
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
    [All()]
    public class All_REF
    {
        
        [Pos(1)]
        public REF_ReceiverIdentification REF_ReceiverIdentification { get; set; }
        [Pos(2)]
        public REF_VersionIdentification REF_VersionIdentification { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",EV,")]
    public class X12_ID_128_REF_ReceiverIdentification
    {
    }
    
    [Serializable()]
    [EdiCodes(",F2,")]
    public class X12_ID_128_REF_VersionIdentification
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_VersionIdentification))]
    public class REF_VersionIdentification
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_VersionIdentification))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string VersionIdentificationCode_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_ReceiverIdentification))]
    public class REF_ReceiverIdentification
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ReceiverIdentification))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ReceiverIdentifier_02 { get; set; }
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
    [Segment("CUR", typeof(X12_ID_98_CUR_ForeignCurrencyInformation))]
    public class CUR_ForeignCurrencyInformation
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_CUR_ForeignCurrencyInformation))]
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
    [Segment("TRN", typeof(X12_ID_481_TRN_ReassociationTraceNumber))]
    public class TRN_ReassociationTraceNumber
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_ReassociationTraceNumber))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string CheckOrEFTTraceNumber_02 { get; set; }
        [Required]
        [StringLength(10, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PayerIdentifier_03 { get; set; }
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
        public string TotalActualProviderPaymentAmount_02 { get; set; }
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
        public string SenderDFIIdentifier_07 { get; set; }
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
        public string PayerIdentifier_10 { get; set; }
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
        public string ReceiverOrProviderBankIDNumber_13 { get; set; }
        [DataElement("569", typeof(X12_ID_569_BPR_FinancialInformation))]
        [Pos(14)]
        public string AccountNumberQualifier_14 { get; set; }
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(15)]
        public string ReceiverOrProviderAccountNumber_15 { get; set; }
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
    [EdiCodes(",ACH,BOP,CHK,FWT,NON,")]
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
    [EdiCodes(",DA,")]
    public class X12_ID_569_BPR_FinancialInformation
    {
    }
}
