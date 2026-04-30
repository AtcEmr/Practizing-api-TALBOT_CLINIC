using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
  public  interface ILoggedInUser:IPracticeDTO
    {
        int Id { get; set; }
        
    }
}
