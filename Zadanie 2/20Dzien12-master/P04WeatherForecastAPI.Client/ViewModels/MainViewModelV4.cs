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
        private ForcastViewModel _forcastViewModel;
        private DailyForecast _dailyForecast;
        private readonly IAccuWeatherService _accuWeatherService;
        private readonly FavoriteCitiesView _favoriteCitiesView;
        private readonly FavoriteCityViewModel _favoriteCityViewModel;
        //public ICommand LoadCitiesCommand { get;  }


        public MainViewModelV4(IAccuWeatherService accuWeatherService, FavoriteCityViewModel favoriteCityViewModel, FavoriteCitiesView favoriteCitiesView)
        {
            _favoriteCitiesView = favoriteCitiesView;
            _favoriteCityViewModel = favoriteCityViewModel;
            
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); 
        }

        [ObservableProperty]
        private WeatherViewModel weatherView;


        public CityViewModel SelectedCity
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
                _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key); 
                var neighbours = await _accuWeatherService.GetNeighbouredCity(_selectedCity.Key);


                WeatherView  = new WeatherViewModel(_weather);
                
                Cities.Clear();
                foreach (var city in neighbours ) 
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
                SelectedCity = new CityViewModel(await _accuWeatherService.GetCurrentLocationFromIP(str));
            }
            else if (IsValidLatLongFormat(str))
            {
                SelectedCity = new CityViewModel(await _accuWeatherService.GetCurrentLocationFromGeoposition(str));
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

        [RelayCommand]
        public void OpenFavotireCities()
        {
            //var favoriteCitiesView = new FavoriteCitiesView();
            _favoriteCityViewModel.SelectedCity = new FavoriteCity() { Name = "Warsaw" };
            _favoriteCitiesView.Show();
        }
    }
}
