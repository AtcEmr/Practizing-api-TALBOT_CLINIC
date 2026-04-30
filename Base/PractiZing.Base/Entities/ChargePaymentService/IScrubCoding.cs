using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IScrubCoding
    {
        int ScrubResultId { get; set; }

        short FacilityId { get; set; }
        string ClinicCode { get; set; }
        int PatientCaseId { get; set; }
        int ChargeNumber { get; set; }
        int ScrubId { get; set; }
        string Message { get; set; }
        DateTime ActionDate { get; set; }
        
        short ScrubStatus { get; set; }
    }
}
