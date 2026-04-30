using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class BulkPaymentScreenDTO : IBulkPaymentScreenDTO
    {

        public BulkPaymentScreenDTO()
        {
            this.Vouchers = new List<VoucherDTO>();
            this.AttFiles = new List<AttFile>();
        }

        public int PaymentBatchId { get; set; }
        public DateTime BatchDate { get; set; }
        public string BatchNo { get; set; }
        public int DepositTypeId { get; set; }
        public decimal BatchAmount { get; set; }
        public decimal PostedAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public int PatientId { get; set; }
        public decimal DifferenceAmount { get; set; }
        public string CreatedBy { get; set; }
        public bool IsChanged { get; set; }
        public bool IsReversed { get; set; }
        public bool IsNewPayment { get; set; }
        public int PaymentId { get; set; }
        public Guid PaymentBatchUId { get; set; }

        public IEnumerable<IVoucherDTO> Vouchers { get; set; }
        public IEnumerable<IAttFile> AttFiles { get; set; }
    }

    public class BalanceAdjustmentModel: IBalanceAdjustmentModel
    {
        public BalanceAdjustmentModel()
        {
            InvCharges = new List<PostedBalanceCharges>();            
        }
        public Guid PatientUId { get; set; }
        public string ReasonCode { get; set; }
        public string AdjustmentType { get; set; }
        public IEnumerable<IPostedBalanceCharges> InvCharges { get; set; }
    }

    public class PostedBalanceCharges: IPostedBalanceCharges
    {
        public int Id { get; set; }
        public Guid InvoiceUId { get; set; }
        public Guid ChargeUId { get; set; }
        public decimal PostedAmount { get; set; }
    }

    public class BalanceCharge: IBalanceCharge
    {
        public int Id { get; set; }
        public string AccessionNumber { get; set; }
        public DateTime Dos { get; set; }
        public string CptCode { get; set; }
        public decimal Amount { get; set; }
        public decimal DueAmount { get; set; }
        public string ChargeUId { get; set; }
        public string InvoiceUId { get; set; }

    }
}
