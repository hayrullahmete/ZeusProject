using ZeusLibrary.Models;

namespace ZeusLibrary.Interfaces
{
    interface ICondition
    {
        string DayHour { get; set; }
        Temperature Temp { get; set; }
        string Precip { get; set; }
        string Humidity { get; set; }
        Wind Wind { get; set; }
        string IconURL { get; set; }
        string Comment { get; set; }
    }
}
