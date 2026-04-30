using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PractiZing.BusinessLogic.Common
{
    public static class ParseParameter
    {
        public static string ParseReport(string templateBody, DataRow dr)
        {
            try
            {
                string finalBody = templateBody;

                while (true)
                {
                    int findIndex = finalBody.IndexOf("{");
                    int nextIndex = -1;
                    string foundToken = "";
                    string tokenValue = "";
                    if (findIndex >= 0)
                    {
                        nextIndex = finalBody.IndexOf("}", findIndex + 1);
                        if (nextIndex >= 0)
                        {
                            foundToken = finalBody.Substring(findIndex + 1, nextIndex - findIndex - 1);
                            for (var i = 0; i < dr.ItemArray.Count(); i++)
                            {
                                if (dr.Table.Columns[i].ColumnName.ToLower() == foundToken.ToLower())
                                {
                                    tokenValue = dr[i].ToString() == string.Empty ? "null" : dr[i].ToString();
                                    finalBody = finalBody.Replace("{" + foundToken + "}", "'" + tokenValue + "'");
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                return finalBody;
            }
            catch
            {
                throw;
            }
        }
    }
}
