using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigFollowUpPeriod : IConfigFollowUpPeriod
    {
        [Key]
        [AutoIncrement]
        public int ID { get; set; }
       public bool IsActive { get; set; }
        public int FollowUpDays { get; set; }

        [MaxLength(50, ErrorMessage = "FollowUpValue - Must not enter more than 50 characters.")]
        public string FollowUpValue { get; set; }
        public int FollowUpMonths { get; set; }
    }
}
