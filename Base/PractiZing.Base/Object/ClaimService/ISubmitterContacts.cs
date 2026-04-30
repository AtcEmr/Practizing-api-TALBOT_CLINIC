using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ClaimService
{
    public interface ISubmitterContacts
    {
        string Phone { get; set; }
        string Fax { get; set; }
        string Email { get; set; }
        string Extension { get; set; }
    }
}
