using LEDController.Interfaces;
using LEDController.Utils;
using static LEDController.Utils.MyColor;

namespace LEDController.Manager
{
    public class LedManager : ILedManager
    {
        public RGB[] _State { get; }

        public int LEDCount { get; }

        public int StripLength { get; } = 60;

        public int StripCount { get; }

        public LedManager(int ledCount, int stripCount)
        {
            LEDCount = ledCount;
            _State = new RGB[LEDCount];
            StripCount = stripCount;
            clear();
        }

        public bool setColor(int strip, int pos, RGB color)
        {
            if(pos >= StripLength || pos < 0)
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

        public bool setColor(int pos, RGB color)
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

        public bool setColor(RGB[] state)
        {
            if (state == null)
                return false;

            for(var i = 0; i < LEDCount; i++)
            {
                _State[i] = state[i] ?? Off;
            }
            
            return true;
        }

        public bool fill(RGB color)
        {
            if (color == null)
                return false;

            for (var i = 0; i < LEDCount; i++)
            {
                _State[i] = color;
            }

            return true;
        }

        public bool mix(RGB color, double ratio = 0.5)
        {
            if (color == null)
                return false;

            for (var i = 0; i < LEDCount; i++)
            {
                var oldcolor = _State[i];
                var newcolor = new RGB(
                        weightedAverage(oldcolor.Red, color.Red, ratio),
                        weightedAverage(oldcolor.Green, color.Green, ratio),
                        weightedAverage(oldcolor.Blue, color.Blue, ratio)
                    );
                _State[i] = newcolor;
            }

            return true;
        }

        private int weightedAverage(int a, int b, double ratio)
        {
            return (int)(a * (1.0 - ratio) + b * ratio);
        }

        public bool clear()
        {
            return fill(Off);
        }

    }
}
