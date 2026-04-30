using PractiZing.Base.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.View.ChargePaymentService
{
    public interface IChargeViewDTO : IUniqueIdentifier, IPracticeDTO, IStamp
    {
        int Id { get; set; }
        DateTime EntryDate { get; set; }
        DateTime BillFromDate { get; set; }
        DateTime BillToDate { get; set; }
        int ChargeNo { get; set; }
        bool IsDeleted { get; set; }
        bool IsLocked { get; set; }
        int PatientCaseId { get; set; }
        int? InvoiceId { get; set; }
        bool IsTaxable { get; set; }
        bool BillToInsurance { get; set; }
        bool BillToPatient { get; set; }
        bool BillToClinic { get; set; }
        string CPTCode { get; set; }
        string Mod1 { get; set; }
        string Mod2 { get; set; }
        string Mod3 { get; set; }
        string Mod4 { get; set; }

        string ICD1 { get; set; }
        string ICD2 { get; set; }
        string ICD3 { get; set; }
        string ICD4 { get; set; }
        string Description { get; set; }
        string NDCCode { get; set; }
        Int16? NDCFormat { get; set; }
        Int16? UnitOfMeasure { get; set; }
        Int16? DrugQty { get; set; }
        Int16? TOSId { get; set; }
        Int16? POSId { get; set; }
        Int16? PerformingProviderId { get; set; }
        Int16? OrderingProviderId { get; set; }
        Int16? PerformingFacilityId { get; set; }
        Int16 Qty { get; set; }
        bool MultiplyQty { get; set; }
        decimal? Amount { get; set; }
        decimal? Discount { get; set; }
        decimal? Tax { get; set; }
        Int16? DueBy { get; set; }
        Int16? DueByFlagCD { get; set; }
        string Comments { get; set; }

        string Message1 { get; set; }
        string Message2 { get; set; }
        string RefNumber { get; set; }
        string EMG { get; set; }

        decimal DueAmount { get; set; }
        decimal ActualAmount { get; set; }
    }
}
