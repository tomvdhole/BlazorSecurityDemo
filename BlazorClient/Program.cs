using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorClient.Services;

namespace BlazorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = "https://localhost:5000/";
                options.ProviderOptions.ClientId = "blazor";
                options.ProviderOptions.DefaultScopes = new List<string> { "openid", "profile", "email", "weatherapi"};
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.PostLogoutRedirectUri = "/";

            });

            await builder.Build().RunAsync();
        }
    }
}
