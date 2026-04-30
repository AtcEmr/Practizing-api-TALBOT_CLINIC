using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;
using System;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class NDCFilter : BaseSearchModel, INDCFilter
    {
        [SearchField(Name = NDCFilterModel.Code)]
        public Int16? Code { get; set; }

        [SearchField(Name = NDCFilterModel.NDCCode)]
        public string NDCCode { get; set; }

        [SearchField(Name = NDCFilterModel.Format)]
        public Int16? Format { get; set; }

        [SearchField(Name = NDCFilterModel.UoM)]
        public Int16? UoM { get; set; }

        [SearchField(Name = NDCFilterModel.DrugQty)]
        public decimal? DrugQty { get; set; }

        [SearchField(Name = NDCFilterModel.Description)]
        public string Description { get; set; }
    }

    public class NDCFilterModel
    {
        public const string TableName = "NDC";
        public const string Code = TableName + "." + "Code";
        public const string NDCCode = TableName + "." + "NDCCode";
        public const string Format = TableName + "." + "Format";
        public const string UoM = TableName + "." + "UoM";
        public const string DrugQty = TableName + "." + "DrugQty";
        public const string Description = TableName + "." + "Description";
    }
}
