using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface IHueGenerator
    {
        MyColor.HSV getNextColor(float hueDelta, float saturationDelta, float brightnessDelta);
    }
}
