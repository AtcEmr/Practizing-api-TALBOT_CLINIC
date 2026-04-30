using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{

    internal class FacilityBuilder : ISegmentBuilder<Loop_2310C_837P>
    {

        public Loop_2310C_837P Build(Claim claim, ClaimOptions claimOptions)
        {

            var facilityPos = claim.POSCode;

            List<string> postCodeList = GetPosList();

            //var poscode = postCodeList.FirstOrDefault(i => i.ToString() == facilityPos);
            //if (poscode == null)
            //{
            //    return null;
            //}

            if(claim.InsuranceCompanyCode=="61103")
            {
                if(claim.BillingFacilityId==claim.PerformingFacilityNPI)
                {
                    return null;
                }
            }

            if(string.IsNullOrWhiteSpace(claim.PerformingLocationName))
            {
                return null;
            }

            return new Loop_2310C_837P
            {
                NM1_ServiceFacilityLocationName = BuildName(claim),
                N3_ServiceFacilityLocationAddress = GetAddress(claim),
                N4_ServiceFacilityLocationCity_State_ZIPCode = GetCityStateZipCode(claim)
            };
        }

        private List<string> GetPosList()
        {
            List<string> postCodeList = new List<string>();
            postCodeList.Add("21");
            postCodeList.Add("22");
            postCodeList.Add("23");
            postCodeList.Add("24");
            postCodeList.Add("25");
            return postCodeList;

        }

        private static NM1_ServiceFacilityLocation BuildName(Claim claim)
        {
            return new NM1_ServiceFacilityLocation
            {
                EntityIdentifierCode_01 = X12_ID_98_11.Item77.X12(),
                EntityTypeQualifier_02 = X12_ID_1065_2.Item2.X12(),
                ResponseContactLastorOrganizationName_03 = claim.PerformingLocationName,
                IdentificationCodeQualifier_08 = IdentificationCodeQualifier.XX.X12(),
                ResponseContactIdentifier_09 = claim.PerformingFacilityNPI == string.Empty ? "" : claim.PerformingFacilityNPI
            };
        }

        private static N3_AdditionalPatientInformationContactAddress GetAddress(Claim address)
        {
            return new N3_AdditionalPatientInformationContactAddress
            {
                ResponseContactAddressLine_01 = address.PerformingLocationAddressLine1
            };
        }

        private static N4_AdditionalPatientInformationContactCity GetCityStateZipCode(Claim address)
        {
            return new N4_AdditionalPatientInformationContactCity
            {
                AdditionalPatientInformationContactCityName_01 = address.PerformingLocationCity,
                AdditionalPatientInformationContactStateCode_02 = address.PerformingLocationState,
                AdditionalPatientInformationContactPostalZoneorZIPCode_03 = address.PerformingLocationZIP
            };
        }

    }
}
