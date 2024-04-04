using IntegrationTestDemo.Api.Controllers;
using System.Text.Json;

namespace IntegrationTestDemo.Api.HttpClients;

public class WeatherApiClient : IWeatherApiClient
{
    private const string BaseUri = "https://api.open-meteo.com/";
    private readonly HttpClient _client;

    public WeatherApiClient(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri(BaseUri);
    }

    public async Task<WeatherResponse?> GetWeatherForecast(string requestUrl)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(requestUrl, UriKind.Relative)
        };

        using var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();

        if (body is null)
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<WeatherResponse>(body);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
