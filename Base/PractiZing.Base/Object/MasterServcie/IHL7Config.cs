using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IHL7Config
    {
         string URL { get; set; }

         string UserName { get; set; }

         string Password { get; set; }

         string InputFolder { get; set; }

         string ProcessedFolder { get; set; }

         string ErrorFolder { get; set; }

         int PracticeId { get; set; }
    }
}
