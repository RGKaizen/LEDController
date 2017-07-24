using System;
using System.Windows.Forms;
using LEDController.Utils;
using LEDController.Interfaces;
using LEDController.Manager;

namespace LEDController.UI
{
    public partial class MainMenu : Form
    {
        private ILEDManager _LEDManager { get; set; }

        public MainMenu()
        {
            InitializeComponent();
            _LEDManager = new LEDManager("192.168.1.103", "5000", 60);
            strip_comboBox.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ColorChooser(_LEDManager).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RainbowGenerator(new HueGenerator(0.0f, 0.0f, 0.0f), _LEDManager).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MoodSelector(_LEDManager).Show();
        }
    }
}
