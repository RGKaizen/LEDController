using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.Generators
{
    public class PushAnimator : AnimatorBase, IAnimator
    {
        public PushAnimator(ILedManager ledManager, IPaletteManager palette) : base(ledManager, palette)
        {
        }

        public MyColor.RGB[] getNextFrame()
        {
            ledManager.setColor(1, ledManager.StripLength / 2, palette.GetColor());
            Push();
            return ledManager._State;
        }

        // Pushes from the center like this  <-- -->
        private void Push()
        {
            for (int i = 0; i < ledManager.StripLength / 2; i++)
            {
                int waveUp = i;
                int waveDown = ledManager.StripLength - 1 - i;
                ledManager.setColor(1, waveUp, ledManager._State[waveUp + 1]);
                ledManager.setColor(1, waveDown, ledManager._State[waveDown - 1]);
                ledManager.setColor(2, waveUp, ledManager._State[waveUp + 1]);
                ledManager.setColor(2, waveDown, ledManager._State[waveDown - 1]);
            }
        }
    }
}
