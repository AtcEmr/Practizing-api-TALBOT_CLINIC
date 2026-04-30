namespace EdiFabric.Rules.X12005010X223A2837 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_837 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningofHierarchicalTransaction S_BHT_BeginningofHierarchicalTransaction {get; set;}
    [XmlElement(Order=2)]
    public A_NM1 A_NM1 {get; set;}
    [XmlElement("G_TS837_2000A",Order=3)]
    public List<G_TS837_2000A> G_TS837_2000A {get; set;}
    [XmlElement(Order=4)]
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
        [XmlEnum("837")]
        Item837,
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
    public string D_BHT06_ClaimIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1005 {
        [XmlEnum("0019")]
        Item0019,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_353 {
        [XmlEnum("00")]
        Item00,
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_1000A G_TS837_1000A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_1000B G_TS837_1000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_1000A {
    [XmlElement(Order=0)]
    public S_NM1_SubmitterName S_NM1_SubmitterName {get; set;}
    [XmlElement("S_PER_SubmitterEDIContactInformation",Order=1)]
    public List<S_PER_SubmitterEDIContactInformation> S_PER_SubmitterEDIContactInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubmitterName {
    [XmlElement(Order=0)]
    public X12_ID_98 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SubmitterLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SubmitterFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_SubmitterMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_NameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SubmitterIdentifier {get; set;}
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
        [XmlEnum("41")]
        Item41,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_SubmitterEDIContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_SubmitterContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_CommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_CommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_CommunicationNumber {get; set;}
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
    public class G_TS837_1000B {
    [XmlElement(Order=0)]
    public S_NM1_ReceiverName S_NM1_ReceiverName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReceiverName {
    [XmlElement(Order=0)]
    public X12_ID_98_3 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ReceiverName {get; set;}
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
    public string D_NM109_ReceiverPrimaryIdentifier {get; set;}
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
        [XmlEnum("40")]
        Item40,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_2 {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2000A {
    [XmlElement(Order=0)]
    public S_HL_BillingProviderHierarchicalLevel S_HL_BillingProviderHierarchicalLevel {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_BillingProviderSpecialtyInformation S_PRV_BillingProviderSpecialtyInformation {get; set;}
    [XmlElement(Order=2)]
    public S_CUR_ForeignCurrencyInformation S_CUR_ForeignCurrencyInformation {get; set;}
    [XmlElement(Order=3)]
    public A_NM1_2 A_NM1_2 {get; set;}
    [XmlElement("G_TS837_2000B",Order=4)]
    public List<G_TS837_2000B> G_TS837_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_BillingProviderHierarchicalLevel {
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
    public class S_PRV_BillingProviderSpecialtyInformation {
    [XmlElement(Order=0)]
    public X12_ID_1221 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation C_C035_ProviderSpecialtyInformation {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1221 {
        BI,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128 {
        PXC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CUR_ForeignCurrencyInformation {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_CUR01_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CUR02_CurrencyCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CUR03_ExchangeRate {get; set;}
    [XmlElement(Order=3)]
    public string D_CUR04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CUR05_CurrencyCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CUR06_CurrencyMarket_ExchangeCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CUR07_Date_TimeQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_CUR08_Date {get; set;}
    [XmlElement(Order=8)]
    public string D_CUR09_Time {get; set;}
    [XmlElement(Order=9)]
    public string D_CUR10_Date_TimeQualifier {get; set;}
    [XmlElement(Order=10)]
    public string D_CUR11_Date {get; set;}
    [XmlElement(Order=11)]
    public string D_CUR12_Time {get; set;}
    [XmlElement(Order=12)]
    public string D_CUR13_Date_TimeQualifier {get; set;}
    [XmlElement(Order=13)]
    public string D_CUR14_Date {get; set;}
    [XmlElement(Order=14)]
    public string D_CUR15_Time {get; set;}
    [XmlElement(Order=15)]
    public string D_CUR16_Date_TimeQualifier {get; set;}
    [XmlElement(Order=16)]
    public string D_CUR17_Date {get; set;}
    [XmlElement(Order=17)]
    public string D_CUR18_Time {get; set;}
    [XmlElement(Order=18)]
    public string D_CUR19_Date_TimeQualifier {get; set;}
    [XmlElement(Order=19)]
    public string D_CUR20_Date {get; set;}
    [XmlElement(Order=20)]
    public string D_CUR21_Time {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_4 {
        [XmlEnum("85")]
        Item85,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_2 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2010AA G_TS837_2010AA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2010AB G_TS837_2010AB {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2010AC G_TS837_2010AC {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2010AA {
    [XmlElement(Order=0)]
    public S_NM1_BillingProviderName S_NM1_BillingProviderName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_BillingProviderAddress S_N3_BillingProviderAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_BillingProviderCity_State_ZIPCode S_N4_BillingProviderCity_State_ZIPCode {get; set;}
    [XmlElement(Order=3)]
    public S_REF_BillingProviderTaxIdentification S_REF_BillingProviderTaxIdentification {get; set;}
    [XmlElement("S_PER_BillingProviderContactInformation",Order=4)]
    public List<S_PER_BillingProviderContactInformation> S_PER_BillingProviderContactInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_BillingProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_BillingProviderOrganizationalName {get; set;}
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
    public string D_NM109_BillingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_BillingProviderAddress {
    [XmlElement(Order=0)]
    public string D_N301_BillingProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_BillingProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_BillingProviderCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_BillingProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_BillingProviderStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_BillingProviderPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_BillingProviderTaxIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_2 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderTaxIdentificationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier C_C040_ReferenceIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_2 {
        EI,
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
    public class S_PER_BillingProviderContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_BillingProviderContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_CommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_CommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_CommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2010AB {
    [XmlElement(Order=0)]
    public S_NM1_Pay_toAddressName S_NM1_Pay_toAddressName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_Pay_ToAddress_ADDRESS S_N3_Pay_ToAddress_ADDRESS {get; set;}
    [XmlElement(Order=2)]
    public S_N4_Pay_toAddressCity_State_ZIPCode S_N4_Pay_toAddressCity_State_ZIPCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_Pay_toAddressName {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_Pay_toAddressName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
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
        [XmlEnum("87")]
        Item87,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_Pay_ToAddress_ADDRESS {
    [XmlElement(Order=0)]
    public string D_N301_Pay_toAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_Pay_toAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_Pay_toAddressCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_Pay_toAddressCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_Pay_toAddressStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_Pay_toAddressPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2010AC {
    [XmlElement(Order=0)]
    public S_NM1_Pay_ToPlanName S_NM1_Pay_ToPlanName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_Pay_ToPlanAddress S_N3_Pay_ToPlanAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_Pay_ToPlanCity_State_ZipCode S_N4_Pay_ToPlanCity_State_ZipCode {get; set;}
    [XmlElement(Order=3)]
    public A_REF A_REF {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_Pay_ToPlanName {
    [XmlElement(Order=0)]
    public X12_ID_98_6 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_Pay_toPlanOrganizationalName {get; set;}
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
    public string D_NM109_Pay_toPlanPrimaryIdentifier {get; set;}
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
        PE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_Pay_ToPlanAddress {
    [XmlElement(Order=0)]
    public string D_N301_Pay_toPlanAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_Pay_toPlanAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_Pay_ToPlanCity_State_ZipCode {
    [XmlElement(Order=0)]
    public string D_N401_Pay_toPlanCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_Pay_ToPlanStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_Pay_toPlanPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF {
    [XmlElementAttribute(Order=0)]
    public S_REF_Pay_ToPlanSecondaryIdentification S_REF_Pay_ToPlanSecondaryIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_Pay_ToTaxIdentificationNumber S_REF_Pay_ToTaxIdentificationNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_Pay_ToPlanSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_Pay_toPlanSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2 C_C040_ReferenceIdentifier_2 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        [XmlEnum("2U")]
        Item2U,
        FY,
        NF,
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
    public class S_REF_Pay_ToTaxIdentificationNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_2 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_Pay_ToPlanTaxIdentificationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3 C_C040_ReferenceIdentifier_3 {get; set;}
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
    public class G_TS837_2000B {
    [XmlElement(Order=0)]
    public S_HL_SubscriberHierarchicalLevel S_HL_SubscriberHierarchicalLevel {get; set;}
    [XmlElement(Order=1)]
    public S_SBR_SubscriberInformation S_SBR_SubscriberInformation {get; set;}
    [XmlElement(Order=2)]
    public A_NM1_3 A_NM1_3 {get; set;}
    [XmlElement("G_TS837_2300",Order=3)]
    public List<G_TS837_2300> G_TS837_2300 {get; set;}
    [XmlElement("G_TS837_2000C",Order=4)]
    public List<G_TS837_2000C> G_TS837_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberHierarchicalLevel {
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
    public class S_SBR_SubscriberInformation {
    [XmlElement(Order=0)]
    public X12_ID_1138 D_SBR01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public string D_SBR02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SBR03_SubscriberGrouporPolicyNumber {get; set;}
    [XmlElement(Order=3)]
    public string D_SBR04_SubscriberGroupName {get; set;}
    [XmlElement(Order=4)]
    public string D_SBR05_InsuranceTypeCode {get; set;}
    [XmlElement(Order=5)]
    public string D_SBR06_CoordinationofBenefitsCode {get; set;}
    [XmlElement(Order=6)]
    public string D_SBR07_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=7)]
    public string D_SBR08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SBR09_ClaimFilingIndicatorCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1138 {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        P,
        S,
        T,
        U,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_3 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2010BA G_TS837_2010BA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2010BB G_TS837_2010BB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2010BA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName S_NM1_SubscriberName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_SubscriberAddress S_N3_SubscriberAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_SubscriberCity_State_ZIPCode S_N4_SubscriberCity_State_ZIPCode {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_SubscriberDemographicInformation S_DMG_SubscriberDemographicInformation {get; set;}
    [XmlElement(Order=4)]
    public A_REF_2 A_REF_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName {
    [XmlElement(Order=0)]
    public X12_ID_98_7 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SubscriberLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SubscriberFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_SubscriberMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_SubscriberNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SubscriberPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_7 {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_SubscriberAddress {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_SubscriberCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_SubscriberStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_SubscriberPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_SubscriberDemographicInformation {
    [XmlElement(Order=0)]
    public X12_ID_1250 D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_SubscriberBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_SubscriberGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04_MaritalStatusCode {get; set;}
    [XmlElement("C_C056_CompositeRaceorEthnicityInformation",Order=4)]
    public List<C_C056_CompositeRaceorEthnicityInformation> C_C056_CompositeRaceorEthnicityInformation {get; set;}
    [XmlElement(Order=5)]
    public string D_DMG06_CitizenshipStatusCode {get; set;}
    [XmlElement(Order=6)]
    public string D_DMG07_CountryCode {get; set;}
    [XmlElement(Order=7)]
    public string D_DMG08_BasisofVerificationCode {get; set;}
    [XmlElement(Order=8)]
    public string D_DMG09_Quantity {get; set;}
    [XmlElement(Order=9)]
    public string D_DMG10_CodeListQualifierCode {get; set;}
    [XmlElement(Order=10)]
    public string D_DMG11_IndustryCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250 {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C056_CompositeRaceorEthnicityInformation {
    [XmlElement(Order=0)]
    public string D_C05601_RaceorEthnicityCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05602_CodeListQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05603_IndustryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_2 {
    [XmlElementAttribute(Order=0)]
    public S_REF_SubscriberSecondaryIdentification S_REF_SubscriberSecondaryIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PropertyandCasualtyClaimNumber S_REF_PropertyandCasualtyClaimNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4 C_C040_ReferenceIdentifier_4 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
        SY,
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
    public class S_REF_PropertyandCasualtyClaimNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyCasualtyClaimNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5 C_C040_ReferenceIdentifier_5 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        Y4,
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
    public class G_TS837_2010BB {
    [XmlElement(Order=0)]
    public S_NM1_PayerName S_NM1_PayerName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayerAddress S_N3_PayerAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayerCity_State_ZIPCode S_N4_PayerCity_State_ZIPCode {get; set;}
    [XmlElement(Order=3)]
    public A_REF_3 A_REF_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PayerName {
    [XmlElement(Order=0)]
    public X12_ID_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
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
    public enum X12_ID_98_8 {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PayerAddress {
    [XmlElement(Order=0)]
    public string D_N301_PayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PayerCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_PayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PayerPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_3 {
    [XmlElement(Order=0)]
    public U_REF_PayerSecondaryIdentification U_REF_PayerSecondaryIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_BillingProviderSecondaryIdentification S_REF_BillingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_6 C_C040_ReferenceIdentifier_6 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_7 {
        [XmlEnum("2U")]
        Item2U,
        EI,
        FY,
        NF,
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
    public class S_REF_BillingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_7 C_C040_ReferenceIdentifier_7 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_8 {
        G2,
        LU,
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
    public class G_TS837_2300 {
    [XmlElement(Order=0)]
    public S_CLM_Claiminformation S_CLM_Claiminformation {get; set;}
    [XmlElement(Order=1)]
    public A_DTP A_DTP {get; set;}
    [XmlElement(Order=2)]
    public S_CL1_InstitutionalClaimCode S_CL1_InstitutionalClaimCode {get; set;}
    [XmlElement("S_PWK_ClaimSupplementalInformation",Order=3)]
    public List<S_PWK_ClaimSupplementalInformation> S_PWK_ClaimSupplementalInformation {get; set;}
    [XmlElement(Order=4)]
    public S_CN1_ContractInformation S_CN1_ContractInformation {get; set;}
    [XmlElement(Order=5)]
    public S_AMT_PatientEstimatedAmountDue S_AMT_PatientEstimatedAmountDue {get; set;}
    [XmlElement(Order=6)]
    public A_REF_4 A_REF_4 {get; set;}
    [XmlElement("S_K3_FileInformation",Order=7)]
    public List<S_K3_FileInformation> S_K3_FileInformation {get; set;}
    [XmlElement(Order=8)]
    public A_NTE A_NTE {get; set;}
    [XmlElement(Order=9)]
    public S_CRC_EPSDTReferral S_CRC_EPSDTReferral {get; set;}
    [XmlElement(Order=10)]
    public A_HI A_HI {get; set;}
    [XmlElement(Order=11)]
    public S_HCP_ClaimPricing_RepricingInformation S_HCP_ClaimPricing_RepricingInformation {get; set;}
    [XmlElement(Order=12)]
    public A_NM1_4 A_NM1_4 {get; set;}
    [XmlElement("G_TS837_2320",Order=13)]
    public List<G_TS837_2320> G_TS837_2320 {get; set;}
    [XmlElement("G_TS837_2400",Order=14)]
    public List<G_TS837_2400> G_TS837_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CLM_Claiminformation {
    [XmlElement(Order=0)]
    public string D_CLM01_PatientControlNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_CLM02_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_CLM03_ClaimFilingIndicatorCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CLM04_Non_InstitutionalClaimTypeCode {get; set;}
    [XmlElement(Order=4)]
    public C_C023_HealthCareServiceLocationInformation C_C023_HealthCareServiceLocationInformation {get; set;}
    [XmlElement(Order=5)]
    public string D_CLM06_ProviderorSupplierSignatureIndicator {get; set;}
    [XmlElement(Order=6)]
    public string D_CLM07_AssignmentorPlanParticipationCode {get; set;}
    [XmlElement(Order=7)]
    public string D_CLM08_BenefitsAssignmentCertificationIndicator {get; set;}
    [XmlElement(Order=8)]
    public string D_CLM09_ReleaseofInformationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_CLM10_PatientSignatureSourceCode {get; set;}
    [XmlElement(Order=10)]
    public C_C024_RelatedCausesInformation C_C024_RelatedCausesInformation {get; set;}
    [XmlElement(Order=11)]
    public string D_CLM12_SpecialProgramCode {get; set;}
    [XmlElement(Order=12)]
    public string D_CLM13_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=13)]
    public string D_CLM14_LevelofServiceCode {get; set;}
    [XmlElement(Order=14)]
    public string D_CLM15_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=15)]
    public string D_CLM16_ProviderAgreementCode {get; set;}
    [XmlElement(Order=16)]
    public string D_CLM17_ClaimStatusCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CLM18_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=18)]
    public string D_CLM19_ClaimSubmissionReasonCode {get; set;}
    [XmlElement(Order=19)]
    public string D_CLM20_DelayReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C023_HealthCareServiceLocationInformation {
    [XmlElement(Order=0)]
    public string D_C02301_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02302_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_C02303_ClaimFrequencyCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C024_RelatedCausesInformation {
    [XmlElement(Order=0)]
    public string D_C02401_RelatedCausesCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02402_Related_CausesCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02403_Related_CausesCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C02404_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C02405_CountryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP {
    [XmlElementAttribute(Order=0)]
    public S_DTP_DischargeHour S_DTP_DischargeHour {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_StatementDates S_DTP_StatementDates {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_AdmissionDate_Hour S_DTP_AdmissionDate_Hour {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_Date_RepricerReceivedDate S_DTP_Date_RepricerReceivedDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DischargeHour {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_2 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DischargeTime {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_2 {
        [XmlEnum("096")]
        Item096,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250_2 {
        TM,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_StatementDates {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_StatementFromorToDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_3 {
        [XmlEnum("434")]
        Item434,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250_3 {
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AdmissionDate_Hour {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_4 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdmissionDateandHour {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_4 {
        [XmlEnum("435")]
        Item435,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250_4 {
        D8,
        DT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_RepricerReceivedDate {
    [XmlElement(Order=0)]
    public X12_ID_374_5 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_RepricerReceivedDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_5 {
        [XmlEnum("050")]
        Item050,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CL1_InstitutionalClaimCode {
    [XmlElement(Order=0)]
    public string D_CL101_AdmissionTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CL102_AdmissionSourceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CL103_PatientStatusCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CL104_NursingHomeResidentialStatusCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_ClaimSupplementalInformation {
    [XmlElement(Order=0)]
    public X12_ID_755 D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_756 D_PWK02_AttachmentTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03_ReportCopiesNeeded {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_Description {get; set;}
    [XmlElement(Order=7)]
    public C_C002_ActionsIndicated C_C002_ActionsIndicated {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09_RequestCategoryCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_755 {
        [XmlEnum("03")]
        Item03,
        [XmlEnum("04")]
        Item04,
        [XmlEnum("05")]
        Item05,
        [XmlEnum("06")]
        Item06,
        [XmlEnum("07")]
        Item07,
        [XmlEnum("08")]
        Item08,
        [XmlEnum("09")]
        Item09,
        [XmlEnum("10")]
        Item10,
        [XmlEnum("11")]
        Item11,
        [XmlEnum("13")]
        Item13,
        [XmlEnum("15")]
        Item15,
        [XmlEnum("21")]
        Item21,
        A3,
        A4,
        AM,
        AS,
        B2,
        B3,
        B4,
        BR,
        BS,
        BT,
        CB,
        CK,
        CT,
        D2,
        DA,
        DB,
        DG,
        DJ,
        DS,
        EB,
        HC,
        HR,
        I5,
        IR,
        LA,
        M1,
        MT,
        NN,
        OB,
        OC,
        OD,
        OE,
        OX,
        OZ,
        P4,
        P5,
        PE,
        PN,
        PO,
        PQ,
        PY,
        PZ,
        RB,
        RR,
        RT,
        RX,
        SG,
        V5,
        XP,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_756 {
        AA,
        BM,
        EL,
        EM,
        FT,
        FX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C002_ActionsIndicated {
    [XmlElement(Order=0)]
    public string D_C00201_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00202_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00203_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C00204_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00205_Paperwork_ReportActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CN1_ContractInformation {
    [XmlElement(Order=0)]
    public X12_ID_1166 D_CN101_ContractTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CN102_ContractAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_CN103_ContractPercentage {get; set;}
    [XmlElement(Order=3)]
    public string D_CN104_ContractCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CN105_TermsDiscountPercentage {get; set;}
    [XmlElement(Order=5)]
    public string D_CN106_ContractVersionIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1166 {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("02")]
        Item02,
        [XmlEnum("03")]
        Item03,
        [XmlEnum("04")]
        Item04,
        [XmlEnum("05")]
        Item05,
        [XmlEnum("06")]
        Item06,
        [XmlEnum("09")]
        Item09,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_PatientEstimatedAmountDue {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PatientResponsibilityAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522 {
        F3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_4 {
    [XmlElementAttribute(Order=0)]
    public S_REF_ServiceAuthorizationExceptionCode S_REF_ServiceAuthorizationExceptionCode {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_ReferralNumber S_REF_ReferralNumber {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_PriorAuthorization S_REF_PriorAuthorization {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_PayerClaimControlNumber S_REF_PayerClaimControlNumber {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_RepricedClaimNumber S_REF_RepricedClaimNumber {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_AdjustedRepricedClaimNumber S_REF_AdjustedRepricedClaimNumber {get; set;}
    [XmlElement(Order=6)]
    public U_REF_InvestigationalDeviceExemptionNumber U_REF_InvestigationalDeviceExemptionNumber {get; set;}
    [XmlElementAttribute(Order=7)]
    public S_REF_ClaimIdentifierForTransmissionIntermediaries S_REF_ClaimIdentifierForTransmissionIntermediaries {get; set;}
    [XmlElementAttribute(Order=8)]
    public S_REF_AutoAccidentState S_REF_AutoAccidentState {get; set;}
    [XmlElementAttribute(Order=9)]
    public S_REF_MedicalRecordNumber S_REF_MedicalRecordNumber {get; set;}
    [XmlElementAttribute(Order=10)]
    public S_REF_DemonstrationProjectIdentifier S_REF_DemonstrationProjectIdentifier {get; set;}
    [XmlElementAttribute(Order=11)]
    public S_REF_PeerReviewOrganization_PRO_ApprovalNumber S_REF_PeerReviewOrganization_PRO_ApprovalNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceAuthorizationExceptionCode {
    [XmlElement(Order=0)]
    public X12_ID_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_127_1 D_REF02_ServiceAuthorizationExceptionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_8 C_C040_ReferenceIdentifier_8 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_9 {
        [XmlEnum("4N")]
        Item4N,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_127_1 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("4")]
        Item4,
        [XmlEnum("5")]
        Item5,
        [XmlEnum("6")]
        Item6,
        [XmlEnum("7")]
        Item7,
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
    public class S_REF_ReferralNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_10 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_9 C_C040_ReferenceIdentifier_9 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_10 {
        [XmlEnum("9F")]
        Item9F,
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
    public class S_REF_PriorAuthorization {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_10 C_C040_ReferenceIdentifier_10 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_11 {
        G1,
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
    public class S_REF_PayerClaimControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_12 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_11 C_C040_ReferenceIdentifier_11 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_12 {
        F8,
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
    public class S_REF_RepricedClaimNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_13 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_12 C_C040_ReferenceIdentifier_12 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_13 {
        [XmlEnum("9A")]
        Item9A,
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
    public class S_REF_AdjustedRepricedClaimNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_14 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_13 C_C040_ReferenceIdentifier_13 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_14 {
        [XmlEnum("9C")]
        Item9C,
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
    public class S_REF_InvestigationalDeviceExemptionNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_15 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InvestigationalDeviceExemptionIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_14 C_C040_ReferenceIdentifier_14 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_15 {
        LX,
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
    public class S_REF_ClaimIdentifierForTransmissionIntermediaries {
    [XmlElement(Order=0)]
    public X12_ID_128_16 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ValueAddedNetworkTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_15 C_C040_ReferenceIdentifier_15 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_16 {
        D9,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_15 {
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
    public class S_REF_AutoAccidentState {
    [XmlElement(Order=0)]
    public X12_ID_128_17 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AutoAccidentStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_16 C_C040_ReferenceIdentifier_16 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_17 {
        LU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_16 {
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
    public class S_REF_MedicalRecordNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_18 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MedicalRecordNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_17 C_C040_ReferenceIdentifier_17 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_18 {
        EA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_17 {
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
    public class S_REF_DemonstrationProjectIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_19 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DemonstrationProjectIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_18 C_C040_ReferenceIdentifier_18 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_19 {
        P4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_18 {
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
    public class S_REF_PeerReviewOrganization_PRO_ApprovalNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PeerReviewAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_19 C_C040_ReferenceIdentifier_19 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_20 {
        G4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_19 {
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
    public class S_K3_FileInformation {
    [XmlElement(Order=0)]
    public string D_K301_FixedFormatInformation {get; set;}
    [XmlElement(Order=1)]
    public string D_K302_RecordFormatCode {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitofMeasure C_C001_CompositeUnitofMeasure {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C001_CompositeUnitofMeasure {
    [XmlElement(Order=0)]
    public string D_C00101_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00102_Exponent {get; set;}
    [XmlElement(Order=2)]
    public string D_C00103_Multiplier {get; set;}
    [XmlElement(Order=3)]
    public string D_C00104_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00105_Exponent {get; set;}
    [XmlElement(Order=5)]
    public string D_C00106_Multiplier {get; set;}
    [XmlElement(Order=6)]
    public string D_C00107_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=7)]
    public string D_C00108_Exponent {get; set;}
    [XmlElement(Order=8)]
    public string D_C00109_Multiplier {get; set;}
    [XmlElement(Order=9)]
    public string D_C00110_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=10)]
    public string D_C00111_Exponent {get; set;}
    [XmlElement(Order=11)]
    public string D_C00112_Multiplier {get; set;}
    [XmlElement(Order=12)]
    public string D_C00113_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=13)]
    public string D_C00114_Exponent {get; set;}
    [XmlElement(Order=14)]
    public string D_C00115_Multiplier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NTE {
    [XmlElement(Order=0)]
    public U_NTE_ClaimNote U_NTE_ClaimNote {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_NTE_BillingNote S_NTE_BillingNote {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_ClaimNote {
    [XmlElement(Order=0)]
    public X12_ID_363 D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_ClaimNoteText {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_363 {
        ALG,
        DCP,
        DGN,
        DME,
        MED,
        NTR,
        ODT,
        RHB,
        RLH,
        RNH,
        SET,
        SFM,
        SPT,
        UPI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_BillingNote {
    [XmlElement(Order=0)]
    public X12_ID_363_2 D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_BillingNoteText {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_363_2 {
        ADD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_EPSDTReferral {
    [XmlElement(Order=0)]
    public X12_ID_1136 D_CRC01_CodeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1073_2 D_CRC02_CertificationConditionCodeAppliesIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionIndicator {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionIndicator {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionIndicator {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionIndicator {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionIndicator {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1136 {
        ZZ,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1073_2 {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_HI {
    [XmlElementAttribute(Order=0)]
    public S_HI_PrincipalDiagnosis S_HI_PrincipalDiagnosis {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_HI_AdmittingDiagnosis S_HI_AdmittingDiagnosis {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_HI_Patient_sReasonForVisit S_HI_Patient_sReasonForVisit {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_HI_ExternalCauseofInjury S_HI_ExternalCauseofInjury {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_HI_DiagnosisRelatedGroup_DRG_Information S_HI_DiagnosisRelatedGroup_DRG_Information {get; set;}
    [XmlElement(Order=5)]
    public U_HI_OtherDiagnosisInformation U_HI_OtherDiagnosisInformation {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_HI_PrincipalProcedureInformation S_HI_PrincipalProcedureInformation {get; set;}
    [XmlElement(Order=7)]
    public U_HI_OtherProcedureInformation U_HI_OtherProcedureInformation {get; set;}
    [XmlElement(Order=8)]
    public U_HI_OccurrenceSpanInformation U_HI_OccurrenceSpanInformation {get; set;}
    [XmlElement(Order=9)]
    public U_HI_OccurrenceInformation U_HI_OccurrenceInformation {get; set;}
    [XmlElement(Order=10)]
    public U_HI_ValueInformation U_HI_ValueInformation {get; set;}
    [XmlElement(Order=11)]
    public U_HI_ConditionInformation U_HI_ConditionInformation {get; set;}
    [XmlElement(Order=12)]
    public U_HI_TreatmentCodeInformation U_HI_TreatmentCodeInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_PrincipalDiagnosis {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation C_C022_HealthCareCodeInformation {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_2 C_C022_HealthCareCodeInformation_2 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_3 C_C022_HealthCareCodeInformation_3 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_4 C_C022_HealthCareCodeInformation_4 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_5 C_C022_HealthCareCodeInformation_5 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_6 C_C022_HealthCareCodeInformation_6 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_7 C_C022_HealthCareCodeInformation_7 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_8 C_C022_HealthCareCodeInformation_8 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_9 C_C022_HealthCareCodeInformation_9 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_10 C_C022_HealthCareCodeInformation_10 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_11 C_C022_HealthCareCodeInformation_11 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_12 C_C022_HealthCareCodeInformation_12 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation {
    [XmlElement(Order=0)]
    public X12_ID_1270_2 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PrincipalDiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_2 {
        ABK,
        BK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270 {
        [XmlEnum("0")]
        Item0,
        [XmlEnum("1")]
        Item1,
        [XmlEnum("10")]
        Item10,
        [XmlEnum("100")]
        Item100,
        [XmlEnum("101")]
        Item101,
        [XmlEnum("102")]
        Item102,
        [XmlEnum("103")]
        Item103,
        [XmlEnum("104")]
        Item104,
        [XmlEnum("105")]
        Item105,
        [XmlEnum("106")]
        Item106,
        [XmlEnum("107")]
        Item107,
        [XmlEnum("108")]
        Item108,
        [XmlEnum("109")]
        Item109,
        [XmlEnum("11")]
        Item11,
        [XmlEnum("12")]
        Item12,
        [XmlEnum("13")]
        Item13,
        [XmlEnum("14")]
        Item14,
        [XmlEnum("15")]
        Item15,
        [XmlEnum("16")]
        Item16,
        [XmlEnum("17")]
        Item17,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("20")]
        Item20,
        [XmlEnum("21")]
        Item21,
        [XmlEnum("22")]
        Item22,
        [XmlEnum("23")]
        Item23,
        [XmlEnum("24")]
        Item24,
        [XmlEnum("25")]
        Item25,
        [XmlEnum("26")]
        Item26,
        [XmlEnum("27")]
        Item27,
        [XmlEnum("28")]
        Item28,
        [XmlEnum("29")]
        Item29,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("30")]
        Item30,
        [XmlEnum("31")]
        Item31,
        [XmlEnum("32")]
        Item32,
        [XmlEnum("33")]
        Item33,
        [XmlEnum("34")]
        Item34,
        [XmlEnum("35")]
        Item35,
        [XmlEnum("36")]
        Item36,
        [XmlEnum("37")]
        Item37,
        [XmlEnum("38")]
        Item38,
        [XmlEnum("39")]
        Item39,
        [XmlEnum("4")]
        Item4,
        [XmlEnum("40")]
        Item40,
        [XmlEnum("41")]
        Item41,
        [XmlEnum("42")]
        Item42,
        [XmlEnum("43")]
        Item43,
        [XmlEnum("44")]
        Item44,
        [XmlEnum("45")]
        Item45,
        [XmlEnum("46")]
        Item46,
        [XmlEnum("47")]
        Item47,
        [XmlEnum("48")]
        Item48,
        [XmlEnum("49")]
        Item49,
        [XmlEnum("5")]
        Item5,
        [XmlEnum("50")]
        Item50,
        [XmlEnum("52")]
        Item52,
        [XmlEnum("53")]
        Item53,
        [XmlEnum("54")]
        Item54,
        [XmlEnum("55")]
        Item55,
        [XmlEnum("56")]
        Item56,
        [XmlEnum("57")]
        Item57,
        [XmlEnum("58")]
        Item58,
        [XmlEnum("59")]
        Item59,
        [XmlEnum("60")]
        Item60,
        [XmlEnum("61")]
        Item61,
        [XmlEnum("62")]
        Item62,
        [XmlEnum("63")]
        Item63,
        [XmlEnum("65")]
        Item65,
        [XmlEnum("66")]
        Item66,
        [XmlEnum("67")]
        Item67,
        [XmlEnum("68")]
        Item68,
        [XmlEnum("69")]
        Item69,
        [XmlEnum("7")]
        Item7,
        [XmlEnum("71")]
        Item71,
        [XmlEnum("72")]
        Item72,
        [XmlEnum("73")]
        Item73,
        [XmlEnum("74")]
        Item74,
        [XmlEnum("75")]
        Item75,
        [XmlEnum("78")]
        Item78,
        [XmlEnum("79")]
        Item79,
        [XmlEnum("8")]
        Item8,
        [XmlEnum("80")]
        Item80,
        [XmlEnum("81")]
        Item81,
        [XmlEnum("82")]
        Item82,
        [XmlEnum("83")]
        Item83,
        [XmlEnum("84")]
        Item84,
        [XmlEnum("85")]
        Item85,
        [XmlEnum("87")]
        Item87,
        [XmlEnum("88")]
        Item88,
        [XmlEnum("89")]
        Item89,
        [XmlEnum("90")]
        Item90,
        [XmlEnum("91")]
        Item91,
        [XmlEnum("92")]
        Item92,
        [XmlEnum("93")]
        Item93,
        [XmlEnum("94")]
        Item94,
        [XmlEnum("95")]
        Item95,
        [XmlEnum("96")]
        Item96,
        [XmlEnum("97")]
        Item97,
        [XmlEnum("98")]
        Item98,
        [XmlEnum("99")]
        Item99,
        A,
        A1,
        A2,
        A3,
        A4,
        A5,
        A6,
        A7,
        A8,
        A9,
        AA,
        AAA,
        AAD,
        AAE,
        AAF,
        AAG,
        AAH,
        AAI,
        AAJ,
        AAK,
        AAL,
        AAM,
        AAN,
        AAO,
        AAP,
        AAQ,
        AAR,
        AAS,
        AAT,
        AAU,
        AAV,
        AAW,
        AAX,
        AAY,
        AB,
        ABF,
        ABJ,
        ABK,
        ABN,
        ABR,
        ABS,
        ABU,
        ABV,
        AC,
        ACR,
        AD,
        ADD,
        ADJ,
        AE,
        AF,
        AG,
        AH,
        AI,
        AJ,
        AJT,
        AK,
        AL,
        ALM,
        ALP,
        AM,
        AN,
        AO,
        APE,
        APR,
        AQ,
        AR,
        ARI,
        AS,
        ASD,
        AT,
        ATD,
        ATT,
        AU,
        AV,
        AW,
        AX,
        AY,
        AZ,
        B,
        BA,
        BB,
        BBQ,
        BBR,
        BC,
        BCC,
        BCR,
        BD,
        BE,
        BF,
        BG,
        BH,
        BI,
        BJ,
        BK,
        BL,
        BN,
        BO,
        BP,
        BPL,
        BQ,
        BR,
        BRL,
        BS,
        BSL,
        BSP,
        BT,
        BTC,
        BU,
        BUI,
        BV,
        BW,
        BX,
        BY,
        BZ,
        C,
        C1,
        C2,
        C3,
        CA,
        CAH,
        CB,
        CC,
        CD,
        CE,
        CF,
        CFI,
        CG,
        CH,
        CHG,
        CI,
        CIE,
        CJ,
        CK,
        CL,
        CLP,
        CM,
        CML,
        CN,
        CNC,
        CO,
        COG,
        CP,
        CPS,
        CQ,
        CR,
        CRC,
        CS,
        CSD,
        CSF,
        CT,
        CU,
        CV,
        CW,
        CZ,
        D,
        D1,
        D2,
        D3,
        D4,
        D5,
        DA,
        DAC,
        DB,
        DBS,
        DC,
        DD,
        DE,
        DF,
        DG,
        DGO,
        DH,
        DI,
        DJ,
        DK,
        DL,
        DLO,
        DLP,
        DM,
        DN,
        DO,
        DOF,
        DP,
        DPE,
        DPL,
        DQ,
        DR,
        DRL,
        DS,
        DSR,
        DSS,
        DT,
        DU,
        DW,
        DX,
        DY,
        DZ,
        E,
        EA,
        EAA,
        EAB,
        EAC,
        EAD,
        EAE,
        EAF,
        EAG,
        EAH,
        EAI,
        EAJ,
        EAK,
        EAL,
        EAM,
        EAN,
        EAO,
        EAP,
        EAQ,
        EAR,
        EAS,
        EAT,
        EAU,
        EAV,
        EAW,
        EAX,
        EAY,
        EAZ,
        EB,
        EBA,
        EBB,
        EBC,
        EBD,
        EBE,
        EBF,
        EBG,
        EBH,
        EBI,
        EBJ,
        EBK,
        EBL,
        EBM,
        EBN,
        EBO,
        EBP,
        EBQ,
        EBR,
        EBS,
        EBT,
        EBU,
        EBV,
        EBW,
        EBX,
        EBY,
        EBZ,
        EC,
        ECA,
        ECB,
        ECC,
        ECD,
        ECE,
        ECF,
        ECG,
        ECH,
        ECI,
        ECJ,
        ECK,
        ECL,
        ECM,
        ECN,
        ECO,
        ECP,
        ECQ,
        ECR,
        ECS,
        ECT,
        ECU,
        ECV,
        ECW,
        ECX,
        ECY,
        ECZ,
        ED,
        EDA,
        EDB,
        EDC,
        EDD,
        EDE,
        EDF,
        EDG,
        EDH,
        EDI,
        EDJ,
        EDK,
        EDL,
        EDM,
        EDN,
        EDO,
        EDP,
        EDQ,
        EDR,
        EDS,
        EDT,
        EDU,
        EDV,
        EDW,
        EDX,
        EDY,
        EDZ,
        EE,
        EEA,
        EEB,
        EEC,
        EED,
        EEE,
        EEF,
        EEG,
        EEH,
        EEI,
        EEJ,
        EEK,
        EEL,
        EEM,
        EEN,
        EEO,
        EEP,
        EEQ,
        EER,
        EES,
        EF,
        EG,
        EH,
        EI,
        EJ,
        EK,
        EL,
        EM,
        EMC,
        EN,
        EO,
        EQ,
        EQR,
        ER,
        ES,
        ESC,
        ESL,
        ET,
        ETL,
        EU,
        EV,
        EW,
        EWC,
        EWR,
        EX,
        EXD,
        EY,
        EZ,
        F,
        FA,
        FAP,
        FB,
        FC,
        FC1,
        FD,
        FE,
        FF,
        FF1,
        FG,
        FH,
        FH1,
        FI,
        FIR,
        FJ,
        FK,
        FL,
        FL1,
        FM,
        FMO,
        FMS,
        FN,
        FO,
        FP,
        FP1,
        FQ,
        FR,
        FRP,
        FS,
        FT,
        FT1,
        FU,
        FV,
        FW,
        FX,
        FZ,
        G,
        G1,
        GA,
        GB,
        GC,
        GD,
        GE,
        GF,
        GG,
        GI,
        GJ,
        GK,
        GQ,
        GR,
        GS,
        GT,
        GU,
        GV,
        GW,
        GX,
        GY,
        GZ,
        H,
        HA,
        HB,
        HC,
        HD,
        HE,
        HF,
        HG,
        HI,
        HJ,
        HK,
        HL,
        HM,
        HO,
        HRC,
        HS,
        HZR,
        I,
        IBP,
        IC,
        ID,
        IF,
        IMC,
        IMP,
        IND,
        IPA,
        IQ,
        IRR,
        IRT,
        IT,
        J,
        J0,
        J1,
        J2,
        J3,
        J4,
        J5,
        J6,
        J7,
        J8,
        J9,
        JA,
        JB,
        JC,
        JCL,
        JD,
        JE,
        JF,
        JG,
        JH,
        JI,
        JK,
        JL,
        JM,
        JN,
        JO,
        JOL,
        JP,
        K,
        KA,
        KB,
        KC,
        KD,
        KE,
        KF,
        KG,
        KH,
        KI,
        KJ,
        KK,
        KL,
        KM,
        KO,
        KP,
        KQ,
        KS,
        KT,
        KU,
        KW,
        KYL,
        KZ,
        L,
        LA,
        LB,
        LC,
        LD,
        LE,
        LF,
        LG,
        LH,
        LIN,
        LJ,
        LK,
        LM,
        LN,
        LO,
        LOC,
        LOI,
        LP,
        LQ,
        LR,
        LS,
        LSC,
        LT,
        LZ,
        M,
        MA,
        MAC,
        MB,
        MC,
        MCC,
        MCD,
        ME,
        MEC,
        MI,
        MJ,
        MK,
        ML,
        MN,
        MOC,
        MOE,
        MRI,
        MS,
        MT,
        N,
        NA,
        NAC,
        NAF,
        NAN,
        NAS,
        NB,
        NC,
        ND,
        NDC,
        NE,
        NF,
        NH,
        NI,
        NIR,
        NJ,
        NK,
        NP,
        NPC,
        NR,
        NS,
        NT,
        NUB,
        O,
        O1,
        O2,
        O3,
        O4,
        OC,
        P,
        PA,
        PB,
        PC,
        PCR,
        PD,
        PDA,
        PGS,
        PHC,
        PI,
        PIT,
        PL,
        PLC,
        PLS,
        POB,
        PPD,
        PPP,
        PPS,
        PPV,
        PQA,
        PR,
        PRA,
        PRC,
        PRI,
        PRR,
        PRT,
        PS,
        PT,
        PWA,
        PWI,
        PWR,
        PWS,
        PWT,
        Q,
        QA,
        QB,
        QC,
        QDR,
        QE,
        QF,
        QG,
        QH,
        QI,
        QJ,
        QK,
        QS,
        QT,
        R,
        R1,
        R2,
        R3,
        R4,
        RA,
        RAS,
        RC,
        RCA,
        RD,
        RE,
        REC,
        RED,
        REN,
        RET,
        RFC,
        RI,
        RJC,
        RQ,
        RSS,
        RT,
        RTC,
        RUM,
        RVC,
        RX,
        S,
        SA,
        SAT,
        SB,
        SBA,
        SC,
        SCI,
        SD,
        SE,
        SEC,
        SET,
        SF,
        SG,
        SH,
        SHL,
        SHM,
        SHN,
        SHO,
        SHP,
        SHQ,
        SHR,
        SHS,
        SHT,
        SHU,
        SHV,
        SHW,
        SHX,
        SHY,
        SHZ,
        SI,
        SIA,
        SIB,
        SIC,
        SID,
        SIE,
        SIF,
        SIG,
        SIH,
        SII,
        SIJ,
        SIK,
        SIL,
        SIM,
        SIN,
        SIO,
        SIP,
        SIQ,
        SIR,
        SIS,
        SIT,
        SIU,
        SIV,
        SIW,
        SIX,
        SIY,
        SIZ,
        SJ,
        SJA,
        SJB,
        SJC,
        SJD,
        SJE,
        SJF,
        SJG,
        SJH,
        SJI,
        SJJ,
        SJK,
        SJL,
        SJM,
        SJN,
        SJO,
        SJP,
        SJQ,
        SJR,
        SJS,
        SJT,
        SJU,
        SJV,
        SJW,
        SJX,
        SJY,
        SJZ,
        SKA,
        SKB,
        SKC,
        SKD,
        SKE,
        SKF,
        SKG,
        SKH,
        SKI,
        SKJ,
        SKK,
        SKL,
        SKM,
        SKN,
        SKO,
        SKP,
        SKQ,
        SKR,
        SKS,
        SKT,
        SKU,
        SKV,
        SKW,
        SKX,
        SKY,
        SKZ,
        SL,
        SLA,
        SLS,
        SMB,
        SMC,
        SMD,
        SMI,
        SMT,
        SO,
        SP,
        SPE,
        SR,
        SRL,
        SRR,
        SRT,
        SS,
        SSC,
        ST,
        STC,
        STF,
        SUI,
        SVC,
        SWR,
        T,
        T00,
        T01,
        T02,
        T03,
        T04,
        T05,
        T06,
        T07,
        T08,
        T09,
        T10,
        T11,
        T12,
        T13,
        T14,
        T15,
        T16,
        T17,
        T18,
        T19,
        T20,
        T21,
        T22,
        T23,
        T24,
        T25,
        T26,
        T27,
        T28,
        T29,
        T30,
        T31,
        T32,
        T33,
        T34,
        T35,
        TB,
        TC,
        TCD,
        TCL,
        TD,
        TE,
        TF,
        TFR,
        TG,
        TL,
        TOL,
        TP,
        TQ,
        TR,
        TT,
        TTL,
        TX,
        TY,
        U,
        UER,
        UJC,
        UNP,
        UPC,
        UPT,
        UR,
        US,
        UT,
        UTC,
        UU,
        V,
        VAL,
        VP,
        W,
        WDL,
        WRC,
        WSD,
        X,
        XD,
        Y,
        Z,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_4 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_5 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_6 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_7 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_8 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_9 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_10 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_11 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_12 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_AdmittingDiagnosis {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_13 C_C022_HealthCareCodeInformation_13 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_14 C_C022_HealthCareCodeInformation_14 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_15 C_C022_HealthCareCodeInformation_15 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_16 C_C022_HealthCareCodeInformation_16 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_17 C_C022_HealthCareCodeInformation_17 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_18 C_C022_HealthCareCodeInformation_18 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_19 C_C022_HealthCareCodeInformation_19 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_20 C_C022_HealthCareCodeInformation_20 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_21 C_C022_HealthCareCodeInformation_21 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_22 C_C022_HealthCareCodeInformation_22 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_23 C_C022_HealthCareCodeInformation_23 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_24 C_C022_HealthCareCodeInformation_24 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_13 {
    [XmlElement(Order=0)]
    public X12_ID_1270_3 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_AdmittingDiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_3 {
        ABJ,
        BJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_14 {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_15 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_16 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_17 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_18 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_19 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_20 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_21 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_22 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_23 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_24 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_Patient_sReasonForVisit {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_25 C_C022_HealthCareCodeInformation_25 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_26 C_C022_HealthCareCodeInformation_26 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_27 C_C022_HealthCareCodeInformation_27 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_28 C_C022_HealthCareCodeInformation_28 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_29 C_C022_HealthCareCodeInformation_29 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_30 C_C022_HealthCareCodeInformation_30 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_31 C_C022_HealthCareCodeInformation_31 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_32 C_C022_HealthCareCodeInformation_32 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_33 C_C022_HealthCareCodeInformation_33 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_34 C_C022_HealthCareCodeInformation_34 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_35 C_C022_HealthCareCodeInformation_35 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_36 C_C022_HealthCareCodeInformation_36 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_25 {
    [XmlElement(Order=0)]
    public X12_ID_1270_4 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PatientReasonForVisit {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_4 {
        APR,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_26 {
    [XmlElement(Order=0)]
    public X12_ID_1270_4 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PatientReasonForVisit {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_27 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PatientReasonForVisit {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_28 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_29 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_30 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_31 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_32 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_33 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_34 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_35 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_36 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_ExternalCauseofInjury {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_37 C_C022_HealthCareCodeInformation_37 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_38 C_C022_HealthCareCodeInformation_38 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_39 C_C022_HealthCareCodeInformation_39 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_40 C_C022_HealthCareCodeInformation_40 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_41 C_C022_HealthCareCodeInformation_41 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_42 C_C022_HealthCareCodeInformation_42 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_43 C_C022_HealthCareCodeInformation_43 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_44 C_C022_HealthCareCodeInformation_44 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_45 C_C022_HealthCareCodeInformation_45 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_46 C_C022_HealthCareCodeInformation_46 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_47 C_C022_HealthCareCodeInformation_47 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_48 C_C022_HealthCareCodeInformation_48 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_37 {
    [XmlElement(Order=0)]
    public X12_ID_1270_5 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_5 {
        ABN,
        BN,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_38 {
    [XmlElement(Order=0)]
    public X12_ID_1270_5 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_39 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_40 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_41 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_42 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_43 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_44 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_45 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_46 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_47 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_48 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_DiagnosisRelatedGroup_DRG_Information {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_49 C_C022_HealthCareCodeInformation_49 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_50 C_C022_HealthCareCodeInformation_50 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_51 C_C022_HealthCareCodeInformation_51 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_52 C_C022_HealthCareCodeInformation_52 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_53 C_C022_HealthCareCodeInformation_53 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_54 C_C022_HealthCareCodeInformation_54 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_55 C_C022_HealthCareCodeInformation_55 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_56 C_C022_HealthCareCodeInformation_56 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_57 C_C022_HealthCareCodeInformation_57 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_58 C_C022_HealthCareCodeInformation_58 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_59 C_C022_HealthCareCodeInformation_59 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_60 C_C022_HealthCareCodeInformation_60 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_49 {
    [XmlElement(Order=0)]
    public X12_ID_1270_6 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisRelatedGroup_DRG_Code {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_6 {
        DR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_50 {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_51 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_52 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_53 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_54 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_55 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_56 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_57 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_58 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_59 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_60 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OtherDiagnosisInformation {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_61 C_C022_HealthCareCodeInformation_61 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_62 C_C022_HealthCareCodeInformation_62 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_63 C_C022_HealthCareCodeInformation_63 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_64 C_C022_HealthCareCodeInformation_64 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_65 C_C022_HealthCareCodeInformation_65 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_66 C_C022_HealthCareCodeInformation_66 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_67 C_C022_HealthCareCodeInformation_67 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_68 C_C022_HealthCareCodeInformation_68 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_69 C_C022_HealthCareCodeInformation_69 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_70 C_C022_HealthCareCodeInformation_70 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_71 C_C022_HealthCareCodeInformation_71 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_72 C_C022_HealthCareCodeInformation_72 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_61 {
    [XmlElement(Order=0)]
    public X12_ID_1270_7 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_7 {
        ABF,
        BF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_62 {
    [XmlElement(Order=0)]
    public X12_ID_1270_7 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_63 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_64 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_65 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_66 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_67 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_68 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_69 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_70 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_71 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_72 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_PrincipalProcedureInformation {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_73 C_C022_HealthCareCodeInformation_73 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_74 C_C022_HealthCareCodeInformation_74 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_75 C_C022_HealthCareCodeInformation_75 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_76 C_C022_HealthCareCodeInformation_76 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_77 C_C022_HealthCareCodeInformation_77 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_78 C_C022_HealthCareCodeInformation_78 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_79 C_C022_HealthCareCodeInformation_79 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_80 C_C022_HealthCareCodeInformation_80 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_81 C_C022_HealthCareCodeInformation_81 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_82 C_C022_HealthCareCodeInformation_82 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_83 C_C022_HealthCareCodeInformation_83 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_84 C_C022_HealthCareCodeInformation_84 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_73 {
    [XmlElement(Order=0)]
    public X12_ID_1270_8 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PrincipalProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_PrincipalProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_8 {
        BBR,
        BR,
        CAH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_74 {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_75 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_76 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_77 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_78 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_79 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_80 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_81 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_82 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_83 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_84 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OtherProcedureInformation {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_85 C_C022_HealthCareCodeInformation_85 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_86 C_C022_HealthCareCodeInformation_86 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_87 C_C022_HealthCareCodeInformation_87 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_88 C_C022_HealthCareCodeInformation_88 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_89 C_C022_HealthCareCodeInformation_89 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_90 C_C022_HealthCareCodeInformation_90 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_91 C_C022_HealthCareCodeInformation_91 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_92 C_C022_HealthCareCodeInformation_92 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_93 C_C022_HealthCareCodeInformation_93 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_94 C_C022_HealthCareCodeInformation_94 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_95 C_C022_HealthCareCodeInformation_95 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_96 C_C022_HealthCareCodeInformation_96 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_85 {
    [XmlElement(Order=0)]
    public X12_ID_1270_9 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_9 {
        BBQ,
        BQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_86 {
    [XmlElement(Order=0)]
    public X12_ID_1270_9 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_87 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_88 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_89 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_90 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_91 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_92 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_93 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_94 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_95 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_96 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OccurrenceSpanInformation {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_97 C_C022_HealthCareCodeInformation_97 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_98 C_C022_HealthCareCodeInformation_98 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_99 C_C022_HealthCareCodeInformation_99 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_100 C_C022_HealthCareCodeInformation_100 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_101 C_C022_HealthCareCodeInformation_101 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_102 C_C022_HealthCareCodeInformation_102 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_103 C_C022_HealthCareCodeInformation_103 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_104 C_C022_HealthCareCodeInformation_104 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_105 C_C022_HealthCareCodeInformation_105 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_106 C_C022_HealthCareCodeInformation_106 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_107 C_C022_HealthCareCodeInformation_107 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_108 C_C022_HealthCareCodeInformation_108 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_97 {
    [XmlElement(Order=0)]
    public X12_ID_1270_10 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_10 {
        BI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_98 {
    [XmlElement(Order=0)]
    public X12_ID_1270_10 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_99 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_100 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_101 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_102 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_103 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_104 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_105 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_106 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_107 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_108 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OccurrenceInformation {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_109 C_C022_HealthCareCodeInformation_109 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_110 C_C022_HealthCareCodeInformation_110 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_111 C_C022_HealthCareCodeInformation_111 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_112 C_C022_HealthCareCodeInformation_112 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_113 C_C022_HealthCareCodeInformation_113 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_114 C_C022_HealthCareCodeInformation_114 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_115 C_C022_HealthCareCodeInformation_115 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_116 C_C022_HealthCareCodeInformation_116 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_117 C_C022_HealthCareCodeInformation_117 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_118 C_C022_HealthCareCodeInformation_118 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_119 C_C022_HealthCareCodeInformation_119 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_120 C_C022_HealthCareCodeInformation_120 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_109 {
    [XmlElement(Order=0)]
    public X12_ID_1270_11 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_11 {
        BH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_110 {
    [XmlElement(Order=0)]
    public X12_ID_1270_11 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_111 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_112 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_113 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_114 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_115 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_116 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_117 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_118 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_119 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_120 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_ValueInformation {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_121 C_C022_HealthCareCodeInformation_121 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_122 C_C022_HealthCareCodeInformation_122 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_123 C_C022_HealthCareCodeInformation_123 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_124 C_C022_HealthCareCodeInformation_124 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_125 C_C022_HealthCareCodeInformation_125 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_126 C_C022_HealthCareCodeInformation_126 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_127 C_C022_HealthCareCodeInformation_127 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_128 C_C022_HealthCareCodeInformation_128 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_129 C_C022_HealthCareCodeInformation_129 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_130 C_C022_HealthCareCodeInformation_130 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_131 C_C022_HealthCareCodeInformation_131 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_132 C_C022_HealthCareCodeInformation_132 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_121 {
    [XmlElement(Order=0)]
    public X12_ID_1270_12 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_12 {
        BE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_122 {
    [XmlElement(Order=0)]
    public X12_ID_1270_12 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_123 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_124 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_125 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_126 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_127 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_128 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_129 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_130 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_131 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_132 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_ConditionInformation {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_133 C_C022_HealthCareCodeInformation_133 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_134 C_C022_HealthCareCodeInformation_134 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_135 C_C022_HealthCareCodeInformation_135 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_136 C_C022_HealthCareCodeInformation_136 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_137 C_C022_HealthCareCodeInformation_137 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_138 C_C022_HealthCareCodeInformation_138 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_139 C_C022_HealthCareCodeInformation_139 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_140 C_C022_HealthCareCodeInformation_140 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_141 C_C022_HealthCareCodeInformation_141 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_142 C_C022_HealthCareCodeInformation_142 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_143 C_C022_HealthCareCodeInformation_143 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_144 C_C022_HealthCareCodeInformation_144 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_133 {
    [XmlElement(Order=0)]
    public X12_ID_1270_13 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_13 {
        BG,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_134 {
    [XmlElement(Order=0)]
    public X12_ID_1270_13 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_135 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_136 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_137 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_138 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_139 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_140 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_141 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_142 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_143 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_144 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_TreatmentCodeInformation {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_145 C_C022_HealthCareCodeInformation_145 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_146 C_C022_HealthCareCodeInformation_146 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_147 C_C022_HealthCareCodeInformation_147 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_148 C_C022_HealthCareCodeInformation_148 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_149 C_C022_HealthCareCodeInformation_149 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_150 C_C022_HealthCareCodeInformation_150 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_151 C_C022_HealthCareCodeInformation_151 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_152 C_C022_HealthCareCodeInformation_152 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_153 C_C022_HealthCareCodeInformation_153 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_154 C_C022_HealthCareCodeInformation_154 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_155 C_C022_HealthCareCodeInformation_155 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_156 C_C022_HealthCareCodeInformation_156 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_145 {
    [XmlElement(Order=0)]
    public X12_ID_1270_14 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_14 {
        TC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_146 {
    [XmlElement(Order=0)]
    public X12_ID_1270_14 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_147 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_148 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_149 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_150 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_151 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_152 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_153 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_154 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_155 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_156 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HCP_ClaimPricing_RepricingInformation {
    [XmlElement(Order=0)]
    public X12_ID_1473 D_HCP01_PricingMethodology {get; set;}
    [XmlElement(Order=1)]
    public string D_HCP02_RepricedAllowedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_HCP03_RepricedSavingAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_HCP04_RepricingOrganizationIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_HCP05_RepricingPerDiemorFlatRateAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HCP06_RepricedApprovedDRGCode {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_RepricedApprovedAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_RepricedApprovedRevenueCode {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_Product_ServiceID {get; set;}
    [XmlElement(Order=10)]
    public string D_HCP11_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=11)]
    public string D_HCP12_RepricedApprovedServiceUnitCount {get; set;}
    [XmlElement(Order=12)]
    public string D_HCP13_RejectReasonCode {get; set;}
    [XmlElement(Order=13)]
    public string D_HCP14_PolicyComplianceCode {get; set;}
    [XmlElement(Order=14)]
    public string D_HCP15_ExceptionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1473 {
        [XmlEnum("00")]
        Item00,
        [XmlEnum("01")]
        Item01,
        [XmlEnum("02")]
        Item02,
        [XmlEnum("03")]
        Item03,
        [XmlEnum("04")]
        Item04,
        [XmlEnum("05")]
        Item05,
        [XmlEnum("06")]
        Item06,
        [XmlEnum("07")]
        Item07,
        [XmlEnum("08")]
        Item08,
        [XmlEnum("09")]
        Item09,
        [XmlEnum("10")]
        Item10,
        [XmlEnum("11")]
        Item11,
        [XmlEnum("12")]
        Item12,
        [XmlEnum("13")]
        Item13,
        [XmlEnum("14")]
        Item14,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_4 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2310A G_TS837_2310A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2310B G_TS837_2310B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2310C G_TS837_2310C {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837_2310D G_TS837_2310D {get; set;}
    [XmlElementAttribute(Order=4)]
    public G_TS837_2310E G_TS837_2310E {get; set;}
    [XmlElementAttribute(Order=5)]
    public G_TS837_2310F G_TS837_2310F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2310A {
    [XmlElement(Order=0)]
    public S_NM1_AttendingProviderName S_NM1_AttendingProviderName {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AttendingProviderSpecialtyInformation S_PRV_AttendingProviderSpecialtyInformation {get; set;}
    [XmlElement("S_REF_AttendingProviderSecondaryIdentification",Order=2)]
    public List<S_REF_AttendingProviderSecondaryIdentification> S_REF_AttendingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AttendingProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AttendingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AttendingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AttendingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AttendingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AttendingProviderPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_9 {
        [XmlEnum("71")]
        Item71,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_3 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AttendingProviderSpecialtyInformation {
    [XmlElement(Order=0)]
    public X12_ID_1221_2 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_2 C_C035_ProviderSpecialtyInformation_2 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1221_2 {
        AT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_2 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AttendingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AttendingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_20 C_C040_ReferenceIdentifier_20 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_21 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
        G2,
        LU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_20 {
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
    public class G_TS837_2310B {
    [XmlElement(Order=0)]
    public S_NM1_OperatingPhysicianName S_NM1_OperatingPhysicianName {get; set;}
    [XmlElement("S_REF_OperatingPhysicianSecondaryIdentification",Order=1)]
    public List<S_REF_OperatingPhysicianSecondaryIdentification> S_REF_OperatingPhysicianSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OperatingPhysicianName {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OperatingPhysicanMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OperatingPhysicianPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_10 {
        [XmlEnum("72")]
        Item72,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OperatingPhysicianSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OperatingPhysicianSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_21 C_C040_ReferenceIdentifier_21 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_21 {
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
    public class G_TS837_2310C {
    [XmlElement(Order=0)]
    public S_NM1_OtherOperatingPhysicianName S_NM1_OtherOperatingPhysicianName {get; set;}
    [XmlElement("S_REF_OtherOperatingPhysicianSecondaryIdentification",Order=1)]
    public List<S_REF_OtherOperatingPhysicianSecondaryIdentification> S_REF_OtherOperatingPhysicianSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherOperatingPhysicianName {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherOperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherOperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherOperatingPhysicianMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherOperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherOperatingPhysicianIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_11 {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherOperatingPhysicianSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_22 C_C040_ReferenceIdentifier_22 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_22 {
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
    public class G_TS837_2310D {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName S_NM1_RenderingProviderName {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification",Order=1)]
    public List<S_REF_RenderingProviderSecondaryIdentification> S_REF_RenderingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RenderingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RenderingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RenderingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_12 {
        [XmlEnum("82")]
        Item82,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_23 C_C040_ReferenceIdentifier_23 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_23 {
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
    public class G_TS837_2310E {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityLocationName S_NM1_ServiceFacilityLocationName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_ServiceFacilityLocationAddress S_N3_ServiceFacilityLocationAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ServiceFacilityLocationCity_State_ZIP S_N4_ServiceFacilityLocationCity_State_ZIP {get; set;}
    [XmlElement("S_REF_ServiceFacilitySecondaryIdentification",Order=3)]
    public List<S_REF_ServiceFacilitySecondaryIdentification> S_REF_ServiceFacilitySecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceFacilityLocationName {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_LaboratoryorFacilityName {get; set;}
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
    public string D_NM109_LaboratoryorFacilityPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_13 {
        [XmlEnum("77")]
        Item77,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_ServiceFacilityLocationAddress {
    [XmlElement(Order=0)]
    public string D_N301_LaboratoryorFacilityAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_LaboratoryorFacilityAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceFacilityLocationCity_State_ZIP {
    [XmlElement(Order=0)]
    public string D_N401_LaboratoryorFacilityCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_LaboratoryorFacilityStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_LaboratoryorFacilityPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceFacilitySecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_22 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LaboratoryorFacilitySecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_24 C_C040_ReferenceIdentifier_24 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_22 {
        [XmlEnum("0B")]
        Item0B,
        G2,
        LU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_24 {
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
    public class G_TS837_2310F {
    [XmlElement(Order=0)]
    public S_NM1_ReferringProviderName S_NM1_ReferringProviderName {get; set;}
    [XmlElement("S_REF_ReferringProviderSecondaryIdentification",Order=1)]
    public List<S_REF_ReferringProviderSecondaryIdentification> S_REF_ReferringProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReferringProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_14 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ReferringProviderLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ReferringProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ReferringProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ReferringProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ReferringProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_14 {
        DN,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReferringProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_23 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferringProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_25 C_C040_ReferenceIdentifier_25 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_23 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
        G2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_25 {
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
    public class G_TS837_2320 {
    [XmlElement(Order=0)]
    public S_SBR_OtherSubscriberInformation S_SBR_OtherSubscriberInformation {get; set;}
    [XmlElement("S_CAS_ClaimLevelAdjustments",Order=1)]
    public List<S_CAS_ClaimLevelAdjustments> S_CAS_ClaimLevelAdjustments {get; set;}
    [XmlElement(Order=2)]
    public A_AMT A_AMT {get; set;}
    [XmlElement(Order=3)]
    public S_OI_OtherInsuranceCoverageInformation S_OI_OtherInsuranceCoverageInformation {get; set;}
    [XmlElement(Order=4)]
    public S_MIA_InpatientAdjudicationInformation S_MIA_InpatientAdjudicationInformation {get; set;}
    [XmlElement(Order=5)]
    public S_MOA_OutpatientAdjudicationInformation S_MOA_OutpatientAdjudicationInformation {get; set;}
    [XmlElement(Order=6)]
    public A_NM1_5 A_NM1_5 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SBR_OtherSubscriberInformation {
    [XmlElement(Order=0)]
    public X12_ID_1138 D_SBR01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1069_2 D_SBR02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SBR03_InsuredGrouporPolicyNumber {get; set;}
    [XmlElement(Order=3)]
    public string D_SBR04_OtherInsuredGroupName {get; set;}
    [XmlElement(Order=4)]
    public string D_SBR05_InsuranceTypeCode {get; set;}
    [XmlElement(Order=5)]
    public string D_SBR06_CoordinationofBenefitsCode {get; set;}
    [XmlElement(Order=6)]
    public string D_SBR07_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=7)]
    public string D_SBR08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SBR09_ClaimFilingIndicatorCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1069_2 {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("20")]
        Item20,
        [XmlEnum("21")]
        Item21,
        [XmlEnum("39")]
        Item39,
        [XmlEnum("40")]
        Item40,
        [XmlEnum("53")]
        Item53,
        G8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ClaimLevelAdjustments {
    [XmlElement(Order=0)]
    public X12_ID_1033 D_CAS01_ClaimAdjustmentGroupCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CAS02_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CAS03_AdjustmentAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_CAS04_AdjustmentQuantity {get; set;}
    [XmlElement(Order=4)]
    public string D_CAS05_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CAS06_AdjustmentAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_CAS07_AdjustmentQuantity {get; set;}
    [XmlElement(Order=7)]
    public string D_CAS08_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CAS09_AdjustmentAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_CAS10_AdjustmentQuantity {get; set;}
    [XmlElement(Order=10)]
    public string D_CAS11_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=11)]
    public string D_CAS12_AdjustmentAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_CAS13_AdjustmentQuantity {get; set;}
    [XmlElement(Order=13)]
    public string D_CAS14_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=14)]
    public string D_CAS15_AdjustmentAmount {get; set;}
    [XmlElement(Order=15)]
    public string D_CAS16_AdjustmentQuantity {get; set;}
    [XmlElement(Order=16)]
    public string D_CAS17_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CAS18_AdjustmentAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_CAS19_AdjustmentQuantity {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1033 {
        CO,
        CR,
        OA,
        PI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_AMT {
    [XmlElementAttribute(Order=0)]
    public S_AMT_CoordinationofBenefits_COB_PayerPaidAmount S_AMT_CoordinationofBenefits_COB_PayerPaidAmount {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_RemainingPatientLiability S_AMT_RemainingPatientLiability {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_AMT_CoordinationofBenefits_COB_TotalNon_coveredAmount S_AMT_CoordinationofBenefits_COB_TotalNon_coveredAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationofBenefits_COB_PayerPaidAmount {
    [XmlElement(Order=0)]
    public X12_ID_522_2 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PayerPaidAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522_2 {
        D,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_RemainingPatientLiability {
    [XmlElement(Order=0)]
    public X12_ID_522_3 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_RemainingPatientLiability {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522_3 {
        EAF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationofBenefits_COB_TotalNon_coveredAmount {
    [XmlElement(Order=0)]
    public X12_ID_522_4 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_Non_CoveredChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522_4 {
        A8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_OI_OtherInsuranceCoverageInformation {
    [XmlElement(Order=0)]
    public string D_OI01_ClaimFilingIndicatorCode {get; set;}
    [XmlElement(Order=1)]
    public string D_OI02_ClaimSubmissionReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_OI03_BenefitsAssignmentCertificationIndicator {get; set;}
    [XmlElement(Order=3)]
    public string D_OI04_PatientSignatureSourceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_OI05_ProviderAgreementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_OI06_ReleaseofInformationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MIA_InpatientAdjudicationInformation {
    [XmlElement(Order=0)]
    public string D_MIA01_CoveredDaysorVisitsCount {get; set;}
    [XmlElement(Order=1)]
    public string D_MIA02_MonetaryAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MIA03_LifetimePsychiatricDaysCount {get; set;}
    [XmlElement(Order=3)]
    public string D_MIA04_ClaimDRGAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_MIA05_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MIA06_ClaimDisproportionateShareAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_MIA07_ClaimMSPPass_throughAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_MIA08_ClaimPPSCapitalAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MIA09_PPS_CapitalFSPDRGAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_MIA10_PPS_CapitalHSPDRGAmount {get; set;}
    [XmlElement(Order=10)]
    public string D_MIA11_PPS_CapitalDSHDRGAmount {get; set;}
    [XmlElement(Order=11)]
    public string D_MIA12_OldCapitalAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_MIA13_PPS_CapitalIMEamount {get; set;}
    [XmlElement(Order=13)]
    public string D_MIA14_PPS_OperatingHospitalSpecificDRGAmount {get; set;}
    [XmlElement(Order=14)]
    public string D_MIA15_CostReportDayCount {get; set;}
    [XmlElement(Order=15)]
    public string D_MIA16_PPS_OperatingFederalSpecificDRGAmount {get; set;}
    [XmlElement(Order=16)]
    public string D_MIA17_ClaimPPSCapitalOutlierAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_MIA18_ClaimIndirectTeachingAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_MIA19_NonpayableProfessionalComponentAmount {get; set;}
    [XmlElement(Order=19)]
    public string D_MIA20_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=20)]
    public string D_MIA21_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=21)]
    public string D_MIA22_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=22)]
    public string D_MIA23_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=23)]
    public string D_MIA24_PPS_CapitalExceptionAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MOA_OutpatientAdjudicationInformation {
    [XmlElement(Order=0)]
    public string D_MOA01_ReimbursementRate {get; set;}
    [XmlElement(Order=1)]
    public string D_MOA02_HCPCSPayableAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MOA03_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=3)]
    public string D_MOA04_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=4)]
    public string D_MOA05_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MOA06_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=6)]
    public string D_MOA07_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=7)]
    public string D_MOA08_EndStageRenalDiseasePaymentAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MOA09_NonpayableProfessionalComponentAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_5 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2330A G_TS837_2330A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2330B G_TS837_2330B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2330C G_TS837_2330C {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837_2330D G_TS837_2330D {get; set;}
    [XmlElementAttribute(Order=4)]
    public G_TS837_2330E G_TS837_2330E {get; set;}
    [XmlElementAttribute(Order=5)]
    public G_TS837_2330F G_TS837_2330F {get; set;}
    [XmlElementAttribute(Order=6)]
    public G_TS837_2330G G_TS837_2330G {get; set;}
    [XmlElementAttribute(Order=7)]
    public G_TS837_2330H G_TS837_2330H {get; set;}
    [XmlElementAttribute(Order=8)]
    public G_TS837_2330I G_TS837_2330I {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2330A {
    [XmlElement(Order=0)]
    public S_NM1_OtherSubscriberName S_NM1_OtherSubscriberName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherSubscriberAddress S_N3_OtherSubscriberAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherSubscriberCity_State_ZIPCode S_N4_OtherSubscriberCity_State_ZIPCode {get; set;}
    [XmlElement("S_REF_OtherSubscriberSecondaryInformation",Order=3)]
    public List<S_REF_OtherSubscriberSecondaryInformation> S_REF_OtherSubscriberSecondaryInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherSubscriberName {
    [XmlElement(Order=0)]
    public X12_ID_98_7 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherInsuredLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherInsuredFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherInsuredMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherInsuredNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherInsuredIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_OtherSubscriberAddress {
    [XmlElement(Order=0)]
    public string D_N301_OtherInsuredAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_OtherInsuredAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_OtherSubscriberCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_OtherInsuredCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_OtherInsuredStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_OtherInsuredPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherSubscriberSecondaryInformation {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherInsuredAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_26 C_C040_ReferenceIdentifier_26 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_26 {
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
    public class G_TS837_2330B {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerName S_NM1_OtherPayerName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherPayerAddress S_N3_OtherPayerAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherPayerCity_State_ZIPCode S_N4_OtherPayerCity_State_ZIPCode {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_ClaimCheckOrRemittanceDate S_DTP_ClaimCheckOrRemittanceDate {get; set;}
    [XmlElement(Order=4)]
    public A_REF_5 A_REF_5 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerName {
    [XmlElement(Order=0)]
    public X12_ID_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherPayerLastorOrganizationName {get; set;}
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
    public string D_NM109_OtherPayerPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_OtherPayerAddress {
    [XmlElement(Order=0)]
    public string D_N301_OtherPayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_OtherPayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_OtherPayerCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_OtherPayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_OtherPayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_OtherPayerPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimCheckOrRemittanceDate {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdjudicationorPaymentDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_6 {
        [XmlEnum("573")]
        Item573,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_5 {
    [XmlElement(Order=0)]
    public U_REF_OtherPayerSecondaryIdentifier U_REF_OtherPayerSecondaryIdentifier {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_OtherPayerPriorAuthorizationNumber S_REF_OtherPayerPriorAuthorizationNumber {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_OtherPayerReferralNumber S_REF_OtherPayerReferralNumber {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_OtherPayerClaimAdjustmentIndicator S_REF_OtherPayerClaimAdjustmentIndicator {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_OtherPayerClaimControlNumber S_REF_OtherPayerClaimControlNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerSecondaryIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_27 C_C040_ReferenceIdentifier_27 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_27 {
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
    public class S_REF_OtherPayerPriorAuthorizationNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationorReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_28 C_C040_ReferenceIdentifier_28 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_28 {
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
    public class S_REF_OtherPayerReferralNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_10 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationorReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_29 C_C040_ReferenceIdentifier_29 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_29 {
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
    public class S_REF_OtherPayerClaimAdjustmentIndicator {
    [XmlElement(Order=0)]
    public X12_ID_128_24 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerClaimAdjustmentIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_30 C_C040_ReferenceIdentifier_30 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_24 {
        T4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_30 {
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
    public class S_REF_OtherPayerClaimControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_12 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayer_sClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_31 C_C040_ReferenceIdentifier_31 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_31 {
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
    public class G_TS837_2330C {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerAttendingProvider S_NM1_OtherPayerAttendingProvider {get; set;}
    [XmlElement("S_REF_OtherPayerAttendingProviderSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerAttendingProviderSecondaryIdentification> S_REF_OtherPayerAttendingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerAttendingProvider {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerAttendingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerAttendingProviderSecondary_Identifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_32 C_C040_ReferenceIdentifier_32 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_32 {
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
    public class G_TS837_2330D {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerOperatingPhysician S_NM1_OtherPayerOperatingPhysician {get; set;}
    [XmlElement("S_REF_OtherPayerOperatingPhysicianSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerOperatingPhysicianSecondaryIdentification> S_REF_OtherPayerOperatingPhysicianSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerOperatingPhysician {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerOperatingPhysicianSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerAttendingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_33 C_C040_ReferenceIdentifier_33 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_33 {
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
    public class G_TS837_2330E {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerOtherOperatingPhysician S_NM1_OtherPayerOtherOperatingPhysician {get; set;}
    [XmlElement("S_REF_OtherPayerOtherOperatingPhysicianSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerOtherOperatingPhysicianSecondaryIdentification> S_REF_OtherPayerOtherOperatingPhysicianSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerOtherOperatingPhysician {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerOtherOperatingPhysicianSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerOperatingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_34 C_C040_ReferenceIdentifier_34 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_34 {
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
    public class G_TS837_2330F {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerServiceFacilityLocation S_NM1_OtherPayerServiceFacilityLocation {get; set;}
    [XmlElement("S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification> S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerServiceFacilityLocation {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_22 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerOtherOperatingPhysicianIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_35 C_C040_ReferenceIdentifier_35 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_35 {
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
    public class G_TS837_2330G {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerRenderingProviderName S_NM1_OtherPayerRenderingProviderName {get; set;}
    [XmlElement("S_REF_OtherPayerRenderingProviderSecondaryIdentifier",Order=1)]
    public List<S_REF_OtherPayerRenderingProviderSecondaryIdentifier> S_REF_OtherPayerRenderingProviderSecondaryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerRenderingProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerRenderingProviderSecondaryIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerRenderingProviderSecondary_Identifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_36 C_C040_ReferenceIdentifier_36 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_36 {
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
    public class G_TS837_2330H {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerReferringProvider S_NM1_OtherPayerReferringProvider {get; set;}
    [XmlElement("S_REF_OtherPayerReferringProviderSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerReferringProviderSecondaryIdentification> S_REF_OtherPayerReferringProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerReferringProvider {
    [XmlElement(Order=0)]
    public X12_ID_98_14 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerReferringProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_23 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerReferringProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_37 C_C040_ReferenceIdentifier_37 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_37 {
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
    public class G_TS837_2330I {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerBillingProvider S_NM1_OtherPayerBillingProvider {get; set;}
    [XmlElement("S_REF_OtherPayerBillingProviderSecondaryIdentifier",Order=1)]
    public List<S_REF_OtherPayerBillingProviderSecondaryIdentifier> S_REF_OtherPayerBillingProviderSecondaryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerBillingProvider {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerBillingProviderSecondaryIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerBillingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_38 C_C040_ReferenceIdentifier_38 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_38 {
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
    public class G_TS837_2400 {
    [XmlElement(Order=0)]
    public S_LX_ServiceLineNumber S_LX_ServiceLineNumber {get; set;}
    [XmlElement(Order=1)]
    public S_SV2_InstitutionalServiceLine S_SV2_InstitutionalServiceLine {get; set;}
    [XmlElement("S_PWK_LineSupplementalInformation",Order=2)]
    public List<S_PWK_LineSupplementalInformation> S_PWK_LineSupplementalInformation {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_Date_ServiceDate S_DTP_Date_ServiceDate {get; set;}
    [XmlElement(Order=4)]
    public A_REF_6 A_REF_6 {get; set;}
    [XmlElement(Order=5)]
    public A_AMT_2 A_AMT_2 {get; set;}
    [XmlElement(Order=6)]
    public S_NTE_ThirdPartyOrganizationNotes S_NTE_ThirdPartyOrganizationNotes {get; set;}
    [XmlElement(Order=7)]
    public S_HCP_LinePricing_RepricingInformation S_HCP_LinePricing_RepricingInformation {get; set;}
    [XmlElement(Order=8)]
    public G_TS837_2410 G_TS837_2410 {get; set;}
    [XmlElement(Order=9)]
    public A_NM1_6 A_NM1_6 {get; set;}
    [XmlElement("G_TS837_2430",Order=10)]
    public List<G_TS837_2430> G_TS837_2430 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_ServiceLineNumber {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SV2_InstitutionalServiceLine {
    [XmlElement(Order=0)]
    public string D_SV201_ServiceLineRevenueCode {get; set;}
    [XmlElement(Order=1)]
    public C_C003_CompositeMedicalProcedureIdentifier C_C003_CompositeMedicalProcedureIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_SV203_LineItemChargeAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SV204_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SV205_ServiceUnitCount {get; set;}
    [XmlElement(Order=5)]
    public string D_SV206_UnitRate {get; set;}
    [XmlElement(Order=6)]
    public string D_SV207_LineItemDeniedChargeorNon_CoveredChargeAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_SV208_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SV209_NursingHomeResidentialStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV210_LevelofCareCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_235_2 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public enum X12_ID_235_2 {
        ER,
        HC,
        HP,
        IV,
        WK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_LineSupplementalInformation {
    [XmlElement(Order=0)]
    public X12_ID_755 D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_756 D_PWK02_AttachmentTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03_ReportCopiesNeeded {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_Description {get; set;}
    [XmlElement(Order=7)]
    public C_C002_ActionsIndicated_2 C_C002_ActionsIndicated_2 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09_RequestCategoryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C002_ActionsIndicated_2 {
    [XmlElement(Order=0)]
    public string D_C00201_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00202_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00203_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C00204_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00205_Paperwork_ReportActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_ServiceDate {
    [XmlElement(Order=0)]
    public X12_ID_374_7 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_6 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_7 {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250_6 {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_6 {
    [XmlElementAttribute(Order=0)]
    public S_REF_LineItemControlNumber S_REF_LineItemControlNumber {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_RepricedLineItemReferenceNumber S_REF_RepricedLineItemReferenceNumber {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_AdjustedRepricedLineItemReferenceNumber S_REF_AdjustedRepricedLineItemReferenceNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_LineItemControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_25 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_39 C_C040_ReferenceIdentifier_39 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_25 {
        [XmlEnum("6R")]
        Item6R,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_39 {
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
    public class S_REF_RepricedLineItemReferenceNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_26 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedLineItemReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_40 C_C040_ReferenceIdentifier_40 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_26 {
        [XmlEnum("9B")]
        Item9B,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_40 {
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
    public class S_REF_AdjustedRepricedLineItemReferenceNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_27 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedLineItemReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_41 C_C040_ReferenceIdentifier_41 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_27 {
        [XmlEnum("9D")]
        Item9D,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_41 {
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
    public class A_AMT_2 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_ServiceTaxAmount S_AMT_ServiceTaxAmount {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_FacilityTaxAmount S_AMT_FacilityTaxAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ServiceTaxAmount {
    [XmlElement(Order=0)]
    public X12_ID_522_5 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ServiceTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522_5 {
        GT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_FacilityTaxAmount {
    [XmlElement(Order=0)]
    public X12_ID_522_6 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_FacilityTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522_6 {
        N8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_ThirdPartyOrganizationNotes {
    [XmlElement(Order=0)]
    public X12_ID_363_3 D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_LineNoteText {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_363_3 {
        TPO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HCP_LinePricing_RepricingInformation {
    [XmlElement(Order=0)]
    public X12_ID_1473 D_HCP01_PricingMethodology {get; set;}
    [XmlElement(Order=1)]
    public string D_HCP02_MonetaryAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_HCP03_MonetaryAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_HCP04_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_HCP05_Rate {get; set;}
    [XmlElement(Order=5)]
    public string D_HCP06_ReferenceIdentification {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_ProductorServiceID {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_ProductorServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_RepricedApprovedHCPCSCode {get; set;}
    [XmlElement(Order=10)]
    public string D_HCP11_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=11)]
    public string D_HCP12_Quantity {get; set;}
    [XmlElement(Order=12)]
    public string D_HCP13_RejectReasonCode {get; set;}
    [XmlElement(Order=13)]
    public string D_HCP14_PolicyComplianceCode {get; set;}
    [XmlElement(Order=14)]
    public string D_HCP15_ExceptionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2410 {
    [XmlElement(Order=0)]
    public S_LIN_DrugIdentification S_LIN_DrugIdentification {get; set;}
    [XmlElement(Order=1)]
    public S_CTP_DrugQuantity S_CTP_DrugQuantity {get; set;}
    [XmlElement(Order=2)]
    public S_REF_PrescriptionorCompoundDrugAssociationNumber S_REF_PrescriptionorCompoundDrugAssociationNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LIN_DrugIdentification {
    [XmlElement(Order=0)]
    public string D_LIN01_AssignedIdentification {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_235_3 D_LIN02_ProductorServiceIDQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_LIN03_NationalDrugCode {get; set;}
    [XmlElement(Order=3)]
    public string D_LIN04_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=4)]
    public string D_LIN05_Product_ServiceID {get; set;}
    [XmlElement(Order=5)]
    public string D_LIN06_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_LIN07_Product_ServiceID {get; set;}
    [XmlElement(Order=7)]
    public string D_LIN08_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_LIN09_Product_ServiceID {get; set;}
    [XmlElement(Order=9)]
    public string D_LIN10_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=10)]
    public string D_LIN11_Product_ServiceID {get; set;}
    [XmlElement(Order=11)]
    public string D_LIN12_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=12)]
    public string D_LIN13_Product_ServiceID {get; set;}
    [XmlElement(Order=13)]
    public string D_LIN14_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=14)]
    public string D_LIN15_Product_ServiceID {get; set;}
    [XmlElement(Order=15)]
    public string D_LIN16_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=16)]
    public string D_LIN17_Product_ServiceID {get; set;}
    [XmlElement(Order=17)]
    public string D_LIN18_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=18)]
    public string D_LIN19_Product_ServiceID {get; set;}
    [XmlElement(Order=19)]
    public string D_LIN20_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=20)]
    public string D_LIN21_Product_ServiceID {get; set;}
    [XmlElement(Order=21)]
    public string D_LIN22_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=22)]
    public string D_LIN23_Product_ServiceID {get; set;}
    [XmlElement(Order=23)]
    public string D_LIN24_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=24)]
    public string D_LIN25_Product_ServiceID {get; set;}
    [XmlElement(Order=25)]
    public string D_LIN26_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=26)]
    public string D_LIN27_Product_ServiceID {get; set;}
    [XmlElement(Order=27)]
    public string D_LIN28_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=28)]
    public string D_LIN29_Product_ServiceID {get; set;}
    [XmlElement(Order=29)]
    public string D_LIN30_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=30)]
    public string D_LIN31_Product_ServiceID {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_235_3 {
        N4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CTP_DrugQuantity {
    [XmlElement(Order=0)]
    public string D_CTP01_ClassofTradeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CTP02_PriceIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CTP03_UnitPrice {get; set;}
    [XmlElement(Order=3)]
    public string D_CTP04_NationalDrugUnitCount {get; set;}
    [XmlElement(Order=4)]
    public C_C001_CompositeUnitofMeasure_2 C_C001_CompositeUnitofMeasure_2 {get; set;}
    [XmlElement(Order=5)]
    public string D_CTP06_PriceMultiplierQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_CTP07_Multiplier {get; set;}
    [XmlElement(Order=7)]
    public string D_CTP08_MonetaryAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_CTP09_BasisofUnitPriceCode {get; set;}
    [XmlElement(Order=9)]
    public string D_CTP10_ConditionValue {get; set;}
    [XmlElement(Order=10)]
    public string D_CTP11_MultiplePriceQuantity {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C001_CompositeUnitofMeasure_2 {
    [XmlElement(Order=0)]
    public string D_C00101_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00102_Exponent {get; set;}
    [XmlElement(Order=2)]
    public string D_C00103_Multiplier {get; set;}
    [XmlElement(Order=3)]
    public string D_C00104_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00105_Exponent {get; set;}
    [XmlElement(Order=5)]
    public string D_C00106_Multiplier {get; set;}
    [XmlElement(Order=6)]
    public string D_C00107_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=7)]
    public string D_C00108_Exponent {get; set;}
    [XmlElement(Order=8)]
    public string D_C00109_Multiplier {get; set;}
    [XmlElement(Order=9)]
    public string D_C00110_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=10)]
    public string D_C00111_Exponent {get; set;}
    [XmlElement(Order=11)]
    public string D_C00112_Multiplier {get; set;}
    [XmlElement(Order=12)]
    public string D_C00113_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=13)]
    public string D_C00114_Exponent {get; set;}
    [XmlElement(Order=14)]
    public string D_C00115_Multiplier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PrescriptionorCompoundDrugAssociationNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_28 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PrescriptionNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_42 C_C040_ReferenceIdentifier_42 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_28 {
        VY,
        XZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_42 {
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
    public class A_NM1_6 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2420A G_TS837_2420A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2420B G_TS837_2420B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2420C G_TS837_2420C {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837_2420D G_TS837_2420D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2420A {
    [XmlElement(Order=0)]
    public S_NM1_OperatingPhysicianName_2 S_NM1_OperatingPhysicianName_2 {get; set;}
    [XmlElement("S_REF_OperatingPhysicianSecondaryIdentification_2",Order=1)]
    public List<S_REF_OperatingPhysicianSecondaryIdentification_2> S_REF_OperatingPhysicianSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OperatingPhysicianName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OperatingPhysicanMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OperatingPhysicianPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OperatingPhysicianSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OperatingPhysicianSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_43 C_C040_ReferenceIdentifier_43 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_43 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherPayerPrimaryIdentifier {get; set;}
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
    public class G_TS837_2420B {
    [XmlElement(Order=0)]
    public S_NM1_OtherOperatingPhysicianName_2 S_NM1_OtherOperatingPhysicianName_2 {get; set;}
    [XmlElement("S_REF_OtherOperatingPhysicianSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherOperatingPhysicianSecondaryIdentification_2> S_REF_OtherOperatingPhysicianSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherOperatingPhysicianName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherOperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherOperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherOperatingPhysicianMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherOperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherOperatingPhysicianIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherOperatingPhysicianSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_44 C_C040_ReferenceIdentifier_44 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_44 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherPayerPrimaryIdentifier {get; set;}
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
    public class G_TS837_2420C {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName_2 S_NM1_RenderingProviderName_2 {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification_2",Order=1)]
    public List<S_REF_RenderingProviderSecondaryIdentification_2> S_REF_RenderingProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RenderingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RenderingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RenderingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_45 C_C040_ReferenceIdentifier_45 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_45 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherPayerPrimaryIdentifier {get; set;}
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
    public class G_TS837_2420D {
    [XmlElement(Order=0)]
    public S_NM1_ReferringProviderName_2 S_NM1_ReferringProviderName_2 {get; set;}
    [XmlElement("S_REF_ReferringProviderSecondaryIdentification_2",Order=1)]
    public List<S_REF_ReferringProviderSecondaryIdentification_2> S_REF_ReferringProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReferringProviderName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_14 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ReferringProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ReferringProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ReferringProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ReferringProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ReferringProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReferringProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_23 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferringProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_46 C_C040_ReferenceIdentifier_46 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_46 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherPayerPrimaryIdentifier {get; set;}
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
    public class G_TS837_2430 {
    [XmlElement(Order=0)]
    public S_SVD_LineAdjudicationInformation S_SVD_LineAdjudicationInformation {get; set;}
    [XmlElement("S_CAS_LineAdjustment",Order=1)]
    public List<S_CAS_LineAdjustment> S_CAS_LineAdjustment {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_LineCheckorRemittanceDate S_DTP_LineCheckorRemittanceDate {get; set;}
    [XmlElement(Order=3)]
    public S_AMT_RemainingPatientLiability_2 S_AMT_RemainingPatientLiability_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVD_LineAdjudicationInformation {
    [XmlElement(Order=0)]
    public string D_SVD01_OtherPayerPrimaryIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVD02_ServiceLinePaidAmount {get; set;}
    [XmlElement(Order=2)]
    public C_C003_CompositeMedicalProcedureIdentifier_2 C_C003_CompositeMedicalProcedureIdentifier_2 {get; set;}
    [XmlElement(Order=3)]
    public string D_SVD04_Product_ServiceID {get; set;}
    [XmlElement(Order=4)]
    public string D_SVD05_PaidServiceUnitCount {get; set;}
    [XmlElement(Order=5)]
    public string D_SVD06_BundledorUnbundledLineNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_2 {
    [XmlElement(Order=0)]
    public string D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00307_ProcedureCodeDescription {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_LineAdjustment {
    [XmlElement(Order=0)]
    public X12_ID_1033 D_CAS01_ClaimAdjustmentGroupCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CAS02_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CAS03_AdjustmentAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_CAS04_AdjustmentQuantity {get; set;}
    [XmlElement(Order=4)]
    public string D_CAS05_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CAS06_AdjustmentAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_CAS07_AdjustmentQuantity {get; set;}
    [XmlElement(Order=7)]
    public string D_CAS08_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CAS09_AdjustmentAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_CAS10_AdjustmentQuantity {get; set;}
    [XmlElement(Order=10)]
    public string D_CAS11_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=11)]
    public string D_CAS12_AdjustmentAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_CAS13_AdjustmentQuantity {get; set;}
    [XmlElement(Order=13)]
    public string D_CAS14_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=14)]
    public string D_CAS15_AdjustmentAmount {get; set;}
    [XmlElement(Order=15)]
    public string D_CAS16_AdjustmentQuantity {get; set;}
    [XmlElement(Order=16)]
    public string D_CAS17_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CAS18_AdjustmentAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_CAS19_AdjustmentQuantity {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LineCheckorRemittanceDate {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdjudicationorPaymentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_RemainingPatientLiability_2 {
    [XmlElement(Order=0)]
    public X12_ID_522_3 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_RemainingPatientLiability {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2000C {
    [XmlElement(Order=0)]
    public S_HL_PatientHierarchicalLevel S_HL_PatientHierarchicalLevel {get; set;}
    [XmlElement(Order=1)]
    public S_PAT_PatientInformation S_PAT_PatientInformation {get; set;}
    [XmlElement(Order=2)]
    public G_TS837_2010CA G_TS837_2010CA {get; set;}
    [XmlElement("G_TS837_2300_1",Order=3)]
    public List<G_TS837_2300_1> G_TS837_2300_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_PatientHierarchicalLevel {
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
    public class S_PAT_PatientInformation {
    [XmlElement(Order=0)]
    public X12_ID_1069_3 D_PAT01_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PAT02_PatientLocationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PAT03_EmploymentStatusCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PAT04_StudentStatusCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PAT05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PAT06_DateTimePeriod {get; set;}
    [XmlElement(Order=6)]
    public string D_PAT07_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=7)]
    public string D_PAT08_Weight {get; set;}
    [XmlElement(Order=8)]
    public string D_PAT09_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1069_3 {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("20")]
        Item20,
        [XmlEnum("21")]
        Item21,
        [XmlEnum("39")]
        Item39,
        [XmlEnum("40")]
        Item40,
        [XmlEnum("53")]
        Item53,
        G8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_PatientName S_NM1_PatientName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PatientAddress S_N3_PatientAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PatientCity_State_ZIPCode S_N4_PatientCity_State_ZIPCode {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_PatientDemographicInformation S_DMG_PatientDemographicInformation {get; set;}
    [XmlElement(Order=4)]
    public A_REF_7 A_REF_7 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientName {
    [XmlElement(Order=0)]
    public X12_ID_98_15 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PatientNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_15 {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PatientAddress {
    [XmlElement(Order=0)]
    public string D_N301_PatientAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PatientAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PatientCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_PatientCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PatientStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PatientPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_PatientDemographicInformation {
    [XmlElement(Order=0)]
    public X12_ID_1250 D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_PatientBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_PatientGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04_MaritalStatusCode {get; set;}
    [XmlElement("C_C056_CompositeRaceorEthnicityInformation_2",Order=4)]
    public List<C_C056_CompositeRaceorEthnicityInformation_2> C_C056_CompositeRaceorEthnicityInformation_2 {get; set;}
    [XmlElement(Order=5)]
    public string D_DMG06_CitizenshipStatusCode {get; set;}
    [XmlElement(Order=6)]
    public string D_DMG07_CountryCode {get; set;}
    [XmlElement(Order=7)]
    public string D_DMG08_BasisofVerificationCode {get; set;}
    [XmlElement(Order=8)]
    public string D_DMG09_Quantity {get; set;}
    [XmlElement(Order=9)]
    public string D_DMG10_CodeListQualifierCode {get; set;}
    [XmlElement(Order=10)]
    public string D_DMG11_IndustryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C056_CompositeRaceorEthnicityInformation_2 {
    [XmlElement(Order=0)]
    public string D_C05601_RaceorEthnicityCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05602_CodeListQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05603_IndustryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_7 {
    [XmlElementAttribute(Order=0)]
    public S_REF_PropertyandCasualtyClaimNumber_2 S_REF_PropertyandCasualtyClaimNumber_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PropertyandCasualtyPatientIdentifier S_REF_PropertyandCasualtyPatientIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PropertyandCasualtyClaimNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyCasualtyClaimNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_47 C_C040_ReferenceIdentifier_47 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_47 {
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
    public class S_REF_PropertyandCasualtyPatientIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_30 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyandCasualtyPatientIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_48 C_C040_ReferenceIdentifier_48 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_30 {
        [XmlEnum("1W")]
        Item1W,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_48 {
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
    public class G_TS837_2300_1 {
    [XmlElement(Order=0)]
    public S_CLM_Claiminformation_2 S_CLM_Claiminformation_2 {get; set;}
    [XmlElement(Order=1)]
    public A_DTP_2 A_DTP_2 {get; set;}
    [XmlElement(Order=2)]
    public S_CL1_InstitutionalClaimCode_2 S_CL1_InstitutionalClaimCode_2 {get; set;}
    [XmlElement("S_PWK_ClaimSupplementalInformation_2",Order=3)]
    public List<S_PWK_ClaimSupplementalInformation_2> S_PWK_ClaimSupplementalInformation_2 {get; set;}
    [XmlElement(Order=4)]
    public S_CN1_ContractInformation_2 S_CN1_ContractInformation_2 {get; set;}
    [XmlElement(Order=5)]
    public S_AMT_PatientEstimatedAmountDue_2 S_AMT_PatientEstimatedAmountDue_2 {get; set;}
    [XmlElement(Order=6)]
    public A_REF_8 A_REF_8 {get; set;}
    [XmlElement("S_K3_FileInformation_2",Order=7)]
    public List<S_K3_FileInformation_2> S_K3_FileInformation_2 {get; set;}
    [XmlElement(Order=8)]
    public A_NTE_2 A_NTE_2 {get; set;}
    [XmlElement(Order=9)]
    public S_CRC_EPSDTReferral_2 S_CRC_EPSDTReferral_2 {get; set;}
    [XmlElement(Order=10)]
    public A_HI_2 A_HI_2 {get; set;}
    [XmlElement(Order=11)]
    public S_HCP_ClaimPricing_RepricingInformation_2 S_HCP_ClaimPricing_RepricingInformation_2 {get; set;}
    [XmlElement(Order=12)]
    public A_NM1_7 A_NM1_7 {get; set;}
    [XmlElement("G_TS837_2320_1",Order=13)]
    public List<G_TS837_2320_1> G_TS837_2320_1 {get; set;}
    [XmlElement("G_TS837_2400_1",Order=14)]
    public List<G_TS837_2400_1> G_TS837_2400_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CLM_Claiminformation_2 {
    [XmlElement(Order=0)]
    public string D_CLM01_PatientControlNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_CLM02_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_CLM03_ClaimFilingIndicatorCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CLM04_Non_InstitutionalClaimTypeCode {get; set;}
    [XmlElement(Order=4)]
    public C_C023_HealthCareServiceLocationInformation_2 C_C023_HealthCareServiceLocationInformation_2 {get; set;}
    [XmlElement(Order=5)]
    public string D_CLM06_ProviderorSupplierSignatureIndicator {get; set;}
    [XmlElement(Order=6)]
    public string D_CLM07_AssignmentorPlanParticipationCode {get; set;}
    [XmlElement(Order=7)]
    public string D_CLM08_BenefitsAssignmentCertificationIndicator {get; set;}
    [XmlElement(Order=8)]
    public string D_CLM09_ReleaseofInformationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_CLM10_PatientSignatureSourceCode {get; set;}
    [XmlElement(Order=10)]
    public C_C024_RelatedCausesInformation_2 C_C024_RelatedCausesInformation_2 {get; set;}
    [XmlElement(Order=11)]
    public string D_CLM12_SpecialProgramCode {get; set;}
    [XmlElement(Order=12)]
    public string D_CLM13_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=13)]
    public string D_CLM14_LevelofServiceCode {get; set;}
    [XmlElement(Order=14)]
    public string D_CLM15_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=15)]
    public string D_CLM16_ProviderAgreementCode {get; set;}
    [XmlElement(Order=16)]
    public string D_CLM17_ClaimStatusCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CLM18_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=18)]
    public string D_CLM19_ClaimSubmissionReasonCode {get; set;}
    [XmlElement(Order=19)]
    public string D_CLM20_DelayReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C023_HealthCareServiceLocationInformation_2 {
    [XmlElement(Order=0)]
    public string D_C02301_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02302_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_C02303_ClaimFrequencyCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C024_RelatedCausesInformation_2 {
    [XmlElement(Order=0)]
    public string D_C02401_RelatedCausesCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02402_Related_CausesCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02403_Related_CausesCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C02404_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C02405_CountryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_2 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_DischargeHour_2 S_DTP_DischargeHour_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_StatementDates_2 S_DTP_StatementDates_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_AdmissionDate_Hour_2 S_DTP_AdmissionDate_Hour_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_Date_RepricerReceivedDate_2 S_DTP_Date_RepricerReceivedDate_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DischargeHour_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_2 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DischargeTime {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_StatementDates_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_StatementFromorToDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AdmissionDate_Hour_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_4 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdmissionDateandHour {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_RepricerReceivedDate_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_5 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_RepricerReceivedDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CL1_InstitutionalClaimCode_2 {
    [XmlElement(Order=0)]
    public string D_CL101_AdmissionTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CL102_AdmissionSourceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CL103_PatientStatusCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CL104_NursingHomeResidentialStatusCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_ClaimSupplementalInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_755 D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_756 D_PWK02_AttachmentTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03_ReportCopiesNeeded {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_Description {get; set;}
    [XmlElement(Order=7)]
    public C_C002_ActionsIndicated_3 C_C002_ActionsIndicated_3 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09_RequestCategoryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C002_ActionsIndicated_3 {
    [XmlElement(Order=0)]
    public string D_C00201_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00202_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00203_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C00204_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00205_Paperwork_ReportActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CN1_ContractInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1166 D_CN101_ContractTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CN102_ContractAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_CN103_ContractPercentage {get; set;}
    [XmlElement(Order=3)]
    public string D_CN104_ContractCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CN105_TermsDiscountPercentage {get; set;}
    [XmlElement(Order=5)]
    public string D_CN106_ContractVersionIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_PatientEstimatedAmountDue_2 {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PatientResponsibilityAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_8 {
    [XmlElementAttribute(Order=0)]
    public S_REF_ServiceAuthorizationExceptionCode_2 S_REF_ServiceAuthorizationExceptionCode_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_ReferralNumber_2 S_REF_ReferralNumber_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_PriorAuthorization_2 S_REF_PriorAuthorization_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_PayerClaimControlNumber_2 S_REF_PayerClaimControlNumber_2 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_RepricedClaimNumber_2 S_REF_RepricedClaimNumber_2 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_AdjustedRepricedClaimNumber_2 S_REF_AdjustedRepricedClaimNumber_2 {get; set;}
    [XmlElement(Order=6)]
    public U_REF_InvestigationalDeviceExemptionNumber_2 U_REF_InvestigationalDeviceExemptionNumber_2 {get; set;}
    [XmlElementAttribute(Order=7)]
    public S_REF_ClaimIdentifierForTransmissionIntermediaries_2 S_REF_ClaimIdentifierForTransmissionIntermediaries_2 {get; set;}
    [XmlElementAttribute(Order=8)]
    public S_REF_AutoAccidentState_2 S_REF_AutoAccidentState_2 {get; set;}
    [XmlElementAttribute(Order=9)]
    public S_REF_MedicalRecordNumber_2 S_REF_MedicalRecordNumber_2 {get; set;}
    [XmlElementAttribute(Order=10)]
    public S_REF_DemonstrationProjectIdentifier_2 S_REF_DemonstrationProjectIdentifier_2 {get; set;}
    [XmlElementAttribute(Order=11)]
    public S_REF_PeerReviewOrganization_PRO_ApprovalNumber_2 S_REF_PeerReviewOrganization_PRO_ApprovalNumber_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceAuthorizationExceptionCode_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_127_1 D_REF02_ServiceAuthorizationExceptionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_49 C_C040_ReferenceIdentifier_49 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_49 {
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
    public class S_REF_ReferralNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_10 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_50 C_C040_ReferenceIdentifier_50 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_50 {
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
    public class S_REF_PriorAuthorization_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_51 C_C040_ReferenceIdentifier_51 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_51 {
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
    public class S_REF_PayerClaimControlNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_12 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_52 C_C040_ReferenceIdentifier_52 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_52 {
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
    public class S_REF_RepricedClaimNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_13 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_53 C_C040_ReferenceIdentifier_53 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_53 {
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
    public class S_REF_AdjustedRepricedClaimNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_14 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_54 C_C040_ReferenceIdentifier_54 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_54 {
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
    public class S_REF_InvestigationalDeviceExemptionNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_15 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InvestigationalDeviceExemptionIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_55 C_C040_ReferenceIdentifier_55 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_55 {
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
    public class S_REF_ClaimIdentifierForTransmissionIntermediaries_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_16 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ValueAddedNetworkTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_56 C_C040_ReferenceIdentifier_56 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_56 {
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
    public class S_REF_AutoAccidentState_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_17 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AutoAccidentStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_57 C_C040_ReferenceIdentifier_57 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_57 {
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
    public class S_REF_MedicalRecordNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_18 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MedicalRecordNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_58 C_C040_ReferenceIdentifier_58 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_58 {
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
    public class S_REF_DemonstrationProjectIdentifier_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_19 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DemonstrationProjectIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_59 C_C040_ReferenceIdentifier_59 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_59 {
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
    public class S_REF_PeerReviewOrganization_PRO_ApprovalNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PeerReviewAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_60 C_C040_ReferenceIdentifier_60 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_60 {
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
    public class S_K3_FileInformation_2 {
    [XmlElement(Order=0)]
    public string D_K301_FixedFormatInformation {get; set;}
    [XmlElement(Order=1)]
    public string D_K302_RecordFormatCode {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitofMeasure_3 C_C001_CompositeUnitofMeasure_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C001_CompositeUnitofMeasure_3 {
    [XmlElement(Order=0)]
    public string D_C00101_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00102_Exponent {get; set;}
    [XmlElement(Order=2)]
    public string D_C00103_Multiplier {get; set;}
    [XmlElement(Order=3)]
    public string D_C00104_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00105_Exponent {get; set;}
    [XmlElement(Order=5)]
    public string D_C00106_Multiplier {get; set;}
    [XmlElement(Order=6)]
    public string D_C00107_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=7)]
    public string D_C00108_Exponent {get; set;}
    [XmlElement(Order=8)]
    public string D_C00109_Multiplier {get; set;}
    [XmlElement(Order=9)]
    public string D_C00110_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=10)]
    public string D_C00111_Exponent {get; set;}
    [XmlElement(Order=11)]
    public string D_C00112_Multiplier {get; set;}
    [XmlElement(Order=12)]
    public string D_C00113_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=13)]
    public string D_C00114_Exponent {get; set;}
    [XmlElement(Order=14)]
    public string D_C00115_Multiplier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NTE_2 {
    [XmlElement(Order=0)]
    public U_NTE_ClaimNote_2 U_NTE_ClaimNote_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_NTE_BillingNote_2 S_NTE_BillingNote_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_ClaimNote_2 {
    [XmlElement(Order=0)]
    public X12_ID_363 D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_ClaimNoteText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_BillingNote_2 {
    [XmlElement(Order=0)]
    public X12_ID_363_2 D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_BillingNoteText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_EPSDTReferral_2 {
    [XmlElement(Order=0)]
    public X12_ID_1136 D_CRC01_CodeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1073_2 D_CRC02_CertificationConditionCodeAppliesIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionIndicator {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionIndicator {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionIndicator {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionIndicator {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_HI_2 {
    [XmlElementAttribute(Order=0)]
    public S_HI_PrincipalDiagnosis_2 S_HI_PrincipalDiagnosis_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_HI_AdmittingDiagnosis_2 S_HI_AdmittingDiagnosis_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_HI_Patient_sReasonForVisit_2 S_HI_Patient_sReasonForVisit_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_HI_ExternalCauseofInjury_2 S_HI_ExternalCauseofInjury_2 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_HI_DiagnosisRelatedGroup_DRG_Information_2 S_HI_DiagnosisRelatedGroup_DRG_Information_2 {get; set;}
    [XmlElement(Order=5)]
    public U_HI_OtherDiagnosisInformation_2 U_HI_OtherDiagnosisInformation_2 {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_HI_PrincipalProcedureInformation_2 S_HI_PrincipalProcedureInformation_2 {get; set;}
    [XmlElement(Order=7)]
    public U_HI_OtherProcedureInformation_2 U_HI_OtherProcedureInformation_2 {get; set;}
    [XmlElement(Order=8)]
    public U_HI_OccurrenceSpanInformation_2 U_HI_OccurrenceSpanInformation_2 {get; set;}
    [XmlElement(Order=9)]
    public U_HI_OccurrenceInformation_2 U_HI_OccurrenceInformation_2 {get; set;}
    [XmlElement(Order=10)]
    public U_HI_ValueInformation_2 U_HI_ValueInformation_2 {get; set;}
    [XmlElement(Order=11)]
    public U_HI_ConditionInformation_2 U_HI_ConditionInformation_2 {get; set;}
    [XmlElement(Order=12)]
    public U_HI_TreatmentCodeInformation_2 U_HI_TreatmentCodeInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_PrincipalDiagnosis_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_157 C_C022_HealthCareCodeInformation_157 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_158 C_C022_HealthCareCodeInformation_158 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_159 C_C022_HealthCareCodeInformation_159 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_160 C_C022_HealthCareCodeInformation_160 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_161 C_C022_HealthCareCodeInformation_161 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_162 C_C022_HealthCareCodeInformation_162 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_163 C_C022_HealthCareCodeInformation_163 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_164 C_C022_HealthCareCodeInformation_164 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_165 C_C022_HealthCareCodeInformation_165 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_166 C_C022_HealthCareCodeInformation_166 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_167 C_C022_HealthCareCodeInformation_167 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_168 C_C022_HealthCareCodeInformation_168 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_157 {
    [XmlElement(Order=0)]
    public X12_ID_1270_2 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PrincipalDiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_158 {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_159 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_160 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_161 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_162 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_163 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_164 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_165 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_166 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_167 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_168 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_AdmittingDiagnosis_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_169 C_C022_HealthCareCodeInformation_169 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_170 C_C022_HealthCareCodeInformation_170 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_171 C_C022_HealthCareCodeInformation_171 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_172 C_C022_HealthCareCodeInformation_172 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_173 C_C022_HealthCareCodeInformation_173 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_174 C_C022_HealthCareCodeInformation_174 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_175 C_C022_HealthCareCodeInformation_175 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_176 C_C022_HealthCareCodeInformation_176 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_177 C_C022_HealthCareCodeInformation_177 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_178 C_C022_HealthCareCodeInformation_178 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_179 C_C022_HealthCareCodeInformation_179 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_180 C_C022_HealthCareCodeInformation_180 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_169 {
    [XmlElement(Order=0)]
    public X12_ID_1270_3 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_AdmittingDiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_170 {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_171 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_172 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_173 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_174 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_175 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_176 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_177 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_178 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_179 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_180 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_Patient_sReasonForVisit_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_181 C_C022_HealthCareCodeInformation_181 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_182 C_C022_HealthCareCodeInformation_182 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_183 C_C022_HealthCareCodeInformation_183 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_184 C_C022_HealthCareCodeInformation_184 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_185 C_C022_HealthCareCodeInformation_185 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_186 C_C022_HealthCareCodeInformation_186 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_187 C_C022_HealthCareCodeInformation_187 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_188 C_C022_HealthCareCodeInformation_188 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_189 C_C022_HealthCareCodeInformation_189 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_190 C_C022_HealthCareCodeInformation_190 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_191 C_C022_HealthCareCodeInformation_191 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_192 C_C022_HealthCareCodeInformation_192 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_181 {
    [XmlElement(Order=0)]
    public X12_ID_1270_4 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PatientReasonForVisit {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_182 {
    [XmlElement(Order=0)]
    public X12_ID_1270_4 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PatientReasonForVisit {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_183 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PatientReasonForVisit {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_184 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_185 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_186 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_187 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_188 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_189 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_190 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_191 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_192 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_ExternalCauseofInjury_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_193 C_C022_HealthCareCodeInformation_193 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_194 C_C022_HealthCareCodeInformation_194 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_195 C_C022_HealthCareCodeInformation_195 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_196 C_C022_HealthCareCodeInformation_196 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_197 C_C022_HealthCareCodeInformation_197 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_198 C_C022_HealthCareCodeInformation_198 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_199 C_C022_HealthCareCodeInformation_199 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_200 C_C022_HealthCareCodeInformation_200 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_201 C_C022_HealthCareCodeInformation_201 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_202 C_C022_HealthCareCodeInformation_202 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_203 C_C022_HealthCareCodeInformation_203 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_204 C_C022_HealthCareCodeInformation_204 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_193 {
    [XmlElement(Order=0)]
    public X12_ID_1270_5 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_194 {
    [XmlElement(Order=0)]
    public X12_ID_1270_5 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_195 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_196 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_197 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_198 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_199 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_200 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_201 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_202 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_203 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_204 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ExternalCauseofInjuryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_DiagnosisRelatedGroup_DRG_Information_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_205 C_C022_HealthCareCodeInformation_205 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_206 C_C022_HealthCareCodeInformation_206 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_207 C_C022_HealthCareCodeInformation_207 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_208 C_C022_HealthCareCodeInformation_208 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_209 C_C022_HealthCareCodeInformation_209 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_210 C_C022_HealthCareCodeInformation_210 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_211 C_C022_HealthCareCodeInformation_211 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_212 C_C022_HealthCareCodeInformation_212 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_213 C_C022_HealthCareCodeInformation_213 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_214 C_C022_HealthCareCodeInformation_214 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_215 C_C022_HealthCareCodeInformation_215 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_216 C_C022_HealthCareCodeInformation_216 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_205 {
    [XmlElement(Order=0)]
    public X12_ID_1270_6 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisRelatedGroup_DRG_Code {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_206 {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_207 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_208 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_209 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_210 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_211 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_212 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_213 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_214 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_215 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_216 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OtherDiagnosisInformation_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_217 C_C022_HealthCareCodeInformation_217 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_218 C_C022_HealthCareCodeInformation_218 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_219 C_C022_HealthCareCodeInformation_219 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_220 C_C022_HealthCareCodeInformation_220 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_221 C_C022_HealthCareCodeInformation_221 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_222 C_C022_HealthCareCodeInformation_222 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_223 C_C022_HealthCareCodeInformation_223 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_224 C_C022_HealthCareCodeInformation_224 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_225 C_C022_HealthCareCodeInformation_225 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_226 C_C022_HealthCareCodeInformation_226 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_227 C_C022_HealthCareCodeInformation_227 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_228 C_C022_HealthCareCodeInformation_228 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_217 {
    [XmlElement(Order=0)]
    public X12_ID_1270_7 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_218 {
    [XmlElement(Order=0)]
    public X12_ID_1270_7 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_219 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_220 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_221 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_222 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_223 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_224 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_225 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_226 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_227 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_228 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_PresentonAdmissionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_PrincipalProcedureInformation_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_229 C_C022_HealthCareCodeInformation_229 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_230 C_C022_HealthCareCodeInformation_230 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_231 C_C022_HealthCareCodeInformation_231 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_232 C_C022_HealthCareCodeInformation_232 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_233 C_C022_HealthCareCodeInformation_233 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_234 C_C022_HealthCareCodeInformation_234 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_235 C_C022_HealthCareCodeInformation_235 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_236 C_C022_HealthCareCodeInformation_236 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_237 C_C022_HealthCareCodeInformation_237 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_238 C_C022_HealthCareCodeInformation_238 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_239 C_C022_HealthCareCodeInformation_239 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_240 C_C022_HealthCareCodeInformation_240 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_229 {
    [XmlElement(Order=0)]
    public X12_ID_1270_8 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_PrincipalProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_PrincipalProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_230 {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_231 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_232 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_233 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_234 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_235 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_236 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_237 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_238 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_239 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_240 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OtherProcedureInformation_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_241 C_C022_HealthCareCodeInformation_241 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_242 C_C022_HealthCareCodeInformation_242 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_243 C_C022_HealthCareCodeInformation_243 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_244 C_C022_HealthCareCodeInformation_244 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_245 C_C022_HealthCareCodeInformation_245 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_246 C_C022_HealthCareCodeInformation_246 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_247 C_C022_HealthCareCodeInformation_247 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_248 C_C022_HealthCareCodeInformation_248 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_249 C_C022_HealthCareCodeInformation_249 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_250 C_C022_HealthCareCodeInformation_250 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_251 C_C022_HealthCareCodeInformation_251 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_252 C_C022_HealthCareCodeInformation_252 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_241 {
    [XmlElement(Order=0)]
    public X12_ID_1270_9 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_242 {
    [XmlElement(Order=0)]
    public X12_ID_1270_9 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_243 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_244 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_245 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_246 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_247 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_248 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_249 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_250 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_251 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_252 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OccurrenceSpanInformation_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_253 C_C022_HealthCareCodeInformation_253 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_254 C_C022_HealthCareCodeInformation_254 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_255 C_C022_HealthCareCodeInformation_255 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_256 C_C022_HealthCareCodeInformation_256 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_257 C_C022_HealthCareCodeInformation_257 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_258 C_C022_HealthCareCodeInformation_258 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_259 C_C022_HealthCareCodeInformation_259 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_260 C_C022_HealthCareCodeInformation_260 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_261 C_C022_HealthCareCodeInformation_261 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_262 C_C022_HealthCareCodeInformation_262 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_263 C_C022_HealthCareCodeInformation_263 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_264 C_C022_HealthCareCodeInformation_264 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_253 {
    [XmlElement(Order=0)]
    public X12_ID_1270_10 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_254 {
    [XmlElement(Order=0)]
    public X12_ID_1270_10 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_255 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_256 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_257 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_258 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_259 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_260 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_261 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_262 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_263 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_264 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceSpanCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OccurrenceInformation_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_265 C_C022_HealthCareCodeInformation_265 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_266 C_C022_HealthCareCodeInformation_266 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_267 C_C022_HealthCareCodeInformation_267 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_268 C_C022_HealthCareCodeInformation_268 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_269 C_C022_HealthCareCodeInformation_269 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_270 C_C022_HealthCareCodeInformation_270 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_271 C_C022_HealthCareCodeInformation_271 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_272 C_C022_HealthCareCodeInformation_272 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_273 C_C022_HealthCareCodeInformation_273 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_274 C_C022_HealthCareCodeInformation_274 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_275 C_C022_HealthCareCodeInformation_275 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_276 C_C022_HealthCareCodeInformation_276 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_265 {
    [XmlElement(Order=0)]
    public X12_ID_1270_11 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_266 {
    [XmlElement(Order=0)]
    public X12_ID_1270_11 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_267 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_268 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_269 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_270 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_271 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_272 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_273 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_274 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_275 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_276 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_OccurrenceCodeDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_ValueInformation_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_277 C_C022_HealthCareCodeInformation_277 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_278 C_C022_HealthCareCodeInformation_278 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_279 C_C022_HealthCareCodeInformation_279 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_280 C_C022_HealthCareCodeInformation_280 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_281 C_C022_HealthCareCodeInformation_281 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_282 C_C022_HealthCareCodeInformation_282 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_283 C_C022_HealthCareCodeInformation_283 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_284 C_C022_HealthCareCodeInformation_284 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_285 C_C022_HealthCareCodeInformation_285 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_286 C_C022_HealthCareCodeInformation_286 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_287 C_C022_HealthCareCodeInformation_287 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_288 C_C022_HealthCareCodeInformation_288 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_277 {
    [XmlElement(Order=0)]
    public X12_ID_1270_12 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_278 {
    [XmlElement(Order=0)]
    public X12_ID_1270_12 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_279 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_280 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_281 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_282 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_283 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_284 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_285 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_286 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_287 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_288 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_ValueCodeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_ConditionInformation_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_289 C_C022_HealthCareCodeInformation_289 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_290 C_C022_HealthCareCodeInformation_290 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_291 C_C022_HealthCareCodeInformation_291 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_292 C_C022_HealthCareCodeInformation_292 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_293 C_C022_HealthCareCodeInformation_293 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_294 C_C022_HealthCareCodeInformation_294 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_295 C_C022_HealthCareCodeInformation_295 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_296 C_C022_HealthCareCodeInformation_296 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_297 C_C022_HealthCareCodeInformation_297 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_298 C_C022_HealthCareCodeInformation_298 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_299 C_C022_HealthCareCodeInformation_299 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_300 C_C022_HealthCareCodeInformation_300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_289 {
    [XmlElement(Order=0)]
    public X12_ID_1270_13 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_290 {
    [XmlElement(Order=0)]
    public X12_ID_1270_13 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_291 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_292 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_293 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_294 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_295 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_296 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_297 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_298 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_299 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_300 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_TreatmentCodeInformation_2 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_301 C_C022_HealthCareCodeInformation_301 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_302 C_C022_HealthCareCodeInformation_302 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_303 C_C022_HealthCareCodeInformation_303 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_304 C_C022_HealthCareCodeInformation_304 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_305 C_C022_HealthCareCodeInformation_305 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_306 C_C022_HealthCareCodeInformation_306 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_307 C_C022_HealthCareCodeInformation_307 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_308 C_C022_HealthCareCodeInformation_308 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_309 C_C022_HealthCareCodeInformation_309 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_310 C_C022_HealthCareCodeInformation_310 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_311 C_C022_HealthCareCodeInformation_311 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_312 C_C022_HealthCareCodeInformation_312 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_301 {
    [XmlElement(Order=0)]
    public X12_ID_1270_14 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_302 {
    [XmlElement(Order=0)]
    public X12_ID_1270_14 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_303 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_304 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_305 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_306 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_307 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_308 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_309 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_310 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_311 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_312 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HCP_ClaimPricing_RepricingInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1473 D_HCP01_PricingMethodology {get; set;}
    [XmlElement(Order=1)]
    public string D_HCP02_RepricedAllowedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_HCP03_RepricedSavingAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_HCP04_RepricingOrganizationIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_HCP05_RepricingPerDiemorFlatRateAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HCP06_RepricedApprovedDRGCode {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_RepricedApprovedAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_RepricedApprovedRevenueCode {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_Product_ServiceID {get; set;}
    [XmlElement(Order=10)]
    public string D_HCP11_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=11)]
    public string D_HCP12_RepricedApprovedServiceUnitCount {get; set;}
    [XmlElement(Order=12)]
    public string D_HCP13_RejectReasonCode {get; set;}
    [XmlElement(Order=13)]
    public string D_HCP14_PolicyComplianceCode {get; set;}
    [XmlElement(Order=14)]
    public string D_HCP15_ExceptionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_7 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2310A_1 G_TS837_2310A_1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2310B_1 G_TS837_2310B_1 {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2310C_1 G_TS837_2310C_1 {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837_2310D_1 G_TS837_2310D_1 {get; set;}
    [XmlElementAttribute(Order=4)]
    public G_TS837_2310E_1 G_TS837_2310E_1 {get; set;}
    [XmlElementAttribute(Order=5)]
    public G_TS837_2310F_1 G_TS837_2310F_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2310A_1 {
    [XmlElement(Order=0)]
    public S_NM1_AttendingProviderName_2 S_NM1_AttendingProviderName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AttendingProviderSpecialtyInformation_2 S_PRV_AttendingProviderSpecialtyInformation_2 {get; set;}
    [XmlElement("S_REF_AttendingProviderSecondaryIdentification_2",Order=2)]
    public List<S_REF_AttendingProviderSecondaryIdentification_2> S_REF_AttendingProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AttendingProviderName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AttendingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AttendingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AttendingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AttendingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AttendingProviderPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AttendingProviderSpecialtyInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1221_2 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_3 C_C035_ProviderSpecialtyInformation_3 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_3 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AttendingProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AttendingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_61 C_C040_ReferenceIdentifier_61 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_61 {
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
    public class G_TS837_2310B_1 {
    [XmlElement(Order=0)]
    public S_NM1_OperatingPhysicianName_3 S_NM1_OperatingPhysicianName_3 {get; set;}
    [XmlElement("S_REF_OperatingPhysicianSecondaryIdentification_3",Order=1)]
    public List<S_REF_OperatingPhysicianSecondaryIdentification_3> S_REF_OperatingPhysicianSecondaryIdentification_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OperatingPhysicianName_3 {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OperatingPhysicanMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OperatingPhysicianPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OperatingPhysicianSecondaryIdentification_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OperatingPhysicianSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_62 C_C040_ReferenceIdentifier_62 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_62 {
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
    public class G_TS837_2310C_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherOperatingPhysicianName_3 S_NM1_OtherOperatingPhysicianName_3 {get; set;}
    [XmlElement("S_REF_OtherOperatingPhysicianSecondaryIdentification_3",Order=1)]
    public List<S_REF_OtherOperatingPhysicianSecondaryIdentification_3> S_REF_OtherOperatingPhysicianSecondaryIdentification_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherOperatingPhysicianName_3 {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherOperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherOperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherOperatingPhysicianMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherOperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherOperatingPhysicianIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherOperatingPhysicianSecondaryIdentification_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_63 C_C040_ReferenceIdentifier_63 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_63 {
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
    public class G_TS837_2310D_1 {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName_3 S_NM1_RenderingProviderName_3 {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification_3",Order=1)]
    public List<S_REF_RenderingProviderSecondaryIdentification_3> S_REF_RenderingProviderSecondaryIdentification_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName_3 {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RenderingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RenderingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RenderingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_64 C_C040_ReferenceIdentifier_64 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_64 {
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
    public class G_TS837_2310E_1 {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityLocationName_2 S_NM1_ServiceFacilityLocationName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_ServiceFacilityLocationAddress_2 S_N3_ServiceFacilityLocationAddress_2 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ServiceFacilityLocationCity_State_ZIP_2 S_N4_ServiceFacilityLocationCity_State_ZIP_2 {get; set;}
    [XmlElement("S_REF_ServiceFacilitySecondaryIdentification_2",Order=3)]
    public List<S_REF_ServiceFacilitySecondaryIdentification_2> S_REF_ServiceFacilitySecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceFacilityLocationName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_LaboratoryorFacilityName {get; set;}
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
    public string D_NM109_LaboratoryorFacilityPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_ServiceFacilityLocationAddress_2 {
    [XmlElement(Order=0)]
    public string D_N301_LaboratoryorFacilityAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_LaboratoryorFacilityAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceFacilityLocationCity_State_ZIP_2 {
    [XmlElement(Order=0)]
    public string D_N401_LaboratoryorFacilityCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_LaboratoryorFacilityStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_LaboratoryorFacilityPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceFacilitySecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_22 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LaboratoryorFacilitySecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_65 C_C040_ReferenceIdentifier_65 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_65 {
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
    public class G_TS837_2310F_1 {
    [XmlElement(Order=0)]
    public S_NM1_ReferringProviderName_3 S_NM1_ReferringProviderName_3 {get; set;}
    [XmlElement("S_REF_ReferringProviderSecondaryIdentification_3",Order=1)]
    public List<S_REF_ReferringProviderSecondaryIdentification_3> S_REF_ReferringProviderSecondaryIdentification_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReferringProviderName_3 {
    [XmlElement(Order=0)]
    public X12_ID_98_14 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ReferringProviderLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ReferringProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ReferringProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ReferringProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ReferringProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReferringProviderSecondaryIdentification_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_23 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferringProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_66 C_C040_ReferenceIdentifier_66 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_66 {
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
    public class G_TS837_2320_1 {
    [XmlElement(Order=0)]
    public S_SBR_OtherSubscriberInformation_2 S_SBR_OtherSubscriberInformation_2 {get; set;}
    [XmlElement("S_CAS_ClaimLevelAdjustments_2",Order=1)]
    public List<S_CAS_ClaimLevelAdjustments_2> S_CAS_ClaimLevelAdjustments_2 {get; set;}
    [XmlElement(Order=2)]
    public A_AMT_3 A_AMT_3 {get; set;}
    [XmlElement(Order=3)]
    public S_OI_OtherInsuranceCoverageInformation_2 S_OI_OtherInsuranceCoverageInformation_2 {get; set;}
    [XmlElement(Order=4)]
    public S_MIA_InpatientAdjudicationInformation_2 S_MIA_InpatientAdjudicationInformation_2 {get; set;}
    [XmlElement(Order=5)]
    public S_MOA_OutpatientAdjudicationInformation_2 S_MOA_OutpatientAdjudicationInformation_2 {get; set;}
    [XmlElement(Order=6)]
    public A_NM1_8 A_NM1_8 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SBR_OtherSubscriberInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1138 D_SBR01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1069_2 D_SBR02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SBR03_InsuredGrouporPolicyNumber {get; set;}
    [XmlElement(Order=3)]
    public string D_SBR04_OtherInsuredGroupName {get; set;}
    [XmlElement(Order=4)]
    public string D_SBR05_InsuranceTypeCode {get; set;}
    [XmlElement(Order=5)]
    public string D_SBR06_CoordinationofBenefitsCode {get; set;}
    [XmlElement(Order=6)]
    public string D_SBR07_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=7)]
    public string D_SBR08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SBR09_ClaimFilingIndicatorCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ClaimLevelAdjustments_2 {
    [XmlElement(Order=0)]
    public X12_ID_1033 D_CAS01_ClaimAdjustmentGroupCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CAS02_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CAS03_AdjustmentAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_CAS04_AdjustmentQuantity {get; set;}
    [XmlElement(Order=4)]
    public string D_CAS05_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CAS06_AdjustmentAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_CAS07_AdjustmentQuantity {get; set;}
    [XmlElement(Order=7)]
    public string D_CAS08_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CAS09_AdjustmentAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_CAS10_AdjustmentQuantity {get; set;}
    [XmlElement(Order=10)]
    public string D_CAS11_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=11)]
    public string D_CAS12_AdjustmentAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_CAS13_AdjustmentQuantity {get; set;}
    [XmlElement(Order=13)]
    public string D_CAS14_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=14)]
    public string D_CAS15_AdjustmentAmount {get; set;}
    [XmlElement(Order=15)]
    public string D_CAS16_AdjustmentQuantity {get; set;}
    [XmlElement(Order=16)]
    public string D_CAS17_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CAS18_AdjustmentAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_CAS19_AdjustmentQuantity {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_AMT_3 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_CoordinationofBenefits_COB_PayerPaidAmount_2 S_AMT_CoordinationofBenefits_COB_PayerPaidAmount_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_RemainingPatientLiability_3 S_AMT_RemainingPatientLiability_3 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_AMT_CoordinationofBenefits_COB_TotalNon_coveredAmount_2 S_AMT_CoordinationofBenefits_COB_TotalNon_coveredAmount_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationofBenefits_COB_PayerPaidAmount_2 {
    [XmlElement(Order=0)]
    public X12_ID_522_2 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PayerPaidAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_RemainingPatientLiability_3 {
    [XmlElement(Order=0)]
    public X12_ID_522_3 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_RemainingPatientLiability {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationofBenefits_COB_TotalNon_coveredAmount_2 {
    [XmlElement(Order=0)]
    public X12_ID_522_4 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_Non_CoveredChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_OI_OtherInsuranceCoverageInformation_2 {
    [XmlElement(Order=0)]
    public string D_OI01_ClaimFilingIndicatorCode {get; set;}
    [XmlElement(Order=1)]
    public string D_OI02_ClaimSubmissionReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_OI03_BenefitsAssignmentCertificationIndicator {get; set;}
    [XmlElement(Order=3)]
    public string D_OI04_PatientSignatureSourceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_OI05_ProviderAgreementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_OI06_ReleaseofInformationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MIA_InpatientAdjudicationInformation_2 {
    [XmlElement(Order=0)]
    public string D_MIA01_CoveredDaysorVisitsCount {get; set;}
    [XmlElement(Order=1)]
    public string D_MIA02_MonetaryAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MIA03_LifetimePsychiatricDaysCount {get; set;}
    [XmlElement(Order=3)]
    public string D_MIA04_ClaimDRGAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_MIA05_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MIA06_ClaimDisproportionateShareAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_MIA07_ClaimMSPPass_throughAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_MIA08_ClaimPPSCapitalAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MIA09_PPS_CapitalFSPDRGAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_MIA10_PPS_CapitalHSPDRGAmount {get; set;}
    [XmlElement(Order=10)]
    public string D_MIA11_PPS_CapitalDSHDRGAmount {get; set;}
    [XmlElement(Order=11)]
    public string D_MIA12_OldCapitalAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_MIA13_PPS_CapitalIMEamount {get; set;}
    [XmlElement(Order=13)]
    public string D_MIA14_PPS_OperatingHospitalSpecificDRGAmount {get; set;}
    [XmlElement(Order=14)]
    public string D_MIA15_CostReportDayCount {get; set;}
    [XmlElement(Order=15)]
    public string D_MIA16_PPS_OperatingFederalSpecificDRGAmount {get; set;}
    [XmlElement(Order=16)]
    public string D_MIA17_ClaimPPSCapitalOutlierAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_MIA18_ClaimIndirectTeachingAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_MIA19_NonpayableProfessionalComponentAmount {get; set;}
    [XmlElement(Order=19)]
    public string D_MIA20_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=20)]
    public string D_MIA21_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=21)]
    public string D_MIA22_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=22)]
    public string D_MIA23_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=23)]
    public string D_MIA24_PPS_CapitalExceptionAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MOA_OutpatientAdjudicationInformation_2 {
    [XmlElement(Order=0)]
    public string D_MOA01_ReimbursementRate {get; set;}
    [XmlElement(Order=1)]
    public string D_MOA02_HCPCSPayableAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MOA03_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=3)]
    public string D_MOA04_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=4)]
    public string D_MOA05_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MOA06_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=6)]
    public string D_MOA07_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=7)]
    public string D_MOA08_EndStageRenalDiseasePaymentAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MOA09_NonpayableProfessionalComponentAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_8 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2330A_1 G_TS837_2330A_1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2330B_1 G_TS837_2330B_1 {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2330C_1 G_TS837_2330C_1 {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837_2330D_1 G_TS837_2330D_1 {get; set;}
    [XmlElementAttribute(Order=4)]
    public G_TS837_2330E_1 G_TS837_2330E_1 {get; set;}
    [XmlElementAttribute(Order=5)]
    public G_TS837_2330F_1 G_TS837_2330F_1 {get; set;}
    [XmlElementAttribute(Order=6)]
    public G_TS837_2330G_1 G_TS837_2330G_1 {get; set;}
    [XmlElementAttribute(Order=7)]
    public G_TS837_2330H_1 G_TS837_2330H_1 {get; set;}
    [XmlElementAttribute(Order=8)]
    public G_TS837_2330I_1 G_TS837_2330I_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2330A_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherSubscriberName_2 S_NM1_OtherSubscriberName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherSubscriberAddress_2 S_N3_OtherSubscriberAddress_2 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherSubscriberCity_State_ZIPCode_2 S_N4_OtherSubscriberCity_State_ZIPCode_2 {get; set;}
    [XmlElement("S_REF_OtherSubscriberSecondaryInformation_2",Order=3)]
    public List<S_REF_OtherSubscriberSecondaryInformation_2> S_REF_OtherSubscriberSecondaryInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherSubscriberName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_7 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherInsuredLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherInsuredFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherInsuredMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherInsuredNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherInsuredIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_OtherSubscriberAddress_2 {
    [XmlElement(Order=0)]
    public string D_N301_OtherInsuredAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_OtherInsuredAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_OtherSubscriberCity_State_ZIPCode_2 {
    [XmlElement(Order=0)]
    public string D_N401_OtherInsuredCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_OtherInsuredStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_OtherInsuredPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherSubscriberSecondaryInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherInsuredAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_67 C_C040_ReferenceIdentifier_67 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_67 {
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
    public class G_TS837_2330B_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerName_2 S_NM1_OtherPayerName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherPayerAddress_2 S_N3_OtherPayerAddress_2 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherPayerCity_State_ZIPCode_2 S_N4_OtherPayerCity_State_ZIPCode_2 {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_ClaimCheckOrRemittanceDate_2 S_DTP_ClaimCheckOrRemittanceDate_2 {get; set;}
    [XmlElement(Order=4)]
    public A_REF_9 A_REF_9 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherPayerLastorOrganizationName {get; set;}
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
    public string D_NM109_OtherPayerPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_OtherPayerAddress_2 {
    [XmlElement(Order=0)]
    public string D_N301_OtherPayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_OtherPayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_OtherPayerCity_State_ZIPCode_2 {
    [XmlElement(Order=0)]
    public string D_N401_OtherPayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_OtherPayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_OtherPayerPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_CountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimCheckOrRemittanceDate_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdjudicationorPaymentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_9 {
    [XmlElement(Order=0)]
    public U_REF_OtherPayerSecondaryIdentifier_2 U_REF_OtherPayerSecondaryIdentifier_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_OtherPayerPriorAuthorizationNumber_2 S_REF_OtherPayerPriorAuthorizationNumber_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_OtherPayerReferralNumber_2 S_REF_OtherPayerReferralNumber_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_OtherPayerClaimAdjustmentIndicator_2 S_REF_OtherPayerClaimAdjustmentIndicator_2 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_OtherPayerClaimControlNumber_2 S_REF_OtherPayerClaimControlNumber_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerSecondaryIdentifier_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_68 C_C040_ReferenceIdentifier_68 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_68 {
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
    public class S_REF_OtherPayerPriorAuthorizationNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationorReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_69 C_C040_ReferenceIdentifier_69 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_69 {
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
    public class S_REF_OtherPayerReferralNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_10 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationorReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_70 C_C040_ReferenceIdentifier_70 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_70 {
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
    public class S_REF_OtherPayerClaimAdjustmentIndicator_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_24 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerClaimAdjustmentIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_71 C_C040_ReferenceIdentifier_71 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_71 {
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
    public class S_REF_OtherPayerClaimControlNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_12 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayer_sClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_72 C_C040_ReferenceIdentifier_72 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_72 {
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
    public class G_TS837_2330C_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerAttendingProvider_2 S_NM1_OtherPayerAttendingProvider_2 {get; set;}
    [XmlElement("S_REF_OtherPayerAttendingProviderSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerAttendingProviderSecondaryIdentification_2> S_REF_OtherPayerAttendingProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerAttendingProvider_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerAttendingProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerAttendingProviderSecondary_Identifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_73 C_C040_ReferenceIdentifier_73 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_73 {
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
    public class G_TS837_2330D_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerOperatingPhysician_2 S_NM1_OtherPayerOperatingPhysician_2 {get; set;}
    [XmlElement("S_REF_OtherPayerOperatingPhysicianSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerOperatingPhysicianSecondaryIdentification_2> S_REF_OtherPayerOperatingPhysicianSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerOperatingPhysician_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerOperatingPhysicianSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerAttendingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_74 C_C040_ReferenceIdentifier_74 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_74 {
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
    public class G_TS837_2330E_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerOtherOperatingPhysician_2 S_NM1_OtherPayerOtherOperatingPhysician_2 {get; set;}
    [XmlElement("S_REF_OtherPayerOtherOperatingPhysicianSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerOtherOperatingPhysicianSecondaryIdentification_2> S_REF_OtherPayerOtherOperatingPhysicianSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerOtherOperatingPhysician_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerOtherOperatingPhysicianSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerOperatingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_75 C_C040_ReferenceIdentifier_75 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_75 {
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
    public class G_TS837_2330F_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerServiceFacilityLocation_2 S_NM1_OtherPayerServiceFacilityLocation_2 {get; set;}
    [XmlElement("S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification_2> S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerServiceFacilityLocation_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_22 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerOtherOperatingPhysicianIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_76 C_C040_ReferenceIdentifier_76 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_76 {
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
    public class G_TS837_2330G_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerRenderingProviderName_2 S_NM1_OtherPayerRenderingProviderName_2 {get; set;}
    [XmlElement("S_REF_OtherPayerRenderingProviderSecondaryIdentifier_2",Order=1)]
    public List<S_REF_OtherPayerRenderingProviderSecondaryIdentifier_2> S_REF_OtherPayerRenderingProviderSecondaryIdentifier_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerRenderingProviderName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerRenderingProviderSecondaryIdentifier_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerRenderingProviderSecondary_Identifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_77 C_C040_ReferenceIdentifier_77 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_77 {
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
    public class G_TS837_2330H_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerReferringProvider_2 S_NM1_OtherPayerReferringProvider_2 {get; set;}
    [XmlElement("S_REF_OtherPayerReferringProviderSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerReferringProviderSecondaryIdentification_2> S_REF_OtherPayerReferringProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerReferringProvider_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_14 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerReferringProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_23 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerReferringProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_78 C_C040_ReferenceIdentifier_78 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_78 {
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
    public class G_TS837_2330I_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerBillingProvider_2 S_NM1_OtherPayerBillingProvider_2 {get; set;}
    [XmlElement("S_REF_OtherPayerBillingProviderSecondaryIdentifier_2",Order=1)]
    public List<S_REF_OtherPayerBillingProviderSecondaryIdentifier_2> S_REF_OtherPayerBillingProviderSecondaryIdentifier_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerBillingProvider_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_NameLastorOrganizationName {get; set;}
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
    public string D_NM109_IdentificationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerBillingProviderSecondaryIdentifier_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerBillingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_79 C_C040_ReferenceIdentifier_79 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_79 {
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
    public class G_TS837_2400_1 {
    [XmlElement(Order=0)]
    public S_LX_ServiceLineNumber_2 S_LX_ServiceLineNumber_2 {get; set;}
    [XmlElement(Order=1)]
    public S_SV2_InstitutionalServiceLine_2 S_SV2_InstitutionalServiceLine_2 {get; set;}
    [XmlElement("S_PWK_LineSupplementalInformation_2",Order=2)]
    public List<S_PWK_LineSupplementalInformation_2> S_PWK_LineSupplementalInformation_2 {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_Date_ServiceDate_2 S_DTP_Date_ServiceDate_2 {get; set;}
    [XmlElement(Order=4)]
    public A_REF_10 A_REF_10 {get; set;}
    [XmlElement(Order=5)]
    public A_AMT_4 A_AMT_4 {get; set;}
    [XmlElement(Order=6)]
    public S_NTE_ThirdPartyOrganizationNotes_2 S_NTE_ThirdPartyOrganizationNotes_2 {get; set;}
    [XmlElement(Order=7)]
    public S_HCP_LinePricing_RepricingInformation_2 S_HCP_LinePricing_RepricingInformation_2 {get; set;}
    [XmlElement(Order=8)]
    public G_TS837_2410_1 G_TS837_2410_1 {get; set;}
    [XmlElement(Order=9)]
    public A_NM1_9 A_NM1_9 {get; set;}
    [XmlElement("G_TS837_2430_1",Order=10)]
    public List<G_TS837_2430_1> G_TS837_2430_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_ServiceLineNumber_2 {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SV2_InstitutionalServiceLine_2 {
    [XmlElement(Order=0)]
    public string D_SV201_ServiceLineRevenueCode {get; set;}
    [XmlElement(Order=1)]
    public C_C003_CompositeMedicalProcedureIdentifier_3 C_C003_CompositeMedicalProcedureIdentifier_3 {get; set;}
    [XmlElement(Order=2)]
    public string D_SV203_LineItemChargeAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SV204_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SV205_ServiceUnitCount {get; set;}
    [XmlElement(Order=5)]
    public string D_SV206_UnitRate {get; set;}
    [XmlElement(Order=6)]
    public string D_SV207_LineItemDeniedChargeorNon_CoveredChargeAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_SV208_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SV209_NursingHomeResidentialStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV210_LevelofCareCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_3 {
    [XmlElement(Order=0)]
    public X12_ID_235_2 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public class S_PWK_LineSupplementalInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_755 D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_756 D_PWK02_AttachmentTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03_ReportCopiesNeeded {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_Description {get; set;}
    [XmlElement(Order=7)]
    public C_C002_ActionsIndicated_4 C_C002_ActionsIndicated_4 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09_RequestCategoryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C002_ActionsIndicated_4 {
    [XmlElement(Order=0)]
    public string D_C00201_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00202_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00203_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C00204_Paperwork_ReportActionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00205_Paperwork_ReportActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_ServiceDate_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_7 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_6 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_10 {
    [XmlElementAttribute(Order=0)]
    public S_REF_LineItemControlNumber_2 S_REF_LineItemControlNumber_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_RepricedLineItemReferenceNumber_2 S_REF_RepricedLineItemReferenceNumber_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_AdjustedRepricedLineItemReferenceNumber_2 S_REF_AdjustedRepricedLineItemReferenceNumber_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_LineItemControlNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_25 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_80 C_C040_ReferenceIdentifier_80 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_80 {
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
    public class S_REF_RepricedLineItemReferenceNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_26 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedLineItemReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_81 C_C040_ReferenceIdentifier_81 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_81 {
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
    public class S_REF_AdjustedRepricedLineItemReferenceNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_27 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedLineItemReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_82 C_C040_ReferenceIdentifier_82 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_82 {
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
    public class A_AMT_4 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_ServiceTaxAmount_2 S_AMT_ServiceTaxAmount_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_FacilityTaxAmount_2 S_AMT_FacilityTaxAmount_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ServiceTaxAmount_2 {
    [XmlElement(Order=0)]
    public X12_ID_522_5 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ServiceTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_FacilityTaxAmount_2 {
    [XmlElement(Order=0)]
    public X12_ID_522_6 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_FacilityTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_ThirdPartyOrganizationNotes_2 {
    [XmlElement(Order=0)]
    public X12_ID_363_3 D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_LineNoteText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HCP_LinePricing_RepricingInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1473 D_HCP01_PricingMethodology {get; set;}
    [XmlElement(Order=1)]
    public string D_HCP02_MonetaryAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_HCP03_MonetaryAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_HCP04_ReferenceIdentification {get; set;}
    [XmlElement(Order=4)]
    public string D_HCP05_Rate {get; set;}
    [XmlElement(Order=5)]
    public string D_HCP06_ReferenceIdentification {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_ProductorServiceID {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_ProductorServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_RepricedApprovedHCPCSCode {get; set;}
    [XmlElement(Order=10)]
    public string D_HCP11_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=11)]
    public string D_HCP12_Quantity {get; set;}
    [XmlElement(Order=12)]
    public string D_HCP13_RejectReasonCode {get; set;}
    [XmlElement(Order=13)]
    public string D_HCP14_PolicyComplianceCode {get; set;}
    [XmlElement(Order=14)]
    public string D_HCP15_ExceptionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2410_1 {
    [XmlElement(Order=0)]
    public S_LIN_DrugIdentification_2 S_LIN_DrugIdentification_2 {get; set;}
    [XmlElement(Order=1)]
    public S_CTP_DrugQuantity_2 S_CTP_DrugQuantity_2 {get; set;}
    [XmlElement(Order=2)]
    public S_REF_PrescriptionorCompoundDrugAssociationNumber_2 S_REF_PrescriptionorCompoundDrugAssociationNumber_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LIN_DrugIdentification_2 {
    [XmlElement(Order=0)]
    public string D_LIN01_AssignedIdentification {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_235_3 D_LIN02_ProductorServiceIDQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_LIN03_NationalDrugCode {get; set;}
    [XmlElement(Order=3)]
    public string D_LIN04_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=4)]
    public string D_LIN05_Product_ServiceID {get; set;}
    [XmlElement(Order=5)]
    public string D_LIN06_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_LIN07_Product_ServiceID {get; set;}
    [XmlElement(Order=7)]
    public string D_LIN08_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_LIN09_Product_ServiceID {get; set;}
    [XmlElement(Order=9)]
    public string D_LIN10_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=10)]
    public string D_LIN11_Product_ServiceID {get; set;}
    [XmlElement(Order=11)]
    public string D_LIN12_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=12)]
    public string D_LIN13_Product_ServiceID {get; set;}
    [XmlElement(Order=13)]
    public string D_LIN14_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=14)]
    public string D_LIN15_Product_ServiceID {get; set;}
    [XmlElement(Order=15)]
    public string D_LIN16_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=16)]
    public string D_LIN17_Product_ServiceID {get; set;}
    [XmlElement(Order=17)]
    public string D_LIN18_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=18)]
    public string D_LIN19_Product_ServiceID {get; set;}
    [XmlElement(Order=19)]
    public string D_LIN20_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=20)]
    public string D_LIN21_Product_ServiceID {get; set;}
    [XmlElement(Order=21)]
    public string D_LIN22_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=22)]
    public string D_LIN23_Product_ServiceID {get; set;}
    [XmlElement(Order=23)]
    public string D_LIN24_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=24)]
    public string D_LIN25_Product_ServiceID {get; set;}
    [XmlElement(Order=25)]
    public string D_LIN26_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=26)]
    public string D_LIN27_Product_ServiceID {get; set;}
    [XmlElement(Order=27)]
    public string D_LIN28_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=28)]
    public string D_LIN29_Product_ServiceID {get; set;}
    [XmlElement(Order=29)]
    public string D_LIN30_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=30)]
    public string D_LIN31_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CTP_DrugQuantity_2 {
    [XmlElement(Order=0)]
    public string D_CTP01_ClassofTradeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CTP02_PriceIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CTP03_UnitPrice {get; set;}
    [XmlElement(Order=3)]
    public string D_CTP04_NationalDrugUnitCount {get; set;}
    [XmlElement(Order=4)]
    public C_C001_CompositeUnitofMeasure_4 C_C001_CompositeUnitofMeasure_4 {get; set;}
    [XmlElement(Order=5)]
    public string D_CTP06_PriceMultiplierQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_CTP07_Multiplier {get; set;}
    [XmlElement(Order=7)]
    public string D_CTP08_MonetaryAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_CTP09_BasisofUnitPriceCode {get; set;}
    [XmlElement(Order=9)]
    public string D_CTP10_ConditionValue {get; set;}
    [XmlElement(Order=10)]
    public string D_CTP11_MultiplePriceQuantity {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C001_CompositeUnitofMeasure_4 {
    [XmlElement(Order=0)]
    public string D_C00101_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00102_Exponent {get; set;}
    [XmlElement(Order=2)]
    public string D_C00103_Multiplier {get; set;}
    [XmlElement(Order=3)]
    public string D_C00104_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00105_Exponent {get; set;}
    [XmlElement(Order=5)]
    public string D_C00106_Multiplier {get; set;}
    [XmlElement(Order=6)]
    public string D_C00107_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=7)]
    public string D_C00108_Exponent {get; set;}
    [XmlElement(Order=8)]
    public string D_C00109_Multiplier {get; set;}
    [XmlElement(Order=9)]
    public string D_C00110_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=10)]
    public string D_C00111_Exponent {get; set;}
    [XmlElement(Order=11)]
    public string D_C00112_Multiplier {get; set;}
    [XmlElement(Order=12)]
    public string D_C00113_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=13)]
    public string D_C00114_Exponent {get; set;}
    [XmlElement(Order=14)]
    public string D_C00115_Multiplier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PrescriptionorCompoundDrugAssociationNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_28 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PrescriptionNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_83 C_C040_ReferenceIdentifier_83 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_83 {
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
    public class A_NM1_9 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2420A_1 G_TS837_2420A_1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2420B_1 G_TS837_2420B_1 {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2420C_1 G_TS837_2420C_1 {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837_2420D_1 G_TS837_2420D_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2420A_1 {
    [XmlElement(Order=0)]
    public S_NM1_OperatingPhysicianName_4 S_NM1_OperatingPhysicianName_4 {get; set;}
    [XmlElement("S_REF_OperatingPhysicianSecondaryIdentification_4",Order=1)]
    public List<S_REF_OperatingPhysicianSecondaryIdentification_4> S_REF_OperatingPhysicianSecondaryIdentification_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OperatingPhysicianName_4 {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OperatingPhysicanMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OperatingPhysicianPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OperatingPhysicianSecondaryIdentification_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OperatingPhysicianSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_84 C_C040_ReferenceIdentifier_84 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_84 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherPayerPrimaryIdentifier {get; set;}
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
    public class G_TS837_2420B_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherOperatingPhysicianName_4 S_NM1_OtherOperatingPhysicianName_4 {get; set;}
    [XmlElement("S_REF_OtherOperatingPhysicianSecondaryIdentification_4",Order=1)]
    public List<S_REF_OtherOperatingPhysicianSecondaryIdentification_4> S_REF_OtherOperatingPhysicianSecondaryIdentification_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherOperatingPhysicianName_4 {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherOperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherOperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherOperatingPhysicianMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherOperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherOperatingPhysicianIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherOperatingPhysicianSecondaryIdentification_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_85 C_C040_ReferenceIdentifier_85 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_85 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherPayerPrimaryIdentifier {get; set;}
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
    public class G_TS837_2420C_1 {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName_4 S_NM1_RenderingProviderName_4 {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification_4",Order=1)]
    public List<S_REF_RenderingProviderSecondaryIdentification_4> S_REF_RenderingProviderSecondaryIdentification_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName_4 {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RenderingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RenderingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RenderingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_86 C_C040_ReferenceIdentifier_86 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_86 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherPayerPrimaryIdentifier {get; set;}
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
    public class G_TS837_2420D_1 {
    [XmlElement(Order=0)]
    public S_NM1_ReferringProviderName_4 S_NM1_ReferringProviderName_4 {get; set;}
    [XmlElement("S_REF_ReferringProviderSecondaryIdentification_4",Order=1)]
    public List<S_REF_ReferringProviderSecondaryIdentification_4> S_REF_ReferringProviderSecondaryIdentification_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReferringProviderName_4 {
    [XmlElement(Order=0)]
    public X12_ID_98_14 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ReferringProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ReferringProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ReferringProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ReferringProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ReferringProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReferringProviderSecondaryIdentification_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_23 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferringProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_87 C_C040_ReferenceIdentifier_87 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_87 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherPayerPrimaryIdentifier {get; set;}
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
    public class G_TS837_2430_1 {
    [XmlElement(Order=0)]
    public S_SVD_LineAdjudicationInformation_2 S_SVD_LineAdjudicationInformation_2 {get; set;}
    [XmlElement("S_CAS_LineAdjustment_2",Order=1)]
    public List<S_CAS_LineAdjustment_2> S_CAS_LineAdjustment_2 {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_LineCheckorRemittanceDate_2 S_DTP_LineCheckorRemittanceDate_2 {get; set;}
    [XmlElement(Order=3)]
    public S_AMT_RemainingPatientLiability_4 S_AMT_RemainingPatientLiability_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVD_LineAdjudicationInformation_2 {
    [XmlElement(Order=0)]
    public string D_SVD01_OtherPayerPrimaryIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVD02_ServiceLinePaidAmount {get; set;}
    [XmlElement(Order=2)]
    public C_C003_CompositeMedicalProcedureIdentifier_4 C_C003_CompositeMedicalProcedureIdentifier_4 {get; set;}
    [XmlElement(Order=3)]
    public string D_SVD04_Product_ServiceID {get; set;}
    [XmlElement(Order=4)]
    public string D_SVD05_PaidServiceUnitCount {get; set;}
    [XmlElement(Order=5)]
    public string D_SVD06_BundledorUnbundledLineNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_4 {
    [XmlElement(Order=0)]
    public string D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00307_ProcedureCodeDescription {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_LineAdjustment_2 {
    [XmlElement(Order=0)]
    public X12_ID_1033 D_CAS01_ClaimAdjustmentGroupCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CAS02_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CAS03_AdjustmentAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_CAS04_AdjustmentQuantity {get; set;}
    [XmlElement(Order=4)]
    public string D_CAS05_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CAS06_AdjustmentAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_CAS07_AdjustmentQuantity {get; set;}
    [XmlElement(Order=7)]
    public string D_CAS08_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CAS09_AdjustmentAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_CAS10_AdjustmentQuantity {get; set;}
    [XmlElement(Order=10)]
    public string D_CAS11_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=11)]
    public string D_CAS12_AdjustmentAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_CAS13_AdjustmentQuantity {get; set;}
    [XmlElement(Order=13)]
    public string D_CAS14_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=14)]
    public string D_CAS15_AdjustmentAmount {get; set;}
    [XmlElement(Order=15)]
    public string D_CAS16_AdjustmentQuantity {get; set;}
    [XmlElement(Order=16)]
    public string D_CAS17_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CAS18_AdjustmentAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_CAS19_AdjustmentQuantity {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LineCheckorRemittanceDate_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdjudicationorPaymentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_RemainingPatientLiability_4 {
    [XmlElement(Order=0)]
    public X12_ID_522_3 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_RemainingPatientLiability {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SE {
    [XmlElement(Order=0)]
    public string D_SE01_TransactionSegmentCount {get; set;}
    [XmlElement(Order=1)]
    public string D_SE02_TransactionSetControlNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PayerSecondaryIdentification {
    [XmlElement("S_REF_PayerSecondaryIdentification",Order=0)]
    public List<S_REF_PayerSecondaryIdentification> S_REF_PayerSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_InvestigationalDeviceExemptionNumber {
    [XmlElement("S_REF_InvestigationalDeviceExemptionNumber",Order=0)]
    public List<S_REF_InvestigationalDeviceExemptionNumber> S_REF_InvestigationalDeviceExemptionNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_NTE_ClaimNote {
    [XmlElement("S_NTE_ClaimNote",Order=0)]
    public List<S_NTE_ClaimNote> S_NTE_ClaimNote {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OtherDiagnosisInformation {
    [XmlElement("S_HI_OtherDiagnosisInformation",Order=0)]
    public List<S_HI_OtherDiagnosisInformation> S_HI_OtherDiagnosisInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OtherProcedureInformation {
    [XmlElement("S_HI_OtherProcedureInformation",Order=0)]
    public List<S_HI_OtherProcedureInformation> S_HI_OtherProcedureInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OccurrenceSpanInformation {
    [XmlElement("S_HI_OccurrenceSpanInformation",Order=0)]
    public List<S_HI_OccurrenceSpanInformation> S_HI_OccurrenceSpanInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OccurrenceInformation {
    [XmlElement("S_HI_OccurrenceInformation",Order=0)]
    public List<S_HI_OccurrenceInformation> S_HI_OccurrenceInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_ValueInformation {
    [XmlElement("S_HI_ValueInformation",Order=0)]
    public List<S_HI_ValueInformation> S_HI_ValueInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_ConditionInformation {
    [XmlElement("S_HI_ConditionInformation",Order=0)]
    public List<S_HI_ConditionInformation> S_HI_ConditionInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_TreatmentCodeInformation {
    [XmlElement("S_HI_TreatmentCodeInformation",Order=0)]
    public List<S_HI_TreatmentCodeInformation> S_HI_TreatmentCodeInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherPayerSecondaryIdentifier {
    [XmlElement("S_REF_OtherPayerSecondaryIdentifier",Order=0)]
    public List<S_REF_OtherPayerSecondaryIdentifier> S_REF_OtherPayerSecondaryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_InvestigationalDeviceExemptionNumber_2 {
    [XmlElement("S_REF_InvestigationalDeviceExemptionNumber_2",Order=0)]
    public List<S_REF_InvestigationalDeviceExemptionNumber_2> S_REF_InvestigationalDeviceExemptionNumber_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_NTE_ClaimNote_2 {
    [XmlElement("S_NTE_ClaimNote_2",Order=0)]
    public List<S_NTE_ClaimNote_2> S_NTE_ClaimNote_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OtherDiagnosisInformation_2 {
    [XmlElement("S_HI_OtherDiagnosisInformation_2",Order=0)]
    public List<S_HI_OtherDiagnosisInformation_2> S_HI_OtherDiagnosisInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OtherProcedureInformation_2 {
    [XmlElement("S_HI_OtherProcedureInformation_2",Order=0)]
    public List<S_HI_OtherProcedureInformation_2> S_HI_OtherProcedureInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OccurrenceSpanInformation_2 {
    [XmlElement("S_HI_OccurrenceSpanInformation_2",Order=0)]
    public List<S_HI_OccurrenceSpanInformation_2> S_HI_OccurrenceSpanInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OccurrenceInformation_2 {
    [XmlElement("S_HI_OccurrenceInformation_2",Order=0)]
    public List<S_HI_OccurrenceInformation_2> S_HI_OccurrenceInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_ValueInformation_2 {
    [XmlElement("S_HI_ValueInformation_2",Order=0)]
    public List<S_HI_ValueInformation_2> S_HI_ValueInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_ConditionInformation_2 {
    [XmlElement("S_HI_ConditionInformation_2",Order=0)]
    public List<S_HI_ConditionInformation_2> S_HI_ConditionInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_TreatmentCodeInformation_2 {
    [XmlElement("S_HI_TreatmentCodeInformation_2",Order=0)]
    public List<S_HI_TreatmentCodeInformation_2> S_HI_TreatmentCodeInformation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherPayerSecondaryIdentifier_2 {
    [XmlElement("S_REF_OtherPayerSecondaryIdentifier_2",Order=0)]
    public List<S_REF_OtherPayerSecondaryIdentifier_2> S_REF_OtherPayerSecondaryIdentifier_2 {get; set;}
    }
}
