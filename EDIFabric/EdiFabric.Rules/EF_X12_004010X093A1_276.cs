namespace EdiFabric.Rules.X12004010X093A1276 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_276 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS276A1 S_BHT_BeginningOfHierarchicalTransaction_TS276A1 {get; set;}
    [XmlElement("G_TS276A1_2000A",Order=2)]
    public List<G_TS276A1_2000A> G_TS276A1_2000A {get; set;}
    [XmlElement(Order=3)]
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
    public class S_BHT_BeginningOfHierarchicalTransaction_TS276A1 {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS276A1D_BHT01_HierarchicalStructureCode D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS276A1D_BHT02_TransactionSetPurposeCode D_BHT02_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BHT03 {get; set;}
    [XmlElement(Order=3)]
    public string D_BHT04_TransactionSetCreationDate {get; set;}
    [XmlElement(Order=4)]
    public string D_BHT05 {get; set;}
    [XmlElement(Order=5)]
    public string D_BHT06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS276A1D_BHT01_HierarchicalStructureCode {
        [XmlEnum("0010")]
        Item0010,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS276A1D_BHT02_TransactionSetPurposeCode {
        [XmlEnum("13")]
        Item13,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2000A {
    [XmlElement(Order=0)]
    public S_HL_InformationSourceLevel_TS276A1_2000A S_HL_InformationSourceLevel_TS276A1_2000A {get; set;}
    [XmlElement("G_TS276A1_2100A",Order=1)]
    public List<G_TS276A1_2100A> G_TS276A1_2100A {get; set;}
    [XmlElement("G_TS276A1_2000B",Order=2)]
    public List<G_TS276A1_2000B> G_TS276A1_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_InformationSourceLevel_TS276A1_2000A {
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
    public class G_TS276A1_2100A {
    [XmlElement(Order=0)]
    public S_NM1_PayerName_TS276A1_2100A S_NM1_PayerName_TS276A1_2100A {get; set;}
    [XmlElement(Order=1)]
    public S_PER_PayerContactInformation_TS276A1_2100A S_PER_PayerContactInformation_TS276A1_2100A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PayerName_TS276A1_2100A {
    [XmlElement(Order=0)]
    public S_NM1_PayerName_TS276A1_2100AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_PayerName_TS276A1_2100AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_PayerName_TS276A1_2100AD_NM101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PayerName_TS276A1_2100AD_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_PayerContactInformation_TS276A1_2100A {
    [XmlElement(Order=0)]
    public S_PER_PayerContactInformation_TS276A1_2100AD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_PayerContactName {get; set;}
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
    public enum S_PER_PayerContactInformation_TS276A1_2100AD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2000B {
    [XmlElement(Order=0)]
    public S_HL_InformationReceiverLevel_TS276A1_2000B S_HL_InformationReceiverLevel_TS276A1_2000B {get; set;}
    [XmlElement("G_TS276A1_2100B",Order=1)]
    public List<G_TS276A1_2100B> G_TS276A1_2100B {get; set;}
    [XmlElement("G_TS276A1_2000C",Order=2)]
    public List<G_TS276A1_2000C> G_TS276A1_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_InformationReceiverLevel_TS276A1_2000B {
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
    public class G_TS276A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_InformationReceiverName_TS276A1_2100B S_NM1_InformationReceiverName_TS276A1_2100B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationReceiverName_TS276A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_InformationReceiverName_TS276A1_2100BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_InformationReceiverName_TS276A1_2100BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_InformationReceiverLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_InformationReceiverFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_InformationReceiverMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_InformationReceiverNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_InformationReceiverIdentificationNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_InformationReceiverName_TS276A1_2100BD_NM101_EntityIdentifierCode {
        [XmlEnum("41")]
        Item41,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_InformationReceiverName_TS276A1_2100BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2000C {
    [XmlElement(Order=0)]
    public S_HL_ServiceProviderLevel_TS276A1_2000C S_HL_ServiceProviderLevel_TS276A1_2000C {get; set;}
    [XmlElement("G_TS276A1_2100C",Order=1)]
    public List<G_TS276A1_2100C> G_TS276A1_2100C {get; set;}
    [XmlElement("G_TS276A1_2000D",Order=2)]
    public List<G_TS276A1_2000D> G_TS276A1_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_ServiceProviderLevel_TS276A1_2000C {
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
    public class G_TS276A1_2100C {
    [XmlElement(Order=0)]
    public S_NM1_ProviderName_TS276A1_2100C S_NM1_ProviderName_TS276A1_2100C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ProviderName_TS276A1_2100C {
    [XmlElement(Order=0)]
    public S_NM1_ProviderName_TS276A1_2100CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ProviderName_TS276A1_2100CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ProviderLastOrOrganizationName {get; set;}
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
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ProviderName_TS276A1_2100CD_NM101_EntityIdentifierCode {
        [XmlEnum("1P")]
        Item1P,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ProviderName_TS276A1_2100CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2000D {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel_TS276A1_2000D S_HL_SubscriberLevel_TS276A1_2000D {get; set;}
    [XmlElement(Order=1)]
    public S_DMG_SubscriberDemographicInformation_TS276A1_2000D S_DMG_SubscriberDemographicInformation_TS276A1_2000D {get; set;}
    [XmlElement(Order=2)]
    public G_TS276A1_2100D G_TS276A1_2100D {get; set;}
    [XmlElement("G_TS276A1_2200D",Order=3)]
    public List<G_TS276A1_2200D> G_TS276A1_2200D {get; set;}
    [XmlElement("G_TS276A1_2000E",Order=4)]
    public List<G_TS276A1_2000E> G_TS276A1_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberLevel_TS276A1_2000D {
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
    public class S_DMG_SubscriberDemographicInformation_TS276A1_2000D {
    [XmlElement(Order=0)]
    public S_DMG_SubscriberDemographicInformation_TS276A1_2000DD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_SubscriberDemographicInformation_TS276A1_2000DD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2100D {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS276A1_2100D S_NM1_SubscriberName_TS276A1_2100D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS276A1_2100D {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS276A1_2100DD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubscriberName_TS276A1_2100DD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SubscriberLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_SubscriberFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_SubscriberMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_SubscriberNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_SubscriberNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_SubscriberIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS276A1_2100DD_NM101_EntityIdentifierCode {
        IL,
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS276A1_2100DD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2200D {
    [XmlElement(Order=0)]
    public S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200D S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200D {get; set;}
    [XmlElement(Order=1)]
    public A_REF_TS276A1_2200D A_REF_TS276A1_2200D {get; set;}
    [XmlElement(Order=2)]
    public S_AMT_ClaimSubmittedCharges_TS276A1_2200D S_AMT_ClaimSubmittedCharges_TS276A1_2200D {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_ClaimServiceDate_TS276A1_2200D S_DTP_ClaimServiceDate_TS276A1_2200D {get; set;}
    [XmlElement("G_TS276A1_2210D",Order=4)]
    public List<G_TS276A1_2210D> G_TS276A1_2210D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200D {
    [XmlElement(Order=0)]
    public S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200DD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_TraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03 {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200DD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS276A1_2200D {
    [XmlElementAttribute(Order=0)]
    public S_REF_PayerClaimIdentificationNumber_TS276A1_2200D S_REF_PayerClaimIdentificationNumber_TS276A1_2200D {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_InstitutionalBillTypeIdentification_TS276A1_2200D S_REF_InstitutionalBillTypeIdentification_TS276A1_2200D {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_MedicalRecordIdentification_TS276A1_2200D S_REF_MedicalRecordIdentification_TS276A1_2200D {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_GroupNumber_TS276A1_2200D S_REF_GroupNumber_TS276A1_2200D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerClaimIdentificationNumber_TS276A1_2200D {
    [XmlElement(Order=0)]
    public S_REF_PayerClaimIdentificationNumber_TS276A1_2200DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U53 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PayerClaimIdentificationNumber_TS276A1_2200DD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1K")]
        Item1K,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InstitutionalBillTypeIdentification_TS276A1_2200D {
    [XmlElement(Order=0)]
    public S_REF_InstitutionalBillTypeIdentification_TS276A1_2200DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillTypeIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U54 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_InstitutionalBillTypeIdentification_TS276A1_2200DD_REF01_ReferenceIdentificationQualifier {
        BLT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_MedicalRecordIdentification_TS276A1_2200D {
    [XmlElement(Order=0)]
    public S_REF_MedicalRecordIdentification_TS276A1_2200DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MedicalRecordNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U55 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_MedicalRecordIdentification_TS276A1_2200DD_REF01_ReferenceIdentificationQualifier {
        EA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_GroupNumber_TS276A1_2200D {
    [XmlElement(Order=0)]
    public S_REF_GroupNumber_TS276A1_2200DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_GroupNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U5056 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_GroupNumber_TS276A1_2200DD_REF01_ReferenceIdentificationQualifier {
        LU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ClaimSubmittedCharges_TS276A1_2200D {
    [XmlElement(Order=0)]
    public S_AMT_ClaimSubmittedCharges_TS276A1_2200DD_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_ClaimSubmittedCharges_TS276A1_2200DD_AMT01_AmountQualifierCode {
        T3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimServiceDate_TS276A1_2200D {
    [XmlElement(Order=0)]
    public S_DTP_ClaimServiceDate_TS276A1_2200DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ClaimServiceDate_TS276A1_2200DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ClaimServicePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ClaimServiceDate_TS276A1_2200DD_DTP01_DateTimeQualifier {
        [XmlEnum("232")]
        Item232,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ClaimServiceDate_TS276A1_2200DD_DTP02_DateTimePeriodFormatQualifier {
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2210D {
    [XmlElement(Order=0)]
    public S_SVC_ServiceLineInformation_TS276A1_2210D S_SVC_ServiceLineInformation_TS276A1_2210D {get; set;}
    [XmlElement(Order=1)]
    public S_REF_ServiceLineItemIdentification_TS276A1_2210D S_REF_ServiceLineItemIdentification_TS276A1_2210D {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_ServiceLineDate_TS276A1_2210D S_DTP_ServiceLineDate_TS276A1_2210D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVC_ServiceLineInformation_TS276A1_2210D {
    [XmlElement(Order=0)]
    public C_SVC01_C003U56_TS276A1_2210D C_SVC01_C003U56_TS276A1_2210D {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC02_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC03 {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC04_RevenueCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC05 {get; set;}
    [XmlElement(Order=5)]
    public string D_SVC06_C003U64 {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC07_OriginalUnitsOfServiceCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SVC01_C003U56_TS276A1_2210D {
    [XmlElement(Order=0)]
    public C_SVC01_C003U56_TS276A1_2210DD_SVC01_C00301U57_ProductOrServiceIDQualifier D_SVC01_C00301U57_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC01_C00302U58_ServiceIdentificationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC01_C00303U59_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC01_C00304U60_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC01_C00305U61_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_SVC01_C00306U62_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC01_C00307U5064 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_SVC01_C003U56_TS276A1_2210DD_SVC01_C00301U57_ProductOrServiceIDQualifier {
        AD,
        CI,
        HC,
        ID,
        IV,
        N1,
        N2,
        N3,
        N4,
        ND,
        NH,
        NU,
        RB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceLineItemIdentification_TS276A1_2210D {
    [XmlElement(Order=0)]
    public S_REF_ServiceLineItemIdentification_TS276A1_2210DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U65 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceLineItemIdentification_TS276A1_2210DD_REF01_ReferenceIdentificationQualifier {
        FJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceLineDate_TS276A1_2210D {
    [XmlElement(Order=0)]
    public S_DTP_ServiceLineDate_TS276A1_2210DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ServiceLineDate_TS276A1_2210DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceLineDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceLineDate_TS276A1_2210DD_DTP01_DateTimeQualifier {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceLineDate_TS276A1_2210DD_DTP02_DateTimePeriodFormatQualifier {
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2000E {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel_TS276A1_2000E S_HL_DependentLevel_TS276A1_2000E {get; set;}
    [XmlElement(Order=1)]
    public S_DMG_DependentDemographicInformation_TS276A1_2000E S_DMG_DependentDemographicInformation_TS276A1_2000E {get; set;}
    [XmlElement(Order=2)]
    public G_TS276A1_2100E G_TS276A1_2100E {get; set;}
    [XmlElement("G_TS276A1_2200E",Order=3)]
    public List<G_TS276A1_2200E> G_TS276A1_2200E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_DependentLevel_TS276A1_2000E {
    [XmlElement(Order=0)]
    public string D_HL01_HierarchicalIDNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_HL02_HierarchicalParentIDNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_HL03_HierarchicalLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HL04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_DependentDemographicInformation_TS276A1_2000E {
    [XmlElement(Order=0)]
    public S_DMG_DependentDemographicInformation_TS276A1_2000ED_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_DependentDemographicInformation_TS276A1_2000ED_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2100E {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS276A1_2100E S_NM1_DependentName_TS276A1_2100E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName_TS276A1_2100E {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS276A1_2100ED_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_DependentName_TS276A1_2100ED_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_PatientNamePrefix {get; set;}
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
    public enum S_NM1_DependentName_TS276A1_2100ED_NM101_EntityIdentifierCode {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_DependentName_TS276A1_2100ED_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2200E {
    [XmlElement(Order=0)]
    public S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200E S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200E {get; set;}
    [XmlElement(Order=1)]
    public A_REF_TS276A1_2200E A_REF_TS276A1_2200E {get; set;}
    [XmlElement(Order=2)]
    public S_AMT_ClaimSubmittedCharges_TS276A1_2200E S_AMT_ClaimSubmittedCharges_TS276A1_2200E {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_ClaimServiceDate_TS276A1_2200E S_DTP_ClaimServiceDate_TS276A1_2200E {get; set;}
    [XmlElement("G_TS276A1_2210E",Order=4)]
    public List<G_TS276A1_2210E> G_TS276A1_2210E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200E {
    [XmlElement(Order=0)]
    public S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200ED_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_TraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03 {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_ClaimSubmitterTraceNumber_TS276A1_2200ED_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS276A1_2200E {
    [XmlElementAttribute(Order=0)]
    public S_REF_PayerClaimIdentificationNumber_TS276A1_2200E S_REF_PayerClaimIdentificationNumber_TS276A1_2200E {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_InstitutionalBillTypeIdentification_TS276A1_2200E S_REF_InstitutionalBillTypeIdentification_TS276A1_2200E {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_REF_MedicalRecordIdentification_TS276A1_2200E S_REF_MedicalRecordIdentification_TS276A1_2200E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayerClaimIdentificationNumber_TS276A1_2200E {
    [XmlElement(Order=0)]
    public S_REF_PayerClaimIdentificationNumber_TS276A1_2200ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U66 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PayerClaimIdentificationNumber_TS276A1_2200ED_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1K")]
        Item1K,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InstitutionalBillTypeIdentification_TS276A1_2200E {
    [XmlElement(Order=0)]
    public S_REF_InstitutionalBillTypeIdentification_TS276A1_2200ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_BillTypeIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U67 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_InstitutionalBillTypeIdentification_TS276A1_2200ED_REF01_ReferenceIdentificationQualifier {
        BLT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_MedicalRecordIdentification_TS276A1_2200E {
    [XmlElement(Order=0)]
    public S_REF_MedicalRecordIdentification_TS276A1_2200ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MedicalRecordNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U68 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_MedicalRecordIdentification_TS276A1_2200ED_REF01_ReferenceIdentificationQualifier {
        EA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ClaimSubmittedCharges_TS276A1_2200E {
    [XmlElement(Order=0)]
    public S_AMT_ClaimSubmittedCharges_TS276A1_2200ED_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_ClaimSubmittedCharges_TS276A1_2200ED_AMT01_AmountQualifierCode {
        T3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ClaimServiceDate_TS276A1_2200E {
    [XmlElement(Order=0)]
    public S_DTP_ClaimServiceDate_TS276A1_2200ED_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ClaimServiceDate_TS276A1_2200ED_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ClaimServicePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ClaimServiceDate_TS276A1_2200ED_DTP01_DateTimeQualifier {
        [XmlEnum("232")]
        Item232,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ClaimServiceDate_TS276A1_2200ED_DTP02_DateTimePeriodFormatQualifier {
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS276A1_2210E {
    [XmlElement(Order=0)]
    public S_SVC_ServiceLineInformation_TS276A1_2210E S_SVC_ServiceLineInformation_TS276A1_2210E {get; set;}
    [XmlElement(Order=1)]
    public S_REF_ServiceLineItemIdentification_TS276A1_2210E S_REF_ServiceLineItemIdentification_TS276A1_2210E {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_ServiceLineDate_TS276A1_2210E S_DTP_ServiceLineDate_TS276A1_2210E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVC_ServiceLineInformation_TS276A1_2210E {
    [XmlElement(Order=0)]
    public C_SVC01_C003U69_TS276A1_2210E C_SVC01_C003U69_TS276A1_2210E {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC02_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC03 {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC04_RevenueCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC05 {get; set;}
    [XmlElement(Order=5)]
    public string D_SVC06_C003U77 {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC07_OriginalUnitsOfServiceCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SVC01_C003U69_TS276A1_2210E {
    [XmlElement(Order=0)]
    public C_SVC01_C003U69_TS276A1_2210ED_SVC01_C00301U70_ProductOrServiceIDQualifier D_SVC01_C00301U70_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC01_C00302U71_ServiceIdentificationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC01_C00303U72_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC01_C00304U73_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC01_C00305U74_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_SVC01_C00306U75_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC01_C00307U5077 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_SVC01_C003U69_TS276A1_2210ED_SVC01_C00301U70_ProductOrServiceIDQualifier {
        AD,
        CI,
        HC,
        ID,
        IV,
        N1,
        N2,
        N3,
        N4,
        ND,
        NH,
        NU,
        RB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceLineItemIdentification_TS276A1_2210E {
    [XmlElement(Order=0)]
    public S_REF_ServiceLineItemIdentification_TS276A1_2210ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U78 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceLineItemIdentification_TS276A1_2210ED_REF01_ReferenceIdentificationQualifier {
        FJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceLineDate_TS276A1_2210E {
    [XmlElement(Order=0)]
    public S_DTP_ServiceLineDate_TS276A1_2210ED_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ServiceLineDate_TS276A1_2210ED_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceLineDate_TS276A1_2210ED_DTP01_DateTimeQualifier {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceLineDate_TS276A1_2210ED_DTP02_DateTimePeriodFormatQualifier {
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SE {
    [XmlElement(Order=0)]
    public string D_SE01 {get; set;}
    [XmlElement(Order=1)]
    public string D_SE02 {get; set;}
    }
}
