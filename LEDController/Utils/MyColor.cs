using System;

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

            public HSV(int H, int S, int V)
            {
                Hue = H;
                Saturation = S;
                Value = V;
            }

            public HSV(MyColor.RGB rgb)
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
                set { value.Clamp(0, 256); }
            }
            public int Green
            {
                get { return _green; }
                set { value.Clamp(0,256); }
            }
            public int Blue
            {
                get { return _blue; }
                set { value.Clamp(0, 256); }
            }

            #endregion

            public RGB(int red = 0, int green = 0, int blue = 0)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }

            public RGB(HSV hsv)
            {
                if (hsv == null)
                {
                    _red = 0;
                    _green = 0;
                    _blue = 0;
                    return;
                }

                // HSV contains values scaled as in the color wheel:
                // that is, all from 0 to 128. 

                // for ( this code to work, HSV.Hue needs
                // to be scaled from 0 to 360 (it//s the angle of the selected
                // point within the circle). HSV.Saturation and HSV.value must be 
                // scaled to be between 0 and 1.

                double h;
                double s;
                double v;

                double r = 0;
                double g = 0;
                double b = 0;

                // Scale Hue to be between 0 and 360. Saturation
                // and value scale to be between 0 and 1.
                h = ((double)hsv.Hue / 256 * 360) % 360;
                s = (double)hsv.Saturation / 256;
                v = (double)hsv.Value / 256;

                if (s == 0)
                {
                    // If s is 0, all colors are the same.
                    // This is some flavor of gray.
                    r = v;
                    g = v;
                    b = v;
                }
                else
                {
                    double p;
                    double q;
                    double t;

                    double fractionalSector;
                    int sectorNumber;
                    double sectorPos;

                    // The color wheel consists of 6 sectors.
                    // Figure out which sector you//re in.
                    sectorPos = h / 60;
                    sectorNumber = (int)(Math.Floor(sectorPos));

                    // get the fractional part of the sector.
                    // That is, how many degrees into the sector
                    // are you?
                    fractionalSector = sectorPos - sectorNumber;

                    // Calculate values for the three axes
                    // of the color. 
                    p = v * (1 - s);
                    q = v * (1 - (s * fractionalSector));
                    t = v * (1 - (s * (1 - fractionalSector)));

                    // Assign the fractional colors to radius_norm, _g, and b
                    // based on the sector the angle is in.
                    switch (sectorNumber)
                    {
                        case 0:
                            r = v;
                            g = t;
                            b = p;
                            break;

                        case 1:
                            r = q;
                            g = v;
                            b = p;
                            break;

                        case 2:
                            r = p;
                            g = v;
                            b = t;
                            break;

                        case 3:
                            r = p;
                            g = q;
                            b = v;
                            break;

                        case 4:
                            r = t;
                            g = p;
                            b = v;
                            break;

                        case 5:
                            r = v;
                            g = p;
                            b = q;
                            break;
                    }
                }
                // return an RGB structure, with values scaled
                // to be between 0 and 255.
                Red = (int)(r * 256);
                Green = (int)(g * 256);
                Blue = (int)(b * 256);
            }

            public RGB(System.Drawing.Color c) : this(c.R, c.G, c.B)
            {
            }

            public int CompareTo(RGB other)
            {
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

        public static System.Drawing.Color HSVtoColor(HSV hsv)
        {
            if (hsv == null)
                return System.Drawing.Color.Blue;

            RGB RGB = new RGB(hsv);
            return System.Drawing.Color.FromArgb(RGB.Red, RGB.Green, RGB.Blue);
        }

        public static System.Drawing.Color RGBtoColor(RGB rgb)
        {
            return System.Drawing.Color.FromArgb(rgb.Red, rgb.Green, rgb.Blue);
        }

        public static readonly RGB Red = new RGB(256, 0, 0);
        public static readonly RGB Green = new RGB(0, 256, 0);
        public static readonly RGB Blue = new RGB(0, 0, 256);
        public static readonly RGB Off = new RGB(1, 0, 0);

    }
}