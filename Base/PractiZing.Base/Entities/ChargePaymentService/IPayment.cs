using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPayment : IStamp, IUniqueIdentifier
    {
        int Id { get; set; }
        int VoucherId { get; set; }
        int TransactionNo { get; set; }
        int PatientId { get; set; }
        bool IsCommitted { get; set; }
        decimal Amount { get; set; }
        decimal Adjustment { get; set; }
        string PaymentSourceCD { get; set; }
        int? DepositInsuranceCompanyId { get; set; }
        int PatientInsuranceCompanyId { get; set; }
        decimal NonAccAdjustment { get; set; }
        bool IsReversed { get; set; }
        string PayorControl { get; set; }

        IEnumerable<IPaymentCharge> PaymentCharges { get; set; }
        IEnumerable<IPaymentAdjustment> PaymentAdjustments { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PatientName { get; }
        Guid? DepositInsuranceCompanyUId { get; set; }

        Guid PatientInsuranceCompanyUId { get; set; }
        bool? IsSendAck { get; set; }
        string DeleteComments { get; set; }
        string PatientControlNumber { get; set; }
    }
}
