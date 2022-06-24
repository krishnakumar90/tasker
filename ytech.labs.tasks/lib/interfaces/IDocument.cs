using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ytech.labs.tasks.lib.interfaces
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("id")]
        ObjectId Id { get; set; }

        [BsonElement("created")]
        DateTime Created { get; set; }
        [BsonElement("lastmodified")]
        DateTime LastModified { get; set; }
        [BsonElement("createdby")]
        ObjectId CreatedBy { get; set; }
        [BsonElement("lastmodifiedby")]
        ObjectId LastModifiedBy { get; set; }
    }
}

