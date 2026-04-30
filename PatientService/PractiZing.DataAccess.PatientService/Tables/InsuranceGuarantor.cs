using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class InsuranceGuarantor : IInsuranceGuarantor
    {
        [Key]
        [AutoIncrement]
        public int ID { get; set; }
        public int PatientID { get; set; }

        [MaxLength(250, ErrorMessage = "GuarantorNumber - Must not enter more than 250 characters.")]
        public string GuarantorNumber { get; set; }
        [MaxLength(100, ErrorMessage = "FirstName - Must not enter more than 100 characters.")]
        public string FirstName { get; set; }
        [MaxLength(100, ErrorMessage = "LastName - Must not enter more than 100 characters.")]
        public string LastName { get; set; }
        [MaxLength(250, ErrorMessage = "Address1 - Must not enter more than 250 characters.")]
        public string Address1 { get; set; }
        [MaxLength(250, ErrorMessage = "Address2 - Must not enter more than 250 characters.")]
        public string Address2 { get; set; }
        [MaxLength(75, ErrorMessage = "City - Must not enter more than 75 characters.")]
        public string City { get; set; }
        [MaxLength(25, ErrorMessage = "State - Must not enter more than 25 characters.")]
        public string State { get; set; }
        [MaxLength(10, ErrorMessage = "Zip - Must not enter more than 10 characters.")]
        public string Zip { get; set; }
        [MaxLength(15, ErrorMessage = "HomePhone - Must not enter more than 15 characters.")]
        public string HomePhone { get; set; }
        [MaxLength(25, ErrorMessage = "BusPhone - Must not enter more than 25 characters.")]
        public string BusPhone { get; set; }
        [MaxLength(26, ErrorMessage = "DOB - Must not enter more than 26 characters.")]
        public string DOB { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Insurance guarantor sex is required")]
        public char AdminSex { get; set; }
        [MaxLength(250, ErrorMessage = "GuarantorRel - Must not enter more than 250 characters.")]
        public string GuarantorRel { get; set; }
        [MaxLength(250, ErrorMessage = "EmployerAddress1 - Must not enter more than 250 characters.")]
        public string EmployerAddress1 { get; set; }
        [MaxLength(250, ErrorMessage = "EmployerAddress2 - Must not enter more than 250 characters.")]
        public string EmployerAddress2 { get; set; }
        [MaxLength(75, ErrorMessage = "EmployerCity - Must not enter more than 75 characters.")]
        public string EmployerCity { get; set; }
        [MaxLength(25, ErrorMessage = "EmployerState - Must not enter more than 25 characters.")]
        public string EmployerState { get; set; }
        [MaxLength(10, ErrorMessage = "EmployerZip - Must not enter more than 10 characters.")]
        public string EmployerZip { get; set; }
        [MaxLength(250, ErrorMessage = "EmployerPhone - Must not enter more than 250 characters.")]
        public string EmployerPhone { get; set; }
        [MaxLength(2, ErrorMessage = "EmploymentStatus - Must not enter more than 2 characters.")]
        public string EmploymentStatus { get; set; }
        [MaxLength(250, ErrorMessage = "OrganizationName - Must not enter more than 250 characters.")]
        public string OrganizationName { get; set; }
        [MaxLength(250, ErrorMessage = "MaritalStatus - Must not enter more than 250 characters.")]
        public string MaritalStatus { get; set; }

        public char Student { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public char PreferedContact { get; set; }
        public string MobilePhone { get; set; }
    }
}
