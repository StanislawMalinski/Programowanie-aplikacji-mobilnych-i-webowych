using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05WeatherForecastAPI.ClientExtended.Models
{
    internal class WeatherForecastResponse
    {
        public Headline Headline { get; set; }
        public DailyForecast [] DailyForecasts { get; set; }
    }
}
