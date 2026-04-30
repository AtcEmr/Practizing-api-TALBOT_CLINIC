using Microsoft.Extensions.Logging;
using PractiZing.Base.Repositories.ReportService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ReportService.Repositories
{
    public class DateRangeCustomFields : ICustomFormulaField
    {
      
        public async Task<string> GetFormulaValue(DataTable dataTable, string fieldName)
        {
            CultureInfo culture = new CultureInfo("en-US");
            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();
            string date = "";
            int PracticeId = 0;

            if (fieldName == "FromDate")
            {
                date = "";
                if(dataTable.Rows[0]["FromDate"].ToString().Contains("NaN") == false)
                {
                    fromDate = Convert.ToDateTime(dataTable.Rows[0]["FromDate"].ToString().Replace("'", ""), culture);
                    date = fromDate.Date.ToString("MM/dd/yy");
                }
            }
            else if (fieldName == "ToDate")
            {
                date = "";
                if (dataTable.Rows[0]["ToDate"].ToString().Contains("NaN") == false)
                {
                    toDate = Convert.ToDateTime(dataTable.Rows[0]["ToDate"].ToString().Replace("'", ""), culture);
                    date = toDate.Date.ToString("MM/dd/yy");
                }
            }
            else if (dataTable.Columns.Contains("PracticeId"))
            {
                PracticeId = Convert.ToInt32(dataTable.Rows[0]["PracticeId"]);
            }

            return date;
        }
    }

}
