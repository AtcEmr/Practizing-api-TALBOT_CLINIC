using PractiZing.Base.Model.ReportService;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ReportService.DTO
{
    public partial class ReportARChargesMonthWiseDTO : IReportARChargesMonthWiseDTO
    {
        public int YearId { get; set; }
        public int MonthId { get; set; }
    }

}
