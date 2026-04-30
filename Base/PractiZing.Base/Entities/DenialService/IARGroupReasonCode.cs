using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.DenialService
{
    public interface IARGroupReasonCode
    {
        int Id { get; set; }
        int ARGroupId { get; set; }
        string ReasonCode { get; set; }
    }
}
