using Newtonsoft.Json;
namespace Shedule
{
    public class Faculty
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
