using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class ServiceChargeSupervisingProvider : ISegmentBuilder<Loop_2420D_837P>
        
    {
       
        public Loop_2420D_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            return claim != null
                ? new Loop_2420D_837P
                {
                    NM1_SupervisingProviderName = GetRenderingProviderName(claim)                    
                }
                : null;
        }

        
        protected NM1_SupervisingProviderName GetRenderingProviderName(Claim provider)
        {
            NM1_SupervisingProviderName nameLoop = new NM1_SupervisingProviderName();
            nameLoop.EntityIdentifierCode_01 = X12_ID_98_9.DQ.X12();
            nameLoop.EntityTypeQualifier_02 = X12_ID_1065.Item1.X12();
            nameLoop.ResponseContactLastorOrganizationName_03 = provider.SupervisionDoctorLastName;
            nameLoop.ResponseContactFirstName_04 = provider.SupervisionDoctorFirstName;
            nameLoop.ResponseContactNameSuffix_07 = "";
            nameLoop.ResponseContactMiddleName_05 = "";
            nameLoop.IdentificationCodeQualifier_08 = IdentificationCodeQualifier.XX.X12();
            nameLoop.ResponseContactIdentifier_09 = provider.SupervisionDoctorNPI == string.Empty ? "" : provider.SupervisionDoctorNPI;
            return nameLoop;
        }
    }
}
