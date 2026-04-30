using System;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IConfigHCFAFormField : IModifiedStamp
    {
        int InsuranceCompanyOrTypeId { get; set; }
        int CompanyTypeId { get; set; }
        int ViewType { get; set; }
        string Reserved10 { get; set; }
        Int16? Box24 { get; set; }
        bool? NumberOnly { get; set; }
        string ClaimType { get; set; }
        string FilingCode { get; set; }
        string PIN { get; set; }
        string GRP { get; set; }
        string Box11 { get; set; }
        bool? Blank9abcd { get; set; }
        bool? Blank11abc { get; set; }
        bool? BlankBalance { get; set; }
        bool? NASecondary { get; set; }
        string Box23 { get; set; }
        string Res10Provider { get; set; }
        bool? Box9Same { get; set; }
        bool? MedigapOnly { get; set; }
        bool? Box11dBlank { get; set; }
        string Box9aPrefix { get; set; }
        bool? Box9cAddress { get; set; }
        bool? Box9dPayorId { get; set; }
        string Box9a { get; set; }
        bool? ExcludeAdjustments { get; set; }
        bool? Box1aBlank { get; set; }
        bool? LabOnly { get; set; }
        string FacilityNum { get; set; }
        bool? NoRend { get; set; }
        string SplitBy { get; set; }
        bool? ShowCPTDesc { get; set; }
        string Box17Over { get; set; }
        bool? OverrideBox17 { get; set; }
        bool? Box31Clinic { get; set; }
        bool? Box14 { get; set; }
        bool? NPIAlways { get; set; }
        bool? GroupNPI { get; set; }
        bool? Box33bSpace { get; set; }
        string Box33 { get; set; }
        bool? AuthNum { get; set; }
        bool? EoB { get; set; }
        bool? Box11cPayorID { get; set; }
        string Medicare2 { get; set; }
        int? AmtPaid { get; set; }
        string Box4_7 { get; set; }
        bool? MSP { get; set; }
        bool? HideDecimalPt { get; set; }
        string TextArea_Claim { get; set; }
        bool? IsLoop2420E { get; set; }
        bool? IsLoop2420D { get; set; }
    }
}
