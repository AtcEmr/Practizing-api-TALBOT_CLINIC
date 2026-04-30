using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.DenialService
{
    public interface IClaimDetailForDenialDTO
    {
        int ClaimCount { get; set; }
        decimal ClaimAmount { get; set; }
    }
}
