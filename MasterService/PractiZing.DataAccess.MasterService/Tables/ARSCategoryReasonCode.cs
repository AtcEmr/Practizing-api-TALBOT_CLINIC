using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ARSCategoryReasonCode : IARSCategoryReasonCode
    {
        [Key]
        [AutoIncrement]
        public long Id { get; set; }
        public int PracticeId { get; set; }

        public int NotesCategoryId { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(30, ErrorMessage = "ReasonCode - Must not enter more than 30 characters.")]
        public string ReasonCode { get; set; }

        [Ignore]
        public bool IsReasonCodeDeleted { get; set; }
    }
}
