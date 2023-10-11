using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05WeatherForecastAPI.ClientExtended.Models
{
    internal class City
    {
        public int Version { get; set; }
        public required string Key { get; set; }
        public required string Type { get; set; }
        public required int Rank { get; set; }
        public required string LocalizedName { get; set; }
        public required Country Country { get; set; }
        public required AdministrativeArea AdministrativeArea { get; set; }
        public required GeoPosition GeoPosition { get; set; }
    }
}
