using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IAttFileTable
    {
        int Id { get; set; }
        string TableName { get; set; }
        string Description { get; set; }
    }
}
