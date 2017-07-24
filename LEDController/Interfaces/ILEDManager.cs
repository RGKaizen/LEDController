using System.Threading.Tasks;
using LEDController.Dtos;
using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface ILEDManager
    {
        int TotalLEDCount { get; }

        int StripLength { get; }

        bool SendRGBMessage(RGBMessageDto rgbMessage);

        RGBMessageDto CreateMessage(DRColor.RGB[] input);

        RGBMessageDto CreateMessage(DRColor.RGB input);
    }
}
