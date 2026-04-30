using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class ChargeError : IChargeError
    {
        public ChargeError(int claimId, int chargeId, string errorMessage)
        {
            this.ClaimId = claimId;
            this.ChargeId = chargeId;
            this.ErrorMessage = errorMessage;
        }

        public int ClaimId { get; set; }
        public int ChargeId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
