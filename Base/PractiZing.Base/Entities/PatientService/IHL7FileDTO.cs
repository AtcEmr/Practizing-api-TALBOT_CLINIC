using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IHL7FileDTO
    {
        
        int CaseType { get; set; }
        string DrivingLicenseNo { get; set; }
        string ClientName { get; set; }
        string ReferringNPI { get; set; }
        string Location { get; set; }
        short BillFacilityId { get; set; }
        Guid BillFacilityUId { get; set; }
        short? PerformingFacilityId { get; set; }
        Guid? PerformingFacilityUId { get; set; }
        //IEnumerable<int> InsuranceCompanyId { get; set; }

        //IInsuranceGuarantor InsuranceGuarantor { get; set; }

        IInvoice Invoice { get; set; }
        List<IDiagnosisDTO> DiagnosisDTOs { get; set; }
        string ProviderName { get; set; }
        string POSCode { get; set; }
        
        string ReferringProviderAddress1 { get; set; }

        string ReferringProviderAddress2 { get; set; }

        string ReferringProviderCity { get; set; }

        string ReferringProviderState { get; set; }

        string ReferringProviderZip { get; set; }

        string ReferringProviderFirstName { get; set; }

        string ReferringProviderLastName { get; set; }
        int LabClientID { get; set; }
        string RenderingProviderFirstName { get; set; }
        string RenderingProviderLastName { get; set; }
        string RenderingProviderNPI { get; set; }
        string RenderingProviderSupervisorFirstName { get; set; }
        string RenderingProviderSupervisorLastName { get; set; }
        string RenderingProviderSupervisorNPI { get; set; }
        string BillingFacilityNPI { get; set; }
        string BillingFacilityCode { get; set; }
        string PerformingFacilityNPI { get; set; }
        string PerformingFacilityCode { get; set; }
        string TOSCode { get; set; }
        
        string BillingProviderFirstName { get; set; }
        string BillingProviderLastName { get; set; }
        string BillingProviderNPI { get; set; }
        short? PatientBillTypeId { get; set; }
        IEnumerable<IInsurancePolicy> InsurancePolicy { get; set; }
        string OrderingProviderFirstName { get; set; }
        string OrderingProviderLastName { get; set; }
        string OrderingProviderNPI { get; set; }
        bool? IsPrimaryCareNPI { get; set; }
    }
}
