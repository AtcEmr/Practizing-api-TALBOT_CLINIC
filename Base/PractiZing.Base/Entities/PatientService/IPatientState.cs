using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatientState 
    {
        long Id { get; set; }     
        string PatientId { get; set; }
        int ConsecutiveNoChange { get; set; }
        bool MaxAttemptsReached { get; set; }
        DateTime LastCallDate { get; set; }     
        string LastCallOutcome { get; set; }
        DateTime LastPaymentDate { get; set; }      
        string PhoneStatus { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        bool IsActive { get; set; }
    }
}
