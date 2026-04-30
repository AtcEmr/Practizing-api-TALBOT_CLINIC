using PractiZing.Base.Object.PatientService;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientFilter : BaseSearchModel, IPatientFilter
    {
        [SearchField(Name = PatientFilterModel.PatientId)]
        public string PatientId { get; set; }

        [SearchField(Name = PatientFilterModel.BillingId)]
        public string BillingId { get; set; }

        [SearchField(Name = PatientFilterModel.FirstName)]
        public string FirstName { get; set; }

        [SearchField(Name = PatientFilterModel.LastName)]
        public string LastName { get; set; }

        [SearchField(Name = PatientFilterModel.SSN)]
        public string SSN { get; set; }

        [SearchField(Name = PatientFilterModel.DOB)]
        public string DOB { get; set; }
    }

    public class PatientFilterModel
    {
        public const string TableName = "patient";
        public const string PatientId = TableName + "." + "Id";
        public const string BillingId = TableName + "." + "BillingId";
        public const string FirstName = TableName + "." + "FirstName";
        public const string LastName = TableName + "." + "LastName";
        public const string SSN = TableName + "." + "SSN";
        public const string DOB = TableName + "." + "DOB";
    }
}
