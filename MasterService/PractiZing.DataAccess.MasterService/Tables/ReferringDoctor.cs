using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ReferringDoctor : IReferringDoctor
    {
        [Key]
        [AutoIncrement]
        public Int16 Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [MaxLength(5, ErrorMessage = "Prefix - Must not enter more than 5 characters.")]
        public string Prefix { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "FirstName is required. \n")]
        [MaxLength(30, ErrorMessage = "FirstName - Must not enter more than 30 characters.")]
        public string FirstName { get; set; }

        [MaxLength(15, ErrorMessage = "Middle - Must not enter more than 15 characters.")]
        public string Middle { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "LastName is required. \n")]
        [MaxLength(30, ErrorMessage = "LastName - Must not enter more than 30 characters.")]
        public string LastName { get; set; }

        [MaxLength(6, ErrorMessage = "Suffix - Must not enter more than 6 characters.\n")]
        public string Suffix { get; set; }

        [MaxLength(40, ErrorMessage = "Address - Must not enter more than 40 characters.")]
        public string Address { get; set; }

        [MaxLength(40, ErrorMessage = "Address2 - Must not enter more than 40 characters.")]
        public string Address2 { get; set; }

        [MaxLength(20, ErrorMessage = "City - Must not enter more than 20 characters.")]
        public string City { get; set; }

        [MaxLength(2, ErrorMessage = "State - Must not enter more than 2 characters.")]
        public string State { get; set; }

        [MaxLength(10, ErrorMessage = "Zip - Must not enter more than 10 characters.")]
        public string Zip { get; set; }

        [MaxLength(15, ErrorMessage = "Phone - Must not enter more than 15 characters.")]
        public string Phone { get; set; }

        [MaxLength(15, ErrorMessage = "Fax - Must not enter more than 15 characters.")]
        public string Fax { get; set; }

        [MaxLength(50, ErrorMessage = "Email - Must not enter more than 50 characters.")]
        public string Email { get; set; }

        [MaxLength(75, ErrorMessage = "PracticeName - Must not enter more than 75 characters.")]
        public string PracticeName { get; set; }

        public Int16? Degree { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "NPI is required. \n")]
        [MaxLength(10, ErrorMessage = "NPI - Must not enter more than 10 characters.")]
        public string NPI { get; set; }

        [MaxLength(10, ErrorMessage = "Comments - Must not enter more than 10 characters.")]
        public string Comments { get; set; }

        public int? PM_Person_NO { get; set; }
        public int? DirectEmailID { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public string FullName
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Middle) ? $"{this.FirstName} {this.LastName}" : $"{this.FirstName} {this.LastName}, {this.Middle}";
            }
        }
    }
}
