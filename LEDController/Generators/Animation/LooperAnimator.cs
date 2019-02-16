using LEDController.Interfaces;
using LEDController.Utils;
using static LEDController.Utils.MyColor;

namespace LEDController.Generators
{
    public class LooperAnimator : AnimatorBase, IAnimator
    {
        private Dot dot1;
        private Dot dot2;

        public LooperAnimator(ILedManager ledManager, IPaletteManager palette) : base(ledManager, palette)
        {
            dot1 = new Dot
            {
                color = palette.GetColor(0),
                position = 0,
                direction = 1,
                strip = 1
            };
            dot2 = new Dot
            {
                color = palette.GetColor(1),
                position = 60,
                direction = -1,
                strip = 2
            };
        }

        public RGB[] getNextFrame()
        {
            dot1.color = palette.GetColor(0);
            dot2.color = palette.GetColor(1);

            dot1.position = dot1.position + 1 * dot1.direction;
            dot2.position = dot2.position + 1 * dot2.direction;

            ledManager.setColor(dot1.strip, dot1.position, dot1.color);
            ledManager.setColor(dot2.strip, dot2.position, dot2.color);
            ledManager.mix(MyColor.Off, 0.1);

            if (dot1.position == ledManager.StripLength / 2)
            {
                dot1.direction = -1;
                dot1.strip = 2;
            }
            if (dot1.position == 0)
            {
                dot1.direction = 1;
                dot1.strip = 1;
            }

            if (dot2.position == ledManager.StripLength / 2)
            {
                dot2.direction = 1;
                dot2.strip = 1;
            }
            if (dot2.position == ledManager.StripLength)
            {
                dot2.direction = -1;
                dot2.strip = 2;
            }

            return ledManager._State;
        }
    }

    class Dot
    {
         public RGB color { get; set; }

         public int position { get; set; }

         public int direction { get; set; }

         public int strip { get; set; }
    }
}
