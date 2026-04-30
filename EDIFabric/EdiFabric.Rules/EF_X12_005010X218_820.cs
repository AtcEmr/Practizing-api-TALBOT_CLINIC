namespace EdiFabric.Rules.X12005010X218820 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_820 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BPR_FinancialInformation S_BPR_FinancialInformation {get; set;}
    [XmlElement(Order=2)]
    public S_TRN_ReassociationTraceNumber S_TRN_ReassociationTraceNumber {get; set;}
    [XmlElement(Order=3)]
    public S_CUR_ForeignCurrencyInformation S_CUR_ForeignCurrencyInformation {get; set;}
    [XmlElement("S_REF_PremiumReceiversIdentificationKey",Order=4)]
    public List<S_REF_PremiumReceiversIdentificationKey> S_REF_PremiumReceiversIdentificationKey {get; set;}
    [XmlElement(Order=5)]
    public A_DTM A_DTM {get; set;}
    [XmlElement(Order=6)]
    public A_N1 A_N1 {get; set;}
    [XmlElement(Order=7)]
    public A_ENT A_ENT {get; set;}
    [XmlElement(Order=8)]
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
        [XmlEnum("820")]
        Item820,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BPR_FinancialInformation {
    [XmlElement(Order=0)]
    public X12_ID_305 D_BPR01_TransactionHandlingCode {get; set;}
    [XmlElement(Order=1)]
    public string D_BPR02_TotalPremiumPaymentAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_BPR03_CreditorDebitFlagCode {get; set;}
    [XmlElement(Order=3)]
    public string D_BPR04_PaymentMethodCode {get; set;}
    [XmlElement(Order=4)]
    public string D_BPR05_PaymentFormatCode {get; set;}
    [XmlElement(Order=5)]
    public string D_BPR06_DepositoryFinancialInstitution_DFI_IdentificationNumberQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_BPR07_OriginatingDepositoryFinancialInstitution_DFI_Identifier {get; set;}
    [XmlElement(Order=7)]
    public string D_BPR08_AccountNumberQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_BPR09_SenderBankAccountNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_BPR10_PayerIdentifier {get; set;}
    [XmlElement(Order=10)]
    public string D_BPR11_OriginatingCompanySupplementalCode {get; set;}
    [XmlElement(Order=11)]
    public string D_BPR12_DepositoryFinancialInstitution_DFI_IdentificationNumberQualifier {get; set;}
    [XmlElement(Order=12)]
    public string D_BPR13_ReceivingDepositoryFinancialInstitution_DFI_Identifier {get; set;}
    [XmlElement(Order=13)]
    public string D_BPR14_AccountNumberQualifier {get; set;}
    [XmlElement(Order=14)]
    public string D_BPR15_ReceiverBankAccountNumber {get; set;}
    [XmlElement(Order=15)]
    public string D_BPR16_CheckIssueorEFTEffectiveDate {get; set;}
    [XmlElement(Order=16)]
    public string D_BPR17_BusinessFunctionCode {get; set;}
    [XmlElement(Order=17)]
    public string D_BPR18_DFI_IDNumberQualifier {get; set;}
    [XmlElement(Order=18)]
    public string D_BPR19_DFI_IdentificationNumber {get; set;}
    [XmlElement(Order=19)]
    public string D_BPR20_AccountNumberQualifier {get; set;}
    [XmlElement(Order=20)]
    public string D_BPR21_AccountNumber {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_305 {
        C,
        D,
        I,
        P,
        U,
        X,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ReassociationTraceNumber {
    [XmlElement(Order=0)]
    public X12_ID_481 D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_CheckorEFTTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_OriginatingCompanySupplementalCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_481 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("3")]
        Item3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CUR_ForeignCurrencyInformation {
    [XmlElement(Order=0)]
    public X12_ID_98 D_CUR01_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CUR02_CurrencyCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CUR03_ExchangeRate {get; set;}
    [XmlElement(Order=3)]
    public string D_CUR04_EntityIdentifierCode {get; set;}
    [XmlElement(Order=4)]
    public string D_CUR05_CurrencyCode {get; set;}
    [XmlElement(Order=5)]
    public string D_CUR06_CurrencyMarket_ExchangeCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CUR07_Date_TimeQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_CUR08_Date {get; set;}
    [XmlElement(Order=8)]
    public string D_CUR09_Time {get; set;}
    [XmlElement(Order=9)]
    public string D_CUR10_Date_TimeQualifier {get; set;}
    [XmlElement(Order=10)]
    public string D_CUR11_Date {get; set;}
    [XmlElement(Order=11)]
    public string D_CUR12_Time {get; set;}
    [XmlElement(Order=12)]
    public string D_CUR13_Date_TimeQualifier {get; set;}
    [XmlElement(Order=13)]
    public string D_CUR14_Date {get; set;}
    [XmlElement(Order=14)]
    public string D_CUR15_Time {get; set;}
    [XmlElement(Order=15)]
    public string D_CUR16_Date_TimeQualifier {get; set;}
    [XmlElement(Order=16)]
    public string D_CUR17_Date {get; set;}
    [XmlElement(Order=17)]
    public string D_CUR18_Time {get; set;}
    [XmlElement(Order=18)]
    public string D_CUR19_Date_TimeQualifier {get; set;}
    [XmlElement(Order=19)]
    public string D_CUR20_Date {get; set;}
    [XmlElement(Order=20)]
    public string D_CUR21_Time {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98 {
        [XmlEnum("2B")]
        Item2B,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PremiumReceiversIdentificationKey {
    [XmlElement(Order=0)]
    public X12_ID_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PremiumReceiverReferenceIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier C_C040_ReferenceIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128 {
        [XmlEnum("14")]
        Item14,
        [XmlEnum("17")]
        Item17,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("2F")]
        Item2F,
        [XmlEnum("38")]
        Item38,
        [XmlEnum("72")]
        Item72,
        LB,
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
    public class A_DTM {
    [XmlElementAttribute(Order=0)]
    public S_DTM_ProcessDate S_DTM_ProcessDate {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTM_DeliveryDate S_DTM_DeliveryDate {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTM_CoveragePeriod S_DTM_CoveragePeriod {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_DTM_CreationDate S_DTM_CreationDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_ProcessDate {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_PayerProcessDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03_Time {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04_TimeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06_DateTimePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_2 {
        [XmlEnum("009")]
        Item009,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_DeliveryDate {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_PremiumDeliveryDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03_Time {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04_TimeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06_DateTimePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_3 {
        [XmlEnum("035")]
        Item035,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_CoveragePeriod {
    [XmlElement(Order=0)]
    public X12_ID_374_4 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_Date {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03_Time {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04_TimeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06_CoveragePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_4 {
        [XmlEnum("582")]
        Item582,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_CreationDate {
    [XmlElement(Order=0)]
    public X12_ID_374_5 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_Date {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03_Time {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04_TimeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06_DateTimePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_5 {
        [XmlEnum("097")]
        Item097,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_N1 {
    [XmlElementAttribute(Order=0)]
    public G_TS820_1000A G_TS820_1000A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS820_1000B G_TS820_1000B {get; set;}
    [XmlElement(Order=2)]
    public U_TS820_1000C U_TS820_1000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_1000A {
    [XmlElement(Order=0)]
    public S_N1_PremiumReceiver_sName S_N1_PremiumReceiver_sName {get; set;}
    [XmlElement(Order=1)]
    public S_N2_PremiumReceiverAdditionalName S_N2_PremiumReceiverAdditionalName {get; set;}
    [XmlElement(Order=2)]
    public S_N3_PremiumReceiver_sAddress S_N3_PremiumReceiver_sAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_PremiumReceiver_sCity_State_andZIPCode S_N4_PremiumReceiver_sCity_State_andZIPCode {get; set;}
    [XmlElement(Order=4)]
    public S_RDM_PremiumReceiver_sRemittanceDeliveryMethod S_RDM_PremiumReceiver_sRemittanceDeliveryMethod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_PremiumReceiver_sName {
    [XmlElement(Order=0)]
    public X12_ID_98_3 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PremiumReceiver_sLastorOrganizationName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_PremiumReceiver_sIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N105_EntityRelationshipCode {get; set;}
    [XmlElement(Order=5)]
    public string D_N106_EntityIdentifierCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_3 {
        PE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N2_PremiumReceiverAdditionalName {
    [XmlElement(Order=0)]
    public string D_N201_PremiumReceiver_sAdditionalName {get; set;}
    [XmlElement(Order=1)]
    public string D_N202_Name {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PremiumReceiver_sAddress {
    [XmlElement(Order=0)]
    public string D_N301_PremiumReceiver_sAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PremiumReceiver_sAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PremiumReceiver_sCity_State_andZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_PremiumReceiver_sCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PremiumReceiver_sStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PremiumReceiver_sPostalZoneorZipCode {get; set;}
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
    public class S_RDM_PremiumReceiver_sRemittanceDeliveryMethod {
    [XmlElement(Order=0)]
    public X12_ID_756 D_RDM01_RemittanceDeliveryMethodCode {get; set;}
    [XmlElement(Order=1)]
    public string D_RDM02_PremiumReceiver_sLastorOrganizationName {get; set;}
    [XmlElement(Order=2)]
    public string D_RDM03_PremiumReceiver_sCommunicationNumber {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2 C_C040_ReferenceIdentifier_2 {get; set;}
    [XmlElement(Order=4)]
    public C_C040_ReferenceIdentifier_3 C_C040_ReferenceIdentifier_3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_756 {
        BM,
        EM,
        FT,
        FX,
        IA,
        OL,
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
    public class G_TS820_1000B {
    [XmlElement(Order=0)]
    public S_N1_PremiumPayer_sName S_N1_PremiumPayer_sName {get; set;}
    [XmlElement(Order=1)]
    public S_N2_PremiumPayerAdditionalName S_N2_PremiumPayerAdditionalName {get; set;}
    [XmlElement(Order=2)]
    public S_N3_PremiumPayer_sAddress S_N3_PremiumPayer_sAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_PremiumPayer_sCity_State_ZIPCode S_N4_PremiumPayer_sCity_State_ZIPCode {get; set;}
    [XmlElement("S_PER_PremiumPayer_sAdministrativeContact",Order=4)]
    public List<S_PER_PremiumPayer_sAdministrativeContact> S_PER_PremiumPayer_sAdministrativeContact {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_PremiumPayer_sName {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PremiumPayerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_PremiumPayerIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_N105_EntityRelationshipCode {get; set;}
    [XmlElement(Order=5)]
    public string D_N106_EntityIdentifierCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_4 {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N2_PremiumPayerAdditionalName {
    [XmlElement(Order=0)]
    public string D_N201_PremiumPayerAdditionalName {get; set;}
    [XmlElement(Order=1)]
    public string D_N202_Name {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PremiumPayer_sAddress {
    [XmlElement(Order=0)]
    public string D_N301_PremiumPayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PremiumPayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PremiumPayer_sCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_PremiumPayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PremiumPayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PremiumPayerPostalZoneorZIPCode {get; set;}
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
    public class S_PER_PremiumPayer_sAdministrativeContact {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_PremiumPayerContactName {get; set;}
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
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_1000C {
    [XmlElement(Order=0)]
    public S_N1_IntermediaryBankInformation S_N1_IntermediaryBankInformation {get; set;}
    [XmlElement(Order=1)]
    public S_N2_IntermediaryBankAdditionalName S_N2_IntermediaryBankAdditionalName {get; set;}
    [XmlElement(Order=2)]
    public S_N3_IntermediaryBank_sAddress S_N3_IntermediaryBank_sAddress {get; set;}
    [XmlElement(Order=3)]
    public S_N4_IntermediaryBank_sCity_State_ZIPCode S_N4_IntermediaryBank_sCity_State_ZIPCode {get; set;}
    [XmlElement("S_PER_IntermediaryBank_sAdministrativeContact",Order=4)]
    public List<S_PER_IntermediaryBank_sAdministrativeContact> S_PER_IntermediaryBank_sAdministrativeContact {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_IntermediaryBankInformation {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PremiumPayerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_IntermediaryBankIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_N105_EntityRelationshipCode {get; set;}
    [XmlElement(Order=5)]
    public string D_N106_EntityIdentifierCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_5 {
        [XmlEnum("04")]
        Item04,
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("8W")]
        Item8W,
        AK,
        BE,
        BK,
        C1,
        C2,
        IAT,
        MJ,
        RB,
        Z6,
        ZB,
        ZL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N2_IntermediaryBankAdditionalName {
    [XmlElement(Order=0)]
    public string D_N201_IntermediaryBankAdditionalName {get; set;}
    [XmlElement(Order=1)]
    public string D_N202_Name {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_IntermediaryBank_sAddress {
    [XmlElement(Order=0)]
    public string D_N301_IntermediaryBankAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_IntermediaryBankAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_IntermediaryBank_sCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_IntermediaryBankCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_IntermediaryBankStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_IntermediaryBankPostalZoneorZIPCode {get; set;}
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
    public class S_PER_IntermediaryBank_sAdministrativeContact {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_IntermediaryBankContactName {get; set;}
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
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_ENT {
    [XmlElementAttribute(Order=0)]
    public G_TS820_2000A G_TS820_2000A {get; set;}
    [XmlElement(Order=1)]
    public U_TS820_2000B U_TS820_2000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2000A {
    [XmlElement(Order=0)]
    public S_ENT_OrganizationSummaryRemittance S_ENT_OrganizationSummaryRemittance {get; set;}
    [XmlElement("G_TS820_2200A",Order=1)]
    public List<G_TS820_2200A> G_TS820_2200A {get; set;}
    [XmlElement("G_TS820_2300A",Order=2)]
    public List<G_TS820_2300A> G_TS820_2300A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ENT_OrganizationSummaryRemittance {
    [XmlElement(Order=0)]
    public string D_ENT01_AssignedNumber {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_98_6 D_ENT02_EntityIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_ENT03_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ENT04_OrganizationIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_ENT05_EntityIdentifierCode {get; set;}
    [XmlElement(Order=5)]
    public string D_ENT06_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_ENT07_IdentificationCode {get; set;}
    [XmlElement(Order=7)]
    public string D_ENT08_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_ENT09_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_6 {
        [XmlEnum("2L")]
        Item2L,
        AG,
        NH,
        RGA,
        UN,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2200A {
    [XmlElement(Order=0)]
    public S_ADX_OrganizationSummaryRemittanceLevelAdjustmentforPreviousPayment S_ADX_OrganizationSummaryRemittanceLevelAdjustmentforPreviousPayment {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ADX_OrganizationSummaryRemittanceLevelAdjustmentforPreviousPayment {
    [XmlElement(Order=0)]
    public string D_ADX01_PremiumPaymentAdjustmentAmount {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_426 D_ADX02_PremiumPaymentAdjustmentReason {get; set;}
    [XmlElement(Order=2)]
    public string D_ADX03_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ADX04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_426 {
        [XmlEnum("52")]
        Item52,
        [XmlEnum("53")]
        Item53,
        [XmlEnum("80")]
        Item80,
        [XmlEnum("81")]
        Item81,
        [XmlEnum("86")]
        Item86,
        BJ,
        H1,
        H6,
        RU,
        WO,
        WW,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2300A {
    [XmlElement(Order=0)]
    public S_RMR_OrganizationSummaryRemittanceDetail S_RMR_OrganizationSummaryRemittanceDetail {get; set;}
    [XmlElement("S_REF_ReferenceInformation",Order=1)]
    public List<S_REF_ReferenceInformation> S_REF_ReferenceInformation {get; set;}
    [XmlElement(Order=2)]
    public S_DTM_OrganizationalCoveragePeriod S_DTM_OrganizationalCoveragePeriod {get; set;}
    [XmlElement(Order=3)]
    public G_TS820_2310A G_TS820_2310A {get; set;}
    [XmlElement("G_TS820_2320A",Order=4)]
    public List<G_TS820_2320A> G_TS820_2320A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_RMR_OrganizationSummaryRemittanceDetail {
    [XmlElement(Order=0)]
    public X12_ID_128_3 D_RMR01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_RMR02_Contract_Invoice_Account_Group_orPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_RMR03_PaymentActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_RMR04_DetailPremiumPaymentAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_RMR05_BilledPremiumAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_RMR06_MonetaryAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_RMR07_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=7)]
    public string D_RMR08_MonetaryAmount {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_3 {
        [XmlEnum("11")]
        Item11,
        [XmlEnum("1L")]
        Item1L,
        CT,
        IK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReferenceInformation {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_OrganizationalReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OrganizationalReferenceIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4 C_C040_ReferenceIdentifier_4 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        [XmlEnum("14")]
        Item14,
        [XmlEnum("17")]
        Item17,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("2F")]
        Item2F,
        [XmlEnum("38")]
        Item38,
        E9,
        LB,
        LU,
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
    public class S_DTM_OrganizationalCoveragePeriod {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_Date {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03_Time {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04_TimeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06_CoveragePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_6 {
        [XmlEnum("582")]
        Item582,
        AAG,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2310A {
    [XmlElement(Order=0)]
    public S_IT1_SummaryLineItem S_IT1_SummaryLineItem {get; set;}
    [XmlElement("G_TS820_2312A",Order=1)]
    public List<G_TS820_2312A> G_TS820_2312A {get; set;}
    [XmlElement("G_TS820_2315A",Order=2)]
    public List<G_TS820_2315A> G_TS820_2315A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_IT1_SummaryLineItem {
    [XmlElement(Order=0)]
    public string D_IT101_LineItemControlNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_IT102_QuantityInvoiced {get; set;}
    [XmlElement(Order=2)]
    public string D_IT103_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=3)]
    public string D_IT104_UnitPrice {get; set;}
    [XmlElement(Order=4)]
    public string D_IT105_BasisofUnitPriceCode {get; set;}
    [XmlElement(Order=5)]
    public string D_IT106_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_IT107_Product_ServiceID {get; set;}
    [XmlElement(Order=7)]
    public string D_IT108_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_IT109_Product_ServiceID {get; set;}
    [XmlElement(Order=9)]
    public string D_IT110_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=10)]
    public string D_IT111_Product_ServiceID {get; set;}
    [XmlElement(Order=11)]
    public string D_IT112_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=12)]
    public string D_IT113_Product_ServiceID {get; set;}
    [XmlElement(Order=13)]
    public string D_IT114_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=14)]
    public string D_IT115_Product_ServiceID {get; set;}
    [XmlElement(Order=15)]
    public string D_IT116_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=16)]
    public string D_IT117_Product_ServiceID {get; set;}
    [XmlElement(Order=17)]
    public string D_IT118_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=18)]
    public string D_IT119_Product_ServiceID {get; set;}
    [XmlElement(Order=19)]
    public string D_IT120_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=20)]
    public string D_IT121_Product_ServiceID {get; set;}
    [XmlElement(Order=21)]
    public string D_IT122_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=22)]
    public string D_IT123_Product_ServiceID {get; set;}
    [XmlElement(Order=23)]
    public string D_IT124_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=24)]
    public string D_IT125_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2312A {
    [XmlElement(Order=0)]
    public S_SAC_Service_Promotion_Allowance_orChargeInformation S_SAC_Service_Promotion_Allowance_orChargeInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SAC_Service_Promotion_Allowance_orChargeInformation {
    [XmlElement(Order=0)]
    public X12_ID_248 D_SAC01_AllowanceorChargeIndicator {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1300 D_SAC02_Service_Promotion_Allowance_orChargeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SAC03_AgencyQualifierCode {get; set;}
    [XmlElement(Order=3)]
    public string D_SAC04_AgencyService_Promotion_Allowance_orChargeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SAC05_Amount {get; set;}
    [XmlElement(Order=5)]
    public string D_SAC06_Allowance_ChargePercentQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SAC07_Percent_DecimalFormat {get; set;}
    [XmlElement(Order=7)]
    public string D_SAC08_Rate {get; set;}
    [XmlElement(Order=8)]
    public string D_SAC09_UnitorBasisforMeasurementCode {get; set;}
    [XmlElement(Order=9)]
    public string D_SAC10_Quantity {get; set;}
    [XmlElement(Order=10)]
    public string D_SAC11_Quantity {get; set;}
    [XmlElement(Order=11)]
    public string D_SAC12_AllowanceorChargeMethodofHandlingCode {get; set;}
    [XmlElement(Order=12)]
    public string D_SAC13_ReferenceIdentification {get; set;}
    [XmlElement(Order=13)]
    public string D_SAC14_OptionNumber {get; set;}
    [XmlElement(Order=14)]
    public string D_SAC15_Description {get; set;}
    [XmlElement(Order=15)]
    public string D_SAC16_LanguageCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_248 {
        C,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1300 {
        A172,
        B680,
        D940,
        G740,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2315A {
    [XmlElement(Order=0)]
    public S_SLN_MemberCount S_SLN_MemberCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SLN_MemberCount {
    [XmlElement(Order=0)]
    public string D_SLN01_LineItemControlNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_SLN02_AssignedIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_SLN03_InformationOnlyIndicator {get; set;}
    [XmlElement(Order=3)]
    public string D_SLN04_HeadCount {get; set;}
    [XmlElement(Order=4)]
    public C_C001_CompositeUnitofMeasure C_C001_CompositeUnitofMeasure {get; set;}
    [XmlElement(Order=5)]
    public string D_SLN06_UnitPrice {get; set;}
    [XmlElement(Order=6)]
    public string D_SLN07_BasisofUnitPriceCode {get; set;}
    [XmlElement(Order=7)]
    public string D_SLN08_RelationshipCode {get; set;}
    [XmlElement(Order=8)]
    public string D_SLN09_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=9)]
    public string D_SLN10_Product_ServiceID {get; set;}
    [XmlElement(Order=10)]
    public string D_SLN11_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=11)]
    public string D_SLN12_Product_ServiceID {get; set;}
    [XmlElement(Order=12)]
    public string D_SLN13_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=13)]
    public string D_SLN14_Product_ServiceID {get; set;}
    [XmlElement(Order=14)]
    public string D_SLN15_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=15)]
    public string D_SLN16_Product_ServiceID {get; set;}
    [XmlElement(Order=16)]
    public string D_SLN17_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=17)]
    public string D_SLN18_Product_ServiceID {get; set;}
    [XmlElement(Order=18)]
    public string D_SLN19_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=19)]
    public string D_SLN20_Product_ServiceID {get; set;}
    [XmlElement(Order=20)]
    public string D_SLN21_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=21)]
    public string D_SLN22_Product_ServiceID {get; set;}
    [XmlElement(Order=22)]
    public string D_SLN23_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=23)]
    public string D_SLN24_Product_ServiceID {get; set;}
    [XmlElement(Order=24)]
    public string D_SLN25_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=25)]
    public string D_SLN26_Product_ServiceID {get; set;}
    [XmlElement(Order=26)]
    public string D_SLN27_Product_ServiceIDQualifier {get; set;}
    [XmlElement(Order=27)]
    public string D_SLN28_Product_ServiceID {get; set;}
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
    public class G_TS820_2320A {
    [XmlElement(Order=0)]
    public S_ADX_OrganizationSummaryRemittanceLevelAdjustmentforCurrentPayment S_ADX_OrganizationSummaryRemittanceLevelAdjustmentforCurrentPayment {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ADX_OrganizationSummaryRemittanceLevelAdjustmentforCurrentPayment {
    [XmlElement(Order=0)]
    public string D_ADX01_AdjustmentAmount {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_426_3 D_ADX02_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_ADX03_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ADX04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_426_3 {
        [XmlEnum("20")]
        Item20,
        [XmlEnum("52")]
        Item52,
        [XmlEnum("53")]
        Item53,
        AA,
        AX,
        H1,
        H6,
        IA,
        J3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2000B {
    [XmlElement(Order=0)]
    public S_ENT_IndividualRemittance S_ENT_IndividualRemittance {get; set;}
    [XmlElement("G_TS820_2100B",Order=1)]
    public List<G_TS820_2100B> G_TS820_2100B {get; set;}
    [XmlElement("G_TS820_2200B",Order=2)]
    public List<G_TS820_2200B> G_TS820_2200B {get; set;}
    [XmlElement("G_TS820_2300B",Order=3)]
    public List<G_TS820_2300B> G_TS820_2300B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ENT_IndividualRemittance {
    [XmlElement(Order=0)]
    public string D_ENT01_AssignedNumber {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_98_7 D_ENT02_EntityIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_ENT03_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ENT04_Receiver_sIndividualIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_ENT05_EntityIdentifierCode {get; set;}
    [XmlElement(Order=5)]
    public string D_ENT06_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_ENT07_IdentificationCode {get; set;}
    [XmlElement(Order=7)]
    public string D_ENT08_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_ENT09_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_98_7 {
        [XmlEnum("2J")]
        Item2J,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2100B {
    [XmlElement(Order=0)]
    public S_NM1_IndividualName S_NM1_IndividualName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_IndividualName {
    [XmlElement(Order=0)]
    public X12_ID_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_IndividualLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_IndividualFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_IndividualMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_IndividualNamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_IndividualNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_IndividualIdentifier {get; set;}
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
        DO,
        EY,
        IL,
        QE,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2200B {
    [XmlElement(Order=0)]
    public S_ADX_IndividualPremiumAdjustmentforPreviousPayment S_ADX_IndividualPremiumAdjustmentforPreviousPayment {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ADX_IndividualPremiumAdjustmentforPreviousPayment {
    [XmlElement(Order=0)]
    public string D_ADX01_PremiumPaymentAdjustmentAmount {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_426_4 D_ADX02_PremiumPaymentAdjustmentReason {get; set;}
    [XmlElement(Order=2)]
    public string D_ADX03_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ADX04_ReferenceIdentification {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_426_4 {
        [XmlEnum("52")]
        Item52,
        [XmlEnum("53")]
        Item53,
        [XmlEnum("80")]
        Item80,
        [XmlEnum("81")]
        Item81,
        [XmlEnum("86")]
        Item86,
        BJ,
        H1,
        H6,
        RU,
        WO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2300B {
    [XmlElement(Order=0)]
    public S_RMR_IndividualPremiumRemittanceDetail S_RMR_IndividualPremiumRemittanceDetail {get; set;}
    [XmlElement("S_REF_ReferenceInformation_2",Order=1)]
    public List<S_REF_ReferenceInformation_2> S_REF_ReferenceInformation_2 {get; set;}
    [XmlElement(Order=2)]
    public S_DTM_IndividualCoveragePeriod S_DTM_IndividualCoveragePeriod {get; set;}
    [XmlElement("G_TS820_2320B",Order=3)]
    public List<G_TS820_2320B> G_TS820_2320B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_RMR_IndividualPremiumRemittanceDetail {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_RMR01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_RMR02_InsuranceRemittanceReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_RMR03_PaymentActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_RMR04_DetailPremiumPaymentAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_RMR05_BilledPremiumAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_RMR06_MonetaryAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_RMR07_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=7)]
    public string D_RMR08_MonetaryAmount {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
        [XmlEnum("11")]
        Item11,
        [XmlEnum("9J")]
        Item9J,
        AZ,
        B7,
        CT,
        ID,
        IG,
        IK,
        KW,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReferenceInformation_2 {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_OrganizationalReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OrganizationalReferenceIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5 C_C040_ReferenceIdentifier_5 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        [XmlEnum("14")]
        Item14,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("2F")]
        Item2F,
        [XmlEnum("38")]
        Item38,
        E9,
        LU,
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
    public class S_DTM_IndividualCoveragePeriod {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_Date {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03_Time {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04_TimeCode {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06_CoveragePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820_2320B {
    [XmlElement(Order=0)]
    public S_ADX_IndividualPremiumAdjustmentforCurrentPayment S_ADX_IndividualPremiumAdjustmentforCurrentPayment {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ADX_IndividualPremiumAdjustmentforCurrentPayment {
    [XmlElement(Order=0)]
    public string D_ADX01_AdjustmentAmount {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_426_3 D_ADX02_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_ADX03_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ADX04_ReferenceIdentification {get; set;}
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
    public class U_TS820_1000C {
    [XmlElement("G_TS820_1000C",Order=0)]
    public List<G_TS820_1000C> G_TS820_1000C {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_TS820_2000B {
    [XmlElement("G_TS820_2000B",Order=0)]
    public List<G_TS820_2000B> G_TS820_2000B {get; set;}
    }
}
