using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.Claim
{
    public interface IInsuranceClaimData : IFileNameData
    {
        int ClaimId { get; }

        string ClaimType { get; }
        string GroupNPI { get; }
        string ReferringProviderFirstName { get; }
        string ReferringProviderLastName { get; }
        string ReferringProviderNPI { get; }

        string InsuranceName { get; }
        string InsuranceAddressPrimary { get; }
        string InsuranceAddressSecondary { get; }
        string InsuranceCityStateZip { get; }

        string PatientFullName { get; }
        DateTime PatientDob { get; }
        GenderType PatientGender { get; }
        string PatientCity { get; }
        string PatientZip { get; }
        string PatientPhone { get; }
        string PatientAreaCode { get; }
        string PatientState { get; }
        string PatientStreet { get; }

        string PatientFirstName { get; }
        string PatientLastName { get; }
        string PatientMiddleName { get; }
        //Add enum
        PatientRelation PatientRelation { get; }


        string InsuranceId { get; }
        string InsuredName { get; }
        string PayerName { get; }
        string PayerAddressLine1 { get; }
        string PayerAddressLine2 { get; }
        string PayerCity { get; }
        string PayerState { get; }
        string PayerZip { get; }
        string InsuredStreet { get; }
        string InsuredCity { get; }
        string InsuredState { get; }
        string InsuredZip { get; }
        string InsuredAreaCode { get; }
        string InsuredPhone { get; }
        string InsuredPolicy { get; }
        DateTime InsuredDob { get; }
        GenderType InsuredGender { get; }
        string InsurancePlanName { get; }
        bool AnotherBenefitPlanExists { get; }
        string PatientSignature { get; }
        string DateOfSign { get; }
        DateTime? DateOfSignAsDate { get; }
        string InsuredSignature { get; }
        string OtherInsuredFullName { get; }
        string OtherInsuredPolicy { get; }
        string OtherInsuredPlanName { get; }

        bool Employment { get; }
        bool AutoAccident { get; }
        //State name
        string AutoAccidentPlace { get; }
        bool OtherAccident { get; }

        DateTime? CurrentIllnesDate { get; }
        DateTime? OtherIllnesDate { get; }
        DatePeriod UnableToWork { get; }
        string PhysicianReference { get; }
        string PhysicianNPI { get; }
        string PhysicianReferenceQualifier { get; }
        

        DatePeriod Hospitalization { get; }
        string AdditionalInformation { get; }
        bool OutsideLab { get; }
        decimal? OutsideLabCharge { get; }
        int ICDIndex { get; }
        string[] Diagnosis { get; }
        string ResubmissionCode { get; }
        string OriginalRefNo { get; }
        string PriorAuthorizationNumber { get; }
        string FederalTaxIdNumber { get; }
        string TaxNumberType { get; }
        string PatientAccountNumber { get; }
        bool AcceptAssignment { get; }
        decimal? TotalCharge { get; }
        decimal? AmountPaid { get; }
        string ServiceFacilityName { get; }
        string ServiceFacilityStreet { get; }
        string ServiceFacilityLocation { get; }
        string ServiceFacilityNpi { get; }
        string ClaimFacilityNpi { get; }


        string BillingProviderPhoneArea { get; }
        string BillingProviderPhone { get; }
        string BillingProviderTelephone { get; }
        string BillingProviderFax { get; }
        string BillingProviderName { get; set; }
        string BillingProviderStreet { get; }
        string BillingsProviderLocation { get; }
        string BillingProviderNpi { get; }
        string BillingProviderCity { get; }
        string BillingProviderZIP { get; }
        string BillingProviderState { get; }

        string BillingProviderSigned { get; }

        DateTime BillingProviderDate { get; }

        string BillingProviderDetails { get; }
        string PerformingLocationNPI { get; }
        //string UB4ClaimBillType { get; }
        string BillTypeCode { get; }

        string Box10Or07 { get; }
        string Box19Or80 { get; }
        IInsuranceService[] Services { get;  }

        string SupervisionDoctorFirstName { get; }
        string SupervisionDoctorLastName { get; }
        string SupervisionDoctorNPI { get; }
        string OrderingDoctorFirstName { get; }
        string OrderingDoctorLastName { get; }
        string OrderingDoctorNPI { get; }

    }

}
