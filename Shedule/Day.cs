using Newtonsoft.Json;

namespace Shedule
{
    public class Day
    {
        [JsonProperty("num")]
        public string num { get; set; }

        [JsonProperty("subject_title")]
        public string subject_title { get; set; }

        [JsonProperty("t1_chair")]
        public string t1_chair { get; set; }

        [JsonProperty("t1_last_name")]
        public string t1_last_name { get; set; }

        [JsonProperty("t1_first_name")]
        public string t1_first_name { get; set; }

        [JsonProperty("t1_middle_name")]
        public string t1_middle_name { get; set; }

        [JsonProperty("t2_chair")]
        public string t2_chair { get; set; }

        [JsonProperty("t2_last_name")]
        public string t2_last_name { get; set; }

        [JsonProperty("t2_first_name")]
        public string t2_first_name { get; set; }

        [JsonProperty("t2_middle_name")]
        public string t2_middle_name { get; set; }

        [JsonProperty("classroom")]
        public string classroom { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}
