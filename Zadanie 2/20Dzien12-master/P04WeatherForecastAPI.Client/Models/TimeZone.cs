using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models{
    public class TimeZone
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required float GmtOffset { get; set; }       
        public required bool IsDaylightSaving { get; set; }
        public required string NextOffsetChange { get; set; }
    }
}