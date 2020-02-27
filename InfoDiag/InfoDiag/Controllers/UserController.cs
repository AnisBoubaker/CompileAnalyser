using InfoDiag.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace InfoDiag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User/all
        [HttpGet("all")]
        public IActionResult Get()
        {
            var user = this.UserDto();

            if (user == null || user.Role != Constants.Enums.UserRole.Admin)
            {
                return Unauthorized();
            }

            return Ok(_userService.GetAll().Value);
        }
    }
}
