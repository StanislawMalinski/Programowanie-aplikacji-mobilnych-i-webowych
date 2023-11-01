using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using P04WeatherForecastAPI.Client.Models;
using System.Text.RegularExpressions;

namespace P04WeatherForecastAPI.Client.Services
{
    public class DummyAccuWeatherService : IAccuWeatherService
    {

        public async Task<City> GetCurrentLocationFromIP(string IP)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "resources\\geoposition.txt");
            var json = File.ReadAllText(path);
            City city = JsonConvert.DeserializeObject<City>(json);
            return city;
        }

        public async Task<City> GetCurrentLocationFromGeoposition(string geoposition)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "resources\\geoposition.txt");
            var json = File.ReadAllText(path); 
            City city = JsonConvert.DeserializeObject<City>(json);
            return city;
        }

        public async Task<City[]> GetLocations(string locationName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "resources\\autocomplete.txt");
            var json = File.ReadAllText(path);
            City[] cities = JsonConvert.DeserializeObject<City[]>(json);
            return cities;
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "resources\\currentcondition.txt");
            var json = File.ReadAllText(path);
            Weather[] weathers= JsonConvert.DeserializeObject<Weather[]>(json);
            return weathers.FirstOrDefault();
        }

        public async Task<DailyForecast> GetForcastForOneDay(string cityKey)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "resources\\forecast.txt");
            var json = File.ReadAllText(path);
            WeatherForecastResponse wheatherResponse = JsonConvert.DeserializeObject<WeatherForecastResponse>(json);
            return wheatherResponse.DailyForecasts.FirstOrDefault();
        }

        public async Task<WeatherInfo> GetWeatherHistory(string cityKey){
            var path = Path.Combine(Directory.GetCurrentDirectory(), "resources\\history.txt");
            var json = File.ReadAllText(path);
            WeatherInfo[] wheatherResponse = JsonConvert.DeserializeObject<WeatherInfo[]>(json);
            return wheatherResponse.Last();
        }

        public async Task<City[]> GetNeighbouredCity(string cityKey){
            var path = Path.Combine(Directory.GetCurrentDirectory(), "resources\\neighbour.txt");
            var json = File.ReadAllText(path);
            City[] cities = JsonConvert.DeserializeObject<City[]>(json);
            return cities;
        }
    }
}
