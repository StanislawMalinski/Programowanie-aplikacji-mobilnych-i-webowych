using System;
using System.Threading.Tasks;
using Shared.Model;
using Client.ViewModel;

namespace Client.Services
{
    public interface IAddFilmService
    {
        void SetFilm(FilmViewModel filmView);
        Task<Boolean> AddFilm(FilmModel film);
        Task<Boolean> UpdateFilm(FilmModel film);
    }
}
