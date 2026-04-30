using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IInsuranceCompany : IPracticeDTO, IUniqueIdentifier, IStamp, IActive
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
        int? PMS_ID { get; set; }
        string EXTERNAL_ID { get; set; }
        bool Medigap { get; set; }
        Int16? CompanyTypeId { get; set; }
        Int16? FormTypeId { get; set; }
        Int16? ClearingHouseId { get; set; }
        bool TransmitClaims { get; set; }
        string SubmitterID { get; set; }
        string Color { get; set; }
        bool IsInnetwork { get; set; }
        bool IsGCodeAccepted { get; set; }
        string CrossWalkId { get; set; }
        string EligibilityPayerId { get; set; }
        string Claim_StatusPayerId { get; set; }
        bool IsNew { get; set; }
        bool? IsProviderTaxonomyNeeded { get; set; }
        int? InUse { get; set; }
        int? InsuranceCompanyIdOfPolicy { get; set; }
        string FormType { get; set; }
        string CompanyType { get; set; }
        string ClearingHouseName { get; set; }
        Guid ClearingHouseUId { get; set; }
        bool? IsRefProviderAndRendProviderSame { get; set; }
        bool? PatientElig { get; set; }
        bool? IsLoop2420ARequired { get; set; }
        string TempCompanyCode { get; set; }
        int? MedicaidClearingHouseId { get; set; }
        string MedicaidPayerId { get; set; }
        string MedicaidPayerReceiverId { get; set; }
    }
}
