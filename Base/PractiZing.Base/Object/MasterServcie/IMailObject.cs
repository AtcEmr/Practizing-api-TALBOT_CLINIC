using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IMailObject
    {
        string FromAddress { get; set; }
        string FromAdressTitle { get; set; }
        string FromAddressPassword { get; set; }
        //To Address  
        IEnumerable<IMailToObject> To { get; set; }
        string Subject { get; set; }
        string BodyContent { get; set; }

        string SmtpUrl { get; set; }
        string SmtpPort { get; set; }
        string SmtpUserName { get; set; }
        string SmtpPassword { get; set; }
    }
    public interface IMailToObject
    {
        string ToAddress { get; set; }
        string ToAdressTitle { get; set; }
    }
}
