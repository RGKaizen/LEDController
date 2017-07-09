using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface IHueGenerator
    {
        DRColor.HSV getNextColor(float hue_delta, float sat_delta, float value_delta);
    }
}
