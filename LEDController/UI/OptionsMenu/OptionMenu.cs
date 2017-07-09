using System;
using System.Windows.Forms;
using LEDController.Utils;
using LEDController.Interfaces;
using LEDController.Manager;

namespace LEDController.UI
{
    public partial class OptionMenu : Form
    {
        private ILEDManager _LEDManager { get; set; }

        public OptionMenu()
        {
            InitializeComponent();
            _LEDManager = new LEDManager("192.168.1.102", "5000", 60);
            strip_comboBox.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ColorChooser(_LEDManager).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RainbowGenerator(new HueGenerator(127.0f, 55.0f, 127.0f), _LEDManager).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MoodSelector(_LEDManager).Show();
        }
    }
}
