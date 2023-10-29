using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models{
     public class GeoPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Elevation Elevation { get; set; }
    }
}