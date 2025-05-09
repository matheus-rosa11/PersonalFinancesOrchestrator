using Shared.Utils.Helpers;
using System.Text.RegularExpressions;

namespace Shared.Utils.Extensions
{
    public static partial class StringExtensions
    {
        public static bool IsValidEmail(this string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var regex = RegexHelper.ValidEmailRegex();
            return regex.IsMatch(email);
        }

        public static bool IsNullOrEmpty(this string? str) => string.IsNullOrEmpty(str);
        public static bool IsNullOrWhiteSpace(this string? str) => string.IsNullOrWhiteSpace(str);

        public static string Capitalize(this string? str)
        {
            if (str.IsNullOrWhiteSpace())
                return string.Empty;

            str = str!.ToLower();

            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
