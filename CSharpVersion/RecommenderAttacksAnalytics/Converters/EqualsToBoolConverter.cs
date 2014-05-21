using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace RecommenderAttacksAnalytics.Converters
{
    public class EqualsToBoolConverter : IValueConverter
    {

        public bool IsInverted { get; set; }
        //public bool IsInverted { get { return m_isInverted; } set { m_isInverted = value; } }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var converter = TypeDescriptor.GetConverter(targetType);
            if (converter.CanConvertFrom(parameter.GetType()) && converter.CanConvertFrom(value.GetType()))
            {
                var firstValue = converter.ConvertFrom(parameter);
                var secondValue = converter.ConvertFrom(parameter);
                return IsInverted ^ firstValue != null && firstValue.Equals(secondValue);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
