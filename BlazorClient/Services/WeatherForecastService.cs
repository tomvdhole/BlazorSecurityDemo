using BlazorClient.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorClient.Services
{
    public class WeatherForecastService: IWeatherForecastService
    {
        private HttpClient HttpClient { get; set; }
        private IAccessTokenProvider TokenProvider { get; set; }

        public WeatherForecastService(HttpClient httpClient,
                                      IAccessTokenProvider tokenProvider)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            TokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        }

        public async Task<ApiResult<WeatherForecast[]>> GetForcasts()
        {
            var tokenRequest = await TokenProvider.RequestAccessToken();
            if (tokenRequest.TryGetToken(out var token))
            {
                HttpClient.DefaultRequestHeaders.Clear();
                HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.Value}");

                try //try catch needed for possible  error in javascript layer
                {
                    var response = await HttpClient.GetAsync("https://localhost:5002/WeatherForecast");
                    if (response.IsSuccessStatusCode)
                    {
                        return new ApiResult<WeatherForecast[]>
                        {
                            Content = await response.Content.ReadFromJsonAsync<WeatherForecast[]>(),
                            StatusCode = (int)response.StatusCode,
                            Error = string.Empty
                        };
                    }
                    else
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            return new ApiResult<WeatherForecast[]>
                            {
                                Content = null,
                                StatusCode = (int)response.StatusCode,
                                Error = "You are not authorized to get this info!"
                            };
                        }
                        else
                        {
                            return new ApiResult<WeatherForecast[]>
                            {
                                Content = null,
                                StatusCode = 500,
                                Error = "Server error!"
                            };
                        }
                    }
                }
                catch (Exception)
                {
                    return new ApiResult<WeatherForecast[]>
                    {
                        Content = null,
                        StatusCode = 500,
                        Error = "Server error!"
                    };
                }
            }
            else
            {
                return new ApiResult<WeatherForecast[]>
                {
                    Content = null,
                    StatusCode = 500,
                    Error = "Server error!"
                };
            }
        }
    }
}
