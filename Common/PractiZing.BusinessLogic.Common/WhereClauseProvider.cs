using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.Common
{
    public static class WhereClauseProvider<T> where T : class
    {
        public static async Task<string> GetWhereClause(T searchModel)
        {
            if (searchModel == null) return "";

            StringBuilder sbQuery = new StringBuilder();

            PropertyInfo[] props = searchModel.GetType().GetProperties();

            // var filteredProps = props.Where(i => !searchModel.ExcludeFields.Contains(i.Name));
            var filteredProps = props;
            foreach (PropertyInfo prop in filteredProps)
            {
                var attrs = prop.GetCustomAttributes<SearchFieldAttribute>(true);
                object value = prop.GetValue(searchModel);
                object originalValue = prop.GetValue(searchModel);
                string paramValue = "";
                string typeOperator = "";
                if (prop.PropertyType.ToString().Contains("System.DateTime"))
                {
                    value = (Convert.ToDateTime(value) == DateTime.MinValue ? null : value);
                }

                if (prop.PropertyType.ToString().Contains("System.DateTime") || prop.PropertyType.ToString() == "System.String")
                {
                    paramValue = value == null ? "NULL" : "'" + value.ToString().Replace("'", "''") + "'";
                    value = "'" + value + "'";
                }
                else if (prop.PropertyType.ToString().Contains("System.Boolean"))
                {
                    if (value != null)
                    {
                        paramValue = value.ToString();
                    }
                }
                else
                {
                    paramValue = value == null ? "NULL" : value.ToString();
                }
                //if (prop.Name == "FromDate")
                //{
                //    typeOperator = !string.IsNullOrEmpty(paramValue) ? " >= " + paramValue : "";
                //}
                //else if (prop.Name == "ToDate")
                //{
                //    typeOperator = !string.IsNullOrEmpty(paramValue) ? " <= " + paramValue : "";
                //}
                ////else if (prop.Name == "DepositTypeIds")
                ////{
                ////    typeOperator = !string.IsNullOrEmpty(paramValue) ? " In(" + paramValue : ")";
                ////}

                typeOperator = !string.IsNullOrEmpty(paramValue) ? " = " + paramValue : "";


                if (prop.PropertyType.ToString() == "System.String" && prop.Name == "DepositTypeIds")
                {
                    typeOperator = "" + (originalValue == null ? " like  '%NULL%'" : " In (" + originalValue.ToString().Replace("'", "''") + ")");
                }
                else if (prop.PropertyType.ToString() == "System.String" && (prop.Name == "FromDate" || prop.Name == "BatchFromDate"))
                {
                    typeOperator = " >= '" + (originalValue == null ? "NULL" : originalValue.ToString().Replace("'", "''")) + "'";
                }
                else if (prop.PropertyType.ToString() == "System.String" && (prop.Name == "ToDate" || prop.Name == "BatchToDate"))
                {
                    typeOperator = " <= '" + (originalValue == null ? "NULL" : originalValue.ToString().Replace("'", "''")) + "'";
                }
                else if (prop.PropertyType.ToString() == "System.String")
                {
                    typeOperator = " like '%" + (originalValue == null ? "NULL" : originalValue.ToString().Replace("'", "''")) + "%'";
                }
                else if (prop.PropertyType.ToString().Contains("System.Double") || prop.PropertyType.ToString().Contains("System.Int32") || prop.PropertyType.ToString().Contains("System.Int64"))
                {
                    if (value != null)
                    {
                        typeOperator = " like '%" + (value == null ? "NULL" : originalValue.ToString().Replace("'", "''")) + "%'";
                    }
                }

                if (string.IsNullOrEmpty(typeOperator))
                    continue;

                foreach (var attr in attrs)
                {
                    SearchFieldAttribute searchAttr = attr as SearchFieldAttribute;
                    string fieldName = searchAttr.Name;
                    if (prop.PropertyType.ToString().Contains("System.Double") || prop.PropertyType.ToString().Contains("System.Int32") || prop.PropertyType.ToString().Contains("System.Int64"))
                    {
                        fieldName = $"Cast({fieldName} as nchar)";
                    }

                    if (sbQuery.ToString() == string.Empty && prop.Name == "DepositTypeIds")
                    {
                        sbQuery.AppendFormat("(" + fieldName + typeOperator + " or " + paramValue + " IS NULL" + ")");
                    }
                    else if (sbQuery.ToString() != string.Empty && prop.Name == "DepositTypeIds")
                    {
                        sbQuery.AppendFormat(" AND (" + "(" + fieldName + typeOperator + " or (" + paramValue + ") IS NULL)" + ")");
                    }
                    else if (sbQuery.ToString() != string.Empty && (prop.Name == "FromDate" || prop.Name == "BatchFromDate"))
                    {
                        sbQuery.AppendFormat(" AND (" + "(" + fieldName + typeOperator + " or (" + paramValue + ") IS NULL)" + ")");
                    }
                    else if (sbQuery.ToString() != string.Empty && (prop.Name == "ToDate" || prop.Name == "BatchToDate"))
                    {
                        sbQuery.AppendFormat(" AND (" + fieldName + typeOperator + " or (" + paramValue + ") IS NULL)");
                    }
                    else if (sbQuery.ToString() != string.Empty && prop.Name == "IsCommitted")
                    {
                        if (paramValue == "'2'")
                            sbQuery.AppendFormat(" AND (" + fieldName + " like '%NULL%'" + " or (" + "NULL" + ") IS NULL)");
                        else
                            sbQuery.AppendFormat(" AND (" + fieldName + typeOperator + " or (" + paramValue + ") IS NULL)");
                    }
                    else if (sbQuery.ToString() != string.Empty && prop.Name == "IsImportInBilling")
                    {
                        if (paramValue == "'2'")
                            sbQuery.AppendFormat(" AND (" + fieldName + " like '%NULL%'" + " or (" + "NULL" + ") IS NULL)");
                        else
                            sbQuery.AppendFormat(" AND (" + fieldName + typeOperator + " or (" + paramValue + ") IS NULL)");
                    }
                    else if (sbQuery.ToString() == string.Empty)
                    {
                        sbQuery.AppendFormat("(" + fieldName + typeOperator + " or " + paramValue + " IS NULL" + ")");
                    }
                    else
                    {
                        sbQuery.AppendFormat(" AND (" + fieldName + typeOperator + " or " + paramValue + " IS NULL)");
                    }
                }
            }

            return sbQuery.ToString();
        }
    }
}
