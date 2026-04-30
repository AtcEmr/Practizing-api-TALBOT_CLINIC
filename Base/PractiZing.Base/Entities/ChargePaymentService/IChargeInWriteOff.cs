using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IChargeInWriteOff : IStamp
    {
        int Id { get; set; }
        int ChargeId { get; set; }
        int StatusId { get; set; }       
        string ReasonCode { get; set; }
        string Comments { get; set; }
        bool IsPosted { get; set; }
    }
}
