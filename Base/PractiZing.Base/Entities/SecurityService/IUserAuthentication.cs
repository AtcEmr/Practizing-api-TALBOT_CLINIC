using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IUserAuthentication
    {
        int Id { get; set; }
        int UserId { get; set; }
        string Token { get; set; }
        string SmallToken { get; set; }
        DateTime ExpiryDateTime { get; set; }
        DateTime CreatedDateTime { get; set; }
        string FingerPrint { get; set; }
    }
}
