using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigSetting : ICreatedStamp, IActive
    {
        [Key]
        string SettingCD { get; set; }
        string SettingGroupCD { get; set; }
        string SettingDisplayName { get; set; }
        int DisplayOrder { get; set; }
        string DefaultValues { get; set; }
        string FormControlCD { get; set; }
        string DataTypeCD { get; set; }
        int MaxLength { get; set; }

        string SettingValue { get; set; }
        IEnumerable<string> SaveSettingValue { get; set; }
        IEnumerable<string> DefaultValuesList { get; set; }
        int IsInsuranceCompany { get; set; }
        Guid ExternalGUID { get; set; }
    }
}
