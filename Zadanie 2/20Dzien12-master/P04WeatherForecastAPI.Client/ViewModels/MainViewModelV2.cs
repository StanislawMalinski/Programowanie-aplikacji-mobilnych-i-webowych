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
    public class MainViewModelV2 : BaseViewModel
    {
        private CityViewModel _selectedCity;
       //private Weather _weather;
        private readonly IAccuWeatherService _accuWeatherService;
        private WeatherViewModel weatherView;

        public ICommand LoadCitiesCommand { get;  }

        public MainViewModelV2(IAccuWeatherService accuWeatherService)
        {
            LoadCitiesCommand = new RelayCommand(x => LoadCities(x as string));
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); 

            //_weather = MainViewDataseeder.GenerateWeather;
            //_selectedCity = MainViewDataseeder.GenerateSelectedCity;
            //_cities = MainViewDataseeder.GenerateCities;
        }


        //private Weather Weather
        //{
        
        
        
        
        
        
        
        //}

         
       

        public WeatherViewModel WeatherView { 
            get { return weatherView; } 
            set { 
                weatherView = value;
                OnPropertyChanged();
            }
        }
        

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
                Weather  _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key); 
                WeatherView = new WeatherViewModel(_weather);
                
            }
        }

        
        public ObservableCollection<CityViewModel> Cities { get; set; }


        public async void LoadCities(string locationName)
        {
            
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities) 
                Cities.Add(new CityViewModel(city));
        }
    }
}
