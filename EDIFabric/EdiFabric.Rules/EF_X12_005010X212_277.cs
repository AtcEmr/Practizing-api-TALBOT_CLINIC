namespace EdiFabric.Rules.X12005010X212277 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_277 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningofHierarchicalTransaction S_BHT_BeginningofHierarchicalTransaction {get; set;}
    [XmlElement("G_TS277_2000A",Order=2)]
    public List<G_TS277_2000A> G_TS277_2000A {get; set;}
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
    public string D_ST03_Version_Release_orIndustryIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_143 {
        [XmlEnum("277")]
        Item277,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BHT_BeginningofHierarchicalTransaction {
    [XmlElement(Order=0)]
    public X12_ID_1005 D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_353 D_BHT02_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BHT03_OriginatorApplicationTransactionIdentifier {get; set;}
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
        [XmlEnum("0010")]
        Item0010,
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
    [XmlElement("G_TS277_2000B",Order=2)]
    public List<G_TS277_2000B> G_TS277_2000B {get; set;}
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
    public S_NM1_PayerName S_NM1_PayerName {get; set;}
    [XmlElement(Order=1)]
    public S_PER_PayerContactInformation S_PER_PayerContactInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PayerName {
    [XmlElement(Order=0)]
    public X12_ID_98 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PayerName {get; set;}
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
    public string D_NM109_PayerIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98 {
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
    public class S_PER_PayerContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_PayerContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_PayerContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_PayerContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_PayerContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_366 {
        IC,
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
    public string D_NM103_InformationReceiverLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_InformationReceiverFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_InformationReceiverMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_InformationReceiverNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_InformationReceiverIdentificationNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
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
    public S_TRN_InformationReceiverTraceIdentifier S_TRN_InformationReceiverTraceIdentifier {get; set;}
    [XmlElement("S_STC_InformationReceiverStatusInformation",Order=1)]
    public List<S_STC_InformationReceiverStatusInformation> S_STC_InformationReceiverStatusInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_InformationReceiverTraceIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ClaimTransactionBatchNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_481 {
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
    public C_C043_HealthCareClaimStatus_2 C_C043_HealthCareClaimStatus_2 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_3 C_C043_HealthCareClaimStatus_3 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_Free_formMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
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
    public string D_C04302_StatusCode {get; set;}
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
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2000C {
    [XmlElement(Order=0)]
    public S_HL_ServiceProviderLevel S_HL_ServiceProviderLevel {get; set;}
    [XmlElement("G_TS277_2100C",Order=1)]
    public List<G_TS277_2100C> G_TS277_2100C {get; set;}
    [XmlElement(Order=2)]
    public G_TS277_2200C G_TS277_2200C {get; set;}
    [XmlElement("G_TS277_2000D",Order=3)]
    public List<G_TS277_2000D> G_TS277_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_ServiceProviderLevel {
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
    public S_NM1_ProviderName S_NM1_ProviderName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ProviderLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_ProviderNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_5 {
        [XmlEnum("1P")]
        Item1P,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2200C {
    [XmlElement(Order=0)]
    public S_TRN_ProviderofServiceTraceIdentifier S_TRN_ProviderofServiceTraceIdentifier {get; set;}
    [XmlElement("S_STC_ProviderStatusInformation",Order=1)]
    public List<S_STC_ProviderStatusInformation> S_STC_ProviderStatusInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ProviderofServiceTraceIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_481_2 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ProviderofServiceInformationTraceIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_481_2 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_STC_ProviderStatusInformation {
    [XmlElement(Order=0)]
    public C_C043_HealthCareClaimStatus_4 C_C043_HealthCareClaimStatus_4 {get; set;}
    [XmlElement(Order=1)]
    public string D_STC02_StatusInformationEffectiveDate {get; set;}
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
    public C_C043_HealthCareClaimStatus_5 C_C043_HealthCareClaimStatus_5 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_6 C_C043_HealthCareClaimStatus_6 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_Free_formMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_4 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
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
    public string D_C04302_StatusCode {get; set;}
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
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2000D {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel S_HL_SubscriberLevel {get; set;}
    [XmlElement(Order=1)]
    public G_TS277_2100D G_TS277_2100D {get; set;}
    [XmlElement("G_TS277_2200D",Order=2)]
    public List<G_TS277_2200D> G_TS277_2200D {get; set;}
    [XmlElement("G_TS277_2000E",Order=3)]
    public List<G_TS277_2000E> G_TS277_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberLevel {
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
    public S_NM1_SubscriberName S_NM1_SubscriberName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName {
    [XmlElement(Order=0)]
    public X12_ID_98_6 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SubscriberLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SubscriberFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_SubscriberMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_SubscriberNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_SubscriberNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SubscriberIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_6 {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2200D {
    [XmlElement(Order=0)]
    public S_TRN_ClaimStatusTrackingNumber S_TRN_ClaimStatusTrackingNumber {get; set;}
    [XmlElement("S_STC_ClaimLevelStatusInformation",Order=1)]
    public List<S_STC_ClaimLevelStatusInformation> S_STC_ClaimLevelStatusInformation {get; set;}
    [XmlElement(Order=2)]
    public A_REF A_REF {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_ClaimServiceDate S_DTP_ClaimServiceDate {get; set;}
    [XmlElement("G_TS277_2220D",Order=4)]
    public List<G_TS277_2220D> G_TS277_2220D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ClaimStatusTrackingNumber {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ReferencedTransactionTraceNumber {get; set;}
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
    public string D_STC03_ActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_STC04_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_STC05_ClaimPaymentAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_STC06_AdjudicationFinalizedDate {get; set;}
    [XmlElement(Order=6)]
    public string D_STC07_PaymentMethodCode {get; set;}
    [XmlElement(Order=7)]
    public string D_STC08_RemittanceDate {get; set;}
    [XmlElement(Order=8)]
    public string D_STC09_RemittanceTraceNumber {get; set;}
    [XmlElement(Order=9)]
    public C_C043_HealthCareClaimStatus_8 C_C043_HealthCareClaimStatus_8 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_9 C_C043_HealthCareClaimStatus_9 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_Free_formMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_7 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
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
    public string D_C04302_StatusCode {get; set;}
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
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF {
    [XmlElementAttribute(Order=0)]
    public S_REF_PayerClaimControlNumber S_REF_PayerClaimControlNumber {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_InstitutionalBillTypeIdentification S_REF_InstitutionalBillTypeIdentification {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_PatientControlNumber S_REF_PatientControlNumber {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_PharmacyPrescriptionNumber S_REF_PharmacyPrescriptionNumber {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_VoucherIdentifier S_REF_VoucherIdentifier {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_ClaimIdentificationNumberForClearinghousesandOtherTransmissonIntermediaries S_REF_ClaimIdentificationNumberForClearinghousesandOtherTransmissonIntermediaries {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerClaimControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier C_C040_ReferenceIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128 {
        [XmlEnum("1K")]
        Item1K,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InstitutionalBillTypeIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_3 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillTypeIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2 C_C040_ReferenceIdentifier_2 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_3 {
        BLT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_2 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PatientControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PatientControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3 C_C040_ReferenceIdentifier_3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        EJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_3 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PharmacyPrescriptionNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PharmacyPrescriptionNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4 C_C040_ReferenceIdentifier_4 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
        XZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_4 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_VoucherIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_VoucherIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5 C_C040_ReferenceIdentifier_5 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        VV,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_5 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ClaimIdentificationNumberForClearinghousesandOtherTransmissonIntermediaries {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ClearinghouseTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_6 C_C040_ReferenceIdentifier_6 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_7 {
        D9,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_6 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimServiceDate {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ClaimServicePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374 {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250 {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2220D {
    [XmlElement(Order=0)]
    public S_SVC_ServiceLineInformation S_SVC_ServiceLineInformation {get; set;}
    [XmlElement("S_STC_ServiceLineStatusInformation",Order=1)]
    public List<S_STC_ServiceLineStatusInformation> S_STC_ServiceLineStatusInformation {get; set;}
    [XmlElement(Order=2)]
    public S_REF_ServiceLineItemIdentification S_REF_ServiceLineItemIdentification {get; set;}
    [XmlElement(Order=3)]
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
    public string D_SVC03_LineItemPaymentAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC04_RevenueCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC05_Quantity {get; set;}
    [XmlElement(Order=5)]
    public C_C003_CompositeMedicalProcedureIdentifier_2 C_C003_CompositeMedicalProcedureIdentifier_2 {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC07_UnitsofServiceCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_235 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_235 {
        AD,
        ER,
        HC,
        HP,
        IV,
        N4,
        NU,
        WK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_2 {
    [XmlElement(Order=0)]
    public string D_C00301_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C00302_Product_ServiceID {get; set;}
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
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_STC_ServiceLineStatusInformation {
    [XmlElement(Order=0)]
    public C_C043_HealthCareClaimStatus_10 C_C043_HealthCareClaimStatus_10 {get; set;}
    [XmlElement(Order=1)]
    public string D_STC02_StatusInformationEffectiveDate {get; set;}
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
    public string D_STC12_Free_formMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_10 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
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
    public string D_C04302_StatusCode {get; set;}
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
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceLineItemIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_7 C_C040_ReferenceIdentifier_7 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_8 {
        FJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_7 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceLineDate {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceLineDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2000E {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel S_HL_DependentLevel {get; set;}
    [XmlElement(Order=1)]
    public G_TS277_2100E G_TS277_2100E {get; set;}
    [XmlElement("G_TS277_2200E",Order=2)]
    public List<G_TS277_2200E> G_TS277_2200E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_DependentLevel {
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
    public class G_TS277_2100E {
    [XmlElement(Order=0)]
    public S_NM1_DependentName S_NM1_DependentName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName {
    [XmlElement(Order=0)]
    public X12_ID_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_PatientNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PatientNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PatientPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_8 {
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
    public class G_TS277_2200E {
    [XmlElement(Order=0)]
    public S_TRN_ClaimStatusTrackingNumber_2 S_TRN_ClaimStatusTrackingNumber_2 {get; set;}
    [XmlElement("S_STC_ClaimLevelStatusInformation_2",Order=1)]
    public List<S_STC_ClaimLevelStatusInformation_2> S_STC_ClaimLevelStatusInformation_2 {get; set;}
    [XmlElement(Order=2)]
    public A_REF_2 A_REF_2 {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_ClaimServiceDate_2 S_DTP_ClaimServiceDate_2 {get; set;}
    [XmlElement("G_TS277_2220E",Order=4)]
    public List<G_TS277_2220E> G_TS277_2220E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ClaimStatusTrackingNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ReferencedTransactionTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_STC_ClaimLevelStatusInformation_2 {
    [XmlElement(Order=0)]
    public C_C043_HealthCareClaimStatus_13 C_C043_HealthCareClaimStatus_13 {get; set;}
    [XmlElement(Order=1)]
    public string D_STC02_StatusInformationEffectiveDate {get; set;}
    [XmlElement(Order=2)]
    public string D_STC03_ActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_STC04_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_STC05_ClaimPaymentAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_STC06_AdjudicationFinalizedDate {get; set;}
    [XmlElement(Order=6)]
    public string D_STC07_PaymentMethodCode {get; set;}
    [XmlElement(Order=7)]
    public string D_STC08_RemittanceDate {get; set;}
    [XmlElement(Order=8)]
    public string D_STC09_RemittanceTraceNumber {get; set;}
    [XmlElement(Order=9)]
    public C_C043_HealthCareClaimStatus_14 C_C043_HealthCareClaimStatus_14 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_15 C_C043_HealthCareClaimStatus_15 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_Free_formMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_13 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_14 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_15 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_2 {
    [XmlElementAttribute(Order=0)]
    public S_REF_PayerClaimControlNumber_2 S_REF_PayerClaimControlNumber_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_InstitutionalBillTypeIdentification_2 S_REF_InstitutionalBillTypeIdentification_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_PatientControlNumber_2 S_REF_PatientControlNumber_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_PharmacyPrescriptionNumber_2 S_REF_PharmacyPrescriptionNumber_2 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_VoucherIdentifier_2 S_REF_VoucherIdentifier_2 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_ClaimIdentificationNumberForClearinghousesandOtherTransmissonIntermediaries_2 S_REF_ClaimIdentificationNumberForClearinghousesandOtherTransmissonIntermediaries_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerClaimControlNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_8 C_C040_ReferenceIdentifier_8 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_8 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InstitutionalBillTypeIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_3 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillTypeIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_9 C_C040_ReferenceIdentifier_9 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_9 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PatientControlNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PatientControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_10 C_C040_ReferenceIdentifier_10 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_10 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PharmacyPrescriptionNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PharmacyPrescriptionNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_11 C_C040_ReferenceIdentifier_11 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_11 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_VoucherIdentifier_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_VoucherIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_12 C_C040_ReferenceIdentifier_12 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_12 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ClaimIdentificationNumberForClearinghousesandOtherTransmissonIntermediaries_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ClearinghouseTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_13 C_C040_ReferenceIdentifier_13 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_13 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimServiceDate_2 {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ClaimServicePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS277_2220E {
    [XmlElement(Order=0)]
    public S_SVC_ServiceLineInformation_2 S_SVC_ServiceLineInformation_2 {get; set;}
    [XmlElement("S_STC_ServiceLineStatusInformation_2",Order=1)]
    public List<S_STC_ServiceLineStatusInformation_2> S_STC_ServiceLineStatusInformation_2 {get; set;}
    [XmlElement(Order=2)]
    public S_REF_ServiceLineItemIdentification_2 S_REF_ServiceLineItemIdentification_2 {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_ServiceLineDate_2 S_DTP_ServiceLineDate_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVC_ServiceLineInformation_2 {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier_3 C_C003_CompositeMedicalProcedureIdentifier_3 {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC02_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC03_LineItemPaymentAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC04_RevenueCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC05_Quantity {get; set;}
    [XmlElement(Order=5)]
    public C_C003_CompositeMedicalProcedureIdentifier_4 C_C003_CompositeMedicalProcedureIdentifier_4 {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC07_UnitsofServiceCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_3 {
    [XmlElement(Order=0)]
    public X12_ID_235 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_4 {
    [XmlElement(Order=0)]
    public string D_C00301_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C00302_Product_ServiceID {get; set;}
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
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_STC_ServiceLineStatusInformation_2 {
    [XmlElement(Order=0)]
    public C_C043_HealthCareClaimStatus_16 C_C043_HealthCareClaimStatus_16 {get; set;}
    [XmlElement(Order=1)]
    public string D_STC02_StatusInformationEffectiveDate {get; set;}
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
    public C_C043_HealthCareClaimStatus_17 C_C043_HealthCareClaimStatus_17 {get; set;}
    [XmlElement(Order=10)]
    public C_C043_HealthCareClaimStatus_18 C_C043_HealthCareClaimStatus_18 {get; set;}
    [XmlElement(Order=11)]
    public string D_STC12_Free_formMessageText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_16 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_17 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C043_HealthCareClaimStatus_18 {
    [XmlElement(Order=0)]
    public string D_C04301_HealthCareClaimStatusCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04302_StatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C04303_EntityIdentifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C04304_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceLineItemIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_14 C_C040_ReferenceIdentifier_14 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_14 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_ReferenceIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceLineDate_2 {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
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
