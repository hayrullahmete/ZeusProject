using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using ZeusLibrary.Models;

namespace ZeusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherStatusController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public WeatherStatusController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET: api/<WeatherStatusController>
        [HttpGet]
        public IActionResult Get([FromQuery] string cityName)
        {
            WeatherStatus weatherStatus = new();

            try
            {
                string resp = ZeusLibrary.Infra.GetResponse($"{Configuration.GetValue<string>("ExternalAPIBaseUrl")}/{cityName}", out Exception outException);
                JObject joResp = JObject.Parse(resp);
                weatherStatus.Region = joResp["region"].ToString();
                if (joResp.ContainsKey("currentConditions"))
                    if (joResp["currentConditions"] != null)
                    {
                        weatherStatus.CurrentConditions = new()
                        {
                            Comment = joResp["currentConditions"]["comment"].ToString(),
                            Precip = joResp["currentConditions"]["precip"].ToString(),
                            Humidity = joResp["currentConditions"]["humidity"].ToString(),
                            IconURL = joResp["currentConditions"]["iconURL"].ToString(),
                            Temp = new()
                            {
                                C = (int)joResp["currentConditions"]["temp"]["c"],
                                F = (int)joResp["currentConditions"]["temp"]["f"]
                            },
                            Wind = new()
                            {
                                Km = (int)joResp["currentConditions"]["wind"]["km"],
                                Mile = (int)joResp["currentConditions"]["wind"]["mile"]
                            },
                            DayHour = joResp["currentConditions"]["dayhour"].ToString(),
                        };

                        joResp["next_days"].ToList().ForEach(nd =>
                        {
                            weatherStatus.NextDays.Add(new()
                            {
                                Day = nd["day"].ToString(),
                                IconURL = nd["iconURL"].ToString(),
                                Comment = nd["comment"].ToString(),
                                MinTemp = new()
                                {
                                    C = (int)nd["min_temp"]["c"],
                                    F = (int)nd["min_temp"]["f"]
                                },
                                MaxTemp = new()
                                {
                                    C = (int)nd["max_temp"]["c"],
                                    F = (int)nd["max_temp"]["f"]
                                }
                            });
                        });
                    }
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

            return Ok(weatherStatus);
        }
    }
}
