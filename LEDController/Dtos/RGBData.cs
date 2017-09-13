using Newtonsoft.Json;

namespace LEDController.Dtos
{
    public class RGBData
    {
        [JsonProperty("channel")]
        public int Channel { get; set; }

        [JsonProperty("pos")]
        public int Position { get; set; }

        [JsonProperty("red")]
        public int Red { get; set; }

        [JsonProperty("green")]
        public int Green { get; set; }

        [JsonProperty("blue")]
        public int Blue { get; set; }
    }
}
