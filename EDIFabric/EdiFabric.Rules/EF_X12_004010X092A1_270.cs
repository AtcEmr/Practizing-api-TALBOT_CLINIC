namespace EdiFabric.Rules.X12004010X092A1270 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_270 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS270A1 S_BHT_BeginningOfHierarchicalTransaction_TS270A1 {get; set;}
    [XmlElement("G_TS270A1_2000A",Order=2)]
    public List<G_TS270A1_2000A> G_TS270A1_2000A {get; set;}
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
    public class S_BHT_BeginningOfHierarchicalTransaction_TS270A1 {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS270A1D_BHT01_HierarchicalStructureCode D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS270A1D_BHT02_TransactionSetPurposeCode D_BHT02_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BHT03_SubmitterTransactionIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_BHT04_TransactionSetCreationDate {get; set;}
    [XmlElement(Order=4)]
    public string D_BHT05_TransactionSetCreationTime {get; set;}
    [XmlElement(Order=5)]
    public string D_BHT06_TransactionTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS270A1D_BHT01_HierarchicalStructureCode {
        [XmlEnum("0022")]
        Item0022,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS270A1D_BHT02_TransactionSetPurposeCode {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("13")]
        Item13,
        [XmlEnum("36")]
        Item36,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS270A1_2000A {
    [XmlElement(Order=0)]
    public S_HL_InformationSourceLevel_TS270A1_2000A S_HL_InformationSourceLevel_TS270A1_2000A {get; set;}
    [XmlElement(Order=1)]
    public G_TS270A1_2100A G_TS270A1_2100A {get; set;}
    [XmlElement("G_TS270A1_2000B",Order=2)]
    public List<G_TS270A1_2000B> G_TS270A1_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_InformationSourceLevel_TS270A1_2000A {
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
    public class G_TS270A1_2100A {
    [XmlElement(Order=0)]
    public S_NM1_InformationSourceName_TS270A1_2100A S_NM1_InformationSourceName_TS270A1_2100A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationSourceName_TS270A1_2100A {
    [XmlElement(Order=0)]
    public S_NM1_InformationSourceName_TS270A1_2100AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_InformationSourceName_TS270A1_2100AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_InformationSourceLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_InformationSourceFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_InformationSourceMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_InformationSourceNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_InformationSourcePrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_InformationSourceName_TS270A1_2100AD_NM101_EntityIdentifierCode {
        [XmlEnum("2B")]
        Item2B,
        [XmlEnum("36")]
        Item36,
        GP,
        P5,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_InformationSourceName_TS270A1_2100AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS270A1_2000B {
    [XmlElement(Order=0)]
    public S_HL_InformationReceiverLevel_TS270A1_2000B S_HL_InformationReceiverLevel_TS270A1_2000B {get; set;}
    [XmlElement(Order=1)]
    public G_TS270A1_2100B G_TS270A1_2100B {get; set;}
    [XmlElement("G_TS270A1_2000C",Order=2)]
    public List<G_TS270A1_2000C> G_TS270A1_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_InformationReceiverLevel_TS270A1_2000B {
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
    public class G_TS270A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_InformationReceiverName_TS270A1_2100B S_NM1_InformationReceiverName_TS270A1_2100B {get; set;}
    [XmlElement("S_REF_InformationReceiverAdditionalIdentification_TS270A1_2100B",Order=1)]
    public List<S_REF_InformationReceiverAdditionalIdentification_TS270A1_2100B> S_REF_InformationReceiverAdditionalIdentification_TS270A1_2100B {get; set;}
    [XmlElement(Order=2)]
    public S_N3_InformationReceiverAddress_TS270A1_2100B S_N3_InformationReceiverAddress_TS270A1_2100B {get; set;}
    [XmlElement(Order=3)]
    public S_N4_InformationReceiverCityStateZIPCode_TS270A1_2100B S_N4_InformationReceiverCityStateZIPCode_TS270A1_2100B {get; set;}
    [XmlElement("S_PER_InformationReceiverContactInformation_TS270A1_2100B",Order=4)]
    public List<S_PER_InformationReceiverContactInformation_TS270A1_2100B> S_PER_InformationReceiverContactInformation_TS270A1_2100B {get; set;}
    [XmlElement(Order=5)]
    public S_PRV_InformationReceiverProviderInformation_TS270A1_2100B S_PRV_InformationReceiverProviderInformation_TS270A1_2100B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationReceiverName_TS270A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_InformationReceiverName_TS270A1_2100BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_InformationReceiverName_TS270A1_2100BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_InformationReceiverName_TS270A1_2100BD_NM101_EntityIdentifierCode {
        [XmlEnum("1P")]
        Item1P,
        [XmlEnum("2B")]
        Item2B,
        [XmlEnum("36")]
        Item36,
        [XmlEnum("80")]
        Item80,
        FA,
        GP,
        P5,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_InformationReceiverName_TS270A1_2100BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InformationReceiverAdditionalIdentification_TS270A1_2100B {
    [XmlElement(Order=0)]
    public S_REF_InformationReceiverAdditionalIdentification_TS270A1_2100BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InformationReceiverAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_LicenseNumberStateCode {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_InformationReceiverAdditionalIdentification_TS270A1_2100BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1C")]
        Item1C,
        [XmlEnum("1D")]
        Item1D,
        [XmlEnum("1J")]
        Item1J,
        [XmlEnum("4A")]
        Item4A,
        CT,
        EL,
        EO,
        HPI,
        JD,
        N5,
        N7,
        Q4,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_InformationReceiverAddress_TS270A1_2100B {
    [XmlElement(Order=0)]
    public string D_N301_InformationReceiverAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_InformationReceiverAdditionalAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_InformationReceiverCityStateZIPCode_TS270A1_2100B {
    [XmlElement(Order=0)]
    public string D_N401_InformationReceiverCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_InformationReceiverStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_InformationReceiverPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_InformationReceiverContactInformation_TS270A1_2100B {
    [XmlElement(Order=0)]
    public S_PER_InformationReceiverContactInformation_TS270A1_2100BD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_InformationReceiverContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_InformationReceiverCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_InformationReceiverCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_InformationReceiverCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_InformationReceiverContactInformation_TS270A1_2100BD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_InformationReceiverProviderInformation_TS270A1_2100B {
    [XmlElement(Order=0)]
    public S_PRV_InformationReceiverProviderInformation_TS270A1_2100BD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_InformationReceiverProviderInformation_TS270A1_2100BD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ReceiverProviderSpecialtyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U2 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_InformationReceiverProviderInformation_TS270A1_2100BD_PRV01_ProviderCode {
        AD,
        AT,
        BI,
        CO,
        CV,
        H,
        HH,
        LA,
        OT,
        P1,
        P2,
        PC,
        PE,
        R,
        RF,
        SB,
        SK,
        SU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_InformationReceiverProviderInformation_TS270A1_2100BD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS270A1_2000C {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel_TS270A1_2000C S_HL_SubscriberLevel_TS270A1_2000C {get; set;}
    [XmlElement("S_TRN_SubscriberTraceNumber_TS270A1_2000C",Order=1)]
    public List<S_TRN_SubscriberTraceNumber_TS270A1_2000C> S_TRN_SubscriberTraceNumber_TS270A1_2000C {get; set;}
    [XmlElement(Order=2)]
    public G_TS270A1_2100C G_TS270A1_2100C {get; set;}
    [XmlElement("G_TS270A1_2000D",Order=3)]
    public List<G_TS270A1_2000D> G_TS270A1_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberLevel_TS270A1_2000C {
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
    public class S_TRN_SubscriberTraceNumber_TS270A1_2000C {
    [XmlElement(Order=0)]
    public S_TRN_SubscriberTraceNumber_TS270A1_2000CD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_TraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_SubscriberTraceNumber_TS270A1_2000CD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS270A1_2100C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS270A1_2100C S_NM1_SubscriberName_TS270A1_2100C {get; set;}
    [XmlElement("S_REF_SubscriberAdditionalIdentification_TS270A1_2100C",Order=1)]
    public List<S_REF_SubscriberAdditionalIdentification_TS270A1_2100C> S_REF_SubscriberAdditionalIdentification_TS270A1_2100C {get; set;}
    [XmlElement(Order=2)]
    public S_N3_SubscriberAddress_TS270A1_2100C S_N3_SubscriberAddress_TS270A1_2100C {get; set;}
    [XmlElement(Order=3)]
    public S_N4_SubscriberCityStateZIPCode_TS270A1_2100C S_N4_SubscriberCityStateZIPCode_TS270A1_2100C {get; set;}
    [XmlElement(Order=4)]
    public S_PRV_ProviderInformation_TS270A1_2100C S_PRV_ProviderInformation_TS270A1_2100C {get; set;}
    [XmlElement(Order=5)]
    public S_DMG_SubscriberDemographicInformation_TS270A1_2100C S_DMG_SubscriberDemographicInformation_TS270A1_2100C {get; set;}
    [XmlElement(Order=6)]
    public S_INS_SubscriberRelationship_TS270A1_2100C S_INS_SubscriberRelationship_TS270A1_2100C {get; set;}
    [XmlElement("S_DTP_SubscriberDate_TS270A1_2100C",Order=7)]
    public List<S_DTP_SubscriberDate_TS270A1_2100C> S_DTP_SubscriberDate_TS270A1_2100C {get; set;}
    [XmlElement("G_TS270A1_2110C",Order=8)]
    public List<G_TS270A1_2110C> G_TS270A1_2110C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS270A1_2100C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS270A1_2100CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubscriberName_TS270A1_2100CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_SubscriberName_TS270A1_2100CD_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS270A1_2100CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberAdditionalIdentification_TS270A1_2100C {
    [XmlElement(Order=0)]
    public S_REF_SubscriberAdditionalIdentification_TS270A1_2100CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberAdditionalIdentification_TS270A1_2100CD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("18")]
        Item18,
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("49")]
        Item49,
        [XmlEnum("6P")]
        Item6P,
        A6,
        CT,
        EA,
        EJ,
        F6,
        GH,
        HJ,
        IG,
        N6,
        NQ,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_SubscriberAddress_TS270A1_2100C {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberCityStateZIPCode_TS270A1_2100C {
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
    public class S_PRV_ProviderInformation_TS270A1_2100C {
    [XmlElement(Order=0)]
    public S_PRV_ProviderInformation_TS270A1_2100CD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_ProviderInformation_TS270A1_2100CD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U4 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ProviderInformation_TS270A1_2100CD_PRV01_ProviderCode {
        AD,
        AT,
        BI,
        CO,
        CV,
        H,
        LA,
        OT,
        P1,
        P2,
        PC,
        PE,
        R,
        SB,
        SK,
        SU,
        HH,
        RF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ProviderInformation_TS270A1_2100CD_PRV02_ReferenceIdentificationQualifier {
        [XmlEnum("9K")]
        Item9K,
        D3,
        EI,
        HPI,
        SY,
        TJ,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_SubscriberDemographicInformation_TS270A1_2100C {
    [XmlElement(Order=0)]
    public S_DMG_SubscriberDemographicInformation_TS270A1_2100CD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_SubscriberDemographicInformation_TS270A1_2100CD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_SubscriberRelationship_TS270A1_2100C {
    [XmlElement(Order=0)]
    public S_INS_SubscriberRelationship_TS270A1_2100CD_INS01_InsuredIndicator D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_INS_SubscriberRelationship_TS270A1_2100CD_INS02_IndividualRelationshipCode D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03 {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04 {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05 {get; set;}
    [XmlElement(Order=5)]
    public string D_INS06 {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07 {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08 {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09 {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10 {get; set;}
    [XmlElement(Order=10)]
    public string D_INS11 {get; set;}
    [XmlElement(Order=11)]
    public string D_INS12 {get; set;}
    [XmlElement(Order=12)]
    public string D_INS13 {get; set;}
    [XmlElement(Order=13)]
    public string D_INS14 {get; set;}
    [XmlElement(Order=14)]
    public string D_INS15 {get; set;}
    [XmlElement(Order=15)]
    public string D_INS16 {get; set;}
    [XmlElement(Order=16)]
    public string D_INS17_BirthSequenceNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_SubscriberRelationship_TS270A1_2100CD_INS01_InsuredIndicator {
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_SubscriberRelationship_TS270A1_2100CD_INS02_IndividualRelationshipCode {
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_SubscriberDate_TS270A1_2100C {
    [XmlElement(Order=0)]
    public S_DTP_SubscriberDate_TS270A1_2100CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_SubscriberDate_TS270A1_2100CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SubscriberDate_TS270A1_2100CD_DTP01_DateTimeQualifier {
        [XmlEnum("102")]
        Item102,
        [XmlEnum("307")]
        Item307,
        [XmlEnum("435")]
        Item435,
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SubscriberDate_TS270A1_2100CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS270A1_2110C {
    [XmlElement(Order=0)]
    public S_EQ_SubscriberEligibilityOrBenefitInquiryInformation_TS270A1_2110C S_EQ_SubscriberEligibilityOrBenefitInquiryInformation_TS270A1_2110C {get; set;}
    [XmlElement(Order=1)]
    public S_AMT_SubscriberSpendDownAmount_TS270A1_2110C S_AMT_SubscriberSpendDownAmount_TS270A1_2110C {get; set;}
    [XmlElement("S_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110C",Order=2)]
    public List<S_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110C> S_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110C {get; set;}
    [XmlElement(Order=3)]
    public S_REF_SubscriberAdditionalInformation_TS270A1_2110C S_REF_SubscriberAdditionalInformation_TS270A1_2110C {get; set;}
    [XmlElement(Order=4)]
    public S_DTP_SubscriberEligibilityBenefitDate_TS270A1_2110C S_DTP_SubscriberEligibilityBenefitDate_TS270A1_2110C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_EQ_SubscriberEligibilityOrBenefitInquiryInformation_TS270A1_2110C {
    [XmlElement(Order=0)]
    public S_EQ_SubscriberEligibilityOrBenefitInquiryInformation_TS270A1_2110CD_EQ01_ServiceTypeCode D_EQ01_ServiceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public C_EQ02_C003U5_TS270A1_2110C C_EQ02_C003U5_TS270A1_2110C {get; set;}
    [XmlElement(Order=2)]
    public string D_EQ03_BenefitCoverageLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_EQ04_InsuranceTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_EQ_SubscriberEligibilityOrBenefitInquiryInformation_TS270A1_2110CD_EQ01_ServiceTypeCode {
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
        [XmlEnum("9")]
        Item9,
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
        [XmlEnum("30")]
        Item30,
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
        [XmlEnum("50")]
        Item50,
        [XmlEnum("51")]
        Item51,
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
        [XmlEnum("64")]
        Item64,
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
        [XmlEnum("70")]
        Item70,
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
        [XmlEnum("76")]
        Item76,
        [XmlEnum("77")]
        Item77,
        [XmlEnum("78")]
        Item78,
        [XmlEnum("79")]
        Item79,
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
        [XmlEnum("86")]
        Item86,
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
        A0,
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
        AB,
        AC,
        AD,
        AE,
        AF,
        AG,
        AH,
        AI,
        AJ,
        AK,
        AL,
        AM,
        AN,
        AO,
        AQ,
        AR,
        BA,
        BB,
        BC,
        BD,
        BE,
        BF,
        BG,
        BH,
        BI,
        BJ,
        BK,
        BL,
        BM,
        BN,
        BP,
        BQ,
        BR,
        BS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_EQ02_C003U5_TS270A1_2110C {
    [XmlElement(Order=0)]
    public C_EQ02_C003U5_TS270A1_2110CD_EQ02_C00301U6_ProductOrServiceIDQualifier D_EQ02_C00301U6_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_EQ02_C00302U7_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_EQ02_C00303U8_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_EQ02_C00304U9_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_EQ02_C00305U10_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_EQ02_C00306U11_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_EQ02_C00307U5012 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_EQ02_C003U5_TS270A1_2110CD_EQ02_C00301U6_ProductOrServiceIDQualifier {
        AD,
        CJ,
        HC,
        ID,
        IV,
        N4,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_SubscriberSpendDownAmount_TS270A1_2110C {
    [XmlElement(Order=0)]
    public S_AMT_SubscriberSpendDownAmount_TS270A1_2110CD_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_SpendDownAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_SubscriberSpendDownAmount_TS270A1_2110CD_AMT01_AmountQualifierCode {
        R,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110C {
    [XmlElement(Order=0)]
    public S_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110CD_III01_CodeListQualifierCode D_III01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_III02_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_III03 {get; set;}
    [XmlElement(Order=3)]
    public string D_III04 {get; set;}
    [XmlElement(Order=4)]
    public string D_III05 {get; set;}
    [XmlElement(Order=5)]
    public string D_III06_C001U13 {get; set;}
    [XmlElement(Order=6)]
    public string D_III07 {get; set;}
    [XmlElement(Order=7)]
    public string D_III08 {get; set;}
    [XmlElement(Order=8)]
    public string D_III09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_III_SubscriberEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110CD_III01_CodeListQualifierCode {
        BF,
        BK,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberAdditionalInformation_TS270A1_2110C {
    [XmlElement(Order=0)]
    public S_REF_SubscriberAdditionalInformation_TS270A1_2110CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorAuthorizationOrReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U14 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberAdditionalInformation_TS270A1_2110CD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9F")]
        Item9F,
        G1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_SubscriberEligibilityBenefitDate_TS270A1_2110C {
    [XmlElement(Order=0)]
    public S_DTP_SubscriberEligibilityBenefitDate_TS270A1_2110CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_SubscriberEligibilityBenefitDate_TS270A1_2110CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SubscriberEligibilityBenefitDate_TS270A1_2110CD_DTP01_DateTimeQualifier {
        [XmlEnum("307")]
        Item307,
        [XmlEnum("435")]
        Item435,
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SubscriberEligibilityBenefitDate_TS270A1_2110CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS270A1_2000D {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel_TS270A1_2000D S_HL_DependentLevel_TS270A1_2000D {get; set;}
    [XmlElement("S_TRN_DependentTraceNumber_TS270A1_2000D",Order=1)]
    public List<S_TRN_DependentTraceNumber_TS270A1_2000D> S_TRN_DependentTraceNumber_TS270A1_2000D {get; set;}
    [XmlElement(Order=2)]
    public G_TS270A1_2100D G_TS270A1_2100D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_DependentLevel_TS270A1_2000D {
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
    public class S_TRN_DependentTraceNumber_TS270A1_2000D {
    [XmlElement(Order=0)]
    public S_TRN_DependentTraceNumber_TS270A1_2000DD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_TraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_DependentTraceNumber_TS270A1_2000DD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS270A1_2100D {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS270A1_2100D S_NM1_DependentName_TS270A1_2100D {get; set;}
    [XmlElement("S_REF_DependentAdditionalIdentification_TS270A1_2100D",Order=1)]
    public List<S_REF_DependentAdditionalIdentification_TS270A1_2100D> S_REF_DependentAdditionalIdentification_TS270A1_2100D {get; set;}
    [XmlElement(Order=2)]
    public S_N3_DependentAddress_TS270A1_2100D S_N3_DependentAddress_TS270A1_2100D {get; set;}
    [XmlElement(Order=3)]
    public S_N4_DependentCityStateZIPCode_TS270A1_2100D S_N4_DependentCityStateZIPCode_TS270A1_2100D {get; set;}
    [XmlElement(Order=4)]
    public S_PRV_ProviderInformation_TS270A1_2100D S_PRV_ProviderInformation_TS270A1_2100D {get; set;}
    [XmlElement(Order=5)]
    public S_DMG_DependentDemographicInformation_TS270A1_2100D S_DMG_DependentDemographicInformation_TS270A1_2100D {get; set;}
    [XmlElement(Order=6)]
    public S_INS_DependentRelationship_TS270A1_2100D S_INS_DependentRelationship_TS270A1_2100D {get; set;}
    [XmlElement("S_DTP_DependentDate_TS270A1_2100D",Order=7)]
    public List<S_DTP_DependentDate_TS270A1_2100D> S_DTP_DependentDate_TS270A1_2100D {get; set;}
    [XmlElement("G_TS270A1_2110D",Order=8)]
    public List<G_TS270A1_2110D> G_TS270A1_2110D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName_TS270A1_2100D {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS270A1_2100DD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_DependentName_TS270A1_2100DD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_DependentLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_DependentFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_DependentMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_DependentNameSuffix {get; set;}
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
    public enum S_NM1_DependentName_TS270A1_2100DD_NM101_EntityIdentifierCode {
        [XmlEnum("03")]
        Item03,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_DependentName_TS270A1_2100DD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentAdditionalIdentification_TS270A1_2100D {
    [XmlElement(Order=0)]
    public S_REF_DependentAdditionalIdentification_TS270A1_2100DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U15 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_DependentAdditionalIdentification_TS270A1_2100DD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("18")]
        Item18,
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("6P")]
        Item6P,
        A6,
        CT,
        EA,
        EJ,
        F6,
        GH,
        HJ,
        IF,
        IG,
        N6,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_DependentAddress_TS270A1_2100D {
    [XmlElement(Order=0)]
    public string D_N301_DependentAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_DependentAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_DependentCityStateZIPCode_TS270A1_2100D {
    [XmlElement(Order=0)]
    public string D_N401_DependentCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_DependentStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_DependentPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ProviderInformation_TS270A1_2100D {
    [XmlElement(Order=0)]
    public S_PRV_ProviderInformation_TS270A1_2100DD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_ProviderInformation_TS270A1_2100DD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U16 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ProviderInformation_TS270A1_2100DD_PRV01_ProviderCode {
        AD,
        AT,
        BI,
        CO,
        CV,
        H,
        LA,
        OT,
        P1,
        P2,
        PC,
        PE,
        R,
        SB,
        SK,
        SU,
        HH,
        RF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ProviderInformation_TS270A1_2100DD_PRV02_ReferenceIdentificationQualifier {
        [XmlEnum("9K")]
        Item9K,
        D3,
        EI,
        HPI,
        SY,
        TJ,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_DependentDemographicInformation_TS270A1_2100D {
    [XmlElement(Order=0)]
    public S_DMG_DependentDemographicInformation_TS270A1_2100DD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_DependentBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_DependentGenderCode {get; set;}
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
    public enum S_DMG_DependentDemographicInformation_TS270A1_2100DD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_DependentRelationship_TS270A1_2100D {
    [XmlElement(Order=0)]
    public S_INS_DependentRelationship_TS270A1_2100DD_INS01_InsuredIndicator D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_INS_DependentRelationship_TS270A1_2100DD_INS02_IndividualRelationshipCode D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03 {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04 {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05 {get; set;}
    [XmlElement(Order=5)]
    public string D_INS06 {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07 {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08 {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09 {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10 {get; set;}
    [XmlElement(Order=10)]
    public string D_INS11 {get; set;}
    [XmlElement(Order=11)]
    public string D_INS12 {get; set;}
    [XmlElement(Order=12)]
    public string D_INS13 {get; set;}
    [XmlElement(Order=13)]
    public string D_INS14 {get; set;}
    [XmlElement(Order=14)]
    public string D_INS15 {get; set;}
    [XmlElement(Order=15)]
    public string D_INS16 {get; set;}
    [XmlElement(Order=16)]
    public string D_INS17_BirthSequenceNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_DependentRelationship_TS270A1_2100DD_INS01_InsuredIndicator {
        N,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_DependentRelationship_TS270A1_2100DD_INS02_IndividualRelationshipCode {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("34")]
        Item34,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DependentDate_TS270A1_2100D {
    [XmlElement(Order=0)]
    public S_DTP_DependentDate_TS270A1_2100DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DependentDate_TS270A1_2100DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DependentDate_TS270A1_2100DD_DTP01_DateTimeQualifier {
        [XmlEnum("102")]
        Item102,
        [XmlEnum("307")]
        Item307,
        [XmlEnum("435")]
        Item435,
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DependentDate_TS270A1_2100DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS270A1_2110D {
    [XmlElement(Order=0)]
    public S_EQ_DependentEligibilityOrBenefitInquiryInformation_TS270A1_2110D S_EQ_DependentEligibilityOrBenefitInquiryInformation_TS270A1_2110D {get; set;}
    [XmlElement("S_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110D",Order=1)]
    public List<S_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110D> S_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110D {get; set;}
    [XmlElement(Order=2)]
    public S_REF_DependentAdditionalInformation_TS270A1_2110D S_REF_DependentAdditionalInformation_TS270A1_2110D {get; set;}
    [XmlElement(Order=3)]
    public S_DTP_DependentEligibilityBenefitDate_TS270A1_2110D S_DTP_DependentEligibilityBenefitDate_TS270A1_2110D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_EQ_DependentEligibilityOrBenefitInquiryInformation_TS270A1_2110D {
    [XmlElement(Order=0)]
    public S_EQ_DependentEligibilityOrBenefitInquiryInformation_TS270A1_2110DD_EQ01_ServiceTypeCode D_EQ01_ServiceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public C_EQ02_C003U17_TS270A1_2110D C_EQ02_C003U17_TS270A1_2110D {get; set;}
    [XmlElement(Order=2)]
    public string D_EQ03_BenefitCoverageLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_EQ04_InsuranceTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_EQ_DependentEligibilityOrBenefitInquiryInformation_TS270A1_2110DD_EQ01_ServiceTypeCode {
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
        [XmlEnum("9")]
        Item9,
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
        [XmlEnum("30")]
        Item30,
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
        [XmlEnum("50")]
        Item50,
        [XmlEnum("51")]
        Item51,
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
        [XmlEnum("64")]
        Item64,
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
        [XmlEnum("70")]
        Item70,
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
        [XmlEnum("76")]
        Item76,
        [XmlEnum("77")]
        Item77,
        [XmlEnum("78")]
        Item78,
        [XmlEnum("79")]
        Item79,
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
        [XmlEnum("86")]
        Item86,
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
        A0,
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
        AB,
        AC,
        AD,
        AE,
        AF,
        AG,
        AH,
        AI,
        AJ,
        AK,
        AL,
        AM,
        AN,
        AO,
        AQ,
        AR,
        BA,
        BB,
        BC,
        BD,
        BE,
        BF,
        BG,
        BH,
        BI,
        BJ,
        BK,
        BL,
        BM,
        BN,
        BP,
        BQ,
        BR,
        BS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_EQ02_C003U17_TS270A1_2110D {
    [XmlElement(Order=0)]
    public C_EQ02_C003U17_TS270A1_2110DD_EQ02_C00301U18_ProductOrServiceIDQualifier D_EQ02_C00301U18_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_EQ02_C00302U19_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_EQ02_C00303U20_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_EQ02_C00304U21_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_EQ02_C00305U22_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_EQ02_C00306U23_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_EQ02_C00307U5024 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_EQ02_C003U17_TS270A1_2110DD_EQ02_C00301U18_ProductOrServiceIDQualifier {
        AD,
        CJ,
        HC,
        ID,
        IV,
        N4,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110D {
    [XmlElement(Order=0)]
    public S_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110DD_III01_CodeListQualifierCode D_III01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_III02_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_III03 {get; set;}
    [XmlElement(Order=3)]
    public string D_III04 {get; set;}
    [XmlElement(Order=4)]
    public string D_III05 {get; set;}
    [XmlElement(Order=5)]
    public string D_III06_C001U25 {get; set;}
    [XmlElement(Order=6)]
    public string D_III07 {get; set;}
    [XmlElement(Order=7)]
    public string D_III08 {get; set;}
    [XmlElement(Order=8)]
    public string D_III09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_III_DependentEligibilityOrBenefitAdditionalInquiryInformation_TS270A1_2110DD_III01_CodeListQualifierCode {
        BF,
        BK,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentAdditionalInformation_TS270A1_2110D {
    [XmlElement(Order=0)]
    public S_REF_DependentAdditionalInformation_TS270A1_2110DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorAuthorizationOrReferralNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U26 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_DependentAdditionalInformation_TS270A1_2110DD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("9F")]
        Item9F,
        G1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DependentEligibilityBenefitDate_TS270A1_2110D {
    [XmlElement(Order=0)]
    public S_DTP_DependentEligibilityBenefitDate_TS270A1_2110DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DependentEligibilityBenefitDate_TS270A1_2110DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DependentEligibilityBenefitDate_TS270A1_2110DD_DTP01_DateTimeQualifier {
        [XmlEnum("307")]
        Item307,
        [XmlEnum("435")]
        Item435,
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DependentEligibilityBenefitDate_TS270A1_2110DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
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
