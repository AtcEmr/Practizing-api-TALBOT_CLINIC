namespace EdiFabric.Rules.X12004010X095A1834 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_834 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BGN_BeginningSegment_TS834A1 S_BGN_BeginningSegment_TS834A1 {get; set;}
    [XmlElement(Order=2)]
    public S_REF_TransactionSetPolicyNumber_TS834A1 S_REF_TransactionSetPolicyNumber_TS834A1 {get; set;}
    [XmlElement("S_DTP_FileEffectiveDate_TS834A1",Order=3)]
    public List<S_DTP_FileEffectiveDate_TS834A1> S_DTP_FileEffectiveDate_TS834A1 {get; set;}
    [XmlElement(Order=4)]
    public G_TS834A1_1000A G_TS834A1_1000A {get; set;}
    [XmlElement(Order=5)]
    public G_TS834A1_1000B G_TS834A1_1000B {get; set;}
    [XmlElement("G_TS834A1_1000C",Order=6)]
    public List<G_TS834A1_1000C> G_TS834A1_1000C {get; set;}
    [XmlElement("G_TS834A1_2000",Order=7)]
    public List<G_TS834A1_2000> G_TS834A1_2000 {get; set;}
    [XmlElement(Order=8)]
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
    public class S_BGN_BeginningSegment_TS834A1 {
    [XmlElement(Order=0)]
    public S_BGN_BeginningSegment_TS834A1D_BGN01_TransactionSetPurposeCode D_BGN01_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_BGN02_TransactionSetIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_BGN03_TransactionSetCreationDate {get; set;}
    [XmlElement(Order=3)]
    public string D_BGN04_TransactionSetCreationTime {get; set;}
    [XmlElement(Order=4)]
    public string D_BGN05_TimeZoneCode {get; set;}
    [XmlElement(Order=5)]
    public string D_BGN06_TransactionSetIdentifierCode {get; set;}
    [XmlElement(Order=6)]
    public string D_BGN07 {get; set;}
    [XmlElement(Order=7)]
    public string D_BGN08_ActionCode {get; set;}
    [XmlElement(Order=8)]
    public string D_BGN09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BGN_BeginningSegment_TS834A1D_BGN01_TransactionSetPurposeCode {
        [XmlEnum("00")]
        Item00,
        [XmlEnum("15")]
        Item15,
        [XmlEnum("22")]
        Item22,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_TransactionSetPolicyNumber_TS834A1 {
    [XmlElement(Order=0)]
    public S_REF_TransactionSetPolicyNumber_TS834A1D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MasterPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U775 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_TransactionSetPolicyNumber_TS834A1D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("38")]
        Item38,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_FileEffectiveDate_TS834A1 {
    [XmlElement(Order=0)]
    public S_DTP_FileEffectiveDate_TS834A1D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_FileEffectiveDate_TS834A1D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_FileEffectiveDate_TS834A1D_DTP01_DateTimeQualifier {
        [XmlEnum("007")]
        Item007,
        [XmlEnum("303")]
        Item303,
        [XmlEnum("382")]
        Item382,
        [XmlEnum("388")]
        Item388,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_FileEffectiveDate_TS834A1D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_1000A {
    [XmlElement(Order=0)]
    public S_N1_SponsorName_TS834A1_1000A S_N1_SponsorName_TS834A1_1000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_SponsorName_TS834A1_1000A {
    [XmlElement(Order=0)]
    public S_N1_SponsorName_TS834A1_1000AD_N101_EntityIdentifierCode D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PlanSponsorName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_SponsorIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_N105 {get; set;}
    [XmlElement(Order=5)]
    public string D_N106 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_N1_SponsorName_TS834A1_1000AD_N101_EntityIdentifierCode {
        P5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_1000B {
    [XmlElement(Order=0)]
    public S_N1_Payer_TS834A1_1000B S_N1_Payer_TS834A1_1000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_Payer_TS834A1_1000B {
    [XmlElement(Order=0)]
    public S_N1_Payer_TS834A1_1000BD_N101_EntityIdentifierCode D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_InsurerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_InsurerIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N105 {get; set;}
    [XmlElement(Order=5)]
    public string D_N106 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_N1_Payer_TS834A1_1000BD_N101_EntityIdentifierCode {
        IN,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_1000C {
    [XmlElement(Order=0)]
    public S_N1_TPABrokerName_TS834A1_1000C S_N1_TPABrokerName_TS834A1_1000C {get; set;}
    [XmlElement(Order=1)]
    public G_TS834A1_1100C G_TS834A1_1100C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_TPABrokerName_TS834A1_1000C {
    [XmlElement(Order=0)]
    public S_N1_TPABrokerName_TS834A1_1000CD_N101_EntityIdentifierCode D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_TPAOrBrokerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_TPAOrBrokerIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N105 {get; set;}
    [XmlElement(Order=5)]
    public string D_N106 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_N1_TPABrokerName_TS834A1_1000CD_N101_EntityIdentifierCode {
        BO,
        TV,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_1100C {
    [XmlElement(Order=0)]
    public S_ACT_TPABrokerAccountInformation_TS834A1_1100C S_ACT_TPABrokerAccountInformation_TS834A1_1100C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ACT_TPABrokerAccountInformation_TS834A1_1100C {
    [XmlElement(Order=0)]
    public string D_ACT01_TPAOrBrokerAccountNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_ACT02 {get; set;}
    [XmlElement(Order=2)]
    public string D_ACT03 {get; set;}
    [XmlElement(Order=3)]
    public string D_ACT04 {get; set;}
    [XmlElement(Order=4)]
    public string D_ACT05 {get; set;}
    [XmlElement(Order=5)]
    public string D_ACT06_TPAOrBrokerAccountNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_ACT07 {get; set;}
    [XmlElement(Order=7)]
    public string D_ACT08 {get; set;}
    [XmlElement(Order=8)]
    public string D_ACT09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2000 {
    [XmlElement(Order=0)]
    public S_INS_MemberLevelDetail_TS834A1_2000 S_INS_MemberLevelDetail_TS834A1_2000 {get; set;}
    [XmlElement(Order=1)]
    public A_REF_TS834A1_2000 A_REF_TS834A1_2000 {get; set;}
    [XmlElement("S_DTP_MemberLevelDates_TS834A1_2000",Order=2)]
    public List<S_DTP_MemberLevelDates_TS834A1_2000> S_DTP_MemberLevelDates_TS834A1_2000 {get; set;}
    [XmlElement(Order=3)]
    public G_TS834A1_2100A G_TS834A1_2100A {get; set;}
    [XmlElement(Order=4)]
    public G_TS834A1_2100B G_TS834A1_2100B {get; set;}
    [XmlElement(Order=5)]
    public G_TS834A1_2100C G_TS834A1_2100C {get; set;}
    [XmlElement("G_TS834A1_2100D",Order=6)]
    public List<G_TS834A1_2100D> G_TS834A1_2100D {get; set;}
    [XmlElement("G_TS834A1_2100E",Order=7)]
    public List<G_TS834A1_2100E> G_TS834A1_2100E {get; set;}
    [XmlElement(Order=8)]
    public G_TS834A1_2100F G_TS834A1_2100F {get; set;}
    [XmlElement(Order=9)]
    public G_TS834A1_2100G G_TS834A1_2100G {get; set;}
    [XmlElement(Order=10)]
    public G_TS834A1_2200 G_TS834A1_2200 {get; set;}
    [XmlElement("G_TS834A1_2300",Order=11)]
    public List<G_TS834A1_2300> G_TS834A1_2300 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_MemberLevelDetail_TS834A1_2000 {
    [XmlElement(Order=0)]
    public S_INS_MemberLevelDetail_TS834A1_2000D_INS01_InsuredIndicator D_INS01_InsuredIndicator {get; set;}
    [XmlElement(Order=1)]
    public S_INS_MemberLevelDetail_TS834A1_2000D_INS02_IndividualRelationshipCode D_INS02_IndividualRelationshipCode {get; set;}
    [XmlElement(Order=2)]
    public string D_INS03_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=3)]
    public string D_INS04_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=4)]
    public string D_INS05_BenefitStatusCode {get; set;}
    [XmlElement(Order=5)]
    public string D_INS06_MedicarePlanCode {get; set;}
    [XmlElement(Order=6)]
    public string D_INS07_ConsolidatedOmnibusBudgetReconciliationActCOBRAQualifyingEventCode {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09_StudentStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10_HandicapIndicator {get; set;}
    [XmlElement(Order=10)]
    public string D_INS11_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=11)]
    public string D_INS12_InsuredIndividualDeathDate {get; set;}
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
    public enum S_INS_MemberLevelDetail_TS834A1_2000D_INS01_InsuredIndicator {
        N,
        Y,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_INS_MemberLevelDetail_TS834A1_2000D_INS02_IndividualRelationshipCode {
        [XmlEnum("01")]
        Item01,
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
        [XmlEnum("15")]
        Item15,
        [XmlEnum("17")]
        Item17,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("23")]
        Item23,
        [XmlEnum("24")]
        Item24,
        [XmlEnum("25")]
        Item25,
        [XmlEnum("26")]
        Item26,
        [XmlEnum("31")]
        Item31,
        [XmlEnum("32")]
        Item32,
        [XmlEnum("33")]
        Item33,
        [XmlEnum("38")]
        Item38,
        [XmlEnum("48")]
        Item48,
        [XmlEnum("49")]
        Item49,
        [XmlEnum("53")]
        Item53,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS834A1_2000 {
    [XmlElementAttribute(Order=0)]
    public S_REF_SubscriberNumber_TS834A1_2000 S_REF_SubscriberNumber_TS834A1_2000 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_MemberPolicyNumber_TS834A1_2000 S_REF_MemberPolicyNumber_TS834A1_2000 {get; set;}
    [XmlElement(Order=2)]
    public U_REF_MemberIdentificationNumber_TS834A1_2000 U_REF_MemberIdentificationNumber_TS834A1_2000 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_REF_PriorCoverageMonths_TS834A1_2000 S_REF_PriorCoverageMonths_TS834A1_2000 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberNumber_TS834A1_2000 {
    [XmlElement(Order=0)]
    public S_REF_SubscriberNumber_TS834A1_2000D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U776 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_SubscriberNumber_TS834A1_2000D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("0F")]
        Item0F,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_MemberPolicyNumber_TS834A1_2000 {
    [XmlElement(Order=0)]
    public S_REF_MemberPolicyNumber_TS834A1_2000D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U777 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_MemberPolicyNumber_TS834A1_2000D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1L")]
        Item1L,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_MemberIdentificationNumber_TS834A1_2000 {
    [XmlElement(Order=0)]
    public S_REF_MemberIdentificationNumber_TS834A1_2000D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U778 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_MemberIdentificationNumber_TS834A1_2000D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("17")]
        Item17,
        [XmlEnum("23")]
        Item23,
        [XmlEnum("3H")]
        Item3H,
        [XmlEnum("6O")]
        Item6O,
        DX,
        F6,
        Q4,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PriorCoverageMonths_TS834A1_2000 {
    [XmlElement(Order=0)]
    public S_REF_PriorCoverageMonths_TS834A1_2000D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorCoverageMonthCount {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U779 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PriorCoverageMonths_TS834A1_2000D_REF01_ReferenceIdentificationQualifier {
        QQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_MemberLevelDates_TS834A1_2000 {
    [XmlElement(Order=0)]
    public S_DTP_MemberLevelDates_TS834A1_2000D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_MemberLevelDates_TS834A1_2000D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_StatusInformationEffectiveDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_MemberLevelDates_TS834A1_2000D_DTP01_DateTimeQualifier {
        [XmlEnum("286")]
        Item286,
        [XmlEnum("296")]
        Item296,
        [XmlEnum("297")]
        Item297,
        [XmlEnum("300")]
        Item300,
        [XmlEnum("301")]
        Item301,
        [XmlEnum("303")]
        Item303,
        [XmlEnum("336")]
        Item336,
        [XmlEnum("337")]
        Item337,
        [XmlEnum("338")]
        Item338,
        [XmlEnum("339")]
        Item339,
        [XmlEnum("340")]
        Item340,
        [XmlEnum("341")]
        Item341,
        [XmlEnum("350")]
        Item350,
        [XmlEnum("351")]
        Item351,
        [XmlEnum("356")]
        Item356,
        [XmlEnum("357")]
        Item357,
        [XmlEnum("383")]
        Item383,
        [XmlEnum("393")]
        Item393,
        [XmlEnum("394")]
        Item394,
        [XmlEnum("473")]
        Item473,
        [XmlEnum("474")]
        Item474,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_MemberLevelDates_TS834A1_2000D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2100A {
    [XmlElement(Order=0)]
    public S_NM1_MemberName_TS834A1_2100A S_NM1_MemberName_TS834A1_2100A {get; set;}
    [XmlElement(Order=1)]
    public S_PER_MemberCommunicationsNumbers_TS834A1_2100A S_PER_MemberCommunicationsNumbers_TS834A1_2100A {get; set;}
    [XmlElement(Order=2)]
    public S_N3_MemberResidenceStreetAddress_TS834A1_2100A S_N3_MemberResidenceStreetAddress_TS834A1_2100A {get; set;}
    [XmlElement(Order=3)]
    public S_N4_MemberResidenceCityStateZIPCode_TS834A1_2100A S_N4_MemberResidenceCityStateZIPCode_TS834A1_2100A {get; set;}
    [XmlElement(Order=4)]
    public S_DMG_MemberDemographics_TS834A1_2100A S_DMG_MemberDemographics_TS834A1_2100A {get; set;}
    [XmlElement(Order=5)]
    public S_ICM_MemberIncome_TS834A1_2100A S_ICM_MemberIncome_TS834A1_2100A {get; set;}
    [XmlElement("S_AMT_MemberPolicyAmounts_TS834A1_2100A",Order=6)]
    public List<S_AMT_MemberPolicyAmounts_TS834A1_2100A> S_AMT_MemberPolicyAmounts_TS834A1_2100A {get; set;}
    [XmlElement(Order=7)]
    public S_HLH_MemberHealthInformation_TS834A1_2100A S_HLH_MemberHealthInformation_TS834A1_2100A {get; set;}
    [XmlElement("S_LUI_MemberLanguage_TS834A1_2100A",Order=8)]
    public List<S_LUI_MemberLanguage_TS834A1_2100A> S_LUI_MemberLanguage_TS834A1_2100A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_MemberName_TS834A1_2100A {
    [XmlElement(Order=0)]
    public S_NM1_MemberName_TS834A1_2100AD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_MemberName_TS834A1_2100AD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_MemberName_TS834A1_2100AD_NM101_EntityIdentifierCode {
        [XmlEnum("74")]
        Item74,
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_MemberName_TS834A1_2100AD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_MemberCommunicationsNumbers_TS834A1_2100A {
    [XmlElement(Order=0)]
    public S_PER_MemberCommunicationsNumbers_TS834A1_2100AD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02 {get; set;}
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
    public enum S_PER_MemberCommunicationsNumbers_TS834A1_2100AD_PER01_ContactFunctionCode {
        IP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_MemberResidenceStreetAddress_TS834A1_2100A {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_MemberResidenceCityStateZIPCode_TS834A1_2100A {
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
    public class S_DMG_MemberDemographics_TS834A1_2100A {
    [XmlElement(Order=0)]
    public S_DMG_MemberDemographics_TS834A1_2100AD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_MemberBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_GenderCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DMG04_MaritalStatusCode {get; set;}
    [XmlElement(Order=4)]
    public string D_DMG05_RaceOrEthnicityCode {get; set;}
    [XmlElement(Order=5)]
    public string D_DMG06_CitizenshipStatusCode {get; set;}
    [XmlElement(Order=6)]
    public string D_DMG07 {get; set;}
    [XmlElement(Order=7)]
    public string D_DMG08 {get; set;}
    [XmlElement(Order=8)]
    public string D_DMG09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DMG_MemberDemographics_TS834A1_2100AD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ICM_MemberIncome_TS834A1_2100A {
    [XmlElement(Order=0)]
    public S_ICM_MemberIncome_TS834A1_2100AD_ICM01_FrequencyCode D_ICM01_FrequencyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_ICM02_WageAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_ICM03_WorkHoursCount {get; set;}
    [XmlElement(Order=3)]
    public string D_ICM04_LocationIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_ICM05_SalaryGradeCode {get; set;}
    [XmlElement(Order=5)]
    public string D_ICM06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_ICM_MemberIncome_TS834A1_2100AD_ICM01_FrequencyCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("4")]
        Item4,
        [XmlEnum("6")]
        Item6,
        [XmlEnum("7")]
        Item7,
        [XmlEnum("8")]
        Item8,
        [XmlEnum("9")]
        Item9,
        B,
        C,
        H,
        Q,
        S,
        U,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_MemberPolicyAmounts_TS834A1_2100A {
    [XmlElement(Order=0)]
    public S_AMT_MemberPolicyAmounts_TS834A1_2100AD_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ContractAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_MemberPolicyAmounts_TS834A1_2100AD_AMT01_AmountQualifierCode {
        B9,
        C1,
        D2,
        P3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HLH_MemberHealthInformation_TS834A1_2100A {
    [XmlElement(Order=0)]
    public S_HLH_MemberHealthInformation_TS834A1_2100AD_HLH01_HealthRelatedCode D_HLH01_HealthRelatedCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HLH02_MemberHeight {get; set;}
    [XmlElement(Order=2)]
    public string D_HLH03_MemberWeight {get; set;}
    [XmlElement(Order=3)]
    public string D_HLH04 {get; set;}
    [XmlElement(Order=4)]
    public string D_HLH05 {get; set;}
    [XmlElement(Order=5)]
    public string D_HLH06 {get; set;}
    [XmlElement(Order=6)]
    public string D_HLH07 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_HLH_MemberHealthInformation_TS834A1_2100AD_HLH01_HealthRelatedCode {
        N,
        S,
        T,
        U,
        X,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LUI_MemberLanguage_TS834A1_2100A {
    [XmlElement(Order=0)]
    public S_LUI_MemberLanguage_TS834A1_2100AD_LUI01_IdentificationCodeQualifier D_LUI01_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_LUI02_LanguageCode {get; set;}
    [XmlElement(Order=2)]
    public string D_LUI03_LanguageDescription {get; set;}
    [XmlElement(Order=3)]
    public string D_LUI04_LanguageUseIndicator {get; set;}
    [XmlElement(Order=4)]
    public string D_LUI05 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_LUI_MemberLanguage_TS834A1_2100AD_LUI01_IdentificationCodeQualifier {
        LD,
        LE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_IncorrectMemberName_TS834A1_2100B S_NM1_IncorrectMemberName_TS834A1_2100B {get; set;}
    [XmlElement(Order=1)]
    public S_DMG_IncorrectMemberDemographics_TS834A1_2100B S_DMG_IncorrectMemberDemographics_TS834A1_2100B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_IncorrectMemberName_TS834A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_IncorrectMemberName_TS834A1_2100BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_IncorrectMemberName_TS834A1_2100BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PriorIncorrectInsuredLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PriorIncorrectInsuredFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PriorIncorrectInsuredMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_PriorIncorrectInsuredNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PriorIncorrectInsuredNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PriorIncorrectInsuredIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_IncorrectMemberName_TS834A1_2100BD_NM101_EntityIdentifierCode {
        [XmlEnum("70")]
        Item70,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_IncorrectMemberName_TS834A1_2100BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_IncorrectMemberDemographics_TS834A1_2100B {
    [XmlElement(Order=0)]
    public S_DMG_IncorrectMemberDemographics_TS834A1_2100BD_DMG01_DateTimePeriodFormatQualifier D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_PriorIncorrectInsuredBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_PriorIncorrectInsuredGenderCode {get; set;}
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
    public enum S_DMG_IncorrectMemberDemographics_TS834A1_2100BD_DMG01_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2100C {
    [XmlElement(Order=0)]
    public S_NM1_MemberMailingAddress_TS834A1_2100C S_NM1_MemberMailingAddress_TS834A1_2100C {get; set;}
    [XmlElement(Order=1)]
    public S_N3_MemberMailStreetAddress_TS834A1_2100C S_N3_MemberMailStreetAddress_TS834A1_2100C {get; set;}
    [XmlElement(Order=2)]
    public S_N4_MemberMailCityStateZip_TS834A1_2100C S_N4_MemberMailCityStateZip_TS834A1_2100C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_MemberMailingAddress_TS834A1_2100C {
    [XmlElement(Order=0)]
    public S_NM1_MemberMailingAddress_TS834A1_2100CD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_MemberMailingAddress_TS834A1_2100CD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public enum S_NM1_MemberMailingAddress_TS834A1_2100CD_NM101_EntityIdentifierCode {
        [XmlEnum("31")]
        Item31,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_MemberMailingAddress_TS834A1_2100CD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_MemberMailStreetAddress_TS834A1_2100C {
    [XmlElement(Order=0)]
    public string D_N301_SubscriberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SubscriberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_MemberMailCityStateZip_TS834A1_2100C {
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
    public class G_TS834A1_2100D {
    [XmlElement(Order=0)]
    public S_NM1_MemberEmployer_TS834A1_2100D S_NM1_MemberEmployer_TS834A1_2100D {get; set;}
    [XmlElement(Order=1)]
    public S_PER_MemberEmployerCommunicationsNumbers_TS834A1_2100D S_PER_MemberEmployerCommunicationsNumbers_TS834A1_2100D {get; set;}
    [XmlElement(Order=2)]
    public S_N3_MemberEmployerStreetAddress_TS834A1_2100D S_N3_MemberEmployerStreetAddress_TS834A1_2100D {get; set;}
    [XmlElement(Order=3)]
    public S_N4_MemberEmployerCityStateZip_TS834A1_2100D S_N4_MemberEmployerCityStateZip_TS834A1_2100D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_MemberEmployer_TS834A1_2100D {
    [XmlElement(Order=0)]
    public S_NM1_MemberEmployer_TS834A1_2100DD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_MemberEmployer_TS834A1_2100DD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_InsuredEmployerName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_InsuredEmployerFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_InsuredEmployerMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_InsuredEmployerNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_InsuredEmployerIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_MemberEmployer_TS834A1_2100DD_NM101_EntityIdentifierCode {
        ES,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_MemberEmployer_TS834A1_2100DD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_MemberEmployerCommunicationsNumbers_TS834A1_2100D {
    [XmlElement(Order=0)]
    public S_PER_MemberEmployerCommunicationsNumbers_TS834A1_2100DD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02 {get; set;}
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
    public enum S_PER_MemberEmployerCommunicationsNumbers_TS834A1_2100DD_PER01_ContactFunctionCode {
        EP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_MemberEmployerStreetAddress_TS834A1_2100D {
    [XmlElement(Order=0)]
    public string D_N301_InsuredEmployerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_InsuredEmployerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_MemberEmployerCityStateZip_TS834A1_2100D {
    [XmlElement(Order=0)]
    public string D_N401_InsuredEmployerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_InsuredEmployerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_InsuredEmployerPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2100E {
    [XmlElement(Order=0)]
    public S_NM1_MemberSchool_TS834A1_2100E S_NM1_MemberSchool_TS834A1_2100E {get; set;}
    [XmlElement(Order=1)]
    public S_PER_MemberSchoolCommmunicationsNumbers_TS834A1_2100E S_PER_MemberSchoolCommmunicationsNumbers_TS834A1_2100E {get; set;}
    [XmlElement(Order=2)]
    public S_N3_MemberSchoolStreetAddress_TS834A1_2100E S_N3_MemberSchoolStreetAddress_TS834A1_2100E {get; set;}
    [XmlElement(Order=3)]
    public S_N4_MemberSchoolCityStateZip_TS834A1_2100E S_N4_MemberSchoolCityStateZip_TS834A1_2100E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_MemberSchool_TS834A1_2100E {
    [XmlElement(Order=0)]
    public S_NM1_MemberSchool_TS834A1_2100ED_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_MemberSchool_TS834A1_2100ED_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SchoolName {get; set;}
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
    public enum S_NM1_MemberSchool_TS834A1_2100ED_NM101_EntityIdentifierCode {
        M8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_MemberSchool_TS834A1_2100ED_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_MemberSchoolCommmunicationsNumbers_TS834A1_2100E {
    [XmlElement(Order=0)]
    public S_PER_MemberSchoolCommmunicationsNumbers_TS834A1_2100ED_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02 {get; set;}
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
    public enum S_PER_MemberSchoolCommmunicationsNumbers_TS834A1_2100ED_PER01_ContactFunctionCode {
        SK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_MemberSchoolStreetAddress_TS834A1_2100E {
    [XmlElement(Order=0)]
    public string D_N301_SchoolAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SchoolAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_MemberSchoolCityStateZip_TS834A1_2100E {
    [XmlElement(Order=0)]
    public string D_N401_SchoolCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_SchoolStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_SchoolPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2100F {
    [XmlElement(Order=0)]
    public S_NM1_CustodialParent_TS834A1_2100F S_NM1_CustodialParent_TS834A1_2100F {get; set;}
    [XmlElement(Order=1)]
    public S_PER_CustodialParentCommunicationsNumbers_TS834A1_2100F S_PER_CustodialParentCommunicationsNumbers_TS834A1_2100F {get; set;}
    [XmlElement(Order=2)]
    public S_N3_CustodialParentStreetAddress_TS834A1_2100F S_N3_CustodialParentStreetAddress_TS834A1_2100F {get; set;}
    [XmlElement(Order=3)]
    public S_N4_CustodialParentCityStateZip_TS834A1_2100F S_N4_CustodialParentCityStateZip_TS834A1_2100F {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CustodialParent_TS834A1_2100F {
    [XmlElement(Order=0)]
    public S_NM1_CustodialParent_TS834A1_2100FD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_CustodialParent_TS834A1_2100FD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CustodialParentLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_CustodialParentFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_CustodialParentMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_CustodialParentNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_CustodialParentNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_CustodialParentIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CustodialParent_TS834A1_2100FD_NM101_EntityIdentifierCode {
        S3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CustodialParent_TS834A1_2100FD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_CustodialParentCommunicationsNumbers_TS834A1_2100F {
    [XmlElement(Order=0)]
    public S_PER_CustodialParentCommunicationsNumbers_TS834A1_2100FD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02 {get; set;}
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
    public enum S_PER_CustodialParentCommunicationsNumbers_TS834A1_2100FD_PER01_ContactFunctionCode {
        PQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_CustodialParentStreetAddress_TS834A1_2100F {
    [XmlElement(Order=0)]
    public string D_N301_CustodialParentAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_CustodialParentAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_CustodialParentCityStateZip_TS834A1_2100F {
    [XmlElement(Order=0)]
    public string D_N401_CustodialParentCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_CustodialParentStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_CustodialParentPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2100G {
    [XmlElement(Order=0)]
    public S_NM1_ResponsiblePerson_TS834A1_2100G S_NM1_ResponsiblePerson_TS834A1_2100G {get; set;}
    [XmlElement(Order=1)]
    public S_PER_ResponsiblePersonCommunicationsNumbers_TS834A1_2100G S_PER_ResponsiblePersonCommunicationsNumbers_TS834A1_2100G {get; set;}
    [XmlElement(Order=2)]
    public S_N3_ResponsiblePersonStreetAddress_TS834A1_2100G S_N3_ResponsiblePersonStreetAddress_TS834A1_2100G {get; set;}
    [XmlElement(Order=3)]
    public S_N4_ResponsiblePersonCityStateZip_TS834A1_2100G S_N4_ResponsiblePersonCityStateZip_TS834A1_2100G {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ResponsiblePerson_TS834A1_2100G {
    [XmlElement(Order=0)]
    public S_NM1_ResponsiblePerson_TS834A1_2100GD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ResponsiblePerson_TS834A1_2100GD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ResponsiblePartyLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_ResponsiblePartyFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_ResponsiblePartyMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_ResponsiblePartyNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_ResponsiblePartySuffixName {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_ResponsiblePartyIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ResponsiblePerson_TS834A1_2100GD_NM101_EntityIdentifierCode {
        E1,
        EI,
        EXS,
        GD,
        J6,
        QD,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ResponsiblePerson_TS834A1_2100GD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_ResponsiblePersonCommunicationsNumbers_TS834A1_2100G {
    [XmlElement(Order=0)]
    public S_PER_ResponsiblePersonCommunicationsNumbers_TS834A1_2100GD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02 {get; set;}
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
    public enum S_PER_ResponsiblePersonCommunicationsNumbers_TS834A1_2100GD_PER01_ContactFunctionCode {
        RP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_ResponsiblePersonStreetAddress_TS834A1_2100G {
    [XmlElement(Order=0)]
    public string D_N301_ResponsiblePartyAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ResponsiblePartyAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ResponsiblePersonCityStateZip_TS834A1_2100G {
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
    public class G_TS834A1_2200 {
    [XmlElement(Order=0)]
    public S_DSB_DisabilityInformation_TS834A1_2200 S_DSB_DisabilityInformation_TS834A1_2200 {get; set;}
    [XmlElement("S_DTP_DisabilityEligibilityDates_TS834A1_2200",Order=1)]
    public List<S_DTP_DisabilityEligibilityDates_TS834A1_2200> S_DTP_DisabilityEligibilityDates_TS834A1_2200 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DSB_DisabilityInformation_TS834A1_2200 {
    [XmlElement(Order=0)]
    public S_DSB_DisabilityInformation_TS834A1_2200D_DSB01_DisabilityTypeCode D_DSB01_DisabilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_DSB02 {get; set;}
    [XmlElement(Order=2)]
    public string D_DSB03 {get; set;}
    [XmlElement(Order=3)]
    public string D_DSB04 {get; set;}
    [XmlElement(Order=4)]
    public string D_DSB05 {get; set;}
    [XmlElement(Order=5)]
    public string D_DSB06 {get; set;}
    [XmlElement(Order=6)]
    public string D_DSB07_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_DSB08_DiagnosisCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DSB_DisabilityInformation_TS834A1_2200D_DSB01_DisabilityTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("4")]
        Item4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_DisabilityEligibilityDates_TS834A1_2200 {
    [XmlElement(Order=0)]
    public S_DTP_DisabilityEligibilityDates_TS834A1_2200D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_DisabilityEligibilityDates_TS834A1_2200D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DisabilityEligibilityDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DisabilityEligibilityDates_TS834A1_2200D_DTP01_DateTimeQualifier {
        [XmlEnum("360")]
        Item360,
        [XmlEnum("361")]
        Item361,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_DisabilityEligibilityDates_TS834A1_2200D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2300 {
    [XmlElement(Order=0)]
    public S_HD_HealthCoverage_TS834A1_2300 S_HD_HealthCoverage_TS834A1_2300 {get; set;}
    [XmlElement("S_DTP_HealthCoverageDates_TS834A1_2300",Order=1)]
    public List<S_DTP_HealthCoverageDates_TS834A1_2300> S_DTP_HealthCoverageDates_TS834A1_2300 {get; set;}
    [XmlElement("S_AMT_HealthCoveragePolicy_TS834A1_2300",Order=2)]
    public List<S_AMT_HealthCoveragePolicy_TS834A1_2300> S_AMT_HealthCoveragePolicy_TS834A1_2300 {get; set;}
    [XmlElement("S_REF_HealthCoveragePolicyNumber_TS834A1_2300",Order=3)]
    public List<S_REF_HealthCoveragePolicyNumber_TS834A1_2300> S_REF_HealthCoveragePolicyNumber_TS834A1_2300 {get; set;}
    [XmlElement("S_IDC_IdentificationCard_TS834A1_2300",Order=4)]
    public List<S_IDC_IdentificationCard_TS834A1_2300> S_IDC_IdentificationCard_TS834A1_2300 {get; set;}
    [XmlElement("G_TS834A1_2310",Order=5)]
    public List<G_TS834A1_2310> G_TS834A1_2310 {get; set;}
    [XmlElement("G_TS834A1_2320",Order=6)]
    public List<G_TS834A1_2320> G_TS834A1_2320 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HD_HealthCoverage_TS834A1_2300 {
    [XmlElement(Order=0)]
    public S_HD_HealthCoverage_TS834A1_2300D_HD01_MaintenanceTypeCode D_HD01_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HD02 {get; set;}
    [XmlElement(Order=2)]
    public string D_HD03_InsuranceLineCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HD04_PlanCoverageDescription {get; set;}
    [XmlElement(Order=4)]
    public string D_HD05_CoverageLevelCode {get; set;}
    [XmlElement(Order=5)]
    public string D_HD06 {get; set;}
    [XmlElement(Order=6)]
    public string D_HD07 {get; set;}
    [XmlElement(Order=7)]
    public string D_HD08 {get; set;}
    [XmlElement(Order=8)]
    public string D_HD09 {get; set;}
    [XmlElement(Order=9)]
    public string D_HD10 {get; set;}
    [XmlElement(Order=10)]
    public string D_HD11 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_HD_HealthCoverage_TS834A1_2300D_HD01_MaintenanceTypeCode {
        [XmlEnum("001")]
        Item001,
        [XmlEnum("002")]
        Item002,
        [XmlEnum("021")]
        Item021,
        [XmlEnum("024")]
        Item024,
        [XmlEnum("025")]
        Item025,
        [XmlEnum("026")]
        Item026,
        [XmlEnum("030")]
        Item030,
        [XmlEnum("032")]
        Item032,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_HealthCoverageDates_TS834A1_2300 {
    [XmlElement(Order=0)]
    public S_DTP_HealthCoverageDates_TS834A1_2300D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_HealthCoverageDates_TS834A1_2300D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CoveragePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_HealthCoverageDates_TS834A1_2300D_DTP01_DateTimeQualifier {
        [XmlEnum("303")]
        Item303,
        [XmlEnum("348")]
        Item348,
        [XmlEnum("349")]
        Item349,
        [XmlEnum("543")]
        Item543,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_HealthCoverageDates_TS834A1_2300D_DTP02_DateTimePeriodFormatQualifier {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_HealthCoveragePolicy_TS834A1_2300 {
    [XmlElement(Order=0)]
    public S_AMT_HealthCoveragePolicy_TS834A1_2300D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ContractAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_HealthCoveragePolicy_TS834A1_2300D_AMT01_AmountQualifierCode {
        B9,
        C1,
        D2,
        P3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_HealthCoveragePolicyNumber_TS834A1_2300 {
    [XmlElement(Order=0)]
    public S_REF_HealthCoveragePolicyNumber_TS834A1_2300D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U780 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_HealthCoveragePolicyNumber_TS834A1_2300D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("17")]
        Item17,
        [XmlEnum("1L")]
        Item1L,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_IDC_IdentificationCard_TS834A1_2300 {
    [XmlElement(Order=0)]
    public string D_IDC01_PlanCoverageDescription {get; set;}
    [XmlElement(Order=1)]
    public S_IDC_IdentificationCard_TS834A1_2300D_IDC02_IdentificationCardTypeCode D_IDC02_IdentificationCardTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_IDC03_IdentificationCardCount {get; set;}
    [XmlElement(Order=3)]
    public string D_IDC04_ActionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_IDC_IdentificationCard_TS834A1_2300D_IDC02_IdentificationCardTypeCode {
        D,
        H,
        P,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2310 {
    [XmlElement(Order=0)]
    public S_LX_ProviderInformation_TS834A1_2310 S_LX_ProviderInformation_TS834A1_2310 {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ProviderName_TS834A1_2310 S_NM1_ProviderName_TS834A1_2310 {get; set;}
    [XmlElement(Order=2)]
    public S_N4_ProviderCityStateZIPCode_TS834A1_2310 S_N4_ProviderCityStateZIPCode_TS834A1_2310 {get; set;}
    [XmlElement("S_PER_ProviderCommunicationsNumbers_TS834A1_2310",Order=3)]
    public List<S_PER_ProviderCommunicationsNumbers_TS834A1_2310> S_PER_ProviderCommunicationsNumbers_TS834A1_2310 {get; set;}
    [XmlElement(Order=4)]
    public S_PLA_PCPChangeReason_TS834A1_2310 S_PLA_PCPChangeReason_TS834A1_2310 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_ProviderInformation_TS834A1_2310 {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ProviderName_TS834A1_2310 {
    [XmlElement(Order=0)]
    public S_NM1_ProviderName_TS834A1_2310D_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ProviderName_TS834A1_2310D_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ProviderName_TS834A1_2310D_NM101_EntityIdentifierCode {
        [XmlEnum("3D")]
        Item3D,
        OD,
        P3,
        QA,
        QN,
        Y2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ProviderName_TS834A1_2310D_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ProviderCityStateZIPCode_TS834A1_2310 {
    [XmlElement(Order=0)]
    public string D_N401_MemberCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_MemberStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_MemberPostalZoneOrZipCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405_LocationQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_N406_LocationIdentificationCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_ProviderCommunicationsNumbers_TS834A1_2310 {
    [XmlElement(Order=0)]
    public S_PER_ProviderCommunicationsNumbers_TS834A1_2310D_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02 {get; set;}
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
    public enum S_PER_ProviderCommunicationsNumbers_TS834A1_2310D_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PLA_PCPChangeReason_TS834A1_2310 {
    [XmlElement(Order=0)]
    public S_PLA_PCPChangeReason_TS834A1_2310D_PLA01_ActionCode D_PLA01_ActionCode {get; set;}
    [XmlElement(Order=1)]
    public S_PLA_PCPChangeReason_TS834A1_2310D_PLA02_EntityIdentifierCode D_PLA02_EntityIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PLA03_ProviderEffectiveDate {get; set;}
    [XmlElement(Order=3)]
    public string D_PLA04 {get; set;}
    [XmlElement(Order=4)]
    public string D_PLA05_MaintenanceReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PLA_PCPChangeReason_TS834A1_2310D_PLA01_ActionCode {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PLA_PCPChangeReason_TS834A1_2310D_PLA02_EntityIdentifierCode {
        [XmlEnum("1P")]
        Item1P,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834A1_2320 {
    [XmlElement(Order=0)]
    public S_COB_CoordinationOfBenefits_TS834A1_2320 S_COB_CoordinationOfBenefits_TS834A1_2320 {get; set;}
    [XmlElement("S_REF_AdditionalCoordinationOfBenefitsIdentifiers_TS834A1_2320",Order=1)]
    public List<S_REF_AdditionalCoordinationOfBenefitsIdentifiers_TS834A1_2320> S_REF_AdditionalCoordinationOfBenefitsIdentifiers_TS834A1_2320 {get; set;}
    [XmlElement(Order=2)]
    public S_N1_OtherInsuranceCompanyName_TS834A1_2320 S_N1_OtherInsuranceCompanyName_TS834A1_2320 {get; set;}
    [XmlElement("S_DTP_CoordinationOfBenefitsEligibilityDates_TS834A1_2320",Order=3)]
    public List<S_DTP_CoordinationOfBenefitsEligibilityDates_TS834A1_2320> S_DTP_CoordinationOfBenefitsEligibilityDates_TS834A1_2320 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_COB_CoordinationOfBenefits_TS834A1_2320 {
    [XmlElement(Order=0)]
    public S_COB_CoordinationOfBenefits_TS834A1_2320D_COB01_PayerResponsibilitySequenceNumberCode D_COB01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public string D_COB02_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_COB03_CoordinationOfBenefitsCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_COB_CoordinationOfBenefits_TS834A1_2320D_COB01_PayerResponsibilitySequenceNumberCode {
        P,
        S,
        T,
        U,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AdditionalCoordinationOfBenefitsIdentifiers_TS834A1_2320 {
    [XmlElement(Order=0)]
    public S_REF_AdditionalCoordinationOfBenefitsIdentifiers_TS834A1_2320D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U781 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_AdditionalCoordinationOfBenefitsIdentifiers_TS834A1_2320D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("60")]
        Item60,
        [XmlEnum("6P")]
        Item6P,
        A6,
        SY,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_OtherInsuranceCompanyName_TS834A1_2320 {
    [XmlElement(Order=0)]
    public S_N1_OtherInsuranceCompanyName_TS834A1_2320D_N101_EntityIdentifierCode D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_InsurerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_InsuredGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_N105 {get; set;}
    [XmlElement(Order=5)]
    public string D_N106 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_N1_OtherInsuranceCompanyName_TS834A1_2320D_N101_EntityIdentifierCode {
        IN,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTP_CoordinationOfBenefitsEligibilityDates_TS834A1_2320 {
    [XmlElement(Order=0)]
    public S_DTP_CoordinationOfBenefitsEligibilityDates_TS834A1_2320D_DTP01_DateTimeQualifier D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public S_DTP_CoordinationOfBenefitsEligibilityDates_TS834A1_2320D_DTP02_DateTimePeriodFormatQualifier D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CoordinationOfBenefitsDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_CoordinationOfBenefitsEligibilityDates_TS834A1_2320D_DTP01_DateTimeQualifier {
        [XmlEnum("344")]
        Item344,
        [XmlEnum("345")]
        Item345,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTP_CoordinationOfBenefitsEligibilityDates_TS834A1_2320D_DTP02_DateTimePeriodFormatQualifier {
        D8,
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
    public class U_REF_MemberIdentificationNumber_TS834A1_2000 {
    [XmlElement("S_REF_MemberIdentificationNumber_TS834A1_2000",Order=0)]
    public List<S_REF_MemberIdentificationNumber_TS834A1_2000> S_REF_MemberIdentificationNumber_TS834A1_2000 {get; set;}
    }
}
