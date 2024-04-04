using IntegrationTestDemo.Api.Controllers;

namespace IntegrationTestDemo.Api.HttpClients
{
    public interface IWeatherApiClient
    {
        Task<WeatherResponse?> GetWeatherForecast(string requestUrl);
    }
}