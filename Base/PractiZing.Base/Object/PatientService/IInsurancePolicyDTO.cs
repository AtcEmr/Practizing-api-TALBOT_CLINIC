using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PatientService
{
    public interface IInsurancePolicyDTO
    {
        int PatientCaseId { get; set; }
        int InsuranceLevel { get; set; }
        DateTime? PlanEffectiveDate { get; set; }
        DateTime? PlanExpirationDate { get; set; }
        string InsuranceCompanyName { get; set; }
        string InsuranceCompanyCode { get; set; }
    }

    public interface IPolicyException
    {
        string BillingPolicyId { get; set; }
        string Exception { get; set; }
        long EMRPolicyId { get; set; }
    }
}
