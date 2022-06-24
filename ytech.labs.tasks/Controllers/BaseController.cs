using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ytech.labs.tasks.lib.core;
using ytech.labs.tasks.lib.interfaces;
using ytech.labs.tasks.lib.Struct;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ytech.labs.tasks.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        MongoDbConfig _dbConfig;
        public BaseController([FromServices] IOptionsSnapshot<MongoDbConfig> dbConfig)
        {
            _dbConfig = dbConfig.Value;
        }

        protected virtual IMongoRepository<T> CreateRepository<T>() where T:IDocument
        {
            return new MongoRepository<T>(_dbConfig.ConnectionString, _dbConfig.Database);
        }
    }
}

