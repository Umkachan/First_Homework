using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTools.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            var result = string.Empty;

            try
            {
                var fieldResult = value.GetType().GetField(value.ToString());
                var attributes = (DescriptionAttribute[])fieldResult.GetCustomAttributes(typeof(DescriptionAttribute), false);

                result = attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
            catch (Exception) { }

            return result;
        }
    }
}
