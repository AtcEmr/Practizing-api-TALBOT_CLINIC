using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ReversePaymentReportDTO: IReversePaymentReportDTO
    {   
        public int ChargeId { get; set; }
        public int PatientId { get; set; }
        public string BillingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Provider { get; set; }
        public DateTime DosDate { get; set; }
        public string CptCode { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal TakeBackAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CheckNumber { get; set; }
        public decimal DueAmount { get; set; }
        public string AdjustCode { get; set; }
        public string AdjustReason { get; set; }
        public string RemarkCode { get; set; }
        public string RemarkMessage { get; set; }
        public decimal ActualPayment { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public string InsuranceCompany { get; set; }
        public string AccessionNumber { get; set; }
        public string PatientUId { get; set; }
        public string DueBy { get; set; }
        public string PaymentPostDate { get; set; }
        public string RemitDate { get; set; }
    }
}
