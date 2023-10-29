using Film.Shared.Model;
using Film.Shared.Services;
using System.Threading.Tasks;

namespace Film.Shared.Services
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}