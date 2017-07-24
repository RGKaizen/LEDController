using System;
using System.Windows.Forms;
using System.Threading;
using LEDController.Interfaces;
using LEDController.Utils;

namespace LEDController.UI
{
    public partial class RainbowGenerator : Form
    {
        private IHueGenerator _hueGenerator { get; set; }
        private ILEDManager _LEDManager { get; set; }
        private AnimationThread _animationThread = null;
        private DRColor.RGB[] _ledState { get; set; }

        public RainbowGenerator(IHueGenerator hueGenerator, ILEDManager ledManager)
        {
            InitializeComponent();
            _hueGenerator = hueGenerator;
            _LEDManager = ledManager;
            _animationThread = new AnimationThread(Animate);
            _ledState = RainbowUtils.createEmptyArray(ledManager.TotalLEDCount);
        }

        public void Animate()
        {
            // Color Generation 
            var newColor = new DRColor.RGB(
                    _hueGenerator.getNextColor(
                        (float)HueSliderValue,
                        (float)SaturationSliderValue,
                        (float)ValueSliderValue));

            // Position Generation
            _ledState[_LEDManager.TotalLEDCount / 2] = newColor;
            Push();
            _LEDManager.SendRGBMessage(_LEDManager.CreateMessage(_ledState));
            Thread.Sleep(refreshRate);
        }

        // Pushes from the center like this  <-- -->
        public void Push()
        {
            for (int i = 0; i < _LEDManager.TotalLEDCount/2; i++)
            {
                int waveUp = i;
                int waveDown = _LEDManager.TotalLEDCount-1 - i;
                _ledState[waveUp] = _ledState[waveUp + 1];
                _ledState[waveDown] = _ledState[waveDown - 1];
            }
        }

        // Starts/stops repeat thread
        private void PlayPause(object sender, EventArgs e)
        {
            if (_animationThread.isOn)
            {
                BtnStartStop.Text = "Play";
                _animationThread.Stop();
            }
            else
            {
                BtnStartStop.Text = "Pause";
                _animationThread.Start();
            }
        }

        private void ClearButton(object sender, EventArgs e)
        {
            DRColor.RGB r = new DRColor.RGB(0, 0, 0);
            _LEDManager.SendRGBMessage(_LEDManager.CreateMessage(r));
        }

        public double HueSliderValue = 61;
        private void HueSlider_Scroll(object sender, ScrollEventArgs e)
        {
            HueSliderValue = Math.Pow(Math.E, (5.545d * Slider1.Value / 1000) );
            Slider1ValueLbl.Text = "Val: " + String.Format("{0:N2}", HueSliderValue);
        }

        public double SaturationSliderValue = 45;
        private void SaturationSlider_Scroll(object sender, ScrollEventArgs e)
        {
            SaturationSliderValue = Math.Pow(Math.E, (5.545d * Slider2.Value / 1000) );
            Slider2ValueLbl.Text = "Val: " + String.Format("{0:N2}", SaturationSliderValue);
        }

        public double ValueSliderValue = 34;
        private void ValueSlider_Scroll(object sender, ScrollEventArgs e)
        {
            ValueSliderValue = Math.Pow(Math.E, (5.545d * Slider3.Value / 1000));
            Slider3ValueLbl.Text = "Val: " + String.Format("{0:N2}", ValueSliderValue);
        }

        public int refreshRate = 0;
        private void RefreshBar_Scroll(object sender, ScrollEventArgs e)
        {
            refreshRate = RefreshBar.Value;
            refreshLbl.Text = refreshRate + " ms";
        }

    }
}
