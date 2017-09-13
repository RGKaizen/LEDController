using System;
using LEDController.Utils;

namespace LEDController.UI
{
    public class ColorChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Written by Ken Getz
        /// </summary>
        private MyColor.RGB mRGB;
        private MyColor.HSV mHSV;

        public ColorChangedEventArgs(MyColor.RGB RGB, MyColor.HSV HSV)
        {
            mRGB = RGB;
            mHSV = HSV;
        }

        public MyColor.RGB RGB
        {
            get
            {
                return mRGB;
            }
        }

        public MyColor.HSV HSV
        {
            get
            {
                return mHSV;
            }
        }
    }
}