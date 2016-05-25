﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule
{
    public class Group
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("specialty")]
        public string specialty { get; set; }
    }
}
