using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
   
    public class InitializeBuilders
    {
        
        public static void Intialize()
        {
            List<IBuilder> builders = new List<IBuilder>();

            builders.Add(new Other2SubscriberBuilder());
            builders.Add(new OtherSubscriberBuilder());
            builders.Add(new PayerBuilder());
            builders.Add(new SubscriberBuilder());
            builders.Add(new BillingProviderBuilder());
            builders.Add(new OrderingProviderBuilder());
            builders.Add(new ReferringProviderBuilder());
            builders.Add( new RenderingProviderBuilder());
            builders.Add(new ServiceChargeRenderingProvider());            
            builders.Add(new P_837Builder());
            builders.Add(new P_276Builder());
            builders.Add(new PayToProviderBuilder());
            builders.Add(new ClaimBuilder());
            builders.Add(new FacilityBuilder());
            builders.Add(new PatientBuilder());
            builders.Add(new ServiceChargeBuilder());
            builders.Add(new SubmitterAndReceiverBuilder());
            builders.Add(new SubscriberHierarchicalBuilder());
            builders.Add(new SupervisingProviderBuilder());
            builders.Add(new ServiceChargeSupervisingProvider());

            SegmentBuilders.Add(builders);
        }

              


    }


}
