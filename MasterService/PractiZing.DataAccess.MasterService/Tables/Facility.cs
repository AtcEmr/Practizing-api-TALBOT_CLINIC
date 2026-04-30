using PractiZing.Base.Entities;
using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    [Alias("Facility")]
    public class Facility : IFacility, IEntity
    {
        [Key]
        [AutoIncrement]
        public Int16 Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [MaxLength(59, ErrorMessage = "Name - Must not enter more than 59 characters.")]
        public string Name { get; set; }
        [MaxLength(59, ErrorMessage = "Child Facility Name - Must not enter more than 59 characters.")]
        public string ChildFacilityName { get; set; }

        [MaxLength(35, ErrorMessage = "Address1 - Must not enter more than 35 characters.")]
        public string Address1 { get; set; }
        [MaxLength(35, ErrorMessage = "Address2 - Must not enter more than 35 characters.")]
        public string Address2 { get; set; }
        [MaxLength(35, ErrorMessage = "city - Must not enter more than 35 characters.")]
        public string city { get; set; }
        [MaxLength(2, ErrorMessage = "state - Must not enter more than 2 characters.")]
        public string state { get; set; }
        [MaxLength(10, ErrorMessage = "ZipCode - Must not enter more than 10 characters.")]
        public string ZipCode { get; set; }
        [MaxLength(25, ErrorMessage = "Phone - Must not enter more than 25 characters.")]
        public string Phone { get; set; }

        [MaxLength(5, ErrorMessage = "FacilityCode - Must not enter more than 5 characters.")]
        public string FacilityCode { get; set; }
        [MaxLength(50, ErrorMessage = "FacilityDescription - Must not enter more than 50 characters.")]
        public string FacilityDescription { get; set; }

        [MaxLength(25, ErrorMessage = "Fax - Must not enter more than 25 characters.")]
        public string Fax { get; set; }
        [MaxLength(2, ErrorMessage = "POSCode - Must not enter more than 2 characters.")]
        public string POSCode { get; set; }
        [Ignore]
        public string POSCodeDesc { get; set; }
        [MaxLength(5, ErrorMessage = "LocationCode - Must not enter more than 5 characters.")]
        public string LocationCode { get; set; }

        [MaxLength(100, ErrorMessage = "TimeZone - Must not enter more than 100 characters.")]
        public string TimeZone { get; set; }

        [MaxLength(2, ErrorMessage = "ServiceTypeCode - Must not enter more than 2 characters.")]
        public string ServiceTypeCode { get; set; }

        [MaxLength(100, ErrorMessage = "ContactName - Must not enter more than 100 characters.")]
        public string ContactName { get; set; }
        public Int16? DefaultProviderId { get; set; }

        public bool IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? FacilitySubTypeId { get; set; }
        public string VenderId { get; set; }
        public int? ParentId { get; set; }
        public bool? IsMentalDefault { get; set; }
        public int? EMRFacilityId { get; set; }
        public bool? IsMentalFacility { get; set; }
        [Ignore]
        public string KeyID => Id.ToString();
    }
}
