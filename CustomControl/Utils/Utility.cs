using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CustomControl.Utils
{
    static class Utility
    {
        /// <summary>
        /// Validates if value is a valid color
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if values is a valid color</returns>
        public static bool isValidColor(object value)
        {
            if (value == null)
            {
                return false;
            }
            var stringValue = value.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return false;
            }

            try
            {
                ColorConverter.ConvertFromString(stringValue.Trim());
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
