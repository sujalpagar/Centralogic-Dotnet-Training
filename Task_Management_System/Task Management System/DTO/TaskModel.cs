using Newtonsoft.Json;

namespace Task_Management_System.DTO
{
    public class TaskModel
    {
        [JsonProperty(PropertyName = "taskId", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskId { get; set; }

        [JsonProperty(PropertyName = "taskName", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskName { get; set; }

        [JsonProperty(PropertyName = "taskDesc", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskDesc { get; set; }
    }
}
