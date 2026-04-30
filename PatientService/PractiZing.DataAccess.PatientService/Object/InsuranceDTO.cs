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
    public class InsuranceDTO : IInsuranceDTO
    {
        public InsuranceDTO()
        {
            this.InsuranceCompany = new InsuranceCompany();
            this.InsurancePolicy = new InsurancePolicy();
            this.InsurancePolicyHolder = new InsurancePolicyHolder();
        }

        public IInsuranceCompany InsuranceCompany { get; set; }
        public IInsurancePolicy InsurancePolicy { get; set; }
        public IInsurancePolicyHolder InsurancePolicyHolder { get; set; }
    }
}
