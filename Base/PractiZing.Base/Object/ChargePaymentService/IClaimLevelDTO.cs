using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IClaimLevelDTO
    {
        string PatientAccountNumber { get; set; }
        short? InsLevel { get; set; }
    }
}
