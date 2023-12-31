using System;
using System.Text;
using Newtonsoft.Json;


namespace WebApp.Components.Services
{
    public class ClientPost : IClientPost
    {
        private readonly ILogger<ClientPost> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ClientPost(HttpClient httpClient, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<ClientPost>();
            _httpClient.BaseAddress = new Uri(_configuration["URL:BaseURL"]);
        }

        public async Task<List<Post>> GetPosts(int page)
        {
            var url = _configuration["URL:Post:GetMain"].Replace("{page}", page.ToString());
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Post>>(result);
        }

        public async Task<int> GetMaxPage(){
            var url = _configuration["URL:Post:GetMainMaxPage"];
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(result);
        }
        public async Task<Post> PostPost(Post post)
        {
            var url = _configuration["URL:Post:Post"];
            var content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
            _logger.LogInformation("PostPost: " + JsonConvert.SerializeObject(post));
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("PostPost: " + result.ToString());
            return JsonConvert.DeserializeObject<Post>(result);
        }
        public async Task<List<Post>> GetPostsForUserProfiles(string userId, int page)
        {
            var url = _configuration["URL:Post:GetPostForUser"].Replace("{page}", page.ToString()).Replace("{id}", userId);
            var response = await _httpClient.GetAsync(url);
            Console.WriteLine(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Post>>(result);
        }

        public async Task<Post> GetPost(string id)
        {
            var url = _configuration["URL:Post:Get"].Replace("{id}", id);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Post>(result);
        }

        public async Task<Post> PutPost(Post post)
        {
            var url = _configuration["URL:Post:Put"];
            var content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Post>(result);
        }

        public async Task DeletePost(string id)
        {
            var url = _configuration["URL:Post:Delete"].Replace("{id}", id);
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
        }

        public async Task<int> GetMaxPageForUserProfiles(string userId)
        {
            var url = _configuration["URL:Post:GetMaxPostForUser"].Replace("{id}", userId);
            var response = _httpClient.GetAsync(url);
            response.Result.EnsureSuccessStatusCode();
            var result = response.Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(result.Result);
        }
    }
}
