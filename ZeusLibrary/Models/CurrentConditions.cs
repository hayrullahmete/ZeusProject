using ZeusLibrary.Interfaces;

namespace ZeusLibrary.Models
{
    public class CurrentConditions : ICondition
    {
        public string DayHour { get; set; }
        public Temperature Temp { get; set; }
        public string Precip { get; set; }
        public string Humidity { get; set; }
        public Wind Wind { get; set; }
        public string IconURL { get; set; }
        public string Comment { get; set; }
    }
}