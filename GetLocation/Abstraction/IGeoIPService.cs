using GetLocation.Models;

namespace GetLocation.Abstraction
{
    public interface IGeoIPService
    {
        public Task<IpGeolocationResponse> GetCountryAndCity(string ipAddress);
    }
}
