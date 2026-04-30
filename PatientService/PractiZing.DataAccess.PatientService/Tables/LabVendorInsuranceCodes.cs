using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class LabVendorInsuranceCodes : ILabVendorInsuranceCodes
    {
        [Key]
        [AutoIncrement]
        public int LabVendorInsuranceCodeID {get; set;}
        public int LabCompanyID {get; set;}
        public int InsuranceCompanyID {get; set;}
        public string Code {get; set;}
    }
}
