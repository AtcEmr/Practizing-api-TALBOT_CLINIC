namespace EdiFabric.Rules.X12005010X224A2837 {
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
    public string D_ST03_ImplementationGuideVersionName {get; set;}
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
    public string D_BHT06_ClaimorEncounterIdentifier {get; set;}
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
    public A_REF A_REF {get; set;}
    [XmlElement("S_PER_BillingProviderContactInformation",Order=4)]
    public List<S_PER_BillingProviderContactInformation> S_PER_BillingProviderContactInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_BillingProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_BillingProviderLastorOrganizationalName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_BillingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_BillingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_BillingProviderNameSuffix {get; set;}
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
    public class A_REF {
    [XmlElementAttribute(Order=0)]
    public S_REF_BillingProviderTaxIdentification S_REF_BillingProviderTaxIdentification {get; set;}
    [XmlElement(Order=1)]
    public U_REF_BillingProviderUPIN_LicenseInformation U_REF_BillingProviderUPIN_LicenseInformation {get; set;}
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
        SY,
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
    public class S_REF_BillingProviderUPIN_LicenseInformation {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderLicenseand_orUPINInformation {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2 C_C040_ReferenceIdentifier_2 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
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
    public S_N3_Pay_toAddress_ADDRESS S_N3_Pay_toAddress_ADDRESS {get; set;}
    [XmlElement(Order=2)]
    public S_N4_Pay_toAddress_City_State_ZIPCode S_N4_Pay_toAddress_City_State_ZIPCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_Pay_toAddressName {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_Pay_toAddressLastorOrganizationalName {get; set;}
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
    public class S_N3_Pay_toAddress_ADDRESS {
    [XmlElement(Order=0)]
    public string D_N301_Pay_toAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_Pay_toAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_Pay_toAddress_City_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_Pay_toAddressCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_Pay_ToAddressStateorProvinceCode {get; set;}
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
    public A_REF_2 A_REF_2 {get; set;}
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
    public class A_REF_2 {
    [XmlElementAttribute(Order=0)]
    public S_REF_Pay_ToPlanSecondaryIdentification S_REF_Pay_ToPlanSecondaryIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_Pay_ToPlanTaxIdentificationNumber S_REF_Pay_ToPlanTaxIdentificationNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_Pay_ToPlanSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_Pay_toPlanSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3 C_C040_ReferenceIdentifier_3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
        [XmlEnum("2U")]
        Item2U,
        FY,
        NF,
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
    public class S_REF_Pay_ToPlanTaxIdentificationNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_Pay_ToPlanTaxIdentificationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4 C_C040_ReferenceIdentifier_4 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        EI,
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
    public A_REF_3 A_REF_3 {get; set;}
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
    public class A_REF_3 {
    [XmlElementAttribute(Order=0)]
    public S_REF_SubscriberSecondaryIdentification S_REF_SubscriberSecondaryIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PropertyandCasualtyClaimNumber S_REF_PropertyandCasualtyClaimNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5 C_C040_ReferenceIdentifier_5 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_7 {
        SY,
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
    public class S_REF_PropertyandCasualtyClaimNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyCasualtyClaimNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_6 C_C040_ReferenceIdentifier_6 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_8 {
        Y4,
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
    public class G_TS837_2010BB {
    [XmlElement(Order=0)]
    public S_NM1_PayerName S_NM1_PayerName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayerAddress S_N3_PayerAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayerCity_State_ZIPCode S_N4_PayerCity_State_ZIPCode {get; set;}
    [XmlElement(Order=3)]
    public A_REF_4 A_REF_4 {get; set;}
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
    public class A_REF_4 {
    [XmlElement(Order=0)]
    public U_REF_PayerSecondaryIdentification U_REF_PayerSecondaryIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_BillingProviderSecondaryIdentification S_REF_BillingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_7 C_C040_ReferenceIdentifier_7 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_9 {
        [XmlEnum("2U")]
        Item2U,
        EI,
        FY,
        NF,
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
    public class S_REF_BillingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_10 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_8 C_C040_ReferenceIdentifier_8 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_10 {
        G2,
        LU,
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
    public class G_TS837_2300 {
    [XmlElement(Order=0)]
    public S_CLM_ClaimInformation S_CLM_ClaimInformation {get; set;}
    [XmlElement(Order=1)]
    public A_DTP A_DTP {get; set;}
    [XmlElement(Order=2)]
    public S_DN1_OrthodonticTotalMonthsofTreatment S_DN1_OrthodonticTotalMonthsofTreatment {get; set;}
    [XmlElement("S_DN2_ToothStatus",Order=3)]
    public List<S_DN2_ToothStatus> S_DN2_ToothStatus {get; set;}
    [XmlElement("S_PWK_ClaimSupplementalInformation",Order=4)]
    public List<S_PWK_ClaimSupplementalInformation> S_PWK_ClaimSupplementalInformation {get; set;}
    [XmlElement(Order=5)]
    public S_CN1_ContractInformation S_CN1_ContractInformation {get; set;}
    [XmlElement(Order=6)]
    public S_AMT_PatientAmountPaid S_AMT_PatientAmountPaid {get; set;}
    [XmlElement(Order=7)]
    public A_REF_5 A_REF_5 {get; set;}
    [XmlElement("S_K3_FileInformation",Order=8)]
    public List<S_K3_FileInformation> S_K3_FileInformation {get; set;}
    [XmlElement("S_NTE_ClaimNote",Order=9)]
    public List<S_NTE_ClaimNote> S_NTE_ClaimNote {get; set;}
    [XmlElement(Order=10)]
    public S_HI_HealthCareDiagnosisCode S_HI_HealthCareDiagnosisCode {get; set;}
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
    public class S_CLM_ClaimInformation {
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
    public string D_CLM12_SpecialProgramIndicator {get; set;}
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
    public string D_CLM19_PredeterminationofBenefitsCode {get; set;}
    [XmlElement(Order=19)]
    public string D_CLM20_DelayReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C023_HealthCareServiceLocationInformation {
    [XmlElement(Order=0)]
    public string D_C02301_PlaceofServiceCode {get; set;}
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
    public string D_C02402_RelatedCausesCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02403_Related_CausesCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C02404_AutoAccidentStateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C02405_CountryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP {
    [XmlElementAttribute(Order=0)]
    public S_DTP_Date_Accident S_DTP_Date_Accident {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_Date_AppliancePlacement S_DTP_Date_AppliancePlacement {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_Date_ServiceDate S_DTP_Date_ServiceDate {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_Date_RepricerReceivedDate S_DTP_Date_RepricerReceivedDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_Accident {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_2 {
        [XmlEnum("439")]
        Item439,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_AppliancePlacement {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OrthodonticBandingDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_3 {
        [XmlEnum("452")]
        Item452,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_ServiceDate {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_2 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_4 {
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
    public class S_DN1_OrthodonticTotalMonthsofTreatment {
    [XmlElement(Order=0)]
    public string D_DN101_OrthodonticTreatmentMonthsCount {get; set;}
    [XmlElement(Order=1)]
    public string D_DN102_OrthodonticTreatmentMonthsRemainingCount {get; set;}
    [XmlElement(Order=2)]
    public string D_DN103_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DN104_OrthodonticTreatmentIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DN2_ToothStatus {
    [XmlElement(Order=0)]
    public string D_DN201_ToothNumber {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1368 D_DN202_ToothStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_DN203_Quantity {get; set;}
    [XmlElement(Order=3)]
    public string D_DN204_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=4)]
    public string D_DN205_DateTimePeriod {get; set;}
    [XmlElement(Order=5)]
    public string D_DN206_CodeListQualifierCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1368 {
        E,
        M,
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
        B4,
        DA,
        DG,
        EB,
        OZ,
        P6,
        RB,
        RR,
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
    public class S_AMT_PatientAmountPaid {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PatientAmountPaid {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522 {
        F5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_5 {
    [XmlElementAttribute(Order=0)]
    public S_REF_PredeterminationIdentification S_REF_PredeterminationIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_ServiceAuthorizationExceptionCode S_REF_ServiceAuthorizationExceptionCode {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_PayerClaimControlNumber S_REF_PayerClaimControlNumber {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_ReferralNumber S_REF_ReferralNumber {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_PriorAuthorization S_REF_PriorAuthorization {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_RepricedClaimNumber S_REF_RepricedClaimNumber {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_REF_AdjustedRepricedClaimNumber S_REF_AdjustedRepricedClaimNumber {get; set;}
    [XmlElementAttribute(Order=7)]
    public S_REF_ClaimIdentifierForTransmissionIntermediaries S_REF_ClaimIdentifierForTransmissionIntermediaries {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PredeterminationIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PredeterminationofBenefitsIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_9 C_C040_ReferenceIdentifier_9 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_11 {
        G3,
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
    public class S_REF_ServiceAuthorizationExceptionCode {
    [XmlElement(Order=0)]
    public X12_ID_128_12 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_127_1 D_REF02_ServiceAuthorizationExceptionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_10 C_C040_ReferenceIdentifier_10 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_12 {
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
    public X12_ID_128_13 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_11 C_C040_ReferenceIdentifier_11 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_13 {
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
    public class S_REF_ReferralNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_14 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_12 C_C040_ReferenceIdentifier_12 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_14 {
        [XmlEnum("9F")]
        Item9F,
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
    public class S_REF_PriorAuthorization {
    [XmlElement(Order=0)]
    public X12_ID_128_15 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_13 C_C040_ReferenceIdentifier_13 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_15 {
        G1,
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
    public class S_REF_RepricedClaimNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_16 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_14 C_C040_ReferenceIdentifier_14 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_16 {
        [XmlEnum("9A")]
        Item9A,
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
    public class S_REF_AdjustedRepricedClaimNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_17 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_15 C_C040_ReferenceIdentifier_15 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_17 {
        [XmlEnum("9C")]
        Item9C,
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
    public class S_REF_ClaimIdentifierForTransmissionIntermediaries {
    [XmlElement(Order=0)]
    public X12_ID_128_18 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ValueAddedNetworkTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_16 C_C040_ReferenceIdentifier_16 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_18 {
        D9,
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
    public class S_NTE_ClaimNote {
    [XmlElement(Order=0)]
    public X12_ID_363 D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_ClaimNoteText {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_363 {
        ADD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_HealthCareDiagnosisCode {
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
    public X12_ID_1270_3 D_C02201_CodeListQualifierCode {get; set;}
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
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_3 {
        ABK,
        BK,
        TQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1270_4 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
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
        ABF,
        BF,
        TQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
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
    public string D_C02202_DiagnosisCode {get; set;}
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
    public string D_HCP06_RepricedApprovedAmbulatoryPatientGroupCode {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_Product_ServiceID {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_Product_ServiceID {get; set;}
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
    [XmlElement(Order=0)]
    public U_TS837_2310A U_TS837_2310A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2310B G_TS837_2310B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2310C G_TS837_2310C {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837_2310D G_TS837_2310D {get; set;}
    [XmlElementAttribute(Order=4)]
    public G_TS837_2310E G_TS837_2310E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2310A {
    [XmlElement(Order=0)]
    public S_NM1_ReferringProviderName S_NM1_ReferringProviderName {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_ReferringProviderSpecialtyInformation S_PRV_ReferringProviderSpecialtyInformation {get; set;}
    [XmlElement("S_REF_ReferringProviderSecondaryIdentification",Order=2)]
    public List<S_REF_ReferringProviderSecondaryIdentification> S_REF_ReferringProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReferringProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
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
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_9 {
        DN,
        P3,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_3 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ReferringProviderSpecialtyInformation {
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
        RF,
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
    public class S_REF_ReferringProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_19 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferringProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_17 C_C040_ReferenceIdentifier_17 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_19 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
        G2,
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
    public class G_TS837_2310B {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName S_NM1_RenderingProviderName {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RenderingProviderSpecialtyInformation S_PRV_RenderingProviderSpecialtyInformation {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification",Order=2)]
    public List<S_REF_RenderingProviderSecondaryIdentification> S_REF_RenderingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastorOrganizationName {get; set;}
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
    public enum X12_ID_98_10 {
        [XmlEnum("82")]
        Item82,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_RenderingProviderSpecialtyInformation {
    [XmlElement(Order=0)]
    public X12_ID_1221_3 D_PRV01_ProviderCode {get; set;}
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
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1221_3 {
        PE,
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
    public class S_REF_RenderingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_18 C_C040_ReferenceIdentifier_18 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_20 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
        G2,
        LU,
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
    public class G_TS837_2310C {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityLocationName S_NM1_ServiceFacilityLocationName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_ServiceFacilityLocationAddress S_N3_ServiceFacilityLocationAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ServiceFacilityLocationCity_State_ZipCode S_N4_ServiceFacilityLocationCity_State_ZipCode {get; set;}
    [XmlElement("S_REF_ServiceFacilityLocationSecondaryIdentification",Order=3)]
    public List<S_REF_ServiceFacilityLocationSecondaryIdentification> S_REF_ServiceFacilityLocationSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceFacilityLocationName {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
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
    public enum X12_ID_98_11 {
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
    public class S_N4_ServiceFacilityLocationCity_State_ZipCode {
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
    public class S_REF_ServiceFacilityLocationSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LaboratoryorFacilitySecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_19 C_C040_ReferenceIdentifier_19 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_21 {
        [XmlEnum("0B")]
        Item0B,
        G2,
        LU,
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
    public class G_TS837_2310D {
    [XmlElement(Order=0)]
    public S_NM1_AssistantSurgeonName S_NM1_AssistantSurgeonName {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AssistantSurgeonSpecialtyInformation S_PRV_AssistantSurgeonSpecialtyInformation {get; set;}
    [XmlElement("S_REF_AssistantSurgeonSecondaryIdentification",Order=2)]
    public List<S_REF_AssistantSurgeonSecondaryIdentification> S_REF_AssistantSurgeonSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AssistantSurgeonName {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AssistantSurgeonLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AssistantSurgeonFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AssistantSurgeonMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AssistantSurgeonNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AssistantSurgeonPrimaryIdentifier {get; set;}
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
        DD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AssistantSurgeonSpecialtyInformation {
    [XmlElement(Order=0)]
    public X12_ID_1221_4 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_4 C_C035_ProviderSpecialtyInformation_4 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1221_4 {
        AS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_4 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AssistantSurgeonSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AssistantSurgeonSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_20 C_C040_ReferenceIdentifier_20 {get; set;}
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
    public class G_TS837_2310E {
    [XmlElement(Order=0)]
    public S_NM1_SupervisingProviderName S_NM1_SupervisingProviderName {get; set;}
    [XmlElement("S_REF_SupervisingProviderSecondaryIdentification",Order=1)]
    public List<S_REF_SupervisingProviderSecondaryIdentification> S_REF_SupervisingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SupervisingProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SupervisingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SupervisingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_SupervisingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_SupervisingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SupervisingProviderIdentifier {get; set;}
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
        DQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SupervisingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SupervisingProviderSecondaryIdentifier {get; set;}
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
    public S_MOA_OutpatientAdjudicationInformation S_MOA_OutpatientAdjudicationInformation {get; set;}
    [XmlElement(Order=5)]
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
    public string D_MOA08_MonetaryAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MOA09_Non_PayableProfessionalComponentBilledAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_5 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2330A G_TS837_2330A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2330B G_TS837_2330B {get; set;}
    [XmlElement(Order=2)]
    public U_TS837_2330C U_TS837_2330C {get; set;}
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
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2330A {
    [XmlElement(Order=0)]
    public S_NM1_OtherSubscriberName S_NM1_OtherSubscriberName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherSubscriberAddress S_N3_OtherSubscriberAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherSubscriberCity_State_ZipCode S_N4_OtherSubscriberCity_State_ZipCode {get; set;}
    [XmlElement("S_REF_OtherSubscriberSecondaryIdentification",Order=3)]
    public List<S_REF_OtherSubscriberSecondaryIdentification> S_REF_OtherSubscriberSecondaryIdentification {get; set;}
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
    public class S_N4_OtherSubscriberCity_State_ZipCode {
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
    public class S_REF_OtherSubscriberSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherInsuredAdditionalIdentifier {get; set;}
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
    public A_REF_6 A_REF_6 {get; set;}
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
    public class A_REF_6 {
    [XmlElement(Order=0)]
    public U_REF_OtherPayerSecondaryIdentifier U_REF_OtherPayerSecondaryIdentifier {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_OtherPayerPriorAuthorizationNumber S_REF_OtherPayerPriorAuthorizationNumber {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_OtherPayerReferralNumber S_REF_OtherPayerReferralNumber {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_OtherPayerClaimAdjustmentIndicator S_REF_OtherPayerClaimAdjustmentIndicator {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_OtherPayerPredeterminationIdentification S_REF_OtherPayerPredeterminationIdentification {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_OtherPayerClaimControlNumber S_REF_OtherPayerClaimControlNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerSecondaryIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerSecondaryIdentifier {get; set;}
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
    public class S_REF_OtherPayerPriorAuthorizationNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_15 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationorReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_24 C_C040_ReferenceIdentifier_24 {get; set;}
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
    public class S_REF_OtherPayerReferralNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_14 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_25 C_C040_ReferenceIdentifier_25 {get; set;}
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
    public class S_REF_OtherPayerClaimAdjustmentIndicator {
    [XmlElement(Order=0)]
    public X12_ID_128_22 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerClaimAdjustmentIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_26 C_C040_ReferenceIdentifier_26 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_22 {
        T4,
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
    public class S_REF_OtherPayerPredeterminationIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPredeterminationofBenefitsIdentifier {get; set;}
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
    public class S_REF_OtherPayerClaimControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_13 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayer_sClaimControlNumber {get; set;}
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
    public class G_TS837_2330C {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerReferringProvider S_NM1_OtherPayerReferringProvider {get; set;}
    [XmlElement("S_REF_OtherPayerReferringProviderSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerReferringProviderSecondaryIdentification> S_REF_OtherPayerReferringProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerReferringProvider {
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
    public class S_REF_OtherPayerReferringProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_19 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerReferringProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2330D {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerRenderingProvider S_NM1_OtherPayerRenderingProvider {get; set;}
    [XmlElement("S_REF_OtherPayerRenderingProviderSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerRenderingProviderSecondaryIdentification> S_REF_OtherPayerRenderingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerRenderingProvider {
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
    public class S_REF_OtherPayerRenderingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerRenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_30 C_C040_ReferenceIdentifier_30 {get; set;}
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
    public class G_TS837_2330E {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerSupervisingProvider S_NM1_OtherPayerSupervisingProvider {get; set;}
    [XmlElement("S_REF_OtherPayerSupervisingProviderIdentification",Order=1)]
    public List<S_REF_OtherPayerSupervisingProviderIdentification> S_REF_OtherPayerSupervisingProviderIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerSupervisingProvider {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
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
    public class S_REF_OtherPayerSupervisingProviderIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerSupervisingProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2330F {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerBillingProvider S_NM1_OtherPayerBillingProvider {get; set;}
    [XmlElement("S_REF_OtherPayerBillingProviderSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerBillingProviderSecondaryIdentification> S_REF_OtherPayerBillingProviderSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerBillingProvider {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
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
    public class S_REF_OtherPayerBillingProviderSecondaryIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_10 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerBillingProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2330G {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerServiceFacilityLocation S_NM1_OtherPayerServiceFacilityLocation {get; set;}
    [XmlElement("S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification",Order=1)]
    public List<S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification> S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerServiceFacilityLocation {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
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
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerServiceFacilityLocationIdentifier {get; set;}
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
    public class G_TS837_2330H {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerAssistantSurgeon S_NM1_OtherPayerAssistantSurgeon {get; set;}
    [XmlElement("S_REF_OtherPayerAssistantSurgeonSecondaryIdentifier",Order=1)]
    public List<S_REF_OtherPayerAssistantSurgeonSecondaryIdentifier> S_REF_OtherPayerAssistantSurgeonSecondaryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerAssistantSurgeon {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
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
    public class S_REF_OtherPayerAssistantSurgeonSecondaryIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerAssistantSurgeonSecondaryIdentifier {get; set;}
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
    public class G_TS837_2400 {
    [XmlElement(Order=0)]
    public S_LX_ServiceLineNumber S_LX_ServiceLineNumber {get; set;}
    [XmlElement(Order=1)]
    public S_SV3_DentalService S_SV3_DentalService {get; set;}
    [XmlElement("S_TOO_ToothInformation",Order=2)]
    public List<S_TOO_ToothInformation> S_TOO_ToothInformation {get; set;}
    [XmlElement(Order=3)]
    public A_DTP_2 A_DTP_2 {get; set;}
    [XmlElement(Order=4)]
    public S_CN1_ContractInformation_2 S_CN1_ContractInformation_2 {get; set;}
    [XmlElement(Order=5)]
    public A_REF_7 A_REF_7 {get; set;}
    [XmlElement(Order=6)]
    public S_AMT_SalesTaxAmount S_AMT_SalesTaxAmount {get; set;}
    [XmlElement("S_K3_FileInformation_2",Order=7)]
    public List<S_K3_FileInformation_2> S_K3_FileInformation_2 {get; set;}
    [XmlElement(Order=8)]
    public S_HCP_LinePricing_RepricingInformation S_HCP_LinePricing_RepricingInformation {get; set;}
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
    public class S_SV3_DentalService {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier C_C003_CompositeMedicalProcedureIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SV302_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SV303_PlaceofServiceCode {get; set;}
    [XmlElement(Order=3)]
    public C_C006_OralCavityDesignation C_C006_OralCavityDesignation {get; set;}
    [XmlElement(Order=4)]
    public string D_SV305_Prosthesis_Crown_orInlayCode {get; set;}
    [XmlElement(Order=5)]
    public string D_SV306_ProcedureCount {get; set;}
    [XmlElement(Order=6)]
    public string D_SV307_Description {get; set;}
    [XmlElement(Order=7)]
    public string D_SV308_CopayStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SV309_ProviderAgreementCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV310_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=10)]
    public C_C004_CompositeDiagnosisCodePointer C_C004_CompositeDiagnosisCodePointer {get; set;}
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
    public string D_C00307_ProcedureCodeDescription {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_235_2 {
        AD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C006_OralCavityDesignation {
    [XmlElement(Order=0)]
    public string D_C00601_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00602_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00603_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C00604_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00605_OralCavityDesignationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C004_CompositeDiagnosisCodePointer {
    [XmlElement(Order=0)]
    public string D_C00401_DiagnosisCodePointer {get; set;}
    [XmlElement(Order=1)]
    public string D_C00402_DiagnosisCodePointer {get; set;}
    [XmlElement(Order=2)]
    public string D_C00403_DiagnosisCodePointer {get; set;}
    [XmlElement(Order=3)]
    public string D_C00404_DiagnosisCodePointer {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TOO_ToothInformation {
    [XmlElement(Order=0)]
    public X12_ID_1270_2 D_TOO01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TOO02_ToothCode {get; set;}
    [XmlElement(Order=2)]
    public C_C005_ToothSurface C_C005_ToothSurface {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_2 {
        JP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C005_ToothSurface {
    [XmlElement(Order=0)]
    public string D_C00501_ToothSurfaceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00502_ToothSurfaceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00503_ToothSurfaceCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C00504_ToothSurfaceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00505_ToothSurfaceCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_2 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_Date_ServiceDate_2 S_DTP_Date_ServiceDate_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_Date_PriorPlacement S_DTP_Date_PriorPlacement {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_Date_AppliancePlacement_2 S_DTP_Date_AppliancePlacement_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_Date_Replacement S_DTP_Date_Replacement {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_DTP_Date_TreatmentStart S_DTP_Date_TreatmentStart {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_DTP_Date_TreatmentCompletion S_DTP_Date_TreatmentCompletion {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_ServiceDate_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_PriorPlacement {
    [XmlElement(Order=0)]
    public X12_ID_374_7 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_PriorPlacementDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_7 {
        [XmlEnum("139")]
        Item139,
        [XmlEnum("441")]
        Item441,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_AppliancePlacement_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OrthodonticBandingDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_Replacement {
    [XmlElement(Order=0)]
    public X12_ID_374_8 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ReplacementDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_8 {
        [XmlEnum("446")]
        Item446,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_TreatmentStart {
    [XmlElement(Order=0)]
    public X12_ID_374_9 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_TreatmentStartDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_9 {
        [XmlEnum("196")]
        Item196,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_TreatmentCompletion {
    [XmlElement(Order=0)]
    public X12_ID_374_10 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_TreatmentCompletionDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_10 {
        [XmlEnum("198")]
        Item198,
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
    public class A_REF_7 {
    [XmlElement(Order=0)]
    public U_REF_ServicePredeterminationIdentification U_REF_ServicePredeterminationIdentification {get; set;}
    [XmlElement(Order=1)]
    public U_REF_PriorAuthorization_2 U_REF_PriorAuthorization_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_LineItemControlNumber S_REF_LineItemControlNumber {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_RepricedClaimNumber_2 S_REF_RepricedClaimNumber_2 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_AdjustedRepricedClaimNumber_2 S_REF_AdjustedRepricedClaimNumber_2 {get; set;}
    [XmlElement(Order=5)]
    public U_REF_ReferralNumber_2 U_REF_ReferralNumber_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServicePredeterminationIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PredeterminationofBenefitsIdentifier {get; set;}
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
    public class S_REF_PriorAuthorization_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_15 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorAuthorizationorReferralNumber {get; set;}
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
    public class S_REF_LineItemControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_24 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_37 C_C040_ReferenceIdentifier_37 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_24 {
        [XmlEnum("6R")]
        Item6R,
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
    public class S_REF_RepricedClaimNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_16 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedClaimReferenceNumber {get; set;}
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
    public class S_REF_AdjustedRepricedClaimNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_17 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_39 C_C040_ReferenceIdentifier_39 {get; set;}
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
    public class S_REF_ReferralNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_14 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_40 C_C040_ReferenceIdentifier_40 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_40 {
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
    public class S_AMT_SalesTaxAmount {
    [XmlElement(Order=0)]
    public X12_ID_522_5 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_SalesTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522_5 {
        T,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_K3_FileInformation_2 {
    [XmlElement(Order=0)]
    public string D_K301_FixedFormatInformation {get; set;}
    [XmlElement(Order=1)]
    public string D_K302_RecordFormatCode {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitofMeasure_2 C_C001_CompositeUnitofMeasure_2 {get; set;}
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
    public class S_HCP_LinePricing_RepricingInformation {
    [XmlElement(Order=0)]
    public X12_ID_1473_2 D_HCP01_PricingMethodology {get; set;}
    [XmlElement(Order=1)]
    public string D_HCP02_RepricedAllowedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_HCP03_RepricedSavingAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_HCP04_RepricingOrganizationIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_HCP05_RepricingPerDiemorFlatRateAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HCP06_ReferenceIdentification {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_Product_ServiceID {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_ProductorServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_RepricedApprovedHCPCSCode {get; set;}
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
    public enum X12_ID_1473_2 {
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
    public S_NM1_RenderingProviderName_2 S_NM1_RenderingProviderName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RenderingProviderSpecialtyInformation_2 S_PRV_RenderingProviderSpecialtyInformation_2 {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification_2",Order=2)]
    public List<S_REF_RenderingProviderSecondaryIdentification_2> S_REF_RenderingProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastorOrganizationName {get; set;}
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
    public class S_PRV_RenderingProviderSpecialtyInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1221_3 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_5 C_C035_ProviderSpecialtyInformation_5 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_5 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_41 C_C040_ReferenceIdentifier_41 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_41 {
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
    public S_NM1_AssistantSurgeonName_2 S_NM1_AssistantSurgeonName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_2 S_PRV_AssistantSurgeonSpecialtyInformation_2 {get; set;}
    [XmlElement("S_REF_AssistantSurgeonSecondaryIdentification_2",Order=2)]
    public List<S_REF_AssistantSurgeonSecondaryIdentification_2> S_REF_AssistantSurgeonSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AssistantSurgeonName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AssistantSurgeonLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AssistantSurgeonFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AssistantSurgeonMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AssistantSurgeonNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AssistantSurgeonPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AssistantSurgeonSpecialtyInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1221_4 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_6 C_C035_ProviderSpecialtyInformation_6 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_6 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AssistantSurgeonSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AssistantSurgeonSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_42 C_C040_ReferenceIdentifier_42 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_42 {
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
    public S_NM1_SupervisingProviderName_2 S_NM1_SupervisingProviderName_2 {get; set;}
    [XmlElement("S_REF_SupervisingProviderSecondaryIdentification_2",Order=1)]
    public List<S_REF_SupervisingProviderSecondaryIdentification_2> S_REF_SupervisingProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SupervisingProviderName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SupervisingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SupervisingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AssistantSurgeonMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_SupervisingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SupervisingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SupervisingProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SupervisingProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2420D {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityLocationName_2 S_NM1_ServiceFacilityLocationName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_ServiceFacilityLocationAddress_2 S_N3_ServiceFacilityLocationAddress_2 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ServiceFacilityLocationCity_State_ZIPCode S_N4_ServiceFacilityLocationCity_State_ZIPCode {get; set;}
    [XmlElement("S_REF_ServiceFacilityLocationSecondaryIdentification_2",Order=3)]
    public List<S_REF_ServiceFacilityLocationSecondaryIdentification_2> S_REF_ServiceFacilityLocationSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceFacilityLocationName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
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
    public class S_N4_ServiceFacilityLocationCity_State_ZIPCode {
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
    public class S_REF_ServiceFacilityLocationSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_25 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ServiceFacilityLocationSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_44 C_C040_ReferenceIdentifier_44 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_25 {
        [XmlEnum("1G")]
        Item1G,
        G2,
        LU,
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
    public A_REF_8 A_REF_8 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientName {
    [XmlElement(Order=0)]
    public X12_ID_98_14 D_NM101_EntityIdentifierCode {get; set;}
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
    public enum X12_ID_98_14 {
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
    public class A_REF_8 {
    [XmlElementAttribute(Order=0)]
    public S_REF_PropertyandCasualtyClaimNumber_2 S_REF_PropertyandCasualtyClaimNumber_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PropertyandCasualtyPatientIdentifier S_REF_PropertyandCasualtyPatientIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PropertyandCasualtyClaimNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyCasualtyClaimNumber {get; set;}
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
    public X12_ID_128_26 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyandCasualtyPatientIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_46 C_C040_ReferenceIdentifier_46 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_26 {
        [XmlEnum("1W")]
        Item1W,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_46 {
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
    public S_CLM_ClaimInformation_2 S_CLM_ClaimInformation_2 {get; set;}
    [XmlElement(Order=1)]
    public A_DTP_3 A_DTP_3 {get; set;}
    [XmlElement(Order=2)]
    public S_DN1_OrthodonticTotalMonthsofTreatment_2 S_DN1_OrthodonticTotalMonthsofTreatment_2 {get; set;}
    [XmlElement("S_DN2_ToothStatus_2",Order=3)]
    public List<S_DN2_ToothStatus_2> S_DN2_ToothStatus_2 {get; set;}
    [XmlElement("S_PWK_ClaimSupplementalInformation_2",Order=4)]
    public List<S_PWK_ClaimSupplementalInformation_2> S_PWK_ClaimSupplementalInformation_2 {get; set;}
    [XmlElement(Order=5)]
    public S_CN1_ContractInformation_3 S_CN1_ContractInformation_3 {get; set;}
    [XmlElement(Order=6)]
    public S_AMT_PatientAmountPaid_2 S_AMT_PatientAmountPaid_2 {get; set;}
    [XmlElement(Order=7)]
    public A_REF_9 A_REF_9 {get; set;}
    [XmlElement("S_K3_FileInformation_3",Order=8)]
    public List<S_K3_FileInformation_3> S_K3_FileInformation_3 {get; set;}
    [XmlElement("S_NTE_ClaimNote_2",Order=9)]
    public List<S_NTE_ClaimNote_2> S_NTE_ClaimNote_2 {get; set;}
    [XmlElement(Order=10)]
    public S_HI_HealthCareDiagnosisCode_2 S_HI_HealthCareDiagnosisCode_2 {get; set;}
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
    public class S_CLM_ClaimInformation_2 {
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
    public string D_CLM12_SpecialProgramIndicator {get; set;}
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
    public string D_CLM19_PredeterminationofBenefitsCode {get; set;}
    [XmlElement(Order=19)]
    public string D_CLM20_DelayReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C023_HealthCareServiceLocationInformation_2 {
    [XmlElement(Order=0)]
    public string D_C02301_PlaceofServiceCode {get; set;}
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
    public string D_C02402_RelatedCausesCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02403_Related_CausesCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C02404_AutoAccidentStateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C02405_CountryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_3 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_Date_Accident_2 S_DTP_Date_Accident_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_Date_AppliancePlacement_3 S_DTP_Date_AppliancePlacement_3 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_Date_ServiceDate_3 S_DTP_Date_ServiceDate_3 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_Date_RepricerReceivedDate_2 S_DTP_Date_RepricerReceivedDate_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_Accident_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_AppliancePlacement_3 {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OrthodonticBandingDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_ServiceDate_3 {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_2 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
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
    public class S_DN1_OrthodonticTotalMonthsofTreatment_2 {
    [XmlElement(Order=0)]
    public string D_DN101_OrthodonticTreatmentMonthsCount {get; set;}
    [XmlElement(Order=1)]
    public string D_DN102_OrthodonticTreatmentMonthsRemainingCount {get; set;}
    [XmlElement(Order=2)]
    public string D_DN103_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DN104_OrthodonticTreatmentIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DN2_ToothStatus_2 {
    [XmlElement(Order=0)]
    public string D_DN201_ToothNumber {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1368 D_DN202_ToothStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_DN203_Quantity {get; set;}
    [XmlElement(Order=3)]
    public string D_DN204_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=4)]
    public string D_DN205_DateTimePeriod {get; set;}
    [XmlElement(Order=5)]
    public string D_DN206_CodeListQualifierCode {get; set;}
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
    public class S_CN1_ContractInformation_3 {
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
    public class S_AMT_PatientAmountPaid_2 {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PatientAmountPaid {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_9 {
    [XmlElementAttribute(Order=0)]
    public S_REF_PredeterminationIdentification_2 S_REF_PredeterminationIdentification_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_ServiceAuthorizationExceptionCode_2 S_REF_ServiceAuthorizationExceptionCode_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_PayerClaimControlNumber_2 S_REF_PayerClaimControlNumber_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_ReferralNumber_3 S_REF_ReferralNumber_3 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_PriorAuthorization_3 S_REF_PriorAuthorization_3 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_RepricedClaimNumber_3 S_REF_RepricedClaimNumber_3 {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_REF_AdjustedRepricedClaimNumber_3 S_REF_AdjustedRepricedClaimNumber_3 {get; set;}
    [XmlElementAttribute(Order=7)]
    public S_REF_ClaimIdentifierForTransmissionIntermediaries_2 S_REF_ClaimIdentifierForTransmissionIntermediaries_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PredeterminationIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PredeterminationofBenefitsIdentifier {get; set;}
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
    public class S_REF_ServiceAuthorizationExceptionCode_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_12 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_127_1 D_REF02_ServiceAuthorizationExceptionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_48 C_C040_ReferenceIdentifier_48 {get; set;}
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
    public class S_REF_PayerClaimControlNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_13 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
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
    public class S_REF_ReferralNumber_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_14 D_REF01_ReferenceIdentificationQualifier {get; set;}
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
    public class S_REF_PriorAuthorization_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_15 D_REF01_ReferenceIdentificationQualifier {get; set;}
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
    public class S_REF_RepricedClaimNumber_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_16 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedClaimReferenceNumber {get; set;}
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
    public class S_REF_AdjustedRepricedClaimNumber_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_17 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedClaimReferenceNumber {get; set;}
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
    public class S_REF_ClaimIdentifierForTransmissionIntermediaries_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_18 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ValueAddedNetworkTraceNumber {get; set;}
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
    public class S_K3_FileInformation_3 {
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
    public class S_NTE_ClaimNote_2 {
    [XmlElement(Order=0)]
    public X12_ID_363 D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_ClaimNoteText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_HealthCareDiagnosisCode_2 {
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
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_14 {
    [XmlElement(Order=0)]
    public X12_ID_1270_4 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
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
    public string D_C02202_DiagnosisCode {get; set;}
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
    public string D_C02202_DiagnosisCode {get; set;}
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
    public string D_HCP06_RepricedApprovedAmbulatoryPatientGroupCode {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_Product_ServiceID {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_Product_ServiceID {get; set;}
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
    public class A_NM1_7 {
    [XmlElement(Order=0)]
    public U_TS837_2310A_1 U_TS837_2310A_1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2310B_1 G_TS837_2310B_1 {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837_2310C_1 G_TS837_2310C_1 {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837_2310D_1 G_TS837_2310D_1 {get; set;}
    [XmlElementAttribute(Order=4)]
    public G_TS837_2310E_1 G_TS837_2310E_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2310A_1 {
    [XmlElement(Order=0)]
    public S_NM1_ReferringProviderName_2 S_NM1_ReferringProviderName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_ReferringProviderSpecialtyInformation_2 S_PRV_ReferringProviderSpecialtyInformation_2 {get; set;}
    [XmlElement("S_REF_ReferringProviderSecondaryIdentification_2",Order=2)]
    public List<S_REF_ReferringProviderSecondaryIdentification_2> S_REF_ReferringProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReferringProviderName_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
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
    public class S_PRV_ReferringProviderSpecialtyInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1221_2 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_7 C_C035_ProviderSpecialtyInformation_7 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_7 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReferringProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_19 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferringProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2310B_1 {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName_3 S_NM1_RenderingProviderName_3 {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RenderingProviderSpecialtyInformation_3 S_PRV_RenderingProviderSpecialtyInformation_3 {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification_3",Order=2)]
    public List<S_REF_RenderingProviderSecondaryIdentification_3> S_REF_RenderingProviderSecondaryIdentification_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName_3 {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastorOrganizationName {get; set;}
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
    public class S_PRV_RenderingProviderSpecialtyInformation_3 {
    [XmlElement(Order=0)]
    public X12_ID_1221_3 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_8 C_C035_ProviderSpecialtyInformation_8 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_8 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2310C_1 {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityLocationName_3 S_NM1_ServiceFacilityLocationName_3 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_ServiceFacilityLocationAddress_3 S_N3_ServiceFacilityLocationAddress_3 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ServiceFacilityLocationCity_State_ZipCode_2 S_N4_ServiceFacilityLocationCity_State_ZipCode_2 {get; set;}
    [XmlElement("S_REF_ServiceFacilityLocationSecondaryIdentification_3",Order=3)]
    public List<S_REF_ServiceFacilityLocationSecondaryIdentification_3> S_REF_ServiceFacilityLocationSecondaryIdentification_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceFacilityLocationName_3 {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
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
    public class S_N3_ServiceFacilityLocationAddress_3 {
    [XmlElement(Order=0)]
    public string D_N301_LaboratoryorFacilityAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_LaboratoryorFacilityAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceFacilityLocationCity_State_ZipCode_2 {
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
    public class S_REF_ServiceFacilityLocationSecondaryIdentification_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LaboratoryorFacilitySecondaryIdentifier {get; set;}
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
    public class G_TS837_2310D_1 {
    [XmlElement(Order=0)]
    public S_NM1_AssistantSurgeonName_3 S_NM1_AssistantSurgeonName_3 {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_3 S_PRV_AssistantSurgeonSpecialtyInformation_3 {get; set;}
    [XmlElement("S_REF_AssistantSurgeonSecondaryIdentification_3",Order=2)]
    public List<S_REF_AssistantSurgeonSecondaryIdentification_3> S_REF_AssistantSurgeonSecondaryIdentification_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AssistantSurgeonName_3 {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AssistantSurgeonLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AssistantSurgeonFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AssistantSurgeonMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AssistantSurgeonNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AssistantSurgeonPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AssistantSurgeonSpecialtyInformation_3 {
    [XmlElement(Order=0)]
    public X12_ID_1221_4 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_9 C_C035_ProviderSpecialtyInformation_9 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_9 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AssistantSurgeonSecondaryIdentification_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AssistantSurgeonSecondaryIdentifier {get; set;}
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
    public class G_TS837_2310E_1 {
    [XmlElement(Order=0)]
    public S_NM1_SupervisingProviderName_3 S_NM1_SupervisingProviderName_3 {get; set;}
    [XmlElement("S_REF_SupervisingProviderSecondaryIdentification_3",Order=1)]
    public List<S_REF_SupervisingProviderSecondaryIdentification_3> S_REF_SupervisingProviderSecondaryIdentification_3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SupervisingProviderName_3 {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SupervisingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SupervisingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_SupervisingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_SupervisingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SupervisingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SupervisingProviderSecondaryIdentification_3 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SupervisingProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2320_1 {
    [XmlElement(Order=0)]
    public S_SBR_OtherSubscriberInformation_2 S_SBR_OtherSubscriberInformation_2 {get; set;}
    [XmlElement("S_CAS_ClaimLevelAdjustments_2",Order=1)]
    public List<S_CAS_ClaimLevelAdjustments_2> S_CAS_ClaimLevelAdjustments_2 {get; set;}
    [XmlElement(Order=2)]
    public A_AMT_2 A_AMT_2 {get; set;}
    [XmlElement(Order=3)]
    public S_OI_OtherInsuranceCoverageInformation_2 S_OI_OtherInsuranceCoverageInformation_2 {get; set;}
    [XmlElement(Order=4)]
    public S_MOA_OutpatientAdjudicationInformation_2 S_MOA_OutpatientAdjudicationInformation_2 {get; set;}
    [XmlElement(Order=5)]
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
    public class A_AMT_2 {
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
    public string D_MOA08_MonetaryAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MOA09_Non_PayableProfessionalComponentBilledAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_8 {
    [XmlElementAttribute(Order=0)]
    public G_TS837_2330A_1 G_TS837_2330A_1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837_2330B_1 G_TS837_2330B_1 {get; set;}
    [XmlElement(Order=2)]
    public U_TS837_2330C_1 U_TS837_2330C_1 {get; set;}
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
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837_2330A_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherSubscriberName_2 S_NM1_OtherSubscriberName_2 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherSubscriberAddress_2 S_N3_OtherSubscriberAddress_2 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherSubscriberCity_State_ZipCode_2 S_N4_OtherSubscriberCity_State_ZipCode_2 {get; set;}
    [XmlElement("S_REF_OtherSubscriberSecondaryIdentification_2",Order=3)]
    public List<S_REF_OtherSubscriberSecondaryIdentification_2> S_REF_OtherSubscriberSecondaryIdentification_2 {get; set;}
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
    public class S_N4_OtherSubscriberCity_State_ZipCode_2 {
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
    public class S_REF_OtherSubscriberSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherInsuredAdditionalIdentifier {get; set;}
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
    public A_REF_10 A_REF_10 {get; set;}
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
    public class A_REF_10 {
    [XmlElement(Order=0)]
    public U_REF_OtherPayerSecondaryIdentifier_2 U_REF_OtherPayerSecondaryIdentifier_2 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_OtherPayerPriorAuthorizationNumber_2 S_REF_OtherPayerPriorAuthorizationNumber_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_OtherPayerReferralNumber_2 S_REF_OtherPayerReferralNumber_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_OtherPayerClaimAdjustmentIndicator_2 S_REF_OtherPayerClaimAdjustmentIndicator_2 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_OtherPayerPredeterminationIdentification_2 S_REF_OtherPayerPredeterminationIdentification_2 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_OtherPayerClaimControlNumber_2 S_REF_OtherPayerClaimControlNumber_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerSecondaryIdentifier_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerSecondaryIdentifier {get; set;}
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
    public class S_REF_OtherPayerPriorAuthorizationNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_15 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationorReferralNumber {get; set;}
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
    public class S_REF_OtherPayerReferralNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_14 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerReferralNumber {get; set;}
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
    public class S_REF_OtherPayerClaimAdjustmentIndicator_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_22 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerClaimAdjustmentIndicator {get; set;}
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
    public class S_REF_OtherPayerPredeterminationIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPredeterminationofBenefitsIdentifier {get; set;}
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
    public class S_REF_OtherPayerClaimControlNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_13 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayer_sClaimControlNumber {get; set;}
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
    public class G_TS837_2330C_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerReferringProvider_2 S_NM1_OtherPayerReferringProvider_2 {get; set;}
    [XmlElement("S_REF_OtherPayerReferringProviderSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerReferringProviderSecondaryIdentification_2> S_REF_OtherPayerReferringProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerReferringProvider_2 {
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
    public class S_REF_OtherPayerReferringProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_19 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerReferringProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2330D_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerRenderingProvider_2 S_NM1_OtherPayerRenderingProvider_2 {get; set;}
    [XmlElement("S_REF_OtherPayerRenderingProviderSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerRenderingProviderSecondaryIdentification_2> S_REF_OtherPayerRenderingProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerRenderingProvider_2 {
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
    public class S_REF_OtherPayerRenderingProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerRenderingProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2330E_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerSupervisingProvider_2 S_NM1_OtherPayerSupervisingProvider_2 {get; set;}
    [XmlElement("S_REF_OtherPayerSupervisingProviderIdentification_2",Order=1)]
    public List<S_REF_OtherPayerSupervisingProviderIdentification_2> S_REF_OtherPayerSupervisingProviderIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerSupervisingProvider_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
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
    public class S_REF_OtherPayerSupervisingProviderIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerSupervisingProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2330F_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerBillingProvider_2 S_NM1_OtherPayerBillingProvider_2 {get; set;}
    [XmlElement("S_REF_OtherPayerBillingProviderSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerBillingProviderSecondaryIdentification_2> S_REF_OtherPayerBillingProviderSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerBillingProvider_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
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
    public class S_REF_OtherPayerBillingProviderSecondaryIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_10 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerBillingProviderSecondaryIdentifier {get; set;}
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
    public class G_TS837_2330G_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerServiceFacilityLocation_2 S_NM1_OtherPayerServiceFacilityLocation_2 {get; set;}
    [XmlElement("S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification_2",Order=1)]
    public List<S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification_2> S_REF_OtherPayerServiceFacilityLocationSecondaryIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerServiceFacilityLocation_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
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
    public X12_ID_128_21 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerServiceFacilityLocationIdentifier {get; set;}
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
    public class G_TS837_2330H_1 {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerAssistantSurgeon_2 S_NM1_OtherPayerAssistantSurgeon_2 {get; set;}
    [XmlElement("S_REF_OtherPayerAssistantSurgeonSecondaryIdentifier_2",Order=1)]
    public List<S_REF_OtherPayerAssistantSurgeonSecondaryIdentifier_2> S_REF_OtherPayerAssistantSurgeonSecondaryIdentifier_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerAssistantSurgeon_2 {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
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
    public class S_REF_OtherPayerAssistantSurgeonSecondaryIdentifier_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerAssistantSurgeonSecondaryIdentifier {get; set;}
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
    public class G_TS837_2400_1 {
    [XmlElement(Order=0)]
    public S_LX_ServiceLineNumber_2 S_LX_ServiceLineNumber_2 {get; set;}
    [XmlElement(Order=1)]
    public S_SV3_DentalService_2 S_SV3_DentalService_2 {get; set;}
    [XmlElement("S_TOO_ToothInformation_2",Order=2)]
    public List<S_TOO_ToothInformation_2> S_TOO_ToothInformation_2 {get; set;}
    [XmlElement(Order=3)]
    public A_DTP_4 A_DTP_4 {get; set;}
    [XmlElement(Order=4)]
    public S_CN1_ContractInformation_4 S_CN1_ContractInformation_4 {get; set;}
    [XmlElement(Order=5)]
    public A_REF_11 A_REF_11 {get; set;}
    [XmlElement(Order=6)]
    public S_AMT_SalesTaxAmount_2 S_AMT_SalesTaxAmount_2 {get; set;}
    [XmlElement("S_K3_FileInformation_4",Order=7)]
    public List<S_K3_FileInformation_4> S_K3_FileInformation_4 {get; set;}
    [XmlElement(Order=8)]
    public S_HCP_LinePricing_RepricingInformation_2 S_HCP_LinePricing_RepricingInformation_2 {get; set;}
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
    public class S_SV3_DentalService_2 {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier_3 C_C003_CompositeMedicalProcedureIdentifier_3 {get; set;}
    [XmlElement(Order=1)]
    public string D_SV302_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SV303_PlaceofServiceCode {get; set;}
    [XmlElement(Order=3)]
    public C_C006_OralCavityDesignation_2 C_C006_OralCavityDesignation_2 {get; set;}
    [XmlElement(Order=4)]
    public string D_SV305_Prosthesis_Crown_orInlayCode {get; set;}
    [XmlElement(Order=5)]
    public string D_SV306_ProcedureCount {get; set;}
    [XmlElement(Order=6)]
    public string D_SV307_Description {get; set;}
    [XmlElement(Order=7)]
    public string D_SV308_CopayStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SV309_ProviderAgreementCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV310_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=10)]
    public C_C004_CompositeDiagnosisCodePointer_2 C_C004_CompositeDiagnosisCodePointer_2 {get; set;}
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
    public string D_C00307_ProcedureCodeDescription {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C006_OralCavityDesignation_2 {
    [XmlElement(Order=0)]
    public string D_C00601_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00602_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00603_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C00604_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00605_OralCavityDesignationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C004_CompositeDiagnosisCodePointer_2 {
    [XmlElement(Order=0)]
    public string D_C00401_DiagnosisCodePointer {get; set;}
    [XmlElement(Order=1)]
    public string D_C00402_DiagnosisCodePointer {get; set;}
    [XmlElement(Order=2)]
    public string D_C00403_DiagnosisCodePointer {get; set;}
    [XmlElement(Order=3)]
    public string D_C00404_DiagnosisCodePointer {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TOO_ToothInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1270_2 D_TOO01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TOO02_ToothCode {get; set;}
    [XmlElement(Order=2)]
    public C_C005_ToothSurface_2 C_C005_ToothSurface_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C005_ToothSurface_2 {
    [XmlElement(Order=0)]
    public string D_C00501_ToothSurfaceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C00502_ToothSurfaceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C00503_ToothSurfaceCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C00504_ToothSurfaceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C00505_ToothSurfaceCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_4 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_Date_ServiceDate_4 S_DTP_Date_ServiceDate_4 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_Date_PriorPlacement_2 S_DTP_Date_PriorPlacement_2 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_Date_AppliancePlacement_4 S_DTP_Date_AppliancePlacement_4 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_Date_Replacement_2 S_DTP_Date_Replacement_2 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_DTP_Date_TreatmentStart_2 S_DTP_Date_TreatmentStart_2 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_DTP_Date_TreatmentCompletion_2 S_DTP_Date_TreatmentCompletion_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_ServiceDate_4 {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_PriorPlacement_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_7 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_PriorPlacementDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_AppliancePlacement_4 {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OrthodonticBandingDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_Replacement_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_8 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ReplacementDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_TreatmentStart_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_9 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_TreatmentStartDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_Date_TreatmentCompletion_2 {
    [XmlElement(Order=0)]
    public X12_ID_374_10 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_TreatmentCompletionDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CN1_ContractInformation_4 {
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
    public class A_REF_11 {
    [XmlElement(Order=0)]
    public U_REF_ServicePredeterminationIdentification_2 U_REF_ServicePredeterminationIdentification_2 {get; set;}
    [XmlElement(Order=1)]
    public U_REF_PriorAuthorization_4 U_REF_PriorAuthorization_4 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_LineItemControlNumber_2 S_REF_LineItemControlNumber_2 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_RepricedClaimNumber_4 S_REF_RepricedClaimNumber_4 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_AdjustedRepricedClaimNumber_4 S_REF_AdjustedRepricedClaimNumber_4 {get; set;}
    [XmlElement(Order=5)]
    public U_REF_ReferralNumber_4 U_REF_ReferralNumber_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServicePredeterminationIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PredeterminationofBenefitsIdentifier {get; set;}
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
    public class S_REF_PriorAuthorization_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_15 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorAuthorizationorReferralNumber {get; set;}
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
    public class S_REF_LineItemControlNumber_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_24 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
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
    public class S_REF_RepricedClaimNumber_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_16 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedClaimReferenceNumber {get; set;}
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
    public class S_REF_AdjustedRepricedClaimNumber_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_17 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedClaimReferenceNumber {get; set;}
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
    public class S_REF_ReferralNumber_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_14 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferralNumber {get; set;}
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
    public class S_AMT_SalesTaxAmount_2 {
    [XmlElement(Order=0)]
    public X12_ID_522_5 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_SalesTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_K3_FileInformation_4 {
    [XmlElement(Order=0)]
    public string D_K301_FixedFormatInformation {get; set;}
    [XmlElement(Order=1)]
    public string D_K302_RecordFormatCode {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitofMeasure_4 C_C001_CompositeUnitofMeasure_4 {get; set;}
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
    public class S_HCP_LinePricing_RepricingInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1473_2 D_HCP01_PricingMethodology {get; set;}
    [XmlElement(Order=1)]
    public string D_HCP02_RepricedAllowedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_HCP03_RepricedSavingAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_HCP04_RepricingOrganizationIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_HCP05_RepricingPerDiemorFlatRateAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HCP06_ReferenceIdentification {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_Product_ServiceID {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_ProductorServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_RepricedApprovedHCPCSCode {get; set;}
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
    public S_NM1_RenderingProviderName_4 S_NM1_RenderingProviderName_4 {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RenderingProviderSpecialtyInformation_4 S_PRV_RenderingProviderSpecialtyInformation_4 {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification_4",Order=2)]
    public List<S_REF_RenderingProviderSecondaryIdentification_4> S_REF_RenderingProviderSecondaryIdentification_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName_4 {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastorOrganizationName {get; set;}
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
    public class S_PRV_RenderingProviderSpecialtyInformation_4 {
    [XmlElement(Order=0)]
    public X12_ID_1221_3 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_10 C_C035_ProviderSpecialtyInformation_10 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_10 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
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
    public S_NM1_AssistantSurgeonName_4 S_NM1_AssistantSurgeonName_4 {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_4 S_PRV_AssistantSurgeonSpecialtyInformation_4 {get; set;}
    [XmlElement("S_REF_AssistantSurgeonSecondaryIdentification_4",Order=2)]
    public List<S_REF_AssistantSurgeonSecondaryIdentification_4> S_REF_AssistantSurgeonSecondaryIdentification_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AssistantSurgeonName_4 {
    [XmlElement(Order=0)]
    public X12_ID_98_12 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AssistantSurgeonLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AssistantSurgeonFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AssistantSurgeonMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AssistantSurgeonNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AssistantSurgeonPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AssistantSurgeonSpecialtyInformation_4 {
    [XmlElement(Order=0)]
    public X12_ID_1221_4 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_11 C_C035_ProviderSpecialtyInformation_11 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_11 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AssistantSurgeonSecondaryIdentification_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AssistantSurgeonSecondaryIdentifier {get; set;}
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
    public S_NM1_SupervisingProviderName_4 S_NM1_SupervisingProviderName_4 {get; set;}
    [XmlElement("S_REF_SupervisingProviderSecondaryIdentification_4",Order=1)]
    public List<S_REF_SupervisingProviderSecondaryIdentification_4> S_REF_SupervisingProviderSecondaryIdentification_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SupervisingProviderName_4 {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SupervisingProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SupervisingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AssistantSurgeonMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_SupervisingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SupervisingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SupervisingProviderSecondaryIdentification_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_20 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SupervisingProviderSecondaryIdentifier {get; set;}
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
    public S_NM1_ServiceFacilityLocationName_4 S_NM1_ServiceFacilityLocationName_4 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_ServiceFacilityLocationAddress_4 S_N3_ServiceFacilityLocationAddress_4 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ServiceFacilityLocationCity_State_ZIPCode_2 S_N4_ServiceFacilityLocationCity_State_ZIPCode_2 {get; set;}
    [XmlElement("S_REF_ServiceFacilityLocationSecondaryIdentification_4",Order=3)]
    public List<S_REF_ServiceFacilityLocationSecondaryIdentification_4> S_REF_ServiceFacilityLocationSecondaryIdentification_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceFacilityLocationName_4 {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
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
    public class S_N3_ServiceFacilityLocationAddress_4 {
    [XmlElement(Order=0)]
    public string D_N301_LaboratoryorFacilityAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_LaboratoryorFacilityAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceFacilityLocationCity_State_ZIPCode_2 {
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
    public class S_REF_ServiceFacilityLocationSecondaryIdentification_4 {
    [XmlElement(Order=0)]
    public X12_ID_128_25 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ServiceFacilityLocationSecondaryIdentifier {get; set;}
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
    public class U_REF_BillingProviderUPIN_LicenseInformation {
    [XmlElement("S_REF_BillingProviderUPIN_LicenseInformation",Order=0)]
    public List<S_REF_BillingProviderUPIN_LicenseInformation> S_REF_BillingProviderUPIN_LicenseInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PayerSecondaryIdentification {
    [XmlElement("S_REF_PayerSecondaryIdentification",Order=0)]
    public List<S_REF_PayerSecondaryIdentification> S_REF_PayerSecondaryIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS837_2310A {
    [XmlElement("G_TS837_2310A",Order=0)]
    public List<G_TS837_2310A> G_TS837_2310A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherPayerSecondaryIdentifier {
    [XmlElement("S_REF_OtherPayerSecondaryIdentifier",Order=0)]
    public List<S_REF_OtherPayerSecondaryIdentifier> S_REF_OtherPayerSecondaryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS837_2330C {
    [XmlElement("G_TS837_2330C",Order=0)]
    public List<G_TS837_2330C> G_TS837_2330C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_ServicePredeterminationIdentification {
    [XmlElement("S_REF_ServicePredeterminationIdentification",Order=0)]
    public List<S_REF_ServicePredeterminationIdentification> S_REF_ServicePredeterminationIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PriorAuthorization_2 {
    [XmlElement("S_REF_PriorAuthorization_2",Order=0)]
    public List<S_REF_PriorAuthorization_2> S_REF_PriorAuthorization_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_ReferralNumber_2 {
    [XmlElement("S_REF_ReferralNumber_2",Order=0)]
    public List<S_REF_ReferralNumber_2> S_REF_ReferralNumber_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS837_2310A_1 {
    [XmlElement("G_TS837_2310A_1",Order=0)]
    public List<G_TS837_2310A_1> G_TS837_2310A_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherPayerSecondaryIdentifier_2 {
    [XmlElement("S_REF_OtherPayerSecondaryIdentifier_2",Order=0)]
    public List<S_REF_OtherPayerSecondaryIdentifier_2> S_REF_OtherPayerSecondaryIdentifier_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS837_2330C_1 {
    [XmlElement("G_TS837_2330C_1",Order=0)]
    public List<G_TS837_2330C_1> G_TS837_2330C_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_ServicePredeterminationIdentification_2 {
    [XmlElement("S_REF_ServicePredeterminationIdentification_2",Order=0)]
    public List<S_REF_ServicePredeterminationIdentification_2> S_REF_ServicePredeterminationIdentification_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PriorAuthorization_4 {
    [XmlElement("S_REF_PriorAuthorization_4",Order=0)]
    public List<S_REF_PriorAuthorization_4> S_REF_PriorAuthorization_4 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_ReferralNumber_4 {
    [XmlElement("S_REF_ReferralNumber_4",Order=0)]
    public List<S_REF_ReferralNumber_4> S_REF_ReferralNumber_4 {get; set;}
    }
}
