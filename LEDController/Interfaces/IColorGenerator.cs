using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface IColorGenerator
    {
        MyColor.RGB getNextColor(float hueDelta, float saturationDelta, float brightnessDelta);

        MyColor.RGB getNextColor(MyColor.HSV hsvDelta);
    }
}
