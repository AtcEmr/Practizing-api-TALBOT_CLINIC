using PractiZing.Base.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public static class SearchQuery
    {
        public static SearchQuery<TTo> Map<TFrom, TTo>(this SearchQuery<TFrom> instance)
            where TTo : class
            where TFrom : class
        {
            TranslateOrderByClause<TFrom>(instance);
            SearchQuery<TTo> toInstance = new SearchQuery<TTo>();
            toInstance.EndPageNo = instance.EndPageNo;
            toInstance.Filter = instance.Filter as TTo;
            toInstance.PageSize = instance.PageSize;
            toInstance.RunCount = instance.RunCount;
            toInstance.SortExpression = instance.SortExpression;
            toInstance.StartPageNo = instance.StartPageNo;
            return toInstance;
        }

        private static void TranslateOrderByClause<TFrom>(SearchQuery<TFrom> query) where TFrom : class
        {
            // if (query.SortExpression == null) return;
            var typeInfo = typeof(TFrom).GetTypeInfo();
            var properties = typeInfo.GetProperties();
            if (string.IsNullOrEmpty(query.SortExpression) && properties.Length > 0)
            {
                var searchField = properties[0].GetCustomAttribute<SearchFieldAttribute>();
                if (searchField != null)
                {
                    query.SortExpression = searchField.Name;
                }
            }
            else
            {
                foreach (var property in properties)
                {
                    if ((query.SortExpression.Split(' ')[0]).Trim() == property.Name)
                    {
                        var searchField = property.GetCustomAttribute<SearchFieldAttribute>();
                        if (searchField != null)
                        {
                            query.SortExpression = query.SortExpression.Replace(property.Name, searchField.Name);
                        }
                        break;
                    }
                }
            }
        }
    }
}
