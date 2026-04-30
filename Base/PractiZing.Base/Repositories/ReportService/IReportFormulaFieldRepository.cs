using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ReportService
{
    public interface IReportFormulaFieldRepository
    {
        Task<string> GetFieldData(int reportId, object parameterObject);
    }
}
