using GetLocation.Abstraction;
using GetLocation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetLocationController : ControllerBase
    {
        private readonly IGeoIPService _geoIPService;
        private readonly HttpClient _httpClient;
        public GetLocationController(IGeoIPService geoIPService,HttpClient httpClient)
        {
                _geoIPService = geoIPService;
            _httpClient = httpClient;
        }

        [HttpGet(Name = "GetGeoIp")]
        public async Task< ActionResult<IpGeolocationResponse>> Get(string Ip)
        {
            var location= await _geoIPService.GetCountryAndCity(Ip);

            return Ok(location);
        }

    }
}
