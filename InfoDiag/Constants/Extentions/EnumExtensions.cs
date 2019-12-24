using System;
using System.Collections.Generic;
using System.Text;

namespace Constants.Extentions
{
    public static class EnumExtensions
    {
        public static (object key, string value)[] ToTupple(Type enumType)
        {
            var arr = Enum.GetValues(enumType);
            var len = arr.Length;
            var dic = new (object key, string value)[len];
            for (var i = 0; i < len; i++)
            {
                var val = arr.GetValue(i);
                dic[i] = (val, Enum.GetName(enumType, val));
            }

            return dic;
        }
    }
}
