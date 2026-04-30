using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class FSDiscount : IFSDiscount
    {
        [Key]
        [AutoIncrement]
        public short Id { get; set; }
        public short FSChargeID { get; set; }
        public short? ProviderId { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public DateTime EffectiveDate { get; set; }

        public decimal FacilityDiscount { get; set; }
        public decimal NonFacilityDiscount { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public bool IsFSDiscountDeleted { get; set; }
        [Ignore]
        public Guid? ProviderUId { get; set; }
        [Ignore]
        public Guid? InsuranceCompanyUId { get; set; }

        public int? PractitionerServiceId { get; set; }

    }
}
