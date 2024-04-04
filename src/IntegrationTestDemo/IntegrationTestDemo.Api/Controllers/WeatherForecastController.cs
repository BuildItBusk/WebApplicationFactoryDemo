using IntegrationTestDemo.Api.HttpClients;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private const string RequestUrl = @"v1/forecast?latitude=55.8674&longitude=12.4952&current=temperature_2m&hourly=temperature_2m&wind_speed_unit=ms&forecast_days=1";
    private readonly IWeatherApiClient _weatherApiClient;

    public WeatherForecastController(IWeatherApiClient weatherApiClient)
    {
        _weatherApiClient = weatherApiClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await 
            _weatherApiClient.GetWeatherForecast(RequestUrl) is WeatherResponse weatherResponse
            ? Ok(weatherResponse)
            : NotFound();
    }
}