using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PaymentReportData : IPaymentReportData
    {

        public PaymentReportData()
        {
            
        }

        [Key]
        [AutoIncrement]
        public long Id { get; set; }

        public int ChargeId { get; set; }
        public DateTime ChargePostDate { get; set; }
        public DateTime DosDate { get; set; }
        public string CptCode { get; set; }
        public string Description { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal? Payment { get; set; }
        public decimal? Adjustment { get; set; }
        public string PaymentPostDate { get; set; }
        public DateTime RemitDate { get; set; }
        public int PatientId { get; set; }
        public string BillingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string PatientUId { get; set; }
        public string PerformingProviderUId { get; set; }
        public string PatientCaseUId { get; set; }
        public string InvoiceUId { get; set; }
        public string PatientName { get; set; }
        public string AccessionNumber { get; set; }
        public string Aging { get; set; }
        public string AgingText { get; set; }
        public string AgingByPostDate { get; set; }
        public string AgingByPostDateText { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DepositCreationDate { get; set; }
        public int ChargeRowNumber { get; set; }
        public int InvoiceId { get; set; }
        public string DepositType { get; set; }
        public bool? HasDenial { get; set; }
        public bool? IsAccounted { get; set; }

    }
}
