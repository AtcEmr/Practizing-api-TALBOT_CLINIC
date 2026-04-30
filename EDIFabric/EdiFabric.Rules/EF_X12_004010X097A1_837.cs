namespace EdiFabric.Rules.X12004010X097A1837 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_837 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS837Q2 S_BHT_BeginningOfHierarchicalTransaction_TS837Q2 {get; set;}
    [XmlElement(Order=2)]
    public S_REF_TransmissionTypeIdentification_TS837Q2 S_REF_TransmissionTypeIdentification_TS837Q2 {get; set;}
    [XmlElement(Order=3)]
    public G_TS837Q2_1000A G_TS837Q2_1000A {get; set;}
    [XmlElement(Order=4)]
    public G_TS837Q2_1000B G_TS837Q2_1000B {get; set;}
    [XmlElement("G_TS837Q2_2000A",Order=5)]
    public List<G_TS837Q2_2000A> G_TS837Q2_2000A {get; set;}
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
    public class S_BHT_BeginningOfHierarchicalTransaction_TS837Q2 {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS837Q2D_BHT01_HierarchicalStructureCode D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS837Q2D_BHT02_TransactionSetPurposeCode D_BHT02_TransactionSetPurposeCode {get; set;}
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
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS837Q2D_BHT01_HierarchicalStructureCode {
        [XmlEnum("0019")]
        Item0019,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS837Q2D_BHT02_TransactionSetPurposeCode {
        [XmlEnum("00")]
        Item00,
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_TransmissionTypeIdentification_TS837Q2 {
    [XmlElement(Order=0)]
    public S_REF_TransmissionTypeIdentification_TS837Q2D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_TransmissionTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U993 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_TransmissionTypeIdentification_TS837Q2D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("87")]
        Item87,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_1000A {
    [XmlElement(Order=0)]
    public S_NM1_SubmitterName_TS837Q2_1000A S_NM1_SubmitterName_TS837Q2_1000A {get; set;}
    [XmlElement("S_PER_SubmitterContactInformation_TS837Q2_1000A",Order=1)]
    public List<S_PER_SubmitterContactInformation_TS837Q2_1000A> S_PER_SubmitterContactInformation_TS837Q2_1000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubmitterName_TS837Q2_1000A {
    [XmlElement(Order=0)]
    public S_NM1_SubmitterName_TS837Q2_1000AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubmitterName_TS837Q2_1000AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_SubmitterName_TS837Q2_1000AD_NM101_EntityIdentifierCode {
        [XmlEnum("41")]
        Item41,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubmitterName_TS837Q2_1000AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_SubmitterContactInformation_TS837Q2_1000A {
    [XmlElement(Order=0)]
    public S_PER_SubmitterContactInformation_TS837Q2_1000AD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public enum S_PER_SubmitterContactInformation_TS837Q2_1000AD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_1000B {
    [XmlElement(Order=0)]
    public S_NM1_ReceiverName_TS837Q2_1000B S_NM1_ReceiverName_TS837Q2_1000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReceiverName_TS837Q2_1000B {
    [XmlElement(Order=0)]
    public S_NM1_ReceiverName_TS837Q2_1000BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ReceiverName_TS837Q2_1000BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ReceiverPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ReceiverName_TS837Q2_1000BD_NM101_EntityIdentifierCode {
        [XmlEnum("40")]
        Item40,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ReceiverName_TS837Q2_1000BD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2000A {
    [XmlElement(Order=0)]
    public S_HL_BillingPaytoProviderHierarchicalLevel_TS837Q2_2000A S_HL_BillingPaytoProviderHierarchicalLevel_TS837Q2_2000A {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_BillingPaytoProviderSpecialtyInformation_TS837Q2_2000A S_PRV_BillingPaytoProviderSpecialtyInformation_TS837Q2_2000A {get; set;}
    [XmlElement(Order=2)]
    public S_CUR_ForeignCurrencyInformation_TS837Q2_2000A S_CUR_ForeignCurrencyInformation_TS837Q2_2000A {get; set;}
    [XmlElement(Order=3)]
    public A_TS837Q2_2010A A_TS837Q2_2010A {get; set;}
    [XmlElement("G_TS837Q2_2000B",Order=4)]
    public List<G_TS837Q2_2000B> G_TS837Q2_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_BillingPaytoProviderHierarchicalLevel_TS837Q2_2000A {
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
    public class S_PRV_BillingPaytoProviderSpecialtyInformation_TS837Q2_2000A {
    [XmlElement(Order=0)]
    public S_PRV_BillingPaytoProviderSpecialtyInformation_TS837Q2_2000AD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_BillingPaytoProviderSpecialtyInformation_TS837Q2_2000AD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U994 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_BillingPaytoProviderSpecialtyInformation_TS837Q2_2000AD_PRV01_ProviderCode {
        BI,
        PT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_BillingPaytoProviderSpecialtyInformation_TS837Q2_2000AD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CUR_ForeignCurrencyInformation_TS837Q2_2000A {
    [XmlElement(Order=0)]
    public S_CUR_ForeignCurrencyInformation_TS837Q2_2000AD_CUR01_EntityIdentifierCode D_CUR01_EntityIdentifierCode {get; set;}
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
    public enum S_CUR_ForeignCurrencyInformation_TS837Q2_2000AD_CUR01_EntityIdentifierCode {
        [XmlEnum("85")]
        Item85,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q2_2010A {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q2_2010AA G_TS837Q2_2010AA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q2_2010AB G_TS837Q2_2010AB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2010AA {
    [XmlElement(Order=0)]
    public S_NM1_BillingProviderName_TS837Q2_2010AA S_NM1_BillingProviderName_TS837Q2_2010AA {get; set;}
    [XmlElement(Order=1)]
    public S_N3_BillingProviderAddress_TS837Q2_2010AA S_N3_BillingProviderAddress_TS837Q2_2010AA {get; set;}
    [XmlElement(Order=2)]
    public S_N4_BillingProviderCityStateZIPCode_TS837Q2_2010AA S_N4_BillingProviderCityStateZIPCode_TS837Q2_2010AA {get; set;}
    [XmlElement(Order=3)]
    public A_REF_TS837Q2_2010AA A_REF_TS837Q2_2010AA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_BillingProviderName_TS837Q2_2010AA {
    [XmlElement(Order=0)]
    public S_NM1_BillingProviderName_TS837Q2_2010AAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_BillingProviderName_TS837Q2_2010AAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_BillingProviderLastOrOrganizationalName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_BillingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_BillingProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_BillingProviderNameSuffix {get; set;}
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
    public enum S_NM1_BillingProviderName_TS837Q2_2010AAD_NM101_EntityIdentifierCode {
        [XmlEnum("85")]
        Item85,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_BillingProviderName_TS837Q2_2010AAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_BillingProviderAddress_TS837Q2_2010AA {
    [XmlElement(Order=0)]
    public string D_N301_BillingProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_BillingProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_BillingProviderCityStateZIPCode_TS837Q2_2010AA {
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
    public class A_REF_TS837Q2_2010AA {
    [XmlElement(Order=0)]
    public U_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AA U_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AA {get; set;}
    [XmlElement(Order=1)]
    public U_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AA U_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AA {
    [XmlElement(Order=0)]
    public S_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U995 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AAD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        G5,
        LU,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AA {
    [XmlElement(Order=0)]
    public S_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillingProviderCreditCardIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U996 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AAD_REF01_ReferenceIdentificationQualifier {
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
    public class G_TS837Q2_2010AB {
    [XmlElement(Order=0)]
    public S_NM1_PaytoProvidersName_TS837Q2_2010AB S_NM1_PaytoProvidersName_TS837Q2_2010AB {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PaytoProvidersAddress_TS837Q2_2010AB S_N3_PaytoProvidersAddress_TS837Q2_2010AB {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PaytoProviderCityStateZip_TS837Q2_2010AB S_N4_PaytoProviderCityStateZip_TS837Q2_2010AB {get; set;}
    [XmlElement("S_REF_PaytoProviderSecondaryIdentificationNumber_TS837Q2_2010AB",Order=3)]
    public List<S_REF_PaytoProviderSecondaryIdentificationNumber_TS837Q2_2010AB> S_REF_PaytoProviderSecondaryIdentificationNumber_TS837Q2_2010AB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PaytoProvidersName_TS837Q2_2010AB {
    [XmlElement(Order=0)]
    public S_NM1_PaytoProvidersName_TS837Q2_2010ABD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_PaytoProvidersName_TS837Q2_2010ABD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PaytoProviderLastOrOrganizationalName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PaytoProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PaytoProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PaytoProviderNameSuffix {get; set;}
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
    public enum S_NM1_PaytoProvidersName_TS837Q2_2010ABD_NM101_EntityIdentifierCode {
        [XmlEnum("87")]
        Item87,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PaytoProvidersName_TS837Q2_2010ABD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PaytoProvidersAddress_TS837Q2_2010AB {
    [XmlElement(Order=0)]
    public string D_N301_PaytoProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PaytoProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PaytoProviderCityStateZip_TS837Q2_2010AB {
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
    public class S_REF_PaytoProviderSecondaryIdentificationNumber_TS837Q2_2010AB {
    [XmlElement(Order=0)]
    public S_REF_PaytoProviderSecondaryIdentificationNumber_TS837Q2_2010ABD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PaytoProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U997 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PaytoProviderSecondaryIdentificationNumber_TS837Q2_2010ABD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        G5,
        LU,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2000B {
    [XmlElement(Order=0)]
    public S_HL_SubscriberHierarchicalLevel_TS837Q2_2000B S_HL_SubscriberHierarchicalLevel_TS837Q2_2000B {get; set;}
    [XmlElement(Order=1)]
    public S_SBR_SubscriberInformation_TS837Q2_2000B S_SBR_SubscriberInformation_TS837Q2_2000B {get; set;}
    [XmlElement(Order=2)]
    public A_TS837Q2_2010B A_TS837Q2_2010B {get; set;}
    [XmlElement("G_TS837Q2_2300",Order=3)]
    public List<G_TS837Q2_2300> G_TS837Q2_2300 {get; set;}
    [XmlElement("G_TS837Q2_2000C",Order=4)]
    public List<G_TS837Q2_2000C> G_TS837Q2_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberHierarchicalLevel_TS837Q2_2000B {
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
    public class S_SBR_SubscriberInformation_TS837Q2_2000B {
    [XmlElement(Order=0)]
    public S_SBR_SubscriberInformation_TS837Q2_2000BD_SBR01_PayerResponsibilitySequenceNumberCode D_SBR01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public S_SBR_SubscriberInformation_TS837Q2_2000BD_SBR02_IndividualRelationshipCode D_SBR02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SBR03_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=3)]
    public string D_SBR04_InsuredGroupName {get; set;}
    [XmlElement(Order=4)]
    public string D_SBR05 {get; set;}
    [XmlElement(Order=5)]
    public string D_SBR06_CoordinationOfBenefitsCode {get; set;}
    [XmlElement(Order=6)]
    public string D_SBR07 {get; set;}
    [XmlElement(Order=7)]
    public string D_SBR08 {get; set;}
    [XmlElement(Order=8)]
    public string D_SBR09_ClaimFilingIndicatorCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_SBR_SubscriberInformation_TS837Q2_2000BD_SBR01_PayerResponsibilitySequenceNumberCode {
        P,
        S,
        T,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_SBR_SubscriberInformation_TS837Q2_2000BD_SBR02_IndividualRelationshipCode {
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q2_2010B {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q2_2010BA G_TS837Q2_2010BA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q2_2010BB G_TS837Q2_2010BB {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837Q2_2010BC G_TS837Q2_2010BC {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2010BA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS837Q2_2010BA S_NM1_SubscriberName_TS837Q2_2010BA {get; set;}
    [XmlElement(Order=1)]
    public S_N3_SubscriberAddress_TS837Q2_2010BA S_N3_SubscriberAddress_TS837Q2_2010BA {get; set;}
    [XmlElement(Order=2)]
    public S_N4_SubscriberCityStateZIPCode_TS837Q2_2010BA S_N4_SubscriberCityStateZIPCode_TS837Q2_2010BA {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_SubscriberDemographicInformation_TS837Q2_2010BA S_DMG_SubscriberDemographicInformation_TS837Q2_2010BA {get; set;}
    [XmlElement(Order=4)]
    public A_REF_TS837Q2_2010BA A_REF_TS837Q2_2010BA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS837Q2_2010BA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS837Q2_2010BAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubscriberName_TS837Q2_2010BAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_SubscriberName_TS837Q2_2010BAD_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS837Q2_2010BAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_SubscriberAddress_TS837Q2_2010BA {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberCityStateZIPCode_TS837Q2_2010BA {
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
    public class S_DMG_SubscriberDemographicInformation_TS837Q2_2010BA {
    [XmlElement(Order=0)]
    public S_DMG_SubscriberDemographicInformation_TS837Q2_2010BAD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_SubscriberDemographicInformation_TS837Q2_2010BAD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS837Q2_2010BA {
    [XmlElement(Order=0)]
    public U_REF_SubscriberSecondaryIdentification_TS837Q2_2010BA U_REF_SubscriberSecondaryIdentification_TS837Q2_2010BA {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010BA S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010BA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberSecondaryIdentification_TS837Q2_2010BA {
    [XmlElement(Order=0)]
    public S_REF_SubscriberSecondaryIdentification_TS837Q2_2010BAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U998 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberSecondaryIdentification_TS837Q2_2010BAD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("23")]
        Item23,
        IG,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010BA {
    [XmlElement(Order=0)]
    public S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010BAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyCasualtyClaimNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U999 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010BAD_REF01_ReferenceIdentificationQualifier {
        Y4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2010BB {
    [XmlElement(Order=0)]
    public S_NM1_PayerName_TS837Q2_2010BB S_NM1_PayerName_TS837Q2_2010BB {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayerAddress_TS837Q2_2010BB S_N3_PayerAddress_TS837Q2_2010BB {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayerCityStateZIPCode_TS837Q2_2010BB S_N4_PayerCityStateZIPCode_TS837Q2_2010BB {get; set;}
    [XmlElement("S_REF_PayerSecondaryIdentificationNumber_TS837Q2_2010BB",Order=3)]
    public List<S_REF_PayerSecondaryIdentificationNumber_TS837Q2_2010BB> S_REF_PayerSecondaryIdentificationNumber_TS837Q2_2010BB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PayerName_TS837Q2_2010BB {
    [XmlElement(Order=0)]
    public S_NM1_PayerName_TS837Q2_2010BBD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_PayerName_TS837Q2_2010BBD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_PayerName_TS837Q2_2010BBD_NM101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PayerName_TS837Q2_2010BBD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PayerAddress_TS837Q2_2010BB {
    [XmlElement(Order=0)]
    public string D_N301_PayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PayerCityStateZIPCode_TS837Q2_2010BB {
    [XmlElement(Order=0)]
    public string D_N401_PayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PayerPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_PayerPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerSecondaryIdentificationNumber_TS837Q2_2010BB {
    [XmlElement(Order=0)]
    public S_REF_PayerSecondaryIdentificationNumber_TS837Q2_2010BBD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1000 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PayerSecondaryIdentificationNumber_TS837Q2_2010BBD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("2U")]
        Item2U,
        FY,
        NF,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2010BC {
    [XmlElement(Order=0)]
    public S_NM1_CreditDebitCardHolderName_TS837Q2_2010BC S_NM1_CreditDebitCardHolderName_TS837Q2_2010BC {get; set;}
    [XmlElement("S_REF_CreditDebitCardInformation_TS837Q2_2010BC",Order=1)]
    public List<S_REF_CreditDebitCardInformation_TS837Q2_2010BC> S_REF_CreditDebitCardInformation_TS837Q2_2010BC {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CreditDebitCardHolderName_TS837Q2_2010BC {
    [XmlElement(Order=0)]
    public S_NM1_CreditDebitCardHolderName_TS837Q2_2010BCD_NM101_LocationQualifier D_NM101_LocationQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_CreditDebitCardHolderName_TS837Q2_2010BCD_NM102_IdentifierCode D_NM102_IdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CreditOrDebitCardHolderLastOrOrganizationalName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_CreditDebitCardHolderName_TS837Q2_2010BCD_NM101_LocationQualifier {
        AO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CreditDebitCardHolderName_TS837Q2_2010BCD_NM102_IdentifierCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_CreditDebitCardInformation_TS837Q2_2010BC {
    [XmlElement(Order=0)]
    public S_REF_CreditDebitCardInformation_TS837Q2_2010BCD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_CreditOrDebitCardAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1001 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_CreditDebitCardInformation_TS837Q2_2010BCD_REF01_ReferenceIdentificationQualifier {
        BB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_CLM_ClaimInformation_TS837Q2_2300 S_CLM_ClaimInformation_TS837Q2_2300 {get; set;}
    [XmlElement(Order=1)]
    public A_DTP_Date_TS837Q2_2300 A_DTP_Date_TS837Q2_2300 {get; set;}
    [XmlElement(Order=2)]
    public S_DN1_OrthodonticTotalMonthsOfTreatment_TS837Q2_2300 S_DN1_OrthodonticTotalMonthsOfTreatment_TS837Q2_2300 {get; set;}
    [XmlElement("S_DN2_ToothStatus_TS837Q2_2300",Order=3)]
    public List<S_DN2_ToothStatus_TS837Q2_2300> S_DN2_ToothStatus_TS837Q2_2300 {get; set;}
    [XmlElement("S_PWK_ClaimSupplementalInformation_TS837Q2_2300",Order=4)]
    public List<S_PWK_ClaimSupplementalInformation_TS837Q2_2300> S_PWK_ClaimSupplementalInformation_TS837Q2_2300 {get; set;}
    [XmlElement(Order=5)]
    public A_AMT_TS837Q2_2300 A_AMT_TS837Q2_2300 {get; set;}
    [XmlElement(Order=6)]
    public A_REF_TS837Q2_2300 A_REF_TS837Q2_2300 {get; set;}
    [XmlElement("S_NTE_ClaimNote_TS837Q2_2300",Order=7)]
    public List<S_NTE_ClaimNote_TS837Q2_2300> S_NTE_ClaimNote_TS837Q2_2300 {get; set;}
    [XmlElement(Order=8)]
    public A_TS837Q2_2310 A_TS837Q2_2310 {get; set;}
    [XmlElement("G_TS837Q2_2320",Order=9)]
    public List<G_TS837Q2_2320> G_TS837Q2_2320 {get; set;}
    [XmlElement("G_TS837Q2_2400",Order=10)]
    public List<G_TS837Q2_2400> G_TS837Q2_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CLM_ClaimInformation_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public string D_CLM01_PatientAccountNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_CLM02_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_CLM03 {get; set;}
    [XmlElement(Order=3)]
    public string D_CLM04 {get; set;}
    [XmlElement(Order=4)]
    public C_CLM05_C023U1004_TS837Q2_2300 C_CLM05_C023U1004_TS837Q2_2300 {get; set;}
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
    public C_CLM11_C024U1008_TS837Q2_2300 C_CLM11_C024U1008_TS837Q2_2300 {get; set;}
    [XmlElement(Order=11)]
    public string D_CLM12_SpecialProgramIndicator {get; set;}
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
    public string D_CLM18 {get; set;}
    [XmlElement(Order=18)]
    public string D_CLM19_ClaimSubmissionReasonCode {get; set;}
    [XmlElement(Order=19)]
    public string D_CLM20_DelayReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CLM05_C023U1004_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public string D_CLM05_C02301U1005_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CLM05_C02302U6036 {get; set;}
    [XmlElement(Order=2)]
    public string D_CLM05_C02303U1007_ClaimSubmissionReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CLM11_C024U1008_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public string D_CLM11_C02401U1009_RelatedCausesCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CLM11_C02402U1010_RelatedCausesCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CLM11_C02403U1011_RelatedCausesCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CLM11_C02404U1012_AutoAccidentStateOrProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CLM11_C02405U1013_CountryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_Date_TS837Q2_2300 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_DateAdmission_TS837Q2_2300 S_DTP_DateAdmission_TS837Q2_2300 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_DateDischarge_TS837Q2_2300 S_DTP_DateDischarge_TS837Q2_2300 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_DateReferral_TS837Q2_2300 S_DTP_DateReferral_TS837Q2_2300 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_DateAccident_TS837Q2_2300 S_DTP_DateAccident_TS837Q2_2300 {get; set;}
    [XmlElement(Order=4)]
    public U_DTP_DateAppliancePlacement_TS837Q2_2300 U_DTP_DateAppliancePlacement_TS837Q2_2300 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_DTP_DateService_TS837Q2_2300 S_DTP_DateService_TS837Q2_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateAdmission_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_DTP_DateAdmission_TS837Q2_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateAdmission_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_RelatedHospitalizationAdmissionDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateAdmission_TS837Q2_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("435")]
        Item435,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateAdmission_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateDischarge_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_DTP_DateDischarge_TS837Q2_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateDischarge_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DischargeOrEndOfCareDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateDischarge_TS837Q2_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("096")]
        Item096,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateDischarge_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateReferral_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_DTP_DateReferral_TS837Q2_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateReferral_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ReferralDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateReferral_TS837Q2_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("330")]
        Item330,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateReferral_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateAccident_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_DTP_DateAccident_TS837Q2_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateAccident_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateAccident_TS837Q2_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("439")]
        Item439,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateAccident_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateAppliancePlacement_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_DTP_DateAppliancePlacement_TS837Q2_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateAppliancePlacement_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OrthodonticBandingDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateAppliancePlacement_TS837Q2_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("452")]
        Item452,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateAppliancePlacement_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateService_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_DTP_DateService_TS837Q2_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateService_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateService_TS837Q2_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateService_TS837Q2_2300D_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DN1_OrthodonticTotalMonthsOfTreatment_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public string D_DN101_OrthodonticTreatmentMonthsCount {get; set;}
    [XmlElement(Order=1)]
    public string D_DN102_OrthodonticTreatmentMonthsRemainingCount {get; set;}
    [XmlElement(Order=2)]
    public string D_DN103_QuestionResponse {get; set;}
    [XmlElement(Order=3)]
    public string D_DN104 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DN2_ToothStatus_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public string D_DN201_ToothNumber {get; set;}
    [XmlElement(Order=1)]
    public S_DN2_ToothStatus_TS837Q2_2300D_DN202_ToothStatusCode D_DN202_ToothStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_DN203 {get; set;}
    [XmlElement(Order=3)]
    public string D_DN204 {get; set;}
    [XmlElement(Order=4)]
    public string D_DN205 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DN2_ToothStatus_TS837Q2_2300D_DN202_ToothStatusCode {
        E,
        I,
        M,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_ClaimSupplementalInformation_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_PWK_ClaimSupplementalInformation_TS837Q2_2300D_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_ClaimSupplementalInformation_TS837Q2_2300D_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
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
    public string D_PWK08_C002U1014 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_ClaimSupplementalInformation_TS837Q2_2300D_PWK01_AttachmentReportTypeCode {
        B4,
        DA,
        DG,
        EB,
        OB,
        OZ,
        P6,
        RB,
        RR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_ClaimSupplementalInformation_TS837Q2_2300D_PWK02_AttachmentTransmissionCode {
        AA,
        BM,
        EL,
        EM,
        FX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_AMT_TS837Q2_2300 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_PatientAmountPaid_TS837Q2_2300 S_AMT_PatientAmountPaid_TS837Q2_2300 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_CreditDebitCardMaximumAmount_TS837Q2_2300 S_AMT_CreditDebitCardMaximumAmount_TS837Q2_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_PatientAmountPaid_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_AMT_PatientAmountPaid_TS837Q2_2300D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PatientAmountPaid {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_PatientAmountPaid_TS837Q2_2300D_AMT01_AmountQualifierCode {
        F5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CreditDebitCardMaximumAmount_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_AMT_CreditDebitCardMaximumAmount_TS837Q2_2300D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_CreditOrDebitCardMaximumAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CreditDebitCardMaximumAmount_TS837Q2_2300D_AMT01_AmountQualifierCode {
        MA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public U_REF_PredeterminationIdentification_TS837Q2_2300 U_REF_PredeterminationIdentification_TS837Q2_2300 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_ServiceAuthorizationExceptionCode_TS837Q2_2300 S_REF_ServiceAuthorizationExceptionCode_TS837Q2_2300 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_OriginalReferenceNumberICNDCN_TS837Q2_2300 S_REF_OriginalReferenceNumberICNDCN_TS837Q2_2300 {get; set;}
    [XmlElement(Order=3)]
    public U_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300 U_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q2_2300 S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q2_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PredeterminationIdentification_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_REF_PredeterminationIdentification_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PredeterminationOfBenefitsIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1015 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PredeterminationIdentification_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier {
        G3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceAuthorizationExceptionCode_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_REF_ServiceAuthorizationExceptionCode_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ServiceAuthorizationExceptionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1016 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceAuthorizationExceptionCode_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("4N")]
        Item4N,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OriginalReferenceNumberICNDCN_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_REF_OriginalReferenceNumberICNDCN_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ClaimOriginalReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1017 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OriginalReferenceNumberICNDCN_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier {
        F8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1018 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9F")]
        Item9F,
        G1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ValueAddedNetworkTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1019 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ClaimIdentificationNumberForClearinghousesAndOtherTransmissionIntermediaries_TS837Q2_2300D_REF01_ReferenceIdentificationQualifier {
        D9,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_ClaimNote_TS837Q2_2300 {
    [XmlElement(Order=0)]
    public S_NTE_ClaimNote_TS837Q2_2300D_NTE01_NoteReferenceCode D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_ClaimNoteText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NTE_ClaimNote_TS837Q2_2300D_NTE01_NoteReferenceCode {
        ADD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q2_2310 {
    [XmlElement(Order=0)]
    public U_TS837Q2_2310A U_TS837Q2_2310A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q2_2310B G_TS837Q2_2310B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837Q2_2310C G_TS837Q2_2310C {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837Q2_2310D G_TS837Q2_2310D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2310A {
    [XmlElement(Order=0)]
    public S_NM1_ReferringProviderName_TS837Q2_2310A S_NM1_ReferringProviderName_TS837Q2_2310A {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_ReferringProviderSpecialtyInformation_TS837Q2_2310A S_PRV_ReferringProviderSpecialtyInformation_TS837Q2_2310A {get; set;}
    [XmlElement("S_REF_ReferringProviderSecondaryIdentification_TS837Q2_2310A",Order=2)]
    public List<S_REF_ReferringProviderSecondaryIdentification_TS837Q2_2310A> S_REF_ReferringProviderSecondaryIdentification_TS837Q2_2310A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ReferringProviderName_TS837Q2_2310A {
    [XmlElement(Order=0)]
    public S_NM1_ReferringProviderName_TS837Q2_2310AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ReferringProviderName_TS837Q2_2310AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ReferringProviderLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ReferringProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ReferringProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ReferringProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ReferringProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ReferringProviderName_TS837Q2_2310AD_NM101_EntityIdentifierCode {
        DN,
        P3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ReferringProviderName_TS837Q2_2310AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ReferringProviderSpecialtyInformation_TS837Q2_2310A {
    [XmlElement(Order=0)]
    public S_PRV_ReferringProviderSpecialtyInformation_TS837Q2_2310AD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_ReferringProviderSpecialtyInformation_TS837Q2_2310AD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U1020 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ReferringProviderSpecialtyInformation_TS837Q2_2310AD_PRV01_ProviderCode {
        RF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ReferringProviderSpecialtyInformation_TS837Q2_2310AD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReferringProviderSecondaryIdentification_TS837Q2_2310A {
    [XmlElement(Order=0)]
    public S_REF_ReferringProviderSecondaryIdentification_TS837Q2_2310AD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferringProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1021 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ReferringProviderSecondaryIdentification_TS837Q2_2310AD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        G5,
        LU,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2310B {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName_TS837Q2_2310B S_NM1_RenderingProviderName_TS837Q2_2310B {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2310B S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2310B {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2310B",Order=2)]
    public List<S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2310B> S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2310B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName_TS837Q2_2310B {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName_TS837Q2_2310BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_RenderingProviderName_TS837Q2_2310BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RenderingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RenderingProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RenderingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_RenderingProviderName_TS837Q2_2310BD_NM101_EntityIdentifierCode {
        [XmlEnum("82")]
        Item82,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_RenderingProviderName_TS837Q2_2310BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2310B {
    [XmlElement(Order=0)]
    public S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2310BD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2310BD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U1022 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2310BD_PRV01_ProviderCode {
        PE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2310BD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2310B {
    [XmlElement(Order=0)]
    public S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2310BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1023 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2310BD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        G5,
        LU,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2310C {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityLocation_TS837Q2_2310C S_NM1_ServiceFacilityLocation_TS837Q2_2310C {get; set;}
    [XmlElement("S_REF_ServiceFacilityLocationSecondaryIdentification_TS837Q2_2310C",Order=1)]
    public List<S_REF_ServiceFacilityLocationSecondaryIdentification_TS837Q2_2310C> S_REF_ServiceFacilityLocationSecondaryIdentification_TS837Q2_2310C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceFacilityLocation_TS837Q2_2310C {
    [XmlElement(Order=0)]
    public S_NM1_ServiceFacilityLocation_TS837Q2_2310CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ServiceFacilityLocation_TS837Q2_2310CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_ServiceFacilityLocation_TS837Q2_2310CD_NM101_EntityIdentifierCode {
        FA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceFacilityLocation_TS837Q2_2310CD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceFacilityLocationSecondaryIdentification_TS837Q2_2310C {
    [XmlElement(Order=0)]
    public S_REF_ServiceFacilityLocationSecondaryIdentification_TS837Q2_2310CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LaboratoryOrFacilitySecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1024 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceFacilityLocationSecondaryIdentification_TS837Q2_2310CD_REF01_ReferenceIdentificationQualifier {
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
        G2,
        LU,
        TJ,
        X4,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2310D {
    [XmlElement(Order=0)]
    public S_NM1_AssistantSurgeonName_TS837Q2_2310D S_NM1_AssistantSurgeonName_TS837Q2_2310D {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2310D S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2310D {get; set;}
    [XmlElement(Order=2)]
    public S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2310D S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2310D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AssistantSurgeonName_TS837Q2_2310D {
    [XmlElement(Order=0)]
    public S_NM1_AssistantSurgeonName_TS837Q2_2310DD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_AssistantSurgeonName_TS837Q2_2310DD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AssistantSurgeonLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AssistantSurgeonFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AssistantSurgeonMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AssistantSurgeonNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AssistantSurgeonIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AssistantSurgeonName_TS837Q2_2310DD_NM101_EntityIdentifierCode {
        DD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AssistantSurgeonName_TS837Q2_2310DD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2310D {
    [XmlElement(Order=0)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2310DD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2310DD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U6055 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2310DD_PRV01_ProviderCode {
        AS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2310DD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2310D {
    [XmlElement(Order=0)]
    public S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2310DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AssistantSurgeonSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U6056 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2310DD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        G2,
        LU,
        TJ,
        X4,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_SBR_OtherSubscriberInformation_TS837Q2_2320 S_SBR_OtherSubscriberInformation_TS837Q2_2320 {get; set;}
    [XmlElement("S_CAS_ClaimAdjustment_TS837Q2_2320",Order=1)]
    public List<S_CAS_ClaimAdjustment_TS837Q2_2320> S_CAS_ClaimAdjustment_TS837Q2_2320 {get; set;}
    [XmlElement(Order=2)]
    public A_AMT_CoordinationOfBenefitsCOB_TS837Q2_2320 A_AMT_CoordinationOfBenefitsCOB_TS837Q2_2320 {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_OtherInsuredDemographicInformation_TS837Q2_2320 S_DMG_OtherInsuredDemographicInformation_TS837Q2_2320 {get; set;}
    [XmlElement(Order=4)]
    public S_OI_OtherInsuranceCoverageInformation_TS837Q2_2320 S_OI_OtherInsuranceCoverageInformation_TS837Q2_2320 {get; set;}
    [XmlElement(Order=5)]
    public A_TS837Q2_2330 A_TS837Q2_2330 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SBR_OtherSubscriberInformation_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_SBR_OtherSubscriberInformation_TS837Q2_2320D_SBR01_PayerResponsibilitySequenceNumberCode D_SBR01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public S_SBR_OtherSubscriberInformation_TS837Q2_2320D_SBR02_IndividualRelationshipCode D_SBR02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SBR03_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=3)]
    public string D_SBR04_PolicyName {get; set;}
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
    public enum S_SBR_OtherSubscriberInformation_TS837Q2_2320D_SBR01_PayerResponsibilitySequenceNumberCode {
        P,
        S,
        T,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_SBR_OtherSubscriberInformation_TS837Q2_2320D_SBR02_IndividualRelationshipCode {
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
        [XmlEnum("22")]
        Item22,
        [XmlEnum("29")]
        Item29,
        [XmlEnum("76")]
        Item76,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ClaimAdjustment_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_CAS_ClaimAdjustment_TS837Q2_2320D_CAS01_ClaimAdjustmentGroupCode D_CAS01_ClaimAdjustmentGroupCode {get; set;}
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
    public enum S_CAS_ClaimAdjustment_TS837Q2_2320D_CAS01_ClaimAdjustmentGroupCode {
        CO,
        CR,
        OA,
        PI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_AMT_CoordinationOfBenefitsCOB_TS837Q2_2320 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBPayerPaidAmount_TS837Q2_2320 S_AMT_CoordinationOfBenefitsCOBPayerPaidAmount_TS837Q2_2320 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_CoordinationOfBenefitsCOBApprovedAmount_TS837Q2_2320 S_AMT_CoordinationOfBenefitsCOBApprovedAmount_TS837Q2_2320 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_AMT_CoordinationOfBenefitsCOBAllowedAmount_TS837Q2_2320 S_AMT_CoordinationOfBenefitsCOBAllowedAmount_TS837Q2_2320 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_TS837Q2_2320 S_AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_TS837Q2_2320 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_AMT_CoordinationOfBenefitsCOBCoveredAmount_TS837Q2_2320 S_AMT_CoordinationOfBenefitsCOBCoveredAmount_TS837Q2_2320 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_AMT_CoordinationOfBenefitsCOBDiscountAmount_TS837Q2_2320 S_AMT_CoordinationOfBenefitsCOBDiscountAmount_TS837Q2_2320 {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_AMT_CoordinationOfBenefitsCOBPatientPaidAmount_TS837Q2_2320 S_AMT_CoordinationOfBenefitsCOBPatientPaidAmount_TS837Q2_2320 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBPayerPaidAmount_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBPayerPaidAmount_TS837Q2_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PayerPaidAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBPayerPaidAmount_TS837Q2_2320D_AMT01_AmountQualifierCode {
        D,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBApprovedAmount_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBApprovedAmount_TS837Q2_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ApprovedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBApprovedAmount_TS837Q2_2320D_AMT01_AmountQualifierCode {
        AAE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBAllowedAmount_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBAllowedAmount_TS837Q2_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_AllowedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBAllowedAmount_TS837Q2_2320D_AMT01_AmountQualifierCode {
        B6,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_TS837Q2_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_PatientResponsibilityAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBPatientResponsibilityAmount_TS837Q2_2320D_AMT01_AmountQualifierCode {
        F2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBCoveredAmount_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBCoveredAmount_TS837Q2_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_CoveredAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBCoveredAmount_TS837Q2_2320D_AMT01_AmountQualifierCode {
        AU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBDiscountAmount_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBDiscountAmount_TS837Q2_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_OtherPayerDiscountAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBDiscountAmount_TS837Q2_2320D_AMT01_AmountQualifierCode {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_CoordinationOfBenefitsCOBPatientPaidAmount_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_AMT_CoordinationOfBenefitsCOBPatientPaidAmount_TS837Q2_2320D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_OtherPayerPatientPaidAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_CoordinationOfBenefitsCOBPatientPaidAmount_TS837Q2_2320D_AMT01_AmountQualifierCode {
        F5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_OtherInsuredDemographicInformation_TS837Q2_2320 {
    [XmlElement(Order=0)]
    public S_DMG_OtherInsuredDemographicInformation_TS837Q2_2320D_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_OtherInsuredDemographicInformation_TS837Q2_2320D_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_OI_OtherInsuranceCoverageInformation_TS837Q2_2320 {
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
    public class A_TS837Q2_2330 {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q2_2330A G_TS837Q2_2330A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q2_2330B G_TS837Q2_2330B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837Q2_2330C G_TS837Q2_2330C {get; set;}
    [XmlElementAttribute(Order=3)]
    public G_TS837Q2_2330D G_TS837Q2_2330D {get; set;}
    [XmlElementAttribute(Order=4)]
    public G_TS837Q2_2330E G_TS837Q2_2330E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2330A {
    [XmlElement(Order=0)]
    public S_NM1_OtherSubscriberName_TS837Q2_2330A S_NM1_OtherSubscriberName_TS837Q2_2330A {get; set;}
    [XmlElement(Order=1)]
    public S_N3_OtherSubscriberAddress_TS837Q2_2330A S_N3_OtherSubscriberAddress_TS837Q2_2330A {get; set;}
    [XmlElement(Order=2)]
    public S_N4_OtherSubscriberCityStateZipCode_TS837Q2_2330A S_N4_OtherSubscriberCityStateZipCode_TS837Q2_2330A {get; set;}
    [XmlElement("S_REF_OtherSubscriberSecondaryIdentification_TS837Q2_2330A",Order=3)]
    public List<S_REF_OtherSubscriberSecondaryIdentification_TS837Q2_2330A> S_REF_OtherSubscriberSecondaryIdentification_TS837Q2_2330A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherSubscriberName_TS837Q2_2330A {
    [XmlElement(Order=0)]
    public S_NM1_OtherSubscriberName_TS837Q2_2330AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherSubscriberName_TS837Q2_2330AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_OtherSubscriberName_TS837Q2_2330AD_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherSubscriberName_TS837Q2_2330AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_OtherSubscriberAddress_TS837Q2_2330A {
    [XmlElement(Order=0)]
    public string D_N301_OtherInsuredAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_OtherInsuredAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_OtherSubscriberCityStateZipCode_TS837Q2_2330A {
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
    public class S_REF_OtherSubscriberSecondaryIdentification_TS837Q2_2330A {
    [XmlElement(Order=0)]
    public S_REF_OtherSubscriberSecondaryIdentification_TS837Q2_2330AD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherInsuredAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1025 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherSubscriberSecondaryIdentification_TS837Q2_2330AD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("23")]
        Item23,
        IG,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2330B {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerName_TS837Q2_2330B S_NM1_OtherPayerName_TS837Q2_2330B {get; set;}
    [XmlElement("S_PER_OtherPayerContactInformation_TS837Q2_2330B",Order=1)]
    public List<S_PER_OtherPayerContactInformation_TS837Q2_2330B> S_PER_OtherPayerContactInformation_TS837Q2_2330B {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_ClaimPaidDate_TS837Q2_2330B S_DTP_ClaimPaidDate_TS837Q2_2330B {get; set;}
    [XmlElement(Order=3)]
    public A_REF_OtherPayer_TS837Q2_2330B A_REF_OtherPayer_TS837Q2_2330B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerName_TS837Q2_2330B {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerName_TS837Q2_2330BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerName_TS837Q2_2330BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_OtherPayerName_TS837Q2_2330BD_NM101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerName_TS837Q2_2330BD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_OtherPayerContactInformation_TS837Q2_2330B {
    [XmlElement(Order=0)]
    public S_PER_OtherPayerContactInformation_TS837Q2_2330BD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_OtherPayerContactName {get; set;}
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
    public enum S_PER_OtherPayerContactInformation_TS837Q2_2330BD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimPaidDate_TS837Q2_2330B {
    [XmlElement(Order=0)]
    public S_DTP_ClaimPaidDate_TS837Q2_2330BD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ClaimPaidDate_TS837Q2_2330BD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateClaimPaid {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ClaimPaidDate_TS837Q2_2330BD_DTP01_DateTimeQualifier {
        [XmlEnum("573")]
        Item573,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ClaimPaidDate_TS837Q2_2330BD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_OtherPayer_TS837Q2_2330B {
    [XmlElement(Order=0)]
    public U_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330B U_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330B {get; set;}
    [XmlElement(Order=1)]
    public U_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330B U_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330B {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_OtherPayerClaimAdjustmentIndicator_TS837Q2_2330B S_REF_OtherPayerClaimAdjustmentIndicator_TS837Q2_2330B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330B {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1026 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("2U")]
        Item2U,
        D8,
        F8,
        FY,
        NF,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330B {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationOrReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1027 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9F")]
        Item9F,
        G1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerClaimAdjustmentIndicator_TS837Q2_2330B {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerClaimAdjustmentIndicator_TS837Q2_2330BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerClaimAdjustmentIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1028 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerClaimAdjustmentIndicator_TS837Q2_2330BD_REF01_ReferenceIdentificationQualifier {
        T4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2330C {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerPatientInformation_TS837Q2_2330C S_NM1_OtherPayerPatientInformation_TS837Q2_2330C {get; set;}
    [XmlElement("S_REF_OtherPayerPatientIdentification_TS837Q2_2330C",Order=1)]
    public List<S_REF_OtherPayerPatientIdentification_TS837Q2_2330C> S_REF_OtherPayerPatientIdentification_TS837Q2_2330C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerPatientInformation_TS837Q2_2330C {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerPatientInformation_TS837Q2_2330CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerPatientInformation_TS837Q2_2330CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_OtherPayerPatientInformation_TS837Q2_2330CD_NM101_EntityIdentifierCode {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerPatientInformation_TS837Q2_2330CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerPatientIdentification_TS837Q2_2330C {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerPatientIdentification_TS837Q2_2330CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPatientPrimaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1029 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerPatientIdentification_TS837Q2_2330CD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("23")]
        Item23,
        IG,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2330D {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerReferringProvider_TS837Q2_2330D S_NM1_OtherPayerReferringProvider_TS837Q2_2330D {get; set;}
    [XmlElement("S_REF_OtherPayerReferringProviderIdentification_TS837Q2_2330D",Order=1)]
    public List<S_REF_OtherPayerReferringProviderIdentification_TS837Q2_2330D> S_REF_OtherPayerReferringProviderIdentification_TS837Q2_2330D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerReferringProvider_TS837Q2_2330D {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerReferringProvider_TS837Q2_2330DD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerReferringProvider_TS837Q2_2330DD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_OtherPayerReferringProvider_TS837Q2_2330DD_NM101_EntityIdentifierCode {
        DN,
        P3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerReferringProvider_TS837Q2_2330DD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerReferringProviderIdentification_TS837Q2_2330D {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerReferringProviderIdentification_TS837Q2_2330DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerReferringProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1030 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerReferringProviderIdentification_TS837Q2_2330DD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        G5,
        LU,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2330E {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerRenderingProvider_TS837Q2_2330E S_NM1_OtherPayerRenderingProvider_TS837Q2_2330E {get; set;}
    [XmlElement("S_REF_OtherPayerRenderingProviderIdentification_TS837Q2_2330E",Order=1)]
    public List<S_REF_OtherPayerRenderingProviderIdentification_TS837Q2_2330E> S_REF_OtherPayerRenderingProviderIdentification_TS837Q2_2330E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerRenderingProvider_TS837Q2_2330E {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerRenderingProvider_TS837Q2_2330ED_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerRenderingProvider_TS837Q2_2330ED_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_OtherPayerRenderingProvider_TS837Q2_2330ED_NM101_EntityIdentifierCode {
        [XmlEnum("82")]
        Item82,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerRenderingProvider_TS837Q2_2330ED_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerRenderingProviderIdentification_TS837Q2_2330E {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerRenderingProviderIdentification_TS837Q2_2330ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerRenderingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1031 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerRenderingProviderIdentification_TS837Q2_2330ED_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        G5,
        LU,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2400 {
    [XmlElement("S_LX_LineCounter_TS837Q2_2400",Order=0)]
    public List<S_LX_LineCounter_TS837Q2_2400> S_LX_LineCounter_TS837Q2_2400 {get; set;}
    [XmlElement(Order=1)]
    public S_SV3_DentalService_TS837Q2_2400 S_SV3_DentalService_TS837Q2_2400 {get; set;}
    [XmlElement("S_TOO_ToothInformation_TS837Q2_2400",Order=2)]
    public List<S_TOO_ToothInformation_TS837Q2_2400> S_TOO_ToothInformation_TS837Q2_2400 {get; set;}
    [XmlElement(Order=3)]
    public A_DTP_Date_TS837Q2_2400 A_DTP_Date_TS837Q2_2400 {get; set;}
    [XmlElement("S_QTY_AnesthesiaQuantity_TS837Q2_2400",Order=4)]
    public List<S_QTY_AnesthesiaQuantity_TS837Q2_2400> S_QTY_AnesthesiaQuantity_TS837Q2_2400 {get; set;}
    [XmlElement(Order=5)]
    public A_REF_TS837Q2_2400 A_REF_TS837Q2_2400 {get; set;}
    [XmlElement(Order=6)]
    public A_AMT_TS837Q2_2400 A_AMT_TS837Q2_2400 {get; set;}
    [XmlElement("S_NTE_LineNote_TS837Q2_2400",Order=7)]
    public List<S_NTE_LineNote_TS837Q2_2400> S_NTE_LineNote_TS837Q2_2400 {get; set;}
    [XmlElement(Order=8)]
    public A_TS837Q2_2420 A_TS837Q2_2420 {get; set;}
    [XmlElement("G_TS837Q2_2430",Order=9)]
    public List<G_TS837Q2_2430> G_TS837Q2_2430 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_LineCounter_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SV3_DentalService_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public C_SV301_C003U1032_TS837Q2_2400 C_SV301_C003U1032_TS837Q2_2400 {get; set;}
    [XmlElement(Order=1)]
    public string D_SV302_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SV303_FacilityTypeCode {get; set;}
    [XmlElement(Order=3)]
    public C_SV304_C006U1040_TS837Q2_2400 C_SV304_C006U1040_TS837Q2_2400 {get; set;}
    [XmlElement(Order=4)]
    public string D_SV305_ProsthesisCrownOrInlayCode {get; set;}
    [XmlElement(Order=5)]
    public string D_SV306_ProcedureCount {get; set;}
    [XmlElement(Order=6)]
    public string D_SV307 {get; set;}
    [XmlElement(Order=7)]
    public string D_SV308 {get; set;}
    [XmlElement(Order=8)]
    public string D_SV309 {get; set;}
    [XmlElement(Order=9)]
    public string D_SV310 {get; set;}
    [XmlElement(Order=10)]
    public string D_SV311_C004U1046 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SV301_C003U1032_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public C_SV301_C003U1032_TS837Q2_2400D_SV301_C00301U1033_ProductOrServiceIDQualifier D_SV301_C00301U1033_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SV301_C00302U1034_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SV301_C00303U1035_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_SV301_C00304U1036_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_SV301_C00305U1037_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_SV301_C00306U1038_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SV301_C00307U6071 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_SV301_C003U1032_TS837Q2_2400D_SV301_C00301U1033_ProductOrServiceIDQualifier {
        AD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SV304_C006U1040_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public string D_SV304_C00601U1041_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=1)]
    public string D_SV304_C00602U1042_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SV304_C00603U1043_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=3)]
    public string D_SV304_C00604U1044_OralCavityDesignationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SV304_C00605U1045_OralCavityDesignationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TOO_ToothInformation_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_TOO_ToothInformation_TS837Q2_2400D_TOO01_CodeListQualifierCode D_TOO01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TOO02_ToothCode {get; set;}
    [XmlElement(Order=2)]
    public C_TOO03_C005U1047_TS837Q2_2400 C_TOO03_C005U1047_TS837Q2_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TOO_ToothInformation_TS837Q2_2400D_TOO01_CodeListQualifierCode {
        JP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_TOO03_C005U1047_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public string D_TOO03_C00501U1048_ToothSurfaceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TOO03_C00502U1049_ToothSurfaceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_TOO03_C00503U1050_ToothSurfaceCode {get; set;}
    [XmlElement(Order=3)]
    public string D_TOO03_C00504U1051_ToothSurfaceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_TOO03_C00505U1052_ToothSurfaceCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_Date_TS837Q2_2400 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_DateService_TS837Q2_2400 S_DTP_DateService_TS837Q2_2400 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_DatePriorPlacement_TS837Q2_2400 S_DTP_DatePriorPlacement_TS837Q2_2400 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_DateAppliancePlacement_TS837Q2_2400 S_DTP_DateAppliancePlacement_TS837Q2_2400 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_DateReplacement_TS837Q2_2400 S_DTP_DateReplacement_TS837Q2_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateService_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_DTP_DateService_TS837Q2_2400D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateService_TS837Q2_2400D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateService_TS837Q2_2400D_DTP01_DateTimeQualifier {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateService_TS837Q2_2400D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DatePriorPlacement_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_DTP_DatePriorPlacement_TS837Q2_2400D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DatePriorPlacement_TS837Q2_2400D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_PriorPlacementDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DatePriorPlacement_TS837Q2_2400D_DTP01_DateTimeQualifier {
        [XmlEnum("441")]
        Item441,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DatePriorPlacement_TS837Q2_2400D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateAppliancePlacement_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_DTP_DateAppliancePlacement_TS837Q2_2400D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateAppliancePlacement_TS837Q2_2400D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OrthodonticBandingDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateAppliancePlacement_TS837Q2_2400D_DTP01_DateTimeQualifier {
        [XmlEnum("452")]
        Item452,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateAppliancePlacement_TS837Q2_2400D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DateReplacement_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_DTP_DateReplacement_TS837Q2_2400D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DateReplacement_TS837Q2_2400D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ReplacementDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateReplacement_TS837Q2_2400D_DTP01_DateTimeQualifier {
        [XmlEnum("446")]
        Item446,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DateReplacement_TS837Q2_2400D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_AnesthesiaQuantity_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_QTY_AnesthesiaQuantity_TS837Q2_2400D_QTY01_QuantityQualifier D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_AnesthesiaUnitCount {get; set;}
    [XmlElement(Order=2)]
    public string D_QTY03_C001U1053 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_QTY_AnesthesiaQuantity_TS837Q2_2400D_QTY01_QuantityQualifier {
        BF,
        EM,
        HM,
        HO,
        HP,
        P3,
        P4,
        P5,
        SG,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS837Q2_2400 {
    [XmlElementAttribute(Order=0)]
    public S_REF_ServicePredeterminationIdentification_TS837Q2_2400 S_REF_ServicePredeterminationIdentification_TS837Q2_2400 {get; set;}
    [XmlElement(Order=1)]
    public U_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400 U_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_LineItemControlNumber_TS837Q2_2400 S_REF_LineItemControlNumber_TS837Q2_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServicePredeterminationIdentification_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_REF_ServicePredeterminationIdentification_TS837Q2_2400D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PredeterminationOfBenefitsIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1054 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServicePredeterminationIdentification_TS837Q2_2400D_REF01_ReferenceIdentificationQualifier {
        G3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1055 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9F")]
        Item9F,
        G1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_LineItemControlNumber_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_REF_LineItemControlNumber_TS837Q2_2400D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1056 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_LineItemControlNumber_TS837Q2_2400D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("6R")]
        Item6R,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_AMT_TS837Q2_2400 {
    [XmlElementAttribute(Order=0)]
    public S_AMT_ApprovedAmount_TS837Q2_2400 S_AMT_ApprovedAmount_TS837Q2_2400 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_AMT_SalesTaxAmount_TS837Q2_2400 S_AMT_SalesTaxAmount_TS837Q2_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ApprovedAmount_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_AMT_ApprovedAmount_TS837Q2_2400D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ApprovedAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_ApprovedAmount_TS837Q2_2400D_AMT01_AmountQualifierCode {
        AAE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_SalesTaxAmount_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_AMT_SalesTaxAmount_TS837Q2_2400D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_SalesTaxAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_SalesTaxAmount_TS837Q2_2400D_AMT01_AmountQualifierCode {
        T,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NTE_LineNote_TS837Q2_2400 {
    [XmlElement(Order=0)]
    public S_NTE_LineNote_TS837Q2_2400D_NTE01_NoteReferenceCode D_NTE01_NoteReferenceCode {get; set;}
    [XmlElement(Order=1)]
    public string D_NTE02_ClaimNoteText {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NTE_LineNote_TS837Q2_2400D_NTE01_NoteReferenceCode {
        ADD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS837Q2_2420 {
    [XmlElementAttribute(Order=0)]
    public G_TS837Q2_2420A G_TS837Q2_2420A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS837Q2_2420B G_TS837Q2_2420B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS837Q2_2420C G_TS837Q2_2420C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2420A {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName_TS837Q2_2420A S_NM1_RenderingProviderName_TS837Q2_2420A {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2420A S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2420A {get; set;}
    [XmlElement("S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2420A",Order=2)]
    public List<S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2420A> S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2420A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RenderingProviderName_TS837Q2_2420A {
    [XmlElement(Order=0)]
    public S_NM1_RenderingProviderName_TS837Q2_2420AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_RenderingProviderName_TS837Q2_2420AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RenderingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RenderingProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RenderingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_RenderingProviderName_TS837Q2_2420AD_NM101_EntityIdentifierCode {
        [XmlEnum("82")]
        Item82,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_RenderingProviderName_TS837Q2_2420AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2420A {
    [XmlElement(Order=0)]
    public S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2420AD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2420AD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U1057 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2420AD_PRV01_ProviderCode {
        PE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_RenderingProviderSpecialtyInformation_TS837Q2_2420AD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2420A {
    [XmlElement(Order=0)]
    public S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2420AD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1058 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_RenderingProviderSecondaryIdentification_TS837Q2_2420AD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        EI,
        G2,
        G5,
        LU,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2420B {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerReferralNumber_TS837Q2_2420B S_NM1_OtherPayerReferralNumber_TS837Q2_2420B {get; set;}
    [XmlElement("S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2420B",Order=1)]
    public List<S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2420B> S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2420B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherPayerReferralNumber_TS837Q2_2420B {
    [XmlElement(Order=0)]
    public S_NM1_OtherPayerReferralNumber_TS837Q2_2420BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_OtherPayerReferralNumber_TS837Q2_2420BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public string D_NM109_OtherPayerReferralNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerReferralNumber_TS837Q2_2420BD_NM101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_OtherPayerReferralNumber_TS837Q2_2420BD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2420B {
    [XmlElement(Order=0)]
    public S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2420BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherPayerPriorAuthorizationOrReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1059 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2420BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9F")]
        Item9F,
        G1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2420C {
    [XmlElement(Order=0)]
    public S_NM1_AssistantSurgeonName_TS837Q2_2420C S_NM1_AssistantSurgeonName_TS837Q2_2420C {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2420C S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2420C {get; set;}
    [XmlElement(Order=2)]
    public S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2420C S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2420C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AssistantSurgeonName_TS837Q2_2420C {
    [XmlElement(Order=0)]
    public S_NM1_AssistantSurgeonName_TS837Q2_2420CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_AssistantSurgeonName_TS837Q2_2420CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_AssistantSurgeonLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_AssistantSurgeonFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_AssistantSurgeonMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_AssistantSurgeonNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_AssistantSurgeonIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AssistantSurgeonName_TS837Q2_2420CD_NM101_EntityIdentifierCode {
        DD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AssistantSurgeonName_TS837Q2_2420CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2420C {
    [XmlElement(Order=0)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2420CD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2420CD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U6092 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2420CD_PRV01_ProviderCode {
        AS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_AssistantSurgeonSpecialtyInformation_TS837Q2_2420CD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2420C {
    [XmlElement(Order=0)]
    public S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2420CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AssistantSurgeonSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U6093 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_AssistantSurgeonSecondaryIdentification_TS837Q2_2420CD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1H")]
        Item1H,
        G2,
        LU,
        TJ,
        X4,
        X5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2430 {
    [XmlElement(Order=0)]
    public S_SVD_LineAdjudicationInformation_TS837Q2_2430 S_SVD_LineAdjudicationInformation_TS837Q2_2430 {get; set;}
    [XmlElement("S_CAS_ServiceAdjustment_TS837Q2_2430",Order=1)]
    public List<S_CAS_ServiceAdjustment_TS837Q2_2430> S_CAS_ServiceAdjustment_TS837Q2_2430 {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_LineAdjudicationDate_TS837Q2_2430 S_DTP_LineAdjudicationDate_TS837Q2_2430 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVD_LineAdjudicationInformation_TS837Q2_2430 {
    [XmlElement(Order=0)]
    public string D_SVD01_OtherPayerPrimaryIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVD02_ServiceLinePaidAmount {get; set;}
    [XmlElement(Order=2)]
    public C_SVD03_C003U1060_TS837Q2_2430 C_SVD03_C003U1060_TS837Q2_2430 {get; set;}
    [XmlElement(Order=3)]
    public string D_SVD04 {get; set;}
    [XmlElement(Order=4)]
    public string D_SVD05_PaidServiceUnitCount {get; set;}
    [XmlElement(Order=5)]
    public string D_SVD06_BundledOrUnbundledLineNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SVD03_C003U1060_TS837Q2_2430 {
    [XmlElement(Order=0)]
    public string D_SVD03_C00301U1061_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVD03_C00302U1062_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SVD03_C00303U1063_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_SVD03_C00304U1064_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_SVD03_C00305U1065_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_SVD03_C00306U1066_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SVD03_C00307U1067_ProcedureCodeDescription {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ServiceAdjustment_TS837Q2_2430 {
    [XmlElement(Order=0)]
    public S_CAS_ServiceAdjustment_TS837Q2_2430D_CAS01_ClaimAdjustmentGroupCode D_CAS01_ClaimAdjustmentGroupCode {get; set;}
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
    public enum S_CAS_ServiceAdjustment_TS837Q2_2430D_CAS01_ClaimAdjustmentGroupCode {
        CO,
        CR,
        OA,
        PI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LineAdjudicationDate_TS837Q2_2430 {
    [XmlElement(Order=0)]
    public S_DTP_LineAdjudicationDate_TS837Q2_2430D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_LineAdjudicationDate_TS837Q2_2430D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AdjudicationOrPaymentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LineAdjudicationDate_TS837Q2_2430D_DTP01_DateTimeQualifier {
        [XmlEnum("573")]
        Item573,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LineAdjudicationDate_TS837Q2_2430D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2000C {
    [XmlElement(Order=0)]
    public S_HL_PatientHierarchicalLevel_TS837Q2_2000C S_HL_PatientHierarchicalLevel_TS837Q2_2000C {get; set;}
    [XmlElement(Order=1)]
    public S_PAT_PatientInformation_TS837Q2_2000C S_PAT_PatientInformation_TS837Q2_2000C {get; set;}
    [XmlElement(Order=2)]
    public G_TS837Q2_2010CA G_TS837Q2_2010CA {get; set;}
    [XmlElement("G_TS837Q2_2300",Order=3)]
    public List<G_TS837Q2_2300> G_TS837Q2_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_PatientHierarchicalLevel_TS837Q2_2000C {
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
    public class S_PAT_PatientInformation_TS837Q2_2000C {
    [XmlElement(Order=0)]
    public S_PAT_PatientInformation_TS837Q2_2000CD_PAT01_IndividualRelationshipCode D_PAT01_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PAT02 {get; set;}
    [XmlElement(Order=2)]
    public string D_PAT03 {get; set;}
    [XmlElement(Order=3)]
    public string D_PAT04_StudentStatusCode {get; set;}
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
    public enum S_PAT_PatientInformation_TS837Q2_2000CD_PAT01_IndividualRelationshipCode {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("20")]
        Item20,
        [XmlEnum("22")]
        Item22,
        [XmlEnum("29")]
        Item29,
        [XmlEnum("41")]
        Item41,
        [XmlEnum("53")]
        Item53,
        [XmlEnum("76")]
        Item76,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS837Q2_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_PatientName_TS837Q2_2010CA S_NM1_PatientName_TS837Q2_2010CA {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PatientAddress_TS837Q2_2010CA S_N3_PatientAddress_TS837Q2_2010CA {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PatientCityStateZIPCode_TS837Q2_2010CA S_N4_PatientCityStateZIPCode_TS837Q2_2010CA {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_PatientDemographicInformation_TS837Q2_2010CA S_DMG_PatientDemographicInformation_TS837Q2_2010CA {get; set;}
    [XmlElement(Order=4)]
    public A_REF_TS837Q2_2010CA A_REF_TS837Q2_2010CA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientName_TS837Q2_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_PatientName_TS837Q2_2010CAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_PatientName_TS837Q2_2010CAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_PatientName_TS837Q2_2010CAD_NM101_EntityIdentifierCode {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PatientName_TS837Q2_2010CAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PatientAddress_TS837Q2_2010CA {
    [XmlElement(Order=0)]
    public string D_N301_PatientAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PatientAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PatientCityStateZIPCode_TS837Q2_2010CA {
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
    public class S_DMG_PatientDemographicInformation_TS837Q2_2010CA {
    [XmlElement(Order=0)]
    public S_DMG_PatientDemographicInformation_TS837Q2_2010CAD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_PatientDemographicInformation_TS837Q2_2010CAD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS837Q2_2010CA {
    [XmlElement(Order=0)]
    public U_REF_PatientSecondaryIdentification_TS837Q2_2010CA U_REF_PatientSecondaryIdentification_TS837Q2_2010CA {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010CA S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010CA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PatientSecondaryIdentification_TS837Q2_2010CA {
    [XmlElement(Order=0)]
    public S_REF_PatientSecondaryIdentification_TS837Q2_2010CAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PatientSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1002 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PatientSecondaryIdentification_TS837Q2_2010CAD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("23")]
        Item23,
        IG,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010CA {
    [XmlElement(Order=0)]
    public S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010CAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PropertyCasualtyClaimNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1003 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PropertyAndCasualtyClaimNumber_TS837Q2_2010CAD_REF01_ReferenceIdentificationQualifier {
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
    public class U_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AA {
    [XmlElement("S_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AA",Order=0)]
    public List<S_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AA> S_REF_BillingProviderSecondaryIdentificationNumber_TS837Q2_2010AA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AA {
    [XmlElement("S_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AA",Order=0)]
    public List<S_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AA> S_REF_ClaimSubmitterCreditDebitCardInformation_TS837Q2_2010AA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_SubscriberSecondaryIdentification_TS837Q2_2010BA {
    [XmlElement("S_REF_SubscriberSecondaryIdentification_TS837Q2_2010BA",Order=0)]
    public List<S_REF_SubscriberSecondaryIdentification_TS837Q2_2010BA> S_REF_SubscriberSecondaryIdentification_TS837Q2_2010BA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_DTP_DateAppliancePlacement_TS837Q2_2300 {
    [XmlElement("S_DTP_DateAppliancePlacement_TS837Q2_2300",Order=0)]
    public List<S_DTP_DateAppliancePlacement_TS837Q2_2300> S_DTP_DateAppliancePlacement_TS837Q2_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PredeterminationIdentification_TS837Q2_2300 {
    [XmlElement("S_REF_PredeterminationIdentification_TS837Q2_2300",Order=0)]
    public List<S_REF_PredeterminationIdentification_TS837Q2_2300> S_REF_PredeterminationIdentification_TS837Q2_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300 {
    [XmlElement("S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300",Order=0)]
    public List<S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300> S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS837Q2_2310A {
    [XmlElement("G_TS837Q2_2310A",Order=0)]
    public List<G_TS837Q2_2310A> G_TS837Q2_2310A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330B {
    [XmlElement("S_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330B",Order=0)]
    public List<S_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330B> S_REF_OtherPayerSecondaryIdentifier_TS837Q2_2330B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330B {
    [XmlElement("S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330B",Order=0)]
    public List<S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330B> S_REF_OtherPayerPriorAuthorizationOrReferralNumber_TS837Q2_2330B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400 {
    [XmlElement("S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400",Order=0)]
    public List<S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400> S_REF_PriorAuthorizationOrReferralNumber_TS837Q2_2400 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_PatientSecondaryIdentification_TS837Q2_2010CA {
    [XmlElement("S_REF_PatientSecondaryIdentification_TS837Q2_2010CA",Order=0)]
    public List<S_REF_PatientSecondaryIdentification_TS837Q2_2010CA> S_REF_PatientSecondaryIdentification_TS837Q2_2010CA {get; set;}
    }
}
