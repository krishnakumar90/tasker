using System;
using MongoDB.Bson.Serialization.Attributes;
using ytech.labs.tasks.lib.core;

namespace ytech.labs.tasks.lib.entities
{
    [BsonCollection("tasks")]
    public class TaskDocument : BaseDocument
    {
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("iscompleted")]
        public bool IsCompleted { get; set; }
    }
}

