using System;
using System.Globalization;
using Xamarin.Forms;

namespace TodoApp.Converters
{
    public class CompletedToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var completed = (bool)value;
            return completed ? Color.DimGray : Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
