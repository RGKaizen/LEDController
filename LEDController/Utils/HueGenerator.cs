using LEDController.Interfaces;

namespace LEDController.Utils
{
    public class HueGenerator : IHueGenerator
    {
        // Functions
        private float hueAngle;
        private float saturation;
        private float value;
        private bool saturationSign;
        private bool valueSign;

        private const float saturationMax = 256.0f;
        private const float valueMax = 256.0f;

        private const float saturationMin = 0.0f;
        private const float valueMin = 0.0f;

        public HueGenerator(float startHue, float startSaturation, float startValue)
        {
            hueAngle = startHue;
            saturation = startSaturation;
            value = startValue;
            saturationSign = true;
            valueSign = true;
        }

        public DRColor.HSV getNextColor(float hueDelta, float saturationDelta, float valueDelta)
        {
            // Add or subtract delta based on flag state
            saturation = saturationSign ? saturation += saturationDelta : saturation -= saturationDelta;
            value = valueSign ? value += valueDelta : value -= valueDelta;

            // Flip flag state when borders hit
            if(saturation > saturationMax || saturation <= saturationMin)
            {
                saturationSign = !saturationSign;
            }
            if (value > valueMax || value <= valueMin)
            {
                valueSign = !valueSign;
            }

            saturation = saturation.Clamp(saturationMin, saturationMax);
            value = value.Clamp(valueMin, valueMax);
            hueAngle = (hueAngle + hueDelta) % 360;

            // Angle to 8 bit color
            var hue = hueAngle * 256 / 360;

            return new DRColor.HSV((int)hue, (int)saturation, (int)value);
        }

    }
}
