using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusLibrary.Models;

namespace ZeusLibrary.Interfaces
{
    interface IWeatherStatus
    {
        string Region { get; set; }
        CurrentConditions CurrentConditions { get; set; }
        List<NextDay> NextDays { get; set; }
    }
}
