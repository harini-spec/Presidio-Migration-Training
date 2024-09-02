using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using ToDoApplication.Exceptions;
using ToDoApplication.Models.DTO;
using ToDoApplication.Services.Interfaces;

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _LoginService;

        public LoginController(ILoginService loginService)
        {
            _LoginService = loginService;
        }

        [HttpPost("LoginEmployee")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> AuthenticateCard(LoginDTO loginDTO)
        {
                try
                {
                    var result = await _LoginService.Authenticate(loginDTO);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
        }
    }
}
