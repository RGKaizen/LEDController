using LEDController.Dtos;
using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface ILEDManager
    {
        int TotalLEDCount { get; }

        int LEDStripLength { get; }

        bool SendRGBMessage(RGBMessageDto rgbMessage);

        RGBMessageDto CreateMessage(MyColor.RGB[] input);

        RGBMessageDto CreateMessage(MyColor.RGB input);
    }
}
