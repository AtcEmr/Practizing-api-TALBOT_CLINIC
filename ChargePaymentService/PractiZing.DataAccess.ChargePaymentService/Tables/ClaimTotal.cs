using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ClaimTotal : IClaimTotal
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public short PageNumber { get; set; }
        public decimal? LabCharges { get; set; }
        public decimal? TotalCharges { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? BalanceDue { get; set; }
        public bool OutsideLab { get; set; }

        [MaxLength(48, ErrorMessage = "Reserved19 - Must not enter more than 48 characters.")]
        public string Reserved19 { get; set; }

        [MaxLength(11, ErrorMessage = "MedicaidResubmissionCode - Must not enter more than 11 characters.")]
        public string MedicaidResubmissionCode { get; set; }

        [MaxLength(18, ErrorMessage = "OriginalReferenceNumber - Must not enter more than 18 characters.")]
        public string OriginalReferenceNumber { get; set; }
        public short? NumKind { get; set; }

        [MaxLength(28, ErrorMessage = "PriorAuthorizationNumber - Must not enter more than 28 characters.")]
        public string PriorAuthorizationNumber { get; set; }
        public int? Flags { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
