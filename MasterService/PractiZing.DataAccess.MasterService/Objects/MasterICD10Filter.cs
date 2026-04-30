using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class MasterICD10Filter : IMasterICD10Filter
    {
        [SearchField(Name = MasterICD10FilterModel.Code)]
        public string Code { get; set; }

        [SearchField(Name = MasterICD10FilterModel.Description)]
        public string Description { get; set; }
    }

    public class MasterICD10FilterModel
    {
        public const string TableName = "MasterICD10";
        public const string Code = TableName + "." + "Code";
        public const string Description = TableName + "." + "Description";
    }
}
