using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class FeeSchedule : IFeeSchedule
    {
        public FeeSchedule()
        {
            this.FSCharges = new List<FSCharge>();
        }
        [Key]
        [AutoIncrement]
        public short Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [MaxLength(100, ErrorMessage = "Name - Must not enter more than 100 characters.")]
        public string Name { get; set; }
        public short? FSLocalityCarrierId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public IEnumerable<IFSCharge> FSCharges { get; set; }

    }
}
