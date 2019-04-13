using ProjectManagerApi.Entities.EntityModels;

namespace ProjectManagerApi.Models
{
    public class TaskUpdateResponse
    {
        public TaskModel Task { get; set; }
        public Status Status { get; set; }
    }
}