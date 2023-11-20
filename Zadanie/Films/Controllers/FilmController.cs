using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using Films.Services;
using System.Numerics;
using Microsoft.AspNetCore.Server.Kestrel.Core;

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

        [HttpGet("main")] //https://localhost:[port]/Film/main
        public ActionResult<bool> GetMain()
        {
            bool isMain = _filmService.GetMain();
            return Ok(isMain);
        }

        [HttpGet("all")] //https://localhost:[port]/Film/all
        public ActionResult<IEnumerable<FilmModel>> GetAllFilms()
        {
            var films = _filmService.GetFilms();
            if (films == null || !films.Any())
            {
                return NotFound();
            }
            return Ok(films);
        }

        [HttpGet("Top10")] //https://localhost:[port]/Film/Top10
        public ActionResult<IEnumerable<FilmModel>> GetTop10()
        {
            return Ok(_filmService.GetFilms()
                .Take(10));
        }

        [HttpGet("page={page}")] //https://localhost:[port]/Film/page=1
        public ActionResult<List<FilmModel>> GetFilmsByPage(int page)
        {
            List<FilmModel> films = _filmService.GetFilms();
            if (films == null || !films.Any() || page < 1)
            {
                return NotFound();
            }
            return Ok(films.Skip((page - 1) * 10).Take(10));
        }

        [HttpGet("pages")] //https://localhost:[port]/Film/pages
        public ActionResult<int> GetPages()
        {
            var films = _filmService.GetFilms();
            if (films == null || !films.Any())
            {
                return NotFound();
            }
            return Ok((int)Math.Ceiling((double)films.Count() / 10));
        }

        [HttpGet("film/{id}")] //https://localhost:[port]/Film/films/1
        public ActionResult<FilmModel> GetFilmById(int id)
        {
            var film = _filmService.GetFilmById(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpGet("filter")] //https://localhost:[port]/Film/filter?Genre=action&RatingLow=5&RatingHigh=10
        public ActionResult<List<FilmModel>> GetFilmsByFilter([FromQuery] FilterRequest filter)
        {
            var resp = Enumerable.Empty<List<FilmModel>>();
            return Ok(_filmService.GetFilmsByFilter(filter));
        }

        [HttpPost("add")] //https://localhost:[port]/Film/add
        [HttpPost("create")] //https://localhost:[port]/Film/create
        public ActionResult<Boolean> PostFilm([FromBody] FilmModel film)
        {
            bool resp = _filmService.PostFilm(film);
            return Ok(resp);
        }
        
        [HttpPut("update")] //https://localhost:[port]/Film/update/1
        public ActionResult<Boolean>  PutFilm([FromBody] FilmModel film)
        {
            bool resp = _filmService.PutFilm(film);
            return Ok(resp);
        }

        [HttpDelete("delete/{id}")] //https://localhost:[port]/Film/delete/1
        public ActionResult<Boolean>  DeleteFilm(int id)
        {
            bool resp = _filmService.DeleteFilm(id);
            return Ok(resp);
        }
    }
}
