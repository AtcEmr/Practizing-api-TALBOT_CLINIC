using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.Common
{
    public class ScrubError : IScrubError
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int ClaimId { get ; set ; }
        public int InvoiceId { get ; set ; }
        public Guid InvoiceUId { get; set; }
        public DateTime ScrubDateTime { get ; set ; }
        public bool HasError { get ; set ; }
        public string ErrorJson { get ; set ; }
        public int PatientId { get; set; }
        public Guid PatientUId { get; set; }
        public string ScrubName { get; set; }

        [Ignore]
        public int ChargeId { get; set; }
        [Ignore]
        public string AccessionNumber { get; set; }
        [Ignore]
        public string ErrorMessage { get; set; }
    }
}
