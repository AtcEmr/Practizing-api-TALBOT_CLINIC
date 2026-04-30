using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{

    internal class ReferringProviderBuilder : ISegmentBuilder<Loop_2310A_837P>
    {
      
        public Loop_2310A_837P Build(Claim claim, ClaimOptions claimOptions)
        {
          
            X12_ID_98_9 item = new X12_ID_98_9();
            if (claim.ReferringPhyQualifier == "DN")
            {
                item = X12_ID_98_9.DN;
            }
            else if (claim.ReferringPhyQualifier == "DQ")
            {
                item = X12_ID_98_9.DQ;
            }

            return new Loop_2310A_837P
            {
                NM1_ReferringProviderName = new NM1_ReferringProviderName
                {
                    EntityIdentifierCode_01 = item.X12(),
                    EntityTypeQualifier_02 = X12_ID_1065_3.Item1.X12(),
                    ResponseContactLastorOrganizationName_03 = claim.ReferringPhyLastName,
                    ResponseContactFirstName_04 = claim.ReferringPhyFirstName,
                    ResponseContactMiddleName_05 = "",                    
                    IdentificationCodeQualifier_08 = IdentificationCodeQualifier.XX.X12(),
                    ResponseContactIdentifier_09 = claim.ReferringPhysicianNpi
                }
            };
        }
    }
}
