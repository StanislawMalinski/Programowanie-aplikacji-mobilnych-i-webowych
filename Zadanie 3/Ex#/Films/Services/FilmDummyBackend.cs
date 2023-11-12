using System.Collections;
using System.Reflection;
using System.Security.Authentication;
using Shared.Model;
using Microsoft.AspNetCore.Mvc;


namespace Films.Services
{
    public class FilmDummyBackend : IFilmService
    {
        private FilmSeeder _filmSeeder = new FilmSeeder();
        private static List<FilmModel> _films = new List<FilmModel>();
        private int _id = 0;

        public Boolean GetMain()
        {
            var films = _filmSeeder.GetRandomFilms(20);
            addAllToFilms(films);
            return true;
        }

        public List<FilmModel> GetFilms()
        {
            return _films;
        }

        public List<FilmModel> GetTop10()
        {
            int remain = _films.Count - 10;
            if (remain < 0)
            {
                return _films;
            }
            List<FilmModel> films = new List<FilmModel>(_films);
            films.Sort((x, y) => y.Rating.CompareTo(x.Rating));
            return films.GetRange(0, 10);
        }

        public FilmModel GetFilmById(int id)
        {
            if (_films.Find(film => film.Id == id) != null)
            {
                return _films[id];
            }
            else
            {
                return null;
            }
        }

        public List<FilmModel> GetFilmsByFilter([FromQuery] FilterRequest filterRequest)
        {
            var films = _filmSeeder.GetRandomFilms(20, filterRequest);
            addAllToFilms(films);
            return films;
        }

        public FilmModel GetFilm(string title)
        {
            return _films.Find(film => film.Title == title);
        }


        public Boolean PostFilm([FromBody] FilmModel film)
        {
            addToFilms(film);
            return true;
        }

        public Boolean PutFilm(int id, FilmModel film)
        {
            if (_films.Find(film => film.Id == id) != null)
            {
                _films[id] = film;
            }
            else
            {
                return false;
            }
            return true;
        }

        public Boolean DeleteFilm(int id)
        {
            var film  = _films.Find(film => film.Id == id);
            if (film != null)
            {
                _films.Remove(film);
            }
            else
            {
                return false;
            }
            return true;
        }

        private void addAllToFilms(List<FilmModel> films){
            for (int i = 0; i < films.Count; i++)
            {
                films[i].Id = _id++;
                _films.Add(films[i]);
            }
        }

        private void addToFilms(FilmModel film){
            film.Id = _id++;
            _films.Add(film);
        }
    }
}