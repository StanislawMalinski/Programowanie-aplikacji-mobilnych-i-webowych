using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Model;

namespace Client.Services
{
    public class FilmSearchService : IFilmSearchService
    {
        private readonly IFilmClientService _filmClientService;
        public List<FilmModel> SearchFilms(FilterRequest filter)
        {   
            return _filmClientService.GetFilteredFilms(
                filter.Genre ?? "", 
                filter.RatingLow ?? 0, 
                filter.RatingHigh ?? 10,
                filter.YearLow ?? 1900,
                filter.YearHigh ?? 2023
                ).Result;
        }
    }
}
