using PractiZing.Base.Model.DenialService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Model
{
    public class ClaimDetailForDenialDTO : IClaimDetailForDenialDTO
    {
        public int ClaimCount { get; set; }
        public decimal ClaimAmount { get; set; }
    }
}
