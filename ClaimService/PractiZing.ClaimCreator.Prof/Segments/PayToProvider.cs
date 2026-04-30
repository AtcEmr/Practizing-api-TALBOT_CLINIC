using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{

    internal class PayToProviderBuilder : ISegmentBuilder<Loop_2000A_837P>
    {
        public Loop_2000A_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            return new Loop_2000A_837P
            {
                HL_BillingProviderHierarchicalLevel = BuildHierarchicalLevel(claimOptions),
                PRV_BillingProviderSpecialtyInformation = BuildSpecialtyInformation(claim),
                AllNM1 = SegmentBuilders.Build<BillingProviderBuilder, All_NM1_837P>(claim, claimOptions),
                Loop2000B = new List<Loop_2000B_837P> { SegmentBuilders.Build<SubscriberHierarchicalBuilder, Loop_2000B_837P>(claim, claimOptions) }
            };
        }

        private HL_BillingProviderHierarchicalLevel BuildHierarchicalLevel(ClaimOptions claimOptions)
        {

            if (claimOptions.ClearingHouse.RECVR_ID == "ZIRMED" || claimOptions.ClearingHouse.Name == "OHIOMEDICAID")
            {
                return new HL_BillingProviderHierarchicalLevel
                {
                    HierarchicalIDNumber_01 = "1",
                    HierarchicalParentIDNumber_02 = "",
                    HierarchicalLevelCode_03 = "20",
                    HierarchicalChildCode_04 = "1"

                };
            }
            else
            {
                return new HL_BillingProviderHierarchicalLevel
                {
                    HierarchicalIDNumber_01 = "1",
                    HierarchicalParentIDNumber_02 = "0",
                    HierarchicalLevelCode_03 = "20",
                    HierarchicalChildCode_04 = "1"

                };
            }


        }

        private PRV_BillingProviderSpecialtyInformation BuildSpecialtyInformation(Claim claim)
        {
            if (String.IsNullOrWhiteSpace(claim.TaxonomyCode))
            {
                return null;
            }

            return new PRV_BillingProviderSpecialtyInformation
            {
                ProviderCode_01 = X12_ID_1221.BI.X12(),
                ReferenceIdentificationQualifier_02 = X12_ID_128.PXC.X12(),
                ProviderTaxonomyCode_03 = claim.TaxonomyCode
            };
        }



    }
}

