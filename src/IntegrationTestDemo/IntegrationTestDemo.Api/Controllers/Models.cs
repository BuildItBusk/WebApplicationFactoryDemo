namespace IntegrationTestDemo.Api.Controllers;

public class CurrentUnits
{
    public string time { get; set; }
    public string interval { get; set; }
    public string temperature_2m { get; set; }
}

public class Current
{
    public string time { get; set; }
    public double temperature_2m { get; set; }
}

public class HourlyUnits
{
    public string time { get; set; }
    public string temperature_2m { get; set; }
}

public class Hourly
{
    public List<double> temperature_2m { get; set; }
}

public class WeatherResponse
{
    public double latitude { get; set; }
    public double longitude { get; set; }
    public CurrentUnits current_units { get; set; }
    public Current current { get; set; }
    public Hourly hourly { get; set; }
}