using Microsoft.AspNetCore.Mvc;
using ToDo.Repositories;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        //add Task
        [HttpPost("addTask")]
        public async Task<IActionResult> AddTask(Models.Task task)
        {
            var TaskToAdd = new Models.Task
            {
                ExpiryDateTime = task.ExpiryDateTime,
                Title = task.Title,
                Description = task.Description,
                PercentComplete = task.PercentComplete,
            };
            var addItem = await _taskRepository.AddTask(TaskToAdd);
            //return status 200
            return Ok();
        }
        // get all tasks
        [HttpGet("getAllTasks")]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }
        [HttpGet("getSpecificTask/{id}")]
        public async Task<ActionResult<Models.Task>> GetTaskById(int id)
        {
            var specificTask = await _taskRepository.GetTaskById(id);
            if (specificTask!=null)
            {
                return Ok(specificTask);
            }else
            {
                //specific task not exist
                return BadRequest("Task not exist");
            }
        }
    }
}
