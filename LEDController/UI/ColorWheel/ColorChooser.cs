using LEDController.Interfaces;
using LEDController.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace LEDController.UI
{
    /// <summary>
    /// Written by Ken Getz
    /// </summary>
	public class ColorChooser : Form
	{
		internal Label lblBlue;
		internal Label lblGreen;
		internal Label lblRed;
		internal Label lblBrightness;
		internal Label lblSaturation;
		internal Label lblHue;
		internal HScrollBar hsbBlue;
		internal HScrollBar hsbGreen;
		internal HScrollBar hsbRed;
		internal HScrollBar hsbBrightness;
		internal HScrollBar hsbSaturation;
        internal HScrollBar hsbHue;
		internal Label Label3;
		internal Label Label7;
		internal Panel pnlColor;
		internal Label Label6;
		internal Label Label1;
		internal Label Label5;
		internal Panel pnlSelectedColor;
		internal Panel pnlBrightness;
        internal Label Label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private ILedClient _ledClient { get; set; }

		public ColorChooser(ILedClient ledClient)
		{
			InitializeComponent();
            _ledClient = ledClient;
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            lblBlue = new Label();
            lblGreen = new Label();
            lblRed = new Label();
            lblBrightness = new Label();
            lblSaturation = new Label();
            lblHue = new Label();
            hsbBlue = new HScrollBar();
            hsbGreen = new HScrollBar();
            hsbRed = new HScrollBar();
            hsbBrightness = new HScrollBar();
            hsbSaturation = new HScrollBar();
            hsbHue = new HScrollBar();
            Label3 = new Label();
            Label7 = new Label();
            pnlColor = new Panel();
            Label6 = new Label();
            Label1 = new Label();
            Label5 = new Label();
            pnlSelectedColor = new Panel();
            pnlBrightness = new Panel();
            Label2 = new Label();
            SuspendLayout();
            // 
            // lblBlue
            // 
            lblBlue.Location = new System.Drawing.Point(312, 360);
            lblBlue.Name = "lblBlue";
            lblBlue.Size = new System.Drawing.Size(40, 23);
            lblBlue.TabIndex = 54;
            lblBlue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGreen
            // 
            lblGreen.Location = new System.Drawing.Point(312, 336);
            lblGreen.Name = "lblGreen";
            lblGreen.Size = new System.Drawing.Size(40, 23);
            lblGreen.TabIndex = 53;
            lblGreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRed
            // 
            lblRed.Location = new System.Drawing.Point(312, 312);
            lblRed.Name = "lblRed";
            lblRed.Size = new System.Drawing.Size(40, 23);
            lblRed.TabIndex = 52;
            lblRed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBrightness
            // 
            lblBrightness.Location = new System.Drawing.Point(312, 280);
            lblBrightness.Name = "lblBrightness";
            lblBrightness.Size = new System.Drawing.Size(40, 23);
            lblBrightness.TabIndex = 51;
            lblBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSaturation
            // 
            lblSaturation.Location = new System.Drawing.Point(312, 256);
            lblSaturation.Name = "lblSaturation";
            lblSaturation.Size = new System.Drawing.Size(40, 23);
            lblSaturation.TabIndex = 50;
            lblSaturation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHue
            // 
            lblHue.Location = new System.Drawing.Point(312, 232);
            lblHue.Name = "lblHue";
            lblHue.Size = new System.Drawing.Size(40, 23);
            lblHue.TabIndex = 49;
            lblHue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hsbBlue
            // 
            hsbBlue.LargeChange = 1;
            hsbBlue.Location = new System.Drawing.Point(80, 360);
            hsbBlue.Maximum = 128;
            hsbBlue.Name = "hsbBlue";
            hsbBlue.Size = new System.Drawing.Size(224, 18);
            hsbBlue.TabIndex = 48;
            hsbBlue.Scroll += new ScrollEventHandler(HandleRGBScroll);
            // 
            // hsbGreen
            // 
            hsbGreen.LargeChange = 1;
            hsbGreen.Location = new System.Drawing.Point(80, 336);
            hsbGreen.Maximum = 128;
            hsbGreen.Name = "hsbGreen";
            hsbGreen.Size = new System.Drawing.Size(224, 18);
            hsbGreen.TabIndex = 47;
            hsbGreen.Scroll += new ScrollEventHandler(HandleRGBScroll);
            // 
            // hsbRed
            // 
            hsbRed.LargeChange = 1;
            hsbRed.Location = new System.Drawing.Point(80, 312);
            hsbRed.Maximum = 128;
            hsbRed.Name = "hsbRed";
            hsbRed.Size = new System.Drawing.Size(224, 18);
            hsbRed.TabIndex = 46;
            hsbRed.Scroll += new ScrollEventHandler(HandleRGBScroll);
            // 
            // hsbBrightness
            // 
            hsbBrightness.LargeChange = 1;
            hsbBrightness.Location = new System.Drawing.Point(80, 280);
            hsbBrightness.Maximum = 255;
            hsbBrightness.Name = "hsbBrightness";
            hsbBrightness.Size = new System.Drawing.Size(224, 18);
            hsbBrightness.TabIndex = 45;
            hsbBrightness.Scroll += new ScrollEventHandler(HandleHSVScroll);
            // 
            // hsbSaturation
            // 
            hsbSaturation.LargeChange = 1;
            hsbSaturation.Location = new System.Drawing.Point(80, 256);
            hsbSaturation.Maximum = 255;
            hsbSaturation.Name = "hsbSaturation";
            hsbSaturation.Size = new System.Drawing.Size(224, 18);
            hsbSaturation.TabIndex = 44;
            hsbSaturation.Scroll += new ScrollEventHandler(HandleHSVScroll);
            // 
            // hsbHue
            // 
            hsbHue.LargeChange = 1;
            hsbHue.Location = new System.Drawing.Point(80, 232);
            hsbHue.Maximum = 255;
            hsbHue.Name = "hsbHue";
            hsbHue.Size = new System.Drawing.Size(224, 18);
            hsbHue.TabIndex = 43;
            hsbHue.Scroll += new ScrollEventHandler(HandleHSVScroll);
            // 
            // Label3
            // 
            Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label3.Location = new System.Drawing.Point(8, 360);
            Label3.Name = "Label3";
            Label3.Size = new System.Drawing.Size(72, 18);
            Label3.TabIndex = 34;
            Label3.Text = "Blue";
            Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label7.Location = new System.Drawing.Point(8, 280);
            Label7.Name = "Label7";
            Label7.Size = new System.Drawing.Size(72, 18);
            Label7.TabIndex = 37;
            Label7.Text = "Brightness";
            Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlColor
            // 
            pnlColor.Location = new System.Drawing.Point(8, 8);
            pnlColor.Name = "pnlColor";
            pnlColor.Size = new System.Drawing.Size(224, 216);
            pnlColor.TabIndex = 38;
            pnlColor.Visible = false;
            // 
            // Label6
            // 
            Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label6.Location = new System.Drawing.Point(8, 256);
            Label6.Name = "Label6";
            Label6.Size = new System.Drawing.Size(72, 18);
            Label6.TabIndex = 36;
            Label6.Text = "Saturation";
            Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label1.Location = new System.Drawing.Point(8, 312);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(72, 18);
            Label1.TabIndex = 32;
            Label1.Text = "Red";
            Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label5.Location = new System.Drawing.Point(8, 232);
            Label5.Name = "Label5";
            Label5.Size = new System.Drawing.Size(72, 18);
            Label5.TabIndex = 35;
            Label5.Text = "Hue";
            Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSelectedColor
            // 
            pnlSelectedColor.Location = new System.Drawing.Point(287, 93);
            pnlSelectedColor.Name = "pnlSelectedColor";
            pnlSelectedColor.Size = new System.Drawing.Size(44, 47);
            pnlSelectedColor.TabIndex = 40;
            pnlSelectedColor.Visible = false;
            // 
            // pnlBrightness
            // 
            pnlBrightness.Location = new System.Drawing.Point(240, 8);
            pnlBrightness.Name = "pnlBrightness";
            pnlBrightness.Size = new System.Drawing.Size(24, 216);
            pnlBrightness.TabIndex = 39;
            pnlBrightness.Visible = false;
            // 
            // Label2
            // 
            Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label2.Location = new System.Drawing.Point(8, 336);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(72, 18);
            Label2.TabIndex = 33;
            Label2.Text = "Green";
            Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ColorChooser
            // 
            AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            ClientSize = new System.Drawing.Size(362, 386);
            Controls.Add(lblBlue);
            Controls.Add(lblGreen);
            Controls.Add(lblRed);
            Controls.Add(lblBrightness);
            Controls.Add(lblSaturation);
            Controls.Add(lblHue);
            Controls.Add(hsbBlue);
            Controls.Add(hsbGreen);
            Controls.Add(hsbRed);
            Controls.Add(hsbBrightness);
            Controls.Add(hsbSaturation);
            Controls.Add(hsbHue);
            Controls.Add(Label3);
            Controls.Add(Label7);
            Controls.Add(pnlColor);
            Controls.Add(Label6);
            Controls.Add(Label1);
            Controls.Add(Label5);
            Controls.Add(pnlSelectedColor);
            Controls.Add(pnlBrightness);
            Controls.Add(Label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ColorChooser";
            Text = "Select Color";
            Load += new System.EventHandler(ColorChooser_Load);
            Paint += new PaintEventHandler(ColorChooser_Paint);
            MouseDown += new MouseEventHandler(HandleMouse);
            MouseMove += new MouseEventHandler(HandleMouse);
            MouseUp += new MouseEventHandler(frmMain_MouseUp);
            ResumeLayout(false);

		}
		#endregion

		private enum ChangeStyle
		{
			MouseMove,
			RGB,
			HSV,
			None
		}

		private ChangeStyle _changeType = ChangeStyle.None;
		private Point _selectedPoint;

		private ColorWheel myColorWheel;
        private MyColor.RGB RGB;
		private MyColor.HSV HSV;

		private void ColorChooser_Load(object sender, System.EventArgs e)
		{
            MyColor.HSV default_color = new MyColor.HSV(127, 256, 82);

            // Turn on double-buffering, so the form looks better. 
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

			// These properties are set in design view, as well, but they
			// have to be set to false in order for the Paint
			// event to be able to display their contents.
			// Never hurts to make sure they're invisible.
			pnlSelectedColor.Visible = false;
			pnlBrightness.Visible = false;
			pnlColor.Visible = false;

			// Calculate the coordinates of the three
			// required regions on the form.
			Rectangle SelectedColorRectangle =  new Rectangle(pnlSelectedColor.Location, pnlSelectedColor.Size);
			Rectangle BrightnessRectangle = new Rectangle(pnlBrightness.Location, pnlBrightness.Size);
			Rectangle ColorRectangle = new Rectangle(pnlColor.Location, pnlColor.Size);

			// Create the new ColorWheel class, indicating
			// the locations of the color wheel itself, the
			// brightness area, and the position of the selected color.
            myColorWheel = new ColorWheel(ColorRectangle, BrightnessRectangle, SelectedColorRectangle, default_color);
			myColorWheel.ColorChanged += new ColorWheel.ColorChangedEventHandler(colorWheel_Changed);

            // Set the RGB and HSV values 
            // of the NumericUpDown controls.
            SetRGB(new MyColor.RGB(default_color));
            SetHSV(default_color);		
		}

		private void HandleMouse(object sender,  MouseEventArgs e)
		{
			// If you have the left mouse button down, 
			// then update the selectedPoint value and 
			// force angle repaint of the color wheel.
			if ( e.Button == MouseButtons.Left ) 
			{
				_changeType = ChangeStyle.MouseMove;
				_selectedPoint = new Point(e.X, e.Y);
                Invalidate();
			}
		}

		private void frmMain_MouseUp(object sender,  MouseEventArgs e)
		{
			myColorWheel.SetMouseUp();
			_changeType = ChangeStyle.None;
		}

        private void SetRGBLabels(MyColor.RGB RGB) 
		{
			RefreshText(lblRed, RGB.Red);
			RefreshText(lblBlue, RGB.Blue);
			RefreshText(lblGreen, RGB.Green);
		}

		private void SetHSVLabels(MyColor.HSV HSV) 
		{
			RefreshText(lblHue, HSV.Hue);
			RefreshText(lblSaturation, HSV.Saturation);
			RefreshText(lblBrightness, HSV.Value);
		}

        private void SetRGB(MyColor.RGB RGB) 
		{
            if (RGB == null)
                return;
			// Update the RGB values on the form.
			RefreshValue(hsbRed, RGB.Red);
			RefreshValue(hsbBlue, RGB.Blue);
			RefreshValue(hsbGreen, RGB.Green);
			SetRGBLabels(RGB);
	   }

		private void SetHSV(MyColor.HSV HSV) 
		{
            if (HSV == null)
                return;

			// Update the HSV values on the form.
			RefreshValue(hsbHue, HSV.Hue);
			RefreshValue(hsbSaturation, HSV.Saturation);
			RefreshValue(hsbBrightness, HSV.Value);
			SetHSVLabels(HSV);
		}

		private void RefreshValue(HScrollBar hsb, int value) 
		{
            if (value >= 128)
            {
                value = 128;
            }
            hsb.Value = value;
		}

		private void RefreshText(Label lbl, int value) 
		{
			lbl.Text = value.ToString();
		}

		public Color ActiveColor  
		{
			// Get or set the color to be
			// displayed in the color wheel.
			get 
			{
				return myColorWheel.Color;
			}

			set 
			{
				// Indicate the color change type. Either RGB or HSV
				// will cause the color wheel to update the position
				// of the pointer.
				_changeType = ChangeStyle.RGB;
                SetRGB(new MyColor.RGB(value.R, value.G, value.B));
                SetHSV(new MyColor.HSV(RGB));
			}
		}

		private void colorWheel_Changed(object sender,  ColorChangedEventArgs e)  
		{
            if(e.RGB == null || e.HSV == null)
            {
                return;
            }

			SetRGB(e.RGB);
			SetHSV(e.HSV);
            _ledClient.Send(e.RGB);
        }

        // If the H, S, or V values change, use this 
        // code to update the RGB values and invalidate
        // the color wheel (so it updates the pointers).
        // Check the isInUpdate flag to avoid recursive events
        // when you update the NumericUpdownControls.
        private void HandleHSVScroll(object sender, ScrollEventArgs e)  
		{
			_changeType = ChangeStyle.HSV;
            HSV = new MyColor.HSV(hsbHue.Value, hsbSaturation.Value, hsbBrightness.Value);
            SetRGB(new MyColor.RGB(HSV));
			SetHSVLabels(HSV);
			Invalidate();
            _ledClient.Send(new MyColor.RGB(HSV));
		}

        // If the R, G, or B values change, use this 
        // code to update the HSV values and invalidate
        // the color wheel (so it updates the pointers).
        // Check the isInUpdate flag to avoid recursive events
        // when you update the NumericUpdownControls.
		private void HandleRGBScroll(object sender, ScrollEventArgs e)
		{

			_changeType = ChangeStyle.RGB;
            RGB = new MyColor.RGB(hsbRed.Value, hsbGreen.Value, hsbBlue.Value);
            SetHSV(new MyColor.HSV(RGB));
			SetRGBLabels(RGB);
			Invalidate();
            _ledClient.Send(RGB);
        }

		private void ColorChooser_Paint(object sender, PaintEventArgs e)
		{
			// Depending on the circumstances, force angle repaint
			// of the color wheel passing different information.
			switch (_changeType)
			{
				case ChangeStyle.HSV:
					myColorWheel.Draw(e.Graphics, HSV);
					break;
				case ChangeStyle.MouseMove:
				case ChangeStyle.None:
					myColorWheel.Draw(e.Graphics, _selectedPoint);
					break;
				case ChangeStyle.RGB:
					myColorWheel.Draw(e.Graphics, RGB);
					break;
			}
		}

	}
}

