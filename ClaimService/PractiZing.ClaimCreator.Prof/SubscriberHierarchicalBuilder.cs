using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{

    internal class SubscriberHierarchicalBuilder : ISegmentBuilder<Loop_2000B_837P>
    {

        public Loop_2000B_837P Build(Claim claim, ClaimOptions claimOptions)
        {

            var subscriberSameWithPatient = (RelationshipType)claim.PolicyHolderRelation == RelationshipType.Self;

            return new Loop_2000B_837P
            {
                HL_SubscriberHierarchicalLevel = BuildHierarchicalLevel(subscriberSameWithPatient),
                SBR_SubscriberInformation = BuildSubscriber(claim, subscriberSameWithPatient),
                AllNM1 = BuildSubscriberAndPayer(claim, claimOptions),
                Loop2300 = new List<Loop_2300_837P_2> { SegmentBuilders.Build<ClaimBuilder, Loop_2300_837P_2>(claim, claimOptions) }
            };
        }

        private static HL_SubscriberHierarchicalLevel BuildHierarchicalLevel(bool subscriberSameWithPatient)
        {
            return new HL_SubscriberHierarchicalLevel
            {
                HierarchicalIDNumber_01 = "2",
                HierarchicalParentIDNumber_02 = "1",
                HierarchicalLevelCode_03 = "22",
                HierarchicalChildCode_04 = subscriberSameWithPatient ? "0" : "1"
            };
        }

        private static SBR_SubscriberInformation BuildSubscriber(Claim claim, bool subscriberSameWithPatient)
        {

            var sbr = new SBR_SubscriberInformation
            {
                PayerResponsibilitySequenceNumberCode_01 = GetInsuranceLevel(claim)
            };

            if (subscriberSameWithPatient)
            {
                sbr.IndividualRelationshipCode_02 = "18";
            }
            else
            {
                sbr.IndividualRelationshipCode_02 = BuildPatientInformation(claim); 
            }

            sbr.InsuredGrouporPolicyNumber_03 = claim.PolicyGroupNumber;
            //sbr.OtherInsuredGroupName_04 = claim.PolicyGroupName;


            //specified only when Medicare is 2ndary
            var medicareIsSecondary = ReferenceEquals(claim.InsuranceLevel, "Secondary");
            if (medicareIsSecondary)
            {
                sbr.InsuranceTypeCode_05 = claim.InsuranceType;
            }

            sbr.ClaimFilingIndicatorCode_09 = claim.FillingCode;

            return sbr;
        }

        private static string BuildPatientInformation(Claim claim)
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
            return pat_PatientInformation.IndividualRelationshipCode_01;
        }


        private static string GetInsuranceLevel(Claim claim)
        {
            if (ReferenceEquals(claim.InsuranceLevel, "Primary"))
            {
                return X12_ID_1138.P.ToString();
            }
            if (ReferenceEquals(claim.InsuranceLevel, "Secondary"))
            {
                return X12_ID_1138.S.ToString();
            }
            if (ReferenceEquals(claim.InsuranceLevel, "Tertiory"))
            {
                return X12_ID_1138.T.ToString();
            }
            throw new NotImplementedException("Need to set correct insurance level");
        }


        private static All_NM1_837P_2 BuildSubscriberAndPayer(Claim claim, ClaimOptions options)
        {
            return new All_NM1_837P_2
            {
                Loop2010BA = SegmentBuilders.Build<SubscriberBuilder, Loop_2010BA_837P>(claim, options),
                Loop2010BB = SegmentBuilders.Build<PayerBuilder, Loop_2010BB_837P>(claim, options),
            };
        }


    }
}
