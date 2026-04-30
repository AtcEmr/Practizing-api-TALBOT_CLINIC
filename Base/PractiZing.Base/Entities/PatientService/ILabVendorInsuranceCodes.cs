using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface ILabVendorInsuranceCodes
    {
        int LabVendorInsuranceCodeID { get; set; }
        int LabCompanyID { get; set; }
        int InsuranceCompanyID { get; set; }
        string Code { get; set; }
    }
}
