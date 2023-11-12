using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Model;

namespace Shared.Services
{
    public interface IFilmSearchService
    {
        public List<FilmModel> SearchFilms(FilterRequest filter);
    }
}
