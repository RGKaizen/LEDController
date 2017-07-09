namespace LEDController.Utils
{
    public static class RainbowUtils
    {
        public static void fillBoth(DRColor.RGB rgb)
        {
        }

        public static void update()
        {
        }


        public static void TurnOff()
        {
        }

        public static DRColor.RGB increaseBrightness(DRColor.RGB rgb, int amt)
        {
            DRColor.HSV hsv = new DRColor.HSV(rgb);
            hsv.Value = hsv.Value + amt > 256 ? 256 : hsv.Value + amt;
            return new DRColor.RGB(hsv);
        }

    }
}
