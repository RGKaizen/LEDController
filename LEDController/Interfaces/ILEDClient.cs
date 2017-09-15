using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface ILedClient
    {
        bool Send(MyColor.RGB[] input);

        bool Send(MyColor.RGB input);
    }
}