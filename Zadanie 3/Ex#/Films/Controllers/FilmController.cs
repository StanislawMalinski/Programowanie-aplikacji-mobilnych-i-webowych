using Microsoft.AspNetCore.Mvc;
using Films.Model;
using Films.Services;

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
        public IEnumerable<Boolean> GetMain()
        {
            var resp = Enumerable.Empty<Boolean>();
            return resp.Append(_filmService.GetMain());
        }

        [HttpGet("all")] //https://localhost:5001/api/film/all
        public IEnumerable<List<FilmModel>> GetFilms()
        {
            var resp = Enumerable.Empty<List<FilmModel>>();
            return resp.Append(_filmService.GetFilms());
        }

        [HttpGet("Top10")] //https://localhost:5001/api/film/Top50
        public IEnumerable<List<FilmModel>> GetTop10()
        {
            var resp = Enumerable.Empty<List<FilmModel>>();
            return resp.Append(_filmService.GetTop10());
        }

        [HttpGet("getfilm/{id}")] //https://localhost:5001/api/film/getfilm/1
        public IEnumerable<FilmModel> GetFilmById(int id)
        {
            var resp = Enumerable.Empty<FilmModel>();
            return resp.Append(_filmService.GetFilmById(id));
        }

        [HttpGet("filter")] //https://localhost:5001/api/film/filter?Genre=action&RatingLow=5&RatingHigh=10
        public IEnumerable<List<FilmModel>> GetFilmsByFilter([FromQuery] FilterRequest filter)
        {
            var resp = Enumerable.Empty<List<FilmModel>>();
            return resp.Append(_filmService.GetFilmsByFilter(filter));
        }

        [HttpPost("add")] //https://localhost:5001/api/film/add
        [HttpPost("create")] //https://localhost:5001/api/film/create
        public IEnumerable<Boolean> PostFilm([FromBody] FilmModel film)
        {
            var resp = Enumerable.Empty<Boolean>();
            return resp.Append(_filmService.PostFilm(film));
        }
        
        [HttpPut("update/{id}")] //https://localhost:5001/api/film/update/1
        public IEnumerable<Boolean>  PutFilm(int id, [FromBody] FilmModel film)
        {
            var resp = Enumerable.Empty<Boolean>();
            return resp.Append(_filmService.PutFilm(id, film));
        }

        [HttpDelete("delete/{id}")] //https://localhost:5001/api/film/delete/1
        public IEnumerable<Boolean>  DeleteFilm(int id)
        {
            var resp = Enumerable.Empty<Boolean>();
            return resp.Append(_filmService.DeleteFilm(id));
        }
    }
}
