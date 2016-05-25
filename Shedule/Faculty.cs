using Newtonsoft.Json;
namespace Shedule
{
    class Faculty
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
