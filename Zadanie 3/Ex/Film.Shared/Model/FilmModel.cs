using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Shared.Model
{
    public class FilmModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}