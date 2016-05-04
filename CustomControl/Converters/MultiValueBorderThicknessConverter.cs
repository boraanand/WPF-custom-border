using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;
using CustomControl.Utils;

namespace CustomControl
{
    /// <summary>
    /// Multivalue converter
    /// Takes input for border, thickness and color and returns thickness.
    /// </summary>
    public class MultiValueBorderThicknessConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                Thickness thickness = new Thickness();

                // Set all border to specified thickness
                Boolean isAll = Boolean.Parse(values[0].ToString());
                if (isAll && Utility.isValidColor(values[10]))
                {
                    try
                    {
                        int thicknessAll = System.Convert.ToInt32(values[1]);
                        thickness.Left = thicknessAll;
                        thickness.Top = thicknessAll;
                        thickness.Right = thicknessAll;
                        thickness.Bottom = thicknessAll;

                        return thickness;
                    } catch { }
                }

                // Set left border thickness
                Boolean isLeft = Boolean.Parse(values[2].ToString());
                if (isLeft && Utility.isValidColor(values[11]))
                {
                    try
                    {
                        int thicknessLeft = System.Convert.ToInt32(values[3]);
                        thickness.Left = thicknessLeft;
                    } catch { }
                }

                // Set top border thickness
                Boolean isTop = Boolean.Parse(values[4].ToString());
                if (isTop && Utility.isValidColor(values[12]))
                {
                    try
                    {
                        int thicknessTop = System.Convert.ToInt32(values[5]);
                        thickness.Top = thicknessTop;
                    } catch { }
                }

                // Set right border thickness
                Boolean isRight = Boolean.Parse(values[6].ToString());
                if (isRight && Utility.isValidColor(values[13]))
                {
                    try
                    {
                        int thicknessRight = System.Convert.ToInt32(values[7]);
                        thickness.Right = thicknessRight;
                    } catch { }
                }

                // Set bottom border thickness
                Boolean isBottom = Boolean.Parse(values[8].ToString());
                if (isBottom && Utility.isValidColor(values[14]))
                {
                    try
                    {
                        int thicknessBottom = System.Convert.ToInt32(values[9]);
                        thickness.Bottom = thicknessBottom;
                    } catch { }
                }

                return thickness;
            }
            catch
            {
                return new Thickness();
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
