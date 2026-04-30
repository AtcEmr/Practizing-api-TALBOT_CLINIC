using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ReportService
{
    public interface IPatientChargePaymentDTO
    {

        #region Generated Properties

         string DueByFlagCD { get; set; }

         DateTime CreatedDate { get; set; }

         decimal ChargeAmount { get; set; }

         string CPTCode { get; set; }

         string Description { get; set; }

         decimal PaidAmount { get; set; }

         decimal AdjustmentAmount { get; set; }

         string AdjustmentReasonCode { get; set; }

         decimal DueAmount { get; set; }     

         int ChargeId { get; set; }

         DateTime DOS { get; set; }

         bool HasPaymentsOrAdjustments { get; set; }
         bool IsCharge { get; set; }
         bool IsPayment { get; set; }

        #endregion
    }

}
