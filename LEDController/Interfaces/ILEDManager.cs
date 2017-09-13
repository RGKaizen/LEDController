using LEDController.Utils;

namespace LEDController.Interfaces
{
    public interface ILEDManager
    {
        MyColor.RGB[] _State { get; }

        int TotalLEDCount { get; }

        int LEDStripLength { get; }

        int StripCount { get; }

        bool setColor(int strip, int pos, MyColor.RGB color);

        bool setColor(int pos, MyColor.RGB color);

        bool setColor(MyColor.RGB[] state);
    }
}
