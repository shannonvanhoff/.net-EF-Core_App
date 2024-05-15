using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.Services.Models;
using Webapi.Services.Services.HTaskservice;


namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HTaskController : ControllerBase
    {
        private readonly IHTaskService _taskService;

        public HTaskController(IHTaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskDto> AddTask([FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTask = _taskService.AddTask(taskDto);
            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.TaskId }, newTask);
        }

        [HttpPut("{id}")]
        public ActionResult<TaskDto> UpdateTask(int id, [FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTask = _taskService.UpdateTask(id, taskDto);
            if (updatedTask == null)
            {
                return NotFound();
            }

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var deleted = _taskService.DeleteTaskById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
