using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RecommenderAttacksAnalytics.Converters
{
    public class BoolToValueConverter : IValueConverter
    {

        public Object TrueValue { get; set; }
        public Object FalseValue { get; set; }
        public Type ReturnType { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                var returnValue = (bool) value ? TrueValue : FalseValue;
                try
                {
                    var converter = TypeDescriptor.GetConverter(ReturnType);
                    var convertedValue = converter.ConvertFrom(returnValue);
                    return convertedValue;
                    //return (bool)value ? System.Convert.ChangeType(TrueValue, ReturnType) : System.Convert.ChangeType(FalseValue, ReturnType);
                }
                catch (Exception e)
                {
                    try
                    {
                        return Activator.CreateInstance(ReturnType, new object[] {returnValue});
                    }
                    catch (Exception exception)
                    {
                        return DependencyProperty.UnsetValue;
                    }
                }
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
