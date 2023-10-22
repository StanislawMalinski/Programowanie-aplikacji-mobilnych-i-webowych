using P06WeatherForecastAPI.ClientExtended.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06WeatherForecastAPI.ClientExtended.Services
{
    public interface IAccuWeatherService
    {
        Task<IP> GetCurrentLocationFromIP(string IP);
        Task<City> GetCurrentLocationFromGeoposition(string geoposition);
        Task<City[]> GetLocations(string locationName);
        Task<Weather> GetCurrentConditions(string cityKey);
        Task<DailyForecast> GetForcastForOneDay(string cityKey);
        Task<WeatherInfo> GetWeatherHistory(string cityKey);
        Task<City[]> GetNeighbouredCity(string cityKey);
    }
}
