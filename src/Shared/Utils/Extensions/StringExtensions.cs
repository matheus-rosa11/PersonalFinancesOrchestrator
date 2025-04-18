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
    }
}
