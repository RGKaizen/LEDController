using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.Generators
{
    public class HueGenerator : IColorGenerator
    {
        private bool saturationSign;
        private bool brightnessSign;

        private const int saturationMin = 230;
        private const int saturationMax = 256;

        private const int brightnessMin = 0;
        private const int brightnessMax = 256;

        private MyColor.HSV _hsv;
        public MyColor.HSV hsvDelta { get; set; }

        public HueGenerator()
        {
            _hsv = new MyColor.HSV(0, 256, 256);
            saturationSign = true;
            brightnessSign = true;

            hsvDelta = new MyColor.HSV();
        }

        public MyColor.RGB getNextColor()
        {
            // Add or subtract delta based on flag state
            _hsv.Saturation = saturationSign ? _hsv.Saturation += hsvDelta.Saturation : _hsv.Saturation -= hsvDelta.Saturation;
            _hsv.Value = brightnessSign ? _hsv.Value += hsvDelta.Value : _hsv.Value -= hsvDelta.Value;

            // Flip flag state when borders hit
            if (_hsv.Saturation != _hsv.Saturation.Clamp(saturationMin, saturationMax))
            {
                saturationSign = !saturationSign;
            }
            if (_hsv.Value != _hsv.Value.Clamp(brightnessMin, brightnessMax))
            {
                brightnessSign = !brightnessSign;
            }

            _hsv.Saturation = _hsv.Saturation.Clamp(saturationMin, saturationMax);
            _hsv.Value = _hsv.Value.Clamp(brightnessMin, brightnessMax);
            _hsv.Hue = (_hsv.Hue + hsvDelta.Hue) % 360 * 256 / 360; // [0 - 360] => [0 - 256]

            return new MyColor.RGB(_hsv);
        }

        public MyColor.RGB getNextColor(MyColor.HSV hsvDelta)
        {
            this.hsvDelta = hsvDelta;
            return getNextColor();
        }

    }
}
