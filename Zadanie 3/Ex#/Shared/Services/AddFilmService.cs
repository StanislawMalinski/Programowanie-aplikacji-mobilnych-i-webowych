
using System;
using System.Threading.Tasks;
using Shared.Model;

namespace Shared.Services
{
    public class AddFilmService : IAddFilmService
    {
        private IFilmClientService _filmClientService;

        public async Task<Boolean> AddFilm(FilmModel film)
        {
            return await _filmClientService.CreateFilm(film);
        }

        public async Task<Boolean> UpdateFilm(FilmModel film)
        {
            return await _filmClientService.UpdateFilm(film);
        }
    }
}