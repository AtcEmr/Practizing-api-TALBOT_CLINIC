using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;
using PractiZing.Base.Common;

namespace ServiceStack.OrmLite.Dapper
{
    public static class SqlMapper
    {
        public static async Task<PaginationQuery<T>> QueryPagination<T>(this IDbConnection cnn,
            SqlExpression<T> expressionVisitor,
            string selectExpression = "",
            string whereExpression = "",
            string countExpression = "",
            string groupByExpression = "",
            string havingExpression = "",
            string orderByExpression = "",
            int? startPageNo = null,
            int? endPageNo = null,
            int? pageSize = null,
            object parameters = null,
            string sortOrder = "",
            bool runCount = false)
        {

            if (expressionVisitor == null)
                expressionVisitor = cnn.GetDialectProvider().SqlExpression<T>();

            if (string.IsNullOrEmpty(selectExpression))
                selectExpression = $"{expressionVisitor.SelectExpression} {expressionVisitor.FromExpression}";

            if (string.IsNullOrEmpty(whereExpression))
                whereExpression = expressionVisitor.WhereExpression;

            if (string.IsNullOrEmpty(havingExpression))
                havingExpression = expressionVisitor.HavingExpression;

            if (string.IsNullOrEmpty(groupByExpression))
                groupByExpression = expressionVisitor.GroupByExpression;

            if (!string.IsNullOrEmpty(orderByExpression))
            {
                if (string.IsNullOrEmpty(expressionVisitor.OrderByExpression))
                {
                    if (!orderByExpression.Contains("ORDER BY"))
                    {
                        if (orderByExpression.Contains("fullName") || orderByExpression.Contains("lastName"))
                            orderByExpression = !string.IsNullOrEmpty(expressionVisitor.OrderByExpression) ? $"ORDER BY {expressionVisitor.OrderByExpression}" : $"ORDER BY LastName {sortOrder}, FirstName {sortOrder} ";
                        else
                            orderByExpression = $"ORDER BY {orderByExpression} {sortOrder} ";
                    }
                    else
                        orderByExpression = $" {orderByExpression} {sortOrder} ";
                }
                else
                    orderByExpression = $"ORDER BY {expressionVisitor.OrderByExpression}";
                // !string.IsNullOrEmpty(expressionVisitor.OrderByExpression) ?
            }

            //orderByExpression = $"ORDER BY 1";

            countExpression = string.IsNullOrEmpty(countExpression) ? expressionVisitor.ToCountStatement() : countExpression;

            countExpression = $"{countExpression} {whereExpression}";

            var startPageValue = startPageNo.GetValueOrDefault(1);
            if (endPageNo == null || endPageNo == 0)
            {
                endPageNo = startPageNo.GetValueOrDefault(1);
            }
            var endPageValue = endPageNo.GetValueOrDefault(1);
            var pageSizevalue = pageSize.GetValueOrDefault();

            string limit = string.Empty;
            if (pageSizevalue > 0)
                limit = $"OFFSET {(startPageValue - 1) * pageSizevalue} ROWS FETCH NEXT {pageSizevalue} ROWS ONLY";
            var sqlExpression = $"{selectExpression} {whereExpression}  {orderByExpression} {limit} ";

            try
            {
                var data = await cnn.QueryAsync<T>(sqlExpression, parameters);
                long countValue = 0;

                if (startPageValue == 1 || runCount)
                    countValue = await cnn.QueryFirstAsync<long>(countExpression, parameters);

                return new PaginationQuery<T>(data, countValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<PaginationQuery<T>> QueryPagination<T, TSearchModel>(this IDbConnection cnn,
           Expression<Func<T, bool>> selectPredicate,
           SearchQuery<TSearchModel> query,
           string selectExpression = "",
           string whereExpression = "",
           string countExpression = "",
           string sortOrder = "",
           object parameters = null) where TSearchModel : class
        {
            var expressionvisitor = cnn.GetDialectProvider().SqlExpression<T>();
            string whereSql = "";
            if (selectPredicate != null)
            {
                whereSql = expressionvisitor.Where(selectPredicate).WhereExpression;
            }

            if (string.IsNullOrEmpty(whereSql) && !string.IsNullOrEmpty(whereExpression) && !whereExpression.Contains("WHERE"))
            {
                whereExpression = $" WHERE {whereExpression}";
            }
            else if (string.IsNullOrEmpty(whereExpression))
            {
                whereExpression = whereSql;
            }
            else if (!string.IsNullOrEmpty(whereSql) && !string.IsNullOrEmpty(whereExpression))
            {
                whereExpression = $"{whereSql} AND {whereExpression}";
            }

            //if (parameters == null)
            //{
            //    parameters = expressionvisitor.Params;
            //}

            var result = await QueryPagination<T>(cnn,
              expressionvisitor,
              selectExpression,
              whereExpression,
              countExpression,
              "",
              "",
              query.SortExpression,
              query.StartPageNo,
              query.EndPageNo,
              query.PageSize,
              parameters,
              sortOrder,
              query.RunCount);
            return result;
        }

        public static async Task<PaginationQuery<T>> QueryPagination<T, TSearchModel>(this IDbConnection cnn,
           SearchQuery<TSearchModel> query,
           string whereExpression = "") where TSearchModel : class
        {
            return await QueryPagination<T, TSearchModel>(cnn,
                null,
                query,
                "",
                whereExpression);
        }

        public static async Task<PaginationQuery<T>> QueryPagination<T, TSearchModel>(this IDbConnection cnn,
           SearchQuery<TSearchModel> query,
           string selectExpression = "",
           string whereExpression = "",
           string countExpression = "",
           string sortOrder = "",
           object parameters = null) where TSearchModel : class
        {
            return await QueryPagination<T, TSearchModel>(cnn,
              null,
              query,
              selectExpression,
              whereExpression,
              countExpression,
              sortOrder,
              parameters);
        }

        public static async Task<IEnumerable<TKey>> QueryAsync<TKey>(this IDbConnection cnn, string v, SqlExpression<TKey> query, params object[] parameters)
        {
            return await QueryAsync<TKey, TKey>(cnn, query, parameters);
        }

        public static async Task<IEnumerable<TReturn>> QueryAsync<TFrom, TReturn>(this IDbConnection cnn, SqlExpression<TFrom> query, params object[] parameters)
        {
            string selectStatement = CreateSelectStatement<TFrom>(query, parameters);

            return await cnn.QueryAsync<TReturn>(selectStatement);

        }

        public static async Task<TKey> QueryFirstOrDefaultAsync<TKey>(this IDbConnection cnn, SqlExpression<TKey> query, params object[] parameters)
        {
            return await QueryFirstOrDefaultAsync<TKey, TKey>(cnn, query, parameters);
        }

        public static async Task<TReturn> QueryFirstOrDefaultAsync<TFrom, TReturn>(this IDbConnection cnn, SqlExpression<TFrom> query, params object[] parameters)
        {
            string selectStatement = CreateSelectStatement<TFrom>(query, parameters);
            return await cnn.QueryFirstOrDefaultAsync<TReturn>(selectStatement);

        }

        private static string CreateSelectStatement<TFrom>(SqlExpression<TFrom> query, params object[] parameters)
        {
            string selectStatement = query.ToSelectStatement();
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    var parameter = CreateSelectParameter(parameters[i]);
                    selectStatement = selectStatement.Replace($"@{i}", parameter);
                }
            }
            return selectStatement;
        }

        private static string CreateSelectParameter(object parameter)
        {
            if (parameter == null)
            {
                return "NULL";
            }
            else if (parameter is string)
            {
                string value = parameter.ToString();
                return string.IsNullOrEmpty(value) ? "NULL" : $"'{value.ToString()}'";
            }
            else if (parameter is DateTime)
            {
                DateTime? value = Convert.ToDateTime(parameter);
                object dvalue = value == DateTime.MinValue ? null : value;
                return dvalue == null ? "NULL" : $"'{Convert.ToDateTime(dvalue).ToString("yyyy/MM/dd")}'";
            }
            else if (parameter is bool || parameter is long || parameter is int || parameter is decimal || parameter is double || parameter is float)
            {
                return parameter.ToString();
            }
            else
            {
                return "NULL";
            }
        }
    }

    public class PaginationQuery<T> : IPaginationQuery<T>
    {
        public PaginationQuery(IEnumerable<T> data, long totalRecords)
        {
            this.Data = data;
            this.TotalRecords = totalRecords;
        }
        public IEnumerable<T> Data { get; set; }
        public long TotalRecords { get; set; }
    }
}
