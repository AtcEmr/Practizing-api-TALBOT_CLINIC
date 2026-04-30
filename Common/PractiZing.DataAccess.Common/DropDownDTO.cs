using PractiZing.Base.Object.CommonEntites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class DropDownDTO : IDropDownDTO
    {
        public string label { get; set; }
        public Guid value { get; set; }
    }
}
