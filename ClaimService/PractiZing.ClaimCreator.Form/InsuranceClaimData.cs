

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.CompilerServices;
using System.Globalization;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.Claim;

namespace PractiZing.ClaimCreator.Form
{
    /// <summary>
    /// Represend claim data with Cms1500 fields names mapping.
    /// </summary>
    internal sealed class InsuranceClaimData
    {
        internal string ClaimType { get; set; }

        #region Payer info
        internal string InsuranceName { get; private set; }
        internal string InsuranceAddressPrimary { get; private set; }
        internal string InsuranceAddressSecondary { get; private set; }
        internal string InsuranceCityStateZip { get; private set; }
        #endregion Payer info

        #region Patient info
        internal string PatientFullName { get; private set; }

        internal string PatientDobMonth { get; private set; }

        internal string PatientDobDay { get; private set; }

        internal int PatientDobYear { get; private set; }

        internal GenderType PatientGender { get; private set; }

        internal string PatientCity { get; private set; }

        internal string PatientZip { get; private set; }

        internal string PatientAreaCode { get; private set; }

        internal string PatientPhone { get; private set; }

        internal string PatientState { get; private set; }

        internal string PatientStreet { get; private set; }

        internal PatientRelation PatientRelation { get; private set; }
        #endregion Patient info

        #region Insured's info
        internal string InsuranceId { get; private set; }

        internal string InsuredName { get; private set; }

        internal string InsuredStreet { get; private set; }

        internal string InsuredCity { get; private set; }

        internal string InsuredState { get; private set; }

        internal string InsuredZip { get; private set; }

        internal string InsuredAreaCode { get; private set; }

        internal string InsuredPhone { get; private set; }

        internal string InsuredPolicy { get; private set; }

        internal string InsuredDobMonth { get; private set; }

        internal string InsuredDobDay { get; private set; }

        internal int InsuredDobYear { get; private set; }

        internal GenderType InsuredGender { get; private set; }

        internal string InsurancePlanName { get; private set; }

        internal bool AnotherBenefitPlanExists { get; private set; }

        internal string PatientSignature { get; private set; }

        internal string DateOfSign { get; private set; }

        internal string InsuredSignature { get; private set; }

        internal string OtherInsuredFullName { get; private set; }

        internal string OtherInsuredPolicy { get; private set; }

        internal string OtherInsuredPlanName { get; private set; }
        #endregion Insured's info

        #region patient condition
        internal bool Employment { get; private set; }

        internal bool AutoAccident { get; private set; }

        //State name
        internal string AutoAccidentPlace { get; private set; }

        internal bool OtherAccident { get; private set; }
        #endregion patient condition

        #region Cure information
        internal String CurrentIllnesDateMonth { get; private set; }

        internal String CurrentIllnesDateDay { get; private set; }

        internal String CurrentIllnesDateYear { get; private set; }

        internal String CurrentIllnesQualifier { get; private set; }

        internal String OtherIllnesDateMonth { get; private set; }

        internal String OtherIllnesDateDay { get; private set; }

        internal String OtherIllnesDateYear { get; private set; }

        internal String OtherIllnesQualifier { get; private set; }

        internal String UnableToWorkFromMonth { get; private set; }

        internal String UnableToWorkFromDay { get; private set; }

        internal String UnableToWorkFromYear { get; private set; }

        internal String UnableToWorkToMonth { get; private set; }

        internal String UnableToWorkToDay { get; private set; }

        internal String UnableToWorkToYear { get; private set; }

        internal string PhysicianReference { get; private set; }

        internal String PhysicianReferenceQualifier { get; private set; }

        internal string PhysicianNPI { get; private set; }

        internal String HospitalizationFromMonth { get; private set; }

        internal String HospitalizationFromDay { get; private set; }

        internal String HospitalizationFromYear { get; private set; }

        internal String HospitalizationToMonth { get; private set; }

        internal String HospitalizationToDay { get; private set; }

        internal String HospitalizationToYear { get; private set; }

