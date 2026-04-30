using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.UnitTest.Common
{
    public class OrderAttribute : Attribute
    {
        public int I { get; }

        public OrderAttribute(int i)
        {
            I = i;
        }
    }
}
