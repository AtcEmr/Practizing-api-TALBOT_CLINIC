using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IPractice
    {
        int Id { get; set; }

        Guid UId { get; set; }

        string PracticeCode { get; set; }

        string PracticeName { get; set; }

        int PracticeCentralId { get; set; }

        string PracticeCodeCLM { get; set; }

        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime ModifiedDate { get; set; }

        string ModifiedBy { get; set; }

        bool? IsAutomatedClaim { get; set; }
        string OnlinePaymentURL { get; set; }
        string StripePracticeName { get; set; }
        string EMRURL { get; set; }
        string EMRPassword { get; set; }

        string EMRUserName { get; set; }
        string LogoName { get; set; }
        string EMRChargeGetApi { get; set; }
        string EMRChargeUpdateApi { get; set; }
        bool IsMentalACT { get; set; }
        string FavIcon { get; set; }

        string QuickSiteAccessKey { get; set; }
        string QuickSiteSecretKey { get; set; }
        string QuickSiteAWSAccointId { get; set; }
        string QuickSiteRoleName { get; set; }
        string QuickSiteRoleSessionName { get; set; }
        string QuickSiteRegionEndpoint { get; set; }
        string QuickSiteDashboardId { get; set; }
        string QuickSiteSessionLifetimeInMinutes { get; set; }
        string ChargeRejectionCode { get; set; }
        bool IsRequiredInsuranceAddEdit { get; set; }
        string LabURL { get; set; }
        int AutoStatementCount { get; set; }

        string DailyChargesEmail { get; set; }
        string SmtpUrl { get; set; }
        string SmtpPort { get; set; }
        string SmtpUserName { get; set; }
        string SmtpPassword { get; set; }
    }
}
