using PractiZing.Base.Entities.DenialService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.DenialService.Tables
{
    public class DenialQueue : IDenialQueue
    {
        [Key]
        [AutoIncrement]
        public long Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        public int? ChargeId { get; set; }

        [MaxLength(15, ErrorMessage = "AssignedTo - Must not enter more than 15 characters.")]
        public string AssignedTo { get; set; }

        [MaxLength(15, ErrorMessage = "AssignedBy - Must not enter more than 15 characters.")]
        public string AssignedBy { get; set; }
        public DateTime AssignedDate { get; set; }

        public bool? HasFollowUp { get; set; }
        public DateTime? FollowUpDate { get; set; }

        public long? LastNoteId { get; set; }

        public bool IsClosed { get; set; }
        public string ClosedBy { get; set; }
        public DateTime? ClosedDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}