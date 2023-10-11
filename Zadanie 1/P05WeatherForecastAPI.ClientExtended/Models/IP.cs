using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05WeatherForecastAPI.ClientExtended.Models
{
    internal class IP
    {
        public required string Value { get; set; }
        public required City City { get; set; }
        public required Weather Weather { get; set; }
    }
}