using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IFacility : IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        Int16 Id { get; set; }
        string Name { get; set; }
        string ChildFacilityName { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string city { get; set; }
        string state { get; set; }
        string ZipCode { get; set; }
        string Phone { get; set; }
        string FacilityCode { get; set; }
        string FacilityDescription { get; set; }
        string Fax { get; set; }
        string POSCode { get; set; }
        string POSCodeDesc { get; set; }
        string LocationCode { get; set; }

        string TimeZone { get; set; }
        string ServiceTypeCode { get; set; }

        string ContactName { get; set; }
        int? FacilitySubTypeId { get; set; }
        Int16? DefaultProviderId { get; set; }
        bool? IsDefault { get; set; }
        string VenderId { get; set; }
        int? ParentId { get; set; }
        bool? IsMentalDefault { get; set; }
        int? EMRFacilityId { get; set; }
        bool? IsMentalFacility { get; set; }

    }
}
