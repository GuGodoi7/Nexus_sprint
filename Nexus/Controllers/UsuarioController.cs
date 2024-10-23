using _NEXUS.Models;
using _NEXUS.Repository;
using _NEXUS.Service.InterfacesService;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Nexus.Controllers
    [ApiController]
[Tags("Tasks")]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly TaskUseCase _taskUseCase;

    public TasksController(TaskUseCase taskUseCase)
    {
        _taskUseCase = taskUseCase;
    }

    /// <summary>
    /// Retrieves all tasks
    /// </summary>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public ActionResult<IEnumerable<Task>> GetAll()
    {
        var tasks = _taskUseCase.GetAllTasks();

        return Ok(tasks);
    }

    /// <summary>
    /// Retrieves a specific task by ID
    /// </summary>
    /// <param name="id">The ID of the task</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Task), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public ActionResult<Task> GetById(string id)
    {
        var task = _taskUseCase.GetTaskById(id);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    /// <summary>
    /// Create a new task
    /// </summary>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public IActionResult CreateTask([FromBody] CreateTaskRequest request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Description))
        {
            return BadRequest("Title and Description are required.");
        }

        var task = new Task
        {
            Title = request.Title,
            Description = request.Description
        };

        _taskUseCase.AddTask(task);

        return Created();
    }

    /// <summary>
    /// Updates an existing task
    /// </summary>
    /// <param name="id">The ID of the task</param>
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public IActionResult Update(string id, [FromBody] CreateTaskRequest request)
    {
        var taskToUpdate = _taskUseCase.GetTaskById(id);

        if (taskToUpdate == null)
        {
            return NotFound();
        }

        taskToUpdate.Title = request.Title;
        taskToUpdate.Description = request.Description;

        _taskUseCase.UpdateTask(taskToUpdate);

        return NoContent();
    }

    /// <summary>
    /// Deletes a task by id
    /// </summary>
    /// <param name="id">The ID of the task</param>
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public IActionResult Delete(string id)
    {
        var taskToDelete = _taskUseCase.GetTaskById(id);

        if (taskToDelete == null)
        {
            return NotFound();
        }

        _taskUseCase.DeleteTask(id);

        return NoContent();
    }

    /// <summary>
    /// Marks a task as complete
    /// </summary>
    /// <param name="id">The ID of the task</param>
    [HttpPost("{id}/complete")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public IActionResult MarkAsComplete(string id)
    {
        var task = _taskUseCase.GetTaskById(id);

        if (task == null)
        {
            return NotFound();
        }

        task.IsCompleted = true;

        _taskUseCase.UpdateTask(task);

        return Ok();
    }
}
}
