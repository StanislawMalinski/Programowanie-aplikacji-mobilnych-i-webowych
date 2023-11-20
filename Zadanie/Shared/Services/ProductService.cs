 
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Shared;
using Shared.Configuration;
using Shared.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public ProductService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<ServiceResponse<Product>> CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.BaseProductEndpoint.GetAllProductsEndpoint, product);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Product>>();
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteProductAsync(int id)
        {
            // jesli uzyjemy / na poczatku to wtedy sciezka trakktowana jest od root czyli pomija czesc środkową adresu 
            // zazwyczaj unikamy stosowania / na poczatku 
            var response = await _httpClient.DeleteAsync($"{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return result;
        }

   


        //// skopiowane z postmana 
        //public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        //{
        //    //var client = new HttpClient();   
        //    var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseProductEndpoint.GetAllProductsEndpoint);
        //    var response = await _httpClient.SendAsync(request);
        //    response.EnsureSuccessStatusCode();        
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<List<Product>>>(json);
        //    return result;
        //}


        // alternatywny sposób pobierania danych 
        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_appSettings.BaseProductEndpoint.GetAllProductsEndpoint);
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Product>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<List<Product>>>(json)
                    ?? new ServiceResponse<List<Product>> { Success = false, Message = "Deserialization failed" };

                result.Success = result.Success && result.Data != null;

                return result;
            }
            catch (JsonException)
            {
                return new ServiceResponse<List<Product>>
                {
                    Success = false,
                    Message = "Cannot deserialize data"
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Product>>
                {
                    Success = false,
                    Message = "Network error"
                };
            }


        }

        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(id.ToString());
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse<Product>
                {
                    Success = false,
                    Message = "HTTP request failed"
                };

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Product>>(json)
                ?? new ServiceResponse<Product> { Success = false, Message = "Deserialization failed" };

            result.Success = result.Success && result.Data != null;

            return result;
        }


        // wersja 1 
        //public async Task<ServiceResponse<Product>> UpdateProductAsync(Product product)
        //{
        //    var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseProductEndpoint.GetAllProductsEndpoint, product);
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<Product>>(json);
        //    return result;
        //}

        // wersja 2 
        public async Task<ServiceResponse<Product>> UpdateProductAsync(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseProductEndpoint.GetAllProductsEndpoint, product);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Product>>();
            return result;
        }

        public async Task<ServiceResponse<List<Product>>> SearchProductsAsync(string text, int page, int pageSize)
        {

            try
            {
                string searchUrl = string.IsNullOrWhiteSpace(text) ? "" : $"/{text}";
                var response = await _httpClient.GetAsync(_appSettings.BaseProductEndpoint.SearchProductsEndpoint + searchUrl + $"/{page}/{pageSize}");
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Product>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<List<Product>>>(json)
                    ?? new ServiceResponse<List<Product>> { Success = false, Message = "Deserialization failed" };

                result.Success = result.Success && result.Data != null;

                return result;
            }
            catch (JsonException)
            {
                return new ServiceResponse<List<Product>>
                {
                    Success = false,
                    Message = "Cannot deserialize data"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new ServiceResponse<List<Product>>
                {
                    Success = false,
                    Message = "Network error"
                };
            }
        }
    }
}
