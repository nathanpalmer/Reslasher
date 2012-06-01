using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Reslasher
{
    public static class ReslashExtensions
    {
        public static string Reslash(this string input, char from = '\\', char to = '/')
        {
            return input.Replace(from, to);
        }

        public static string Combine(this string input, params string[] next)
        {
            var firstSlash = input.IndexOfAny(new[] {'/', '\\'});
            var from = firstSlash >= 0
                           ? input[firstSlash] == '\\'
                                 ? '/'
                                 : '\\'
                           : '\\';
            var to = from == '/' ? '\\' : '/';
            var result = input;

            foreach (var s in next)
            {
                var item = s.Reslash(from, to);
                item = item[0] == to ? item.Substring(1) : item;
                result = Path.Combine(result, item);
            }

            return result.Reslash(from, to);
        }
    }
}
