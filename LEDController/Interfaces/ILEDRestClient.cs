using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface ILEDRestClient
    {
        bool Send(MyColor.RGB[] input);

        bool Send(MyColor.RGB input);
    }
}