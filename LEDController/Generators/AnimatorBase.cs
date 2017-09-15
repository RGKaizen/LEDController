using LEDController.Interfaces;
using LEDController.Utils;
using System;
using System.Collections.Generic;

namespace LEDController.Generators
{
    public class AnimatorBase
    {
        protected ILedManager _LEDManager { get; set; }

        protected MyColor.RGB[] _ledState { get; set; }

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

        public AnimatorBase(ILedManager ledManager)
        {
            _LEDManager = ledManager;
            _ledState = RainbowUtils.createEmptyArray(ledManager.LEDCount);
            palette = new MyColor.RGB[1];
        }
    }
}
