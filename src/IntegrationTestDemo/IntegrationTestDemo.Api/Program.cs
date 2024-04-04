using IntegrationTestDemo.Api.HttpClients;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
{
    builder.Services.AddHttpClient<IWeatherApiClient,WeatherApiClient>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

// This allows access for the IntegrationTestDemo.Api project to the Program class.
public partial class Program { }