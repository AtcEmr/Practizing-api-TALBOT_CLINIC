namespace EdiFabric.Templates.Hipaa5010
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.X12;
    using EdiFabric.Core.Model.Edi.ErrorContexts;

    /// <summary>
    /// Name
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("N1")]
    public class N1 
    {
       
        /// <summary>
        /// Entity Identifier Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string Name_02 { get; set; }
        /// <summary>
        /// Identification Code Qualifier
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string IdentificationCodeQualifier_03 { get; set; }
        /// <summary>
        /// Identification Code
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string IdentificationCode_04 { get; set; }
        /// <summary>
        /// Entity Relationship Code
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string EntityRelationshipCode_05 { get; set; }
        /// <summary>
        /// Entity Identifier Code
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string EntityIdentifierCode_06 { get; set; }
    }


    /// <summary>
    /// Additional Name Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("N2")]
    public class N2 
    {

      
        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string Name_01 { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string Name_02 { get; set; }
    }

    /// <summary>
    /// Address Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("N3")]
    public class N3 
    {

        
        /// <summary>
        /// Address Information
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string AddressInformation_01 { get; set; }
        /// <summary>
        /// Address Information
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string AddressInformation_02 { get; set; }
    }

    /// <summary>
    /// Geographic Location
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("N4")]
    public class N4 
    {

       
        /// <summary>
        /// City Name
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string CityName_01 { get; set; }
        /// <summary>
        /// State or Province Code
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string StateorProvinceCode_02 { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string PostalCode_03 { get; set; }
        /// <summary>
        /// Country Code
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string CountryCode_04 { get; set; }
        /// <summary>
        /// Location Qualifier
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string LocationQualifier_05 { get; set; }
        /// <summary>
        /// Location Identifier
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string LocationIdentifier_06 { get; set; }
    }

    /// <summary>
    /// Reference Identification
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("REF")]
    public class REF 
    {

       
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string Description_03 { get; set; }
        /// <summary>
        /// Reference Identifier
        /// </summary>
        [DataMember]
        [Pos(4)]
        public virtual C040 ReferenceIdentifier_04 { get; set; }
    }

    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040 
    {

        
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }


    /// <summary>
    /// Loop for Name
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(N1))]
    public class Loop_N1_824
    {   
        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [Pos(1)]
        public virtual N1 N1 { get; set; }
        /// <summary>
        /// Additional Name Information
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual List<N2> N2 { get; set; }
        /// <summary>
        /// Address Information
        /// </summary>
        [DataMember]
        [Pos(3)]
        public virtual List<N3> N3 { get; set; }
        /// <summary>
        /// Geographic Location
        /// </summary>
        [DataMember]
        [Pos(4)]
        public virtual N4 N4 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Pos(5)]
        public virtual List<REF> REF { get; set; }
        /// <summary>
        /// Administrative Communications Contact
        /// </summary>
        [DataMember]
        [Pos(6)]
        public virtual List<PER> PER { get; set; }
    }

    /// <summary>
    /// Administrative Communications Contact
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("PER")]
    public class PER 
    {

       
        /// <summary>
        /// Contact Function Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string ContactFunctionCode_01 { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string Name_02 { get; set; }
        /// <summary>
        /// Communication Number Qualifier
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string CommunicationNumberQualifier_03 { get; set; }
        /// <summary>
        /// Communication Number
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string CommunicationNumber_04 { get; set; }
        /// <summary>
        /// Communication Number Qualifier
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string CommunicationNumberQualifier_05 { get; set; }
        /// <summary>
        /// Communication Number
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string CommunicationNumber_06 { get; set; }
        /// <summary>
        /// Communication Number Qualifier
        /// </summary>
        [DataMember]
        [Pos(7)]
        public string CommunicationNumberQualifier_07 { get; set; }
        /// <summary>
        /// Communication Number
        /// </summary>
        [DataMember]
        [Pos(8)]
        public string CommunicationNumber_08 { get; set; }
        /// <summary>
        /// Contact Inquiry Reference
        /// </summary>
        [DataMember]
        [Pos(9)]
        public string ContactInquiryReference_09 { get; set; }
    }

    /// <summary>
    /// Original Transaction Identification
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("OTI")]
    public class OTI 
    {

      
        /// <summary>
        /// Application Acknowledgment Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string ApplicationAcknowledgmentCode_01 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string ReferenceIdentificationQualifier_02 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string ReferenceIdentification_03 { get; set; }
        /// <summary>
        /// Application Sender's Code
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string ApplicationSendersCode_04 { get; set; }
        /// <summary>
        /// Application Receiver's Code
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string ApplicationReceiversCode_05 { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string Date_06 { get; set; }
        /// <summary>
        /// Time
        /// </summary>
        [DataMember]
        [Pos(7)]
        public string Time_07 { get; set; }
        /// <summary>
        /// Group Control Number
        /// </summary>
        [DataMember]
        [Pos(8)]
        public string GroupControlNumber_08 { get; set; }
        /// <summary>
        /// Transaction Set Control Number
        /// </summary>
        [DataMember]
        [Pos(9)]
        public string TransactionSetControlNumber_09 { get; set; }
        /// <summary>
        /// Transaction Set Identifier Code
        /// </summary>
        [DataMember]
        [Pos(10)]
        public string TransactionSetIdentifierCode_10 { get; set; }
        /// <summary>
        /// Version / Release / Industry Identifier Code
        /// </summary>
        [DataMember]
        [Pos(11)]
        public string VersionReleaseIndustryIdentifierCode_11 { get; set; }
        /// <summary>
        /// Transaction Set Purpose Code
        /// </summary>
        [DataMember]
        [Pos(12)]
        public string TransactionSetPurposeCode_12 { get; set; }
        /// <summary>
        /// Transaction Type Code
        /// </summary>
        [DataMember]
        [Pos(13)]
        public string TransactionTypeCode_13 { get; set; }
        /// <summary>
        /// Application Type
        /// </summary>
        [DataMember]
        [Pos(14)]
        public string ApplicationType_14 { get; set; }
        /// <summary>
        /// Action Code
        /// </summary>
        [DataMember]
        [Pos(15)]
        public string ActionCode_15 { get; set; }
        /// <summary>
        /// Transaction Handling Code
        /// </summary>
        [DataMember]
        [Pos(16)]
        public string TransactionHandlingCode_16 { get; set; }
        /// <summary>
        /// Status Reason Code
        /// </summary>
        [DataMember]
        [Pos(17)]
        public string StatusReasonCode_17 { get; set; }
    }

    /// <summary>
    /// Date/Time Reference
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("DTM")]
    public class DTM 
    {

     
        /// <summary>
        /// Date/Time Qualifier
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string DateTimeQualifier_01 { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string Date_02 { get; set; }
        /// <summary>
        /// Time
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string Time_03 { get; set; }
        /// <summary>
        /// Time Code
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string TimeCode_04 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string DateTimePeriodFormatQualifier_05 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string DateTimePeriod_06 { get; set; }
    }

    /// <summary>
    /// Monetary Amount
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("AMT")]
    public class AMT 
    {

       
        /// <summary>
        /// Amount Qualifier Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string AmountQualifierCode_01 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string MonetaryAmount_02 { get; set; }
        /// <summary>
        /// Credit/Debit Flag Code
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string CreditDebitFlagCode_03 { get; set; }
    }

    /// <summary>
    /// Quantity
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("QTY")]
    public class QTY 
    {

        
        /// <summary>
        /// Quantity Qualifier
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string QuantityQualifier_01 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string Quantity_02 { get; set; }
        /// <summary>
        /// Composite Unit of Measure
        /// </summary>
        [DataMember]
        [Pos(3)]
        public virtual C001 CompositeUnitofMeasure_03 { get; set; }
        /// <summary>
        /// Free-Form Message
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string FreeFormMessage_04 { get; set; }
    }

    /// <summary>
    /// Composite Unit of Measure
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C001")]
    public class C001 
    {

       
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string UnitorBasisforMeasurementCode_01 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string Exponent_02 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string Multiplier_03 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string UnitorBasisforMeasurementCode_04 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string Exponent_05 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string Multiplier_06 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [Pos(7)]
        public string UnitorBasisforMeasurementCode_07 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [Pos(8)]
        public string Exponent_08 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [Pos(9)]
        public string Multiplier_09 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [Pos(10)]
        public string UnitorBasisforMeasurementCode_10 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [Pos(11)]
        public string Exponent_11 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [Pos(12)]
        public string Multiplier_12 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [Pos(13)]
        public string UnitorBasisforMeasurementCode_13 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [Pos(14)]
        public string Exponent_14 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [Pos(15)]
        public string Multiplier_15 { get; set; }
    }

    /// <summary>
    /// Individual or Organizational Name
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("NM1")]
    public class NM1 
    {

        
        /// <summary>
        /// Entity Identifier Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string EntityIdentifierCode_01 { get; set; }
        /// <summary>
        /// Entity Type Qualifier
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string EntityTypeQualifier_02 { get; set; }
        /// <summary>
        /// Name Last or Organization Name
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string NameLastorOrganizationName_03 { get; set; }
        /// <summary>
        /// Name First
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string NameFirst_04 { get; set; }
        /// <summary>
        /// Name Middle
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string NameMiddle_05 { get; set; }
        /// <summary>
        /// Name Prefix
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string NamePrefix_06 { get; set; }
        /// <summary>
        /// Name Suffix
        /// </summary>
        [DataMember]
        [Pos(7)]
        public string NameSuffix_07 { get; set; }
        /// <summary>
        /// Identification Code Qualifier
        /// </summary>
        [DataMember]
        [Pos(8)]
        public string IdentificationCodeQualifier_08 { get; set; }
        /// <summary>
        /// Identification Code
        /// </summary>
        [DataMember]
        [Pos(9)]
        public string IdentificationCode_09 { get; set; }
        /// <summary>
        /// Entity Relationship Code
        /// </summary>
        [DataMember]
        [Pos(10)]
        public string EntityRelationshipCode_10 { get; set; }
        /// <summary>
        /// Entity Identifier Code
        /// </summary>
        [DataMember]
        [Pos(11)]
        public string EntityIdentifierCode_11 { get; set; }
    }

    /// <summary>
    /// Technical Error Description
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("TED")]
    public class TED
    {

       
        /// <summary>
        /// Application Error Condition Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string ApplicationErrorConditionCode_01 { get; set; }
        /// <summary>
        /// Free Form Message
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string FreeFormMessage_02 { get; set; }
        /// <summary>
        /// Segment ID Code
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string SegmentIDCode_03 { get; set; }
        /// <summary>
        /// Segment Position in Transaction Set
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string SegmentPositioninTransactionSet_04 { get; set; }
        /// <summary>
        /// Element Position in Segment
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string ElementPositioninSegment_05 { get; set; }
        /// <summary>
        /// Data Element Reference Number
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string DataElementReferenceNumber_06 { get; set; }
        /// <summary>
        /// Copy of Bad Data Element
        /// </summary>
        [DataMember]
        [Pos(7)]
        public string CopyofBadDataElement_07 { get; set; }
        /// <summary>
        /// Data Element New Content
        /// </summary>
        [DataMember]
        [Pos(8)]
        public string DataElementNewContent_08 { get; set; }
    }

    /// <summary>
    /// Note/Special Instruction
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("NTE")]
    public class NTE 
    {

        
        /// <summary>
        /// Note Reference Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string NoteReferenceCode_01 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string Description_02 { get; set; }
    }

    /// <summary>
    /// Related Data
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("RED")]
    public class RED 
    {

      
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string Description_01 { get; set; }
        /// <summary>
        /// Related Data Identification Code
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string RelatedDataIdentificationCode_02 { get; set; }
        /// <summary>
        /// Agency Qualifier Code
        /// </summary>
        [DataMember]
        [Pos(3)]
        public string AgencyQualifierCode_03 { get; set; }
        /// <summary>
        /// Source Subqualifier
        /// </summary>
        [DataMember]
        [Pos(4)]
        public string SourceSubqualifier_04 { get; set; }
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Pos(5)]
        public string CodeListQualifierCode_05 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Pos(6)]
        public string IndustryCode_06 { get; set; }
    }


    /// <summary>
    /// Loop for Technical Error Description
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(TED))]
    public class Loop_TED_824
    {  
        /// <summary>
        /// Technical Error Description
        /// </summary>
        [DataMember]
        [Pos(1)]
        public virtual TED TED { get; set; }
        /// <summary>
        /// Note/Special Instruction
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual List<NTE> NTE { get; set; }
        /// <summary>
        /// Related Data
        /// </summary>
        [DataMember]
        [Pos(3)]
        public virtual List<RED> RED { get; set; }
    }

    /// <summary>
    /// Code Source Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("LM")]
    public class LM 
    {   
        /// <summary>
        /// Agency Qualifier Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string AgencyQualifierCode_01 { get; set; }
        /// <summary>
        /// Source Subqualifier
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string SourceSubqualifier_02 { get; set; }
    }

    /// <summary>
    /// Loop for Code Source Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(LM))]
    public class Loop_LM_824
    {  
        /// <summary>
        /// Code Source Information
        /// </summary>
        [DataMember]
        [Pos(1)]
        public virtual LM LM { get; set; }
        /// <summary>
        /// Loop for Industry Code
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual List<Loop_LQ_824> LQLoop { get; set; }
    }

    /// <summary>
    /// Industry Code
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("LQ")]
    public class LQ 
    {   
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
    }

    /// <summary>
    /// Loop for Industry Code
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(LQ))]
    public class Loop_LQ_824
    {        
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Pos(1)]
        public virtual LQ LQ { get; set; }
        /// <summary>
        /// Related Data
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual List<RED> RED { get; set; }
    }

    /// <summary>
    /// Loop for Original Transaction Identification
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(OTI))]
    public class Loop_OTI_824
    {

       
        /// <summary>
        /// Original Transaction Identification
        /// </summary>
        [DataMember]
        [Pos(1)]
        public virtual OTI OTI { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual List<REF> REF { get; set; }
        /// <summary>
        /// Date/Time Reference
        /// </summary>
        [DataMember]
        [Pos(3)]
        public virtual List<DTM> DTM { get; set; }
        /// <summary>
        /// Administrative Communications Contact
        /// </summary>
        [DataMember]
        [Pos(4)]
        public virtual List<PER> PER { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [Pos(5)]
        public virtual List<AMT> AMT { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [Pos(6)]
        public virtual List<QTY> QTY { get; set; }
        /// <summary>
        /// Individual or Organizational Name
        /// </summary>
        [DataMember]
        [Pos(7)]
        public virtual List<NM1> NM1 { get; set; }
        /// <summary>
        /// Loop for Technical Error Description
        /// </summary>
        [DataMember]
        [Pos(8)]
        public virtual List<Loop_TED_824> TEDLoop { get; set; }
        /// <summary>
        /// Loop for Code Source Information
        /// </summary>
        [DataMember]
        [Pos(9)]
        public virtual List<Loop_LM_824> LMLoop { get; set; }
    }

    /// <summary>
    /// Health Care Claim Acknowledgment
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Message("X12", "005010X186A1", "824")]
    public class TS824 : EdiMessage
    {
        
        /// <summary>
        /// Transaction Set Header
        /// </summary>
        [DataMember]
        [Pos(1)]
        public ST ST { get; set; }
        /// <summary>
        /// Beginning of Hierarchical Transaction
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public BGN_BeginningSegment1 BGN_BeginningSegment { get; set; }
        ///// <summary>
        ///// Information Source Level Loop
        ///// </summary>
        //[DataMember]
        //[Required]
        //[Pos(3)]
        //public Loop_2000A_277A Loop2000A { get; set; }
        /// <summary>
        /// Loop for Name
        /// </summary>
        [DataMember]
        [Pos(3)]
        public virtual List<Loop_N1_824> N1Loop { get; set; }
        /// <summary>
        /// Loop for Original Transaction Identification
        /// </summary>
        [DataMember]
        [Pos(4)]
        public virtual List<Loop_OTI_824> OTILoop { get; set; }
        /// <summary>
        /// Transaction Set Trailer
        /// </summary>
        [DataMember]
        [Pos(4)]
        public SE SE { get; set; }
    }

    /// <summary>
    /// Beginning Segment
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Segment("BGN")]
    public class BGN_BeginningSegment1
    {

        /// <summary>
        /// Transaction Set Purpose Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("353", typeof(X12_ID_353_6))]
        [Pos(1)]
        public string TransactionSetPurposeCode_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(2)]
        public string TransactionSetReferenceNumber_02 { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(8, 8)]
        [DataElement("373", typeof(X12_DT))]
        [Pos(3)]
        public string TransactionSetCreationDate_03 { get; set; }
        /// <summary>
        /// Time
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(4, 8)]
        [DataElement("337", typeof(X12_TM))]
        [Pos(4)]
        public string TransactionSetCreationTime_04 { get; set; }
        /// <summary>
        /// Time Code
        /// </summary>
        [DataMember]
        [Conditional(4)]
        [DataElement("623", typeof(X12_ID_623))]
        [Pos(5)]
        public string TimeZoneCode_05 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(6)]
        public string OriginalTransactionSetReferenceNumber_06 { get; set; }
        /// <summary>
        /// Transaction Type Code
        /// </summary>
        [DataMember]
        [DataElement("640", typeof(X12_ID_640_2))]
        [Pos(7)]
        public string TransactionTypeCode_07 { get; set; }
        /// <summary>
        /// Action Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("306", typeof(X12_ID_306_8))]
        [Pos(8)]
        public string ActionCode_08 { get; set; }
        /// <summary>
        /// Security Level Code
        /// </summary>
        [DataMember]
        [DataElement("786", typeof(X12_ID_786))]
        [Pos(9)]
        public string SecurityLevelCode_09 { get; set; }
    }

}
