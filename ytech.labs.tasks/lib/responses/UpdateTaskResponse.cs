using System;
using ytech.labs.tasks.lib.Struct;

namespace ytech.labs.tasks.lib.responses
{
    public class UpdateTaskResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public UpdateTaskResponse()
        {

        }
        public UpdateTaskResponse(TaskDTO task)
        {
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            IsCompleted = task.IsCompleted;
        }
    }
}

