using PractiZing.Base.View.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.View
{
    [Alias("vw_Voucher")]
    public class VoucherViewDTO: IVoucherViewDTO
    {
        public string CompanyName { get; set; }
        public string CheckNumber { get; set; }
        public string DepositType { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal CheckAmount { get; set; }
        public decimal PostedAmount { get; set; }
        public int InsuranceCompanyId { get; set; }
    }
}
