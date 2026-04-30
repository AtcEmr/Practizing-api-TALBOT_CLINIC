namespace EdiFabric.Rules.X12005010X214277 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_277 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction S_BHT_BeginningOfHierarchicalTransaction {get; set;}
    [XmlElement(Order=2)]
    public G_TS277_2000A G_TS277_2000A {get; set;}
    [XmlElement(Order=3)]
    public S_SE S_SE {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ST {
    [XmlElement(Order=0)]
    public X12_ID_143 D_ST01_TransactionSetIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_ST02_TransactionSetControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_ST03_ImplementationConventionReference {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_143 {
        [XmlEnum("277")]
        Item277,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BHT_BeginningOfHierarchicalTransaction {
    [XmlElement(Order=0)]
    public X12_ID_1005 D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_353 D_BHT02_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BHT03_ReferenceIdentification {get; set;}
    [XmlElement(Order=3)]
    public string D_BHT04_TransactionSetCreationDate {get; set;}
    [XmlElement(Order=4)]
    public string D_BHT05_TransactionSetCreationTime {get; set;}
    [XmlElement(Order=5)]
    public string D_BHT06_TransactionTypeCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1005 {
        [XmlEnum("0085")]
        Item0085,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_353 {
        [XmlEnum("08")]
        Item08,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2000A {
    [XmlElement(Order=0)]
    public S_HL_InformationSourceLevel S_HL_InformationSourceLevel {get; set;}
    [XmlElement(Order=1)]
    public G_TS277_2100A G_TS277_2100A {get; set;}
    [XmlElement(Order=2)]
    public G_TS277_2200A G_TS277_2200A {get; set;}
    [XmlElement(Order=3)]
    public G_TS277_2000B G_TS277_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_InformationSourceLevel {
    [XmlElement(Order=0)]
    public string D_HL01_HierarchicalIDNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_HL02_HierarchicalParentIDNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_HL03_HierarchicalLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HL04_HierarchicalChildCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2100A {
    [XmlElement(Order=0)]
    public S_NM1_InformationSourceName S_NM1_InformationSourceName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationSourceName {
    [XmlElement(Order=0)]
    public X12_ID_98 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_InformationSourceName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_NameFirst {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_NameMiddle {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_NameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_InformationSourceIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastOrOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98 {
        AY,
        PR,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065 {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2200A {
    [XmlElement(Order=0)]
    public S_TRN_TransmissionReceiptControlIdentifier S_TRN_TransmissionReceiptControlIdentifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_InformationSourceReceiptDate S_DTP_InformationSourceReceiptDate {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_InformationSourceProcessDate S_DTP_InformationSourceProcessDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_TransmissionReceiptControlIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_InformationSourceApplicationTraceIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_481 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_InformationSourceReceiptDate {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_InformationSourceReceiptDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374 {
        [XmlEnum("050")]
        Item050,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250 {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_InformationSourceProcessDate {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_InformationSourceProcessDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_2 {
        [XmlEnum("009")]
        Item009,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2000B {
    [XmlElement(Order=0)]
    public S_HL_InformationReceiverLevel S_HL_InformationReceiverLevel {get; set;}
    [XmlElement(Order=1)]
    public G_TS277_2100B G_TS277_2100B {get; set;}
    [XmlElement(Order=2)]
    public G_TS277_2200B G_TS277_2200B {get; set;}
    [XmlElement("G_TS277_2000C",Order=3)]
    public List<G_TS277_2000C> G_TS277_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_InformationReceiverLevel {
    [XmlElement(Order=0)]
    public string D_HL01_HierarchicalIDNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_HL02_HierarchicalParentIDNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_HL03_HierarchicalLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HL04_HierarchicalChildCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2100B {
    [XmlElement(Order=0)]
    public S_NM1_InformationReceiverName S_NM1_InformationReceiverName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationReceiverName {
    [XmlElement(Order=0)]
    public X12_ID_98_3 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_InformationReceiverLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_InformationReceiverFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_InformationReceiverMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_NameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_InformationReceiverPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastOrOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_3 {
        [XmlEnum("41")]
        Item41,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_2 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2200B {
    [XmlElement(Order=0)]
    public S_TRN_InformationReceiverApplicationTraceIdentifier S_TRN_InformationReceiverApplicationTraceIdentifier {get; set;}
    [XmlElement("S_STC_InformationReceiverStatusInformation",Order=1)]
    public List<S_STC_InformationReceiverStatusInformation> S_STC_InformationReceiverStatusInformation {get; set;}
    [XmlElement(Order=2)]
    public S_QTY_TotalAcceptedQuantity S_QTY_TotalAcceptedQuantity {get; set;}
    [XmlElement(Order=3)]
    public S_QTY_TotalRejectedQuantity S_QTY_TotalRejectedQuantity {get; set;}
    [XmlElement(Order=4)]
    public S_AMT_TotalAcceptedAmount S_AMT_TotalAcceptedAmount {get; set;}
    [XmlElement(Order=5)]
    public S_AMT_TotalRejectedAmount S_AMT_TotalRejectedAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_InformationReceiverApplicationTraceIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_481_2 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ClaimTransactionBatchNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_481_2 {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_STC_InformationReceiverStatusInformation {
    [XmlElement(Order=0)]
    public C_C043_HealthCareClaimStatus C_C043_HealthCareClaimStatus {get; set;}
    [XmlElement(Order=1)]
    public string D_STC02_StatusInformationEffectiveDate {get; set;}
    [XmlElement(Order=2)]
    public string D_STC03_ActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_STC04_TotalSubmittedChargesForUnitWork {get; set;}
    [XmlElement(Order=4)]
    public string D_STC05_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_STC06_Date {get; set;}
    [XmlElement(Order=6)]
    public string D_STC07_PaymentMethodCode {get; set;}
    [XmlElement(Order=7)]
    public string D_STC08_Date {get; set;}
    [XmlElement(Order=8)]
    public string D_STC09_CheckNumber {get; set;}
    [XmlElement(Order=9)]
    public C_C043_HealthCareClaimStatus_2 C_C043_HealthCareClaimStatus_2 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_3 C_C043_HealthCareClaimStatus_3 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_FreeformMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_2 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_3 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_TotalAcceptedQuantity {
    [XmlElement(Order=0)]
    public X12_ID_673 D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_TotalAcceptedQuantity {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitOfMeasure C_C001_CompositeUnitOfMeasure {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04_FreeformInformation {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_673 {
        [XmlEnum("90")]
        Item90,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C001_CompositeUnitOfMeasure {
    [XmlElement(Order=0)]
    public string D_C00101 {get; set;}
    [XmlElement(Order=1)]
    public string D_C00102 {get; set;}
    [XmlElement(Order=2)]
    public string D_C00103 {get; set;}
    [XmlElement(Order=3)]
    public string D_C00104 {get; set;}
    [XmlElement(Order=4)]
    public string D_C00105 {get; set;}
    [XmlElement(Order=5)]
    public string D_C00106 {get; set;}
    [XmlElement(Order=6)]
    public string D_C00107 {get; set;}
    [XmlElement(Order=7)]
    public string D_C00108 {get; set;}
    [XmlElement(Order=8)]
    public string D_C00109 {get; set;}
    [XmlElement(Order=9)]
    public string D_C00110 {get; set;}
    [XmlElement(Order=10)]
    public string D_C00111 {get; set;}
    [XmlElement(Order=11)]
    public string D_C00112 {get; set;}
    [XmlElement(Order=12)]
    public string D_C00113 {get; set;}
    [XmlElement(Order=13)]
    public string D_C00114 {get; set;}
    [XmlElement(Order=14)]
    public string D_C00115 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_TotalRejectedQuantity {
    [XmlElement(Order=0)]
    public X12_ID_673_2 D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_TotalRejectedQuantity {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitOfMeasure_2 C_C001_CompositeUnitOfMeasure_2 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04_FreeformInformation {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_673_2 {
        AA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C001_CompositeUnitOfMeasure_2 {
    [XmlElement(Order=0)]
    public string D_C00101 {get; set;}
    [XmlElement(Order=1)]
    public string D_C00102 {get; set;}
    [XmlElement(Order=2)]
    public string D_C00103 {get; set;}
    [XmlElement(Order=3)]
    public string D_C00104 {get; set;}
    [XmlElement(Order=4)]
    public string D_C00105 {get; set;}
    [XmlElement(Order=5)]
    public string D_C00106 {get; set;}
    [XmlElement(Order=6)]
    public string D_C00107 {get; set;}
    [XmlElement(Order=7)]
    public string D_C00108 {get; set;}
    [XmlElement(Order=8)]
    public string D_C00109 {get; set;}
    [XmlElement(Order=9)]
    public string D_C00110 {get; set;}
    [XmlElement(Order=10)]
    public string D_C00111 {get; set;}
    [XmlElement(Order=11)]
    public string D_C00112 {get; set;}
    [XmlElement(Order=12)]
    public string D_C00113 {get; set;}
    [XmlElement(Order=13)]
    public string D_C00114 {get; set;}
    [XmlElement(Order=14)]
    public string D_C00115 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_TotalAcceptedAmount {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_TotalAcceptedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_CreditDebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522 {
        YU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_TotalRejectedAmount {
    [XmlElement(Order=0)]
    public X12_ID_522_2 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_TotalRejectedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_CreditDebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522_2 {
        YY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2000C {
    [XmlElement(Order=0)]
    public S_HL_BillingProviderOfServiceLevel S_HL_BillingProviderOfServiceLevel {get; set;}
    [XmlElement(Order=1)]
    public G_TS277_2100C G_TS277_2100C {get; set;}
    [XmlElement(Order=2)]
    public G_TS277_2200C G_TS277_2200C {get; set;}
    [XmlElement("G_TS277_2000D",Order=3)]
    public List<G_TS277_2000D> G_TS277_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_BillingProviderOfServiceLevel {
    [XmlElement(Order=0)]
    public string D_HL01_HierarchicalIDNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_HL02_HierarchicalParentIDNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_HL03_HierarchicalLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HL04_HierarchicalChildCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2100C {
    [XmlElement(Order=0)]
    public S_NM1_BillingProviderName S_NM1_BillingProviderName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_BillingProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ProviderLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_BillingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastOrOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_5 {
        [XmlEnum("85")]
        Item85,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2200C {
    [XmlElement(Order=0)]
    public S_TRN_ProviderOfServiceInformationTraceIdentifier S_TRN_ProviderOfServiceInformationTraceIdentifier {get; set;}
    [XmlElement("S_STC_BillingProviderStatusInformation",Order=1)]
    public List<S_STC_BillingProviderStatusInformation> S_STC_BillingProviderStatusInformation {get; set;}
    [XmlElement("S_REF_ProviderSecondaryIdentifier",Order=2)]
    public List<S_REF_ProviderSecondaryIdentifier> S_REF_ProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=3)]
    public S_QTY_TotalAcceptedQuantity_2 S_QTY_TotalAcceptedQuantity_2 {get; set;}
    [XmlElement(Order=4)]
    public S_QTY_TotalRejectedQuantity_2 S_QTY_TotalRejectedQuantity_2 {get; set;}
    [XmlElement(Order=5)]
    public S_AMT_TotalAcceptedAmount_2 S_AMT_TotalAcceptedAmount_2 {get; set;}
    [XmlElement(Order=6)]
    public S_AMT_TotalRejectedAmount_2 S_AMT_TotalRejectedAmount_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ProviderOfServiceInformationTraceIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ProviderOfServiceInformationTraceIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_STC_BillingProviderStatusInformation {
    [XmlElement(Order=0)]
    public C_C043_HealthCareClaimStatus_4 C_C043_HealthCareClaimStatus_4 {get; set;}
    [XmlElement(Order=1)]
    public string D_STC02_Date {get; set;}
    [XmlElement(Order=2)]
    public string D_STC03_ActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_STC04_TotalSubmittedChargesForUnitWork {get; set;}
    [XmlElement(Order=4)]
    public string D_STC05_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_STC06_Date {get; set;}
    [XmlElement(Order=6)]
    public string D_STC07_PaymentMethodCode {get; set;}
    [XmlElement(Order=7)]
    public string D_STC08_Date {get; set;}
    [XmlElement(Order=8)]
    public string D_STC09_CheckNumber {get; set;}
    [XmlElement(Order=9)]
    public C_C043_HealthCareClaimStatus_5 C_C043_HealthCareClaimStatus_5 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_6 C_C043_HealthCareClaimStatus_6 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_FreeformMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_4 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_5 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_6 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ProviderSecondaryIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier C_C040_ReferenceIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
        G2,
        LU,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier {
    [XmlElement(Order=0)]
    public string D_C04001 {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002 {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003 {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004 {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005 {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_TotalAcceptedQuantity_2 {
    [XmlElement(Order=0)]
    public X12_ID_673_3 D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_TotalAcceptedQuantity {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitOfMeasure_3 C_C001_CompositeUnitOfMeasure_3 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04_FreeformInformation {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_673_3 {
        QA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C001_CompositeUnitOfMeasure_3 {
    [XmlElement(Order=0)]
    public string D_C00101 {get; set;}
    [XmlElement(Order=1)]
    public string D_C00102 {get; set;}
    [XmlElement(Order=2)]
    public string D_C00103 {get; set;}
    [XmlElement(Order=3)]
    public string D_C00104 {get; set;}
    [XmlElement(Order=4)]
    public string D_C00105 {get; set;}
    [XmlElement(Order=5)]
    public string D_C00106 {get; set;}
    [XmlElement(Order=6)]
    public string D_C00107 {get; set;}
    [XmlElement(Order=7)]
    public string D_C00108 {get; set;}
    [XmlElement(Order=8)]
    public string D_C00109 {get; set;}
    [XmlElement(Order=9)]
    public string D_C00110 {get; set;}
    [XmlElement(Order=10)]
    public string D_C00111 {get; set;}
    [XmlElement(Order=11)]
    public string D_C00112 {get; set;}
    [XmlElement(Order=12)]
    public string D_C00113 {get; set;}
    [XmlElement(Order=13)]
    public string D_C00114 {get; set;}
    [XmlElement(Order=14)]
    public string D_C00115 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_TotalRejectedQuantity_2 {
    [XmlElement(Order=0)]
    public X12_ID_673_4 D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_TotalRejectedQuantity {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitOfMeasure_4 C_C001_CompositeUnitOfMeasure_4 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04_FreeformInformation {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_673_4 {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C001_CompositeUnitOfMeasure_4 {
    [XmlElement(Order=0)]
    public string D_C00101 {get; set;}
    [XmlElement(Order=1)]
    public string D_C00102 {get; set;}
    [XmlElement(Order=2)]
    public string D_C00103 {get; set;}
    [XmlElement(Order=3)]
    public string D_C00104 {get; set;}
    [XmlElement(Order=4)]
    public string D_C00105 {get; set;}
    [XmlElement(Order=5)]
    public string D_C00106 {get; set;}
    [XmlElement(Order=6)]
    public string D_C00107 {get; set;}
    [XmlElement(Order=7)]
    public string D_C00108 {get; set;}
    [XmlElement(Order=8)]
    public string D_C00109 {get; set;}
    [XmlElement(Order=9)]
    public string D_C00110 {get; set;}
    [XmlElement(Order=10)]
    public string D_C00111 {get; set;}
    [XmlElement(Order=11)]
    public string D_C00112 {get; set;}
    [XmlElement(Order=12)]
    public string D_C00113 {get; set;}
    [XmlElement(Order=13)]
    public string D_C00114 {get; set;}
    [XmlElement(Order=14)]
    public string D_C00115 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_TotalAcceptedAmount_2 {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_TotalAcceptedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_CreditDebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_TotalRejectedAmount_2 {
    [XmlElement(Order=0)]
    public X12_ID_522_2 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_TotalRejectedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_CreditDebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2000D {
    [XmlElement(Order=0)]
    public S_HL_PatientLevel S_HL_PatientLevel {get; set;}
    [XmlElement(Order=1)]
    public G_TS277_2100D G_TS277_2100D {get; set;}
    [XmlElement("G_TS277_2200D",Order=2)]
    public List<G_TS277_2200D> G_TS277_2200D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_PatientLevel {
    [XmlElement(Order=0)]
    public string D_HL01_HierarchicalIDNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_HL02_HierarchicalParentIDNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_HL03_HierarchicalLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HL04_HierarchicalChildCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2100D {
    [XmlElement(Order=0)]
    public S_NM1_PatientName S_NM1_PatientName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientName {
    [XmlElement(Order=0)]
    public X12_ID_98_7 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientMiddleNameOrInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PatientNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PatientIdentificationNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastOrOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_7 {
        QC,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_3 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2200D {
    [XmlElement(Order=0)]
    public S_TRN_ClaimStatusTrackingNumber S_TRN_ClaimStatusTrackingNumber {get; set;}
    [XmlElement("S_STC_ClaimLevelStatusInformation",Order=1)]
    public List<S_STC_ClaimLevelStatusInformation> S_STC_ClaimLevelStatusInformation {get; set;}
    [XmlElement(Order=2)]
    public S_REF_PayerClaimControlNumber S_REF_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=3)]
    public S_REF_ClaimIdentifierForTransmissionIntermediaries S_REF_ClaimIdentifierForTransmissionIntermediaries {get; set;}
    [XmlElement(Order=4)]
    public S_REF_InstitutionalBillTypeIdentification S_REF_InstitutionalBillTypeIdentification {get; set;}
    [XmlElement(Order=5)]
    public S_DTP_ClaimLevelServiceDate S_DTP_ClaimLevelServiceDate {get; set;}
    [XmlElement("G_TS277_2220D",Order=6)]
    public List<G_TS277_2220D> G_TS277_2220D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ClaimStatusTrackingNumber {
    [XmlElement(Order=0)]
    public X12_ID_481_2 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_PatientControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_STC_ClaimLevelStatusInformation {
    [XmlElement(Order=0)]
    public C_C043_HealthCareClaimStatus_7 C_C043_HealthCareClaimStatus_7 {get; set;}
    [XmlElement(Order=1)]
    public string D_STC02_StatusInformationEffectiveDate {get; set;}
    [XmlElement(Order=2)]
    public string D_STC03_StatusInformationActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_STC04_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_STC05_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_STC06_Date {get; set;}
    [XmlElement(Order=6)]
    public string D_STC07_PaymentMethodCode {get; set;}
    [XmlElement(Order=7)]
    public string D_STC08_Date {get; set;}
    [XmlElement(Order=8)]
    public string D_STC09_CheckNumber {get; set;}
    [XmlElement(Order=9)]
    public C_C043_HealthCareClaimStatus_8 C_C043_HealthCareClaimStatus_8 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_9 C_C043_HealthCareClaimStatus_9 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_FreeFormMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_7 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_8 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_9 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerClaimControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_3 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2 C_C040_ReferenceIdentifier_2 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_3 {
        [XmlEnum("1K")]
        Item1K,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_2 {
    [XmlElement(Order=0)]
    public string D_C04001 {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002 {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003 {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004 {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005 {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ClaimIdentifierForTransmissionIntermediaries {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ClearinghouseTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3 C_C040_ReferenceIdentifier_3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        D9,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_3 {
    [XmlElement(Order=0)]
    public string D_C04001 {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002 {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003 {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004 {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005 {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InstitutionalBillTypeIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillTypeIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4 C_C040_ReferenceIdentifier_4 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
        BLT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_4 {
    [XmlElement(Order=0)]
    public string D_C04001 {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002 {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003 {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004 {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005 {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimLevelServiceDate {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_2 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ClaimServicePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_3 {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250_2 {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2220D {
    [XmlElement(Order=0)]
    public S_SVC_ServiceLineInformation S_SVC_ServiceLineInformation {get; set;}
    [XmlElement("S_STC_ServiceLineLevelStatusInformation",Order=1)]
    public List<S_STC_ServiceLineLevelStatusInformation> S_STC_ServiceLineLevelStatusInformation {get; set;}
    [XmlElement(Order=2)]
    public S_REF_ServiceLineItemIdentification S_REF_ServiceLineItemIdentification {get; set;}
    [XmlElement(Order=3)]
    public S_REF_PharmacyPrescriptionNumber S_REF_PharmacyPrescriptionNumber {get; set;}
    [XmlElement(Order=4)]
    public S_DTP_ServiceLineDate S_DTP_ServiceLineDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVC_ServiceLineInformation {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier C_C003_CompositeMedicalProcedureIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC02_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC03_MonetaryAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC04_RevenueCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC05_Quantity {get; set;}
    [XmlElement(Order=5)]
    public C_C003_CompositeMedicalProcedureIdentifier_2 C_C003_CompositeMedicalProcedureIdentifier_2 {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC07_OriginalUnitsOfServiceCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_235 D_C00301_ProcedureCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00302_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00303_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C00304_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_C00305_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C00306_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_C00307_Description {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308_ProductServiceID {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_235 {
        AD,
        ER,
        HC,
        HP,
        IV,
        NU,
        WK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_2 {
    [XmlElement(Order=0)]
    public string D_C00301 {get; set;}
    [XmlElement(Order=1)]
    public string D_C00302 {get; set;}
    [XmlElement(Order=2)]
    public string D_C00303 {get; set;}
    [XmlElement(Order=3)]
    public string D_C00304 {get; set;}
    [XmlElement(Order=4)]
    public string D_C00305 {get; set;}
    [XmlElement(Order=5)]
    public string D_C00306 {get; set;}
    [XmlElement(Order=6)]
    public string D_C00307 {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_STC_ServiceLineLevelStatusInformation {
    [XmlElement(Order=0)]
    public C_C043_HealthCareClaimStatus_10 C_C043_HealthCareClaimStatus_10 {get; set;}
    [XmlElement(Order=1)]
    public string D_STC02_Date {get; set;}
    [XmlElement(Order=2)]
    public string D_STC03_ActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_STC04_MonetaryAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_STC05_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_STC06_Date {get; set;}
    [XmlElement(Order=6)]
    public string D_STC07_PaymentMethodCode {get; set;}
    [XmlElement(Order=7)]
    public string D_STC08_Date {get; set;}
    [XmlElement(Order=8)]
    public string D_STC09_CheckNumber {get; set;}
    [XmlElement(Order=9)]
    public C_C043_HealthCareClaimStatus_11 C_C043_HealthCareClaimStatus_11 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_12 C_C043_HealthCareClaimStatus_12 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_FreeFormMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_10 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_11 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_12 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_HealthCareClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceLineItemIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5 C_C040_ReferenceIdentifier_5 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        FJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_5 {
    [XmlElement(Order=0)]
    public string D_C04001 {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002 {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003 {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004 {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005 {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PharmacyPrescriptionNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PharmacyPrescriptionNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_6 C_C040_ReferenceIdentifier_6 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_7 {
        XZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_6 {
    [XmlElement(Order=0)]
    public string D_C04001 {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002 {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003 {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004 {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005 {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceLineDate {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_2 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceLineDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SE {
    [XmlElement(Order=0)]
    public string D_SE01_TransactionSegmentCount {get; set;}
    [XmlElement(Order=1)]
    public string D_SE02_TransactionSetControlNumber {get; set;}
    }
}
