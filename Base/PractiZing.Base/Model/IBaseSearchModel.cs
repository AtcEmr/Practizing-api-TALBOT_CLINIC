using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model
{
    public interface IBaseSearchModel
    {
        List<string> ExcludeFields { get; set; }
    }
}
