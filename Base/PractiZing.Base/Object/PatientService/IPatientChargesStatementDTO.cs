using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientChargesStatementDTO
    {
        int ChargeId { get; set; }
        DateTime ChargeDate { get; set; }
        string ChargeDescription { get; set; }
        string CPTCodes { get; set; }
        decimal ChargeAmount { get; set; }
        decimal PaidAmount { get; set; }
        decimal AdjustmentAmount { get; set; }
        decimal BalanceAmount { get; set; }
        string DueByFlagCD { get; set; }
        string InsuranceCompanyName { get; set; }
        int InsuranceCompanyId { get; set; }
        DateTime? PaymentDate { get; set; }
        DateTime? AdjustmentDate { get; set; }
        int PaymentId { get; set; }

        IEnumerable<IPaymentCharge> PaymentCharges { get; set; }
        IEnumerable<IPaymentAdjustment> PaymentAdjustments { get; set; }
    }
}
