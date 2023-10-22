using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models{
     public class Day
    {
    public int Icon { get; set; }
    public string IconPhrase { get; set; }
    public bool HasPrecipitation { get; set; }
    }
}
