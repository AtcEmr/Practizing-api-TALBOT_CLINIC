using PractiZing.Base.Object.ReportService;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ReportService.DTO
{
    public partial class PatientChargePaymentDTO : IPatientChargePaymentDTO
    {

        #region Generated Properties

        public string DueByFlagCD { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public decimal ChargeAmount { get; set; }

        public string CPTCode { get; set; }

        public string Description { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal AdjustmentAmount { get; set; }

        public string AdjustmentReasonCode { get; set; }

        public decimal DueAmount { get; set; }     

        public int ChargeId { get; set; }

        public DateTime DOS { get; set; }

        public bool HasPaymentsOrAdjustments { get; set; }
        public bool IsCharge { get; set; }
        public bool IsPayment { get; set; }

        #endregion
    }

}
