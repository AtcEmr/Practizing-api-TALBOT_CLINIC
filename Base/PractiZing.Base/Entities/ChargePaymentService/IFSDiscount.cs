using System;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IFSDiscount : IStamp
    {
        Int16 Id { get; set; }
        Int16 FSChargeID { get; set; }
        Int16? ProviderId { get; set; }
        int? InsuranceCompanyId { get; set; }
        DateTime EffectiveDate { get; set; }
        decimal FacilityDiscount { get; set; }
        decimal NonFacilityDiscount { get; set; }
        bool IsActive { get; set; }
        bool IsFSDiscountDeleted { get; set; }
        Guid? ProviderUId { get; set; }
        Guid? InsuranceCompanyUId { get; set; }
        int? PractitionerServiceId { get; set; }
    }
}
