using System.Linq;

namespace kamafi.core.data
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Convert a string to snake (lowered) case string
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns></returns>
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }
}
