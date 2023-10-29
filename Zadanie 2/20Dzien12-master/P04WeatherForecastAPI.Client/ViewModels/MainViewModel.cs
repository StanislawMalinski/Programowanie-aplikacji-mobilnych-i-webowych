using P04WeatherForecastAPI.Client.Commands;
using P04WeatherForecastAPI.Client.DataSeeders;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        
        private City[] _cities;

        private City _selectedCity;
        private Weather _weather;
        private readonly IAccuWeatherService _accuWeatherService;

        public ICommand LoadCitiesCommand { get;  }

        public MainViewModel(IAccuWeatherService accuWeatherService)
        {
            LoadCitiesCommand = new RelayCommand(x => LoadCities(x as string));
            _accuWeatherService = accuWeatherService;
        }


        public Weather Weather
        {
            get { return _weather; }
            set { 
                _weather = value;
                //OnPropertyChanged("Weather");
                OnPropertyChanged();
                //OnPropertyChanged("CurrentTemperature");
                OnPropertyChanged(nameof(CurrentTemperature));
            }
        }

        public string CurrentTemperature => Weather?.Temperature.Metric.Value.ToString();

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
            }
        }

        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                Weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key);
            }
        }

        public City[] Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }

        static bool IsValidLatLongFormat(string input)
        {
            string pattern = @"^-?\d+\.\d+,-?\d+\.\d+$";

            return Regex.IsMatch(input, pattern);
        }

        public async void LoadCities(string str)
        {
            string pattern = @"^[A-Za-z\s\.'-]+$";
            if (IPAddress.TryParse(str, out IPAddress ipAddress))
            {
                SelectedCity = await _accuWeatherService.GetCurrentLocationFromIP(str);
            }
            else if (IsValidLatLongFormat(str))
            {
                SelectedCity = await _accuWeatherService.GetCurrentLocationFromGeoposition(str);
            }
            else if (Regex.IsMatch(str, pattern))
            {
                Cities = await _accuWeatherService.GetLocations(str);
            }
            else
            {
                Cities = new City[0];
            }
        }
    }
}
