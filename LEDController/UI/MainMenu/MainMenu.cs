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
            SuspendLayout();

            colorWheelBtn = new Button
            {
                Location = new System.Drawing.Point(13, 12),
                Margin = new Padding(4, 5, 4, 5),
                Name = "colorWheelBtn",
                Size = new System.Drawing.Size(120, 70),
                TabIndex = 0,
                Text = "Color Wheel",
                UseVisualStyleBackColor = true,
               
            };
            colorWheelBtn.Click += new EventHandler(ColorWheelBtn_Click);

            rainbowBtn = new Button
            {
                Location = new System.Drawing.Point(141, 12),
                Margin = new Padding(4, 5, 4, 5),
                Name = "rainbowBtn",
                Size = new System.Drawing.Size(120, 70),
                Text = "Rainbow Gen",
                UseVisualStyleBackColor = true,

            };
            rainbowBtn.Click += new EventHandler(RainbowBtn_Click);

            clearBtn = new Button
            {
                Location = new System.Drawing.Point(396, 12),
                Margin = new Padding(4, 5, 4, 5),
                Name = "clearBtn",
                Size = new System.Drawing.Size(120, 70),
                Text = "Clear",
                UseVisualStyleBackColor = true,

            };
            clearBtn.Click += new EventHandler(ClearBtn_Click);


            // 
            // MainMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(530, 99);
            Controls.Add(clearBtn);
            Controls.Add(sortBtn);
            Controls.Add(rainbowBtn);
            Controls.Add(colorWheelBtn);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainMenu";
            Text = "Double Rainbow";
            ResumeLayout(false);

        }

        private ILedClient _ledClient { get; set; }
        private ILedManager _ledManager { get; set; }
        private IPaletteManager _paletteManager { get; set; }

        public MainMenu()
        {
            InitializeComponent();

            _ledClient = new LedRestClient("192.168.1.200", "5000", 120);
            _ledManager = new LedManager(120, 2);
            _paletteManager = new PaletteManager(2);       
        }

        private void ColorWheelBtn_Click(object sender, EventArgs e)
        {
            new ColorChooser(_ledClient).Show();
        }

        private void RainbowBtn_Click(object sender, EventArgs e)
        {
            new DoubleRainbow(new AnimatorClient(_ledClient, new LooperAnimator(_ledManager, _paletteManager), new HueGenerator())
                ).Show();
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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            _ledClient.Send(MyColor.Off);
        }
    }
}
