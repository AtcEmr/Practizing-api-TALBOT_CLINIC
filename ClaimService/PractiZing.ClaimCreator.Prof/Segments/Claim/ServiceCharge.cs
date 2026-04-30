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

    internal class ServiceChargeBuilder : ISegmentBuilder<List<Loop_2400_837P>>
    {
        public List<Loop_2400_837P> Build(Claim claim, ClaimOptions claimOptions)
        {

            List<Loop_2400_837P> chargeLines = new List<Loop_2400_837P>();
            int i = 1;
            foreach (var charge in claim.InsuranceServices)
            {
                var chargeLine = BuildCharge(claim, claimOptions, charge, i);
                chargeLines.Add(chargeLine);
                i++;
            }

            return chargeLines;
        }


        private All_NM1_837P_5 BuildRenderingProvider(Claim claim, ClaimOptions claimOptions, ICharges charge)
        {
            bool isSame = false;
            var performaingId = claim.PerformingDoctorId;

            if (charge.PerformingProviderId != null)
            {
                isSame = Convert.ToUInt16(performaingId) == charge.PerformingProviderId;
            }


            All_NM1_837P_5 renderingProvider = null;
            if (!isSame)
            {
                renderingProvider = new All_NM1_837P_5();
                renderingProvider.Loop2420A = BuildSegment<ServiceChargeRenderingProvider, Loop_2420A_837P>(claim, claimOptions);
            }

            if(claim.IsLoop2420ARequired.HasValue)
                if (claim.IsLoop2420ARequired.Value)
                    if(renderingProvider==null)
                    {
                        if(charge.POSId=="99")
                        {
                            renderingProvider = new All_NM1_837P_5();
                            renderingProvider.Loop2420A = BuildSegment<ServiceChargeRenderingProvider, Loop_2420A_837P>(claim, claimOptions);
                        }                        
                    }



                    if (!string.IsNullOrWhiteSpace(claim.OrderingDoctorFirstName))
            {
                if (renderingProvider == null)
                {
                    renderingProvider = new All_NM1_837P_5();
                }
                renderingProvider.Loop2420E = BuildSegment<OrderingProviderBuilder, Loop_2420E_837P>(claim, claimOptions);
            }



            if (claim.IsLoop2420E.HasValue && claim.IsLoop2420E.Value)
            {
                //if (claimOptions.CptCodes.Count > 0)
                //{
                //    var chargeExists = claimOptions.CptCodes.FirstOrDefault(i => i.ToString() == charge.CPTCode);
                //    if (chargeExists != null)
                //    {
                //        if(!string.IsNullOrWhiteSpace( claim.OrderingDoctorFirstName))
                //        {
                //            if (renderingProvider == null)
                //            {
                //                renderingProvider = new All_NM1_837P_5();
                //            }
                //            renderingProvider.Loop2420E = BuildSegment<OrderingProviderBuilder, Loop_2420E_837P>(claim, claimOptions);
                //        }                        
                //    }
                //}
                //Comment on 11 June 2021, 02:22 
                //if (!string.IsNullOrWhiteSpace(claim.SupervisionDoctorFirstName))
                //{
                //    if (renderingProvider == null)
                //    {
                //        renderingProvider = new All_NM1_837P_5();
                //    }

                //    renderingProvider.Loop2420E = BuildSegment<OrderingProviderBuilder, Loop_2420E_837P>(claim, claimOptions);
                //}
                //else
                //{
                //    if(claimOptions.CptCodes.Count>0)
                //    {
                //        var chargeExists = claimOptions.CptCodes.FirstOrDefault(i => i.ToString() == charge.CPTCode);
                //        if(chargeExists!=null)
                //        {
                //            if (renderingProvider == null)
                //            {
                //                renderingProvider = new All_NM1_837P_5();
                //            }
                //            renderingProvider.Loop2420E = BuildSegment<OrderingProviderBuilder, Loop_2420E_837P>(claim, claimOptions);
                //        }                        
                //    }
                //}
            }

            //if (claim.IsLoop2420DRequired.HasValue && claim.IsLoop2420DRequired.Value)
            //{
            //    if (renderingProvider == null)
            //    {
            //        renderingProvider = new All_NM1_837P_5();
            //    }

            //    if (renderingProvider.Loop2420E==null)
            //    {
            //        renderingProvider.Loop2420D = BuildSegment<ServiceChargeSupervisingProvider, Loop_2420D_837P>(claim, claimOptions);
            //    }
            //}


            return renderingProvider;
        }

        private Loop_2400_837P BuildCharge(Claim claim,
            ClaimOptions claimOptions,
            ICharges charge,

            int position)
        {
            All_NM1_837P_5 renderingProvider = BuildRenderingProvider(claim, claimOptions, charge);

            return new Loop_2400_837P
            {

                LX_ServiceLineNumber = new LX_HeaderNumber
                {
                    AssignedNumber_01 = position.ToString()
                },
                SV1_ProfessionalService = BuildProfessionalService(charge, claimOptions,claim),
                AllDTP = new All_DTP_837P
                {
                    DTP_Date_ServiceDate = BuildServiceDate(charge)
                },
                AllREF = new All_REF_837P_2
                {
                    REF_LineItemControlNumber = BuildChargeUniqueRef(charge),
                    REF_ClinicalLaboratoryImprovementAmendment_CLIA_Number = BuildCLIANumber(charge)
                },

                Loop2410 = BuildDrugInformation(charge),
                AllNM1 = renderingProvider,
                Loop2430 = claim.InsLevel > 1 ? BuildPaymentsAndAdjustment(charge, claim) : null,
            };
        }

        private SVD_LineAdjudicationInformation BuildLineAdjustment(Claim claim, ICharges charge,IPaymentCharge paymentCharge)
        {
            return new SVD_LineAdjudicationInformation
            {
                OtherPayerPrimaryIdentifier_01 = claim.SecondaryInsuranceCompanyCode,

                CompositeMedicalProcedureIdentifier_03 = new C003_CompositeMedicalProcedureIdentifier_7
                {
                    ProductorServiceIDQualifier_01 = "HC",
                    ProcedureCode_02 = charge.CPTCode,
                    ProcedureModifier_03 = !string.IsNullOrWhiteSpace(charge.Mod1) ? charge.Mod1 : "",
                    ProcedureModifier_04 = !string.IsNullOrWhiteSpace(charge.Mod1) ? charge.Mod2 : "",
                    ProcedureModifier_05 = !string.IsNullOrWhiteSpace(charge.Mod1) ? charge.Mod3 : "",
                    ProcedureModifier_06 = !string.IsNullOrWhiteSpace(charge.Mod1) ? charge.Mod4 : "",
                    Description_07 = charge.Description
                },


                ServiceLinePaidAmount_02 = paymentCharge.PaidAmount.ToString("F", CultureHelper.Culture), //charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.OtherInsCompanyId).Sum(i => i.PaidAmount).ToString("F", CultureHelper.Culture),
                //commented 14 Jan 2020 // https://therabill.zendesk.com/hc/en-us/articles/360007535611-Secondary-Payer-Format
                //loop2430.S_SVD_LineAdjudicationInformation.D_SVD04_Product_ServiceID = "1";
                //commented 14 Jan 2020
                PaidServiceUnitCount_05 = charge.Qty.ToString()

            };
        }

        private SVD_LineAdjudicationInformation BuildLineAdjustmentOther2(Claim claim, ICharges charge,IPaymentCharge paymentCharge)
        {
            return new SVD_LineAdjudicationInformation
            {
                OtherPayerPrimaryIdentifier_01 = claim.Other2CompanyCode,

                CompositeMedicalProcedureIdentifier_03 = new C003_CompositeMedicalProcedureIdentifier_7
                {
                    ProductorServiceIDQualifier_01 = "HC",
                    ProcedureCode_02 = charge.CPTCode,
                    ProcedureModifier_03 = !string.IsNullOrWhiteSpace(charge.Mod1) ? charge.Mod1 : "",
                    ProcedureModifier_04 = !string.IsNullOrWhiteSpace(charge.Mod1) ? charge.Mod2 : "",
                    ProcedureModifier_05 = !string.IsNullOrWhiteSpace(charge.Mod1) ? charge.Mod3 : "",
                    ProcedureModifier_06 = !string.IsNullOrWhiteSpace(charge.Mod1) ? charge.Mod4 : "",
                    Description_07 = charge.Description
                },


                ServiceLinePaidAmount_02 = paymentCharge.PaidAmount.ToString("F", CultureHelper.Culture),//charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.Other2InsCompanyId).Sum(i => i.PaidAmount).ToString("F", CultureHelper.Culture),
                //commented 14 Jan 2020 // https://therabill.zendesk.com/hc/en-us/articles/360007535611-Secondary-Payer-Format
                //loop2430.S_SVD_LineAdjudicationInformation.D_SVD04_Product_ServiceID = "1";
                //commented 14 Jan 2020
                PaidServiceUnitCount_05 = charge.Qty.ToString()

            };
        }

        private AMT_RemainingPatientLiability BuildRemaining(decimal remainingAmount)
        {
            return new AMT_RemainingPatientLiability
            {
                AmountQualifierCode_01 = X12_ID_522_4.EAF.X12(),
                TotalClaimChargeAmount_02 = remainingAmount.ToString("F", CultureHelper.Culture),
                CreditDebitFlagCode_03 = "C"
            };
        }

        private DTP_ClaimCheckOrRemittanceDate BuildRemittanceDate(ICharges charge, Claim claim)
        {
            return new DTP_ClaimCheckOrRemittanceDate
            {
                DateTimePeriodFormatQualifier_02 = X12_ID_1250.D8.X12(),
                DateTimeQualifier_01 = X12_ID_374_18.Item573.X12(),
                AccidentDate_03 = DateFormatter.FormatDate(charge.PaymentCharges.FirstOrDefault(i => i.InsuranceCompanyCode == claim.SecondaryInsuranceCompanyCode).PaidDate.Value)
            };
        }

        private DTP_ClaimCheckOrRemittanceDate BuildRemittanceDateOther2(ICharges charge, Claim claim)
        {
            return new DTP_ClaimCheckOrRemittanceDate
            {
                DateTimePeriodFormatQualifier_02 = X12_ID_1250.D8.X12(),
                DateTimeQualifier_01 = X12_ID_374_18.Item573.X12(),
                AccidentDate_03 = DateFormatter.FormatDate(charge.PaymentCharges.FirstOrDefault(i => i.InsuranceCompanyId == claim.Other2InsCompanyId).PaidDate.Value)
            };
        }

        private List<CAS_ClaimLevelAdjustments> BuildLineAdjustments(ICharges charge, out decimal patientResponsibility, Claim claim,IPaymentCharge paymentCharge)
        {
            var adjustments = new List<CAS_ClaimLevelAdjustments>();
            patientResponsibility = 0;

            

                var groupCodes = paymentCharge.PaymentAdjustments.Select(ad => ad.ReasonCode.Substring(0, 2)).Distinct();
                foreach (var groupCode in groupCodes)
                {
                    CAS_ClaimLevelAdjustments casAdjustment = new CAS_ClaimLevelAdjustments();
                    casAdjustment.ClaimAdjustmentGroupCode_01 = groupCode;
                    var props = typeof(CAS_ClaimLevelAdjustments).GetProperties();
                    int pCount = 0;
                    foreach (var adjustment in paymentCharge.PaymentAdjustments.Where(i => i.ReasonCode.Substring(0, 2) == groupCode))
                    {
                        var propReasonCode = props.FirstOrDefault(t => t.Name == "AdjustmentReasonCode_" + (2 + pCount).ToString().PadLeft(2, '0'));
                        var propAdjAmt = props.FirstOrDefault(t => t.Name == "AdjustmentAmount_" + (3 + pCount).ToString().PadLeft(2, '0'));
                        var propAdjQty = props.FirstOrDefault(t => t.Name == "AdjustmentQuantity_" + (4 + pCount).ToString().PadLeft(2, '0'));

                        propReasonCode.SetValue(casAdjustment, adjustment.ReasonCode.Substring(2, adjustment.ReasonCode.Length - 2));
                        propAdjAmt.SetValue(casAdjustment, adjustment.Amount.ToString("F", CultureHelper.Culture));
                        propAdjQty.SetValue(casAdjustment, charge.Qty.ToString());


                        if (adjustment.ReasonCode.Substring(0, 2) == "PR")
                        {
                            patientResponsibility += adjustment.Amount;
                        }

                        pCount += 3;
                    }

                    adjustments.Add(casAdjustment);
                }
            


            //foreach (var payment in charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.OtherInsCompanyId))
            //{

            //    var groupCodes = payment.PaymentAdjustments.Select(ad => ad.ReasonCode.Substring(0, 2)).Distinct();
            //    foreach (var groupCode in groupCodes)
            //    {
            //        CAS_ClaimLevelAdjustments casAdjustment = new CAS_ClaimLevelAdjustments();
            //        casAdjustment.ClaimAdjustmentGroupCode_01 = groupCode;
            //        var props = typeof(CAS_ClaimLevelAdjustments).GetProperties();
            //        int pCount = 0;
            //        foreach (var adjustment in payment.PaymentAdjustments.Where(i => i.ReasonCode.Substring(0, 2) == groupCode))
            //        {
            //            var propReasonCode = props.FirstOrDefault(t => t.Name == "AdjustmentReasonCode_" + (2 + pCount).ToString().PadLeft(2, '0'));
            //            var propAdjAmt = props.FirstOrDefault(t => t.Name == "AdjustmentAmount_" + (3 + pCount).ToString().PadLeft(2, '0'));
            //            var propAdjQty = props.FirstOrDefault(t => t.Name == "AdjustmentQuantity_" + (4 + pCount).ToString().PadLeft(2, '0'));

            //            propReasonCode.SetValue(casAdjustment, adjustment.ReasonCode.Substring(2, adjustment.ReasonCode.Length - 2));
            //            propAdjAmt.SetValue(casAdjustment, adjustment.Amount.ToString("F", CultureHelper.Culture));
            //            propAdjQty.SetValue(casAdjustment, charge.Qty.ToString());


            //            if (adjustment.ReasonCode.Substring(0, 2) == "PR")
            //            {
            //                patientResponsibility += adjustment.Amount;
            //            }

            //            pCount += 3;
            //        }

            //        adjustments.Add(casAdjustment);
            //    }
            //}
            return adjustments;
        }

        private List<CAS_ClaimLevelAdjustments> BuildLineAdjustmentsOther2(ICharges charge, out decimal patientResponsibility, Claim claim, IPaymentCharge paymentCharge)
        {
            var adjustments = new List<CAS_ClaimLevelAdjustments>();
            patientResponsibility = 0;
            var groupCodes = paymentCharge.PaymentAdjustments.Select(ad => ad.ReasonCode.Substring(0, 2)).Distinct();


            foreach (var groupCode in groupCodes)
            {
                CAS_ClaimLevelAdjustments casAdjustment = new CAS_ClaimLevelAdjustments();
                casAdjustment.ClaimAdjustmentGroupCode_01 = groupCode;
                var props = typeof(CAS_ClaimLevelAdjustments).GetProperties();
                int pCount = 0;
                foreach (var adjustment in paymentCharge.PaymentAdjustments.Where(i => i.ReasonCode.Substring(0, 2) == groupCode))
                {
                    var propReasonCode = props.FirstOrDefault(t => t.Name == "AdjustmentReasonCode_" + (2 + pCount).ToString().PadLeft(2, '0'));
                    var propAdjAmt = props.FirstOrDefault(t => t.Name == "AdjustmentAmount_" + (3 + pCount).ToString().PadLeft(2, '0'));
                    var propAdjQty = props.FirstOrDefault(t => t.Name == "AdjustmentQuantity_" + (4 + pCount).ToString().PadLeft(2, '0'));

                    propReasonCode.SetValue(casAdjustment, adjustment.ReasonCode.Substring(2, adjustment.ReasonCode.Length - 2));
                    propAdjAmt.SetValue(casAdjustment, adjustment.Amount.ToString("F", CultureHelper.Culture));
                    propAdjQty.SetValue(casAdjustment, charge.Qty.ToString());


                    if (adjustment.ReasonCode.Substring(0, 2) == "PR")
                    {
                        patientResponsibility += adjustment.Amount;
                    }

                    pCount += 3;
                }

                adjustments.Add(casAdjustment);
            }

            return adjustments;
        }

        private List<Loop_2430_837P> BuildPaymentsAndAdjustment(ICharges charge, Claim claim)
        {

            List<Loop_2430_837P> lst = new List<Loop_2430_837P>();
            Loop_2430_837P loop2430 = null;
            if (charge.PaymentCharges.Where(i => i.InsuranceCompanyCode == claim.SecondaryInsuranceCompanyCode).Count() > 0)
            {
                var paymentCharges = charge.PaymentCharges.Where(i => i.InsuranceCompanyCode == claim.SecondaryInsuranceCompanyCode && i.IsDenial==false);
                if(paymentCharges==null || paymentCharges.Count()==0)
                {
                    paymentCharges = charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.OtherInsCompanyId).OrderByDescending(i=>i.Id);
                }

                foreach (var paymentCharge in paymentCharges)
                {
                    loop2430 = new Loop_2430_837P();
                    loop2430.SVD_LineAdjudicationInformation = BuildLineAdjustment(claim, charge, paymentCharge);


                    var paidamount = paymentCharge.PaidAmount;//charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.OtherInsCompanyId).Sum(i => i.PaidAmount);//.ToString("F", CultureHelper.Culture);

                    //if (charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.OtherInsCompanyId).Count() > 0)
                    //{
                    //    charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.OtherInsCompanyId).ToList().ForEach((res) =>
                    //    {
                    //        res.TotalAdjustment = res.PaymentAdjustments.Where(i => i.PaymentChargeId == res.Id).Sum(i => i.Amount);
                    //    });

                    //    paidamount = paidamount + charge.PaymentCharges.Sum(i => i.TotalAdjustment);
                    //}
                    paidamount = paidamount + paymentCharge.PaymentAdjustments.Sum(i => i.Amount);
                    var chargeBalance = charge.Amount - paidamount;

                    //loop2430.AMT_RemainingPatientLiability = BuildRemaining(chargeBalance);

                    loop2430.DTP_LineCheckorRemittanceDate = BuildRemittanceDate(charge, claim);

                    if (paymentCharge!=null)
                    {
                        decimal patientResponsibility = 0;
                        loop2430.CAS_LineAdjustment = BuildLineAdjustments(charge, out patientResponsibility, claim,paymentCharge);
                        if (patientResponsibility > 0)
                        {
                            loop2430.AMT_RemainingPatientLiability = new AMT_RemainingPatientLiability();
                            loop2430.AMT_RemainingPatientLiability.AmountQualifierCode_01 = "EAF";
                            loop2430.AMT_RemainingPatientLiability.TotalClaimChargeAmount_02 = patientResponsibility.ToString("F", CultureHelper.Culture);
                        }
                    }

                    lst.Add(loop2430);
                }               
            }
            

            if (claim.InsLevel == 3)
            {
                var item = BuildPaymentsAndAdjustmentOther2(charge, claim);
                if (item != null)
                    lst.Add(BuildPaymentsAndAdjustmentOther2(charge, claim));
            }

            return lst;
        }

        private Loop_2430_837P BuildPaymentsAndAdjustmentOther2(ICharges charge, Claim claim)
        {
            Loop_2430_837P loop2430 = null;
            if (charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.Other2InsCompanyId).Count() > 0)
            {

                var paymentCharges = charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.Other2InsCompanyId && i.IsDenial == false);

                if (paymentCharges == null || paymentCharges.Count() == 0)
                {
                    paymentCharges = charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.Other2InsCompanyId).OrderByDescending(i => i.Id);
                }

                foreach (var paymentCharge in paymentCharges)
                {
                    loop2430 = new Loop_2430_837P();

                    loop2430.SVD_LineAdjudicationInformation = BuildLineAdjustmentOther2(claim, charge, paymentCharge);

                    var paidamount = paymentCharge.PaidAmount; //charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.Other2InsCompanyId).Sum(i => i.PaidAmount);//.ToString("F", CultureHelper.Culture);

                    //if (charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.Other2InsCompanyId).Count() > 0)
                    //{
                    //    charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.Other2InsCompanyId).ToList().ForEach((res) =>
                    //    {
                    //        res.TotalAdjustment = res.PaymentAdjustments.Where(i => i.PaymentChargeId == res.Id).Sum(i => i.Amount);
                    //    });

                    //    paidamount = paidamount + charge.PaymentCharges.Sum(i => i.TotalAdjustment);
                    //}

                    paidamount = paidamount + paymentCharge.PaymentAdjustments.Sum(i => i.Amount);

                    var chargeBalance = charge.Amount - paidamount;

                    //loop2430.AMT_RemainingPatientLiability = BuildRemaining(chargeBalance);

                    loop2430.DTP_LineCheckorRemittanceDate = BuildRemittanceDateOther2(charge, claim);

                    if (charge.PaymentCharges.Where(i => i.InsuranceCompanyId == claim.Other2InsCompanyId).Count() > 0)
                    {
                        decimal patientResponsibility = 0;
                        loop2430.CAS_LineAdjustment = BuildLineAdjustmentsOther2(charge, out patientResponsibility, claim, paymentCharge);
                        if (patientResponsibility > 0)
                        {
                            loop2430.AMT_RemainingPatientLiability = new AMT_RemainingPatientLiability();
                            loop2430.AMT_RemainingPatientLiability.AmountQualifierCode_01 = "EAF";
                            loop2430.AMT_RemainingPatientLiability.TotalClaimChargeAmount_02 = patientResponsibility.ToString("F", CultureHelper.Culture);
                        }
                    }

                }

                
            }

                

            return loop2430;
        }


        private static SV1_ProfessionalService BuildProfessionalService(ICharges charge, ClaimOptions claimOptions, Claim claim)
        {

            var professionalService = new SV1_ProfessionalService
            {
                CompositeMedicalProcedureIdentifier_01 = new C003_CompositeMedicalProcedureIdentifier_12
                {

                    ProductorServiceIDQualifier_01 = X12_ID_235_2.HC.X12(),
                    ProcedureCode_02 = charge.CPTCode,
                    ProcedureModifier_03 = charge.Mod1,
                    ProcedureModifier_04 = charge.Mod2,
                    ProcedureModifier_05 = charge.Mod3,
                    ProcedureModifier_06 = charge.Mod4,
                    Description_07 = charge.Description
                },

                LineItemChargeAmount_02 = charge.Amount.ToString("F", CultureHelper.Culture),
                UnitorBasisforMeasurementCode_03 = "UN",// X12_ID_355_5.UN, oldcode
                ServiceUnitCount_04 = charge.Qty.ToString(),
                PlaceofServiceCode_05 = claimOptions.ClearingHouse.Name != "OHIOMEDICAID" ? charge.POSId : "",
                EmergencyIndicator_09 = charge.EMG
            };

            if (charge.CPTCode.StartsWith("J"))
            {
                //if (claim.ClaimToAddress1.ToLower().Contains("humana"))
                //{
                //    professionalService.CompositeMedicalProcedureIdentifier_01.Description_07 = "";
                //}
                if (claim.InsuranceCompanyCode== "29076")
                {
                    professionalService.CompositeMedicalProcedureIdentifier_01.Description_07 = "";
                }
                if (claim.InsuranceCompanyCode == "BHOVO")
                {
                    professionalService.CompositeMedicalProcedureIdentifier_01.Description_07 = "";
                }
            }

            var diagnosisCodePointer =
            professionalService.CompositeDiagnosisCodePointer_07 = new C004_CompositeDiagnosisCodePointer();
            if (charge.DiagnoseCode != null && charge.DiagnoseCode.Length > 0)
            {
                int[] diagnoses = Array.ConvertAll(charge.DiagnoseCode.Split(','), int.Parse);

                var diagnosisCodePointerType = typeof(C004_CompositeDiagnosisCodePointer);
                for (var i = 0; i < diagnoses.Length; i++)
                {
                    diagnosisCodePointerType.GetProperty($"DiagnosisCodePointer_0{i + 1}")
                                            .SetValue(diagnosisCodePointer, diagnoses[i].ToString()); //todo check
                }
            }

            return professionalService;
        }

        private DTP_ClaimLevelServiceDate BuildServiceDate(ICharges details)
        {

            return new DTP_ClaimLevelServiceDate
            {
                DateTimeQualifier_01 = X12_ID_374_19.Item472.X12(),
                DateTimePeriodFormatQualifier_02 = X12_ID_1250_2.RD8.X12(),
                AccidentDate_03 = DateFormatter.FormatDateRange(details.BillFromDate, details.BillFromDate)
            };
        }

        private REF_ClinicalLaboratoryImprovementAmendment BuildCLIANumber(ICharges charge)
        {

            if (!string.IsNullOrWhiteSpace(charge.CliaNumber))
            {
                return new REF_ClinicalLaboratoryImprovementAmendment
                {
                    ReferenceIdentificationQualifier_01 = X12_ID_128_17.X4.X12(),
                    MemberGrouporPolicyNumber_02 = charge.CliaNumber
                };
            }
            return null;
        }

        private REF_LineItemControlNumber BuildChargeUniqueRef(ICharges charge)
        {
            return new REF_LineItemControlNumber
            {
                ReferenceIdentificationQualifier_01 = X12_ID_128_32.Item6R.X12(),
                MemberGrouporPolicyNumber_02 = charge.ChargeNo.ToString()
            };
        }

        private Loop_2410_837P BuildDrugInformation(ICharges ndcInfo)
        {
            return (ndcInfo.DrugQty != 0 && ndcInfo.DrugQty != null)
                ? new Loop_2410_837P
                {
                    LIN_DrugIdentification = new LIN_DrugIdentification_2
                    {
                        ProductorServiceIDQualifier_02 = "N4",//ndcInfo.NDCFormat.ToString(),//(X12_ID_235_4)Enum.Parse(typeof(X12_ID_235_4), ndcInfo.NDCFormat), //todo
                        NationalDrugCode_03 = ndcInfo.NDCCode.Replace("-","")
                    },
                    CTP_DrugQuantity = new CTP_DrugQuantity
                    {
                        NationalDrugUnitCount_04 = (ndcInfo.DrugQty ?? 0).ToString(),
                        CompositeUnitofMeasure_05 = new C001_CompositeUnitofMeasure_2
                        {
                            UnitorBasisforMeasurementCode_01 = CodeQualifierValues.ValuesArray[(ndcInfo.UnitOfMeasure-1) ?? 0]
                        }
                    }
                }
                : null;
        }


        public TSegment BuildSegment<TBuilder, TSegment>(Claim claim, ClaimOptions claimOptions)
        {
            return SegmentBuilders.Build<TBuilder, TSegment>(claim, claimOptions);
        }
    }
}
