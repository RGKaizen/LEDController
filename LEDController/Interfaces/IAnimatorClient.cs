using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface IAnimatorClient
    {
        int RefreshRate { get; set; }

        bool isRunning { get; }

        bool PlayPause();

        MyColor.HSV hsvDelta { get; set; }
    }
}