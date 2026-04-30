using PractiZing.Base.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class DatePeriod : Range<DateTime>
    {
        public DatePeriod(DateTime from, DateTime? to) : base(from, to)
        {
        }
    }


}
