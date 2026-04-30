using System;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IInsurancePolicyException 
    {
        int Id { get; set; }
        long PolicyId { get; set; }
        string ErrorMessage { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
