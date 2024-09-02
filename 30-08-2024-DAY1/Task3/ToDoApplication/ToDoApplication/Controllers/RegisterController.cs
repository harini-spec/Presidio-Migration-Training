using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Models.DTO;
using ToDoApplication.Services.Interfaces;

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly IRegisterService _RegisterService;

        public RegisterController(IRegisterService registerService)
        {
            _RegisterService = registerService;
        }

        [HttpPost("RegisterEmployee")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> AuthenticateCard(UserDTO userDTO)
        {
            try
            {
                var result = await _RegisterService.RegisterEmployee(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
