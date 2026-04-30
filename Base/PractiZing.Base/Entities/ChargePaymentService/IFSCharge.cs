using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IFSCharge : IStamp
    {
        Int16 Id { get; set; }
        Int16 FeeScheduleId { get; set; }
        Guid FeeScheduleUId { get; set; }
        string CPTCode { get; set; }
        string Modifier { get; set; }
        string Modifier2 { get; set; }
        string Modifier3 { get; set; }
        string Modifier4 { get; set; }
        decimal FacilityCharge { get; set; }
        decimal NonFacilityCharge { get; set; }
        bool IsFSChargeDeleted { get; set; }
        IEnumerable<IFSDiscount> FSDiscounts { get; set; }
        int? InsuranceCompayId { get; set; }
        string InsuranceCompanyName { get; set; }
        Guid? InsuranceCompayUId { get; set; }
        int? ProviderId { get; set; }
        Guid? ProviderUId { get; set; }
        string ProviderName { get; set; }
        decimal CommunityCharge { get; set; }
        int? QualificationId { get; set; }
        string Modifiers { get; set; }
    }
}
