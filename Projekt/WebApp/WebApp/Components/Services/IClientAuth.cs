using Models;

namespace WebApp.Components.Services
{
    public interface IClientAuth
    {
        public Task<LoginResponse> Login(LoginRequest request);
        public Task<LoginResponse> Register(RegisterRequest request);
    }
}