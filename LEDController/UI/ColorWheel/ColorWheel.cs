using LEDController.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using static LEDController.Utils.MyColor;

namespace LEDController.UI
{
    public sealed class ColorWheel : IDisposable
    {
        /// <summary>
        /// Written by Ken Getz
        /// </summary>
        private Graphics _g;
        private Region _colorRegion;
        private Region _brightnessRegion;
        private Bitmap _colorImage;

        public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs e);
        public ColorChangedEventHandler ColorChanged;

        // Keep track of the current mouse state. 
        public enum MouseState
        {
            MouseUp,
            ClickOnColor,
            DragInColor,
            ClickOnBrightness,
            DragInBrightness,
            ClickOutsideRegion,
            DragOutsideRegion,
        }
        private MouseState _currentState = MouseState.MouseUp;

        private const double DEGREES_PER_RADIAN = 180.0 / Math.PI;
        private const int COLOR_COUNT = 6 * 256;

        private Point _centerPoint;
        private int _radius;

        private Rectangle _colorRect;
        private Rectangle _brightnessRect;
        private Rectangle _selectedColorRect;
        private int _brightnessCursorX;
        private double _brightnessScaling;

        private HSV _HSV = new HSV(0, 0, 0);
        private RGB _RGB => _HSV.toRGB();
        public Color Color => _HSV.toColor();

        // Locations for the two "pointers" on the form.
        private Point _colorPointer;
        private Point _brightnessPointer;

        private int _brightness => _HSV.Value;
        private int _brightnessMin;
        private int _brightnessMax;

        protected void OnColorChanged(RGB RGB, HSV HSV)
        {
            ColorChanged(this, new ColorChangedEventArgs(RGB, HSV));
        }

        public ColorWheel(Rectangle clrRect, Rectangle brightRect, Rectangle selectedClrRect, HSV defaultClr)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                _colorRect = clrRect;
                _brightnessRect = brightRect;
                _selectedColorRect = selectedClrRect;

                _radius = Math.Min(_colorRect.Width, _colorRect.Height) / 2;
                _centerPoint = _colorRect.Location;
                _centerPoint.Offset(_radius, _radius);
                _colorPointer = _centerPoint;

                path.AddEllipse(_colorRect);
                _colorRegion = new Region(path);

                _brightnessMin = _brightnessRect.Top;
                _brightnessMax = _brightnessRect.Bottom;

                path.AddRectangle(new Rectangle(_brightnessRect.Left, _brightnessRect.Top - 10, _brightnessRect.Width + 10, _brightnessRect.Height + 20));
                _brightnessRegion = new Region(path);

                _brightnessCursorX = _brightnessRect.Left + _brightnessRect.Width;
                _brightnessScaling = (double)255 / (_brightnessMax - _brightnessMin);

                _brightnessPointer = new Point(_brightnessCursorX, _brightnessMax);

