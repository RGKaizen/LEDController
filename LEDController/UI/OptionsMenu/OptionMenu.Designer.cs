using System.Windows.Forms;

namespace LEDController.UI
{
    partial class MainMenu
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.strip_comboBox = new ComboBox();
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(249, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "Mood Lighting";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // strip_comboBox
            // 
            this.strip_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.strip_comboBox.FormattingEnabled = true;
            this.strip_comboBox.Items.AddRange(new object[] {
            "Kai",
            "Zen",
            "Both"});
            this.strip_comboBox.Location = new System.Drawing.Point(32, 68);
            this.strip_comboBox.Name = "strip_comboBox";
            this.strip_comboBox.Size = new System.Drawing.Size(121, 21);
            this.strip_comboBox.TabIndex = 3;
            // 
            // OptionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 99);
            this.Controls.Add(this.strip_comboBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "OptionMenu";
            this.Text = "Double Rainbow";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox strip_comboBox;
    }
}