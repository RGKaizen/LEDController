using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.Manager
{
    public class LEDManager : ILEDManager
    {
        public MyColor.RGB[] _State { get; }

        public int TotalLEDCount { get; }

        public int LEDStripLength { get; } = 60;

        public int StripCount { get; }

        public LEDManager(int ledCount, int stripCount)
        {
            TotalLEDCount = ledCount;
            StripCount = stripCount;
        }

        public bool setColor(int strip, int pos, MyColor.RGB color)
        {
            if(pos > LEDStripLength || pos < 0)
            {
                return false;
            }
            if (strip > StripCount || strip < 0)
            {
                return false;
            }
            if(color == null)
            {
                return false;
            }
            _State[(strip - 1) * 60 + pos] = color;
            return true;
        }

        public bool setColor(int pos, MyColor.RGB color)
        {
            if (pos > TotalLEDCount || pos < 0)
            {
                return false;
            }
            if (color == null)
            {
                return false;
            }
            _State[pos] = color;
            return true;
        }

        public bool setColor(MyColor.RGB[] state)
        {
            if (state == null)
                return false;

            for(var i = 0; i < TotalLEDCount; i++)
            {
                _State[i] = state[i] ?? MyColor.Off;
            }
            
            return true;
        }

    }
}
