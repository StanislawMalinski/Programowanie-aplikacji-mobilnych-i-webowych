using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface IAccuWeatherService
    {
        public Task<City> GetCurrentLocationFromIP(string IP);
        public Task<City> GetCurrentLocationFromGeoposition(string geoposition);
        public Task<City[]> GetLocations(string locationName);
        public Task<Weather> GetCurrentConditions(string cityKey);
        public Task<DailyForecast> GetForcastForOneDay(string cityKey);
        public Task<WeatherInfo> GetWeatherHistory(string cityKey);
        public Task<City[]> GetNeighbouredCity(string cityKey);
    }
}
