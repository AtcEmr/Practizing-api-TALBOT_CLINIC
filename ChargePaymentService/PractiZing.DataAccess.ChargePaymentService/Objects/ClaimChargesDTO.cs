using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ClaimChargesDTO : IClaimChargesDTO
    {
        public int AllCount { get; set; }
        public int ClaimNotMadeCount { get; set; }
        public int ClaimNotSentCount { get; set; }
        public int ClaimSentCount { get; set; }
        public IEnumerable<ICharges> ChargesAll { get; set; }
        public IEnumerable<ICharges> ChargesClaimNotMade { get; set; }
        public IEnumerable<ICharges> ChargesClaimNotSent { get; set; }
        public IEnumerable<ICharges> ChargesClaimSent { get; set; }
    }
}
