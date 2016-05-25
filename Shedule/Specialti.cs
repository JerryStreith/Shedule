using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule
{
    public class Specialti
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("faculty")]
        public string faculty { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
