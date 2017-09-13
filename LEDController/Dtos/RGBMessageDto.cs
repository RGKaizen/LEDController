using System.Collections.Generic;
using Newtonsoft.Json;

namespace LEDController.Dtos
{
    public class RGBMessageDto
    {
        [JsonProperty("pixels")]
        public IList<RGBData> Pixels { get; set; }

        public RGBMessageDto()
        {
            Pixels = new List<RGBData>();
        }
    }  
}
