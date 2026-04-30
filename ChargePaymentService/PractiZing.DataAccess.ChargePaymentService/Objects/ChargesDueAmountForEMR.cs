using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargesDueAmountForEMR : IChargesDueAmountForEMR
    {
        public decimal DueByPatient { get; set; }
        public decimal DueByInsurance { get; set; }
        public decimal DueByMedicaidPatient { get; set; }
        public decimal UnPostedAmount { get; set; }
        public decimal UnMatchedAmount { get; set; }
    }
}
