using static LEDController.Utils.MyColor;

namespace LEDController.Interfaces
{
    public interface ILedClient
    {
        bool Send(RGB[] input);

        bool Send(RGB input);
    }
}