        internal string AdditionalInformation { get; private set; }

        internal bool OutsideLab { get; private set; }

        internal decimal? OutsideLabCharge { get; private set; }

        internal int ICDIndex { get; private set; }

        internal string[] Diagnosis { get; private set; }

        internal string ResubmissionCode { get; private set; }

        internal string OriginalRefNo { get; private set; }

        internal string PriorAuthorizationNumber { get; private set; }

        internal InsuranceService[] Services { get; private set; }

        internal string FederalTaxIdNumber { get; private set; }

        internal string TaxNumberType { get; private set; }

        internal string PatientAccountNumber { get; private set; }

        internal bool AsseptAssignment { get; private set; }

        internal string TotalCharge { get; private set; }

        internal string AmountPaid { get; private set; }

        internal string ServiceFacilityName { get; private set; }

        internal string ServiceFacilityStreet { get; private set; }

        internal string ServiceFacilityLocation { get; private set; }

        internal string ServiceFacilityNpi { get; private set; }
        #endregion Cure information

        #region Billing provider info
        internal string BillingProviderPhoneArea { get; private set; }

        internal string BillingProviderPhone { get; private set; }

        internal string BillingProviderName { get; private set; }

        internal string BillingProviderStreet { get; private set; }

        internal string BillingProviderLocation { get; private set; }

        internal string BillingProviderNpi { get; private set; }

        internal string GroupNPI { get; private set; }

        internal string BillingProviderSigned { get; private set; }

        internal string BillingProviderDate { get; private set; }

        internal string BillingProviderDetails { get; private set; }

        internal string SupervisionDoctorFirstName { get; private set; }
        internal string SupervisionDoctorLastName { get; private set; }
        internal string SupervisionDoctorNPI { get; private set; }
        internal string OrderingDoctorFirstName { get; private set; }
        internal string OrderingDoctorLastName { get; private set; }
        internal string OrderingDoctorNPI { get; private set; }

        #endregion Billing provider info

        internal InsuranceClaimData(IInsuranceClaimData data)
        {
            CopyData(data);
        }

