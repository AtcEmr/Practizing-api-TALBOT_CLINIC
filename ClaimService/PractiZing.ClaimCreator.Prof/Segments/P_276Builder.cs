using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Templates.Hipaa5010;
using PractiZing.Base.Entities.MasterService;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PractiZing.ClaimCreator.Prof
{
    internal class P_276Builder : ISegmentBuilder<TS276>
    {


        internal P_276Builder()
        {

        }


        public TS276 Build(Claim claim, ClaimOptions options)
        {

            var transactionSetControlNumber = ControlNumberGenerator.GenerateUniqueNumber();

            var transactionDate = options.TransactionDate;

            var submitter = options.PracticeConfig;

            var transactionIdentity = ControlNumberGenerator.GenerateUniqueIdentity();


            var patientInsurance = claim.InsuranceLevel;


            var totalAmount = Convert.ToDecimal(claim.ClaimTotal.AmountPaid);

            ST header = BuildHeader(transactionSetControlNumber, options.ClearingHouse);
            BHT_BeginningofHierarchicalTransaction_3 transaction = GetBeginningOfHierarchicalTransaction(transactionIdentity, transactionDate);

            var provider = BuildRequestTransmission(claim, options);

            //   SE trailer = GetTrailer(transactionSetControlNumber);

            return new TS276
            {
                ST = header,
                BHT_BeginningofHierarchicalTransaction = transaction,
                Loop2000A = provider,
            };
        }

        private List<Loop_2000A_276> BuildRequestTransmission(Claim claim, ClaimOptions options)
        {



            //  Repeating 2000A Loops
            List<Loop_2000A_276> Loop2000A = new List<Loop_2000A_276>();

            //  Begin 2000A Loop
            var loop2000A = new Loop_2000A_276();

            loop2000A.HL_InformationSourceLevel = new HL_BillingProviderHierarchicalLevel();
            loop2000A.HL_InformationSourceLevel.HierarchicalIDNumber_01 = "1";
            loop2000A.HL_InformationSourceLevel.HierarchicalLevelCode_03 = "20";
            loop2000A.HL_InformationSourceLevel.HierarchicalChildCode_04 = "1";

            //  Begin 2100A Loop
            loop2000A.Loop2100A = new Loop_2100A_276();

            loop2000A.Loop2100A.NM1_PayerName = new NM1_OtherPayerName();
            loop2000A.Loop2100A.NM1_PayerName.EntityIdentifierCode_01 = "PR";
            loop2000A.Loop2100A.NM1_PayerName.EntityTypeQualifier_02 = "2";
            loop2000A.Loop2100A.NM1_PayerName.ResponseContactLastorOrganizationName_03 = claim.PayerName; //"ABC INSURANCE";
            loop2000A.Loop2100A.NM1_PayerName.IdentificationCodeQualifier_08 = "PI";
            loop2000A.Loop2100A.NM1_PayerName.ResponseContactIdentifier_09 = claim.InsuranceCompanyCode; //"12345";

            //  End 2100A Loop

            //  Repeating 2000B Loops
            loop2000A.Loop2000B = new List<Loop_2000B_276>();

            //  Begin 2000B Loop
            var loop2000B = new Loop_2000B_276();

            loop2000B.HL_InformationReceiverLevel = new HL_InformationReceiverLevel();
            loop2000B.HL_InformationReceiverLevel.HierarchicalIDNumber_01 = "2";
            loop2000B.HL_InformationReceiverLevel.HierarchicalParentIDNumber_02 = "1";
            loop2000B.HL_InformationReceiverLevel.HierarchicalLevelCode_03 = "21";
            loop2000B.HL_InformationReceiverLevel.HierarchicalChildCode_04 = "1";

            //  Begin 2100B Loop
            loop2000B.Loop2100B = new Loop_2100B_276();

            loop2000B.Loop2100B.NM1_InformationReceiverName = new NM1_InformationReceiverName_3();
            loop2000B.Loop2100B.NM1_InformationReceiverName.EntityIdentifierCode_01 = "41";
            loop2000B.Loop2100B.NM1_InformationReceiverName.EntityTypeQualifier_02 = "2";
            loop2000B.Loop2100B.NM1_InformationReceiverName.ResponseContactLastorOrganizationName_03 = options.PracticeConfig.Name;
            loop2000B.Loop2100B.NM1_InformationReceiverName.IdentificationCodeQualifier_08 = "46";
            loop2000B.Loop2100B.NM1_InformationReceiverName.ResponseContactIdentifier_09 = options.PracticeConfig.Code;

            //  End 2100B Loop

            //  Repeating 2000C Loops
            loop2000B.Loop2000C = new List<Loop_2000C_276>();

            //  Begin 2000C Loop 1
            var loop2000C1 = new Loop_2000C_276();

            loop2000C1.HL_ServiceProviderLevel = new HL_ServiceProviderLevel();
            loop2000C1.HL_ServiceProviderLevel.HierarchicalIDNumber_01 = "3";
            loop2000C1.HL_ServiceProviderLevel.HierarchicalParentIDNumber_02 = "2";
            loop2000C1.HL_ServiceProviderLevel.HierarchicalLevelCode_03 = "19";
            loop2000C1.HL_ServiceProviderLevel.HierarchicalChildCode_04 = "1";

            //  Repeating 2100C Loops
            loop2000C1.Loop2100C = new List<Loop_2100C_276>();

            //  Begin 2100C Loop
            var loop2100C = new Loop_2100C_276();

            loop2100C.NM1_ProviderName = new NM1_ProviderName();
            loop2100C.NM1_ProviderName.EntityIdentifierCode_01 = "1P";
            loop2100C.NM1_ProviderName.EntityTypeQualifier_02 = "2";
            loop2100C.NM1_ProviderName.ResponseContactLastorOrganizationName_03 = "TALBOT CLINICAL SERVICES OF OHIO, LLC";
            loop2100C.NM1_ProviderName.IdentificationCodeQualifier_08 = "XX";
            loop2100C.NM1_ProviderName.ResponseContactIdentifier_09 = "1245635549";

            //  End 2100C Loop
            loop2000C1.Loop2100C.Add(loop2100C);

            //  Repeating 2000D Loops
            loop2000C1.Loop2000D = new List<Loop_2000D_276>();

            //  Begin 2000D Loop 1
            var loop2000D1 = new Loop_2000D_276();

            loop2000D1.HL_SubscriberLevel = new HL_SubscriberHierarchicalLevel();
            loop2000D1.HL_SubscriberLevel.HierarchicalIDNumber_01 = "4";
            loop2000D1.HL_SubscriberLevel.HierarchicalParentIDNumber_02 = "3";
            loop2000D1.HL_SubscriberLevel.HierarchicalLevelCode_03 = "22";
            loop2000D1.HL_SubscriberLevel.HierarchicalChildCode_04 = "0";

            loop2000D1.DMG_SubscriberDemographicInformation = new DMG_DependentDemographicInformation_3();
            loop2000D1.DMG_SubscriberDemographicInformation.DateTimePeriodFormatQualifier_01 = "D8";
            loop2000D1.DMG_SubscriberDemographicInformation.DependentBirthDate_02 = DateFormatter.FormatDate(claim.PolicyHolderDOB.Value);
            loop2000D1.DMG_SubscriberDemographicInformation.DependentGenderCode_03 = Utility.GetGender(claim.PolicyHolderSex.ToString(), true);

            

            //  Begin 2100D Loop
            loop2000D1.Loop2100D = new Loop_2100D_276();

            loop2000D1.Loop2100D.NM1_SubscriberName = new NM1_SubscriberName_2();
            loop2000D1.Loop2100D.NM1_SubscriberName.EntityIdentifierCode_01 = "IL";
            loop2000D1.Loop2100D.NM1_SubscriberName.EntityTypeQualifier_02 = "1";
            loop2000D1.Loop2100D.NM1_SubscriberName.ResponseContactLastorOrganizationName_03 = (Utility.DivideName(claim.PolicyHolderName)).lastName;
            loop2000D1.Loop2100D.NM1_SubscriberName.ResponseContactFirstName_04 = (Utility.DivideName(claim.PolicyHolderName)).firstName;
            loop2000D1.Loop2100D.NM1_SubscriberName.IdentificationCodeQualifier_08 = "MI";
            loop2000D1.Loop2100D.NM1_SubscriberName.ResponseContactIdentifier_09 = claim.PolicyNo;

            //  End 2100D Loop

            //  Repeating 2200D Loops
            loop2000D1.Loop2200D = new List<Loop_2200D_276>();

            //  Begin 2200D Loop
            var loop2200D = new Loop_2200D_276();

            loop2200D.TRN_ClaimStatusTrackingNumber = new TRN_ClaimStatusTrackingNumber();
            loop2200D.TRN_ClaimStatusTrackingNumber.TraceTypeCode_01 = "1";
            loop2200D.TRN_ClaimStatusTrackingNumber.CurrentTransactionTraceNumber_02 = claim.PatientAccountNumber;

            //  Occurrence of REF Segments in any order
            loop2200D.AllREF = new All_REF_276();

            //loop2200D.AllREF.REF_InstitutionalBillTypeIdentification = new REF_InstitutionalBillTypeIdentification();
            //loop2200D.AllREF.REF_InstitutionalBillTypeIdentification.ReferenceIdentificationQualifier_01 = "BLT";
            //loop2200D.AllREF.REF_InstitutionalBillTypeIdentification.MemberGrouporPolicyNumber_02 = "111";

            loop2200D.AllREF.REF_PatientControlNumber = new REF_PatientControlNumber();
            loop2200D.AllREF.REF_PatientControlNumber.ReferenceIdentificationQualifier_01 = "EJ";
            loop2200D.AllREF.REF_PatientControlNumber.MemberGrouporPolicyNumber_02 = claim.PatientAccountNumber;

            loop2200D.AMT_ClaimSubmittedCharges = new AMT_ClaimSubmittedCharges();
            loop2200D.AMT_ClaimSubmittedCharges.AmountQualifierCode_01 = "T3";
            loop2200D.AMT_ClaimSubmittedCharges.TotalClaimChargeAmount_02 = claim.InsuranceServices.Sum(x => x.Amount).ToString("F", CultureHelper.Culture);
            
            loop2200D.DTP_ClaimServiceDate = new DTP_ClaimLevelServiceDate();
            loop2200D.DTP_ClaimServiceDate.DateTimeQualifier_01 = "472";
            loop2200D.DTP_ClaimServiceDate.DateTimePeriodFormatQualifier_02 = "RD8";
            loop2200D.DTP_ClaimServiceDate.AccidentDate_03 = DateFormatter.FormatDateRange(claim.FromDate.Value, claim.FromDate.Value);

            //  End 2200D Loop
            loop2000D1.Loop2200D.Add(loop2200D);

            //  End 2000D Loop 1
            loop2000C1.Loop2000D.Add(loop2000D1);

            ////  Begin 2000D Loop 2
            //var loop2000D2 = new Loop_2000D_276();

            //loop2000D2.HL_SubscriberLevel = new HL_SubscriberHierarchicalLevel();
            //loop2000D2.HL_SubscriberLevel.HierarchicalIDNumber_01 = "5";
            //loop2000D2.HL_SubscriberLevel.HierarchicalParentIDNumber_02 = "3";
            //loop2000D2.HL_SubscriberLevel.HierarchicalLevelCode_03 = "22";
            //loop2000D2.HL_SubscriberLevel.HierarchicalChildCode_04 = "0";

            //loop2000D2.DMG_SubscriberDemographicInformation = new DMG_DependentDemographicInformation_3();
            //loop2000D2.DMG_SubscriberDemographicInformation.DateTimePeriodFormatQualifier_01 = "D8";
            //loop2000D2.DMG_SubscriberDemographicInformation.DependentBirthDate_02 = "19301115";
            //loop2000D2.DMG_SubscriberDemographicInformation.DependentGenderCode_03 = "F";

            ////  Begin 2100D Loop
            //loop2000D2.Loop2100D = new Loop_2100D_276();

            //loop2000D2.Loop2100D.NM1_SubscriberName = new NM1_SubscriberName_2();
            //loop2000D2.Loop2100D.NM1_SubscriberName.EntityIdentifierCode_01 = "IL";
            //loop2000D2.Loop2100D.NM1_SubscriberName.EntityTypeQualifier_02 = "1";
            //loop2000D2.Loop2100D.NM1_SubscriberName.ResponseContactLastorOrganizationName_03 = "JONES";
            //loop2000D2.Loop2100D.NM1_SubscriberName.ResponseContactFirstName_04 = "MARY";
            //loop2000D2.Loop2100D.NM1_SubscriberName.IdentificationCodeQualifier_08 = "MI";
            //loop2000D2.Loop2100D.NM1_SubscriberName.ResponseContactIdentifier_09 = "234567890A";

            //  End 2100D Loop

            //  Repeating 2200D Loops
           // loop2000D2.Loop2200D = new List<Loop_2200D_276>();

            //  Begin 2200D Loop
            //var loop2200D2 = new Loop_2200D_276();

            //loop2200D2.TRN_ClaimStatusTrackingNumber = new TRN_ClaimStatusTrackingNumber();
            //loop2200D2.TRN_ClaimStatusTrackingNumber.TraceTypeCode_01 = "1";
            //loop2200D2.TRN_ClaimStatusTrackingNumber.CurrentTransactionTraceNumber_02 = "ABCXYZ2";

            ////  Occurrence of REF Segments in any order
            //loop2200D2.AllREF = new All_REF_276();

            //loop2200D2.AllREF.REF_InstitutionalBillTypeIdentification = new REF_InstitutionalBillTypeIdentification();
            //loop2200D2.AllREF.REF_InstitutionalBillTypeIdentification.ReferenceIdentificationQualifier_01 = "BLT";
            //loop2200D2.AllREF.REF_InstitutionalBillTypeIdentification.MemberGrouporPolicyNumber_02 = "111";

            //loop2200D2.AllREF.REF_PatientControlNumber = new REF_PatientControlNumber();
            //loop2200D2.AllREF.REF_PatientControlNumber.ReferenceIdentificationQualifier_01 = "EJ";
            //loop2200D2.AllREF.REF_PatientControlNumber.MemberGrouporPolicyNumber_02 = "JO234567";

            //loop2200D2.AMT_ClaimSubmittedCharges = new AMT_ClaimSubmittedCharges();
            //loop2200D2.AMT_ClaimSubmittedCharges.AmountQualifierCode_01 = "T3";
            //loop2200D2.AMT_ClaimSubmittedCharges.TotalClaimChargeAmount_02 = "7599";

            //loop2200D2.DTP_ClaimServiceDate = new DTP_ClaimLevelServiceDate();
            //loop2200D2.DTP_ClaimServiceDate.DateTimeQualifier_01 = "472";
            //loop2200D2.DTP_ClaimServiceDate.DateTimePeriodFormatQualifier_02 = "RD8";
            //loop2200D2.DTP_ClaimServiceDate.DateTimeQualifier_01 = "20050731-20050809";

            ////  End 2200D Loop
            //loop2000D2.Loop2200D.Add(loop2200D2);

            //  End 2000D Loop 2
           // loop2000C1.Loop2000D.Add(loop2000D2);

            //  End 2000C Loop 1
            loop2000B.Loop2000C.Add(loop2000C1);

            ////  Begin 2000C Loop 2
            //var loop2000C2 = new Loop_2000C_276();

            //loop2000C2.HL_ServiceProviderLevel = new HL_ServiceProviderLevel();
            //loop2000C2.HL_ServiceProviderLevel.HierarchicalIDNumber_01 = "6";
            //loop2000C2.HL_ServiceProviderLevel.HierarchicalParentIDNumber_02 = "2";
            //loop2000C2.HL_ServiceProviderLevel.HierarchicalLevelCode_03 = "19";
            //loop2000C2.HL_ServiceProviderLevel.HierarchicalChildCode_04 = "1";

            ////  Repeating 2100C Loops
            //loop2000C2.Loop2100C = new List<Loop_2100C_276>();

            ////  Begin 2100C Loop
            //var loop2100C2 = new Loop_2100C_276();

            //loop2100C2.NM1_ProviderName = new NM1_ProviderName();
            //loop2100C2.NM1_ProviderName.EntityIdentifierCode_01 = "1P";
            //loop2100C2.NM1_ProviderName.EntityTypeQualifier_02 = "2";
            //loop2100C2.NM1_ProviderName.ResponseContactLastorOrganizationName_03 = "HOME HOSPITAL PHYSICIANS";
            //loop2100C2.NM1_ProviderName.IdentificationCodeQualifier_08 = "XX";
            //loop2100C2.NM1_ProviderName.ResponseContactIdentifier_09 = "1666666666";

            ////  End 2100C Loop
            //loop2000C2.Loop2100C.Add(loop2100C2);

            ////  Repeating 2000D Loops
            //loop2000C2.Loop2000D = new List<Loop_2000D_276>();

            ////  Begin 2000D Loop 1
            //var loop2000D3 = new Loop_2000D_276();

            //loop2000D3.HL_SubscriberLevel = new HL_SubscriberHierarchicalLevel();
            //loop2000D3.HL_SubscriberLevel.HierarchicalIDNumber_01 = "7";
            //loop2000D3.HL_SubscriberLevel.HierarchicalParentIDNumber_02 = "6";
            //loop2000D3.HL_SubscriberLevel.HierarchicalLevelCode_03 = "22";
            //loop2000D3.HL_SubscriberLevel.HierarchicalChildCode_04 = "1";

            ////  Begin 2100D Loop
            //loop2000D3.Loop2100D = new Loop_2100D_276();

            //loop2000D3.Loop2100D.NM1_SubscriberName = new NM1_SubscriberName_2();
            //loop2000D3.Loop2100D.NM1_SubscriberName.EntityIdentifierCode_01 = "IL";
            //loop2000D3.Loop2100D.NM1_SubscriberName.EntityTypeQualifier_02 = "1";
            //loop2000D3.Loop2100D.NM1_SubscriberName.ResponseContactLastorOrganizationName_03 = "MANN";
            //loop2000D3.Loop2100D.NM1_SubscriberName.ResponseContactFirstName_04 = "JOHN";
            //loop2000D3.Loop2100D.NM1_SubscriberName.IdentificationCodeQualifier_08 = "MI";
            //loop2000D3.Loop2100D.NM1_SubscriberName.ResponseContactIdentifier_09 = "345678901";

            //  End 2100D Loop   

            //  Repeating 2000E Loops
            //loop2000D3.Loop2000E = new List<Loop_2000E_276>();

            //  Begin 2000E Loop
            //var loop2000E = new Loop_2000E_276();

            //loop2000E.HL_DependentLevel = new HL_DependentLevel_2();
            //loop2000E.HL_DependentLevel.HierarchicalIDNumber_01 = "8";
            //loop2000E.HL_DependentLevel.HierarchicalParentIDNumber_02 = "7";
            //loop2000E.HL_DependentLevel.HierarchicalLevelCode_03 = "23";

            //loop2000E.DMG_DependentDemographicInformation = new DMG_DependentDemographicInformation_3();
            //loop2000E.DMG_DependentDemographicInformation.DateTimePeriodFormatQualifier_01 = "D8";
            //loop2000E.DMG_DependentDemographicInformation.DependentBirthDate_02 = "19951101";
            //loop2000E.DMG_DependentDemographicInformation.DependentGenderCode_03 = "M";

            ////  Begin 2100E Loop
            //loop2000E.Loop2100E = new Loop_2100E_276();

            //loop2000E.Loop2100E.NM1_DependentName = new NM1_DependentName_2();
            //loop2000E.Loop2100E.NM1_DependentName.EntityIdentifierCode_01 = "QC";
            //loop2000E.Loop2100E.NM1_DependentName.EntityTypeQualifier_02 = "1";
            //loop2000E.Loop2100E.NM1_DependentName.ResponseContactLastorOrganizationName_03 = "MANN";
            //loop2000E.Loop2100E.NM1_DependentName.ResponseContactFirstName_04 = "JOSEPH";

            ////  End 2100E Loop

            ////  Repeating 2200E Loops
            //loop2000E.Loop2200E = new List<Loop_2200E_276>();

            ////  Begin 2200E Loop
            //var loop2200E = new Loop_2200E_276();

            //loop2200E.TRN_ClaimStatusTrackingNumber = new TRN_ClaimStatusTrackingNumber();
            //loop2200E.TRN_ClaimStatusTrackingNumber.TraceTypeCode_01 = "1";
            //loop2200E.TRN_ClaimStatusTrackingNumber.CurrentTransactionTraceNumber_02 = "ABCXYZ3";

            ////  Occurrence of REF Segments in any order
            //loop2200E.AllREF = new All_REF_276();

            //loop2200E.AllREF.REF_PatientControlNumber = new REF_PatientControlNumber();
            //loop2200E.AllREF.REF_PatientControlNumber.ReferenceIdentificationQualifier_01 = "EJ";
            //loop2200E.AllREF.REF_PatientControlNumber.MemberGrouporPolicyNumber_02 = "MA345678";

            ////  Repeating 2210E Loops
            //loop2200E.Loop2210E = new List<Loop_2210E_276>();

            ////  Begin 2210E Loop
            //var loop2210E = new Loop_2210E_276();

            //loop2210E.SVC_ServiceLineInformation = new SVC_ServiceLineInformation();
            //loop2210E.SVC_ServiceLineInformation.CompositeMedicalProcedureIdentifier_01 = new C003_CompositeMedicalProcedureIdentifier_6();
            //loop2210E.SVC_ServiceLineInformation.CompositeMedicalProcedureIdentifier_01.ProductorServiceIDQualifier_01 = "HC";
            //loop2210E.SVC_ServiceLineInformation.CompositeMedicalProcedureIdentifier_01.ProcedureCode_02 = "99203";
            //loop2210E.SVC_ServiceLineInformation.LineItemChargeAmount_02 = "150";
            //loop2210E.SVC_ServiceLineInformation.UnitsofServiceCount_07 = "1";

            //loop2210E.DTP_ServiceLineDate = new DTP_ClaimLevelServiceDate();
            //loop2210E.DTP_ServiceLineDate.DateTimeQualifier_01 = "472";
            //loop2210E.DTP_ServiceLineDate.DateTimePeriodFormatQualifier_02 = "D8";
            //loop2210E.DTP_ServiceLineDate.DateTimeQualifier_01 = "20050501";

            //  End 2210E Loop
            //loop2200E.Loop2210E.Add(loop2210E);

            //  End 2200E Loop
            //loop2000E.Loop2200E.Add(loop2200E);

            //  End 2000E Loop
            //loop2000D3.Loop2000E.Add(loop2000E);

            //  End 2000D Loop 2
            //loop2000C2.Loop2000D.Add(loop2000D3);

            //  End 2000C Loop 2
            //loop2000B.Loop2000C.Add(loop2000C2);

            //  End 2000B Loop
            loop2000A.Loop2000B.Add(loop2000B);

            //  End 2000A Loop
            Loop2000A.Add(loop2000A);

            return Loop2000A;
        }

        private ST BuildHeader(string transactionSetControlNumber, IClearingHouse clearingHouse)
        {
            return new ST
            {
                TransactionSetIdentifierCode_01 = "276",
                TransactionSetControlNumber_02 = transactionSetControlNumber,
                ImplementationConventionPreference_03 = "005010X212"// clearingHouse.TransactionType
            };
        }

        private static SE GetTrailer(string transactionSetControlNumber)
        {
            return new SE
            {
                NumberofIncludedSegments_01 = "1",
                TransactionSetControlNumber_02 = transactionSetControlNumber
            };
        }



        public TSegment BuildSegment<TBuilder, TSegment>(Claim claim, ClaimOptions claimOptions)
        {
            return SegmentBuilders.Build<TBuilder, TSegment>(claim, claimOptions);
        }




        private static BHT_BeginningofHierarchicalTransaction_3 GetBeginningOfHierarchicalTransaction(string transactionIdentity, DateTime transationDate)
        {
            return new BHT_BeginningofHierarchicalTransaction_3
            {
                HierarchicalStructureCode_01 = "0010",
                TransactionSetPurposeCode_02 = "13",
                SubmitterTransactionIdentifier_03 = transactionIdentity,
                TransactionSetCreationDate_04 = DateFormatter.FormatDate(transationDate),
                TransactionSetCreationTime_05 = DateFormatter.FormatTime(transationDate),
                //TransactionTypeCode_06 = "CH"
            };
        }



        //private static S_SE GetTrailer(string transactionSetControlNumber)
        //{
        //    return new S_SE
        //    {
        //        D_SE01_TransactionSegmentCount = "1",
        //        D_SE02_TransactionSetControlNumber = transactionSetControlNumber
        //    };
        //}
    }
}