                CreateGradient();
                UpdatePointers(defaultClr);
            }
        }

        private void CreateGradient()
        {
            using (var pgb = new PathGradientBrush(GetPoints(_radius, new Point(_radius, _radius))))
            {
                pgb.CenterColor = Color.White;
                pgb.CenterPoint = new PointF(_radius, _radius);
                pgb.SurroundColors = GetColors();

                _colorImage = new Bitmap(
                    _colorRect.Width, _colorRect.Height,
                    PixelFormat.Format32bppArgb);

                using (var newGraphics = Graphics.FromImage(_colorImage))
                {
                    newGraphics.FillEllipse(pgb, 0, 0,
                        _colorRect.Width, _colorRect.Height);
                }
            }
        }

        void IDisposable.Dispose()
        {
            // Dispose of graphic resources
            if (_colorImage != null)
                _colorImage.Dispose();
            if (_colorRegion != null)
                _colorRegion.Dispose();
            if (_brightnessRegion != null)
                _brightnessRegion.Dispose();
            if (_g != null)
                _g.Dispose();
        }

        public void SetMouseUp()
        {
            _currentState = MouseState.MouseUp;
        }

        public void Draw(Graphics g, RGB RGB)
        {
            Draw(g, new HSV(RGB));
        }

        public void Draw(Graphics g, HSV hsv)
        {
            _g = g;
            _HSV = hsv;
            UpdatePointers(_HSV);
            UpdateDisplay();
        }

        public void Draw(Graphics g, Point mousePoint)
        {
            _g = g;
            if (_currentState == MouseState.MouseUp && !mousePoint.IsEmpty)
            {
                if (_colorRegion.IsVisible(mousePoint))
                {
                    _currentState = MouseState.ClickOnColor;
                }
                else if (_brightnessRegion.IsVisible(mousePoint))
                {
                    _currentState = MouseState.ClickOnBrightness;
                }
                else
                {
                    _currentState = MouseState.ClickOutsideRegion;
                }
            }

            switch (_currentState)
            {
                case MouseState.ClickOnBrightness:
                case MouseState.DragInBrightness:
                    BrightnessSliderUpdate(mousePoint);
                    _currentState = MouseState.DragInBrightness;
                    break;

                case MouseState.ClickOnColor:
                case MouseState.DragInColor:
                    ColorWheelUpdate(mousePoint);
                    _currentState = MouseState.DragInColor;
                    break;
                case MouseState.MouseUp:
                case MouseState.ClickOutsideRegion:
                case MouseState.DragOutsideRegion:
                    _currentState = MouseState.DragOutsideRegion;
                    break;
            }

            UpdateDisplay();
            OnColorChanged(_RGB, _HSV);
        }

        private void BrightnessSliderUpdate(Point mousePoint)
        {
            var clampedY = mousePoint.Y.Clamp(_brightnessMin, _brightnessMax);
            _brightnessPointer = new Point(_brightnessCursorX, clampedY);
            _HSV.Value = (int)((_brightnessMax - clampedY) * _brightnessScaling);
        }

        private void ColorWheelUpdate(Point mousePoint)
        {
            _colorPointer = mousePoint;
            var delta = new Point(mousePoint.X - _centerPoint.X, mousePoint.Y - _centerPoint.Y);
            var degrees = CalcDegrees(delta);
            var distance = Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y) / _radius;
            if (_currentState == MouseState.DragInColor)
            {
                if (distance > 1)
                {
                    distance = 1;
                    _colorPointer = GetPoint(degrees, _radius, _centerPoint);
                }
            }
            _HSV = new HSV(degrees * 255 / 360, (int)(distance * 255), _brightness);
        }

        private void UpdatePointers(HSV HSV)
        {
            _colorPointer = GetPoint(
                (double)HSV.Hue / 255 * 360,
                (double)HSV.Saturation / 255 * _radius,
                _centerPoint);

            _brightnessPointer = new Point(_brightnessCursorX, (int)(_brightnessMax - _brightness / _brightnessScaling));
        }

        private int CalcDegrees(Point pt)
        {
            int degrees;

            if (pt.X == 0)
            {
                if (pt.Y > 0)
                {
                    degrees = 270;
                }
                else
                {
                    degrees = 90;
                }
            }
            else
            {
                degrees = (int)(-Math.Atan((double)pt.Y / pt.X) * DEGREES_PER_RADIAN);
                if (pt.X < 0)
                {
                    degrees += 180;
                }

                degrees = (degrees + 360) % 360;
            }
            return degrees;
        }

        private Color[] GetColors()
        {
            var Colors = new Color[COLOR_COUNT];

            for (var i = 0; i <= COLOR_COUNT - 1; i++)
            {
                var hue = (int)((double)(i * 255) / COLOR_COUNT);
                var hsv = new HSV(hue, 255, 255).toColor();
                Colors[i] = Color.FromArgb(hsv.R, hsv.G, hsv.B);
            }
            return Colors;
        }

        private Point[] GetPoints(double radius, Point centerPoint)
        {
            var Points = new Point[COLOR_COUNT];

            for (var i = 0; i <= COLOR_COUNT - 1; i++)
                Points[i] = GetPoint((double)(i * 360) / COLOR_COUNT, radius, centerPoint);
            return Points;
        }

        private Point GetPoint(double degrees, double radius, Point centerPoint)
        {
            double radians = degrees / DEGREES_PER_RADIAN;

            return new Point((int)(centerPoint.X + Math.Floor(radius * Math.Cos(radians))),
                             (int)(centerPoint.Y - Math.Floor(radius * Math.Sin(radians))));
        }

        private void UpdateDisplay()
        {
            using (Brush selectedBrush = new SolidBrush(Color))
            {
                _g.DrawImage(_colorImage, _colorRect);
                _g.FillRectangle(selectedBrush, _selectedColorRect);

                DrawLinearGradient(_RGB);
                DrawColorPointer(_colorPointer);
                DrawBrightnessPointer(_brightnessPointer);
            }
        }

        private void DrawLinearGradient(RGB TopColor)
        {
            using (var lgb = new LinearGradientBrush(_brightnessRect, TopColor.toColor(), Color.Black, LinearGradientMode.Vertical))
            {
                _g.FillRectangle(lgb, _brightnessRect);
            }
        }

        private void DrawColorPointer(Point pt)
        {
            const int SIZE = 3;
            _g.DrawRectangle(Pens.Black, pt.X - SIZE, pt.Y - SIZE, SIZE * 2, SIZE * 2);
        }

        private void DrawBrightnessPointer(Point pt)
        {
            const int HEIGHT = 10;
            const int WIDTH = 7;

            var Points = new Point[3];
            Points[0] = pt;
            Points[1] = new Point(pt.X + WIDTH, pt.Y + HEIGHT / 2);
            Points[2] = new Point(pt.X + WIDTH, pt.Y - HEIGHT / 2);
            _g.FillPolygon(Brushes.Black, Points);
        }
    }

}