using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;

using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class PatientBuilder : ISegmentBuilder<Loop_2000C_837P>
    {

        public Loop_2000C_837P Build(Claim claim, ClaimOptions claimOptions)
        {

            return new Loop_2000C_837P
            {
                HL_PatientHierarchicalLevel = BuildHierarchicalLevel(),
                PAT_PatientInformation = BuildPatientInformation(claim),
                Loop2010CA = BuildPatientDetail(claim)
            };
        }

        private static HL_DependentLevel BuildHierarchicalLevel()
        {
            const int sectionNumber = 3;
            const int parentNumber = 2;

            return new HL_DependentLevel
            {

                HierarchicalIDNumber_01 = sectionNumber.ToString(),
                HierarchicalParentIDNumber_02 = parentNumber.ToString(),

                HierarchicalLevelCode_03 = "23",
                HierarchicalChildCode_04 = "0"
            };
        }


        private PAT_PatientInformation BuildPatientInformation(Claim claim)
        {
            RelationshipType relationshipType = (RelationshipType)claim.PolicyHolderRelation;

            PAT_PatientInformation pat_PatientInformation = new PAT_PatientInformation();
            if (relationshipType == RelationshipType.Child)
            {
                pat_PatientInformation.IndividualRelationshipCode_01 = "19";
            }
            else if (relationshipType == RelationshipType.Spouse)
            {
                pat_PatientInformation.IndividualRelationshipCode_01 = "01";
            }
            else if (relationshipType == RelationshipType.LifePartner)
            {
                pat_PatientInformation.IndividualRelationshipCode_01 = "53";
            }
            else if (relationshipType == RelationshipType.Other)
            {
                pat_PatientInformation.IndividualRelationshipCode_01 = "G8";
            }
            return pat_PatientInformation;
        }


        private Loop_2010CA_837P BuildPatientDetail(Claim patient)
        {
            return new Loop_2010CA_837P
            {
                NM1_PatientName = BuildPatientName(patient),
                N3_PatientAddress = BuildPatientAddress(patient),
                N4_PatientCity_State_ZIPCode = BuildPatientCityStateZip(patient),
                DMG_PatientDemographicInformation = BuildPatientDemographic(patient)
            };
        }

        private static NM1_PatientName_3 BuildPatientName(Claim name)
        {
            return new NM1_PatientName_3
            {
                EntityIdentifierCode_01 = "QC",
                EntityTypeQualifier_02 = "1",
                ResponseContactLastorOrganizationName_03 = name.PatientLastName,
                ResponseContactFirstName_04 = name.PatientFirstName,
                ResponseContactMiddleName_05 = name.PatientMiddleName,
                ResponseContactNameSuffix_07 = ""
            };
        }

        private static N3_AdditionalPatientInformationContactAddress BuildPatientAddress(Claim address)
        {

            return new N3_AdditionalPatientInformationContactAddress
            {
                ResponseContactAddressLine_01 = address.PatientStreet,
                ResponseContactAddressLine_02 = address.PatientStreet
            };
        }

        private static N4_AdditionalPatientInformationContactCity BuildPatientCityStateZip(Claim address)
        {

            return new N4_AdditionalPatientInformationContactCity
            {
                AdditionalPatientInformationContactCityName_01 = address.PatientCity,
                AdditionalPatientInformationContactStateCode_02 = address.PatientState,
                AdditionalPatientInformationContactPostalZoneorZIPCode_03 = address.PatientZip
            };
        }

        private static DMG_PatientDemographicInformation BuildPatientDemographic(Claim patient)
        {
            return new DMG_PatientDemographicInformation
            {
                DateTimePeriodFormatQualifier_01 = "D8",
                DependentBirthDate_02 = DateFormatter.FormatDate(patient.PatientDOB.Value),
                DependentGenderCode_03 = patient.PatientGender
            };
        }
    }
}
