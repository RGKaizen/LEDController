using System;
using System.Drawing;

namespace LEDController.Utils
{
    public class MyColor
    {

        public class HSV
        {
            // All values are between 0 and 128.
            public int Hue;
            public int Saturation;
            public int Value;

            public HSV(int H = 1, int S = 1, int V = 1)
            {
                Hue = H;
                Saturation = S;
                Value = V;
            }

            public HSV(RGB rgb)
            {

                // In this function, R, G, and B values must be scaled 
                // to be between 0 and 1.
                // HSV.Hue will be angle value between 0 and 360, and 
                // HSV.Saturation and value are between 0 and 1.
                // The code must scale these to be between 0 and 255 for
                // the purposes of this application.
                double min;
                double max;
                double delta;

                double r = (double)rgb.Red / 256;
                double g = (double)rgb.Green/ 256;
                double b = (double)rgb.Blue / 256;

                double h;
                double s;
                double v;

                min = Math.Min(Math.Min(r, g), b);
                max = Math.Max(Math.Max(r, g), b);
                v = max;
                delta = max - min;
                if (max == 0 || delta == 0)
                {
                    // R, G, and B must be 0, or all the same.
                    // In this case, S is 0, and H is undefined.
                    // Using H = 0 is as good as any...
                    s = 0;
                    h = 0;
                }
                else
                {
                    s = delta / max;
                    if (r == max)
                    {
                        // Between Yellow and Magenta
                        h = (g - b) / delta;
                    }
                    else if (g == max)
                    {
                        // Between Cyan and Yellow
                        h = 2 + (b - r) / delta;
                    }
                    else
                    {
                        // Between Magenta and Cyan
                        h = 4 + (r - g) / delta;
                    }

                }
                // Scale height to be between 0 and 360. 
                // This may require adding 360, if the value
                // is negative.
                h *= 60;
                if (h < 0)
                {
                    h += 360;
                }

                // Scale to the requirements of this 
                // application. All values are between 0 and 255.
                Hue = (int)(h / 360 * 256);
                Saturation = (int)(s * 256);
                Value = (int)(v * 256);
            }

            public override string ToString()
            {
                return String.Format("({0}, {1}, {2})", Hue, Saturation, Value);
            }
        }

        public class RGB : IComparable<RGB>
        {
            private int _red;
            private int _green;
            private int _blue;

            #region Accessors
            public int Red
            {
                get { return _red; }
                set { _red = value.Clamp(0, 256); }
            }
            public int Green
            {
                get { return _green; }
                set { _green = value.Clamp(0,256); }
            }
            public int Blue
            {
                get { return _blue; }
                set { _blue = value.Clamp(0, 256); }
            }

            #endregion

            public RGB(int red = 0, int green = 0, int blue = 0)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }


            public RGB(Color c) : this(c.R, c.G, c.B)
            {
            }

            public int CompareTo(RGB other)
            {

                if(other == null)
                {
                    return 1;
                }

                if (Red < other.Red)
                    return 1;
                else if (Red > other.Red)
                    return -1;
                else
                {
                    if (Green < other.Green)
                        return 1;
                    else if (Green > other.Green)
                        return -1;
                    else
                    {
                        if (Blue < other.Blue)
                            return 1;
                        else if (Blue > other.Blue)
                            return -1;
                    }
                }

                return 0;
            }

            public override string ToString()
            {
                return $"{Red}, {Green}, {Blue}";
            }
        }

        public static readonly RGB Red = new RGB(256, 0, 0);
        public static readonly RGB Green = new RGB(0, 256, 0);
        public static readonly RGB Blue = new RGB(0, 0, 256);
        public static readonly RGB Off = new RGB(1, 0, 0);

    }
}