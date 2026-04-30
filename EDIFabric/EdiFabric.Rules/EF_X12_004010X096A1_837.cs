namespace EdiFabric.Rules.X12004010X096A1837 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_837 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS837Q3 S_BHT_BeginningOfHierarchicalTransaction_TS837Q3 {get; set;}
    [XmlElement(Order=2)]
    public S_REF_TransmissionTypeIdentification_TS837Q3 S_REF_TransmissionTypeIdentification_TS837Q3 {get; set;}
    [XmlElement(Order=3)]
    public G_TS837Q3_1000A G_TS837Q3_1000A {get; set;}
    [XmlElement(Order=4)]
    public G_TS837Q3_1000B G_TS837Q3_1000B {get; set;}
    [XmlElement("G_TS837Q3_2000A",Order=5)]
    public List<G_TS837Q3_2000A> G_TS837Q3_2000A {get; set;}
    [XmlElement(Order=6)]
    public S_SE S_SE {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ST {
    [XmlElement(Order=0)]
    public string D_ST01 {get; set;}
    [XmlElement(Order=1)]
    public string D_ST02 {get; set;}
    [XmlElement(Order=2)]
    public string D_ST03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BHT_BeginningOfHierarchicalTransaction_TS837Q3 {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS837Q3D_BHT01_HierarchicalStructureCode D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS837Q3D_BHT02_TransactionSetPurposeCode D_BHT02_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BHT03_OriginatorApplicationTransactionIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_BHT04_TransactionSetCreationDate {get; set;}
    [XmlElement(Order=4)]
    public string D_BHT05_TransactionSetCreationTime {get; set;}
    [XmlElement(Order=5)]
    public string D_BHT06_ClaimOrEncounterIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS837Q3D_BHT01_HierarchicalStructureCode {
        [XmlEnum("0019")]
        Item0019,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS837Q3D_BHT02_TransactionSetPurposeCode {
        [XmlEnum("00")]
        Item00,
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_TransmissionTypeIdentification_TS837Q3 {
    [XmlElement(Order=0)]
    public S_REF_TransmissionTypeIdentification_TS837Q3D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_TransmissionTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1068 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_TransmissionTypeIdentification_TS837Q3D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("87")]
        Item87,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_1000A {
    [XmlElement(Order=0)]
    public S_NM1_SubmitterName_TS837Q3_1000A S_NM1_SubmitterName_TS837Q3_1000A {get; set;}
    [XmlElement("S_PER_SubmitterEDIContactInformation_TS837Q3_1000A",Order=1)]
    public List<S_PER_SubmitterEDIContactInformation_TS837Q3_1000A> S_PER_SubmitterEDIContactInformation_TS837Q3_1000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubmitterName_TS837Q3_1000A {
    [XmlElement(Order=0)]
    public S_NM1_SubmitterName_TS837Q3_1000AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubmitterName_TS837Q3_1000AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SubmitterLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SubmitterFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_SubmitterMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SubmitterIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubmitterName_TS837Q3_1000AD_NM101_EntityIdentifierCode {
        [XmlEnum("41")]
        Item41,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubmitterName_TS837Q3_1000AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_SubmitterEDIContactInformation_TS837Q3_1000A {
    [XmlElement(Order=0)]
    public S_PER_SubmitterEDIContactInformation_TS837Q3_1000AD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_SubmitterEDIContactInformation_TS837Q3_1000AD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_1000B {
    [XmlElement(Order=0)]
    public S_NM1_ReceiverName_TS837Q3_1000B S_NM1_ReceiverName_TS837Q3_1000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReceiverName_TS837Q3_1000B {
    [XmlElement(Order=0)]
    public S_NM1_ReceiverName_TS837Q3_1000BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ReceiverName_TS837Q3_1000BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ReceiverName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_InformationReceiverIdentificationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ReceiverPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ReceiverName_TS837Q3_1000BD_NM101_EntityIdentifierCode {
        [XmlEnum("40")]
        Item40,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ReceiverName_TS837Q3_1000BD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2000A {
    [XmlElement(Order=0)]
    public S_HL_BillingPayToProviderHierarchicalLevel_TS837Q3_2000A S_HL_BillingPayToProviderHierarchicalLevel_TS837Q3_2000A {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_BillingPayToProviderSpecialtyInformation_TS837Q3_2000A S_PRV_BillingPayToProviderSpecialtyInformation_TS837Q3_2000A {get; set;}
    [XmlElement(Order=2)]
    public S_CUR_ForeignCurrencyInformation_TS837Q3_2000A S_CUR_ForeignCurrencyInformation_TS837Q3_2000A {get; set;}
    [XmlElement(Order=3)]
    public A_TS837Q3_2010A A_TS837Q3_2010A {get; set;}
    [XmlElement("G_TS837Q3_2000B",Order=4)]
    public List<G_TS837Q3_2000B> G_TS837Q3_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_BillingPayToProviderHierarchicalLevel_TS837Q3_2000A {
    [XmlElement(Order=0)]
    public string D_HL01_HierarchicalIDNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_HL02 {get; set;}
    [XmlElement(Order=2)]
    public string D_HL03_HierarchicalLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HL04_HierarchicalChildCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_BillingPayToProviderSpecialtyInformation_TS837Q3_2000A {
    [XmlElement(Order=0)]
    public S_PRV_BillingPayToProviderSpecialtyInformation_TS837Q3_2000AD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_BillingPayToProviderSpecialtyInformation_TS837Q3_2000AD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U1069 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_BillingPayToProviderSpecialtyInformation_TS837Q3_2000AD_PRV01_ProviderCode {
        BI,
        PT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_BillingPayToProviderSpecialtyInformation_TS837Q3_2000AD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CUR_ForeignCurrencyInformation_TS837Q3_2000A {
    [XmlElement(Order=0)]
    public S_CUR_ForeignCurrencyInformation_TS837Q3_2000AD_CUR01_EntityIdentifierCode D_CUR01_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CUR02_CurrencyCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CUR03 {get; set;}
    [XmlElement(Order=3)]
    public string D_CUR04 {get; set;}
    [XmlElement(Order=4)]
    public string D_CUR05 {get; set;}
    [XmlElement(Order=5)]
    public string D_CUR06 {get; set;}
    [XmlElement(Order=6)]
    public string D_CUR07 {get; set;}
    [XmlElement(Order=7)]
    public string D_CUR08 {get; set;}
    [XmlElement(Order=8)]
    public string D_CUR09 {get; set;}
    [XmlElement(Order=9)]
    public string D_CUR10 {get; set;}
    [XmlElement(Order=10)]
    public string D_CUR11 {get; set;}
    [XmlElement(Order=11)]
    public string D_CUR12 {get; set;}
    [XmlElement(Order=12)]
    public string D_CUR13 {get; set;}
    [XmlElement(Order=13)]
    public string D_CUR14 {get; set;}
    [XmlElement(Order=14)]
    public string D_CUR15 {get; set;}
    [XmlElement(Order=15)]
    public string D_CUR16 {get; set;}
    [XmlElement(Order=16)]
    public string D_CUR17 {get; set;}
    [XmlElement(Order=17)]
    public string D_CUR18 {get; set;}
    [XmlElement(Order=18)]
    public string D_CUR19 {get; set;}
    [XmlElement(Order=19)]
    public string D_CUR20 {get; set;}
    [XmlElement(Order=20)]
    public string D_CUR21 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CUR_ForeignCurrencyInformation_TS837Q3_2000AD_CUR01_EntityIdentifierCode {
        [XmlEnum("85")]
        Item85,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q3_2010A {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q3_2010AA G_TS837Q3_2010AA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q3_2010AB G_TS837Q3_2010AB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2010AA {
    [XmlElement(Order=0)]
    public S_NM1_BillingProviderName_TS837Q3_2010AA S_NM1_BillingProviderName_TS837Q3_2010AA {get; set;}
    [XmlElement(Order=1)]
    public S_N3_BillingProviderAddress_TS837Q3_2010AA S_N3_BillingProviderAddress_TS837Q3_2010AA {get; set;}
    [XmlElement(Order=2)]
    public S_N4_BillingProviderCityStateZIPCode_TS837Q3_2010AA S_N4_BillingProviderCityStateZIPCode_TS837Q3_2010AA {get; set;}
    [XmlElement(Order=3)]
    public A_REF_TS837Q3_2010AA A_REF_TS837Q3_2010AA {get; set;}
    [XmlElement("S_PER_BillingProviderContactInformation_TS837Q3_2010AA",Order=4)]
    public List<S_PER_BillingProviderContactInformation_TS837Q3_2010AA> S_PER_BillingProviderContactInformation_TS837Q3_2010AA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_BillingProviderName_TS837Q3_2010AA {
    [XmlElement(Order=0)]
    public S_NM1_BillingProviderName_TS837Q3_2010AAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_BillingProviderName_TS837Q3_2010AAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_BillingProviderLastOrOrganizationalName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_BillingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_BillingProviderName_TS837Q3_2010AAD_NM101_EntityIdentifierCode {
        [XmlEnum("85")]
        Item85,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_BillingProviderName_TS837Q3_2010AAD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_BillingProviderAddress_TS837Q3_2010AA {
    [XmlElement(Order=0)]
    public string D_N301_BillingProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_BillingProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_BillingProviderCityStateZIPCode_TS837Q3_2010AA {
    [XmlElement(Order=0)]
    public string D_N401_BillingProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_BillingProviderStateOrProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_BillingProviderPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS837Q3_2010AA {
    [XmlElement(Order=0)]
    public U_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AA U_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AA {get; set;}
    [XmlElement(Order=1)]
    public U_REF_CreditDebitCardBillingInformation_TS837Q3_2010AA U_REF_CreditDebitCardBillingInformation_TS837Q3_2010AA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AA {
    [XmlElement(Order=0)]
    public S_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1070 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AAD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        [XmlEnum("1J")]
        Item1J,
        B3,
        BQ,
        EI,
        FH,
        G2,
        G5,
        LU,
        SY,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_CreditDebitCardBillingInformation_TS837Q3_2010AA {
    [XmlElement(Order=0)]
    public S_REF_CreditDebitCardBillingInformation_TS837Q3_2010AAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderCreditCardIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1071 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_CreditDebitCardBillingInformation_TS837Q3_2010AAD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("06")]
        Item06,
        [XmlEnum("8U")]
        Item8U,
        EM,
        IJ,
        RB,
        ST,
        TT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_BillingProviderContactInformation_TS837Q3_2010AA {
    [XmlElement(Order=0)]
    public S_PER_BillingProviderContactInformation_TS837Q3_2010AAD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_BillingProviderContactInformation_TS837Q3_2010AAD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2010AB {
    [XmlElement(Order=0)]
    public S_NM1_PayToProviderName_TS837Q3_2010AB S_NM1_PayToProviderName_TS837Q3_2010AB {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayToProviderAddress_TS837Q3_2010AB S_N3_PayToProviderAddress_TS837Q3_2010AB {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayToProviderCityStateZIPCode_TS837Q3_2010AB S_N4_PayToProviderCityStateZIPCode_TS837Q3_2010AB {get; set;}
    [XmlElement("S_REF_PayToProviderSecondaryIdentification_TS837Q3_2010AB",Order=3)]
    public List<S_REF_PayToProviderSecondaryIdentification_TS837Q3_2010AB> S_REF_PayToProviderSecondaryIdentification_TS837Q3_2010AB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PayToProviderName_TS837Q3_2010AB {
    [XmlElement(Order=0)]
    public S_NM1_PayToProviderName_TS837Q3_2010ABD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_PayToProviderName_TS837Q3_2010ABD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PaytoProviderLastOrOrganizationalName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PaytoProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PayToProviderName_TS837Q3_2010ABD_NM101_EntityIdentifierCode {
        [XmlEnum("87")]
        Item87,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PayToProviderName_TS837Q3_2010ABD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PayToProviderAddress_TS837Q3_2010AB {
    [XmlElement(Order=0)]
    public string D_N301_PaytoProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PaytoProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PayToProviderCityStateZIPCode_TS837Q3_2010AB {
    [XmlElement(Order=0)]
    public string D_N401_PaytoProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PaytoProviderStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PaytoProviderPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayToProviderSecondaryIdentification_TS837Q3_2010AB {
    [XmlElement(Order=0)]
    public S_REF_PayToProviderSecondaryIdentification_TS837Q3_2010ABD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PaytoProviderAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1072 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PayToProviderSecondaryIdentification_TS837Q3_2010ABD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        [XmlEnum("1J")]
        Item1J,
        B3,
        BQ,
        EI,
        FH,
        G2,
        G5,
        LU,
        SY,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2000B {
    [XmlElement(Order=0)]
    public S_HL_SubscriberHierarchicalLevel_TS837Q3_2000B S_HL_SubscriberHierarchicalLevel_TS837Q3_2000B {get; set;}
    [XmlElement(Order=1)]
    public S_SBR_SubscriberInformation_TS837Q3_2000B S_SBR_SubscriberInformation_TS837Q3_2000B {get; set;}
    [XmlElement(Order=2)]
    public A_TS837Q3_2010B A_TS837Q3_2010B {get; set;}
    [XmlElement("G_TS837Q3_2300",Order=3)]
    public List<G_TS837Q3_2300> G_TS837Q3_2300 {get; set;}
    [XmlElement("G_TS837Q3_2000C",Order=4)]
    public List<G_TS837Q3_2000C> G_TS837Q3_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberHierarchicalLevel_TS837Q3_2000B {
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
    public class S_SBR_SubscriberInformation_TS837Q3_2000B {
    [XmlElement(Order=0)]
    public S_SBR_SubscriberInformation_TS837Q3_2000BD_SBR01_PayerResponsibilitySequenceNumberCode D_SBR01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public S_SBR_SubscriberInformation_TS837Q3_2000BD_SBR02_IndividualRelationshipCode D_SBR02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SBR03_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=3)]
    public string D_SBR04_InsuredGroupName {get; set;}
    [XmlElement(Order=4)]
    public string D_SBR05 {get; set;}
    [XmlElement(Order=5)]
    public string D_SBR06 {get; set;}
    [XmlElement(Order=6)]
    public string D_SBR07 {get; set;}
    [XmlElement(Order=7)]
    public string D_SBR08 {get; set;}
    [XmlElement(Order=8)]
    public string D_SBR09_ClaimFilingIndicatorCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_SBR_SubscriberInformation_TS837Q3_2000BD_SBR01_PayerResponsibilitySequenceNumberCode {
        P,
        S,
        T,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_SBR_SubscriberInformation_TS837Q3_2000BD_SBR02_IndividualRelationshipCode {
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q3_2010B {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q3_2010BA G_TS837Q3_2010BA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q3_2010BB G_TS837Q3_2010BB {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837Q3_2010BC G_TS837Q3_2010BC {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837Q3_2010BD G_TS837Q3_2010BD {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2010BA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS837Q3_2010BA S_NM1_SubscriberName_TS837Q3_2010BA {get; set;}
    [XmlElement(Order=1)]
    public S_N3_SubscriberAddress_TS837Q3_2010BA S_N3_SubscriberAddress_TS837Q3_2010BA {get; set;}
    [XmlElement(Order=2)]
    public S_N4_SubscriberCityStateZIPCode_TS837Q3_2010BA S_N4_SubscriberCityStateZIPCode_TS837Q3_2010BA {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_SubscriberDemographicInformation_TS837Q3_2010BA S_DMG_SubscriberDemographicInformation_TS837Q3_2010BA {get; set;}
    [XmlElement(Order=4)]
    public A_REF_TS837Q3_2010BA A_REF_TS837Q3_2010BA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS837Q3_2010BA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS837Q3_2010BAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubscriberName_TS837Q3_2010BAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SubscriberLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SubscriberFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_SubscriberMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_SubscriberNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SubscriberPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS837Q3_2010BAD_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS837Q3_2010BAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_SubscriberAddress_TS837Q3_2010BA {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberCityStateZIPCode_TS837Q3_2010BA {
    [XmlElement(Order=0)]
    public string D_N401_SubscriberCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_SubscriberStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_SubscriberPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_SubscriberDemographicInformation_TS837Q3_2010BA {
    [XmlElement(Order=0)]
    public S_DMG_SubscriberDemographicInformation_TS837Q3_2010BAD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_SubscriberBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_SubscriberGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04 {get; set;}
    [XmlElement(Order=4)]
    public string D_DMG05 {get; set;}
    [XmlElement(Order=5)]
    public string D_DMG06 {get; set;}
    [XmlElement(Order=6)]
    public string D_DMG07 {get; set;}
    [XmlElement(Order=7)]
    public string D_DMG08 {get; set;}
    [XmlElement(Order=8)]
    public string D_DMG09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DMG_SubscriberDemographicInformation_TS837Q3_2010BAD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS837Q3_2010BA {
    [XmlElement(Order=0)]
    public U_REF_SubscriberSecondaryIdentification_TS837Q3_2010BA U_REF_SubscriberSecondaryIdentification_TS837Q3_2010BA {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010BA S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010BA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberSecondaryIdentification_TS837Q3_2010BA {
    [XmlElement(Order=0)]
    public S_REF_SubscriberSecondaryIdentification_TS837Q3_2010BAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1073 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberSecondaryIdentification_TS837Q3_2010BAD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("23")]
        Item23,
        IG,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010BA {
    [XmlElement(Order=0)]
    public S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010BAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyCasualtyClaimNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1074 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010BAD_REF01_ReferenceIdentificationQualifier {
        Y4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2010BB {
    [XmlElement(Order=0)]
    public S_NM1_CreditDebitCardAccountHolderName_TS837Q3_2010BB S_NM1_CreditDebitCardAccountHolderName_TS837Q3_2010BB {get; set;}
    [XmlElement("S_REF_CreditDebitCardInformation_TS837Q3_2010BB",Order=1)]
    public List<S_REF_CreditDebitCardInformation_TS837Q3_2010BB> S_REF_CreditDebitCardInformation_TS837Q3_2010BB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CreditDebitCardAccountHolderName_TS837Q3_2010BB {
    [XmlElement(Order=0)]
    public S_NM1_CreditDebitCardAccountHolderName_TS837Q3_2010BBD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_CreditDebitCardAccountHolderName_TS837Q3_2010BBD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CreditOrDebitCardHolderLastOrOrganizationalName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_CreditOrDebitCardHolderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_CreditOrDebitCardHolderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_CreditOrDebitCardHolderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_CreditOrDebitCardNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CreditDebitCardAccountHolderName_TS837Q3_2010BBD_NM101_EntityIdentifierCode {
        AO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CreditDebitCardAccountHolderName_TS837Q3_2010BBD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_CreditDebitCardInformation_TS837Q3_2010BB {
    [XmlElement(Order=0)]
    public S_REF_CreditDebitCardInformation_TS837Q3_2010BBD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_CreditOrDebitCardAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1075 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_CreditDebitCardInformation_TS837Q3_2010BBD_REF01_ReferenceIdentificationQualifier {
        AB,
        BB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2010BC {
    [XmlElement(Order=0)]
    public S_NM1_PayerName_TS837Q3_2010BC S_NM1_PayerName_TS837Q3_2010BC {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayerAddress_TS837Q3_2010BC S_N3_PayerAddress_TS837Q3_2010BC {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayerCityStateZIPCode_TS837Q3_2010BC S_N4_PayerCityStateZIPCode_TS837Q3_2010BC {get; set;}
    [XmlElement("S_REF_PayerSecondaryIdentification_TS837Q3_2010BC",Order=3)]
    public List<S_REF_PayerSecondaryIdentification_TS837Q3_2010BC> S_REF_PayerSecondaryIdentification_TS837Q3_2010BC {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PayerName_TS837Q3_2010BC {
    [XmlElement(Order=0)]
    public S_NM1_PayerName_TS837Q3_2010BCD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_PayerName_TS837Q3_2010BCD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PayerName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PayerIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PayerName_TS837Q3_2010BCD_NM101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PayerName_TS837Q3_2010BCD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PayerAddress_TS837Q3_2010BC {
    [XmlElement(Order=0)]
    public string D_N301_PayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PayerCityStateZIPCode_TS837Q3_2010BC {
    [XmlElement(Order=0)]
    public string D_N401_PayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PayerPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerSecondaryIdentification_TS837Q3_2010BC {
    [XmlElement(Order=0)]
    public S_REF_PayerSecondaryIdentification_TS837Q3_2010BCD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1076 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PayerSecondaryIdentification_TS837Q3_2010BCD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("2U")]
        Item2U,
        FY,
        NF,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2010BD {
    [XmlElement(Order=0)]
    public S_NM1_ResponsiblePartyName_TS837Q3_2010BD S_NM1_ResponsiblePartyName_TS837Q3_2010BD {get; set;}
    [XmlElement(Order=1)]
    public S_N3_ResponsiblePartyAddress_TS837Q3_2010BD S_N3_ResponsiblePartyAddress_TS837Q3_2010BD {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ResponsiblePartyCityStateZIPCode_TS837Q3_2010BD S_N4_ResponsiblePartyCityStateZIPCode_TS837Q3_2010BD {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ResponsiblePartyName_TS837Q3_2010BD {
    [XmlElement(Order=0)]
    public S_NM1_ResponsiblePartyName_TS837Q3_2010BDD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ResponsiblePartyName_TS837Q3_2010BDD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ResponsiblePartyLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ResponsiblePartyFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ResponsiblePartyMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ResponsiblePartySuffixName {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108 {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109 {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ResponsiblePartyName_TS837Q3_2010BDD_NM101_EntityIdentifierCode {
        QD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ResponsiblePartyName_TS837Q3_2010BDD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_ResponsiblePartyAddress_TS837Q3_2010BD {
    [XmlElement(Order=0)]
    public string D_N301_ResponsiblePartyAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ResponsiblePartyAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ResponsiblePartyCityStateZIPCode_TS837Q3_2010BD {
    [XmlElement(Order=0)]
    public string D_N401_ResponsiblePartyCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ResponsiblePartyStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ResponsiblePartyPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_CLM_ClaimInformation_TS837Q3_2300 S_CLM_ClaimInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public A_DTP_TS837Q3_2300 A_DTP_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public S_CL1_InstitutionalClaimCode_TS837Q3_2300 S_CL1_InstitutionalClaimCode_TS837Q3_2300 {get; set;}
    [XmlElement("S_PWK_ClaimSupplementalInformation_TS837Q3_2300",Order=3)]
    public List<S_PWK_ClaimSupplementalInformation_TS837Q3_2300> S_PWK_ClaimSupplementalInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public S_CN1_ContractInformation_TS837Q3_2300 S_CN1_ContractInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public A_AMT_TS837Q3_2300 A_AMT_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public A_REF_TS837Q3_2300 A_REF_TS837Q3_2300 {get; set;}
    [XmlElement("S_K3_FileInformation_TS837Q3_2300",Order=7)]
    public List<S_K3_FileInformation_TS837Q3_2300> S_K3_FileInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public A_NTE_TS837Q3_2300 A_NTE_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public S_CR6_HomeHealthCareInformation_TS837Q3_2300 S_CR6_HomeHealthCareInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=10)]
    public A_CRC_HomeHealth_TS837Q3_2300 A_CRC_HomeHealth_TS837Q3_2300 {get; set;}
    [XmlElement(Order=11)]
    public A_HI_TS837Q3_2300 A_HI_TS837Q3_2300 {get; set;}
    [XmlElement("S_QTY_ClaimQuantity_TS837Q3_2300",Order=12)]
    public List<S_QTY_ClaimQuantity_TS837Q3_2300> S_QTY_ClaimQuantity_TS837Q3_2300 {get; set;}
    [XmlElement(Order=13)]
    public S_HCP_ClaimPricingRepricingInformation_TS837Q3_2300 S_HCP_ClaimPricingRepricingInformation_TS837Q3_2300 {get; set;}
    [XmlElement("G_TS837Q3_2305",Order=14)]
    public List<G_TS837Q3_2305> G_TS837Q3_2305 {get; set;}
    [XmlElement(Order=15)]
    public A_TS837Q3_2310 A_TS837Q3_2310 {get; set;}
    [XmlElement("G_TS837Q3_2320",Order=16)]
    public List<G_TS837Q3_2320> G_TS837Q3_2320 {get; set;}
    [XmlElement("G_TS837Q3_2400",Order=17)]
    public List<G_TS837Q3_2400> G_TS837Q3_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CLM_ClaimInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_CLM01_PatientAccountNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_CLM02_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_CLM03 {get; set;}
    [XmlElement(Order=3)]
    public string D_CLM04 {get; set;}
    [XmlElement(Order=4)]
    public C_CLM05_C023U1079_TS837Q3_2300 C_CLM05_C023U1079_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public string D_CLM06_ProviderOrSupplierSignatureIndicator {get; set;}
    [XmlElement(Order=6)]
    public string D_CLM07_MedicareAssignmentCode {get; set;}
    [XmlElement(Order=7)]
    public string D_CLM08_BenefitsAssignmentCertificationIndicator {get; set;}
    [XmlElement(Order=8)]
    public string D_CLM09_ReleaseOfInformationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_CLM10 {get; set;}
    [XmlElement(Order=10)]
    public string D_CLM11_C024U6117 {get; set;}
    [XmlElement(Order=11)]
    public string D_CLM12 {get; set;}
    [XmlElement(Order=12)]
    public string D_CLM13 {get; set;}
    [XmlElement(Order=13)]
    public string D_CLM14 {get; set;}
    [XmlElement(Order=14)]
    public string D_CLM15 {get; set;}
    [XmlElement(Order=15)]
    public string D_CLM16 {get; set;}
    [XmlElement(Order=16)]
    public string D_CLM17 {get; set;}
    [XmlElement(Order=17)]
    public string D_CLM18_ExplanationOfBenefitsIndicator {get; set;}
    [XmlElement(Order=18)]
    public string D_CLM19 {get; set;}
    [XmlElement(Order=19)]
    public string D_CLM20_DelayReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CLM05_C023U1079_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_CLM05_C02301U1080_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CLM05_C02302U1081_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_CLM05_C02303U1082_ClaimFrequencyCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_TS837Q3_2300 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_DischargeHour_TS837Q3_2300 S_DTP_DischargeHour_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_StatementDates_TS837Q3_2300 S_DTP_StatementDates_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_AdmissionDateHour_TS837Q3_2300 S_DTP_AdmissionDateHour_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DischargeHour_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_DTP_DischargeHour_TS837Q3_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DischargeHour_TS837Q3_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DischargeHour {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DischargeHour_TS837Q3_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("096")]
        Item096,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DischargeHour_TS837Q3_2300D_DTP02_DateTimePeriodFormatQualifier {
        TM,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_StatementDates_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_DTP_StatementDates_TS837Q3_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_StatementDates_TS837Q3_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_StatementFromOrToDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_StatementDates_TS837Q3_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("434")]
        Item434,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_StatementDates_TS837Q3_2300D_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AdmissionDateHour_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_DTP_AdmissionDateHour_TS837Q3_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_AdmissionDateHour_TS837Q3_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdmissionDateAndHour {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AdmissionDateHour_TS837Q3_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("435")]
        Item435,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AdmissionDateHour_TS837Q3_2300D_DTP02_DateTimePeriodFormatQualifier {
        DT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CL1_InstitutionalClaimCode_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_CL101_AdmissionTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CL102_AdmissionSourceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CL103_PatientStatusCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CL104 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_ClaimSupplementalInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_PWK_ClaimSupplementalInformation_TS837Q3_2300D_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_ClaimSupplementalInformation_TS837Q3_2300D_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03 {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_AttachmentDescription {get; set;}
    [XmlElement(Order=7)]
    public string D_PWK08_C002U1089 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_ClaimSupplementalInformation_TS837Q3_2300D_PWK01_AttachmentReportTypeCode {
        AS,
        B2,
        B3,
        B4,
        CT,
        DA,
        DG,
        DS,
        EB,
        MT,
        NN,
        OB,
        OZ,
        PN,
        PO,
        PZ,
        RB,
        RR,
        RT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_ClaimSupplementalInformation_TS837Q3_2300D_PWK02_AttachmentTransmissionCode {
        AA,
        BM,
        EL,
        EM,
        FX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CN1_ContractInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_CN1_ContractInformation_TS837Q3_2300D_CN101_ContractTypeCode D_CN101_ContractTypeCode {get; set;}
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
    public enum S_CN1_ContractInformation_TS837Q3_2300D_CN101_ContractTypeCode {
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
    public class A_AMT_TS837Q3_2300 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_PayerEstimatedAmountDue_TS837Q3_2300 S_AMT_PayerEstimatedAmountDue_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_PatientEstimatedAmountDue_TS837Q3_2300 S_AMT_PatientEstimatedAmountDue_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_AMT_PatientPaidAmount_TS837Q3_2300 S_AMT_PatientPaidAmount_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_AMT_CreditDebitCardMaximumAmount_TS837Q3_2300 S_AMT_CreditDebitCardMaximumAmount_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_PayerEstimatedAmountDue_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_AMT_PayerEstimatedAmountDue_TS837Q3_2300D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_EstimatedClaimDueAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_PayerEstimatedAmountDue_TS837Q3_2300D_AMT01_AmountQualifierCode {
        C5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_PatientEstimatedAmountDue_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_AMT_PatientEstimatedAmountDue_TS837Q3_2300D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PatientResponsibilityAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_PatientEstimatedAmountDue_TS837Q3_2300D_AMT01_AmountQualifierCode {
        F3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_PatientPaidAmount_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_AMT_PatientPaidAmount_TS837Q3_2300D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PatientAmountPaid {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_PatientPaidAmount_TS837Q3_2300D_AMT01_AmountQualifierCode {
        F5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CreditDebitCardMaximumAmount_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_AMT_CreditDebitCardMaximumAmount_TS837Q3_2300D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_CreditOrDebitCardMaximumAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CreditDebitCardMaximumAmount_TS837Q3_2300D_AMT01_AmountQualifierCode {
        MA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS837Q3_2300 {
    [XmlElementAttribute(Order=0)]
    public S_REF_AdjustedRepricedClaimNumber_TS837Q3_2300 S_REF_AdjustedRepricedClaimNumber_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_RepricedClaimNumber_TS837Q3_2300 S_REF_RepricedClaimNumber_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q3_2300 S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public U_REF_DocumentIdentificationCode_TS837Q3_2300 U_REF_DocumentIdentificationCode_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_OriginalReferenceNumberICNDCN_TS837Q3_2300 S_REF_OriginalReferenceNumberICNDCN_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_REF_InvestigationalDeviceExemptionNumber_TS837Q3_2300 S_REF_InvestigationalDeviceExemptionNumber_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_REF_ServiceAuthorizationExceptionCode_TS837Q3_2300 S_REF_ServiceAuthorizationExceptionCode_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=7)]
    public S_REF_PeerReviewOrganizationPROApprovalNumber_TS837Q3_2300 S_REF_PeerReviewOrganizationPROApprovalNumber_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public U_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300 U_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=9)]
    public S_REF_MedicalRecordNumber_TS837Q3_2300 S_REF_MedicalRecordNumber_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=10)]
    public S_REF_DemonstrationProjectIdentifier_TS837Q3_2300 S_REF_DemonstrationProjectIdentifier_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AdjustedRepricedClaimNumber_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_AdjustedRepricedClaimNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdjustedRepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1090 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_AdjustedRepricedClaimNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9C")]
        Item9C,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RepricedClaimNumber_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_RepricedClaimNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RepricedClaimReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1091 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_RepricedClaimNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9A")]
        Item9A,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ValueAddedNetworkTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1092 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        D9,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DocumentIdentificationCode_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_DocumentIdentificationCode_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DocumentControlIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1093 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_DocumentIdentificationCode_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        DD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OriginalReferenceNumberICNDCN_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_OriginalReferenceNumberICNDCN_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ClaimOriginalReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1094 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OriginalReferenceNumberICNDCN_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        F8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InvestigationalDeviceExemptionNumber_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_InvestigationalDeviceExemptionNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InvestigationalDeviceExemptionIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1095 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_InvestigationalDeviceExemptionNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        LX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceAuthorizationExceptionCode_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_ServiceAuthorizationExceptionCode_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ServiceAuthorizationExceptionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1096 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceAuthorizationExceptionCode_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("4N")]
        Item4N,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PeerReviewOrganizationPROApprovalNumber_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_PeerReviewOrganizationPROApprovalNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PeerReviewAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1097 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PeerReviewOrganizationPROApprovalNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        G4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1098 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9F")]
        Item9F,
        G1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_MedicalRecordNumber_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_MedicalRecordNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MedicalRecordNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1099 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_MedicalRecordNumber_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        EA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DemonstrationProjectIdentifier_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_REF_DemonstrationProjectIdentifier_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DemonstrationProjectIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1100 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_DemonstrationProjectIdentifier_TS837Q3_2300D_REF01_ReferenceIdentificationQualifier {
        P4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_K3_FileInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_K301_FixedFormatInformation {get; set;}
    [XmlElement(Order=1)]
    public string D_K302 {get; set;}
    [XmlElement(Order=2)]
    public string D_K303_C001U1101 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NTE_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public U_NTE_ClaimNote_TS837Q3_2300 U_NTE_ClaimNote_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_NTE_BillingNote_TS837Q3_2300 S_NTE_BillingNote_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_ClaimNote_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_NTE_ClaimNote_TS837Q3_2300D_NTE01_NoteReferenceCode D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_ClaimNoteText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NTE_ClaimNote_TS837Q3_2300D_NTE01_NoteReferenceCode {
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
    public class S_NTE_BillingNote_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_NTE_BillingNote_TS837Q3_2300D_NTE01_NoteReferenceCode D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_BillingNoteText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NTE_BillingNote_TS837Q3_2300D_NTE01_NoteReferenceCode {
        ADD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR6_HomeHealthCareInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_CR6_HomeHealthCareInformation_TS837Q3_2300D_CR601_PrognosisCode D_CR601_PrognosisCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR602_ServiceFromDate {get; set;}
    [XmlElement(Order=2)]
    public string D_CR603_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_CR604_HomeHealthCertificationPeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_CR605_DiagnosisDate {get; set;}
    [XmlElement(Order=5)]
    public string D_CR606_SkilledNursingFacilityIndicator {get; set;}
    [XmlElement(Order=6)]
    public string D_CR607_MedicareCoverageIndicator {get; set;}
    [XmlElement(Order=7)]
    public string D_CR608_CertificationTypeCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CR609_SurgeryDate {get; set;}
    [XmlElement(Order=9)]
    public string D_CR610_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=10)]
    public string D_CR611_SurgicalProcedureCode {get; set;}
    [XmlElement(Order=11)]
    public string D_CR612_PhysicianOrderDate {get; set;}
    [XmlElement(Order=12)]
    public string D_CR613_LastVisitDate {get; set;}
    [XmlElement(Order=13)]
    public string D_CR614_PhysicianContactDate {get; set;}
    [XmlElement(Order=14)]
    public string D_CR615_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=15)]
    public string D_CR616_LastAdmissionPeriod {get; set;}
    [XmlElement(Order=16)]
    public string D_CR617_PatientDischargeFacilityTypeCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CR618_DiagnosisDate {get; set;}
    [XmlElement(Order=18)]
    public string D_CR619_DiagnosisDate {get; set;}
    [XmlElement(Order=19)]
    public string D_CR620_DiagnosisDate {get; set;}
    [XmlElement(Order=20)]
    public string D_CR621_DiagnosisDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CR6_HomeHealthCareInformation_TS837Q3_2300D_CR601_PrognosisCode {
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
        [XmlEnum("8")]
        Item8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_CRC_HomeHealth_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public U_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300 U_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public U_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300 U_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public U_CRC_HomeHealthMentalStatus_TS837Q3_2300 U_CRC_HomeHealthMentalStatus_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300D_CRC01_CodeCategory D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public S_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300D_CRC02_CertificationConditionIndicator D_CRC02_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_FunctionalLimitationCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_FunctionalLimitationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_FunctionalLimitationCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_FunctionalLimitationCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_FunctionalLimitationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300D_CRC01_CodeCategory {
        [XmlEnum("75")]
        Item75,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300D_CRC02_CertificationConditionIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300D_CRC01_CertificationConditionIndicator D_CRC01_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300D_CRC02_FunctionalLimitationCode D_CRC02_FunctionalLimitationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ActivitiesPermittedCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ActivitiesPermittedCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ActivitiesPermittedCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ActivitiesPermittedCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ActivitiesPermittedCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300D_CRC01_CertificationConditionIndicator {
        [XmlEnum("76")]
        Item76,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300D_CRC02_FunctionalLimitationCode {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_HomeHealthMentalStatus_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_CRC_HomeHealthMentalStatus_TS837Q3_2300D_CRC01_CertificationConditionIndicator D_CRC01_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_CRC_HomeHealthMentalStatus_TS837Q3_2300D_CRC02_FunctionalLimitationCode D_CRC02_FunctionalLimitationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_MentalStatusCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_MentalStatusCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_MentalStatusCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_MentalStatusCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_MentalStatusCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CRC_HomeHealthMentalStatus_TS837Q3_2300D_CRC01_CertificationConditionIndicator {
        [XmlEnum("77")]
        Item77,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CRC_HomeHealthMentalStatus_TS837Q3_2300D_CRC02_FunctionalLimitationCode {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_HI_TS837Q3_2300 {
    [XmlElementAttribute(Order=0)]
    public S_HI_PrincipalAdmittingECodeAndPatientReasonForVisitDiagnosisInformation_TS837Q3_2300 S_HI_PrincipalAdmittingECodeAndPatientReasonForVisitDiagnosisInformation_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_HI_DiagnosisRelatedGroupDRGInformation_TS837Q3_2300 S_HI_DiagnosisRelatedGroupDRGInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public U_HI_OtherDiagnosisInformation_TS837Q3_2300 U_HI_OtherDiagnosisInformation_TS837Q3_2300 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_HI_PrincipalProcedureInformation_TS837Q3_2300 S_HI_PrincipalProcedureInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public U_HI_OtherProcedureInformation_TS837Q3_2300 U_HI_OtherProcedureInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public U_HI_OccurrenceSpanInformation_TS837Q3_2300 U_HI_OccurrenceSpanInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public U_HI_OccurrenceInformation_TS837Q3_2300 U_HI_OccurrenceInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=7)]
    public U_HI_ValueInformation_TS837Q3_2300 U_HI_ValueInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public U_HI_ConditionInformation_TS837Q3_2300 U_HI_ConditionInformation_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public U_HI_TreatmentCodeInformation_TS837Q3_2300 U_HI_TreatmentCodeInformation_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_PrincipalAdmittingECodeAndPatientReasonForVisitDiagnosisInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1102_TS837Q3_2300 C_HI01_C022U1102_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U1110_TS837Q3_2300 C_HI02_C022U1110_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U1118_TS837Q3_2300 C_HI03_C022U1118_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C022U1126 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C022U1127 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C022U1128 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C022U1129 {get; set;}
    [XmlElement(Order=7)]
    public string D_HI08_C022U1130 {get; set;}
    [XmlElement(Order=8)]
    public string D_HI09_C022U1131 {get; set;}
    [XmlElement(Order=9)]
    public string D_HI10_C022U1132 {get; set;}
    [XmlElement(Order=10)]
    public string D_HI11_C022U1133 {get; set;}
    [XmlElement(Order=11)]
    public string D_HI12_C022U1134 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1102_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1102_TS837Q3_2300D_HI01_C02201U1103_CodeListQualifierCode D_HI01_C02201U1103_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1104_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U6134 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U6135 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6136 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6137 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6138 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1102_TS837Q3_2300D_HI01_C02201U1103_CodeListQualifierCode {
        BK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U1110_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI02_C022U1110_TS837Q3_2300D_HI02_C02201U1111_CodeListQualifierCode D_HI02_C02201U1111_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U1112_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U6142 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U6143 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U6144 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U6145 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U6146 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U1110_TS837Q3_2300D_HI02_C02201U1111_CodeListQualifierCode {
        BJ,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U1118_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U1119_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U1120_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U6150 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U6151 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U6152 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U6153 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U6154 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_DiagnosisRelatedGroupDRGInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1135_TS837Q3_2300 C_HI01_C022U1135_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C022U1143 {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C022U1144 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C022U1145 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C022U1146 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C022U1147 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C022U1148 {get; set;}
    [XmlElement(Order=7)]
    public string D_HI08_C022U1149 {get; set;}
    [XmlElement(Order=8)]
    public string D_HI09_C022U1150 {get; set;}
    [XmlElement(Order=9)]
    public string D_HI10_C022U1151 {get; set;}
    [XmlElement(Order=10)]
    public string D_HI11_C022U1152 {get; set;}
    [XmlElement(Order=11)]
    public string D_HI12_C022U1153 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1135_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1135_TS837Q3_2300D_HI01_C02201U1136_CodeListQualifierCode D_HI01_C02201U1136_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1137_DiagnosisRelatedGroupDRGCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U6167 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U6168 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6169 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6170 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6171 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1135_TS837Q3_2300D_HI01_C02201U1136_CodeListQualifierCode {
        DR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OtherDiagnosisInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1154_TS837Q3_2300 C_HI01_C022U1154_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U1162_TS837Q3_2300 C_HI02_C022U1162_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U1170_TS837Q3_2300 C_HI03_C022U1170_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U1178_TS837Q3_2300 C_HI04_C022U1178_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U1186_TS837Q3_2300 C_HI05_C022U1186_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U1194_TS837Q3_2300 C_HI06_C022U1194_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U1202_TS837Q3_2300 C_HI07_C022U1202_TS837Q3_2300 {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U1210_TS837Q3_2300 C_HI08_C022U1210_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U1218_TS837Q3_2300 C_HI09_C022U1218_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U1226_TS837Q3_2300 C_HI10_C022U1226_TS837Q3_2300 {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U1234_TS837Q3_2300 C_HI11_C022U1234_TS837Q3_2300 {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U1242_TS837Q3_2300 C_HI12_C022U1242_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1154_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1154_TS837Q3_2300D_HI01_C02201U1155_CodeListQualifierCode D_HI01_C02201U1155_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1156_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U6186 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U6187 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6188 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6189 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6190 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1154_TS837Q3_2300D_HI01_C02201U1155_CodeListQualifierCode {
        BF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U1162_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI02_C022U1162_TS837Q3_2300D_HI02_C02201U1163_CodeListQualifierCode D_HI02_C02201U1163_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U1164_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U6194 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U6195 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U6196 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U6197 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U6198 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U1162_TS837Q3_2300D_HI02_C02201U1163_CodeListQualifierCode {
        BF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U1170_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U1171_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U1172_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U6202 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U6203 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U6204 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U6205 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U6206 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U1178_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U1179_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U1180_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U6210 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U6211 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U6212 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U6213 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U6214 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U1186_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U1187_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U1188_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U6218 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U6219 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U6220 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U6221 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U6222 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U1194_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U1195_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U1196_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U6226 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U6227 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U6228 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U6229 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U6230 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U1202_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U1203_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U1204_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U6234 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U6235 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U6236 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U6237 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U6238 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U1210_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U1211_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U1212_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U6242 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U6243 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U6244 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U6245 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U6246 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U1218_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U1219_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U1220_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U6250 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U6251 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U6252 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U6253 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U6254 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U1226_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U1227_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U1228_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U6258 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U6259 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U6260 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U6261 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U6262 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U1234_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U1235_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U1236_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U6266 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U6267 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U6268 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U6269 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U6270 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U1242_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U1243_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U1244_OtherDiagnosis {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U6274 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U6275 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U6276 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U6277 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U6278 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_PrincipalProcedureInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1250_TS837Q3_2300 C_HI01_C022U1250_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C022U1258 {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C022U1259 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C022U1260 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C022U1261 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C022U1262 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C022U1263 {get; set;}
    [XmlElement(Order=7)]
    public string D_HI08_C022U1264 {get; set;}
    [XmlElement(Order=8)]
    public string D_HI09_C022U1265 {get; set;}
    [XmlElement(Order=9)]
    public string D_HI10_C022U1266 {get; set;}
    [XmlElement(Order=10)]
    public string D_HI11_C022U1267 {get; set;}
    [XmlElement(Order=11)]
    public string D_HI12_C022U1268 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1250_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1250_TS837Q3_2300D_HI01_C02201U1251_CodeListQualifierCode D_HI01_C02201U1251_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1252_PrincipalProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U1253_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U1254_DateTimePeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6284 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6285 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6286 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1250_TS837Q3_2300D_HI01_C02201U1251_CodeListQualifierCode {
        BP,
        BR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OtherProcedureInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1269_TS837Q3_2300 C_HI01_C022U1269_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U1277_TS837Q3_2300 C_HI02_C022U1277_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U1285_TS837Q3_2300 C_HI03_C022U1285_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U1293_TS837Q3_2300 C_HI04_C022U1293_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U1301_TS837Q3_2300 C_HI05_C022U1301_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U1309_TS837Q3_2300 C_HI06_C022U1309_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U1317_TS837Q3_2300 C_HI07_C022U1317_TS837Q3_2300 {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U1325_TS837Q3_2300 C_HI08_C022U1325_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U1333_TS837Q3_2300 C_HI09_C022U1333_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U1341_TS837Q3_2300 C_HI10_C022U1341_TS837Q3_2300 {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U1349_TS837Q3_2300 C_HI11_C022U1349_TS837Q3_2300 {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U1357_TS837Q3_2300 C_HI12_C022U1357_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1269_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1269_TS837Q3_2300D_HI01_C02201U1270_CodeListQualifierCode D_HI01_C02201U1270_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1271_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U1272_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U1273_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6303 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6304 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6305 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1269_TS837Q3_2300D_HI01_C02201U1270_CodeListQualifierCode {
        BO,
        BQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U1277_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI02_C022U1277_TS837Q3_2300D_HI02_C02201U1278_CodeListQualifierCode D_HI02_C02201U1278_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U1279_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U1280_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U1281_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U6311 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U6312 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U6313 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U1277_TS837Q3_2300D_HI02_C02201U1278_CodeListQualifierCode {
        BO,
        BQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U1285_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U1286_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U1287_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U1288_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U1289_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U6319 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U6320 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U6321 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U1293_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U1294_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U1295_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U1296_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U1297_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U6327 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U6328 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U6329 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U1301_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U1302_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U1303_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U1304_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U1305_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U6335 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U6336 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U6337 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U1309_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U1310_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U1311_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U1312_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U1313_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U6343 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U6344 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U6345 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U1317_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U1318_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U1319_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U1320_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U1321_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U6351 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U6352 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U6353 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U1325_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U1326_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U1327_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U1328_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U1329_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U6359 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U6360 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U6361 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U1333_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U1334_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U1335_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U1336_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U1337_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U6367 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U6368 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U6369 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U1341_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U1342_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U1343_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U1344_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U1345_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U6375 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U6376 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U6377 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U1349_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U1350_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U1351_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U1352_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U1353_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U6383 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U6384 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U6385 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U1357_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U1358_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U1359_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U1360_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U1361_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U6391 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U6392 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U6393 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OccurrenceSpanInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1365_TS837Q3_2300 C_HI01_C022U1365_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U1373_TS837Q3_2300 C_HI02_C022U1373_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U1381_TS837Q3_2300 C_HI03_C022U1381_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U1389_TS837Q3_2300 C_HI04_C022U1389_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U1397_TS837Q3_2300 C_HI05_C022U1397_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U1405_TS837Q3_2300 C_HI06_C022U1405_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U1413_TS837Q3_2300 C_HI07_C022U1413_TS837Q3_2300 {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U1421_TS837Q3_2300 C_HI08_C022U1421_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U1429_TS837Q3_2300 C_HI09_C022U1429_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U1437_TS837Q3_2300 C_HI10_C022U1437_TS837Q3_2300 {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U1445_TS837Q3_2300 C_HI11_C022U1445_TS837Q3_2300 {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U1453_TS837Q3_2300 C_HI12_C022U1453_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1365_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1365_TS837Q3_2300D_HI01_C02201U1366_CodeListQualifierCode D_HI01_C02201U1366_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1367_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U1368_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U1369_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6399 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6400 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6401 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1365_TS837Q3_2300D_HI01_C02201U1366_CodeListQualifierCode {
        BI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U1373_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI02_C022U1373_TS837Q3_2300D_HI02_C02201U1374_CodeListQualifierCode D_HI02_C02201U1374_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U1375_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U1376_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U1377_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U6407 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U6408 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U6409 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U1373_TS837Q3_2300D_HI02_C02201U1374_CodeListQualifierCode {
        BI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U1381_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U1382_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U1383_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U1384_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U1385_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U6415 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U6416 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U6417 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U1389_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U1390_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U1391_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U1392_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U1393_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U6423 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U6424 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U6425 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U1397_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U1398_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U1399_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U1400_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U1401_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U6431 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U6432 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U6433 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U1405_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U1406_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U1407_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U1408_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U1409_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U6439 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U6440 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U6441 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U1413_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U1414_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U1415_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U1416_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U1417_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U6447 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U6448 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U6449 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U1421_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U1422_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U1423_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U1424_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U1425_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U6455 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U6456 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U6457 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U1429_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U1430_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U1431_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U1432_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U1433_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U6463 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U6464 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U6465 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U1437_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U1438_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U1439_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U1440_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U1441_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U6471 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U6472 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U6473 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U1445_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U1446_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U1447_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U1448_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U1449_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U6479 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U6480 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U6481 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U1453_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U1454_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U1455_OccurrenceSpanCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U1456_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U1457_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U6487 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U6488 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U6489 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_OccurrenceInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1461_TS837Q3_2300 C_HI01_C022U1461_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U1469_TS837Q3_2300 C_HI02_C022U1469_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U1477_TS837Q3_2300 C_HI03_C022U1477_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U1485_TS837Q3_2300 C_HI04_C022U1485_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U1493_TS837Q3_2300 C_HI05_C022U1493_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U1501_TS837Q3_2300 C_HI06_C022U1501_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U1509_TS837Q3_2300 C_HI07_C022U1509_TS837Q3_2300 {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U1517_TS837Q3_2300 C_HI08_C022U1517_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U1525_TS837Q3_2300 C_HI09_C022U1525_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U1533_TS837Q3_2300 C_HI10_C022U1533_TS837Q3_2300 {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U1541_TS837Q3_2300 C_HI11_C022U1541_TS837Q3_2300 {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U1549_TS837Q3_2300 C_HI12_C022U1549_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1461_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1461_TS837Q3_2300D_HI01_C02201U1462_CodeListQualifierCode D_HI01_C02201U1462_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1463_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U1464_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U1465_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6495 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6496 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6497 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1461_TS837Q3_2300D_HI01_C02201U1462_CodeListQualifierCode {
        BH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U1469_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI02_C022U1469_TS837Q3_2300D_HI02_C02201U1470_CodeListQualifierCode D_HI02_C02201U1470_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U1471_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U1472_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U1473_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U6503 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U6504 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U6505 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U1469_TS837Q3_2300D_HI02_C02201U1470_CodeListQualifierCode {
        BH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U1477_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U1478_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U1479_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U1480_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U1481_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U6511 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U6512 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U6513 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U1485_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U1486_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U1487_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U1488_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U1489_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U6519 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U6520 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U6521 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U1493_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U1494_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U1495_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U1496_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U1497_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U6527 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U6528 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U6529 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U1501_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U1502_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U1503_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U1504_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U1505_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U6535 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U6536 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U6537 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U1509_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U1510_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U1511_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U1512_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U1513_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U6543 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U6544 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U6545 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U1517_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U1518_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U1519_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U1520_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U1521_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U6551 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U6552 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U6553 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U1525_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U1526_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U1527_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U1528_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U1529_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U6559 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U6560 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U6561 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U1533_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U1534_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U1535_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U1536_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U1537_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U6567 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U6568 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U6569 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U1541_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U1542_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U1543_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U1544_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U1545_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U6575 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U6576 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U6577 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U1549_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U1550_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U1551_OccurrenceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U1552_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U1553_OccurrenceOrOccurrenceSpanCodeAssociatedDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U6583 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U6584 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U6585 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_ValueInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1557_TS837Q3_2300 C_HI01_C022U1557_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U1565_TS837Q3_2300 C_HI02_C022U1565_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U1573_TS837Q3_2300 C_HI03_C022U1573_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U1581_TS837Q3_2300 C_HI04_C022U1581_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U1589_TS837Q3_2300 C_HI05_C022U1589_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U1597_TS837Q3_2300 C_HI06_C022U1597_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U1605_TS837Q3_2300 C_HI07_C022U1605_TS837Q3_2300 {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U1613_TS837Q3_2300 C_HI08_C022U1613_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U1621_TS837Q3_2300 C_HI09_C022U1621_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U1629_TS837Q3_2300 C_HI10_C022U1629_TS837Q3_2300 {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U1637_TS837Q3_2300 C_HI11_C022U1637_TS837Q3_2300 {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U1645_TS837Q3_2300 C_HI12_C022U1645_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1557_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1557_TS837Q3_2300D_HI01_C02201U1558_CodeListQualifierCode D_HI01_C02201U1558_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1559_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U6589 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U6590 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U1562_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6592 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6593 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1557_TS837Q3_2300D_HI01_C02201U1558_CodeListQualifierCode {
        BE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U1565_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI02_C022U1565_TS837Q3_2300D_HI02_C02201U1566_CodeListQualifierCode D_HI02_C02201U1566_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U1567_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U6597 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U6598 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U1570_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U6600 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U6601 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U1565_TS837Q3_2300D_HI02_C02201U1566_CodeListQualifierCode {
        BE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U1573_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U1574_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U1575_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U6605 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U6606 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U1578_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U6608 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U6609 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U1581_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U1582_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U1583_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U6613 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U6614 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U1586_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U6616 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U6617 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U1589_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U1590_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U1591_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U6621 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U6622 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U1594_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U6624 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U6625 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U1597_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U1598_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U1599_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U6629 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U6630 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U1602_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U6632 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U6633 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U1605_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U1606_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U1607_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U6637 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U6638 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U1610_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U6640 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U6641 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U1613_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U1614_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U1615_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U6645 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U6646 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U1618_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U6648 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U6649 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U1621_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U1622_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U1623_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U6653 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U6654 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U1626_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U6656 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U6657 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U1629_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U1630_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U1631_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U6661 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U6662 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U1634_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U6664 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U6665 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U1637_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U1638_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U1639_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U6669 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U6670 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U1642_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U6672 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U6673 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U1645_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U1646_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U1647_ValueCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U6677 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U6678 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U1650_ValueCodeAssociatedAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U6680 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U6681 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_ConditionInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1653_TS837Q3_2300 C_HI01_C022U1653_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U1661_TS837Q3_2300 C_HI02_C022U1661_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U1669_TS837Q3_2300 C_HI03_C022U1669_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U1677_TS837Q3_2300 C_HI04_C022U1677_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U1685_TS837Q3_2300 C_HI05_C022U1685_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U1693_TS837Q3_2300 C_HI06_C022U1693_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U1701_TS837Q3_2300 C_HI07_C022U1701_TS837Q3_2300 {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U1709_TS837Q3_2300 C_HI08_C022U1709_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U1717_TS837Q3_2300 C_HI09_C022U1717_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U1725_TS837Q3_2300 C_HI10_C022U1725_TS837Q3_2300 {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U1733_TS837Q3_2300 C_HI11_C022U1733_TS837Q3_2300 {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U1741_TS837Q3_2300 C_HI12_C022U1741_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1653_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1653_TS837Q3_2300D_HI01_C02201U1654_CodeListQualifierCode D_HI01_C02201U1654_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1655_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U6685 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U6686 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6687 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6688 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6689 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1653_TS837Q3_2300D_HI01_C02201U1654_CodeListQualifierCode {
        BG,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U1661_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI02_C022U1661_TS837Q3_2300D_HI02_C02201U1662_CodeListQualifierCode D_HI02_C02201U1662_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U1663_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U6693 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U6694 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U6695 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U6696 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U6697 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U1661_TS837Q3_2300D_HI02_C02201U1662_CodeListQualifierCode {
        BG,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U1669_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U1670_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U1671_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U6701 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U6702 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U6703 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U6704 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U6705 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U1677_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U1678_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U1679_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U6709 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U6710 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U6711 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U6712 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U6713 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U1685_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U1686_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U1687_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U6717 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U6718 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U6719 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U6720 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U6721 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U1693_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U1694_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U1695_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U6725 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U6726 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U6727 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U6728 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U6729 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U1701_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U1702_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U1703_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U6733 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U6734 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U6735 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U6736 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U6737 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U1709_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U1710_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U1711_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U6741 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U6742 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U6743 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U6744 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U6745 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U1717_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U1718_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U1719_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U6749 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U6750 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U6751 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U6752 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U6753 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U1725_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U1726_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U1727_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U6757 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U6758 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U6759 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U6760 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U6761 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U1733_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U1734_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U1735_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U6765 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U6766 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U6767 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U6768 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U6769 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U1741_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U1742_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U1743_ConditionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U6773 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U6774 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U6775 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U6776 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U6777 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_TreatmentCodeInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1749_TS837Q3_2300 C_HI01_C022U1749_TS837Q3_2300 {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U1757_TS837Q3_2300 C_HI02_C022U1757_TS837Q3_2300 {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U1765_TS837Q3_2300 C_HI03_C022U1765_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U1773_TS837Q3_2300 C_HI04_C022U1773_TS837Q3_2300 {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U1781_TS837Q3_2300 C_HI05_C022U1781_TS837Q3_2300 {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U1789_TS837Q3_2300 C_HI06_C022U1789_TS837Q3_2300 {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U1797_TS837Q3_2300 C_HI07_C022U1797_TS837Q3_2300 {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U1805_TS837Q3_2300 C_HI08_C022U1805_TS837Q3_2300 {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U1813_TS837Q3_2300 C_HI09_C022U1813_TS837Q3_2300 {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U1821_TS837Q3_2300 C_HI10_C022U1821_TS837Q3_2300 {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U1829_TS837Q3_2300 C_HI11_C022U1829_TS837Q3_2300 {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U1837_TS837Q3_2300 C_HI12_C022U1837_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U1749_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI01_C022U1749_TS837Q3_2300D_HI01_C02201U1750_CodeListQualifierCode D_HI01_C02201U1750_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U1751_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U6781 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U6782 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U6783 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U6784 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U6785 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U1749_TS837Q3_2300D_HI01_C02201U1750_CodeListQualifierCode {
        TC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U1757_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public C_HI02_C022U1757_TS837Q3_2300D_HI02_C02201U1758_CodeListQualifierCode D_HI02_C02201U1758_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U1759_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U6789 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U6790 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U6791 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U6792 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U6793 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U1757_TS837Q3_2300D_HI02_C02201U1758_CodeListQualifierCode {
        TC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U1765_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U1766_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U1767_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U6797 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U6798 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U6799 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U6800 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U6801 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U1773_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U1774_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U1775_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U6805 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U6806 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U6807 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U6808 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U6809 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U1781_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U1782_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U1783_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U6813 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U6814 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U6815 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U6816 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U6817 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U1789_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U1790_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U1791_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U6821 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U6822 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U6823 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U6824 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U6825 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U1797_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U1798_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U1799_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U6829 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U6830 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U6831 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U6832 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U6833 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U1805_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U1806_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U1807_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U6837 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U6838 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U6839 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U6840 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U6841 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U1813_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U1814_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U1815_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U6845 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U6846 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U6847 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U6848 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U6849 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U1821_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U1822_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U1823_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U6853 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U6854 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U6855 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U6856 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U6857 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U1829_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U1830_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U1831_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U6861 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U6862 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U6863 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U6864 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U6865 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U1837_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U1838_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U1839_TreatmentCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U6869 {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U6870 {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U6871 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U6872 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U6873 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_ClaimQuantity_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_QTY_ClaimQuantity_TS837Q3_2300D_QTY01_QuantityQualifier D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_ClaimDaysCount {get; set;}
    [XmlElement(Order=2)]
    public C_QTY03_C001U1845_TS837Q3_2300 C_QTY03_C001U1845_TS837Q3_2300 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_QTY_ClaimQuantity_TS837Q3_2300D_QTY01_QuantityQualifier {
        CA,
        CD,
        LA,
        NA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_QTY03_C001U1845_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public string D_QTY03_C00101U1846_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY03_C00102U6876 {get; set;}
    [XmlElement(Order=2)]
    public string D_QTY03_C00103U6877 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY03_C00104U6878 {get; set;}
    [XmlElement(Order=4)]
    public string D_QTY03_C00105U6879 {get; set;}
    [XmlElement(Order=5)]
    public string D_QTY03_C00106U6880 {get; set;}
    [XmlElement(Order=6)]
    public string D_QTY03_C00107U6881 {get; set;}
    [XmlElement(Order=7)]
    public string D_QTY03_C00108U6882 {get; set;}
    [XmlElement(Order=8)]
    public string D_QTY03_C00109U6883 {get; set;}
    [XmlElement(Order=9)]
    public string D_QTY03_C00110U6884 {get; set;}
    [XmlElement(Order=10)]
    public string D_QTY03_C00111U6885 {get; set;}
    [XmlElement(Order=11)]
    public string D_QTY03_C00112U6886 {get; set;}
    [XmlElement(Order=12)]
    public string D_QTY03_C00113U6887 {get; set;}
    [XmlElement(Order=13)]
    public string D_QTY03_C00114U6888 {get; set;}
    [XmlElement(Order=14)]
    public string D_QTY03_C00115U6889 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HCP_ClaimPricingRepricingInformation_TS837Q3_2300 {
    [XmlElement(Order=0)]
    public S_HCP_ClaimPricingRepricingInformation_TS837Q3_2300D_HCP01_PricingMethodology D_HCP01_PricingMethodology {get; set;}
    [XmlElement(Order=1)]
    public string D_HCP02_RepricedAllowedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_HCP03_RepricedSavingAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_HCP04_RepricingOrganizationIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_HCP05_RepricingPerDiemOrFlatRateAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HCP06_RepricedApprovedDRGCode {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_RepricedApprovedAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_RepricedApprovedRevenueCode {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_RepricedApprovedHCPCSCode {get; set;}
    [XmlElement(Order=10)]
    public string D_HCP11_UnitOrBasisForMeasurementCode {get; set;}
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
    public enum S_HCP_ClaimPricingRepricingInformation_TS837Q3_2300D_HCP01_PricingMethodology {
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
    public class G_TS837Q3_2305 {
    [XmlElement(Order=0)]
    public S_CR7_HomeHealthCarePlanInformation_TS837Q3_2305 S_CR7_HomeHealthCarePlanInformation_TS837Q3_2305 {get; set;}
    [XmlElement("S_HSD_HealthCareServicesDelivery_TS837Q3_2305",Order=1)]
    public List<S_HSD_HealthCareServicesDelivery_TS837Q3_2305> S_HSD_HealthCareServicesDelivery_TS837Q3_2305 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR7_HomeHealthCarePlanInformation_TS837Q3_2305 {
    [XmlElement(Order=0)]
    public S_CR7_HomeHealthCarePlanInformation_TS837Q3_2305D_CR701_DisciplineTypeCode D_CR701_DisciplineTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR702_VisitsPriorToRecertificationDateCount {get; set;}
    [XmlElement(Order=2)]
    public string D_CR703_TotalVisitsProjectedThisCertificationCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CR7_HomeHealthCarePlanInformation_TS837Q3_2305D_CR701_DisciplineTypeCode {
        AI,
        MS,
        OT,
        PT,
        SN,
        ST,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HSD_HealthCareServicesDelivery_TS837Q3_2305 {
    [XmlElement(Order=0)]
    public S_HSD_HealthCareServicesDelivery_TS837Q3_2305D_HSD01_Visits D_HSD01_Visits {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_NumberOfVisits {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_FrequencyPeriod {get; set;}
    [XmlElement(Order=3)]
    public string D_HSD04_FrequencyCount {get; set;}
    [XmlElement(Order=4)]
    public string D_HSD05_DurationOfVisitsUnits {get; set;}
    [XmlElement(Order=5)]
    public string D_HSD06_DurationOfVisitsNumberOfUnits {get; set;}
    [XmlElement(Order=6)]
    public string D_HSD07_ShipDeliveryOrCalendarPatternCode {get; set;}
    [XmlElement(Order=7)]
    public string D_HSD08_DeliveryPatternTimeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_HSD_HealthCareServicesDelivery_TS837Q3_2305D_HSD01_Visits {
        VS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q3_2310 {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q3_2310A G_TS837Q3_2310A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q3_2310B G_TS837Q3_2310B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837Q3_2310C G_TS837Q3_2310C {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837Q3_2310E G_TS837Q3_2310E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2310A {
    [XmlElement(Order=0)]
    public S_NM1_AttendingPhysicianName_TS837Q3_2310A S_NM1_AttendingPhysicianName_TS837Q3_2310A {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AttendingPhysicianSpecialtyInformation_TS837Q3_2310A S_PRV_AttendingPhysicianSpecialtyInformation_TS837Q3_2310A {get; set;}
    [XmlElement("S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2310A",Order=2)]
    public List<S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2310A> S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2310A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AttendingPhysicianName_TS837Q3_2310A {
    [XmlElement(Order=0)]
    public S_NM1_AttendingPhysicianName_TS837Q3_2310AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_AttendingPhysicianName_TS837Q3_2310AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AttendingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AttendingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AttendingPhysicianMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AttendingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AttendingPhysicianPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AttendingPhysicianName_TS837Q3_2310AD_NM101_EntityIdentifierCode {
        [XmlEnum("71")]
        Item71,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AttendingPhysicianName_TS837Q3_2310AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AttendingPhysicianSpecialtyInformation_TS837Q3_2310A {
    [XmlElement(Order=0)]
    public S_PRV_AttendingPhysicianSpecialtyInformation_TS837Q3_2310AD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AttendingPhysicianSpecialtyInformation_TS837Q3_2310AD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U1861 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_AttendingPhysicianSpecialtyInformation_TS837Q3_2310AD_PRV01_ProviderCode {
        AT,
        SU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_AttendingPhysicianSpecialtyInformation_TS837Q3_2310AD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2310A {
    [XmlElement(Order=0)]
    public S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2310AD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AttendingPhysicianSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1862 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2310AD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
        SY,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2310B {
    [XmlElement(Order=0)]
    public S_NM1_OperatingPhysicianName_TS837Q3_2310B S_NM1_OperatingPhysicianName_TS837Q3_2310B {get; set;}
    [XmlElement("S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2310B",Order=1)]
    public List<S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2310B> S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2310B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OperatingPhysicianName_TS837Q3_2310B {
    [XmlElement(Order=0)]
    public S_NM1_OperatingPhysicianName_TS837Q3_2310BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OperatingPhysicianName_TS837Q3_2310BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OperatingPhysicanMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OperatingPhysicianPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OperatingPhysicianName_TS837Q3_2310BD_NM101_EntityIdentifierCode {
        [XmlEnum("72")]
        Item72,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OperatingPhysicianName_TS837Q3_2310BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2310B {
    [XmlElement(Order=0)]
    public S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2310BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OperatingPhysicianSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1864 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2310BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
        SY,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2310C {
    [XmlElement(Order=0)]
    public S_NM1_OtherProviderName_TS837Q3_2310C S_NM1_OtherProviderName_TS837Q3_2310C {get; set;}
    [XmlElement("S_REF_OtherProviderSecondaryIdentification_TS837Q3_2310C",Order=1)]
    public List<S_REF_OtherProviderSecondaryIdentification_TS837Q3_2310C> S_REF_OtherProviderSecondaryIdentification_TS837Q3_2310C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherProviderName_TS837Q3_2310C {
    [XmlElement(Order=0)]
    public S_NM1_OtherProviderName_TS837Q3_2310CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherProviderName_TS837Q3_2310CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherPhysicianIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherProviderName_TS837Q3_2310CD_NM101_EntityIdentifierCode {
        [XmlEnum("73")]
        Item73,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherProviderName_TS837Q3_2310CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherProviderSecondaryIdentification_TS837Q3_2310C {
    [XmlElement(Order=0)]
    public S_REF_OtherProviderSecondaryIdentification_TS837Q3_2310CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1866 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherProviderSecondaryIdentification_TS837Q3_2310CD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
        SY,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2310E {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityName_TS837Q3_2310E S_NM1_ServiceFacilityName_TS837Q3_2310E {get; set;}
    [XmlElement(Order=1)]
    public S_N3_ServiceFacilityAddress_TS837Q3_2310E S_N3_ServiceFacilityAddress_TS837Q3_2310E {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ServiceFacilityCityStateZipCode_TS837Q3_2310E S_N4_ServiceFacilityCityStateZipCode_TS837Q3_2310E {get; set;}
    [XmlElement("S_REF_ServiceFacilitySecondaryIdentification_TS837Q3_2310E",Order=3)]
    public List<S_REF_ServiceFacilitySecondaryIdentification_TS837Q3_2310E> S_REF_ServiceFacilitySecondaryIdentification_TS837Q3_2310E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceFacilityName_TS837Q3_2310E {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityName_TS837Q3_2310ED_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ServiceFacilityName_TS837Q3_2310ED_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_LaboratoryOrFacilityName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_LaboratoryOrFacilityPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceFacilityName_TS837Q3_2310ED_NM101_EntityIdentifierCode {
        FA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceFacilityName_TS837Q3_2310ED_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_ServiceFacilityAddress_TS837Q3_2310E {
    [XmlElement(Order=0)]
    public string D_N301_LaboratoryOrFacilityAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_LaboratoryOrFacilityAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceFacilityCityStateZipCode_TS837Q3_2310E {
    [XmlElement(Order=0)]
    public string D_N401_LaboratoryOrFacilityCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_LaboratoryOrFacilityStateOrProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_LaboratoryOrFacilityPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceFacilitySecondaryIdentification_TS837Q3_2310E {
    [XmlElement(Order=0)]
    public S_REF_ServiceFacilitySecondaryIdentification_TS837Q3_2310ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LaboratoryOrFacilitySecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1870 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceFacilitySecondaryIdentification_TS837Q3_2310ED_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        [XmlEnum("1J")]
        Item1J,
        EI,
        FH,
        G2,
        G5,
        LU,
        N5,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_SBR_OtherSubscriberInformation_TS837Q3_2320 S_SBR_OtherSubscriberInformation_TS837Q3_2320 {get; set;}
    [XmlElement("S_CAS_ClaimLevelAdjustment_TS837Q3_2320",Order=1)]
    public List<S_CAS_ClaimLevelAdjustment_TS837Q3_2320> S_CAS_ClaimLevelAdjustment_TS837Q3_2320 {get; set;}
    [XmlElement(Order=2)]
    public A_AMT_TS837Q3_2320 A_AMT_TS837Q3_2320 {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_OtherSubscriberDemographicInformation_TS837Q3_2320 S_DMG_OtherSubscriberDemographicInformation_TS837Q3_2320 {get; set;}
    [XmlElement(Order=4)]
    public S_OI_OtherInsuranceCoverageInformation_TS837Q3_2320 S_OI_OtherInsuranceCoverageInformation_TS837Q3_2320 {get; set;}
    [XmlElement(Order=5)]
    public S_MIA_MedicareInpatientAdjudicationInformation_TS837Q3_2320 S_MIA_MedicareInpatientAdjudicationInformation_TS837Q3_2320 {get; set;}
    [XmlElement(Order=6)]
    public S_MOA_MedicareOutpatientAdjudicationInformation_TS837Q3_2320 S_MOA_MedicareOutpatientAdjudicationInformation_TS837Q3_2320 {get; set;}
    [XmlElement(Order=7)]
    public A_TS837Q3_2330 A_TS837Q3_2330 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SBR_OtherSubscriberInformation_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_SBR_OtherSubscriberInformation_TS837Q3_2320D_SBR01_PayerResponsibilitySequenceNumberCode D_SBR01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public S_SBR_OtherSubscriberInformation_TS837Q3_2320D_SBR02_IndividualRelationshipCode D_SBR02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SBR03_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=3)]
    public string D_SBR04_OtherInsuredGroupName {get; set;}
    [XmlElement(Order=4)]
    public string D_SBR05 {get; set;}
    [XmlElement(Order=5)]
    public string D_SBR06 {get; set;}
    [XmlElement(Order=6)]
    public string D_SBR07 {get; set;}
    [XmlElement(Order=7)]
    public string D_SBR08 {get; set;}
    [XmlElement(Order=8)]
    public string D_SBR09_ClaimFilingIndicatorCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_SBR_OtherSubscriberInformation_TS837Q3_2320D_SBR01_PayerResponsibilitySequenceNumberCode {
        P,
        S,
        T,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_SBR_OtherSubscriberInformation_TS837Q3_2320D_SBR02_IndividualRelationshipCode {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("04")]
        Item04,
        [XmlEnum("05")]
        Item05,
        [XmlEnum("07")]
        Item07,
        [XmlEnum("10")]
        Item10,
        [XmlEnum("15")]
        Item15,
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
        [XmlEnum("29")]
        Item29,
        [XmlEnum("32")]
        Item32,
        [XmlEnum("33")]
        Item33,
        [XmlEnum("36")]
        Item36,
        [XmlEnum("39")]
        Item39,
        [XmlEnum("40")]
        Item40,
        [XmlEnum("41")]
        Item41,
        [XmlEnum("43")]
        Item43,
        [XmlEnum("53")]
        Item53,
        G8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ClaimLevelAdjustment_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_CAS_ClaimLevelAdjustment_TS837Q3_2320D_CAS01_ClaimAdjustmentGroupCode D_CAS01_ClaimAdjustmentGroupCode {get; set;}
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
    public enum S_CAS_ClaimLevelAdjustment_TS837Q3_2320D_CAS01_ClaimAdjustmentGroupCode {
        CO,
        CR,
        OA,
        PI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_AMT_TS837Q3_2320 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_PayerPriorPayment_TS837Q3_2320 S_AMT_PayerPriorPayment_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_TS837Q3_2320 S_AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_TS837Q3_2320 S_AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_AMT_DiagnosticRelatedGroupDRGOutlierAmount_TS837Q3_2320 S_AMT_DiagnosticRelatedGroupDRGOutlierAmount_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_TS837Q3_2320 S_AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_AMT_MedicarePaidAmount100_TS837Q3_2320 S_AMT_MedicarePaidAmount100_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_AMT_MedicarePaidAmount80_TS837Q3_2320 S_AMT_MedicarePaidAmount80_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=7)]
    public S_AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_TS837Q3_2320 S_AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=8)]
    public S_AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_TS837Q3_2320 S_AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=9)]
    public S_AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_TS837Q3_2320 S_AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_TS837Q3_2320 {get; set;}
    [XmlElementAttribute(Order=10)]
    public S_AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_TS837Q3_2320 S_AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_TS837Q3_2320 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_PayerPriorPayment_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_PayerPriorPayment_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_OtherPayerPatientPaidAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_PayerPriorPayment_TS837Q3_2320D_AMT01_AmountQualifierCode {
        C4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_AllowedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBTotalAllowedAmount_TS837Q3_2320D_AMT01_AmountQualifierCode {
        B6,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_CoordinationOfBenefitsTotalSubmittedChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBTotalSubmittedCharges_TS837Q3_2320D_AMT01_AmountQualifierCode {
        T3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_DiagnosticRelatedGroupDRGOutlierAmount_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_DiagnosticRelatedGroupDRGOutlierAmount_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ClaimDRGOutlierAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_DiagnosticRelatedGroupDRGOutlierAmount_TS837Q3_2320D_AMT01_AmountQualifierCode {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_TotalMedicarePaidAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBTotalMedicarePaidAmount_TS837Q3_2320D_AMT01_AmountQualifierCode {
        N1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_MedicarePaidAmount100_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_MedicarePaidAmount100_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_MedicarePaidAt100Amount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_MedicarePaidAmount100_TS837Q3_2320D_AMT01_AmountQualifierCode {
        KF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_MedicarePaidAmount80_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_MedicarePaidAmount80_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_MedicarePaidAt80Amount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_MedicarePaidAmount80_TS837Q3_2320D_AMT01_AmountQualifierCode {
        PG,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PaidFromPartAMedicareTrustFundAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBMedicareATrustFundPaidAmount_TS837Q3_2320D_AMT01_AmountQualifierCode {
        AA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PaidFromPartBMedicareTrustFundAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBMedicareBTrustFundPaidAmount_TS837Q3_2320D_AMT01_AmountQualifierCode {
        B1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_NonCoveredChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBTotalNoncoveredAmount_TS837Q3_2320D_AMT01_AmountQualifierCode {
        A8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_TS837Q3_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ClaimTotalDeniedChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBTotalDeniedAmount_TS837Q3_2320D_AMT01_AmountQualifierCode {
        YT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_OtherSubscriberDemographicInformation_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public S_DMG_OtherSubscriberDemographicInformation_TS837Q3_2320D_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_OtherInsuredBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_OtherInsuredGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04 {get; set;}
    [XmlElement(Order=4)]
    public string D_DMG05 {get; set;}
    [XmlElement(Order=5)]
    public string D_DMG06 {get; set;}
    [XmlElement(Order=6)]
    public string D_DMG07 {get; set;}
    [XmlElement(Order=7)]
    public string D_DMG08 {get; set;}
    [XmlElement(Order=8)]
    public string D_DMG09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DMG_OtherSubscriberDemographicInformation_TS837Q3_2320D_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_OI_OtherInsuranceCoverageInformation_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public string D_OI01 {get; set;}
    [XmlElement(Order=1)]
    public string D_OI02 {get; set;}
    [XmlElement(Order=2)]
    public string D_OI03_BenefitsAssignmentCertificationIndicator {get; set;}
    [XmlElement(Order=3)]
    public string D_OI04 {get; set;}
    [XmlElement(Order=4)]
    public string D_OI05 {get; set;}
    [XmlElement(Order=5)]
    public string D_OI06_ReleaseOfInformationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MIA_MedicareInpatientAdjudicationInformation_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public string D_MIA01_CoveredDaysOrVisitsCount {get; set;}
    [XmlElement(Order=1)]
    public string D_MIA02_LifetimeReserveDaysCount {get; set;}
    [XmlElement(Order=2)]
    public string D_MIA03_LifetimePsychiatricDaysCount {get; set;}
    [XmlElement(Order=3)]
    public string D_MIA04_ClaimDRGAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_MIA05_RemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MIA06_ClaimDisproportionateShareAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_MIA07_ClaimMSPPassthroughAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_MIA08_ClaimPPSCapitalAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MIA09_PPSCapitalFSPDRGAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_MIA10_PPSCapitalHSPDRGAmount {get; set;}
    [XmlElement(Order=10)]
    public string D_MIA11_PPSCapitalDSHDRGAmount {get; set;}
    [XmlElement(Order=11)]
    public string D_MIA12_OldCapitalAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_MIA13_PPSCapitalIMEAmount {get; set;}
    [XmlElement(Order=13)]
    public string D_MIA14_PPSOperatingHospitalSpecificDRGAmount {get; set;}
    [XmlElement(Order=14)]
    public string D_MIA15_CostReportDayCount {get; set;}
    [XmlElement(Order=15)]
    public string D_MIA16_PPSOperatingFederalSpecificDRGAmount {get; set;}
    [XmlElement(Order=16)]
    public string D_MIA17_ClaimPPSCapitalOutlierAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_MIA18_ClaimIndirectTeachingAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_MIA19_NonpayableProfessionalComponentAmount {get; set;}
    [XmlElement(Order=19)]
    public string D_MIA20_RemarkCode {get; set;}
    [XmlElement(Order=20)]
    public string D_MIA21_RemarkCode {get; set;}
    [XmlElement(Order=21)]
    public string D_MIA22_RemarkCode {get; set;}
    [XmlElement(Order=22)]
    public string D_MIA23_RemarkCode {get; set;}
    [XmlElement(Order=23)]
    public string D_MIA24_PPSCapitalExceptionAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MOA_MedicareOutpatientAdjudicationInformation_TS837Q3_2320 {
    [XmlElement(Order=0)]
    public string D_MOA01_ReimbursementRate {get; set;}
    [XmlElement(Order=1)]
    public string D_MOA02_ClaimHCPCSPayableAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MOA03_RemarkCode {get; set;}
    [XmlElement(Order=3)]
    public string D_MOA04_RemarkCode {get; set;}
    [XmlElement(Order=4)]
    public string D_MOA05_RemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MOA06_RemarkCode {get; set;}
    [XmlElement(Order=6)]
    public string D_MOA07_RemarkCode {get; set;}
    [XmlElement(Order=7)]
    public string D_MOA08_ClaimESRDPaymentAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MOA09_NonpayableProfessionalComponentAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q3_2330 {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q3_2330A G_TS837Q3_2330A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q3_2330B G_TS837Q3_2330B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837Q3_2330C G_TS837Q3_2330C {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837Q3_2330D G_TS837Q3_2330D {get; set;}
    [XmlElementAttribute(Order=4)]
    public G_TS837Q3_2330E G_TS837Q3_2330E {get; set;}
    [XmlElementAttribute(Order=5)]
    public G_TS837Q3_2330F G_TS837Q3_2330F {get; set;}
    [XmlElementAttribute(Order=6)]
    public G_TS837Q3_2330H G_TS837Q3_2330H {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2330A {
    [XmlElement(Order=0)]
    public S_NM1_OtherSubscriberName_TS837Q3_2330A S_NM1_OtherSubscriberName_TS837Q3_2330A {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherSubscriberAddress_TS837Q3_2330A S_N3_OtherSubscriberAddress_TS837Q3_2330A {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherSubscriberCityStateZIPCode_TS837Q3_2330A S_N4_OtherSubscriberCityStateZIPCode_TS837Q3_2330A {get; set;}
    [XmlElement("S_REF_OtherSubscriberSecondaryInformation_TS837Q3_2330A",Order=3)]
    public List<S_REF_OtherSubscriberSecondaryInformation_TS837Q3_2330A> S_REF_OtherSubscriberSecondaryInformation_TS837Q3_2330A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherSubscriberName_TS837Q3_2330A {
    [XmlElement(Order=0)]
    public S_NM1_OtherSubscriberName_TS837Q3_2330AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherSubscriberName_TS837Q3_2330AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherInsuredLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherInsuredFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherInsuredMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherInsuredNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherInsuredIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherSubscriberName_TS837Q3_2330AD_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherSubscriberName_TS837Q3_2330AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_OtherSubscriberAddress_TS837Q3_2330A {
    [XmlElement(Order=0)]
    public string D_N301_OtherInsuredAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_OtherInsuredAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_OtherSubscriberCityStateZIPCode_TS837Q3_2330A {
    [XmlElement(Order=0)]
    public string D_N401_OtherInsuredCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_OtherInsuredStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_OtherInsuredPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherSubscriberSecondaryInformation_TS837Q3_2330A {
    [XmlElement(Order=0)]
    public S_REF_OtherSubscriberSecondaryInformation_TS837Q3_2330AD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherInsuredAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1871 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherSubscriberSecondaryInformation_TS837Q3_2330AD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("23")]
        Item23,
        IG,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2330B {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerName_TS837Q3_2330B S_NM1_OtherPayerName_TS837Q3_2330B {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherPayerAddress_TS837Q3_2330B S_N3_OtherPayerAddress_TS837Q3_2330B {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherPayerCityStateZIPCode_TS837Q3_2330B S_N4_OtherPayerCityStateZIPCode_TS837Q3_2330B {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_ClaimAdjudicationDate_TS837Q3_2330B S_DTP_ClaimAdjudicationDate_TS837Q3_2330B {get; set;}
    [XmlElement(Order=4)]
    public A_REF_OtherPayer_TS837Q3_2330B A_REF_OtherPayer_TS837Q3_2330B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerName_TS837Q3_2330B {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerName_TS837Q3_2330BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerName_TS837Q3_2330BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherPayerLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherPayerPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerName_TS837Q3_2330BD_NM101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerName_TS837Q3_2330BD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_OtherPayerAddress_TS837Q3_2330B {
    [XmlElement(Order=0)]
    public string D_N301_OtherPayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_OtherPayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_OtherPayerCityStateZIPCode_TS837Q3_2330B {
    [XmlElement(Order=0)]
    public string D_N401_OtherPayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_OtherPayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_OtherPayerPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimAdjudicationDate_TS837Q3_2330B {
    [XmlElement(Order=0)]
    public S_DTP_ClaimAdjudicationDate_TS837Q3_2330BD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ClaimAdjudicationDate_TS837Q3_2330BD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdjudicationOrPaymentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ClaimAdjudicationDate_TS837Q3_2330BD_DTP01_DateTimeQualifier {
        [XmlEnum("573")]
        Item573,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ClaimAdjudicationDate_TS837Q3_2330BD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_OtherPayer_TS837Q3_2330B {
    [XmlElement(Order=0)]
    public U_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330B U_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330B {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q3_2330B S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q3_2330B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330B {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1872 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("2U")]
        Item2U,
        F8,
        FY,
        NF,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q3_2330B {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q3_2330BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationOrReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1873 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q3_2330BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9F")]
        Item9F,
        G1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2330C {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerPatientInformation_TS837Q3_2330C S_NM1_OtherPayerPatientInformation_TS837Q3_2330C {get; set;}
    [XmlElement("S_REF_OtherPayerPatientIdentificationNumber_TS837Q3_2330C",Order=1)]
    public List<S_REF_OtherPayerPatientIdentificationNumber_TS837Q3_2330C> S_REF_OtherPayerPatientIdentificationNumber_TS837Q3_2330C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerPatientInformation_TS837Q3_2330C {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerPatientInformation_TS837Q3_2330CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerPatientInformation_TS837Q3_2330CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103 {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherPayerPatientPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerPatientInformation_TS837Q3_2330CD_NM101_EntityIdentifierCode {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerPatientInformation_TS837Q3_2330CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerPatientIdentificationNumber_TS837Q3_2330C {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerPatientIdentificationNumber_TS837Q3_2330CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPatientSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1874 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerPatientIdentificationNumber_TS837Q3_2330CD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1W")]
        Item1W,
        IG,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2330D {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerAttendingProvider_TS837Q3_2330D S_NM1_OtherPayerAttendingProvider_TS837Q3_2330D {get; set;}
    [XmlElement("S_REF_OtherPayerAttendingProviderIdentification_TS837Q3_2330D",Order=1)]
    public List<S_REF_OtherPayerAttendingProviderIdentification_TS837Q3_2330D> S_REF_OtherPayerAttendingProviderIdentification_TS837Q3_2330D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerAttendingProvider_TS837Q3_2330D {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerAttendingProvider_TS837Q3_2330DD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerAttendingProvider_TS837Q3_2330DD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103 {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108 {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109 {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerAttendingProvider_TS837Q3_2330DD_NM101_EntityIdentifierCode {
        [XmlEnum("71")]
        Item71,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerAttendingProvider_TS837Q3_2330DD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerAttendingProviderIdentification_TS837Q3_2330D {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerAttendingProviderIdentification_TS837Q3_2330DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerAttendingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1875 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerAttendingProviderIdentification_TS837Q3_2330DD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2330E {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerOperatingProvider_TS837Q3_2330E S_NM1_OtherPayerOperatingProvider_TS837Q3_2330E {get; set;}
    [XmlElement("S_REF_OtherPayerOperatingProviderIdentification_TS837Q3_2330E",Order=1)]
    public List<S_REF_OtherPayerOperatingProviderIdentification_TS837Q3_2330E> S_REF_OtherPayerOperatingProviderIdentification_TS837Q3_2330E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerOperatingProvider_TS837Q3_2330E {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerOperatingProvider_TS837Q3_2330ED_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerOperatingProvider_TS837Q3_2330ED_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103 {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108 {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109 {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerOperatingProvider_TS837Q3_2330ED_NM101_EntityIdentifierCode {
        [XmlEnum("72")]
        Item72,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerOperatingProvider_TS837Q3_2330ED_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerOperatingProviderIdentification_TS837Q3_2330E {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerOperatingProviderIdentification_TS837Q3_2330ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerOperatingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1876 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerOperatingProviderIdentification_TS837Q3_2330ED_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2330F {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerOtherProvider_TS837Q3_2330F S_NM1_OtherPayerOtherProvider_TS837Q3_2330F {get; set;}
    [XmlElement("S_REF_OtherPayerOtherProviderIdentification_TS837Q3_2330F",Order=1)]
    public List<S_REF_OtherPayerOtherProviderIdentification_TS837Q3_2330F> S_REF_OtherPayerOtherProviderIdentification_TS837Q3_2330F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerOtherProvider_TS837Q3_2330F {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerOtherProvider_TS837Q3_2330FD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerOtherProvider_TS837Q3_2330FD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103 {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108 {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109 {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerOtherProvider_TS837Q3_2330FD_NM101_EntityIdentifierCode {
        [XmlEnum("73")]
        Item73,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerOtherProvider_TS837Q3_2330FD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerOtherProviderIdentification_TS837Q3_2330F {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerOtherProviderIdentification_TS837Q3_2330FD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerOtherProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1877 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerOtherProviderIdentification_TS837Q3_2330FD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2330H {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerServiceFacilityProvider_TS837Q3_2330H S_NM1_OtherPayerServiceFacilityProvider_TS837Q3_2330H {get; set;}
    [XmlElement("S_REF_OtherPayerServiceFacilityProviderIdentification_TS837Q3_2330H",Order=1)]
    public List<S_REF_OtherPayerServiceFacilityProviderIdentification_TS837Q3_2330H> S_REF_OtherPayerServiceFacilityProviderIdentification_TS837Q3_2330H {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerServiceFacilityProvider_TS837Q3_2330H {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerServiceFacilityProvider_TS837Q3_2330HD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerServiceFacilityProvider_TS837Q3_2330HD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103 {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108 {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109 {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerServiceFacilityProvider_TS837Q3_2330HD_NM101_EntityIdentifierCode {
        FA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerServiceFacilityProvider_TS837Q3_2330HD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerServiceFacilityProviderIdentification_TS837Q3_2330H {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerServiceFacilityProviderIdentification_TS837Q3_2330HD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerServiceFacilityProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1879 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerServiceFacilityProviderIdentification_TS837Q3_2330HD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        EI,
        G2,
        LU,
        N5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public S_LX_ServiceLineNumber_TS837Q3_2400 S_LX_ServiceLineNumber_TS837Q3_2400 {get; set;}
    [XmlElement(Order=1)]
    public S_SV2_InstitutionalServiceLine_TS837Q3_2400 S_SV2_InstitutionalServiceLine_TS837Q3_2400 {get; set;}
    [XmlElement("S_PWK_LineSupplementalInformation_TS837Q3_2400",Order=2)]
    public List<S_PWK_LineSupplementalInformation_TS837Q3_2400> S_PWK_LineSupplementalInformation_TS837Q3_2400 {get; set;}
    [XmlElement(Order=3)]
    public A_DTP_TS837Q3_2400 A_DTP_TS837Q3_2400 {get; set;}
    [XmlElement(Order=4)]
    public A_AMT_TS837Q3_2400 A_AMT_TS837Q3_2400 {get; set;}
    [XmlElement(Order=5)]
    public S_HCP_LinePricingRepricingInformation_TS837Q3_2400 S_HCP_LinePricingRepricingInformation_TS837Q3_2400 {get; set;}
    [XmlElement("G_TS837Q3_2410",Order=6)]
    public List<G_TS837Q3_2410> G_TS837Q3_2410 {get; set;}
    [XmlElement(Order=7)]
    public A_TS837Q3_2420 A_TS837Q3_2420 {get; set;}
    [XmlElement("G_TS837Q3_2430",Order=8)]
    public List<G_TS837Q3_2430> G_TS837Q3_2430 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_ServiceLineNumber_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SV2_InstitutionalServiceLine_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public string D_SV201_ServiceLineRevenueCode {get; set;}
    [XmlElement(Order=1)]
    public C_SV202_C003U1880_TS837Q3_2400 C_SV202_C003U1880_TS837Q3_2400 {get; set;}
    [XmlElement(Order=2)]
    public string D_SV203_LineItemChargeAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SV204_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SV205_ServiceUnitCount {get; set;}
    [XmlElement(Order=5)]
    public string D_SV206_ServiceLineRate {get; set;}
    [XmlElement(Order=6)]
    public string D_SV207_LineItemDeniedChargeOrNonCoveredChargeAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_SV208 {get; set;}
    [XmlElement(Order=8)]
    public string D_SV209 {get; set;}
    [XmlElement(Order=9)]
    public string D_SV210 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SV202_C003U1880_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public C_SV202_C003U1880_TS837Q3_2400D_SV202_C00301U1881_ProductOrServiceIDQualifier D_SV202_C00301U1881_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SV202_C00302U1882_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SV202_C00303U1883_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_SV202_C00304U1884_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_SV202_C00305U1885_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_SV202_C00306U1886_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SV202_C00307U6910 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_SV202_C003U1880_TS837Q3_2400D_SV202_C00301U1881_ProductOrServiceIDQualifier {
        HC,
        IV,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_LineSupplementalInformation_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public S_PWK_LineSupplementalInformation_TS837Q3_2400D_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_LineSupplementalInformation_TS837Q3_2400D_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03 {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07 {get; set;}
    [XmlElement(Order=7)]
    public string D_PWK08_C002U1889 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_LineSupplementalInformation_TS837Q3_2400D_PWK01_AttachmentReportTypeCode {
        AS,
        B2,
        B3,
        B4,
        CT,
        DA,
        DG,
        DS,
        EB,
        MT,
        NN,
        OB,
        OZ,
        PN,
        PO,
        PZ,
        RB,
        RR,
        RT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_LineSupplementalInformation_TS837Q3_2400D_PWK02_AttachmentTransmissionCode {
        AA,
        AB,
        AD,
        AF,
        AG,
        BM,
        EL,
        EM,
        FX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_TS837Q3_2400 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_ServiceLineDate_TS837Q3_2400 S_DTP_ServiceLineDate_TS837Q3_2400 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_AssessmentDate_TS837Q3_2400 S_DTP_AssessmentDate_TS837Q3_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceLineDate_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public S_DTP_ServiceLineDate_TS837Q3_2400D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ServiceLineDate_TS837Q3_2400D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceLineDate_TS837Q3_2400D_DTP01_DateTimeQualifier {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceLineDate_TS837Q3_2400D_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AssessmentDate_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public S_DTP_AssessmentDate_TS837Q3_2400D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_AssessmentDate_TS837Q3_2400D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AssessmentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AssessmentDate_TS837Q3_2400D_DTP01_DateTimeQualifier {
        [XmlEnum("866")]
        Item866,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AssessmentDate_TS837Q3_2400D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_AMT_TS837Q3_2400 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_ServiceTaxAmount_TS837Q3_2400 S_AMT_ServiceTaxAmount_TS837Q3_2400 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_FacilityTaxAmount_TS837Q3_2400 S_AMT_FacilityTaxAmount_TS837Q3_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ServiceTaxAmount_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public S_AMT_ServiceTaxAmount_TS837Q3_2400D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ServiceTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_ServiceTaxAmount_TS837Q3_2400D_AMT01_AmountQualifierCode {
        GT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_FacilityTaxAmount_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public S_AMT_FacilityTaxAmount_TS837Q3_2400D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_FacilityTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_FacilityTaxAmount_TS837Q3_2400D_AMT01_AmountQualifierCode {
        N8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HCP_LinePricingRepricingInformation_TS837Q3_2400 {
    [XmlElement(Order=0)]
    public S_HCP_LinePricingRepricingInformation_TS837Q3_2400D_HCP01_PricingMethodology D_HCP01_PricingMethodology {get; set;}
    [XmlElement(Order=1)]
    public string D_HCP02_RepricedAllowedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_HCP03_RepricedSavingAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_HCP04_RepricedOrganizationalIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_HCP05_RepricingPerDiemOrFlatRateAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HCP06_RepricedApprovedAmbulatoryPatientGroupCode {get; set;}
    [XmlElement(Order=6)]
    public string D_HCP07_RepricedApprovedAmbulatoryPatientGroupAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_HCP08_RepricedApprovedRevenueCode {get; set;}
    [XmlElement(Order=8)]
    public string D_HCP09_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_HCP10_ProcedureCode {get; set;}
    [XmlElement(Order=10)]
    public string D_HCP11_UnitOrBasisForMeasurementCode {get; set;}
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
    public enum S_HCP_LinePricingRepricingInformation_TS837Q3_2400D_HCP01_PricingMethodology {
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
    public class G_TS837Q3_2410 {
    [XmlElement(Order=0)]
    public S_LIN_DrugIdentification_TS837Q3_2410 S_LIN_DrugIdentification_TS837Q3_2410 {get; set;}
    [XmlElement(Order=1)]
    public S_CTP_DrugPricing_TS837Q3_2410 S_CTP_DrugPricing_TS837Q3_2410 {get; set;}
    [XmlElement(Order=2)]
    public S_REF_PrescriptionNumber_TS837Q3_2410 S_REF_PrescriptionNumber_TS837Q3_2410 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LIN_DrugIdentification_TS837Q3_2410 {
    [XmlElement(Order=0)]
    public string D_LIN01 {get; set;}
    [XmlElement(Order=1)]
    public S_LIN_DrugIdentification_TS837Q3_2410D_LIN02_ProductOrServiceIDQualifier D_LIN02_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_LIN03_ProductOrServiceID {get; set;}
    [XmlElement(Order=3)]
    public string D_LIN04 {get; set;}
    [XmlElement(Order=4)]
    public string D_LIN05 {get; set;}
    [XmlElement(Order=5)]
    public string D_LIN06 {get; set;}
    [XmlElement(Order=6)]
    public string D_LIN07 {get; set;}
    [XmlElement(Order=7)]
    public string D_LIN08 {get; set;}
    [XmlElement(Order=8)]
    public string D_LIN09 {get; set;}
    [XmlElement(Order=9)]
    public string D_LIN10 {get; set;}
    [XmlElement(Order=10)]
    public string D_LIN11 {get; set;}
    [XmlElement(Order=11)]
    public string D_LIN12 {get; set;}
    [XmlElement(Order=12)]
    public string D_LIN13 {get; set;}
    [XmlElement(Order=13)]
    public string D_LIN14 {get; set;}
    [XmlElement(Order=14)]
    public string D_LIN15 {get; set;}
    [XmlElement(Order=15)]
    public string D_LIN16 {get; set;}
    [XmlElement(Order=16)]
    public string D_LIN17 {get; set;}
    [XmlElement(Order=17)]
    public string D_LIN18 {get; set;}
    [XmlElement(Order=18)]
    public string D_LIN19 {get; set;}
    [XmlElement(Order=19)]
    public string D_LIN20 {get; set;}
    [XmlElement(Order=20)]
    public string D_LIN21 {get; set;}
    [XmlElement(Order=21)]
    public string D_LIN22 {get; set;}
    [XmlElement(Order=22)]
    public string D_LIN23 {get; set;}
    [XmlElement(Order=23)]
    public string D_LIN24 {get; set;}
    [XmlElement(Order=24)]
    public string D_LIN25 {get; set;}
    [XmlElement(Order=25)]
    public string D_LIN26 {get; set;}
    [XmlElement(Order=26)]
    public string D_LIN27 {get; set;}
    [XmlElement(Order=27)]
    public string D_LIN28 {get; set;}
    [XmlElement(Order=28)]
    public string D_LIN29 {get; set;}
    [XmlElement(Order=29)]
    public string D_LIN30 {get; set;}
    [XmlElement(Order=30)]
    public string D_LIN31 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_LIN_DrugIdentification_TS837Q3_2410D_LIN02_ProductOrServiceIDQualifier {
        N4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CTP_DrugPricing_TS837Q3_2410 {
    [XmlElement(Order=0)]
    public string D_CTP01 {get; set;}
    [XmlElement(Order=1)]
    public string D_CTP02 {get; set;}
    [XmlElement(Order=2)]
    public string D_CTP03_DrugUnitPrice {get; set;}
    [XmlElement(Order=3)]
    public string D_CTP04_NationalDrugUnitCount {get; set;}
    [XmlElement(Order=4)]
    public C_CTP05_C001U6912_TS837Q3_2410 C_CTP05_C001U6912_TS837Q3_2410 {get; set;}
    [XmlElement(Order=5)]
    public string D_CTP06 {get; set;}
    [XmlElement(Order=6)]
    public string D_CTP07 {get; set;}
    [XmlElement(Order=7)]
    public string D_CTP08 {get; set;}
    [XmlElement(Order=8)]
    public string D_CTP09 {get; set;}
    [XmlElement(Order=9)]
    public string D_CTP10 {get; set;}
    [XmlElement(Order=10)]
    public string D_CTP11 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTP05_C001U6912_TS837Q3_2410 {
    [XmlElement(Order=0)]
    public string D_CTP05_C00101U6913_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CTP05_C00102U6914 {get; set;}
    [XmlElement(Order=2)]
    public string D_CTP05_C00103U6915 {get; set;}
    [XmlElement(Order=3)]
    public string D_CTP05_C00104U6916 {get; set;}
    [XmlElement(Order=4)]
    public string D_CTP05_C00105U6917 {get; set;}
    [XmlElement(Order=5)]
    public string D_CTP05_C00106U6918 {get; set;}
    [XmlElement(Order=6)]
    public string D_CTP05_C00107U6919 {get; set;}
    [XmlElement(Order=7)]
    public string D_CTP05_C00108U6920 {get; set;}
    [XmlElement(Order=8)]
    public string D_CTP05_C00109U6921 {get; set;}
    [XmlElement(Order=9)]
    public string D_CTP05_C00110U6922 {get; set;}
    [XmlElement(Order=10)]
    public string D_CTP05_C00111U6923 {get; set;}
    [XmlElement(Order=11)]
    public string D_CTP05_C00112U6924 {get; set;}
    [XmlElement(Order=12)]
    public string D_CTP05_C00113U6925 {get; set;}
    [XmlElement(Order=13)]
    public string D_CTP05_C00114U6926 {get; set;}
    [XmlElement(Order=14)]
    public string D_CTP05_C00115U6927 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PrescriptionNumber_TS837Q3_2410 {
    [XmlElement(Order=0)]
    public S_REF_PrescriptionNumber_TS837Q3_2410D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PrescriptionNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U6928 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PrescriptionNumber_TS837Q3_2410D_REF01_ReferenceIdentificationQualifier {
        XZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q3_2420 {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q3_2420A G_TS837Q3_2420A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q3_2420B G_TS837Q3_2420B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837Q3_2420C G_TS837Q3_2420C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2420A {
    [XmlElement(Order=0)]
    public S_NM1_AttendingPhysicianName_TS837Q3_2420A S_NM1_AttendingPhysicianName_TS837Q3_2420A {get; set;}
    [XmlElement(Order=1)]
    public S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2420A S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2420A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AttendingPhysicianName_TS837Q3_2420A {
    [XmlElement(Order=0)]
    public S_NM1_AttendingPhysicianName_TS837Q3_2420AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_AttendingPhysicianName_TS837Q3_2420AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AttendingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AttendingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AttendingPhysicianMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AttendingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AttendingPhysicianPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AttendingPhysicianName_TS837Q3_2420AD_NM101_EntityIdentifierCode {
        [XmlEnum("71")]
        Item71,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AttendingPhysicianName_TS837Q3_2420AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2420A {
    [XmlElement(Order=0)]
    public S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2420AD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AttendingPhysicianSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1891 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_AttendingPhysicianSecondaryIdentification_TS837Q3_2420AD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
        SY,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2420B {
    [XmlElement(Order=0)]
    public S_NM1_OperatingPhysicianName_TS837Q3_2420B S_NM1_OperatingPhysicianName_TS837Q3_2420B {get; set;}
    [XmlElement(Order=1)]
    public S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2420B S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2420B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OperatingPhysicianName_TS837Q3_2420B {
    [XmlElement(Order=0)]
    public S_NM1_OperatingPhysicianName_TS837Q3_2420BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OperatingPhysicianName_TS837Q3_2420BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OperatingPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OperatingPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OperatingPhysicanMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OperatingPhysicianNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OperatingPhysicianPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OperatingPhysicianName_TS837Q3_2420BD_NM101_EntityIdentifierCode {
        [XmlEnum("72")]
        Item72,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OperatingPhysicianName_TS837Q3_2420BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2420B {
    [XmlElement(Order=0)]
    public S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2420BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OperatingPhysicianSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1893 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OperatingPhysicianSecondaryIdentification_TS837Q3_2420BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
        SY,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2420C {
    [XmlElement(Order=0)]
    public S_NM1_OtherProviderName_TS837Q3_2420C S_NM1_OtherProviderName_TS837Q3_2420C {get; set;}
    [XmlElement(Order=1)]
    public S_REF_OtherProviderSecondaryIdentification_TS837Q3_2420C S_REF_OtherProviderSecondaryIdentification_TS837Q3_2420C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherProviderName_TS837Q3_2420C {
    [XmlElement(Order=0)]
    public S_NM1_OtherProviderName_TS837Q3_2420CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherProviderName_TS837Q3_2420CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherPhysicianLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherPhysicianFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherProviderName_TS837Q3_2420CD_NM101_EntityIdentifierCode {
        [XmlEnum("73")]
        Item73,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherProviderName_TS837Q3_2420CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherProviderSecondaryIdentification_TS837Q3_2420C {
    [XmlElement(Order=0)]
    public S_REF_OtherProviderSecondaryIdentification_TS837Q3_2420CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1895 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherProviderSecondaryIdentification_TS837Q3_2420CD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1A")]
        Item1A,
        [XmlEnum("1B")]
        Item1B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        LU,
        N5,
        SY,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2430 {
    [XmlElement(Order=0)]
    public S_SVD_ServiceLineAdjudicationInformation_TS837Q3_2430 S_SVD_ServiceLineAdjudicationInformation_TS837Q3_2430 {get; set;}
    [XmlElement("S_CAS_ServiceLineAdjustment_TS837Q3_2430",Order=1)]
    public List<S_CAS_ServiceLineAdjustment_TS837Q3_2430> S_CAS_ServiceLineAdjustment_TS837Q3_2430 {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_ServiceAdjudicationDate_TS837Q3_2430 S_DTP_ServiceAdjudicationDate_TS837Q3_2430 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVD_ServiceLineAdjudicationInformation_TS837Q3_2430 {
    [XmlElement(Order=0)]
    public string D_SVD01_PayerIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVD02_ServiceLinePaidAmount {get; set;}
    [XmlElement(Order=2)]
    public C_SVD03_C003U1898_TS837Q3_2430 C_SVD03_C003U1898_TS837Q3_2430 {get; set;}
    [XmlElement(Order=3)]
    public string D_SVD04_ServiceLineRevenueCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SVD05_AdjustmentQuantity {get; set;}
    [XmlElement(Order=5)]
    public string D_SVD06_BundledOrUnbundledLineNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SVD03_C003U1898_TS837Q3_2430 {
    [XmlElement(Order=0)]
    public string D_SVD03_C00301U1899_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVD03_C00302U1900_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SVD03_C00303U1901_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_SVD03_C00304U1902_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_SVD03_C00305U1903_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_SVD03_C00306U1904_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SVD03_C00307U1905_ProcedureCodeDescription {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ServiceLineAdjustment_TS837Q3_2430 {
    [XmlElement(Order=0)]
    public S_CAS_ServiceLineAdjustment_TS837Q3_2430D_CAS01_ClaimAdjustmentGroupCode D_CAS01_ClaimAdjustmentGroupCode {get; set;}
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
    public enum S_CAS_ServiceLineAdjustment_TS837Q3_2430D_CAS01_ClaimAdjustmentGroupCode {
        CO,
        CR,
        OA,
        PI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceAdjudicationDate_TS837Q3_2430 {
    [XmlElement(Order=0)]
    public S_DTP_ServiceAdjudicationDate_TS837Q3_2430D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ServiceAdjudicationDate_TS837Q3_2430D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceAdjudicationOrPaymentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceAdjudicationDate_TS837Q3_2430D_DTP01_DateTimeQualifier {
        [XmlEnum("573")]
        Item573,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceAdjudicationDate_TS837Q3_2430D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2000C {
    [XmlElement(Order=0)]
    public S_HL_PatientHierarchicalLevel_TS837Q3_2000C S_HL_PatientHierarchicalLevel_TS837Q3_2000C {get; set;}
    [XmlElement(Order=1)]
    public S_PAT_PatientInformation_TS837Q3_2000C S_PAT_PatientInformation_TS837Q3_2000C {get; set;}
    [XmlElement(Order=2)]
    public G_TS837Q3_2010CA G_TS837Q3_2010CA {get; set;}
    [XmlElement("G_TS837Q3_2300",Order=3)]
    public List<G_TS837Q3_2300> G_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_PatientHierarchicalLevel_TS837Q3_2000C {
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
    public class S_PAT_PatientInformation_TS837Q3_2000C {
    [XmlElement(Order=0)]
    public S_PAT_PatientInformation_TS837Q3_2000CD_PAT01_IndividualRelationshipCode D_PAT01_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PAT02 {get; set;}
    [XmlElement(Order=2)]
    public string D_PAT03 {get; set;}
    [XmlElement(Order=3)]
    public string D_PAT04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PAT05 {get; set;}
    [XmlElement(Order=5)]
    public string D_PAT06 {get; set;}
    [XmlElement(Order=6)]
    public string D_PAT07 {get; set;}
    [XmlElement(Order=7)]
    public string D_PAT08 {get; set;}
    [XmlElement(Order=8)]
    public string D_PAT09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PAT_PatientInformation_TS837Q3_2000CD_PAT01_IndividualRelationshipCode {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("04")]
        Item04,
        [XmlEnum("05")]
        Item05,
        [XmlEnum("07")]
        Item07,
        [XmlEnum("10")]
        Item10,
        [XmlEnum("15")]
        Item15,
        [XmlEnum("17")]
        Item17,
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
        [XmlEnum("29")]
        Item29,
        [XmlEnum("32")]
        Item32,
        [XmlEnum("33")]
        Item33,
        [XmlEnum("36")]
        Item36,
        [XmlEnum("39")]
        Item39,
        [XmlEnum("40")]
        Item40,
        [XmlEnum("41")]
        Item41,
        [XmlEnum("43")]
        Item43,
        [XmlEnum("53")]
        Item53,
        G8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q3_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_PatientName_TS837Q3_2010CA S_NM1_PatientName_TS837Q3_2010CA {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PatientAddress_TS837Q3_2010CA S_N3_PatientAddress_TS837Q3_2010CA {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PatientCityStateZIPCode_TS837Q3_2010CA S_N4_PatientCityStateZIPCode_TS837Q3_2010CA {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_PatientDemographicInformation_TS837Q3_2010CA S_DMG_PatientDemographicInformation_TS837Q3_2010CA {get; set;}
    [XmlElement(Order=4)]
    public A_REF_TS837Q3_2010CA A_REF_TS837Q3_2010CA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientName_TS837Q3_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_PatientName_TS837Q3_2010CAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_PatientName_TS837Q3_2010CAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PatientNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PatientPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PatientName_TS837Q3_2010CAD_NM101_EntityIdentifierCode {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PatientName_TS837Q3_2010CAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PatientAddress_TS837Q3_2010CA {
    [XmlElement(Order=0)]
    public string D_N301_PatientAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PatientAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PatientCityStateZIPCode_TS837Q3_2010CA {
    [XmlElement(Order=0)]
    public string D_N401_PatientCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PatientStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PatientPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_PatientDemographicInformation_TS837Q3_2010CA {
    [XmlElement(Order=0)]
    public S_DMG_PatientDemographicInformation_TS837Q3_2010CAD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_PatientBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_PatientGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04 {get; set;}
    [XmlElement(Order=4)]
    public string D_DMG05 {get; set;}
    [XmlElement(Order=5)]
    public string D_DMG06 {get; set;}
    [XmlElement(Order=6)]
    public string D_DMG07 {get; set;}
    [XmlElement(Order=7)]
    public string D_DMG08 {get; set;}
    [XmlElement(Order=8)]
    public string D_DMG09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DMG_PatientDemographicInformation_TS837Q3_2010CAD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS837Q3_2010CA {
    [XmlElement(Order=0)]
    public U_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CA U_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CA {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010CA S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010CA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CA {
    [XmlElement(Order=0)]
    public S_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PatientSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1077 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CAD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("23")]
        Item23,
        IG,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010CA {
    [XmlElement(Order=0)]
    public S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010CAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyCasualtyClaimNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1078 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PropertyAndCasualtyClaimNumber_TS837Q3_2010CAD_REF01_ReferenceIdentificationQualifier {
        Y4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SE {
    [XmlElement(Order=0)]
    public string D_SE01 {get; set;}
    [XmlElement(Order=1)]
    public string D_SE02 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AA {
    [XmlElement("S_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AA",Order=0)]
    public List<S_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AA> S_REF_BillingProviderSecondaryIdentification_TS837Q3_2010AA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_CreditDebitCardBillingInformation_TS837Q3_2010AA {
    [XmlElement("S_REF_CreditDebitCardBillingInformation_TS837Q3_2010AA",Order=0)]
    public List<S_REF_CreditDebitCardBillingInformation_TS837Q3_2010AA> S_REF_CreditDebitCardBillingInformation_TS837Q3_2010AA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_SubscriberSecondaryIdentification_TS837Q3_2010BA {
    [XmlElement("S_REF_SubscriberSecondaryIdentification_TS837Q3_2010BA",Order=0)]
    public List<S_REF_SubscriberSecondaryIdentification_TS837Q3_2010BA> S_REF_SubscriberSecondaryIdentification_TS837Q3_2010BA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_DocumentIdentificationCode_TS837Q3_2300 {
    [XmlElement("S_REF_DocumentIdentificationCode_TS837Q3_2300",Order=0)]
    public List<S_REF_DocumentIdentificationCode_TS837Q3_2300> S_REF_DocumentIdentificationCode_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300 {
    [XmlElement("S_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300",Order=0)]
    public List<S_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300> S_REF_PriorAuthorizationOrReferralNumber_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_NTE_ClaimNote_TS837Q3_2300 {
    [XmlElement("S_NTE_ClaimNote_TS837Q3_2300",Order=0)]
    public List<S_NTE_ClaimNote_TS837Q3_2300> S_NTE_ClaimNote_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300 {
    [XmlElement("S_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300",Order=0)]
    public List<S_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300> S_CRC_HomeHealthFunctionalLimitations_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300 {
    [XmlElement("S_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300",Order=0)]
    public List<S_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300> S_CRC_HomeHealthActivitiesPermitted_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_CRC_HomeHealthMentalStatus_TS837Q3_2300 {
    [XmlElement("S_CRC_HomeHealthMentalStatus_TS837Q3_2300",Order=0)]
    public List<S_CRC_HomeHealthMentalStatus_TS837Q3_2300> S_CRC_HomeHealthMentalStatus_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OtherDiagnosisInformation_TS837Q3_2300 {
    [XmlElement("S_HI_OtherDiagnosisInformation_TS837Q3_2300",Order=0)]
    public List<S_HI_OtherDiagnosisInformation_TS837Q3_2300> S_HI_OtherDiagnosisInformation_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OtherProcedureInformation_TS837Q3_2300 {
    [XmlElement("S_HI_OtherProcedureInformation_TS837Q3_2300",Order=0)]
    public List<S_HI_OtherProcedureInformation_TS837Q3_2300> S_HI_OtherProcedureInformation_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OccurrenceSpanInformation_TS837Q3_2300 {
    [XmlElement("S_HI_OccurrenceSpanInformation_TS837Q3_2300",Order=0)]
    public List<S_HI_OccurrenceSpanInformation_TS837Q3_2300> S_HI_OccurrenceSpanInformation_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_OccurrenceInformation_TS837Q3_2300 {
    [XmlElement("S_HI_OccurrenceInformation_TS837Q3_2300",Order=0)]
    public List<S_HI_OccurrenceInformation_TS837Q3_2300> S_HI_OccurrenceInformation_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_ValueInformation_TS837Q3_2300 {
    [XmlElement("S_HI_ValueInformation_TS837Q3_2300",Order=0)]
    public List<S_HI_ValueInformation_TS837Q3_2300> S_HI_ValueInformation_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_ConditionInformation_TS837Q3_2300 {
    [XmlElement("S_HI_ConditionInformation_TS837Q3_2300",Order=0)]
    public List<S_HI_ConditionInformation_TS837Q3_2300> S_HI_ConditionInformation_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_HI_TreatmentCodeInformation_TS837Q3_2300 {
    [XmlElement("S_HI_TreatmentCodeInformation_TS837Q3_2300",Order=0)]
    public List<S_HI_TreatmentCodeInformation_TS837Q3_2300> S_HI_TreatmentCodeInformation_TS837Q3_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330B {
    [XmlElement("S_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330B",Order=0)]
    public List<S_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330B> S_REF_OtherPayerSecondaryIdentificationAndReferenceNumber_TS837Q3_2330B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CA {
    [XmlElement("S_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CA",Order=0)]
    public List<S_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CA> S_REF_PatientSecondaryIdentificationNumber_TS837Q3_2010CA {get; set;}
    }
}
