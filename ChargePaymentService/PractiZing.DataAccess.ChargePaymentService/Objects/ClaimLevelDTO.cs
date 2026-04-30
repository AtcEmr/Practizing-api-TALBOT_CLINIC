using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ClaimLevelDTO : IClaimLevelDTO
    {
        public string PatientAccountNumber { get; set; }
        public short? InsLevel { get; set; }
    }
}
