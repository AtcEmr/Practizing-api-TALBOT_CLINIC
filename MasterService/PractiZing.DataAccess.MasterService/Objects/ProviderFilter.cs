using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class ProviderFilter : BaseSearchModel, IProviderFilter
    {
        [SearchField(Name = ProviderFilterModel.UserName)]
        public string UserName { get; set; }
    }
    public class ProviderFilterModel
    {
        public const string TableName = "Provider";
        public const string UserName = TableName + "." + "UserName";
    }
}
