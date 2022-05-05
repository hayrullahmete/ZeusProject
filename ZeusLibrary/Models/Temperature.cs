using ZeusLibrary.Interfaces;

namespace ZeusLibrary.Models
{
    public class Temperature : ITemperature
    {
        public int C { get; set; }
        public int F { get; set; }
    }
}