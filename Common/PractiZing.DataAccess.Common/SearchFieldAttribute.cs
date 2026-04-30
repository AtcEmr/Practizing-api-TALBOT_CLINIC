using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class SearchFieldAttribute : Attribute
    {
        public SearchFieldAttribute(string name)
        {
            this.Name = name;
        }

        public SearchFieldAttribute()
        {

        }

        public string Name { get; set; }

        public object DefaultValue { get; set; }

        public List<object> SearchIn { get; set; }
    }
}
