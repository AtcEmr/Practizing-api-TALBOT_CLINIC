using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.DenialService.Tables
{
    public class ActionCategory : IActionCategory
    {
        public ActionCategory()
        {
            this.AttFiles = new List<AttFile>();
        }
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public int? ParentCategoryId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(200,ErrorMessage = "CategoryName - Must not enter more than 200 characters.")]
        public string CategoryName { get; set; }
        public bool IsAttachmentRequired { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(1000, ErrorMessage = "DefaultNote - Must not enter more than 1000 characters.")]
        public string DefaultNote { get; set; }
        public bool IsActive { get; set; }
        public bool? HasFollowUp { get; set; }

        [MaxLength(50, ErrorMessage = "ResponseByCD - Must not enter more than 50 characters.")]
        public string ResponseByCD { get; set; }

        [MaxLength(50, ErrorMessage = "FollowUpPeriodCD - Must not enter more than 50 characters.")]
        public string FollowUpPeriodCD { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public IEnumerable<IAttFile> AttFiles { get; set; }
        [Ignore]
        public Guid? ParentCategoryUId { get; set; }
    }
}
