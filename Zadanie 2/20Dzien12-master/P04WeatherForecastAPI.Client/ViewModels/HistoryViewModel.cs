using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models.ViewModels
{
    public class HistoryViewModel
    {
        public HistoryViewModel(WeatherInfo weather)
        {
            WeatherHistory = weather.WeatherText;
        }
        public string WeatherHistory { get; set; }
    }
}
