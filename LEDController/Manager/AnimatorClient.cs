using LEDController.Interfaces;
using LEDController.Utils;
using System;
using System.Threading;

namespace LEDController.Manager
{
    public class AnimatorClient : IAnimatorClient
    {        
        private ILedClient _ledClient { get; set; }
        private IAnimator _Animator { get; set; }
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

        public AnimatorClient(ILedClient restClient, IAnimator animator, IColorGenerator hueGenerator)
        {
            _ledClient = restClient;
            _Animator = animator;
            _HueGenerator = hueGenerator;

            _animationThread = new AnimationThread(Animate);

            RefreshRate = 0;
            hsvDelta = new MyColor.HSV(3, 0, 2);
        }

        private void Animate()
        {
            _Animator.palette[0] = _HueGenerator.getNextColor(hsvDelta);
            _Animator.palette[1] = _HueGenerator.getNextColor(hsvDelta);
            _ledClient.Send(_Animator.getNextFrame());
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
