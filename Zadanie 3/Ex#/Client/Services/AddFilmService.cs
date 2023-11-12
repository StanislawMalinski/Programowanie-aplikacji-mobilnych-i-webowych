
using System;
using System.Threading.Tasks;
using Shared.Model;

namespace Client.Services
{
    public class AddFilmService : IAddFilmService
    {
        private IFilmClientService _filmClientService;
        private FilmViewModel _filmView;

        public void SetFilm(FilmViewModel filmView)
        {
            _filmView = filmView;
        }
        
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