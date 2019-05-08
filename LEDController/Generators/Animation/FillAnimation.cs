using LEDController.Interfaces;
using LEDController.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.Generators.Animation
{
    public class FillAnimation : AnimatorBase, IAnimator
    {
        public FillAnimation(ILedManager ledManager, IPaletteManager palette) : base(ledManager, palette)
        {

        }

        public MyColor.RGB[] getNextFrame()
        {
            ledManager.fill(palette.GetColor());
            return ledManager._State;
        }
    }
}
