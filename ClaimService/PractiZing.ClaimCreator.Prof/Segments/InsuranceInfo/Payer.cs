using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class PayerBuilder : ISegmentBuilder<Loop_2010BB_837P>
    {

        public Loop_2010BB_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            Loop_2010BB_837P loop_2010BB = new Loop_2010BB_837P();
            loop_2010BB.NM1_PayerName = BuildName(claim);

            if (claim.PolicyInsurancePlanName == "00010")
            {
                loop_2010BB.N3_PayerAddress = BuildAddress(claim);
                loop_2010BB.N4_PayerCity_State_ZIPCode = BuildCityState(claim);
            }

            return loop_2010BB;
        }

        private static NM1_OtherPayerName BuildName(Claim claim)
        {
            return new NM1_OtherPayerName
            {
                EntityIdentifierCode_01 = X12_ID_98_8.PR.X12(),
                EntityTypeQualifier_02 = X12_ID_1065_2.Item2.X12(),
                ResponseContactLastorOrganizationName_03 = claim.ClaimToAddress1,
                IdentificationCodeQualifier_08 = "PI",// X12_ID_66_4.PI, oldcode
                ResponseContactIdentifier_09 = string.IsNullOrWhiteSpace(claim.MedicaidPayerId) ? claim.InsuranceCompanyCode : claim.MedicaidPayerId
            };
        }

        private static N3_AdditionalPatientInformationContactAddress BuildAddress(Claim claim)
        {
            return new N3_AdditionalPatientInformationContactAddress
            {
                ResponseContactAddressLine_01 = claim.ClaimToAddress2,
                ResponseContactAddressLine_02 = ""
            };
        }

        private static N4_AdditionalPatientInformationContactCity BuildCityState(Claim claim)
        {
            return new N4_AdditionalPatientInformationContactCity
            {
                AdditionalPatientInformationContactCityName_01 = claim.ClaimToCity,
                AdditionalPatientInformationContactStateCode_02 = claim.ClaimToState,
                AdditionalPatientInformationContactPostalZoneorZIPCode_03 = claim.ClaimToZip

            };
        }
    }
}
