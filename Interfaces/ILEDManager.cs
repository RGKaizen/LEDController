using System.Threading.Tasks;
using DoubleRainbow.Dtos;
namespace DoubleRainbow.Interfaces
{
    public interface ILEDManager
    {
        Task<bool> SendColor(RGBMessageDto rgbMessage);
    }
}
