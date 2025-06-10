using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal static class Extensions
    {
        public static string GetFirstOrEmptyIfNullOrEmpty(this IEnumerable<string> data)
        {
            if (data == null || data.Count() == 0) return string.Empty;

            return data.First();
        }

        public static int CountWord(this string data)
        {
            if (string.IsNullOrEmpty(data)) return 0;
            var tmp = data.Split(' ');
            return tmp.Count();
        }

        public static T ToEnum<T>(this string value, bool ignoreCase = true) where T : struct, Enum
        {
            if (Enum.TryParse<T>(value, ignoreCase, out var result))
                return result;
            throw new Exception();
        }
    }
}
