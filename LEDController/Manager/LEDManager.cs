using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.Manager
{
    public class LedManager : ILedManager
    {
        public MyColor.RGB[] _State { get; }

        public int LEDCount { get; }

        public int StripLength { get; } = 60;

        public int StripCount { get; }

        public LedManager(int ledCount, int stripCount)
        {
            LEDCount = ledCount;
            _State = new MyColor.RGB[LEDCount];
            StripCount = stripCount;
            clear();
        }

        public bool setColor(int strip, int pos, MyColor.RGB color)
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
            if (color == null)
                return false;

            for (var i = 0; i < LEDCount; i++)
            {
                _State[i] = color;
            }

            return true;
        }

        public bool mix(MyColor.RGB color, double ratio = 0.5)
        {
            if (color == null)
                return false;

            for (var i = 0; i < LEDCount; i++)
            {
                var oldcolor = _State[i];
                var newcolor = new MyColor.RGB(
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
            return fill(MyColor.Off);
        }

    }
}
