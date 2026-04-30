using PractiZing.Base.Entities.DenialService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.DenialService.Tables
{
    public class ARGroupReasonCode : IARGroupReasonCode
    {
        [Key]
        public int Id { get; set; }
        public int ARGroupId { get; set; }
        [MaxLength(30, ErrorMessage = "ReasonCode - Must not enter more than 30 characters.")]
        public string ReasonCode { get; set; }
    }
}
