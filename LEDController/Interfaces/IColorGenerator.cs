using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface IColorGenerator
    {
        MyColor.RGB getNextColor();

        MyColor.HSV hsvDelta { get; set; }
    }
}
