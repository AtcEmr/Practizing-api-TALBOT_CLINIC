using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class OrderingProviderBuilder : ISegmentBuilder<Loop_2420E_837P>
          
    {
      
        public Loop_2420E_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            return claim != null
                ? new Loop_2420E_837P
                {
                    NM1_OrderingProviderName = new NM1_OrderingProviderName
                    {
                        EntityIdentifierCode_01 = X12_ID_98_16.DK.X12(),
                        EntityTypeQualifier_02 = X12_ID_1065_3.Item1.X12(),
                        ResponseContactLastorOrganizationName_03 = claim.OrderingDoctorLastName,
                        ResponseContactFirstName_04 = claim.OrderingDoctorFirstName,
                        //ResponseContactMiddleName_05 = !string.IsNullOrWhiteSpace(claim.SupervisionDoctorMiddleName) ? claim.SupervisionDoctorMiddleName : "",
                        ResponseContactMiddleName_05 = !string.IsNullOrWhiteSpace(claim.OrderingDoctorMiddleName) ? claim.OrderingDoctorMiddleName : "",
                        ResponseContactNameSuffix_07 = "",
                        IdentificationCodeQualifier_08 = IdentificationCodeQualifier.XX.X12(),
                        ResponseContactIdentifier_09 = claim.OrderingDoctorNPI
                    }
                }
                : null;
        }        
    }
}
