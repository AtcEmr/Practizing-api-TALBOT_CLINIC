using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class ScrubErrorTest : IScrubErrorTest
    {
        public ScrubErrorTest()
        {
            this.ChargeErrors = new List<ChargeError>();
        }

        //public int FacilityId { get; set; }
        public string ClinicCode { get; set; }
        public int ScrubId { get; set; }
        public string ScrubName { get; set; }
        //public int CaseNo { get; set; }
        //public int ChargeNumber { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ActionDate { get; set; }
        public IEnumerable<IChargeError> ChargeErrors { get; set; }
    }
}
