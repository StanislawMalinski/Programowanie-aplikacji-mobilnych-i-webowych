using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using Films.Services;
using System.Numerics;

namespace Films.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet("main")] //https://localhost:5001/api/film/main
        public ActionResult<bool> GetMain()
        {
            bool isMain = _filmService.GetMain();
            return Ok(isMain);
        }

        [HttpGet("all")] //https://localhost:5001/api/film/all
        public ActionResult<IEnumerable<FilmModel>> GetAllFilms()
        {
            var films = _filmService.GetFilms();
            if (films == null || !films.Any())
            {
                return NotFound();
            }
            return Ok(films);
        }

        [HttpGet("Top10")] //https://localhost:5001/api/film/Top10
        public IEnumerable<FilmModel> GetTop10()
        {
            return _filmService.GetFilms()
                .OrderByDescending(f => f.Rating)
                .Take(10);
        }

        [HttpGet("films/{id}")] //https://localhost:5001/api/film/films/1
        public ActionResult<FilmModel> GetFilmById(int id)
        {
            var film = _filmService.GetFilmById(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpGet("filter")] //https://localhost:5001/api/film/filter?Genre=action&RatingLow=5&RatingHigh=10
        public ActionResult<List<FilmModel>> GetFilmsByFilter([FromQuery] FilterRequest filter)
        {
            var resp = Enumerable.Empty<List<FilmModel>>();
            return Ok(_filmService.GetFilmsByFilter(filter));
        }

        [HttpPost("add")] //https://localhost:5001/api/film/add
        [HttpPost("create")] //https://localhost:5001/api/film/create
        public ActionResult<Boolean> PostFilm([FromBody] FilmModel film)
        {
            bool resp = _filmService.PostFilm(film);
            return Ok(resp);
        }
        
        [HttpPut("update/{id}")] //https://localhost:5001/api/film/update/1
        public ActionResult<Boolean>  PutFilm(int id, [FromBody] FilmModel film)
        {
            bool resp = _filmService.PutFilm(id, film);
            return Ok(resp);
        }

        [HttpDelete("delete/{id}")] //https://localhost:5001/api/film/delete/1
        public ActionResult<Boolean>  DeleteFilm(int id)
        {
            bool resp = _filmService.DeleteFilm(id);
            return Ok(resp);
        }
    }
}
