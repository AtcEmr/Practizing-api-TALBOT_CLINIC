using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ClaimConfig : IClaimConfig
    {
        public ClaimConfig()
        {
            this.AppSettings = new List<AppSetting>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int PracticeId { get; set; }
        public Int16? InsuranceCompanyTypeId { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public bool IsDefault { get; set; }
        public Guid UId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public IEnumerable<IAppSetting> AppSettings { get; set; }
        [Ignore]
        public string InsuranceCompanyUId { get; set; }
    }
}
