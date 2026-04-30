using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IVoucher : IModifiedStamp, IUniqueIdentifier
    {
        int Id { get; set; }
        int PracticeId { get; set; }
        int PaymentBatchId { get; set; }
        int VoucherNo { get; set; }
        string VoucherTypeCD { get; set; }
        string PaymentSourceCD { get; set; }
        Int16 DepositTypeId { get; set; }
        decimal Amount { get; set; }
        string Description { get; set; }
        DateTime EffectiveDate { get; set; }
        string ReferenceNo { get; set; }
        DateTime ReferenceDate { get; set; }
        bool IsSelfPayment { get; set; }
        int? PatientId { get; set; }
        // string PayorClaimControlNumber { get; set; }
        int? InsuranceCompanyId { get; set; }
        bool IsCommitted { get; set; }
        string InsuranceCompanyName { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        bool? IsMatchedWithBank { get; set; }
        

        IEnumerable<IPayment> Payments { get; set; }
        IEnumerable<IAttFile> AttFiles { get; set; }
        IEnumerable<int> PatientCaseId { get; set; }
        string PatientName { get; }
        string PatientFirstName { get; set; }
        string PatientLastName { get; set; }
        decimal TotalPaymentsInVoucher { get; set; }
        decimal TotalPaidAmountInVoucher { get; set; }
        decimal PaymentBatchAmount { get; set; }
        Guid DepositTypeUId { get; set; }
        Guid PatientCaseUId { get; set; }
        Guid PatientUId { get; set; }
        Guid PaymentBatchUId { get; set; }
        Guid DepositInsuranceCompanyUId { get; set; }
    }
}
