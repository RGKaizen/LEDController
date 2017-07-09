using System;
using System.Windows.Forms;

namespace LEDController.UI
{
    public partial class DlgNameChooser : Form
    {
        private TextBox nameTextBox;
        private Label label1;
        private Button Okaybtn;

        public String name = "";

        public DlgNameChooser()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void InitializeComponent()
        {
            nameTextBox = new TextBox();
            label1 = new Label();
            Okaybtn = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(15, 32);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(100, 20);
            nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(125, 13);
            label1.TabIndex = 1;
            label1.Text = "Enter name for MoodSeq";
            // 
            // Okaybtn
            // 
            Okaybtn.Location = new System.Drawing.Point(15, 62);
            Okaybtn.Name = "Okaybtn";
            Okaybtn.Size = new System.Drawing.Size(75, 23);
            Okaybtn.TabIndex = 2;
            Okaybtn.Text = "Okay";
            Okaybtn.UseVisualStyleBackColor = true;
            Okaybtn.Click += new System.EventHandler(Okaybtn_Click);
            // 
            // DlgNameChooser
            // 
            ClientSize = new System.Drawing.Size(143, 97);
            Controls.Add(Okaybtn);
            Controls.Add(label1);
            Controls.Add(nameTextBox);
            Name = "DlgNameChooser";
            ResumeLayout(false);
            PerformLayout();

        }


        private void Okaybtn_Click(object sender, EventArgs e)
        {
            name = nameTextBox.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}
