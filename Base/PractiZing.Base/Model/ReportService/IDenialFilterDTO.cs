using PractiZing.Base.Object.DenialService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ReportService
{
    public interface IReportARChargesMonthWiseDTO
    {
        int YearId { get; set; }
        int MonthId { get; set; }        
    }
}
