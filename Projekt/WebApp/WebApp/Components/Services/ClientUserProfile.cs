    using System.Net.Http;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;
    using System.Text;
    using Newtonsoft.Json;

    namespace WebApp.Components.Services
    {
        public class ClientUserProfile : IClientUserProfile
        {

            private readonly HttpClient _httpClient;
            private readonly IConfiguration _configuration;

            public ClientUserProfile(HttpClient httpClient, IConfiguration configuration)
            {
                _httpClient = httpClient;
                _configuration = configuration;
                _httpClient.BaseAddress = new Uri(_configuration["URL:BaseURL"]);
            }

            public async Task<UserProfile> PostUserProfile(UserProfile userProfile)
            {
                var url = _configuration["URL:UserProfile:Post"];
                var content = new StringContent(JsonConvert.SerializeObject(userProfile), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserProfile>(result);
            }

            public async Task<UserProfile> GetUserProfile(string id)
            {
                var url = _configuration["URL:UserProfile:Get"].Replace("{id}", id);
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserProfile>(result);
            }

            public async Task<UserProfile> PutUserProfile(string id, UserProfile userProfile)
            {
                var url = _configuration["URL:UserProfile:Put"].Replace("{id}", id);
                var content = new StringContent(JsonConvert.SerializeObject(userProfile), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserProfile>(result);
            }

            public async Task<Boolean> DeleteUserProfile(string id)
            {
                var url = _configuration["URL:UserProfile:Delete"].Replace("{id}", id);
                var response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Boolean>(result);
            }
        }
    }
