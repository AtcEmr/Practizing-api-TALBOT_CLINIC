using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class ClaimBuilder : ISegmentBuilder<Loop_2300_837P_2>
    {
        private All_NM1_837P_3 BuildProviders(Claim claim, ClaimOptions claimOptions)
        {

            Loop_2310D_837P supervisingProvider = null;
            //if (claim.IsLoop2310DRequired.HasValue && claim.IsLoop2310DRequired.Value)
            //{
            //    supervisingProvider = BuildSegment<SupervisingProviderBuilder, Loop_2310D_837P>(claim, claimOptions);
            //}
            if (!string.IsNullOrWhiteSpace(claim.SupervisionDoctorFirstName))
            {
                supervisingProvider = BuildSegment<SupervisingProviderBuilder, Loop_2310D_837P>(claim, claimOptions);
            }

            All_NM1_837P_3 nm1 = new All_NM1_837P_3
            {
                Loop2310A = new List<Loop_2310A_837P>
                {
                    !string.IsNullOrWhiteSpace(claim.ReferringPhyFirstName)?
                    BuildSegment<ReferringProviderBuilder,Loop_2310A_837P>(claim,claimOptions) :null
                },
                Loop2310B = BuildSegment<RenderingProviderBuilder, Loop_2310B_837P>(claim, claimOptions),
                Loop2310C = BuildSegment<FacilityBuilder, Loop_2310C_837P>(claim, claimOptions),
                Loop2310D = supervisingProvider// BuildSegment<SupervisingProviderBuilder, Loop_2310D_837P>(claim, claimOptions)
            };

            return nm1;
        }

        public Loop_2300_837P_2 Build(Claim claim, ClaimOptions claimOptions)
        {


            All_REF_837P_6 priorAuthorizationInfo = GetPriorAuthorizationInfo(claim);
            var subscriberSameWithPatient = (RelationshipType)claim.PolicyHolderRelation == RelationshipType.Self;
            Loop_2300_837P_2 claimInfo;
            try
            {
                claimInfo = new Loop_2300_837P_2
                {

                    //Manoj ToDo
                    //G_TS837_2000C = GetPatient(claim, subscriberSameWithPatient, (RelationshipType)claim.PolicyHolderRelation),
                    //Loop_2000C = BuildSegment<PatientBuilder, Loop_2000C_837P>(claim, claimOptions),
                    CLM_ClaimInformation = BuildClaimInformation(claim),
                    AllDTP = BuildHospitalizationDate(claim),
                    AllHI = BuildHealthCareDiagnosis(claim.DiagnosisCodes),
                    AllNM1 = BuildProviders(claim, claimOptions),
                    Loop2400 = BuildSegment<ServiceChargeBuilder, List<Loop_2400_837P>>(claim, claimOptions),
                    AllREF = priorAuthorizationInfo,
                    Loop2320 = GetOtherPolicyInformation(claim,claimOptions)

                };

                if (subscriberSameWithPatient == true)
                {
                    //Manoj ToDo
                    claimInfo.Loop_2000C = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Claim # " + claim.Id + " Error: " + e.Message, e.InnerException);
            }
            return claimInfo;
        }

        private List<Loop_2320_837P> GetOtherPolicyInformation(Claim claim, ClaimOptions claimOptions)
        {
            List<Loop_2320_837P> lst = null;

            if (!string.IsNullOrEmpty(claim.SecondaryPolicyHolderName) )
            {
                lst = new List<Loop_2320_837P>();
                var item = BuildSegment<OtherSubscriberBuilder, Loop_2320_837P>(claim, claimOptions);
                lst.Add(item);
            }
            if (!string.IsNullOrEmpty(claim.Other2PolicyHolderName))
            {
                
                var item1 = BuildSegment<Other2SubscriberBuilder, Loop_2320_837P>(claim, claimOptions);
                lst.Add(item1);
            }


            return lst;
        }

        public TSegment BuildSegment<TBuilder, TSegment>(Claim claim, ClaimOptions claimOptions)
        {
            return SegmentBuilders.Build<TBuilder, TSegment>(claim, claimOptions);
        }

        //private static List<G_TS837_2000C> GetPatient(Claim patient, bool subscriberSameWithPatient, RelationshipType relationshipType)
        //{
        //    Contract.RequiresNotNull(patient, $"{nameof(patient)} != null");

        //    return subscriberSameWithPatient
        //        ? null
        //        : new List<G_TS837_2000C> { Converter.Instance.Convert<Claim, G_TS837_2000C>(patient, relationshipType) };
        //}

        private All_REF_837P_6 GetPriorAuthorizationInfo(Claim claim)
        {
            string authorizationNumber = !string.IsNullOrEmpty(claim.ReferCliaNumber) ? claim.ReferCliaNumber : claim.ClaimTotal.PriorAuthorizationNumber;

            All_REF_837P_6 result = null;
            int x = 0;

            if (!String.IsNullOrEmpty(authorizationNumber))
            {
                if (claim.IsCliaNumber.HasValue)
                {
                    if (claim.IsCliaNumber.Value)
                        result = new All_REF_837P_6
                        {
                            REF_ClinicalLaboratoryImprovementAmendment_CLIA_Number = new REF_ClinicalLaboratoryImprovementAmendment
                            {
                                ReferenceIdentificationQualifier_01 = X12_ID_128_17.X4.X12(),
                                MemberGrouporPolicyNumber_02 = authorizationNumber
                            }
                        };
                }
                else
                {
                    result = new All_REF_837P_6
                    {
                        REF_PriorAuthorization = new REF_OtherPayerPriorAuthorizationNumber
                        {
                            ReferenceIdentificationQualifier_01 = X12_ID_128_15.G1.X12(),
                            MemberGrouporPolicyNumber_02 = authorizationNumber
                        }
                    };
                }
            }
            if ((ClaimResubmissionCode)claim.Frequency == ClaimResubmissionCode.Corrected || (ClaimResubmissionCode)claim.Frequency == ClaimResubmissionCode.Cancel || (ClaimResubmissionCode)claim.Frequency == ClaimResubmissionCode.Replacement)
            {
                if (!string.IsNullOrWhiteSpace(claim.ClaimTotal.OriginalReferenceNumber))
                {
                    if (result == null)
                    {
                        result = new All_REF_837P_6();
                    }

                    result.REF_PayerClaimControlNumber = new REF_OtherPayerClaimControlNumber
                    {
                        ReferenceIdentificationQualifier_01 = X12_ID_128_16.F8.X12(),
                        MemberGrouporPolicyNumber_02 = claim.ClaimTotal.OriginalReferenceNumber
                    };
                }
            }

            return result;
        }

        private static CLM_ClaimInformation_2 BuildClaimInformation(Claim claim)
        {

            var serviceCharges = claim.InsuranceServices;


            return new CLM_ClaimInformation_2
            {
                PatientControlNumber_01 = claim.PatientAccountNumber.ToString(),
                TotalClaimChargeAmount_02 = serviceCharges.Sum(x => x.Amount).ToString("F", CultureHelper.Culture), //todo need to recalc with adjustments
                HealthCareServiceLocationInformation_05 = new C023_HealthCareServiceLocationInformation_2
                {
                    FacilityTypeCode_01 = serviceCharges.Select(x => x.POSId)
                                                                .FirstOrDefault() ?? string.Empty,
                    FacilityCodeQualifier_02 = "B",
                    ClaimFrequencyTypeCode_03 = claim.Frequency.ToString()
                },
                ProviderorSupplierSignatureIndicator_06 = claim.InsuranceSignatureOnFile == "Signature on File" ? YesNoValues.Yes : YesNoValues.No,
                AssignmentorPlanParticipationCode_07 = GetAcceptAssignmentType((AcceptAssignmentType)Convert.ToInt16(claim.AcceptAssignment)),
                BenefitsAssignmentCertificationIndicator_08 = claim.InsuranceSignatureOnFile == "Signature on File" ? YesNoValues.Yes : YesNoValues.No,
                ReleaseofInformationCode_09 = claim.PatientSignatureOnFile == "Signature on File" ? YesNoValues.Yes : YesNoValues.No
            };
        }

        private static string GetAcceptAssignmentType(AcceptAssignmentType acceptAssignmentType)
        {
            switch (acceptAssignmentType)
            {
                case AcceptAssignmentType.Assigned:
                    return AcceptAssignmentValues.Assigned;
                case AcceptAssignmentType.AssignmentAcceptedOnly:
                    return AcceptAssignmentValues.AssignmentAcceptedOnly;
                default:
                    return AcceptAssignmentValues.NotAssigned;
            }
        }



        private static All_DTP_837P_2 BuildHospitalizationDate(Claim claim)
        {
            All_DTP_837P_2 aDTP = null;
            if (claim.UnableToWorkFrom != null && claim.UnableToWorkTo != null && (claim.UnableToWorkFrom.Value.Year > 1 || claim.UnableToWorkTo.Value.Year > 1))
            {
                string disabilityDate = "";
                aDTP = new All_DTP_837P_2();
                var dtpDisability = new DTP_DisabilityDates();

                if (claim.UnableToWorkFrom.Value.Year > 1 && claim.UnableToWorkTo.Value.Year > 1)
                {
                    dtpDisability.DateTimeQualifier_01 = X12_ID_374_10.Item314.X12();
                }
                else if (claim.UnableToWorkFrom.Value.Year > 1 && claim.UnableToWorkTo.Value.Year == 1)
                {
                    dtpDisability.DateTimeQualifier_01 = X12_ID_374_10.Item360.X12();
                }
                else
                {
                    dtpDisability.DateTimeQualifier_01 = X12_ID_374_10.Item361.X12();
                }

                if (dtpDisability.DateTimeQualifier_01 == X12_ID_374_10.Item360.X12() || dtpDisability.DateTimeQualifier_01 == X12_ID_374_10.Item361.X12())
                {
                    dtpDisability.DateTimeQualifier_01 = X12_ID_1250_2.D8.X12();
                }
                else
                {
                    dtpDisability.DateTimePeriodFormatQualifier_02 = X12_ID_1250_2.RD8.X12();
                }

                if (claim.UnableToWorkFrom.Value.Year > 1 && claim.UnableToWorkTo.Value.Year > 1)
                {
                    disabilityDate = DateFormatter.FormatDateRange(claim.UnableToWorkFrom.Value, claim.UnableToWorkTo.Value);
                }
                else if (claim.UnableToWorkFrom.Value.Year > 1)
                {
                    disabilityDate = DateFormatter.FormatDate(claim.UnableToWorkFrom.Value);
                }
                else if (claim.UnableToWorkTo.Value.Year > 1)
                {
                    disabilityDate = DateFormatter.FormatDate(claim.UnableToWorkTo.Value);
                }

                dtpDisability.AccidentDate_03 = disabilityDate;
            }

            if (claim.HospitalizationFrom != null && claim.HospitalizationFrom.Value.Year > 1)
            {
                if (aDTP == null)
                {
                    aDTP = new All_DTP_837P_2();
                }

                aDTP.DTP_Date_Admission = new DTP_AdmissionDate_4();

                aDTP.DTP_Date_Admission.DateTimeQualifier_01 = X12_ID_374_13.Item435.X12();
                aDTP.DTP_Date_Admission.DateTimePeriodFormatQualifier_02 = X12_ID_1250.D8.X12();
                aDTP.DTP_Date_Admission.AccidentDate_03 = DateFormatter.FormatDate(claim.HospitalizationFrom.Value);
            }

            if (claim.HospitalizationTo != null && claim.HospitalizationTo.Value.Year > 1)
            {
                if (aDTP == null)
                {
                    aDTP = new All_DTP_837P_2();
                }
                aDTP.DTP_Date_Discharge = new DTP_Discharge();
                aDTP.DTP_Date_Discharge.DateTimeQualifier_01 = X12_ID_374_14.Item096.X12();
                aDTP.DTP_Date_Discharge.DateTimePeriodFormatQualifier_02 = X12_ID_1250.D8.X12();
                aDTP.DTP_Date_Discharge.AccidentDate_03 = DateFormatter.FormatDate(claim.HospitalizationTo.Value);
            }

            if (claim.CurrentIllnesDate!= null && claim.CurrentIllnesDate.Value.Year > 1)
            {
                if (aDTP == null)
                {
                    aDTP = new All_DTP_837P_2();
                }
                aDTP.DTP_Date_OnsetofCurrentIllnessorSymptom = new DTP_OnsetofCurrentIllnessorSymptom();
                aDTP.DTP_Date_OnsetofCurrentIllnessorSymptom.DateTimeQualifier_01 = "431";
                aDTP.DTP_Date_OnsetofCurrentIllnessorSymptom.DateTimePeriodFormatQualifier_02 = X12_ID_1250.D8.X12();
                aDTP.DTP_Date_OnsetofCurrentIllnessorSymptom.AccidentDate_03 = DateFormatter.FormatDate(claim.CurrentIllnesDate.Value);
            }



            return aDTP;
        }



        private All_HI_837P BuildHealthCareDiagnosis(string diagnosis)
        {
            var diagnoses = diagnosis.Split(",").ToArray();

            var items = diagnoses;

            string qualifier = X12_ID_1270_3.ABF.X12();


            return new All_HI_837P
            {
                HI_HealthCareDiagnosisCode = new HI_DependentHealthCareDiagnosisCode
                {

                    HealthCareCodeInformation_01 = GetDiagnosisCode<C022_HealthCareCodeInformation_8>(diagnoses, 0, X12_ID_1270_2.ABK.X12()),
                    HealthCareCodeInformation_02 = GetDiagnosisCode<C022_HealthCareCodeInformation_4>(diagnoses, 1, qualifier),
                    HealthCareCodeInformation_03 = GetDiagnosisCode<C022_HealthCareCodeInformation_4>(diagnoses, 2, qualifier),
                    HealthCareCodeInformation_04 = GetDiagnosisCode<C022_HealthCareCodeInformation_4>(diagnoses, 3, qualifier),
                    HealthCareCodeInformation_05 = GetDiagnosisCode<C022_HealthCareCodeInformation_4>(diagnoses, 4, qualifier),
                    HealthCareCodeInformation_06 = GetDiagnosisCode<C022_HealthCareCodeInformation_4>(diagnoses, 5, qualifier),
                    HealthCareCodeInformation_07 = GetDiagnosisCode<C022_HealthCareCodeInformation_4>(diagnoses, 6, qualifier),
                    HealthCareCodeInformation_08 = GetDiagnosisCode<C022_HealthCareCodeInformation_4>(diagnoses, 7, qualifier),
                    HealthCareCodeInformation_09 = GetDiagnosisCode<C022_HealthCareCodeInformation>(diagnoses, 8, qualifier),
                    HealthCareCodeInformation_10 = GetDiagnosisCode<C022_HealthCareCodeInformation>(diagnoses, 9, qualifier),
                    HealthCareCodeInformation_11 = GetDiagnosisCode<C022_HealthCareCodeInformation>(diagnoses, 10, qualifier),
                    HealthCareCodeInformation_12 = GetDiagnosisCode<C022_HealthCareCodeInformation>(diagnoses, 11, qualifier),
                }
            };
        }


        private static T GetDiagnosisCode<T>(string[] diagnoses, int position, dynamic diagnosisTypeCode)
            where T : class, new()
        {
            var items = diagnoses;
            if (items.Count() <= position)
            {
                return null;
            }
            dynamic information = new T();
            try
            {
                information.CodeListQualifierCode_01 = diagnosisTypeCode;
                information.IndustryCode_02 = items.ElementAt(position).Replace(".", string.Empty);
            }
            catch (Exception e)
            {
                throw new Exception("Diagnosis Code # " + position.ToString(), e.InnerException);
            }
            return information;
        }




    }
}
