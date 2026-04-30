using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IMonthEndClose : IPracticeDTO, IUniqueIdentifier
    {
        int MonthId { get; set; }
        int YearId { get; set; }
        string CreatedBy { get; set; }
    }
}
