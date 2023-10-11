using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05WeatherForecastAPI.ClientExtended.Models
{
    internal class Country
    {
        public required string ID { get; set; }
        public required string LocalizedName { get; set; }
    }
}
