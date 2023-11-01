using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Shared.Model
{
    public class FilterRequest
    {
        public int? YearLow { get; set; }
        public int? YearHigh { get; set; }
        public string? Genre { get; set; }
        public int? RatingLow { get; set; }
        public int? RatingHigh { get; set; }
        public List<Actor>? Actors { get; set; }
    }
}