using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class InsuranceCompany : IInsuranceCompany
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [MaxLength(250, ErrorMessage = "CompanyCode - Must not enter more than 250 characters.")]
        public string CompanyCode { get; set; }

        [MaxLength(250, ErrorMessage = "CompanyName - Must not enter more than 250 characters.")]
        public string CompanyName { get; set; }

        [MaxLength(250, ErrorMessage = "CompanyAddress1 - Must not enter more than 250 characters.")]
        public string CompanyAddress1 { get; set; }

        [MaxLength(250, ErrorMessage = "CompanyAddress2 - Must not enter more than 250 characters.")]
        public string CompanyAddress2 { get; set; }

        [MaxLength(75, ErrorMessage = "CompanyCity - Must not enter more than 75 characters.")]
        public string CompanyCity { get; set; }

        [MaxLength(25, ErrorMessage = "CompanyState - Must not enter more than 25 characters.")]
        public string CompanyState { get; set; }

        [MaxLength(10, ErrorMessage = "CompanyZip - Must not enter more than 10 characters.")]
        public string CompanyZip { get; set; }

        [MaxLength(250, ErrorMessage = "PhoneNumber - Must not enter more than 250 characters.")]
        public string PhoneNumber { get; set; }
        public int? PMS_ID { get; set; }

        [MaxLength(20, ErrorMessage = "EXTERNAL_ID - Must not enter more than 20 characters.")]
        public string EXTERNAL_ID { get; set; }
        public bool Medigap { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Company type is required. ")]
        public Int16? CompanyTypeId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Form type is required. ")]
        public Int16? FormTypeId { get; set; }
        public Int16? ClearingHouseId { get; set; }
        public bool TransmitClaims { get; set; }

        [MaxLength(15, ErrorMessage = "SubmitterID - Must not enter more than 15 characters.")]
        public string SubmitterID { get; set; }

        [MaxLength(60, ErrorMessage = "Color - Must not enter more than 60 characters.")]
        public string Color { get; set; }
        public bool IsInnetwork { get; set; }
        public bool IsGCodeAccepted { get; set; }

        [MaxLength(20, ErrorMessage = "CrossWalkId - Must not enter more than 20 characters.")]
        public string CrossWalkId { get; set; }

        [MaxLength(10, ErrorMessage = "EligibilityPayerId - Must not enter more than 10 characters.")]
        public string EligibilityPayerId { get; set; }

        [MaxLength(10, ErrorMessage = "Claim_StatusPayerId - Must not enter more than 10 characters.")]
        public string Claim_StatusPayerId { get; set; }

        public bool IsActive { get; set; }

        public bool? IsProviderTaxonomyNeeded { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string TempCompanyCode { get; set; }

        private int? _inUse;
        [Ignore]
        public int? InUse
        {
            get
            {
                return _inUse;
            }
            set
            {
                _inUse = this.InsuranceCompanyIdOfPolicy == null ? 0 : 1;
            }
        }
        [Ignore]
        public int? InsuranceCompanyIdOfPolicy { get; set; }
        [Ignore]
        public bool IsNew { get; set; }
        [Ignore]
        public string FormType { get; set; }
        [Ignore]
        public string CompanyType { get; set; }
        [Ignore]
        public string ClearingHouseName { get; set; }
        [Ignore]
        public Guid ClearingHouseUId { get; set; }

        public bool? IsRefProviderAndRendProviderSame { get; set; }
        public bool? IsLoop2420ARequired { get; set; }

        public bool? PatientElig { get; set; }
        public int? MedicaidClearingHouseId { get; set; }
        public string MedicaidPayerId { get; set; }
        public string MedicaidPayerReceiverId { get; set; }

        private string _fullName;
        [Ignore]
        public string FullName
        {
            get {
                _fullName = CompanyCode + "-" + CompanyName + "-" + CompanyType;

                return _fullName;
            }
        }

    }
}
