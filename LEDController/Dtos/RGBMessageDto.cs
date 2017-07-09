using System.Collections.Generic;
using LEDController.Utils;
using Newtonsoft.Json;

namespace LEDController.Dtos
{

    public class RGBMessageDto
    {
        [JsonProperty("pixels")]
        public IList<RGBData> pixels { get; set; }

        public RGBMessageDto()
        {
            pixels = new List<RGBData>();
        }
    }

    public class RGBData
    {
        [JsonProperty("channel")]
        public int channel { get; set; }

        [JsonProperty("pos")]
        public int position { get; set; }

        [JsonProperty("red")]
        public int red { get; set; }

        [JsonProperty("green")]
        public int green { get; set; }

        [JsonProperty("blue")]
        public int blue { get; set; }
    }
    
}
