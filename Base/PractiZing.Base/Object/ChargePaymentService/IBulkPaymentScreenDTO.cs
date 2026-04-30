using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IBulkPaymentScreenDTO
    {
        int PaymentBatchId { get; set; }
        DateTime BatchDate { get; set; }
        string BatchNo { get; set; }
        int DepositTypeId { get; set; }
        decimal BatchAmount { get; set; }
        decimal PostedAmount { get; set; }
        decimal DepositAmount { get; set; }
        int PatientId { get; set; }
        decimal DifferenceAmount { get; set; }
        string CreatedBy { get; set; }
        bool IsChanged { get; set; }
        bool IsReversed { get; set; }
        bool IsNewPayment { get; set; }
        int PaymentId { get; set; }

        IEnumerable<IVoucherDTO> Vouchers { get; set; }
        IEnumerable<IAttFile> AttFiles { get; set; }
    }

    public interface IBalanceAdjustmentModel
    {
        Guid PatientUId { get; set; }        
        string ReasonCode { get; set; }
        string AdjustmentType { get; set; }
        IEnumerable<IPostedBalanceCharges> InvCharges { get; set; }
    }

    public interface IPostedBalanceCharges
    {
        int Id { get; set; }
        Guid InvoiceUId { get; set; }
        Guid ChargeUId { get; set; }
        decimal PostedAmount { get; set; }
    }

    public interface IBalanceCharge
    {
        int Id { get; set; }
        string AccessionNumber { get; set; }
        DateTime Dos { get; set; }
        string CptCode { get; set; }
        decimal Amount { get; set; }
        decimal DueAmount { get; set; }
        string ChargeUId { get; set; }
        string InvoiceUId { get; set; }
    }
}
