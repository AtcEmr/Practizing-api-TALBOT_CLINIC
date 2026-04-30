using PractiZing.Base.Entities.ReportService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ReportService.Tables
{
    [Alias("PZ_Report")]
    public class Report : IReport
    {
        [Key]
        [AutoIncrement]
        public int ID { get; set; }
        public string ReportName { get; set; }
        public string Command { get; set; }
        public int Menu { get; set; }
        public string Parameters { get; set; }
        public string DataSetName { get; set; }
        public string ReportParameter { get; set; }
        public string ComponentName { get; set; }
        public int ReportTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
