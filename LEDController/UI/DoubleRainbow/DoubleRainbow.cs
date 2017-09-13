using System;
using System.Windows.Forms;
using LEDController.Interfaces;
using LEDController.Utils;

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
            this.PlayPauseBtn = new System.Windows.Forms.Button();

            this.SleepSlider = new System.Windows.Forms.HScrollBar();
            this.SleepLbl = new System.Windows.Forms.Label();
            this.SleepValueLbl = new System.Windows.Forms.Label();

            this.HueSlider = new System.Windows.Forms.HScrollBar();
            this.HueSliderLbl = new System.Windows.Forms.Label();
            this.HueSliderValueLbl = new System.Windows.Forms.Label();

            this.SaturationSlider = new System.Windows.Forms.HScrollBar();
            this.SaturationSliderLbl = new System.Windows.Forms.Label();
            this.SaturationSliderValueLbl = new System.Windows.Forms.Label();

            this.BrightnessSlider = new System.Windows.Forms.HScrollBar();
            this.BrightnessSliderLbl = new System.Windows.Forms.Label();
            this.BrightnessSliderValueLbl = new System.Windows.Forms.Label();

            this.SuspendLayout();
            // 
            // PlayPauseBtn
            // 
            this.PlayPauseBtn.Location = new System.Drawing.Point(406, 14);
            this.PlayPauseBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PlayPauseBtn.Name = "PlayPauseBtn";
            this.PlayPauseBtn.Size = new System.Drawing.Size(112, 35);
            this.PlayPauseBtn.TabIndex = 9;
            this.PlayPauseBtn.Text = "PlayPause";
            this.PlayPauseBtn.UseVisualStyleBackColor = true;
            this.PlayPauseBtn.Click += new System.EventHandler(this.PlayPauseEvent);
            // 
            // HueSlider
            // 
            this.HueSlider.Location = new System.Drawing.Point(140, 124);
            this.HueSlider.Maximum = 1000;
            this.HueSlider.Name = "HueSlider";
            this.HueSlider.Size = new System.Drawing.Size(324, 18);
            this.HueSlider.SmallChange = 5;
            this.HueSlider.TabIndex = 10;
            this.HueSlider.Value = 60;
            this.HueSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HueSlider_Scroll);
            // 
            // HueSliderLbl
            // 
            this.HueSliderLbl.AutoSize = true;
            this.HueSliderLbl.Location = new System.Drawing.Point(53, 124);
            this.HueSliderLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HueSliderLbl.Name = "HueSliderLbl";
            this.HueSliderLbl.Size = new System.Drawing.Size(83, 20);
            this.HueSliderLbl.TabIndex = 11;
            this.HueSliderLbl.Text = "Hue Slider";
            // 
            // HueSliderValueLbl
            // 
            this.HueSliderValueLbl.AutoSize = true;
            this.HueSliderValueLbl.Location = new System.Drawing.Point(478, 122);
            this.HueSliderValueLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HueSliderValueLbl.Name = "HueSliderValueLbl";
            this.HueSliderValueLbl.Size = new System.Drawing.Size(40, 20);
            this.HueSliderValueLbl.TabIndex = 12;
            this.HueSliderValueLbl.Text = "Val: ";
            // 
            // RefreshBar
            // 
            this.SleepSlider.Location = new System.Drawing.Point(140, 73);
            this.SleepSlider.Name = "RefreshBar";
            this.SleepSlider.Size = new System.Drawing.Size(324, 18);
            this.SleepSlider.TabIndex = 13;
            this.SleepSlider.Value = 50;
            this.SleepSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.RefreshBar_Scroll);
            // 
            // SaturationSliderValueLbl
            // 
            this.SaturationSliderValueLbl.AutoSize = true;
            this.SaturationSliderValueLbl.Location = new System.Drawing.Point(478, 168);
            this.SaturationSliderValueLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SaturationSliderValueLbl.Name = "SaturationSliderValueLbl";
            this.SaturationSliderValueLbl.Size = new System.Drawing.Size(40, 20);
            this.SaturationSliderValueLbl.TabIndex = 16;
            this.SaturationSliderValueLbl.Text = "Val: ";
            // 
            // SaturationSliderLbl
            // 
            this.SaturationSliderLbl.AutoSize = true;
            this.SaturationSliderLbl.Location = new System.Drawing.Point(9, 168);
            this.SaturationSliderLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SaturationSliderLbl.Name = "SaturationSliderLbl";
            this.SaturationSliderLbl.Size = new System.Drawing.Size(127, 20);
            this.SaturationSliderLbl.TabIndex = 15;
            this.SaturationSliderLbl.Text = "Saturation Slider";
            // 
            // SaturationSlider
            // 
            this.SaturationSlider.Location = new System.Drawing.Point(140, 170);
            this.SaturationSlider.Maximum = 1000;
            this.SaturationSlider.Name = "SaturationSlider";
            this.SaturationSlider.Size = new System.Drawing.Size(324, 18);
            this.SaturationSlider.SmallChange = 5;
            this.SaturationSlider.TabIndex = 14;
            this.SaturationSlider.Value = 95;
            this.SaturationSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SaturationSlider_Scroll);
            // 
            // BrightnessSliderValueLbl
            // 
            this.BrightnessSliderValueLbl.AutoSize = true;
            this.BrightnessSliderValueLbl.Location = new System.Drawing.Point(478, 211);
            this.BrightnessSliderValueLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BrightnessSliderValueLbl.Name = "BrightnessSliderValueLbl";
            this.BrightnessSliderValueLbl.Size = new System.Drawing.Size(40, 20);
            this.BrightnessSliderValueLbl.TabIndex = 19;
            this.BrightnessSliderValueLbl.Text = "Val: ";
            // 
            // BrightnessSliderLbl
            // 
            this.BrightnessSliderLbl.AutoSize = true;
            this.BrightnessSliderLbl.Location = new System.Drawing.Point(7, 211);
            this.BrightnessSliderLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BrightnessSliderLbl.Name = "BrightnessSliderLbl";
            this.BrightnessSliderLbl.Size = new System.Drawing.Size(129, 20);
            this.BrightnessSliderLbl.TabIndex = 18;
            this.BrightnessSliderLbl.Text = "Brightness Slider";
            // 
            // BrightnessSlider
            // 
            this.BrightnessSlider.Location = new System.Drawing.Point(140, 213);
            this.BrightnessSlider.Maximum = 1000;
            this.BrightnessSlider.Name = "BrightnessSlider";
            this.BrightnessSlider.Size = new System.Drawing.Size(324, 18);
            this.BrightnessSlider.SmallChange = 5;
            this.BrightnessSlider.TabIndex = 17;
            this.BrightnessSlider.Value = 125;
            this.BrightnessSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ValueSlider_Scroll);
            // 
            // SleepLbl
            // 
            this.SleepLbl.AutoSize = true;
            this.SleepLbl.Location = new System.Drawing.Point(73, 73);
            this.SleepLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SleepLbl.Name = "SleepLbl";
            this.SleepLbl.Size = new System.Drawing.Size(50, 20);
            this.SleepLbl.TabIndex = 23;
            this.SleepLbl.Text = "Sleep";
            // 
            // RefreshLbl
            // 
            this.SleepValueLbl.AutoSize = true;
            this.SleepValueLbl.Location = new System.Drawing.Point(471, 73);
            this.SleepValueLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SleepValueLbl.Name = "RefreshLbl";
            this.SleepValueLbl.Size = new System.Drawing.Size(47, 20);
            this.SleepValueLbl.TabIndex = 24;
            this.SleepValueLbl.Text = "T: ms";
            // 
            // RainbowGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 246);
            this.Controls.Add(this.SleepValueLbl);
            this.Controls.Add(this.SleepLbl);
            this.Controls.Add(this.BrightnessSliderLbl);
            this.Controls.Add(this.BrightnessSliderValueLbl);
            this.Controls.Add(this.BrightnessSlider);
            this.Controls.Add(this.SaturationSliderValueLbl);
            this.Controls.Add(this.SaturationSliderLbl);
            this.Controls.Add(this.SaturationSlider);
            this.Controls.Add(this.SleepSlider);
            this.Controls.Add(this.HueSliderValueLbl);
            this.Controls.Add(this.HueSliderLbl);
            this.Controls.Add(this.HueSlider);
            this.Controls.Add(this.PlayPauseBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RainbowGenerator";
            this.Text = "Main Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IAnimatorClient _AnimatorClient { get; set; }

        public DoubleRainbow(IAnimatorClient animatorClient)
        {
            InitializeComponent();          
            _AnimatorClient = animatorClient;
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

        public int HueSliderValue = 61;
        private void HueSlider_Scroll(object sender, ScrollEventArgs e)
        {
            HueSliderValue = (int)Math.Pow(Math.E, (5.545d * HueSlider.Value / 1000) );
            HueSliderValueLbl.Text = "Val: " + String.Format("{0:N2}", HueSliderValue);
            _AnimatorClient.hsvDelta.Hue = HueSliderValue;
        }

        public int SaturationSliderValue = 45;
        private void SaturationSlider_Scroll(object sender, ScrollEventArgs e)
        {
            SaturationSliderValue = (int)Math.Pow(Math.E, (5.545d * SaturationSlider.Value / 1000) );
            SaturationSliderValueLbl.Text = "Val: " + String.Format("{0:N2}", SaturationSliderValue);
            _AnimatorClient.hsvDelta.Saturation = SaturationSliderValue;
        }

        public int BrightnessSliderValue = 34;
        private void ValueSlider_Scroll(object sender, ScrollEventArgs e)
        {
            BrightnessSliderValue = (int)Math.Pow(Math.E, (5.545d * BrightnessSlider.Value / 1000));
            BrightnessSliderLbl.Text = "Val: " + String.Format("{0:N2}", BrightnessSliderValue);
            _AnimatorClient.hsvDelta.Value = BrightnessSliderValue;
        }

        public int refreshRate = 0;
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
