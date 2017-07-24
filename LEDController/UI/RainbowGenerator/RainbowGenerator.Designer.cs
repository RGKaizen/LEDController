﻿using System;
using System.Windows.Forms;

namespace LEDController.UI
{
    partial class RainbowGenerator
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
            this.posBox = new TextBox();
            this.tryButton = new Button();
            this.button1 = new Button();
            this.BtnStartStop = new Button();
            this.Slider1 = new HScrollBar();
            this.Slider1Lbl = new Label();
            this.Slider1ValueLbl = new Label();
            this.RefreshBar = new HScrollBar();
            this.Slider2ValueLbl = new Label();
            this.Slider2Lbl = new Label();
            this.Slider2 = new HScrollBar();
            this.Slider3ValueLbl = new Label();
            this.Slider3Lbl = new Label();
            this.Slider3 = new HScrollBar();
            this.openFileDialog1 = new OpenFileDialog();
            this.label1 = new Label();
            this.refreshLbl = new Label();
            this.SuspendLayout();
            // 
            // posBox
            // 
            this.posBox.Location = new System.Drawing.Point(12, 12);
            this.posBox.Name = "posBox";
            this.posBox.Size = new System.Drawing.Size(54, 20);
            this.posBox.TabIndex = 0;
            this.posBox.Text = "3";
            // 
            // tryButton
            // 
            this.tryButton.Location = new System.Drawing.Point(105, 38);
            this.tryButton.Name = "tryButton";
            this.tryButton.Size = new System.Drawing.Size(75, 23);
            this.tryButton.TabIndex = 4;
            this.tryButton.Text = "Test";
            this.tryButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearButton);
            // 
            // button2
            // 
            this.BtnStartStop.Location = new System.Drawing.Point(207, 38);
            this.BtnStartStop.Name = "button2";
            this.BtnStartStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStartStop.TabIndex = 9;
            this.BtnStartStop.Text = "PlayPause";
            this.BtnStartStop.UseVisualStyleBackColor = true;
            this.BtnStartStop.Click += new System.EventHandler(this.PlayPause);
            // 
            // Slider1
            // 
            this.Slider1.Location = new System.Drawing.Point(66, 108);
            this.Slider1.Maximum = 1000;
            this.Slider1.Name = "Slider1";
            this.Slider1.Size = new System.Drawing.Size(216, 18);
            this.Slider1.SmallChange = 5;
            this.Slider1.TabIndex = 10;
            this.Slider1.Value = 60;
            this.Slider1.Scroll += new ScrollEventHandler(this.HueSlider_Scroll);
            // 
            // Slider1Lbl
            // 
            this.Slider1Lbl.AutoSize = true;
            this.Slider1Lbl.Location = new System.Drawing.Point(21, 108);
            this.Slider1Lbl.Name = "Slider1Lbl";
            this.Slider1Lbl.Size = new System.Drawing.Size(42, 13);
            this.Slider1Lbl.TabIndex = 11;
            this.Slider1Lbl.Text = "Slider 1";
            // 
            // Slider1ValueLbl
            // 
            this.Slider1ValueLbl.AutoSize = true;
            this.Slider1ValueLbl.Location = new System.Drawing.Point(296, 114);
            this.Slider1ValueLbl.Name = "Slider1ValueLbl";
            this.Slider1ValueLbl.Size = new System.Drawing.Size(28, 13);
            this.Slider1ValueLbl.TabIndex = 12;
            this.Slider1ValueLbl.Text = "Val: ";
            // 
            // RefreshBar
            // 
            this.RefreshBar.Location = new System.Drawing.Point(66, 75);
            this.RefreshBar.Name = "RefreshBar";
            this.RefreshBar.Size = new System.Drawing.Size(216, 18);
            this.RefreshBar.TabIndex = 13;
            this.RefreshBar.Value = 50;
            this.RefreshBar.Scroll += new ScrollEventHandler(this.RefreshBar_Scroll);
            // 
            // Slider2ValueLbl
            // 
            this.Slider2ValueLbl.AutoSize = true;
            this.Slider2ValueLbl.Location = new System.Drawing.Point(296, 144);
            this.Slider2ValueLbl.Name = "Slider2ValueLbl";
            this.Slider2ValueLbl.Size = new System.Drawing.Size(28, 13);
            this.Slider2ValueLbl.TabIndex = 16;
            this.Slider2ValueLbl.Text = "Val: ";
            // 
            // Slider2Lbl
            // 
            this.Slider2Lbl.AutoSize = true;
            this.Slider2Lbl.Location = new System.Drawing.Point(21, 138);
            this.Slider2Lbl.Name = "Slider2Lbl";
            this.Slider2Lbl.Size = new System.Drawing.Size(42, 13);
            this.Slider2Lbl.TabIndex = 15;
            this.Slider2Lbl.Text = "Slider 2";
            // 
            // Slider2
            // 
            this.Slider2.Location = new System.Drawing.Point(66, 138);
            this.Slider2.Maximum = 1000;
            this.Slider2.Name = "Slider2";
            this.Slider2.Size = new System.Drawing.Size(216, 18);
            this.Slider2.SmallChange = 5;
            this.Slider2.TabIndex = 14;
            this.Slider2.Value = 95;
            this.Slider2.Scroll += new ScrollEventHandler(this.SaturationSlider_Scroll);
            // 
            // Slider3ValueLbl
            // 
            this.Slider3ValueLbl.AutoSize = true;
            this.Slider3ValueLbl.Location = new System.Drawing.Point(296, 172);
            this.Slider3ValueLbl.Name = "Slider3ValueLbl";
            this.Slider3ValueLbl.Size = new System.Drawing.Size(28, 13);
            this.Slider3ValueLbl.TabIndex = 19;
            this.Slider3ValueLbl.Text = "Val: ";
            // 
            // Slider3Lbl
            // 
            this.Slider3Lbl.AutoSize = true;
            this.Slider3Lbl.Location = new System.Drawing.Point(21, 166);
            this.Slider3Lbl.Name = "Slider3Lbl";
            this.Slider3Lbl.Size = new System.Drawing.Size(42, 13);
            this.Slider3Lbl.TabIndex = 18;
            this.Slider3Lbl.Text = "Slider 3";
            // 
            // Slider3
            // 
            this.Slider3.Location = new System.Drawing.Point(66, 166);
            this.Slider3.Maximum = 1000;
            this.Slider3.Name = "Slider3";
            this.Slider3.Size = new System.Drawing.Size(216, 18);
            this.Slider3.SmallChange = 5;
            this.Slider3.TabIndex = 17;
            this.Slider3.Value = 125;
            this.Slider3.Scroll += new ScrollEventHandler(this.ValueSlider_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Sleep";
            // 
            // refreshLbl
            // 
            this.refreshLbl.AutoSize = true;
            this.refreshLbl.Location = new System.Drawing.Point(296, 80);
            this.refreshLbl.Name = "refreshLbl";
            this.refreshLbl.Size = new System.Drawing.Size(33, 13);
            this.refreshLbl.TabIndex = 24;
            this.refreshLbl.Text = "T: ms";
            // 
            // RainbowGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 202);
            this.Controls.Add(this.refreshLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Slider3ValueLbl);
            this.Controls.Add(this.Slider3Lbl);
            this.Controls.Add(this.Slider3);
            this.Controls.Add(this.Slider2ValueLbl);
            this.Controls.Add(this.Slider2Lbl);
            this.Controls.Add(this.Slider2);
            this.Controls.Add(this.RefreshBar);
            this.Controls.Add(this.Slider1ValueLbl);
            this.Controls.Add(this.Slider1Lbl);
            this.Controls.Add(this.Slider1);
            this.Controls.Add(this.BtnStartStop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tryButton);
            this.Controls.Add(this.posBox);
            this.Name = "RainbowGenerator";
            this.Text = "Main Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox posBox;
        private Button tryButton;
        private Button button1;
        private Button BtnStartStop;
        private HScrollBar Slider1;
        private Label Slider1Lbl;
        private Label Slider1ValueLbl;
        private HScrollBar RefreshBar;
        private Label Slider2ValueLbl;
        private Label Slider2Lbl;
        private HScrollBar Slider2;
        private Label Slider3ValueLbl;
        private Label Slider3Lbl;
        private HScrollBar Slider3;
        private OpenFileDialog openFileDialog1;
        private Label label1;
        private Label refreshLbl;
    }
}

