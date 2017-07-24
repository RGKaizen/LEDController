namespace LEDController.Utils
{
    public static class RainbowUtils
    {
        public static DRColor.RGB[] createEmptyArray(int count)
        {
            var array = new DRColor.RGB[count];
            for (var i = 0; i < count; i++)
            {
                array[i] = new DRColor.RGB(0, 0, 0);
            }
            return array;
        }


        public static DRColor.RGB increaseBrightness(DRColor.RGB rgb, int amt)
        {
            DRColor.HSV hsv = new DRColor.HSV(rgb);
            hsv.Value = hsv.Value + amt > 256 ? 256 : hsv.Value + amt;
            return new DRColor.RGB(hsv);
        }

    }
}
