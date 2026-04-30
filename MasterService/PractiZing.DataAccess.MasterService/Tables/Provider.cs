using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class Provider : IProvider
    {
        [Key]
        [AutoIncrement]
        public Int16 Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public Int16? PUserId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(30, ErrorMessage = "LastName - Must not enter more than 30 characters.")]
        public string LastName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(30, ErrorMessage = "FirstName - Must not enter more than 30 characters.")]
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "Middle - Must not enter more than 30 characters.")]
        public string Middle { get; set; }

        [Ignore]
        public string FullName
        {
            get
            {
                return string.IsNullOrEmpty(this.Middle) ? $"{this.LastName} {this.FirstName}" : $"{this.LastName} {this.FirstName}, {this.Middle}";
            }
        }

        [Ignore]
        public string FullNameForClaim
        {
            get
            {
                return $"{FirstName}, {LastName} {Middle}";
                //return $"{this.LastName} {this.FirstName}, {this.Middle}";
            }
        }

        [MaxLength(10, ErrorMessage = "Suffix - Must not enter more than 10 characters.")]
        public string Suffix { get; set; }

        [MaxLength(10, ErrorMessage = "Prefix - Must not enter more than 10 characters.")]
        public string Prefix { get; set; }

        public Int16 FacilityId { get; set; }


        [MaxLength(35, ErrorMessage = "License - Must not enter more than 35 characters.")]
        public string License { get; set; }

        [Ignore]
        public byte?[] Signature { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public bool TOC { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int Slot { get; set; }

        [MaxLength(11, ErrorMessage = "SSN - Must not enter more than 11 characters.")]
        public string SSN { get; set; }
        public Int16? SpecialtyId { get; set; }

        [MaxLength(15, ErrorMessage = "Specialty - Must not enter more than 15 characters.")]
        public string Specialty { get; set; }

        public bool? BillUnderGroupNPI { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public int? EmrProviderId { get; set; }
        public bool? IsPrescriber { get; set; }
        [Ignore]
        public string UserName { get; set; }
        [Ignore]
        public string Password { get; set; }
        [Ignore]
        public bool IsProviderAUser { get; set; }
        [Ignore]
        public string SpecialityName { get; set; }
        [Ignore]
        public Guid FacilityUId { get; set; }
        [Ignore]
        public Guid? SupervisorUId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int? PractitionerServiceId { get; set; }
        public int? SUDPractitionerServiceId { get; set; }
        public Int16? SupervisorId { get; set; }
        public Int16? SwapProviderId { get; set; }
        
        public bool? IsBillUnderSupervisor { get; set; }
        public Int16? SupervisionTypeId { get; set; }
        public int? ServiceCircumstanceId { get; set; }
        [Ignore]
        public string ProfessionalAbbreviation { get; set; }
        [Ignore]
        public string ProvidingService { get; set; }
        [Ignore]
        public string Designation { get; set; }
        [Ignore]
        public string Qualification { get; set; }
        [Ignore]
        public string SupervisorName { get; set; }
        [Ignore]
        public Guid? SwapProviderUId { get; set; }
        [Ignore]
        public string SUDProfessionalAbbreviation { get; set; }
        [Ignore]
        public string SUDProvidingService { get; set; }
    }
}
