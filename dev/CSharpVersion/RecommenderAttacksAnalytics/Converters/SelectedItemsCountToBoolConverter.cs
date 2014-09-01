using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Collections;
using System.Windows;

namespace RecommenderAttacksAnalytics.Converters
{
    public class SelectedItemsCountToBoolConverter : IValueConverter 
    {
        

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IList selectedItems ;
            if (!(value is IList))
                return false;

            selectedItems = value as IList;
            return selectedItems.Count > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
