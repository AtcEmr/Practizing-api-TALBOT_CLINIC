using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class DailyQueue : IDailyQueue
    {
        public DailyQueue()
        {           
        }

        [Key]
        [AutoIncrement]
        public long Id { get; set; }      

        // [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(20, ErrorMessage = "PatientId - Must not enter more than 20 characters.")]
        public string PatientId { get; set; }

        public DateTime QueueDate { get; set; }

        public int Priority { get; set; }
        public int QueuePosition { get; set; }

        [MaxLength(20, ErrorMessage = "Status - Must not enter more than 20 characters.")]
        public string Status { get; set; }

        public DateTime ProcessedTime { get; set; }

        [MaxLength(50, ErrorMessage = "SessionID - Must not enter more than 50 characters.")]
        public string SessionID { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
