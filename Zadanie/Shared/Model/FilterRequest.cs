using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class FilterRequest
    {
        public int? YearLow { get; set; }
        public int? YearHigh { get; set; }
        public string? Genre { get; set; }
        public int? RatingLow { get; set; }
        public int? RatingHigh { get; set; }
        public List<string>? Actors { get; set; }
        public string? Director { get; set; }
    }
}