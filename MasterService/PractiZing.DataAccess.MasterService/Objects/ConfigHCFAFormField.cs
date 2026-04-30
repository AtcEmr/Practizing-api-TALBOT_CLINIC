using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class ConfigHCFAFormField : IConfigHCFAFormField
    {
        [Key]
        public int InsuranceCompanyOrTypeId { get; set; }


        public int CompanyTypeId { get; set; }

        public int ViewType { get; set; }

        public string Reserved10 { get; set; }

        public Int16? Box24 { get; set; }

        public bool? NumberOnly { get; set; }

        public string ClaimType { get; set; }

        public string FilingCode { get; set; }

        public string PIN { get; set; }

        public string GRP { get; set; }

        public string Box11 { get; set; }

        public bool? Blank9abcd { get; set; }

        public bool? Blank11abc { get; set; }

        public bool? BlankBalance { get; set; }

        public bool? NASecondary { get; set; }

        public string Box23 { get; set; }

        public string Res10Provider { get; set; }

        public bool? Box9Same { get; set; }

        public bool? MedigapOnly { get; set; }

        public bool? Box11dBlank { get; set; }

        public string Box9aPrefix { get; set; }

        public bool? Box9cAddress { get; set; }

        public bool? Box9dPayorId { get; set; }

        public string Box9a { get; set; }

        public bool? ExcludeAdjustments { get; set; }

        public bool? Box1aBlank { get; set; }

        public bool? LabOnly { get; set; }

        public string FacilityNum { get; set; }

        public bool? NoRend { get; set; }

        public string SplitBy { get; set; }

        public bool? ShowCPTDesc { get; set; }

        public string Box17Over { get; set; }

        public bool? OverrideBox17 { get; set; }

        public bool? Box31Clinic { get; set; }

        public bool? Box14 { get; set; }

        public bool? NPIAlways { get; set; }

        public bool? GroupNPI { get; set; }

        public bool? Box33bSpace { get; set; }

        public string Box33 { get; set; }


        public bool? AuthNum { get; set; }

        public bool? EoB { get; set; }

        public bool? Box11cPayorID { get; set; }

        public string Medicare2 { get; set; }

        public string Box4_7 { get; set; }

        public bool? MSP { get; set; }

        public int? AmtPaid { get; set; }

        public bool? HideDecimalPt { get; set; }

        public string TextArea_Claim { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? IsLoop2420E { get; set; }

        public bool? IsLoop2420D { get; set; }
    }
}
