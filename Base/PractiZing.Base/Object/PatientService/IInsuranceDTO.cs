using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PatientService
{
    public interface IInsuranceDTO
    {
        IInsuranceCompany InsuranceCompany { get; set; }
        IInsurancePolicy InsurancePolicy { get; set; }
        IInsurancePolicyHolder InsurancePolicyHolder { get; set; }
    }
}
