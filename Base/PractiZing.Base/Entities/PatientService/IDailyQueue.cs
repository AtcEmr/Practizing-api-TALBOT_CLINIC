using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IDailyQueue
    {
        long Id { get; set; }       
        string PatientId { get; set; }
        DateTime QueueDate { get; set; }
        int Priority { get; set; }
        int QueuePosition { get; set; }       
        string Status { get; set; }
        DateTime ProcessedTime { get; set; }     
        string SessionID { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
