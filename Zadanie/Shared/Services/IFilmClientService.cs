using Shared.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shared.Services
{
    public interface IFilmClientService
    {
        public Task<List<FilmModel>> GetPage(int page);
        public Task<int> GetPagesCount();
        public Task<Boolean> GetMain();
        public Task<List<FilmModel>> GetAllFilms();
        public Task<List<FilmModel>> GetTop10();
        public Task<FilmModel> GetFilmById(int id);
        public Task<List<FilmModel>> GetFilteredFilms(string genre, int ratingLow, int ratingHigh, int yearLow, int yearHigh);
        public Task<Boolean> CreateFilm(FilmModel film);
        public Task<Boolean> UpdateFilm(FilmModel film);
        public Task<Boolean> DeleteFilm(int id);
    }
}