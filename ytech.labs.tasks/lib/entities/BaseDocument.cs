using System;
using MongoDB.Bson;
using ytech.labs.tasks.lib.interfaces;

namespace ytech.labs.tasks.lib.entities
{
    public abstract class BaseDocument:IDocument
    {
        public ObjectId Id { get ; set ; }
        public DateTime Created { get ; set ; }
        public DateTime LastModified { get ; set ; }
        public ObjectId CreatedBy { get ; set ; }
        public ObjectId LastModifiedBy { get ; set ; }
    }
}

