using System;
using System.Windows.Forms;
using LEDController.Utils;
using LEDController.Interfaces;
using LEDController.Manager;
using LEDController.Generators;

namespace LEDController.UI
{
    public class MainMenu : Form
    {

        private Button colorWheelBtn;
        private Button rainbowBtn;
        private Button clearBtn;
        private Button sortBtn;

        private void InitializeComponent()
        {
            this.colorWheelBtn = new System.Windows.Forms.Button();
            this.rainbowBtn = new System.Windows.Forms.Button();
            this.sortBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colorWheelBtn
            // 
            this.colorWheelBtn.Location = new System.Drawing.Point(13, 12);
            this.colorWheelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.colorWheelBtn.Name = "colorWheelBtn";
            this.colorWheelBtn.Size = new System.Drawing.Size(120, 70);
            this.colorWheelBtn.TabIndex = 0;
            this.colorWheelBtn.Text = "Color Wheel";
            this.colorWheelBtn.UseVisualStyleBackColor = true;
            this.colorWheelBtn.Click += new System.EventHandler(this.ColorWheelBtn_Click);
            // 
            // rainbowBtn
            // 
            this.rainbowBtn.Location = new System.Drawing.Point(141, 12);
            this.rainbowBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rainbowBtn.Name = "rainbowBtn";
            this.rainbowBtn.Size = new System.Drawing.Size(120, 70);
            this.rainbowBtn.TabIndex = 1;
            this.rainbowBtn.Text = "Rainbow Gen";
            this.rainbowBtn.UseVisualStyleBackColor = true;
            this.rainbowBtn.Click += new System.EventHandler(this.RainbowBtn_Click);
            // 
            // sortBtn
            // 
            this.sortBtn.Location = new System.Drawing.Point(269, 12);
            this.sortBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(120, 70);
            this.sortBtn.TabIndex = 2;
            this.sortBtn.Text = "Sort";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.SortBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(396, 12);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(120, 70);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 99);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.sortBtn);
            this.Controls.Add(this.rainbowBtn);
            this.Controls.Add(this.colorWheelBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainMenu";
            this.Text = "Double Rainbow";
            this.ResumeLayout(false);

        }

        private ILedClient _ledClient { get; set; }
        private ILedManager _ledManager { get; set; }
        private IPaletteManager _paletteManager { get; set; }

        public MainMenu()
        {
            InitializeComponent();

            _ledClient = new LedRestClient("192.168.1.101", "5000", 120);
            _ledManager = new LedManager(120, 2);
            _paletteManager = new PaletteManager(1);       

            new DoubleRainbow(new AnimatorClient(_ledClient, new PushAnimator(_ledManager, _paletteManager), new HueGenerator())
                ).Show();
        }

        private void ColorWheelBtn_Click(object sender, EventArgs e)
        {
            new ColorChooser(_ledClient).Show();
        }

        private void RainbowBtn_Click(object sender, EventArgs e)
        {
            //new DoubleRainbow(new AnimatorClient(_ledClient, new LooperAnimator(_ledManager), new HueGenerator())
            //    ).Show();
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
            var ledStrip1 = RainbowUtils.createEmptyArray(_ledManager.StripLength);
            var ledStrip2 = RainbowUtils.createEmptyArray(_ledManager.StripLength);
            var ledState = RainbowUtils.createEmptyArray(_ledManager.LEDCount);
            var r = new Random();
            for(int i = 0; i < _ledManager.LEDCount/2; i++)
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
            //_LEDManager.SendRGBMessage(_LEDManager.CreateMessage(MyColor.Off));
            Array.Copy(ledStrip1, ledState, _ledManager.StripLength);

            Array.Copy(ledStrip1, ledStrip2, _ledManager.StripLength);
            Array.Sort(ledStrip2);
            Array.Copy(ledStrip2, 0, ledState, ledStrip1.Length, ledStrip2.Length);

            //_LEDManager.SendRGBMessage(_LEDManager.CreateMessage(ledState));
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            _ledClient.Send(MyColor.Off);
        }
    }
}
