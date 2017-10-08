using LEDController.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.Interfaces
{
    public interface IPaletteManager
    {
        MyColor.RGB GetColor(int index = 0);

        void PopulatePalette(IColorGenerator colorGenerator);
    }
}
