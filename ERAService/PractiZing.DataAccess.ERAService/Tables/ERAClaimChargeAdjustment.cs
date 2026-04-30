
using PractiZing.Base.Entities.ERAService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ERAService.Tables
{
    public  class ERAClaimChargeAdjustment: IERAClaimChargeAdjustment
    {
        [Key]
        [AutoIncrement]
        public long Id { get; set; }

        public long ERAClaimChargePaymentId { get; set; }

        public string CASCode { get; set; }

        public string AdjustmentReasonCode { get; set; }

        public decimal Amount { get; set; }


    }
}
