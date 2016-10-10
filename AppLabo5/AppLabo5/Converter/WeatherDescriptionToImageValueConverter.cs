using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace AppLabo5.Converter
{
    class WeatherDescriptionToImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var forecast = (string)value;
            if (forecast.Contains("nuageux"))
                return new BitmapImage(new Uri("ms-appx:/Images/rainy-weather.png"));
            else
                return new BitmapImage(new Uri("ms-appx:/Images/sunny_weather.jpg"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
