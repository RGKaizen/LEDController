using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface ILedManager
    {
        MyColor.RGB[] _State { get; }

        int LEDCount { get; }

        int LEDStripLength { get; }

        int StripCount { get; }

        bool setColor(int strip, int pos, MyColor.RGB color);

        bool setColor(int pos, MyColor.RGB color);

        bool setColor(MyColor.RGB[] state);

        bool clear();

        bool fill(MyColor.RGB color);

        bool mix(MyColor.RGB color, double ratio);
    }
}
