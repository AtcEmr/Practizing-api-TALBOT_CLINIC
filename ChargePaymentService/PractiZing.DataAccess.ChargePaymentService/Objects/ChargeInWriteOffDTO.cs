using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargeInWriteOffDTO : IChargeInWriteOffDTO
    {
        public string ChargeUids { get; set; }
        public string ReasonCodeId { get; set; }
        public string Comments { get; set; }
    }

    public class EmrChargeInWriteOffDTO : IEmrChargeInWriteOffDTO
    {
        public int ChargeId { get; set; }
        public int StatusId { get; set; }

    }
}
