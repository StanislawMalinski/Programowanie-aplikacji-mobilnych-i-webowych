using System.Text;
using Models;
using Newtonsoft.Json;

namespace WebApp.Components.Services
{
    public class ClientAuth : IClientAuth
    {
        private readonly ILogger<ClientAuth> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ClientAuth(HttpClient httpClient, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<ClientAuth>();
            _httpClient.BaseAddress = new Uri(_configuration["URL:BaseURL"]);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            _logger.LogInformation("Login request: " + request.ToString());
            var url = _configuration["URL:Auth:Login"];
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponse>(result);
        }

        public async Task<LoginResponse> Register(RegisterRequest request)
        {
            _logger.LogInformation("Register request: " + request.ToString());
            var url = _configuration["URL:Auth:Register"];
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponse>(result);
        }
    }


}