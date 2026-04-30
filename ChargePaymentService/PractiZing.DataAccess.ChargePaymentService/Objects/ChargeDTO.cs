using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargeDTO : IChargeDTO
    {
        public int InvoiceId { get; set; }
        public string BatchNo { get; set; }
        public string AccessionNumber { get; set; }
        public DateTime DOS { get; set; }        
        public string PatientName { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string OrderingPhysician { get; set; }                                     
        public DateTime PostDate { get; set; }        
        public decimal ChargeAmount { get; set; }        
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
        public string DueByFlagCD { get; set; }
    }
}
