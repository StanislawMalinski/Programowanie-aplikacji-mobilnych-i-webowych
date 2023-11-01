using Microsoft.AspNetCore.Mvc;
using static Film.Shared.Model.FilmModel;
using Film.Shared.Services;

namespace Film.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        [HttpGet("main")] //https://localhost:5001/api/film/main
        public ServiceResponse<Bool> GetMain()
        {
            var success = true;
            var response = new ServiceResponse<Bool>() { Data = data, Success = success };
            return response;
        }

        [HttpGet("Top50")] //https://localhost:5001/api/film/Top50
        public ServiceResponse<List<FilmModel>> GetTop50()
        {
            try{
                var got = await _filmService.GetTop50Films();
                return got;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getfilm/{id}")] //https://localhost:5001/api/film/getfilm/1
        public ServiceResponse<FilmModel> GetFilmById(int id)
        {
            if (id < 0)
            {
                var Success = false;
                var ErrorMessage = "ID must be greater than 0";
                var response = new ServiceResponse<FilmModel>() { Success = Success, ErrorMessage = ErrorMessage };
                return response;
            } 

            try
            {
                var response = await _filmService.GetFilmById(id);
                return response;
            }
            catch (Exception ex)
            {
                var Success = false;
                var ErrorMessage = ex.Message;
                return new ServiceResponse<FilmModel>() { Success = Success, ErrorMessage = ErrorMessage };
            }
        }

        [HttpGet("filter")] //https://localhost:5001/api/film/filter?Genre=action&RatingLow=5&RatingHigh=10
        public ServiceResponse<List<FilmModel>> GetFilmsByFilter([FromQuery] FilterRequest filter)
        {
            try{
                var films = await _filmService.GetFilmsByFilter(filter);
                return films;
            }
            catch (Exception ex)
            {
                var Success = false;
                var ErrorMessage = ex.Message;
                return new ServiceResponse<List<FilmModel>>() { Success = Success, ErrorMessage = ErrorMessage };
            }
        }

        [HttpPost("add")] //https://localhost:5001/api/film/add
        [HttpPost("create")] //https://localhost:5001/api/film/create
        public ServiceResponse PostFilm([FromBody] FilmModel film)
        {
            try{
                var film = await _filmService.CreateFilm(film);
                return film;
            }
            catch (Exception ex)
            {
                var Success = false;
                var ErrorMessage = ex.Message;
                return new ServiceResponse<FilmModel>() { Success = Success, ErrorMessage = ErrorMessage };
            }
            
        }
        
        [HttpPut("update/{id}")] //https://localhost:5001/api/film/update/1
        public ServiceResponse PutFilm(int id, [FromBody] FilmModel film)
        {
            try{
                FilmModel updatedFilm = await _filmService.UpdateFilm(film);
                return Ok(updatedFilm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")] //https://localhost:5001/api/film/delete/1
        public ServiceResponse DeleteFilm(int id)
        {
            try{
                FilmModel deletedFilm = await _filmService.DeleteFilm(id);
                return new ServiceResopnse();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")] //https://localhost:5001/api/film/TurnOff
        public ServiceResponse TurnOff()
        {
            Environment.Exit(0);
            return Ok("Turned off");
        }
    }
}
