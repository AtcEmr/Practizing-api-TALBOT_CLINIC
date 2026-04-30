using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
  public  interface IMasterICD10Filter
    {
        string Code { get; set; }
        string Description { get; set; }
    }
}
