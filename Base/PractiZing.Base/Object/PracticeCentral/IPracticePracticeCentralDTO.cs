using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PracticeCentral
{
    public interface IPracticePracticeCentralDTO
    {
        string PracticeCode { get; set; }

        string PracticeName { get; set; }

        string DBName { get; set; }

        string StripeKey { get; set; }

        string CustomerKey { get; set; }

        string LabDBName { get; set; }
    }
}
