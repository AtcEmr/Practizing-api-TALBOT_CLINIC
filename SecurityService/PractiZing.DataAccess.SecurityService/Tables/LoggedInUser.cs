using PractiZing.Base.Entities.SecurityService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.SecurityService.Tables
{
   public class LoggedInUser : ILoggedInUser
    {
        public int Id { get; set; }
        public int PracticeId { get; set; }
        string LogoName { get; set; }
        
    }
}
