using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace V3.Extensions
{
    public static class StringExtensions
    {
        public static string Join<T>(this IEnumerable<T> values, string separator)
        {
            return String.Join(separator, values.Select(v => v.ToString()).ToArray());
        }

        public static string Join<T>(this IEnumerable<T> values, string separator, string lastSeparator)
        {
            var valueList = values.ToList();

            if (valueList.Count > 1)
            { 
                var lastValue = valueList[valueList.Count - 1];
                var preValue = valueList.Take(valueList.Count - 1).Join(separator);
                return preValue + lastSeparator + lastValue;
            }

            return values.Join(separator);
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return String.Format(format, args);
        }

        public static string HtmlDecode(this string value)
        {
            return HttpUtility.HtmlDecode(value);
        }

        public static string UrlDecode(this string value)
        {
            return HttpUtility.UrlDecode(value);
        }   
    }
}
