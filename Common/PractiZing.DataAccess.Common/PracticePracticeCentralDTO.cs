using PractiZing.Base.Object.PracticeCentral;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class PracticePracticeCentralDTO : IPracticePracticeCentralDTO
    {
        public string PracticeCode { get; set; }

        public string PracticeName { get; set; }

        public string DBName { get; set; }

        public string StripeKey { get; set; }

        public string CustomerKey { get; set; }

        public string LabDBName { get; set; }
    }
}
