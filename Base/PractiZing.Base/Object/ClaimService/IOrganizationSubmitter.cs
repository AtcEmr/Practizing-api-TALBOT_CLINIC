using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ClaimService
{
    public interface IOrganizationSubmitter
    {
        string Code { get; set; }

        string Name { get; set; }

        ISubmitterContacts Contacts { get; set; }

    }
}
