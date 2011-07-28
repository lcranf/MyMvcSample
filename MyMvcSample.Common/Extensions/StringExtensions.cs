using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyMvcSample.Common.Extensions
{
    public static class StringExtensions
    {
        public static string DisplayName(this string name)
        {
            return string.IsNullOrEmpty(name) ? string.Empty : Regex.Replace(name, "(\\B[A-Z])", " $1");
        }
    }
}
