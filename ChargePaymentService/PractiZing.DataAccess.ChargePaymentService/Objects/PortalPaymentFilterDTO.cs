using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PortalPaymentFilterDTO : IPortalPaymentFilterDTO
    {
        [SearchField(PortalPaymentModel.CreatedDate)]
        public string FromDate { get; set; }
        [SearchField(PortalPaymentModel.CreatedDate)]
        public string ToDate { get; set; }
        [SearchField(PortalPaymentModel.IsCommitted)]
        public string IsCommitted { get; set; }
        [SearchField(PortalPaymentModel.IsRefundedRecord)]
        public string IsRefundedRecord { get; set; }
    }

    public class PortalPaymentModel
    {
        public const string TableName = "PortalPayment";
        public const string CreatedDate = TableName + "." + "CreatedDate";
        public const string IsCommitted = TableName + "." + "IsCommitted";
        public const string IsRefundedRecord = TableName + "." + "IsRefundNeeded";
    }

    public class DynmoPaymentFilterDTO: IDynmoPaymentFilterDTO
    {
        [SearchField(DynmoPaymentModel.CreatedDate)]
        public string FromDate { get; set; }
        [SearchField(DynmoPaymentModel.CreatedDate)]
        public string ToDate { get; set; }
        [SearchField(DynmoPaymentModel.IsImportInBilling)]
        public string IsImportInBilling { get; set; }
    }

    public class DynmoPaymentModel
    {
        public const string TableName = "DynmoPayments";
        public const string CreatedDate = TableName + "." + "CreatedDate";
        public const string IsImportInBilling = TableName + "." + "IsImportInBilling";
    }

    public class ChargesReportDataFilterDTO : IChargesReportDataFilterDTO
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int IsPostOrDosDate { get; set; }
        public string ReasonCode { get; set; }
        public string PerformingProviderUId { get; set; }
        public string InsuranceCompanyUId { get; set; }
    }

    public class PaymentReportDataFilterDTO:IPaymentReportDataFilterDTO
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
