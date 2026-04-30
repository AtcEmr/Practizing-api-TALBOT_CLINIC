using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.DenialService
{
    public interface IDenialManagementDTO
    {
        int PatientCount { get; set; }
        decimal BalanceAmount { get; set; }
        string Tag { get; set; }
        string FromDays { get; set; }
        string ToDays { get; set; }
        string Category { get; set; }
        bool IsSelected { get; set; }
    }
}
