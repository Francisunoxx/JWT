using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace jwt
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Authenticate authenticate)
        {
            var user = _userService.Authenticate(authenticate.Username, authenticate.Password);

            HttpContext.Response.Cookies.Append(
            "Refresh-Token",
            "anything",
            new CookieOptions
            {
                HttpOnly = true
            });

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [Authorize]
        [HttpGet("refresh")]
        public IActionResult Refresh()
        {
            var token = Request.Cookies["Refresh-Token"];
            var user = _userService.Authenticate();

            if (token == "anything")
            {
                return Ok(user);
            }

            return BadRequest(new { message = "Invalid" });
        }

        [Authorize]
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("Test");
        }
    }
}