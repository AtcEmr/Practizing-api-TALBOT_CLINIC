using System;

namespace PractiZing.Base.Model.Master
{
    public interface IInsuranceCompaniesDTO
    {
        int Id { get; set; }
        string CompanyCode { get; set; }
        string CompanyName { get; set; }
        string CompanyAddress1 { get; set; }
        string CompanyAddress2 { get; set; }
        string CompanyCity { get; set; }
        string CompanyState { get; set; }
        string CompanyZip { get; set; }
        string PhoneNumber { get; set; }
        int InsuranceCompanyID { get; set; }
        int PracticeId { get; set; }
        int? PMS_ID { get; set; }
        string EXTERNAL_ID { get; set; }
        bool Medigap { get; set; }
        Int16? CompanyTypeId { get; set; }
        Int16? FormTypeId { get; set; }
        Int16? ClearingHouseId { get; set; }
        bool? TransmitClaims { get; set; }
        string InsuranceCompanyTypeName { get; set; }
        Guid UId { get; set; }
        string CompanyType { get; set; }
    }
}
