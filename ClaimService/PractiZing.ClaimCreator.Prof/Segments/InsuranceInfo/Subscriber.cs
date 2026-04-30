using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class SubscriberBuilder : ISegmentBuilder<Loop_2010BA_837P>
    {

        public Loop_2010BA_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            return new Loop_2010BA_837P
            {
                NM1_SubscriberName = BuildName(claim),
                N3_SubscriberAddress = BuildAddress(claim),
                N4_SubscriberCity_State_ZIPCode = BuildCityStateZipCode(claim),
                DMG_SubscriberDemographicInformation = BuildDemographicInformation(claim)
            };
        }

        private NM1_SubscriberName_5 BuildName(Claim claim)
        {

            return new NM1_SubscriberName_5
            {
                EntityIdentifierCode_01 = X12_ID_98_7.IL.X12(),
                EntityTypeQualifier_02 = X12_ID_1065.Item1.X12(),
                ResponseContactLastorOrganizationName_03 = (Utility.DivideName(claim.PatientName)).lastName,
                ResponseContactFirstName_04 = (Utility.DivideName(claim.PatientName)).firstName,
                ResponseContactMiddleName_05 = "",
                IdentificationCodeQualifier_08 = "MI",
                ResponseContactIdentifier_09 = claim.PolicyNo
            };
        }

        private N3_AdditionalPatientInformationContactAddress BuildAddress(Claim claim)
        {
            return new N3_AdditionalPatientInformationContactAddress
            {
                ResponseContactAddressLine_01 = !string.IsNullOrWhiteSpace(claim.PatientStreet) ? claim.PolicyHolderAddress1.Trim() : "",
                //ResponseContactAddressLine_02 = !string.IsNullOrWhiteSpace(claim.PolicyHolderAddress2) ? claim.PolicyHolderAddress2.Trim() : "",
            };
        }

        private N4_AdditionalPatientInformationContactCity BuildCityStateZipCode(Claim claim)
        {
            return new N4_AdditionalPatientInformationContactCity
            {
                AdditionalPatientInformationContactCityName_01 = claim.PatientCity,
                AdditionalPatientInformationContactStateCode_02 = claim.PatientState.ToUpper(),
                AdditionalPatientInformationContactPostalZoneorZIPCode_03 = claim.PatientZip
            };
        }

        private DMG_PatientDemographicInformation BuildDemographicInformation(Claim claim)
        {
            return new DMG_PatientDemographicInformation
            {
                DateTimePeriodFormatQualifier_01 = X12_ID_1250.D8.X12(),
                DependentBirthDate_02 = DateFormatter.FormatDate(claim.PatientDOB.Value),
                DependentGenderCode_03 = Utility.GetGender(claim.PatientGender.ToString(), true)
            };
        }


    }
}
