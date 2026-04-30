using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class CallHistory : ICallHistory
    {
        public CallHistory()
        {           
        }

        [Key]
        [AutoIncrement]
        public long Id { get; set; }      

        // [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(20, ErrorMessage = "PatientId - Must not enter more than 20 characters.")]
        public string PatientId { get; set; }

        public DateTime CallDateTime { get; set; }

        [MaxLength(50, ErrorMessage = "CallOutcome - Must not enter more than 50 characters.")]
        public string CallOutcome { get; set; }

        public int CallDuration { get; set; }
        public decimal BalanceBeforeCall { get; set; }
        public decimal BalanceAfterCall { get; set; }
        public decimal WeekStartBalance { get; set; }
        public int Priority { get; set; }
        public decimal VAPICost { get; set; }

        [MaxLength(100, ErrorMessage = "VAPICallID - Must not enter more than 100 characters.")]
        public string VAPICallID { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
