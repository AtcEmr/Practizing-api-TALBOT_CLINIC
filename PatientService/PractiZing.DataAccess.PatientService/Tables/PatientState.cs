using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class PatientState : IPatientState
    {
        public PatientState()
        {           
        }

        [Key]
        [AutoIncrement]
        public long Id { get; set; }      

        // [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(20, ErrorMessage = "PatientId - Must not enter more than 20 characters.")]
        public string PatientId { get; set; }


        public int ConsecutiveNoChange { get; set; }
        public bool MaxAttemptsReached { get; set; }


        public DateTime LastCallDate { get; set; }

        [MaxLength(50, ErrorMessage = "LastCallOutcome - Must not enter more than 50 characters.")]
        public string LastCallOutcome { get; set; }

        public DateTime LastPaymentDate { get; set; }

        [MaxLength(20, ErrorMessage = "PhoneStatus - Must not enter more than 20 characters.")]
        public string PhoneStatus { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }              
    }
}
