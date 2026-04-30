using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.DenialService
{
    public interface IActionNote : IPracticeDTO, IUniqueIdentifier, IStamp
    {
        int Id { get; set; }
        int PatientId { get; set; }
        int? ChargeId { get; set; }
        int? ClaimId { get; set; }
        string Note { get; set; }
        string NoteSourceCD { get; set; }
        int? ActionCategoryId { get; set; }
        bool? HasFollowUp { get; set; }
        DateTime? FollowUpDate { get; set; }
        string ResponseByCD { get; set; }
        bool HasAttachment { get; set; }
        bool? IsNote { get; set; }
        string ConfigSystemDescription { get; set; }
        Guid? ActionCategoryUId { get; set; }
        Guid PatientUId { get; set; }
        Guid ChargeUId { get; set; }
        string ResponseByCDDescription { get; set; }
        IEnumerable<IAttFile> AttFiles { get; set; }
        string NoteSourceCDDescription { get; set; }
        int? ActionSubCategoryId { get; set; }
        Guid? ActionSubCategoryUId { get; set; }
        string UserName { get; set; }
        string ActionCategoryName { get; set; }
        string ActionSubCategoryName { get; set; }
        string AssignedTo { get; set; }
        DateTime? DenialQueueFollowUpDate { get; set; }
    }
}
