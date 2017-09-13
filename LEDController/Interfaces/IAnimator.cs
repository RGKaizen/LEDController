using LEDController.Utils;
using System.Collections.Generic;

namespace LEDController.Interfaces
{
    public interface IAnimator
    {
        IList<MyColor.RGB> palette { get; set; }

        MyColor.RGB[] getNextFrame();
    }
}