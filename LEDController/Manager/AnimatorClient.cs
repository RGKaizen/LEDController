using LEDController.Interfaces;
using LEDController.Utils;
using System;
using System.Threading;
using static LEDController.Utils.MyColor;

namespace LEDController.Manager
{
    public class AnimatorClient : IAnimatorClient
    {
        private ILedClient _ledClient { get; set; }
        private IAnimator _animator { get; set; }
        private IColorGenerator _hueGenerator { get; set; }

        public bool isRunning { get; private set; }
        private AnimationThread _animationThread = null;

        private int _refreshRate;
        public int RefreshRate
        {
            get => _refreshRate;
            set => _refreshRate = value.Clamp(0, int.MaxValue);
        }

        private HSV _hsvDelta;
        public HSV hsvDelta
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
            _animator = animator;
            _hueGenerator = hueGenerator;
            _animationThread = new AnimationThread(Animate);

            RefreshRate = 0;
            hsvDelta = new HSV();
        }

        private void Animate()
        {
            _hueGenerator.hsvDelta = hsvDelta;
            _animator.palette.PopulatePalette(_hueGenerator);
            _ledClient.Send(_animator.getNextFrame());
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

        public void Stop()
        {
            _animationThread.Stop();
            isRunning = false;
        }

        public void UpdateFillAnimation(IAnimator animator)
        {
            _animator = animator;
        }
    }
}
