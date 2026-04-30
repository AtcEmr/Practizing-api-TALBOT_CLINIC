namespace EdiFabric.Rules.X12004010X091A1835 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_835 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_BPR_FinancialInformation_TS835W1 S_BPR_FinancialInformation_TS835W1 {get; set;}
    [XmlElement(Order=2)]
    public S_TRN_ReassociationTraceNumber_TS835W1 S_TRN_ReassociationTraceNumber_TS835W1 {get; set;}
    [XmlElement(Order=3)]
    public S_CUR_ForeignCurrencyInformation_TS835W1 S_CUR_ForeignCurrencyInformation_TS835W1 {get; set;}
    [XmlElement(Order=4)]
    public A_REF_TS835W1 A_REF_TS835W1 {get; set;}
    [XmlElement(Order=5)]
    public S_DTM_ProductionDate_TS835W1 S_DTM_ProductionDate_TS835W1 {get; set;}
    [XmlElement(Order=6)]
    public G_TS835W1_1000A G_TS835W1_1000A {get; set;}
    [XmlElement(Order=7)]
    public G_TS835W1_1000B G_TS835W1_1000B {get; set;}
    [XmlElement("G_TS835W1_2000",Order=8)]
    public List<G_TS835W1_2000> G_TS835W1_2000 {get; set;}
    [XmlElement("S_PLB_ProviderAdjustment_TS835W1",Order=9)]
    public List<S_PLB_ProviderAdjustment_TS835W1> S_PLB_ProviderAdjustment_TS835W1 {get; set;}
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
    public class S_BPR_FinancialInformation_TS835W1 {
    [XmlElement(Order=0)]
    public S_BPR_FinancialInformation_TS835W1D_BPR01_TransactionHandlingCode D_BPR01_TransactionHandlingCode {get; set;}
    [XmlElement(Order=1)]
    public string D_BPR02_TotalActualProviderPaymentAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_BPR03_CreditOrDebitFlagCode {get; set;}
    [XmlElement(Order=3)]
    public string D_BPR04_PaymentMethodCode {get; set;}
    [XmlElement(Order=4)]
    public string D_BPR05_PaymentFormatCode {get; set;}
    [XmlElement(Order=5)]
    public string D_BPR06_DepositoryFinancialInstitutionDFIIdentificationNumberQualifier {get; set;}
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
    public string D_BPR12_DepositoryFinancialInstitutionDFIIdentificationNumberQualifier {get; set;}
    [XmlElement(Order=12)]
    public string D_BPR13_ReceiverOrProviderBankIDNumber {get; set;}
    [XmlElement(Order=13)]
    public string D_BPR14_AccountNumberQualifier {get; set;}
    [XmlElement(Order=14)]
    public string D_BPR15_ReceiverOrProviderAccountNumber {get; set;}
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
    public enum S_BPR_FinancialInformation_TS835W1D_BPR01_TransactionHandlingCode {
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
    public class S_TRN_ReassociationTraceNumber_TS835W1 {
    [XmlElement(Order=0)]
    public S_TRN_ReassociationTraceNumber_TS835W1D_TRN01_TraceTypeCode D_TRN01_TraceTypeCode {get; set;}
    [XmlElement(Order=1)]
    public string D_TRN02_CheckOrEFTTraceNumber {get; set;}
    [XmlElement(Order=2)]
    public string D_TRN03_PayerIdentifier {get; set;}
    [XmlElement(Order=3)]
    public string D_TRN04_OriginatingCompanySupplementalCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_TRN_ReassociationTraceNumber_TS835W1D_TRN01_TraceTypeCode {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CUR_ForeignCurrencyInformation_TS835W1 {
    [XmlElement(Order=0)]
    public S_CUR_ForeignCurrencyInformation_TS835W1D_CUR01_EntityIdentifierCode D_CUR01_EntityIdentifierCode {get; set;}
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
    public enum S_CUR_ForeignCurrencyInformation_TS835W1D_CUR01_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS835W1 {
    [XmlElementAttribute(Order=0)]
    public S_REF_ReceiverIdentification_TS835W1 S_REF_ReceiverIdentification_TS835W1 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_REF_VersionIdentification_TS835W1 S_REF_VersionIdentification_TS835W1 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ReceiverIdentification_TS835W1 {
    [XmlElement(Order=0)]
    public S_REF_ReceiverIdentification_TS835W1D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ReceiverIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U782 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ReceiverIdentification_TS835W1D_REF01_ReferenceIdentificationQualifier {
        EV,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_VersionIdentification_TS835W1 {
    [XmlElement(Order=0)]
    public S_REF_VersionIdentification_TS835W1D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_VersionIdentificationCode {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U783 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_VersionIdentification_TS835W1D_REF01_ReferenceIdentificationQualifier {
        F2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_ProductionDate_TS835W1 {
    [XmlElement(Order=0)]
    public S_DTM_ProductionDate_TS835W1D_DTM01_DateTimeQualifier D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_ProductionDate {get; set;}
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
    public enum S_DTM_ProductionDate_TS835W1D_DTM01_DateTimeQualifier {
        [XmlEnum("405")]
        Item405,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS835W1_1000A {
    [XmlElement(Order=0)]
    public S_N1_PayerIdentification_TS835W1_1000A S_N1_PayerIdentification_TS835W1_1000A {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayerAddress_TS835W1_1000A S_N3_PayerAddress_TS835W1_1000A {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayerCityStateZIPCode_TS835W1_1000A S_N4_PayerCityStateZIPCode_TS835W1_1000A {get; set;}
    [XmlElement("S_REF_AdditionalPayerIdentification_TS835W1_1000A",Order=3)]
    public List<S_REF_AdditionalPayerIdentification_TS835W1_1000A> S_REF_AdditionalPayerIdentification_TS835W1_1000A {get; set;}
    [XmlElement(Order=4)]
    public S_PER_PayerContactInformation_TS835W1_1000A S_PER_PayerContactInformation_TS835W1_1000A {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_PayerIdentification_TS835W1_1000A {
    [XmlElement(Order=0)]
    public S_N1_PayerIdentification_TS835W1_1000AD_N101_EntityIdentifierCode D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PayerName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_PayerIdentifier {get; set;}
    [XmlElement(Order=4)]
    public string D_N105 {get; set;}
    [XmlElement(Order=5)]
    public string D_N106 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_N1_PayerIdentification_TS835W1_1000AD_N101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PayerAddress_TS835W1_1000A {
    [XmlElement(Order=0)]
    public string D_N301_PayerAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PayerAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PayerCityStateZIPCode_TS835W1_1000A {
    [XmlElement(Order=0)]
    public string D_N401_PayerCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PayerStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PayerPostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404 {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_AdditionalPayerIdentification_TS835W1_1000A {
    [XmlElement(Order=0)]
    public S_REF_AdditionalPayerIdentification_TS835W1_1000AD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdditionalPayerIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U784 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_AdditionalPayerIdentification_TS835W1_1000AD_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("2U")]
        Item2U,
        EO,
        HI,
        NF,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_PayerContactInformation_TS835W1_1000A {
    [XmlElement(Order=0)]
    public S_PER_PayerContactInformation_TS835W1_1000AD_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_PayerContactInformation_TS835W1_1000AD_PER01_ContactFunctionCode {
        CX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS835W1_1000B {
    [XmlElement(Order=0)]
    public S_N1_PayeeIdentification_TS835W1_1000B S_N1_PayeeIdentification_TS835W1_1000B {get; set;}
    [XmlElement(Order=1)]
    public S_N3_PayeeAddress_TS835W1_1000B S_N3_PayeeAddress_TS835W1_1000B {get; set;}
    [XmlElement(Order=2)]
    public S_N4_PayeeCityStateZIPCode_TS835W1_1000B S_N4_PayeeCityStateZIPCode_TS835W1_1000B {get; set;}
    [XmlElement("S_REF_PayeeAdditionalIdentification_TS835W1_1000B",Order=3)]
    public List<S_REF_PayeeAdditionalIdentification_TS835W1_1000B> S_REF_PayeeAdditionalIdentification_TS835W1_1000B {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N1_PayeeIdentification_TS835W1_1000B {
    [XmlElement(Order=0)]
    public S_N1_PayeeIdentification_TS835W1_1000BD_N101_EntityIdentifierCode D_N101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_N102_PayeeName {get; set;}
    [XmlElement(Order=2)]
    public string D_N103_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=3)]
    public string D_N104_PayeeIdentificationCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N105 {get; set;}
    [XmlElement(Order=5)]
    public string D_N106 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_N1_PayeeIdentification_TS835W1_1000BD_N101_EntityIdentifierCode {
        PE,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N3_PayeeAddress_TS835W1_1000B {
    [XmlElement(Order=0)]
    public string D_N301_PayeeAddressLine {get; set;}
    [XmlElement(Order=1)]
    public string D_N302_PayeeAddressLine {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_N4_PayeeCityStateZIPCode_TS835W1_1000B {
    [XmlElement(Order=0)]
    public string D_N401_PayeeCityName {get; set;}
    [XmlElement(Order=1)]
    public string D_N402_PayeeStateCode {get; set;}
    [XmlElement(Order=2)]
    public string D_N403_PayeePostalZoneOrZIPCode {get; set;}
    [XmlElement(Order=3)]
    public string D_N404_CountryCode {get; set;}
    [XmlElement(Order=4)]
    public string D_N405 {get; set;}
    [XmlElement(Order=5)]
    public string D_N406 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_PayeeAdditionalIdentification_TS835W1_1000B {
    [XmlElement(Order=0)]
    public S_REF_PayeeAdditionalIdentification_TS835W1_1000BD_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_AdditionalPayeeIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U785 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_PayeeAdditionalIdentification_TS835W1_1000BD_REF01_ReferenceIdentificationQualifier {
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
        [XmlEnum("1E")]
        Item1E,
        [XmlEnum("1F")]
        Item1F,
        [XmlEnum("1G")]
        Item1G,
        [XmlEnum("1H")]
        Item1H,
        D3,
        G2,
        N5,
        PQ,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS835W1_2000 {
    [XmlElement(Order=0)]
    public S_LX_HeaderNumber_TS835W1_2000 S_LX_HeaderNumber_TS835W1_2000 {get; set;}
    [XmlElement(Order=1)]
    public S_TS3_ProviderSummaryInformation_TS835W1_2000 S_TS3_ProviderSummaryInformation_TS835W1_2000 {get; set;}
    [XmlElement(Order=2)]
    public S_TS2_ProviderSupplementalSummaryInformation_TS835W1_2000 S_TS2_ProviderSupplementalSummaryInformation_TS835W1_2000 {get; set;}
    [XmlElement("G_TS835W1_2100",Order=3)]
    public List<G_TS835W1_2100> G_TS835W1_2100 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LX_HeaderNumber_TS835W1_2000 {
    [XmlElement(Order=0)]
    public string D_LX01_AssignedNumber {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_TS3_ProviderSummaryInformation_TS835W1_2000 {
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
    public string D_TS306_TotalCoveredChargeAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_TS307_TotalNoncoveredChargeAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_TS308_TotalDeniedChargeAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_TS309_TotalProviderPaymentAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_TS310_TotalInterestAmount {get; set;}
    [XmlElement(Order=10)]
    public string D_TS311_TotalContractualAdjustmentAmount {get; set;}
    [XmlElement(Order=11)]
    public string D_TS312_TotalGrammRudmanReductionAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_TS313_TotalMSPPayerAmount {get; set;}
    [XmlElement(Order=13)]
    public string D_TS314_TotalBloodDeductibleAmount {get; set;}
    [XmlElement(Order=14)]
    public string D_TS315_TotalNonLabChargeAmount {get; set;}
    [XmlElement(Order=15)]
    public string D_TS316_TotalCoinsuranceAmount {get; set;}
    [XmlElement(Order=16)]
    public string D_TS317_TotalHCPCSReportedChargeAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_TS318_TotalHCPCSPayableAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_TS319_TotalDeductibleAmount {get; set;}
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
    public class S_TS2_ProviderSupplementalSummaryInformation_TS835W1_2000 {
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
    public string D_TS210_AverageDRGLengthOfStay {get; set;}
    [XmlElement(Order=10)]
    public string D_TS211_TotalDischargeCount {get; set;}
    [XmlElement(Order=11)]
    public string D_TS212_TotalCostReportDayCount {get; set;}
    [XmlElement(Order=12)]
    public string D_TS213_TotalCoveredDayCount {get; set;}
    [XmlElement(Order=13)]
    public string D_TS214_TotalNoncoveredDayCount {get; set;}
    [XmlElement(Order=14)]
    public string D_TS215_TotalMSPPassThroughAmount {get; set;}
    [XmlElement(Order=15)]
    public string D_TS216_AverageDRGWeight {get; set;}
    [XmlElement(Order=16)]
    public string D_TS217_TotalPPSCapitalFSPDRGAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_TS218_TotalPPSCapitalHSPDRGAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_TS219_TotalPPSDSHDRGAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_CLP_ClaimPaymentInformation_TS835W1_2100 S_CLP_ClaimPaymentInformation_TS835W1_2100 {get; set;}
    [XmlElement("S_CAS_ClaimAdjustment_TS835W1_2100",Order=1)]
    public List<S_CAS_ClaimAdjustment_TS835W1_2100> S_CAS_ClaimAdjustment_TS835W1_2100 {get; set;}
    [XmlElement(Order=2)]
    public A_NM1_TS835W1_2100 A_NM1_TS835W1_2100 {get; set;}
    [XmlElement(Order=3)]
    public S_MIA_InpatientAdjudicationInformation_TS835W1_2100 S_MIA_InpatientAdjudicationInformation_TS835W1_2100 {get; set;}
    [XmlElement(Order=4)]
    public S_MOA_OutpatientAdjudicationInformation_TS835W1_2100 S_MOA_OutpatientAdjudicationInformation_TS835W1_2100 {get; set;}
    [XmlElement(Order=5)]
    public A_REF_TS835W1_2100 A_REF_TS835W1_2100 {get; set;}
    [XmlElement("S_DTM_ClaimDate_TS835W1_2100",Order=6)]
    public List<S_DTM_ClaimDate_TS835W1_2100> S_DTM_ClaimDate_TS835W1_2100 {get; set;}
    [XmlElement("S_PER_ClaimContactInformation_TS835W1_2100",Order=7)]
    public List<S_PER_ClaimContactInformation_TS835W1_2100> S_PER_ClaimContactInformation_TS835W1_2100 {get; set;}
    [XmlElement("S_AMT_ClaimSupplementalInformation_TS835W1_2100",Order=8)]
    public List<S_AMT_ClaimSupplementalInformation_TS835W1_2100> S_AMT_ClaimSupplementalInformation_TS835W1_2100 {get; set;}
    [XmlElement("S_QTY_ClaimSupplementalInformationQuantity_TS835W1_2100",Order=9)]
    public List<S_QTY_ClaimSupplementalInformationQuantity_TS835W1_2100> S_QTY_ClaimSupplementalInformationQuantity_TS835W1_2100 {get; set;}
    [XmlElement("G_TS835W1_2110",Order=10)]
    public List<G_TS835W1_2110> G_TS835W1_2110 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CLP_ClaimPaymentInformation_TS835W1_2100 {
    [XmlElement(Order=0)]
    public string D_CLP01_PatientControlNumber {get; set;}
    [XmlElement(Order=1)]
    public S_CLP_ClaimPaymentInformation_TS835W1_2100D_CLP02_ClaimStatusCode D_CLP02_ClaimStatusCode {get; set;}
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
    public string D_CLP10 {get; set;}
    [XmlElement(Order=10)]
    public string D_CLP11_DiagnosisRelatedGroupDRGCode {get; set;}
    [XmlElement(Order=11)]
    public string D_CLP12_DiagnosisRelatedGroupDRGWeight {get; set;}
    [XmlElement(Order=12)]
    public string D_CLP13_DischargeFraction {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_CLP_ClaimPaymentInformation_TS835W1_2100D_CLP02_ClaimStatusCode {
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
        [XmlEnum("10")]
        Item10,
        [XmlEnum("13")]
        Item13,
        [XmlEnum("15")]
        Item15,
        [XmlEnum("16")]
        Item16,
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
        [XmlEnum("25")]
        Item25,
        [XmlEnum("27")]
        Item27,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ClaimAdjustment_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_CAS_ClaimAdjustment_TS835W1_2100D_CAS01_ClaimAdjustmentGroupCode D_CAS01_ClaimAdjustmentGroupCode {get; set;}
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
    public enum S_CAS_ClaimAdjustment_TS835W1_2100D_CAS01_ClaimAdjustmentGroupCode {
        CO,
        CR,
        OA,
        PI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_NM1_TS835W1_2100 {
    [XmlElementAttribute(Order=0)]
    public S_NM1_PatientName_TS835W1_2100 S_NM1_PatientName_TS835W1_2100 {get; set;}
    [XmlElementAttribute(Order=1)]
    public S_NM1_InsuredName_TS835W1_2100 S_NM1_InsuredName_TS835W1_2100 {get; set;}
    [XmlElementAttribute(Order=2)]
    public S_NM1_CorrectedPatientInsuredName_TS835W1_2100 S_NM1_CorrectedPatientInsuredName_TS835W1_2100 {get; set;}
    [XmlElementAttribute(Order=3)]
    public S_NM1_ServiceProviderName_TS835W1_2100 S_NM1_ServiceProviderName_TS835W1_2100 {get; set;}
    [XmlElementAttribute(Order=4)]
    public S_NM1_CrossoverCarrierName_TS835W1_2100 S_NM1_CrossoverCarrierName_TS835W1_2100 {get; set;}
    [XmlElement(Order=5)]
    public U_NM1_CorrectedPriorityPayerName_TS835W1_2100 U_NM1_CorrectedPriorityPayerName_TS835W1_2100 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_PatientName_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_NM1_PatientName_TS835W1_2100D_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_PatientName_TS835W1_2100D_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_PatientLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_PatientFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_PatientMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_PatientNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_PatientIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PatientName_TS835W1_2100D_NM101_EntityIdentifierCode {
        QC,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_PatientName_TS835W1_2100D_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_InsuredName_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_NM1_InsuredName_TS835W1_2100D_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_InsuredName_TS835W1_2100D_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
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
    public string D_NM109_SubscriberIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_InsuredName_TS835W1_2100D_NM101_EntityIdentifierCode {
        IL,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_InsuredName_TS835W1_2100D_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CorrectedPatientInsuredName_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_NM1_CorrectedPatientInsuredName_TS835W1_2100D_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_CorrectedPatientInsuredName_TS835W1_2100D_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CorrectedPatientOrInsuredLastName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_CorrectedPatientOrInsuredFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_CorrectedPatientOrInsuredMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_CorrectedPatientOrInsuredNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_CorrectedInsuredIdentificationIndicator {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CorrectedPatientInsuredName_TS835W1_2100D_NM101_EntityIdentifierCode {
        [XmlEnum("74")]
        Item74,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CorrectedPatientInsuredName_TS835W1_2100D_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_ServiceProviderName_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_NM1_ServiceProviderName_TS835W1_2100D_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_ServiceProviderName_TS835W1_2100D_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_RenderingProviderLastOrOrganizationName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104_RenderingProviderFirstName {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105_RenderingProviderMiddleName {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107_RenderingProviderNameSuffix {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceProviderName_TS835W1_2100D_NM101_EntityIdentifierCode {
        [XmlEnum("82")]
        Item82,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_ServiceProviderName_TS835W1_2100D_NM102_EntityTypeQualifier {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CrossoverCarrierName_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_NM1_CrossoverCarrierName_TS835W1_2100D_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_CrossoverCarrierName_TS835W1_2100D_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CoordinationOfBenefitsCarrierName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_CoordinationOfBenefitsCarrierIdentifier {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CrossoverCarrierName_TS835W1_2100D_NM101_EntityIdentifierCode {
        TT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CrossoverCarrierName_TS835W1_2100D_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_NM1_CorrectedPriorityPayerName_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_NM1_CorrectedPriorityPayerName_TS835W1_2100D_NM101_EntityIdentifierCode D_NM101_EntityIdentifierCode {get; set;}
    [XmlElement(Order=1)]
    public S_NM1_CorrectedPriorityPayerName_TS835W1_2100D_NM102_EntityTypeQualifier D_NM102_EntityTypeQualifier {get; set;}
    [XmlElement(Order=2)]
    public string D_NM103_CorrectedPriorityPayerName {get; set;}
    [XmlElement(Order=3)]
    public string D_NM104 {get; set;}
    [XmlElement(Order=4)]
    public string D_NM105 {get; set;}
    [XmlElement(Order=5)]
    public string D_NM106 {get; set;}
    [XmlElement(Order=6)]
    public string D_NM107 {get; set;}
    [XmlElement(Order=7)]
    public string D_NM108_IdentificationCodeQualifier {get; set;}
    [XmlElement(Order=8)]
    public string D_NM109_CorrectedPriorityPayerIdentificationNumber {get; set;}
    [XmlElement(Order=9)]
    public string D_NM110 {get; set;}
    [XmlElement(Order=10)]
    public string D_NM111 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CorrectedPriorityPayerName_TS835W1_2100D_NM101_EntityIdentifierCode {
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_NM1_CorrectedPriorityPayerName_TS835W1_2100D_NM102_EntityTypeQualifier {
        [XmlEnum("2")]
        Item2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MIA_InpatientAdjudicationInformation_TS835W1_2100 {
    [XmlElement(Order=0)]
    public string D_MIA01_CoveredDaysOrVisitsCount {get; set;}
    [XmlElement(Order=1)]
    public string D_MIA02_PPSOperatingOutlierAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MIA03_LifetimePsychiatricDaysCount {get; set;}
    [XmlElement(Order=3)]
    public string D_MIA04_ClaimDRGAmount {get; set;}
    [XmlElement(Order=4)]
    public string D_MIA05_RemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MIA06_ClaimDisproportionateShareAmount {get; set;}
    [XmlElement(Order=6)]
    public string D_MIA07_ClaimMSPPassthroughAmount {get; set;}
    [XmlElement(Order=7)]
    public string D_MIA08_ClaimPPSCapitalAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MIA09_PPSCapitalFSPDRGAmount {get; set;}
    [XmlElement(Order=9)]
    public string D_MIA10_PPSCapitalHSPDRGAmount {get; set;}
    [XmlElement(Order=10)]
    public string D_MIA11_PPSCapitalDSHDRGAmount {get; set;}
    [XmlElement(Order=11)]
    public string D_MIA12_OldCapitalAmount {get; set;}
    [XmlElement(Order=12)]
    public string D_MIA13_PPSCapitalIMEAmount {get; set;}
    [XmlElement(Order=13)]
    public string D_MIA14_PPSOperatingHospitalSpecificDRGAmount {get; set;}
    [XmlElement(Order=14)]
    public string D_MIA15_CostReportDayCount {get; set;}
    [XmlElement(Order=15)]
    public string D_MIA16_PPSOperatingFederalSpecificDRGAmount {get; set;}
    [XmlElement(Order=16)]
    public string D_MIA17_ClaimPPSCapitalOutlierAmount {get; set;}
    [XmlElement(Order=17)]
    public string D_MIA18_ClaimIndirectTeachingAmount {get; set;}
    [XmlElement(Order=18)]
    public string D_MIA19_NonpayableProfessionalComponentAmount {get; set;}
    [XmlElement(Order=19)]
    public string D_MIA20_RemarkCode {get; set;}
    [XmlElement(Order=20)]
    public string D_MIA21_RemarkCode {get; set;}
    [XmlElement(Order=21)]
    public string D_MIA22_RemarkCode {get; set;}
    [XmlElement(Order=22)]
    public string D_MIA23_RemarkCode {get; set;}
    [XmlElement(Order=23)]
    public string D_MIA24_PPSCapitalExceptionAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_MOA_OutpatientAdjudicationInformation_TS835W1_2100 {
    [XmlElement(Order=0)]
    public string D_MOA01_ReimbursementRate {get; set;}
    [XmlElement(Order=1)]
    public string D_MOA02_ClaimHCPCSPayableAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_MOA03_RemarkCode {get; set;}
    [XmlElement(Order=3)]
    public string D_MOA04_RemarkCode {get; set;}
    [XmlElement(Order=4)]
    public string D_MOA05_RemarkCode {get; set;}
    [XmlElement(Order=5)]
    public string D_MOA06_RemarkCode {get; set;}
    [XmlElement(Order=6)]
    public string D_MOA07_RemarkCode {get; set;}
    [XmlElement(Order=7)]
    public string D_MOA08_ClaimESRDPaymentAmount {get; set;}
    [XmlElement(Order=8)]
    public string D_MOA09_NonpayableProfessionalComponentAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS835W1_2100 {
    [XmlElement(Order=0)]
    public U_REF_OtherClaimRelatedIdentification_TS835W1_2100 U_REF_OtherClaimRelatedIdentification_TS835W1_2100 {get; set;}
    [XmlElement(Order=1)]
    public U_REF_RenderingProviderIdentification_TS835W1_2100 U_REF_RenderingProviderIdentification_TS835W1_2100 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_OtherClaimRelatedIdentification_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_REF_OtherClaimRelatedIdentification_TS835W1_2100D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_OtherClaimRelatedIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U786 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_OtherClaimRelatedIdentification_TS835W1_2100D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1L")]
        Item1L,
        [XmlEnum("1W")]
        Item1W,
        [XmlEnum("9A")]
        Item9A,
        [XmlEnum("9C")]
        Item9C,
        A6,
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
    public class S_REF_RenderingProviderIdentification_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_REF_RenderingProviderIdentification_TS835W1_2100D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderSecondaryIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U787 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_RenderingProviderIdentification_TS835W1_2100D_REF01_ReferenceIdentificationQualifier {
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
        D3,
        G2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_ClaimDate_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_DTM_ClaimDate_TS835W1_2100D_DTM01_DateTimeQualifier D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_ClaimDate {get; set;}
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
    public enum S_DTM_ClaimDate_TS835W1_2100D_DTM01_DateTimeQualifier {
        [XmlEnum("036")]
        Item036,
        [XmlEnum("050")]
        Item050,
        [XmlEnum("232")]
        Item232,
        [XmlEnum("233")]
        Item233,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PER_ClaimContactInformation_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_PER_ClaimContactInformation_TS835W1_2100D_PER01_ContactFunctionCode D_PER01_ContactFunctionCode {get; set;}
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
    public string D_PER09 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_PER_ClaimContactInformation_TS835W1_2100D_PER01_ContactFunctionCode {
        CX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ClaimSupplementalInformation_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_AMT_ClaimSupplementalInformation_TS835W1_2100D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ClaimSupplementalInformationAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_ClaimSupplementalInformation_TS835W1_2100D_AMT01_AmountQualifierCode {
        AU,
        D8,
        DY,
        F5,
        I,
        NL,
        T,
        ZK,
        ZL,
        ZM,
        ZN,
        ZO,
        ZZ,
        T2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_ClaimSupplementalInformationQuantity_TS835W1_2100 {
    [XmlElement(Order=0)]
    public S_QTY_ClaimSupplementalInformationQuantity_TS835W1_2100D_QTY01_QuantityQualifier D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_ClaimSupplementalInformationQuantity {get; set;}
    [XmlElement(Order=2)]
    public string D_QTY03_C001U788 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_QTY_ClaimSupplementalInformationQuantity_TS835W1_2100D_QTY01_QuantityQualifier {
        CA,
        CD,
        LA,
        LE,
        NA,
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
    public class G_TS835W1_2110 {
    [XmlElement(Order=0)]
    public S_SVC_ServicePaymentInformation_TS835W1_2110 S_SVC_ServicePaymentInformation_TS835W1_2110 {get; set;}
    [XmlElement("S_DTM_ServiceDate_TS835W1_2110",Order=1)]
    public List<S_DTM_ServiceDate_TS835W1_2110> S_DTM_ServiceDate_TS835W1_2110 {get; set;}
    [XmlElement("S_CAS_ServiceAdjustment_TS835W1_2110",Order=2)]
    public List<S_CAS_ServiceAdjustment_TS835W1_2110> S_CAS_ServiceAdjustment_TS835W1_2110 {get; set;}
    [XmlElement(Order=3)]
    public A_REF_TS835W1_2110 A_REF_TS835W1_2110 {get; set;}
    [XmlElement("S_AMT_ServiceSupplementalAmount_TS835W1_2110",Order=4)]
    public List<S_AMT_ServiceSupplementalAmount_TS835W1_2110> S_AMT_ServiceSupplementalAmount_TS835W1_2110 {get; set;}
    [XmlElement("S_QTY_ServiceSupplementalQuantity_TS835W1_2110",Order=5)]
    public List<S_QTY_ServiceSupplementalQuantity_TS835W1_2110> S_QTY_ServiceSupplementalQuantity_TS835W1_2110 {get; set;}
    [XmlElement("S_LQ_HealthCareRemarkCodes_TS835W1_2110",Order=6)]
    public List<S_LQ_HealthCareRemarkCodes_TS835W1_2110> S_LQ_HealthCareRemarkCodes_TS835W1_2110 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SVC_ServicePaymentInformation_TS835W1_2110 {
    [XmlElement(Order=0)]
    public C_SVC01_C003U789_TS835W1_2110 C_SVC01_C003U789_TS835W1_2110 {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC02_LineItemChargeAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC03_LineItemProviderPaymentAmount {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC04_NationalUniformBillingCommitteeRevenueCode {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC05_UnitsOfServicePaidCount {get; set;}
    [XmlElement(Order=5)]
    public C_SVC06_C003U797_TS835W1_2110 C_SVC06_C003U797_TS835W1_2110 {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC07_OriginalUnitsOfServiceCount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SVC01_C003U789_TS835W1_2110 {
    [XmlElement(Order=0)]
    public C_SVC01_C003U789_TS835W1_2110D_SVC01_C00301U790_ProductOrServiceIDQualifier D_SVC01_C00301U790_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC01_C00302U791_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC01_C00303U792_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC01_C00304U793_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC01_C00305U794_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_SVC01_C00306U795_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC01_C00307U796_ProcedureCodeDescription {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum C_SVC01_C003U789_TS835W1_2110D_SVC01_C00301U790_ProductOrServiceIDQualifier {
        AD,
        ER,
        HC,
        ID,
        IV,
        N4,
        NU,
        RB,
        ZZ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_SVC06_C003U797_TS835W1_2110 {
    [XmlElement(Order=0)]
    public string D_SVC06_C00301U798_ProductOrServiceIDQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_SVC06_C00302U799_ProcedureCode {get; set;}
    [XmlElement(Order=2)]
    public string D_SVC06_C00303U800_ProcedureModifier {get; set;}
    [XmlElement(Order=3)]
    public string D_SVC06_C00304U801_ProcedureModifier {get; set;}
    [XmlElement(Order=4)]
    public string D_SVC06_C00305U802_ProcedureModifier {get; set;}
    [XmlElement(Order=5)]
    public string D_SVC06_C00306U803_ProcedureModifier {get; set;}
    [XmlElement(Order=6)]
    public string D_SVC06_C00307U804_ProcedureCodeDescription {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_DTM_ServiceDate_TS835W1_2110 {
    [XmlElement(Order=0)]
    public S_DTM_ServiceDate_TS835W1_2110D_DTM01_DateTimeQualifier D_DTM01_DateTimeQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_DTM02_ServiceDate {get; set;}
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
    public enum S_DTM_ServiceDate_TS835W1_2110D_DTM01_DateTimeQualifier {
        [XmlEnum("150")]
        Item150,
        [XmlEnum("151")]
        Item151,
        [XmlEnum("472")]
        Item472,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CAS_ServiceAdjustment_TS835W1_2110 {
    [XmlElement(Order=0)]
    public S_CAS_ServiceAdjustment_TS835W1_2110D_CAS01_ClaimAdjustmentGroupCode D_CAS01_ClaimAdjustmentGroupCode {get; set;}
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
    public enum S_CAS_ServiceAdjustment_TS835W1_2110D_CAS01_ClaimAdjustmentGroupCode {
        CO,
        CR,
        OA,
        PI,
        PR,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class A_REF_TS835W1_2110 {
    [XmlElement(Order=0)]
    public U_REF_ServiceIdentification_TS835W1_2110 U_REF_ServiceIdentification_TS835W1_2110 {get; set;}
    [XmlElement(Order=1)]
    public U_REF_RenderingProviderInformation_TS835W1_2110 U_REF_RenderingProviderInformation_TS835W1_2110 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_ServiceIdentification_TS835W1_2110 {
    [XmlElement(Order=0)]
    public S_REF_ServiceIdentification_TS835W1_2110D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_ProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U805 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_ServiceIdentification_TS835W1_2110D_REF01_ReferenceIdentificationQualifier {
        [XmlEnum("1S")]
        Item1S,
        [XmlEnum("6R")]
        Item6R,
        BB,
        E9,
        G1,
        G3,
        LU,
        RB,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_REF_RenderingProviderInformation_TS835W1_2110 {
    [XmlElement(Order=0)]
    public S_REF_RenderingProviderInformation_TS835W1_2110D_REF01_ReferenceIdentificationQualifier D_REF01_ReferenceIdentificationQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_REF02_RenderingProviderIdentifier {get; set;}
    [XmlElement(Order=2)]
    public string D_REF03 {get; set;}
    [XmlElement(Order=3)]
    public string D_REF04_C040U806 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_REF_RenderingProviderInformation_TS835W1_2110D_REF01_ReferenceIdentificationQualifier {
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
        HPI,
        SY,
        TJ,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AMT_ServiceSupplementalAmount_TS835W1_2110 {
    [XmlElement(Order=0)]
    public S_AMT_ServiceSupplementalAmount_TS835W1_2110D_AMT01_AmountQualifierCode D_AMT01_AmountQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_AMT02_ServiceSupplementalAmount {get; set;}
    [XmlElement(Order=2)]
    public string D_AMT03 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_AMT_ServiceSupplementalAmount_TS835W1_2110D_AMT01_AmountQualifierCode {
        B6,
        DY,
        KH,
        NE,
        T,
        ZK,
        ZL,
        ZM,
        ZN,
        ZO,
        T2,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_QTY_ServiceSupplementalQuantity_TS835W1_2110 {
    [XmlElement(Order=0)]
    public S_QTY_ServiceSupplementalQuantity_TS835W1_2110D_QTY01_QuantityQualifier D_QTY01_QuantityQualifier {get; set;}
    [XmlElement(Order=1)]
    public string D_QTY02_ServiceSupplementalQuantityCount {get; set;}
    [XmlElement(Order=2)]
    public string D_QTY03_C001U807 {get; set;}
    [XmlElement(Order=3)]
    public string D_QTY04 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_QTY_ServiceSupplementalQuantity_TS835W1_2110D_QTY01_QuantityQualifier {
        NE,
        ZK,
        ZL,
        ZM,
        ZN,
        ZO,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_LQ_HealthCareRemarkCodes_TS835W1_2110 {
    [XmlElement(Order=0)]
    public S_LQ_HealthCareRemarkCodes_TS835W1_2110D_LQ01_CodeListQualifierCode D_LQ01_CodeListQualifierCode {get; set;}
    [XmlElement(Order=1)]
    public string D_LQ02_RemarkCode {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    public enum S_LQ_HealthCareRemarkCodes_TS835W1_2110D_LQ01_CodeListQualifierCode {
        HE,
        RX,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_PLB_ProviderAdjustment_TS835W1 {
    [XmlElement(Order=0)]
    public string D_PLB01_ProviderIdentifier {get; set;}
    [XmlElement(Order=1)]
    public string D_PLB02_FiscalPeriodDate {get; set;}
    [XmlElement(Order=2)]
    public C_PLB03_C042U808_TS835W1 C_PLB03_C042U808_TS835W1 {get; set;}
    [XmlElement(Order=3)]
    public string D_PLB04_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=4)]
    public C_PLB05_C042U811_TS835W1 C_PLB05_C042U811_TS835W1 {get; set;}
    [XmlElement(Order=5)]
    public string D_PLB06_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=6)]
    public C_PLB07_C042U814_TS835W1 C_PLB07_C042U814_TS835W1 {get; set;}
    [XmlElement(Order=7)]
    public string D_PLB08_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=8)]
    public C_PLB09_C042U817_TS835W1 C_PLB09_C042U817_TS835W1 {get; set;}
    [XmlElement(Order=9)]
    public string D_PLB10_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=10)]
    public C_PLB11_C042U820_TS835W1 C_PLB11_C042U820_TS835W1 {get; set;}
    [XmlElement(Order=11)]
    public string D_PLB12_ProviderAdjustmentAmount {get; set;}
    [XmlElement(Order=12)]
    public C_PLB13_C042U823_TS835W1 C_PLB13_C042U823_TS835W1 {get; set;}
    [XmlElement(Order=13)]
    public string D_PLB14_ProviderAdjustmentAmount {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_PLB03_C042U808_TS835W1 {
    [XmlElement(Order=0)]
    public string D_PLB03_C04201U809_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PLB03_C04202U810_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_PLB05_C042U811_TS835W1 {
    [XmlElement(Order=0)]
    public string D_PLB05_C04201U812_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PLB05_C04202U813_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_PLB07_C042U814_TS835W1 {
    [XmlElement(Order=0)]
    public string D_PLB07_C04201U815_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PLB07_C04202U816_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_PLB09_C042U817_TS835W1 {
    [XmlElement(Order=0)]
    public string D_PLB09_C04201U818_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PLB09_C04202U819_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_PLB11_C042U820_TS835W1 {
    [XmlElement(Order=0)]
    public string D_PLB11_C04201U821_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PLB11_C04202U822_ProviderAdjustmentIdentifier {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_PLB13_C042U823_TS835W1 {
    [XmlElement(Order=0)]
    public string D_PLB13_C04201U824_AdjustmentReasonCode {get; set;}
    [XmlElement(Order=1)]
    public string D_PLB13_C04202U825_ProviderAdjustmentIdentifier {get; set;}
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
    public class U_NM1_CorrectedPriorityPayerName_TS835W1_2100 {
    [XmlElement("S_NM1_CorrectedPriorityPayerName_TS835W1_2100",Order=0)]
    public List<S_NM1_CorrectedPriorityPayerName_TS835W1_2100> S_NM1_CorrectedPriorityPayerName_TS835W1_2100 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_OtherClaimRelatedIdentification_TS835W1_2100 {
    [XmlElement("S_REF_OtherClaimRelatedIdentification_TS835W1_2100",Order=0)]
    public List<S_REF_OtherClaimRelatedIdentification_TS835W1_2100> S_REF_OtherClaimRelatedIdentification_TS835W1_2100 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_RenderingProviderIdentification_TS835W1_2100 {
    [XmlElement("S_REF_RenderingProviderIdentification_TS835W1_2100",Order=0)]
    public List<S_REF_RenderingProviderIdentification_TS835W1_2100> S_REF_RenderingProviderIdentification_TS835W1_2100 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_ServiceIdentification_TS835W1_2110 {
    [XmlElement("S_REF_ServiceIdentification_TS835W1_2110",Order=0)]
    public List<S_REF_ServiceIdentification_TS835W1_2110> S_REF_ServiceIdentification_TS835W1_2110 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class U_REF_RenderingProviderInformation_TS835W1_2110 {
    [XmlElement("S_REF_RenderingProviderInformation_TS835W1_2110",Order=0)]
    public List<S_REF_RenderingProviderInformation_TS835W1_2110> S_REF_RenderingProviderInformation_TS835W1_2110 {get; set;}
    }
}
