using PractiZing.Base.Entities.MasterService;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class Practice : IPractice
    {
        [Key]
        public int Id { get; set; }

        public Guid UId { get; set; }

        public string PracticeCode { get; set; }

        public string PracticeName { get; set; }

        public string PracticeCodeCLM { get; set; }

        public int PracticeCentralId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
        public bool? IsAutomatedClaim { get; set; }

        public string OnlinePaymentURL { get; set; }

        public string StripePracticeName { get; set; }

        public string EMRURL { get; set; }

        public string EMRPassword { get; set; }

        public string EMRUserName { get; set; }

        public string LogoName { get; set; }

        public string EMRChargeGetApi { get; set; }

        public bool IsMentalACT { get; set; }

        public string FavIcon { get; set; }

        public string EMRChargeUpdateApi { get; set; }

        public string QuickSiteAccessKey { get; set; }
        public string QuickSiteSecretKey { get; set; }
        public string QuickSiteAWSAccointId { get; set; }
        public string QuickSiteRoleName { get; set; }
        public string QuickSiteRoleSessionName { get; set; }
        public string QuickSiteRegionEndpoint { get; set; }
        public string QuickSiteDashboardId { get; set; }
        public string QuickSiteSessionLifetimeInMinutes { get; set; }
        public string ChargeRejectionCode { get; set; }
        public bool IsRequiredInsuranceAddEdit { get; set; }
        public string LabURL { get; set; }
        public int AutoStatementCount { get; set; }

        public string DailyChargesEmail { get; set; }
        public string SmtpUrl { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        
    }
}
