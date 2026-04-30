using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PractiZing.ClaimCreator.Prof
{
    
    internal class BillingProviderBuilder : ISegmentBuilder<All_NM1_837P>        
    {

        protected X12_ID_1065 EntityTypeQualifier => X12_ID_1065.Item2;


        public All_NM1_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            NM1_BillingProviderName_2 billingBpoviderName = GetName(claim);
            N3_AdditionalPatientInformationContactAddress billingProviderAddress = GetAddress(claim);
            N4_AdditionalPatientInformationContactCity billingProviderCityStateZip = GetCityStateZipCode(claim);
            All_REF_837P_8 taxIdentification = GetTaxIdentification(claim);

            return new All_NM1_837P
            {
                Loop2010AA = new Loop_2010AA_837P
                {
                    NM1_BillingProviderName = billingBpoviderName,
                    N3_BillingProviderAddress = billingProviderAddress,//GetACTAddress(claim),
                    N4_BillingProviderCity_State_ZIPCode = billingProviderCityStateZip,//GetACTCityStateZipCode(claim),

                    AllREF = taxIdentification,

                }
            };
        }

        private static N3_AdditionalPatientInformationContactAddress GetACTAddress(Claim address)
        {
            return new N3_AdditionalPatientInformationContactAddress
            {
                ResponseContactAddressLine_01 = "6400 E Broad St Suite 400"
            };
        }

        private static N4_AdditionalPatientInformationContactCity GetACTCityStateZipCode(Claim address)
        {
            return new N4_AdditionalPatientInformationContactCity
            {

                AdditionalPatientInformationContactCityName_01 = "Columbus ",
                AdditionalPatientInformationContactStateCode_02 = "OH",
                AdditionalPatientInformationContactPostalZoneorZIPCode_03 = "43213"
            };
        }


        protected virtual NM1_BillingProviderName_2 GetName(Claim provider)
        {
            return new NM1_BillingProviderName_2
            {
                EntityIdentifierCode_01 = X12_ID_98_4.Item85.X12(),
                EntityTypeQualifier_02 = EntityTypeQualifier.X12(),
                ResponseContactLastorOrganizationName_03 = provider.BillingProviderFacilityName,
                IdentificationCodeQualifier_08 = IdentificationCodeQualifier.XX.X12(),
                ResponseContactIdentifier_09 = provider.BillingFacilityId
            };
        }

        private static N3_AdditionalPatientInformationContactAddress GetAddress(Claim address)
        {
            return new N3_AdditionalPatientInformationContactAddress
            {
                ResponseContactAddressLine_01 = string.IsNullOrWhiteSpace(address.Box32FacilityAddress1) ? address.BillingDoctorAddressLine1 : address.Box32FacilityAddress1,
                ResponseContactAddressLine_02 = string.IsNullOrWhiteSpace(address.Box32FacilityAddress2) ? address.BillingDoctorAddressLine2 : address.Box32FacilityAddress2
            };
        }

        private static N4_AdditionalPatientInformationContactCity GetCityStateZipCode(Claim address)
        {
            return new N4_AdditionalPatientInformationContactCity
            {
                AdditionalPatientInformationContactCityName_01 = string.IsNullOrWhiteSpace(address.Box32FacilityCity) ? address.BillingDoctorCity : address.Box32FacilityCity,
                AdditionalPatientInformationContactStateCode_02 = string.IsNullOrWhiteSpace(address.Box32FacilityState) ? address.BillingDoctorState : address.Box32FacilityState,
                AdditionalPatientInformationContactPostalZoneorZIPCode_03 = string.IsNullOrWhiteSpace(address.Box32FacilityZip) ? address.BillingDoctorZip : address.Box32FacilityZip
            };
        }

        private static All_REF_837P_8 GetTaxIdentification(Claim details)
        {
            return new All_REF_837P_8
            {
                REF_BillingProviderTaxIdentification = new REF_BillingProviderTaxIdentification
                {
                    ReferenceIdentificationQualifier_01 = X12_ID_128_2.EI.X12(),
                    MemberGrouporPolicyNumber_02 = details.FederalTaxIDNumber
                }
            };
        }

        public object Build(object claimData, params object[] options)
        {
            return Build((Claim)claimData, options);
        }
    }
}
