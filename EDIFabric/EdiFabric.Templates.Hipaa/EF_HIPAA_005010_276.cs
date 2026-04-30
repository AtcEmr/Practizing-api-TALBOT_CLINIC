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
    
    
    [Serializable()]
    [DataContract()]
    [All()]
    public class All_REF_276
    {
        
        /// <summary>
        /// Payer Claim Control Number
        /// </summary>
        [DataMember]
        [Pos(1)]
        public REF_PayerClaimControlNumber REF_PayerClaimControlNumber { get; set; }
        /// <summary>
        /// Institutional Bill Type Identification
        /// </summary>
        [DataMember]
        [Pos(2)]
        public REF_InstitutionalBillTypeIdentification REF_InstitutionalBillTypeIdentification { get; set; }
        /// <summary>
        /// Application or Location System Identifier
        /// </summary>
        [DataMember]
        [Pos(3)]
        public REF_ApplicationorLocationSystemIdentifier REF_ApplicationorLocationSystemIdentifier { get; set; }
        /// <summary>
        /// Group Number
        /// </summary>
        [DataMember]
        [Pos(4)]
        public REF_GroupNumber REF_GroupNumber { get; set; }
        /// <summary>
        /// Patient Control Number
        /// </summary>
        [DataMember]
        [Pos(5)]
        public REF_PatientControlNumber REF_PatientControlNumber { get; set; }
        /// <summary>
        /// Pharmacy Prescription Number
        /// </summary>
        [DataMember]
        [Pos(6)]
        public REF_PharmacyPrescriptionNumber REF_PharmacyPrescriptionNumber { get; set; }
        /// <summary>
        /// Claim Identification Number For Clearinghouses and Other Transmission Intermediaries
        /// </summary>
        [DataMember]
        [Pos(7)]
        public REF_ClaimIdentificationNumberForClearinghousesandOtherTransmissionIntermediaries REF_ClaimIdentificationNumberForClearinghousesandOtherTransmissionIntermediaries { get; set; }
    }
    
    /// <summary>
    /// Loop for Information Source Level
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(HL_BillingProviderHierarchicalLevel))]
    public class Loop_2000A_276
    {
        
        /// <summary>
        /// Information Source Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public HL_BillingProviderHierarchicalLevel HL_InformationSourceLevel { get; set; }
        /// <summary>
        /// Loop for Payer Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public Loop_2100A_276 Loop2100A { get; set; }
        /// <summary>
        /// Loop for Information Receiver Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public List<Loop_2000B_276> Loop2000B { get; set; }
    }
    
    /// <summary>
    /// Loop for Information Receiver Level
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(HL_InformationReceiverLevel))]
    public class Loop_2000B_276
    {
        
        /// <summary>
        /// Information Receiver Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public HL_InformationReceiverLevel HL_InformationReceiverLevel { get; set; }
        /// <summary>
        /// Loop for Information Receiver Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public Loop_2100B_276 Loop2100B { get; set; }
        /// <summary>
        /// Loop for Service Provider Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public List<Loop_2000C_276> Loop2000C { get; set; }
    }
    
    /// <summary>
    /// Loop for Service Provider Level
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(HL_ServiceProviderLevel))]
    public class Loop_2000C_276
    {
        
        /// <summary>
        /// Service Provider Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public HL_ServiceProviderLevel HL_ServiceProviderLevel { get; set; }
        /// <summary>
        /// Loop for Provider Name
        /// </summary>
        [DataMember]
        [Required]
        [ListCount(2)]
        [Pos(2)]
        public List<Loop_2100C_276> Loop2100C { get; set; }
        /// <summary>
        /// Loop for Subscriber Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public List<Loop_2000D_276> Loop2000D { get; set; }
    }
    
    /// <summary>
    /// Loop for Subscriber Level
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(HL_SubscriberHierarchicalLevel))]
    public class Loop_2000D_276
    {
        
        /// <summary>
        /// Subscriber Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public HL_SubscriberHierarchicalLevel HL_SubscriberLevel { get; set; }
        /// <summary>
        /// Subscriber Demographic Information
        /// </summary>
        [DataMember]
        [Pos(2)]
        public DMG_DependentDemographicInformation_3 DMG_SubscriberDemographicInformation { get; set; }
        /// <summary>
        /// Loop for Subscriber Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public Loop_2100D_276 Loop2100D { get; set; }
        /// <summary>
        /// Loop for Claim Status Tracking Number
        /// </summary>
        [DataMember]
        [Pos(4)]
        public List<Loop_2200D_276> Loop2200D { get; set; }
        /// <summary>
        /// Loop for Dependent Level
        /// </summary>
        [DataMember]
        [Pos(5)]
        public List<Loop_2000E_276> Loop2000E { get; set; }
    }
    
    /// <summary>
    /// Loop for Dependent Level
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(HL_DependentLevel_2))]
    public class Loop_2000E_276
    {
        
        /// <summary>
        /// Dependent Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public HL_DependentLevel_2 HL_DependentLevel { get; set; }
        /// <summary>
        /// Dependent Demographic Information
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public DMG_DependentDemographicInformation_3 DMG_DependentDemographicInformation { get; set; }
        /// <summary>
        /// Loop for Dependent Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public Loop_2100E_276 Loop2100E { get; set; }
        /// <summary>
        /// Loop for Claim Status Tracking Number
        /// </summary>
        [DataMember]
        [Required]
        [Pos(4)]
        public List<Loop_2200E_276> Loop2200E { get; set; }
    }
    
    /// <summary>
    /// Loop for Payer Name
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(NM1_OtherPayerName))]
    public class Loop_2100A_276
    {
        
        /// <summary>
        /// Payer Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public NM1_OtherPayerName NM1_PayerName { get; set; }
    }
    
    /// <summary>
    /// Loop for Information Receiver Name
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(NM1_InformationReceiverName_3))]
    public class Loop_2100B_276
    {
        
        /// <summary>
        /// Information Receiver Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public NM1_InformationReceiverName_3 NM1_InformationReceiverName { get; set; }
    }
    
    /// <summary>
    /// Loop for Provider Name
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(NM1_ProviderName))]
    public class Loop_2100C_276
    {
        
        /// <summary>
        /// Provider Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public NM1_ProviderName NM1_ProviderName { get; set; }
    }
    
    /// <summary>
    /// Loop for Subscriber Name
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(NM1_SubscriberName_2))]
    public class Loop_2100D_276
    {
        
        /// <summary>
        /// Subscriber Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public NM1_SubscriberName_2 NM1_SubscriberName { get; set; }
    }
    
    /// <summary>
    /// Loop for Dependent Name
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(NM1_DependentName_2))]
    public class Loop_2100E_276
    {
        
        /// <summary>
        /// Dependent Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public NM1_DependentName_2 NM1_DependentName { get; set; }
    }
    
    /// <summary>
    /// Loop for Claim Status Tracking Number
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(TRN_ClaimStatusTrackingNumber))]
    public class Loop_2200D_276
    {
        
        /// <summary>
        /// Claim Status Tracking Number
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public TRN_ClaimStatusTrackingNumber TRN_ClaimStatusTrackingNumber { get; set; }
        [DataMember]
        [Pos(2)]
        public All_REF_276 AllREF { get; set; }
        /// <summary>
        /// Claim Submitted Charges
        /// </summary>
        [DataMember]
        [Pos(3)]
        public AMT_ClaimSubmittedCharges AMT_ClaimSubmittedCharges { get; set; }
        /// <summary>
        /// Claim Service Date
        /// </summary>
        [DataMember]
        [Pos(4)]
        public DTP_ClaimLevelServiceDate DTP_ClaimServiceDate { get; set; }
        /// <summary>
        /// Loop for Service Line Information
        /// </summary>
        [DataMember]
        [Pos(5)]
        public List<Loop_2210D_276> Loop2210D { get; set; }
    }
    
    /// <summary>
    /// Loop for Claim Status Tracking Number
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(TRN_ClaimStatusTrackingNumber))]
    public class Loop_2200E_276
    {
        
        /// <summary>
        /// Claim Status Tracking Number
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public TRN_ClaimStatusTrackingNumber TRN_ClaimStatusTrackingNumber { get; set; }
        [DataMember]
        [Pos(2)]
        public All_REF_276 AllREF { get; set; }
        /// <summary>
        /// Claim Submitted Charges
        /// </summary>
        [DataMember]
        [Pos(3)]
        public AMT_ClaimSubmittedCharges AMT_ClaimSubmittedCharges { get; set; }
        /// <summary>
        /// Claim Service Date
        /// </summary>
        [DataMember]
        [Pos(4)]
        public DTP_ClaimLevelServiceDate DTP_ClaimServiceDate { get; set; }
        /// <summary>
        /// Loop for Service Line Information
        /// </summary>
        [DataMember]
        [Pos(5)]
        public List<Loop_2210E_276> Loop2210E { get; set; }
    }
    
    /// <summary>
    /// Loop for Service Line Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(SVC_ServiceLineInformation))]
    public class Loop_2210D_276
    {
        
        /// <summary>
        /// Service Line Information
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public SVC_ServiceLineInformation SVC_ServiceLineInformation { get; set; }
        /// <summary>
        /// Service Line Item Identification
        /// </summary>
        [DataMember]
        [Pos(2)]
        public REF_ServiceLineItemIdentification REF_ServiceLineItemIdentification { get; set; }
        /// <summary>
        /// Service Line Date
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public DTP_ClaimLevelServiceDate DTP_ServiceLineDate { get; set; }
    }
    
    /// <summary>
    /// Loop for Service Line Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(SVC_ServiceLineInformation))]
    public class Loop_2210E_276
    {
        
        /// <summary>
        /// Service Line Information
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public SVC_ServiceLineInformation SVC_ServiceLineInformation { get; set; }
        /// <summary>
        /// Service Line Item Identification
        /// </summary>
        [DataMember]
        [Pos(2)]
        public REF_ServiceLineItemIdentification REF_ServiceLineItemIdentification { get; set; }
        /// <summary>
        /// Service Line Date
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public DTP_ClaimLevelServiceDate DTP_ServiceLineDate { get; set; }
    }
    
    /// <summary>
    /// Health Care Claim Status Request
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Message("X12", "005010X212", "276")]
    public class TS276 : EdiMessage
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
        public BHT_BeginningofHierarchicalTransaction_3 BHT_BeginningofHierarchicalTransaction { get; set; }
        /// <summary>
        /// Loop for Information Source Level
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public List<Loop_2000A_276> Loop2000A { get; set; }
        /// <summary>
        /// Transaction Set Trailer
        /// </summary>
        [DataMember]
        [Pos(4)]
        public SE SE { get; set; }
    }
}
