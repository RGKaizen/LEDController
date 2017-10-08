using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface IAnimator
    {
        IPaletteManager palette { get; set; }

        MyColor.RGB[] getNextFrame();
    }
}