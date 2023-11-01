using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class ForcastViewModel
    {
        public ForcastViewModel(DailyForecast forcast)
        {
            WeatherForcast = forcast.Day.IconPhrase;
        }
        public string WeatherForcast { get; set; }
    }
}
