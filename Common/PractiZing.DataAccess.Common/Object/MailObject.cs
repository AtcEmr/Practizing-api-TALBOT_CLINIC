using PractiZing.Base.Object.MasterServcie;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.DataAccess.Common.Object
{
    public class MailObject : IMailObject
    {
        public MailObject()
        {
            To = new List<MailToObject>();
        }
        public string FromAddress { get; set; }
        public string FromAdressTitle { get; set; }
        public string FromAddressPassword { get; set; }
        public IEnumerable<IMailToObject> To { get; set; }
        public string Subject { get; set; }
        public string BodyContent { get; set; }

        public string SmtpUrl { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
    }
    public class MailToObject : IMailToObject
    {
        public string ToAddress { get; set; }
        public string ToAdressTitle { get; set; }
    }
}
