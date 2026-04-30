using System;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IInsurancePolicyHolder : IUniqueIdentifier, IStamp
    {
        int Id { get; set; }
        int PatientId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string HomePhone { get; set; }
        string BusPhone { get; set; }
        DateTime? DOB { get; set; }
        string Sex { get; set; }
        string PHRel { get; set; }
        string EmployerAddress1 { get; set; }
        string EmployerAddress2 { get; set; }
        string EmployerCity { get; set; }
        string EmployerState { get; set; }
        string EmployerZip { get; set; }
        string EmployerPhone { get; set; }
        string EmploymentStatus { get; set; }
        string OrganizationName { get; set; }
        byte? MaritalStatusId { get; set; }
        string Student { get; set; }
        Guid PatientUId { get; set; }
    }
}
