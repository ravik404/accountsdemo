using Accounts.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Accounts.Core.Converters.UI
{
    public class NameToFormattedNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            if (!(value is UserName))
                throw new Exception("Type is not supported");

            var obj = (UserName)value;
            return $"{obj.First} {obj.Last}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;// Not required at this stage
        }
    }
}
