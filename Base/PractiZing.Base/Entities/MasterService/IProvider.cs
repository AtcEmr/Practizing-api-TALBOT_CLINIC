using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IProvider : IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        Int16 Id { get; set; }
        Int16? PUserId { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string Middle { get; set; }
        string FullName { get; }
        string FullNameForClaim { get; }
        string Suffix { get; set; }
        string Prefix { get; set; }
        Int16 FacilityId { get; set; }
        string License { get; set; }
        byte?[] Signature { get; set; }
        bool TOC { get; set; }
        int Slot { get; set; }
        string SSN { get; set; }
        Int16? SpecialtyId { get; set; }
        string Specialty { get; set; }
        bool? BillUnderGroupNPI { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsProviderAUser { get; set; }
        string SpecialityName { get; set; }
        bool? IsDefault { get; set; }
        Guid FacilityUId { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        int? PractitionerServiceId { get; set; }
        int? SUDPractitionerServiceId { get; set; }        
        Int16? SupervisorId { get; set; }
        bool? IsBillUnderSupervisor { get; set; }
        Int16? SupervisionTypeId { get; set; }
        Guid? SupervisorUId { get; set; }
        int? ServiceCircumstanceId { get; set; }
        string ProfessionalAbbreviation { get; set; }       
        string ProvidingService { get; set; }
        string Qualification { get; set; }
        string Designation { get; set; }
        string SupervisorName { get; set; }
        int? EmrProviderId { get; set; }
        bool? IsPrescriber { get; set; }
        Int16? SwapProviderId { get; set; }
        Guid? SwapProviderUId { get; set; }
        string SUDProfessionalAbbreviation { get; set; }
        string SUDProvidingService { get; set; }
    }
}
