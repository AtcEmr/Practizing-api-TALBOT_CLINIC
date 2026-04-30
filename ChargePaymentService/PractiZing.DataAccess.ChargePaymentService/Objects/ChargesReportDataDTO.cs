using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargesReportDataDTO : IChargesReportDataDTO
    {
        public ChargesReportDataDTO()
        {
            Charges = new List<ChargesReportData>();
        }
        public long TotalSamples { get; set; }
        public decimal? ChargesAmount { get; set; }
        public decimal? Payments { get; set; }
        public decimal? Adjustments { get; set; }
        public decimal? DenialsAmount { get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? FeeAmount { get; set; }
        public decimal? WriteOffAmount { get; set; }
        
        public  IEnumerable<IChargesReportData> Charges { get; set; }
    }

    public class CPAReportDTO : ICPAReportDTO
    {
        public decimal? ThirtyDaysBalance { get; set; }
        public decimal? SixtyDaysBalance { get; set; }
        public decimal? AboveNintyBalance { get; set; }
        public decimal? UnAdjucatedBalance { get; set; }
        public decimal? UnderPaid { get; set; }
        public decimal? BillableButNotClaimed { get; set; }
        public decimal? NotBillableClaim { get; set; }
        public decimal? UnTouchCharges { get; set; }
        public decimal? InWriteOffRequest { get; set; }
        public decimal? AllCharges { get; set; }
        public decimal? ClaimFillingLimit { get; set; }
        public decimal? RejectedCharges { get; set; }
        public decimal? TotalWriteOff { get; set; }
        public decimal? PayerRatherThanSelfAmount { get; set; }
        public decimal? BilledVsCurrentIns { get; set; }
    }

    public class PatientBalanceForEMR: IPatientBalanceForEMR
    {
        public int PatientId { get; set; }
        public string BillingID { get; set; }
        public string EmrBillingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string CptCode { get; set; }
        public DateTime DosDate { get; set; }
        public string Provider { get; set; }
        public decimal? ChargeAmount { get; set; }
        public decimal? FeeAmount { get; set; }
        public decimal? Payment { get; set; }
        public decimal? Adjustment { get; set; }
        public string AdjustmentCode { get; set; }
        public decimal? DueAmount { get; set; }
        public string DBName { get; set; }
        public bool? IsMedicaidCharge { get; set; }
    }

    public class BalanceForEMR : IBalanceForEMR
    {        
        public string BillingID { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }                
        public decimal? DueAmount { get; set; }
        public string PatientPhone { get; set; }
        public string PatientCaseUId { get; set; }
        public DateTime DosDate { get; set; }
        public int PatientCaseId { get; set; }
        public decimal UnPostedAmount { get; set; }
        public decimal UnMatchedAmount { get; set; }
        public string DBName { get; set; }
    }
}
