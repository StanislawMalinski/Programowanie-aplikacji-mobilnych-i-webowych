using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models
{
    public class FavoriteCity
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public string Country { get; set; }
    }
}
