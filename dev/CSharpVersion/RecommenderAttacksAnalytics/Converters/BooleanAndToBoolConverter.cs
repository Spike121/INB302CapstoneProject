using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace RecommenderAttacksAnalytics.Converters
{
    public class BooleanAndToBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var finalValue = true;
            foreach (var value in values)
            {
                if (!(value is bool))
                    return DependencyProperty.UnsetValue;
                
                finalValue &= (bool) value;
            }

            return finalValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
