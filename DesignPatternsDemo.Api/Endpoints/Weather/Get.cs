using DesignPatternsDemo.Api.Endpoints.Weather.Models;
using FastEndpoints;

namespace DesignPatternsDemo.Api.Endpoints.Weather;

public class Get : EndpointWithoutRequest<List<WeatherForecastResponse>>
{
    public override void Configure()
    {
        Get("/weatherforecast");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastResponse
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToList();
        
        await SendAsync(forecast, cancellation: ct);
    }
}