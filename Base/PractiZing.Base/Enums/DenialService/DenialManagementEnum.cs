using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Enums.DenialService
{
    public enum DenialManagementEnum
    {
        IsAgingHeader = 1,
        IsFollowUpHeader = 2,
        IsDenialHeader = 3,
        IsCompanyHeader = 4,
        IsCompanyTypeHeader = 5
    }

    public static class DenialManagementFilterHeaderConstant
    {
        public const string Aging = "Aging";
        public const string FollowUpCategories = "Follow up Categories";
        public const string InsuranceCompanies = "Insurance Companies";
        public const string DenialCategories = "Denial Categories";
        public const string InsuranceCompaniesTypes = "Insurance Companies Types";
    }
}
