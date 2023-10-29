using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06WeatherForecastAPI.ClientExtended.Models
{
    internal class Temperature
    {
        public required Metric Metric { get; set; }
        public required Imperial Imperial { get; set; }
    }
}
