using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IClaimConfig : IUniqueIdentifier, IStamp, IPracticeDTO
    {
        int Id { get; set; }
        Int16? InsuranceCompanyTypeId { get; set; }
        int? InsuranceCompanyId { get; set; }
        bool IsDefault { get; set; }

        IEnumerable<IAppSetting> AppSettings { get; set; }
        string InsuranceCompanyUId { get; set; }
    }
}
