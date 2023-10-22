using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models{
    public class Region
    {
        public required string ID{ get; set; }
        public required string LocalizedName { get; set; }
        public required string EnglishName { get; set; }
    }
}
