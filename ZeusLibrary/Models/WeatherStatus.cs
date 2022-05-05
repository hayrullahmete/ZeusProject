using System.Collections.Generic;
using ZeusLibrary.Interfaces;

namespace ZeusLibrary.Models
{
    public class WeatherStatus: IWeatherStatus
    {
        public string Region { get; set; }
        public CurrentConditions CurrentConditions { get; set; }
        public List<NextDay> NextDays { get; set; } = new();
    }
}
