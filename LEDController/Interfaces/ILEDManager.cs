using System.Threading.Tasks;
using LEDController.Dtos;
namespace LEDController.Interfaces
{
    public interface ILEDManager
    {
        Task<bool> SendColor(RGBMessageDto rgbMessage);
    }
}
