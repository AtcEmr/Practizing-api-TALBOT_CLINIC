using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.DenialService
{
    public interface IARGroup : IUniqueIdentifier, IPracticeDTO, IStamp
    {
        int Id { get; set; }
        string GroupName { get; set; }
    }
}
