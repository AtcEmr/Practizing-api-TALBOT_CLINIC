using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class AppSetting : IAppSetting
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string SettingCD { get; set; }
        public string SettingValue { get; set; }
        public Guid? ExternalTableUId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int PracticeId { get; set; }
        public bool IsActive { get; set; }
        [Ignore]
        public string FormControlCD { get; set; }
    }
}
