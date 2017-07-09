using System;
using System.Windows.Forms;
using LEDController.Utils;

namespace LEDController.UI
{
    public partial class OptionMenu : Form
    {
        public OptionMenu()
        {
            InitializeComponent();
            strip_comboBox.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ColorChooser().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RainbowGenerator(new HueGenerator(127.0f, 55.0f, 127.0f)).Show();
        }

        private void OptionMenu_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RainbowUtils.TurnOff();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MoodSelector().Show();
        }

        private void strip_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = strip_comboBox.SelectedItem.ToString();
            if (selected.Equals("Both"))
            {
            }
            else if (selected.Equals("Kai"))
            {
            }
            else if (selected.Equals("Zen"))
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
