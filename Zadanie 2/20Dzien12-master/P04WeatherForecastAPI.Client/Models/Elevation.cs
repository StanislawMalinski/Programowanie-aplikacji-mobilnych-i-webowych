using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models{
     public class Elevation
    {
        public required Metric Metric { get; set; }
        public required Imperial Imperial { get; set; }
    }
}