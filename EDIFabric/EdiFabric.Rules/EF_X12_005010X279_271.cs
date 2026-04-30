namespace EdiFabric.Rules.X12005010X279271 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_271 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningofHierarchicalTransaction S_BHT_BeginningofHierarchicalTransaction {get; set;}
    [XmlElement("G_TS271_2000A",Order=2)]
    public List<G_TS271_2000A> G_TS271_2000A {get; set;}
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
        [XmlEnum("271")]
        Item271,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BHT_BeginningofHierarchicalTransaction {
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
        [XmlEnum("0022")]
        Item0022,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_353 {
        [XmlEnum("06")]
        Item06,
        [XmlEnum("11")]
        Item11,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2000A {
    [XmlElement(Order=0)]
    public S_HL_InformationSourceLevel S_HL_InformationSourceLevel {get; set;}
    [XmlElement("S_AAA_RequestValidation",Order=1)]
    public List<S_AAA_RequestValidation> S_AAA_RequestValidation {get; set;}
    [XmlElement(Order=2)]
    public G_TS271_2100A G_TS271_2100A {get; set;}
    [XmlElement("G_TS271_2000B",Order=3)]
    public List<G_TS271_2000B> G_TS271_2000B {get; set;}
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
    public class S_AAA_RequestValidation {
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
    public class G_TS271_2100A {
    [XmlElement(Order=0)]
    public S_NM1_InformationSourceName S_NM1_InformationSourceName {get; set;}
    [XmlElement("S_PER_InformationSourceContactInformation",Order=1)]
    public List<S_PER_InformationSourceContactInformation> S_PER_InformationSourceContactInformation {get; set;}
    [XmlElement("S_AAA_RequestValidation_2",Order=2)]
    public List<S_AAA_RequestValidation_2> S_AAA_RequestValidation_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationSourceName {
    [XmlElement(Order=0)]
    public X12_ID_98 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_InformationSourceLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_InformationSourceFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_InformationSourceMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_InformationSourceNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_InformationSourcePrimaryIdentifier {get; set;}
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
        GP,
        P5,
        PR,
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
    public class S_PER_InformationSourceContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_InformationSourceContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_InformationSourceCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_InformationSourceCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_InformationSourceCommunicationNumber {get; set;}
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
    public class S_AAA_RequestValidation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1073 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2000B {
    [XmlElement(Order=0)]
    public S_HL_InformationReceiverLevel S_HL_InformationReceiverLevel {get; set;}
    [XmlElement(Order=1)]
    public G_TS271_2100B G_TS271_2100B {get; set;}
    [XmlElement("G_TS271_2000C",Order=2)]
    public List<G_TS271_2000C> G_TS271_2000C {get; set;}
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
    public class G_TS271_2100B {
    [XmlElement(Order=0)]
    public S_NM1_InformationReceiverName S_NM1_InformationReceiverName {get; set;}
    [XmlElement("S_REF_InformationReceiverAdditionalIdentification",Order=1)]
    public List<S_REF_InformationReceiverAdditionalIdentification> S_REF_InformationReceiverAdditionalIdentification {get; set;}
    [XmlElement("S_AAA_InformationReceiverRequestValidation",Order=2)]
    public List<S_AAA_InformationReceiverRequestValidation> S_AAA_InformationReceiverRequestValidation {get; set;}
    [XmlElement(Order=3)]
    public S_PRV_InformationReceiverProviderInformation S_PRV_InformationReceiverProviderInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationReceiverName {
    [XmlElement(Order=0)]
    public X12_ID_98_3 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
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
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InformationReceiverAdditionalIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InformationReceiverAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_InformationReceiverAdditionalIdentifierState {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier C_C040_ReferenceIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128 {
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
    public class S_AAA_InformationReceiverRequestValidation {
    [XmlElement(Order=0)]
    public X12_ID_1073 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_InformationReceiverProviderInformation {
    [XmlElement(Order=0)]
    public X12_ID_1221 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ReceiverProviderSpecialtyCode {get; set;}
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
    public class G_TS271_2000C {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel S_HL_SubscriberLevel {get; set;}
    [XmlElement("S_TRN_SubscriberTraceNumber",Order=1)]
    public List<S_TRN_SubscriberTraceNumber> S_TRN_SubscriberTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public G_TS271_2100C G_TS271_2100C {get; set;}
    [XmlElement("G_TS271_2000D",Order=3)]
    public List<G_TS271_2000D> G_TS271_2000D {get; set;}
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
    public class S_TRN_SubscriberTraceNumber {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_TraceNumber {get; set;}
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
    public class G_TS271_2100C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName S_NM1_SubscriberName {get; set;}
    [XmlElement("S_REF_SubscriberAdditionalIdentification",Order=1)]
    public List<S_REF_SubscriberAdditionalIdentification> S_REF_SubscriberAdditionalIdentification {get; set;}
    [XmlElement(Order=2)]
    public S_N3_SubscriberAddress S_N3_SubscriberAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_SubscriberCity_State_ZIPCode S_N4_SubscriberCity_State_ZIPCode {get; set;}
    [XmlElement("S_AAA_SubscriberRequestValidation",Order=4)]
    public List<S_AAA_SubscriberRequestValidation> S_AAA_SubscriberRequestValidation {get; set;}
    [XmlElement(Order=5)]
    public S_PRV_ProviderInformation S_PRV_ProviderInformation {get; set;}
    [XmlElement(Order=6)]
    public S_DMG_SubscriberDemographicInformation S_DMG_SubscriberDemographicInformation {get; set;}
    [XmlElement(Order=7)]
    public S_INS_SubscriberRelationship S_INS_SubscriberRelationship {get; set;}
    [XmlElement(Order=8)]
    public S_HI_SubscriberHealthCareDiagnosisCode S_HI_SubscriberHealthCareDiagnosisCode {get; set;}
    [XmlElement("S_DTP_SubscriberDate",Order=9)]
    public List<S_DTP_SubscriberDate> S_DTP_SubscriberDate {get; set;}
    [XmlElement(Order=10)]
    public S_MPI_SubscriberMilitaryPersonnelInformation S_MPI_SubscriberMilitaryPersonnelInformation {get; set;}
    [XmlElement("G_TS271_2110C",Order=11)]
    public List<G_TS271_2110C> G_TS271_2110C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName {
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
    public class S_REF_SubscriberAdditionalIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Plan_GrouporPlanNetworkName {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2 C_C040_ReferenceIdentifier_2 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        [XmlEnum("18")]
        Item18,
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("3H")]
        Item3H,
        [XmlEnum("49")]
        Item49,
        [XmlEnum("6P")]
        Item6P,
        CT,
        EA,
        EJ,
        F6,
        GH,
        HJ,
        IF,
        IG,
        N6,
        NQ,
        Q4,
        SY,
        Y4,
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
    public string D_N404_SubscriberCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_SubscriberCountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_SubscriberRequestValidation {
    [XmlElement(Order=0)]
    public X12_ID_1073 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ProviderInformation {
    [XmlElement(Order=0)]
    public X12_ID_1221_2 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderIdentifier {get; set;}
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
        SK,
        SU,
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
    public class S_DMG_SubscriberDemographicInformation {
    [XmlElement(Order=0)]
    public string D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public class S_INS_SubscriberRelationship {
    [XmlElement(Order=0)]
    public X12_ID_1073_3 D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1069 D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05_BenefitStatusCode {get; set;}
    [XmlElement(Order=5)]
    public C_C052_MedicareStatusCode C_C052_MedicareStatusCode {get; set;}
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
    public enum X12_ID_1073_3 {
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
    public class C_C052_MedicareStatusCode {
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
    public class S_HI_SubscriberHealthCareDiagnosisCode {
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
    public C_C022_Diagnosis C_C022_Diagnosis {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_9 C_C022_HealthCareCodeInformation_9 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_10 C_C022_HealthCareCodeInformation_10 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_11 C_C022_HealthCareCodeInformation_11 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation {
    [XmlElement(Order=0)]
    public X12_ID_1270_2 D_C02201_DiagnosisTypeCode {get; set;}
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
    public enum X12_ID_1270_2 {
        ABK,
        BK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1270_3 D_C02201_DiagnosisTypeCode {get; set;}
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
    public enum X12_ID_1270_3 {
        ABF,
        BF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_3 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_6 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_7 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_8 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public class C_C022_Diagnosis {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public class S_DTP_SubscriberDate {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374 {
        [XmlEnum("096")]
        Item096,
        [XmlEnum("102")]
        Item102,
        [XmlEnum("152")]
        Item152,
        [XmlEnum("291")]
        Item291,
        [XmlEnum("307")]
        Item307,
        [XmlEnum("318")]
        Item318,
        [XmlEnum("340")]
        Item340,
        [XmlEnum("341")]
        Item341,
        [XmlEnum("342")]
        Item342,
        [XmlEnum("343")]
        Item343,
        [XmlEnum("346")]
        Item346,
        [XmlEnum("347")]
        Item347,
        [XmlEnum("356")]
        Item356,
        [XmlEnum("357")]
        Item357,
        [XmlEnum("382")]
        Item382,
        [XmlEnum("435")]
        Item435,
        [XmlEnum("442")]
        Item442,
        [XmlEnum("458")]
        Item458,
        [XmlEnum("472")]
        Item472,
        [XmlEnum("539")]
        Item539,
        [XmlEnum("540")]
        Item540,
        [XmlEnum("636")]
        Item636,
        [XmlEnum("771")]
        Item771,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250_3 {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MPI_SubscriberMilitaryPersonnelInformation {
    [XmlElement(Order=0)]
    public X12_ID_1201 D_MPI01_InformationStatusCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_584_2 D_MPI02_EmploymentStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_MPI03_GovernmentServiceAffiliationCode {get; set;}
    [XmlElement(Order=3)]
    public string D_MPI04_Description {get; set;}
    [XmlElement(Order=4)]
    public string D_MPI05_MilitaryServiceRankCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MPI06_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_MPI07_DateTimePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1201 {
        A,
        C,
        L,
        O,
        P,
        S,
        T,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_584_2 {
        AE,
        AO,
        AS,
        AT,
        AU,
        CC,
        DD,
        HD,
        IR,
        LX,
        PE,
        RE,
        RM,
        RR,
        RU,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2110C {
    [XmlElement(Order=0)]
    public S_EB_SubscriberEligibilityorBenefitInformation S_EB_SubscriberEligibilityorBenefitInformation {get; set;}
    [XmlElement("S_HSD_HealthCareServicesDelivery",Order=1)]
    public List<S_HSD_HealthCareServicesDelivery> S_HSD_HealthCareServicesDelivery {get; set;}
    [XmlElement("S_REF_SubscriberAdditionalIdentification_2",Order=2)]
    public List<S_REF_SubscriberAdditionalIdentification_2> S_REF_SubscriberAdditionalIdentification_2 {get; set;}
    [XmlElement("S_DTP_SubscriberEligibility_BenefitDate",Order=3)]
    public List<S_DTP_SubscriberEligibility_BenefitDate> S_DTP_SubscriberEligibility_BenefitDate {get; set;}
    [XmlElement("S_AAA_SubscriberRequestValidation_2",Order=4)]
    public List<S_AAA_SubscriberRequestValidation_2> S_AAA_SubscriberRequestValidation_2 {get; set;}
    [XmlElement("S_MSG_MessageText",Order=5)]
    public List<S_MSG_MessageText> S_MSG_MessageText {get; set;}
    [XmlElement("G_TS271_2115C",Order=6)]
    public List<G_TS271_2115C> G_TS271_2115C {get; set;}
    [XmlElement(Order=7)]
    public G_TS271_LS G_TS271_LS {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_EB_SubscriberEligibilityorBenefitInformation {
    [XmlElement(Order=0)]
    public X12_ID_1390 D_EB01_EligibilityorBenefitInformation {get; set;}
    [XmlElement(Order=1)]
    public string D_EB02_BenefitCoverageLevelCode {get; set;}
    [XmlElement("D_EB03_ServiceTypeCode",Order=2)]
    public List<string> D_EB03_ServiceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_EB04_InsuranceTypeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_EB05_PlanCoverageDescription {get; set;}
    [XmlElement(Order=5)]
    public string D_EB06_TimePeriodQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_EB07_BenefitAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_EB08_BenefitPercent {get; set;}
    [XmlElement(Order=8)]
    public string D_EB09_QuantityQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_EB10_BenefitQuantity {get; set;}
    [XmlElement(Order=10)]
    public string D_EB11_AuthorizationorCertificationIndicator {get; set;}
    [XmlElement(Order=11)]
    public string D_EB12_InPlanNetworkIndicator {get; set;}
    [XmlElement(Order=12)]
    public C_C003_CompositeMedicalProcedureIdentifier C_C003_CompositeMedicalProcedureIdentifier {get; set;}
    [XmlElement(Order=13)]
    public C_C004_CompositeDiagnosisCodePointer C_C004_CompositeDiagnosisCodePointer {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1390 {
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
        A,
        B,
        C,
        CB,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        MC,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier {
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
    public string D_C00307_Description {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308_ProductorServiceID {get; set;}
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
    public class S_HSD_HealthCareServicesDelivery {
    [XmlElement(Order=0)]
    public string D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_BenefitQuantity {get; set;}
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
    public class S_REF_SubscriberAdditionalIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberEligibilityorBenefitIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Plan_GrouporPlanNetworkName {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3 C_C040_ReferenceIdentifier_3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
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
        [XmlEnum("9F")]
        Item9F,
        ALS,
        CLI,
        F6,
        FO,
        G1,
        IG,
        M7,
        N6,
        NQ,
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
    public class S_DTP_SubscriberEligibility_BenefitDate {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EligibilityorBenefitDateTimePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_2 {
        [XmlEnum("096")]
        Item096,
        [XmlEnum("193")]
        Item193,
        [XmlEnum("194")]
        Item194,
        [XmlEnum("198")]
        Item198,
        [XmlEnum("290")]
        Item290,
        [XmlEnum("291")]
        Item291,
        [XmlEnum("292")]
        Item292,
        [XmlEnum("295")]
        Item295,
        [XmlEnum("304")]
        Item304,
        [XmlEnum("307")]
        Item307,
        [XmlEnum("318")]
        Item318,
        [XmlEnum("346")]
        Item346,
        [XmlEnum("348")]
        Item348,
        [XmlEnum("349")]
        Item349,
        [XmlEnum("356")]
        Item356,
        [XmlEnum("357")]
        Item357,
        [XmlEnum("435")]
        Item435,
        [XmlEnum("472")]
        Item472,
        [XmlEnum("636")]
        Item636,
        [XmlEnum("771")]
        Item771,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_SubscriberRequestValidation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1073 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MSG_MessageText {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02_PrinterCarriageControlCode {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03_Number {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2115C {
    [XmlElement(Order=0)]
    public S_III_SubscriberEligibilityorBenefitAdditionalInformation S_III_SubscriberEligibilityorBenefitAdditionalInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_III_SubscriberEligibilityorBenefitAdditionalInformation {
    [XmlElement(Order=0)]
    public string D_III01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_III02_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_III03_CodeCategory {get; set;}
    [XmlElement(Order=3)]
    public string D_III04_InjuredBodyPartName {get; set;}
    [XmlElement(Order=4)]
    public string D_III05_Quantity {get; set;}
    [XmlElement(Order=5)]
    public C_C001_CompositeUnitofMeasure C_C001_CompositeUnitofMeasure {get; set;}
    [XmlElement(Order=6)]
    public string D_III07_Surface_Layer_PositionCode {get; set;}
    [XmlElement(Order=7)]
    public string D_III08_Surface_Layer_PositionCode {get; set;}
    [XmlElement(Order=8)]
    public string D_III09_Surface_Layer_PositionCode {get; set;}
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
    public class G_TS271_LS {
    [XmlElement(Order=0)]
    public S_LS_Header S_LS_Header {get; set;}
    [XmlElement("G_TS271_2120C",Order=1)]
    public List<G_TS271_2120C> G_TS271_2120C {get; set;}
    [XmlElement(Order=2)]
    public S_LE_Trailer S_LE_Trailer {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LS_Header {
    [XmlElement(Order=0)]
    public string D_LS01_IdentifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2120C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberBenefitRelatedEntityName S_NM1_SubscriberBenefitRelatedEntityName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_SubscriberBenefitRelatedEntityAddress S_N3_SubscriberBenefitRelatedEntityAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_SubscriberBenefitRelatedEntityCity_State_ZIPCode S_N4_SubscriberBenefitRelatedEntityCity_State_ZIPCode {get; set;}
    [XmlElement("S_PER_SubscriberBenefitRelatedEntityContactInformation",Order=3)]
    public List<S_PER_SubscriberBenefitRelatedEntityContactInformation> S_PER_SubscriberBenefitRelatedEntityContactInformation {get; set;}
    [XmlElement(Order=4)]
    public S_PRV_SubscriberBenefitRelatedProviderInformation S_PRV_SubscriberBenefitRelatedProviderInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberBenefitRelatedEntityName {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_BenefitRelatedEntityLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_BenefitRelatedEntityFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_BenefitRelatedEntityMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_BenefitRelatedEntityNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_BenefitRelatedEntityIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_BenefitRelatedEntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_5 {
        [XmlEnum("13")]
        Item13,
        [XmlEnum("1I")]
        Item1I,
        [XmlEnum("1P")]
        Item1P,
        [XmlEnum("2B")]
        Item2B,
        [XmlEnum("36")]
        Item36,
        [XmlEnum("73")]
        Item73,
        FA,
        GP,
        GW,
        I3,
        IL,
        LR,
        OC,
        P3,
        P4,
        P5,
        PR,
        PRP,
        SEP,
        TTP,
        VN,
        VY,
        X3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_SubscriberBenefitRelatedEntityAddress {
    [XmlElement(Order=0)]
    public string D_N301_BenefitRelatedEntityAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_BenefitRelatedEntityAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberBenefitRelatedEntityCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_BenefitRelatedEntityCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_BenefitRelatedEntityStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_BenefitRelatedEntityPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_BenefitRelatedEntityCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_BenefitRelatedEntityLocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_BenefitRelatedEntityDODHealthServiceRegion {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_BenefitRelatedEntityCountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_SubscriberBenefitRelatedEntityContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_BenefitRelatedEntityContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_BenefitRelatedEntityCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_BenefitRelatedEntityCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_BenefitRelatedEntityCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_SubscriberBenefitRelatedProviderInformation {
    [XmlElement(Order=0)]
    public X12_ID_1221 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderIdentifier {get; set;}
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
    public class S_LE_Trailer {
    [XmlElement(Order=0)]
    public string D_LE01_IdentifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2000D {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel S_HL_DependentLevel {get; set;}
    [XmlElement("S_TRN_DependentTraceNumber",Order=1)]
    public List<S_TRN_DependentTraceNumber> S_TRN_DependentTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public G_TS271_2100D G_TS271_2100D {get; set;}
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
    public class S_TRN_DependentTraceNumber {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_TraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2100D {
    [XmlElement(Order=0)]
    public S_NM1_DependentName S_NM1_DependentName {get; set;}
    [XmlElement("S_REF_DependentAdditionalIdentification",Order=1)]
    public List<S_REF_DependentAdditionalIdentification> S_REF_DependentAdditionalIdentification {get; set;}
    [XmlElement(Order=2)]
    public S_N3_DependentAddress S_N3_DependentAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_DependentCity_State_ZIPCode S_N4_DependentCity_State_ZIPCode {get; set;}
    [XmlElement("S_AAA_DependentRequestValidation",Order=4)]
    public List<S_AAA_DependentRequestValidation> S_AAA_DependentRequestValidation {get; set;}
    [XmlElement(Order=5)]
    public S_PRV_ProviderInformation_2 S_PRV_ProviderInformation_2 {get; set;}
    [XmlElement(Order=6)]
    public S_DMG_DependentDemographicInformation S_DMG_DependentDemographicInformation {get; set;}
    [XmlElement(Order=7)]
    public S_INS_DependentRelationship S_INS_DependentRelationship {get; set;}
    [XmlElement(Order=8)]
    public S_HI_DependentHealthCareDiagnosisCode S_HI_DependentHealthCareDiagnosisCode {get; set;}
    [XmlElement("S_DTP_DependentDate",Order=9)]
    public List<S_DTP_DependentDate> S_DTP_DependentDate {get; set;}
    [XmlElement(Order=10)]
    public S_MPI_DependentMilitaryPersonnelInformation S_MPI_DependentMilitaryPersonnelInformation {get; set;}
    [XmlElement("G_TS271_2110D",Order=11)]
    public List<G_TS271_2110D> G_TS271_2110D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName {
    [XmlElement(Order=0)]
    public X12_ID_98_6 D_NM101_EntityIdentifierCode {get; set;}
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
    public enum X12_ID_98_6 {
        [XmlEnum("03")]
        Item03,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentAdditionalIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Plan_GrouporPlanNetworkName {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4 C_C040_ReferenceIdentifier_4 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        [XmlEnum("18")]
        Item18,
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("49")]
        Item49,
        [XmlEnum("6P")]
        Item6P,
        CT,
        EA,
        EJ,
        F6,
        GH,
        HJ,
        IF,
        IG,
        MRC,
        N6,
        NQ,
        Q4,
        SY,
        Y4,
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
    public class S_N3_DependentAddress {
    [XmlElement(Order=0)]
    public string D_N301_DependentAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_DependentAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_DependentCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_DependentCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_DependentStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_DependentPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_DependentCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentifier {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_DependentCountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_DependentRequestValidation {
    [XmlElement(Order=0)]
    public X12_ID_1073 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ProviderInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1221_3 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04_StateorProvinceCode {get; set;}
    [XmlElement(Order=4)]
    public C_C035_ProviderSpecialtyInformation_4 C_C035_ProviderSpecialtyInformation_4 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06_ProviderOrganizationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1221_3 {
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
        SK,
        SU,
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
    public class S_DMG_DependentDemographicInformation {
    [XmlElement(Order=0)]
    public string D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_DependentBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_DependentGenderCode {get; set;}
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
    public class S_INS_DependentRelationship {
    [XmlElement(Order=0)]
    public X12_ID_1073_5 D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1069_2 D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05_BenefitStatusCode {get; set;}
    [XmlElement(Order=5)]
    public C_C052_MedicareStatusCode_2 C_C052_MedicareStatusCode_2 {get; set;}
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
    public enum X12_ID_1073_5 {
        N,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1069_2 {
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
    public class C_C052_MedicareStatusCode_2 {
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
    public class S_HI_DependentHealthCareDiagnosisCode {
    [XmlElement(Order=0)]
    public C_C022_HealthCareCodeInformation_12 C_C022_HealthCareCodeInformation_12 {get; set;}
    [XmlElement(Order=1)]
    public C_C022_HealthCareCodeInformation_13 C_C022_HealthCareCodeInformation_13 {get; set;}
    [XmlElement(Order=2)]
    public C_C022_HealthCareCodeInformation_14 C_C022_HealthCareCodeInformation_14 {get; set;}
    [XmlElement(Order=3)]
    public C_C022_HealthCareCodeInformation_15 C_C022_HealthCareCodeInformation_15 {get; set;}
    [XmlElement(Order=4)]
    public C_C022_HealthCareCodeInformation_16 C_C022_HealthCareCodeInformation_16 {get; set;}
    [XmlElement(Order=5)]
    public C_C022_HealthCareCodeInformation_17 C_C022_HealthCareCodeInformation_17 {get; set;}
    [XmlElement(Order=6)]
    public C_C022_HealthCareCodeInformation_18 C_C022_HealthCareCodeInformation_18 {get; set;}
    [XmlElement(Order=7)]
    public C_C022_HealthCareCodeInformation_19 C_C022_HealthCareCodeInformation_19 {get; set;}
    [XmlElement(Order=8)]
    public C_C022_HealthCareCodeInformation_20 C_C022_HealthCareCodeInformation_20 {get; set;}
    [XmlElement(Order=9)]
    public C_C022_HealthCareCodeInformation_21 C_C022_HealthCareCodeInformation_21 {get; set;}
    [XmlElement(Order=10)]
    public C_C022_HealthCareCodeInformation_22 C_C022_HealthCareCodeInformation_22 {get; set;}
    [XmlElement(Order=11)]
    public C_C022_HealthCareCodeInformation_23 C_C022_HealthCareCodeInformation_23 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C022_HealthCareCodeInformation_12 {
    [XmlElement(Order=0)]
    public X12_ID_1270_2 D_C02201_DiagnosisTypeCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_13 {
    [XmlElement(Order=0)]
    public X12_ID_1270_3 D_C02201_DiagnosisTypeCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_14 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_18 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public class C_C022_HealthCareCodeInformation_19 {
    [XmlElement(Order=0)]
    public string D_C02201_DiagnosisTypeCode {get; set;}
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
    public class S_DTP_DependentDate {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MPI_DependentMilitaryPersonnelInformation {
    [XmlElement(Order=0)]
    public X12_ID_1201 D_MPI01_InformationStatusCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_584_2 D_MPI02_EmploymentStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_MPI03_GovernmentServiceAffiliationCode {get; set;}
    [XmlElement(Order=3)]
    public string D_MPI04_Description {get; set;}
    [XmlElement(Order=4)]
    public string D_MPI05_MilitaryServiceRankCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MPI06_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_MPI07_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2110D {
    [XmlElement(Order=0)]
    public S_EB_DependentEligibilityorBenefitInformation S_EB_DependentEligibilityorBenefitInformation {get; set;}
    [XmlElement("S_HSD_HealthCareServicesDelivery_2",Order=1)]
    public List<S_HSD_HealthCareServicesDelivery_2> S_HSD_HealthCareServicesDelivery_2 {get; set;}
    [XmlElement("S_REF_DependentAdditionalIdentification_2",Order=2)]
    public List<S_REF_DependentAdditionalIdentification_2> S_REF_DependentAdditionalIdentification_2 {get; set;}
    [XmlElement("S_DTP_DependentEligibility_BenefitDate",Order=3)]
    public List<S_DTP_DependentEligibility_BenefitDate> S_DTP_DependentEligibility_BenefitDate {get; set;}
    [XmlElement("S_AAA_DependentRequestValidation_2",Order=4)]
    public List<S_AAA_DependentRequestValidation_2> S_AAA_DependentRequestValidation_2 {get; set;}
    [XmlElement("S_MSG_MessageText_2",Order=5)]
    public List<S_MSG_MessageText_2> S_MSG_MessageText_2 {get; set;}
    [XmlElement("G_TS271_2115D",Order=6)]
    public List<G_TS271_2115D> G_TS271_2115D {get; set;}
    [XmlElement(Order=7)]
    public G_TS271_LS_1 G_TS271_LS_1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_EB_DependentEligibilityorBenefitInformation {
    [XmlElement(Order=0)]
    public X12_ID_1390 D_EB01_EligibilityorBenefitInformation {get; set;}
    [XmlElement(Order=1)]
    public string D_EB02_BenefitCoverageLevelCode {get; set;}
    [XmlElement("D_EB03_ServiceTypeCode",Order=2)]
    public List<string> D_EB03_ServiceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_EB04_InsuranceTypeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_EB05_PlanCoverageDescription {get; set;}
    [XmlElement(Order=5)]
    public string D_EB06_TimePeriodQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_EB07_BenefitAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_EB08_BenefitPercent {get; set;}
    [XmlElement(Order=8)]
    public string D_EB09_QuantityQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_EB10_BenefitQuantity {get; set;}
    [XmlElement(Order=10)]
    public string D_EB11_AuthorizationorCertificationIndicator {get; set;}
    [XmlElement(Order=11)]
    public string D_EB12_InPlanNetworkIndicator {get; set;}
    [XmlElement(Order=12)]
    public C_C003_CompositeMedicalProcedureIdentifier_2 C_C003_CompositeMedicalProcedureIdentifier_2 {get; set;}
    [XmlElement(Order=13)]
    public C_C004_CompositeDiagnosisCodePointer_2 C_C004_CompositeDiagnosisCodePointer_2 {get; set;}
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
    public string D_C00307_Description {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308_ProductorServiceID {get; set;}
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
    public class S_HSD_HealthCareServicesDelivery_2 {
    [XmlElement(Order=0)]
    public string D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_BenefitQuantity {get; set;}
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
    public class S_REF_DependentAdditionalIdentification_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentEligibilityorBenefitIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Plan_GrouporPlanNetworkName {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5 C_C040_ReferenceIdentifier_5 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_7 {
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
        [XmlEnum("9F")]
        Item9F,
        ALS,
        CLI,
        F6,
        FO,
        G1,
        IG,
        N6,
        NQ,
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
    public class S_DTP_DependentEligibility_BenefitDate {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_3 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EligibilityorBenefitDateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_DependentRequestValidation_2 {
    [XmlElement(Order=0)]
    public X12_ID_1073 D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02_AgencyQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_Follow_upActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MSG_MessageText_2 {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02_PrinterCarriageControlCode {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03_Number {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2115D {
    [XmlElement(Order=0)]
    public S_III_DependentEligibilityorBenefitAdditionalInformation S_III_DependentEligibilityorBenefitAdditionalInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_III_DependentEligibilityorBenefitAdditionalInformation {
    [XmlElement(Order=0)]
    public string D_III01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_III02_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_III03_CodeCategory {get; set;}
    [XmlElement(Order=3)]
    public string D_III04_InjuredBodyPartName {get; set;}
    [XmlElement(Order=4)]
    public string D_III05_Quantity {get; set;}
    [XmlElement(Order=5)]
    public C_C001_CompositeUnitofMeasure_2 C_C001_CompositeUnitofMeasure_2 {get; set;}
    [XmlElement(Order=6)]
    public string D_III07_Surface_Layer_PositionCode {get; set;}
    [XmlElement(Order=7)]
    public string D_III08_Surface_Layer_PositionCode {get; set;}
    [XmlElement(Order=8)]
    public string D_III09_Surface_Layer_PositionCode {get; set;}
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
    public class G_TS271_LS_1 {
    [XmlElement(Order=0)]
    public S_LS_Header_2 S_LS_Header_2 {get; set;}
    [XmlElement("G_TS271_2120D",Order=1)]
    public List<G_TS271_2120D> G_TS271_2120D {get; set;}
    [XmlElement(Order=2)]
    public S_LE_Trailer_2 S_LE_Trailer_2 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LS_Header_2 {
    [XmlElement(Order=0)]
    public string D_LS01_IdentifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271_2120D {
    [XmlElement(Order=0)]
    public S_NM1_DependentBenefitRelatedEntityName S_NM1_DependentBenefitRelatedEntityName {get; set;}
    [XmlElement(Order=1)]
    public S_N3_DependentBenefitRelatedEntityAddress S_N3_DependentBenefitRelatedEntityAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_DependentBenefitRelatedEntityCity_State_ZIPCode S_N4_DependentBenefitRelatedEntityCity_State_ZIPCode {get; set;}
    [XmlElement("S_PER_DependentBenefitRelatedEntityContactInformation",Order=3)]
    public List<S_PER_DependentBenefitRelatedEntityContactInformation> S_PER_DependentBenefitRelatedEntityContactInformation {get; set;}
    [XmlElement(Order=4)]
    public S_PRV_DependentBenefitRelatedProviderInformation S_PRV_DependentBenefitRelatedProviderInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentBenefitRelatedEntityName {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_BenefitRelatedEntityLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_BenefitRelatedEntityFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_BenefitRelatedEntityMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_BenefitRelatedEntityNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_BenefitRelatedEntityIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_BenefitRelatedEntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_DependentBenefitRelatedEntityAddress {
    [XmlElement(Order=0)]
    public string D_N301_BenefitRelatedEntityAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_BenefitRelatedEntityAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_DependentBenefitRelatedEntityCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_BenefitRelatedEntityCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_BenefitRelatedEntityStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_BenefitRelatedEntityPostalZoneorZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_BenefitRelatedEntityCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_BenefitRelatedEntityLocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_BenefitRelatedEntityDODHealthServiceRegion {get; set;}
    [XmlElement(Order=6)]
    public string D_N407_BenefitRelatedEntityCountrySubdivisionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_DependentBenefitRelatedEntityContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_BenefitRelatedEntityContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_BenefitRelatedEntityCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_BenefitRelatedEntityCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_BenefitRelatedEntityCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_DependentBenefitRelatedProviderInformation {
    [XmlElement(Order=0)]
    public X12_ID_1221 D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderIdentifier {get; set;}
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
    public class S_LE_Trailer_2 {
    [XmlElement(Order=0)]
    public string D_LE01_IdentifierCode {get; set;}
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
