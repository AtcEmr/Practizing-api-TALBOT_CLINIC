using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class MasterCPTFilter : IMasterCPTFilter
    {
        [SearchField(Name = MasterCPTFilterModel.Code)]
        public string Code { get; set; }

        [SearchField(Name = MasterCPTFilterModel.Description)]
        public string Description { get; set; }
    }
    public class MasterCPTFilterModel
    {
        public const string TableName = "MasterCPT";
        public const string Code = TableName + "." + "Code";
        public const string Description = TableName + "." + "Description";
    }
}
