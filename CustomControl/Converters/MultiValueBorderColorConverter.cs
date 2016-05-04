using System;
using System.Windows.Data;
using System.Globalization;

namespace CustomControl
{
    /// <summary>
    /// Multivalue converter
    /// Takes input for border color and returns color string
    /// </summary>
    public class MultiValueBorderColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string color = "";

            try
            {
                // Same color for all borders
                Boolean isAll = Boolean.Parse(values[0].ToString());
                if (isAll)
                {
                    color = System.Convert.ToString(values[1]);

                    return color;
                }

                for (int i = 2; i < 10; i+=2)
                {
                    // Individual border colors
                    Boolean isBorder = Boolean.Parse(values[i].ToString());
                    string colorBorder = System.Convert.ToString(values[i+1]);

                    if (isBorder && !String.IsNullOrWhiteSpace(colorBorder))
                    {
                        color += colorBorder;
                    }
                    else
                    {
                        color += "Transparent";
                    }
                    if (i < 8)
                    {
                        color += ",";
                    }
                }

                return color;
            }
            catch
            {
                return "Transparent";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
