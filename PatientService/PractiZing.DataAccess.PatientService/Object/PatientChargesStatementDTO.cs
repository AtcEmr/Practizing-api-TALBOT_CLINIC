using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.PatientService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientChargesStatementDTO : IPatientChargesStatementDTO
    {
        public PatientChargesStatementDTO()
        {
            this.PaymentCharges = new List<PaymentCharge>();
            this.PaymentAdjustments = new List<PaymentAdjustment>();
        }

        public int ChargeId { get; set; }
        public DateTime ChargeDate { get; set; }
        public string ChargeDescription { get; set; }
        public string CPTCodes { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string DueByFlagCD { get; set; }
        public string InsuranceCompanyName { get; set; }
        public int InsuranceCompanyId { get; set; }

        [Ignore]
        public int PaymentId { get; set; }
        [Ignore]
        public DateTime? PaymentDate { get; set; }
        [Ignore]
        public DateTime? AdjustmentDate { get; set; }
        [Ignore]
        public IEnumerable<IPaymentCharge> PaymentCharges { get; set; }
        [Ignore]
        public IEnumerable<IPaymentAdjustment> PaymentAdjustments { get; set; }
    }
}
