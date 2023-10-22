using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06WeatherForecastAPI.ClientExtended.Models
{
    internal class DailyForecast
    {
        public string Date { get; set; }
        public long EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public string[] Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}