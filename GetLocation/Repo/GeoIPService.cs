using GetLocation.Abstraction;
using GetLocation.Models;
using System.Net.Http;
using System.Text.Json;

namespace GetLocation.Repo
{
    public class GeoIPService : IGeoIPService
    {
        private readonly HttpClient _httpClient=new HttpClient();
        private readonly string _apiKey = "bdc_5f8e57fb3cb84870bd92c86414f1ed2e";
        public GeoIPService()
        {
            
        }

        public async Task<IpGeolocationResponse> GetCountryAndCity(string ipAddress)
        {

            var url = $"https://api-bdc.net/data/ip-geolocation?ip={ipAddress}&localityLanguage=en&key={_apiKey}";

           var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var geoData = JsonSerializer.Deserialize<IpGeolocationResponse>(content);

                return geoData;
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve geolocation data. Status code: {response.StatusCode}");
            }
        }
    }
    }

