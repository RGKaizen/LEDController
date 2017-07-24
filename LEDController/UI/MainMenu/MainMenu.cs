using System;
using System.Windows.Forms;
using LEDController.Utils;
using LEDController.Interfaces;
using LEDController.Manager;

namespace LEDController.UI
{
    public class MainMenu : Form
    {

        private Button button1;
        private Button button2;
        private Button button4;

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Color Wheel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Rainbow Gen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(239, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 45);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 75);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainMenu";
            this.Text = "Double Rainbow";
            this.ResumeLayout(false);

        }

        private ILEDManager _LEDManager { get; set; }

        public MainMenu()
        {
            InitializeComponent();
            _LEDManager = new LEDManager("192.168.1.103", "5000", 120);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ColorChooser(_LEDManager).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RainbowGenerator(new HueGenerator(0.0f, 0.0f, 0.0f), _LEDManager).Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            var ledStrip1 = RainbowUtils.createEmptyArray(_LEDManager.StripLength);
            var ledStrip2 = RainbowUtils.createEmptyArray(_LEDManager.StripLength);
            var ledState = RainbowUtils.createEmptyArray(_LEDManager.TotalLEDCount);
            var r = new Random();
            for(int i = 0; i < _LEDManager.TotalLEDCount/2; i++)
            {
                var s = r.Next(0, 3);
                if(s ==0)
                {
                    ledStrip1[i] = DRColor.Red;
                }
                if (s == 1)
                {
                    ledStrip1[i] = DRColor.Green;
                }
                if (s == 2)
                {
                    ledStrip1[i] = DRColor.Blue;
                }

            }
            _LEDManager.SendRGBMessage(_LEDManager.CreateMessage(DRColor.Off));
            Array.Copy(ledStrip1, ledState, _LEDManager.StripLength);

            Array.Copy(ledStrip1, ledStrip2, _LEDManager.StripLength);
            Array.Sort(ledStrip2);
            Array.Copy(ledStrip2, 0, ledState, ledStrip1.Length, ledStrip2.Length);

            _LEDManager.SendRGBMessage(_LEDManager.CreateMessage(ledState));
        }
    }
}
