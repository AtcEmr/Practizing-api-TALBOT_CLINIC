using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ReportService
{
    public interface IReportDataDTO
    {
        List<Dictionary<string, string>> Schema { get; set; }
        List<List<Dictionary<string, object>>> Data { get; set; }
    }
}
