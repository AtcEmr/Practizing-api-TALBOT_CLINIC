using PractiZing.Base.Common;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigFollowUpPeriod : IActive
    {
        int ID { get; set; }
        int FollowUpDays { get; set; }
        string FollowUpValue { get; set; }
        int FollowUpMonths { get; set; }
    }
}
