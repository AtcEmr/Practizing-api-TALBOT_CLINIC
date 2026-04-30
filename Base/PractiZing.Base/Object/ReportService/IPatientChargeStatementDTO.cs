using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ReportService
{
    public interface IPatientChargeStatementDTO
    {
        #region Generated Properties

        string FacilityName { get; set; }

        string FacilityAddress1 { get; set; }

         string FacilityAddress2 { get; set; }

         string FacilityCity { get; set; }

         string FacilityState { get; set; }

         string FacilityZipCode { get; set; }

         string FacilityPhone { get; set; }

         string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }

         string GuarantorFirstName { get; set; } // patient guarantor
        string GuarantorMiddleName { get; set; } // patient guarantor
        string GuarantorLastName { get; set; } // patient guarantor

        string GuarantorAddress1 { get; set; }

         string GuarantorAddress2 { get; set; }

         string GuarantorCity { get; set; }

         string GuarantorState { get; set; }

         string GuarantorZip { get; set; }


         string BillAddress1 { get; set; }

         string BillAddress2 { get; set; }

         string BillCity { get; set; }

         string BillState { get; set; }

         string BillZip { get; set; }

         int PatientId { get; set; }

         string BillingId { get; set; }

         string DunningMessage { get; set; }

         string PayByWeb { get; set; }

         string PayByPhoneNumber { get; set; }

        // DateTime CreatedDate { get; set; }

        // DateTime DOS { get; set; }

        // decimal ChargeAmount { get; set; }

        // string CPTCode { get; set; }

        // string Description { get; set; }

        // decimal PaidAmount { get; set; } = 0;

        // decimal AdjustmentAmount { get; set; } = 0;

        // string AdjustmentReasonCode { get; set; }

        // decimal DueAmount { get; set; } = 0;

        // string DueByFlagCD { get; set; } = string.Empty;

         string RemitAddress1 { get; set; }

         string RemitAddress2 { get; set; }

         string RemitCity { get; set; }

         string RemitState { get; set; }

         string RemitZipCode { get; set; }

         string RemitPhone { get; set; }
         int ChargeId { get; set; }        

        // int FacilityId { get; set; }

         decimal TotalDueAmount { get; set; }

         string PracticeName { get; set; }
        // DateTime? FromDate { get; set; }
        // DateTime? ToDate { get; set; }

         DateTime StatementDate { get; set; }

         DateTime DueDate { get; set; }
         string StatementMessage { get; set; }
        string Note { get; set; }
        int? PatientStatementCount { get; set; }

         decimal Current { get; set; }

         decimal Over30Days { get; set; }

         decimal Over60Days { get; set; }

         decimal Over90Days { get; set; }

         decimal Over120Days { get; set; }

        // patient charges, payments and adjustments
         ICollection<IPatientChargePaymentDTO> ChargePayments { get; set; }

        #endregion
    }
}
