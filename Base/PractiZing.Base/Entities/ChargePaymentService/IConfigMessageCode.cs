using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IConfigMessageCode
    {
        string MessageCode { get; set; }
        string Description { get; set; }
        string DeleteFlag { get; set; }
        string OnStatements { get; set; }
        string OnClaims { get; set; }
        string Available { get; set; }
        string Category { get; set; }
        string Task { get; set; }
        bool? Visible { get; set; }
    }
}
