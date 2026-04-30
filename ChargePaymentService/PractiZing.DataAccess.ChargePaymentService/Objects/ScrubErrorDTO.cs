using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ScrubErrorDTO : IScrubErrorDTO
    {        
        public string AccessionNumber { get; set; }
        public string CPTCode { get; set; }
        public string ICDCode { get; set; }
        public string Modifier { get; set; }
        public string ErrorMessage { get; set; }        
    }
}
