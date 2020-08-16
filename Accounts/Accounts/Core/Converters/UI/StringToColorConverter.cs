using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Accounts.Core.Converters.UI
{
    public class StringToColorConverter : IValueConverter
    {
        #region Color filed list       
        private const string ColorBlue = "blue";
        private const string ColorGreen = "green";
        private const string ColorBlack = "black";
        private const string ColorBrown = "brown";
        #endregion

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var colorText = value.ToString().ToLower();
                switch (colorText)
                {
                    case ColorBlack:
                        return Color.Black;
                    case ColorBlue:
                        return Color.Blue;
                    case ColorGreen:
                        return Color.Green;
                    case ColorBrown:
                        return Color.Brown;
                    default:
                        return Color.Black;
                }
                   
            }
            return Color.Black; //Default
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
