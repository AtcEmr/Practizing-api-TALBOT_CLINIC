using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.View
{
    [Alias("vw_GetChargeDetailByAccessionNumber")]
    public class ChargeViewAccessionWiseDTO: IChargeViewAccessionWise
    {        
        public string AccessionNumber { get; set; }
        public decimal ChargeAmount { get; set; }                
        public decimal? PatientPaid { get; set; }
        public decimal? InsurancePaid { get; set; }
        public decimal? PatientAdjustment { get; set; }
        public decimal? InsuranceAdjustment { get; set; }              
    }
}
