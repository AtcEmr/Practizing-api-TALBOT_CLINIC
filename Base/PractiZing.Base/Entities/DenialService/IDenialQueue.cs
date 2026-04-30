using System;

namespace PractiZing.Base.Entities.DenialService
{
    public interface IDenialQueue : IUniqueIdentifier, IPracticeDTO, ICreatedStamp
    {
        long Id { get; set; }
        string AssignedTo { get; set; }
        string AssignedBy { get; set; }
        int? ChargeId { get; set; }
        DateTime AssignedDate { get; set; }
        bool? HasFollowUp { get; set; }
        DateTime? FollowUpDate { get; set; }
        bool IsClosed { get; set; }
        long? LastNoteId { get; set; }
        string ClosedBy { get; set; }
        DateTime? ClosedDate { get; set; }
    }
}