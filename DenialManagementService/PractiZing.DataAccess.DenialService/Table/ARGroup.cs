using PractiZing.Base.Entities.DenialService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.DenialService.Tables
{
    public class ARGroup : IARGroup
    {
        [Key]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        [MaxLength(200, ErrorMessage = "GroupName - Must not enter more than 200 characters.")]
        public string GroupName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
