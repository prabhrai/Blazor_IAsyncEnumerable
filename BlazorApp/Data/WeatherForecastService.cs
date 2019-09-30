using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async IAsyncEnumerable<WeatherForecast> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();

            for (int i = 0; i < 10; i++)
            {
                yield return await CreateSampleWeatherForecastAsAsync(startDate, i, rng);
            }

        }

        private static async Task<WeatherForecast> CreateSampleWeatherForecastAsAsync(DateTime startDate, int index, Random rng)
        {
            await Task.Delay(1000);

            return new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }
}
