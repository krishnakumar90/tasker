using System;
using MongoDB.Bson;
using ytech.labs.tasks.lib.core;
using ytech.labs.tasks.lib.entities;
using ytech.labs.tasks.lib.interfaces;
using ytech.labs.tasks.lib.requests;
using ytech.labs.tasks.lib.Struct;

namespace ytech.labs.tasks.lib.service
{
    public class TaskService
    {
        IMongoRepository<TaskDocument> _repository;

        public TaskService(IMongoDbConfig mongoDbConfig)
        {
            _repository = new MongoRepository<TaskDocument>(mongoDbConfig);
        }

        public async Task<IEnumerable<TaskDTO>> GetAll()
        {
            return _repository.AsQueryable().ToList().Select(x => new TaskDTO(x));
        }

        public async Task<TaskDTO> Get(string id)
        {
            var task = await _repository.FindByIdAsync(id);
            return new TaskDTO(task);
        }

        public async Task<TaskDTO> AddNew(NewTaskRequest request)
        {
            var newTask = new TaskDocument
            {
                Id = ObjectId.GenerateNewId(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false,
                Created = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };
            await _repository.InsertOneAsync(newTask);

            return new TaskDTO(newTask);
        }

        public async Task<TaskDTO> Update(string id, UpdateTaskRequest request)
        {
            var task = await _repository.FindByIdAsync(id);
            task.Title = request.Title;
            task.Description = request.Description;
            task.IsCompleted = request.IsCompleted;
            await _repository.ReplaceOneAsync(task);
            return new TaskDTO(task);
        }

        public async Task<bool> Delete(string id)
        {
            await _repository.DeleteByIdAsync(id);
            return true;
        }

        public async Task<bool> MarkAsCompleted(string taskId)
        {
            var task = await _repository.FindByIdAsync(taskId);
            task.LastModified = DateTime.UtcNow;
            task.IsCompleted = true;
            await _repository.ReplaceOneAsync(task);
            return true;
        }
    }
}

