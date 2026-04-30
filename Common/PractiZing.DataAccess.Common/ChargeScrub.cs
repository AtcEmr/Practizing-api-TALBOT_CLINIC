using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.Common
{
    public class ChargeScrub : IChargeScrub
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int ChargeId { get; set; }
        public string ErrorJson { get; set; }        
    }
}
