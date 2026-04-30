using System;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IChargeBatch : IPracticeDTO, IUniqueIdentifier, IStamp, IActive
    {
        int Id { get; set; }
        string BatchNo { get; set; }
        DateTime BatchDate { get; set; }
        decimal BatchAmount { get; set; }
        int RecordCount { get; set; }
        string CPTCode { get; set; }
        int PostedChargesCount { get; set; }
        decimal PostedChargesValue { get; set; }
        decimal Amount { get; set; }
    }
}


