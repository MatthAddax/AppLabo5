using AppLabo5.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace AppLabo5.ViewModel
{
    class WeatherViewModel : ViewModelBase
    {
        private ObservableCollection<WeatherForecast> _forecast = null;
        private City _selectedCity;

        public City SelectedCity
        {
            get { return _selectedCity; }
            set {
                if (_selectedCity == value)
                    return;
                _selectedCity = value;
                RaisePropertyChanged("SelectedCity");
                GetForecast(_selectedCity);
            }
        }


        public ObservableCollection<WeatherForecast> Forecast
        {
            get { return _forecast; }
            set {
                if (_forecast == value)
                    return;
                _forecast = value;
                RaisePropertyChanged("Forecast");
            }
        }
        private INavigationService _navigationService;
        public void OnNavigateTo(NavigationEventArgs e)
        {
            SelectedCity = (City)e.Parameter;
        }

        [PreferredConstructor]
        public WeatherViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            if (IsInDesignMode)
            {
                var forecast = new Forecast() { Cityname = "Namur" };
                var weatherForecasts = new List<WeatherForecast>();
                for(int i = 0; i < 40; i++)
                {
                    weatherForecasts.Add(new WeatherForecast()
                    {
                        Date = DateTime.Now.AddDays(i),
                        MaxTemp = 5 + i / 2,
                        MinTemp = 0 + i / 2,
                        WeatherDescription = "Peu de nuages",
                        WindSpeed = i % 7
                    });
                }

                forecast.WeatherForecasts = weatherForecasts;
                Forecast = new ObservableCollection<WeatherForecast>(weatherForecasts);
            }
        }
        


        private async Task GetForecast(City selectedCity)
        {
            var service = new WeatherService(selectedCity);
            var forecast = await service.GetForecast();
            Forecast = new ObservableCollection<WeatherForecast>(forecast);
        }
    }
}
