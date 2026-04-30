using System;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IUserRole : IUniqueIdentifier, IStamp
    {
        int Id { get; set; }
        Int16 UserId { get; set; }
        int RoleId { get; set; }
        bool IsAssigned { get; set; }
        string RoleName { get; set; }
    }
}
