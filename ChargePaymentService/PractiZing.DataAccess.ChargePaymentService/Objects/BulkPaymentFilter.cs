using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class BulkPaymentFilter : BaseSearchModel, IBulkPaymentFilter
    {
        [SearchField(Name = VoucherFilterModel.CreatedDate)]
        public string FromDate { get; set; }
        [SearchField(Name = VoucherFilterModel.CreatedDate)]
        public string ToDate { get; set; }
        [SearchField(Name = VoucherFilterModel.DepositTypeId)]
        public string DepositTypeIds { get; set; }
        [SearchField(Name = VoucherFilterModel.IsCommitted)]
        public string IsCommitted { get; set; }
        [SearchField(Name = VoucherFilterModel.PaymentSourceCD)]
        public string PaymentSourceCD { get; set; }
        public int? DifferenceId { get; set; }
        [SearchField(Name = PaymentClaimBatchFilter.BatchDate)]
        public string BatchFromDate { get; set; }
        [SearchField(Name = PaymentClaimBatchFilter.BatchDate)]
        public string BatchToDate { get; set; }
        public string DepositTypeUIds { get; set; }
        public Guid? VoucherUId { get; set; }
    }

    public class VoucherFilterModel
    {
        public const string TableName = "Voucher";
        public const string CreatedDate = TableName + "." + "CreatedDate";
        public const string DepositTypeId = TableName + "." + "DepositTypeId";
        public const string IsCommitted = TableName + "." + "IsCommitted";
        public const string PaymentSourceCD = TableName + "." + "PaymentSourceCD";
    }

    public class PaymentClaimBatchFilter
    {
        public const string TableName = "PaymentBatch";
        public const string BatchDate = TableName + "." + "CreatedDate";
    }

    public class PaymentFilterModel
    {
        public const string TableName = "Payment";
        public const string IsCommitted = TableName + "." + "IsCommitted";
        public const string PaymentSourceCD = TableName + "." + "PaymentSourceCD";
    }
}
