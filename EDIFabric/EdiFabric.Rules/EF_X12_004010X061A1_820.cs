namespace EdiFabric.Rules.X12004010X061A1820 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_820 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BPR_FinancialInformation_TS820A1 S_BPR_FinancialInformation_TS820A1 {get; set;}
    [XmlElement(Order=2)]
    public S_TRN_ReassociationKey_TS820A1 S_TRN_ReassociationKey_TS820A1 {get; set;}
    [XmlElement(Order=3)]
    public S_CUR_NonUSDollarsCurrency_TS820A1 S_CUR_NonUSDollarsCurrency_TS820A1 {get; set;}
    [XmlElement("S_REF_PremiumReceiversIdentificationKey_TS820A1",Order=4)]
    public List<S_REF_PremiumReceiversIdentificationKey_TS820A1> S_REF_PremiumReceiversIdentificationKey_TS820A1 {get; set;}
    [XmlElement(Order=5)]
    public A_DTM_TS820A1 A_DTM_TS820A1 {get; set;}
    [XmlElement(Order=6)]
    public G_TS820A1_1000A G_TS820A1_1000A {get; set;}
    [XmlElement(Order=7)]
    public G_TS820A1_1000B G_TS820A1_1000B {get; set;}
    [XmlElement(Order=8)]
    public G_TS820A1_2000A G_TS820A1_2000A {get; set;}
    [XmlElement("G_TS820A1_2000B",Order=9)]
    public List<G_TS820A1_2000B> G_TS820A1_2000B {get; set;}
    [XmlElement(Order=10)]
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
    public class S_BPR_FinancialInformation_TS820A1 {
    [XmlElement(Order=0)]
    public S_BPR_FinancialInformation_TS820A1D_BPR01_TransactionHandlingCode D_BPR01_TransactionHandlingCode {get; set;}
    [XmlElement(Order=1)]
    public string D_BPR02_TotalPremiumPaymentAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_BPR03_CreditOrDebitFlagCode {get; set;}
    [XmlElement(Order=3)]
    public string D_BPR04_PaymentMethodCode {get; set;}
    [XmlElement(Order=4)]
    public string D_BPR05_PaymentFormatCode {get; set;}
    [XmlElement(Order=5)]
    public string D_BPR06_DepositoryFinancialInstitutionDFIIdentificationNumberQualifier {get; set;}
    [XmlElement(Order=6)]
    public string D_BPR07_OriginatingDepositoryFinancialInstitutionDFIIdentifier {get; set;}
    [XmlElement(Order=7)]
    public string D_BPR08_AccountNumberQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_BPR09_SenderBankAccountNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_BPR10_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=10)]
    public string D_BPR11_OriginatingCompanySupplementalCode {get; set;}
    [XmlElement(Order=11)]
    public string D_BPR12_DepositoryFinancialInstitutionDFIIdentificationNumberQualifier {get; set;}
    [XmlElement(Order=12)]
    public string D_BPR13_ReceivingDepositoryFinancialInstitutionDFIIdentifier {get; set;}
    [XmlElement(Order=13)]
    public string D_BPR14_AccountNumberQualifier {get; set;}
    [XmlElement(Order=14)]
    public string D_BPR15_ReceiverBankAccountNumber {get; set;}
    [XmlElement(Order=15)]
    public string D_BPR16_CheckIssueOrEFTEffectiveDate {get; set;}
    [XmlElement(Order=16)]
    public string D_BPR17 {get; set;}
    [XmlElement(Order=17)]
    public string D_BPR18 {get; set;}
    [XmlElement(Order=18)]
    public string D_BPR19 {get; set;}
    [XmlElement(Order=19)]
    public string D_BPR20 {get; set;}
    [XmlElement(Order=20)]
    public string D_BPR21 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_BPR_FinancialInformation_TS820A1D_BPR01_TransactionHandlingCode {
        C,
        D,
        I,
        P,
        U,
        X,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TRN_ReassociationKey_TS820A1 {
    [XmlElement(Order=0)]
    public S_TRN_ReassociationKey_TS820A1D_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_CheckOrEFTTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_OriginatingCompanyIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_OriginatingCompanySupplementalCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_ReassociationKey_TS820A1D_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("3")]
        Item3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CUR_NonUSDollarsCurrency_TS820A1 {
    [XmlElement(Order=0)]
    public S_CUR_NonUSDollarsCurrency_TS820A1D_CUR01_EntityIdentifierCode D_CUR01_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_CUR02_CurrencyCode {get; set;}
    [XmlElement(Order=2)]
    public string D_CUR03_ExchangeRate {get; set;}
    [XmlElement(Order=3)]
    public string D_CUR04 {get; set;}
    [XmlElement(Order=4)]
    public string D_CUR05 {get; set;}
    [XmlElement(Order=5)]
    public string D_CUR06 {get; set;}
    [XmlElement(Order=6)]
    public string D_CUR07 {get; set;}
    [XmlElement(Order=7)]
    public string D_CUR08 {get; set;}
    [XmlElement(Order=8)]
    public string D_CUR09 {get; set;}
    [XmlElement(Order=9)]
    public string D_CUR10 {get; set;}
    [XmlElement(Order=10)]
    public string D_CUR11 {get; set;}
    [XmlElement(Order=11)]
    public string D_CUR12 {get; set;}
    [XmlElement(Order=12)]
    public string D_CUR13 {get; set;}
    [XmlElement(Order=13)]
    public string D_CUR14 {get; set;}
    [XmlElement(Order=14)]
    public string D_CUR15 {get; set;}
    [XmlElement(Order=15)]
    public string D_CUR16 {get; set;}
    [XmlElement(Order=16)]
    public string D_CUR17 {get; set;}
    [XmlElement(Order=17)]
    public string D_CUR18 {get; set;}
    [XmlElement(Order=18)]
    public string D_CUR19 {get; set;}
    [XmlElement(Order=19)]
    public string D_CUR20 {get; set;}
    [XmlElement(Order=20)]
    public string D_CUR21 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CUR_NonUSDollarsCurrency_TS820A1D_CUR01_EntityIdentifierCode {
        [XmlEnum("2B")]
        Item2B,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PremiumReceiversIdentificationKey_TS820A1 {
    [XmlElement(Order=0)]
    public S_REF_PremiumReceiversIdentificationKey_TS820A1D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_PremiumReceiverReferenceIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U758 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PremiumReceiversIdentificationKey_TS820A1D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("14")]
        Item14,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("2F")]
        Item2F,
        [XmlEnum("38")]
        Item38,
        [XmlEnum("72")]
        Item72,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_DTM_TS820A1 {
    [XmlElementAttribute(Order=0)]
    public S_DTM_ProcessDate_TS820A1 S_DTM_ProcessDate_TS820A1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_DTM_DeliveryDate_TS820A1 S_DTM_DeliveryDate_TS820A1 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_DTM_CoveragePeriod_TS820A1 S_DTM_CoveragePeriod_TS820A1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_ProcessDate_TS820A1 {
    [XmlElement(Order=0)]
    public S_DTM_ProcessDate_TS820A1D_DTM01_DateTimeQualifier D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_PayerProcessDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03 {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04 {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05 {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTM_ProcessDate_TS820A1D_DTM01_DateTimeQualifier {
        [XmlEnum("009")]
        Item009,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_DeliveryDate_TS820A1 {
    [XmlElement(Order=0)]
    public S_DTM_DeliveryDate_TS820A1D_DTM01_DateTimeQualifier D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_PremiumDeliveryDate {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03 {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04 {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05 {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTM_DeliveryDate_TS820A1D_DTM01_DateTimeQualifier {
        [XmlEnum("035")]
        Item035,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_CoveragePeriod_TS820A1 {
    [XmlElement(Order=0)]
    public S_DTM_CoveragePeriod_TS820A1D_DTM01_DateTimeQualifier D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02 {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03 {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04 {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06_CoveragePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTM_CoveragePeriod_TS820A1D_DTM01_DateTimeQualifier {
        [XmlEnum("582")]
        Item582,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_1000A {
    [XmlElement(Order=0)]
    public S_N1_PremiumReceiversName_TS820A1_1000A S_N1_PremiumReceiversName_TS820A1_1000A {get; set;}
    [XmlElement(Order=1)]
    public S_N2_PremiumReceiverAdditionalName_TS820A1_1000A S_N2_PremiumReceiverAdditionalName_TS820A1_1000A {get; set;}
    [XmlElement(Order=2)]
    public S_N3_PremiumReceiversAddress_TS820A1_1000A S_N3_PremiumReceiversAddress_TS820A1_1000A {get; set;}
    [XmlElement(Order=3)]
    public S_N4_PremiumReceiversCityStateZip_TS820A1_1000A S_N4_PremiumReceiversCityStateZip_TS820A1_1000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_PremiumReceiversName_TS820A1_1000A {
    [XmlElement(Order=0)]
    public S_N1_PremiumReceiversName_TS820A1_1000AD_N101_EntityIdentifierCode D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_InformationReceiverLastOrOrganizationName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_ReceiverIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_N105 {get; set;}
    [XmlElement(Order=5)]
    public string D_N106 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_N1_PremiumReceiversName_TS820A1_1000AD_N101_EntityIdentifierCode {
        PE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N2_PremiumReceiverAdditionalName_TS820A1_1000A {
    [XmlElement(Order=0)]
    public string D_N201_ReceiverAdditionalName {get; set;}
    [XmlElement(Order=1)]
    public string D_N202 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PremiumReceiversAddress_TS820A1_1000A {
    [XmlElement(Order=0)]
    public string D_N301_ReceiverAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_ReceiverAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PremiumReceiversCityStateZip_TS820A1_1000A {
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
    public class G_TS820A1_1000B {
    [XmlElement(Order=0)]
    public S_N1_PremiumPayersName_TS820A1_1000B S_N1_PremiumPayersName_TS820A1_1000B {get; set;}
    [XmlElement(Order=1)]
    public S_N2_PremiumPayerAdditionalName_TS820A1_1000B S_N2_PremiumPayerAdditionalName_TS820A1_1000B {get; set;}
    [XmlElement(Order=2)]
    public S_N3_PremiumPayersAddress_TS820A1_1000B S_N3_PremiumPayersAddress_TS820A1_1000B {get; set;}
    [XmlElement(Order=3)]
    public S_N4_PremiumPayersCityStateZip_TS820A1_1000B S_N4_PremiumPayersCityStateZip_TS820A1_1000B {get; set;}
    [XmlElement("S_PER_PremiumPayersAdministrativeContact_TS820A1_1000B",Order=4)]
    public List<S_PER_PremiumPayersAdministrativeContact_TS820A1_1000B> S_PER_PremiumPayersAdministrativeContact_TS820A1_1000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_PremiumPayersName_TS820A1_1000B {
    [XmlElement(Order=0)]
    public S_N1_PremiumPayersName_TS820A1_1000BD_N101_EntityIdentifierCode D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PremiumPayerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_PremiumPayerIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_N105 {get; set;}
    [XmlElement(Order=5)]
    public string D_N106 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_N1_PremiumPayersName_TS820A1_1000BD_N101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N2_PremiumPayerAdditionalName_TS820A1_1000B {
    [XmlElement(Order=0)]
    public string D_N201_PremiumPayerAdditionalName {get; set;}
    [XmlElement(Order=1)]
    public string D_N202 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PremiumPayersAddress_TS820A1_1000B {
    [XmlElement(Order=0)]
    public string D_N301_PremiumPayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PremiumPayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PremiumPayersCityStateZip_TS820A1_1000B {
    [XmlElement(Order=0)]
    public string D_N401_PremiumPayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PremiumPayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PremiumPayerPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_PremiumPayersAdministrativeContact_TS820A1_1000B {
    [XmlElement(Order=0)]
    public S_PER_PremiumPayersAdministrativeContact_TS820A1_1000BD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_PremiumPayersAdministrativeContact_TS820A1_1000BD_PER01_ContactFunctionCode {
        IC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2000A {
    [XmlElement(Order=0)]
    public S_ENT_OrganizationSummaryRemittance_TS820A1_2000A S_ENT_OrganizationSummaryRemittance_TS820A1_2000A {get; set;}
    [XmlElement("G_TS820A1_2300A",Order=1)]
    public List<G_TS820A1_2300A> G_TS820A1_2300A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ENT_OrganizationSummaryRemittance_TS820A1_2000A {
    [XmlElement(Order=0)]
    public string D_ENT01_AssignedNumber {get; set;}
    [XmlElement(Order=1)]
    public S_ENT_OrganizationSummaryRemittance_TS820A1_2000AD_ENT02_EntityIdentifierCode D_ENT02_EntityIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_ENT03_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ENT04_OrganizationIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_ENT05 {get; set;}
    [XmlElement(Order=5)]
    public string D_ENT06 {get; set;}
    [XmlElement(Order=6)]
    public string D_ENT07 {get; set;}
    [XmlElement(Order=7)]
    public string D_ENT08 {get; set;}
    [XmlElement(Order=8)]
    public string D_ENT09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_ENT_OrganizationSummaryRemittance_TS820A1_2000AD_ENT02_EntityIdentifierCode {
        [XmlEnum("2L")]
        Item2L,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2300A {
    [XmlElement(Order=0)]
    public S_RMR_OrganizationSummaryRemittanceDetail_TS820A1_2300A S_RMR_OrganizationSummaryRemittanceDetail_TS820A1_2300A {get; set;}
    [XmlElement(Order=1)]
    public G_TS820A1_2310A G_TS820A1_2310A {get; set;}
    [XmlElement("G_TS820A1_2320A",Order=2)]
    public List<G_TS820A1_2320A> G_TS820A1_2320A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_RMR_OrganizationSummaryRemittanceDetail_TS820A1_2300A {
    [XmlElement(Order=0)]
    public S_RMR_OrganizationSummaryRemittanceDetail_TS820A1_2300AD_RMR01_ReferenceIdentificationQualifier D_RMR01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_RMR02_ContractInvoiceAccountGroupOrPolicyNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_RMR03_PaymentActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_RMR04_DetailPremiumPaymentAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_RMR05_BilledPremiumAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_RMR06 {get; set;}
    [XmlElement(Order=6)]
    public string D_RMR07 {get; set;}
    [XmlElement(Order=7)]
    public string D_RMR08 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_RMR_OrganizationSummaryRemittanceDetail_TS820A1_2300AD_RMR01_ReferenceIdentificationQualifier {
        [XmlEnum("11")]
        Item11,
        [XmlEnum("1L")]
        Item1L,
        CT,
        IK,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2310A {
    [XmlElement(Order=0)]
    public S_IT1_SummaryLineItem_TS820A1_2310A S_IT1_SummaryLineItem_TS820A1_2310A {get; set;}
    [XmlElement("G_TS820A1_2315A",Order=1)]
    public List<G_TS820A1_2315A> G_TS820A1_2315A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_IT1_SummaryLineItem_TS820A1_2310A {
    [XmlElement(Order=0)]
    public string D_IT101_LineItemControlNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_IT102 {get; set;}
    [XmlElement(Order=2)]
    public string D_IT103 {get; set;}
    [XmlElement(Order=3)]
    public string D_IT104 {get; set;}
    [XmlElement(Order=4)]
    public string D_IT105 {get; set;}
    [XmlElement(Order=5)]
    public string D_IT106 {get; set;}
    [XmlElement(Order=6)]
    public string D_IT107 {get; set;}
    [XmlElement(Order=7)]
    public string D_IT108 {get; set;}
    [XmlElement(Order=8)]
    public string D_IT109 {get; set;}
    [XmlElement(Order=9)]
    public string D_IT110 {get; set;}
    [XmlElement(Order=10)]
    public string D_IT111 {get; set;}
    [XmlElement(Order=11)]
    public string D_IT112 {get; set;}
    [XmlElement(Order=12)]
    public string D_IT113 {get; set;}
    [XmlElement(Order=13)]
    public string D_IT114 {get; set;}
    [XmlElement(Order=14)]
    public string D_IT115 {get; set;}
    [XmlElement(Order=15)]
    public string D_IT116 {get; set;}
    [XmlElement(Order=16)]
    public string D_IT117 {get; set;}
    [XmlElement(Order=17)]
    public string D_IT118 {get; set;}
    [XmlElement(Order=18)]
    public string D_IT119 {get; set;}
    [XmlElement(Order=19)]
    public string D_IT120 {get; set;}
    [XmlElement(Order=20)]
    public string D_IT121 {get; set;}
    [XmlElement(Order=21)]
    public string D_IT122 {get; set;}
    [XmlElement(Order=22)]
    public string D_IT123 {get; set;}
    [XmlElement(Order=23)]
    public string D_IT124 {get; set;}
    [XmlElement(Order=24)]
    public string D_IT125 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2315A {
    [XmlElement(Order=0)]
    public S_SLN_MemberCount_TS820A1_2315A S_SLN_MemberCount_TS820A1_2315A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SLN_MemberCount_TS820A1_2315A {
    [XmlElement(Order=0)]
    public string D_SLN01_LineItemControlNumber {get; set;}
    [XmlElement(Order=1)]
    public string D_SLN02 {get; set;}
    [XmlElement(Order=2)]
    public string D_SLN03_InformationOnlyIndicator {get; set;}
    [XmlElement(Order=3)]
    public string D_SLN04_HeadCount {get; set;}
    [XmlElement(Order=4)]
    public C_SLN05_C001U759_TS820A1_2315A C_SLN05_C001U759_TS820A1_2315A {get; set;}
    [XmlElement(Order=5)]
    public string D_SLN06 {get; set;}
    [XmlElement(Order=6)]
    public string D_SLN07 {get; set;}
    [XmlElement(Order=7)]
    public string D_SLN08 {get; set;}
    [XmlElement(Order=8)]
    public string D_SLN09 {get; set;}
    [XmlElement(Order=9)]
    public string D_SLN10 {get; set;}
    [XmlElement(Order=10)]
    public string D_SLN11 {get; set;}
    [XmlElement(Order=11)]
    public string D_SLN12 {get; set;}
    [XmlElement(Order=12)]
    public string D_SLN13 {get; set;}
    [XmlElement(Order=13)]
    public string D_SLN14 {get; set;}
    [XmlElement(Order=14)]
    public string D_SLN15 {get; set;}
    [XmlElement(Order=15)]
    public string D_SLN16 {get; set;}
    [XmlElement(Order=16)]
    public string D_SLN17 {get; set;}
    [XmlElement(Order=17)]
    public string D_SLN18 {get; set;}
    [XmlElement(Order=18)]
    public string D_SLN19 {get; set;}
    [XmlElement(Order=19)]
    public string D_SLN20 {get; set;}
    [XmlElement(Order=20)]
    public string D_SLN21 {get; set;}
    [XmlElement(Order=21)]
    public string D_SLN22 {get; set;}
    [XmlElement(Order=22)]
    public string D_SLN23 {get; set;}
    [XmlElement(Order=23)]
    public string D_SLN24 {get; set;}
    [XmlElement(Order=24)]
    public string D_SLN25 {get; set;}
    [XmlElement(Order=25)]
    public string D_SLN26 {get; set;}
    [XmlElement(Order=26)]
    public string D_SLN27 {get; set;}
    [XmlElement(Order=27)]
    public string D_SLN28 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SLN05_C001U759_TS820A1_2315A {
    [XmlElement(Order=0)]
    public string D_SLN05_C00101U760_UnitOrBasisForMeasurementCode {get; set;}
    [XmlElement(Order=1)]
    public string D_SLN05_C00102U5768 {get; set;}
    [XmlElement(Order=2)]
    public string D_SLN05_C00103U5769 {get; set;}
    [XmlElement(Order=3)]
    public string D_SLN05_C00104U5770 {get; set;}
    [XmlElement(Order=4)]
    public string D_SLN05_C00105U5771 {get; set;}
    [XmlElement(Order=5)]
    public string D_SLN05_C00106U5772 {get; set;}
    [XmlElement(Order=6)]
    public string D_SLN05_C00107U5773 {get; set;}
    [XmlElement(Order=7)]
    public string D_SLN05_C00108U5774 {get; set;}
    [XmlElement(Order=8)]
    public string D_SLN05_C00109U5775 {get; set;}
    [XmlElement(Order=9)]
    public string D_SLN05_C00110U5776 {get; set;}
    [XmlElement(Order=10)]
    public string D_SLN05_C00111U5777 {get; set;}
    [XmlElement(Order=11)]
    public string D_SLN05_C00112U5778 {get; set;}
    [XmlElement(Order=12)]
    public string D_SLN05_C00113U5779 {get; set;}
    [XmlElement(Order=13)]
    public string D_SLN05_C00114U5780 {get; set;}
    [XmlElement(Order=14)]
    public string D_SLN05_C00115U5781 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2320A {
    [XmlElement(Order=0)]
    public S_ADX_OrganizationSummaryRemittanceLevelAdjustment_TS820A1_2320A S_ADX_OrganizationSummaryRemittanceLevelAdjustment_TS820A1_2320A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ADX_OrganizationSummaryRemittanceLevelAdjustment_TS820A1_2320A {
    [XmlElement(Order=0)]
    public string D_ADX01_AdjustmentAmount {get; set;}
    [XmlElement(Order=1)]
    public S_ADX_OrganizationSummaryRemittanceLevelAdjustment_TS820A1_2320AD_ADX02_AdjustmentReasonCode D_ADX02_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_ADX03 {get; set;}
    [XmlElement(Order=3)]
    public string D_ADX04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_ADX_OrganizationSummaryRemittanceLevelAdjustment_TS820A1_2320AD_ADX02_AdjustmentReasonCode {
        [XmlEnum("20")]
        Item20,
        [XmlEnum("52")]
        Item52,
        [XmlEnum("53")]
        Item53,
        AA,
        H1,
        H6,
        IA,
        J3,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2000B {
    [XmlElement(Order=0)]
    public S_ENT_IndividualRemittance_TS820A1_2000B S_ENT_IndividualRemittance_TS820A1_2000B {get; set;}
    [XmlElement("G_TS820A1_2100B",Order=1)]
    public List<G_TS820A1_2100B> G_TS820A1_2100B {get; set;}
    [XmlElement("G_TS820A1_2300B",Order=2)]
    public List<G_TS820A1_2300B> G_TS820A1_2300B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ENT_IndividualRemittance_TS820A1_2000B {
    [XmlElement(Order=0)]
    public string D_ENT01_AssignedNumber {get; set;}
    [XmlElement(Order=1)]
    public S_ENT_IndividualRemittance_TS820A1_2000BD_ENT02_EntityIdentifierCode D_ENT02_EntityIdentifierCode {get; set;}
    [XmlElement(Order=2)]
    public string D_ENT03_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_ENT04_ReceiversIndividualIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_ENT05 {get; set;}
    [XmlElement(Order=5)]
    public string D_ENT06 {get; set;}
    [XmlElement(Order=6)]
    public string D_ENT07 {get; set;}
    [XmlElement(Order=7)]
    public string D_ENT08 {get; set;}
    [XmlElement(Order=8)]
    public string D_ENT09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_ENT_IndividualRemittance_TS820A1_2000BD_ENT02_EntityIdentifierCode {
        [XmlEnum("2J")]
        Item2J,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_IndividualName_TS820A1_2100B S_NM1_IndividualName_TS820A1_2100B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_IndividualName_TS820A1_2100B {
    [XmlElement(Order=0)]
    public S_NM1_IndividualName_TS820A1_2100BD_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_IndividualName_TS820A1_2100BD_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_IndividualName_TS820A1_2100BD_NM101_EntityIdentifierCode {
        EY,
        QE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_IndividualName_TS820A1_2100BD_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2300B {
    [XmlElement(Order=0)]
    public S_RMR_IndividualPremiumRemittanceDetail_TS820A1_2300B S_RMR_IndividualPremiumRemittanceDetail_TS820A1_2300B {get; set;}
    [XmlElement(Order=1)]
    public S_DTM_IndividualCoveragePeriod_TS820A1_2300B S_DTM_IndividualCoveragePeriod_TS820A1_2300B {get; set;}
    [XmlElement("G_TS820A1_2320B",Order=2)]
    public List<G_TS820A1_2320B> G_TS820A1_2320B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_RMR_IndividualPremiumRemittanceDetail_TS820A1_2300B {
    [XmlElement(Order=0)]
    public S_RMR_IndividualPremiumRemittanceDetail_TS820A1_2300BD_RMR01_ReferenceIdentificationQualifier D_RMR01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_RMR02_InsuranceRemittanceReferenceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_RMR03_PaymentActionCode {get; set;}
    [XmlElement(Order=3)]
    public string D_RMR04_DetailPremiumPaymentAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_RMR05_BilledPremiumAmount {get; set;}
    [XmlElement(Order=5)]
    public string D_RMR06 {get; set;}
    [XmlElement(Order=6)]
    public string D_RMR07 {get; set;}
    [XmlElement(Order=7)]
    public string D_RMR08 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_RMR_IndividualPremiumRemittanceDetail_TS820A1_2300BD_RMR01_ReferenceIdentificationQualifier {
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
    public class S_DTM_IndividualCoveragePeriod_TS820A1_2300B {
    [XmlElement(Order=0)]
    public S_DTM_IndividualCoveragePeriod_TS820A1_2300BD_DTM01_DateTimeQualifier D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02 {get; set;}
    [XmlElement(Order=2)]
    public string D_DTM03 {get; set;}
    [XmlElement(Order=3)]
    public string D_DTM04 {get; set;}
    [XmlElement(Order=4)]
    public string D_DTM05_DateTimePeriodFormatQualifier {get; set;}
    [XmlElement(Order=5)]
    public string D_DTM06_CoveragePeriod {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_DTM_IndividualCoveragePeriod_TS820A1_2300BD_DTM01_DateTimeQualifier {
        [XmlEnum("582")]
        Item582,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS820A1_2320B {
    [XmlElement(Order=0)]
    public S_ADX_IndividualPremiumAdjustment_TS820A1_2320B S_ADX_IndividualPremiumAdjustment_TS820A1_2320B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ADX_IndividualPremiumAdjustment_TS820A1_2320B {
    [XmlElement(Order=0)]
    public string D_ADX01_AdjustmentAmount {get; set;}
    [XmlElement(Order=1)]
    public S_ADX_IndividualPremiumAdjustment_TS820A1_2320BD_ADX02_AdjustmentReasonCode D_ADX02_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=2)]
    public string D_ADX03 {get; set;}
    [XmlElement(Order=3)]
    public string D_ADX04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_ADX_IndividualPremiumAdjustment_TS820A1_2320BD_ADX02_AdjustmentReasonCode {
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
    public class S_SE {
    [XmlElement(Order=0)]
    public string D_SE01 {get; set;}
    [XmlElement(Order=1)]
    public string D_SE02 {get; set;}
    }
}
