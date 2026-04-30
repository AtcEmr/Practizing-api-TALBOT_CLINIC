using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class VoucherDTO : IVoucherDTO
    {

        public VoucherDTO()
        {
            this.PaymentDTOs = new List<PaymentDTO>();
            this.Voucher = new Voucher();
        }

        public string BatchNumber { get; set; }
        public Int16 DepositTypeId { get; set; }
        public DateTime DepositDate { get; set; }
        public string PayeeName { get; set; }
        public decimal PostedAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public int PatientId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public bool IsCommitted { get; set; }
        public decimal DifferenceAmount { get; set; }
        public string CheckRefNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PaymentBatchId { get; set; }
        public int VoucherId { get; set; }
        public bool IsSelfPayment { get; set; }
        public bool IsReversed { get; set; }
        public Guid VoucherGUId { get; set; }
        public Guid PatientUID { get; set; }
        public bool? IsMatchedWithBank { get; set; }

        public IEnumerable<IPaymentDTO> PaymentDTOs { get; set; }
        [Ignore]
        public Guid PaymentBatchGUId { get; set; }
        [Ignore]
        public Guid PatientCaseUID { get; set; }
        [Ignore]
        public IVoucher Voucher { get; set; }
        [Ignore]
        public string PaymentSourceCD { get; set; }
        [Ignore]
        public string FirstName { get; set; }
        [Ignore]
        public string LastName { get; set; }
        [Ignore]
        public string InsuranceCompanyName { get; set; }
        [Ignore]
        public decimal TotalPaidAmount { get; set; }
        [Ignore]
        public decimal PaymentBatchAmount { get; set; }
        [Ignore]
        public DateTime EffectiveDate { get; set; }
        [Ignore]
        public DateTime ReferenceDate { get; set; }
    }

    public class VoucherPlaidDTO: IVoucherPlaidDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Practice { get; set; }
    }

    public class VoucherPlaidUpdateDTO:IVoucherPlaidUpdateDTO
    {
        public int VoucherId { get; set; }
        public int PlaidPaymentId { get; set; }
    }
}
