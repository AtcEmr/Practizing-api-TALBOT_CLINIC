using System.Collections.Generic;

namespace PractiZing.Base.Entities.MasterService
{
    public interface INotesCategory : IPracticeDTO, IUniqueIdentifier, IStamp, IActive
    {
        int ID { get; set; }
        string CategoryName { get; set; }
        bool? AttachmentRequired { get; set; }
        string DefaultNote { get; set; }
        bool? HasFollowUp { get; set; }
        string ResponseBy { get; set; }
        int? ParentID { get; set; }
        string FollowUpPeriod { get; set; }
        bool? IsDenial { get; set; }
        bool? IsARSCategory { get; set; }
        bool? IsDisputed { get; set; }
        string ParentCategoryName { get; set; }
        IEnumerable<IARSCategoryReasonCode> aRSCategoryReasonCodes { get; set; }
    }
}
