using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IPaymentDTO
    {
        int PatientId { get; set; }
        string PatientName { get; set; }
        decimal TotalChargeAmount { get; set; }
        decimal TotalCrChargeAmount { get; set; }
        decimal TotalDrChargeAmount { get; set; }
        decimal TotalAdjustmentAmount { get; set; }
        decimal PatientResponsibility { get; set; }
        decimal  NonAccAdjustment { get; set; }
        decimal BonusAmount { get; set; }
        decimal DifferenceAmount { get; set; }
        int VoucherId { get; set; }
        int PaymentId { get; set; }
        decimal PaidAmount { get; set; }
        bool IsReversed { get; set; }
        bool IsCommitted { get; set; }
        IEnumerable<IPaymentChargeDTO> ChargeDTOs { get; set; }
        IVoucher Voucher { get; set; }
        Guid VoucherUId { get; set; }
        Guid PatientUId { get; set; }
        Guid PatientCaseUId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
