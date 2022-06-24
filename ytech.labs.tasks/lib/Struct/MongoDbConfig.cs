using System;
using ytech.labs.tasks.lib.interfaces;

namespace ytech.labs.tasks.lib.Struct
{
    public class MongoDbConfig : IMongoDbConfig
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}

