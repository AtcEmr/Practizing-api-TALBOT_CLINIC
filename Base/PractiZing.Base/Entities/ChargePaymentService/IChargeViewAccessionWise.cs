using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public class IChargeViewAccessionWise
    {
        string AccessionNumber { get; set; }
        decimal ChargeAmount { get; set; }
        decimal? PatientPaid { get; set; }
        decimal? InsurancePaid { get; set; }
        decimal? PatientAdjustment { get; set; }
        decimal? InsuranceAdjustment { get; set; }

    }
}
