using LEDController.Interfaces;
using LEDController.Utils;
using System.Threading;

namespace LEDController.UI
{
    public class AnimatorClient
    {
        private IHueGenerator _hueGenerator { get; set; }
        private ILEDManager _LEDManager { get; set; }
        private AnimationThread _animationThread = null;
        private MyColor.RGB[] _ledState { get; set; }
        private int _refreshRate { get; set; }
        private MyColor.HSV _hsvDelta { get; set; }

        public AnimatorClient(IHueGenerator hueGenerator, ILEDManager ledManager)
        {
            _hueGenerator = hueGenerator;
            _LEDManager = ledManager;
            _animationThread = new AnimationThread(Animate);
            _ledState = RainbowUtils.createEmptyArray(ledManager.TotalLEDCount);
            _refreshRate = 0;
        }


        private void Animate()
        {
            // Color Generation 
            var newColor = new MyColor.RGB(_hueGenerator.getNextColor(_hsvDelta));

            // Position Generation
            _ledState[_LEDManager.TotalLEDCount / 2] = newColor;
            _LEDManager.SendRGBMessage(_LEDManager.CreateMessage(_ledState));
            Thread.Sleep(_refreshRate);
        }

        public bool PlayPause()
        {
            if (_animationThread.isOn)
            {
                _animationThread.Stop();
            }
            else
            {
                _animationThread.Start();
            }

            return true;
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
