using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class ICDCodeFilter : BaseSearchModel, IICDCodeFilter
    {
        [SearchField(Name = ICDCodeFilterModel.Code)]
        public string Code { get; set; }

        [SearchField(Name = ICDCodeFilterModel.Description)]
        public string Description { get; set; }

        [SearchField(Name = ICDCodeFilterModel.DefaultPlan)]
        public string DefaultPlan { get; set; }
    }

    public class ICDCodeFilterModel
    {
        public const string TableName = "ICDCode";
        public const string Code = TableName + "." + "Code";
        public const string Description = TableName + "." + "Description";
        public const string DefaultPlan = TableName + "." + "DefaultPlan";
    }
}
