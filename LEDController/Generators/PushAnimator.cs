using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.Generators
{
    public class PushAnimator : AnimatorBase, IAnimator
    {
        public PushAnimator(ILedManager ledManager) : base(ledManager)
        {
            _LEDManager = ledManager;
            _ledState = RainbowUtils.createEmptyArray(ledManager.LEDCount);
            palette = new MyColor.RGB[1];
        }

        public MyColor.RGB[] getNextFrame()
        {
            _ledState[_LEDManager.LEDCount / 2] = palette[0] ?? MyColor.Red;
            Push();
            return _ledState;
        }

        // Pushes from the center like this  <-- -->
        private void Push()
        {
            for (int i = 0; i < _LEDManager.LEDCount / 2; i++)
            {
                int waveUp = i;
                int waveDown = _LEDManager.LEDCount - 1 - i;
                _ledState[waveUp] = _ledState[waveUp + 1];
                _ledState[waveDown] = _ledState[waveDown - 1];
            }
        }
    }
}