        public string RemoveSpecialChars(string str)
        {
            //string[] chars = new string[] { ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
            string[] chars = new string[] { ",", "-", "#", "." };

            if (str != null)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (str.Contains(chars[i]))
                    {
                        str = str.Replace(chars[i], "");
                    }
                }
            }
            else
            {
                str = "";
            }
            return str;
        }

        private void CopyData(IInsuranceClaimData data)
        {
            SupervisionDoctorFirstName = data.SupervisionDoctorFirstName;
            SupervisionDoctorLastName = data.SupervisionDoctorLastName;
            SupervisionDoctorNPI = data.SupervisionDoctorNPI;

            OrderingDoctorFirstName = data.OrderingDoctorFirstName;
            OrderingDoctorLastName = data.OrderingDoctorLastName;
            OrderingDoctorNPI = data.OrderingDoctorNPI;

            ClaimType = data.ClaimType;

            InsuranceName = data.InsuranceName;
            InsuranceAddressPrimary = RemoveSpecialChars(data.InsuranceAddressPrimary);
            InsuranceAddressSecondary = RemoveSpecialChars(data.InsuranceAddressSecondary);
            InsuranceCityStateZip = RemoveSpecialChars(data.InsuranceCityStateZip);

            PatientFullName = data.PatientFullName;
            PatientDobMonth = data.PatientDob.Month.ToString("D2");
            PatientDobDay = data.PatientDob.Day.ToString("D2");
            PatientDobYear = data.PatientDob.Year;

            PatientGender = data.PatientGender;

            PatientCity = RemoveSpecialChars(data.PatientCity);
            PatientZip = RemoveSpecialChars(data.PatientZip);
            //PatientPhone = data.PatientPhone;
            //PatientAreaCode = RemoveSpecialChars(data.PatientAreaCode);
            PatientAreaCode = !string.IsNullOrEmpty(data.PatientPhone) && data.PatientPhone.Length > 3 ? data.PatientPhone.Substring(0, 3) : string.Empty;
            PatientPhone = !string.IsNullOrEmpty(data.PatientPhone) && data.PatientPhone.Length > 9 ? data.PatientPhone.Substring(3, 7) : string.Empty;
            PatientState = data.PatientState;
            PatientStreet = RemoveSpecialChars(data.PatientStreet);
            
            PatientRelation = data.PatientRelation;

            InsuranceId = data.InsuranceId;
            InsuredName = data.InsuredName;
            InsuredStreet = RemoveSpecialChars(data.InsuredStreet);
            InsuredCity = RemoveSpecialChars(data.InsuredCity);
            InsuredState = data.InsuredState;
            InsuredZip = RemoveSpecialChars(data.InsuredZip);


            InsuredAreaCode = !string.IsNullOrEmpty(data.InsuredPhone) && data.InsuredPhone.Length > 3 ? data.InsuredPhone.Substring(0, 3) : string.Empty;
            InsuredPhone = !string.IsNullOrEmpty(data.InsuredPhone) && data.InsuredPhone.Length > 9 ? data.InsuredPhone.Substring(3, 7) : string.Empty;
            
            InsuredPolicy = data.InsuredPolicy;
            InsuredDobMonth = data.InsuredDob.Month.ToString("D2");
            InsuredDobDay = data.InsuredDob.Day.ToString("D2");
            InsuredDobYear = data.InsuredDob.Year;

            InsuredGender = data.InsuredGender;

            InsurancePlanName = data.InsurancePlanName;
            AnotherBenefitPlanExists = data.AnotherBenefitPlanExists;

            PatientSignature = data.PatientSignature;
            DateOfSign = data.DateOfSign;
            InsuredSignature = data.InsuredSignature;

            OtherInsuredFullName = data.OtherInsuredFullName;
            OtherInsuredPolicy = data.OtherInsuredPolicy;
            OtherInsuredPlanName = data.OtherInsuredPlanName;

            Employment = data.Employment;
            AutoAccident = data.AutoAccident;
            AutoAccidentPlace = data.AutoAccidentPlace;
            OtherAccident = data.OtherAccident;



            if ((data.CurrentIllnesDate != null) && (data.CurrentIllnesDate.Value.Year != 1))
            {
                CurrentIllnesDateMonth = data.CurrentIllnesDate.Value.Month.ToString("D2");
                CurrentIllnesDateDay = data.CurrentIllnesDate.Value.Day.ToString("D2");
                CurrentIllnesDateYear = data.CurrentIllnesDate.Value.Year.ToString();
                CurrentIllnesQualifier = "431";
            }

            if ((data.OtherIllnesDate != null) && (data.OtherIllnesDate.Value.Year != 1))
            {
                DateTime value = data.OtherIllnesDate.Value;
                OtherIllnesDateMonth = value.Month.ToString("D2");
                OtherIllnesDateDay = value.Day.ToString("D2");
                OtherIllnesDateYear = value.Year.ToString();
                OtherIllnesQualifier = "454";
            }

            if (data.UnableToWork != null)
            {
                DateTime from = data.UnableToWork.From;
                if (from.Year > 1)
                {
                    UnableToWorkFromMonth = from.Month.ToString("D2");
                    UnableToWorkFromDay = from.Day.ToString("D2");
                    UnableToWorkFromYear = from.Year.ToString();
                }
                if(data.UnableToWork.To.HasValue)
                {
                    DateTime to = data.UnableToWork.To.Value;
                    if (to.Year > 1)
                    {
                        UnableToWorkToMonth = to.Month.ToString("D2");
                        UnableToWorkToDay = to.Day.ToString("D2");
                        UnableToWorkToYear = to.Year.ToString();
                    }
                }                
            }
            

            if (!string.IsNullOrEmpty(SupervisionDoctorFirstName))
            {
                PhysicianReferenceQualifier = "DQ";
                PhysicianReference = SupervisionDoctorLastName+", "+ SupervisionDoctorFirstName;
                PhysicianNPI = SupervisionDoctorNPI;
            }
            if (!string.IsNullOrEmpty(OrderingDoctorFirstName))
            {
                PhysicianReferenceQualifier = "DK";
                PhysicianReference = OrderingDoctorLastName + ", " + OrderingDoctorFirstName;
                PhysicianNPI = OrderingDoctorNPI;
            }
            if (!string.IsNullOrEmpty(data.PhysicianReference))
            {
                PhysicianReferenceQualifier = data.PhysicianReferenceQualifier;
                PhysicianReference = data.PhysicianReference;
                PhysicianNPI = data.PhysicianNPI;
            }
            

            

            if (data.Hospitalization != null)
            {
                DateTime from = data.Hospitalization.From;
                if (from.Year > 1)
                {
                    HospitalizationFromMonth = from.Month.ToString("D2");
                    HospitalizationFromDay = from.Day.ToString("D2");
                    HospitalizationFromYear = from.Year.ToString();
                }
                if(data.Hospitalization.To.HasValue)
                {
                    DateTime to = data.Hospitalization.To.Value;
                    if (to.Year > 1)
                    {
                        HospitalizationToMonth = to.Month.ToString("D2");
                        HospitalizationToDay = to.Day.ToString("D2");
                        HospitalizationToYear = to.Year.ToString();
                    }
                }
            }

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = " ";
            nfi.CurrencySymbol = "";
            nfi.CurrencyGroupSeparator = "";

            AdditionalInformation = data.AdditionalInformation;

            ICDIndex = data.ICDIndex;
            Diagnosis = data.Diagnosis;

            ResubmissionCode = data.ResubmissionCode;
            OriginalRefNo = data.OriginalRefNo;
            PriorAuthorizationNumber = data.PriorAuthorizationNumber;

            Services = data.Services?.Select(x => new InsuranceService(x)).ToArray();

            FederalTaxIdNumber = data.FederalTaxIdNumber;
            TaxNumberType = "EmployerIdentitificationNumber";
            PatientAccountNumber = data.PatientAccountNumber;
            AsseptAssignment = data.AcceptAssignment;
            TotalCharge = Convert.ToDecimal(data.TotalCharge).ToString("C",nfi);
            AmountPaid = Convert.ToDecimal(data.AmountPaid).ToString("C", nfi);
            ServiceFacilityName = data.ServiceFacilityName;
            ServiceFacilityStreet = data.ServiceFacilityStreet;
            ServiceFacilityLocation = data.ServiceFacilityLocation;
            ServiceFacilityNpi = data.ServiceFacilityNpi;

            //BillingProviderPhoneArea = data.BillingProviderPhoneArea;
            BillingProviderPhoneArea = !string.IsNullOrEmpty(data.BillingProviderPhone) && data.BillingProviderPhone.Length > 3 ? data.BillingProviderPhone.Substring(0, 3) : string.Empty;
            BillingProviderPhone = !string.IsNullOrEmpty(data.BillingProviderPhone) && data.BillingProviderPhone.Length > 9  ? data.BillingProviderPhone.Substring(3, 7) : string.Empty;
            BillingProviderName = data.BillingProviderName;
            BillingProviderStreet = RemoveSpecialChars(data.BillingProviderStreet);
            BillingProviderLocation = RemoveSpecialChars(data.BillingsProviderLocation);
            BillingProviderNpi = !string.IsNullOrWhiteSpace( data.GroupNPI)? data.GroupNPI:  data.ClaimFacilityNpi;
            BillingProviderSigned = data.BillingProviderSigned;
            BillingProviderDate = data.BillingProviderDate.ToString("MM/dd/yyyy");
            BillingProviderDetails = data.BillingProviderDetails;

            if (BillingProviderNpi == ServiceFacilityNpi)
            {
                OutsideLab = false;
            }
            else
            {
                OutsideLab = true;
            }

            //OutsideLab = data.OutsideLab;
            OutsideLabCharge = data.OutsideLabCharge;
        }
    }
}
