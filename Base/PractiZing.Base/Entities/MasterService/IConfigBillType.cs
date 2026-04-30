using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigBillType : IActive
    {
        int Id { get; set; }
        string Value { get; set; }
    }
}
