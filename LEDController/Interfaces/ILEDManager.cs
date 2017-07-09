using System.Threading.Tasks;
using LEDController.Dtos;
using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface ILEDManager
    {
        int LEDCount { get; }

        bool SendColor(RGBMessageDto rgbMessage);

        RGBMessageDto CreateMessage(DRColor.RGB[] input);

        RGBMessageDto CreateMessage(DRColor.RGB input);
    }
}
