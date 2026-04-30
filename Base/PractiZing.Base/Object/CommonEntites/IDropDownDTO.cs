using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.CommonEntites
{
    public interface IDropDownDTO
    {
        string label { get; set; }
        Guid value { get; set; }
    }
}
