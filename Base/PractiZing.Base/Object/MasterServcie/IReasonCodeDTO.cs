using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IReasonCodeDTO
    {
        string GroupCode { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        string ReasonCode { get; set; }
    }
}
