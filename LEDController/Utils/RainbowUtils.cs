namespace LEDController.Utils
{
    public static class RainbowUtils
    {
        public static MyColor.RGB[] createEmptyArray(int count)
        {
            var array = new MyColor.RGB[count];
            for (var i = 0; i < count; i++)
            {
                array[i] = new MyColor.RGB(0, 0, 0);
            }
            return array;
        }
    }
}
