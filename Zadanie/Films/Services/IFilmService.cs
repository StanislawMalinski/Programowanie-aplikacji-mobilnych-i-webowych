using Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace Films.Services
{
     public interface IFilmService
     {
          public Boolean GetMain();
          public List<FilmModel> GetFilms();
          public List<FilmModel> GetTop10();
          public FilmModel GetFilmById(int id);
          public List<FilmModel> GetFilmsByFilter([FromQuery] FilterRequest filter);
          public FilmModel GetFilm(string title);
          public Boolean PostFilm([FromBody] FilmModel film);
          public Boolean PutFilm([FromBody] FilmModel film);
          public Boolean DeleteFilm(int id);
     }
}
