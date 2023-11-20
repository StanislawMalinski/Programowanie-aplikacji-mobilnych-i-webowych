using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Model;

namespace Client.Services
{
    public interface IFilmSearchService
    {
        public List<FilmModel> SearchFilms(FilterRequest filter);
    }
}
