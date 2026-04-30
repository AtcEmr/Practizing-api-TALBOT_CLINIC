using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface ICategoryDDO
    {
        Int16 Id { get; set; }
        string CategoryName { get; set; }
        Guid UId { get; set; }
    }
}
