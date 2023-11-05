using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Model
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public List<Actor> Actors { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}