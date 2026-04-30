using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IEDI824 
    {
        Int64 Id { get; set; }
        string ClaimBatchNumber { get; set; }
        string ClaimTransactionNumber { get; set; }
        string ErrorCode { get; set; }
        string ErrorDesc { get; set; }
        string PracticeName { get; set; }
        DateTime CreatedDate { get; set; }
        short? IsFound { get; set; }
        string Note { get; set; }
        string ClearingHouseTransactionNo { get; set; }
        string PayerCode { get; set; }
    }
}
