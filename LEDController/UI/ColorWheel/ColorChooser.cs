using LEDController.Interfaces;
using LEDController.Utils;
using System.Drawing;
using System.Windows.Forms;
using static LEDController.Utils.MyColor;

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
			lblBlue.Location = new Point(312, 360);
			lblBlue.Name = "lblBlue";
			lblBlue.Size = new Size(40, 23);
			lblBlue.TabIndex = 54;
			lblBlue.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblGreen
			// 
			lblGreen.Location = new Point(312, 336);
			lblGreen.Name = "lblGreen";
			lblGreen.Size = new Size(40, 23);
			lblGreen.TabIndex = 53;
			lblGreen.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblRed
			// 
			lblRed.Location = new Point(312, 312);
			lblRed.Name = "lblRed";
			lblRed.Size = new Size(40, 23);
			lblRed.TabIndex = 52;
			lblRed.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblBrightness
			// 
			lblBrightness.Location = new Point(312, 280);
			lblBrightness.Name = "lblBrightness";
			lblBrightness.Size = new Size(40, 23);
			lblBrightness.TabIndex = 51;
			lblBrightness.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblSaturation
			// 
			lblSaturation.Location = new Point(312, 256);
			lblSaturation.Name = "lblSaturation";
			lblSaturation.Size = new Size(40, 23);
			lblSaturation.TabIndex = 50;
			lblSaturation.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblHue
			// 
			lblHue.Location = new Point(312, 232);
			lblHue.Name = "lblHue";
			lblHue.Size = new Size(40, 23);
			lblHue.TabIndex = 49;
			lblHue.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// hsbBlue
			// 
			hsbBlue.LargeChange = 1;
			hsbBlue.Location = new Point(80, 360);
			hsbBlue.Maximum = 255;
			hsbBlue.Name = "hsbBlue";
			hsbBlue.Size = new Size(224, 18);
			hsbBlue.Scroll += new ScrollEventHandler(HandleRGBScroll);
			// 
			// hsbGreen
			// 
			hsbGreen.LargeChange = 1;
			hsbGreen.Location = new Point(80, 336);
			hsbGreen.Maximum = 255;
			hsbGreen.Name = "hsbGreen";
			hsbGreen.Size = new Size(224, 18);
			hsbGreen.Scroll += new ScrollEventHandler(HandleRGBScroll);
			// 
			// hsbRed
			// 
			hsbRed.LargeChange = 1;
			hsbRed.Location = new Point(80, 312);
			hsbRed.Maximum = 255;
			hsbRed.Name = "hsbRed";
			hsbRed.Size = new Size(224, 18);
			hsbRed.TabIndex = 46;
			hsbRed.Scroll += new ScrollEventHandler(HandleRGBScroll);
			// 
			// hsbBrightness
			// 
			hsbBrightness.LargeChange = 1;
			hsbBrightness.Location = new Point(80, 280);
			hsbBrightness.Maximum = 255;
			hsbBrightness.Name = "hsbBrightness";
			hsbBrightness.Size = new Size(224, 18);
			hsbBrightness.TabIndex = 45;
			hsbBrightness.Scroll += new ScrollEventHandler(HandleHSVScroll);
			// 
			// hsbSaturation
			// 
			hsbSaturation.LargeChange = 1;
			hsbSaturation.Location = new Point(80, 256);
			hsbSaturation.Maximum = 255;
			hsbSaturation.Name = "hsbSaturation";
			hsbSaturation.Size = new Size(224, 18);
			hsbSaturation.Scroll += new ScrollEventHandler(HandleHSVScroll);
			// 
			// hsbHue
			// 
			hsbHue.LargeChange = 1;
			hsbHue.Location = new Point(80, 232);
			hsbHue.Maximum = 255;
			hsbHue.Name = "hsbHue";
			hsbHue.Size = new Size(224, 18);
			hsbHue.Scroll += new ScrollEventHandler(HandleHSVScroll);
			// 
			// Label3
			// 
			Label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Label3.Location = new Point(8, 360);
			Label3.Name = "Label3";
			Label3.Size = new Size(72, 18);
			Label3.TabIndex = 34;
			Label3.Text = "Blue";
			Label3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// Label7
			// 
			Label7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Label7.Location = new Point(8, 280);
			Label7.Name = "Label7";
			Label7.Size = new Size(72, 18);
			Label7.TabIndex = 37;
			Label7.Text = "Brightness";
			Label7.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// pnlColor
			// 
			pnlColor.Location = new Point(8, 8);
			pnlColor.Name = "pnlColor";
			pnlColor.Size = new Size(224, 216);
			pnlColor.TabIndex = 38;
			pnlColor.Visible = false;
			// 
			// Label6
			// 
			Label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Label6.Location = new Point(8, 256);
			Label6.Name = "Label6";
			Label6.Size = new Size(72, 18);
			Label6.TabIndex = 36;
			Label6.Text = "Saturation";
			Label6.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// Label1
			// 
			Label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Label1.Location = new Point(8, 312);
			Label1.Name = "Label1";
			Label1.Size = new Size(72, 18);
			Label1.TabIndex = 32;
			Label1.Text = "Red";
			Label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// Label5
			// 
			Label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Label5.Location = new Point(8, 232);
			Label5.Name = "Label5";
			Label5.Size = new Size(72, 18);
			Label5.TabIndex = 35;
			Label5.Text = "Hue";
			Label5.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// pnlSelectedColor
			// 
			pnlSelectedColor.Location = new Point(287, 93);
			pnlSelectedColor.Name = "pnlSelectedColor";
			pnlSelectedColor.Size = new Size(44, 47);
			pnlSelectedColor.TabIndex = 40;
			pnlSelectedColor.Visible = false;
			// 
			// pnlBrightness
			// 
			pnlBrightness.Location = new Point(240, 8);
			pnlBrightness.Name = "pnlBrightness";
			pnlBrightness.Size = new Size(24, 216);
			pnlBrightness.TabIndex = 39;
			pnlBrightness.Visible = false;
			// 
			// Label2
			// 
			Label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Label2.Location = new Point(8, 336);
			Label2.Name = "Label2";
			Label2.Size = new Size(72, 18);
			Label2.TabIndex = 33;
			Label2.Text = "Green";
			Label2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// ColorChooser
			// 
			AutoScaleBaseSize = new Size(5, 13);
			ClientSize = new Size(362, 386);
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
			MouseUp += new MouseEventHandler(HandleMouseU);
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

		private ColorWheel _colorWheel;
		private RGB _RGB;
		private HSV _HSV;

		private void ColorChooser_Load(object sender, System.EventArgs e)
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			pnlSelectedColor.Visible = false;
			pnlBrightness.Visible = false;
			pnlColor.Visible = false;

			var SelectedColorRectangle =  new Rectangle(pnlSelectedColor.Location, pnlSelectedColor.Size);
			var BrightnessRectangle = new Rectangle(pnlBrightness.Location, pnlBrightness.Size);
			var ColorRectangle = new Rectangle(pnlColor.Location, pnlColor.Size);

			var startColor = new HSV(127, 256, 82);
			_colorWheel = new ColorWheel(ColorRectangle, BrightnessRectangle, SelectedColorRectangle, startColor);
			_colorWheel.ColorChanged += new ColorWheel.ColorChangedEventHandler(colorWheel_Changed);
			SetRGB(startColor.toRGB());
			SetHSV(startColor);		
		}

		private void HandleMouse(object sender,  MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) 
			{
				_changeType = ChangeStyle.MouseMove;
				_selectedPoint = new Point(e.X, e.Y);
				Invalidate();
			}
		}

		private void HandleMouseU(object sender,  MouseEventArgs e)
		{
			_colorWheel.SetMouseUp();
			_changeType = ChangeStyle.None;
		}

		private void SetRGBLabels(RGB RGB) 
		{
			lblRed.Text = RGB.Red.ToString();
			lblGreen.Text = RGB.Green.ToString();
			lblBlue.Text = RGB.Blue.ToString();
		}

		private void SetHSVLabels(HSV HSV) 
		{
			lblHue.Text = HSV.Hue.ToString();
			lblSaturation.Text = HSV.Saturation.ToString();
			lblBrightness.Text = HSV.Value.ToString();
		}

		private void SetRGB(RGB RGB) 
		{
			if (RGB == null)
				return;
			// Update the RGB values on the form.
			UpdateScrollbarValue(hsbRed, RGB.Red);
			UpdateScrollbarValue(hsbBlue, RGB.Blue);
			UpdateScrollbarValue(hsbGreen, RGB.Green);
			SetRGBLabels(RGB);
	   }

		private void SetHSV(HSV HSV) 
		{
			if (HSV == null)
				return;

			// Update the HSV values on the form.
			UpdateScrollbarValue(hsbHue, HSV.Hue);
			UpdateScrollbarValue(hsbSaturation, HSV.Saturation);
			UpdateScrollbarValue(hsbBrightness, HSV.Value);
			SetHSVLabels(HSV);
		}

		private void UpdateScrollbarValue(HScrollBar hsb, int value) 
		{
			hsb.Value = value.Clamp(0,255);
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

		private void HandleHSVScroll(object sender, ScrollEventArgs e)  
		{
			_changeType = ChangeStyle.HSV;
			_HSV = new HSV(hsbHue.Value, hsbSaturation.Value, hsbBrightness.Value);
			SetRGB(_HSV.toRGB());
			SetHSVLabels(_HSV);
			Invalidate();
			_ledClient.Send(_HSV.toRGB());
		}

		private void HandleRGBScroll(object sender, ScrollEventArgs e)
		{
			_changeType = ChangeStyle.RGB;
			_RGB = new RGB(hsbRed.Value, hsbGreen.Value, hsbBlue.Value);
			SetHSV(new HSV(_RGB));
			SetRGBLabels(_RGB);
			Invalidate();
			_ledClient.Send(_RGB);
		}

		private void ColorChooser_Paint(object sender, PaintEventArgs e)
		{
			// Depending on the circumstances, force angle repaint
			// of the color wheel passing different information.
			switch (_changeType)
			{
				case ChangeStyle.HSV:
					_colorWheel.Draw(e.Graphics, _HSV);
					break;
				case ChangeStyle.MouseMove:
				case ChangeStyle.None:
					_colorWheel.Draw(e.Graphics, _selectedPoint);
					break;
				case ChangeStyle.RGB:
					_colorWheel.Draw(e.Graphics, _RGB);
					break;
			}
		}

	}
}

