using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientChargesStatementFooterDTO
    {
        decimal TotalDues { get; set; }
        DateTime DueDate { get; set; }
        DateTime StatementDate { get; set; }
        int PatientId { get; set; }
        string PatientName { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal AmountDues { get; set; }
        decimal AmountEnclosed { get; set; }
    }
}
