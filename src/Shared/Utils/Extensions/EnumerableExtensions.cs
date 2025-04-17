using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool SafeAny<T>(this IEnumerable<T>? source) => source != null && source.Any();
    }
}
