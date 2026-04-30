using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface INotesCategoryFilter
    {
        string CategoryName { get; set; }
        int? ParentID { get; set; }
        string DefaultNote { get; set; }
        bool? HasFollowUp { get; set; }
        string FollowUpPeriod { get; set; }
    }
}
