using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientChargesStatementFooterDTO : IPatientChargesStatementFooterDTO
    {
        public decimal TotalDues { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StatementDate { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get { return $"{FirstName} {LastName}"; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AmountDues { get; set; }
        public decimal AmountEnclosed { get; set; }
    }
}
