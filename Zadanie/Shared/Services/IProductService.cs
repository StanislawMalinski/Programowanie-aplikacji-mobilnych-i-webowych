using Shared;
using Shared.Shop;

namespace Shared.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();

        Task<ServiceResponse<Product>> UpdateProductAsync(Product product);

        Task<ServiceResponse<bool>> DeleteProductAsync(int id);

        Task<ServiceResponse<Product>> CreateProductAsync(Product product);

        Task<ServiceResponse<Product>> GetProductByIdAsync(int id);

        Task<ServiceResponse<List<Product>>> SearchProductsAsync(string text, int page, int pageSize);
    }
}
