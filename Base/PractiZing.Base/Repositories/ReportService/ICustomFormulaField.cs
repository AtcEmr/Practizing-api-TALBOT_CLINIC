using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ReportService
{
    public interface ICustomFormulaField
    {
        Task<string> GetFormulaValue(DataTable parameterData, string fieldName);
    }
}
