using System.Text.RegularExpressions;

namespace Shared.Utils.Helpers
{
    public static partial class RegexHelper
    {
        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public static partial Regex ValidEmailRegex();
    }
}
