using ZeusLibrary.Models;

namespace ZeusLibrary.Interfaces
{
    interface INextDay
    {
        string Day { get; set; }
        string Comment { get; set; }
        Temperature MaxTemp { get; set; }
        Temperature MinTemp { get; set; }
        string IconURL { get; set; }
    }
}
