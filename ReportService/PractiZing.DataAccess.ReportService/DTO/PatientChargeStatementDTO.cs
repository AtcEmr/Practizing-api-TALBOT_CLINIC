using PractiZing.Base.Object.ReportService;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ReportService.DTO
{
    public partial class PatientChargeStatementDTO : IPatientChargeStatementDTO
    {

        #region Generated Properties

        public string FacilityName { get; set; }

        public string FacilityAddress1 { get; set; }

        public string FacilityAddress2 { get; set; }

        public string FacilityCity { get; set; }

        public string FacilityState { get; set; }

        public string FacilityZipCode { get; set; }

        public string FacilityPhone { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string GuarantorFirstName { get; set; } // patient guarantor
        public string GuarantorMiddleName { get; set; } // patient guarantor
        public string GuarantorLastName { get; set; } // patient guarantor

        public string GuarantorAddress1 { get; set; }

        public string GuarantorAddress2 { get; set; }

        public string GuarantorCity { get; set; }

        public string GuarantorState { get; set; }

        public string GuarantorZip { get; set; }


        public string BillAddress1 { get; set; }

        public string BillAddress2 { get; set; }

        public string BillCity { get; set; }

        public string BillState { get; set; }

        public string BillZip { get; set; }

        public int PatientId { get; set; }

        public string BillingId { get; set; }

        public string DunningMessage { get; set; }

        public string PayByWeb { get; set; }

        public string PayByPhoneNumber { get; set; }

        //public DateTime CreatedDate { get; set; }

        //public DateTime DOS { get; set; }

        //public decimal ChargeAmount { get; set; }

        //public string CPTCode { get; set; }

        //public string Description { get; set; }

        //public decimal PaidAmount { get; set; } = 0;

        //public decimal AdjustmentAmount { get; set; } = 0;

        //public string AdjustmentReasonCode { get; set; }

        //public decimal DueAmount { get; set; } = 0;

        //public string DueByFlagCD { get; set; } = string.Empty;

        public string RemitAddress1 { get; set; }

        public string RemitAddress2 { get; set; }

        public string RemitCity { get; set; }

        public string RemitState { get; set; }

        public string RemitZipCode { get; set; }

        public string RemitPhone { get; set; }
        public int ChargeId { get; set; }        

        //public int FacilityId { get; set; }

        public decimal TotalDueAmount { get; set; }

        public string PracticeName { get; set; }
        //public DateTime? FromDate { get; set; }
        //public DateTime? ToDate { get; set; }

        public DateTime StatementDate { get; set; }

        public DateTime DueDate { get; set; }
        public string StatementMessage { get; set; }
        public string Note { get; set; }
        public int? PatientStatementCount { get; set; }

        public decimal Current { get; set; } = 0;

        public decimal Over30Days { get; set; } = 0;

        public decimal Over60Days { get; set; } = 0;

        public decimal Over90Days { get; set; } = 0;

        public decimal Over120Days { get; set; } = 0;

        // patient charges, payments and adjustments
        public ICollection<IPatientChargePaymentDTO> ChargePayments { get; set; }

        #endregion
    }
}
