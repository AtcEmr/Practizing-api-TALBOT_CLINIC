using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class VoucherViewFilter : IVoucherViewFilter
    {   
        [SearchField(Name = VoucherViewModel.EffectiveDate)]
        public string FromDate { get; set; }
        [SearchField(Name = VoucherViewModel.EffectiveDate)]
        public string ToDate { get; set; }
        [SearchField(Name = VoucherViewModel.InsuranceCompanyId)]
        public int? InsuranceCompanyId { get; set; }
    }

    public class VoucherViewModel
    {
        public const string TableName = "vw_Voucher";                
        public const string EffectiveDate = TableName + "." + "EffectiveDate";
        public const string InsuranceCompanyId = TableName + "." + "InsuranceCompanyId";
    }
}
