using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P05WeatherForecastAPI.ClientExtended.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P05WeatherForecastAPI.ClientExtended.Services
{
    internal class AccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";
        private const string IP_address_search_endpoint = "/locations/v1/cities/ipaddress?apikey={0}&q={1}&language{2}";
        private const string geoposition_endpoint = "/locations/v1/cities/geoposition/search?apikey={0}&q={1}&language{2}";

        // private const string api_key = "5hFl75dja3ZuKSLpXFxUzSc9vXdtnwG5";
        string api_key;
        //private const string language = "pl";
        string language;

        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json"); 

            var configuration = builder.Build();
            api_key = configuration["api_key"];
            language = configuration["default_language"];
        }


        public async Task<City> GetCurrentLocationFromIP(string IP)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, IP, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City city = JsonConvert.DeserializeObject<City>(json);
                return city;
            }
        }

        public async Task<City> GetCurrentLocationFromGeoposition(string geoposition)
        {
            string uri = base_url + "/" + string.Format(geoposition_endpoint, api_key, geoposition, language);
            using (HttpClient client = new HttpClient())
            {   
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City city = JsonConvert.DeserializeObject<City>(json);
                return city;
            }
        }

        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key,language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers= JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }
    }
}
