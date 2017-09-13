using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.Generators
{
    public class HueGenerator : IColorGenerator
    {
        private float hueAngle;
        private float saturation;
        private float brightness;
        private bool saturationSign;
        private bool brightnessSign;

        private const float saturationMin = 230.0f;
        private const float saturationMax = 256.0f;

        private const float brightnessMin = 0.0f;
        private const float brightnessMax = 256.0f;     

        public HueGenerator()
        {
            hueAngle = 0f;
            saturation = 256f;
            brightness = 256f;
            saturationSign = true;
            brightnessSign = true;
        }

        public MyColor.RGB getNextColor(MyColor.HSV hsv)
        {
            return getNextColor(hsv.Hue, hsv.Saturation, hsv.Value);
        }

        public MyColor.RGB getNextColor(float hueDelta, float saturationDelta, float brightnessDelta)
        {
            // Add or subtract delta based on flag state
            saturation = saturationSign ? saturation += saturationDelta : saturation -= saturationDelta;
            brightness = brightnessSign ? brightness += brightnessDelta : brightness -= brightnessDelta;

            // Flip flag state when borders hit
            if(saturation != saturation.Clamp(saturationMin, saturationMax))
            {
                saturationSign = !saturationSign;
            }
            if (brightness != brightness.Clamp(brightnessMin, brightnessMax))
            {
                brightnessSign = !brightnessSign;
            }

            saturation = saturation.Clamp(saturationMin, saturationMax);
            brightness = brightness.Clamp(brightnessMin, brightnessMax);
            hueAngle = (hueAngle + hueDelta) % 360;

            // Angle to 8 bit color
            var hue = hueAngle * 256 / 360;

            return new MyColor.RGB(new MyColor.HSV((int)hue, (int)saturation, (int)brightness));
        }

    }
}
