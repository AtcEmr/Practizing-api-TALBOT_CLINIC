using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IAppSetting : IStamp, IPracticeDTO, IActive
    {
        int Id { get; set; }
        string SettingCD { get; set; }
        string SettingValue { get; set; }
        Guid? ExternalTableUId { get; set; }
        string FormControlCD { get; set; }
    }
}
