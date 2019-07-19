using LEDController.Generators;
using LEDController.Generators.Animation;
using LEDController.Interfaces;
using LEDController.Manager;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        private ComboBox animationOptions;
        private Label animationLbl;
        private Label BrightnessSliderValueLbl;

        private List<String> AnimatorOptionsList = new List<string> { "Fill", "Loop", "Push" };

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoubleRainbow));
            this.PlayPauseBtn = new Button();
            this.SleepSlider = new HScrollBar();
            this.SleepLbl = new Label();
            this.SleepValueLbl = new Label();
            this.HueSlider = new HScrollBar();
            this.HueSliderLbl = new Label();
            this.HueSliderValueLbl = new Label();
            this.SaturationSlider = new HScrollBar();
            this.SaturationSliderLbl = new Label();
            this.SaturationSliderValueLbl = new Label();
            this.BrightnessSlider = new HScrollBar();
            this.BrightnessSliderLbl = new Label();
            this.BrightnessSliderValueLbl = new Label();
            this.animationOptions = new ComboBox();
            this.animationLbl = new Label();
            this.SuspendLayout();
            // 
            // PlayPauseBtn
            // 
            this.PlayPauseBtn.Location = new System.Drawing.Point(271, 9);
            this.PlayPauseBtn.Name = "PlayPauseBtn";
            this.PlayPauseBtn.Size = new System.Drawing.Size(75, 23);
            this.PlayPauseBtn.TabIndex = 9;
            this.PlayPauseBtn.Text = "PlayPause";
            this.PlayPauseBtn.UseVisualStyleBackColor = true;
            this.PlayPauseBtn.Click += new EventHandler(this.PlayPauseEvent);
            // 
            // SleepSlider
            // 
            this.SleepSlider.Location = new System.Drawing.Point(110, 67);
            this.SleepSlider.Name = "SleepSlider";
            this.SleepSlider.Size = new System.Drawing.Size(216, 18);
            this.SleepSlider.TabIndex = 13;
            this.SleepSlider.Scroll += new ScrollEventHandler(this.RefreshBar_Scroll);
            // 
            // SleepLbl
            // 
            this.SleepLbl.AutoSize = true;
            this.SleepLbl.Location = new System.Drawing.Point(66, 67);
            this.SleepLbl.Name = "SleepLbl";
            this.SleepLbl.Size = new System.Drawing.Size(34, 13);
            this.SleepLbl.TabIndex = 23;
            this.SleepLbl.Text = "Sleep";
            // 
            // SleepValueLbl
            // 
            this.SleepValueLbl.AutoSize = true;
            this.SleepValueLbl.Location = new System.Drawing.Point(331, 67);
            this.SleepValueLbl.Name = "SleepValueLbl";
            this.SleepValueLbl.Size = new System.Drawing.Size(33, 13);
            this.SleepValueLbl.TabIndex = 24;
            this.SleepValueLbl.Text = "T: ms";
            // 
            // HueSlider
            // 
            this.HueSlider.Location = new System.Drawing.Point(110, 101);
            this.HueSlider.Maximum = 1000;
            this.HueSlider.Name = "HueSlider";
            this.HueSlider.Size = new System.Drawing.Size(216, 18);
            this.HueSlider.SmallChange = 5;
            this.HueSlider.TabIndex = 10;
            this.HueSlider.Scroll += new ScrollEventHandler(this.HueSlider_Scroll);
            // 
            // HueSliderLbl
            // 
            this.HueSliderLbl.AutoSize = true;
            this.HueSliderLbl.Location = new System.Drawing.Point(52, 101);
            this.HueSliderLbl.Name = "HueSliderLbl";
            this.HueSliderLbl.Size = new System.Drawing.Size(56, 13);
            this.HueSliderLbl.TabIndex = 11;
            this.HueSliderLbl.Text = "Hue Slider";
            // 
            // HueSliderValueLbl
            // 
            this.HueSliderValueLbl.AutoSize = true;
            this.HueSliderValueLbl.Location = new System.Drawing.Point(336, 99);
            this.HueSliderValueLbl.Name = "HueSliderValueLbl";
            this.HueSliderValueLbl.Size = new System.Drawing.Size(28, 13);
            this.HueSliderValueLbl.TabIndex = 12;
            this.HueSliderValueLbl.Text = "Val: ";
            // 
            // SaturationSlider
            // 
            this.SaturationSlider.Location = new System.Drawing.Point(110, 130);
            this.SaturationSlider.Maximum = 1000;
            this.SaturationSlider.Name = "SaturationSlider";
            this.SaturationSlider.Size = new System.Drawing.Size(216, 18);
            this.SaturationSlider.SmallChange = 5;
            this.SaturationSlider.TabIndex = 14;
            this.SaturationSlider.Scroll += new ScrollEventHandler(this.SaturationSlider_Scroll);
            // 
            // SaturationSliderLbl
            // 
            this.SaturationSliderLbl.AutoSize = true;
            this.SaturationSliderLbl.Location = new System.Drawing.Point(23, 129);
            this.SaturationSliderLbl.Name = "SaturationSliderLbl";
            this.SaturationSliderLbl.Size = new System.Drawing.Size(84, 13);
            this.SaturationSliderLbl.TabIndex = 15;
            this.SaturationSliderLbl.Text = "Saturation Slider";
            // 
            // SaturationSliderValueLbl
            // 
            this.SaturationSliderValueLbl.AutoSize = true;
            this.SaturationSliderValueLbl.Location = new System.Drawing.Point(336, 129);
            this.SaturationSliderValueLbl.Name = "SaturationSliderValueLbl";
            this.SaturationSliderValueLbl.Size = new System.Drawing.Size(28, 13);
            this.SaturationSliderValueLbl.TabIndex = 16;
            this.SaturationSliderValueLbl.Text = "Val: ";
            // 
            // BrightnessSlider
            // 
            this.BrightnessSlider.Location = new System.Drawing.Point(110, 158);
            this.BrightnessSlider.Maximum = 1000;
            this.BrightnessSlider.Name = "BrightnessSlider";
            this.BrightnessSlider.Size = new System.Drawing.Size(216, 18);
            this.BrightnessSlider.SmallChange = 5;
            this.BrightnessSlider.TabIndex = 17;
            this.BrightnessSlider.Scroll += new ScrollEventHandler(this.ValueSlider_Scroll);
            // 
            // BrightnessSliderLbl
            // 
            this.BrightnessSliderLbl.AutoSize = true;
            this.BrightnessSliderLbl.Location = new System.Drawing.Point(22, 157);
            this.BrightnessSliderLbl.Name = "BrightnessSliderLbl";
            this.BrightnessSliderLbl.Size = new System.Drawing.Size(85, 13);
            this.BrightnessSliderLbl.TabIndex = 18;
            this.BrightnessSliderLbl.Text = "Brightness Slider";
            // 
            // BrightnessSliderValueLbl
            // 
            this.BrightnessSliderValueLbl.AutoSize = true;
            this.BrightnessSliderValueLbl.Location = new System.Drawing.Point(336, 157);
            this.BrightnessSliderValueLbl.Name = "BrightnessSliderValueLbl";
            this.BrightnessSliderValueLbl.Size = new System.Drawing.Size(28, 13);
            this.BrightnessSliderValueLbl.TabIndex = 19;
            this.BrightnessSliderValueLbl.Text = "Val: ";
            // 
            // animationOptions
            // 
            this.animationOptions.DataSource = AnimatorOptionsList;
            this.animationOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            this.animationOptions.FormattingEnabled = true;
            this.animationOptions.Location = new System.Drawing.Point(110, 11);
            this.animationOptions.Name = "animationOptions";
            this.animationOptions.Size = new System.Drawing.Size(121, 21);
            this.animationOptions.TabIndex = 25;
            this.animationOptions.SelectedIndexChanged += new EventHandler(this.AnimationOptions_SelectedIndexChanged);
            // 
            // animationLbl
            // 
            this.animationLbl.AutoSize = true;
            this.animationLbl.Location = new System.Drawing.Point(25, 14);
            this.animationLbl.Name = "animationLbl";
            this.animationLbl.Size = new System.Drawing.Size(83, 13);
            this.animationLbl.TabIndex = 26;
            this.animationLbl.Text = "Animation Mode";
            // 
            // DoubleRainbow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 193);
            this.Controls.Add(this.animationLbl);
            this.Controls.Add(this.animationOptions);
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
            this.Name = "DoubleRainbow";
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
            HueSliderValue = (int)Math.Pow(Math.E, (5.545d * HueSlider.Value / 1000));
            HueSliderValueLbl.Text = "Val: " + String.Format("{0:N0}", HueSliderValue);
            _AnimatorClient.hsvDelta.Hue = HueSliderValue;
        }

        public int SaturationSliderValue = 15;
        private void SaturationSlider_Scroll(object sender, ScrollEventArgs e)
        {
            SaturationSliderValue = (int)Math.Pow(Math.E, (5.545d * SaturationSlider.Value / 1000));
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

        private void AnimationOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ledManager = new LedManager(120, 2);
            var paletteManager = new PaletteManager(2);
            switch (((ComboBox)sender).SelectedValue)
            {
                case "Fill":
                    _AnimatorClient.UpdateFillAnimation(new FillAnimation(ledManager, paletteManager));
                    break;
                case "Loop":
                    _AnimatorClient.UpdateFillAnimation(new LooperAnimator(ledManager, paletteManager));
                    break;
                case "Push":
                    _AnimatorClient.UpdateFillAnimation(new PushAnimator(ledManager, paletteManager));
                    break;
            }

        }
    }
}
