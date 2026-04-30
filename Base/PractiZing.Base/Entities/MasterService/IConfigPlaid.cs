using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigPlaid 
    {
        int Id { get; set; }
        string ClientId { get; set; }
        string SecretKey { get; set; }
        string AccessToken { get; set; }
        int PracticeId { get; set; }
        string PlaidURL { get; set; }
    }
}
