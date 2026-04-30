using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigSetting : IConfigSetting
    {
        public ConfigSetting()
        {
            this.DefaultValuesList = new List<string>();
            this.SaveSettingValue = new List<string>();
        }

        public string SettingCD { get; set; }
        public string SettingGroupCD { get; set; }
        public string SettingDisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public string DefaultValues { get; set; }
        public string FormControlCD { get; set; }
        public string DataTypeCD { get; set; }
        public int MaxLength { get; set; }
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        [Ignore]
        public string SettingValue { get; set; }
        [Ignore]
        public IEnumerable<string> SaveSettingValue { get; set; }
        [Ignore]
        public IEnumerable<string> DefaultValuesList { get; set; }
        [Ignore]
        public int IsInsuranceCompany { get; set; }
        [Ignore]
        public Guid ExternalGUID { get; set; }
    }
}
