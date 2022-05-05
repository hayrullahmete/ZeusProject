using ZeusLibrary.Interfaces;

namespace ZeusLibrary.Models
{
    public class Wind : IWind
    {
        public int Km { get; set; }
        public int Mile { get; set; }
    }
}