using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IDemographicNote : IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        int DemographicNoteId { get; set; }
        int PatientId { get; set; }
        int NoteID { get; set; }
        string Note { get; set; }
        DateTime? Dos { get; set; }
        long Id { get; set; }
        Int16? NoteTypeId { get; set; }
        string AttachedFile { get; set; }
        bool? IsBilling { get; set; }
        long? TransactionID { get; set; }
        int? CategoryID { get; set; }
        bool? HasFollowUp { get; set; }
        DateTime? FollowUpDate { get; set; }
        bool? NoteBy { get; set; }
        string ResponseBy { get; set; }
        int? SubCategoryID { get; set; }
        long? ChargeNumber { get; set; }
        bool IsAddNote { get; set; }
    }
}
