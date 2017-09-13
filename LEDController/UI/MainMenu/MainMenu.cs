using System;
using System.Windows.Forms;
using LEDController.Utils;
using LEDController.Interfaces;
using LEDController.Manager;

namespace LEDController.UI
{
    public class MainMenu : Form
    {

        private Button colorWheelBtn;
        private Button rainbowBtn;
        private Button sortBtn;

        private void InitializeComponent()
        {
            colorWheelBtn = new Button();
            rainbowBtn = new Button();
            sortBtn = new Button();
            SuspendLayout();

            colorWheelBtn.Location = new System.Drawing.Point(32, 12);
            colorWheelBtn.Size = new System.Drawing.Size(78, 45);
            colorWheelBtn.TabIndex = 0;
            colorWheelBtn.Text = "Color Wheel";
            colorWheelBtn.UseVisualStyleBackColor = true;
            colorWheelBtn.Click += new System.EventHandler(this.ColorWheelBtn_Click);

            rainbowBtn.Location = new System.Drawing.Point(138, 12);
            rainbowBtn.Size = new System.Drawing.Size(78, 45);
            rainbowBtn.TabIndex = 1;
            rainbowBtn.Text = "Rainbow Gen";
            rainbowBtn.UseVisualStyleBackColor = true;
            rainbowBtn.Click += new System.EventHandler(RainbowBtn_Click);

            sortBtn.Location = new System.Drawing.Point(239, 12);
            sortBtn.Size = new System.Drawing.Size(80, 45);
            sortBtn.TabIndex = 2;
            sortBtn.Text = "Sort";
            sortBtn.UseVisualStyleBackColor = true;
            sortBtn.Click += new EventHandler(SortBtn_Click);
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(350, 75);
            Controls.Add(sortBtn);
            Controls.Add(rainbowBtn);
            Controls.Add(colorWheelBtn);
            Name = "MainMenu";
            Text = "Double Rainbow";
            ResumeLayout(false);

        }

        private ILEDManager _LEDManager { get; set; }

        public MainMenu()
        {
            InitializeComponent();
            _LEDManager = new LEDManager("192.168.1.103", "5000", 120);
        }

        private void ColorWheelBtn_Click(object sender, EventArgs e)
        {
            new ColorChooser(_LEDManager).Show();
        }

        private void RainbowBtn_Click(object sender, EventArgs e)
        {
            new RainbowGenerator(new HueGenerator(), _LEDManager).Show();
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

        private void SortBtn_Click(object sender, EventArgs e)
        {
            var ledStrip1 = RainbowUtils.createEmptyArray(_LEDManager.LEDStripLength);
            var ledStrip2 = RainbowUtils.createEmptyArray(_LEDManager.LEDStripLength);
            var ledState = RainbowUtils.createEmptyArray(_LEDManager.TotalLEDCount);
            var r = new Random();
            for(int i = 0; i < _LEDManager.TotalLEDCount/2; i++)
            {
                var s = r.Next(0, 3);
                if(s ==0)
                {
                    ledStrip1[i] = MyColor.Red;
                }
                if (s == 1)
                {
                    ledStrip1[i] = MyColor.Green;
                }
                if (s == 2)
                {
                    ledStrip1[i] = MyColor.Blue;
                }

            }
            _LEDManager.SendRGBMessage(_LEDManager.CreateMessage(MyColor.Off));
            Array.Copy(ledStrip1, ledState, _LEDManager.LEDStripLength);

            Array.Copy(ledStrip1, ledStrip2, _LEDManager.LEDStripLength);
            Array.Sort(ledStrip2);
            Array.Copy(ledStrip2, 0, ledState, ledStrip1.Length, ledStrip2.Length);

            _LEDManager.SendRGBMessage(_LEDManager.CreateMessage(ledState));
        }
    }
}
