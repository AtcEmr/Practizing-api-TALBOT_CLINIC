using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigERARemarkCodes
    {
        int Id { get; set; }
        string RemarkQualifier { get; set; }
        string RemarkCode { get; set; }
        string RemarkMessage { get; set; }
        bool IsActive { get; set; }

        string FullCode { get; set; }
    }
}
