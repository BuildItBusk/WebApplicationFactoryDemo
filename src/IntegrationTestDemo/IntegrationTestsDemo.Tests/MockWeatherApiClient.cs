using IntegrationTestDemo.Api.Controllers;
using IntegrationTestDemo.Api.HttpClients;

namespace IntegrationTestsDemo.Tests;

internal class MockWeatherApiClient : IWeatherApiClient
{
    public MockWeatherApiClient(HttpClient client)
    {
        // We need the constructor to be able to insatiate the class as an HttpClient.
        _ = client;
    }

    Task<WeatherResponse?> IWeatherApiClient.GetWeatherForecast(string requestUrl)
    {
        WeatherResponse? result = new()
        {
            latitude = 42.0000,
            longitude = 3.1415,
            current_units = new CurrentUnits
            {
                time = "s",
                interval = "1h",
                temperature_2m = "C"
            },
            current = new Current
            {
                time = "2022-01-01T00:00:00Z",
                temperature_2m = 10.0
            },
            hourly = new Hourly
            {
                temperature_2m = [10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0, 21.0, 22.0, 23.0, 24.0, 25.0, 26.0, 27.0, 28.0, 29.0, 30.0, 31.0, 32.0, 33.0]
            }
        };

        return Task.FromResult<WeatherResponse?>(result);
    }
}
