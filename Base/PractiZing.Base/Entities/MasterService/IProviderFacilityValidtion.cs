using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IProviderFacilityValidtion
    {
        int Id { get; set; }
        short ProviderId { get; set; }
        short FacilityId { get; set; }
    }
}
