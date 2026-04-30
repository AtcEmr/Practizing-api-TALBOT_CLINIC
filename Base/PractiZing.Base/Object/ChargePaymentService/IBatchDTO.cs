using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IBatchDTO
    {
        string BatchNo { get; set; }
        DateTime BatchDate { get; set; }
        decimal Amount { get; set; }
        int RecordCount { get; set; }
        int PostedChargesCount { get; set; }
        decimal PostedChargesValue { get; set; }
        decimal Difference { get; }
        int Id { get; set; }
        decimal BatchAmount { get; set; }
        string CPTCode { get; set; }
        bool? Active { get; set; }
        Int16 Qty { get; set; }
        bool MultiplyQty { get; set; }
        Guid UId { get; set; }
        string CreatedBy { get; set; }
    }
}
