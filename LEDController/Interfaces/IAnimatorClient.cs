using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface IAnimatorClient
    {
        int RefreshRate { get; set; }

        bool isRunning { get; }

        bool PlayPause();

        void Stop();

        MyColor.HSV hsvDelta { get; set; }

        void UpdateFillAnimation(IAnimator animator);
    }
}