using Newtonsoft.Json;

namespace Shedule
{
    public class Sсhedule
    {
        [JsonProperty("Понеділок")]
        public Day[] Monday;

        [JsonProperty("Вівторок")]
        public Day[] Tuesday;

        [JsonProperty("Середа")]
        public Day[] Wednesday;

        [JsonProperty("Четвер")]
        public Day[] Thursday;

        [JsonProperty("П'ятниця")]
        public Day[] Friday;

        [JsonProperty("Субота")]
        public Day[] Saturday;
    }
}
