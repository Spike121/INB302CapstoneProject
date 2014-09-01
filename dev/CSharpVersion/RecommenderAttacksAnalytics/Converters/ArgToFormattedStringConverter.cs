using System;
using System.Windows;
using System.Windows.Data;

namespace RecommenderAttacksAnalytics.Converters
{
    public class ArgToFormattedStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter is string && value != null)
            {
                return String.Format(parameter as string, value);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
