namespace EdiFabric.Rules.HIPAA_004010X093A1_277
{
    using System;
    using System.Collections.Generic;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    
    
    [Serializable()]
    [Message("X12", "004010X093A1", "277")]
    public class TS277 : EdiMessage
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
    [EdiCodes(",0010,")]
    public class X12_ID_1005_BHT_BeginningOfHierarchicalTransaction
    {
    }
    
    [Serializable()]
    [EdiCodes(",08,")]
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
        public List<Loop_2100A> Loop_2100A { get; set; }
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
        public List<Loop_2100B> Loop_2100B { get; set; }
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
    [Group(typeof(HL_ServiceProviderLevel_2000C))]
    public class Loop_2000C
    {
        
        [Required]
        [Pos(1)]
        public HL_ServiceProviderLevel_2000C HL_ServiceProviderLevel_2000C { get; set; }
        [Required]
        [Pos(2)]
        public List<Loop_2100C> Loop_2100C { get; set; }
        [Required]
        [Pos(3)]
        public List<Loop_2000D> Loop_2000D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",19,")]
    public class X12_ID_735_HL_ServiceProviderLevel_2000C
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_SubscriberLevel_2000D))]
    public class Loop_2000D
    {
        
        [Required]
        [Pos(1)]
        public HL_SubscriberLevel_2000D HL_SubscriberLevel_2000D { get; set; }
        [Pos(2)]
        public DMG_SubscriberDemographicInformation_2000D DMG_SubscriberDemographicInformation_2000D { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2100D Loop_2100D { get; set; }
        [Pos(4)]
        public List<Loop_2200D> Loop_2200D { get; set; }
        [Pos(5)]
        public List<Loop_2000E> Loop_2000E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",22,")]
    public class X12_ID_735_HL_SubscriberLevel_2000D
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_SubscriberDemographicInformation_2000D
    {
    }
    
    [Serializable()]
    [Group(typeof(HL_DependentLevel_2000E))]
    public class Loop_2000E
    {
        
        [Required]
        [Pos(1)]
        public HL_DependentLevel_2000E HL_DependentLevel_2000E { get; set; }
        [Required]
        [Pos(2)]
        public DMG_DependentDemographicInformation_2000E DMG_DependentDemographicInformation_2000E { get; set; }
        [Required]
        [Pos(3)]
        public Loop_2100E Loop_2100E { get; set; }
        [Required]
        [Pos(4)]
        public List<Loop_2200E> Loop_2200E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",23,")]
    public class X12_ID_735_HL_DependentLevel_2000E
    {
    }
    
    [Serializable()]
    [EdiCodes(",D8,")]
    public class X12_ID_1250_DMG_DependentDemographicInformation_2000E
    {
    }
    
    [Serializable()]
    [Group(typeof(TRN_ClaimSubmitterTraceNumber_2200E))]
    public class Loop_2200E
    {
        
        [Required]
        [Pos(1)]
        public TRN_ClaimSubmitterTraceNumber_2200E TRN_ClaimSubmitterTraceNumber_2200E { get; set; }
        [Required]
        [Pos(2)]
        public STC_ClaimLevelStatusInformation_2200E STC_ClaimLevelStatusInformation_2200E { get; set; }
        [Required]
        [Pos(3)]
        public All_REF_2200E All_REF_2200E { get; set; }
        [Pos(4)]
        public DTP_ClaimServiceDate_2200E DTP_ClaimServiceDate_2200E { get; set; }
        [Pos(5)]
        public List<Loop_2220E> Loop_2220E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_481_TRN_ClaimSubmitterTraceNumber_2200E
    {
    }
    
    [Serializable()]
    public class X12_DT
    {
    }
    
    [Serializable()]
    [EdiCodes(",232,")]
    public class X12_ID_374_DTP_ClaimServiceDate_2200E
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_DTP_ClaimServiceDate_2200E
    {
    }
    
    [Serializable()]
    [Group(typeof(SVC_ServiceLineInformation_2220E))]
    public class Loop_2220E
    {
        
        [Required]
        [Pos(1)]
        public SVC_ServiceLineInformation_2220E SVC_ServiceLineInformation_2220E { get; set; }
        [Pos(2)]
        public STC_ServiceLineStatusInformation_2220E STC_ServiceLineStatusInformation_2220E { get; set; }
        [Pos(3)]
        public REF_ServiceLineItemIdentification_2220E REF_ServiceLineItemIdentification_2220E { get; set; }
        [Pos(4)]
        public DTP_ServiceLineDate_2220E DTP_ServiceLineDate_2220E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AD,CI,HC,ID,IV,N1,N2,N3,N4,ND,NH,NU,RB,")]
    public class X12_ID_235_C003_1508363204
    {
    }
    
    [Serializable()]
    public class X12_R
    {
    }
    
    [Serializable()]
    [EdiCodes(",FJ,")]
    public class X12_ID_128_REF_ServiceLineItemIdentification_2220E
    {
    }
    
    [Serializable()]
    [EdiCodes(",472,")]
    public class X12_ID_374_DTP_ServiceLineDate_2220E
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_DTP_ServiceLineDate_2220E
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_ServiceLineDate_2220E), typeof(X12_ID_1250_DTP_ServiceLineDate_2220E))]
    public class DTP_ServiceLineDate_2220E
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ServiceLineDate_2220E))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ServiceLineDate_2220E))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ServiceDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_ServiceLineItemIdentification_2220E))]
    public class REF_ServiceLineItemIdentification_2220E
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ServiceLineItemIdentification_2220E))]
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
    [Segment("STC")]
    public class STC_ServiceLineStatusInformation_2220E
    {
        
        [Required]
        [Pos(1)]
        public C043_1220585687 C043_1220585687 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string StatusInformationEffectiveDate_02 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string STC_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string LineItemChargeAmount_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string LineItemProviderPaymentAmount_05 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(6)]
        public string STC_06 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string STC_07 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(8)]
        public string STC_08 { get; set; }
        [StringLength(1, 16)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string STC_09 { get; set; }
        [Pos(10)]
        public C043_1105013141 C043_1105013141 { get; set; }
        [Pos(11)]
        public C043_1576816047 C043_1576816047 { get; set; }
        [StringLength(1, 264)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string STC_12 { get; set; }
    }
    
    [Serializable()]
    public class X12_ID
    {
    }
    
    [Serializable()]
    [Composite("C043_1576816047")]
    public class C043_1576816047
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_1576816047))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_1576816047
    {
    }
    
    [Serializable()]
    [Composite("C043_1105013141")]
    public class C043_1105013141
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_1105013141))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_1105013141
    {
    }
    
    [Serializable()]
    [Composite("C043_1220585687")]
    public class C043_1220585687
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_1220585687))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2D,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_1220585687
    {
    }
    
    [Serializable()]
    [Segment("SVC", typeof(X12_ID_235_C003_1508363204))]
    public class SVC_ServiceLineInformation_2220E
    {
        
        [Required]
        [Pos(1)]
        public C003_1508363204 C003_1508363204 { get; set; }
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
        public string RevenueCode_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string SVC_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string SVC_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string OriginalUnitsOfServiceCount_07 { get; set; }
    }
    
    [Serializable()]
    [Composite("C003_1508363204")]
    public class C003_1508363204
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_1508363204))]
        [Pos(1)]
        public string ProductOrServiceIDQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ServiceIdentificationCode_02 { get; set; }
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
        public string SVC_07 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_ClaimServiceDate_2200E), typeof(X12_ID_1250_DTP_ClaimServiceDate_2200E))]
    public class DTP_ClaimServiceDate_2200E
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ClaimServiceDate_2200E))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ClaimServiceDate_2200E))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ClaimServicePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2200E
    {
        
        [Required]
        [Pos(1)]
        public REF_PayerClaimIdentificationNumber_2200E REF_PayerClaimIdentificationNumber_2200E { get; set; }
        [Pos(2)]
        public REF_InstitutionalBillTypeIdentification_2200E REF_InstitutionalBillTypeIdentification_2200E { get; set; }
        [Pos(3)]
        public REF_MedicalRecordIdentification_2200E REF_MedicalRecordIdentification_2200E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1K,")]
    public class X12_ID_128_REF_PayerClaimIdentificationNumber_2200E
    {
    }
    
    [Serializable()]
    [EdiCodes(",BLT,")]
    public class X12_ID_128_REF_InstitutionalBillTypeIdentification_2200E
    {
    }
    
    [Serializable()]
    [EdiCodes(",EA,")]
    public class X12_ID_128_REF_MedicalRecordIdentification_2200E
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_MedicalRecordIdentification_2200E))]
    public class REF_MedicalRecordIdentification_2200E
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_MedicalRecordIdentification_2200E))]
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
    [Segment("REF", typeof(X12_ID_128_REF_InstitutionalBillTypeIdentification_2200E))]
    public class REF_InstitutionalBillTypeIdentification_2200E
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_InstitutionalBillTypeIdentification_2200E))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BillTypeIdentifier_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_PayerClaimIdentificationNumber_2200E))]
    public class REF_PayerClaimIdentificationNumber_2200E
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PayerClaimIdentificationNumber_2200E))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayerClaimControlNumber_02 { get; set; }
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
    [Segment("STC")]
    public class STC_ClaimLevelStatusInformation_2200E
    {
        
        [Required]
        [Pos(1)]
        public C043_2026958133 C043_2026958133 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string StatusInformationEffectiveDate_02 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string STC_03 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string TotalClaimChargeAmount_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ClaimPaymentAmount_05 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(6)]
        public string AdjudicationOrPaymentDate_06 { get; set; }
        [DataElement("591", typeof(X12_ID_591_STC_ClaimLevelStatusInformation_2200E))]
        [Pos(7)]
        public string PaymentMethodCode_07 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(8)]
        public string CheckIssueOrEFTEffectiveDate_08 { get; set; }
        [StringLength(1, 16)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string CheckOrEFTTraceNumber_09 { get; set; }
        [Pos(10)]
        public C043_1220454615 C043_1220454615 { get; set; }
        [Pos(11)]
        public C043_1105144213 C043_1105144213 { get; set; }
        [StringLength(1, 264)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string STC_12 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ACH,BOP,CHK,FWT,NON,")]
    public class X12_ID_591_STC_ClaimLevelStatusInformation_2200E
    {
    }
    
    [Serializable()]
    [Composite("C043_1105144213")]
    public class C043_1105144213
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_1105144213))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_1105144213
    {
    }
    
    [Serializable()]
    [Composite("C043_1220454615")]
    public class C043_1220454615
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_1220454615))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_1220454615
    {
    }
    
    [Serializable()]
    [Composite("C043_2026958133")]
    public class C043_2026958133
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_2026958133))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2D,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_2026958133
    {
    }
    
    [Serializable()]
    [Segment("TRN", typeof(X12_ID_481_TRN_ClaimSubmitterTraceNumber_2200E))]
    public class TRN_ClaimSubmitterTraceNumber_2200E
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_ClaimSubmitterTraceNumber_2200E))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TraceNumber_02 { get; set; }
        [StringLength(10, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string TRN_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string TRN_04 { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_DependentName_2100E))]
    public class Loop_2100E
    {
        
        [Required]
        [Pos(1)]
        public NM1_DependentName_2100E NM1_DependentName_2100E { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",QC,")]
    public class X12_ID_98_NM1_DependentName_2100E
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_1065_NM1_DependentName_2100E
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_DependentName_2100E), typeof(X12_ID_1065_NM1_DependentName_2100E))]
    public class NM1_DependentName_2100E
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_DependentName_2100E))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_DependentName_2100E))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string PatientLastName_03 { get; set; }
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
        public string PatientNamePrefix_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string PatientNameSuffix_07 { get; set; }
        [DataElement("66", typeof(X12_ID_66_NM1_DependentName_2100E))]
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
    public class X12_ID_66_NM1_DependentName_2100E
    {
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_DependentDemographicInformation_2000E))]
    public class DMG_DependentDemographicInformation_2000E
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_DependentDemographicInformation_2000E))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PatientBirthDate_02 { get; set; }
        [Required]
        [DataElement("1068", typeof(X12_ID_1068_DMG_DependentDemographicInformation_2000E))]
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
    public class X12_ID_1068_DMG_DependentDemographicInformation_2000E
    {
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_DependentLevel_2000E))]
    public class HL_DependentLevel_2000E
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
        [DataElement("735", typeof(X12_ID_735_HL_DependentLevel_2000E))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_ID))]
        [Pos(4)]
        public string HL_04 { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(TRN_ClaimSubmitterTraceNumber_2200D))]
    public class Loop_2200D
    {
        
        [Required]
        [Pos(1)]
        public TRN_ClaimSubmitterTraceNumber_2200D TRN_ClaimSubmitterTraceNumber_2200D { get; set; }
        [Required]
        [Pos(2)]
        public STC_ClaimLevelStatusInformation_2200D STC_ClaimLevelStatusInformation_2200D { get; set; }
        [Pos(3)]
        public All_REF_2200D All_REF_2200D { get; set; }
        [Pos(4)]
        public DTP_ClaimServiceDate_2200D DTP_ClaimServiceDate_2200D { get; set; }
        [Pos(5)]
        public List<Loop_2220D> Loop_2220D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_481_TRN_ClaimSubmitterTraceNumber_2200D
    {
    }
    
    [Serializable()]
    [EdiCodes(",232,")]
    public class X12_ID_374_DTP_ClaimServiceDate_2200D
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_DTP_ClaimServiceDate_2200D
    {
    }
    
    [Serializable()]
    [Group(typeof(SVC_ServiceLineInformation_2220D))]
    public class Loop_2220D
    {
        
        [Required]
        [Pos(1)]
        public SVC_ServiceLineInformation_2220D SVC_ServiceLineInformation_2220D { get; set; }
        [Pos(2)]
        public STC_ServiceLineStatusInformation_2220D STC_ServiceLineStatusInformation_2220D { get; set; }
        [Pos(3)]
        public REF_ServiceLineItemIdentification_2220D REF_ServiceLineItemIdentification_2220D { get; set; }
        [Pos(4)]
        public DTP_ServiceLineDate_2220D DTP_ServiceLineDate_2220D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",AD,CI,HC,ID,IV,N1,N2,N3,N4,ND,NH,NU,RB,")]
    public class X12_ID_235_C003_843663465
    {
    }
    
    [Serializable()]
    [EdiCodes(",FJ,")]
    public class X12_ID_128_REF_ServiceLineItemIdentification_2220D
    {
    }
    
    [Serializable()]
    [EdiCodes(",472,")]
    public class X12_ID_374_DTP_ServiceLineDate_2220D
    {
    }
    
    [Serializable()]
    [EdiCodes(",RD8,")]
    public class X12_ID_1250_DTP_ServiceLineDate_2220D
    {
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_ServiceLineDate_2220D), typeof(X12_ID_1250_DTP_ServiceLineDate_2220D))]
    public class DTP_ServiceLineDate_2220D
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ServiceLineDate_2220D))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ServiceLineDate_2220D))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ServiceLineDate_03 { get; set; }
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_ServiceLineItemIdentification_2220D))]
    public class REF_ServiceLineItemIdentification_2220D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_ServiceLineItemIdentification_2220D))]
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
    [Segment("STC")]
    public class STC_ServiceLineStatusInformation_2220D
    {
        
        [Required]
        [Pos(1)]
        public C043_1623608070 C043_1623608070 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string StatusInformationEffectiveDate_02 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string STC_03 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string LineItemChargeAmount_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string LineItemProviderPaymentAmount_05 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(6)]
        public string STC_06 { get; set; }
        [StringLength(3, 3)]
        [DataElement("", typeof(X12_ID))]
        [Pos(7)]
        public string STC_07 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(8)]
        public string STC_08 { get; set; }
        [StringLength(1, 16)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string STC_09 { get; set; }
        [Pos(10)]
        public C043_701990758 C043_701990758 { get; set; }
        [Pos(11)]
        public C043_1508494276 C043_1508494276 { get; set; }
        [StringLength(1, 264)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string STC_12 { get; set; }
    }
    
    [Serializable()]
    [Composite("C043_1508494276")]
    public class C043_1508494276
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_1508494276))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_1508494276
    {
    }
    
    [Serializable()]
    [Composite("C043_701990758")]
    public class C043_701990758
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_701990758))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_701990758
    {
    }
    
    [Serializable()]
    [Composite("C043_1623608070")]
    public class C043_1623608070
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_1623608070))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_1623608070
    {
    }
    
    [Serializable()]
    [Segment("SVC", typeof(X12_ID_235_C003_843663465))]
    public class SVC_ServiceLineInformation_2220D
    {
        
        [Required]
        [Pos(1)]
        public C003_843663465 C003_843663465 { get; set; }
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
        public string RevenueCode_04 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string SVC_05 { get; set; }
        [StringLength(1, 1)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string SVC_06 { get; set; }
        [DataElement("", typeof(X12_R))]
        [Pos(7)]
        public string OriginalUnitsOfServiceCount_07 { get; set; }
    }
    
    [Serializable()]
    [Composite("C003_843663465")]
    public class C003_843663465
    {
        
        [Required]
        [DataElement("235", typeof(X12_ID_235_C003_843663465))]
        [Pos(1)]
        public string ProductOrServiceIDQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ServiceIdentificationCode_02 { get; set; }
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
        public string SVC_07 { get; set; }
    }
    
    [Serializable()]
    [Segment("DTP", typeof(X12_ID_374_DTP_ClaimServiceDate_2200D), typeof(X12_ID_1250_DTP_ClaimServiceDate_2200D))]
    public class DTP_ClaimServiceDate_2200D
    {
        
        [Required]
        [DataElement("374", typeof(X12_ID_374_DTP_ClaimServiceDate_2200D))]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DTP_ClaimServiceDate_2200D))]
        [Pos(2)]
        public string DateTimePeriodFormatQualifier_02 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ClaimServicePeriod_03 { get; set; }
    }
    
    [Serializable()]
    [All()]
    public class All_REF_2200D
    {
        
        [Pos(1)]
        public REF_PayerClaimIdentificationNumber_2200D REF_PayerClaimIdentificationNumber_2200D { get; set; }
        [Pos(2)]
        public REF_InstitutionalBillTypeIdentification_2200D REF_InstitutionalBillTypeIdentification_2200D { get; set; }
        [Pos(3)]
        public REF_MedicalRecordIdentification_2200D REF_MedicalRecordIdentification_2200D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1K,")]
    public class X12_ID_128_REF_PayerClaimIdentificationNumber_2200D
    {
    }
    
    [Serializable()]
    [EdiCodes(",BLT,")]
    public class X12_ID_128_REF_InstitutionalBillTypeIdentification_2200D
    {
    }
    
    [Serializable()]
    [EdiCodes(",EA,")]
    public class X12_ID_128_REF_MedicalRecordIdentification_2200D
    {
    }
    
    [Serializable()]
    [Segment("REF", typeof(X12_ID_128_REF_MedicalRecordIdentification_2200D))]
    public class REF_MedicalRecordIdentification_2200D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_MedicalRecordIdentification_2200D))]
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
    [Segment("REF", typeof(X12_ID_128_REF_InstitutionalBillTypeIdentification_2200D))]
    public class REF_InstitutionalBillTypeIdentification_2200D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_InstitutionalBillTypeIdentification_2200D))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string BillTypeIdentifier_02 { get; set; }
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
    [Segment("REF", typeof(X12_ID_128_REF_PayerClaimIdentificationNumber_2200D))]
    public class REF_PayerClaimIdentificationNumber_2200D
    {
        
        [Required]
        [DataElement("128", typeof(X12_ID_128_REF_PayerClaimIdentificationNumber_2200D))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayerClaimControlNumber_02 { get; set; }
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
    [Segment("STC")]
    public class STC_ClaimLevelStatusInformation_2200D
    {
        
        [Required]
        [Pos(1)]
        public C043_842942583 C043_842942583 { get; set; }
        [Required]
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(2)]
        public string StatusInformationEffectiveDate_02 { get; set; }
        [StringLength(1, 2)]
        [DataElement("", typeof(X12_ID))]
        [Pos(3)]
        public string STC_03 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(4)]
        public string TotalClaimChargeAmount_04 { get; set; }
        [Required]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string ClaimPaymentAmount_05 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(6)]
        public string AdjudicationOrPaymentDate_06 { get; set; }
        [DataElement("591", typeof(X12_ID_591_STC_ClaimLevelStatusInformation_2200D))]
        [Pos(7)]
        public string PaymentMethodCode_07 { get; set; }
        [StringLength(8, 8)]
        [DataElement("", typeof(X12_DT))]
        [Pos(8)]
        public string CheckIssueOrEFTEffectiveDate_08 { get; set; }
        [StringLength(1, 16)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string CheckOrEFTTraceNumber_09 { get; set; }
        [Pos(10)]
        public C043_843597928 C043_843597928 { get; set; }
        [Pos(11)]
        public C043_843860072 C043_843860072 { get; set; }
        [StringLength(1, 264)]
        [DataElement("", typeof(X12_AN))]
        [Pos(12)]
        public string STC_12 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",ACH,BOP,CHK,FWT,NON,")]
    public class X12_ID_591_STC_ClaimLevelStatusInformation_2200D
    {
    }
    
    [Serializable()]
    [Composite("C043_843860072")]
    public class C043_843860072
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_843860072))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_843860072
    {
    }
    
    [Serializable()]
    [Composite("C043_843597928")]
    public class C043_843597928
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_843597928))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_843597928
    {
    }
    
    [Serializable()]
    [Composite("C043_842942583")]
    public class C043_842942583
    {
        
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string HealthCareClaimStatusCode_02 { get; set; }
        [DataElement("98", typeof(X12_ID_98_C043_842942583))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(@",13,17,1E,1G,1H,1I,1O,1P,1Q,1R,1S,1T,1U,1V,1W,1X,1Y,1Z,28,2A,2B,2E,2I,2K,2P,2Q,2S,2Z,30,36,3A,3C,3D,3E,3F,3G,3H,3I,3J,3K,3L,3M,3N,3O,3P,3Q,3R,3S,3T,3U,3V,3W,3X,3Y,3Z,40,43,44,4A,4B,4C,4D,4E,4F,4G,4H,4I,4J,4L,4M,4N,4O,4P,4Q,4R,4S,4U,4V,4W,4X,4Y,4Z,5A,5B,5C,5D,5E,5F,5G,5H,5I,5J,5K,5L,5M,5N,5O,5P,5Q,5R,5S,5T,5U,5V,5W,5X,5Y,5Z,61,6A,6B,6C,6D,6E,6F,6G,6H,6I,6J,6K,6L,6M,6N,6O,6P,6Q,6R,6S,6U,6V,6W,6X,6Y,71,72,73,74,77,7C,80,82,84,85,87,95,CK,CZ,D2,DD,DJ,DK,DN,DO,DQ,E1,E2,E7,E9,FA,FD,FE,G0,G3,GB,GD,GI,GJ,GK,GM,GY,HF,HH,I3,IJ,IL,IN,LI,LR,MR,OB,OD,OX,P0,P2,P3,P4,P6,P7,PT,PV,PW,QA,QB,QC,QD,QE,QH,QK,QL,QN,QO,QS,QV,QY,RC,RW,S4,SJ,SU,T4,TQ,TT,TU,UH,X3,X4,X5,ZZ,")]
    public class X12_ID_98_C043_842942583
    {
    }
    
    [Serializable()]
    [Segment("TRN", typeof(X12_ID_481_TRN_ClaimSubmitterTraceNumber_2200D))]
    public class TRN_ClaimSubmitterTraceNumber_2200D
    {
        
        [Required]
        [DataElement("481", typeof(X12_ID_481_TRN_ClaimSubmitterTraceNumber_2200D))]
        [Pos(1)]
        public string TraceTypeCode_01 { get; set; }
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string TraceNumber_02 { get; set; }
        [StringLength(10, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string TRN_03 { get; set; }
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string TRN_04 { get; set; }
    }
    
    [Serializable()]
    [Group(typeof(NM1_SubscriberName_2100D))]
    public class Loop_2100D
    {
        
        [Required]
        [Pos(1)]
        public NM1_SubscriberName_2100D NM1_SubscriberName_2100D { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",IL,QC,")]
    public class X12_ID_98_NM1_SubscriberName_2100D
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_SubscriberName_2100D
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_SubscriberName_2100D), typeof(X12_ID_1065_NM1_SubscriberName_2100D))]
    public class NM1_SubscriberName_2100D
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_SubscriberName_2100D))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_SubscriberName_2100D))]
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
        public string SubscriberNamePrefix_06 { get; set; }
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string SubscriberNameSuffix_07 { get; set; }
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_SubscriberName_2100D))]
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
    [EdiCodes(",24,MI,ZZ,")]
    public class X12_ID_66_NM1_SubscriberName_2100D
    {
    }
    
    [Serializable()]
    [Segment("DMG", typeof(X12_ID_1250_DMG_SubscriberDemographicInformation_2000D))]
    public class DMG_SubscriberDemographicInformation_2000D
    {
        
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_DMG_SubscriberDemographicInformation_2000D))]
        [Pos(1)]
        public string DateTimePeriodFormatQualifier_01 { get; set; }
        [Required]
        [StringLength(1, 35)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string SubscriberBirthDate_02 { get; set; }
        [Required]
        [DataElement("1068", typeof(X12_ID_1068_DMG_SubscriberDemographicInformation_2000D))]
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
    public class X12_ID_1068_DMG_SubscriberDemographicInformation_2000D
    {
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_SubscriberLevel_2000D))]
    public class HL_SubscriberLevel_2000D
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
        [DataElement("735", typeof(X12_ID_735_HL_SubscriberLevel_2000D))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_SubscriberLevel_2000D))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",0,1,")]
    public class X12_ID_736_HL_SubscriberLevel_2000D
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_ProviderName_2100C))]
    public class Loop_2100C
    {
        
        [Required]
        [Pos(1)]
        public NM1_ProviderName_2100C NM1_ProviderName_2100C { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1P,")]
    public class X12_ID_98_NM1_ProviderName_2100C
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_ProviderName_2100C
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_ProviderName_2100C), typeof(X12_ID_1065_NM1_ProviderName_2100C))]
    public class NM1_ProviderName_2100C
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_ProviderName_2100C))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_ProviderName_2100C))]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        [Required]
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
        [Required]
        [DataElement("66", typeof(X12_ID_66_NM1_ProviderName_2100C))]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        [Required]
        [StringLength(2, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(9)]
        public string ProviderIdentifier_09 { get; set; }
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
    [EdiCodes(",FI,SV,XX,")]
    public class X12_ID_66_NM1_ProviderName_2100C
    {
    }
    
    [Serializable()]
    [Segment("HL", typeof(X12_ID_735_HL_ServiceProviderLevel_2000C))]
    public class HL_ServiceProviderLevel_2000C
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
        [DataElement("735", typeof(X12_ID_735_HL_ServiceProviderLevel_2000C))]
        [Pos(3)]
        public string HierarchicalLevelCode_03 { get; set; }
        [Required]
        [DataElement("736", typeof(X12_ID_736_HL_ServiceProviderLevel_2000C))]
        [Pos(4)]
        public string HierarchicalChildCode_04 { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",1,")]
    public class X12_ID_736_HL_ServiceProviderLevel_2000C
    {
    }
    
    [Serializable()]
    [Group(typeof(NM1_InformationReceiverName_2100B))]
    public class Loop_2100B
    {
        
        [Required]
        [Pos(1)]
        public NM1_InformationReceiverName_2100B NM1_InformationReceiverName_2100B { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",41,")]
    public class X12_ID_98_NM1_InformationReceiverName_2100B
    {
    }
    
    [Serializable()]
    [EdiCodes(",1,2,")]
    public class X12_ID_1065_NM1_InformationReceiverName_2100B
    {
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
        [Required]
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
        public string InformationReceiverNamePrefix_06 { get; set; }
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
    [EdiCodes(",46,FI,XX,")]
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
    [Group(typeof(NM1_PayerName_2100A))]
    public class Loop_2100A
    {
        
        [Required]
        [Pos(1)]
        public NM1_PayerName_2100A NM1_PayerName_2100A { get; set; }
        [Pos(2)]
        public PER_PayerContactInformation_2100A PER_PayerContactInformation_2100A { get; set; }
    }
    
    [Serializable()]
    [EdiCodes(",PR,")]
    public class X12_ID_98_NM1_PayerName_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",2,")]
    public class X12_ID_1065_NM1_PayerName_2100A
    {
    }
    
    [Serializable()]
    [EdiCodes(",IC,")]
    public class X12_ID_366_PER_PayerContactInformation_2100A
    {
    }
    
    [Serializable()]
    [Segment("PER", typeof(X12_ID_366_PER_PayerContactInformation_2100A))]
    public class PER_PayerContactInformation_2100A
    {
        
        [Required]
        [DataElement("366", typeof(X12_ID_366_PER_PayerContactInformation_2100A))]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        [StringLength(1, 60)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string PayerContactName_02 { get; set; }
        [Required]
        [DataElement("365", typeof(X12_ID_365_PER_PayerContactInformation_2100A))]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        [Required]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_PayerContactInformation_2100A))]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        [DataElement("365", typeof(X12_ID_365_PER_PayerContactInformation_2100A))]
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
    [EdiCodes(",ED,EM,TE,")]
    public class X12_ID_365_PER_PayerContactInformation_2100A
    {
    }
    
    [Serializable()]
    [Segment("NM1", typeof(X12_ID_98_NM1_PayerName_2100A), typeof(X12_ID_1065_NM1_PayerName_2100A))]
    public class NM1_PayerName_2100A
    {
        
        [Required]
        [DataElement("98", typeof(X12_ID_98_NM1_PayerName_2100A))]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        [Required]
        [DataElement("1065", typeof(X12_ID_1065_NM1_PayerName_2100A))]
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
        [DataElement("66", typeof(X12_ID_66_NM1_PayerName_2100A))]
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
    [EdiCodes(",21,AD,FI,NI,PI,PP,XV,")]
    public class X12_ID_66_NM1_PayerName_2100A
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
        [StringLength(4, 8)]
        [DataElement("", typeof(X12_TM))]
        [Pos(5)]
        public string BHT_05 { get; set; }
        [Required]
        [DataElement("640", typeof(X12_ID_640_BHT_BeginningOfHierarchicalTransaction))]
        [Pos(6)]
        public string TransactionTypeCode_06 { get; set; }
    }
    
    [Serializable()]
    public class X12_TM
    {
    }
    
    [Serializable()]
    [EdiCodes(",DG,")]
    public class X12_ID_640_BHT_BeginningOfHierarchicalTransaction
    {
    }
}
