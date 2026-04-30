using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.ClaimService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Factory
{
    public interface ISubmitterFactory
    {
        IOrganizationSubmitter Init(IClearingHouse house, IEnumerable<dynamic> configs, dynamic config5010);
    }
}
