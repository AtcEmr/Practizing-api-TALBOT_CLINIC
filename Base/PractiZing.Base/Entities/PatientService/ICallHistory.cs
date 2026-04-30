using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.PatientService
{
    public interface ICallHistory 
    {
         long Id { get; set; }        
         string PatientId { get; set; }
         DateTime CallDateTime { get; set; }       
         string CallOutcome { get; set; }
         int CallDuration { get; set; }
         decimal BalanceBeforeCall { get; set; }
         decimal BalanceAfterCall { get; set; }
         decimal WeekStartBalance { get; set; }
         int Priority { get; set; }
         decimal VAPICost { get; set; }       
         string VAPICallID { get; set; }
         DateTime CreatedDate { get; set; }
    }
}
