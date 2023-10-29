using Film.Shared.Model;
using Film.Shared.Services;
using System.Threading.Tasks;

namespace Film.Shared.Services
{
     public interface IFilmSerivce
     {
          Task<ServiceResponse<List<FilmModel>>> GetFilms();
          Task<ServiceResponse<List<FilmModel>>> GetFilms(FilterRequest filterRequest);
          Task<ServiceResponse<List<FilmModel>>> GetTop50Films();
          Task<ServiceResponse<FilmModel>> GetFilm(string title);
          Task<ServiceResponse<FilmModel>> CreateFilm(FilmModel film);
          Task<ServiceResponse<FilmModel>> UpdateFilm(FilmModel film);
          Task<ServiceResponse<FilmModel>> DeleteFilm(string title);
     }
}
