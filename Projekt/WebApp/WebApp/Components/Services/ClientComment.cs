using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace WebApp.Components.Services
{
    public class ClientComment : IClientComment
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ClientComment(HttpClient httpClient, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _httpClient.BaseAddress = new Uri(_configuration["URL:BaseURL"]);
        }

        //###Comments###
        public async Task<Comment> PostComment(Comment comment)
        {
            var url = _configuration["URL:Comment:Post"];
            var content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Comment>(result);
        }

        public async Task<Comment> GetComment(string id)
        {
            var url = _configuration["URL:Comment:Get"].Replace("{id}", id);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Comment>(result);
        }

        public async Task<List<Comment>> GetCommentsForPost(string id)
        {
            var url = _configuration["URL:Comment:GetAll"].Replace("{id}", id);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Comment>>(result);
        }

        public async Task<Boolean> DeleteComment(string id)
        {
            var url = _configuration["URL:Comment:Delete"].Replace("{id}", id);
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Boolean>(result);
        }

        public async Task<Comment> PutComment(Comment comment)
        {
            var url = _configuration["URL:Comment:Put"];
            var content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Comment>(result);
        }
    }
}