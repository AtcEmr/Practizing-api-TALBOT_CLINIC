namespace EdiFabric.Rules.X12005010X220A1834 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_834 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BGN_BeginningSegment S_BGN_BeginningSegment {get; set;}
    [XmlElement(Order=2)]
    public S_REF_TransactionSetPolicyNumber S_REF_TransactionSetPolicyNumber {get; set;}
    [XmlElement("S_DTP_FileEffectiveDate",Order=3)]
    public List<S_DTP_FileEffectiveDate> S_DTP_FileEffectiveDate {get; set;}
    [XmlElement("S_QTY_TransactionSetControlTotals",Order=4)]
    public List<S_QTY_TransactionSetControlTotals> S_QTY_TransactionSetControlTotals {get; set;}
    [XmlElement(Order=5)]
    public A_N1 A_N1 {get; set;}
    [XmlElement("G_TS834_2000",Order=6)]
    public List<G_TS834_2000> G_TS834_2000 {get; set;}
    [XmlElement(Order=7)]
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
        [XmlEnum("834")]
        Item834,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BGN_BeginningSegment {
    [XmlElement(Order=0)]
    public X12_ID_353 D_BGN01_TransactionSetPurposeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_BGN02_TransactionSetReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_BGN03_TransactionSetCreationDate {get; set;}
    [XmlElement(Order=3)]
    public string D_BGN04_TransactionSetCreationTime {get; set;}
    [XmlElement(Order=4)]
    public string D_BGN05_TimeZoneCode {get; set;}
    [XmlElement(Order=5)]
    public string D_BGN06_OriginalTransactionSetReferenceNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_BGN07_TransactionTypeCode {get; set;}
    [XmlElement(Order=7)]
    public string D_BGN08_ActionCode {get; set;}
    [XmlElement(Order=8)]
    public string D_BGN09_SecurityLevelCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_353 {
        [XmlEnum("00")]
        Item00,
        [XmlEnum("15")]
        Item15,
        [XmlEnum("22")]
        Item22,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_TransactionSetPolicyNumber {
    [XmlElement(Order=0)]
    public X12_ID_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MasterPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier C_C040_ReferenceIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128 {
        [XmlEnum("38")]
        Item38,
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
    public class S_DTP_FileEffectiveDate {
    [XmlElement(Order=0)]
    public X12_ID_374 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DateTimePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374 {
        [XmlEnum("007")]
        Item007,
        [XmlEnum("090")]
        Item090,
        [XmlEnum("091")]
        Item091,
        [XmlEnum("303")]
        Item303,
        [XmlEnum("382")]
        Item382,
        [XmlEnum("388")]
        Item388,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250 {
        D8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_TransactionSetControlTotals {
    [XmlElement(Order=0)]
    public X12_ID_673 D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_RecordTotals {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitofMeasure C_C001_CompositeUnitofMeasure {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04_Free_formInformation {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_673 {
        DT,
        ET,
        TO,
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
    public class A_N1 {
    [XmlElementAttribute(Order=0)]
    public G_TS834_1000A G_TS834_1000A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS834_1000B G_TS834_1000B {get; set;}
    [XmlElement(Order=2)]
    public U_TS834_1000C U_TS834_1000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_1000A {
    [XmlElement(Order=0)]
    public S_N1_SponsorName S_N1_SponsorName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_SponsorName {
    [XmlElement(Order=0)]
    public X12_ID_98 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PlanSponsorName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_SponsorIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_N105_EntityRelationshipCode {get; set;}
    [XmlElement(Order=5)]
    public string D_N106_EntityIdentifierCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98 {
        P5,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_1000B {
    [XmlElement(Order=0)]
    public S_N1_Payer S_N1_Payer {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_Payer {
    [XmlElement(Order=0)]
    public X12_ID_98_3 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_InsurerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_InsurerIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N105_EntityRelationshipCode {get; set;}
    [XmlElement(Order=5)]
    public string D_N106_EntityIdentifierCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_3 {
        IN,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_1000C {
    [XmlElement(Order=0)]
    public S_N1_TPA_BrokerName S_N1_TPA_BrokerName {get; set;}
    [XmlElement(Order=1)]
    public G_TS834_1100C G_TS834_1100C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_TPA_BrokerName {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_TPAorBrokerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_TPAorBrokerIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N105_EntityRelationshipCode {get; set;}
    [XmlElement(Order=5)]
    public string D_N106_EntityIdentifierCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_4 {
        BO,
        TV,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_1100C {
    [XmlElement(Order=0)]
    public S_ACT_TPA_BrokerAccountInformation S_ACT_TPA_BrokerAccountInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ACT_TPA_BrokerAccountInformation {
    [XmlElement(Order=0)]
    public string D_ACT01_TPAorBrokerAccountNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_ACT02_Name {get; set;}
    [XmlElement(Order=2)]
    public string D_ACT03_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ACT04_IdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_ACT05_AccountNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_ACT06_TPAorBrokerAccountNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_ACT07_Description {get; set;}
    [XmlElement(Order=7)]
    public string D_ACT08_PaymentMethodTypeCode {get; set;}
    [XmlElement(Order=8)]
    public string D_ACT09_BenefitStatusCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2000 {
    [XmlElement(Order=0)]
    public S_INS_MemberLevelDetail S_INS_MemberLevelDetail {get; set;}
    [XmlElement(Order=1)]
    public A_REF A_REF {get; set;}
    [XmlElement("S_DTP_MemberLevelDates",Order=2)]
    public List<S_DTP_MemberLevelDates> S_DTP_MemberLevelDates {get; set;}
    [XmlElement(Order=3)]
    public A_NM1 A_NM1 {get; set;}
    [XmlElement("G_TS834_2200",Order=4)]
    public List<G_TS834_2200> G_TS834_2200 {get; set;}
    [XmlElement("G_TS834_2300",Order=5)]
    public List<G_TS834_2300> G_TS834_2300 {get; set;}
    [XmlElement(Order=6)]
    public G_TS834_LS G_TS834_LS {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_INS_MemberLevelDetail {
    [XmlElement(Order=0)]
    public X12_ID_1073 D_INS01_MemberIndicator {get; set;}
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
    public string D_INS07_ConsolidatedOmnibusBudgetReconciliationAct__COBRA_QualifyingEventCode {get; set;}
    [XmlElement(Order=7)]
    public string D_INS08_EmploymentStatusCode {get; set;}
    [XmlElement(Order=8)]
    public string D_INS09_StudentStatusCode {get; set;}
    [XmlElement(Order=9)]
    public string D_INS10_HandicapIndicator {get; set;}
    [XmlElement(Order=10)]
    public string D_INS11_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=11)]
    public string D_INS12_MemberIndividualDeathDate {get; set;}
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
    public enum X12_ID_1073 {
        N,
        Y,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1069 {
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
        [XmlEnum("16")]
        Item16,
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
        [XmlEnum("38")]
        Item38,
        [XmlEnum("53")]
        Item53,
        [XmlEnum("60")]
        Item60,
        D2,
        G8,
        G9,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C052_MedicareStatusCode {
    [XmlElement(Order=0)]
    public string D_C05201_MedicarePlanCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05202_MedicareEligibilityReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05203_EligibilityReasonCode {get; set;}
    [XmlElement(Order=3)]
    public string D_C05204_EligibilityReasonCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF {
    [XmlElementAttribute(Order=0)]
    public S_REF_SubscriberIdentifier S_REF_SubscriberIdentifier {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_MemberPolicyNumber S_REF_MemberPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public U_REF_MemberSupplementalIdentifier U_REF_MemberSupplementalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_SubscriberIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_3 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_SubscriberIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2 C_C040_ReferenceIdentifier_2 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_3 {
        [XmlEnum("0F")]
        Item0F,
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
    public class S_REF_MemberPolicyNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MemberGrouporPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3 C_C040_ReferenceIdentifier_3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        [XmlEnum("1L")]
        Item1L,
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
    public class S_REF_MemberSupplementalIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MemberSupplementalIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4 C_C040_ReferenceIdentifier_4 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
        [XmlEnum("17")]
        Item17,
        [XmlEnum("23")]
        Item23,
        [XmlEnum("3H")]
        Item3H,
        [XmlEnum("4A")]
        Item4A,
        [XmlEnum("6O")]
        Item6O,
        ABB,
        D3,
        DX,
        F6,
        P5,
        Q4,
        QQ,
        ZZ,
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
    public class S_DTP_MemberLevelDates {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_StatusInformationEffectiveDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_2 {
        [XmlEnum("050")]
        Item050,
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
        [XmlEnum("385")]
        Item385,
        [XmlEnum("386")]
        Item386,
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
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1 {
    [XmlElementAttribute(Order=0)]
    public G_TS834_2100A G_TS834_2100A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS834_2100B G_TS834_2100B {get; set;}
    [XmlElementAttribute(Order=2)]
    public G_TS834_2100C G_TS834_2100C {get; set;}
    [XmlElement(Order=3)]
    public U_TS834_2100D U_TS834_2100D {get; set;}
    [XmlElement(Order=4)]
    public U_TS834_2100E U_TS834_2100E {get; set;}
    [XmlElementAttribute(Order=5)]
    public G_TS834_2100F G_TS834_2100F {get; set;}
    [XmlElement(Order=6)]
    public U_TS834_2100G U_TS834_2100G {get; set;}
    [XmlElementAttribute(Order=7)]
    public G_TS834_2100H G_TS834_2100H {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2100A {
    [XmlElement(Order=0)]
    public S_NM1_MemberName S_NM1_MemberName {get; set;}
    [XmlElement(Order=1)]
    public S_PER_MemberCommunicationsNumbers S_PER_MemberCommunicationsNumbers {get; set;}
    [XmlElement(Order=2)]
    public S_N3_MemberResidenceStreetAddress S_N3_MemberResidenceStreetAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_MemberCity_State_ZIPCode S_N4_MemberCity_State_ZIPCode {get; set;}
    [XmlElement(Order=4)]
    public S_DMG_MemberDemographics S_DMG_MemberDemographics {get; set;}
    [XmlElement("S_EC_EmploymentClass",Order=5)]
    public List<S_EC_EmploymentClass> S_EC_EmploymentClass {get; set;}
    [XmlElement(Order=6)]
    public S_ICM_MemberIncome S_ICM_MemberIncome {get; set;}
    [XmlElement("S_AMT_MemberPolicyAmounts",Order=7)]
    public List<S_AMT_MemberPolicyAmounts> S_AMT_MemberPolicyAmounts {get; set;}
    [XmlElement(Order=8)]
    public S_HLH_MemberHealthInformation S_HLH_MemberHealthInformation {get; set;}
    [XmlElement("S_LUI_MemberLanguage",Order=9)]
    public List<S_LUI_MemberLanguage> S_LUI_MemberLanguage {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_MemberName {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_MemberLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_MemberFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_MemberMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_MemberNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_MemberNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_MemberIdentifier {get; set;}
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
        [XmlEnum("74")]
        Item74,
        IL,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_MemberCommunicationsNumbers {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_Name {get; set;}
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
        IP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_MemberResidenceStreetAddress {
    [XmlElement(Order=0)]
    public string D_N301_MemberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_MemberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_MemberCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_MemberCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_MemberStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_MemberPostalZoneorZipCode {get; set;}
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
    public class S_DMG_MemberDemographics {
    [XmlElement(Order=0)]
    public X12_ID_1250 D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_MemberBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_GenderCode {get; set;}
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
    public string D_DMG11_RaceorEthnicityCollectionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C056_CompositeRaceorEthnicityInformation {
    [XmlElement(Order=0)]
    public string D_C05601_RaceorEthnicityCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05602_CodeListQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05603_RaceorEthnicityCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_EC_EmploymentClass {
    [XmlElement(Order=0)]
    public X12_ID_1176 D_EC01_EmploymentClassCode {get; set;}
    [XmlElement(Order=1)]
    public string D_EC02_EmploymentClassCode {get; set;}
    [XmlElement(Order=2)]
    public string D_EC03_EmploymentClassCode {get; set;}
    [XmlElement(Order=3)]
    public string D_EC04_PercentageasDecimal {get; set;}
    [XmlElement(Order=4)]
    public string D_EC05_InformationStatusCode {get; set;}
    [XmlElement(Order=5)]
    public string D_EC06_OccupationCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1176 {
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
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ICM_MemberIncome {
    [XmlElement(Order=0)]
    public X12_ID_594 D_ICM01_FrequencyCode {get; set;}
    [XmlElement(Order=1)]
    public string D_ICM02_WageAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_ICM03_WorkHoursCount {get; set;}
    [XmlElement(Order=3)]
    public string D_ICM04_LocationIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_ICM05_SalaryGradeCode {get; set;}
    [XmlElement(Order=5)]
    public string D_ICM06_CurrencyCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_594 {
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
    public class S_AMT_MemberPolicyAmounts {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ContractAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522 {
        B9,
        C1,
        D2,
        EBA,
        FK,
        P3,
        R,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HLH_MemberHealthInformation {
    [XmlElement(Order=0)]
    public X12_ID_1212 D_HLH01_HealthRelatedCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HLH02_MemberHeight {get; set;}
    [XmlElement(Order=2)]
    public string D_HLH03_MemberWeight {get; set;}
    [XmlElement(Order=3)]
    public string D_HLH04_Weight {get; set;}
    [XmlElement(Order=4)]
    public string D_HLH05_Description {get; set;}
    [XmlElement(Order=5)]
    public string D_HLH06_CurrentHealthConditionCode {get; set;}
    [XmlElement(Order=6)]
    public string D_HLH07_Description {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1212 {
        N,
        S,
        T,
        U,
        X,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LUI_MemberLanguage {
    [XmlElement(Order=0)]
    public string D_LUI01_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_LUI02_LanguageCode {get; set;}
    [XmlElement(Order=2)]
    public string D_LUI03_LanguageDescription {get; set;}
    [XmlElement(Order=3)]
    public string D_LUI04_LanguageUseIndicator {get; set;}
    [XmlElement(Order=4)]
    public string D_LUI05_LanguageProficiencyIndicator {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2100B {
    [XmlElement(Order=0)]
    public S_NM1_IncorrectMemberName S_NM1_IncorrectMemberName {get; set;}
    [XmlElement(Order=1)]
    public S_DMG_IncorrectMemberDemographics S_DMG_IncorrectMemberDemographics {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_IncorrectMemberName {
    [XmlElement(Order=0)]
    public X12_ID_98_6 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PriorIncorrectMemberLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PriorIncorrectMemberFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PriorIncorrectMemberMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_PriorIncorrectMemberNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PriorIncorrectMemberNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PriorIncorrectInsuredIdentifier {get; set;}
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
        [XmlEnum("70")]
        Item70,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DMG_IncorrectMemberDemographics {
    [XmlElement(Order=0)]
    public string D_DMG01_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DMG02_PriorIncorrectInsuredBirthDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DMG03_PriorIncorrectInsuredGenderCode {get; set;}
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
    public string D_DMG11_RaceorEthnicityCollectionCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C056_CompositeRaceorEthnicityInformation_2 {
    [XmlElement(Order=0)]
    public string D_C05601_RaceorEthnicityCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C05602_CodeListQualifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_C05603_RaceorEthnicityCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2100C {
    [XmlElement(Order=0)]
    public S_NM1_MemberMailingAddress S_NM1_MemberMailingAddress {get; set;}
    [XmlElement(Order=1)]
    public S_N3_MemberMailStreetAddress S_N3_MemberMailStreetAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_MemberMailCity_State_ZIPCode S_N4_MemberMailCity_State_ZIPCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_MemberMailingAddress {
    [XmlElement(Order=0)]
    public X12_ID_98_7 D_NM101_EntityIdentifierCode {get; set;}
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
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_7 {
        [XmlEnum("31")]
        Item31,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_MemberMailStreetAddress {
    [XmlElement(Order=0)]
    public string D_N301_MemberAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_MemberAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_MemberMailCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_MemberMailCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_MemberMailStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_MemberMailPostalZoneorZIPCode {get; set;}
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
    public class G_TS834_2100D {
    [XmlElement(Order=0)]
    public S_NM1_MemberEmployer S_NM1_MemberEmployer {get; set;}
    [XmlElement(Order=1)]
    public S_PER_MemberEmployerCommunicationsNumbers S_PER_MemberEmployerCommunicationsNumbers {get; set;}
    [XmlElement(Order=2)]
    public S_N3_MemberEmployerStreetAddress S_N3_MemberEmployerStreetAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_MemberEmployerCity_State_ZIPCode S_N4_MemberEmployerCity_State_ZIPCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_MemberEmployer {
    [XmlElement(Order=0)]
    public X12_ID_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_MemberEmployerName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_MemberEmployerFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_MemberEmployerMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_MemberEmployerNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_MemberEmployerNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_MemberEmployerIdentifier {get; set;}
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
        [XmlEnum("36")]
        Item36,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_2 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_MemberEmployerCommunicationsNumbers {
    [XmlElement(Order=0)]
    public X12_ID_366_2 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_MemberEmployerCommunicationsContactName {get; set;}
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
    public enum X12_ID_366_2 {
        EP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_MemberEmployerStreetAddress {
    [XmlElement(Order=0)]
    public string D_N301_MemberEmployerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_MemberEmployerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_MemberEmployerCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_MemberEmployerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_MemberEmployerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_MemberEmployerPostalZoneorZIPCode {get; set;}
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
    public class G_TS834_2100E {
    [XmlElement(Order=0)]
    public S_NM1_MemberSchool S_NM1_MemberSchool {get; set;}
    [XmlElement(Order=1)]
    public S_PER_MemberSchoolCommmunicationsNumbers S_PER_MemberSchoolCommmunicationsNumbers {get; set;}
    [XmlElement(Order=2)]
    public S_N3_MemberSchoolStreetAddress S_N3_MemberSchoolStreetAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_MemberSchoolCity_State_ZIPCode S_N4_MemberSchoolCity_State_ZIPCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_MemberSchool {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_SchoolName {get; set;}
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
    public enum X12_ID_98_9 {
        M8,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_3 {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_MemberSchoolCommmunicationsNumbers {
    [XmlElement(Order=0)]
    public X12_ID_366_3 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_MemberSchoolCommunicationsContactName {get; set;}
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
    public enum X12_ID_366_3 {
        SK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_MemberSchoolStreetAddress {
    [XmlElement(Order=0)]
    public string D_N301_SchoolAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_SchoolAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_MemberSchoolCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_MemberSchoolCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_MemberSchoolStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_MemberSchoolPostalZoneorZIPCode {get; set;}
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
    public class G_TS834_2100F {
    [XmlElement(Order=0)]
    public S_NM1_CustodialParent S_NM1_CustodialParent {get; set;}
    [XmlElement(Order=1)]
    public S_PER_CustodialParentCommunicationsNumbers S_PER_CustodialParentCommunicationsNumbers {get; set;}
    [XmlElement(Order=2)]
    public S_N3_CustodialParentStreetAddress S_N3_CustodialParentStreetAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_CustodialParentCity_State_ZIPCode S_N4_CustodialParentCity_State_ZIPCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CustodialParent {
    [XmlElement(Order=0)]
    public X12_ID_98_10 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
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
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_10 {
        S3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_CustodialParentCommunicationsNumbers {
    [XmlElement(Order=0)]
    public X12_ID_366_4 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_Name {get; set;}
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
    public enum X12_ID_366_4 {
        PQ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_CustodialParentStreetAddress {
    [XmlElement(Order=0)]
    public string D_N301_CustodialParentAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_CustodialParentAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_CustodialParentCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_CustodialParentCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_CustodialParentStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_CustodialParentPostalZoneorZIPCode {get; set;}
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
    public class G_TS834_2100G {
    [XmlElement(Order=0)]
    public S_NM1_ResponsiblePerson S_NM1_ResponsiblePerson {get; set;}
    [XmlElement(Order=1)]
    public S_PER_ResponsiblePersonCommunicationsNumbers S_PER_ResponsiblePersonCommunicationsNumbers {get; set;}
    [XmlElement(Order=2)]
    public S_N3_ResponsiblePersonStreetAddress S_N3_ResponsiblePersonStreetAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_ResponsiblePersonCity_State_ZIPCode S_N4_ResponsiblePersonCity_State_ZIPCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ResponsiblePerson {
    [XmlElement(Order=0)]
    public X12_ID_98_11 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ResponsiblePartyLastorOrganizationName {get; set;}
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
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_11 {
        [XmlEnum("6Y")]
        Item6Y,
        [XmlEnum("9K")]
        Item9K,
        E1,
        EI,
        EXS,
        GB,
        GD,
        J6,
        LR,
        QD,
        S1,
        TZ,
        X4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_ResponsiblePersonCommunicationsNumbers {
    [XmlElement(Order=0)]
    public X12_ID_366_5 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_Name {get; set;}
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
    public enum X12_ID_366_5 {
        RP,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_ResponsiblePersonStreetAddress {
    [XmlElement(Order=0)]
    public string D_N301_ResponsiblePartyAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ResponsiblePartyAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ResponsiblePersonCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_ResponsiblePersonCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ResponsiblePersonStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ResponsiblePersonPostalZoneorZIPCode {get; set;}
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
    public class G_TS834_2100H {
    [XmlElement(Order=0)]
    public S_NM1_DropOffLocation S_NM1_DropOffLocation {get; set;}
    [XmlElement(Order=1)]
    public S_N3_DropOffLocationStreetAddress S_N3_DropOffLocationStreetAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_DropOffLocationCity_State_ZIPCode S_N4_DropOffLocationCity_State_ZIPCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_DropOffLocation {
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
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_12 {
        [XmlEnum("45")]
        Item45,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_DropOffLocationStreetAddress {
    [XmlElement(Order=0)]
    public string D_N301_DropOffLocationAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_DropOffLocationAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_DropOffLocationCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_DropOffLocationCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_DropOffLocationStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_DropOffLocationPostalZoneorZIPCode {get; set;}
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
    public class G_TS834_2200 {
    [XmlElement(Order=0)]
    public S_DSB_DisabilityInformation S_DSB_DisabilityInformation {get; set;}
    [XmlElement("S_DTP_DisabilityEligibilityDates",Order=1)]
    public List<S_DTP_DisabilityEligibilityDates> S_DTP_DisabilityEligibilityDates {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DSB_DisabilityInformation {
    [XmlElement(Order=0)]
    public X12_ID_1146 D_DSB01_DisabilityTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_DSB02_Quantity {get; set;}
    [XmlElement(Order=2)]
    public string D_DSB03_OccupationCode {get; set;}
    [XmlElement(Order=3)]
    public string D_DSB04_WorkIntensityCode {get; set;}
    [XmlElement(Order=4)]
    public string D_DSB05_ProductOptionCode {get; set;}
    [XmlElement(Order=5)]
    public string D_DSB06_MonetaryAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_DSB07_ProductorServiceIDQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_DSB08_DiagnosisCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1146 {
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
    public class S_DTP_DisabilityEligibilityDates {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_DisabilityEligibilityDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_3 {
        [XmlEnum("360")]
        Item360,
        [XmlEnum("361")]
        Item361,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2300 {
    [XmlElement(Order=0)]
    public S_HD_HealthCoverage S_HD_HealthCoverage {get; set;}
    [XmlElement("S_DTP_HealthCoverageDates",Order=1)]
    public List<S_DTP_HealthCoverageDates> S_DTP_HealthCoverageDates {get; set;}
    [XmlElement("S_AMT_HealthCoveragePolicy",Order=2)]
    public List<S_AMT_HealthCoveragePolicy> S_AMT_HealthCoveragePolicy {get; set;}
    [XmlElement(Order=3)]
    public A_REF_2 A_REF_2 {get; set;}
    [XmlElement("S_IDC_IdentificationCard",Order=4)]
    public List<S_IDC_IdentificationCard> S_IDC_IdentificationCard {get; set;}
    [XmlElement("G_TS834_2310",Order=5)]
    public List<G_TS834_2310> G_TS834_2310 {get; set;}
    [XmlElement("G_TS834_2320",Order=6)]
    public List<G_TS834_2320> G_TS834_2320 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_HD_HealthCoverage {
    [XmlElement(Order=0)]
    public X12_ID_875_2 D_HD01_MaintenanceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_HD02_MaintenanceReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_HD03_InsuranceLineCode {get; set;}
    [XmlElement(Order=3)]
    public string D_HD04_PlanCoverageDescription {get; set;}
    [XmlElement(Order=4)]
    public string D_HD05_CoverageLevelCode {get; set;}
    [XmlElement(Order=5)]
    public string D_HD06_Count {get; set;}
    [XmlElement(Order=6)]
    public string D_HD07_Count {get; set;}
    [XmlElement(Order=7)]
    public string D_HD08_UnderwritingDecisionCode {get; set;}
    [XmlElement(Order=8)]
    public string D_HD09_LateEnrollmentIndicator {get; set;}
    [XmlElement(Order=9)]
    public string D_HD10_DrugHouseCode {get; set;}
    [XmlElement(Order=10)]
    public string D_HD11_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_875_2 {
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
    public class S_DTP_HealthCoverageDates {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_2 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CoveragePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_4 {
        [XmlEnum("300")]
        Item300,
        [XmlEnum("303")]
        Item303,
        [XmlEnum("343")]
        Item343,
        [XmlEnum("348")]
        Item348,
        [XmlEnum("349")]
        Item349,
        [XmlEnum("543")]
        Item543,
        [XmlEnum("695")]
        Item695,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1250_2 {
        D8,
        RD8,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_HealthCoveragePolicy {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ContractAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_2 {
    [XmlElement(Order=0)]
    public U_REF_HealthCoveragePolicyNumber U_REF_HealthCoveragePolicyNumber {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_PriorCoverageMonths S_REF_PriorCoverageMonths {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_HealthCoveragePolicyNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MemberGrouporPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5 C_C040_ReferenceIdentifier_5 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        [XmlEnum("17")]
        Item17,
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("9V")]
        Item9V,
        CE,
        E8,
        M7,
        PID,
        RB,
        X9,
        XM,
        XX1,
        XX2,
        ZX,
        ZZ,
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
    public class S_REF_PriorCoverageMonths {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PriorCoverageMonthCount {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_6 C_C040_ReferenceIdentifier_6 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_7 {
        QQ,
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
    public class S_IDC_IdentificationCard {
    [XmlElement(Order=0)]
    public string D_IDC01_PlanCoverageDescription {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1215 D_IDC02_IdentificationCardTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_IDC03_IdentificationCardCount {get; set;}
    [XmlElement(Order=3)]
    public string D_IDC04_ActionCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1215 {
        D,
        H,
        P,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2310 {
    [XmlElement(Order=0)]
    public S_LX_ProviderInformation S_LX_ProviderInformation {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ProviderName S_NM1_ProviderName {get; set;}
    [XmlElement("S_N3_ProviderAddress",Order=2)]
    public List<S_N3_ProviderAddress> S_N3_ProviderAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_ProviderCity_State_ZIPCode S_N4_ProviderCity_State_ZIPCode {get; set;}
    [XmlElement("S_PER_ProviderCommunicationsNumbers",Order=4)]
    public List<S_PER_ProviderCommunicationsNumbers> S_PER_ProviderCommunicationsNumbers {get; set;}
    [XmlElement(Order=5)]
    public S_PLA_ProviderChangeReason S_PLA_ProviderChangeReason {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_ProviderInformation {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_13 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_ProviderLastorOrganizationName {get; set;}
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
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_13 {
        [XmlEnum("1X")]
        Item1X,
        [XmlEnum("3D")]
        Item3D,
        [XmlEnum("80")]
        Item80,
        FA,
        OD,
        P3,
        QA,
        QN,
        Y2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_ProviderAddress {
    [XmlElement(Order=0)]
    public string D_N301_ProviderAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ProviderAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_ProviderCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_ProviderCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_ProviderStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_ProviderPostalZoneorZIPCode {get; set;}
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
    public class S_PER_ProviderCommunicationsNumbers {
    [XmlElement(Order=0)]
    public X12_ID_366_6 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_Name {get; set;}
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
    public enum X12_ID_366_6 {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PLA_ProviderChangeReason {
    [XmlElement(Order=0)]
    public X12_ID_306_3 D_PLA01_ActionCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_98_14 D_PLA02_EntityIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_PLA03_ProviderEffectiveDate {get; set;}
    [XmlElement(Order=3)]
    public string D_PLA04_Time {get; set;}
    [XmlElement(Order=4)]
    public string D_PLA05_MaintenanceReasonCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_306_3 {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_14 {
        [XmlEnum("1P")]
        Item1P,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2320 {
    [XmlElement(Order=0)]
    public S_COB_CoordinationofBenefits S_COB_CoordinationofBenefits {get; set;}
    [XmlElement("S_REF_AdditionalCoordinationofBenefitsIdentifiers",Order=1)]
    public List<S_REF_AdditionalCoordinationofBenefitsIdentifiers> S_REF_AdditionalCoordinationofBenefitsIdentifiers {get; set;}
    [XmlElement("S_DTP_CoordinationofBenefitsEligibilityDates",Order=2)]
    public List<S_DTP_CoordinationofBenefitsEligibilityDates> S_DTP_CoordinationofBenefitsEligibilityDates {get; set;}
    [XmlElement("G_TS834_2330",Order=3)]
    public List<G_TS834_2330> G_TS834_2330 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_COB_CoordinationofBenefits {
    [XmlElement(Order=0)]
    public X12_ID_1138 D_COB01_PayerResponsibilitySequenceNumberCode {get; set;}
    [XmlElement(Order=1)]
    public string D_COB02_MemberGrouporPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_COB03_CoordinationofBenefitsCode {get; set;}
    [XmlElement("D_COB04_ServiceTypeCode",Order=3)]
    public List<string> D_COB04_ServiceTypeCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1138 {
        P,
        S,
        T,
        U,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AdditionalCoordinationofBenefitsIdentifiers {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MemberGrouporPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_7 C_C040_ReferenceIdentifier_7 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_8 {
        [XmlEnum("60")]
        Item60,
        [XmlEnum("6P")]
        Item6P,
        SY,
        ZZ,
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
    public class S_DTP_CoordinationofBenefitsEligibilityDates {
    [XmlElement(Order=0)]
    public X12_ID_374_5 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_CoordinationofBenefitsDate {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_5 {
        [XmlEnum("344")]
        Item344,
        [XmlEnum("345")]
        Item345,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2330 {
    [XmlElement(Order=0)]
    public S_NM1_CoordinationofBenefitsRelatedEntity S_NM1_CoordinationofBenefitsRelatedEntity {get; set;}
    [XmlElement(Order=1)]
    public S_N3_CoordinationofBenefitsRelatedEntityAddress S_N3_CoordinationofBenefitsRelatedEntityAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_CoordinationofBenefitsOtherInsuranceCompanyCity_State_ZIPCode S_N4_CoordinationofBenefitsOtherInsuranceCompanyCity_State_ZIPCode {get; set;}
    [XmlElement(Order=3)]
    public S_PER_AdministrativeCommunicationsContact S_PER_AdministrativeCommunicationsContact {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CoordinationofBenefitsRelatedEntity {
    [XmlElement(Order=0)]
    public X12_ID_98_15 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CoordinationofBenefitsInsurerName {get; set;}
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
    public string D_NM109_CoordinationofBenefitsInsurerIdentification_Code {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_15 {
        [XmlEnum("36")]
        Item36,
        GW,
        IN,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_CoordinationofBenefitsRelatedEntityAddress {
    [XmlElement(Order=0)]
    public string D_N301_AddressInformation {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_AddressInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_CoordinationofBenefitsOtherInsuranceCompanyCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_CoordinationofBenefitsOtherInsuranceCompanyCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_CoordinationofBenefitsOtherInsuranceCompanyStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_CoordinationofBenefitsOtherInsuranceCompanyPostalZoneorZIPCode {get; set;}
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
    public class S_PER_AdministrativeCommunicationsContact {
    [XmlElement(Order=0)]
    public X12_ID_366_7 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_Name {get; set;}
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
    public enum X12_ID_366_7 {
        CN,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_LS {
    [XmlElement(Order=0)]
    public S_LS_AdditionalReportingCategories S_LS_AdditionalReportingCategories {get; set;}
    [XmlElement("G_TS834_2700",Order=1)]
    public List<G_TS834_2700> G_TS834_2700 {get; set;}
    [XmlElement(Order=2)]
    public S_LE_AdditionalReportingCategoriesTermination S_LE_AdditionalReportingCategoriesTermination {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LS_AdditionalReportingCategories {
    [XmlElement(Order=0)]
    public string D_LS01_IdentifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2700 {
    [XmlElement(Order=0)]
    public S_LX_MemberReportingCategories S_LX_MemberReportingCategories {get; set;}
    [XmlElement(Order=1)]
    public G_TS834_2750 G_TS834_2750 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_MemberReportingCategories {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS834_2750 {
    [XmlElement(Order=0)]
    public S_N1_ReportingCategory S_N1_ReportingCategory {get; set;}
    [XmlElement(Order=1)]
    public S_REF_ReportingCategoryReference S_REF_ReportingCategoryReference {get; set;}
    [XmlElement(Order=2)]
    public S_DTP_ReportingCategoryDate S_DTP_ReportingCategoryDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_ReportingCategory {
    [XmlElement(Order=0)]
    public X12_ID_98_16 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_MemberReportingCategoryName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_IdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N105_EntityRelationshipCode {get; set;}
    [XmlElement(Order=5)]
    public string D_N106_EntityIdentifierCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_16 {
        [XmlEnum("75")]
        Item75,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReportingCategoryReference {
    [XmlElement(Order=0)]
    public X12_ID_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_MemberReportingCategoryReferenceID {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_8 C_C040_ReferenceIdentifier_8 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_9 {
        [XmlEnum("00")]
        Item00,
        [XmlEnum("17")]
        Item17,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("26")]
        Item26,
        [XmlEnum("3L")]
        Item3L,
        [XmlEnum("6M")]
        Item6M,
        [XmlEnum("9V")]
        Item9V,
        [XmlEnum("9X")]
        Item9X,
        GE,
        LU,
        PID,
        XX1,
        XX2,
        YY,
        ZZ,
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
    public class S_DTP_ReportingCategoryDate {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTP01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1250_2 D_DTP02_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_DTP03_MemberReportingCategoryEffectiveDate_s {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_6 {
        [XmlEnum("007")]
        Item007,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LE_AdditionalReportingCategoriesTermination {
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS834_1000C {
    [XmlElement("G_TS834_1000C",Order=0)]
    public List<G_TS834_1000C> G_TS834_1000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_MemberSupplementalIdentifier {
    [XmlElement("S_REF_MemberSupplementalIdentifier",Order=0)]
    public List<S_REF_MemberSupplementalIdentifier> S_REF_MemberSupplementalIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS834_2100D {
    [XmlElement("G_TS834_2100D",Order=0)]
    public List<G_TS834_2100D> G_TS834_2100D {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS834_2100E {
    [XmlElement("G_TS834_2100E",Order=0)]
    public List<G_TS834_2100E> G_TS834_2100E {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS834_2100G {
    [XmlElement("G_TS834_2100G",Order=0)]
    public List<G_TS834_2100G> G_TS834_2100G {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_HealthCoveragePolicyNumber {
    [XmlElement("S_REF_HealthCoveragePolicyNumber",Order=0)]
    public List<S_REF_HealthCoveragePolicyNumber> S_REF_HealthCoveragePolicyNumber {get; set;}
    }
}
