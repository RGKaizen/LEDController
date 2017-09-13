using LEDController.Interfaces;
using LEDController.Utils;
using System;
using System.Threading;

namespace LEDController.Manager
{
    public class AnimatorClient : IAnimatorClient
    {        
        private ILEDRestClient _LEDRestClient { get; set; }
        private IAnimator _PushAnimator { get; set; }
        private IColorGenerator _HueGenerator { get; set; }

        public bool isRunning { get; private set; }
        private AnimationThread _animationThread = null;

        private int _refreshRate;
        public int RefreshRate
        {
            get => _refreshRate;
            set => _refreshRate = value.Clamp(0, int.MaxValue);
        }

        private MyColor.HSV _hsvDelta;
        public MyColor.HSV hsvDelta
        {
            get => _hsvDelta;
            set
            {
                if (value == null)
                {
                    if (value == null) throw new ArgumentNullException("hsvDelta");
                }
                _hsvDelta = value;
            }               
        }

        public AnimatorClient(ILEDRestClient restClient, IAnimator animator, IColorGenerator hueGenerator)
        {
            _LEDRestClient = restClient;
            _PushAnimator = animator;
            _HueGenerator = hueGenerator;

            _animationThread = new AnimationThread(Animate);

            RefreshRate = 0;
            hsvDelta = new MyColor.HSV(256, 256, 128);
        }

        private void Animate()
        {
            _PushAnimator.palette[0] = _HueGenerator.getNextColor(hsvDelta);
            _LEDRestClient.Send(_PushAnimator.getNextFrame());
            Thread.Sleep(RefreshRate);
        }

        public bool PlayPause()
        {
            if (_animationThread.isOn)
            {
                _animationThread.Stop();
                isRunning = _animationThread.isOn;
            }
            else
            {
                _animationThread.Start();
                isRunning = _animationThread.isOn;
            }

            return true;
        }
    }
}
