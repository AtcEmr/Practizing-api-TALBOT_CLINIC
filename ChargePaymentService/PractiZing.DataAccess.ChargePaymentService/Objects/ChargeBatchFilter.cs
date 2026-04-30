using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargeBatchFilter : IChargeBatchFilter
    {
        [SearchField(Name = BatchFilterModel.IsActive)]
        public string BatchStatus { get; set; }
        [SearchField(Name = BatchFilterModel.BatchDate)]
        public string FromDate { get; set; }
        [SearchField(Name = BatchFilterModel.BatchDate)]
        public string ToDate { get; set; }
        //[SearchField(Name = BatchFilterModel.InsuranceCompanyId)]
        //public int? InsuranceCompanyId { get; set; }
    }

    public class BatchFilterModel
    {
        public const string TableName = "ChargeBatch";
        public const string BatchDate = TableName + "." + "BatchDate";
        public const string IsActive = TableName + "." + "IsActive";

        public const string TableName1 = "InsurancePolicy";
        public const string InsuranceCompanyId = TableName1 + "." + "InsuranceCompanyId";
    }
}
