using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.Manager
{
    public class LedManager : ILedManager
    {
        public MyColor.RGB[] _State { get; }

        public int LEDCount { get; }

        public int LEDStripLength { get; } = 60;

        public int StripCount { get; }

        public LedManager(int ledCount, int stripCount)
        {
            LEDCount = ledCount;
            StripCount = stripCount;
            _State = new MyColor.RGB[ledCount];
        }

        public bool setColor(int strip, int pos, MyColor.RGB color)
        {
            if(pos >= LEDStripLength || pos < 0)
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
            if (pos > LEDCount || pos < 0)
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

            for(var i = 0; i < LEDCount; i++)
            {
                _State[i] = state[i] ?? MyColor.Off;
            }
            
            return true;
        }

        public bool fill(MyColor.RGB color)
        {
            for (var i = 0; i < LEDCount; i++)
            {
                _State[i] = color;
            }

            return true;
        }

        public bool clear()
        {
            return fill(MyColor.Off);
        }

    }
}
