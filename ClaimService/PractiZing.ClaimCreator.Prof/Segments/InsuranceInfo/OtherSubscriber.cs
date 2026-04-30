using EdiFabric.Templates.Hipaa5010;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class OtherSubscriberBuilder : ISegmentBuilder<Loop_2320_837P>
    {

        public Loop_2320_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            if (claim.SecondaryPolicyHolderName == null)
            {
                return null;
            }

            if (claim.InsLevel == 1)
            {
                return null;
            }

            var lst = claim.InsuranceServices.Select(i => i.PaymentCharges).ToList();
            if (lst.FirstOrDefault().Count() == 0)
            {
                return null;
            }

            Loop_2320_837P item = new Loop_2320_837P();



            item.AllNM1 = BuildSubscriber(claim);
            
            item.SBR_OtherSubscriberInformation = BuildOtherSubscriberInformation(claim);
            item.OI_OtherInsuranceCoverageInformation = BuildOtherInsuranceCoverage(claim);
            item.AllAMT = BuildCOB(claim);
            return item;

        }

        private All_AMT_837P_2 BuildCOB(Claim claim)
        {
            List<IPaymentCharge> lst = new List<IPaymentCharge>();
            claim.InsuranceServices.ToList().ForEach((item) =>
            {
                lst.AddRange(item.PaymentCharges.Where(i => i.InsuranceCompanyCode == claim.SecondaryInsuranceCompanyCode));                
            });

            if (lst.Count() == 0)
            {
                return null;
            }

            var cobDetail = new All_AMT_837P_2();
            var totalPaidAmount = claim.InsuranceServices.Sum(p => p.PaymentCharges.Where(x => x.InsuranceCompanyCode == claim.SecondaryInsuranceCompanyCode).Sum(c => c.PaidAmount));
            decimal adjustmentAmount = claim.InsuranceServices.Sum(p => p.PaymentCharges.Where(x => x.InsuranceCompanyCode == claim.SecondaryInsuranceCompanyCode).Sum(c => c.PaymentAdjustments.Where(a => a.IsDenial == false).Sum(a => a.Amount)));

            if (adjustmentAmount > 0)
            {
                //List<CAS_ClaimLevelAdjustments> claimLevelAdjustments = new List<CAS_ClaimLevelAdjustments>();
                //foreach (var adj in claim.InsuranceServices) ;
                //CAS_ClaimLevelAdjustments claimAdj = new CAS_ClaimLevelAdjustments();

                //claimAdj.AdjustmentAmount_03 = adjustmentAmount.ToString();

                //claimLevelAdjustments.Add(claimAdj);
                //item.CAS_ClaimLevelAdjustments = claimLevelAdjustments;
            }

            //if (totalPaidAmount > 0)
            //{
            cobDetail.AMT_CoordinationofBenefits_COB_PayerPaidAmount = new AMT_CoordinationofBenefits
            {
                AmountQualifierCode_01 = "D",
                TotalClaimChargeAmount_02 = totalPaidAmount.ToString("F", CultureHelper.Culture)
            };
            //cobDetail.AMT_CoordinationofBenefits_COB_TotalNon_Amount = new AMT_CoordinationofBenefits_2()
            //{

            //};
            //cobDetail.AMT_RemainingPatientLiability = new AMT_RemainingPatientLiability()
            //{

            //};

            //}

            return cobDetail;
        }

        private All_NM1_837P_4 BuildSubscriber(Claim claim)
        {
            All_NM1_837P_4 all_NM1 = new All_NM1_837P_4();
            all_NM1.Loop2330B = BuildPayer(claim);
            all_NM1.Loop2330A = BuildSubscriberNameAddress(claim);
            return all_NM1;
        }
        private (string lastName, string firstName) DivideName(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                return ("", "");
            var split = fullname.Split(",");
            if (split.Length == 2)
                return (split[0], split[1]);
            else
                return (split[0], "");
        }

        private Loop_2330A_837P BuildSubscriberNameAddress(Claim claim)
        {
            return new Loop_2330A_837P
            {
                NM1_OtherSubscriberName = BuildSubscriberName(claim),
                N3_OtherSubscriberAddress = BuildSubscriberAddress(claim).address,
                N4_OtherSubscriberCity_State_ZIPCode = BuildSubscriberAddress(claim).city,
                REF_OtherSubscriberSecondaryIdentification = string.IsNullOrWhiteSpace(claim.SecondaryPolicyNo) ? new REF_OtherSubscriberSecondaryIdentification() : null
            };

        }



        private (N3_AdditionalPatientInformationContactAddress address, N4_AdditionalPatientInformationContactCity city) BuildSubscriberAddress(Claim claim)
        {
            return (new N3_AdditionalPatientInformationContactAddress
            {
                ResponseContactAddressLine_01 = claim.SecondaryPolicyHolderStreet,
            },
            new N4_AdditionalPatientInformationContactCity
            {
                AdditionalPatientInformationContactCityName_01 = claim.SecondaryPolicyHolderCity,
                AdditionalPatientInformationContactStateCode_02 = claim.SecondaryPolicyHolderState,
                AdditionalPatientInformationContactPostalZoneorZIPCode_03 = claim.SecondaryPolicyHolderZip
            });
        }

        private NM1_OtherSubscriberName BuildSubscriberName(Claim claim)
        {
            return new NM1_OtherSubscriberName
            {
                EntityIdentifierCode_01 = "IL",
                EntityTypeQualifier_02 = "1",
                ResponseContactNameSuffix_07 = "",
                ResponseContactFirstName_04 = (DivideName(claim.SecondaryPolicyHolderName)).firstName,
                ResponseContactMiddleName_05 = "",
                ResponseContactLastorOrganizationName_03 = (DivideName(claim.SecondaryPolicyHolderName)).lastName,
                IdentificationCodeQualifier_08 = "MI",
                ResponseContactIdentifier_09 = claim.SecondaryPolicyNo,
                //EntityRelationshipCode_10 = GetRelationship(claim)
            };

        }

        private Loop_2330B_837P BuildPayer(Claim claim)
        {
             var paidDate = claim.InsuranceServices.FirstOrDefault().PaymentCharges.FirstOrDefault().PaidDate.Value;

            return new Loop_2330B_837P
            {
                NM1_OtherPayerName = new NM1_OtherPayerName
                {
                    EntityIdentifierCode_01 = "PR",
                    EntityTypeQualifier_02 = "2",
                    ResponseContactLastorOrganizationName_03 = claim.SecondaryPayerName,
                    IdentificationCodeQualifier_08 = "PI",
                    ResponseContactIdentifier_09 = claim.SecondaryInsuranceCompanyCode
                },
                N3_OtherPayerAddress = new N3_AdditionalPatientInformationContactAddress
                {
                    ResponseContactAddressLine_01 = claim.SecondaryPolicyHolderStreet
                },
                N4_OtherPayerCity_State_ZIPCode = new N4_AdditionalPatientInformationContactCity
                {
                    AdditionalPatientInformationContactCityName_01 = claim.SecondaryPolicyHolderCity,
                    AdditionalPatientInformationContactStateCode_02 = claim.SecondaryPolicyHolderState,
                    AdditionalPatientInformationContactPostalZoneorZIPCode_03 = claim.SecondaryPolicyHolderZip
                },
                //DTP_ClaimCheckorRemittanceDate=new DTP_ClaimCheckOrRemittanceDate
                //{
                //    DateTimeQualifier_01= X12_ID_374_18.Item573.X12(),
                //    DateTimePeriodFormatQualifier_02= X12_ID_1250.D8.ToString(),
                //    AccidentDate_03= DateFormatter.FormatDate(paidDate)
                //}

            };
        }

        private SBR_OtherSubscriberInformation BuildOtherSubscriberInformation(Claim claim)
        {
            return new SBR_OtherSubscriberInformation
            {
                InsuranceTypeCode_05 = claim.SecondaryInsuranceType,

                ClaimFilingIndicatorCode_09 = claim.SecondaryFillingCode,


                InsuredGrouporPolicyNumber_03 = claim.InsuranceCompanyCode != "88337"? claim.SecondaryPolicyNo:"",
                //OtherInsuredGroupName_04 = claim.SecondaryPolicyHolderGroupNo,

                PayerResponsibilitySequenceNumberCode_01 = X12_ID_1138.P.ToString(),
                IndividualRelationshipCode_02 = GetRelationship(claim)
            };
        }

        private OI_OtherInsuranceCoverageInformation_2 BuildOtherInsuranceCoverage(Claim claim)
        {
            return new OI_OtherInsuranceCoverageInformation_2
            {
                BenefitsAssignmentCertificationIndicator_03 = claim.SecondaryPolicyHolderSignature == "Signature on File" ? "Y" : "N",
                ReleaseofInformationCode_06 = claim.SecondaryPatientSignatureOnFile == "Signature on File" ? "Y" : "N"
            };
        }



        private string GetRelationship(Claim claim)
        {

            RelationshipType relationshipType = (RelationshipType)claim.SecondaryPolicyHolderRelation;
            if (relationshipType == RelationshipType.Self)
            {
                return X12_ID_1069_3.Item18.X12();
            }
            else if (relationshipType == RelationshipType.Child)
            {
                return X12_ID_1069_3.Item19.X12();
            }
            else if (relationshipType == RelationshipType.Spouse)
            {
                return X12_ID_1069_3.Item01.X12();
            }
            else if (relationshipType == RelationshipType.LifePartner)
            {
                return X12_ID_1069_3.Item53.X12();
            }
            else if (relationshipType == RelationshipType.Dependent)
            {
                return X12_ID_1069_3.Item76.X12();
            }
            else if (relationshipType == RelationshipType.Student)
            {
                return X12_ID_1069_3.Item27.X12();
            }
            else
            {
                return X12_ID_1069_3.G8.X12();
            }

        }


    }
}
