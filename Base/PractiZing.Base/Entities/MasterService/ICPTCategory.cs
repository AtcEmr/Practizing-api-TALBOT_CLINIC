using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface ICPTCategory : IUniqueIdentifier, IPracticeDTO, IStamp
    {
        Int16 Id { get; set; }
        string CategoryName { get; set; }
        string RevenueCode { get; set; }
        string Description { get; set; }
        bool? IsActive { get; set; }
    }
}
