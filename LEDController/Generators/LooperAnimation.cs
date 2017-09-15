using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.Generators
{
    public class LooperAnimator : AnimatorBase, IAnimator
    {
        private Dot dot1;
        private Dot dot2;

        public LooperAnimator(ILedManager ledManager) : base(ledManager)
        {
            palette = new MyColor.RGB[2];
            dot1 = new Dot
            {
                color = palette[0],
                position = 0,
                direction = 1,
                strip = 1
            };
            dot2 = new Dot
            {
                color = palette[1],
                position = 60,
                direction = -1,
                strip = 2
            };
        }

        public MyColor.RGB[] getNextFrame()
        {
            dot1.color = palette[0];
            dot2.color = palette[1];

            dot1.position = dot1.position + 1 * dot1.direction;
            dot2.position = dot2.position + 1 * dot2.direction;

            _LEDManager.clear();
            _LEDManager.setColor(dot1.strip, dot1.position, dot1.color);
            _LEDManager.setColor(dot2.strip, dot2.position, dot2.color);

            if (dot1.position == 30)
            {
                dot1.direction = -1;
                dot1.strip = 2;
            }
            if (dot1.position == 0)
            {
                dot1.direction = 1;
                dot1.strip = 1;
            }

            if (dot2.position == 30)
            {
                dot2.direction = 1;
                dot2.strip = 1;
            }
            if (dot2.position == 60)
            {
                dot2.direction = -1;
                dot2.strip = 2;
            }

            return _LEDManager._State;
        }
    }

    class Dot
    {
         public MyColor.RGB color { get; set; }

         public int position { get; set; }

         public int direction { get; set; }

         public int strip { get; set; }
    }
}
