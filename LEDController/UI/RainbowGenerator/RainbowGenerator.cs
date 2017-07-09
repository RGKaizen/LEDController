﻿using System;
using System.Windows.Forms;
using System.Threading;
using LEDController.Interfaces;
using LEDController.Utils;
using LEDController.Dtos;

namespace LEDController.UI
{

    /*
     * Requirements:
     * Event-driven lighting. Run scripts for animations by accepting requests or events
     * events can be raised externally with custom scripts
     * Structure: source pixel, active width (left and right independent), animation mask
     * */

    public partial class RainbowGenerator : Form
    {
        private IHueGenerator _hueGenerator { get; set; }
        private ILEDManager _ledManager { get; set; }
        private AnimationThread _animationThread = null;
        private DRColor.RGB[] _ledState { get; set; }

        public RainbowGenerator(IHueGenerator hueGenerator, ILEDManager ledManager)
        {
            InitializeComponent();
            _hueGenerator = hueGenerator;
            _ledManager = ledManager;
            _animationThread = new AnimationThread(Animate);
            _ledState = RainbowUtils.createEmptyArray(ledManager.LEDCount);
        }

        public void Animate()
        {
            // Color Generation 
            DRColor.HSV color_gen = _hueGenerator.getNextColor((float)Slider1Value, (float)Slider2Value, (float)Slider3Value);
            DRColor.RGB new_color = new DRColor.RGB(color_gen);

            // Position Generation
            _ledState[_ledManager.LEDCount/2] = new_color;
            _ledState[_ledManager.LEDCount/2 -1] = new_color;
            Push();
            _ledManager.SendColor(_ledManager.CreateMessage(_ledState));
            Thread.Sleep(refreshRate);
        }

        // Pushes from the center like this --> <--
        public void Push()
        {
            for (int i = 0; i < _ledManager.LEDCount/2; i++)
            {
                int wave_up = i;
                int wave_down = _ledManager.LEDCount-1 - i;
                _ledState[wave_up] = _ledState[wave_up + 1];
                _ledState[wave_down] = _ledState[wave_down - 1];
            }
        }

        // Starts/stops repeat thread
        private void PlayPause(object sender, EventArgs e)
        {
            if (_animationThread.isOn)
            {
                button2.Text = "Play";
                _animationThread.Stop();
            }
            else
            {
                button2.Text = "Pause";
                _animationThread.Start();
            }
        }

        private void ClearButton(object sender, EventArgs e)
        {
            RainbowUtils.TurnOff();
        }

        public double Slider1Value = 61;
        private void Slider1_Scroll(object sender, ScrollEventArgs e)
        {
            Slider1Value = Math.Pow(Math.E, (5.545d * Slider1.Value / 1000) );
            Slider1ValueLbl.Text = "Val: " + String.Format("{0:N2}", Slider1Value);
        }

        public double Slider2Value = 45;
        private void Slider2_Scroll(object sender, ScrollEventArgs e)
        {
            Slider2Value = Math.Pow(Math.E, (5.545d * Slider2.Value / 1000) );
            Slider2ValueLbl.Text = "Val: " + String.Format("{0:N2}", Slider2Value);
        }

        public double Slider3Value = 34;
        private void Slider3_Scroll(object sender, ScrollEventArgs e)
        {
            Slider3Value = Math.Pow(Math.E, (5.545d * Slider3.Value / 1000));
            Slider3ValueLbl.Text = "Val: " + String.Format("{0:N2}", Slider3Value);
        }

        public int refreshRate = 0;
        private void RefreshBar_Scroll(object sender, ScrollEventArgs e)
        {
            refreshRate = RefreshBar.Value;
            refreshLbl.Text = refreshRate + " ms";
        }

        private DRColor.RGB AdjustVal(DRColor.RGB rgb, double perc)
        {
            DRColor.HSV hsv = new DRColor.HSV(rgb);
            hsv.Value = (int)(hsv.Value * perc);
            return new DRColor.RGB(hsv);
        }

    }
}
