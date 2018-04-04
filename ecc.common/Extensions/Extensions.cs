using System;
using System.Collections.Generic;
using System.Text;

namespace ecc.common.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// ConvertToEnum
        /// </summary>
        /// <typeparam name="TEnum">Enum Type</typeparam>
        /// <param name="value">string value</param>
        /// <returns>Returns Enum value</returns>
        public static TEnum TryParseEnum<TEnum>(this string value) where TEnum : struct
        {
            TEnum result;
            if (!Enum.TryParse(value, true, out result))
            {
                result = default(TEnum);
            }
            return result;
        }
    }
}
