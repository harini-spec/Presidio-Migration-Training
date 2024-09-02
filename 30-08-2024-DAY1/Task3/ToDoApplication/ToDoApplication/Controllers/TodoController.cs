using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Exceptions;
using ToDoApplication.Models;
using ToDoApplication.Models.DTO;
using ToDoApplication.Services.Interfaces;

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
            private readonly IToDoService _ToDoService;

            public TodoController(IToDoService TodoService)
            {
                _ToDoService = TodoService;
            }

            [HttpPost("AddToDo")]
            [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<bool>> AddToDo(ToDoDTO toDoDTO)
            {
                try
                {
                    var result = await _ToDoService.InsertToDo(toDoDTO);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("SelectToDoById")]
            [ProducesResponseType(typeof(ToDo), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<ToDo>> SelectToDoById(int TodoId)
            {
                try
                {
                    var result = await _ToDoService.SelectToDoById(TodoId);
                    return Ok(result);
                }
                catch (EntityNotFoundException enf)
                {
                    return NotFound(enf.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("SelectToDosByUserId")]
            [ProducesResponseType(typeof(List<ToDo>), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<List<ToDo>>> SelectToDosByUserId(int UserId)
            {
                try
                {
                    var result = await _ToDoService.SelectAllToDosOfUser(UserId);
                    return Ok(result);
                }
                catch (EntityNotFoundException enf)
                {
                    return NotFound(enf.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete("DeleteToDoById")]
            [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<bool>> DeleteToDoById(int ToDoId)
            {
                try
                {
                    var result = await _ToDoService.DeleteToDoById(ToDoId);
                    return Ok(result);
                }
                catch (EntityNotFoundException enf)
                {
                    return NotFound(enf.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut("UpdateToDo")]
            [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<bool>> UpdateToDo(UpdateToDoDTO todo)
            {
                try
                {
                    var result = await _ToDoService.UpdateToDo(todo);
                    return Ok(result);
                }
                catch (EntityNotFoundException enf)
                {
                    return NotFound(enf.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    }
}
