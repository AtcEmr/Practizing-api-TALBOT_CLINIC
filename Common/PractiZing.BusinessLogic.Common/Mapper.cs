using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PractiZing.BusinessLogic.Common
{
    // By using a generic class we can take advantage
    // of the fact that .NET will create a new generic type
    // for each type T. This allows us to avoid creating
    // a dictionary of Dictionary<string, PropertyInfo>
    // for each type T. We also avoid the need for the 
    // lock statement with every call to Map.
    public static class Mapper<T>
        // We can only use reference types
        where T : class, new()
    {
        private static readonly Dictionary<string, PropertyInfo> _propertyMap;

        static Mapper()
        {
            // At this point we can convert each
            // property name to lower case so we avoid 
            // creating a new string more than once.
            _propertyMap =
                typeof(T)
                .GetProperties()
                .ToDictionary(
                    p => p.Name.ToLower(),
                    p => p
                );
        }

        public static IEnumerable<T> MapList(List<dynamic> sources)
        {
            List<T> cObj = new List<T>();
            sources = sources.ToList<object>();
            foreach (var source in sources)
            {
                T obj = new T();
                Map(source, obj);
                cObj.Add(obj);
            }
            return cObj;
        }

        public static T Map(List<dynamic> sources)
        {
            T obj = new T();
            var source = sources.FirstOrDefault();
            if (source == null)
                return null;

            Map(source, obj);
            return obj;
        }

        public static void Map(ExpandoObject source, T destination)
        {
            // Might as well take care of null references early.
            if (source == null)
                throw new ArgumentNullException("source");
            if (destination == null)
                throw new ArgumentNullException("destination");

            // By iterating the KeyValuePair<string, object> of
            // source we can avoid manually searching the keys of
            // source as we see in your original code.
            foreach (var kv in source)
            {
                PropertyInfo p;
                if (_propertyMap.TryGetValue(kv.Key.ToLower(), out p))
                {
                    var propType = p.PropertyType;
                    if (kv.Value == null)
                    {
                        if (!propType.IsByRef && propType.Name != "Nullable`1")
                        {
                            // Throw if type is a value type 
                            // but not Nullable<>
                            throw new ArgumentException("not nullable");
                        }
                    }
                    else if (kv.Value.GetType() != propType)
                    {
                        if (kv.Value.GetType().Name != "DBNull" && propType.Name != "Nullable`1")
                        {
                            // You could make this a bit less strict 
                            // but I don't recommend it.
                            throw new ArgumentException("type mismatch");
                        }
                    }
                    if (kv.Value.GetType().Name == "DBNull")
                        p.SetValue(destination, null, null);
                    else
                        p.SetValue(destination, kv.Value, null);
                }
            }
        }

        public static string CreateSelectParameter(object parameter)
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
}
