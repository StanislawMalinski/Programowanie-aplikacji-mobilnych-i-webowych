using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Film.Shared.Model;
using Film.Shared.Services;

namespace Film.Client.Tests
{
    [TestClass]
    public class FilmControllerTests
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly AppSettings _settings = new AppSettings("appsettings.json");

        [TestMethod]
        public void GetMain_ReturnsSuccessStatusCode()
        {
            // given
            var address = _settings.Domain + _settings.GetMain;

            // when
            var response = await _client.GetAsync(address);

            // then
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public void GetById_ReturnsSuccessStatusCode()
        {
            // given
            var id = 1;
            var address = _settings.Domain + string.Format(_settings.GetFilmById, id);

            // when
            var response = await _client.GetAsync(address);

            // then
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public void GetById_ReturnsNotFoundStatusCode()
        {
            // given
            var id = 999;
            var address = _settings.Domain + string.Format(_settings.GetFilmById, id);

            // when
            var response = await _client.GetAsync(address);

            // then
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void Create_ReturnsSuccessStatusCode()
        {
            // given
            var film = new FilmModel()
            {
                Title = "Test Film",
                ReleaseYear = 2021,
                Director = "Test Director",
                Genre = "Test Genre"
            };
            var address = _settings.Domain + _settings.CreateFilm;
            var request = new HttpRequestMessage(HttpMethod.Post, address)
            {
                Content = new StringContent(JsonConvert.SerializeObject(film), System.Text.Encoding.UTF8, "application/json")
            };

            // when
            var response = await _client.SendAsync(request);

            // then
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public void Update_ReturnsSuccessStatusCode()
        {
            // given
            var id = 1;
            var film = new FilmModel()
            {
                Title = "Updated Test Film",
                ReleaseYear = 2021,
                Director = "Updated Test Director",
                Genre = "Updated Test Genre"
            };
            var address = _settings.Domain + string.Format(_settings.UpdateFilm, id);
            var request = new HttpRequestMessage(HttpMethod.Put, address);
            {
                Content = new StringContent(JsonConvert.SerializeObject(film), System.Text.Encoding.UTF8, "application/json");
            };

            // when
            var response = await _client.SendAsync(request);

            // then
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public void Delete_ReturnsSuccessStatusCode()
        {
            // given
            var id = 1;
            var address = _settings.Domain + string.Format(_settings.DeleteFilm, id);
            var request = new HttpRequestMessage(HttpMethod.Delete, address);
            
            // when
            var response = await _client.SendAsync(request);

            // then
            response.EnsureSuccessStatusCode();
        }
    }
}
