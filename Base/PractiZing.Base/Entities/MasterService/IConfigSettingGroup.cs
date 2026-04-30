using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigSettingGroup :IActive
    {
        [Key]
        string SettingGroupCD { get; set; }
        string SettingGroupDisplayName { get; set; }
        int DisplayOrder { get; set; }

        IEnumerable<IConfigSetting> ConfigSettings { get; set; }
    }
}
