using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05WeatherForecastAPI.ClientExtended.Models
{
    internal class Weather
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public required string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public required object PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public required Temperature Temperature { get; set; }
        public required string MobileLink { get; set; }
        public required string Link { get; set; }
    }
}
