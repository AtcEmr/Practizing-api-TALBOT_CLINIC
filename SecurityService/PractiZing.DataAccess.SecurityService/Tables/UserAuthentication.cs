using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.SecurityService.Tables
{
    [Alias("PZ_UserAuthentication")]
    public class UserAuthentication : IUserAuthentication
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get ; set ; }
        public int UserId { get ; set ; }
        public string Token { get ; set ; }
        public string SmallToken { get ; set ; }
        public DateTime ExpiryDateTime { get ; set ; }
        public DateTime CreatedDateTime { get ; set ; }
        public string FingerPrint { get ; set ; }
    }
}
