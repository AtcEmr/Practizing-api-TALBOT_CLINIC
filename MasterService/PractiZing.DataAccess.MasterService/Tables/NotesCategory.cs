using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class NotesCategory : INotesCategory
    {
        public NotesCategory()
        {
            this.aRSCategoryReasonCodes = new List<ARSCategoryReasonCode>();
        }

        [Key]
        [AutoIncrement]
        public int ID { get; set; }
        public Guid UId { get; set; }

        public int PracticeId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(2000, ErrorMessage = "CategoryName - Must not enter more than 2000 characters.")]
        public string CategoryName { get; set; }

        public bool? AttachmentRequired { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(1000, ErrorMessage = "DefaultNote - Must not enter more than 1000 characters.")]
        public string DefaultNote { get; set; }

        public bool? HasFollowUp { get; set; }

        [MaxLength(20, ErrorMessage = "ResponseBy - Must not enter more than 20 characters.")]
        public string ResponseBy { get; set; }

        public int? ParentID { get; set; }

        [MaxLength(50, ErrorMessage = "FollowUpPeriod - Must not enter more than 50 characters.")]
        public string FollowUpPeriod { get; set; }
        public bool? IsDenial { get; set; }
        public bool? IsARSCategory { get; set; }
        public bool? IsDisputed { get; set; }

        public bool IsActive { get; set; }

        [Ignore]
        public string ParentCategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public IEnumerable<IARSCategoryReasonCode> aRSCategoryReasonCodes { get; set; }
    }
}
