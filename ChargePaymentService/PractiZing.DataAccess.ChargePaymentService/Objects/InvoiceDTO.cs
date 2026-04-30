using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class InvoiceDTO : IInvoiceDTO
    {
        public int InvoiceId { get; set; }
        public string BatchNo { get; set; }
        public string AccessionNumber { get; set; }
        public string DOS { get; set; }        
        public string PatientName { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string OrderingPhysician { get; set; }                                     
        public string PostDate { get; set; }        
        public decimal ChargeAmount { get; set; }        
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
        public string ICDCodes { get; set; }
        public string ChargeType { get; set; }
    }

    public class DataFormDenailFileDTO : IDataFormDenailFileDTO
    {
        public string PatientAccountNumber { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientDOB { get; set; }
        public string AccessionNumber { get; set; }
        public string CPTCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillFromDate { get; set; }
        public string ReasonCode { get; set; }
        public string ProviderFirstName { get; set; }
        public string ProviderLastName { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string ProviderQualification { get; set; }
        public string CPTModifier { get; set; }
        public int PatientCaseId { get; set; }
        
    }
}
