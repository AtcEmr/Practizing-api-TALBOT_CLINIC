using System;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IClaimTotal : IModifiedStamp
    {
        int Id { get; set; }
        int ClaimId { get; set; }
        Int16 PageNumber { get; set; }
        decimal? LabCharges { get; set; }
        decimal? TotalCharges { get; set; }
        decimal? AmountPaid { get; set; }
        decimal? BalanceDue { get; set; }
        bool OutsideLab { get; set; }
        string Reserved19 { get; set; }
        string MedicaidResubmissionCode { get; set; }
        string OriginalReferenceNumber { get; set; }
        Int16? NumKind { get; set; }
        string PriorAuthorizationNumber { get; set; }
        int? Flags { get; set; }
    }
}
