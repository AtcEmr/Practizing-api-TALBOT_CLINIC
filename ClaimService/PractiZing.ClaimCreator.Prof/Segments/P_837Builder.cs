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
    internal class P_837Builder : ISegmentBuilder<TS837P>
    {


        internal P_837Builder()
        {

        }


        public TS837P Build(Claim claim, ClaimOptions options)
        {

            string transactionSetControlNumber = "";
            if (claim.TransactionNumber.HasValue)
                transactionSetControlNumber = claim.TransactionNumber.ToString();//ControlNumberGenerator.GenerateUniqueNumber();
            else
                transactionSetControlNumber = ControlNumberGenerator.GenerateUniqueNumber();

            var transactionDate = options.TransactionDate;

            var submitter = options.PracticeConfig;

            var transactionIdentity = ControlNumberGenerator.GenerateUniqueIdentity();


            var patientInsurance = claim.InsuranceLevel;


            var totalAmount = Convert.ToDecimal(claim.ClaimTotal.AmountPaid);

            ST header = BuildHeader(transactionSetControlNumber, options.ClearingHouse);
            BHT_BeginningofHierarchicalTransaction_7 transaction = GetBeginningOfHierarchicalTransaction(transactionIdentity, transactionDate);
            All_NM1_837P_6 receiver = BuildSegment<SubmitterAndReceiverBuilder, All_NM1_837P_6>(claim, options);


            List<Loop_2000A_837P> provider = new List<Loop_2000A_837P> { BuildSegment<PayToProviderBuilder, Loop_2000A_837P>(claim, options) };

            if (claim.InsuranceLevel == BillToType.Secondary.ToString())
            {

            }
            else
            {

            }


            //   SE trailer = GetTrailer(transactionSetControlNumber);

            return new TS837P
            {
                ST = header,
                BHT_BeginningofHierarchicalTransaction = transaction,
                AllNM1 = receiver,
                Loop2000A = provider,
            };
        }

        private ST BuildHeader(string transactionSetControlNumber, IClearingHouse clearingHouse)
        {
            return new ST
            {
                TransactionSetIdentifierCode_01 = X12_ID_143.Item837.X12(),
                TransactionSetControlNumber_02 = transactionSetControlNumber,
                ImplementationConventionPreference_03 = clearingHouse.TransactionType
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




        private static BHT_BeginningofHierarchicalTransaction_7 GetBeginningOfHierarchicalTransaction(string transactionIdentity, DateTime transationDate)
        {
            return new BHT_BeginningofHierarchicalTransaction_7
            {
                HierarchicalStructureCode_01 = X12_ID_1005.Item0019.X12(),
                TransactionSetPurposeCode_02 = X12_ID_353.Item00.X12(),
                SubmitterTransactionIdentifier_03 = transactionIdentity,
                TransactionSetCreationDate_04 = DateFormatter.FormatDate(transationDate),
                TransactionSetCreationTime_05 = DateFormatter.FormatTime(transationDate),
                TransactionTypeCode_06 = "CH"
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