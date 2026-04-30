using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.DenialService
{
    public interface IActionCategory : IPracticeDTO, IUniqueIdentifier, IStamp, IActive
    {
        int Id { get; set; }
        int? ParentCategoryId { get; set; }
        string CategoryName { get; set; }
        bool IsAttachmentRequired { get; set; }
        string DefaultNote { get; set; }
        bool? HasFollowUp { get; set; }
        string ResponseByCD { get; set; }
        string FollowUpPeriodCD { get; set; }

        IEnumerable<IAttFile> AttFiles { get; set; }
        Guid? ParentCategoryUId { get; set; }
    }
}
