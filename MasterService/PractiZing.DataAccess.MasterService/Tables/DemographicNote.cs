using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    [Alias("ActionNote")]
    public class DemographicNote : IDemographicNote
    {
        [Key]
        [AutoIncrement]
        public long Id { get; set; }

        public int DemographicNoteId { get; set; }
        public int PatientId { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        public int NoteID { get; set; }

        [MaxLength(1000, ErrorMessage = "Note - Must not enter more than 1000 characters.")]
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Dos { get; set; }

        public short? NoteTypeId { get; set; }

        [MaxLength(100, ErrorMessage = "AttachedFile - Must not enter more than 100 characters.")]
        public string AttachedFile { get; set; }
        public bool? IsBilling { get; set; }
        public long? TransactionID { get; set; }
        public int? CategoryID { get; set; }
        public bool? HasFollowUp { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public bool? NoteBy { get; set; }

        [MaxLength(20, ErrorMessage = "ResponseBy - Must not enter more than 20 characters.")]
        public string ResponseBy { get; set; }
        public int? SubCategoryID { get; set; }
        public long? ChargeNumber { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public bool IsAddNote { get; set; }
    }
}
