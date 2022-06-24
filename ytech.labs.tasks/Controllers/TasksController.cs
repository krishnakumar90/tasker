using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ytech.labs.tasks.lib.entities;
using ytech.labs.tasks.lib.requests;
using ytech.labs.tasks.lib.responses;
using ytech.labs.tasks.lib.service;
using ytech.labs.tasks.lib.Struct;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ytech.labs.tasks.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : BaseController
    {
        TaskService _service;
        public TasksController([FromServices] IOptionsSnapshot<MongoDbConfig> dbConfig) : base(dbConfig)
        {
            _service = new TaskService(dbConfig.Value);
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allTasks =await _service.GetAll();
            return new OkObjectResult(allTasks);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var task = await _service.Get(id);
            if (task==null)
            {
                return new NotFoundObjectResult("Task not found");
            }
            return new OkObjectResult(task);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewTaskRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            var newTask = await _service.AddNew(request);
            return new OkObjectResult(new NewTaskResponse(newTask));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]UpdateTaskRequest request )
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(request);
            var task = await _service.Update(id, request);
            return new OkObjectResult(new UpdateTaskResponse(task));
        }

        // PUT api/values/5
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Put(string id)
        {
            await _service.MarkAsCompleted(id);
            return new OkObjectResult(true);
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            ArgumentNullException.ThrowIfNull(id);
            await _service.Delete(id);
            return new OkObjectResult(true);
        }
    }
}

