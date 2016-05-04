using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Controls;
using CustomControl.Utils;

namespace CustomControl
{
    /// <summary>
    /// Custom control with following properties:
    /// 1. Configurable left, right, top, botom or all border thickness
    /// 2. Configurable left, right, top, botom or all border colors
    /// 3. Single configurable fill or gradient from top to bottom using 2 configurable colors
    /// </summary>
    public class CustomBox : ContentControl, INotifyPropertyChanged
    {
        #region Constructor
        static CustomBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomBox), new FrameworkPropertyMetadata(typeof(CustomBox)));
        }
        #endregion

        #region Dependency Properites
        public static readonly DependencyProperty BorderThickProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness),
            typeof(CustomBox), new PropertyMetadata(new Thickness(0, 0, 0, 0), BorderThickChanged));

        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderBrush", typeof(string),
            typeof(CustomBox), new PropertyMetadata(string.Empty, BorderColorChanged));

        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register("Fill", typeof(string),
            typeof(CustomBox), new PropertyMetadata(string.Empty, FillColorChanged));

        public new Thickness BorderThickness
        {
            get
            {
                return (Thickness)GetValue(BorderThickProperty);
            }
            set
            {
                SetValue(BorderThickProperty, value);
            }
        }

        public new string BorderBrush
        {
            get
            {
                return (string)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public string Fill
        {
            get
            {
                return (string)GetValue(FillColorProperty);
            }
            set
            {
                SetValue(FillColorProperty, value);
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Sets left, right, top, bottom thickness properties for custom control
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void BorderThickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomBox grid = d as CustomBox;
            Thickness thickness = (Thickness)e.NewValue;

            grid.LeftThickness = thickness.Left;
            grid.RightThickness = thickness.Right;
            grid.TopThickness = thickness.Top;
            grid.BottomThickness = thickness.Bottom;
        }

        /// <summary>
        /// Sets fill colors for custom control
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void FillColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomBox box = d as CustomBox;

            box.FillColor1 = Colors.Transparent;
            box.FillColor2 = Colors.Transparent;

            if (e.NewValue == null || string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                return;
            }

            BrushConverter converter = new BrushConverter();

            string stringValue = e.NewValue.ToString();

            // Single fill
            if (stringValue.IndexOf(',') == -1 && Utility.isValidColor(stringValue.Trim()))
            {
                box.FillColor1 = (Color)ColorConverter.ConvertFromString(stringValue.Trim());
                box.FillColor2 = (Color)ColorConverter.ConvertFromString(stringValue.Trim());

                return;
            }

            // Gradient
            string[] stringValues = stringValue.Split(',');
            if (stringValues.Length == 2 && Utility.isValidColor(stringValues[0].Trim()) && Utility.isValidColor(stringValues[1].Trim()))
            {
                box.FillColor1 = (Color)ColorConverter.ConvertFromString(stringValues[0].Trim());
                box.FillColor2 = (Color)ColorConverter.ConvertFromString(stringValues[1].Trim());
            }

        }

        /// <summary>
        /// Sets left, right, top, bottom border color for custom control
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void BorderColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomBox box = d as CustomBox;

            box.LeftColor = Brushes.Transparent;
            box.TopColor = Brushes.Transparent;
            box.RightColor = Brushes.Transparent;
            box.BottomColor = Brushes.Transparent;

            if (e.NewValue == null || string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                return;
            }

            BrushConverter converter = new BrushConverter();

            string stringValue = e.NewValue.ToString();

            // Single input, set same color to all four borders
            if (stringValue.IndexOf(',') == -1 && Utility.isValidColor(stringValue.Trim())) 
            {
                box.BottomColor = (Brush)converter.ConvertFromString(stringValue.Trim());
                box.TopColor = (Brush)converter.ConvertFromString(stringValue.Trim());
                box.RightColor = (Brush)converter.ConvertFromString(stringValue.Trim());
                box.LeftColor = (Brush)converter.ConvertFromString(stringValue.Trim());
                return;
            }

            string[] stringValues = stringValue.Split(',');
            if (stringValues.Length == 4 
                && Utility.isValidColor(stringValues[0].Trim()) && Utility.isValidColor(stringValues[1].Trim())
                && Utility.isValidColor(stringValues[2].Trim()) && Utility.isValidColor(stringValues[3].Trim())) {

                box.LeftColor = (Brush)converter.ConvertFromString(stringValues[0].Trim());
                box.TopColor = (Brush)converter.ConvertFromString(stringValues[1].Trim());
                box.RightColor = (Brush)converter.ConvertFromString(stringValues[2].Trim());
                box.BottomColor = (Brush)converter.ConvertFromString(stringValues[3].Trim());
            }
        }

        #endregion

        #region Properties

        private double leftThickness;
        public double LeftThickness
        {
            get
            {
                return leftThickness;
            }
            set
            {
                leftThickness = value;
                RaisePropertyChanged(nameof(LeftThickness));
            }
        }

        private double rightThickness;
        public double RightThickness
        {
            get
            {
                return rightThickness;
            }
            set
            {
                rightThickness = value;
                RaisePropertyChanged(nameof(RightThickness));
            }
        }

        private double topThickness;
        public double TopThickness
        {
            get
            {
                return topThickness;
            }
            set
            {
                topThickness = value;
                RaisePropertyChanged(nameof(TopThickness));
            }
        }

        private double bottomThickness;
        public double BottomThickness
        {
            get
            {
                return bottomThickness;
            }
            set
            {
                bottomThickness = value;
                RaisePropertyChanged(nameof(BottomThickness));
            }
        }

        private Brush leftColor;
        public Brush LeftColor
        {
            get
            {
                return leftColor;
            }
            set
            {
                leftColor = value;
                RaisePropertyChanged(nameof(LeftColor));
            }
        }

        private Brush rightColor;
        public Brush RightColor
        {
            get
            {
                return rightColor;
            }
            set
            {
                rightColor = value;
                RaisePropertyChanged(nameof(RightColor));
            }
        }

        private Brush topColor;
        public Brush TopColor
        {
            get
            {
                return topColor;
            }
            set
            {
                topColor = value;
                RaisePropertyChanged(nameof(TopColor));
            }
        }

        private Brush bottomColor;
        public Brush BottomColor
        {
            get
            {
                return bottomColor;
            }
            set
            {
                bottomColor = value;
                RaisePropertyChanged(nameof(BottomColor));
            }
        }

        private Color fillColor1;
        public Color FillColor1
        {
            get
            {
                return fillColor1;
            }
            set
            {
                fillColor1 = value;
                RaisePropertyChanged(nameof(FillColor1));
            }
        }

        private Color fillColor2;
        public Color FillColor2
        {
            get
            {
                return fillColor2;
            }
            set
            {
                fillColor2 = value;
                RaisePropertyChanged(nameof(FillColor2));
            }
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
