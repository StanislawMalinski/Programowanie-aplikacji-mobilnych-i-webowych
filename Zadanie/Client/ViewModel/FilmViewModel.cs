using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class FilmViewModel 
    {
        public FilmViewModel()
        {
            Id = -1;
            Title = "";
            Year = 0;
            Director = "";
            Actors = new List<Actor>();
            Genre = "";
            Rating = 0;
        }
        
        public FilmViewModel(FilmModel film)
        {
            Id = film.Id;
            Title = film.Title;
            Year = film.Year;
            Director = film.Director;
            Actors = film.Actors;
            Genre = film.Genre;
            Rating = film.Rating;
        }

        public FilmModel toFilmModel(){
            return new FilmModel(){
                Id = this.Id,
                Title = this.Title,
                Year = this.Year,
                Director = this.Director,
                Actors = this.Actors,
                Genre = this.Genre,
                Rating = this.Rating
            };
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public List<Actor> Actors { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}