﻿using BlazorClient.Shared;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Services
{
    interface IWeatherForecastService
    {
        Task<ApiResult<WeatherForecast[]>> GetForcasts();
    }
}
