namespace EdiFabric.Rules.X12005010X217278 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_278 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public G_A1_BHT G_A1_BHT {get; set;}
    [XmlElement(Order=2)]
    public G_A3_BHT G_A3_BHT {get; set;}
    [XmlElement(Order=3)]
    public S_SE S_SE {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ST {
    [XmlElement(Order=0)]
    public X12_ID_A1_143 D_ST01_TransactionSetIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_ST02_TransactionSetControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_ST03_ImplementationGuideVersionName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_143 {
        [XmlEnum("278")]
        Item278,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_A1_BHT {
    [XmlElement(Order=0)]
    public S_BHT_BeginningofHierarchicalTransaction_TS278A1 S_BHT_BeginningofHierarchicalTransaction_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A1_2000A G_TS278A1_2000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BHT_BeginningofHierarchicalTransaction_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1005 D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_353 D_BHT02_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BHT03_SubmitterTransactionIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_BHT04_TransactionSetCreationDate {get; set;}
    [XmlElement(Order=4)]
    public string D_BHT05_TransactionSetCreationTime {get; set;}
    [XmlElement(Order=5)]
    public string D_BHT06_TransactionTypeCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1005 {
        [XmlEnum("0007")]
        Item0007,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_353 {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("13")]
        Item13,
        [XmlEnum("36")]
        Item36,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000A {
    [XmlElement(Order=0)]
    public S_HL_UtilizationManagementOrganization_UMO_Level_TS278A1 S_HL_UtilizationManagementOrganization_UMO_Level_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A1_2010A G_TS278A1_2010A {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A1_2000B G_TS278A1_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_UtilizationManagementOrganization_UMO_Level_TS278A1 {
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
    public class G_TS278A1_2010A {
    [XmlElement(Order=0)]
    public S_NM1_UtilizationManagementOrganization_UMO_Name_TS278A1 S_NM1_UtilizationManagementOrganization_UMO_Name_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_UtilizationManagementOrganization_UMO_Name_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_98 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_UtilizationManagementOrganization_UMO_LastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_UtilizationManagementOrganization_UMO_FirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_UtilizationManagementOrganization_UMO_MiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_UtilizationManagementOrganization_UMO_NameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_UtilizationManagementOrganization_UMO_Identifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_98 {
        [XmlEnum("2B")]
        Item2B,
        [XmlEnum("36")]
        Item36,
        PR,
        X3,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1065 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000B {
    [XmlElement(Order=0)]
    public S_HL_RequesterLevel_TS278A1 S_HL_RequesterLevel_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A1_2010B G_TS278A1_2010B {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A1_2000C G_TS278A1_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_RequesterLevel_TS278A1 {
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
    public class G_TS278A1_2010B {
    [XmlElement(Order=0)]
    public S_NM1_RequesterName_TS278A1 S_NM1_RequesterName_TS278A1 {get; set;}
    [XmlElement("S_REF_RequesterSupplementalIdentification_TS278A1",Order=1)]
    public List<S_REF_RequesterSupplementalIdentification_TS278A1> S_REF_RequesterSupplementalIdentification_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_RequesterAddress_TS278A1 S_N3_RequesterAddress_TS278A1 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_RequesterCity_State_ZIPCode_TS278A1 S_N4_RequesterCity_State_ZIPCode_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public S_PER_RequesterContactInformation_TS278A1 S_PER_RequesterContactInformation_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public S_PRV_RequesterProviderInformation_TS278A1 S_PRV_RequesterProviderInformation_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RequesterName_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_98_3 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RequesterLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RequesterFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RequesterMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RequesterNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RequesterIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_98_3 {
        [XmlEnum("1P")]
        Item1P,
        [XmlEnum("2B")]
        Item2B,
        [XmlEnum("36")]
        Item36,
        FA,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RequesterSupplementalIdentification_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RequesterSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_TS278A1 C_C040_ReferenceIdentifier_TS278A1 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_128 {
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1J")]
        Item1J,
        EI,
        G5,
        N5,
        N7,
        SY,
        ZH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_TS278A1 {
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
    public class S_N3_RequesterAddress_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N301_RequesterAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_RequesterAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_RequesterCity_State_ZIPCode_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N401_RequesterCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_RequesterStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_RequesterPostalZoneorZIPCode {get; set;}
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
    public class S_PER_RequesterContactInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_RequesterContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_RequesterContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_RequesterContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_RequesterContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_366 {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_RequesterProviderInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1221 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_TS278A1 C_C035_ProviderSpecialtyInformation_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1221 {
        AD,
        AS,
        AT,
        CO,
        CV,
        OP,
        OR,
        OT,
        PC,
        PE,
        RF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000C {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel_TS278A1 S_HL_SubscriberLevel_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A1_2010C G_TS278A1_2010C {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A1_2000D G_TS278A1_2000D {get; set;}
    [XmlElement(Order=3)]
    public G_TS278A1_2000E G_TS278A1_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberLevel_TS278A1 {
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
    public class G_TS278A1_2010C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS278A1 S_NM1_SubscriberName_TS278A1 {get; set;}
    [XmlElement("S_REF_SubscriberSupplementalIdentification_TS278A1",Order=1)]
    public List<S_REF_SubscriberSupplementalIdentification_TS278A1> S_REF_SubscriberSupplementalIdentification_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_SubscriberAddress_TS278A1 S_N3_SubscriberAddress_TS278A1 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_SubscriberCity_State_ZIPCode_TS278A1 S_N4_SubscriberCity_State_ZIPCode_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public S_DMG_SubscriberDemographicInformation_TS278A1 S_DMG_SubscriberDemographicInformation_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public S_INS_SubscriberRelationship_TS278A1 S_INS_SubscriberRelationship_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_98_4 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1065_2 D_NM102_EntityTypeQualifier {get; set;}
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
    public enum X12_ID_A1_98_4 {
        IL,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1065_2 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberSupplementalIdentification_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2_TS278A1 C_C040_ReferenceIdentifier_2_TS278A1 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_128_4 {
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("3L")]
        Item3L,
        [XmlEnum("6P")]
        Item6P,
        DP,
        EJ,
        F6,
        HJ,
        IG,
        N6,
        NQ,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_2_TS278A1 {
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
    public class S_N3_SubscriberAddress_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberCity_State_ZIPCode_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N401_SubscriberCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_SubscriberStateCode {get; set;}
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
    public class S_DMG_SubscriberDemographicInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1250 D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_SubscriberBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_SubscriberGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04_MaritalStatusCode {get; set;}
    [XmlElement("C_C056_CompositeRaceorEthnicityInformation_TS278A1",Order=4)]
    public List<C_C056_CompositeRaceorEthnicityInformation_TS278A1> C_C056_CompositeRaceorEthnicityInformation_TS278A1 {get; set;}
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
    public enum X12_ID_A1_1250 {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C056_CompositeRaceorEthnicityInformation_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C05601_RaceorEthnicityCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05602_CodeListQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05603_IndustryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_SubscriberRelationship_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1073_2 D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1069 D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05_BenefitStatusCode {get; set;}
    [XmlElement(Order=5)]
    public C_C052_MedicareStatusCode_TS278A1 C_C052_MedicareStatusCode_TS278A1 {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07_ConsolidatedOmnibusBudgetReconciliationAct_COBRA_QualifyingEventCode {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09_StudentStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=10)]
    public string D_INS11_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=11)]
    public string D_INS12_DateTimePeriod {get; set;}
    [XmlElement(Order=12)]
    public string D_INS13_ConfidentialityCode {get; set;}
    [XmlElement(Order=13)]
    public string D_INS14_CityName {get; set;}
    [XmlElement(Order=14)]
    public string D_INS15_StateorProvinceCode {get; set;}
    [XmlElement(Order=15)]
    public string D_INS16_CountryCode {get; set;}
    [XmlElement(Order=16)]
    public string D_INS17_Number {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1073_2 {
        Y,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1069 {
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C052_MedicareStatusCode_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C05201_MedicarePlanCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05202_EligibilityReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05203_EligibilityReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C05204_EligibilityReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000D {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel_TS278A1 S_HL_DependentLevel_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A1_2010D G_TS278A1_2010D {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A1_2000E G_TS278A1_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_DependentLevel_TS278A1 {
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
    public class G_TS278A1_2010D {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS278A1 S_NM1_DependentName_TS278A1 {get; set;}
    [XmlElement("S_REF_DependentSupplementalIdentification_TS278A1",Order=1)]
    public List<S_REF_DependentSupplementalIdentification_TS278A1> S_REF_DependentSupplementalIdentification_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_DependentAddress_TS278A1 S_N3_DependentAddress_TS278A1 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_DependentCity_State_ZIPCode_TS278A1 S_N4_DependentCity_State_ZIPCode_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public S_DMG_DependentDemographicInformation_TS278A1 S_DMG_DependentDemographicInformation_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public S_INS_DependentRelationship_TS278A1 S_INS_DependentRelationship_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_DependentLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_DependentFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_DependentMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_DependentNameSuffix {get; set;}
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
    public enum X12_ID_A1_98_5 {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentSupplementalIdentification_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3_TS278A1 C_C040_ReferenceIdentifier_3_TS278A1 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_128_5 {
        EJ,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_3_TS278A1 {
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
    public class S_N3_DependentAddress_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N301_DependentAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_DependentAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_DependentCity_State_ZIPCode_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N401_DependentCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_DependentStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_DependentPostalZoneorZIPCode {get; set;}
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
    public class S_DMG_DependentDemographicInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1250 D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_DependentBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_DependentGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04_MaritalStatusCode {get; set;}
    [XmlElement("C_C056_CompositeRaceorEthnicityInformation_2_TS278A1",Order=4)]
    public List<C_C056_CompositeRaceorEthnicityInformation_2_TS278A1> C_C056_CompositeRaceorEthnicityInformation_2_TS278A1 {get; set;}
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
    public class C_C056_CompositeRaceorEthnicityInformation_2_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C05601_RaceorEthnicityCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05602_CodeListQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05603_IndustryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_DependentRelationship_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1073_3 D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1069_2 D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05_BenefitStatusCode {get; set;}
    [XmlElement(Order=5)]
    public C_C052_MedicareStatusCode_2_TS278A1 C_C052_MedicareStatusCode_2_TS278A1 {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07_ConsolidatedOmnibusBudgetReconciliationAct_COBRA_QualifyingEventCode {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09_StudentStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=10)]
    public string D_INS11_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=11)]
    public string D_INS12_DateTimePeriod {get; set;}
    [XmlElement(Order=12)]
    public string D_INS13_ConfidentialityCode {get; set;}
    [XmlElement(Order=13)]
    public string D_INS14_CityName {get; set;}
    [XmlElement(Order=14)]
    public string D_INS15_StateorProvinceCode {get; set;}
    [XmlElement(Order=15)]
    public string D_INS16_CountryCode {get; set;}
    [XmlElement(Order=16)]
    public string D_INS17_BirthSequenceNumber {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1073_3 {
        N,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1069_2 {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("19")]
        Item19,
        G8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C052_MedicareStatusCode_2_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C05201_MedicarePlanCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05202_EligibilityReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05203_EligibilityReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C05204_EligibilityReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000E {
    [XmlElement(Order=0)]
    public S_HL_PatientEventLevel_TS278A1 S_HL_PatientEventLevel_TS278A1 {get; set;}
    [XmlElement("S_TRN_PatientEventTrackingNumber_TS278A1",Order=1)]
    public List<S_TRN_PatientEventTrackingNumber_TS278A1> S_TRN_PatientEventTrackingNumber_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_UM_HealthCareServicesReviewInformation_TS278A1 S_UM_HealthCareServicesReviewInformation_TS278A1 {get; set;}
    [XmlElement(Order=3)]
    public A_REF_TS278A1 A_REF_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public A_DTP_TS278A1 A_DTP_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public S_HI_PatientDiagnosis_TS278A1 S_HI_PatientDiagnosis_TS278A1 {get; set;}
    [XmlElement(Order=6)]
    public S_HSD_HealthCareServicesDelivery_TS278A1 S_HSD_HealthCareServicesDelivery_TS278A1 {get; set;}
    [XmlElement(Order=7)]
    public A_CRC_TS278A1 A_CRC_TS278A1 {get; set;}
    [XmlElement(Order=8)]
    public S_CL1_InstitutionalClaimCode_TS278A1 S_CL1_InstitutionalClaimCode_TS278A1 {get; set;}
    [XmlElement(Order=9)]
    public S_CR1_AmbulanceTransportInformation_TS278A1 S_CR1_AmbulanceTransportInformation_TS278A1 {get; set;}
    [XmlElement(Order=10)]
    public S_CR2_SpinalManipulationServiceInformation_TS278A1 S_CR2_SpinalManipulationServiceInformation_TS278A1 {get; set;}
    [XmlElement(Order=11)]
    public S_CR5_HomeOxygenTherapyInformation_TS278A1 S_CR5_HomeOxygenTherapyInformation_TS278A1 {get; set;}
    [XmlElement(Order=12)]
    public S_CR6_HomeHealthCareInformation_TS278A1 S_CR6_HomeHealthCareInformation_TS278A1 {get; set;}
    [XmlElement("S_PWK_AdditionalPatientInformation_TS278A1",Order=13)]
    public List<S_PWK_AdditionalPatientInformation_TS278A1> S_PWK_AdditionalPatientInformation_TS278A1 {get; set;}
    [XmlElement(Order=14)]
    public S_MSG_MessageText_TS278A1 S_MSG_MessageText_TS278A1 {get; set;}
    [XmlElement(Order=15)]
    public A_NM1_TS278A1 A_NM1_TS278A1 {get; set;}
    [XmlElement("G_TS278A1_2000F",Order=16)]
    public List<G_TS278A1_2000F> G_TS278A1_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_PatientEventLevel_TS278A1 {
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
    public class S_TRN_PatientEventTrackingNumber_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_PatientEventTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_481 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_UM_HealthCareServicesReviewInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1525 D_UM01_RequestCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1322 D_UM02_CertificationTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_UM03_ServiceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public C_C023_HealthCareServiceLocationInformation_TS278A1 C_C023_HealthCareServiceLocationInformation_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public C_C024_RelatedCausesInformation_TS278A1 C_C024_RelatedCausesInformation_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public string D_UM06_LevelofServiceCode {get; set;}
    [XmlElement(Order=6)]
    public string D_UM07_CurrentHealthConditionCode {get; set;}
    [XmlElement(Order=7)]
    public string D_UM08_PrognosisCode {get; set;}
    [XmlElement(Order=8)]
    public string D_UM09_ReleaseofInformationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_UM10_DelayReasonCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1525 {
        AR,
        HS,
        IN,
        SC,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1322 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("4")]
        Item4,
        I,
        N,
        R,
        S,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C023_HealthCareServiceLocationInformation_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02301_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02302_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_C02303_ClaimFrequencyTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C024_RelatedCausesInformation_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02401_RelatedCausesCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02402_RelatedCausesCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02403_RelatedCausesCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C02404_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public string D_C02405_CountryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS278A1 {
    [XmlElementAttribute(Order=0)]
    public S_REF_PreviousReviewAuthorizationNumber_TS278A1 S_REF_PreviousReviewAuthorizationNumber_TS278A1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PreviousReviewAdministrativeReferenceNumber_TS278A1 S_REF_PreviousReviewAdministrativeReferenceNumber_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PreviousReviewAuthorizationNumber_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PreviousReviewAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4_TS278A1 C_C040_ReferenceIdentifier_4_TS278A1 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_128_6 {
        BB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_4_TS278A1 {
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
    public class S_REF_PreviousReviewAdministrativeReferenceNumber_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PreviousAdministrativeReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5_TS278A1 C_C040_ReferenceIdentifier_5_TS278A1 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_128_7 {
        NT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_5_TS278A1 {
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
    public class A_DTP_TS278A1 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_AccidentDate_TS278A1 S_DTP_AccidentDate_TS278A1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A1 S_DTP_LastMenstrualPeriodDate_TS278A1 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_EstimatedDateofBirth_TS278A1 S_DTP_EstimatedDateofBirth_TS278A1 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_OnsetofCurrentSymptomsorIllnessDate_TS278A1 S_DTP_OnsetofCurrentSymptomsorIllnessDate_TS278A1 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_DTP_EventDate_TS278A1 S_DTP_EventDate_TS278A1 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_DTP_AdmissionDate_TS278A1 S_DTP_AdmissionDate_TS278A1 {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_DTP_DischargeDate_TS278A1 S_DTP_DischargeDate_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AccidentDate_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374 {
        [XmlEnum("439")]
        Item439,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LastMenstrualPeriodDate_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_LastMenstrualPeriodDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374_2 {
        [XmlEnum("484")]
        Item484,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_EstimatedDateofBirth_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EstimatedBirthDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374_3 {
        ABC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_OnsetofCurrentSymptomsorIllnessDate_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OnsetDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374_4 {
        [XmlEnum("431")]
        Item431,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_EventDate_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374_5 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedorActualEventDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374_5 {
        AAH,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1250_3 {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AdmissionDate_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374_6 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedorActualAdmissionDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374_6 {
        [XmlEnum("435")]
        Item435,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DischargeDate_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374_7 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedorActualDischargeDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374_7 {
        [XmlEnum("096")]
        Item096,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_PatientDiagnosis_TS278A1 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_TS278A1 C_C022_HealthCareCodeInformation_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_2_TS278A1 C_C022_HealthCareCodeInformation_2_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_3_TS278A1 C_C022_HealthCareCodeInformation_3_TS278A1 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_4_TS278A1 C_C022_HealthCareCodeInformation_4_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_5_TS278A1 C_C022_HealthCareCodeInformation_5_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_6_TS278A1 C_C022_HealthCareCodeInformation_6_TS278A1 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_7_TS278A1 C_C022_HealthCareCodeInformation_7_TS278A1 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_8_TS278A1 C_C022_HealthCareCodeInformation_8_TS278A1 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_9_TS278A1 C_C022_HealthCareCodeInformation_9_TS278A1 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_10_TS278A1 C_C022_HealthCareCodeInformation_10_TS278A1 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_11_TS278A1 C_C022_HealthCareCodeInformation_11_TS278A1 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_12_TS278A1 C_C022_HealthCareCodeInformation_12_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1270_2 D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
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
    public enum X12_ID_A1_1270_2 {
        ABF,
        ABJ,
        ABK,
        APR,
        BF,
        BJ,
        BK,
        DR,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_2_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1270_3 D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
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
    public enum X12_ID_A1_1270_3 {
        ABF,
        ABJ,
        APR,
        BF,
        BJ,
        DR,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_3_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_4_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_5_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_6_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_7_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_8_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_9_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_10_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_11_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_12_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HSD_HealthCareServicesDelivery_TS278A1 {
    [XmlElement(Order=0)]
    public string D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_ServiceUnitCount {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HSD04_SampleSelectionModulus {get; set;}
    [XmlElement(Order=4)]
    public string D_HSD05_TimePeriodQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_HSD06_PeriodCount {get; set;}
    [XmlElement(Order=6)]
    public string D_HSD07_DeliveryFrequencyCode {get; set;}
    [XmlElement(Order=7)]
    public string D_HSD08_DeliveryPatternTimeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_CRC_TS278A1 {
    [XmlElementAttribute(Order=0)]
    public S_CRC_AmbulanceCertificationInformation_TS278A1 S_CRC_AmbulanceCertificationInformation_TS278A1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_CRC_ChiropracticCertificationInformation_TS278A1 S_CRC_ChiropracticCertificationInformation_TS278A1 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_CRC_DurableMedicalEquipmentInformation_TS278A1 S_CRC_DurableMedicalEquipmentInformation_TS278A1 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_CRC_OxygenTherapyCertificationInformation_TS278A1 S_CRC_OxygenTherapyCertificationInformation_TS278A1 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_CRC_FunctionalLimitationsInformation_TS278A1 S_CRC_FunctionalLimitationsInformation_TS278A1 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_CRC_ActivitiesPermittedInformation_TS278A1 S_CRC_ActivitiesPermittedInformation_TS278A1 {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_CRC_MentalStatusInformation_TS278A1 S_CRC_MentalStatusInformation_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_AmbulanceCertificationInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1136 D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1073_4 D_CRC02_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1136 {
        [XmlEnum("07")]
        Item07,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1073_4 {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_ChiropracticCertificationInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1136_2 D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1073_4 D_CRC02_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1136_2 {
        [XmlEnum("08")]
        Item08,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_DurableMedicalEquipmentInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1136_3 D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1073_4 D_CRC02_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1136_3 {
        [XmlEnum("09")]
        Item09,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_OxygenTherapyCertificationInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1136_4 D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1073_4 D_CRC02_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1136_4 {
        [XmlEnum("11")]
        Item11,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_FunctionalLimitationsInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1136_5 D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1073_4 D_CRC02_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1136_5 {
        [XmlEnum("75")]
        Item75,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_ActivitiesPermittedInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1136_6 D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1073_4 D_CRC02_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1136_6 {
        [XmlEnum("76")]
        Item76,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_MentalStatusInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1136_7 D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1073_4 D_CRC02_CertificationConditionIndicator {get; set;}
    [XmlElement(Order=2)]
    public string D_CRC03_ConditionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CRC04_ConditionCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CRC05_ConditionCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CRC06_ConditionCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CRC07_ConditionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1136_7 {
        [XmlEnum("77")]
        Item77,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CL1_InstitutionalClaimCode_TS278A1 {
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
    public class S_CR1_AmbulanceTransportInformation_TS278A1 {
    [XmlElement(Order=0)]
    public string D_CR101_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR102_PatientWeight {get; set;}
    [XmlElement(Order=2)]
    public string D_CR103_AmbulanceTransportCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR104_AmbulanceTransportReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR105_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CR106_TransportDistance {get; set;}
    [XmlElement(Order=6)]
    public string D_CR107_AddressInformation {get; set;}
    [XmlElement(Order=7)]
    public string D_CR108_AddressInformation {get; set;}
    [XmlElement(Order=8)]
    public string D_CR109_RoundTripPurposeDescription {get; set;}
    [XmlElement(Order=9)]
    public string D_CR110_StretcherPurposeDescription {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR2_SpinalManipulationServiceInformation_TS278A1 {
    [XmlElement(Order=0)]
    public string D_CR201_TreatmentSeriesNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_CR202_TreatmentCount {get; set;}
    [XmlElement(Order=2)]
    public string D_CR203_SubluxationLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR204_SubluxationLevelCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR205_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CR206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_CR207_Quantity {get; set;}
    [XmlElement(Order=7)]
    public string D_CR208_PatientConditionCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CR209_ComplicationIndicator {get; set;}
    [XmlElement(Order=9)]
    public string D_CR210_PatientConditionDescription {get; set;}
    [XmlElement(Order=10)]
    public string D_CR211_PatientConditionDescription {get; set;}
    [XmlElement(Order=11)]
    public string D_CR212_X_rayAvailabilityIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR5_HomeOxygenTherapyInformation_TS278A1 {
    [XmlElement(Order=0)]
    public string D_CR501_CertificationTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR502_Quantity {get; set;}
    [XmlElement(Order=2)]
    public string D_CR503_OxygenEquipmentTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR504_OxygenEquipmentTypeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR505_EquipmentReasonDescription {get; set;}
    [XmlElement(Order=5)]
    public string D_CR506_OxygenFlowRate {get; set;}
    [XmlElement(Order=6)]
    public string D_CR507_DailyOxygenUseCount {get; set;}
    [XmlElement(Order=7)]
    public string D_CR508_OxygenUsePeriodHourCount {get; set;}
    [XmlElement(Order=8)]
    public string D_CR509_RespiratoryTherapistOrderText {get; set;}
    [XmlElement(Order=9)]
    public string D_CR510_ArterialBloodGasQuantity {get; set;}
    [XmlElement(Order=10)]
    public string D_CR511_OxygenSaturationQuantity {get; set;}
    [XmlElement(Order=11)]
    public string D_CR512_OxygenTestConditionCode {get; set;}
    [XmlElement(Order=12)]
    public string D_CR513_OxygenTestFindingsCode {get; set;}
    [XmlElement(Order=13)]
    public string D_CR514_OxygenTestFindingsCode {get; set;}
    [XmlElement(Order=14)]
    public string D_CR515_OxygenTestFindingsCode {get; set;}
    [XmlElement(Order=15)]
    public string D_CR516_PortableOxygenSystemFlowRate {get; set;}
    [XmlElement(Order=16)]
    public string D_CR517_OxygenDeliverySystemCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CR518_OxygenEquipmentTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR6_HomeHealthCareInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_923 D_CR601_PrognosisCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR602_HomeHealthStartDate {get; set;}
    [XmlElement(Order=2)]
    public string D_CR603_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_CR604_HomeHealthCertificationPeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_CR605_Date {get; set;}
    [XmlElement(Order=5)]
    public string D_CR606_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CR607_MedicareCoverageIndicator {get; set;}
    [XmlElement(Order=7)]
    public string D_CR608_CertificationTypeCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CR609_SurgeryDate {get; set;}
    [XmlElement(Order=9)]
    public string D_CR610_ProductorServiceIDQualifier {get; set;}
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
    public string D_CR617_PatientLocationCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CR618_Date {get; set;}
    [XmlElement(Order=18)]
    public string D_CR619_Date {get; set;}
    [XmlElement(Order=19)]
    public string D_CR620_Date {get; set;}
    [XmlElement(Order=20)]
    public string D_CR621_Date {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_923 {
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
    public class S_PWK_AdditionalPatientInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_755 D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_756 D_PWK02_ReportTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03_ReportCopiesNeeded {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_AttachmentDescription {get; set;}
    [XmlElement(Order=7)]
    public C_C002_ActionsIndicated_TS278A1 C_C002_ActionsIndicated_TS278A1 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09_RequestCategoryCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_755 {
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
        [XmlEnum("48")]
        Item48,
        [XmlEnum("55")]
        Item55,
        [XmlEnum("59")]
        Item59,
        [XmlEnum("77")]
        Item77,
        A3,
        A4,
        AM,
        AS,
        AT,
        B2,
        B3,
        BR,
        BS,
        BT,
        CB,
        CK,
        D2,
        DA,
        DB,
        DG,
        DJ,
        DS,
        FM,
        HC,
        HR,
        I5,
        IR,
        LA,
        M1,
        NN,
        OB,
        OC,
        OD,
        OE,
        OX,
        P4,
        P5,
        P6,
        P7,
        PE,
        PN,
        PO,
        PQ,
        PY,
        PZ,
        QC,
        QR,
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
    public enum X12_ID_A1_756 {
        AA,
        BM,
        EL,
        EM,
        FX,
        VO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C002_ActionsIndicated_TS278A1 {
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
    public class S_MSG_MessageText_TS278A1 {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02_PrinterCarriageControlCode {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03_Number {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_TS278A1 {
    [XmlElement(Order=0)]
    public U_TS278A1_2010EA U_TS278A1_2010EA {get; set;}
    [XmlElement(Order=1)]
    public U_TS278A1_2010EB U_TS278A1_2010EB {get; set;}
    [XmlElement(Order=2)]
    public U_TS278A1_2010EC U_TS278A1_2010EC {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2010EA {
    [XmlElement(Order=0)]
    public S_NM1_PatientEventProviderName_TS278A1 S_NM1_PatientEventProviderName_TS278A1 {get; set;}
    [XmlElement("S_REF_PatientEventProviderSupplementalInformation_TS278A1",Order=1)]
    public List<S_REF_PatientEventProviderSupplementalInformation_TS278A1> S_REF_PatientEventProviderSupplementalInformation_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_PatientEventProviderAddress_TS278A1 S_N3_PatientEventProviderAddress_TS278A1 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_PatientEventProviderCity_State_ZipCode_TS278A1 S_N4_PatientEventProviderCity_State_ZipCode_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public S_PER_PatientEventProviderContactInformation_TS278A1 S_PER_PatientEventProviderContactInformation_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public S_PRV_PatientEventProviderInformation_TS278A1 S_PRV_PatientEventProviderInformation_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientEventProviderName_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_98_6 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientEventProviderLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientEventProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientEventProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_PatientEventProviderNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PatientEventProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PatientEventProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_98_6 {
        [XmlEnum("71")]
        Item71,
        [XmlEnum("72")]
        Item72,
        [XmlEnum("73")]
        Item73,
        [XmlEnum("77")]
        Item77,
        AAJ,
        DD,
        DK,
        DN,
        FA,
        G3,
        P3,
        QB,
        QV,
        SJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PatientEventProviderSupplementalInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PatientEventProviderSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_LicenseNumberStateCode {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_6_TS278A1 C_C040_ReferenceIdentifier_6_TS278A1 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_128_8 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1J")]
        Item1J,
        EI,
        N5,
        N7,
        SY,
        ZH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_6_TS278A1 {
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
    public class S_N3_PatientEventProviderAddress_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N301_PatientEventProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PatientEventProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PatientEventProviderCity_State_ZipCode_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N401_PatientEventProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PatientEventProviderStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PatientEventProviderPostalZoneorZIPCode {get; set;}
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
    public class S_PER_PatientEventProviderContactInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_PatientEventProviderContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_PatientEventProviderContactCommunicationsNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_PatientEventProviderContactCommunicationsNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_PatientEventProviderContactCommunicationsNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_PatientEventProviderInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1221_2 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_128_3 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_2_TS278A1 C_C035_ProviderSpecialtyInformation_2_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1221_2 {
        AD,
        AS,
        AT,
        OP,
        OR,
        OT,
        PC,
        PE,
        RF,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_128_3 {
        PXC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_2_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2010EB {
    [XmlElement(Order=0)]
    public S_NM1_PatientEventTransportInformation_TS278A1 S_NM1_PatientEventTransportInformation_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PatientEventTransportLocationAddress_TS278A1 S_N3_PatientEventTransportLocationAddress_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PatientEventTransportLocationCity_State_ZIPCode_TS278A1 S_N4_PatientEventTransportLocationCity_State_ZIPCode_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientEventTransportInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_98_7 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientEventTransportLocationName {get; set;}
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
    public enum X12_ID_A1_98_7 {
        [XmlEnum("45")]
        Item45,
        FS,
        ND,
        PW,
        R3,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1065_3 {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PatientEventTransportLocationAddress_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N301_PatientEventTransportLocationAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PatientEventTransportLocationAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PatientEventTransportLocationCity_State_ZIPCode_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N401_PatientEventTransportLocationCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PatientEventTransportLocationStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PatientEventTransportLocationPostalZoneorZIPCode {get; set;}
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
    public class G_TS278A1_2010EC {
    [XmlElement(Order=0)]
    public S_NM1_PatientEventOtherUMOName_TS278A1 S_NM1_PatientEventOtherUMOName_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public S_REF_OtherUMODenialReason_TS278A1 S_REF_OtherUMODenialReason_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_OtherUMODenialDate_TS278A1 S_DTP_OtherUMODenialDate_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientEventOtherUMOName_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherUMOName {get; set;}
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
    public enum X12_ID_A1_98_8 {
        [XmlEnum("00")]
        Item00,
        CA,
        GG,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherUMODenialReason_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherUMODenialReason {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_7_TS278A1 C_C040_ReferenceIdentifier_7_TS278A1 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_128_9 {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_7_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C04001_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C04002_OtherUMODenialReason {get; set;}
    [XmlElement(Order=2)]
    public string D_C04003_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C04004_OtherUMODenialReason {get; set;}
    [XmlElement(Order=4)]
    public string D_C04005_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_C04006_ReferenceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_OtherUMODenialDate_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374_8 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OtherUMODenialDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374_8 {
        [XmlEnum("598")]
        Item598,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_HL_ServiceLevel_TS278A1 S_HL_ServiceLevel_TS278A1 {get; set;}
    [XmlElement("S_TRN_ServiceTraceNumber_TS278A1",Order=1)]
    public List<S_TRN_ServiceTraceNumber_TS278A1> S_TRN_ServiceTraceNumber_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_UM_HealthCareServicesReviewInformation_2_TS278A1 S_UM_HealthCareServicesReviewInformation_2_TS278A1 {get; set;}
    [XmlElement(Order=3)]
    public A_REF_2_TS278A1 A_REF_2_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public S_DTP_ServiceDate_TS278A1 S_DTP_ServiceDate_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public S_SV1_ProfessionalService_TS278A1 S_SV1_ProfessionalService_TS278A1 {get; set;}
    [XmlElement(Order=6)]
    public S_SV2_InstitutionalServiceLine_TS278A1 S_SV2_InstitutionalServiceLine_TS278A1 {get; set;}
    [XmlElement(Order=7)]
    public S_SV3_DentalService_TS278A1 S_SV3_DentalService_TS278A1 {get; set;}
    [XmlElement("S_TOO_ToothInformation_TS278A1",Order=8)]
    public List<S_TOO_ToothInformation_TS278A1> S_TOO_ToothInformation_TS278A1 {get; set;}
    [XmlElement(Order=9)]
    public S_HSD_HealthCareServicesDelivery_2_TS278A1 S_HSD_HealthCareServicesDelivery_2_TS278A1 {get; set;}
    [XmlElement("S_PWK_AdditionalServiceInformation_TS278A1",Order=10)]
    public List<S_PWK_AdditionalServiceInformation_TS278A1> S_PWK_AdditionalServiceInformation_TS278A1 {get; set;}
    [XmlElement(Order=11)]
    public S_MSG_MessageText_2_TS278A1 S_MSG_MessageText_2_TS278A1 {get; set;}
    [XmlElement("G_TS278A1_2010F",Order=12)]
    public List<G_TS278A1_2010F> G_TS278A1_2010F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_ServiceLevel_TS278A1 {
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
    public class S_TRN_ServiceTraceNumber_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ServiceTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_UM_HealthCareServicesReviewInformation_2_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1525_3 D_UM01_RequestCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_UM02_CertificationTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_UM03_ServiceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public C_C023_ValuesenteredattheServiceLeveloverridesthevalueatthePatientEventLevelforthisservice_TS278A1 C_C023_ValuesenteredattheServiceLeveloverridesthevalueatthePatientEventLevelforthisservice_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public C_C024_RelatedCausesInformation_2_TS278A1 C_C024_RelatedCausesInformation_2_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public string D_UM06_LevelofServiceCode {get; set;}
    [XmlElement(Order=6)]
    public string D_UM07_CurrentHealthConditionCode {get; set;}
    [XmlElement(Order=7)]
    public string D_UM08_PrognosisCode {get; set;}
    [XmlElement(Order=8)]
    public string D_UM09_ReleaseofInformationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_UM10_DelayReasonCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1525_3 {
        HS,
        SC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C023_ValuesenteredattheServiceLeveloverridesthevalueatthePatientEventLevelforthisservice_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02301_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02302_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_C02303_ClaimFrequencyTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C024_RelatedCausesInformation_2_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C02401_Related_CausesCode {get; set;}
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
    public class A_REF_2_TS278A1 {
    [XmlElementAttribute(Order=0)]
    public S_REF_PreviousReviewAuthorizationNumber_2_TS278A1 S_REF_PreviousReviewAuthorizationNumber_2_TS278A1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PreviousReviewAdministrativeReferenceNumber_2_TS278A1 S_REF_PreviousReviewAdministrativeReferenceNumber_2_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PreviousReviewAuthorizationNumber_2_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PreviousReviewAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_8_TS278A1 C_C040_ReferenceIdentifier_8_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_8_TS278A1 {
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
    public class S_REF_PreviousReviewAdministrativeReferenceNumber_2_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PreviousAdministrativeReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_9_TS278A1 C_C040_ReferenceIdentifier_9_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_9_TS278A1 {
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
    public class S_DTP_ServiceDate_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_374_9 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedorActualServiceDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_374_9 {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SV1_ProfessionalService_TS278A1 {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier_TS278A1 C_C003_CompositeMedicalProcedureIdentifier_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public string D_SV102_ServiceLineAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SV103_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_SV104_ServiceUnitCount {get; set;}
    [XmlElement(Order=4)]
    public string D_SV105_FacilityCodeValue {get; set;}
    [XmlElement(Order=5)]
    public string D_SV106_ServiceTypeCode {get; set;}
    [XmlElement(Order=6)]
    public C_C004_CompositeDiagnosisCodePointer_TS278A1 C_C004_CompositeDiagnosisCodePointer_TS278A1 {get; set;}
    [XmlElement(Order=7)]
    public string D_SV108_MonetaryAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_SV109_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV110_MultipleProcedureCode {get; set;}
    [XmlElement(Order=10)]
    public string D_SV111_EPSDTIndicator {get; set;}
    [XmlElement(Order=11)]
    public string D_SV112_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=12)]
    public string D_SV113_ReviewCode {get; set;}
    [XmlElement(Order=13)]
    public string D_SV114_NationalorLocalAssignedReviewValue {get; set;}
    [XmlElement(Order=14)]
    public string D_SV115_CopayStatusCode {get; set;}
    [XmlElement(Order=15)]
    public string D_SV116_HealthCareProfessionalShortageAreaCode {get; set;}
    [XmlElement(Order=16)]
    public string D_SV117_ReferenceIdentification {get; set;}
    [XmlElement(Order=17)]
    public string D_SV118_PostalCode {get; set;}
    [XmlElement(Order=18)]
    public string D_SV119_MonetaryAmount {get; set;}
    [XmlElement(Order=19)]
    public string D_SV120_NursingHomeLevelofCare {get; set;}
    [XmlElement(Order=20)]
    public string D_SV121_ProviderAgreementCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_235_2 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00308_ProcedureCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_235_2 {
        HC,
        IV,
        N4,
        WK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C004_CompositeDiagnosisCodePointer_TS278A1 {
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
    public class S_SV2_InstitutionalServiceLine_TS278A1 {
    [XmlElement(Order=0)]
    public string D_SV201_ServiceLineRevenueCode {get; set;}
    [XmlElement(Order=1)]
    public C_C003_CompositeMedicalProcedureIdentifier_2_TS278A1 C_C003_CompositeMedicalProcedureIdentifier_2_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public string D_SV203_ServiceLineAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SV204_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SV205_ServiceUnitCount {get; set;}
    [XmlElement(Order=5)]
    public string D_SV206_ServiceLineRate {get; set;}
    [XmlElement(Order=6)]
    public string D_SV207_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_SV208_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SV209_NursingHomeResidentialStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV210_NursingHomeLevelofCare {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_2_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_235_3 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00308_ProcedureCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_235_3 {
        HC,
        ID,
        IV,
        N4,
        WK,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SV3_DentalService_TS278A1 {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier_3_TS278A1 C_C003_CompositeMedicalProcedureIdentifier_3_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public string D_SV302_ServiceLineAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SV303_FacilityCodeValue {get; set;}
    [XmlElement(Order=3)]
    public C_C006_OralCavityDesignation_TS278A1 C_C006_OralCavityDesignation_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public string D_SV305_Prosthesis_Crown_orInlayCode {get; set;}
    [XmlElement(Order=5)]
    public string D_SV306_ServiceUnitCount {get; set;}
    [XmlElement(Order=6)]
    public string D_SV307_Description {get; set;}
    [XmlElement(Order=7)]
    public string D_SV308_CopayStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SV309_ProviderAgreementCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV310_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=10)]
    public C_C004_CompositeDiagnosisCodePointer_2_TS278A1 C_C004_CompositeDiagnosisCodePointer_2_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_3_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_235_4 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00308_ProcedureCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_235_4 {
        AD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C006_OralCavityDesignation_TS278A1 {
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
    public class C_C004_CompositeDiagnosisCodePointer_2_TS278A1 {
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
    public class S_TOO_ToothInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1270_5 D_TOO01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TOO02_ToothCode {get; set;}
    [XmlElement(Order=2)]
    public C_C005_ToothSurface_TS278A1 C_C005_ToothSurface_TS278A1 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1270_5 {
        JP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C005_ToothSurface_TS278A1 {
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
    public class S_HSD_HealthCareServicesDelivery_2_TS278A1 {
    [XmlElement(Order=0)]
    public string D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_ServiceUnitCount {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HSD04_SampleSelectionModulus {get; set;}
    [XmlElement(Order=4)]
    public string D_HSD05_TimePeriodQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_HSD06_PeriodCount {get; set;}
    [XmlElement(Order=6)]
    public string D_HSD07_DeliveryFrequencyCode {get; set;}
    [XmlElement(Order=7)]
    public string D_HSD08_DeliveryPatternTimeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_AdditionalServiceInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_755 D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_756 D_PWK02_ReportTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03_ReportCopiesNeeded {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_AttachmentDescription {get; set;}
    [XmlElement(Order=7)]
    public C_C002_ActionsIndicated_2_TS278A1 C_C002_ActionsIndicated_2_TS278A1 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09_RequestCategoryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C002_ActionsIndicated_2_TS278A1 {
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
    public class S_MSG_MessageText_2_TS278A1 {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02_PrinterCarriageControlCode {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03_Number {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2010F {
    [XmlElement(Order=0)]
    public S_NM1_ServiceProviderName_TS278A1 S_NM1_ServiceProviderName_TS278A1 {get; set;}
    [XmlElement("S_REF_ServiceProviderSupplementalIdentification_TS278A1",Order=1)]
    public List<S_REF_ServiceProviderSupplementalIdentification_TS278A1> S_REF_ServiceProviderSupplementalIdentification_TS278A1 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_ServiceProviderAddress_TS278A1 S_N3_ServiceProviderAddress_TS278A1 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_ServiceProviderCity_State_ZIPCode_TS278A1 S_N4_ServiceProviderCity_State_ZIPCode_TS278A1 {get; set;}
    [XmlElement(Order=4)]
    public S_PER_ServiceProviderContactInformation_TS278A1 S_PER_ServiceProviderContactInformation_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public S_PRV_ServiceProviderInformation_TS278A1 S_PRV_ServiceProviderInformation_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceProviderName_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_98_9 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ServiceProviderLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ServiceProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ServiceProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_ServiceProviderNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ServiceProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ServiceProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_98_9 {
        [XmlEnum("1T")]
        Item1T,
        [XmlEnum("72")]
        Item72,
        [XmlEnum("73")]
        Item73,
        [XmlEnum("77")]
        Item77,
        DD,
        DK,
        DQ,
        FA,
        G3,
        P3,
        QB,
        QV,
        SJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceProviderSupplementalIdentification_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ServiceProviderSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_LicenseNumberStateCode {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_10_TS278A1 C_C040_ReferenceIdentifier_10_TS278A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_10_TS278A1 {
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
    public class S_N3_ServiceProviderAddress_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N301_ServiceProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ServiceProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceProviderCity_State_ZIPCode_TS278A1 {
    [XmlElement(Order=0)]
    public string D_N401_ServiceProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ServiceProviderStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ServiceProviderPostalZoneorZIPCode {get; set;}
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
    public class S_PER_ServiceProviderContactInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_ServiceProviderContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_ServiceProviderContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_ServiceProviderContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_ServiceProviderContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ServiceProviderInformation_TS278A1 {
    [XmlElement(Order=0)]
    public X12_ID_A1_1221_3 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_A1_128_3 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_3_TS278A1 C_C035_ProviderSpecialtyInformation_3_TS278A1 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_A1_1221_3 {
        AS,
        OP,
        OR,
        OT,
        PC,
        PE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_3_TS278A1 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_A3_BHT {
    [XmlElement(Order=0)]
    public S_BHT_BeginningofHierarchicalTransaction_TS278A3 S_BHT_BeginningofHierarchicalTransaction_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A3_2000A G_TS278A3_2000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BHT_BeginningofHierarchicalTransaction_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1005 D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_353 D_BHT02_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BHT03_SubmitterTransactionIdentifier {get; set;}
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
        [XmlEnum("0007")]
        Item0007,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_353 {
        [XmlEnum("11")]
        Item11,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000A {
    [XmlElement(Order=0)]
    public S_HL_UtilizationManagementOrganization_UMO_Level_TS278A3 S_HL_UtilizationManagementOrganization_UMO_Level_TS278A3 {get; set;}
    [XmlElement("S_AAA_RequestValidation_TS278A3",Order=1)]
    public List<S_AAA_RequestValidation_TS278A3> S_AAA_RequestValidation_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A3_2010A G_TS278A3_2010A {get; set;}
    [XmlElement(Order=3)]
    public G_TS278A3_2000B G_TS278A3_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_UtilizationManagementOrganization_UMO_Level_TS278A3 {
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
    public class S_AAA_RequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1073 {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010A {
    [XmlElement(Order=0)]
    public S_NM1_UtilizationManagementOrganization_UMO_Name_TS278A3 S_NM1_UtilizationManagementOrganization_UMO_Name_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public S_PER_UtilizationManagementOrganization_UMO_ContactInformation_TS278A3 S_PER_UtilizationManagementOrganization_UMO_ContactInformation_TS278A3 {get; set;}
    [XmlElement("S_AAA_UtilizationManagementOrganization_UMO_RequestValidation_TS278A3",Order=2)]
    public List<S_AAA_UtilizationManagementOrganization_UMO_RequestValidation_TS278A3> S_AAA_UtilizationManagementOrganization_UMO_RequestValidation_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_UtilizationManagementOrganization_UMO_Name_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_UtilizationManagementOrganization_UMO_LastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_UtilizationManagementOrganization_UMO_FirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_UtilizationManagementOrganization_UMO_MiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_UtilizationManagementOrganization_UMO_NameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_UtilizationManagementOrganization_UMO_Identifier {get; set;}
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
        [XmlEnum("2B")]
        Item2B,
        [XmlEnum("36")]
        Item36,
        PR,
        X3,
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
    public class S_PER_UtilizationManagementOrganization_UMO_ContactInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_UtilizationManagementOrganization_UMO_ContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_UtilizationManagementOrganization_UMO_ContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_UtilizationManagementOrganization_UMO_ContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_UtilizationManagementOrganization_UMO_ContactCommunicationNumber {get; set;}
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
    public class S_AAA_UtilizationManagementOrganization_UMO_RequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1073_2 {
        N,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000B {
    [XmlElement(Order=0)]
    public S_HL_RequesterLevel_TS278A3 S_HL_RequesterLevel_TS278A3 {get; set;}
    [XmlElement("G_TS278A3_2010B",Order=1)]
    public List<G_TS278A3_2010B> G_TS278A3_2010B {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A3_2000C G_TS278A3_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_RequesterLevel_TS278A3 {
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
    public class G_TS278A3_2010B {
    [XmlElement(Order=0)]
    public S_NM1_RequesterName_TS278A3 S_NM1_RequesterName_TS278A3 {get; set;}
    [XmlElement("S_REF_RequesterSupplementalIdentification_TS278A3",Order=1)]
    public List<S_REF_RequesterSupplementalIdentification_TS278A3> S_REF_RequesterSupplementalIdentification_TS278A3 {get; set;}
    [XmlElement("S_AAA_RequesterRequestValidation_TS278A3",Order=2)]
    public List<S_AAA_RequesterRequestValidation_TS278A3> S_AAA_RequesterRequestValidation_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_PRV_RequesterProviderInformation_TS278A3 S_PRV_RequesterProviderInformation_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RequesterName_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98_3 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RequesterLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RequesterFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RequesterMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RequesterNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RequesterIdentifier {get; set;}
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
        [XmlEnum("1P")]
        Item1P,
        FA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RequesterSupplementalIdentification_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RequesterSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_TS278A3 C_C040_ReferenceIdentifier_TS278A3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128 {
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1J")]
        Item1J,
        EI,
        G5,
        N5,
        N7,
        SY,
        ZH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_TS278A3 {
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
    public class S_AAA_RequesterRequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_RequesterProviderInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1221 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_TS278A3 C_C035_ProviderSpecialtyInformation_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1221 {
        AD,
        AS,
        AT,
        CO,
        CV,
        OP,
        OR,
        OT,
        PC,
        PE,
        RF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel_TS278A3 S_HL_SubscriberLevel_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A3_2010C G_TS278A3_2010C {get; set;}
    [XmlElement("G_TS278A3_2000E",Order=2)]
    public List<G_TS278A3_2000E> G_TS278A3_2000E {get; set;}
    [XmlElement(Order=3)]
    public G_TS278A3_2000D G_TS278A3_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberLevel_TS278A3 {
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
    public class G_TS278A3_2010C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS278A3 S_NM1_SubscriberName_TS278A3 {get; set;}
    [XmlElement("S_REF_SubscriberSupplementalIdentification_TS278A3",Order=1)]
    public List<S_REF_SubscriberSupplementalIdentification_TS278A3> S_REF_SubscriberSupplementalIdentification_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_SubscriberMailingAddress_TS278A3 S_N3_SubscriberMailingAddress_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_SubscriberCity_State_ZIPCode_TS278A3 S_N4_SubscriberCity_State_ZIPCode_TS278A3 {get; set;}
    [XmlElement("S_AAA_SubscriberRequestValidation_TS278A3",Order=4)]
    public List<S_AAA_SubscriberRequestValidation_TS278A3> S_AAA_SubscriberRequestValidation_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public S_DMG_SubscriberDemographicInformation_TS278A3 S_DMG_SubscriberDemographicInformation_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public S_INS_SubscriberRelationship_TS278A3 S_INS_SubscriberRelationship_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_NM101_EntityIdentifierCode {get; set;}
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
    public enum X12_ID_98_4 {
        IL,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_2 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberSupplementalIdentification_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2_TS278A3 C_C040_ReferenceIdentifier_2_TS278A3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("3L")]
        Item3L,
        [XmlEnum("6P")]
        Item6P,
        DP,
        EJ,
        F6,
        HJ,
        IG,
        N6,
        NQ,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_2_TS278A3 {
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
    public class S_N3_SubscriberMailingAddress_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberCity_State_ZIPCode_TS278A3 {
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
    public class S_AAA_SubscriberRequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_SubscriberDemographicInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1250 D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_SubscriberBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_SubscriberGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04_MaritalStatusCode {get; set;}
    [XmlElement("C_C056_CompositeRaceorEthnicityInformation_TS278A3",Order=4)]
    public List<C_C056_CompositeRaceorEthnicityInformation_TS278A3> C_C056_CompositeRaceorEthnicityInformation_TS278A3 {get; set;}
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
    public class C_C056_CompositeRaceorEthnicityInformation_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C05601_RaceorEthnicityCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05602_CodeListQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05603_IndustryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_SubscriberRelationship_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_4 D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1069 D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05_BenefitStatusCode {get; set;}
    [XmlElement(Order=5)]
    public C_C052_MedicareStatusCode_TS278A3 C_C052_MedicareStatusCode_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07_ConsolidatedOmnibusBudgetReconciliationAct_COBRA_QualifyingEventCode {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09_StudentStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=10)]
    public string D_INS11_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=11)]
    public string D_INS12_DateTimePeriod {get; set;}
    [XmlElement(Order=12)]
    public string D_INS13_ConfidentialityCode {get; set;}
    [XmlElement(Order=13)]
    public string D_INS14_CityName {get; set;}
    [XmlElement(Order=14)]
    public string D_INS15_StateorProvinceCode {get; set;}
    [XmlElement(Order=15)]
    public string D_INS16_CountryCode {get; set;}
    [XmlElement(Order=16)]
    public string D_INS17_Number {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1073_4 {
        Y,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1069 {
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C052_MedicareStatusCode_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C05201_MedicarePlanCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05202_EligibilityReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05203_EligibilityReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C05204_EligibilityReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000E {
    [XmlElement(Order=0)]
    public S_HL_PatientEventLevel_TS278A3 S_HL_PatientEventLevel_TS278A3 {get; set;}
    [XmlElement("S_TRN_PatientEventTrackingNumber_TS278A3",Order=1)]
    public List<S_TRN_PatientEventTrackingNumber_TS278A3> S_TRN_PatientEventTrackingNumber_TS278A3 {get; set;}
    [XmlElement("S_AAA_PatientEventRequestValidation_TS278A3",Order=2)]
    public List<S_AAA_PatientEventRequestValidation_TS278A3> S_AAA_PatientEventRequestValidation_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_UM_HealthCareServicesReviewInformation_TS278A3 S_UM_HealthCareServicesReviewInformation_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public S_HCR_HealthCareServicesReview_TS278A3 S_HCR_HealthCareServicesReview_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public A_REF_TS278A3 A_REF_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public A_DTP_TS278A3 A_DTP_TS278A3 {get; set;}
    [XmlElement(Order=7)]
    public S_HI_PatientDiagnosis_TS278A3 S_HI_PatientDiagnosis_TS278A3 {get; set;}
    [XmlElement(Order=8)]
    public S_HSD_HealthCareServicesDelivery_TS278A3 S_HSD_HealthCareServicesDelivery_TS278A3 {get; set;}
    [XmlElement(Order=9)]
    public S_CL1_InstitutionalClaimCode_TS278A3 S_CL1_InstitutionalClaimCode_TS278A3 {get; set;}
    [XmlElement(Order=10)]
    public S_CR1_AmbulanceTransportInformation_TS278A3 S_CR1_AmbulanceTransportInformation_TS278A3 {get; set;}
    [XmlElement(Order=11)]
    public S_CR2_SpinalManipulationServiceInformation_TS278A3 S_CR2_SpinalManipulationServiceInformation_TS278A3 {get; set;}
    [XmlElement(Order=12)]
    public S_CR5_HomeOxygenTherapyInformation_TS278A3 S_CR5_HomeOxygenTherapyInformation_TS278A3 {get; set;}
    [XmlElement(Order=13)]
    public S_CR6_HomeHealthCareInformation_TS278A3 S_CR6_HomeHealthCareInformation_TS278A3 {get; set;}
    [XmlElement("S_PWK_AdditionalPatientInformation_TS278A3",Order=14)]
    public List<S_PWK_AdditionalPatientInformation_TS278A3> S_PWK_AdditionalPatientInformation_TS278A3 {get; set;}
    [XmlElement(Order=15)]
    public S_MSG_MessageText_TS278A3 S_MSG_MessageText_TS278A3 {get; set;}
    [XmlElement(Order=16)]
    public A_NM1_TS278A3 A_NM1_TS278A3 {get; set;}
    [XmlElement("G_TS278A3_2000F",Order=17)]
    public List<G_TS278A3_2000F> G_TS278A3_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_PatientEventLevel_TS278A3 {
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
    public class S_TRN_PatientEventTrackingNumber_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_PatientEventTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_481 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_PatientEventRequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_UM_HealthCareServicesReviewInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1525 D_UM01_RequestCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1322 D_UM02_CertificationTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_UM03_ServiceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public C_C023_HealthCareServiceLocationInformation_TS278A3 C_C023_HealthCareServiceLocationInformation_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public C_C024_RelatedCausesInformation_TS278A3 C_C024_RelatedCausesInformation_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public string D_UM06_LevelofServiceCode {get; set;}
    [XmlElement(Order=6)]
    public string D_UM07_CurrentHealthConditionCode {get; set;}
    [XmlElement(Order=7)]
    public string D_UM08_PrognosisCode {get; set;}
    [XmlElement(Order=8)]
    public string D_UM09_ReleaseofInformationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_UM10_DelayReasonCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1525 {
        AR,
        HS,
        IN,
        SC,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1322 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("4")]
        Item4,
        I,
        N,
        R,
        S,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C023_HealthCareServiceLocationInformation_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02301_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02302_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_C02303_ClaimFrequencyTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C024_RelatedCausesInformation_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02401_Related_CausesCode {get; set;}
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
    public class S_HCR_HealthCareServicesReview_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_306 D_HCR01_ActionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HCR02_ReviewIdentificationNumber {get; set;}
    [XmlElement("D_HCR03_ReviewDecisionReasonCode",Order=2)]
    public List<string> D_HCR03_ReviewDecisionReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HCR04_SecondSurgicalOpinionIndicator {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_306 {
        A1,
        A2,
        A3,
        A4,
        A6,
        C,
        CT,
        NA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS278A3 {
    [XmlElementAttribute(Order=0)]
    public S_REF_AdministrativeReferenceNumber_TS278A3 S_REF_AdministrativeReferenceNumber_TS278A3 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PreviousReviewAuthorizationNumber_TS278A3 S_REF_PreviousReviewAuthorizationNumber_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AdministrativeReferenceNumber_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdministrativeReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4_TS278A3 C_C040_ReferenceIdentifier_4_TS278A3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        NT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_4_TS278A3 {
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
    public class S_REF_PreviousReviewAuthorizationNumber_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PreviousReviewAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5_TS278A3 C_C040_ReferenceIdentifier_5_TS278A3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_7 {
        BB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_5_TS278A3 {
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
    public class A_DTP_TS278A3 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_AccidentDate_TS278A3 S_DTP_AccidentDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A3 S_DTP_LastMenstrualPeriodDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_EstimatedDateofBirth_TS278A3 S_DTP_EstimatedDateofBirth_TS278A3 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_OnsetofCurrentSymptomsorIllnessDate_TS278A3 S_DTP_OnsetofCurrentSymptomsorIllnessDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_DTP_EventDate_TS278A3 S_DTP_EventDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_DTP_AdmissionDate_TS278A3 S_DTP_AdmissionDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_DTP_DischargeDate_TS278A3 S_DTP_DischargeDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=7)]
    public S_DTP_CertificationIssueDate_TS278A3 S_DTP_CertificationIssueDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=8)]
    public S_DTP_CertificationExpirationDate_TS278A3 S_DTP_CertificationExpirationDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=9)]
    public S_DTP_CertificationEffectiveDate_TS278A3 S_DTP_CertificationEffectiveDate_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AccidentDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374 {
        [XmlEnum("439")]
        Item439,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LastMenstrualPeriodDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_LastMenstrualPeriodDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_2 {
        [XmlEnum("484")]
        Item484,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_EstimatedDateofBirth_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EstimatedBirthDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_3 {
        ABC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_OnsetofCurrentSymptomsorIllnessDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OnsetDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_4 {
        [XmlEnum("431")]
        Item431,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_EventDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_5 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedorActualEventDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_5 {
        AAH,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250_3 {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AdmissionDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedorActualAdmissionDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_6 {
        [XmlEnum("435")]
        Item435,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DischargeDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_7 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedorActualDischargeDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_7 {
        [XmlEnum("096")]
        Item096,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationIssueDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_8 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationIssueDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_8 {
        [XmlEnum("102")]
        Item102,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationExpirationDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_9 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationExpirationDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_9 {
        [XmlEnum("036")]
        Item036,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationEffectiveDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_10 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationEffectiveDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_10 {
        [XmlEnum("007")]
        Item007,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_PatientDiagnosis_TS278A3 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_TS278A3 C_C022_HealthCareCodeInformation_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_2_TS278A3 C_C022_HealthCareCodeInformation_2_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_3_TS278A3 C_C022_HealthCareCodeInformation_3_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_4_TS278A3 C_C022_HealthCareCodeInformation_4_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_5_TS278A3 C_C022_HealthCareCodeInformation_5_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_6_TS278A3 C_C022_HealthCareCodeInformation_6_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_7_TS278A3 C_C022_HealthCareCodeInformation_7_TS278A3 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_8_TS278A3 C_C022_HealthCareCodeInformation_8_TS278A3 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_9_TS278A3 C_C022_HealthCareCodeInformation_9_TS278A3 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_10_TS278A3 C_C022_HealthCareCodeInformation_10_TS278A3 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_11_TS278A3 C_C022_HealthCareCodeInformation_11_TS278A3 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_12_TS278A3 C_C022_HealthCareCodeInformation_12_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1270_2 D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
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
    public enum X12_ID_1270_2 {
        ABF,
        ABJ,
        ABK,
        APR,
        BF,
        BJ,
        BK,
        DR,
        LOI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1270_3 D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
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
        ABF,
        ABJ,
        APR,
        BF,
        BJ,
        DR,
        LOI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_3_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_4_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_5_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_6_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_7_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_8_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_9_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_10_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_11_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_12_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C02203_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_C02204_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_C02205_MonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_C02206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_C02207_VersionIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_C02208_IndustryCode {get; set;}
    [XmlElement(Order=8)]
    public string D_C02209_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HSD_HealthCareServicesDelivery_TS278A3 {
    [XmlElement(Order=0)]
    public string D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_ServiceUnitCount {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HSD04_SampleSelectionModulus {get; set;}
    [XmlElement(Order=4)]
    public string D_HSD05_TimePeriodQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_HSD06_PeriodCount {get; set;}
    [XmlElement(Order=6)]
    public string D_HSD07_DeliveryFrequencyCode {get; set;}
    [XmlElement(Order=7)]
    public string D_HSD08_DeliveryPatternTimeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CL1_InstitutionalClaimCode_TS278A3 {
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
    public class S_CR1_AmbulanceTransportInformation_TS278A3 {
    [XmlElement(Order=0)]
    public string D_CR101_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR102_Weight {get; set;}
    [XmlElement(Order=2)]
    public string D_CR103_AmbulanceTransportCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR104_AmbulanceTransportReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR105_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CR106_TransportDistance {get; set;}
    [XmlElement(Order=6)]
    public string D_CR107_AddressInformation {get; set;}
    [XmlElement(Order=7)]
    public string D_CR108_AddressInformation {get; set;}
    [XmlElement(Order=8)]
    public string D_CR109_Description {get; set;}
    [XmlElement(Order=9)]
    public string D_CR110_Description {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR2_SpinalManipulationServiceInformation_TS278A3 {
    [XmlElement(Order=0)]
    public string D_CR201_TreatmentSeriesNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_CR202_TreatmentCount {get; set;}
    [XmlElement(Order=2)]
    public string D_CR203_SubluxationLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR204_SubluxationLevelCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR205_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CR206_Quantity {get; set;}
    [XmlElement(Order=6)]
    public string D_CR207_Quantity {get; set;}
    [XmlElement(Order=7)]
    public string D_CR208_NatureofConditionCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CR209_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=9)]
    public string D_CR210_Description {get; set;}
    [XmlElement(Order=10)]
    public string D_CR211_Description {get; set;}
    [XmlElement(Order=11)]
    public string D_CR212_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR5_HomeOxygenTherapyInformation_TS278A3 {
    [XmlElement(Order=0)]
    public string D_CR501_CertificationTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR502_Quantity {get; set;}
    [XmlElement(Order=2)]
    public string D_CR503_OxygenEquipmentTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR504_OxygenEquipmentTypeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR505_Description {get; set;}
    [XmlElement(Order=5)]
    public string D_CR506_OxygenFlowRate {get; set;}
    [XmlElement(Order=6)]
    public string D_CR507_DailyOxygenUseCount {get; set;}
    [XmlElement(Order=7)]
    public string D_CR508_OxygenUsePeriodHourCount {get; set;}
    [XmlElement(Order=8)]
    public string D_CR509_RespiratoryTherapistOrderText {get; set;}
    [XmlElement(Order=9)]
    public string D_CR510_Quantity {get; set;}
    [XmlElement(Order=10)]
    public string D_CR511_Quantity {get; set;}
    [XmlElement(Order=11)]
    public string D_CR512_OxygenTestConditionCode {get; set;}
    [XmlElement(Order=12)]
    public string D_CR513_OxygenTestFindingsCode {get; set;}
    [XmlElement(Order=13)]
    public string D_CR514_OxygenTestFindingsCode {get; set;}
    [XmlElement(Order=14)]
    public string D_CR515_OxygenTestFindingsCode {get; set;}
    [XmlElement(Order=15)]
    public string D_CR516_PortableOxygenSystemFlowRate {get; set;}
    [XmlElement(Order=16)]
    public string D_CR517_OxygenDeliverySystemCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CR518_OxygenEquipmentTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR6_HomeHealthCareInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_923 D_CR601_PrognosisCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR602_HomeHealthStartDate {get; set;}
    [XmlElement(Order=2)]
    public string D_CR603_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_CR604_HomeHealthCertificationPeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_CR605_Date {get; set;}
    [XmlElement(Order=5)]
    public string D_CR606_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CR607_MedicareCoverageIndicator {get; set;}
    [XmlElement(Order=7)]
    public string D_CR608_CertificationTypeCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CR609_Date {get; set;}
    [XmlElement(Order=9)]
    public string D_CR610_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=10)]
    public string D_CR611_MedicalCodeValue {get; set;}
    [XmlElement(Order=11)]
    public string D_CR612_Date {get; set;}
    [XmlElement(Order=12)]
    public string D_CR613_Date {get; set;}
    [XmlElement(Order=13)]
    public string D_CR614_Date {get; set;}
    [XmlElement(Order=14)]
    public string D_CR615_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=15)]
    public string D_CR616_DateTimePeriod {get; set;}
    [XmlElement(Order=16)]
    public string D_CR617_PatientLocationCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CR618_Date {get; set;}
    [XmlElement(Order=18)]
    public string D_CR619_Date {get; set;}
    [XmlElement(Order=19)]
    public string D_CR620_Date {get; set;}
    [XmlElement(Order=20)]
    public string D_CR621_Date {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_923 {
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
    public class S_PWK_AdditionalPatientInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_755 D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_756 D_PWK02_ReportTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03_ReportCopiesNeeded {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_AttachmentDescription {get; set;}
    [XmlElement(Order=7)]
    public C_C002_ActionsIndicated_TS278A3 C_C002_ActionsIndicated_TS278A3 {get; set;}
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
        [XmlEnum("48")]
        Item48,
        [XmlEnum("55")]
        Item55,
        [XmlEnum("59")]
        Item59,
        [XmlEnum("77")]
        Item77,
        A3,
        A4,
        AM,
        AS,
        AT,
        B2,
        B3,
        BR,
        BS,
        BT,
        CB,
        CK,
        D2,
        DA,
        DB,
        DG,
        DJ,
        DS,
        FM,
        HC,
        HR,
        I5,
        IR,
        LA,
        M1,
        NN,
        OB,
        OC,
        OD,
        OE,
        OX,
        P4,
        P5,
        P6,
        P7,
        PE,
        PN,
        PO,
        PQ,
        PY,
        PZ,
        QC,
        QR,
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
        BM,
        EL,
        EM,
        FX,
        VO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C002_ActionsIndicated_TS278A3 {
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
    public class S_MSG_MessageText_TS278A3 {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02_PrinterCarriageControlCode {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03_Number {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_TS278A3 {
    [XmlElement(Order=0)]
    public U_TS278A3_2010EA U_TS278A3_2010EA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS278A3_2010EB G_TS278A3_2010EB {get; set;}
    [XmlElement(Order=2)]
    public U_TS278A3_2010EC U_TS278A3_2010EC {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010EA {
    [XmlElement(Order=0)]
    public S_NM1_PatientEventProviderName_TS278A3 S_NM1_PatientEventProviderName_TS278A3 {get; set;}
    [XmlElement("S_REF_PatientEventProviderSupplementalIdentification_TS278A3",Order=1)]
    public List<S_REF_PatientEventProviderSupplementalIdentification_TS278A3> S_REF_PatientEventProviderSupplementalIdentification_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_PatientEventProviderAddress_TS278A3 S_N3_PatientEventProviderAddress_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_PatientEventProviderCity_State_ZIPCode_TS278A3 S_N4_PatientEventProviderCity_State_ZIPCode_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public S_PER_ProviderContactInformation_TS278A3 S_PER_ProviderContactInformation_TS278A3 {get; set;}
    [XmlElement("S_AAA_PatientEventProviderRequestValidation_TS278A3",Order=5)]
    public List<S_AAA_PatientEventProviderRequestValidation_TS278A3> S_AAA_PatientEventProviderRequestValidation_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public S_PRV_PatientEventProviderInformation_TS278A3 S_PRV_PatientEventProviderInformation_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientEventProviderName_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98_6 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientEventProviderLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientEventProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientEventProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_PatientEventProviderNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PatientEventProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PatientEventProviderIdentifier {get; set;}
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
        [XmlEnum("71")]
        Item71,
        [XmlEnum("72")]
        Item72,
        [XmlEnum("73")]
        Item73,
        [XmlEnum("77")]
        Item77,
        AAJ,
        DD,
        DK,
        DN,
        FA,
        G3,
        P3,
        QB,
        QV,
        SJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PatientEventProviderSupplementalIdentification_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PatientEventProviderSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_LicenseNumberStateCode {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_6_TS278A3 C_C040_ReferenceIdentifier_6_TS278A3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_8 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1J")]
        Item1J,
        EI,
        N5,
        N7,
        SY,
        ZH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_6_TS278A3 {
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
    public class S_N3_PatientEventProviderAddress_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N301_PatientEventProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PatientEventProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PatientEventProviderCity_State_ZIPCode_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N401_PatientEventProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PatientEventProviderStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PatientEventProviderPostalZoneorZIPCode {get; set;}
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
    public class S_PER_ProviderContactInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_PatientEventProviderContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_PatientEventProviderContactCommunicationsNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_PatientEventProviderContactCommunicationsNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_PatientEventProviderContactCommunicationsNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_PatientEventProviderRequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_PatientEventProviderInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1221_2 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128_3 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_2_TS278A3 C_C035_ProviderSpecialtyInformation_2_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1221_2 {
        AD,
        AS,
        AT,
        OP,
        OR,
        OT,
        PC,
        PE,
        RF,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_3 {
        PXC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_2_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010EB {
    [XmlElement(Order=0)]
    public S_NM1_AdditionalPatientInformationContactName_TS278A3 S_NM1_AdditionalPatientInformationContactName_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_AdditionalPatientInformationContactAddress_TS278A3 S_N3_AdditionalPatientInformationContactAddress_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_AdditionalPatientInformationContactCity_State_ZIPCode_TS278A3 S_N4_AdditionalPatientInformationContactCity_State_ZIPCode_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_PER_AdditionalPatientInformationContactInformation_TS278A3 S_PER_AdditionalPatientInformationContactInformation_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AdditionalPatientInformationContactName_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98_7 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ResponseContactLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ResponseContactFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ResponseContactMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ResponseContactNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ResponseContactIdentifier {get; set;}
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
        L5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_AdditionalPatientInformationContactAddress_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N301_ResponseContactAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ResponseContactAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_AdditionalPatientInformationContactCity_State_ZIPCode_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N401_AdditionalPatientInformationContactCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_AdditionalPatientInformationContactStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_AdditionalPatientInformationContactPostal_ZoneorZIPCode {get; set;}
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
    public class S_PER_AdditionalPatientInformationContactInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_ResponseContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_ResponseContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_ResponseContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_ResponseContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010EC {
    [XmlElement(Order=0)]
    public S_NM1_PatientEventTransportInformation_TS278A3 S_NM1_PatientEventTransportInformation_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PatientEventTransportLocationAddress_TS278A3 S_N3_PatientEventTransportLocationAddress_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PatientEventTransportLocationCity_State_ZIPCode_TS278A3 S_N4_PatientEventTransportLocationCity_State_ZIPCode_TS278A3 {get; set;}
    [XmlElement("S_AAA_PatientEventTransportLocationRequestValidation_TS278A3",Order=3)]
    public List<S_AAA_PatientEventTransportLocationRequestValidation_TS278A3> S_AAA_PatientEventTransportLocationRequestValidation_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientEventTransportInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientEventTransportLocationName {get; set;}
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
    public enum X12_ID_98_8 {
        [XmlEnum("45")]
        Item45,
        FS,
        ND,
        PW,
        R3,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_3 {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PatientEventTransportLocationAddress_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N301_PatientEventTransportLocationAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PatientEventTransportLocationAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PatientEventTransportLocationCity_State_ZIPCode_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N401_PatientEventTransportLocationCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PatientEventTransportLocationStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PatientEventTransportLocationPostalZoneorZIPCode {get; set;}
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
    public class S_AAA_PatientEventTransportLocationRequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_HL_ServiceLevel_TS278A3 S_HL_ServiceLevel_TS278A3 {get; set;}
    [XmlElement("S_TRN_ServiceTraceNumber_TS278A3",Order=1)]
    public List<S_TRN_ServiceTraceNumber_TS278A3> S_TRN_ServiceTraceNumber_TS278A3 {get; set;}
    [XmlElement("S_AAA_ServiceRequestValidation_TS278A3",Order=2)]
    public List<S_AAA_ServiceRequestValidation_TS278A3> S_AAA_ServiceRequestValidation_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_UM_HealthCareServicesReviewInformation_2_TS278A3 S_UM_HealthCareServicesReviewInformation_2_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public S_HCR_HealthCareServicesReview_2_TS278A3 S_HCR_HealthCareServicesReview_2_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public A_REF_2_TS278A3 A_REF_2_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public A_DTP_2_TS278A3 A_DTP_2_TS278A3 {get; set;}
    [XmlElement(Order=7)]
    public S_HI_RequestForAdditionalInformation_TS278A3 S_HI_RequestForAdditionalInformation_TS278A3 {get; set;}
    [XmlElement(Order=8)]
    public S_SV1_ProfessionalService_TS278A3 S_SV1_ProfessionalService_TS278A3 {get; set;}
    [XmlElement(Order=9)]
    public S_SV2_InstitutionalServiceLine_TS278A3 S_SV2_InstitutionalServiceLine_TS278A3 {get; set;}
    [XmlElement(Order=10)]
    public S_SV3_DentalService_TS278A3 S_SV3_DentalService_TS278A3 {get; set;}
    [XmlElement("S_TOO_ToothInformation_TS278A3",Order=11)]
    public List<S_TOO_ToothInformation_TS278A3> S_TOO_ToothInformation_TS278A3 {get; set;}
    [XmlElement(Order=12)]
    public S_HSD_HealthCareServicesDelivery_2_TS278A3 S_HSD_HealthCareServicesDelivery_2_TS278A3 {get; set;}
    [XmlElement("S_PWK_AdditionalServiceInformation_TS278A3",Order=13)]
    public List<S_PWK_AdditionalServiceInformation_TS278A3> S_PWK_AdditionalServiceInformation_TS278A3 {get; set;}
    [XmlElement(Order=14)]
    public S_MSG_MessageText_2_TS278A3 S_MSG_MessageText_2_TS278A3 {get; set;}
    [XmlElement(Order=15)]
    public A_NM1_2_TS278A3 A_NM1_2_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_ServiceLevel_TS278A3 {
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
    public class S_TRN_ServiceTraceNumber_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ServiceTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_ServiceRequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_UM_HealthCareServicesReviewInformation_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1525_3 D_UM01_RequestCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public string D_UM02_CertificationTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_UM03_ServiceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public C_C023_HealthCareServiceLocationInformation_2_TS278A3 C_C023_HealthCareServiceLocationInformation_2_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public C_C024_RelatedCausesInformation_2_TS278A3 C_C024_RelatedCausesInformation_2_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public string D_UM06_LevelofServiceCode {get; set;}
    [XmlElement(Order=6)]
    public string D_UM07_CurrentHealthConditionCode {get; set;}
    [XmlElement(Order=7)]
    public string D_UM08_PrognosisCode {get; set;}
    [XmlElement(Order=8)]
    public string D_UM09_ReleaseofInformationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_UM10_DelayReasonCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1525_3 {
        HS,
        SC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C023_HealthCareServiceLocationInformation_2_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02301_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02302_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_C02303_ClaimFrequencyTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C024_RelatedCausesInformation_2_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02401_Related_CausesCode {get; set;}
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
    public class S_HCR_HealthCareServicesReview_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_306_2 D_HCR01_ActionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HCR02_ReviewIdentificationNumber {get; set;}
    [XmlElement("D_HCR03_ReviewDecisionReasonCode",Order=2)]
    public List<string> D_HCR03_ReviewDecisionReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HCR04_SecondSurgicalOpinionIndicator {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_306_2 {
        A1,
        A3,
        A4,
        A6,
        C,
        CT,
        NA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_2_TS278A3 {
    [XmlElementAttribute(Order=0)]
    public S_REF_AdministrativeReferenceNumber_2_TS278A3 S_REF_AdministrativeReferenceNumber_2_TS278A3 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PreviousReviewAuthorizationNumber_2_TS278A3 S_REF_PreviousReviewAuthorizationNumber_2_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AdministrativeReferenceNumber_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdministrativeReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_7_TS278A3 C_C040_ReferenceIdentifier_7_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_7_TS278A3 {
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
    public class S_REF_PreviousReviewAuthorizationNumber_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PreviousReviewAuthorizationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_8_TS278A3 C_C040_ReferenceIdentifier_8_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_8_TS278A3 {
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
    public class A_DTP_2_TS278A3 {
    [XmlElementAttribute(Order=0)]
    public S_DTP_ServiceDate_TS278A3 S_DTP_ServiceDate_TS278A3 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_CertificationIssueDate_2_TS278A3 S_DTP_CertificationIssueDate_2_TS278A3 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_CertificationExpirationDate_2_TS278A3 S_DTP_CertificationExpirationDate_2_TS278A3 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_CertificationEffectiveDate_2_TS278A3 S_DTP_CertificationEffectiveDate_2_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceDate_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_11 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedorActualServiceDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_11 {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationIssueDate_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_8 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationIssueDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationExpirationDate_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_9 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationExpirationDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationEffectiveDate_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_374_10 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationEffectiveDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_RequestForAdditionalInformation_TS278A3 {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_13_TS278A3 C_C022_HealthCareCodeInformation_13_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_14_TS278A3 C_C022_HealthCareCodeInformation_14_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_15_TS278A3 C_C022_HealthCareCodeInformation_15_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_16_TS278A3 C_C022_HealthCareCodeInformation_16_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_17_TS278A3 C_C022_HealthCareCodeInformation_17_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_18_TS278A3 C_C022_HealthCareCodeInformation_18_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_19_TS278A3 C_C022_HealthCareCodeInformation_19_TS278A3 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_20_TS278A3 C_C022_HealthCareCodeInformation_20_TS278A3 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_21_TS278A3 C_C022_HealthCareCodeInformation_21_TS278A3 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_22_TS278A3 C_C022_HealthCareCodeInformation_22_TS278A3 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_23_TS278A3 C_C022_HealthCareCodeInformation_23_TS278A3 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_24_TS278A3 C_C022_HealthCareCodeInformation_24_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_13_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1270_5 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public enum X12_ID_1270_5 {
        LOI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_14_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1270_5 D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_15_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_16_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_17_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_18_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_19_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_20_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_21_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_22_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_23_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_24_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C02201_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C02202_LOINCCode {get; set;}
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
    public class S_SV1_ProfessionalService_TS278A3 {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier_TS278A3 C_C003_CompositeMedicalProcedureIdentifier_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public string D_SV102_ServiceLineAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SV103_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_SV104_ServiceUnitCount {get; set;}
    [XmlElement(Order=4)]
    public string D_SV105_FacilityCodeValue {get; set;}
    [XmlElement(Order=5)]
    public string D_SV106_ServiceTypeCode {get; set;}
    [XmlElement(Order=6)]
    public C_C004_CompositeDiagnosisCodePointer_TS278A3 C_C004_CompositeDiagnosisCodePointer_TS278A3 {get; set;}
    [XmlElement(Order=7)]
    public string D_SV108_MonetaryAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_SV109_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV110_MultipleProcedureCode {get; set;}
    [XmlElement(Order=10)]
    public string D_SV111_EPSDTIndicator {get; set;}
    [XmlElement(Order=11)]
    public string D_SV112_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=12)]
    public string D_SV113_ReviewCode {get; set;}
    [XmlElement(Order=13)]
    public string D_SV114_NationalorLocalAssignedReviewValue {get; set;}
    [XmlElement(Order=14)]
    public string D_SV115_CopayStatusCode {get; set;}
    [XmlElement(Order=15)]
    public string D_SV116_HealthCareProfessionalShortageAreaCode {get; set;}
    [XmlElement(Order=16)]
    public string D_SV117_ReferenceIdentification {get; set;}
    [XmlElement(Order=17)]
    public string D_SV118_PostalCode {get; set;}
    [XmlElement(Order=18)]
    public string D_SV119_MonetaryAmount {get; set;}
    [XmlElement(Order=19)]
    public string D_SV120_NursingHomeLevelofCare {get; set;}
    [XmlElement(Order=20)]
    public string D_SV121_ProviderAgreementCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_TS278A3 {
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
    public string D_C00308_ProcedureCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_235_2 {
        HC,
        IV,
        N4,
        WK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C004_CompositeDiagnosisCodePointer_TS278A3 {
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
    public class S_SV2_InstitutionalServiceLine_TS278A3 {
    [XmlElement(Order=0)]
    public string D_SV201_ServiceLineRevenueCode {get; set;}
    [XmlElement(Order=1)]
    public C_C003_CompositeMedicalProcedureIdentifier_2_TS278A3 C_C003_CompositeMedicalProcedureIdentifier_2_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public string D_SV203_ServiceLineAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SV204_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SV205_ServiceUnitCount {get; set;}
    [XmlElement(Order=5)]
    public string D_SV206_ServiceLineRate {get; set;}
    [XmlElement(Order=6)]
    public string D_SV207_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_SV208_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SV209_NursingHomeResidentialStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV210_NursingHomeLevelofCare {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_2_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_235_3 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00308_ProcedureCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_235_3 {
        HC,
        ID,
        IV,
        N4,
        WK,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SV3_DentalService_TS278A3 {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier_3_TS278A3 C_C003_CompositeMedicalProcedureIdentifier_3_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public string D_SV302_ServiceLineAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SV303_FacilityCodeValue {get; set;}
    [XmlElement(Order=3)]
    public C_C006_OralCavityDesignation_TS278A3 C_C006_OralCavityDesignation_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public string D_SV305_Prosthesis_Crown_orInlayCode {get; set;}
    [XmlElement(Order=5)]
    public string D_SV306_ServiceUnitCount {get; set;}
    [XmlElement(Order=6)]
    public string D_SV307_Description {get; set;}
    [XmlElement(Order=7)]
    public string D_SV308_CopayStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SV309_ProviderAgreementCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SV310_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=10)]
    public C_C004_CompositeDiagnosisCodePointer_2_TS278A3 C_C004_CompositeDiagnosisCodePointer_2_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier_3_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_235_4 D_C00301_ProductorServiceIDQualifier {get; set;}
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
    public string D_C00308_ProcedureCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_235_4 {
        AD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C006_OralCavityDesignation_TS278A3 {
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
    public class C_C004_CompositeDiagnosisCodePointer_2_TS278A3 {
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
    public class S_TOO_ToothInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1270_6 D_TOO01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TOO02_ToothCode {get; set;}
    [XmlElement(Order=2)]
    public C_C005_ToothSurface_TS278A3 C_C005_ToothSurface_TS278A3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270_6 {
        JP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C005_ToothSurface_TS278A3 {
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
    public class S_HSD_HealthCareServicesDelivery_2_TS278A3 {
    [XmlElement(Order=0)]
    public string D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_ServiceUnitCount {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HSD04_SampleSelectionModulus {get; set;}
    [XmlElement(Order=4)]
    public string D_HSD05_TimePeriodQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_HSD06_PeriodCount {get; set;}
    [XmlElement(Order=6)]
    public string D_HSD07_DeliveryFrequencyCode {get; set;}
    [XmlElement(Order=7)]
    public string D_HSD08_DeliveryPatternTimeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_AdditionalServiceInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_755 D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_756 D_PWK02_ReportTransmissionCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PWK03_ReportCopiesNeeded {get; set;}
    [XmlElement(Order=3)]
    public string D_PWK04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_PWK05_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PWK06_AttachmentControlNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PWK07_AttachmentDescription {get; set;}
    [XmlElement(Order=7)]
    public C_C002_ActionsIndicated_2_TS278A3 C_C002_ActionsIndicated_2_TS278A3 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09_RequestCategoryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C002_ActionsIndicated_2_TS278A3 {
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
    public class S_MSG_MessageText_2_TS278A3 {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02_PrinterCarriageControlCode {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03_Number {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_2_TS278A3 {
    [XmlElement(Order=0)]
    public U_TS278A3_2010FA U_TS278A3_2010FA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS278A3_2010FB G_TS278A3_2010FB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010FA {
    [XmlElement(Order=0)]
    public S_NM1_ServiceProviderName_TS278A3 S_NM1_ServiceProviderName_TS278A3 {get; set;}
    [XmlElement("S_REF_ServiceProviderSupplementalIdentification_TS278A3",Order=1)]
    public List<S_REF_ServiceProviderSupplementalIdentification_TS278A3> S_REF_ServiceProviderSupplementalIdentification_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_ServiceProviderAddress_TS278A3 S_N3_ServiceProviderAddress_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_ServiceProviderCity_State_ZIPCode_TS278A3 S_N4_ServiceProviderCity_State_ZIPCode_TS278A3 {get; set;}
    [XmlElement(Order=4)]
    public S_PER_ServiceProviderContactInformation_TS278A3 S_PER_ServiceProviderContactInformation_TS278A3 {get; set;}
    [XmlElement("S_AAA_ServiceProviderRequestValidation_TS278A3",Order=5)]
    public List<S_AAA_ServiceProviderRequestValidation_TS278A3> S_AAA_ServiceProviderRequestValidation_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public S_PRV_ServiceProviderInformation_TS278A3 S_PRV_ServiceProviderInformation_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceProviderName_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ServiceProviderLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ServiceProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ServiceProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_ServiceProviderNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ServiceProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ServiceProviderIdentifier {get; set;}
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
        [XmlEnum("72")]
        Item72,
        [XmlEnum("73")]
        Item73,
        [XmlEnum("77")]
        Item77,
        DD,
        DK,
        DQ,
        FA,
        G3,
        P3,
        QB,
        QV,
        SJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceProviderSupplementalIdentification_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ServiceProviderSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_LicenseNumberStateCode {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_9_TS278A3 C_C040_ReferenceIdentifier_9_TS278A3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_9 {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1J")]
        Item1J,
        EI,
        G5,
        N5,
        N7,
        SY,
        ZH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_9_TS278A3 {
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
    public class S_N3_ServiceProviderAddress_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N301_ServiceProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ServiceProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceProviderCity_State_ZIPCode_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N401_ServiceProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ServiceProviderStateorProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ServiceProviderPostalZoneorZIPCode {get; set;}
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
    public class S_PER_ServiceProviderContactInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_ServiceProviderContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_ServiceProviderContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_ServiceProviderContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_ServiceProviderContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_ServiceProviderRequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ServiceProviderInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1221_3 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_128_3 D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_3_TS278A3 C_C035_ProviderSpecialtyInformation_3_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1221_3 {
        AS,
        OP,
        OR,
        OT,
        PC,
        PE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C035_ProviderSpecialtyInformation_3_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C03501_ProviderSpecialtyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C03502_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C03503_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010FB {
    [XmlElement(Order=0)]
    public S_NM1_AdditionalServiceInformationContactName_TS278A3 S_NM1_AdditionalServiceInformationContactName_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public S_N3_AdditionalServiceInformationContactAddress_TS278A3 S_N3_AdditionalServiceInformationContactAddress_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_AdditionalServiceInformationContactCity_State_ZIPCode_TS278A3 S_N4_AdditionalServiceInformationContactCity_State_ZIPCode_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_PER_AdditionalServiceInformationContactInformation_TS278A3 S_PER_AdditionalServiceInformationContactInformation_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AdditionalServiceInformationContactName_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98_7 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ResponseContactLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ResponseContactFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ResponseContactMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ResponseContactNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ResponseContactIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_AdditionalServiceInformationContactAddress_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N301_ResponseContactAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ResponseContactAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_AdditionalServiceInformationContactCity_State_ZIPCode_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N401_AdditionalServiceInformationContactCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_AdditionalServiceInformationContactCityName {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_AdditionalServiceInformationContactCityName {get; set;}
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
    public class S_PER_AdditionalServiceInformationContactInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_ResponseContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_ResponseContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_ResponseContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_ResponseContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel_TS278A3 S_HL_DependentLevel_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A3_2010D G_TS278A3_2010D {get; set;}
    [XmlElement("G_TS278A3_2000E",Order=2)]
    public List<G_TS278A3_2000E> G_TS278A3_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_DependentLevel_TS278A3 {
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
    public class G_TS278A3_2010D {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS278A3 S_NM1_DependentName_TS278A3 {get; set;}
    [XmlElement("S_REF_DependentSupplementalIdentification_TS278A3",Order=1)]
    public List<S_REF_DependentSupplementalIdentification_TS278A3> S_REF_DependentSupplementalIdentification_TS278A3 {get; set;}
    [XmlElement(Order=2)]
    public S_N3_DependentAddress_TS278A3 S_N3_DependentAddress_TS278A3 {get; set;}
    [XmlElement(Order=3)]
    public S_N4_DependentCity_State_ZIPCode_TS278A3 S_N4_DependentCity_State_ZIPCode_TS278A3 {get; set;}
    [XmlElement("S_AAA_DependentRequestValidation_TS278A3",Order=4)]
    public List<S_AAA_DependentRequestValidation_TS278A3> S_AAA_DependentRequestValidation_TS278A3 {get; set;}
    [XmlElement(Order=5)]
    public S_DMG_DependentDemographicInformation_TS278A3 S_DMG_DependentDemographicInformation_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public S_INS_DependentRelationship_TS278A3 S_INS_DependentRelationship_TS278A3 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_DependentLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_DependentFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_DependentMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_DependentNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_DependentPrimaryIdentifier {get; set;}
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
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentSupplementalIdentification_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3_TS278A3 C_C040_ReferenceIdentifier_3_TS278A3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
        EJ,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_3_TS278A3 {
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
    public class S_N3_DependentAddress_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N301_DependentAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_DependentAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_DependentCity_State_ZIPCode_TS278A3 {
    [XmlElement(Order=0)]
    public string D_N401_DependentCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_DependentStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_DependentPostalZoneorZIPCode {get; set;}
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
    public class S_AAA_DependentRequestValidation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_DependentDemographicInformation_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1250 D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_DependentBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_DependentGenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04_MaritalStatusCode {get; set;}
    [XmlElement("C_C056_CompositeRaceorEthnicityInformation_2_TS278A3",Order=4)]
    public List<C_C056_CompositeRaceorEthnicityInformation_2_TS278A3> C_C056_CompositeRaceorEthnicityInformation_2_TS278A3 {get; set;}
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
    public class C_C056_CompositeRaceorEthnicityInformation_2_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C05601_RaceorEthnicityCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05602_CodeListQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05603_IndustryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_DependentRelationship_TS278A3 {
    [XmlElement(Order=0)]
    public X12_ID_1073_2 D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1069_2 D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05_BenefitStatusCode {get; set;}
    [XmlElement(Order=5)]
    public C_C052_MedicareStatusCode_2_TS278A3 C_C052_MedicareStatusCode_2_TS278A3 {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07_ConsolidatedOmnibusBudgetReconciliationAct_COBRA_QualifyingEventCode {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09_StudentStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10_Yes_NoConditionorResponseCode {get; set;}
    [XmlElement(Order=10)]
    public string D_INS11_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=11)]
    public string D_INS12_DateTimePeriod {get; set;}
    [XmlElement(Order=12)]
    public string D_INS13_ConfidentialityCode {get; set;}
    [XmlElement(Order=13)]
    public string D_INS14_CityName {get; set;}
    [XmlElement(Order=14)]
    public string D_INS15_StateorProvinceCode {get; set;}
    [XmlElement(Order=15)]
    public string D_INS16_CountryCode {get; set;}
    [XmlElement(Order=16)]
    public string D_INS17_BirthSequenceNumber {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1069_2 {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("19")]
        Item19,
        G8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C052_MedicareStatusCode_2_TS278A3 {
    [XmlElement(Order=0)]
    public string D_C05201_MedicarePlanCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05202_EligibilityReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05203_EligibilityReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C05204_EligibilityReasonCode {get; set;}
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
    public class U_TS278A1_2010EA {
    [XmlElement("G_TS278A1_2010EA",Order=0)]
    public List<G_TS278A1_2010EA> G_TS278A1_2010EA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS278A1_2010EB {
    [XmlElement("G_TS278A1_2010EB",Order=0)]
    public List<G_TS278A1_2010EB> G_TS278A1_2010EB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS278A1_2010EC {
    [XmlElement("G_TS278A1_2010EC",Order=0)]
    public List<G_TS278A1_2010EC> G_TS278A1_2010EC {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS278A3_2010EA {
    [XmlElement("G_TS278A3_2010EA",Order=0)]
    public List<G_TS278A3_2010EA> G_TS278A3_2010EA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS278A3_2010EC {
    [XmlElement("G_TS278A3_2010EC",Order=0)]
    public List<G_TS278A3_2010EC> G_TS278A3_2010EC {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS278A3_2010FA {
    [XmlElement("G_TS278A3_2010FA",Order=0)]
    public List<G_TS278A3_2010FA> G_TS278A3_2010FA {get; set;}
    }
}
