using System;
using System.Windows.Forms;
using LEDController.Interfaces;

namespace LEDController.UI
{
    public partial class DoubleRainbow : Form
    {

        #region Windows Form code
        private Button PlayPauseBtn;

        private HScrollBar SleepSlider;
        private Label SleepLbl;
        private Label SleepValueLbl;

        private HScrollBar HueSlider;
        private Label HueSliderLbl;
        private Label HueSliderValueLbl;

        private HScrollBar SaturationSlider;
        private Label SaturationSliderLbl;
        private Label SaturationSliderValueLbl;

        private HScrollBar BrightnessSlider;
        private Label BrightnessSliderLbl;
        private Label BrightnessSliderValueLbl;       

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PlayPauseBtn = new Button();

            SleepSlider = new HScrollBar();
            SleepLbl = new Label();
            SleepValueLbl = new Label();

            HueSlider = new HScrollBar();
            HueSliderLbl = new Label();
            HueSliderValueLbl = new Label();

            SaturationSlider = new HScrollBar();
            SaturationSliderLbl = new Label();
            SaturationSliderValueLbl = new Label();

            BrightnessSlider = new HScrollBar();
            BrightnessSliderLbl = new Label();
            BrightnessSliderValueLbl = new Label();

            SuspendLayout();
            // 
            // PlayPauseBtn
            // 
            PlayPauseBtn.Location = new System.Drawing.Point(406, 14);
            PlayPauseBtn.Margin = new Padding(4, 5, 4, 5);
            PlayPauseBtn.Name = "PlayPauseBtn";
            PlayPauseBtn.Size = new System.Drawing.Size(112, 35);
            PlayPauseBtn.TabIndex = 9;
            PlayPauseBtn.Text = "PlayPause";
            PlayPauseBtn.UseVisualStyleBackColor = true;
            PlayPauseBtn.Click += new EventHandler(PlayPauseEvent);
            // 
            // HueSlider
            // 
            HueSlider.Location = new System.Drawing.Point(140, 124);
            HueSlider.Maximum = 1000;
            HueSlider.Name = "HueSlider";
            HueSlider.Size = new System.Drawing.Size(324, 18);
            HueSlider.SmallChange = 5;
            HueSlider.TabIndex = 10;
            HueSlider.Scroll += new ScrollEventHandler(HueSlider_Scroll);
            // 
            // HueSliderLbl
            // 
            HueSliderLbl.AutoSize = true;
            HueSliderLbl.Location = new System.Drawing.Point(53, 124);
            HueSliderLbl.Margin = new Padding(4, 0, 4, 0);
            HueSliderLbl.Name = "HueSliderLbl";
            HueSliderLbl.Size = new System.Drawing.Size(83, 20);
            HueSliderLbl.TabIndex = 11;
            HueSliderLbl.Text = "Hue Slider";
            // 
            // HueSliderValueLbl
            // 
            HueSliderValueLbl.AutoSize = true;
            HueSliderValueLbl.Location = new System.Drawing.Point(478, 122);
            HueSliderValueLbl.Margin = new Padding(4, 0, 4, 0);
            HueSliderValueLbl.Name = "HueSliderValueLbl";
            HueSliderValueLbl.Size = new System.Drawing.Size(40, 20);
            HueSliderValueLbl.TabIndex = 12;
            HueSliderValueLbl.Text = "Val: ";
            // 
            // RefreshBar
            // 
            SleepSlider.Location = new System.Drawing.Point(140, 73);
            SleepSlider.Name = "RefreshBar";
            SleepSlider.Size = new System.Drawing.Size(324, 18);
            SleepSlider.TabIndex = 13;
            SleepSlider.Scroll += new ScrollEventHandler(RefreshBar_Scroll);
            // 
            // SaturationSliderValueLbl
            // 
            SaturationSliderValueLbl.AutoSize = true;
            SaturationSliderValueLbl.Location = new System.Drawing.Point(478, 168);
            SaturationSliderValueLbl.Margin = new Padding(4, 0, 4, 0);
            SaturationSliderValueLbl.Name = "SaturationSliderValueLbl";
            SaturationSliderValueLbl.Size = new System.Drawing.Size(40, 20);
            SaturationSliderValueLbl.TabIndex = 16;
            SaturationSliderValueLbl.Text = "Val: ";
            // 
            // SaturationSliderLbl
            // 
            SaturationSliderLbl.AutoSize = true;
            SaturationSliderLbl.Location = new System.Drawing.Point(9, 168);
            SaturationSliderLbl.Margin = new Padding(4, 0, 4, 0);
            SaturationSliderLbl.Name = "SaturationSliderLbl";
            SaturationSliderLbl.Size = new System.Drawing.Size(127, 20);
            SaturationSliderLbl.TabIndex = 15;
            SaturationSliderLbl.Text = "Saturation Slider";
            // 
            // SaturationSlider
            // 
            SaturationSlider.Location = new System.Drawing.Point(140, 170);
            SaturationSlider.Maximum = 1000;
            SaturationSlider.Name = "SaturationSlider";
            SaturationSlider.Size = new System.Drawing.Size(324, 18);
            SaturationSlider.SmallChange = 5;
            SaturationSlider.TabIndex = 14;
            SaturationSlider.Scroll += new ScrollEventHandler(SaturationSlider_Scroll);
            // 
            // BrightnessSliderValueLbl
            // 
            BrightnessSliderValueLbl.AutoSize = true;
            BrightnessSliderValueLbl.Location = new System.Drawing.Point(478, 211);
            BrightnessSliderValueLbl.Margin = new Padding(4, 0, 4, 0);
            BrightnessSliderValueLbl.Name = "BrightnessSliderValueLbl";
            BrightnessSliderValueLbl.Size = new System.Drawing.Size(40, 20);
            BrightnessSliderValueLbl.TabIndex = 19;
            BrightnessSliderValueLbl.Text = "Val: ";
            // 
            // BrightnessSliderLbl
            // 
            BrightnessSliderLbl.AutoSize = true;
            BrightnessSliderLbl.Location = new System.Drawing.Point(7, 211);
            BrightnessSliderLbl.Margin = new Padding(4, 0, 4, 0);
            BrightnessSliderLbl.Name = "BrightnessSliderLbl";
            BrightnessSliderLbl.Size = new System.Drawing.Size(129, 20);
            BrightnessSliderLbl.TabIndex = 18;
            BrightnessSliderLbl.Text = "Brightness Slider";
            // 
            // BrightnessSlider
            // 
            BrightnessSlider.Location = new System.Drawing.Point(140, 213);
            BrightnessSlider.Maximum = 1000;
            BrightnessSlider.Name = "BrightnessSlider";
            BrightnessSlider.Size = new System.Drawing.Size(324, 18);
            BrightnessSlider.SmallChange = 5;
            BrightnessSlider.TabIndex = 17;
            BrightnessSlider.Scroll += new ScrollEventHandler(ValueSlider_Scroll);
            // 
            // SleepLbl
            // 
            SleepLbl.AutoSize = true;
            SleepLbl.Location = new System.Drawing.Point(73, 73);
            SleepLbl.Margin = new Padding(4, 0, 4, 0);
            SleepLbl.Name = "SleepLbl";
            SleepLbl.Size = new System.Drawing.Size(50, 20);
            SleepLbl.TabIndex = 23;
            SleepLbl.Text = "Sleep";
            // 
            // RefreshLbl
            // 
            SleepValueLbl.AutoSize = true;
            SleepValueLbl.Location = new System.Drawing.Point(471, 73);
            SleepValueLbl.Margin = new Padding(4, 0, 4, 0);
            SleepValueLbl.Name = "RefreshLbl";
            SleepValueLbl.Size = new System.Drawing.Size(47, 20);
            SleepValueLbl.TabIndex = 24;
            SleepValueLbl.Text = "T: ms";
            // 
            // RainbowGenerator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(583, 246);
            Controls.Add(SleepValueLbl);
            Controls.Add(SleepLbl);
            Controls.Add(BrightnessSliderLbl);
            Controls.Add(BrightnessSliderValueLbl);
            Controls.Add(BrightnessSlider);
            Controls.Add(SaturationSliderValueLbl);
            Controls.Add(SaturationSliderLbl);
            Controls.Add(SaturationSlider);
            Controls.Add(SleepSlider);
            Controls.Add(HueSliderValueLbl);
            Controls.Add(HueSliderLbl);
            Controls.Add(HueSlider);
            Controls.Add(PlayPauseBtn);
            Margin = new Padding(4, 5, 4, 5);
            Name = "RainbowGenerator";
            Text = "Main Window";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private IAnimatorClient _AnimatorClient { get; set; }

