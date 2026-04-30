using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class CPTFeeDTO : ICPTFeeDTO
    {
        public int SerialNo { get; set; }
        public string CPTCode { get; set; }
        public List<string> Modifiers { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
    }
}
