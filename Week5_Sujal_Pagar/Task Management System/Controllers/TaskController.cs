using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Task_Management_System.DTO;
using Task_Management_System.Entity;
using Task = Task_Management_System.Entity.Task;

namespace Task_Management_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        //Configuration
        public string URI = "https://localhost:8081";
        public string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public string DatabaseName = "TasksDB";
        public string ContainerName = "Task";
        public Container container;

        //Constructor
        public TaskController()
        {
            container = GetContainer();
        }

        private Container GetContainer()
        {
            CosmosClient cosmosClient = new CosmosClient(URI,PrimaryKey);
            Database db = cosmosClient.GetDatabase(DatabaseName);
            Container container = db.GetContainer(ContainerName);
            return container;
        }

        //1]Add Task
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskModel taskModel)
        {
            //convert TaskModel to Task Entity
            Task task = new Entity.Task();
            /*task.UId = taskModel.TaskId;*/
            task.TaskName = taskModel.TaskName;
            task.TaskDesc = taskModel.TaskDesc;

            //assign mandatory fields 
            task.Id = Guid.NewGuid().ToString();
            task.UId = task.Id;
            task.DocumentType = "task";
            task.CreatedBy = "Users Id"; //show user id who created this data
            task.CreatedByName = "User Name"; //show user name who created this data
            task.CreatedOn = DateTime.Now;
            task.UpdatedBy = "User Id"; //show user id who update this data
            task.UpdatedByName = "User Name"; //show user name who updated this data
            task.Version = 1;
            task.Active = true;
            task.Archieved = false;

            //add data in database
            task = await container.CreateItemAsync(task);

            //return to UI
            TaskModel model = new TaskModel();
            model.TaskId = task.UId;
            model.TaskName = task.TaskName; 
            model.TaskDesc = task.TaskDesc;

            return Ok(model);
        }

        //2] Get All Task
        [HttpPost]
        public async Task<IActionResult> GetAllTasks()
        {
            //get all task
            var task = container.GetItemLinqQueryable<Task>(true).Where(q => q.DocumentType=="task" && q.Archieved==false && q.Active==true).AsEnumerable().ToList();
            //map all task data
            List<TaskModel> model = new List<TaskModel>();
            foreach (var item in task)
            {
                TaskModel taskModel = new TaskModel();
                taskModel.TaskId = item.Id;
                taskModel.TaskName = item.TaskName;
                taskModel.TaskDesc = item.TaskDesc;

                model.Add(taskModel);
            }
            return Ok(model);
        }

        //3] Get Task By Id
        [HttpPost]
        public async Task<IActionResult> GetTaskById(string taskId)
        {
            //get task details
            var task = container.GetItemLinqQueryable<Task>(true).Where(q => q.Id == taskId && q.Archieved == false && q.Active == true).AsEnumerable().FirstOrDefault(); 
            //map task to task model
            TaskModel tm = new TaskModel();
            tm.TaskId = task.Id;
            tm.TaskName = task.TaskName;
            tm.TaskDesc = task.TaskDesc;
            return Ok(tm);
        }

        //4] Update Task
        [HttpPost]
        public async Task<IActionResult> UpdateTask(TaskModel taskModel)
        {
            //get task 
            var existingTask = container.GetItemLinqQueryable<Task>(true).Where(q => q.UId==taskModel.TaskId && q.DocumentType=="task" && q.Active==true && q.Archieved==false).AsEnumerable().FirstOrDefault();
            existingTask.Archieved = true;
            container.ReplaceItemAsync(existingTask, existingTask.Id);

            //assign val to mandatory field
            existingTask.Id = Guid.NewGuid().ToString();
            existingTask.UpdatedBy = "User ID";
            existingTask.UpdatedByName = "User Name";
            existingTask.UpdatedOn = DateTime.Now;
            existingTask.Version = existingTask.Version + 1;
            existingTask.Active = true;
            existingTask.Archieved = false;

            //assign UI Field
            existingTask.TaskName = taskModel.TaskName;
            existingTask.TaskDesc = taskModel.TaskDesc;

            //add item in database
            existingTask = await container.CreateItemAsync(existingTask);

            //return data in UI
            TaskModel model = new TaskModel();
            model.TaskId = existingTask.Id;
            model.TaskName = existingTask.TaskName;
            model.TaskDesc = taskModel.TaskDesc;
            return Ok(model);
        }

        //5] Delete Task
        [HttpPost]
        public async Task<IActionResult> DeleteTask(string taskId)
        {
            //get task 
            var myTask = container.GetItemLinqQueryable<Task>(true).Where(q => q.UId == taskId && q.DocumentType == "task" && q.Active == true && q.Archieved == false).AsEnumerable().FirstOrDefault();

            //change details and Hide
            myTask.Active = false;
            await container.ReplaceItemAsync(myTask, myTask.Id);
            return Ok(true);
        }
    }
}
