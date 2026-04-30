using PractiZing.Base.Object.ReportService;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ReportService
{
    public class ReportDataDTO : IReportDataDTO
    {
        public ReportDataDTO()
        {
            this.Schema = new List<Dictionary<string, string>>();
            this.Data = new List<List<Dictionary<string, object>>>();
        }
        public List<Dictionary<string, string>> Schema { get; set; }
        public List<List<Dictionary<string, object>>> Data { get; set; }
    }
}
