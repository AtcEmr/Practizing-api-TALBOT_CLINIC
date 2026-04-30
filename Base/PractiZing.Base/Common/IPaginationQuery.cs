using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Common
{
    public interface IPaginationQuery<T>
    {
        IEnumerable<T> Data { get; set; }

        long TotalRecords { get; set; }
    }
}
