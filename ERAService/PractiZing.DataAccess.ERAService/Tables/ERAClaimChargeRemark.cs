using PractiZing.Base.Entities.ERAService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ERAService.Tables
{
    public class ERAClaimChargeRemark : IERAClaimChargeRemark
    {
        [Key]
        [AutoIncrement]
        public long Id { get; set; }

        public long ERAClaimChargePaymentId { get; set; }

        public string QualifierCode { get; set; }

        public string RemarkCode { get; set; }
    }
}
