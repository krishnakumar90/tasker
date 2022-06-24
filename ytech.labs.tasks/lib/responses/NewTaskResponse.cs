using System;
using Newtonsoft.Json;
using ytech.labs.tasks.lib.Struct;

namespace ytech.labs.tasks.lib.responses
{
    public class NewTaskResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        public NewTaskResponse()
        {

        }

        public NewTaskResponse(TaskDTO task)
        {
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
        }
    }
}

