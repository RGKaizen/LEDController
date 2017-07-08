using System.Collections.Generic;

namespace DoubleRainbow.Dtos
{
    public class RGBMessageDto
    {
        public IEnumerable<RGBData> pixels { get; set; }
    }

    public class RGBData
    {
        public int channel { get; set; }

        public int position { get; set; }

        public DRColor.RGB color { get; set; }
    }
}
