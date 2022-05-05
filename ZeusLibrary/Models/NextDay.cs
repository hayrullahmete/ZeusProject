using ZeusLibrary.Interfaces;

namespace ZeusLibrary.Models
{
    public class NextDay : INextDay
    {
        public string Day { get; set; }
        public string Comment { get; set; }
        public Temperature MaxTemp { get; set; }
        public Temperature MinTemp { get; set; }
        public string IconURL { get; set; }
    }
}