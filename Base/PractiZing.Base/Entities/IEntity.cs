using System;

namespace PractiZing.Base.Entities
{
    public interface IEntity
    {
        string KeyID { get; }
    }
    public interface IUniqueIdentifier
    {
        Guid UId { get; set; }
    }

    public interface IPracticeDTO
    {
        int PracticeId { get; set; }
    }

    public interface IActive
    {
        bool IsActive { get; set; }
    }
}
