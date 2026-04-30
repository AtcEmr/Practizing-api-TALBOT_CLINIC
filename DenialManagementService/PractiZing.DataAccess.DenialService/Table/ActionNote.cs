using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.DenialService.Tables
{
    public class ActionNote : IActionNote
    {
        public ActionNote()
        {
            this.AttFiles = new List<AttFile>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        public int PatientId { get; set; }
        public int? ChargeId { get; set; }
        public int? ClaimId { get; set; }

        [MaxLength(1000, ErrorMessage = "Note - Must not enter more than 1000 characters.")]
        public string Note { get; set; }

        [MaxLength(50, ErrorMessage = "NoteSourceCD - Must not enter more than 50 characters.")]
        public string NoteSourceCD { get; set; }

        public int? ActionCategoryId { get; set; }
        public bool? HasFollowUp { get; set; }
        public DateTime? FollowUpDate { get; set; }

        [MaxLength(50, ErrorMessage = "ResponseByCD - Must not enter more than 50 characters.")]
        public string ResponseByCD { get; set; }
        public bool HasAttachment { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsNote { get; set; }

        [Ignore]
        public string ConfigSystemDescription { get; set; }

        [Ignore]
        public Guid? ActionCategoryUId { get; set; }

        [Ignore]
        public Guid PatientUId { get; set; }

        [Ignore]
        public Guid ChargeUId { get; set; }

        [Ignore]
        public string ResponseByCDDescription { get; set; }

        [Ignore]
        public IEnumerable<IAttFile> AttFiles { get; set; }

        [Ignore]
        public string NoteSourceCDDescription { get; set; }

        [Ignore]
        public Guid? ActionSubCategoryUId { get; set; }
        
        public int? ActionSubCategoryId { get; set; }

        public string UserName { get; set; }

        [Ignore]
        public string ActionCategoryName { get; set; }

        [Ignore]
        public string ActionSubCategoryName { get; set; }

        [Ignore]
        public string AssignedTo { get; set; }

        [Ignore]
        public DateTime? DenialQueueFollowUpDate { get; set; }

    }
}
