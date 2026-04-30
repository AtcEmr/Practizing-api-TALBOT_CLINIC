using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IHL7RuleScripts : IUniqueIdentifier, IPracticeDTO
    {
        int Id { get;}        
        string SqlStatement { get;}
        bool IsActive { get;}
    }
}
