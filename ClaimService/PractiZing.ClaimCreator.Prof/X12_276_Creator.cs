
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Framework.Writers;
using EdiFabric.Templates.Hipaa5010;
using PractiZing.Base.Entities.MasterService;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;

namespace PractiZing.ClaimCreator.Prof
{

    public class X12_276_Creator
    {
        private ClaimOptions _claimOptions;

        public X12_276_Creator(ClaimOptions claimOptions)
        {
            _claimOptions = claimOptions;
        }



        public string Create(IEnumerable<Claim> claims)
        {
            string isaControlNumber = RandomControlNumber();
            ISA interchangeHeader = BuildISAHeader(_claimOptions.ClearingHouse, _claimOptions.TransactionDate, isaControlNumber);

            GS groupHeader = CreateGroupHeader(interchangeHeader,
                                                _claimOptions.ClearingHouse.TransactionType,
                                                _claimOptions.ClearingHouse.TransactionType,
                                                _claimOptions.TransactionDate);

            try
            {
                using (var stream = new MemoryStream())
                {
                    using (var writerX = new X12Writer(stream))
                    {
                        writerX.Write(interchangeHeader);
                        writerX.Write(groupHeader);
                        foreach (var claim in claims)
                        {
                            var message_837_p = SegmentBuilders.Build<P_276Builder, TS276>(claim, _claimOptions);
                            writerX.Write(message_837_p);
                        }
                    }

                    var ediString = stream.LoadToString();

                    /*code added - writer is adding line seperator and element seperator is not getting applied*/
                    return ediString.Replace("~", "~\n").Replace(">", ":");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private ISA BuildISAHeader(IClearingHouse clearingHouse, DateTime transactionDate, string isaControlNumber)
        {
            return new ISA
            {
                AuthorizationInformationQualifier_1 = clearingHouse.AuthorizationInformationQualifier,
                AuthorizationInformation_2 = clearingHouse.AuthorizationInformation.PadRight(10, ' '),
                SecurityInformationQualifier_3 = clearingHouse.SecurityInformationQualifier,
                SecurityInformation_4 = clearingHouse.SecurityInformation.PadRight(10, ' '),
                SenderIDQualifier_5 = clearingHouse.SENDERTYPE,
                InterchangeSenderID_6 = clearingHouse.SENDER_ID.PadRight(15, ' '),
                ReceiverIDQualifier_7 = clearingHouse.RECVRTYPE,
                InterchangeReceiverID_8 = clearingHouse.RECVR_ID.PadRight(15, ' '),
                InterchangeDate_9 = $"{transactionDate:yyMMdd}",
                InterchangeTime_10 = $"{transactionDate:HHmm}",
                InterchangeControlStandardsIdentifier_11 = "^",
                InterchangeControlVersionNumber_12 = "00501",
                InterchangeControlNumber_13 = isaControlNumber,
                AcknowledgementRequested_14 = "0",
                UsageIndicator_15 = clearingHouse.TestMode ? "T" : "P",
                ComponentElementSeparator_16 = ":"
            };

        }
        public GS CreateGroupHeader(ISA interchangeHeader,
          string transactionType,
          string versionAndRelease,
          DateTime transactionDate)
        {
            string gsControlNumber = RandomControlNumber();

            GS result = new GS
            {
                CodeIdentifyingInformationType_1 = "HC",
                SenderIDCode_2 = interchangeHeader.InterchangeSenderID_6.Trim(),
                ReceiverIDCode_3 = interchangeHeader.InterchangeReceiverID_8,
                Date_4 = $"{transactionDate:yyyyMMdd}",
                Time_5 = $"{transactionDate:HHmm}",
                GroupControlNumber_6 = gsControlNumber,
                TransactionTypeCode_7 = "X",
                VersionAndRelease_8 = "005010X212"//versionAndRelease// _clearingHouse.TransactionType,
            };

            return result;
        }

        private string RandomControlNumber()
        {
            using (var cryptoProvider = RandomNumberGenerator.Create())
            {
                byte[] secretKeyByteArray = new byte[32]; //256 bit
                cryptoProvider.GetBytes(secretKeyByteArray);
                return BitConverter.ToUInt32(secretKeyByteArray, 0).ToString().Substring(0, 9);
            }
        }



    }
}
