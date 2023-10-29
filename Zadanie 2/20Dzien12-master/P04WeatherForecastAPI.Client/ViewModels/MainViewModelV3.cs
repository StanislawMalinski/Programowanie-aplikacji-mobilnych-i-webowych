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
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    //CommunityToolkit.Mvvm
    
    public partial class MainViewModelV3 : ObservableObject
    {
        private CityViewModel _selectedCity;
        private Weather _weather;
        private readonly IAccuWeatherService _accuWeatherService;
        

        //public ICommand LoadCitiesCommand { get;  }


        private readonly IServiceProvider _serviceProvider;
        public MainViewModelV3(IAccuWeatherService accuWeatherService, IServiceProvider serviceProvider)
        {
            _serviceProvider= serviceProvider; 
            //LoadCitiesCommand = new RelayCommand(x => LoadCities(x as string));
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); 
        }

        //[ObservableProperty]
        //private WeatherViewModel weatherView;
        //public WeatherViewModel WeatherView { 
        
        
        
        
        
        //}
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
                WeatherView = new WeatherViewModel(_weather);
            }
        } 

        
        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities) 
                Cities.Add(new CityViewModel(city));
        }

        [RelayCommand]
        public void OpenFavotireCities()
        {
            //var favoriteCitiesView = new FavoriteCitiesView();
            var favoriteCitiesView = _serviceProvider.GetService<FavoriteCitiesView>();
            favoriteCitiesView.Show();
        }
    }
}
