namespace EdiFabric.Rules.X12004010X094A1278 {
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
    public string D_ST01 {get; set;}
    [XmlElement(Order=1)]
    public string D_ST02 {get; set;}
    [XmlElement(Order=2)]
    public string D_ST03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_A1_BHT {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS278A1 S_BHT_BeginningOfHierarchicalTransaction_TS278A1 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A1_2000A G_TS278A1_2000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BHT_BeginningOfHierarchicalTransaction_TS278A1 {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS278A1D_BHT01_HierarchicalStructureCode D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS278A1D_BHT02_TransactionSetPurposeCode D_BHT02_TransactionSetPurposeCode {get; set;}
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
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS278A1D_BHT01_HierarchicalStructureCode {
        [XmlEnum("0078")]
        Item0078,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS278A1D_BHT02_TransactionSetPurposeCode {
        [XmlEnum("13")]
        Item13,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000A {
    [XmlElement(Order=0)]
    public S_HL_UtilizationManagementOrganizationUMOLevel_TS278A1_2000A S_HL_UtilizationManagementOrganizationUMOLevel_TS278A1_2000A {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A1_2010A G_TS278A1_2010A {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A1_2000B G_TS278A1_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_UtilizationManagementOrganizationUMOLevel_TS278A1_2000A {
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
    public class G_TS278A1_2010A {
    [XmlElement(Order=0)]
    public S_NM1_UtilizationManagementOrganizationUMOName_TS278A1_2010A S_NM1_UtilizationManagementOrganizationUMOName_TS278A1_2010A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_UtilizationManagementOrganizationUMOName_TS278A1_2010A {
    [XmlElement(Order=0)]
    public S_NM1_UtilizationManagementOrganizationUMOName_TS278A1_2010AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_UtilizationManagementOrganizationUMOName_TS278A1_2010AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_UtilizationManagementOrganizationUMOLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_UtilizationManagementOrganizationUMOFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_UtilizationManagementOrganizationUMOMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_UtilizationManagementOrganizationUMONameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_UtilizationManagementOrganizationUMOIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_UtilizationManagementOrganizationUMOName_TS278A1_2010AD_NM101_EntityIdentifierCode {
        X3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_UtilizationManagementOrganizationUMOName_TS278A1_2010AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000B {
    [XmlElement(Order=0)]
    public S_HL_RequesterLevel_TS278A1_2000B S_HL_RequesterLevel_TS278A1_2000B {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A1_2010B G_TS278A1_2010B {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A1_2000C G_TS278A1_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_RequesterLevel_TS278A1_2000B {
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
    public S_NM1_RequesterName_TS278A1_2010B S_NM1_RequesterName_TS278A1_2010B {get; set;}
    [XmlElement("S_REF_RequesterSupplementalIdentification_TS278A1_2010B",Order=1)]
    public List<S_REF_RequesterSupplementalIdentification_TS278A1_2010B> S_REF_RequesterSupplementalIdentification_TS278A1_2010B {get; set;}
    [XmlElement(Order=2)]
    public S_N3_RequesterAddress_TS278A1_2010B S_N3_RequesterAddress_TS278A1_2010B {get; set;}
    [XmlElement(Order=3)]
    public S_N4_RequesterCityStateZIPCode_TS278A1_2010B S_N4_RequesterCityStateZIPCode_TS278A1_2010B {get; set;}
    [XmlElement(Order=4)]
    public S_PER_RequesterContactInformation_TS278A1_2010B S_PER_RequesterContactInformation_TS278A1_2010B {get; set;}
    [XmlElement(Order=5)]
    public S_PRV_RequesterProviderInformation_TS278A1_2010B S_PRV_RequesterProviderInformation_TS278A1_2010B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RequesterName_TS278A1_2010B {
    [XmlElement(Order=0)]
    public S_NM1_RequesterName_TS278A1_2010BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_RequesterName_TS278A1_2010BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RequesterLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RequesterFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RequesterMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RequesterNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RequesterIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_RequesterName_TS278A1_2010BD_NM101_EntityIdentifierCode {
        [XmlEnum("1P")]
        Item1P,
        FA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_RequesterName_TS278A1_2010BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RequesterSupplementalIdentification_TS278A1_2010B {
    [XmlElement(Order=0)]
    public S_REF_RequesterSupplementalIdentification_TS278A1_2010BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RequesterSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U153 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_RequesterSupplementalIdentification_TS278A1_2010BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1J")]
        Item1J,
        CT,
        EI,
        N5,
        N7,
        SY,
        ZH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_RequesterAddress_TS278A1_2010B {
    [XmlElement(Order=0)]
    public string D_N301_RequesterAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_RequesterAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_RequesterCityStateZIPCode_TS278A1_2010B {
    [XmlElement(Order=0)]
    public string D_N401_RequesterCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_RequesterStateOrProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_RequesterPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_RequesterCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_RequesterContactInformation_TS278A1_2010B {
    [XmlElement(Order=0)]
    public S_PER_RequesterContactInformation_TS278A1_2010BD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_RequesterContactInformation_TS278A1_2010BD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_RequesterProviderInformation_TS278A1_2010B {
    [XmlElement(Order=0)]
    public S_PRV_RequesterProviderInformation_TS278A1_2010BD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RequesterProviderInformation_TS278A1_2010BD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U154 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_RequesterProviderInformation_TS278A1_2010BD_PRV01_ProviderCode {
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
    public enum S_PRV_RequesterProviderInformation_TS278A1_2010BD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000C {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel_TS278A1_2000C S_HL_SubscriberLevel_TS278A1_2000C {get; set;}
    [XmlElement("S_TRN_PatientEventTrackingNumber_TS278A1_2000C",Order=1)]
    public List<S_TRN_PatientEventTrackingNumber_TS278A1_2000C> S_TRN_PatientEventTrackingNumber_TS278A1_2000C {get; set;}
    [XmlElement(Order=2)]
    public A_DTP_TS278A1_2000C A_DTP_TS278A1_2000C {get; set;}
    [XmlElement(Order=3)]
    public S_HI_SubscriberDiagnosis_TS278A1_2000C S_HI_SubscriberDiagnosis_TS278A1_2000C {get; set;}
    [XmlElement("S_PWK_AdditionalPatientInformation_TS278A1_2000C",Order=4)]
    public List<S_PWK_AdditionalPatientInformation_TS278A1_2000C> S_PWK_AdditionalPatientInformation_TS278A1_2000C {get; set;}
    [XmlElement(Order=5)]
    public G_TS278A1_2010CA G_TS278A1_2010CA {get; set;}
    [XmlElement(Order=6)]
    public G_TS278A1_2000D G_TS278A1_2000D {get; set;}
    [XmlElement("G_TS278A1_2000E",Order=7)]
    public List<G_TS278A1_2000E> G_TS278A1_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberLevel_TS278A1_2000C {
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
    public class S_TRN_PatientEventTrackingNumber_TS278A1_2000C {
    [XmlElement(Order=0)]
    public S_TRN_PatientEventTrackingNumber_TS278A1_2000CD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_PatientEventTrackingNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_PatientEventTrackingNumber_TS278A1_2000CD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_TS278A1_2000C {
    [XmlElementAttribute(Order=0)]
    public S_DTP_AccidentDate_TS278A1_2000C S_DTP_AccidentDate_TS278A1_2000C {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A1_2000C S_DTP_LastMenstrualPeriodDate_TS278A1_2000C {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_EstimatedDateOfBirth_TS278A1_2000C S_DTP_EstimatedDateOfBirth_TS278A1_2000C {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000C S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AccidentDate_TS278A1_2000C {
    [XmlElement(Order=0)]
    public S_DTP_AccidentDate_TS278A1_2000CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_AccidentDate_TS278A1_2000CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AccidentDate_TS278A1_2000CD_DTP01_DateTimeQualifier {
        [XmlEnum("439")]
        Item439,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AccidentDate_TS278A1_2000CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LastMenstrualPeriodDate_TS278A1_2000C {
    [XmlElement(Order=0)]
    public S_DTP_LastMenstrualPeriodDate_TS278A1_2000CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A1_2000CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_LastMenstrualPeriodDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LastMenstrualPeriodDate_TS278A1_2000CD_DTP01_DateTimeQualifier {
        [XmlEnum("484")]
        Item484,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LastMenstrualPeriodDate_TS278A1_2000CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_EstimatedDateOfBirth_TS278A1_2000C {
    [XmlElement(Order=0)]
    public S_DTP_EstimatedDateOfBirth_TS278A1_2000CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_EstimatedDateOfBirth_TS278A1_2000CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EstimatedBirthDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_EstimatedDateOfBirth_TS278A1_2000CD_DTP01_DateTimeQualifier {
        ABC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_EstimatedDateOfBirth_TS278A1_2000CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000C {
    [XmlElement(Order=0)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OnsetDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000CD_DTP01_DateTimeQualifier {
        [XmlEnum("431")]
        Item431,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_SubscriberDiagnosis_TS278A1_2000C {
    [XmlElement(Order=0)]
    public C_HI01_C022U155_TS278A1_2000C C_HI01_C022U155_TS278A1_2000C {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U163_TS278A1_2000C C_HI02_C022U163_TS278A1_2000C {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U171_TS278A1_2000C C_HI03_C022U171_TS278A1_2000C {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U179_TS278A1_2000C C_HI04_C022U179_TS278A1_2000C {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U187_TS278A1_2000C C_HI05_C022U187_TS278A1_2000C {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U195_TS278A1_2000C C_HI06_C022U195_TS278A1_2000C {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U203_TS278A1_2000C C_HI07_C022U203_TS278A1_2000C {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U211_TS278A1_2000C C_HI08_C022U211_TS278A1_2000C {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U219_TS278A1_2000C C_HI09_C022U219_TS278A1_2000C {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U227_TS278A1_2000C C_HI10_C022U227_TS278A1_2000C {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U235_TS278A1_2000C C_HI11_C022U235_TS278A1_2000C {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U243_TS278A1_2000C C_HI12_C022U243_TS278A1_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U155_TS278A1_2000C {
    [XmlElement(Order=0)]
    public C_HI01_C022U155_TS278A1_2000CD_HI01_C02201U156_DiagnosisTypeCode D_HI01_C02201U156_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U157_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U158_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U159_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U5161 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U5162 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U5163 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U155_TS278A1_2000CD_HI01_C02201U156_DiagnosisTypeCode {
        BF,
        BJ,
        BK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U163_TS278A1_2000C {
    [XmlElement(Order=0)]
    public C_HI02_C022U163_TS278A1_2000CD_HI02_C02201U164_DiagnosisTypeCode D_HI02_C02201U164_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U165_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U166_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U167_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U5169 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U5170 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U5171 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U163_TS278A1_2000CD_HI02_C02201U164_DiagnosisTypeCode {
        BF,
        BJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U171_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U172_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U173_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U174_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U175_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U5177 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U5178 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U5179 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U179_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U180_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U181_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U182_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U183_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U5185 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U5186 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U5187 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U187_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U188_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U189_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U190_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U191_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U5193 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U5194 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U5195 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U195_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U196_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U197_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U198_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U199_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U5201 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U5202 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U5203 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U203_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U204_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U205_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U206_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U207_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U5209 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U5210 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U5211 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U211_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U212_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U213_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U214_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U215_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U5217 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U5218 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U5219 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U219_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U220_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U221_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U222_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U223_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U5225 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U5226 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U5227 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U227_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U228_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U229_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U230_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U231_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U5233 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U5234 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U5235 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U235_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U236_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U237_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U238_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U239_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U5241 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U5242 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U5243 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U243_TS278A1_2000C {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U244_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U245_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U246_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U247_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U5249 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U5250 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U5251 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_AdditionalPatientInformation_TS278A1_2000C {
    [XmlElement(Order=0)]
    public S_PWK_AdditionalPatientInformation_TS278A1_2000CD_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_AdditionalPatientInformation_TS278A1_2000CD_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
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
    public string D_PWK08_C002U5252 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalPatientInformation_TS278A1_2000CD_PWK01_AttachmentReportTypeCode {
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalPatientInformation_TS278A1_2000CD_PWK02_AttachmentTransmissionCode {
        AA,
        BM,
        EL,
        EM,
        FX,
        VO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS278A1_2010CA S_NM1_SubscriberName_TS278A1_2010CA {get; set;}
    [XmlElement("S_REF_SubscriberSupplementalIdentification_TS278A1_2010CA",Order=1)]
    public List<S_REF_SubscriberSupplementalIdentification_TS278A1_2010CA> S_REF_SubscriberSupplementalIdentification_TS278A1_2010CA {get; set;}
    [XmlElement(Order=2)]
    public S_DMG_SubscriberDemographicInformation_TS278A1_2010CA S_DMG_SubscriberDemographicInformation_TS278A1_2010CA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS278A1_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS278A1_2010CAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubscriberName_TS278A1_2010CAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_SubscriberName_TS278A1_2010CAD_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS278A1_2010CAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberSupplementalIdentification_TS278A1_2010CA {
    [XmlElement(Order=0)]
    public S_REF_SubscriberSupplementalIdentification_TS278A1_2010CAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U5253 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberSupplementalIdentification_TS278A1_2010CAD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("6P")]
        Item6P,
        A6,
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
    public class S_DMG_SubscriberDemographicInformation_TS278A1_2010CA {
    [XmlElement(Order=0)]
    public S_DMG_SubscriberDemographicInformation_TS278A1_2010CAD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_SubscriberDemographicInformation_TS278A1_2010CAD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000D {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel_TS278A1_2000D S_HL_DependentLevel_TS278A1_2000D {get; set;}
    [XmlElement("S_TRN_PatientEventTrackingNumber_TS278A1_2000D",Order=1)]
    public List<S_TRN_PatientEventTrackingNumber_TS278A1_2000D> S_TRN_PatientEventTrackingNumber_TS278A1_2000D {get; set;}
    [XmlElement(Order=2)]
    public A_DTP_TS278A1_2000D A_DTP_TS278A1_2000D {get; set;}
    [XmlElement(Order=3)]
    public S_HI_DependentDiagnosis_TS278A1_2000D S_HI_DependentDiagnosis_TS278A1_2000D {get; set;}
    [XmlElement("S_PWK_AdditionalPatientInformation_TS278A1_2000D",Order=4)]
    public List<S_PWK_AdditionalPatientInformation_TS278A1_2000D> S_PWK_AdditionalPatientInformation_TS278A1_2000D {get; set;}
    [XmlElement(Order=5)]
    public G_TS278A1_2010DA G_TS278A1_2010DA {get; set;}
    [XmlElement("G_TS278A1_2000E",Order=6)]
    public List<G_TS278A1_2000E> G_TS278A1_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_DependentLevel_TS278A1_2000D {
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
    public class S_TRN_PatientEventTrackingNumber_TS278A1_2000D {
    [XmlElement(Order=0)]
    public S_TRN_PatientEventTrackingNumber_TS278A1_2000DD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_PatientEventTrackingNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_PatientEventTrackingNumber_TS278A1_2000DD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_TS278A1_2000D {
    [XmlElementAttribute(Order=0)]
    public S_DTP_AccidentDate_TS278A1_2000D S_DTP_AccidentDate_TS278A1_2000D {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A1_2000D S_DTP_LastMenstrualPeriodDate_TS278A1_2000D {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_EstimatedDateOfBirth_TS278A1_2000D S_DTP_EstimatedDateOfBirth_TS278A1_2000D {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000D S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AccidentDate_TS278A1_2000D {
    [XmlElement(Order=0)]
    public S_DTP_AccidentDate_TS278A1_2000DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_AccidentDate_TS278A1_2000DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AccidentDate_TS278A1_2000DD_DTP01_DateTimeQualifier {
        [XmlEnum("439")]
        Item439,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AccidentDate_TS278A1_2000DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LastMenstrualPeriodDate_TS278A1_2000D {
    [XmlElement(Order=0)]
    public S_DTP_LastMenstrualPeriodDate_TS278A1_2000DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A1_2000DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_LastMenstrualPeriodDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LastMenstrualPeriodDate_TS278A1_2000DD_DTP01_DateTimeQualifier {
        [XmlEnum("484")]
        Item484,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LastMenstrualPeriodDate_TS278A1_2000DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_EstimatedDateOfBirth_TS278A1_2000D {
    [XmlElement(Order=0)]
    public S_DTP_EstimatedDateOfBirth_TS278A1_2000DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_EstimatedDateOfBirth_TS278A1_2000DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EstimatedBirthDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_EstimatedDateOfBirth_TS278A1_2000DD_DTP01_DateTimeQualifier {
        ABC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_EstimatedDateOfBirth_TS278A1_2000DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000D {
    [XmlElement(Order=0)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OnsetDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000DD_DTP01_DateTimeQualifier {
        [XmlEnum("431")]
        Item431,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A1_2000DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_DependentDiagnosis_TS278A1_2000D {
    [XmlElement(Order=0)]
    public C_HI01_C022U252_TS278A1_2000D C_HI01_C022U252_TS278A1_2000D {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U260_TS278A1_2000D C_HI02_C022U260_TS278A1_2000D {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U268_TS278A1_2000D C_HI03_C022U268_TS278A1_2000D {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U276_TS278A1_2000D C_HI04_C022U276_TS278A1_2000D {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U284_TS278A1_2000D C_HI05_C022U284_TS278A1_2000D {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U292_TS278A1_2000D C_HI06_C022U292_TS278A1_2000D {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U300_TS278A1_2000D C_HI07_C022U300_TS278A1_2000D {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U308_TS278A1_2000D C_HI08_C022U308_TS278A1_2000D {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U316_TS278A1_2000D C_HI09_C022U316_TS278A1_2000D {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U324_TS278A1_2000D C_HI10_C022U324_TS278A1_2000D {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U332_TS278A1_2000D C_HI11_C022U332_TS278A1_2000D {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U340_TS278A1_2000D C_HI12_C022U340_TS278A1_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U252_TS278A1_2000D {
    [XmlElement(Order=0)]
    public C_HI01_C022U252_TS278A1_2000DD_HI01_C02201U253_DiagnosisTypeCode D_HI01_C02201U253_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U254_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U255_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U256_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U5259 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U5260 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U5261 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U252_TS278A1_2000DD_HI01_C02201U253_DiagnosisTypeCode {
        BF,
        BJ,
        BK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U260_TS278A1_2000D {
    [XmlElement(Order=0)]
    public C_HI02_C022U260_TS278A1_2000DD_HI02_C02201U261_DiagnosisTypeCode D_HI02_C02201U261_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U262_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U263_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U264_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U5267 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U5268 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U5269 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U260_TS278A1_2000DD_HI02_C02201U261_DiagnosisTypeCode {
        BF,
        BJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U268_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U269_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U270_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U271_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U272_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U5275 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U5276 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U5277 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U276_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U277_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U278_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U279_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U280_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U5283 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U5284 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U5285 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U284_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U285_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U286_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U287_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U288_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U5291 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U5292 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U5293 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U292_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U293_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U294_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U295_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U296_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U5299 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U5300 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U5301 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U300_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U301_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U302_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U303_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U304_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U5307 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U5308 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U5309 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U308_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U309_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U310_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U311_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U312_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U5315 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U5316 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U5317 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U316_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U317_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U318_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U319_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U320_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U5323 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U5324 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U5325 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U324_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U325_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U326_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U327_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U328_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U5331 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U5332 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U5333 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U332_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U333_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U334_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U335_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U336_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U5339 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U5340 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U5341 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U340_TS278A1_2000D {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U341_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U342_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U343_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U344_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U5347 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U5348 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U5349 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_AdditionalPatientInformation_TS278A1_2000D {
    [XmlElement(Order=0)]
    public S_PWK_AdditionalPatientInformation_TS278A1_2000DD_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_AdditionalPatientInformation_TS278A1_2000DD_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
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
    public string D_PWK08_C002U5350 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalPatientInformation_TS278A1_2000DD_PWK01_AttachmentReportTypeCode {
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalPatientInformation_TS278A1_2000DD_PWK02_AttachmentTransmissionCode {
        AA,
        BM,
        EL,
        EM,
        FX,
        VO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2010DA {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS278A1_2010DA S_NM1_DependentName_TS278A1_2010DA {get; set;}
    [XmlElement("S_REF_DependentSupplementalIdentification_TS278A1_2010DA",Order=1)]
    public List<S_REF_DependentSupplementalIdentification_TS278A1_2010DA> S_REF_DependentSupplementalIdentification_TS278A1_2010DA {get; set;}
    [XmlElement(Order=2)]
    public S_DMG_DependentDemographicInformation_TS278A1_2010DA S_DMG_DependentDemographicInformation_TS278A1_2010DA {get; set;}
    [XmlElement(Order=3)]
    public S_INS_DependentRelationship_TS278A1_2010DA S_INS_DependentRelationship_TS278A1_2010DA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName_TS278A1_2010DA {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS278A1_2010DAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_DependentName_TS278A1_2010DAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_DependentName_TS278A1_2010DAD_NM101_EntityIdentifierCode {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_DependentName_TS278A1_2010DAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentSupplementalIdentification_TS278A1_2010DA {
    [XmlElement(Order=0)]
    public S_REF_DependentSupplementalIdentification_TS278A1_2010DAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U5351 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_DependentSupplementalIdentification_TS278A1_2010DAD_REF01_ReferenceIdentificationQualifier {
        A6,
        EJ,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_DependentDemographicInformation_TS278A1_2010DA {
    [XmlElement(Order=0)]
    public S_DMG_DependentDemographicInformation_TS278A1_2010DAD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_DependentDemographicInformation_TS278A1_2010DAD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_DependentRelationship_TS278A1_2010DA {
    [XmlElement(Order=0)]
    public S_INS_DependentRelationship_TS278A1_2010DAD_INS01_InsuredIndicator D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_INS_DependentRelationship_TS278A1_2010DAD_INS02_IndividualRelationshipCode D_INS02_IndividualRelationshipCode {get; set;}
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
    public enum S_INS_DependentRelationship_TS278A1_2010DAD_INS01_InsuredIndicator {
        N,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_DependentRelationship_TS278A1_2010DAD_INS02_IndividualRelationshipCode {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("04")]
        Item04,
        [XmlEnum("05")]
        Item05,
        [XmlEnum("07")]
        Item07,
        [XmlEnum("09")]
        Item09,
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
        [XmlEnum("34")]
        Item34,
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
    public class G_TS278A1_2000E {
    [XmlElement(Order=0)]
    public S_HL_ServiceProviderLevel_TS278A1_2000E S_HL_ServiceProviderLevel_TS278A1_2000E {get; set;}
    [XmlElement(Order=1)]
    public S_MSG_MessageText_TS278A1_2000E S_MSG_MessageText_TS278A1_2000E {get; set;}
    [XmlElement("G_TS278A1_2010E",Order=2)]
    public List<G_TS278A1_2010E> G_TS278A1_2010E {get; set;}
    [XmlElement("G_TS278A1_2000F",Order=3)]
    public List<G_TS278A1_2000F> G_TS278A1_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_ServiceProviderLevel_TS278A1_2000E {
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
    public class S_MSG_MessageText_TS278A1_2000E {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02 {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2010E {
    [XmlElement(Order=0)]
    public S_NM1_ServiceProviderName_TS278A1_2010E S_NM1_ServiceProviderName_TS278A1_2010E {get; set;}
    [XmlElement("S_REF_ServiceProviderSupplementalIdentification_TS278A1_2010E",Order=1)]
    public List<S_REF_ServiceProviderSupplementalIdentification_TS278A1_2010E> S_REF_ServiceProviderSupplementalIdentification_TS278A1_2010E {get; set;}
    [XmlElement(Order=2)]
    public S_N3_ServiceProviderAddress_TS278A1_2010E S_N3_ServiceProviderAddress_TS278A1_2010E {get; set;}
    [XmlElement(Order=3)]
    public S_N4_ServiceProviderCityStateZIPCode_TS278A1_2010E S_N4_ServiceProviderCityStateZIPCode_TS278A1_2010E {get; set;}
    [XmlElement(Order=4)]
    public S_PER_ServiceProviderContactInformation_TS278A1_2010E S_PER_ServiceProviderContactInformation_TS278A1_2010E {get; set;}
    [XmlElement(Order=5)]
    public S_PRV_ServiceProviderInformation_TS278A1_2010E S_PRV_ServiceProviderInformation_TS278A1_2010E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceProviderName_TS278A1_2010E {
    [XmlElement(Order=0)]
    public S_NM1_ServiceProviderName_TS278A1_2010ED_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ServiceProviderName_TS278A1_2010ED_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ServiceProviderLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ServiceProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ServiceProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ServiceProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ServiceProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceProviderName_TS278A1_2010ED_NM101_EntityIdentifierCode {
        [XmlEnum("1T")]
        Item1T,
        FA,
        SJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceProviderName_TS278A1_2010ED_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceProviderSupplementalIdentification_TS278A1_2010E {
    [XmlElement(Order=0)]
    public S_REF_ServiceProviderSupplementalIdentification_TS278A1_2010ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ServiceProviderSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U349 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceProviderSupplementalIdentification_TS278A1_2010ED_REF01_ReferenceIdentificationQualifier {
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
    public class S_N3_ServiceProviderAddress_TS278A1_2010E {
    [XmlElement(Order=0)]
    public string D_N301_ServiceProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ServiceProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceProviderCityStateZIPCode_TS278A1_2010E {
    [XmlElement(Order=0)]
    public string D_N401_ServiceProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ServiceProviderStateOrProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ServiceProviderPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_ServiceProviderCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_ServiceProviderContactInformation_TS278A1_2010E {
    [XmlElement(Order=0)]
    public S_PER_ServiceProviderContactInformation_TS278A1_2010ED_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_ServiceProviderContactInformation_TS278A1_2010ED_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ServiceProviderInformation_TS278A1_2010E {
    [XmlElement(Order=0)]
    public S_PRV_ServiceProviderInformation_TS278A1_2010ED_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_ServiceProviderInformation_TS278A1_2010ED_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U350 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ServiceProviderInformation_TS278A1_2010ED_PRV01_ProviderCode {
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
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ServiceProviderInformation_TS278A1_2010ED_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_HL_ServiceLevel_TS278A1_2000F S_HL_ServiceLevel_TS278A1_2000F {get; set;}
    [XmlElement("S_TRN_ServiceTraceNumber_TS278A1_2000F",Order=1)]
    public List<S_TRN_ServiceTraceNumber_TS278A1_2000F> S_TRN_ServiceTraceNumber_TS278A1_2000F {get; set;}
    [XmlElement(Order=2)]
    public S_UM_HealthCareServicesReviewInformation_TS278A1_2000F S_UM_HealthCareServicesReviewInformation_TS278A1_2000F {get; set;}
    [XmlElement(Order=3)]
    public S_REF_PreviousCertificationIdentification_TS278A1_2000F S_REF_PreviousCertificationIdentification_TS278A1_2000F {get; set;}
    [XmlElement(Order=4)]
    public A_DTP_TS278A1_2000F A_DTP_TS278A1_2000F {get; set;}
    [XmlElement(Order=5)]
    public S_HI_Procedures_TS278A1_2000F S_HI_Procedures_TS278A1_2000F {get; set;}
    [XmlElement(Order=6)]
    public S_HSD_HealthCareServicesDelivery_TS278A1_2000F S_HSD_HealthCareServicesDelivery_TS278A1_2000F {get; set;}
    [XmlElement("S_CRC_PatientConditionInformation_TS278A1_2000F",Order=7)]
    public List<S_CRC_PatientConditionInformation_TS278A1_2000F> S_CRC_PatientConditionInformation_TS278A1_2000F {get; set;}
    [XmlElement(Order=8)]
    public S_CL1_InstitutionalClaimCode_TS278A1_2000F S_CL1_InstitutionalClaimCode_TS278A1_2000F {get; set;}
    [XmlElement(Order=9)]
    public S_CR1_AmbulanceTransportInformation_TS278A1_2000F S_CR1_AmbulanceTransportInformation_TS278A1_2000F {get; set;}
    [XmlElement(Order=10)]
    public S_CR2_SpinalManipulationServiceInformation_TS278A1_2000F S_CR2_SpinalManipulationServiceInformation_TS278A1_2000F {get; set;}
    [XmlElement(Order=11)]
    public S_CR5_HomeOxygenTherapyInformation_TS278A1_2000F S_CR5_HomeOxygenTherapyInformation_TS278A1_2000F {get; set;}
    [XmlElement(Order=12)]
    public S_CR6_HomeHealthCareInformation_TS278A1_2000F S_CR6_HomeHealthCareInformation_TS278A1_2000F {get; set;}
    [XmlElement("S_PWK_AdditionalServiceInformation_TS278A1_2000F",Order=13)]
    public List<S_PWK_AdditionalServiceInformation_TS278A1_2000F> S_PWK_AdditionalServiceInformation_TS278A1_2000F {get; set;}
    [XmlElement(Order=14)]
    public S_MSG_MessageText_TS278A1_2000F S_MSG_MessageText_TS278A1_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_ServiceLevel_TS278A1_2000F {
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
    public class S_TRN_ServiceTraceNumber_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_TRN_ServiceTraceNumber_TS278A1_2000FD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ServiceTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_ServiceTraceNumber_TS278A1_2000FD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_UM_HealthCareServicesReviewInformation_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_UM_HealthCareServicesReviewInformation_TS278A1_2000FD_UM01_RequestCategoryCode D_UM01_RequestCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public S_UM_HealthCareServicesReviewInformation_TS278A1_2000FD_UM02_CertificationTypeCode D_UM02_CertificationTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_UM03_ServiceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public C_UM04_C023U351_TS278A1_2000F C_UM04_C023U351_TS278A1_2000F {get; set;}
    [XmlElement(Order=4)]
    public C_UM05_C024U355_TS278A1_2000F C_UM05_C024U355_TS278A1_2000F {get; set;}
    [XmlElement(Order=5)]
    public string D_UM06_LevelOfServiceCode {get; set;}
    [XmlElement(Order=6)]
    public string D_UM07_CurrentHealthConditionCode {get; set;}
    [XmlElement(Order=7)]
    public string D_UM08_PrognosisCode {get; set;}
    [XmlElement(Order=8)]
    public string D_UM09_ReleaseOfInformationCode {get; set;}
    [XmlElement(Order=9)]
    public string D_UM10_DelayReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_UM_HealthCareServicesReviewInformation_TS278A1_2000FD_UM01_RequestCategoryCode {
        AR,
        HS,
        SC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_UM_HealthCareServicesReviewInformation_TS278A1_2000FD_UM02_CertificationTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("4")]
        Item4,
        I,
        R,
        S,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_UM04_C023U351_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_UM04_C02301U352_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_UM04_C02302U353_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_UM04_C02303U5357 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_UM05_C024U355_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_UM05_C02401U356_RelatedCausesCode {get; set;}
    [XmlElement(Order=1)]
    public string D_UM05_C02402U357_RelatedCausesCode {get; set;}
    [XmlElement(Order=2)]
    public string D_UM05_C02403U358_RelatedCausesCode {get; set;}
    [XmlElement(Order=3)]
    public string D_UM05_C02404U359_StateCode {get; set;}
    [XmlElement(Order=4)]
    public string D_UM05_C02405U360_CountryCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PreviousCertificationIdentification_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_REF_PreviousCertificationIdentification_TS278A1_2000FD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PreviousCertificationIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U361 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PreviousCertificationIdentification_TS278A1_2000FD_REF01_ReferenceIdentificationQualifier {
        BB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_TS278A1_2000F {
    [XmlElementAttribute(Order=0)]
    public S_DTP_ServiceDate_TS278A1_2000F S_DTP_ServiceDate_TS278A1_2000F {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_AdmissionDate_TS278A1_2000F S_DTP_AdmissionDate_TS278A1_2000F {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_DischargeDate_TS278A1_2000F S_DTP_DischargeDate_TS278A1_2000F {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_SurgeryDate_TS278A1_2000F S_DTP_SurgeryDate_TS278A1_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceDate_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_DTP_ServiceDate_TS278A1_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ServiceDate_TS278A1_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedOrActualServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceDate_TS278A1_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceDate_TS278A1_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AdmissionDate_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_DTP_AdmissionDate_TS278A1_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_AdmissionDate_TS278A1_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedOrActualAdmissionDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AdmissionDate_TS278A1_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("435")]
        Item435,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AdmissionDate_TS278A1_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DischargeDate_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_DTP_DischargeDate_TS278A1_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DischargeDate_TS278A1_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedOrActualDischargeDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DischargeDate_TS278A1_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("096")]
        Item096,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DischargeDate_TS278A1_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_SurgeryDate_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_DTP_SurgeryDate_TS278A1_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_SurgeryDate_TS278A1_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedOrActualSurgeryDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SurgeryDate_TS278A1_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("456")]
        Item456,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SurgeryDate_TS278A1_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_Procedures_TS278A1_2000F {
    [XmlElement(Order=0)]
    public C_HI01_C022U362_TS278A1_2000F C_HI01_C022U362_TS278A1_2000F {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U370_TS278A1_2000F C_HI02_C022U370_TS278A1_2000F {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U378_TS278A1_2000F C_HI03_C022U378_TS278A1_2000F {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U386_TS278A1_2000F C_HI04_C022U386_TS278A1_2000F {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U394_TS278A1_2000F C_HI05_C022U394_TS278A1_2000F {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U402_TS278A1_2000F C_HI06_C022U402_TS278A1_2000F {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U410_TS278A1_2000F C_HI07_C022U410_TS278A1_2000F {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U418_TS278A1_2000F C_HI08_C022U418_TS278A1_2000F {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U426_TS278A1_2000F C_HI09_C022U426_TS278A1_2000F {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U434_TS278A1_2000F C_HI10_C022U434_TS278A1_2000F {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U442_TS278A1_2000F C_HI11_C022U442_TS278A1_2000F {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U450_TS278A1_2000F C_HI12_C022U450_TS278A1_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U362_TS278A1_2000F {
    [XmlElement(Order=0)]
    public C_HI01_C022U362_TS278A1_2000FD_HI01_C02201U363_CodeListQualifierCode D_HI01_C02201U363_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U364_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U365_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U366_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U5370_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U368_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U369_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U362_TS278A1_2000FD_HI01_C02201U363_CodeListQualifierCode {
        ABR,
        BO,
        BQ,
        JP,
        NDC,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U370_TS278A1_2000F {
    [XmlElement(Order=0)]
    public C_HI02_C022U370_TS278A1_2000FD_HI02_C02201U371_CodeListQualifierCode D_HI02_C02201U371_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U372_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U373_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U374_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U5378_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U376_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U377_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U370_TS278A1_2000FD_HI02_C02201U371_CodeListQualifierCode {
        ABR,
        BO,
        BQ,
        JP,
        NDC,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U378_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U379_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U380_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U381_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U382_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U5386_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U384_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U385_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U386_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U387_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U388_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U389_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U390_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U5394_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U392_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U393_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U394_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U395_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U396_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U397_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U398_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U5402_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U400_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U401_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U402_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U403_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U404_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U405_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U406_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U5410_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U408_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U409_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U410_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U411_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U412_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U413_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U414_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U5418_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U416_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U417_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U418_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U419_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U420_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U421_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U422_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U5426_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U424_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U425_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U426_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U427_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U428_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U429_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U430_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U5434_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U432_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U433_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U434_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U435_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U436_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U437_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U438_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U5442_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U440_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U441_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U442_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U443_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U444_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U445_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U446_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U5450_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U448_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U449_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U450_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U451_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U452_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U453_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U454_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U5458_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U456_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U457_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HSD_HealthCareServicesDelivery_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_HSD_HealthCareServicesDelivery_TS278A1_2000FD_HSD01_QuantityQualifier D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_ServiceUnitCount {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HSD04_SampleSelectionModulus {get; set;}
    [XmlElement(Order=4)]
    public string D_HSD05_TimePeriodQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_HSD06_PeriodCount {get; set;}
    [XmlElement(Order=6)]
    public string D_HSD07_ShipDeliveryOrCalendarPatternCode {get; set;}
    [XmlElement(Order=7)]
    public string D_HSD08_DeliveryPatternTimeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_HSD_HealthCareServicesDelivery_TS278A1_2000FD_HSD01_QuantityQualifier {
        DY,
        FL,
        HS,
        MN,
        VS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CRC_PatientConditionInformation_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_CRC_PatientConditionInformation_TS278A1_2000FD_CRC01_CodeCategory D_CRC01_CodeCategory {get; set;}
    [XmlElement(Order=1)]
    public S_CRC_PatientConditionInformation_TS278A1_2000FD_CRC02_CertificationConditionIndicator D_CRC02_CertificationConditionIndicator {get; set;}
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CRC_PatientConditionInformation_TS278A1_2000FD_CRC01_CodeCategory {
        [XmlEnum("07")]
        Item07,
        [XmlEnum("08")]
        Item08,
        [XmlEnum("11")]
        Item11,
        [XmlEnum("75")]
        Item75,
        [XmlEnum("76")]
        Item76,
        [XmlEnum("77")]
        Item77,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CRC_PatientConditionInformation_TS278A1_2000FD_CRC02_CertificationConditionIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CL1_InstitutionalClaimCode_TS278A1_2000F {
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
    public class S_CR1_AmbulanceTransportInformation_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_CR1_AmbulanceTransportInformation_TS278A1_2000FD_CR101_UnitOrBasisForMeasurementCode D_CR101_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR102_PatientWeight {get; set;}
    [XmlElement(Order=2)]
    public string D_CR103_AmbulanceTransportCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR104_AmbulanceTransportReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR105_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CR106_TransportDistance {get; set;}
    [XmlElement(Order=6)]
    public string D_CR107_AmbulanceTripOriginAddress {get; set;}
    [XmlElement(Order=7)]
    public string D_CR108_AmbulanceTripDestinationAddress {get; set;}
    [XmlElement(Order=8)]
    public string D_CR109_RoundTripPurposeDescription {get; set;}
    [XmlElement(Order=9)]
    public string D_CR110_StretcherPurposeDescription {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CR1_AmbulanceTransportInformation_TS278A1_2000FD_CR101_UnitOrBasisForMeasurementCode {
        KG,
        LB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR2_SpinalManipulationServiceInformation_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_CR201_TreatmentSeriesNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_CR202_TreatmentCount {get; set;}
    [XmlElement(Order=2)]
    public string D_CR203_SubluxationLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR204_SubluxationLevelCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR205_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CR206_TreatmentPeriodCount {get; set;}
    [XmlElement(Order=6)]
    public string D_CR207_MonthlyTreatmentCount {get; set;}
    [XmlElement(Order=7)]
    public string D_CR208_PatientConditionCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CR209_ComplicationIndicator {get; set;}
    [XmlElement(Order=9)]
    public string D_CR210_PatientConditionDescription {get; set;}
    [XmlElement(Order=10)]
    public string D_CR211_PatientConditionDescription {get; set;}
    [XmlElement(Order=11)]
    public string D_CR212_XrayAvailabilityIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR5_HomeOxygenTherapyInformation_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_CR501 {get; set;}
    [XmlElement(Order=1)]
    public string D_CR502 {get; set;}
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
    public class S_CR6_HomeHealthCareInformation_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_CR6_HomeHealthCareInformation_TS278A1_2000FD_CR601_PrognosisCode D_CR601_PrognosisCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR602_ServiceFromDate {get; set;}
    [XmlElement(Order=2)]
    public string D_CR603_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_CR604_HomeHealthCertificationPeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_CR605 {get; set;}
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
    public string D_CR618 {get; set;}
    [XmlElement(Order=18)]
    public string D_CR619 {get; set;}
    [XmlElement(Order=19)]
    public string D_CR620 {get; set;}
    [XmlElement(Order=20)]
    public string D_CR621 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CR6_HomeHealthCareInformation_TS278A1_2000FD_CR601_PrognosisCode {
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
    public class S_PWK_AdditionalServiceInformation_TS278A1_2000F {
    [XmlElement(Order=0)]
    public S_PWK_AdditionalServiceInformation_TS278A1_2000FD_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_AdditionalServiceInformation_TS278A1_2000FD_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
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
    public string D_PWK08_C002U5461 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalServiceInformation_TS278A1_2000FD_PWK01_AttachmentReportTypeCode {
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalServiceInformation_TS278A1_2000FD_PWK02_AttachmentTransmissionCode {
        AA,
        BM,
        EL,
        EM,
        FX,
        VO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MSG_MessageText_TS278A1_2000F {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02 {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_A3_BHT {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS278A3 S_BHT_BeginningOfHierarchicalTransaction_TS278A3 {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A3_2000A G_TS278A3_2000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BHT_BeginningOfHierarchicalTransaction_TS278A3 {
    [XmlElement(Order=0)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS278A3D_BHT01_HierarchicalStructureCode D_BHT01_HierarchicalStructureCode {get; set;}
    [XmlElement(Order=1)]
    public S_BHT_BeginningOfHierarchicalTransaction_TS278A3D_BHT02_TransactionSetPurposeCode D_BHT02_TransactionSetPurposeCode {get; set;}
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
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS278A3D_BHT01_HierarchicalStructureCode {
        [XmlEnum("0078")]
        Item0078,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BHT_BeginningOfHierarchicalTransaction_TS278A3D_BHT02_TransactionSetPurposeCode {
        [XmlEnum("11")]
        Item11,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000A {
    [XmlElement(Order=0)]
    public S_HL_UtilizationManagementOrganizationUMOLevel_TS278A3_2000A S_HL_UtilizationManagementOrganizationUMOLevel_TS278A3_2000A {get; set;}
    [XmlElement("S_AAA_RequestValidation_TS278A3_2000A",Order=1)]
    public List<S_AAA_RequestValidation_TS278A3_2000A> S_AAA_RequestValidation_TS278A3_2000A {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A3_2010A G_TS278A3_2010A {get; set;}
    [XmlElement(Order=3)]
    public G_TS278A3_2000B G_TS278A3_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_UtilizationManagementOrganizationUMOLevel_TS278A3_2000A {
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
    public class S_AAA_RequestValidation_TS278A3_2000A {
    [XmlElement(Order=0)]
    public S_AAA_RequestValidation_TS278A3_2000AD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_RequestValidation_TS278A3_2000AD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010A {
    [XmlElement(Order=0)]
    public S_NM1_UtilizationManagementOrganizationUMOName_TS278A3_2010A S_NM1_UtilizationManagementOrganizationUMOName_TS278A3_2010A {get; set;}
    [XmlElement(Order=1)]
    public S_PER_UtilizationManagementOrganizationUMOContactInformation_TS278A3_2010A S_PER_UtilizationManagementOrganizationUMOContactInformation_TS278A3_2010A {get; set;}
    [XmlElement("S_AAA_UtilizationManagementOrganizationUMORequestValidation_TS278A3_2010A",Order=2)]
    public List<S_AAA_UtilizationManagementOrganizationUMORequestValidation_TS278A3_2010A> S_AAA_UtilizationManagementOrganizationUMORequestValidation_TS278A3_2010A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_UtilizationManagementOrganizationUMOName_TS278A3_2010A {
    [XmlElement(Order=0)]
    public S_NM1_UtilizationManagementOrganizationUMOName_TS278A3_2010AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_UtilizationManagementOrganizationUMOName_TS278A3_2010AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_UtilizationManagementOrganizationUMOLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_UtilizationManagementOrganizationUMOFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_UtilizationManagementOrganizationUMOMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_UtilizationManagementOrganizationUMONameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_UtilizationManagementOrganizationUMOIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_UtilizationManagementOrganizationUMOName_TS278A3_2010AD_NM101_EntityIdentifierCode {
        X3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_UtilizationManagementOrganizationUMOName_TS278A3_2010AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_UtilizationManagementOrganizationUMOContactInformation_TS278A3_2010A {
    [XmlElement(Order=0)]
    public S_PER_UtilizationManagementOrganizationUMOContactInformation_TS278A3_2010AD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_UtilizationManagementOrganizationUMOContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_UtilizationManagementOrganizationUMOContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_UtilizationManagementOrganizationUMOContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_UtilizationManagementOrganizationUMOContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_UtilizationManagementOrganizationUMOContactInformation_TS278A3_2010AD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_UtilizationManagementOrganizationUMORequestValidation_TS278A3_2010A {
    [XmlElement(Order=0)]
    public S_AAA_UtilizationManagementOrganizationUMORequestValidation_TS278A3_2010AD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_UtilizationManagementOrganizationUMORequestValidation_TS278A3_2010AD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000B {
    [XmlElement(Order=0)]
    public S_HL_RequesterLevel_TS278A3_2000B S_HL_RequesterLevel_TS278A3_2000B {get; set;}
    [XmlElement(Order=1)]
    public G_TS278A3_2010B G_TS278A3_2010B {get; set;}
    [XmlElement(Order=2)]
    public G_TS278A3_2000C G_TS278A3_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_RequesterLevel_TS278A3_2000B {
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
    public S_NM1_RequesterName_TS278A3_2010B S_NM1_RequesterName_TS278A3_2010B {get; set;}
    [XmlElement("S_REF_RequesterSupplementalIdentification_TS278A3_2010B",Order=1)]
    public List<S_REF_RequesterSupplementalIdentification_TS278A3_2010B> S_REF_RequesterSupplementalIdentification_TS278A3_2010B {get; set;}
    [XmlElement("S_AAA_RequesterRequestValidation_TS278A3_2010B",Order=2)]
    public List<S_AAA_RequesterRequestValidation_TS278A3_2010B> S_AAA_RequesterRequestValidation_TS278A3_2010B {get; set;}
    [XmlElement(Order=3)]
    public S_PRV_RequesterProviderInformation_TS278A3_2010B S_PRV_RequesterProviderInformation_TS278A3_2010B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_RequesterName_TS278A3_2010B {
    [XmlElement(Order=0)]
    public S_NM1_RequesterName_TS278A3_2010BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_RequesterName_TS278A3_2010BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RequesterLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RequesterFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RequesterMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RequesterNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RequesterIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_RequesterName_TS278A3_2010BD_NM101_EntityIdentifierCode {
        [XmlEnum("1P")]
        Item1P,
        FA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_RequesterName_TS278A3_2010BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RequesterSupplementalIdentification_TS278A3_2010B {
    [XmlElement(Order=0)]
    public S_REF_RequesterSupplementalIdentification_TS278A3_2010BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RequesterSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U458 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_RequesterSupplementalIdentification_TS278A3_2010BD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1J")]
        Item1J,
        CT,
        EI,
        N5,
        N7,
        SY,
        ZH,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_RequesterRequestValidation_TS278A3_2010B {
    [XmlElement(Order=0)]
    public S_AAA_RequesterRequestValidation_TS278A3_2010BD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_RequesterRequestValidation_TS278A3_2010BD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_RequesterProviderInformation_TS278A3_2010B {
    [XmlElement(Order=0)]
    public S_PRV_RequesterProviderInformation_TS278A3_2010BD_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_RequesterProviderInformation_TS278A3_2010BD_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U459 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_RequesterProviderInformation_TS278A3_2010BD_PRV01_ProviderCode {
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
    public enum S_PRV_RequesterProviderInformation_TS278A3_2010BD_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_HL_SubscriberLevel_TS278A3_2000C S_HL_SubscriberLevel_TS278A3_2000C {get; set;}
    [XmlElement("S_TRN_PatientEventTrackingNumber_TS278A3_2000C",Order=1)]
    public List<S_TRN_PatientEventTrackingNumber_TS278A3_2000C> S_TRN_PatientEventTrackingNumber_TS278A3_2000C {get; set;}
    [XmlElement("S_AAA_SubscriberRequestValidation_TS278A3_2000C",Order=2)]
    public List<S_AAA_SubscriberRequestValidation_TS278A3_2000C> S_AAA_SubscriberRequestValidation_TS278A3_2000C {get; set;}
    [XmlElement(Order=3)]
    public A_DTP_TS278A3_2000C A_DTP_TS278A3_2000C {get; set;}
    [XmlElement(Order=4)]
    public S_HI_SubscriberDiagnosis_TS278A3_2000C S_HI_SubscriberDiagnosis_TS278A3_2000C {get; set;}
    [XmlElement("S_PWK_AdditionalPatientInformation_TS278A3_2000C",Order=5)]
    public List<S_PWK_AdditionalPatientInformation_TS278A3_2000C> S_PWK_AdditionalPatientInformation_TS278A3_2000C {get; set;}
    [XmlElement(Order=6)]
    public A_TS278A3_2010C A_TS278A3_2010C {get; set;}
    [XmlElement(Order=7)]
    public G_TS278A3_2000D G_TS278A3_2000D {get; set;}
    [XmlElement("G_TS278A3_2000E",Order=8)]
    public List<G_TS278A3_2000E> G_TS278A3_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_SubscriberLevel_TS278A3_2000C {
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
    public class S_TRN_PatientEventTrackingNumber_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_TRN_PatientEventTrackingNumber_TS278A3_2000CD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_PatientEventTrackingNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_PatientEventTrackingNumber_TS278A3_2000CD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_SubscriberRequestValidation_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_AAA_SubscriberRequestValidation_TS278A3_2000CD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_SubscriberRequestValidation_TS278A3_2000CD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_TS278A3_2000C {
    [XmlElementAttribute(Order=0)]
    public S_DTP_AccidentDate_TS278A3_2000C S_DTP_AccidentDate_TS278A3_2000C {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A3_2000C S_DTP_LastMenstrualPeriodDate_TS278A3_2000C {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_EstimatedDateOfBirth_TS278A3_2000C S_DTP_EstimatedDateOfBirth_TS278A3_2000C {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000C S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AccidentDate_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_DTP_AccidentDate_TS278A3_2000CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_AccidentDate_TS278A3_2000CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AccidentDate_TS278A3_2000CD_DTP01_DateTimeQualifier {
        [XmlEnum("439")]
        Item439,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AccidentDate_TS278A3_2000CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LastMenstrualPeriodDate_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_DTP_LastMenstrualPeriodDate_TS278A3_2000CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A3_2000CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_LastMenstrualPeriodDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LastMenstrualPeriodDate_TS278A3_2000CD_DTP01_DateTimeQualifier {
        [XmlEnum("484")]
        Item484,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LastMenstrualPeriodDate_TS278A3_2000CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_EstimatedDateOfBirth_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_DTP_EstimatedDateOfBirth_TS278A3_2000CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_EstimatedDateOfBirth_TS278A3_2000CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EstimatedBirthDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_EstimatedDateOfBirth_TS278A3_2000CD_DTP01_DateTimeQualifier {
        ABC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_EstimatedDateOfBirth_TS278A3_2000CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000CD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000CD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OnsetDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000CD_DTP01_DateTimeQualifier {
        [XmlEnum("431")]
        Item431,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000CD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_SubscriberDiagnosis_TS278A3_2000C {
    [XmlElement(Order=0)]
    public C_HI01_C022U460_TS278A3_2000C C_HI01_C022U460_TS278A3_2000C {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U468_TS278A3_2000C C_HI02_C022U468_TS278A3_2000C {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U476_TS278A3_2000C C_HI03_C022U476_TS278A3_2000C {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U484_TS278A3_2000C C_HI04_C022U484_TS278A3_2000C {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U492_TS278A3_2000C C_HI05_C022U492_TS278A3_2000C {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U500_TS278A3_2000C C_HI06_C022U500_TS278A3_2000C {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U508_TS278A3_2000C C_HI07_C022U508_TS278A3_2000C {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U516_TS278A3_2000C C_HI08_C022U516_TS278A3_2000C {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U524_TS278A3_2000C C_HI09_C022U524_TS278A3_2000C {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U532_TS278A3_2000C C_HI10_C022U532_TS278A3_2000C {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U540_TS278A3_2000C C_HI11_C022U540_TS278A3_2000C {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U548_TS278A3_2000C C_HI12_C022U548_TS278A3_2000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U460_TS278A3_2000C {
    [XmlElement(Order=0)]
    public C_HI01_C022U460_TS278A3_2000CD_HI01_C02201U461_DiagnosisTypeCode D_HI01_C02201U461_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U462_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U463_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U464_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U5469 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U5470 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U5471 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U460_TS278A3_2000CD_HI01_C02201U461_DiagnosisTypeCode {
        BF,
        BJ,
        BK,
        LOI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U468_TS278A3_2000C {
    [XmlElement(Order=0)]
    public C_HI02_C022U468_TS278A3_2000CD_HI02_C02201U469_DiagnosisTypeCode D_HI02_C02201U469_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U470_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U471_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U472_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U5477 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U5478 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U5479 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U468_TS278A3_2000CD_HI02_C02201U469_DiagnosisTypeCode {
        BF,
        BJ,
        LOI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U476_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U477_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U478_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U479_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U480_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U5485 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U5486 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U5487 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U484_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U485_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U486_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U487_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U488_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U5493 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U5494 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U5495 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U492_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U493_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U494_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U495_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U496_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U5501 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U5502 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U5503 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U500_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U501_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U502_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U503_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U504_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U5509 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U5510 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U5511 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U508_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U509_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U510_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U511_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U512_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U5517 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U5518 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U5519 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U516_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U517_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U518_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U519_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U520_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U5525 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U5526 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U5527 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U524_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U525_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U526_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U527_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U528_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U5533 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U5534 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U5535 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U532_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U533_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U534_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U535_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U536_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U5541 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U5542 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U5543 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U540_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U541_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U542_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U543_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U544_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U5549 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U5550 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U5551 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U548_TS278A3_2000C {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U549_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U550_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U551_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U552_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U5557 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U5558 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U5559 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_AdditionalPatientInformation_TS278A3_2000C {
    [XmlElement(Order=0)]
    public S_PWK_AdditionalPatientInformation_TS278A3_2000CD_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_AdditionalPatientInformation_TS278A3_2000CD_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
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
    public string D_PWK08_C002U5560 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalPatientInformation_TS278A3_2000CD_PWK01_AttachmentReportTypeCode {
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalPatientInformation_TS278A3_2000CD_PWK02_AttachmentTransmissionCode {
        BM,
        EL,
        EM,
        FX,
        VO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS278A3_2010C {
    [XmlElementAttribute(Order=0)]
    public G_TS278A3_2010CA G_TS278A3_2010CA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS278A3_2010CB G_TS278A3_2010CB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS278A3_2010CA S_NM1_SubscriberName_TS278A3_2010CA {get; set;}
    [XmlElement("S_REF_SubscriberSupplementalIdentification_TS278A3_2010CA",Order=1)]
    public List<S_REF_SubscriberSupplementalIdentification_TS278A3_2010CA> S_REF_SubscriberSupplementalIdentification_TS278A3_2010CA {get; set;}
    [XmlElement("S_AAA_SubscriberRequestValidation_TS278A3_2010CA",Order=2)]
    public List<S_AAA_SubscriberRequestValidation_TS278A3_2010CA> S_AAA_SubscriberRequestValidation_TS278A3_2010CA {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_SubscriberDemographicInformation_TS278A3_2010CA S_DMG_SubscriberDemographicInformation_TS278A3_2010CA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_SubscriberName_TS278A3_2010CA {
    [XmlElement(Order=0)]
    public S_NM1_SubscriberName_TS278A3_2010CAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_SubscriberName_TS278A3_2010CAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_SubscriberName_TS278A3_2010CAD_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_SubscriberName_TS278A3_2010CAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberSupplementalIdentification_TS278A3_2010CA {
    [XmlElement(Order=0)]
    public S_REF_SubscriberSupplementalIdentification_TS278A3_2010CAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U5561 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberSupplementalIdentification_TS278A3_2010CAD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("6P")]
        Item6P,
        A6,
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
    public class S_AAA_SubscriberRequestValidation_TS278A3_2010CA {
    [XmlElement(Order=0)]
    public S_AAA_SubscriberRequestValidation_TS278A3_2010CAD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_SubscriberRequestValidation_TS278A3_2010CAD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_SubscriberDemographicInformation_TS278A3_2010CA {
    [XmlElement(Order=0)]
    public S_DMG_SubscriberDemographicInformation_TS278A3_2010CAD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_SubscriberDemographicInformation_TS278A3_2010CAD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010CB {
    [XmlElement(Order=0)]
    public S_NM1_AdditionalPatientInformationContactName_TS278A3_2010CB S_NM1_AdditionalPatientInformationContactName_TS278A3_2010CB {get; set;}
    [XmlElement(Order=1)]
    public S_N3_AdditionalPatientInformationContactAddress_TS278A3_2010CB S_N3_AdditionalPatientInformationContactAddress_TS278A3_2010CB {get; set;}
    [XmlElement(Order=2)]
    public S_N4_AdditionalPatientInformationContactCityStateZipCode_TS278A3_2010CB S_N4_AdditionalPatientInformationContactCityStateZipCode_TS278A3_2010CB {get; set;}
    [XmlElement(Order=3)]
    public S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010CB S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010CB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AdditionalPatientInformationContactName_TS278A3_2010CB {
    [XmlElement(Order=0)]
    public S_NM1_AdditionalPatientInformationContactName_TS278A3_2010CBD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_AdditionalPatientInformationContactName_TS278A3_2010CBD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ResponseContactLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ResponseContactFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ResponseContactMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ResponseContactNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ResponseContactIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AdditionalPatientInformationContactName_TS278A3_2010CBD_NM101_EntityIdentifierCode {
        [XmlEnum("1P")]
        Item1P,
        [XmlEnum("2B")]
        Item2B,
        ABG,
        FA,
        PR,
        X3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AdditionalPatientInformationContactName_TS278A3_2010CBD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_AdditionalPatientInformationContactAddress_TS278A3_2010CB {
    [XmlElement(Order=0)]
    public string D_N301_ResponseContactAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ResponseContactAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_AdditionalPatientInformationContactCityStateZipCode_TS278A3_2010CB {
    [XmlElement(Order=0)]
    public string D_N401_ResponseContactCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ResponseContactStateOrProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ResponseContactPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_ResponseContactCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_ResponseContactSpecificLocation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010CB {
    [XmlElement(Order=0)]
    public S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010CBD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010CBD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_HL_DependentLevel_TS278A3_2000D S_HL_DependentLevel_TS278A3_2000D {get; set;}
    [XmlElement("S_TRN_PatientEventTrackingNumber_TS278A3_2000D",Order=1)]
    public List<S_TRN_PatientEventTrackingNumber_TS278A3_2000D> S_TRN_PatientEventTrackingNumber_TS278A3_2000D {get; set;}
    [XmlElement("S_AAA_DependentRequestValidation_TS278A3_2000D",Order=2)]
    public List<S_AAA_DependentRequestValidation_TS278A3_2000D> S_AAA_DependentRequestValidation_TS278A3_2000D {get; set;}
    [XmlElement(Order=3)]
    public A_DTP_TS278A3_2000D A_DTP_TS278A3_2000D {get; set;}
    [XmlElement(Order=4)]
    public S_HI_DependentDiagnosis_TS278A3_2000D S_HI_DependentDiagnosis_TS278A3_2000D {get; set;}
    [XmlElement("S_PWK_AdditionalPatientInformation_TS278A3_2000D",Order=5)]
    public List<S_PWK_AdditionalPatientInformation_TS278A3_2000D> S_PWK_AdditionalPatientInformation_TS278A3_2000D {get; set;}
    [XmlElement(Order=6)]
    public A_TS278A3_2010D A_TS278A3_2010D {get; set;}
    [XmlElement("G_TS278A3_2000E",Order=7)]
    public List<G_TS278A3_2000E> G_TS278A3_2000E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_DependentLevel_TS278A3_2000D {
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
    public class S_TRN_PatientEventTrackingNumber_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_TRN_PatientEventTrackingNumber_TS278A3_2000DD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_PatientEventTrackingNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_PatientEventTrackingNumber_TS278A3_2000DD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_DependentRequestValidation_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_AAA_DependentRequestValidation_TS278A3_2000DD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_DependentRequestValidation_TS278A3_2000DD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_TS278A3_2000D {
    [XmlElementAttribute(Order=0)]
    public S_DTP_AccidentDate_TS278A3_2000D S_DTP_AccidentDate_TS278A3_2000D {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A3_2000D S_DTP_LastMenstrualPeriodDate_TS278A3_2000D {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_EstimatedDateOfBirth_TS278A3_2000D S_DTP_EstimatedDateOfBirth_TS278A3_2000D {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000D S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AccidentDate_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_DTP_AccidentDate_TS278A3_2000DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_AccidentDate_TS278A3_2000DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_AccidentDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AccidentDate_TS278A3_2000DD_DTP01_DateTimeQualifier {
        [XmlEnum("439")]
        Item439,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AccidentDate_TS278A3_2000DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_LastMenstrualPeriodDate_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_DTP_LastMenstrualPeriodDate_TS278A3_2000DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_LastMenstrualPeriodDate_TS278A3_2000DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_LastMenstrualPeriodDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LastMenstrualPeriodDate_TS278A3_2000DD_DTP01_DateTimeQualifier {
        [XmlEnum("484")]
        Item484,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_LastMenstrualPeriodDate_TS278A3_2000DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_EstimatedDateOfBirth_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_DTP_EstimatedDateOfBirth_TS278A3_2000DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_EstimatedDateOfBirth_TS278A3_2000DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_EstimatedBirthDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_EstimatedDateOfBirth_TS278A3_2000DD_DTP01_DateTimeQualifier {
        ABC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_EstimatedDateOfBirth_TS278A3_2000DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000DD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000DD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_OnsetDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000DD_DTP01_DateTimeQualifier {
        [XmlEnum("431")]
        Item431,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_OnsetOfCurrentSymptomsOrIllnessDate_TS278A3_2000DD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_DependentDiagnosis_TS278A3_2000D {
    [XmlElement(Order=0)]
    public C_HI01_C022U557_TS278A3_2000D C_HI01_C022U557_TS278A3_2000D {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U565_TS278A3_2000D C_HI02_C022U565_TS278A3_2000D {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U573_TS278A3_2000D C_HI03_C022U573_TS278A3_2000D {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U581_TS278A3_2000D C_HI04_C022U581_TS278A3_2000D {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U589_TS278A3_2000D C_HI05_C022U589_TS278A3_2000D {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U597_TS278A3_2000D C_HI06_C022U597_TS278A3_2000D {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U605_TS278A3_2000D C_HI07_C022U605_TS278A3_2000D {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U613_TS278A3_2000D C_HI08_C022U613_TS278A3_2000D {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U621_TS278A3_2000D C_HI09_C022U621_TS278A3_2000D {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U629_TS278A3_2000D C_HI10_C022U629_TS278A3_2000D {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U637_TS278A3_2000D C_HI11_C022U637_TS278A3_2000D {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U645_TS278A3_2000D C_HI12_C022U645_TS278A3_2000D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U557_TS278A3_2000D {
    [XmlElement(Order=0)]
    public C_HI01_C022U557_TS278A3_2000DD_HI01_C02201U558_DiagnosisTypeCode D_HI01_C02201U558_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U559_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U560_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U561_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U5567 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U5568 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U5569 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U557_TS278A3_2000DD_HI01_C02201U558_DiagnosisTypeCode {
        BF,
        BJ,
        BK,
        LOI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U565_TS278A3_2000D {
    [XmlElement(Order=0)]
    public C_HI02_C022U565_TS278A3_2000DD_HI02_C02201U566_DiagnosisTypeCode D_HI02_C02201U566_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U567_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U568_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U569_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U5575 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U5576 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U5577 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U565_TS278A3_2000DD_HI02_C02201U566_DiagnosisTypeCode {
        BF,
        BJ,
        LOI,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U573_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U574_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U575_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U576_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U577_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U5583 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U5584 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U5585 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U581_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U582_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U583_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U584_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U585_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U5591 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U5592 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U5593 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U589_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U590_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U591_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U592_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U593_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U5599 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U5600 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U5601 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U597_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U598_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U599_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U600_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U601_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U5607 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U5608 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U5609 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U605_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U606_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U607_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U608_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U609_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U5615 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U5616 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U5617 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U613_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U614_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U615_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U616_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U617_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U5623 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U5624 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U5625 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U621_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U622_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U623_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U624_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U625_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U5631 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U5632 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U5633 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U629_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U630_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U631_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U632_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U633_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U5639 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U5640 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U5641 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U637_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U638_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U639_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U640_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U641_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U5647 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U5648 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U5649 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U645_TS278A3_2000D {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U646_DiagnosisTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U647_DiagnosisCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U648_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U649_DiagnosisDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U5655 {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U5656 {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U5657 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PWK_AdditionalPatientInformation_TS278A3_2000D {
    [XmlElement(Order=0)]
    public S_PWK_AdditionalPatientInformation_TS278A3_2000DD_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_AdditionalPatientInformation_TS278A3_2000DD_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
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
    public string D_PWK08_C002U5658 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalPatientInformation_TS278A3_2000DD_PWK01_AttachmentReportTypeCode {
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalPatientInformation_TS278A3_2000DD_PWK02_AttachmentTransmissionCode {
        BM,
        EL,
        EM,
        FX,
        VO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_TS278A3_2010D {
    [XmlElementAttribute(Order=0)]
    public G_TS278A3_2010DA G_TS278A3_2010DA {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS278A3_2010DB G_TS278A3_2010DB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010DA {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS278A3_2010DA S_NM1_DependentName_TS278A3_2010DA {get; set;}
    [XmlElement("S_REF_DependentSupplementalIdentification_TS278A3_2010DA",Order=1)]
    public List<S_REF_DependentSupplementalIdentification_TS278A3_2010DA> S_REF_DependentSupplementalIdentification_TS278A3_2010DA {get; set;}
    [XmlElement("S_AAA_DependentRequestValidation_TS278A3_2010DA",Order=2)]
    public List<S_AAA_DependentRequestValidation_TS278A3_2010DA> S_AAA_DependentRequestValidation_TS278A3_2010DA {get; set;}
    [XmlElement(Order=3)]
    public S_DMG_DependentDemographicInformation_TS278A3_2010DA S_DMG_DependentDemographicInformation_TS278A3_2010DA {get; set;}
    [XmlElement(Order=4)]
    public S_INS_DependentRelationship_TS278A3_2010DA S_INS_DependentRelationship_TS278A3_2010DA {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DependentName_TS278A3_2010DA {
    [XmlElement(Order=0)]
    public S_NM1_DependentName_TS278A3_2010DAD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_DependentName_TS278A3_2010DAD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_DependentName_TS278A3_2010DAD_NM101_EntityIdentifierCode {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_DependentName_TS278A3_2010DAD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_DependentSupplementalIdentification_TS278A3_2010DA {
    [XmlElement(Order=0)]
    public S_REF_DependentSupplementalIdentification_TS278A3_2010DAD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_DependentSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U5659 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_DependentSupplementalIdentification_TS278A3_2010DAD_REF01_ReferenceIdentificationQualifier {
        A6,
        EJ,
        SY,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_DependentRequestValidation_TS278A3_2010DA {
    [XmlElement(Order=0)]
    public S_AAA_DependentRequestValidation_TS278A3_2010DAD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_DependentRequestValidation_TS278A3_2010DAD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_DependentDemographicInformation_TS278A3_2010DA {
    [XmlElement(Order=0)]
    public S_DMG_DependentDemographicInformation_TS278A3_2010DAD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
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
    public enum S_DMG_DependentDemographicInformation_TS278A3_2010DAD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_DependentRelationship_TS278A3_2010DA {
    [XmlElement(Order=0)]
    public S_INS_DependentRelationship_TS278A3_2010DAD_INS01_InsuredIndicator D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_INS_DependentRelationship_TS278A3_2010DAD_INS02_IndividualRelationshipCode D_INS02_IndividualRelationshipCode {get; set;}
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
    public enum S_INS_DependentRelationship_TS278A3_2010DAD_INS01_InsuredIndicator {
        N,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_DependentRelationship_TS278A3_2010DAD_INS02_IndividualRelationshipCode {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("04")]
        Item04,
        [XmlEnum("05")]
        Item05,
        [XmlEnum("07")]
        Item07,
        [XmlEnum("09")]
        Item09,
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
        [XmlEnum("34")]
        Item34,
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
    public class G_TS278A3_2010DB {
    [XmlElement(Order=0)]
    public S_NM1_AdditionalPatientInformationContactName_TS278A3_2010DB S_NM1_AdditionalPatientInformationContactName_TS278A3_2010DB {get; set;}
    [XmlElement(Order=1)]
    public S_N3_AdditionalPatientInformationContactAddress_TS278A3_2010DB S_N3_AdditionalPatientInformationContactAddress_TS278A3_2010DB {get; set;}
    [XmlElement(Order=2)]
    public S_N4_AdditionalPatientInformationContactCityStateZipCode_TS278A3_2010DB S_N4_AdditionalPatientInformationContactCityStateZipCode_TS278A3_2010DB {get; set;}
    [XmlElement(Order=3)]
    public S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010DB S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010DB {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AdditionalPatientInformationContactName_TS278A3_2010DB {
    [XmlElement(Order=0)]
    public S_NM1_AdditionalPatientInformationContactName_TS278A3_2010DBD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_AdditionalPatientInformationContactName_TS278A3_2010DBD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ResponseContactLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ResponseContactFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ResponseContactMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ResponseContactNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ResponseContactIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AdditionalPatientInformationContactName_TS278A3_2010DBD_NM101_EntityIdentifierCode {
        [XmlEnum("1P")]
        Item1P,
        [XmlEnum("2B")]
        Item2B,
        ABG,
        FA,
        PR,
        X3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AdditionalPatientInformationContactName_TS278A3_2010DBD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_AdditionalPatientInformationContactAddress_TS278A3_2010DB {
    [XmlElement(Order=0)]
    public string D_N301_ResponseContactAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ResponseContactAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_AdditionalPatientInformationContactCityStateZipCode_TS278A3_2010DB {
    [XmlElement(Order=0)]
    public string D_N401_ResponseContactCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ResponseContactStateOrProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ResponseContactPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_ResponseContactCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_ResponseContactSpecificLocation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010DB {
    [XmlElement(Order=0)]
    public S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010DBD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_AdditionalPatientInformationContactInformation_TS278A3_2010DBD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000E {
    [XmlElement(Order=0)]
    public S_HL_ServiceProviderLevel_TS278A3_2000E S_HL_ServiceProviderLevel_TS278A3_2000E {get; set;}
    [XmlElement(Order=1)]
    public S_MSG_MessageText_TS278A3_2000E S_MSG_MessageText_TS278A3_2000E {get; set;}
    [XmlElement("G_TS278A3_2010E",Order=2)]
    public List<G_TS278A3_2010E> G_TS278A3_2010E {get; set;}
    [XmlElement("G_TS278A3_2000F",Order=3)]
    public List<G_TS278A3_2000F> G_TS278A3_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_ServiceProviderLevel_TS278A3_2000E {
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
    public class S_MSG_MessageText_TS278A3_2000E {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02 {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010E {
    [XmlElement(Order=0)]
    public S_NM1_ServiceProviderName_TS278A3_2010E S_NM1_ServiceProviderName_TS278A3_2010E {get; set;}
    [XmlElement("S_REF_ServiceProviderSupplementalIdentification_TS278A3_2010E",Order=1)]
    public List<S_REF_ServiceProviderSupplementalIdentification_TS278A3_2010E> S_REF_ServiceProviderSupplementalIdentification_TS278A3_2010E {get; set;}
    [XmlElement(Order=2)]
    public S_N3_ServiceProviderAddress_TS278A3_2010E S_N3_ServiceProviderAddress_TS278A3_2010E {get; set;}
    [XmlElement(Order=3)]
    public S_N4_ServiceProviderCityStateZIPCode_TS278A3_2010E S_N4_ServiceProviderCityStateZIPCode_TS278A3_2010E {get; set;}
    [XmlElement(Order=4)]
    public S_PER_ServiceProviderContactInformation_TS278A3_2010E S_PER_ServiceProviderContactInformation_TS278A3_2010E {get; set;}
    [XmlElement("S_AAA_ServiceProviderRequestValidation_TS278A3_2010E",Order=5)]
    public List<S_AAA_ServiceProviderRequestValidation_TS278A3_2010E> S_AAA_ServiceProviderRequestValidation_TS278A3_2010E {get; set;}
    [XmlElement(Order=6)]
    public S_PRV_ServiceProviderInformation_TS278A3_2010E S_PRV_ServiceProviderInformation_TS278A3_2010E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceProviderName_TS278A3_2010E {
    [XmlElement(Order=0)]
    public S_NM1_ServiceProviderName_TS278A3_2010ED_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ServiceProviderName_TS278A3_2010ED_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ServiceProviderLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ServiceProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ServiceProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ServiceProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ServiceProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceProviderName_TS278A3_2010ED_NM101_EntityIdentifierCode {
        [XmlEnum("1T")]
        Item1T,
        FA,
        SJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceProviderName_TS278A3_2010ED_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceProviderSupplementalIdentification_TS278A3_2010E {
    [XmlElement(Order=0)]
    public S_REF_ServiceProviderSupplementalIdentification_TS278A3_2010ED_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ServiceProviderSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U654 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceProviderSupplementalIdentification_TS278A3_2010ED_REF01_ReferenceIdentificationQualifier {
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
    public class S_N3_ServiceProviderAddress_TS278A3_2010E {
    [XmlElement(Order=0)]
    public string D_N301_ServiceProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ServiceProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ServiceProviderCityStateZIPCode_TS278A3_2010E {
    [XmlElement(Order=0)]
    public string D_N401_ServiceProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ServiceProviderStateOrProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ServiceProviderPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_ServiceProviderCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_ServiceProviderContactInformation_TS278A3_2010E {
    [XmlElement(Order=0)]
    public S_PER_ServiceProviderContactInformation_TS278A3_2010ED_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_ServiceProviderContactInformation_TS278A3_2010ED_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_ServiceProviderRequestValidation_TS278A3_2010E {
    [XmlElement(Order=0)]
    public S_AAA_ServiceProviderRequestValidation_TS278A3_2010ED_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_ServiceProviderRequestValidation_TS278A3_2010ED_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PRV_ServiceProviderInformation_TS278A3_2010E {
    [XmlElement(Order=0)]
    public S_PRV_ServiceProviderInformation_TS278A3_2010ED_PRV01_ProviderCode D_PRV01_ProviderCode {get; set;}
    [XmlElement(Order=1)]
    public S_PRV_ServiceProviderInformation_TS278A3_2010ED_PRV02_ReferenceIdentificationQualifier D_PRV02_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_PRV03_ProviderTaxonomyCode {get; set;}
    [XmlElement(Order=3)]
    public string D_PRV04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PRV05_C035U655 {get; set;}
    [XmlElement(Order=5)]
    public string D_PRV06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ServiceProviderInformation_TS278A3_2010ED_PRV01_ProviderCode {
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
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PRV_ServiceProviderInformation_TS278A3_2010ED_PRV02_ReferenceIdentificationQualifier {
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_HL_ServiceLevel_TS278A3_2000F S_HL_ServiceLevel_TS278A3_2000F {get; set;}
    [XmlElement("S_TRN_ServiceTraceNumber_TS278A3_2000F",Order=1)]
    public List<S_TRN_ServiceTraceNumber_TS278A3_2000F> S_TRN_ServiceTraceNumber_TS278A3_2000F {get; set;}
    [XmlElement("S_AAA_ServiceRequestValidation_TS278A3_2000F",Order=2)]
    public List<S_AAA_ServiceRequestValidation_TS278A3_2000F> S_AAA_ServiceRequestValidation_TS278A3_2000F {get; set;}
    [XmlElement(Order=3)]
    public S_UM_HealthCareServicesReviewInformation_TS278A3_2000F S_UM_HealthCareServicesReviewInformation_TS278A3_2000F {get; set;}
    [XmlElement(Order=4)]
    public S_HCR_HealthCareServicesReview_TS278A3_2000F S_HCR_HealthCareServicesReview_TS278A3_2000F {get; set;}
    [XmlElement(Order=5)]
    public S_REF_PreviousCertificationIdentification_TS278A3_2000F S_REF_PreviousCertificationIdentification_TS278A3_2000F {get; set;}
    [XmlElement(Order=6)]
    public A_DTP_TS278A3_2000F A_DTP_TS278A3_2000F {get; set;}
    [XmlElement(Order=7)]
    public S_HI_Procedures_TS278A3_2000F S_HI_Procedures_TS278A3_2000F {get; set;}
    [XmlElement(Order=8)]
    public S_HSD_HealthCareServicesDelivery_TS278A3_2000F S_HSD_HealthCareServicesDelivery_TS278A3_2000F {get; set;}
    [XmlElement(Order=9)]
    public S_CL1_InstitutionalClaimCode_TS278A3_2000F S_CL1_InstitutionalClaimCode_TS278A3_2000F {get; set;}
    [XmlElement(Order=10)]
    public S_CR1_AmbulanceTransportInformation_TS278A3_2000F S_CR1_AmbulanceTransportInformation_TS278A3_2000F {get; set;}
    [XmlElement(Order=11)]
    public S_CR2_SpinalManipulationServiceInformation_TS278A3_2000F S_CR2_SpinalManipulationServiceInformation_TS278A3_2000F {get; set;}
    [XmlElement(Order=12)]
    public S_CR5_HomeOxygenTherapyInformation_TS278A3_2000F S_CR5_HomeOxygenTherapyInformation_TS278A3_2000F {get; set;}
    [XmlElement(Order=13)]
    public S_CR6_HomeHealthCareInformation_TS278A3_2000F S_CR6_HomeHealthCareInformation_TS278A3_2000F {get; set;}
    [XmlElement("S_PWK_AdditionalServiceInformation_TS278A3_2000F",Order=14)]
    public List<S_PWK_AdditionalServiceInformation_TS278A3_2000F> S_PWK_AdditionalServiceInformation_TS278A3_2000F {get; set;}
    [XmlElement(Order=15)]
    public S_MSG_MessageText_TS278A3_2000F S_MSG_MessageText_TS278A3_2000F {get; set;}
    [XmlElement(Order=16)]
    public G_TS278A3_2010F G_TS278A3_2010F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HL_ServiceLevel_TS278A3_2000F {
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
    public class S_TRN_ServiceTraceNumber_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_TRN_ServiceTraceNumber_TS278A3_2000FD_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_ServiceTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_TraceAssigningEntityIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_TraceAssigningEntityAdditionalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_ServiceTraceNumber_TS278A3_2000FD_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AAA_ServiceRequestValidation_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_AAA_ServiceRequestValidation_TS278A3_2000FD_AAA01_ValidRequestIndicator D_AAA01_ValidRequestIndicator {get; set;}
    [XmlElement(Order=1)]
    public string D_AAA02 {get; set;}
    [XmlElement(Order=2)]
    public string D_AAA03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_AAA04_FollowupActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AAA_ServiceRequestValidation_TS278A3_2000FD_AAA01_ValidRequestIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_UM_HealthCareServicesReviewInformation_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_UM_HealthCareServicesReviewInformation_TS278A3_2000FD_UM01_RequestCategoryCode D_UM01_RequestCategoryCode {get; set;}
    [XmlElement(Order=1)]
    public S_UM_HealthCareServicesReviewInformation_TS278A3_2000FD_UM02_CertificationTypeCode D_UM02_CertificationTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_UM03_ServiceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public C_UM04_C023U656_TS278A3_2000F C_UM04_C023U656_TS278A3_2000F {get; set;}
    [XmlElement(Order=4)]
    public string D_UM05_C024U660 {get; set;}
    [XmlElement(Order=5)]
    public string D_UM06_LevelOfServiceCode {get; set;}
    [XmlElement(Order=6)]
    public string D_UM07 {get; set;}
    [XmlElement(Order=7)]
    public string D_UM08 {get; set;}
    [XmlElement(Order=8)]
    public string D_UM09 {get; set;}
    [XmlElement(Order=9)]
    public string D_UM10 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_UM_HealthCareServicesReviewInformation_TS278A3_2000FD_UM01_RequestCategoryCode {
        AR,
        HS,
        SC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_UM_HealthCareServicesReviewInformation_TS278A3_2000FD_UM02_CertificationTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("4")]
        Item4,
        I,
        R,
        S,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_UM04_C023U656_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_UM04_C02301U657_FacilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_UM04_C02302U658_FacilityCodeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_UM04_C02303U5665 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HCR_HealthCareServicesReview_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_HCR_HealthCareServicesReview_TS278A3_2000FD_HCR01_ActionCode D_HCR01_ActionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HCR02_CertificationNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_HCR03_RejectReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HCR04_SecondSurgicalOpinionIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_HCR_HealthCareServicesReview_TS278A3_2000FD_HCR01_ActionCode {
        A1,
        A3,
        A4,
        A6,
        CT,
        NA,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PreviousCertificationIdentification_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_REF_PreviousCertificationIdentification_TS278A3_2000FD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PreviousCertificationIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U661 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PreviousCertificationIdentification_TS278A3_2000FD_REF01_ReferenceIdentificationQualifier {
        BB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTP_TS278A3_2000F {
    [XmlElementAttribute(Order=0)]
    public S_DTP_ServiceDate_TS278A3_2000F S_DTP_ServiceDate_TS278A3_2000F {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTP_AdmissionDate_TS278A3_2000F S_DTP_AdmissionDate_TS278A3_2000F {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTP_DischargeDate_TS278A3_2000F S_DTP_DischargeDate_TS278A3_2000F {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTP_SurgeryDate_TS278A3_2000F S_DTP_SurgeryDate_TS278A3_2000F {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_DTP_CertificationIssueDate_TS278A3_2000F S_DTP_CertificationIssueDate_TS278A3_2000F {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_DTP_CertificationExpirationDate_TS278A3_2000F S_DTP_CertificationExpirationDate_TS278A3_2000F {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_DTP_CertificationEffectiveDate_TS278A3_2000F S_DTP_CertificationEffectiveDate_TS278A3_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_ServiceDate_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_DTP_ServiceDate_TS278A3_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_ServiceDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedOrActualServiceDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceDate_TS278A3_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_ServiceDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_AdmissionDate_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_DTP_AdmissionDate_TS278A3_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_AdmissionDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedOrActualAdmissionDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AdmissionDate_TS278A3_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("435")]
        Item435,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_AdmissionDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DischargeDate_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_DTP_DischargeDate_TS278A3_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DischargeDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedOrActualDischargeDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DischargeDate_TS278A3_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("096")]
        Item096,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DischargeDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_SurgeryDate_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_DTP_SurgeryDate_TS278A3_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_SurgeryDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_ProposedOrActualSurgeryDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SurgeryDate_TS278A3_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("456")]
        Item456,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_SurgeryDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationIssueDate_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_DTP_CertificationIssueDate_TS278A3_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_CertificationIssueDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationIssueDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_CertificationIssueDate_TS278A3_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("102")]
        Item102,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_CertificationIssueDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationExpirationDate_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_DTP_CertificationExpirationDate_TS278A3_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_CertificationExpirationDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationExpirationDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_CertificationExpirationDate_TS278A3_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("036")]
        Item036,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_CertificationExpirationDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CertificationEffectiveDate_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_DTP_CertificationEffectiveDate_TS278A3_2000FD_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_CertificationEffectiveDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CertificationEffectiveDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_CertificationEffectiveDate_TS278A3_2000FD_DTP01_DateTimeQualifier {
        [XmlEnum("007")]
        Item007,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_CertificationEffectiveDate_TS278A3_2000FD_DTP02_DateTimePeriodFormatQualifier {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HI_Procedures_TS278A3_2000F {
    [XmlElement(Order=0)]
    public C_HI01_C022U662_TS278A3_2000F C_HI01_C022U662_TS278A3_2000F {get; set;}
    [XmlElement(Order=1)]
    public C_HI02_C022U670_TS278A3_2000F C_HI02_C022U670_TS278A3_2000F {get; set;}
    [XmlElement(Order=2)]
    public C_HI03_C022U678_TS278A3_2000F C_HI03_C022U678_TS278A3_2000F {get; set;}
    [XmlElement(Order=3)]
    public C_HI04_C022U686_TS278A3_2000F C_HI04_C022U686_TS278A3_2000F {get; set;}
    [XmlElement(Order=4)]
    public C_HI05_C022U694_TS278A3_2000F C_HI05_C022U694_TS278A3_2000F {get; set;}
    [XmlElement(Order=5)]
    public C_HI06_C022U702_TS278A3_2000F C_HI06_C022U702_TS278A3_2000F {get; set;}
    [XmlElement(Order=6)]
    public C_HI07_C022U710_TS278A3_2000F C_HI07_C022U710_TS278A3_2000F {get; set;}
    [XmlElement(Order=7)]
    public C_HI08_C022U718_TS278A3_2000F C_HI08_C022U718_TS278A3_2000F {get; set;}
    [XmlElement(Order=8)]
    public C_HI09_C022U726_TS278A3_2000F C_HI09_C022U726_TS278A3_2000F {get; set;}
    [XmlElement(Order=9)]
    public C_HI10_C022U734_TS278A3_2000F C_HI10_C022U734_TS278A3_2000F {get; set;}
    [XmlElement(Order=10)]
    public C_HI11_C022U742_TS278A3_2000F C_HI11_C022U742_TS278A3_2000F {get; set;}
    [XmlElement(Order=11)]
    public C_HI12_C022U750_TS278A3_2000F C_HI12_C022U750_TS278A3_2000F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI01_C022U662_TS278A3_2000F {
    [XmlElement(Order=0)]
    public C_HI01_C022U662_TS278A3_2000FD_HI01_C02201U663_CodeListQualifierCode D_HI01_C02201U663_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI01_C02202U664_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI01_C02203U665_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI01_C02204U666_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI01_C02205U5673_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI01_C02206U668_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI01_C02207U669_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI01_C022U662_TS278A3_2000FD_HI01_C02201U663_CodeListQualifierCode {
        ABR,
        BO,
        BQ,
        JP,
        LOI,
        NDC,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI02_C022U670_TS278A3_2000F {
    [XmlElement(Order=0)]
    public C_HI02_C022U670_TS278A3_2000FD_HI02_C02201U671_CodeListQualifierCode D_HI02_C02201U671_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI02_C02202U672_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI02_C02203U673_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI02_C02204U674_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI02_C02205U5681_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI02_C02206U676_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI02_C02207U677_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_HI02_C022U670_TS278A3_2000FD_HI02_C02201U671_CodeListQualifierCode {
        ABR,
        BO,
        BQ,
        JP,
        LOI,
        NDC,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI03_C022U678_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI03_C02201U679_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI03_C02202U680_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI03_C02203U681_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI03_C02204U682_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI03_C02205U5689_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI03_C02206U684_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI03_C02207U685_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI04_C022U686_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI04_C02201U687_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI04_C02202U688_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI04_C02203U689_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI04_C02204U690_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI04_C02205U5697_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI04_C02206U692_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI04_C02207U693_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI05_C022U694_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI05_C02201U695_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI05_C02202U696_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI05_C02203U697_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI05_C02204U698_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI05_C02205U5705_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI05_C02206U700_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI05_C02207U701_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI06_C022U702_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI06_C02201U703_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI06_C02202U704_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI06_C02203U705_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI06_C02204U706_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI06_C02205U5713_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI06_C02206U708_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI06_C02207U709_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI07_C022U710_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI07_C02201U711_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI07_C02202U712_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI07_C02203U713_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI07_C02204U714_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI07_C02205U5721_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI07_C02206U716_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI07_C02207U717_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI08_C022U718_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI08_C02201U719_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI08_C02202U720_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI08_C02203U721_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI08_C02204U722_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI08_C02205U5729_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI08_C02206U724_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI08_C02207U725_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI09_C022U726_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI09_C02201U727_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI09_C02202U728_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI09_C02203U729_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI09_C02204U730_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI09_C02205U5737_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI09_C02206U732_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI09_C02207U733_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI10_C022U734_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI10_C02201U735_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI10_C02202U736_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI10_C02203U737_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI10_C02204U738_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI10_C02205U5745_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI10_C02206U740_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI10_C02207U741_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI11_C022U742_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI11_C02201U743_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI11_C02202U744_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI11_C02203U745_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI11_C02204U746_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI11_C02205U5753_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI11_C02206U748_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI11_C02207U749_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_HI12_C022U750_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_HI12_C02201U751_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HI12_C02202U752_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HI12_C02203U753_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_HI12_C02204U754_ProcedureDate {get; set;}
    [XmlElement(Order=4)]
    public string D_HI12_C02205U5761_ProcedureMonetaryAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_HI12_C02206U756_ProcedureQuantity {get; set;}
    [XmlElement(Order=6)]
    public string D_HI12_C02207U757_VersionReleaseOrIndustryIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HSD_HealthCareServicesDelivery_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_HSD_HealthCareServicesDelivery_TS278A3_2000FD_HSD01_QuantityQualifier D_HSD01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_HSD02_ServiceUnitCount {get; set;}
    [XmlElement(Order=2)]
    public string D_HSD03_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HSD04_SampleSelectionModulus {get; set;}
    [XmlElement(Order=4)]
    public string D_HSD05_TimePeriodQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_HSD06_PeriodCount {get; set;}
    [XmlElement(Order=6)]
    public string D_HSD07_ShipDeliveryOrCalendarPatternCode {get; set;}
    [XmlElement(Order=7)]
    public string D_HSD08_DeliveryPatternTimeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_HSD_HealthCareServicesDelivery_TS278A3_2000FD_HSD01_QuantityQualifier {
        DY,
        FL,
        HS,
        MN,
        VS,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CL1_InstitutionalClaimCode_TS278A3_2000F {
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
    public class S_CR1_AmbulanceTransportInformation_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_CR101 {get; set;}
    [XmlElement(Order=1)]
    public string D_CR102 {get; set;}
    [XmlElement(Order=2)]
    public string D_CR103_AmbulanceTransportCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR104 {get; set;}
    [XmlElement(Order=4)]
    public string D_CR105_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CR106_TransportDistance {get; set;}
    [XmlElement(Order=6)]
    public string D_CR107_AmbulanceTripOriginAddress {get; set;}
    [XmlElement(Order=7)]
    public string D_CR108_AmbulanceTripDestinationAddress {get; set;}
    [XmlElement(Order=8)]
    public string D_CR109 {get; set;}
    [XmlElement(Order=9)]
    public string D_CR110 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR2_SpinalManipulationServiceInformation_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_CR201_TreatmentSeriesNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_CR202_TreatmentCount {get; set;}
    [XmlElement(Order=2)]
    public string D_CR203_SubluxationLevelCode {get; set;}
    [XmlElement(Order=3)]
    public string D_CR204_SubluxationLevelCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CR205_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CR206_TreatmentPeriodCount {get; set;}
    [XmlElement(Order=6)]
    public string D_CR207_MonthlyTreatmentCount {get; set;}
    [XmlElement(Order=7)]
    public string D_CR208 {get; set;}
    [XmlElement(Order=8)]
    public string D_CR209 {get; set;}
    [XmlElement(Order=9)]
    public string D_CR210 {get; set;}
    [XmlElement(Order=10)]
    public string D_CR211 {get; set;}
    [XmlElement(Order=11)]
    public string D_CR212 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR5_HomeOxygenTherapyInformation_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_CR501 {get; set;}
    [XmlElement(Order=1)]
    public string D_CR502 {get; set;}
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
    public string D_CR510 {get; set;}
    [XmlElement(Order=10)]
    public string D_CR511 {get; set;}
    [XmlElement(Order=11)]
    public string D_CR512 {get; set;}
    [XmlElement(Order=12)]
    public string D_CR513 {get; set;}
    [XmlElement(Order=13)]
    public string D_CR514 {get; set;}
    [XmlElement(Order=14)]
    public string D_CR515 {get; set;}
    [XmlElement(Order=15)]
    public string D_CR516_PortableOxygenSystemFlowRate {get; set;}
    [XmlElement(Order=16)]
    public string D_CR517_OxygenDeliverySystemCode {get; set;}
    [XmlElement(Order=17)]
    public string D_CR518_OxygenEquipmentTypeCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CR6_HomeHealthCareInformation_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_CR6_HomeHealthCareInformation_TS278A3_2000FD_CR601_PrognosisCode D_CR601_PrognosisCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CR602_ServiceFromDate {get; set;}
    [XmlElement(Order=2)]
    public string D_CR603_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_CR604_HomeHealthCertificationPeriod {get; set;}
    [XmlElement(Order=4)]
    public string D_CR605 {get; set;}
    [XmlElement(Order=5)]
    public string D_CR606 {get; set;}
    [XmlElement(Order=6)]
    public string D_CR607_MedicareCoverageIndicator {get; set;}
    [XmlElement(Order=7)]
    public string D_CR608_CertificationTypeCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CR609 {get; set;}
    [XmlElement(Order=9)]
    public string D_CR610 {get; set;}
    [XmlElement(Order=10)]
    public string D_CR611 {get; set;}
    [XmlElement(Order=11)]
    public string D_CR612 {get; set;}
    [XmlElement(Order=12)]
    public string D_CR613 {get; set;}
    [XmlElement(Order=13)]
    public string D_CR614 {get; set;}
    [XmlElement(Order=14)]
    public string D_CR615 {get; set;}
    [XmlElement(Order=15)]
    public string D_CR616 {get; set;}
    [XmlElement(Order=16)]
    public string D_CR617 {get; set;}
    [XmlElement(Order=17)]
    public string D_CR618 {get; set;}
    [XmlElement(Order=18)]
    public string D_CR619 {get; set;}
    [XmlElement(Order=19)]
    public string D_CR620 {get; set;}
    [XmlElement(Order=20)]
    public string D_CR621 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CR6_HomeHealthCareInformation_TS278A3_2000FD_CR601_PrognosisCode {
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
    public class S_PWK_AdditionalServiceInformation_TS278A3_2000F {
    [XmlElement(Order=0)]
    public S_PWK_AdditionalServiceInformation_TS278A3_2000FD_PWK01_AttachmentReportTypeCode D_PWK01_AttachmentReportTypeCode {get; set;}
    [XmlElement(Order=1)]
    public S_PWK_AdditionalServiceInformation_TS278A3_2000FD_PWK02_AttachmentTransmissionCode D_PWK02_AttachmentTransmissionCode {get; set;}
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
    public string D_PWK08_C002U5764 {get; set;}
    [XmlElement(Order=8)]
    public string D_PWK09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalServiceInformation_TS278A3_2000FD_PWK01_AttachmentReportTypeCode {
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PWK_AdditionalServiceInformation_TS278A3_2000FD_PWK02_AttachmentTransmissionCode {
        BM,
        EL,
        EM,
        FX,
        VO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MSG_MessageText_TS278A3_2000F {
    [XmlElement(Order=0)]
    public string D_MSG01_FreeFormMessageText {get; set;}
    [XmlElement(Order=1)]
    public string D_MSG02 {get; set;}
    [XmlElement(Order=2)]
    public string D_MSG03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS278A3_2010F {
    [XmlElement(Order=0)]
    public S_NM1_AdditionalServiceInformationContactName_TS278A3_2010F S_NM1_AdditionalServiceInformationContactName_TS278A3_2010F {get; set;}
    [XmlElement(Order=1)]
    public S_N3_AdditionalServiceInformationContactAddress_TS278A3_2010F S_N3_AdditionalServiceInformationContactAddress_TS278A3_2010F {get; set;}
    [XmlElement(Order=2)]
    public S_N4_AdditionalServiceInformationContactCityStateZipCode_TS278A3_2010F S_N4_AdditionalServiceInformationContactCityStateZipCode_TS278A3_2010F {get; set;}
    [XmlElement(Order=3)]
    public S_PER_AdditionalServiceInformationContactInformation_TS278A3_2010F S_PER_AdditionalServiceInformationContactInformation_TS278A3_2010F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_AdditionalServiceInformationContactName_TS278A3_2010F {
    [XmlElement(Order=0)]
    public S_NM1_AdditionalServiceInformationContactName_TS278A3_2010FD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_AdditionalServiceInformationContactName_TS278A3_2010FD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ResponseContactLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ResponseContactFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ResponseContactMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ResponseContactNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ResponseContactIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AdditionalServiceInformationContactName_TS278A3_2010FD_NM101_EntityIdentifierCode {
        [XmlEnum("1P")]
        Item1P,
        [XmlEnum("2B")]
        Item2B,
        ABG,
        FA,
        PR,
        X3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_AdditionalServiceInformationContactName_TS278A3_2010FD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_AdditionalServiceInformationContactAddress_TS278A3_2010F {
    [XmlElement(Order=0)]
    public string D_N301_ResponseContactAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ResponseContactAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_AdditionalServiceInformationContactCityStateZipCode_TS278A3_2010F {
    [XmlElement(Order=0)]
    public string D_N401_ResponseContactCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ResponseContactStateOrProvinceCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ResponseContactPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_ResponseContactCountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_ResponseContactSpecificLocation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_AdditionalServiceInformationContactInformation_TS278A3_2010F {
    [XmlElement(Order=0)]
    public S_PER_AdditionalServiceInformationContactInformation_TS278A3_2010FD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_AdditionalServiceInformationContactInformation_TS278A3_2010FD_PER01_ContactFunctionCode {
        IC,
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
