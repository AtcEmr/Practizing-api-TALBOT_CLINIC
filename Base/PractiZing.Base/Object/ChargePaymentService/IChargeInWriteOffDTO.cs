using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChargeInWriteOffDTO
    {
        string ChargeUids { get; set; }
        string ReasonCodeId { get; set; }
        string Comments { get; set; }
    }

    public interface IEmrChargeInWriteOffDTO
    {
        int ChargeId { get; set; }
        int StatusId { get; set; }
    }
}
