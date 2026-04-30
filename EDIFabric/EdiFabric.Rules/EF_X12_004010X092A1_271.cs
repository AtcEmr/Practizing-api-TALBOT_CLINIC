namespace EdiFabric.Rules.X12004010X092A1271 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_271 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS271A1 S_BHT_BeginningOfHierarchicalTransaction_TS271A1 {get; set;}
    [XmlElement("G_TS271A1_2000A",Order=2)]
    public List<G_TS271A1_2000A> G_TS271A1_2000A {get; set;}
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
    public class S_BHT_BeginningOfHierarchicalTransaction_TS271A1 {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS271A1D_BHT01_HierarchicalStructureCode D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS271A1D_BHT02_TransactionSetPurposeCode D_BHT02_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BHT03_SubmitterTransactionIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_BHT04_TransactionSetCreationDate {get; set;}
    [XmlElement(Order=4)]
    public string D_BHT05_TransactionSetCreationTime {get; set;}
    [XmlElement(Order=5)]
    public string D_BHT06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS271A1D_BHT01_HierarchicalStructureCode {
        [XmlEnum("0022")]
        Item0022,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS271A1D_BHT02_TransactionSetPurposeCode {
        [XmlEnum("11")]
        Item11,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2000A {
    [XmlElement(Order=0)]
    public S_HL_InformationSourceLevel_TS271A1_2000A S_HL_InformationSourceLevel_TS271A1_2000A {get; set;}
    [XmlElement("S_AAA_RequestValidation_TS271A1_2000A",Order=1)]
    public List<S_AAA_RequestValidation_TS271A1_2000A> S_AAA_RequestValidation_TS271A1_2000A {get; set;}
    [XmlElement(Order=2)]
    public G_TS271A1_2100A G_TS271A1_2100A {get; set;}
    [XmlElement("G_TS271A1_2000B",Order=3)]
    public List<G_TS271A1_2000B> G_TS271A1_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_InformationSourceLevel_TS271A1_2000A {
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
    public class S_AAA_RequestValidation_TS271A1_2000A {
    [XmlElement(Order=0)]
    public S_AAA_RequestValidation_TS271A1_2000AD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_RequestValidation_TS271A1_2000AD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2100A {
    [XmlElement(Order=0)]
    public S_NM1_InformationSourceName_TS271A1_2100A S_NM1_InformationSourceName_TS271A1_2100A {get; set;}
    [XmlElement("S_REF_InformationSourceAdditionalIdentification_TS271A1_2100A",Order=1)]
    public List<S_REF_InformationSourceAdditionalIdentification_TS271A1_2100A> S_REF_InformationSourceAdditionalIdentification_TS271A1_2100A {get; set;}
    [XmlElement("S_PER_InformationSourceContactInformation_TS271A1_2100A",Order=2)]
    public List<S_PER_InformationSourceContactInformation_TS271A1_2100A> S_PER_InformationSourceContactInformation_TS271A1_2100A {get; set;}
    [XmlElement("S_AAA_RequestValidation_TS271A1_2100A",Order=3)]
    public List<S_AAA_RequestValidation_TS271A1_2100A> S_AAA_RequestValidation_TS271A1_2100A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationSourceName_TS271A1_2100A {
    [XmlElement(Order=0)]
    public S_NM1_InformationSourceName_TS271A1_2100AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_InformationSourceName_TS271A1_2100AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_InformationSourceName_TS271A1_2100AD_NM101_EntityIdentifierCode {
        [XmlEnum("2B")]
        Item2B,
        [XmlEnum("36")]
        Item36,
        GP,
        P5,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_InformationSourceName_TS271A1_2100AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InformationSourceAdditionalIdentification_TS271A1_2100A {
    [XmlElement(Order=0)]
    public S_REF_InformationSourceAdditionalIdentification_TS271A1_2100AD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InformationSourceAdditionalPlanIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_PlanName {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U27 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_InformationSourceAdditionalIdentification_TS271A1_2100AD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("18")]
        Item18,
        [XmlEnum("55")]
        Item55,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_InformationSourceContactInformation_TS271A1_2100A {
    [XmlElement(Order=0)]
    public S_PER_InformationSourceContactInformation_TS271A1_2100AD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_InformationSourceContactInformation_TS271A1_2100AD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_RequestValidation_TS271A1_2100A {
    [XmlElement(Order=0)]
    public S_AAA_RequestValidation_TS271A1_2100AD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_RequestValidation_TS271A1_2100AD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2000B {
    [XmlElement(Order=0)]
    public S_HL_InformationReceiverLevel_TS271A1_2000B S_HL_InformationReceiverLevel_TS271A1_2000B {get; set;}
    [XmlElement(Order=1)]
    public G_TS271A1_2100B G_TS271A1_2100B {get; set;}
    [XmlElement("G_TS271A1_2000C",Order=2)]
    public List<G_TS271A1_2000C> G_TS271A1_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_InformationReceiverLevel_TS271A1_2000B {
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
    public class G_TS271A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_InformationReceiverName_TS271A1_2100B S_NM1_InformationReceiverName_TS271A1_2100B {get; set;}
    [XmlElement("S_REF_InformationReceiverAdditionalIdentification_TS271A1_2100B",Order=1)]
    public List<S_REF_InformationReceiverAdditionalIdentification_TS271A1_2100B> S_REF_InformationReceiverAdditionalIdentification_TS271A1_2100B {get; set;}
    [XmlElement("S_AAA_InformationReceiverRequestValidation_TS271A1_2100B",Order=2)]
    public List<S_AAA_InformationReceiverRequestValidation_TS271A1_2100B> S_AAA_InformationReceiverRequestValidation_TS271A1_2100B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InformationReceiverName_TS271A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_InformationReceiverName_TS271A1_2100BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_InformationReceiverName_TS271A1_2100BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_InformationReceiverName_TS271A1_2100BD_NM101_EntityIdentifierCode {
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
    public enum S_NM1_InformationReceiverName_TS271A1_2100BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_InformationReceiverAdditionalIdentification_TS271A1_2100B {
    [XmlElement(Order=0)]
    public S_REF_InformationReceiverAdditionalIdentification_TS271A1_2100BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InformationReceiverAdditionalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_LicenseNumberStateCode {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U28 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_InformationReceiverAdditionalIdentification_TS271A1_2100BD_REF01_ReferenceIdentificationQualifier {
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
    public class S_AAA_InformationReceiverRequestValidation_TS271A1_2100B {
    [XmlElement(Order=0)]
    public S_AAA_InformationReceiverRequestValidation_TS271A1_2100BD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_InformationReceiverRequestValidation_TS271A1_2100BD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2000C {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel_TS271A1_2000C S_HL_SubscriberLevel_TS271A1_2000C {get; set;}
    [XmlElement("S_TRN_SubscriberTraceNumber_TS271A1_2000C",Order=1)]
    public List<S_TRN_SubscriberTraceNumber_TS271A1_2000C> S_TRN_SubscriberTraceNumber_TS271A1_2000C {get; set;}
    [XmlElement(Order=2)]
    public G_TS271A1_2100C G_TS271A1_2100C {get; set;}
    [XmlElement("G_TS271A1_2000D",Order=3)]
    public List<G_TS271A1_2000D> G_TS271A1_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberLevel_TS271A1_2000C {
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
    public class S_TRN_SubscriberTraceNumber_TS271A1_2000C {
    [XmlElement(Order=0)]
    public S_TRN_SubscriberTraceNumber_TS271A1_2000CD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_TraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_SubscriberTraceNumber_TS271A1_2000CD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2100C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS271A1_2100C S_NM1_SubscriberName_TS271A1_2100C {get; set;}
    [XmlElement("S_REF_SubscriberAdditionalIdentification_TS271A1_2100C",Order=1)]
    public List<S_REF_SubscriberAdditionalIdentification_TS271A1_2100C> S_REF_SubscriberAdditionalIdentification_TS271A1_2100C {get; set;}
    [XmlElement(Order=2)]
    public S_N3_SubscriberAddress_TS271A1_2100C S_N3_SubscriberAddress_TS271A1_2100C {get; set;}
    [XmlElement(Order=3)]
    public S_N4_SubscriberCityStateZIPCode_TS271A1_2100C S_N4_SubscriberCityStateZIPCode_TS271A1_2100C {get; set;}
    [XmlElement("S_PER_SubscriberContactInformation_TS271A1_2100C",Order=4)]
    public List<S_PER_SubscriberContactInformation_TS271A1_2100C> S_PER_SubscriberContactInformation_TS271A1_2100C {get; set;}
    [XmlElement("S_AAA_SubscriberRequestValidation_TS271A1_2100C",Order=5)]
    public List<S_AAA_SubscriberRequestValidation_TS271A1_2100C> S_AAA_SubscriberRequestValidation_TS271A1_2100C {get; set;}
    [XmlElement(Order=6)]
    public S_DMG_SubscriberDemographicInformation_TS271A1_2100C S_DMG_SubscriberDemographicInformation_TS271A1_2100C {get; set;}
    [XmlElement(Order=7)]
    public S_INS_SubscriberRelationship_TS271A1_2100C S_INS_SubscriberRelationship_TS271A1_2100C {get; set;}
    [XmlElement("S_DTP_SubscriberDate_TS271A1_2100C",Order=8)]
    public List<S_DTP_SubscriberDate_TS271A1_2100C> S_DTP_SubscriberDate_TS271A1_2100C {get; set;}
    [XmlElement("G_TS271A1_2110C",Order=9)]
    public List<G_TS271A1_2110C> G_TS271A1_2110C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS271A1_2100C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS271A1_2100CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubscriberName_TS271A1_2100CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public string D_NM109_SubscriberPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS271A1_2100CD_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS271A1_2100CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberAdditionalIdentification_TS271A1_2100C {
    [XmlElement(Order=0)]
    public S_REF_SubscriberAdditionalIdentification_TS271A1_2100CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_PlanSponsorName {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U29 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberAdditionalIdentification_TS271A1_2100CD_REF01_ReferenceIdentificationQualifier {
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
        A6,
        CT,
        EA,
        EJ,
        F6,
        GH,
        HJ,
        IF,
        IG,
        ML,
        N6,
        NQ,
        Q4,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_SubscriberAddress_TS271A1_2100C {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberCityStateZIPCode_TS271A1_2100C {
    [XmlElement(Order=0)]
    public string D_N401_SubscriberCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_SubscriberStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_SubscriberPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentificationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_SubscriberContactInformation_TS271A1_2100C {
    [XmlElement(Order=0)]
    public S_PER_SubscriberContactInformation_TS271A1_2100CD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_SubscriberContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_SubscriberContactNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_SubscriberContactNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_SubscriberContactNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_SubscriberContactInformation_TS271A1_2100CD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_SubscriberRequestValidation_TS271A1_2100C {
    [XmlElement(Order=0)]
    public S_AAA_SubscriberRequestValidation_TS271A1_2100CD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_SubscriberRequestValidation_TS271A1_2100CD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_SubscriberDemographicInformation_TS271A1_2100C {
    [XmlElement(Order=0)]
    public S_DMG_SubscriberDemographicInformation_TS271A1_2100CD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_SubscriberDemographicInformation_TS271A1_2100CD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_SubscriberRelationship_TS271A1_2100C {
    [XmlElement(Order=0)]
    public S_INS_SubscriberRelationship_TS271A1_2100CD_INS01_InsuredIndicator D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_INS_SubscriberRelationship_TS271A1_2100CD_INS02_IndividualRelationshipCode D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05 {get; set;}
    [XmlElement(Order=5)]
    public string D_INS06 {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07 {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08 {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09_StudentStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10_HandicapIndicator {get; set;}
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
    public enum S_INS_SubscriberRelationship_TS271A1_2100CD_INS01_InsuredIndicator {
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_SubscriberRelationship_TS271A1_2100CD_INS02_IndividualRelationshipCode {
        [XmlEnum("18")]
        Item18,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_SubscriberDate_TS271A1_2100C {
    [XmlElement(Order=0)]
    public S_DTP_SubscriberDate_TS271A1_2100CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_SubscriberDate_TS271A1_2100CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SubscriberDate_TS271A1_2100CD_DTP01_DateTimeQualifier {
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SubscriberDate_TS271A1_2100CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2110C {
    [XmlElement(Order=0)]
    public S_EB_SubscriberEligibilityOrBenefitInformation_TS271A1_2110C S_EB_SubscriberEligibilityOrBenefitInformation_TS271A1_2110C {get; set;}
    [XmlElement("S_HSD_HealthCareServicesDelivery_TS271A1_2110C",Order=1)]
    public List<S_HSD_HealthCareServicesDelivery_TS271A1_2110C> S_HSD_HealthCareServicesDelivery_TS271A1_2110C {get; set;}
    [XmlElement("S_REF_SubscriberAdditionalIdentification_TS271A1_2110C",Order=2)]
    public List<S_REF_SubscriberAdditionalIdentification_TS271A1_2110C> S_REF_SubscriberAdditionalIdentification_TS271A1_2110C {get; set;}
    [XmlElement("S_DTP_SubscriberEligibilityBenefitDate_TS271A1_2110C",Order=3)]
    public List<S_DTP_SubscriberEligibilityBenefitDate_TS271A1_2110C> S_DTP_SubscriberEligibilityBenefitDate_TS271A1_2110C {get; set;}
    [XmlElement("S_AAA_SubscriberRequestValidation_TS271A1_2110C",Order=4)]
    public List<S_AAA_SubscriberRequestValidation_TS271A1_2110C> S_AAA_SubscriberRequestValidation_TS271A1_2110C {get; set;}
    [XmlElement("S_MSG_MessageText_TS271A1_2110C",Order=5)]
    public List<S_MSG_MessageText_TS271A1_2110C> S_MSG_MessageText_TS271A1_2110C {get; set;}
    [XmlElement("G_TS271A1_2115C",Order=6)]
    public List<G_TS271A1_2115C> G_TS271A1_2115C {get; set;}
    [XmlElement(Order=7)]
    public G_LS G_LS {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_EB_SubscriberEligibilityOrBenefitInformation_TS271A1_2110C {
    [XmlElement(Order=0)]
    public S_EB_SubscriberEligibilityOrBenefitInformation_TS271A1_2110CD_EB01_EligibilityOrBenefitInformation D_EB01_EligibilityOrBenefitInformation {get; set;}
    [XmlElement(Order=1)]
    public S_EB_SubscriberEligibilityOrBenefitInformation_TS271A1_2110CD_EB02_BenefitCoverageLevelCode D_EB02_BenefitCoverageLevelCode {get; set;}
    [XmlElement(Order=2)]
    public string D_EB03_ServiceTypeCode {get; set;}
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
    public string D_EB11_AuthorizationOrCertificationIndicator {get; set;}
    [XmlElement(Order=11)]
    public string D_EB12_InPlanNetworkIndicator {get; set;}
    [XmlElement(Order=12)]
    public C_EB13_C003U30_TS271A1_2110C C_EB13_C003U30_TS271A1_2110C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_EB_SubscriberEligibilityOrBenefitInformation_TS271A1_2110CD_EB01_EligibilityOrBenefitInformation {
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
        MC,
        CB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_EB_SubscriberEligibilityOrBenefitInformation_TS271A1_2110CD_EB02_BenefitCoverageLevelCode {
        CHD,
        DEP,
        ECH,
        EMP,
        ESP,
        FAM,
        IND,
        SPC,
        SPO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_EB13_C003U30_TS271A1_2110C {
    [XmlElement(Order=0)]
    public string D_EB13_C00301U31_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_EB13_C00302U32_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_EB13_C00303U33_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_EB13_C00304U34_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_EB13_C00305U35_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_EB13_C00306U36_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_EB13_C00307U5037 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HSD_HealthCareServicesDelivery_TS271A1_2110C {
    [XmlElement(Order=0)]
    public S_HSD_HealthCareServicesDelivery_TS271A1_2110CD_HSD01_QuantityQualifier D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_BenefitQuantity {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_UnitOrBasisForMeasurementCode {get; set;}
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
    public enum S_HSD_HealthCareServicesDelivery_TS271A1_2110CD_HSD01_QuantityQualifier {
        DY,
        FL,
        HS,
        MN,
        VS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberAdditionalIdentification_TS271A1_2110C {
    [XmlElement(Order=0)]
    public S_REF_SubscriberAdditionalIdentification_TS271A1_2110CD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberEligibilityOrBenefitIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_PlanSponsorName {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U38 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberAdditionalIdentification_TS271A1_2110CD_REF01_ReferenceIdentificationQualifier {
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
        A6,
        F6,
        G1,
        IG,
        N6,
        NQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_SubscriberEligibilityBenefitDate_TS271A1_2110C {
    [XmlElement(Order=0)]
    public S_DTP_SubscriberEligibilityBenefitDate_TS271A1_2110CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_SubscriberEligibilityBenefitDate_TS271A1_2110CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EligibilityOrBenefitDateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SubscriberEligibilityBenefitDate_TS271A1_2110CD_DTP01_DateTimeQualifier {
        [XmlEnum("193")]
        Item193,
        [XmlEnum("194")]
        Item194,
        [XmlEnum("198")]
        Item198,
        [XmlEnum("290")]
        Item290,
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
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SubscriberEligibilityBenefitDate_TS271A1_2110CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_SubscriberRequestValidation_TS271A1_2110C {
    [XmlElement(Order=0)]
    public S_AAA_SubscriberRequestValidation_TS271A1_2110CD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_SubscriberRequestValidation_TS271A1_2110CD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MSG_MessageText_TS271A1_2110C {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02 {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2115C {
    [XmlElement(Order=0)]
    public S_III_SubscriberEligibilityOrBenefitAdditionalInformation_TS271A1_2115C S_III_SubscriberEligibilityOrBenefitAdditionalInformation_TS271A1_2115C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_III_SubscriberEligibilityOrBenefitAdditionalInformation_TS271A1_2115C {
    [XmlElement(Order=0)]
    public S_III_SubscriberEligibilityOrBenefitAdditionalInformation_TS271A1_2115CD_III01_CodeListQualifierCode D_III01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_III02_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_III03 {get; set;}
    [XmlElement(Order=3)]
    public string D_III04 {get; set;}
    [XmlElement(Order=4)]
    public string D_III05 {get; set;}
    [XmlElement(Order=5)]
    public string D_III06_C001U39 {get; set;}
    [XmlElement(Order=6)]
    public string D_III07 {get; set;}
    [XmlElement(Order=7)]
    public string D_III08 {get; set;}
    [XmlElement(Order=8)]
    public string D_III09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_III_SubscriberEligibilityOrBenefitAdditionalInformation_TS271A1_2115CD_III01_CodeListQualifierCode {
        BF,
        BK,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_LS {
    [XmlElement(Order=0)]
    public S_LS_Header_TS271A1_2110C S_LS_Header_TS271A1_2110C {get; set;}
    [XmlElement(Order=1)]
    public G_TS271A1_2120C G_TS271A1_2120C {get; set;}
    [XmlElement(Order=2)]
    public S_LE_Trailer_TS271A1_2110C S_LE_Trailer_TS271A1_2110C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LS_Header_TS271A1_2110C {
    [XmlElement(Order=0)]
    public string D_LS01_IdentifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2120C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberBenefitRelatedEntityName_TS271A1_2120C S_NM1_SubscriberBenefitRelatedEntityName_TS271A1_2120C {get; set;}
    [XmlElement(Order=1)]
    public S_N3_SubscriberBenefitRelatedEntityAddress_TS271A1_2120C S_N3_SubscriberBenefitRelatedEntityAddress_TS271A1_2120C {get; set;}
    [XmlElement(Order=2)]
    public S_N4_SubscriberBenefitRelatedCityStateZIPCode_TS271A1_2120C S_N4_SubscriberBenefitRelatedCityStateZIPCode_TS271A1_2120C {get; set;}
    [XmlElement("S_PER_SubscriberBenefitRelatedEntityContactInformation_TS271A1_2120C",Order=3)]
    public List<S_PER_SubscriberBenefitRelatedEntityContactInformation_TS271A1_2120C> S_PER_SubscriberBenefitRelatedEntityContactInformation_TS271A1_2120C {get; set;}
    [XmlElement(Order=4)]
    public S_PRV_SubscriberBenefitRelatedProviderInformation_TS271A1_2120C S_PRV_SubscriberBenefitRelatedProviderInformation_TS271A1_2120C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberBenefitRelatedEntityName_TS271A1_2120C {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberBenefitRelatedEntityName_TS271A1_2120CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubscriberBenefitRelatedEntityName_TS271A1_2120CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_BenefitRelatedEntityLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_BenefitRelatedEntityFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_BenefitRelatedEntityMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_BenefitRelatedEntityNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_BenefitRelatedEntityIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberBenefitRelatedEntityName_TS271A1_2120CD_NM101_EntityIdentifierCode {
        [XmlEnum("13")]
        Item13,
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
        IL,
        LR,
        P3,
        P4,
        P5,
        PR,
        SEP,
        TTP,
        VN,
        X3,
        PRP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberBenefitRelatedEntityName_TS271A1_2120CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_SubscriberBenefitRelatedEntityAddress_TS271A1_2120C {
    [XmlElement(Order=0)]
    public string D_N301_BenefitRelatedEntityAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_BenefitRelatedEntityAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_SubscriberBenefitRelatedCityStateZIPCode_TS271A1_2120C {
    [XmlElement(Order=0)]
    public string D_N401_BenefitRelatedEntityCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_BenefitRelatedEntityStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_BenefitRelatedEntityPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_DepartmentOfDefenseHealthServiceRegionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_SubscriberBenefitRelatedEntityContactInformation_TS271A1_2120C {
    [XmlElement(Order=0)]
    public S_PER_SubscriberBenefitRelatedEntityContactInformation_TS271A1_2120CD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_SubscriberBenefitRelatedEntityContactInformation_TS271A1_2120CD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_SubscriberBenefitRelatedProviderInformation_TS271A1_2120C {
    [XmlElement(Order=0)]
    public S_PRV_SubscriberBenefitRelatedProviderInformation_TS271A1_2120CD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_SubscriberBenefitRelatedProviderInformation_TS271A1_2120CD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U40 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_SubscriberBenefitRelatedProviderInformation_TS271A1_2120CD_PRV01_ProviderCode {
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
        RF,
        HH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_SubscriberBenefitRelatedProviderInformation_TS271A1_2120CD_PRV02_ReferenceIdentificationQualifier {
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
    public class S_LE_Trailer_TS271A1_2110C {
    [XmlElement(Order=0)]
    public string D_LE01_IdentifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2000D {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel_TS271A1_2000D S_HL_DependentLevel_TS271A1_2000D {get; set;}
    [XmlElement("S_TRN_DependentTraceNumber_TS271A1_2000D",Order=1)]
    public List<S_TRN_DependentTraceNumber_TS271A1_2000D> S_TRN_DependentTraceNumber_TS271A1_2000D {get; set;}
    [XmlElement(Order=2)]
    public G_TS271A1_2100D G_TS271A1_2100D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_DependentLevel_TS271A1_2000D {
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
    public class S_TRN_DependentTraceNumber_TS271A1_2000D {
    [XmlElement(Order=0)]
    public S_TRN_DependentTraceNumber_TS271A1_2000DD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_TraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_DependentTraceNumber_TS271A1_2000DD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2100D {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS271A1_2100D S_NM1_DependentName_TS271A1_2100D {get; set;}
    [XmlElement("S_REF_DependentAdditionalIdentification_TS271A1_2100D",Order=1)]
    public List<S_REF_DependentAdditionalIdentification_TS271A1_2100D> S_REF_DependentAdditionalIdentification_TS271A1_2100D {get; set;}
    [XmlElement(Order=2)]
    public S_N3_DependentAddress_TS271A1_2100D S_N3_DependentAddress_TS271A1_2100D {get; set;}
    [XmlElement(Order=3)]
    public S_N4_DependentCityStateZIPCode_TS271A1_2100D S_N4_DependentCityStateZIPCode_TS271A1_2100D {get; set;}
    [XmlElement("S_PER_DependentContactInformation_TS271A1_2100D",Order=4)]
    public List<S_PER_DependentContactInformation_TS271A1_2100D> S_PER_DependentContactInformation_TS271A1_2100D {get; set;}
    [XmlElement("S_AAA_DependentRequestValidation_TS271A1_2100D",Order=5)]
    public List<S_AAA_DependentRequestValidation_TS271A1_2100D> S_AAA_DependentRequestValidation_TS271A1_2100D {get; set;}
    [XmlElement(Order=6)]
    public S_DMG_DependentDemographicInformation_TS271A1_2100D S_DMG_DependentDemographicInformation_TS271A1_2100D {get; set;}
    [XmlElement(Order=7)]
    public S_INS_DependentRelationship_TS271A1_2100D S_INS_DependentRelationship_TS271A1_2100D {get; set;}
    [XmlElement("S_DTP_DependentDate_TS271A1_2100D",Order=8)]
    public List<S_DTP_DependentDate_TS271A1_2100D> S_DTP_DependentDate_TS271A1_2100D {get; set;}
    [XmlElement("G_TS271A1_2110D",Order=9)]
    public List<G_TS271A1_2110D> G_TS271A1_2110D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName_TS271A1_2100D {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS271A1_2100DD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_DependentName_TS271A1_2100DD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_DependentPrimaryIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_DependentName_TS271A1_2100DD_NM101_EntityIdentifierCode {
        [XmlEnum("03")]
        Item03,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_DependentName_TS271A1_2100DD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentAdditionalIdentification_TS271A1_2100D {
    [XmlElement(Order=0)]
    public S_REF_DependentAdditionalIdentification_TS271A1_2100DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_PlanSponsorName {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U41 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_DependentAdditionalIdentification_TS271A1_2100DD_REF01_ReferenceIdentificationQualifier {
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
        IF,
        IG,
        M7,
        N6,
        NQ,
        Q4,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_DependentAddress_TS271A1_2100D {
    [XmlElement(Order=0)]
    public string D_N301_DependentAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_DependentAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_DependentCityStateZIPCode_TS271A1_2100D {
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
    public class S_PER_DependentContactInformation_TS271A1_2100D {
    [XmlElement(Order=0)]
    public S_PER_DependentContactInformation_TS271A1_2100DD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_DependentContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_DependentContactNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_DependentContactNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_DependentContactNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_DependentContactInformation_TS271A1_2100DD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_DependentRequestValidation_TS271A1_2100D {
    [XmlElement(Order=0)]
    public S_AAA_DependentRequestValidation_TS271A1_2100DD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_DependentRequestValidation_TS271A1_2100DD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_DependentDemographicInformation_TS271A1_2100D {
    [XmlElement(Order=0)]
    public S_DMG_DependentDemographicInformation_TS271A1_2100DD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_DependentDemographicInformation_TS271A1_2100DD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_DependentRelationship_TS271A1_2100D {
    [XmlElement(Order=0)]
    public S_INS_DependentRelationship_TS271A1_2100DD_INS01_InsuredIndicator D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_INS_DependentRelationship_TS271A1_2100DD_INS02_IndividualRelationshipCode D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05 {get; set;}
    [XmlElement(Order=5)]
    public string D_INS06 {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07 {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08 {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09_StudentStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10_HandicapIndicator {get; set;}
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
    public enum S_INS_DependentRelationship_TS271A1_2100DD_INS01_InsuredIndicator {
        N,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_DependentRelationship_TS271A1_2100DD_INS02_IndividualRelationshipCode {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("21")]
        Item21,
        [XmlEnum("34")]
        Item34,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DependentDate_TS271A1_2100D {
    [XmlElement(Order=0)]
    public S_DTP_DependentDate_TS271A1_2100DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DependentDate_TS271A1_2100DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DependentDate_TS271A1_2100DD_DTP01_DateTimeQualifier {
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
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DependentDate_TS271A1_2100DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2110D {
    [XmlElement(Order=0)]
    public S_EB_DependentEligibilityOrBenefitInformation_TS271A1_2110D S_EB_DependentEligibilityOrBenefitInformation_TS271A1_2110D {get; set;}
    [XmlElement("S_HSD_HealthCareServicesDelivery_TS271A1_2110D",Order=1)]
    public List<S_HSD_HealthCareServicesDelivery_TS271A1_2110D> S_HSD_HealthCareServicesDelivery_TS271A1_2110D {get; set;}
    [XmlElement("S_REF_DependentAdditionalIdentification_TS271A1_2110D",Order=2)]
    public List<S_REF_DependentAdditionalIdentification_TS271A1_2110D> S_REF_DependentAdditionalIdentification_TS271A1_2110D {get; set;}
    [XmlElement("S_DTP_DependentEligibilityBenefitDate_TS271A1_2110D",Order=3)]
    public List<S_DTP_DependentEligibilityBenefitDate_TS271A1_2110D> S_DTP_DependentEligibilityBenefitDate_TS271A1_2110D {get; set;}
    [XmlElement("S_AAA_DependentRequestValidation_TS271A1_2110D",Order=4)]
    public List<S_AAA_DependentRequestValidation_TS271A1_2110D> S_AAA_DependentRequestValidation_TS271A1_2110D {get; set;}
    [XmlElement("S_MSG_MessageText_TS271A1_2110D",Order=5)]
    public List<S_MSG_MessageText_TS271A1_2110D> S_MSG_MessageText_TS271A1_2110D {get; set;}
    [XmlElement("G_TS271A1_2115D",Order=6)]
    public List<G_TS271A1_2115D> G_TS271A1_2115D {get; set;}
    [XmlElement(Order=7)]
    public G_LS G_LS {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_EB_DependentEligibilityOrBenefitInformation_TS271A1_2110D {
    [XmlElement(Order=0)]
    public S_EB_DependentEligibilityOrBenefitInformation_TS271A1_2110DD_EB01_EligibilityOrBenefitInformation D_EB01_EligibilityOrBenefitInformation {get; set;}
    [XmlElement(Order=1)]
    public S_EB_DependentEligibilityOrBenefitInformation_TS271A1_2110DD_EB02_BenefitCoverageLevelCode D_EB02_BenefitCoverageLevelCode {get; set;}
    [XmlElement(Order=2)]
    public string D_EB03_ServiceTypeCode {get; set;}
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
    public string D_EB11_AuthorizationOrCertificationIndicator {get; set;}
    [XmlElement(Order=11)]
    public string D_EB12_InPlanNetworkIndicator {get; set;}
    [XmlElement(Order=12)]
    public C_EB13_C003U42_TS271A1_2110D C_EB13_C003U42_TS271A1_2110D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_EB_DependentEligibilityOrBenefitInformation_TS271A1_2110DD_EB01_EligibilityOrBenefitInformation {
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
        CB,
        MC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_EB_DependentEligibilityOrBenefitInformation_TS271A1_2110DD_EB02_BenefitCoverageLevelCode {
        CHD,
        DEP,
        ECH,
        ESP,
        FAM,
        IND,
        SPC,
        SPO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_EB13_C003U42_TS271A1_2110D {
    [XmlElement(Order=0)]
    public string D_EB13_C00301U43_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_EB13_C00302U44_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_EB13_C00303U45_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_EB13_C00304U46_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_EB13_C00305U47_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_EB13_C00306U48_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_EB13_C00307U5049 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HSD_HealthCareServicesDelivery_TS271A1_2110D {
    [XmlElement(Order=0)]
    public S_HSD_HealthCareServicesDelivery_TS271A1_2110DD_HSD01_QuantityQualifier D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_BenefitQuantity {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_UnitOrBasisForMeasurementCode {get; set;}
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
    public enum S_HSD_HealthCareServicesDelivery_TS271A1_2110DD_HSD01_QuantityQualifier {
        DY,
        FL,
        HS,
        MN,
        VS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentAdditionalIdentification_TS271A1_2110D {
    [XmlElement(Order=0)]
    public S_REF_DependentAdditionalIdentification_TS271A1_2110DD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentEligibilityOrBenefitIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_PlanSponsorName {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U50 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_DependentAdditionalIdentification_TS271A1_2110DD_REF01_ReferenceIdentificationQualifier {
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
        A6,
        F6,
        G1,
        IG,
        N6,
        NQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DependentEligibilityBenefitDate_TS271A1_2110D {
    [XmlElement(Order=0)]
    public S_DTP_DependentEligibilityBenefitDate_TS271A1_2110DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DependentEligibilityBenefitDate_TS271A1_2110DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EligibilityOrBenefitDateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DependentEligibilityBenefitDate_TS271A1_2110DD_DTP01_DateTimeQualifier {
        [XmlEnum("193")]
        Item193,
        [XmlEnum("194")]
        Item194,
        [XmlEnum("198")]
        Item198,
        [XmlEnum("290")]
        Item290,
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
    public enum S_DTP_DependentEligibilityBenefitDate_TS271A1_2110DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_DependentRequestValidation_TS271A1_2110D {
    [XmlElement(Order=0)]
    public S_AAA_DependentRequestValidation_TS271A1_2110DD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_DependentRequestValidation_TS271A1_2110DD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MSG_MessageText_TS271A1_2110D {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02 {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS271A1_2115D {
    [XmlElement(Order=0)]
    public S_III_DependentEligibilityOrBenefitAdditionalInformation_TS271A1_2115D S_III_DependentEligibilityOrBenefitAdditionalInformation_TS271A1_2115D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_III_DependentEligibilityOrBenefitAdditionalInformation_TS271A1_2115D {
    [XmlElement(Order=0)]
    public S_III_DependentEligibilityOrBenefitAdditionalInformation_TS271A1_2115DD_III01_CodeListQualifierCode D_III01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_III02_IndustryCode {get; set;}
    [XmlElement(Order=2)]
    public string D_III03 {get; set;}
    [XmlElement(Order=3)]
    public string D_III04 {get; set;}
    [XmlElement(Order=4)]
    public string D_III05 {get; set;}
    [XmlElement(Order=5)]
    public string D_III06_C001U51 {get; set;}
    [XmlElement(Order=6)]
    public string D_III07 {get; set;}
    [XmlElement(Order=7)]
    public string D_III08 {get; set;}
    [XmlElement(Order=8)]
    public string D_III09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_III_DependentEligibilityOrBenefitAdditionalInformation_TS271A1_2115DD_III01_CodeListQualifierCode {
        BF,
        BK,
        ZZ,
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
