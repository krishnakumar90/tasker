using System;
using ytech.labs.tasks.lib.entities;

namespace ytech.labs.tasks.lib.Struct
{
    public class TaskDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public TaskDTO(TaskDocument doc)
        {
            if (doc != null)
            {
                Id = doc.Id.ToString();
                Title = doc.Title;
                Description = doc.Description;
                IsCompleted = doc.IsCompleted;
            }
        }
    }
}

