using System;
using System.Threading.Tasks;
using Shared.Model;

namespace Shared.Services
{
    public interface IAddFilmService
    {
        Task<Boolean> AddFilm(FilmModel film);
        Task<Boolean> UpdateFilm(FilmModel film);
    }
}
