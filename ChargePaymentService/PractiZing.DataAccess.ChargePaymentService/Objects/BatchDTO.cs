using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class BatchDTO : IBatchDTO
    {
        public string BatchNo { get; set; }
        public DateTime BatchDate { get; set; }
        public decimal BatchAmount { get; set; }
        public int RecordCount { get; set; }
        public int PostedChargesCount { get; set; }
        public decimal PostedChargesValue { get; set; }
        public string CPTCode { get; set; }
        public int Id { get; set; }
        public bool? Active { get; set; }
        public decimal Amount { get; set; }
        public bool MultiplyQty { get; set; }
        public Int16 Qty { get; set; }
        public string CreatedBy { get; set; }
        public Guid UId { get; set; }

        [Ignore]
        public decimal Difference
        {
            get
            {
                return (BatchAmount - PostedChargesValue);
            }
        }
    }
}
