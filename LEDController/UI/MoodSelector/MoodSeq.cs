using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using LEDController.Utils;

namespace LEDController.UI
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MoodSeq
    {
        [JsonProperty]
        public String Name = " ";

        [JsonProperty]
        public List<DRColor.RGB> Color_List = new List<DRColor.RGB>();

        public MoodSeq()
        {
        }

        public MoodSeq(DRColor.RGB rgb)
        {
            Color_List.Add(rgb);

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
