using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    internal static class StringExtensionMethods
    {
        public static string Minus(this string s1, string s2)
        {
            if (s1.Length >= s2.Length)
            {
                int start = s1.IndexOf(s2);
                if (start > -1)
                {
                    string firstPart = s1.Substring(0, start);
                    string secondPart = s1.Substring(start + s2.Length);
                    return firstPart + secondPart;
                }
            }

            return s1;
        }
    }
}
