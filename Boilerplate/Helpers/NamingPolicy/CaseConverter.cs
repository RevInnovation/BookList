using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Boilerplate.Helpers.NamingPolicy
{
    public static class CaseConverter
    {
        public static string ToSnakeCase(string s)
        {
            return Regex.Replace(s, "[A-Z]", "_$0").ToLower();
        }

        public static string ToTitleCase(string s)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(s.ToLower()).Replace("_", string.Empty);
        }
    }
}
