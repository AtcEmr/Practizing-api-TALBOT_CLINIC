using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
   public interface IScrubErrorTest
    {
         //int FacilityId { get; set; }
         string ClinicCode { get; set; }
         int ScrubId { get; set; }
         string ScrubName { get; set; }
         //int CaseNo { get; set; }
         //int ChargeNumber { get; set; }
         string ErrorMessage { get; set; }
         DateTime ActionDate { get; set; }
        IEnumerable<IChargeError> ChargeErrors { get; set; }
    }
}
