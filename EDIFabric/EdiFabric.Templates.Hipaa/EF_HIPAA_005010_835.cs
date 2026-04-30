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
    public class All_DTM_835
    {
        
        /// <summary>
        /// Statement From or To Date
        /// </summary>
        [DataMember]
        [ListCount(2)]
        [Pos(1)]
        public List<DTM_StatementFromorToDate> DTM_StatementFromorToDate { get; set; }
        /// <summary>
        /// Coverage Expiration Date
        /// </summary>
        [DataMember]
        [Pos(2)]
        public DTM_CoverageExpirationDate DTM_CoverageExpirationDate { get; set; }
        /// <summary>
        /// Claim Received Date
        /// </summary>
        [DataMember]
        [Pos(3)]
        public DTM_ClaimReceivedDate DTM_ClaimReceivedDate { get; set; }
    }
    
    [Serializable()]
    [DataContract()]
    [All()]
    public class All_N1_835
    {
        
        /// <summary>
        /// Loop for Payer Identification
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public Loop_1000A_835 Loop1000A { get; set; }
        /// <summary>
        /// Loop for Payee Identification
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public Loop_1000B_835 Loop1000B { get; set; }
    }
    
    [Serializable()]
    [DataContract()]
    [All()]
    public class All_NM1_835
    {
        
        /// <summary>
        /// Patient Name
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public NM1_PatientName_2 NM1_PatientName { get; set; }
        /// <summary>
        /// Insured Name
        /// </summary>
        [DataMember]
        [Pos(2)]
        public NM1_InsuredName NM1_InsuredName { get; set; }
        /// <summary>
        /// Corrected Patient/Insured Name
        /// </summary>
        [DataMember]
        [Pos(3)]
        public NM1_CorrectedPatient NM1_CorrectedPatient_InsuredName { get; set; }
        /// <summary>
        /// Service Provider Name
        /// </summary>
        [DataMember]
        [Pos(4)]
        public NM1_ServiceProviderName_3 NM1_ServiceProviderName { get; set; }
        /// <summary>
        /// Crossover Carrier Name
        /// </summary>
        [DataMember]
        [Pos(5)]
        public NM1_CrossoverCarrierName NM1_CrossoverCarrierName { get; set; }
        /// <summary>
        /// Corrected Priority Payer Name
        /// </summary>
        [DataMember]
        [Pos(6)]
        public NM1_CorrectedPriorityPayerName NM1_CorrectedPriorityPayerName { get; set; }
        /// <summary>
        /// Other Subscriber Name
        /// </summary>
        [DataMember]
        [Pos(7)]
        public NM1_OtherSubscriberName_2 NM1_OtherSubscriberName { get; set; }
    }
    
    [Serializable()]
    [DataContract()]
    [All()]
    public class All_PER_835
    {
        
        /// <summary>
        /// Payer Business Contact Information
        /// </summary>
        [DataMember]
        [Pos(1)]
        public PER_PayerBusinessContactInformation PER_PayerBusinessContactInformation { get; set; }
        /// <summary>
        /// Payer Technical Contact Information
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public List<PER_PayerTechnicalContactInformation> PER_PayerTechnicalContactInformation { get; set; }
        /// <summary>
        /// Payer WEB Site
        /// </summary>
        [DataMember]
        [Pos(3)]
        public PER_PayerWEBSite PER_PayerWEBSite { get; set; }
    }
    
    [Serializable()]
    [DataContract()]
    [All()]
    public class All_REF_835
    {
        
        /// <summary>
        /// Other Claim Related Identification
        /// </summary>
        [DataMember]
        [ListCount(5)]
        [Pos(1)]
        public List<REF_OtherClaimRelatedIdentification> REF_OtherClaimRelatedIdentification { get; set; }
        /// <summary>
        /// Rendering Provider Identification
        /// </summary>
        [DataMember]
        [ListCount(10)]
        [Pos(2)]
        public List<REF_RenderingProviderIdentification> REF_RenderingProviderIdentification { get; set; }
    }
    
    [Serializable()]
    [DataContract()]
    [All()]
    public class All_REF_835_2
    {
        
        /// <summary>
        /// Service Identification
        /// </summary>
        [DataMember]
        [ListCount(8)]
        [Pos(1)]
        public List<REF_ServiceIdentification> REF_ServiceIdentification { get; set; }
        /// <summary>
        /// Line Item Control Number
        /// </summary>
        [DataMember]
        [Pos(2)]
        public REF_LineItemControlNumber REF_LineItemControlNumber { get; set; }
        /// <summary>
        /// Rendering Provider Information
        /// </summary>
        [DataMember]
        [ListCount(10)]
        [Pos(3)]
        public List<REF_RenderingProviderInformation> REF_RenderingProviderInformation { get; set; }
        /// <summary>
        /// HealthCare Policy Identification
        /// </summary>
        [DataMember]
        [ListCount(5)]
        [Pos(4)]
        public List<REF_HealthCarePolicyIdentification> REF_HealthCarePolicyIdentification { get; set; }
    }
    
    [Serializable()]
    [DataContract()]
    [All()]
    public class All_REF_835_3
    {
        
        /// <summary>
        /// Receiver Identification
        /// </summary>
        [DataMember]
        [Pos(1)]
        public REF_ReceiverIdentification REF_ReceiverIdentification { get; set; }
        /// <summary>
        /// Version Identification
        /// </summary>
        [DataMember]
        [Pos(2)]
        public REF_VersionIdentification REF_VersionIdentification { get; set; }
    }
    
    /// <summary>
    /// Loop for Payer Identification
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(N1_PayerIdentification))]
    public class Loop_1000A_835
    {
        
        /// <summary>
        /// Payer Identification
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public N1_PayerIdentification N1_PayerIdentification { get; set; }
        /// <summary>
        /// Payer Address
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public N3_AdditionalPatientInformationContactAddress N3_PayerAddress { get; set; }
        /// <summary>
        /// Payer City, State, ZIP Code
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public N4_AdditionalPatientInformationContactCity N4_PayerCity_State_ZIPCode { get; set; }
        /// <summary>
        /// Additional Payer Identification
        /// </summary>
        [DataMember]
        [ListCount(4)]
        [Pos(4)]
        public List<REF_AdditionalPayerIdentification> REF_AdditionalPayerIdentification { get; set; }
        [DataMember]
        [Required]
        [Pos(5)]
        public All_PER_835 AllPER { get; set; }
    }
    
    /// <summary>
    /// Loop for Payee Identification
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(N1_PayeeIdentification))]
    public class Loop_1000B_835
    {
        
        /// <summary>
        /// Payee Identification
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public N1_PayeeIdentification N1_PayeeIdentification { get; set; }
        /// <summary>
        /// Payee Address
        /// </summary>
        [DataMember]
        [Pos(2)]
        public N3_AdditionalPatientInformationContactAddress N3_PayeeAddress { get; set; }
        /// <summary>
        /// Payee City, State, ZIP Code
        /// </summary>
        [DataMember]
        [Pos(3)]
        public N4_AdditionalPatientInformationContactCity N4_PayeeCity_State_ZIPCode { get; set; }
        /// <summary>
        /// Payee Additional Identification
        /// </summary>
        [DataMember]
        [Pos(4)]
        public List<REF_PayeeAdditionalIdentification> REF_PayeeAdditionalIdentification { get; set; }
        /// <summary>
        /// Remittance Delivery Method
        /// </summary>
        [DataMember]
        [Pos(5)]
        public RDM_RemittanceDeliveryMethod RDM_RemittanceDeliveryMethod { get; set; }
    }
    
    /// <summary>
    /// Loop for Header Number
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(LX_HeaderNumber))]
    public class Loop_2000_835
    {
        
        /// <summary>
        /// Header Number
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public LX_HeaderNumber LX_HeaderNumber { get; set; }
        /// <summary>
        /// Provider Summary Information
        /// </summary>
        [DataMember]
        [Pos(2)]
        public TS3_ProviderSummaryInformation TS3_ProviderSummaryInformation { get; set; }
        /// <summary>
        /// Provider Supplemental Summary Information
        /// </summary>
        [DataMember]
        [Pos(3)]
        public TS2_ProviderSupplementalSummaryInformation TS2_ProviderSupplementalSummaryInformation { get; set; }
        /// <summary>
        /// Loop for Claim Payment Information
        /// </summary>
        [DataMember]
        [Required]
        [Pos(4)]
        public List<Loop_2100_835> Loop2100 { get; set; }
    }
    
    /// <summary>
    /// Loop for Claim Payment Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(CLP_ClaimPaymentInformation))]
    public class Loop_2100_835
    {
        
        /// <summary>
        /// Claim Payment Information
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public CLP_ClaimPaymentInformation CLP_ClaimPaymentInformation { get; set; }
        /// <summary>
        /// Claims Adjustment
        /// </summary>
        [DataMember]
        [ListCount(99)]
        [Pos(2)]
        public List<CAS_ClaimsAdjustment> CAS_ClaimsAdjustment { get; set; }
        [DataMember]
        [Required]
        [Pos(3)]
        public All_NM1_835 AllNM1 { get; set; }
        /// <summary>
        /// Inpatient Adjudication Information
        /// </summary>
        [DataMember]
        [Pos(4)]
        public MIA_InpatientAdjudicationInformation MIA_InpatientAdjudicationInformation { get; set; }
        /// <summary>
        /// Outpatient Adjudication Information
        /// </summary>
        [DataMember]
        [Pos(5)]
        public MOA_OutpatientAdjudicationInformation MOA_OutpatientAdjudicationInformation { get; set; }
        [DataMember]
        [Pos(6)]
        public All_REF_835 AllREF { get; set; }
        [DataMember]
        [Pos(7)]
        public All_DTM_835 AllDTM { get; set; }
        /// <summary>
        /// Claim Contact Information
        /// </summary>
        [DataMember]
        [ListCount(2)]
        [Pos(8)]
        public List<PER_ClaimContactInformation> PER_ClaimContactInformation { get; set; }
        /// <summary>
        /// Claim Supplemental Information
        /// </summary>
        [DataMember]
        [ListCount(13)]
        [Pos(9)]
        public List<AMT_ClaimSupplementalInformation> AMT_ClaimSupplementalInformation { get; set; }
        /// <summary>
        /// Claim Supplemental Information Quantity
        /// </summary>
        [DataMember]
        [ListCount(14)]
        [Pos(10)]
        public List<QTY_ClaimSupplementalInformationQuantity> QTY_ClaimSupplementalInformationQuantity { get; set; }
        /// <summary>
        /// Loop for Service Payment Information
        /// </summary>
        [DataMember]
        [ListCount(999)]
        [Pos(11)]
        public List<Loop_2110_835> Loop2110 { get; set; }
    }
    
    /// <summary>
    /// Loop for Service Payment Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(SVC_ServicePaymentInformation))]
    public class Loop_2110_835
    {
        
        /// <summary>
        /// Service Payment Information
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public SVC_ServicePaymentInformation SVC_ServicePaymentInformation { get; set; }
        /// <summary>
        /// Service Date
        /// </summary>
        [DataMember]
        [ListCount(2)]
        [Pos(2)]
        public List<DTM_ServiceDate> DTM_ServiceDate { get; set; }
        /// <summary>
        /// Service Adjustment
        /// </summary>
        [DataMember]
        [ListCount(99)]
        [Pos(3)]
        public List<CAS_ClaimsAdjustment> CAS_ServiceAdjustment { get; set; }
        [DataMember]
        [Pos(4)]
        public All_REF_835_2 AllREF { get; set; }
        /// <summary>
        /// Service Supplemental Amount
        /// </summary>
        [DataMember]
        [ListCount(9)]
        [Pos(5)]
        public List<AMT_ServiceSupplementalAmount> AMT_ServiceSupplementalAmount { get; set; }
        /// <summary>
        /// Service Supplemental Quantity
        /// </summary>
        [DataMember]
        [ListCount(6)]
        [Pos(6)]
        public List<QTY_ServiceSupplementalQuantity> QTY_ServiceSupplementalQuantity { get; set; }
        /// <summary>
        /// Health Care Remark Codes
        /// </summary>
        [DataMember]
        [ListCount(99)]
        [Pos(7)]
        public List<LQ_HealthCareRemarkCodes> LQ_HealthCareRemarkCodes { get; set; }
    }
    
    /// <summary>
    /// Health Care Claim Payment/Advice
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Message("X12", "005010X221A1", "835")]
    public class TS835 : EdiMessage
    {
        
        /// <summary>
        /// Transaction Set Header
        /// </summary>
        [DataMember]
        [Pos(1)]
        public ST ST { get; set; }
        /// <summary>
        /// Financial Information
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public BPR_FinancialInformation_2 BPR_FinancialInformation { get; set; }
        /// <summary>
        /// Reassociation Trace Number
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public TRN_DependentTraceNumber TRN_ReassociationTraceNumber { get; set; }
        /// <summary>
        /// Foreign Currency Information
        /// </summary>
        [DataMember]
        [Pos(4)]
        public CUR_ForeignCurrencyInformation_2 CUR_ForeignCurrencyInformation { get; set; }
        [DataMember]
        [Pos(5)]
        public All_REF_835_3 AllREF { get; set; }
        /// <summary>
        /// Production Date
        /// </summary>
        [DataMember]
        [Pos(6)]
        public DTM_ProductionDate DTM_ProductionDate { get; set; }
        [DataMember]
        [Required]
        [Pos(7)]
        public All_N1_835 AllN1 { get; set; }
        /// <summary>
        /// Loop for Header Number
        /// </summary>
        [DataMember]
        [Pos(8)]
        public List<Loop_2000_835> Loop2000 { get; set; }
        /// <summary>
        /// Provider Adjustment
        /// </summary>
        [DataMember]
        [Pos(9)]
        public List<PLB_ProviderAdjustment> PLB_ProviderAdjustment { get; set; }
        /// <summary>
        /// Transaction Set Trailer
        /// </summary>
        [DataMember]
        [Pos(10)]
        public SE SE { get; set; }
    }
}
