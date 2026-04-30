using PractiZing.Base.Entities.ReportService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ReportService.Tables
{
    public class ReportFormulaField : IReportFormulaField
    {
        public int ID { get; set; }
        public int ReportId { get; set; }
        public string FieldName { get; set; }
        public string Type { get; set; }
        public string ValueSource { get; set; }
    }
}
