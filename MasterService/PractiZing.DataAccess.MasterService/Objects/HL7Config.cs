using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class HL7Config : IHL7Config
    {
        public string URL { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string InputFolder { get; set; }

        public string ProcessedFolder { get; set; }

        public string ErrorFolder { get; set; }

        public int PracticeId { get; set; }
    }
}
