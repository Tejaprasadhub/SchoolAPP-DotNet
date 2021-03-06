﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTS.API.AdminAPP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTS.API.Security.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController3 : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController3> _logger;

        public WeatherForecastController3(ILogger<WeatherForecastController3> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
