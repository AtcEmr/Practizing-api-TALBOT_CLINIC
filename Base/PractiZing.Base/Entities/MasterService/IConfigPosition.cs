using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
  public  interface IConfigPosition : IActive
    {
        Int16 Id { get; set; }
        string PositionName { get; set; }
    }
}
