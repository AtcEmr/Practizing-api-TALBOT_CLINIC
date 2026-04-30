using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Object.PatientService;
using PractiZing.DataAccess.PatientService.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Model
{
    public class StatementDTO : IStatementDTO
    {
        public StatementDTO()
        {
            this.PatientChargesStatementHeaderDTO = new PatientChargesStatementHeaderDTO();
            this.PatientCharges = new List<PatientChargesStatementDTO>();
            //this.PatientChargesPayment = new List<PatientChargesStatementDTO>();
            //this.PatientChargesAdjustment = new List<PatientChargesStatementDTO>();
            this.PatientChargesStatementFooterDTO = new PatientChargesStatementFooterDTO();
        }
        
        public IPatientChargesStatementHeaderDTO PatientChargesStatementHeaderDTO { get; set; }
        public IEnumerable<IPatientChargesStatementDTO> PatientCharges { get; set; }
        //public IEnumerable<IPatientChargesStatementDTO> PatientChargesPayment { get; set; }
        //public IEnumerable<IPatientChargesStatementDTO> PatientChargesAdjustment { get; set; }
        public IPatientChargesStatementFooterDTO PatientChargesStatementFooterDTO { get; set; }
    }
}
