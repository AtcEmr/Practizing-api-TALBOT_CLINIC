using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class FeeLocalityCarrierNumber : IFeeLocalityCarrierNumber
    {
        [Key]
        public Int16 LCID { get; set; }
        public string Locality { get; set; }
        public Int16 CarrierNumber { get; set; }
    }
}
