using PractiZing.Base.Model.PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Model
{
    public class HL7StatusDTO: IHL7StatusDTO
    {
        public string FileName { get; set; }
    }
}
