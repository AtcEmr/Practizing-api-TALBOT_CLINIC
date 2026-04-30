using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ReportService
{
    public interface IReport
    {
        int ID { get; set; }
        string ReportName { get; set; }
        string Command { get; set; }
        int Menu { get; set; }
        string Parameters { get; set; }
        string DataSetName { get; set; }
        string ReportParameter { get; set; }
        string ComponentName { get; set; }
        int ReportTypeId { get; set; }
        bool IsActive { get; set; }
    }
}
