using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Object.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientInsuranceLinkingDTO : IPatientInsuranceLinkingDTO
    {
        public PatientInsuranceLinkingDTO()
        {
            this.InsuranceGuarantor = new InsuranceGuarantor();
            this.InsurancePolicy = new List<InsurancePolicy>();
            this.Patient = new Patient();
        }

        public IPatient Patient { get; set; }
        public IInsuranceGuarantor InsuranceGuarantor { get; set; }
        public IEnumerable<IInsurancePolicy> InsurancePolicy { get; set; }
    }
}
