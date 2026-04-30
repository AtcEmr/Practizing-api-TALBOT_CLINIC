using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class ServiceChargeRenderingProvider :ISegmentBuilder<Loop_2420A_837P>
        
    {
       
        public Loop_2420A_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            return claim != null
                ? new Loop_2420A_837P
                {
                    NM1_RenderingProviderName = GetRenderingProviderName(claim)                    
                }
                : null;
        }

        
        protected NM1_RenderingProviderName GetRenderingProviderName(Claim provider)
        {
            NM1_RenderingProviderName nameLoop = new NM1_RenderingProviderName();
            nameLoop.EntityIdentifierCode_01 = X12_ID_98_10.Item82.X12();
            nameLoop.EntityTypeQualifier_02 = X12_ID_1065.Item1.X12();
            nameLoop.ResponseContactLastorOrganizationName_03 = provider.PerformingDoctorLastName;
            nameLoop.ResponseContactFirstName_04 = provider.PerformingDoctorFirstName;
            nameLoop.ResponseContactNameSuffix_07 = "";
            nameLoop.ResponseContactMiddleName_05 = "";
            nameLoop.IdentificationCodeQualifier_08 = IdentificationCodeQualifier.XX.X12();
            nameLoop.ResponseContactIdentifier_09 = provider.PerformingDoctorNPI == string.Empty ? "" : provider.PerformingDoctorNPI;
            return nameLoop;
        }
    }
}
