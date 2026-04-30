using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChargesDueAmountForEMR
    {
        decimal DueByPatient { get; set; }
        decimal DueByInsurance { get; set; }
        decimal DueByMedicaidPatient { get; set; }
        decimal UnPostedAmount { get; set; }
        decimal UnMatchedAmount { get; set; }
    }
}
