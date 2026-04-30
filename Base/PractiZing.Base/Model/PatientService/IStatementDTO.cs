using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.PatientService
{
    public interface IStatementDTO
    {
        IPatientChargesStatementHeaderDTO PatientChargesStatementHeaderDTO { get; set; }
        IEnumerable<IPatientChargesStatementDTO> PatientCharges { get; set; }
        //IEnumerable<IPatientChargesStatementDTO> PatientChargesPayment { get; set; }
        //IEnumerable<IPatientChargesStatementDTO> PatientChargesAdjustment { get; set; }
        IPatientChargesStatementFooterDTO PatientChargesStatementFooterDTO { get; set; }
    }
}
