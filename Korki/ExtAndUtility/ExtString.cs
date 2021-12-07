using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.ExtAndUtility
{
    public static class ExtString
    {
        private static char[] TrimStartCharsForTextInput { get; } = " ,./;'\\[]=<>?:\"|{}_+!@#$%^&*()".ToCharArray();
        private static char[] TrimEndCharsForTextInput { get; } = " ,/;'\\[]=<>:\"|{}_+@#$%^&*()".ToCharArray();

        /// <summary>
        /// Trims the string as if it was a text input string, removing all whitespaces, commas and other characters
        /// from start and end.
        /// </summary>
        public static string TrimAsTextInput(this string str)
        {
            if (str == null) { return null; }
            str.Trim();
            str.TrimStart(TrimStartCharsForTextInput);
            str.TrimEnd(TrimEndCharsForTextInput);
            return str;
        }

        /// <summary>
        /// Cuts the string to maxLength if it exceeds that length.
        /// </summary>
        public static string LimitLength(this string str, int maxLength)
        {
            maxLength = Math.Max(0, maxLength);
            return str?.Substring(0, Math.Min(str.Length, maxLength));
        }
    }
}
