using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Model;

namespace Client.Services
{
    public interface IFilmSearchService
    {
        public List<FilmModel> SearchFilms(FilterRequest filter);
    }
}
