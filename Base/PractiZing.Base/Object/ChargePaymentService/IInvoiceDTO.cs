using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IInvoiceDTO
    {
        int InvoiceId { get; set; }
        string BatchNo { get; set; }
        string AccessionNumber { get; set; }
        string DOS { get; set; }
        string PatientName { get; set; }
        string InsuranceCompanyName { get; set; }
        string OrderingPhysician { get; set; }
        string PostDate { get; set; }
        decimal ChargeAmount { get; set; }
        decimal Interest { get; set; }
        decimal Balance { get; set; }
        string ICDCodes { get; set; }
        string ChargeType { get; set; }
    }

    public interface IDataFormDenailFileDTO
    {
        string PatientAccountNumber { get; set; }
        string PatientFirstName { get; set; }
        string PatientLastName { get; set; }
        DateTime PatientDOB { get; set; }
        string AccessionNumber { get; set; }
        string CPTCode { get; set; }
        decimal Amount { get; set; }
        DateTime BillFromDate { get; set; }
        string ReasonCode { get; set; }
        string ProviderFirstName { get; set; }
        string ProviderLastName { get; set; }
        string InsuranceCompanyName { get; set; }
        string ProviderQualification { get; set; }
        string CPTModifier { get; set; }        
    }
}
