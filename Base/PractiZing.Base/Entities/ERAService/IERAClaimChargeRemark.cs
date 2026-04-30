namespace PractiZing.Base.Entities.ERAService
{
    public interface IERAClaimChargeRemark
    {

        long Id { get; set; }

        long ERAClaimChargePaymentId { get; set; }

        string QualifierCode { get; set; }

        string RemarkCode { get; set; }
    }
}
