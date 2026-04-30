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
    /// Composite Unit of Measure
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C001")]
    public class C001_CompositeUnitofMeasure : IC001
    {
        
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(1)]
        public string UnitorBasisforMeasurementCode_01 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(2)]
        public string Exponent_02 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(3)]
        public string Multiplier_03 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(4)]
        public string UnitorBasisforMeasurementCode_04 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(5)]
        public string Exponent_05 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(6)]
        public string Multiplier_06 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(7)]
        public string UnitorBasisforMeasurementCode_07 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(8)]
        public string Exponent_08 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(9)]
        public string Multiplier_09 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(10)]
        public string UnitorBasisforMeasurementCode_10 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(11)]
        public string Exponent_11 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(12)]
        public string Multiplier_12 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(13)]
        public string UnitorBasisforMeasurementCode_13 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(14)]
        public string Exponent_14 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(15)]
        public string Multiplier_15 { get; set; }
    }
    
    /// <summary>
    /// Composite Unit of Measure
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C001")]
    public class C001_CompositeUnitOfMeasure : IC001
    {
        
        [DataMember]
        [DataElement("", typeof(X12_ID_355))]
        [Pos(1)]
        public string UnitorBasisforMeasurementCode_01 { get; set; }
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("", typeof(X12_R))]
        [Pos(2)]
        public string Exponent_02 { get; set; }
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_R))]
        [Pos(3)]
        public string Multiplier_03 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_355))]
        [Pos(4)]
        public string UnitorBasisforMeasurementCode_04 { get; set; }
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("", typeof(X12_R))]
        [Pos(5)]
        public string Exponent_05 { get; set; }
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_R))]
        [Pos(6)]
        public string Multiplier_06 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_355))]
        [Pos(7)]
        public string UnitorBasisforMeasurementCode_07 { get; set; }
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("", typeof(X12_R))]
        [Pos(8)]
        public string Exponent_08 { get; set; }
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_R))]
        [Pos(9)]
        public string Multiplier_09 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_355))]
        [Pos(10)]
        public string UnitorBasisforMeasurementCode_10 { get; set; }
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("", typeof(X12_R))]
        [Pos(11)]
        public string Exponent_11 { get; set; }
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_R))]
        [Pos(12)]
        public string Multiplier_12 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_355))]
        [Pos(13)]
        public string UnitorBasisforMeasurementCode_13 { get; set; }
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("", typeof(X12_R))]
        [Pos(14)]
        public string Exponent_14 { get; set; }
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("", typeof(X12_R))]
        [Pos(15)]
        public string Multiplier_15 { get; set; }
    }
    
    /// <summary>
    /// Composite Unit of Measure
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C001")]
    public class C001_CompositeUnitofMeasure_2 : IC001
    {
        
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("355", typeof(X12_ID_355_6))]
        [Pos(1)]
        public string UnitorBasisforMeasurementCode_01 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(2)]
        public string Exponent_02 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(3)]
        public string Multiplier_03 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(4)]
        public string UnitorBasisforMeasurementCode_04 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(5)]
        public string Exponent_05 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(6)]
        public string Multiplier_06 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(7)]
        public string UnitorBasisforMeasurementCode_07 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(8)]
        public string Exponent_08 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(9)]
        public string Multiplier_09 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(10)]
        public string UnitorBasisforMeasurementCode_10 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(11)]
        public string Exponent_11 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(12)]
        public string Multiplier_12 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(13)]
        public string UnitorBasisforMeasurementCode_13 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(14)]
        public string Exponent_14 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(15)]
        public string Multiplier_15 { get; set; }
    }
    
    /// <summary>
    /// Composite Unit of Measure
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C001")]
    public class C001_CompositeUnitofMeasure_3 : IC001
    {
        
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("355", typeof(X12_ID_355_2))]
        [Pos(1)]
        public string UnitorBasisforMeasurementCode_01 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(2)]
        public string Exponent_02 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(3)]
        public string Multiplier_03 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(4)]
        public string UnitorBasisforMeasurementCode_04 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(5)]
        public string Exponent_05 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(6)]
        public string Multiplier_06 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(7)]
        public string UnitorBasisforMeasurementCode_07 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(8)]
        public string Exponent_08 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(9)]
        public string Multiplier_09 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(10)]
        public string UnitorBasisforMeasurementCode_10 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(11)]
        public string Exponent_11 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(12)]
        public string Multiplier_12 { get; set; }
        /// <summary>
        /// Unit or Basis for Measurement Code
        /// </summary>
        [DataMember]
        [DataElement("355", typeof(X12_ID_355))]
        [Pos(13)]
        public string UnitorBasisforMeasurementCode_13 { get; set; }
        /// <summary>
        /// Exponent
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("1018", typeof(X12_R))]
        [Pos(14)]
        public string Exponent_14 { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        [DataMember]
        [StringLength(1, 10)]
        [DataElement("649", typeof(X12_R))]
        [Pos(15)]
        public string Multiplier_15 { get; set; }
    }
    
    /// <summary>
    /// Actions Indicated
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C002")]
    public class C002_ActionsIndicated : IC002
    {
        
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("704", typeof(X12_ID_704_2))]
        [Pos(1)]
        public string PaperworkReportActionCode_01 { get; set; }
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [DataElement("704", typeof(X12_ID_704_2))]
        [Pos(2)]
        public string PaperworkReportActionCode_02 { get; set; }
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [DataElement("704", typeof(X12_ID_704_2))]
        [Pos(3)]
        public string PaperworkReportActionCode_03 { get; set; }
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [DataElement("704", typeof(X12_ID_704_2))]
        [Pos(4)]
        public string PaperworkReportActionCode_04 { get; set; }
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [DataElement("704", typeof(X12_ID_704_2))]
        [Pos(5)]
        public string PaperworkReportActionCode_05 { get; set; }
    }
    
    /// <summary>
    /// Actions Indicated
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C002")]
    public class C002_ActionsIndicated_2 : IC002
    {
        
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("704", typeof(X12_ID_704))]
        [Pos(1)]
        public string PaperworkReportActionCode_01 { get; set; }
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [DataElement("704", typeof(X12_ID_704))]
        [Pos(2)]
        public string PaperworkReportActionCode_02 { get; set; }
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [DataElement("704", typeof(X12_ID_704))]
        [Pos(3)]
        public string PaperworkReportActionCode_03 { get; set; }
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [DataElement("704", typeof(X12_ID_704))]
        [Pos(4)]
        public string PaperworkReportActionCode_04 { get; set; }
        /// <summary>
        /// Paperwork/Report Action Code
        /// </summary>
        [DataMember]
        [DataElement("704", typeof(X12_ID_704))]
        [Pos(5)]
        public string PaperworkReportActionCode_05 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_12))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_10 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_18))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_11 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_4))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_12 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_6))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_13 : IC003
    {
        
        [DataMember]
        [Required]
        [DataElement("", typeof(X12_ID_235_13))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_14 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_16))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_15 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_2_Obj))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_16 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_15))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_2 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_3 : IC003
    {
        
        [DataMember]
        [DataElement("", typeof(X12_ID_235))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_4 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_17))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_5 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_7))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_6 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_3))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_7 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_8))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_8 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_5))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Medical Procedure Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C003")]
    public class C003_CompositeMedicalProcedureIdentifier_9 : IC003
    {
        
        /// <summary>
        /// Product/Service ID Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("235", typeof(X12_ID_235_10))]
        [Pos(1)]
        public string ProductorServiceIDQualifier_01 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(2)]
        public string ProcedureCode_02 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(3)]
        public string ProcedureModifier_03 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(4)]
        public string ProcedureModifier_04 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(5)]
        public string ProcedureModifier_05 { get; set; }
        /// <summary>
        /// Procedure Modifier
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("1339", typeof(X12_AN))]
        [Pos(6)]
        public string ProcedureModifier_06 { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [StringLength(1, 80)]
        [DataElement("352", typeof(X12_AN))]
        [Pos(7)]
        public string Description_07 { get; set; }
        /// <summary>
        /// Product/Service ID
        /// </summary>
        [DataMember]
        [StringLength(1, 48)]
        [DataElement("234", typeof(X12_AN))]
        [Pos(8)]
        public string ProductServiceID_08 { get; set; }
    }
    
    /// <summary>
    /// Composite Diagnosis Code Pointer
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C004")]
    public class C004_CompositeDiagnosisCodePointer : IC004
    {
        
        /// <summary>
        /// Diagnosis Code Pointer
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 2)]
        [DataElement("1328", typeof(X12_N0))]
        [Pos(1)]
        public string DiagnosisCodePointer_01 { get; set; }
        /// <summary>
        /// Diagnosis Code Pointer
        /// </summary>
        [DataMember]
        [StringLength(1, 2)]
        [DataElement("1328", typeof(X12_N0))]
        [Pos(2)]
        public string DiagnosisCodePointer_02 { get; set; }
        /// <summary>
        /// Diagnosis Code Pointer
        /// </summary>
        [DataMember]
        [StringLength(1, 2)]
        [DataElement("1328", typeof(X12_N0))]
        [Pos(3)]
        public string DiagnosisCodePointer_03 { get; set; }
        /// <summary>
        /// Diagnosis Code Pointer
        /// </summary>
        [DataMember]
        [StringLength(1, 2)]
        [DataElement("1328", typeof(X12_N0))]
        [Pos(4)]
        public string DiagnosisCodePointer_04 { get; set; }
    }
    
    /// <summary>
    /// Tooth Surface
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C005")]
    public class C005_ToothSurface : IC005
    {
        
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1369", typeof(X12_ID_1369))]
        [Pos(1)]
        public string ToothSurfaceCode_01 { get; set; }
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [DataElement("1369", typeof(X12_ID_1369))]
        [Pos(2)]
        public string ToothSurfaceCode_02 { get; set; }
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [DataElement("1369", typeof(X12_ID_1369))]
        [Pos(3)]
        public string ToothSurfaceCode_03 { get; set; }
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [DataElement("1369", typeof(X12_ID_1369))]
        [Pos(4)]
        public string ToothSurfaceCode_04 { get; set; }
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [DataElement("1369", typeof(X12_ID_1369))]
        [Pos(5)]
        public string ToothSurfaceCode_05 { get; set; }
    }
    
    /// <summary>
    /// Tooth Surface
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C005")]
    public class C005_ToothSurface_2 : IC005
    {
        
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1369", typeof(X12_ID_1369_2))]
        [Pos(1)]
        public string ToothSurfaceCode_01 { get; set; }
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [DataElement("1369", typeof(X12_ID_1369_2))]
        [Pos(2)]
        public string ToothSurfaceCode_02 { get; set; }
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [DataElement("1369", typeof(X12_ID_1369_2))]
        [Pos(3)]
        public string ToothSurfaceCode_03 { get; set; }
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [DataElement("1369", typeof(X12_ID_1369_2))]
        [Pos(4)]
        public string ToothSurfaceCode_04 { get; set; }
        /// <summary>
        /// Tooth Surface Code
        /// </summary>
        [DataMember]
        [DataElement("1369", typeof(X12_ID_1369_2))]
        [Pos(5)]
        public string ToothSurfaceCode_05 { get; set; }
    }
    
    /// <summary>
    /// Oral Cavity Designation
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C006")]
    public class C006_OralCavityDesignation : IC006
    {
        
        /// <summary>
        /// Oral Cavity Designation Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 3)]
        [DataElement("1361", typeof(X12_AN))]
        [Pos(1)]
        public string OralCavityDesignationCode_01 { get; set; }
        /// <summary>
        /// Oral Cavity Designation Code
        /// </summary>
        [DataMember]
        [StringLength(1, 3)]
        [DataElement("1361", typeof(X12_AN))]
        [Pos(2)]
        public string OralCavityDesignationCode_02 { get; set; }
        /// <summary>
        /// Oral Cavity Designation Code
        /// </summary>
        [DataMember]
        [StringLength(1, 3)]
        [DataElement("1361", typeof(X12_AN))]
        [Pos(3)]
        public string OralCavityDesignationCode_03 { get; set; }
        /// <summary>
        /// Oral Cavity Designation Code
        /// </summary>
        [DataMember]
        [StringLength(1, 3)]
        [DataElement("1361", typeof(X12_AN))]
        [Pos(4)]
        public string OralCavityDesignationCode_04 { get; set; }
        /// <summary>
        /// Oral Cavity Designation Code
        /// </summary>
        [DataMember]
        [StringLength(1, 3)]
        [DataElement("1361", typeof(X12_AN))]
        [Pos(5)]
        public string OralCavityDesignationCode_05 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_28))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_10 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_13))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_11 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_14))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_12 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_20))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_13 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_4))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_14 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_18))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_15 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_23))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_16 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_5))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_17 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_19))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_18 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_22))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_19 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_32))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_10))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_12))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_2 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_33))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_10))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_12))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_20 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_12))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_6))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_21 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_24))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_22 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_26))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_6))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_23 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_27))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_6))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_24 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_31))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_10))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_12))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_25 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_8))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_6))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_3 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_17))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_6))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_4 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_11))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_5 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_3))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_6 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_2_obj))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [Required]
        [DataElement("1250", typeof(X12_ID_1250_6))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_7 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_3_Obj))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_8 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_6))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Code Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C022")]
    public class C022_HealthCareCodeInformation_9 : IC022
    {
        
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1270", typeof(X12_ID_1270_21))]
        [Pos(1)]
        public string CodeListQualifierCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string IndustryCode_02 { get; set; }
        /// <summary>
        /// Date Time Period Format Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("1250", typeof(X12_ID_1250_obj))]
        [Pos(3)]
        public string DateTimePeriodFormatQualifier_03 { get; set; }
        /// <summary>
        /// Date Time Period
        /// </summary>
        [DataMember]
        [StringLength(1, 35)]
        [DataElement("1251", typeof(X12_AN))]
        [Pos(4)]
        public string DateTimePeriod_04 { get; set; }
        /// <summary>
        /// Monetary Amount
        /// </summary>
        [DataMember]
        [StringLength(1, 18)]
        [DataElement("782", typeof(X12_R))]
        [Pos(5)]
        public string MonetaryAmount_05 { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember]
        [StringLength(1, 15)]
        [DataElement("380", typeof(X12_R))]
        [Pos(6)]
        public string Quantity_06 { get; set; }
        /// <summary>
        /// Version Identifier
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("799", typeof(X12_AN))]
        [Pos(7)]
        public string VersionIdentifier_07 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Exclusion(9)]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(8)]
        public string IndustryCode_08 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(9)]
        public string YesNoConditionorResponseCode_09 { get; set; }
    }
    
    /// <summary>
    /// Health Care Service Location Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C023")]
    public class C023_HealthCareServiceLocationInformation : IC023
    {
        
        /// <summary>
        /// Facility Code Value
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 2)]
        [DataElement("1331", typeof(X12_AN))]
        [Pos(1)]
        public string FacilityTypeCode_01 { get; set; }
        /// <summary>
        /// Facility Code Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1332", typeof(X12_ID_1332))]
        [Pos(2)]
        public string FacilityCodeQualifier_02 { get; set; }
        /// <summary>
        /// Claim Frequency Type Code
        /// </summary>
        [DataMember]
        [StringLength(1, 1)]
        [DataElement("1325", typeof(X12_AN))]
        [Pos(3)]
        public string ClaimFrequencyTypeCode_03 { get; set; }
    }
    
    /// <summary>
    /// Health Care Service Location Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C023")]
    public class C023_HealthCareServiceLocationInformation_2 : IC023
    {
        
        /// <summary>
        /// Facility Code Value
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 2)]
        [DataElement("1331", typeof(X12_AN))]
        [Pos(1)]
        public string FacilityTypeCode_01 { get; set; }
        /// <summary>
        /// Facility Code Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1332", typeof(X12_ID_1332_2))]
        [Pos(2)]
        public string FacilityCodeQualifier_02 { get; set; }
        /// <summary>
        /// Claim Frequency Type Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 1)]
        [DataElement("1325", typeof(X12_AN))]
        [Pos(3)]
        public string ClaimFrequencyTypeCode_03 { get; set; }
    }
    
    /// <summary>
    /// Health Care Service Location Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C023")]
    public class C023_HealthCareServiceLocationInformation_3 : IC023
    {
        
        /// <summary>
        /// Facility Code Value
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 2)]
        [DataElement("1331", typeof(X12_AN))]
        [Pos(1)]
        public string FacilityTypeCode_01 { get; set; }
        /// <summary>
        /// Facility Code Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1332", typeof(X12_ID_1332_3))]
        [Pos(2)]
        public string FacilityCodeQualifier_02 { get; set; }
        /// <summary>
        /// Claim Frequency Type Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 1)]
        [DataElement("1325", typeof(X12_AN))]
        [Pos(3)]
        public string ClaimFrequencyTypeCode_03 { get; set; }
    }
    
    /// <summary>
    /// Health Care Service Location Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C023")]
    public class C023_HealthCareServiceLocationInformation_4 : IC023
    {
        
        /// <summary>
        /// Facility Code Value
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 2)]
        [DataElement("1331", typeof(X12_AN))]
        [Pos(1)]
        public string FacilityTypeCode_01 { get; set; }
        /// <summary>
        /// Facility Code Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1332", typeof(X12_ID_1332_4))]
        [Pos(2)]
        public string FacilityCodeQualifier_02 { get; set; }
        /// <summary>
        /// Claim Frequency Type Code
        /// </summary>
        [DataMember]
        [StringLength(1, 1)]
        [DataElement("1325", typeof(X12_AN))]
        [Pos(3)]
        public string ClaimFrequencyTypeCode_03 { get; set; }
    }
    
    /// <summary>
    /// Related Causes Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C024")]
    public class C024_RelatedCausesInformation : IC024
    {
        
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1362", typeof(X12_ID_1362_5))]
        [Pos(1)]
        public string RelatedCausesCode_01 { get; set; }
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [DataElement("1362", typeof(X12_ID_1362_5))]
        [Pos(2)]
        public string RelatedCausesCode_02 { get; set; }
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [DataElement("1362", typeof(X12_ID_1362_5))]
        [Pos(3)]
        public string RelatedCausesCode_03 { get; set; }
        /// <summary>
        /// State or Province Code
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("156", typeof(X12_AN))]
        [Pos(4)]
        public string StateorProvinceCode_04 { get; set; }
        /// <summary>
        /// Country Code
        /// </summary>
        [DataMember]
        [StringLength(2, 3)]
        [DataElement("26", typeof(X12_AN))]
        [Pos(5)]
        public string CountryCode_05 { get; set; }
    }
    
    /// <summary>
    /// Related Causes Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C024")]
    public class C024_RelatedCausesInformation_2 : IC024
    {
        
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1362", typeof(X12_ID_1362))]
        [Pos(1)]
        public string RelatedCausesCode_01 { get; set; }
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [DataElement("1362", typeof(X12_ID_1362))]
        [Pos(2)]
        public string RelatedCausesCode_02 { get; set; }
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [DataElement("1362", typeof(X12_ID_1362))]
        [Pos(3)]
        public string RelatedCausesCode_03 { get; set; }
        /// <summary>
        /// State or Province Code
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("156", typeof(X12_AN))]
        [Pos(4)]
        public string StateorProvinceCode_04 { get; set; }
        /// <summary>
        /// Country Code
        /// </summary>
        [DataMember]
        [StringLength(2, 3)]
        [DataElement("26", typeof(X12_AN))]
        [Pos(5)]
        public string CountryCode_05 { get; set; }
    }
    
    /// <summary>
    /// Related Causes Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C024")]
    public class C024_RelatedCausesInformation_3 : IC024
    {
        
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1362", typeof(X12_ID_1362_2))]
        [Pos(1)]
        public string RelatedCausesCode_01 { get; set; }
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [DataElement("1362", typeof(X12_ID_1362_2))]
        [Pos(2)]
        public string RelatedCausesCode_02 { get; set; }
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [DataElement("1362", typeof(X12_ID_1362))]
        [Pos(3)]
        public string RelatedCausesCode_03 { get; set; }
        /// <summary>
        /// State or Province Code
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("156", typeof(X12_AN))]
        [Pos(4)]
        public string StateorProvinceCode_04 { get; set; }
        /// <summary>
        /// Country Code
        /// </summary>
        [DataMember]
        [StringLength(2, 3)]
        [DataElement("26", typeof(X12_AN))]
        [Pos(5)]
        public string CountryCode_05 { get; set; }
    }
    
    /// <summary>
    /// Related Causes Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C024")]
    public class C024_RelatedCausesInformation_4 : IC024
    {
        
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1362", typeof(X12_ID_1362_6))]
        [Pos(1)]
        public string RelatedCausesCode_01 { get; set; }
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [DataElement("1362", typeof(X12_ID_1362_3))]
        [Pos(2)]
        public string RelatedCausesCode_02 { get; set; }
        /// <summary>
        /// Related-Causes Code
        /// </summary>
        [DataMember]
        [DataElement("1362", typeof(X12_ID_1362_4))]
        [Pos(3)]
        public string RelatedCausesCode_03 { get; set; }
        /// <summary>
        /// State or Province Code
        /// </summary>
        [DataMember]
        [StringLength(2, 2)]
        [DataElement("156", typeof(X12_AN))]
        [Pos(4)]
        public string StateorProvinceCode_04 { get; set; }
        /// <summary>
        /// Country Code
        /// </summary>
        [DataMember]
        [StringLength(2, 3)]
        [DataElement("26", typeof(X12_AN))]
        [Pos(5)]
        public string CountryCode_05 { get; set; }
    }
    
    /// <summary>
    /// Provider Specialty Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C035")]
    public class C035_ProviderSpecialtyInformation : IC035
    {
        
        /// <summary>
        /// Provider Specialty Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1222", typeof(X12_ID_1222))]
        [Pos(1)]
        public string ProviderSpecialtyCode_01 { get; set; }
        /// <summary>
        /// Agency Qualifier Code
        /// </summary>
        [DataMember]
        [DataElement("559", typeof(X12_ID_559))]
        [Pos(2)]
        public string AgencyQualifierCode_02 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_2))]
        [Pos(3)]
        public string YesNoConditionorResponseCode_03 { get; set; }
    }
    
    /// <summary>
    /// Provider Specialty Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C035")]
    public class C035_ProviderSpecialtyInformation_2 : IC035
    {
        
        /// <summary>
        /// Provider Specialty Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1222", typeof(X12_ID_1222_2))]
        [Pos(1)]
        public string ProviderSpecialtyCode_01 { get; set; }
        /// <summary>
        /// Agency Qualifier Code
        /// </summary>
        [DataMember]
        [DataElement("559", typeof(X12_ID_559_2))]
        [Pos(2)]
        public string AgencyQualifierCode_02 { get; set; }
        /// <summary>
        /// Yes/No Condition or Response Code
        /// </summary>
        [DataMember]
        [DataElement("1073", typeof(X12_ID_1073_12))]
        [Pos(3)]
        public string YesNoConditionorResponseCode_03 { get; set; }
    }
    
    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040_ReferenceIdentifier : IC040
    {
        
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(6)]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }
    
    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040_ReferenceIdentifier_2 : IC040
    {
        
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("128", typeof(X12_ID_128_87))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("128", typeof(X12_ID_128_87))]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(6)]
        [DataElement("128", typeof(X12_ID_128_87))]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }
    
    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040_ReferenceIdentifier_3 : IC040
    {
        
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("128", typeof(X12_ID_128_27))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(6)]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }
    
    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040_ReferenceIdentifier_4 : IC040
    {
        
        [DataMember]
        [DataElement("", typeof(X12_ID_128_20))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        [DataMember]
        [Paired(0)]
        [DataElement("", typeof(X12_ID_128_20))]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        [DataMember]
        [Paired(6)]
        [DataElement("", typeof(X12_ID_128_20))]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }
    
    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040_ReferenceIdentifier_5 : IC040
    {
        
        [DataMember]
        [DataElement("", typeof(X12_ID_128_20))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        [DataMember]
        [Paired(4)]
        [DataElement("", typeof(X12_ID_128_20))]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        [DataMember]
        [Paired(6)]
        [DataElement("", typeof(X12_ID_128_20))]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("", typeof(X12_AN))]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }
    
    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040_ReferenceIdentifier_6 : IC040
    {
        
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("128", typeof(X12_ID_128_27))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [Required]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(6)]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }
    
    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040_ReferenceIdentifier_7 : IC040
    {
        
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("128", typeof(X12_ID_128_20))]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }
    
    /// <summary>
    /// Reference Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C040")]
    public class C040_ReferenceIdentifier_8 : IC040
    {
        
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("128", typeof(X12_ID_128_94))]
        [Pos(1)]
        public string ReferenceIdentificationQualifier_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(2)]
        public string ReferenceIdentification_02 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(4)]
        [DataElement("128", typeof(X12_ID_128_94))]
        [Pos(3)]
        public string ReferenceIdentificationQualifier_03 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(4)]
        public string ReferenceIdentification_04 { get; set; }
        /// <summary>
        /// Reference Identification Qualifier
        /// </summary>
        [DataMember]
        [Paired(6)]
        [DataElement("128", typeof(X12_ID_128_94))]
        [Pos(5)]
        public string ReferenceIdentificationQualifier_05 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(6)]
        public string ReferenceIdentification_06 { get; set; }
    }
    
    /// <summary>
    /// Adjustment Identifier
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C042")]
    public class C042_AdjustmentIdentifier : IC042
    {
        
        /// <summary>
        /// Adjustment Reason Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("426", typeof(X12_ID_426_5))]
        [Pos(1)]
        public string AdjustmentReasonCode_01 { get; set; }
        /// <summary>
        /// Reference Identification
        /// </summary>
        [DataMember]
        [StringLength(1, 50)]
        [DataElement("127", typeof(X12_AN))]
        [Pos(2)]
        public string ProviderAdjustmentIdentifier_02 { get; set; }
    }
    
    /// <summary>
    /// Health Care Claim Status
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C043")]
    public class C043_HealthCareClaimStatus : IC043
    {
        
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string StatusCode_02 { get; set; }
        /// <summary>
        /// Entity Identifier Code
        /// </summary>
        [DataMember]
        [DataElement("98", typeof(X12_ID_98_42))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [DataElement("1270", typeof(X12_ID_1270_7))]
        [Pos(4)]
        public string CodeListQualifierCode_04 { get; set; }
    }
    
    /// <summary>
    /// Health Care Claim Status
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C043")]
    public class C043_HealthCareClaimStatus_2 : IC043
    {
        
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string StatusCode_02 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_98_46))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_1270_28))]
        [Pos(4)]
        public string CodeListQualifierCode_04 { get; set; }
    }
    
    /// <summary>
    /// Health Care Claim Status
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C043")]
    public class C043_HealthCareClaimStatus_3 : IC043
    {
        
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string StatusCode_02 { get; set; }
        /// <summary>
        /// Entity Identifier Code
        /// </summary>
        [DataMember]
        [DataElement("98", typeof(X12_ID_98_27))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [DataElement("1270", typeof(X12_ID_1270_28))]
        [Pos(4)]
        public string CodeListQualifierCode_04 { get; set; }
    }
    
    /// <summary>
    /// Health Care Claim Status
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C043")]
    public class C043_HealthCareClaimStatus_4 : IC043
    {
        
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string StatusCode_02 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_98_28))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_1270_28))]
        [Pos(4)]
        public string CodeListQualifierCode_04 { get; set; }
    }
    
    /// <summary>
    /// Health Care Claim Status
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C043")]
    public class C043_HealthCareClaimStatus_5 : IC043
    {
        
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(2)]
        public string StatusCode_02 { get; set; }
        /// <summary>
        /// Entity Identifier Code
        /// </summary>
        [DataMember]
        [DataElement("98", typeof(X12_ID_98_12_obj))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [DataElement("1270", typeof(X12_ID_1270_28))]
        [Pos(4)]
        public string CodeListQualifierCode_04 { get; set; }
    }
    
    /// <summary>
    /// Health Care Claim Status
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C043")]
    public class C043_HealthCareClaimStatus_6 : IC043
    {
        
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(1)]
        public string HealthCareClaimStatusCategoryCode_01 { get; set; }
        [DataMember]
        [Required]
        [StringLength(1, 30)]
        [DataElement("", typeof(X12_AN))]
        [Pos(2)]
        public string StatusCode_02 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_98_37))]
        [Pos(3)]
        public string EntityIdentifierCode_03 { get; set; }
        [DataMember]
        [DataElement("", typeof(X12_ID_1270_28))]
        [Pos(4)]
        public string CodeListQualifierCode_04 { get; set; }
    }
    
    /// <summary>
    /// Medicare Status Code
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C052")]
    public class C052_MedicareStatusCode : IC052
    {
        
        /// <summary>
        /// Medicare Plan Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1218", typeof(X12_ID_1218))]
        [Pos(1)]
        public string MedicarePlanCode_01 { get; set; }
        /// <summary>
        /// Eligibility Reason Code
        /// </summary>
        [DataMember]
        [DataElement("1701", typeof(X12_ID_1701))]
        [Pos(2)]
        public string EligibilityReasonCode_02 { get; set; }
        /// <summary>
        /// Eligibility Reason Code
        /// </summary>
        [DataMember]
        [DataElement("1701", typeof(X12_ID_1701))]
        [Pos(3)]
        public string EligibilityReasonCode_03 { get; set; }
        /// <summary>
        /// Eligibility Reason Code
        /// </summary>
        [DataMember]
        [DataElement("1701", typeof(X12_ID_1701))]
        [Pos(4)]
        public string EligibilityReasonCode_04 { get; set; }
    }
    
    /// <summary>
    /// Medicare Status Code
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C052")]
    public class C052_MedicareStatusCode_2 : IC052
    {
        
        /// <summary>
        /// Medicare Plan Code
        /// </summary>
        [DataMember]
        [Required]
        [DataElement("1218", typeof(X12_ID_1218_2))]
        [Pos(1)]
        public string MedicarePlanCode_01 { get; set; }
        /// <summary>
        /// Eligibility Reason Code
        /// </summary>
        [DataMember]
        [DataElement("1701", typeof(X12_ID_1701_2))]
        [Pos(2)]
        public string EligibilityReasonCode_02 { get; set; }
        /// <summary>
        /// Eligibility Reason Code
        /// </summary>
        [DataMember]
        [DataElement("1701", typeof(X12_ID_1701_2))]
        [Pos(3)]
        public string EligibilityReasonCode_03 { get; set; }
        /// <summary>
        /// Eligibility Reason Code
        /// </summary>
        [DataMember]
        [DataElement("1701", typeof(X12_ID_1701_2))]
        [Pos(4)]
        public string EligibilityReasonCode_04 { get; set; }
    }
    
    /// <summary>
    /// Composite Race or Ethnicity Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C056")]
    public class C056_CompositeRaceorEthnicityInformation : IC056
    {
        
        /// <summary>
        /// Race or Ethnicity Code
        /// </summary>
        [DataMember]
        [DataElement("1109", typeof(X12_ID_1109))]
        [Pos(1)]
        public string RaceorEthnicityCode_01 { get; set; }
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Paired(3)]
        [DataElement("1270", typeof(X12_ID_1270_28))]
        [Pos(2)]
        public string CodeListQualifierCode_02 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(3)]
        public string IndustryCode_03 { get; set; }
    }
    
    /// <summary>
    /// Composite Race or Ethnicity Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C056")]
    public class C056_CompositeRaceorEthnicityInformation_2 : IC056
    {
        
        /// <summary>
        /// Race or Ethnicity Code
        /// </summary>
        [DataMember]
        [DataElement("1109", typeof(X12_ID_1109_3))]
        [Pos(1)]
        public string RaceorEthnicityCode_01 { get; set; }
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Paired(3)]
        [DataElement("1270", typeof(X12_ID_1270_35))]
        [Pos(2)]
        public string CodeListQualifierCode_02 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(3)]
        public string IndustryCode_03 { get; set; }
    }
    
    /// <summary>
    /// Composite Race or Ethnicity Information
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Composite("C056")]
    public class C056_CompositeRaceorEthnicityInformation_3 : IC056
    {
        
        /// <summary>
        /// Race or Ethnicity Code
        /// </summary>
        [DataMember]
        [DataElement("1109", typeof(X12_ID_1109_2))]
        [Pos(1)]
        public string RaceorEthnicityCode_01 { get; set; }
        /// <summary>
        /// Code List Qualifier Code
        /// </summary>
        [DataMember]
        [Paired(3)]
        [DataElement("1270", typeof(X12_ID_1270_29))]
        [Pos(2)]
        public string CodeListQualifierCode_02 { get; set; }
        /// <summary>
        /// Industry Code
        /// </summary>
        [DataMember]
        [StringLength(1, 30)]
        [DataElement("1271", typeof(X12_AN))]
        [Pos(3)]
        public string IndustryCode_03 { get; set; }
    }
}
