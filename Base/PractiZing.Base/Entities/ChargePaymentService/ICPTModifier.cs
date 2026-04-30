using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface ICPTModifier : IActive, IUniqueIdentifier
    {
        Int16 ID { get; set; }
        byte? VisitType { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        short CircumstanceModifierId { get; set; }
        bool IsServiceCircumstance { get; set; }
    }
}
