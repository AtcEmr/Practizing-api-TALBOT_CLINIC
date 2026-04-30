using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Model.Claim;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.Common;
using System.Linq;
using System;


namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class Cms1500ClaimData : IInsuranceClaimData
    {
        public Cms1500ClaimData(IClaim claim)
        {
            _claim = claim;
            Services = _claim.InsuranceServices.Select(x => new InsuranceService(x, _claim.GRP, !string.IsNullOrWhiteSpace( claim.GroupNPI)? claim.GroupNPI: claim.PerformingDoctorNPI)).ToArray(); ;
        }

        private readonly IClaim _claim;

        public string SupervisionDoctorFirstName => _claim.SupervisionDoctorFirstName;
        public string SupervisionDoctorLastName => _claim.SupervisionDoctorLastName;
        public string SupervisionDoctorNPI => _claim.SupervisionDoctorNPI;
        public string OrderingDoctorFirstName => _claim.OrderingDoctorFirstName;
        public string OrderingDoctorLastName => _claim.OrderingDoctorLastName;
        public string OrderingDoctorNPI => _claim.OrderingDoctorNPI;


        public string GroupNPI => _claim.GroupNPI;

        public string ReferringProviderFirstName => _claim.ReferringPhyFirstName;

        public string ReferringProviderLastName => _claim.ReferringPhyLastName;

        public string ReferringProviderNPI => _claim.ReferringPhysicianNpi;

        public int ClaimId => _claim.Id;

        public string ClaimType => Enum.GetName(typeof(AddClaimImfoEnum), _claim.ClaimType);

        public string InsuranceName => _claim.ClaimToAddress1;

        public string InsuranceAddressPrimary => _claim.ClaimToAddress2;

        public string InsuranceAddressSecondary => "";

        public string PayerAddressLine1 => _claim.ClaimToAddress2;

        public string PayerAddressLine2 => "";

        public string PayerCity => _claim.ClaimToCity;

        public string PayerState => _claim.ClaimToState;

        public string PayerZip => _claim.ClaimToZip;

        public string InsuranceCityStateZip => $"{_claim.ClaimToCity} {_claim.ClaimToState} {_claim.ClaimToZip}";

        public string PatientFullName => _claim.PatientLastName + ", " + _claim.PatientFirstName + " " + _claim.PatientMiddleName;

        public DateTime PatientDob => _claim.PatientDOB.Value;

        public GenderType PatientGender => GetGender(_claim.PatientGender, false);

        public string PatientCity => _claim.PatientCity;

        public string PatientZip => _claim.PatientZip;

        public string PatientPhone => _claim.PatientPhone;

        public string PatientAreaCode => _claim.PatientAreaCode;

        public string PatientState => _claim.PatientState;

        public string PatientStreet => _claim.PatientStreet;

        public string PatientFirstName => _claim.PatientFirstName;

        public string PatientLastName => _claim.PatientLastName;

        public string PatientMiddleName => _claim.PatientMiddleName;

        public string UB4ClaimBillType => _claim.BillTypeCode;

        public PatientRelation PatientRelation
        {
            get
            {
                PatientRelation result;
                switch (_claim.PolicyHolderRelation.Value)
                {
                    case (int)(RelationshipEnum.Self):
                        result = PatientRelation.Self;
                        break;
                    case (int)(RelationshipEnum.Spouse):
                        result = PatientRelation.Spouse;
                        break;
                    case (int)(RelationshipEnum.Child):
                        result = PatientRelation.Child;
                        break;
                    default:
                        result = PatientRelation.Other;
                        break;
                }

                return result;
            }
        }

        public string InsuranceId => _claim.PolicyNo;

        public string PayerName => _claim.PolicyHolderName;

        public string InsuredName => _claim.PolicyHolderName;

        public string InsuredStreet => _claim.PolicyHolderStreet;

        public string InsuredCity => _claim.PolicyHolderCity;

        public string InsuredState => _claim.PolicyHolderState;

        public string InsuredZip => _claim.PolicyHolderZip;

        public string InsuredAreaCode => _claim.PolicyHolderAreaCode;

        public string InsuredPhone => _claim.PolicyHolderPhone;

        public string InsuredPolicy => _claim.PolicyGroupNumber;

        public DateTime InsuredDob => _claim.PolicyHolderDOB ?? _claim.PolicyHolderDOB.Value;

        public GenderType InsuredGender => GetGender(_claim.PolicyHolderSex.ToString(), true);

        //public string InsurancePlanName => _claim.PolicyInsurancePlanName;

        public string InsurancePlanName => string.Empty;

        public bool AnotherBenefitPlanExists => _claim.HasAnotherPlan;

        public string PatientSignature => _claim.PatientSignatureOnFile;

        public string DateMade => _claim.ClaimDate.ToString("MM dd yyyy");

        public string DateOfSign => _claim.PatientSignatureDate?.ToString("MM dd yyyy");

        public DateTime? DateOfSignAsDate => _claim.PatientSignatureDate;

        public string InsuredSignature => _claim.InsuranceSignatureOnFile;

        public string OtherInsuredFullName => _claim.OtherPolicyHolderName;

        public string OtherInsuredPolicy => _claim.OtherPolicyHolderGroupNo;

        public string OtherInsuredPlanName => _claim.OtherPolicyInsurancePlanName;

        public bool Employment => _claim.AccEmploy;

        public bool AutoAccident => _claim.AccAuto;

        public string AutoAccidentPlace => Convert.ToString(_claim.AccState);

        public bool OtherAccident => _claim.AccOther;

        public DateTime? CurrentIllnesDate => _claim.CurrentIllnesDate;

        public DateTime? OtherIllnesDate => _claim.OtherIllnesDate;

        //public DateTime? OtherIllnesDate => null;

        public DatePeriod UnableToWork => (_claim.UnableToWorkFrom != null && _claim.UnableToWorkTo != null )?new DatePeriod(_claim.UnableToWorkFrom.Value, _claim.UnableToWorkTo.Value) : null;

        public string PhysicianReference => _claim.ReferringPhyName;

        public string PhysicianNPI => _claim.ReferringPhysicianNpi;

        //public string PhysicianReferenceQualifier => _claim.ReferringPhyQualifier;

        public string PhysicianReferenceQualifier => !string.IsNullOrEmpty(PhysicianReference)? "DN" : string.Empty;

        public DatePeriod Hospitalization => (_claim.HospitalizationFrom != null && _claim.HospitalizationTo != null ) ?new DatePeriod(_claim.HospitalizationFrom.Value, _claim.HospitalizationTo.Value) : (_claim.HospitalizationFrom != null? new DatePeriod(_claim.HospitalizationFrom.Value, null) :null );

        public string AdditionalInformation => _claim.ClaimTotal.Reserved19;

        public bool OutsideLab => _claim.ClaimTotal.OutsideLab;

        public decimal? OutsideLabCharge => _claim.ClaimTotal.LabCharges;

        public int ICDIndex => 0;

        public string[] Diagnosis => _claim.DiagnosisCodes.Split(',');

        // public string ResubmissionCode => _claim.Options.ResubmissionCode != ClaimResubmissionCode.Original ?  Enum.GetValues(typeof(ClaimResubmissionCode), _claim.Options.ResubmissionCode) : null;

        //public string ResubmissionCode => GetResubmissionCode(_claim.Frequency);

        public string ResubmissionCode => string.Empty;

        public string OriginalRefNo => _claim.ClaimTotal.OriginalReferenceNumber;

        public string PriorAuthorizationNumber => string.IsNullOrEmpty(_claim.ReferCliaNumber) ? _claim.ClaimTotal.PriorAuthorizationNumber : (_claim.ReferCliaNumber + ',' + _claim.ClaimTotal.PriorAuthorizationNumber);

        public IInsuranceService[] Services { get; private set; }

        public string FederalTaxIdNumber => _claim.FederalTaxIDNumber;

        public string TaxNumberType => "EmployerIdentitificationNumber";


        public string PatientAccountNumber => _claim.AccessionNumber;

        public string BillTypeCode => _claim.BillTypeCode;

        public string Box10Or07 => _claim.Box10Value;
        public string Box19Or80 => _claim.RESERVED19;

        public bool AcceptAssignment => _claim.AcceptAssignment;

        //public decimal TotalCharge => _claim.InsuranceServices.Sum(x => x.Amount);

        public decimal? TotalCharge => _claim.ClaimTotal.TotalCharges;

        public decimal? AmountPaid => _claim.ClaimTotal.AmountPaid;

        public string ServiceFacilityName =>   _claim.PerformingLocationName;

        public string ServiceFacilityStreet => string.IsNullOrWhiteSpace(_claim.Box32FacilityAddress1) ?_claim.PerformingLocationAddressLine1 : _claim.Box32FacilityAddress1;

        public string ServiceFacilityLocation => (_claim.Box32FacilityId.HasValue && _claim.Box32FacilityId.Value>0)? $"{_claim.Box32FacilityCity} {_claim.Box32FacilityState} {_claim.Box32FacilityZip}":$"{_claim.PerformingLocationCity} {_claim.PerformingLocationState} {_claim.PerformingLocationZIP}";

        public string ServiceFacilityNpi => _claim.PerformingFacilityNPI;

        public string ClaimFacilityNpi => _claim.BillingFacilityNPI;

        //public string BillingProviderPhoneArea => _claim.BillingDoctorAreaCode;

        public string BillingProviderPhoneArea => string.Empty;

        public string BillingProviderPhone => _claim.BillingDoctorPhone;
        //public string BillingProviderPhone => string.Empty;
        public string BillingProviderFax => _claim.BillingDoctorFax;
        public string BillingProviderTelephone => _claim.BillingDoctorPhone;

        public string BillingProviderName { get; set; }

        public string BillingProviderCity => _claim.PerformingLocationCity;
        public string BillingProviderState => _claim.PerformingLocationState;

        public string BillingProviderZIP => _claim.PerformingLocationZIP;
        public string BillingProviderStreet => _claim.BillingDoctorAddressLine1;

        public string BillingsProviderLocation => $"{_claim.BillingDoctorCity} { _claim.BillingDoctorState} {_claim.BillingDoctorZip}";

        public string BillingProviderNpi =>  _claim.BillingFacilityNPI;

        public string BillingProviderSigned => _claim.PhysicianSignature;

        public DateTime BillingProviderDate => _claim.ClaimDate;

        public string Taxonomy => _claim.TaxonomyCode;

        //public string BillingProviderDetails => !String.IsNullOrEmpty(billingProvider.Details.Grp)
        //    && billingProvider.Details.Type != GrpType.None ? $"{billingProvider.Details.Grp}{billingProvider.Details.Type.GetCode()}" : "";

        public string BillingProviderDetails => !string.IsNullOrEmpty(_claim.TaxonomyCode) ? $"{_claim.TaxonomyCode}ZZ" : string.Empty;
        public string PerformingLocationNPI => _claim.PerformingFacilityNPI;

        private string GetResubmissionCode(short? resubmissionCode)
        {
            string resubmission = "";

            if (resubmissionCode == (int)FrequencyEnum.Replace)
                resubmission = FrequencyEnum.Replace.ToString();

            else if (resubmissionCode == (int)FrequencyEnum.Correct)
                resubmission = FrequencyEnum.Correct.ToString();

            else if (resubmissionCode == (int)FrequencyEnum.Void)
                resubmission = FrequencyEnum.Void.ToString();

            else if (resubmissionCode == (int)FrequencyEnum.Original)
                resubmission = FrequencyEnum.Original.ToString();
            return resubmission;
        }

        string Base.Model.Claim.IFileNameData.GetFileName()
        {
            return $"{_claim.PatientName.ToString()}({ClaimId.ToString()})";
        }

        private GenderType GetGender(string genderType, bool isInt)
        {
            if (String.IsNullOrEmpty(genderType))
                return GenderType.Unknown;
            if (!isInt)
            {
                switch (genderType)
                {
                    case "M":
                        return GenderType.Male;
                    case "F":
                        return GenderType.Female;
                    default:
                        return GenderType.Unknown;
                }
            }
            switch (genderType)
            {
                case "0":
                    return GenderType.Male;
                case "1":
                    return GenderType.Female;
                default:
                    return GenderType.Unknown;
            }
        }

    }
}
