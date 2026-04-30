using PractiZing.Base.Entities.PatientService;
using System.Collections.Generic;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientInsuranceLinkingDTO
    {
        IPatient Patient { get; set; }
        IInsuranceGuarantor InsuranceGuarantor { get; set; }
        IEnumerable<IInsurancePolicy> InsurancePolicy { get; set; }
    }
}
