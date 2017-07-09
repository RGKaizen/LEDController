using System;

namespace LEDController.Utils
{
    public static class Globals
    {
        // Number of leds on each strip
        public const int KaiLength = 60;
        public const int ZenLength = 60;

        // Functions
        public static Random n = new Random();
        public static DRColor.RGB randomRGB()
        {

            int r = n.Next(256);
            int g = n.Next(256);
            int b = n.Next(256);
            if (r > 80)
                g /= 3;
            if (g > 50)
                r /= 4;
            if (b > 70)
            {
                g /= 3;
            }

            return new DRColor.RGB(r / 4, g / 4, b / 4);
        }
    }
}
