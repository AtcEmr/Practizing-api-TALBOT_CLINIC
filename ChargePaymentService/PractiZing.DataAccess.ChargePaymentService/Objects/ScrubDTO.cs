using PractiZing.Base.Object.ChargePaymentService;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ScrubDTO : IScrubDTO
    {
        public int ClaimId { get; set; }
        public int ClaimBatchId { get; set; }
        public int ProviderId { get; set; }
        public int FacilityId { get; set; }
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime BillFromDate { get; set; }
        public DateTime BillToDate { get; set; }
        public int ChargeNo { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public int PatientCaseId { get; set; }
        public int InvoiceId { get; set; }
        public bool IsTaxable { get; set; }
        public bool BillToInsurance { get; set; }
        public bool BillToPatient { get; set; }
        public bool BillToClinic { get; set; }
        public string CPTCode { get; set; }
        public string Mod1 { get; set; }
        public string Mod2 { get; set; }
        public string Mod3 { get; set; }
        public string Mod4 { get; set; }
        public string ICD1 { get; set; }
        public string ICD2 { get; set; }
        public string ICD3 { get; set; }
        public string ICD4 { get; set; }
        public string Description { get; set; }
        public string NDCCode { get; set; }
        public short NDCFormat { get; set; }
        public short? UnitOfMeasure { get; set; }
        public short? DrugQty { get; set; }
        public string TOSId { get; set; }
        public string POSId { get; set; }
        public short? PerformingProviderId { get; set; }
        public short? OrderingProviderId { get; set; }
        public short? PerformingFacilityId { get; set; }
        public short Qty { get; set; }
        public bool MultiplyQty { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal CoIns { get; set; }
        public decimal CoPay { get; set; }
        public decimal Deductible { get; set; }
        public string DueByFlagCD { get; set; }
        public string Comments { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string RefNumber { get; set; }
        public string EMG { get; set; }
        public decimal? AllowedAmount { get; set; }
        public int PracticeId { get; set; }
    }
}
