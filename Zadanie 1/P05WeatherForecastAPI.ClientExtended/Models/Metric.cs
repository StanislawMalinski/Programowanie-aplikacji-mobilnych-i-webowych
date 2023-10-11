using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05WeatherForecastAPI.ClientExtended.Models
{
    internal class Metric
    {
        public double Value { get; set; }
        public required string Unit { get; set; }
        public int UnitType { get; set; }
    }
}
