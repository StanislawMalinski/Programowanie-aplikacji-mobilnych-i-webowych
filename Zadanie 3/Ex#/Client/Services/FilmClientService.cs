using Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Services
{
    public class FilmClientService : IFilmClientService
    {
        private const string base_url = "https://localhost:5001/api/film";
        private const string getMainUrl = "/main";
        private const string getAllFilmsUrl = "/all";
        private const string getTop10Url = "/Top10";    
        private const string getFilmByIdUrl = "/getfilm/{0}";
        private const string filterFilmUrl = "/filter?Genre={0}}&RatingLow={1}&RatingHigh={2}&YearLow={3}&YearHigh={4}";
        private const string createFilmUrl = "/create";
        private const string updateFilmUrl = "/update/{0}";
        private const string deleteFilmUrl = "/delete/{0}";

        public async Task<Boolean> GetMain()
        {
            string url = base_url + getMainUrl;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Boolean>(result);
            }
        }

        public async Task<List<FilmModel>> GetAllFilms()
        {
            string url = base_url + getAllFilmsUrl;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FilmModel>>(result);
            }
        }

        public async Task<List<FilmModel>> GetTop10()
        {
            string url = base_url + getTop10Url;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FilmModel>>(result);
            }
        }

        public async Task<FilmModel> GetFilmById(int id)
        {
            string url = base_url + string.Format(getFilmByIdUrl, id);
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FilmModel>(result);
            }
        }

        public async Task<List<FilmModel>> GetFilteredFilms(string genre, int ratingLow, int ratingHigh, int yearLow, int yearHigh)
        {
            string url = base_url + string.Format(filterFilmUrl, genre, ratingLow, ratingHigh, yearLow, yearHigh);
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FilmModel>>(result);
            }
        }

        public async Task<Boolean> CreateFilm(FilmModel film)
        {
            string url = base_url + createFilmUrl;
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(film)));
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Boolean>(result);
            }
        }

        public async Task<Boolean> UpdateFilm(FilmModel film)
        {
            string url = base_url + string.Format(updateFilmUrl, film.Id);
            using (var client = new HttpClient())
            {
                var response = await client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(film)));
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Boolean>(result);
            }
        }

        public async Task<Boolean> DeleteFilm(int id)
        {
            string url = base_url + string.Format(deleteFilmUrl, id);
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Boolean>(result);
            }
        }
    }
}