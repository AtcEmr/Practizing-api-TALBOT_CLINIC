using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Object.PatientService;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class InsurancePolicyDTO : IInsurancePolicyDTO
    {
        public int PatientCaseId { get ; set ; }
        public int InsuranceLevel { get; set; }
        public DateTime? PlanEffectiveDate { get ; set ; }
        public DateTime? PlanExpirationDate { get ; set ; }
        public string InsuranceCompanyName { get ; set ; }
        public string InsuranceCompanyCode { get; set; }
    }
}
