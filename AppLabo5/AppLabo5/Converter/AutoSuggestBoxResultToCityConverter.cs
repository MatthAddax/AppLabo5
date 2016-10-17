using AppLabo5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace AppLabo5.Converter
{
    class AutoSuggestBoxResultToCityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // cast value to whatever EventArgs class you are expecting here
            var args = (AutoSuggestBoxSuggestionChosenEventArgs)value;
            // return what you need from the args
            return (City)args.SelectedItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
