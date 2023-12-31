using P06WeatherForecastAPI.ClientExtended.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06WeatherForecastAPI.ClientExtended.ViewModels
{
    public class WeatherViewModel
    {
        public WeatherViewModel(Weather weather)
        {
            CurrentTemperature = weather.Temperature.Metric.Value;
            HasPrecipitation = weather.HasPrecipitation;
        }
        public double CurrentTemperature { get; set; }
        public bool HasPrecipitation { get; set;}
    }
}
