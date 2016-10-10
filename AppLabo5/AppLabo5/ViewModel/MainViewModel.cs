using AppLabo5.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppLabo5.ViewModel
{
    class MainViewModel : ViewModelBase
    {
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


        private ICommand _citySelectedCommand;

        public ICommand CitySelectedCommand
        {
            get { return _citySelectedCommand; }
            set { _citySelectedCommand = value; }
        }


        public MainViewModel()
        {

        }
    }
}
