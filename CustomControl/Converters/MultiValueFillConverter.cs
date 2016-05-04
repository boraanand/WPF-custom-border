using System;
using System.Windows.Data;
using System.Globalization;

namespace CustomControl
{
    /// <summary>
    /// Multivalue converter
    /// Takes input for fill color/ gradient and returns color string
    /// </summary>
    public class MultiValueFillConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string fill = null;

            try
            {
                string fill1 = System.Convert.ToString(values[0]);
                Boolean isGradient = Boolean.Parse(values[1].ToString());
                string fill2 = System.Convert.ToString(values[2]);

                if (!String.IsNullOrWhiteSpace(fill1))
                {
                    fill = fill1;
                }

                if (isGradient && !String.IsNullOrWhiteSpace(fill2) && !String.IsNullOrWhiteSpace(fill1))
                {
                    fill += "," + fill2;
                }
            }
            catch
            {
                // Do nothing.
            }

            return fill;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
