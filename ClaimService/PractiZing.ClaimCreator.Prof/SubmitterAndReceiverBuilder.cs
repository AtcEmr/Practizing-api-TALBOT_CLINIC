using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{

    internal class SubmitterAndReceiverBuilder : ISegmentBuilder<All_NM1_837P_6>
    {

        public All_NM1_837P_6 Build(Claim claim, ClaimOptions claimOptions)
        {

            return new All_NM1_837P_6
            {
                Loop1000A = BuildSubmitter(claimOptions.PracticeConfig),
                Loop1000B = BuildReceiver(claimOptions)
            };
        }


        private Loop_1000A_837P BuildSubmitter(PracticeConfig practice)
        {
            return new Loop_1000A_837P
            {
                NM1_SubmitterName = BuildName(practice),
                PER_SubmitterEDIContactInformation = BuildContacts(practice)
            };

        }

        private NM1_InformationReceiverName_4 BuildName(PracticeConfig practice)
        {
            return new NM1_InformationReceiverName_4
            {
                EntityIdentifierCode_01 = X12_ID_98.Item41.X12(),
                EntityTypeQualifier_02 = X12_ID_1065.Item2.X12(),
                ResponseContactLastorOrganizationName_03 = practice.Name,
                IdentificationCodeQualifier_08 = IdentificationCodeQualifier.Item46.X12(),
                ResponseContactIdentifier_09 = practice.Code
            };
        }


        private Loop_1000B_837P BuildReceiver(ClaimOptions options)
        {
            return new Loop_1000B_837P
            {
                NM1_ReceiverName = new NM1_ReceiverName
                {
                    EntityIdentifierCode_01 = X12_ID_98_3.Item40.X12(),
                    EntityTypeQualifier_02 = X12_ID_1065_2.Item2.X12(),
                    ResponseContactLastorOrganizationName_03 = options.ClearingHouse.Name,
                    IdentificationCodeQualifier_08 = "46",
                    ResponseContactIdentifier_09 = options.ClearingHouse.RECVR_ID
                }
            };
        }

        private List<PER_BillingProviderContactInformation> BuildContacts(PracticeConfig practice)
        {
            var contactInformation = new PER_BillingProviderContactInformation();
            contactInformation.ContactFunctionCode_01 = X12_ID_366.IC.X12();

            var contact = practice.Contact;

            if (contact != null)
            {
                contactInformation.CommunicationNumberQualifier_03 = "TE";
                contactInformation.ResponseContactCommunicationNumber_04 = contact.Phone;

                contactInformation.CommunicationNumberQualifier_05 = "EX";
                contactInformation.ResponseContactCommunicationNumber_06 = contact.Fax;

                contactInformation.CommunicationNumberQualifier_07 = "EM";
                contactInformation.ResponseContactCommunicationNumber_08 = contact.Email;
            }

            return new List<PER_BillingProviderContactInformation> { contactInformation };
        }


    }
}
