using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class VoucherFilter : IVoucherFilter
    {
        //private string _depositTypeIds;
        //private string _paymentSourceCD;
        //private string _isCommitted;
        [SearchField(Name = VoucherModel.DepositTypeId)]
        public string DepositTypeIds { get; set; }
        //{
        //    get
        //    {
        //        return this.DepositTypeIds == "null" ? null : this.DepositTypeIds;
        //    }
        //    set
        //    {
        //        this._depositTypeIds = value == this.DepositTypeIds ? this.DepositTypeIds : value;
        //    }
        //}
        [SearchField(Name = VoucherModel.EffectiveDate)]
        public string FromDate { get; set; }
        [SearchField(Name = VoucherModel.EffectiveDate)]
        public string ToDate { get; set; }
        [SearchField(Name = VoucherModel.IsCommitted)]
        public string IsCommitted { get; set; }
        //{
        //    get
        //    {
        //        return this.IsCommitted == "null" ? null : this.IsCommitted;
        //    }
        //    set
        //    {
        //        this._isCommitted = value == this.IsCommitted ? this.IsCommitted : value;
        //    }
        //}
        [SearchField(Name = VoucherFilterModel.PaymentSourceCD)]
        public string PaymentSourceCD { get; set; }
        //{
        //    get
        //    {
        //        return this.PaymentSourceCD == "null" ? null : this.PaymentSourceCD;
        //    }
        //    set
        //    {
        //        this._paymentSourceCD = value == this.PaymentSourceCD ? this.PaymentSourceCD : value;
        //    }
        //}

        public int? DifferenceId { get; set; }
    }

    public class VoucherModel
    {
        public const string TableName = "Voucher";
        public const string PaymentSourceCD = TableName + "." + "PaymentSourceCD";
        public const string DepositTypeId = TableName + "." + "DepositTypeId";
        public const string EffectiveDate = TableName + "." + "EffectiveDate";
        public const string IsCommitted = TableName + "." + "IsCommitted";
    }
}
