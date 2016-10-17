using AppLabo5.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Template10.Mvvm;

namespace AppLabo5.ViewModel
{
    class MainViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private string _lastInput = "";
        private string _userInput;

        private INavigationService _navigationService;

        public DelegateCommand<City> CitySelectedCommand { get; }
        public string UserInput
        {
            get { return _userInput; }
            set
            {
                _lastInput = _userInput;

                if (_userInput == value)
                    return;
                _userInput = value;
                RaisePropertyChanged("UserInput");
                UpdateCitiesDataSet(_userInput);

            }
        }

        private ObservableCollection<City> _cities;

        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set {
                if (_cities == value)
                    return;
                _cities = value;
                RaisePropertyChanged("Cities");
            }
        }

        private ObservableCollection<City> _citiesDataset;

        public ObservableCollection<City> CitiesDataSet
        {
            get { return _citiesDataset; }
            set {
                if(_citiesDataset == value)
                {
                    return;
                }
                _citiesDataset = value;
                RaisePropertyChanged("CitiesDataSet");
            }
        }
        
        private void CitySelected(City city)
        {
            _navigationService.NavigateTo("WeatherPage", city);
        }

        private void UpdateCitiesDataSet(string userInput)
        {
            /*CitiesDataset = Cities.Where(
                c => (c.Name.Contains(userInput) || c.Country.Contains(userInput))
            );*/
            userInput = userInput.Trim();
            CitiesDataSet = new ObservableCollection<City>(from c in Cities
                            where c.Name.Contains(userInput) || c.Country.Contains(userInput)
                            select c);
        }

        [PreferredConstructor]
        public MainViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            InitializeCitiesList();
            CitySelectedCommand = new DelegateCommand<City>(CitySelected);
        }

        private async void InitializeCitiesList()
        {
            var service = new CityService();
            var cities = await service.GetCitiesFromJson();
            Cities = new ObservableCollection<City>(cities);
            CitiesDataSet = Cities;
        }
    }
}
