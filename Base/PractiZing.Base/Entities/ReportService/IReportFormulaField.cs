using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ReportService
{
    public interface IReportFormulaField
    {
        int ID { get; set; }
        int ReportId { get; set; }
        string FieldName { get; set; }
        string Type { get; set; }
        string ValueSource { get; set; }
    }
}
