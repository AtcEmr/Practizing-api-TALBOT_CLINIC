using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class ReferringDoctorFilter : IReferringDoctorFilter
    {
        [SearchField(Name = ReferringDoctorFilterModel.Prefix)]
        public string Prefix { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.FirstName)]
        public string FirstName { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.Middle)]
        public string Middle { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.LastName)]
        public string LastName { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.Suffix)]
        public string Suffix { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.NPI)]
        public string NPI { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.Address)]
        public string Address { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.Address2)]
        public string Address2 { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.City)]
        public string City { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.State)]
        public string State { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.Zip)]
        public string Zip { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.Phone)]
        public string Phone { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.Fax)]
        public string Fax { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.Email)]
        public string Email { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.PracticeName)]
        public string PracticeName { get; set; }

        [SearchField(Name = ReferringDoctorFilterModel.DirectEmailID)]
        public int? DirectEmailID { get; set; }
    }

    public class ReferringDoctorFilterModel
    {
        public const string TableName = "ReferringDoctor";
        public const string Prefix = TableName + "." + "Prefix";
        public const string FirstName = TableName + "." + "FirstName";
        public const string Middle = TableName + "." + "Middle";
        public const string LastName = TableName + "." + "LastName";
        public const string Suffix = TableName + "." + "Suffix";
        public const string NPI = TableName + "." + "NPI";
        public const string Address = TableName + "." + "Address";
        public const string Address2 = TableName + "." + "Address2";
        public const string City = TableName + "." + "City";
        public const string State = TableName + "." + "State";
        public const string Zip = TableName + "." + "Zip";
        public const string Phone = TableName + "." + "Phone";
        public const string Fax = TableName + "." + "Fax";
        public const string Email = TableName + "." + "Email";
        public const string PracticeName = TableName + "." + "PracticeName";
        public const string DirectEmailID = TableName + "." + "DirectEmailID";
    }

}
