using System;
using System.Globalization;
using Todo.Models;
using Xamarin.Forms;

namespace Todo.Converters
{
    public class TodoItemStatusColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Color.FromHex("#CCCCCC") : Color.FromHex("#333333");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