        public DoubleRainbow(IAnimatorClient animatorClient)
        {
            InitializeComponent();          
            _AnimatorClient = animatorClient;
            _AnimatorClient.RefreshRate = 0;
            _AnimatorClient.PlayPause();
        }

        // Starts/stops repeat thread
        private void PlayPauseEvent(object sender, EventArgs e)
        {
            _AnimatorClient.PlayPause();
            if (_AnimatorClient.isRunning)
            {
                PlayPauseBtn.Text = "Pause";
            }
            else
            {
                PlayPauseBtn.Text = "Play";
            }
        }

        public int HueSliderValue = 15;
        private void HueSlider_Scroll(object sender, ScrollEventArgs e)
        {
            HueSliderValue = (int)Math.Pow(Math.E, (5.545d * HueSlider.Value / 1000) );
            HueSliderValueLbl.Text = "Val: " + String.Format("{0:N0}", HueSliderValue);
            _AnimatorClient.hsvDelta.Hue = HueSliderValue;
        }

        public int SaturationSliderValue = 15;
        private void SaturationSlider_Scroll(object sender, ScrollEventArgs e)
        {
            SaturationSliderValue = (int)Math.Pow(Math.E, (5.545d * SaturationSlider.Value / 1000) );
            SaturationSliderValueLbl.Text = "Val: " + String.Format("{0:N0}", SaturationSliderValue);
            _AnimatorClient.hsvDelta.Saturation = SaturationSliderValue;
        }

        public int BrightnessSliderValue = 15;
        private void ValueSlider_Scroll(object sender, ScrollEventArgs e)
        {
            BrightnessSliderValue = (int)Math.Pow(Math.E, (5.545d * BrightnessSlider.Value / 1000));
            BrightnessSliderValueLbl.Text = "Val: " + String.Format("{0:N0}", BrightnessSliderValue);
            _AnimatorClient.hsvDelta.Value = BrightnessSliderValue;
        }

        public int refreshRate = 15;
        private void RefreshBar_Scroll(object sender, ScrollEventArgs e)
        {
            refreshRate = SleepSlider.Value;
            SleepValueLbl.Text = refreshRate + " ms";
            _AnimatorClient.RefreshRate = refreshRate;
        }


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
