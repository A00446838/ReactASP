using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ReactASP.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static HttpClient client = new HttpClient();

        private readonly IHttpClientFactory _httpClientFactory;


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        /*public async Task<ActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetStringAsync("https://dummyjson.com/products");
            Console.WriteLine("************************");
            Console.WriteLine(result);
            Console.WriteLine("************************");
            return Ok(result);
        }*/

        
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
