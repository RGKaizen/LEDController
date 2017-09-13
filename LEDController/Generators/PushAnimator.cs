using LEDController.Interfaces;
using LEDController.Utils;
using System;
using System.Collections.Generic;

namespace LEDController.Generators
{
    public class PushAnimator : IAnimator
    {
        private ILEDManager _LEDManager { get; set; }

        private MyColor.RGB[] _ledState { get; set; }

        public PushAnimator(ILEDManager ledManager)
        {
            _LEDManager = ledManager;
            _ledState = RainbowUtils.createEmptyArray(ledManager.TotalLEDCount);
            palette = new MyColor.RGB[1];
        }

        private IList<MyColor.RGB> _palette;
        public IList<MyColor.RGB> palette
        {
            get => _palette;
            set
            {
                if (value == null)
                {
                    if (value == null) throw new ArgumentNullException("palette");
                }
                _palette = value;
            }
        }

        public MyColor.RGB[] getNextFrame()
        {
            _ledState[_LEDManager.TotalLEDCount / 2] = palette[0] ?? MyColor.Red;
            Push();
            return _ledState;
        }

        // Pushes from the center like this  <-- -->
        private void Push()
        {
            for (int i = 0; i < _LEDManager.TotalLEDCount / 2; i++)
            {
                int waveUp = i;
                int waveDown = _LEDManager.TotalLEDCount - 1 - i;
                _ledState[waveUp] = _ledState[waveUp + 1];
                _ledState[waveDown] = _ledState[waveDown - 1];
            }
        }
    }
}
