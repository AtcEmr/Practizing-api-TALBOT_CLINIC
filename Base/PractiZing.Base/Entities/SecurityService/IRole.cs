using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IRole
    {
        int Id { get; set; }
        string RoleName { get; set; }
    }
}
