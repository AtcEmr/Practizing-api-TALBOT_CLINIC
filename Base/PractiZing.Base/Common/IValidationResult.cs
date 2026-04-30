using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Common
{
    public interface IValidationResult
    {
        string ErrorMessage { get; set; }
        IEnumerable<string> MemberNames { get; }
        int ErrorCode { get; set; }
    }
}
