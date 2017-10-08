using LEDController.Interfaces;
using LEDController.Utils;
using System;

namespace LEDController.Manager
{
    public class PaletteManager : IPaletteManager
    {
        private MyColor.RGB[] _palette;

        public PaletteManager(int size)
        {
            if(size < 1)
            {
                throw new ArgumentNullException("size");
            }

            _palette = new MyColor.RGB[size];
        }

        public MyColor.RGB GetColor(int index = 0)
        {
            if(index > _palette.Length)
            {
                //Maybe exception
                return _palette[0];
            }

            return _palette[index];
        }

        public void PopulatePalette(IColorGenerator colorGenerator)
        {
            for(var i = 0; i < _palette.Length; i++)
            {
                _palette[i] = colorGenerator.getNextColor();
            }
        }
    }
}
