using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IScrubDTO
    {
        int ClaimId { get; set; }
        int ClaimBatchId { get; set; }
        int ProviderId { get; set; }
        int FacilityId { get; set; }
        int Id { get; set; }
        DateTime EntryDate { get; set; }
        DateTime BillFromDate { get; set; }
        DateTime BillToDate { get; set; }
        int ChargeNo { get; set; }
        bool IsDeleted { get; set; }
        bool IsLocked { get; set; }
        int PatientCaseId { get; set; }
        int InvoiceId { get; set; }
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
        short NDCFormat { get; set; }
        short? UnitOfMeasure { get; set; }
        short? DrugQty { get; set; }
        string TOSId { get; set; }
        string POSId { get; set; }
        short? PerformingProviderId { get; set; }
        short? OrderingProviderId { get; set; }
        short? PerformingFacilityId { get; set; }
        short Qty { get; set; }
        bool MultiplyQty { get; set; }
        decimal Amount { get; set; }
        decimal Discount { get; set; }
        decimal Tax { get; set; }
        decimal CoIns { get; set; }
        decimal CoPay { get; set; }
        decimal Deductible { get; set; }
        string DueByFlagCD { get; set; }
        string Comments { get; set; }
        string Message1 { get; set; }
        string Message2 { get; set; }
        string RefNumber { get; set; }
        string EMG { get; set; }
        decimal? AllowedAmount { get; set; }
        int PracticeId { get; set; }
    }
}
