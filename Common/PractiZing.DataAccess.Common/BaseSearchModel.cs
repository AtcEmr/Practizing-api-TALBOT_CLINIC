using PractiZing.Base.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class BaseSearchModel : IBaseSearchModel
    {
        public BaseSearchModel()
        {
            this.ExcludeFields = new List<string>();
        }

        [IgnoreDataMember]
        public List<string> ExcludeFields { get; set; }
    }
}
