using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
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
    
    public partial class MainViewModelV4 : ObservableObject
    {
        private CityViewModel _selectedCity;
        private Weather _weather;
        private DailyForecast _forcast;
        private WeatherInfo _history; 
        private City[] _neighbours;
        private readonly IAccuWeatherService _accuWeatherService;
        private readonly FavoriteCitiesView _favoriteCitiesView;
        private readonly FavoriteCityViewModel _favoriteCityViewModel;

        public MainViewModelV4(IAccuWeatherService accuWeatherService, FavoriteCityViewModel favoriteCityViewModel, FavoriteCitiesView favoriteCitiesView)
        {
            _favoriteCitiesView = favoriteCitiesView;
            _favoriteCityViewModel = favoriteCityViewModel;
            
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); 
        }

        [ObservableProperty]
        private WeatherViewModel weatherView;
        [ObservableProperty]
        private ForcastViewModel forcastView;
        [ObservableProperty]
        private HistoryViewModel historyView;

        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (value == null)
                    return;
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
            }
        }

         
        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                _weather =      await _accuWeatherService.GetCurrentConditions(SelectedCity.Key); 
                _neighbours =   await _accuWeatherService.GetNeighbouredCity(SelectedCity.Key);
                _forcast =      await _accuWeatherService.GetForcastForOneDay(SelectedCity.Key);
                _history =      await _accuWeatherService.GetWeatherHistory(SelectedCity.Key);

                WeatherView  = new WeatherViewModel(_weather);
                ForcastView  = new ForcastViewModel(_forcast);
                HistoryView  = new HistoryViewModel(_history);

                Cities.Clear();
                foreach (var city in _neighbours) 
                    Cities.Add(new CityViewModel(city));
            }
        } 

        
        static bool IsValidLatLongFormat(string input)
        {
            string pattern = @"^-?\d+\.\d+,-?\d+\.\d+$";

            return Regex.IsMatch(input, pattern);
        }

        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string str)
        {
            string pattern = @"^[A-Za-z\s\.'-]+$";
            if (IPAddress.TryParse(str, out IPAddress ipAddress))
            {
                Cities.Clear();
                Cities.Add(new CityViewModel(await _accuWeatherService.GetCurrentLocationFromIP(str)));
            }
            else if (IsValidLatLongFormat(str))
            {
                Cities.Clear();
                Cities.Add(new CityViewModel(await _accuWeatherService.GetCurrentLocationFromGeoposition(str)));
            }
            else if (Regex.IsMatch(str, pattern))
            {
                var cities = await _accuWeatherService.GetLocations(str);
                Cities.Clear();
                foreach (var city in cities) 
                    Cities.Add(new CityViewModel(city));
            }
            else
            {                
                Cities.Clear();
                Cities.Add(new CityViewModel(new City()));
            }
        }
    }
}
