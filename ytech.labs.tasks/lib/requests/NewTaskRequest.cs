using System;
using Newtonsoft.Json;

namespace ytech.labs.tasks.lib.requests
{
    public class NewTaskRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

