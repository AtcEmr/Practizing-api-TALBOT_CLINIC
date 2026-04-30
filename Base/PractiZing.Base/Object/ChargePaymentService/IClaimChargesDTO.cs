using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IClaimChargesDTO
    {
        int AllCount { get; set; }
        int ClaimNotMadeCount { get; set; }
        int ClaimNotSentCount { get; set; }
        int ClaimSentCount { get; set; }
        IEnumerable<ICharges> ChargesAll { get; set; }
        IEnumerable<ICharges> ChargesClaimNotMade { get; set; }
        IEnumerable<ICharges> ChargesClaimNotSent { get; set; }
        IEnumerable<ICharges> ChargesClaimSent { get; set; }
    }
}
