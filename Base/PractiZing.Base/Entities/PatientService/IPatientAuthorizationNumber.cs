using System;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatientAuthorizationNumber : IUniqueIdentifier, IStamp
    {
        int Id { get; set; }
        long InsurancePolicyId { get; set; }
        string AuthorizationNumber { get; set; }
        DateTime EffectiveDate { get; set; }
        DateTime ExpirationDate { get; set; }
        bool isDeleted { get; set; }
    }
}
