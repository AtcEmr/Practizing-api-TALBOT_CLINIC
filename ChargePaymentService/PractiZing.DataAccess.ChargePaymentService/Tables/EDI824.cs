using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class EDI824: IEDI824
    {
        [Key]
        [AutoIncrement]
        public Int64 Id { get; set; }
        public string ClearingHouseTransactionNo { get; set; }
        public string PayerCode { get; set; }
        public string ClaimBatchNumber { get; set; }
        public string ClaimTransactionNumber { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string PracticeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public short? IsFound { get; set; }
        public string Note { get; set; }
    }
}
