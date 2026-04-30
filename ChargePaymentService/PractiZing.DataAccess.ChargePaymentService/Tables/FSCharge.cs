using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class FSCharge : IFSCharge
    {
        public FSCharge()
        {
            this.FSDiscounts = new List<FSDiscount>();
        }

        [Key]
        [AutoIncrement]
        public short Id { get; set; }
        public short FeeScheduleId { get; set; }
        [Ignore]
        public Guid FeeScheduleUId { get; set; }

        [MaxLength(10, ErrorMessage = "CPTCode - Must not enter more than 10 characters.")]
        public string CPTCode { get; set; }

        [MaxLength(5, ErrorMessage = "Modifier - Must not enter more than 5 characters.")]
        public string Modifier { get; set; }
        [MaxLength(5, ErrorMessage = "Modifier - Must not enter more than 5 characters.")]
        public string Modifier2 { get; set; }
        [MaxLength(5, ErrorMessage = "Modifier - Must not enter more than 5 characters.")]
        public string Modifier3 { get; set; }
        [MaxLength(5, ErrorMessage = "Modifier - Must not enter more than 5 characters.")]
        public string Modifier4 { get; set; }

        public decimal FacilityCharge { get; set; }
        public decimal NonFacilityCharge { get; set; }
        public decimal CommunityCharge { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? InsuranceCompayId { get; set; }
        public int? ProviderId { get; set; }
        public int? QualificationId { get; set; }
        [Ignore]
        public Guid? InsuranceCompayUId { get; set; }
        [Ignore]
        public Guid? ProviderUId { get; set; }

        [Ignore]
        public string InsuranceCompanyName { get; set; }

        [Ignore]
        public string ProviderName { get; set; }

        [Ignore]
        public bool IsFSChargeDeleted { get; set; }

        [Ignore]
        public IEnumerable<IFSDiscount> FSDiscounts { get; set; }

        [Ignore]
        public string Modifiers { get; set; }
    }
}
