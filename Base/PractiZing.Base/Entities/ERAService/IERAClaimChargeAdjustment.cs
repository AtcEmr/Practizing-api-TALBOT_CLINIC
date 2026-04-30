namespace PractiZing.Base.Entities.ERAService
{
    public interface IERAClaimChargeAdjustment
    {
         long Id { get; set; }

         long ERAClaimChargePaymentId { get; set; }

         string CASCode { get; set; }

         string AdjustmentReasonCode { get; set; }

         decimal Amount { get; set; }


    }
}
