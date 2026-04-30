namespace EdiFabric.Rules.X12005010X221A1835 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_835 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BPR_FinancialInformation S_BPR_FinancialInformation {get; set;}
    [XmlElement(Order=2)]
    public S_TRN_ReassociationTraceNumber S_TRN_ReassociationTraceNumber {get; set;}
    [XmlElement(Order=3)]
    public S_CUR_ForeignCurrencyInformation S_CUR_ForeignCurrencyInformation {get; set;}
    [XmlElement(Order=4)]
    public A_REF A_REF {get; set;}
    [XmlElement(Order=5)]
    public S_DTM_ProductionDate S_DTM_ProductionDate {get; set;}
    [XmlElement(Order=6)]
    public A_N1 A_N1 {get; set;}
    [XmlElement("G_TS835_2000",Order=7)]
    public List<G_TS835_2000> G_TS835_2000 {get; set;}
    [XmlElement("S_PLB_ProviderAdjustment",Order=8)]
    public List<S_PLB_ProviderAdjustment> S_PLB_ProviderAdjustment {get; set;}
    [XmlElement(Order=9)]
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
        [XmlEnum("835")]
        Item835,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_BPR_FinancialInformation {
    [XmlElement(Order=0)]
    public X12_ID_305 D_BPR01_TransactionHandlingCode {get; set;}
    [XmlElement(Order=1)]
    public string D_BPR02_TotalActualProviderPaymentAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_BPR03_CreditorDebitFlagCode {get; set;}
    [XmlElement(Order=3)]
    public string D_BPR04_PaymentMethodCode {get; set;}
    [XmlElement(Order=4)]
    public string D_BPR05_PaymentFormatCode {get; set;}
    [XmlElement(Order=5)]
    public string D_BPR06_DepositoryFinancialInstitution_DFI_IdentificationNumberQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_BPR07_SenderDFIIdentifier {get; set;}
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
    public string D_BPR13_ReceiverorProviderBankIDNumber {get; set;}
    [XmlElement(Order=13)]
    public string D_BPR14_AccountNumberQualifier {get; set;}
    [XmlElement(Order=14)]
    public string D_BPR15_ReceiverorProviderAccountNumber {get; set;}
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
        H,
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
    public string D_TRN03_PayerIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_OriginatingCompanySupplementalCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_481 {
        [XmlEnum("1")]
        Item1,
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
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF {
    [XmlElementAttribute(Order=0)]
    public S_REF_ReceiverIdentification S_REF_ReceiverIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_VersionIdentification S_REF_VersionIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReceiverIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReceiverIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier C_C040_ReferenceIdentifier {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128 {
        EV,
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
    public class S_REF_VersionIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_3 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_VersionIdentificationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_2 C_C040_ReferenceIdentifier_2 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_3 {
        F2,
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
    public class S_DTM_ProductionDate {
    [XmlElement(Order=0)]
    public X12_ID_374_2 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_ProductionDate {get; set;}
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
        [XmlEnum("405")]
        Item405,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_N1 {
    [XmlElementAttribute(Order=0)]
    public G_TS835_1000A G_TS835_1000A {get; set;}
    [XmlElementAttribute(Order=1)]
    public G_TS835_1000B G_TS835_1000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS835_1000A {
    [XmlElement(Order=0)]
    public S_N1_PayerIdentification S_N1_PayerIdentification {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayerAddress S_N3_PayerAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayerCity_State_ZIPCode S_N4_PayerCity_State_ZIPCode {get; set;}
    [XmlElement("S_REF_AdditionalPayerIdentification",Order=3)]
    public List<S_REF_AdditionalPayerIdentification> S_REF_AdditionalPayerIdentification {get; set;}
    [XmlElement(Order=4)]
    public A_PER A_PER {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_PayerIdentification {
    [XmlElement(Order=0)]
    public X12_ID_98 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PayerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_PayerIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_N105_EntityRelationshipCode {get; set;}
    [XmlElement(Order=5)]
    public string D_N106_EntityIdentifierCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PayerAddress {
    [XmlElement(Order=0)]
    public string D_N301_PayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PayerCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_PayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PayerStateCode {get; set;}
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
    public class S_REF_AdditionalPayerIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_4 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdditionalPayerIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_3 C_C040_ReferenceIdentifier_3 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_4 {
        [XmlEnum("2U")]
        Item2U,
        EO,
        HI,
        NF,
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
    public class A_PER {
    [XmlElementAttribute(Order=0)]
    public S_PER_PayerBusinessContactInformation S_PER_PayerBusinessContactInformation {get; set;}
    [XmlElement(Order=1)]
    public U_PER_PayerTechnicalContactInformation U_PER_PayerTechnicalContactInformation {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_PER_PayerWEBSite S_PER_PayerWEBSite {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_PayerBusinessContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_PayerContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_PayerContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_PayerContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_PayerContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_366 {
        CX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_PayerTechnicalContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366_2 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_PayerTechnicalContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_PayerContactCommunicationNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_PayerTechnicalContactCommunicationNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_PayerContactCommunicationNumber {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_366_2 {
        BL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_PayerWEBSite {
    [XmlElement(Order=0)]
    public X12_ID_366_3 D_PER01_ContactFunctionCode {get; set;}
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
    public enum X12_ID_366_3 {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS835_1000B {
    [XmlElement(Order=0)]
    public S_N1_PayeeIdentification S_N1_PayeeIdentification {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayeeAddress S_N3_PayeeAddress {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayeeCity_State_ZIPCode S_N4_PayeeCity_State_ZIPCode {get; set;}
    [XmlElement("S_REF_PayeeAdditionalIdentification",Order=3)]
    public List<S_REF_PayeeAdditionalIdentification> S_REF_PayeeAdditionalIdentification {get; set;}
    [XmlElement(Order=4)]
    public S_RDM_RemittanceDeliveryMethod S_RDM_RemittanceDeliveryMethod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_PayeeIdentification {
    [XmlElement(Order=0)]
    public X12_ID_98_3 D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PayeeName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_PayeeIdentificationCode {get; set;}
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
    public class S_N3_PayeeAddress {
    [XmlElement(Order=0)]
    public string D_N301_PayeeAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PayeeAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PayeeCity_State_ZIPCode {
    [XmlElement(Order=0)]
    public string D_N401_PayeeCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PayeeStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PayeePostalZoneorZIPCode {get; set;}
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
    public class S_REF_PayeeAdditionalIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_5 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdditionalPayeeIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_4 C_C040_ReferenceIdentifier_4 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_5 {
        [XmlEnum("0B")]
        Item0B,
        D3,
        PQ,
        TJ,
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
    public class S_RDM_RemittanceDeliveryMethod {
    [XmlElement(Order=0)]
    public X12_ID_756 D_RDM01_ReportTransmissionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_RDM02_Name {get; set;}
    [XmlElement(Order=2)]
    public string D_RDM03_CommunicationNumber {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_5 C_C040_ReferenceIdentifier_5 {get; set;}
    [XmlElement(Order=4)]
    public C_C040_ReferenceIdentifier_6 C_C040_ReferenceIdentifier_6 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_756 {
        BM,
        EM,
        FT,
        OL,
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
    public class G_TS835_2000 {
    [XmlElement(Order=0)]
    public S_LX_HeaderNumber S_LX_HeaderNumber {get; set;}
    [XmlElement(Order=1)]
    public S_TS3_ProviderSummaryInformation S_TS3_ProviderSummaryInformation {get; set;}
    [XmlElement(Order=2)]
    public S_TS2_ProviderSupplementalSummaryInformation S_TS2_ProviderSupplementalSummaryInformation {get; set;}
    [XmlElement("G_TS835_2100",Order=3)]
    public List<G_TS835_2100> G_TS835_2100 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_HeaderNumber {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TS3_ProviderSummaryInformation {
    [XmlElement(Order=0)]
    public string D_TS301_ProviderIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_TS302_FacilityTypeCode {get; set;}
    [XmlElement(Order=2)]
    public string D_TS303_FiscalPeriodDate {get; set;}
    [XmlElement(Order=3)]
    public string D_TS304_TotalClaimCount {get; set;}
    [XmlElement(Order=4)]
    public string D_TS305_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_TS306_MonetaryAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_TS307_MonetaryAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_TS308_MonetaryAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_TS309_MonetaryAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_TS310_MonetaryAmount {get; set;}
    [XmlElement(Order=10)]
    public string D_TS311_MonetaryAmount {get; set;}
    [XmlElement(Order=11)]
    public string D_TS312_MonetaryAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_TS313_TotalMSPPayerAmount {get; set;}
    [XmlElement(Order=13)]
    public string D_TS314_MonetaryAmount {get; set;}
    [XmlElement(Order=14)]
    public string D_TS315_TotalNon_LabChargeAmount {get; set;}
    [XmlElement(Order=15)]
    public string D_TS316_MonetaryAmount {get; set;}
    [XmlElement(Order=16)]
    public string D_TS317_TotalHCPCSReportedChargeAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_TS318_TotalHCPCSPayableAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_TS319_MonetaryAmount {get; set;}
    [XmlElement(Order=19)]
    public string D_TS320_TotalProfessionalComponentAmount {get; set;}
    [XmlElement(Order=20)]
    public string D_TS321_TotalMSPPatientLiabilityMetAmount {get; set;}
    [XmlElement(Order=21)]
    public string D_TS322_TotalPatientReimbursementAmount {get; set;}
    [XmlElement(Order=22)]
    public string D_TS323_TotalPIPClaimCount {get; set;}
    [XmlElement(Order=23)]
    public string D_TS324_TotalPIPAdjustmentAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TS2_ProviderSupplementalSummaryInformation {
    [XmlElement(Order=0)]
    public string D_TS201_TotalDRGAmount {get; set;}
    [XmlElement(Order=1)]
    public string D_TS202_TotalFederalSpecificAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_TS203_TotalHospitalSpecificAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_TS204_TotalDisproportionateShareAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_TS205_TotalCapitalAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_TS206_TotalIndirectMedicalEducationAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_TS207_TotalOutlierDayCount {get; set;}
    [XmlElement(Order=7)]
    public string D_TS208_TotalDayOutlierAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_TS209_TotalCostOutlierAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_TS210_AverageDRGLengthofStay {get; set;}
    [XmlElement(Order=10)]
    public string D_TS211_TotalDischargeCount {get; set;}
    [XmlElement(Order=11)]
    public string D_TS212_TotalCostReportDayCount {get; set;}
    [XmlElement(Order=12)]
    public string D_TS213_TotalCoveredDayCount {get; set;}
    [XmlElement(Order=13)]
    public string D_TS214_TotalNoncoveredDayCount {get; set;}
    [XmlElement(Order=14)]
    public string D_TS215_TotalMSPPass_ThroughAmount {get; set;}
    [XmlElement(Order=15)]
    public string D_TS216_AverageDRGweight {get; set;}
    [XmlElement(Order=16)]
    public string D_TS217_TotalPPSCapitalFSPDRGAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_TS218_TotalPPSCapitalHSPDRGAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_TS219_TotalPPSDSHDRGAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS835_2100 {
    [XmlElement(Order=0)]
    public S_CLP_ClaimPaymentInformation S_CLP_ClaimPaymentInformation {get; set;}
    [XmlElement("S_CAS_ClaimsAdjustment",Order=1)]
    public List<S_CAS_ClaimsAdjustment> S_CAS_ClaimsAdjustment {get; set;}
    [XmlElement(Order=2)]
    public A_NM1 A_NM1 {get; set;}
    [XmlElement(Order=3)]
    public S_MIA_InpatientAdjudicationInformation S_MIA_InpatientAdjudicationInformation {get; set;}
    [XmlElement(Order=4)]
    public S_MOA_OutpatientAdjudicationInformation S_MOA_OutpatientAdjudicationInformation {get; set;}
    [XmlElement(Order=5)]
    public A_REF_2 A_REF_2 {get; set;}
    [XmlElement(Order=6)]
    public A_DTM A_DTM {get; set;}
    [XmlElement("S_PER_ClaimContactInformation",Order=7)]
    public List<S_PER_ClaimContactInformation> S_PER_ClaimContactInformation {get; set;}
    [XmlElement("S_AMT_ClaimSupplementalInformation",Order=8)]
    public List<S_AMT_ClaimSupplementalInformation> S_AMT_ClaimSupplementalInformation {get; set;}
    [XmlElement("S_QTY_ClaimSupplementalInformationQuantity",Order=9)]
    public List<S_QTY_ClaimSupplementalInformationQuantity> S_QTY_ClaimSupplementalInformationQuantity {get; set;}
    [XmlElement("G_TS835_2110",Order=10)]
    public List<G_TS835_2110> G_TS835_2110 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CLP_ClaimPaymentInformation {
    [XmlElement(Order=0)]
    public string D_CLP01_PatientControlNumber {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1029 D_CLP02_ClaimStatusCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CLP03_TotalClaimChargeAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_CLP04_ClaimPaymentAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_CLP05_PatientResponsibilityAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_CLP06_ClaimFilingIndicatorCode {get; set;}
    [XmlElement(Order=6)]
    public string D_CLP07_PayerClaimControlNumber {get; set;}
    [XmlElement(Order=7)]
    public string D_CLP08_FacilityTypeCode {get; set;}
    [XmlElement(Order=8)]
    public string D_CLP09_ClaimFrequencyCode {get; set;}
    [XmlElement(Order=9)]
    public string D_CLP10_PatientStatusCode {get; set;}
    [XmlElement(Order=10)]
    public string D_CLP11_DiagnosisRelatedGroup_DRG_Code {get; set;}
    [XmlElement(Order=11)]
    public string D_CLP12_DiagnosisRelatedGroup_DRG_Weight {get; set;}
    [XmlElement(Order=12)]
    public string D_CLP13_DischargeFraction {get; set;}
    [XmlElement(Order=13)]
    public string D_CLP14_Yes_NoConditionorResponseCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1029 {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("2")]
        Item2,
        [XmlEnum("20")]
        Item20,
        [XmlEnum("21")]
        Item21,
        [XmlEnum("22")]
        Item22,
        [XmlEnum("23")]
        Item23,
        [XmlEnum("25")]
        Item25,
        [XmlEnum("3")]
        Item3,
        [XmlEnum("4")]
        Item4,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ClaimsAdjustment {
    [XmlElement(Order=0)]
    public X12_ID_1033 D_CAS01_ClaimAdjustmentGroupCode {get; set;}
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
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1033 {
        CO,
        OA,
        PI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1 {
    [XmlElementAttribute(Order=0)]
    public S_NM1_PatientName S_NM1_PatientName {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_NM1_InsuredName S_NM1_InsuredName {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_NM1_CorrectedPatient_InsuredName S_NM1_CorrectedPatient_InsuredName {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_NM1_ServiceProviderName S_NM1_ServiceProviderName {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_NM1_CrossoverCarrierName S_NM1_CrossoverCarrierName {get; set;}
    [XmlElementAttribute(Order=5)]
    public S_NM1_CorrectedPriorityPayerName S_NM1_CorrectedPriorityPayerName {get; set;}
    [XmlElementAttribute(Order=6)]
    public S_NM1_OtherSubscriberName S_NM1_OtherSubscriberName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientName {
    [XmlElement(Order=0)]
    public X12_ID_98_4 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PatientNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PatientIdentifier {get; set;}
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
        QC,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065 {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InsuredName {
    [XmlElement(Order=0)]
    public X12_ID_98_5 D_NM101_EntityIdentifierCode {get; set;}
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
    public string D_NM109_SubscriberIdentifier {get; set;}
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
        IL,
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
    public class S_NM1_CorrectedPatient_InsuredName {
    [XmlElement(Order=0)]
    public X12_ID_98_6 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CorrectedPatientorInsuredLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_CorrectedPatientorInsuredFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_CorrectedPatientorInsuredMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_CorrectedPatientorInsuredNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_CorrectedInsuredIdentificationIndicator {get; set;}
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
        [XmlEnum("74")]
        Item74,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceProviderName {
    [XmlElement(Order=0)]
    public X12_ID_98_7 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastorOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RenderingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RenderingProviderMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RenderingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RenderingProviderIdentifier {get; set;}
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
        [XmlEnum("82")]
        Item82,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CrossoverCarrierName {
    [XmlElement(Order=0)]
    public X12_ID_98_8 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CoordinationofBenefitsCarrierName {get; set;}
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
    public string D_NM109_CoordinationofBenefitsCarrierIdentifier {get; set;}
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
        TT,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1065_3 {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CorrectedPriorityPayerName {
    [XmlElement(Order=0)]
    public X12_ID_98 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_3 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CorrectedPriorityPayerName {get; set;}
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
    public string D_NM109_CorrectedPriorityPayerIdentificationNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110_EntityRelationshipCode {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111_EntityIdentifierCode {get; set;}
    [XmlElement(Order=11)]
    public string D_NM112_NameLastorOrganizationName {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_OtherSubscriberName {
    [XmlElement(Order=0)]
    public X12_ID_98_9 D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_1065_2 D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_OtherSubscriberLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_OtherSubscriberFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_OtherSubscriberMiddleNameorInitial {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106_NamePrefix {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_OtherSubscriberNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_OtherSubscriberIdentifier {get; set;}
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
        GB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MIA_InpatientAdjudicationInformation {
    [XmlElement(Order=0)]
    public string D_MIA01_CoveredDaysorVisitsCount {get; set;}
    [XmlElement(Order=1)]
    public string D_MIA02_PPSOperatingOutlierAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MIA03_LifetimePsychiatricDaysCount {get; set;}
    [XmlElement(Order=3)]
    public string D_MIA04_ClaimDRGAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_MIA05_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MIA06_ClaimDisproportionateShareAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_MIA07_ClaimMSPPass_throughAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_MIA08_ClaimPPSCapitalAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MIA09_PPS_CapitalFSPDRGAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_MIA10_PPS_CapitalHSPDRGAmount {get; set;}
    [XmlElement(Order=10)]
    public string D_MIA11_PPS_CapitalDSHDRGAmount {get; set;}
    [XmlElement(Order=11)]
    public string D_MIA12_OldCapitalAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_MIA13_PPS_CapitalIMEamount {get; set;}
    [XmlElement(Order=13)]
    public string D_MIA14_PPS_OperatingHospitalSpecificDRGAmount {get; set;}
    [XmlElement(Order=14)]
    public string D_MIA15_CostReportDayCount {get; set;}
    [XmlElement(Order=15)]
    public string D_MIA16_PPS_OperatingFederalSpecificDRGAmount {get; set;}
    [XmlElement(Order=16)]
    public string D_MIA17_ClaimPPSCapitalOutlierAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_MIA18_ClaimIndirectTeachingAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_MIA19_NonpayableProfessionalComponentAmount {get; set;}
    [XmlElement(Order=19)]
    public string D_MIA20_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=20)]
    public string D_MIA21_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=21)]
    public string D_MIA22_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=22)]
    public string D_MIA23_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=23)]
    public string D_MIA24_PPS_CapitalExceptionAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MOA_OutpatientAdjudicationInformation {
    [XmlElement(Order=0)]
    public string D_MOA01_ReimbursementRate {get; set;}
    [XmlElement(Order=1)]
    public string D_MOA02_ClaimHCPCSPayableAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MOA03_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=3)]
    public string D_MOA04_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=4)]
    public string D_MOA05_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MOA06_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=6)]
    public string D_MOA07_ClaimPaymentRemarkCode {get; set;}
    [XmlElement(Order=7)]
    public string D_MOA08_ClaimESRDPaymentAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MOA09_NonpayableProfessionalComponentAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_2 {
    [XmlElement(Order=0)]
    public U_REF_OtherClaimRelatedIdentification U_REF_OtherClaimRelatedIdentification {get; set;}
    [XmlElement(Order=1)]
    public U_REF_RenderingProviderIdentification U_REF_RenderingProviderIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherClaimRelatedIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_6 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherClaimRelatedIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_7 C_C040_ReferenceIdentifier_7 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_6 {
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("28")]
        Item28,
        [XmlEnum("6P")]
        Item6P,
        [XmlEnum("9A")]
        Item9A,
        [XmlEnum("9C")]
        Item9C,
        BB,
        CE,
        EA,
        F8,
        G1,
        G3,
        IG,
        SY,
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
    public class S_REF_RenderingProviderIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_7 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_8 C_C040_ReferenceIdentifier_8 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_7 {
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
        [XmlEnum("1J")]
        Item1J,
        D3,
        G2,
        LU,
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
    public class A_DTM {
    [XmlElement(Order=0)]
    public U_DTM_StatementFromorToDate U_DTM_StatementFromorToDate {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTM_CoverageExpirationDate S_DTM_CoverageExpirationDate {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTM_ClaimReceivedDate S_DTM_ClaimReceivedDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_StatementFromorToDate {
    [XmlElement(Order=0)]
    public X12_ID_374_3 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_ClaimDate {get; set;}
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
        [XmlEnum("232")]
        Item232,
        [XmlEnum("233")]
        Item233,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_CoverageExpirationDate {
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
    public string D_DTM06_DateTimePeriod {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_374_4 {
        [XmlEnum("036")]
        Item036,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_ClaimReceivedDate {
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
        [XmlEnum("050")]
        Item050,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_ClaimContactInformation {
    [XmlElement(Order=0)]
    public X12_ID_366 D_PER01_ContactFunctionCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PER02_ClaimContactName {get; set;}
    [XmlElement(Order=2)]
    public string D_PER03_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PER04_ClaimContactCommunicationsNumber {get; set;}
    [XmlElement(Order=4)]
    public string D_PER05_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_PER06_ClaimContactCommunicationsNumber {get; set;}
    [XmlElement(Order=6)]
    public string D_PER07_CommunicationNumberQualifier {get; set;}
    [XmlElement(Order=7)]
    public string D_PER08_CommunicationNumberExtension {get; set;}
    [XmlElement(Order=8)]
    public string D_PER09_ContactInquiryReference {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ClaimSupplementalInformation {
    [XmlElement(Order=0)]
    public X12_ID_522 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ClaimSupplementalInformationAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522 {
        AU,
        D8,
        DY,
        F5,
        I,
        NL,
        T,
        T2,
        ZK,
        ZL,
        ZM,
        ZN,
        ZO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_ClaimSupplementalInformationQuantity {
    [XmlElement(Order=0)]
    public X12_ID_673 D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_ClaimSupplementalInformationQuantity {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitofMeasure C_C001_CompositeUnitofMeasure {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04_Free_formInformation {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_673 {
        CA,
        CD,
        LA,
        LE,
        NE,
        NR,
        OU,
        PS,
        VS,
        ZK,
        ZL,
        ZM,
        ZN,
        ZO,
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
    public class G_TS835_2110 {
    [XmlElement(Order=0)]
    public S_SVC_ServicePaymentInformation S_SVC_ServicePaymentInformation {get; set;}
    [XmlElement("S_DTM_ServiceDate",Order=1)]
    public List<S_DTM_ServiceDate> S_DTM_ServiceDate {get; set;}
    [XmlElement("S_CAS_ServiceAdjustment",Order=2)]
    public List<S_CAS_ServiceAdjustment> S_CAS_ServiceAdjustment {get; set;}
    [XmlElement(Order=3)]
    public A_REF_3 A_REF_3 {get; set;}
    [XmlElement("S_AMT_ServiceSupplementalAmount",Order=4)]
    public List<S_AMT_ServiceSupplementalAmount> S_AMT_ServiceSupplementalAmount {get; set;}
    [XmlElement("S_QTY_ServiceSupplementalQuantity",Order=5)]
    public List<S_QTY_ServiceSupplementalQuantity> S_QTY_ServiceSupplementalQuantity {get; set;}
    [XmlElement("S_LQ_HealthCareRemarkCodes",Order=6)]
    public List<S_LQ_HealthCareRemarkCodes> S_LQ_HealthCareRemarkCodes {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVC_ServicePaymentInformation {
    [XmlElement(Order=0)]
    public C_C003_CompositeMedicalProcedureIdentifier C_C003_CompositeMedicalProcedureIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC02_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC03_LineItemProviderPaymentAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC04_NationalUniformBillingCommitteeRevenueCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC05_UnitsofServicePaidCount {get; set;}
    [XmlElement(Order=5)]
    public C_C003_CompositeMedicalProcedureIdentifier_2 C_C003_CompositeMedicalProcedureIdentifier_2 {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC07_OriginalUnitsofServiceCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C003_CompositeMedicalProcedureIdentifier {
    [XmlElement(Order=0)]
    public X12_ID_235 D_C00301_ProductorServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_C00302_AdjudicatedProcedureCode {get; set;}
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
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_235 {
        AD,
        ER,
        HC,
        HP,
        IV,
        N4,
        N6,
        NU,
        UI,
        WK,
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
    public string D_C00307_ProcedureCodeDescription {get; set;}
    [XmlElement(Order=7)]
    public string D_C00308_Product_ServiceID {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_ServiceDate {
    [XmlElement(Order=0)]
    public X12_ID_374_6 D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_ServiceDate {get; set;}
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
    public enum X12_ID_374_6 {
        [XmlEnum("150")]
        Item150,
        [XmlEnum("151")]
        Item151,
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ServiceAdjustment {
    [XmlElement(Order=0)]
    public X12_ID_1033 D_CAS01_ClaimAdjustmentGroupCode {get; set;}
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
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_3 {
    [XmlElement(Order=0)]
    public U_REF_ServiceIdentification U_REF_ServiceIdentification {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_LineItemControlNumber S_REF_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public U_REF_RenderingProviderInformation U_REF_RenderingProviderInformation {get; set;}
    [XmlElement(Order=3)]
    public U_REF_HealthCarePolicyIdentification U_REF_HealthCarePolicyIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_8 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_9 C_C040_ReferenceIdentifier_9 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_8 {
        [XmlEnum("1S")]
        Item1S,
        APC,
        BB,
        E9,
        G1,
        G3,
        LU,
        RB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_9 {
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
    public class S_REF_LineItemControlNumber {
    [XmlElement(Order=0)]
    public X12_ID_128_9 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_LineItemControlNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_10 C_C040_ReferenceIdentifier_10 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_9 {
        [XmlEnum("6R")]
        Item6R,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_10 {
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
    public class S_REF_RenderingProviderInformation {
    [XmlElement(Order=0)]
    public X12_ID_128_10 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_11 C_C040_ReferenceIdentifier_11 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_10 {
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
        [XmlEnum("1J")]
        Item1J,
        D3,
        G2,
        HPI,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_11 {
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
    public class S_REF_HealthCarePolicyIdentification {
    [XmlElement(Order=0)]
    public X12_ID_128_11 D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_HealthcarePolicyIdentification {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03_Description {get; set;}
    [XmlElement(Order=3)]
    public C_C040_ReferenceIdentifier_12 C_C040_ReferenceIdentifier_12 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_128_11 {
        [XmlEnum("0K")]
        Item0K,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C040_ReferenceIdentifier_12 {
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
    public class S_AMT_ServiceSupplementalAmount {
    [XmlElement(Order=0)]
    public X12_ID_522_2 D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ServiceSupplementalAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03_Credit_DebitFlagCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_522_2 {
        B6,
        KH,
        T,
        T2,
        ZK,
        ZL,
        ZM,
        ZN,
        ZO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_ServiceSupplementalQuantity {
    [XmlElement(Order=0)]
    public X12_ID_673_2 D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_ServiceSupplementalQuantityCount {get; set;}
    [XmlElement(Order=2)]
    public C_C001_CompositeUnitofMeasure_2 C_C001_CompositeUnitofMeasure_2 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04_Free_formInformation {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_673_2 {
        ZK,
        ZL,
        ZM,
        ZN,
        ZO,
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
    public class S_LQ_HealthCareRemarkCodes {
    [XmlElement(Order=0)]
    public X12_ID_1270 D_LQ01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_LQ02_RemarkCode {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_1270 {
        HE,
        RX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PLB_ProviderAdjustment {
    [XmlElement(Order=0)]
    public string D_PLB01_ProviderIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_PLB02_FiscalPeriodDate {get; set;}
    [XmlElement(Order=2)]
    public C_C042_AdjustmentIdentifier C_C042_AdjustmentIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_PLB04_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=4)]
    public C_C042_AdjustmentIdentifier_2 C_C042_AdjustmentIdentifier_2 {get; set;}
    [XmlElement(Order=5)]
    public string D_PLB06_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=6)]
    public C_C042_AdjustmentIdentifier_3 C_C042_AdjustmentIdentifier_3 {get; set;}
    [XmlElement(Order=7)]
    public string D_PLB08_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=8)]
    public C_C042_AdjustmentIdentifier_4 C_C042_AdjustmentIdentifier_4 {get; set;}
    [XmlElement(Order=9)]
    public string D_PLB10_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=10)]
    public C_C042_AdjustmentIdentifier_5 C_C042_AdjustmentIdentifier_5 {get; set;}
    [XmlElement(Order=11)]
    public string D_PLB12_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=12)]
    public C_C042_AdjustmentIdentifier_6 C_C042_AdjustmentIdentifier_6 {get; set;}
    [XmlElement(Order=13)]
    public string D_PLB14_ProviderAdjustmentAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C042_AdjustmentIdentifier {
    [XmlElement(Order=0)]
    public string D_C04201_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04202_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C042_AdjustmentIdentifier_2 {
    [XmlElement(Order=0)]
    public string D_C04201_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04202_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C042_AdjustmentIdentifier_3 {
    [XmlElement(Order=0)]
    public string D_C04201_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04202_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C042_AdjustmentIdentifier_4 {
    [XmlElement(Order=0)]
    public string D_C04201_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04202_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C042_AdjustmentIdentifier_5 {
    [XmlElement(Order=0)]
    public string D_C04201_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04202_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_C042_AdjustmentIdentifier_6 {
    [XmlElement(Order=0)]
    public string D_C04201_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_C04202_ProviderAdjustmentIdentifier {get; set;}
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
    public class U_PER_PayerTechnicalContactInformation {
    [XmlElement("S_PER_PayerTechnicalContactInformation",Order=0)]
    public List<S_PER_PayerTechnicalContactInformation> S_PER_PayerTechnicalContactInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherClaimRelatedIdentification {
    [XmlElement("S_REF_OtherClaimRelatedIdentification",Order=0)]
    public List<S_REF_OtherClaimRelatedIdentification> S_REF_OtherClaimRelatedIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_RenderingProviderIdentification {
    [XmlElement("S_REF_RenderingProviderIdentification",Order=0)]
    public List<S_REF_RenderingProviderIdentification> S_REF_RenderingProviderIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_DTM_StatementFromorToDate {
    [XmlElement("S_DTM_StatementFromorToDate",Order=0)]
    public List<S_DTM_StatementFromorToDate> S_DTM_StatementFromorToDate {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_ServiceIdentification {
    [XmlElement("S_REF_ServiceIdentification",Order=0)]
    public List<S_REF_ServiceIdentification> S_REF_ServiceIdentification {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_RenderingProviderInformation {
    [XmlElement("S_REF_RenderingProviderInformation",Order=0)]
    public List<S_REF_RenderingProviderInformation> S_REF_RenderingProviderInformation {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_HealthCarePolicyIdentification {
    [XmlElement("S_REF_HealthCarePolicyIdentification",Order=0)]
    public List<S_REF_HealthCarePolicyIdentification> S_REF_HealthCarePolicyIdentification {get; set;}
    }
}
