﻿using LEDController.Interfaces;
using LEDController.Utils;
using System;
using static LEDController.Utils.MyColor;

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

        private HSV _hsv;
        public HSV hsvDelta { get; set; }

        public HueGenerator()
        {
            _hsv = new HSV(0, 256, 256);
            saturationSign = true;
            brightnessSign = true;

            hsvDelta = new HSV();
        }

        public RGB getNextColor()
        {
            // Add or subtract delta based on flag state
            _hsv.Saturation = saturationSign 
                ? _hsv.Saturation + hsvDelta.Saturation 
                : _hsv.Saturation - hsvDelta.Saturation;

            _hsv.Value = brightnessSign 
                ? _hsv.Value + hsvDelta.Value 
                : _hsv.Value - hsvDelta.Value;

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
            _hsv.Hue = (_hsv.Hue + hsvDelta.Hue) % 256; // [0 - 360] => [0 - 256]

            return _hsv.toRGB();
        }

        public RGB getNextColor(HSV hsvDelta)
        {
            this.hsvDelta = hsvDelta;
            return getNextColor();
        }

    }
}
