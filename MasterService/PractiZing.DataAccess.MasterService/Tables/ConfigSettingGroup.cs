using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigSettingGroup : IConfigSettingGroup
    {
        public ConfigSettingGroup()
        {
            this.ConfigSettings = new List<ConfigSetting>();
        }

        public string SettingGroupCD { get; set; }
        public string SettingGroupDisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        [Ignore]
        public IEnumerable<IConfigSetting> ConfigSettings { get; set; }
    }
}
