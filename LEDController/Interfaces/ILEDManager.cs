using System.Threading.Tasks;
using LEDController.Dtos;
using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface ILEDManager
    {
        int LEDCount { get; }

        Task<bool> SendColor(RGBMessageDto rgbMessage);

        RGBMessageDto CreateMessage(DRColor.RGB[] input);
    }
}
