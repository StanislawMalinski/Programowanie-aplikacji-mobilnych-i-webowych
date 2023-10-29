using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05WeatherForecastAPI.ClientExtended.Models
{
    internal class Headline
    {
        public string EffectiveDate { get; set; }
        public long EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public string EndDate { get; set; }
        public long EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}