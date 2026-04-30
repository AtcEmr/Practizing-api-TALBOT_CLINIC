using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PayBatchFilter : IPayBatchFilter
    {
        //[SearchField(Name = VoucherTable.InsuranceCompanyId)]
        //public int? InsuranceCompanyId { get; set; }
        [SearchField(Name = PayBatchTable.BatchDate)]
        public string FromDate { get; set; }
        [SearchField(Name = PayBatchTable.BatchDate)]
        public string ToDate { get; set; }
        public string BatchStatus { get; set; }
    }

    public class PayBatchTable
    {
        public const string TableName1 = "PaymentBatch";
        public const string BatchDate = TableName1 + "." + "BatchDate";
        public const string DepositTypeId = TableName1 + "." + "DepositTypeId";
    }

    public class VoucherTable
    {
        public const string TableName1 = "Voucher";
        public const string InsuranceCompanyId = TableName1 + "." + "InsuranceCompanyId";
    }
}
