using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class RenderingProviderBuilder: ISegmentBuilder<Loop_2310B_837P>          
    {
        
        public Loop_2310B_837P Build(Claim provider, ClaimOptions claimOptions)
        {
            return provider != null
                ? new Loop_2310B_837P
                {
                    NM1_RenderingProviderName = GetProviderInfo(provider)     ,
                    PRV_RenderingProviderSpecialtyInformation=GetTaxonomy(provider)
                }
                : null;
        }

        private PRV_RenderingProviderSpecialtyInformation GetTaxonomy(Claim claim)
        {
            if(string.IsNullOrWhiteSpace(claim.PerformingProviderTaxonomy))
            {
                return null;
            }
            PRV_RenderingProviderSpecialtyInformation pRV_RenderingProviderSpecialtyInformation = new PRV_RenderingProviderSpecialtyInformation();
            pRV_RenderingProviderSpecialtyInformation.ProviderCode_01 = "PE";
            pRV_RenderingProviderSpecialtyInformation.ReferenceIdentificationQualifier_02 = "PXC";
            pRV_RenderingProviderSpecialtyInformation.ProviderTaxonomyCode_03 = claim.PerformingProviderTaxonomy;

            return pRV_RenderingProviderSpecialtyInformation;

        }

        private  NM1_RenderingProviderName GetName(Claim name)            
        {
            var nameLoop = new NM1_RenderingProviderName();
            nameLoop.EntityIdentifierCode_01 = X12_ID_98_10.Item82.X12();
            nameLoop.EntityTypeQualifier_02 = X12_ID_1065.Item1.X12();

            if (!string.IsNullOrWhiteSpace(name.ReferringPhyLastName))
            {
                nameLoop.ResponseContactLastorOrganizationName_03 = name.IsRefProviderAndRendProviderSame.Value ? name.ReferringPhyLastName : name.PerformingDoctorLastName;
            }
            else
            {
                nameLoop.ResponseContactLastorOrganizationName_03 = name.PerformingDoctorLastName; 
            }

            if (!string.IsNullOrWhiteSpace(name.ReferringPhyFirstName))
            {
                nameLoop.ResponseContactFirstName_04 = name.IsRefProviderAndRendProviderSame.Value ? name.ReferringPhyFirstName : name.PerformingDoctorFirstName;
            }
            else
            {
                nameLoop.ResponseContactFirstName_04 = name.PerformingDoctorFirstName; 
            }

            if (!string.IsNullOrWhiteSpace(name.ReferringPhyMI))
            {
                nameLoop.ResponseContactMiddleName_05 = name.IsRefProviderAndRendProviderSame.Value ? name.ReferringPhyMI : name.PerformingDoctorMiddleName;
            }
            else
            {
                nameLoop.ResponseContactMiddleName_05 = name.PerformingDoctorMiddleName;
            }

            nameLoop.ResponseContactNameSuffix_07 = "";
            return nameLoop;
        }

        private NM1_RenderingProviderName GetProviderInfo(Claim provider)
        {
            NM1_RenderingProviderName result = GetName(provider);
            if (!string.IsNullOrWhiteSpace(provider.ReferringPhysicianNpi))
            {
                result.ResponseContactIdentifier_09 = provider.IsRefProviderAndRendProviderSame.Value ? provider.ReferringPhysicianNpi : provider.PerformingDoctorNPI;
            }
            else
            {
                result.ResponseContactIdentifier_09 = !string.IsNullOrWhiteSpace(provider.GroupNPI)? provider.GroupNPI: provider.PerformingDoctorNPI;
            }
            
            result.IdentificationCodeQualifier_08 = "XX";
            return result;
        }
    }
}
